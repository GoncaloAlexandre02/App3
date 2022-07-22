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
            buttonCamisola.BorderColor = Color.FromHex("#0a2a3b");
            buttonEmprego.BorderColor = Color.Transparent;
            buttonMoveis.BorderColor = Color.Transparent;
        }

        private void buttonEmprego_Clicked(object sender, EventArgs e)
        {
            buttonCamisola.BorderColor = Color.Transparent;
            buttonEmprego.BorderColor = Color.FromHex("#0a2a3b");
            buttonMoveis.BorderColor = Color.Transparent;
        }

        private void buttonMoveis_Clicked(object sender, EventArgs e)
        {
            buttonCamisola.BorderColor = Color.Transparent;
            buttonEmprego.BorderColor = Color.Transparent;
            buttonMoveis.BorderColor = Color.FromHex("#0a2a3b");
            buttonOutro.BorderColor = Color.Transparent;
        }

        private void buttonOutro_Clicked(object sender, EventArgs e)
        {
            buttonCamisola.BorderColor = Color.Transparent;
            buttonEmprego.BorderColor = Color.Transparent;
            buttonMoveis.BorderColor = Color.Transparent;
            buttonOutro.BorderColor = Color.FromHex("#0a2a3b");
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