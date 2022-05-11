using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Xamarin.Essentials;

namespace App3.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ConfigPage : ContentPage
    {
        public ConfigPage()
        {
            InitializeComponent();

        }

        private async void desenvolver_event(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new CompanyPage());
        }

        private async void privacy_event(object sender, EventArgs e)
        {
            await Browser.OpenAsync("https://policies.inpeaceapp.com/", BrowserLaunchMode.SystemPreferred);
        }

        private async void term_event(object sender, EventArgs e)
        {
            await Browser.OpenAsync("https://terms.inpeaceapp.com/", BrowserLaunchMode.SystemPreferred);
        }


    }
}