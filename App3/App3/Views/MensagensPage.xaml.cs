using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace App3.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MensagensPage : ContentPage
    {
        public MensagensPage()
        {
            InitializeComponent();
        }

        private async void Button_Clicked(object sender, EventArgs e)
        {
            await Browser.OpenAsync("https://www.youtube.com/c/ADBETEL/featured", BrowserLaunchMode.SystemPreferred);
        }
    }
}