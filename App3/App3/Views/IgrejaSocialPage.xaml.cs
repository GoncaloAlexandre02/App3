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
            buttonCamisola.BorderColor = Color.Blue;
            buttonEmprego.BorderColor = Color.Transparent;
            buttonMoveis.BorderColor = Color.Transparent;
        }

        private void buttonEmprego_Clicked(object sender, EventArgs e)
        {
            buttonCamisola.BorderColor = Color.Transparent;
            buttonEmprego.BorderColor = Color.Blue;
            buttonMoveis.BorderColor = Color.Transparent;
        }

        private void buttonMoveis_Clicked(object sender, EventArgs e)
        {
            buttonCamisola.BorderColor = Color.Transparent;
            buttonEmprego.BorderColor = Color.Transparent;
            buttonMoveis.BorderColor = Color.Blue;
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