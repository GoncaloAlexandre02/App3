using App3.Models;
using App3.Services;
using System;

using System.Net.Http;
using System.Net.Http.Headers;

using Xamarin.CommunityToolkit.Extensions;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace App3.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class AtualizarPage : ContentPage
    {
        RestService restService;
        User user;
        public AtualizarPage()
        {
            InitializeComponent();
            restService = new RestService();
            AtualizaDados();
        }

        private async void Button_Clicked(object sender, EventArgs e)
        {
            try
            {
                user = await restService.GetUserAsync();
                var nome = tNome.Text;
                var apelido = tApelido.Text;
                var tele = tTele.Text;
                var dtnasc = tDt.Date.ToString("dd/MM/yyyy");
                var email = tEmail.Text;
                var est = tEst.SelectedItem?.ToString();
                var password = user.Password;
                var tipouser = user.Tipouser;
                DateTime dtregisto = user.Dtregisto;
                var imagem = user.Imagem;
                var ocup = tProf.Text;
                var gen = "nao";
                var bat = "nao";
                var loca = tLoca.SelectedItem?.ToString();
                var cpostal = user.Cpostal;
                var morada = user.Morada;
                if (rFe.IsChecked)
                {
                    gen = "feminino";
                }
                else if (rMa.IsChecked)
                {
                    gen = "masculino";
                }
                else
                {
                    gen = "nao";
                }
                if (rBatSim.IsChecked)
                {
                    bat = "sim";
                }
                else
                {
                    bat = "nao";
                }

                if (nome == null || email == null || password == null || tele == null || apelido == null || nome == "" || email == "" || password == "" || tele == "" || apelido == "")
                {
                    await this.DisplayToastAsync("Campos Invalidos", 2000);
                }
                else
                {
                    var dtreg = dtregisto.ToString().Replace('\'', ' ');
                    string data = @"{'iduser':'" + user.Iduser.ToString() + "', 'nome':'" + nome + "', 'apelido':'" + apelido + "', 'email':'" + email + "', 'password':'" + password + "', 'morada':' ', 'cpostal':' ', 'telefone':'" + tele + "', 'emailativo':'nao', 'dtnasc':'" + dtnasc + "', 'batismo':'" + bat + "', 'genero':'" + gen + "', 'localidade':'" + loca + "', 'estadocivil':'" + est + "', 'ocupacao':'" + ocup + "', 'tipouser':'" + tipouser + "', 'imagem':'" + imagem + "'}";
                    var dataal = data.Replace('\'', '\"');
                    var res = await restService.UpdateUser(dataal, user.Iduser.ToString(), user.Dtregisto);
                    if (res == null)
                    {
                        await this.DisplayToastAsync("Erro ao Alterar, Tente mais Tarde", 5000);
                    }
                    else if (res.IsSuccessStatusCode)
                    {

                        //await Navigation.PushAsync(new PerfilPage());
                        await Navigation.PopAsync();
                    }
                    Console.WriteLine(res.ToString());


                }
            }
            catch (NullReferenceException ex)
            {
                await this.DisplayToastAsync("Campos Invalidos", 2000);
            }


        }

        async void AtualizaDados()
        {
            try
            {
                user = await restService.GetUserAsync();

                tNome.Text = user.Nome.ToString();
                tApelido.Text = user.Apelido.ToString();
                tEmail.Text = user.Email.ToString();
                tTele.Text = user.Telefone?.ToString();
                if (user.Dtnasc != null)
                {
                    DateTime date = DateTime.Now;
                    var res = DateTime.TryParse(user.Dtnasc, out date);
                    if (res)
                        tDt.Date = date;
                    else
                        tDt.Date = DateTime.Now;
                }
                    
                //tDt.Date = DateTime.ty user.Dtnasc?.ToString();
                else
                    tDt.Date = DateTime.Now;
                if (user.Estadocivil != null)
                {
                    tEst.Items.Add(user.Estadocivil.ToString());
                    tEst.SelectedItem = user.Estadocivil.ToString();
                }
                if (user.Ocupacao == null)
                    tProf.Text = " ";
                else
                    tProf.Text = user.Ocupacao.ToString();
                var bat = user.Batismo?.ToString();
                var loca = user.Localidade?.ToString();
                tLoca.SelectedItem = loca;
                var gen = "";
                if (user.Genero == null)
                {
                    gen = "";
                }
                else
                {
                    gen = user.Genero.ToString();
                }


                if (gen == "feminino")
                {
                    rFe.IsChecked = true;

                }
                else if (gen == "masculino")
                {
                    rFe.IsChecked = false;
                    rMa.IsChecked = true;
                }
                else
                {
                    rFe.IsChecked = false;
                    rMa.IsChecked = false;
                    rGn.IsChecked = true;
                }
                if (bat == "sim")
                {
                    rBatSim.IsChecked = true;
                }
                else
                {
                    rBatSim.IsChecked = false;
                    rBatNao.IsChecked = true;
                }
            }
            catch (NullReferenceException ex)
            {

                Console.WriteLine(ex.Message);
            }

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

            var response = await httpClient.PostAsync("http://tze.ddns.net:8070/api/Files/Upload?id=" + await SecureStorage.GetAsync("iduser"), content);

            try
            {
                if (response.StatusCode.ToString() == "OK")
                    imgButton.Source = ImageSource.FromStream(() => file.OpenReadAsync().Result);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }

            await Navigation.PushAsync(new PerfilPage());
        }
        async void TakeUploadFile_Clicked(System.Object sender, System.EventArgs e)
        {
            var file = await MediaPicker.CapturePhotoAsync();

            if (file == null)
                return;

            var content = new MultipartFormDataContent();
            content.Add(new StreamContent(await file.OpenReadAsync()), "file", file.FileName);

            var httpClient = new HttpClient(DependencyService.Get<IHttpClientHandlerService>().GetInsecureHandler());
            httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", await SecureStorage.GetAsync("tokenuser"));

            var response = await httpClient.PostAsync("https://10.0.2.2:7004/api/Files/Upload?id=" + await SecureStorage.GetAsync("iduser"), content);


            await Navigation.PushAsync(new PerfilPage());
        }
    }
}