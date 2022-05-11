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
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        }
        private async void Entrar_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushModalAsync(new Views.LoginPage());
        }

        private async void Cadastrar_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushModalAsync(new Views.RegisterPage());
        }
    }
}