﻿using App3.Models;
using App3.Services;
using Plugin.Media.Abstractions;
using System;
using System.Collections.Generic;
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
    public partial class IgrejaSocialAddPage : ContentPage
    {
        FileResult[] file;
        FileResult fileTest;
        int count = 0;
        RestService restService;
        public IgrejaSocialAddPage()
        {
            InitializeComponent();
            restService = new RestService();
            file = new FileResult[3];
        }

        private async void Button_Clicked(object sender, EventArgs e)
        {
            if (txtDesc.Text != null && txtTitulo.Text != null && picker.SelectedItem != null)
            {
                Social socialA = new Social { Nomesocial = txtTitulo.Text.ToString(), Descsocial = txtDesc.Text.ToString(), Tipo = picker.SelectedItem.ToString().ToLower(), Iduser = int.Parse(await SecureStorage.GetAsync("iduser")), Estado = "Disponível" };
                string data = @"{'iduser':'" + await SecureStorage.GetAsync("iduser") + "', 'nomesocial':'" + txtTitulo.Text.ToString() + "', 'descsocial':'" + txtDesc.Text.ToString() + "', 'tiposocial':'" + picker.SelectedItem.ToString().ToLower() + "', 'estadosocial':'" + "Disponível" + "'}";
                var dataal = data.Replace('\'', '\"');
                var aaa = await restService.PostSocial(dataal);

                Console.WriteLine("ID DO SOCIAL: " + aaa.Idsocial.ToString());
                //await Navigation.PushAsync(new IgrejaSocialPage());

                for (int i = 0; i < 3; i++)
                {
                    if (file[i] != null)
                    {
                        Random rdm = new Random();

                        var content = new MultipartFormDataContent();
                        content.Add(new StreamContent(await file[i].OpenReadAsync()), "file", aaa.Idsocial + file[i].FileName);

                        var httpClient = new HttpClient(DependencyService.Get<IHttpClientHandlerService>().GetInsecureHandler());
                        httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", await SecureStorage.GetAsync("tokenuser"));

                        var response = await httpClient.PostAsync("http://tze.ddns.net:8070/api/Files/UploadSocial/" + aaa.Idsocial, content);

                        Console.WriteLine(response.ToString());
                        Console.WriteLine(await response.Content.ReadAsStringAsync());
                    }
                }
                await Navigation.PushAsync(new IgrejaSocialPage());
            }
            else
            {
                await this.DisplayToastAsync("Preencha os Campos Todos", 2000);
            }
        }

        private async void ImageButton_Clicked(object sender, EventArgs e)
        {
            var choices = new[] { "Abrir câmera", "Escolher imagem"};

            var choice =  await Acr.UserDialogs.UserDialogs.Instance.ActionSheetAsync("Escolher", "Cancelar", null, null, choices);
            
            
            if (file[2] == null)
            {
                
                if (choice == "Abrir câmera")
                {
                    fileTest = await MediaPicker.CapturePhotoAsync();
                    file[count] = fileTest;
                    count++;
                }
                else
                {
                    for (int i=0; i<=count; i++)
                    {
                        file[i] = null;
                    }
                    MultiPickerOptions options = new MultiPickerOptions();
                    options.MaximumImagesCount = 3;
                    var images = await Plugin.Media.CrossMedia.Current.PickPhotosAsync(pickerOptions:options);
                    foreach (var i in images)
                    {
                        FileResult fileResult = new FileResult(i.Path);
                        file[count++] = fileResult;
                    }
                }

                lImg.Text = count + " de 3 Imagens";
            }
            else
            {
                lImg.Text = count + " de 3 Imagens";

            }



        }
    }
}