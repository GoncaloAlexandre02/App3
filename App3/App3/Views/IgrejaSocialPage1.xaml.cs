﻿using App3.Models;
using App3.Services;
using Rg.Plugins.Popup.Services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
    public partial class IgrejaSocialPage1 : ContentPage
    {
        Social social1;
        SocialimgRoot socialimg;
        RestService restService;

        ObservableCollection<Image> Images { get; set; } = new ObservableCollection<Image>();

        public IgrejaSocialPage1()
        {
            InitializeComponent();
        }
        public IgrejaSocialPage1(Social social)
        {
            InitializeComponent();
            titulo.Text = social.Nomesocial.ToString();
            desc.Text = social.Descsocial.ToString();
            social1 = social;
            restService = new RestService();
            //CarouselImg.ItemsSource = Images;

            if (social1.Tipo == "emprego")
            {
                btnR.Text = "Enviar Curriculo";

            }
            else
            {

                if (social1.Estado == "Indisponível")
                {
                    btnR.BackgroundColor = Color.Red;
                    btnR.Effects.Clear();
                    btnR.Text = "Indisponível";
                }
                else
                {
                    btnR.BackgroundColor = Color.FromHex("#0a2a3b");
                    btnR.Text = "Reservar";
                    btnR.IsEnabled = true;
                }
            }


            AtualizarImg();

        }

        public async void AtualizarImg()
        {

            try
            {
                socialimg = await restService.GetSocialImgAsync(social1.Idsocial.ToString());
            }
            catch (Exception ex)
            {
                //ImgSoc.Source = "noimage";
            }

            try
            {
                if (socialimg == null || socialimg.data.Count == 0)
                {
                    //ImgSoc.Source = "noimage";
                    Image newImg = new Image();
                    newImg.Source = "noimg";
                    Images.Add(newImg);
                    
                }
                else
                {
                    ImgSoc.Source = await restService.GetImagemServer(socialimg.data[0].Img);
                    ImgSoc.IsVisible = true;

                    foreach (var d in socialimg.data)
                    {
                        Image newImg = new Image(); 
                        newImg.Source = await restService.GetImagemServer(d.Img);
                        Images.Add(newImg);
                    }

                }
            }
            catch (Exception ex)
            {
                //ImgSoc.Source = "noimage";
            }
        }

        private async void btnR_Clicked(object sender, EventArgs e)
        {
            if (social1.Tipo == "emprego")
            {
                var options = new PickOptions
                {
                    PickerTitle = "Escolha um PDF",
                    FileTypes = FilePickerFileType.Pdf
                };

                var file = await FilePicker.PickAsync(options);

                Random rdm = new Random();

                var content = new MultipartFormDataContent();
                content.Add(new StreamContent(await file.OpenReadAsync()), "file", rdm.Next(10000).ToString() + file.FileName);

                var httpClient = new HttpClient(DependencyService.Get<IHttpClientHandlerService>().GetInsecureHandler());
                httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", await SecureStorage.GetAsync("tokenuser"));

                var response = await httpClient.PostAsync("https://10.0.2.2:7004/api/Files/UploadSocialR/" + social1.Idsocial + "?iduser=" + social1.Iduser, content);


                Console.WriteLine(response.ToString());

                if (response.IsSuccessStatusCode)
                {
                    await this.DisplayToastAsync("Curriculo Enviado", 2000);
                    btnR.BackgroundColor = Color.LightGreen;
                    btnR.Text = "Enviado";
                }
                else
                {
                    await this.DisplayToastAsync("Erro ao enviar curriculo", 2000);
                }

            }
            else
            {
                string data = @"{'idreserva':'" + social1.Idsocial.ToString() + "', 'iduser':'" + await SecureStorage.GetAsync("iduser") + "'}";
                var dataal = data.Replace('\'', '\"');
                var aab = await restService.PostSocialReserva(dataal);

                if (aab.IsSuccessStatusCode)
                {
                    social1.Estado = "Indisponível";

                    Social2 social2A = new Social2 { Idsocial = social1.Idsocial, Iduser = social1.Iduser, Tiposocial = social1.Tipo, Estadosocial = social1.Estado, Nomesocial = social1.Nomesocial, Descsocial = social1.Descsocial, Idigreja = null };

                    var abc = await restService.UpdateSocial(social2A, social1.Idsocial.ToString());

                    if (abc.IsSuccessStatusCode)
                    {
                        await this.DisplayToastAsync("Reservado com sucesso", 2000);
                        btnR.BackgroundColor = Color.LightGreen;
                        btnR.Text = "Reservado";

                    }
                }
                else
                {
                    await this.DisplayToastAsync("Erro ao Reservar, Contactar Admin", 2000);
                }
            }
        }

        async Task<FileResult> PickAndShow(PickOptions options)
        {
            try
            {
                var result = await FilePicker.PickAsync(options);
                if (result != null)
                {


                }

                return result;
            }
            catch (Exception ex)
            {
                // The user canceled or something went wrong
            }

            return null;
        }
        private async void TapGestureRecognizer_Tapped(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new ChatPageSocial(social1));
        }

        private async void ImageTapped(object sender, EventArgs e)
        {
            var image = (Image)sender;
            
            //await Navigation.ShowPopupAsync(new PopUpImg(image));
            await Navigation.ShowPopupAsync(new PopUpMultiImg(Images));
            //await PopupNavigation.Instance.PushAsync(new PopUpImg(image));
        }

        protected override bool OnBackButtonPressed()
        {
            //Rg.Plugins.Popup.pop
            // Do something if there are some pages in the `PopupStack`
            //Task.Run(() => PopupNavigation.Instance.PopAllAsync());
            return false;
            //return base.OnBackButtonPressed();
        }
    }
}