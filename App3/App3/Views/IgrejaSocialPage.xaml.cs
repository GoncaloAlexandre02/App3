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
        public IgrejaSocialPage()
        {
            InitializeComponent();
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
        }

        private void buttonCamisola1_Clicked(object sender, EventArgs e)
        {
            buttonCamisola1.IsVisible = false;
            buttonCamisola.IsVisible = true;
            buttonEmpregos1.IsVisible = false;
            buttonMoveil1.IsVisible = false;
            buttonOutro1.IsVisible = false;
            buttonMoveis.IsVisible = true;
            buttonCamisola.IsVisible = true;
            buttonEmprego.IsVisible = true;
            buttonOutro.IsVisible = true;
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

        }
        private void buttonEmprego1_Clicked(object sender, EventArgs e)
        {
            buttonCamisola1.IsVisible = false;
            buttonEmprego.IsVisible = true;
            buttonEmpregos1.IsVisible = false;
            buttonMoveil1.IsVisible = false;
            buttonOutro1.IsVisible = false;
            buttonMoveis.IsVisible = true;
            buttonCamisola.IsVisible = true;
            buttonEmprego.IsVisible = true;
            buttonOutro.IsVisible = true;
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
        }

        private void buttonMoveis1_Clicked(object sender, EventArgs e)
        {
            buttonCamisola1.IsVisible = false;
            buttonMoveis.IsVisible = true;
            buttonEmpregos1.IsVisible = false;
            buttonMoveil1.IsVisible = false;
            buttonOutro1.IsVisible = false;
            buttonMoveis.IsVisible = true;
            buttonCamisola.IsVisible = true;
            buttonEmprego.IsVisible = true;
            buttonOutro.IsVisible = true;
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
        }

        private void buttonOutro1_Clicked(object sender, EventArgs e)
        {
            buttonCamisola1.IsVisible = false;
            buttonOutro.IsVisible = true;
            buttonEmpregos1.IsVisible = false;
            buttonMoveil1.IsVisible = false;
            buttonOutro1.IsVisible = false;
            buttonMoveis.IsVisible = true;
            buttonCamisola.IsVisible = true;
            buttonEmprego.IsVisible = true;

        }

        private async void TapGestureRecognizer_Tapped(object sender, EventArgs e)
        {
            await Navigation.PushModalAsync(new IgrejaSocialPage1());
        }

        private async void TapGestureRecognizer_Tapped_Add(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new IgrejaSocialAddPage());
        }

        private async void TapGestureRecognizer_Tapped_1(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new IgrejaSocialPage2());
        }
    }
}