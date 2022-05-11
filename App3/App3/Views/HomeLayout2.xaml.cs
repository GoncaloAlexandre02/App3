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
    public partial class HomeLayout2 : ContentPage
    {
        public HomeLayout2()
        {
            InitializeComponent();
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

        private async void TapGestureRecognizer_Tapped_Mensagem(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new MensagensPage());
        }
    }
}