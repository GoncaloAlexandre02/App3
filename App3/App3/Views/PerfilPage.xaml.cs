using App3.Models;
using App3.Services;
using Plugin.Media.Abstractions;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using Xamarin.CommunityToolkit.Extensions;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace App3.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class PerfilPage : ContentPage
    {
        RestService restService;
        User user;
        private MediaFile _mediaFile;
        private Image image;

        public PerfilPage()
        {
            InitializeComponent();
            /*Navigation.ShowPopup(new PopUpLoading());
            restService = new RestService();
            AtualizaDados();*/
        }
        protected override void OnAppearing()
        {
            Navigation.ShowPopup(new PopUpLoading());
            restService = new RestService();
            AtualizaDados();
        }
        async void AtualizaDados()
        {
            try
            {
                user = await restService.GetUserAsync();

                tNome.Text = user.Nome.ToString() + " " + user.Apelido.ToString();
                tEmail.Text = user.Email.ToString();
                tTele.Text = user.Telefone?.ToString();
                tDt.Text = user.Dtnasc?.ToString();

                var imageSource = ImageSource.FromStream(() => new MemoryStream(user.ImageSource));
                Imagem.Source = imageSource;
            }
            catch (NullReferenceException ex)
            {
                await Navigation.PushAsync(new HomeLayout2());
                Console.WriteLine(ex.Message);
            }
            /*try
            {
                var client = new HttpClient(DependencyService.Get<IHttpClientHandlerService>().GetInsecureHandler());

                var response = await client.GetAsync("http://tze.ddns.net:8070/api/getImage?img=" + user.Imagem.ToString());
                byte[] image = await response.Content.ReadAsByteArrayAsync();
                var imageSource = ImageSource.FromStream(() => new MemoryStream(image));
                Imagem.Source = imageSource;
            }
            catch (NullReferenceException ex)
            {

                Console.WriteLine(ex.Message);
            }*/

        }
        async void UploadFile_Clicked(System.Object sender, System.EventArgs e)
        {
            var file = await MediaPicker.PickPhotoAsync();

            if (file == null)
                return;

            var content = new MultipartFormDataContent();
            content.Add(new StreamContent(await file.OpenReadAsync()), "file", file.FileName);

            var httpClient = new HttpClient(DependencyService.Get<IHttpClientHandlerService>().GetInsecureHandler());
            httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", await SecureStorage.GetAsync("tokenuser"));

            var response = await httpClient.PostAsync("https://10.0.2.2:7004/api/Files/Upload?id=" + await SecureStorage.GetAsync("iduser"), content);

            await this.DisplayToastAsync(response.StatusCode.ToString(), 3000);

        }
        async Task<String> UploadFile()
        {
            var file = await MediaPicker.PickPhotoAsync();

            if (file == null)
                return null;

            var content = new MultipartFormDataContent();
            content.Add(new StreamContent(await file.OpenReadAsync()), "file", file.FileName);

            var httpClient = new HttpClient(DependencyService.Get<IHttpClientHandlerService>().GetInsecureHandler());
            httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", await SecureStorage.GetAsync("tokenuser"));
            var id = await SecureStorage.GetAsync("iduser");
            var response = await httpClient.PostAsync("http://tze.ddns.net:8070/api/Files/Upload?id=" + id, content);

            try
            {
                if (response.StatusCode.ToString() == "OK")
                    Imagem.Source = ImageSource.FromStream(() => file.OpenReadAsync().Result);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
            

            return response.StatusCode.ToString();
        }

        async void OnPickPhotoButtonClicked(object sender, EventArgs e)
        {
            //(sender as Button).IsEnabled = false;
            try
            {
                //Stream stream = await DependencyService.Get<IPhotoPickerService>().GetImageStreamAsync();
                //if (stream != null)
                //{

                //    image.Source = ImageSource.FromStream(() => stream);

                //}
                var res = await UploadFile();
                if (res == "OK")
                {
                    await this.DisplayToastAsync("Foto alterada");
                } else if (res != null)
                {
                    await this.DisplayToastAsync("Erro ao alterar foto");
                }
               // await this.DisplayToastAsync(await UploadFile(), 3000);


            }
            catch (NullReferenceException ex)
            {
                Console.WriteLine(ex.Message);
            }

            //(sender as Button).IsEnabled = true;
        }

        private async void TapGestureRecognizer_Tapped_Atualizar(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new AtualizarPage());
        }
    }
}