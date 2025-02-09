﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using App3.Services;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace App3.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class HomeLayout2 : ContentPage
    {
        public HomeLayout2()
        {
            InitializeComponent();

            //Read intent page string and redirect to respective page
            if (Application.Current.Properties["intentPage"] != null && !string.IsNullOrEmpty(Application.Current.Properties["intentPage"].ToString()))
            {
                string page = Application.Current.Properties["intentPage"].ToString();
                Application.Current.Properties["intentPage"] = null;

                switch(page)
                {
                    case "Mensagens": 
                        Navigation.PushAsync(new MessagePage());
                        break;

                    case "Social":
                        Navigation.PushAsync(new IgrejaSocialPage());
                        break;

                    case "Eventos":
                        Navigation.PushAsync(new EventoPage());
                        break;

                    default: 
                        break;
                }
            }
        }




        private async void TapGestureRecognizer_Tapped_Biblia(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new BibliaPage());
        }
        private async void TapGestureRecognizer_Tapped_1(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new IgrejaPage());
        }

        private async void TapGestureRecognizer_Tapped_Config(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new ConfigPage());
        }

        private async void TapGestureRecognizer_Tapped_Donate(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new DonatePage());


        }
        private async void TapGestureRecognizer_Tapped_Mural(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new MuralPage());


        }
        private async void TapGestureRecognizer_Tapped_Batismo(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new BatismoPage());


        }
        private async void TapGestureRecognizer_Tapped_Plano(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new PlanoOracaoPage());


        }

        private async void TapGestureRecognizer_Tapped_Video(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new VideoPage());
        }

        private async void TapGestureRecognizer_Tapped_Evento(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new EventoPage());
        }

        private async void TapGestureRecognizer_Tapped_Departamento(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new DepartamentoPage());
        }

        

        private async void TapGestureRecognizer_Tapped_Noticia(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new NoticiaPage());
        }

        private async void TapGestureRecognizer_Tapped_Podcast(object sender, EventArgs e)
        {
            await Browser.OpenAsync("https://open.spotify.com/show/7x7o7VRQifLYTzs0nEimpt?si=2727a7bfb0f048d7", BrowserLaunchMode.SystemPreferred);
        }

        private async void TapGestureRecognizer_Tapped_Redes(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new RedesSociaisPage());

        }

        private async void TapGestureRecognizer_Tapped_Hinario(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new HinarioPage1());
        }

        private async void TapGestureRecognizer_Tapped_Versiculo(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new VersiculoPage());
        }

        private async void TapGestureRecognizer_Tapped_Socia(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new IgrejaSocialPage());
        }
    }
}