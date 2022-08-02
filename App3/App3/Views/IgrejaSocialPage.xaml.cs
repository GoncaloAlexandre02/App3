using App3.Models;
using App3.Services;
using App3.Views.Partials;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace App3.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class IgrejaSocialPage : ContentPage
    {
        SocialRoot aaa;
        RestService restService;
        public IgrejaSocialPage()
        {
            InitializeComponent();
            restService = new RestService();
            AtualizarSocial("tudo");
        }

        private async void AtualizarSocial(string tipo)
        {
            EcraSocial.Children.Clear();
            aaa = await restService.GetSocialItemsAsync(tipo);

            try
            {

                foreach (Social social in aaa.data)
                {

                    EcraSocial.Children.Add(new SocialSingleView(social));
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        private void buttonCamisola_Clicked(object sender, EventArgs e)
        {
            buttonCamisola1.IsVisible = true;
            buttonCamisola.IsVisible = false;
            buttonEmpregos1.IsVisible = false;
            buttonMoveil1.IsVisible = false;
            buttonOutro1.IsVisible = false;
            buttonMoveis.IsVisible = true;
            buttonOutro.IsVisible = true;
            buttonEmprego.IsVisible = true;
            AtualizarSocial("roupa");
        }



        private void buttonEmprego_Clicked(object sender, EventArgs e)
        {
            buttonCamisola1.IsVisible = false;
            buttonEmprego.IsVisible = false;
            buttonEmpregos1.IsVisible = true;
            buttonMoveil1.IsVisible = false;
            buttonOutro1.IsVisible = false;
            buttonMoveis.IsVisible = true;
            buttonCamisola.IsVisible = true;
            buttonOutro.IsVisible = true;
            AtualizarSocial("emprego");

        }


        private void buttonMoveis_Clicked(object sender, EventArgs e)
        {
            buttonCamisola1.IsVisible = false;
            buttonMoveis.IsVisible = false;
            buttonEmpregos1.IsVisible = false;
            buttonMoveil1.IsVisible = true;
            buttonOutro1.IsVisible = false;
            buttonMoveis.IsVisible = true;
            buttonCamisola.IsVisible = true;
            buttonEmprego.IsVisible = true;
            buttonOutro.IsVisible = true;
            AtualizarSocial("mobilia");
        }



        private void buttonOutro_Clicked(object sender, EventArgs e)
        {
            buttonCamisola1.IsVisible = false;
            buttonOutro.IsVisible = false;
            buttonEmpregos1.IsVisible = false;
            buttonMoveil1.IsVisible = false;
            buttonOutro1.IsVisible = true;
            buttonMoveis.IsVisible = true;
            buttonCamisola.IsVisible = true;
            buttonEmprego.IsVisible = true;
            AtualizarSocial("outros");
        }



        private async void TapGestureRecognizer_Tapped(object sender, EventArgs e)
        {
            await Navigation.PushModalAsync(new IgrejaSocialPage1());
        }

        private async void TapGestureRecognizer_Tapped_Add(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new IgrejaSocialAddPage());
        }

    }
}