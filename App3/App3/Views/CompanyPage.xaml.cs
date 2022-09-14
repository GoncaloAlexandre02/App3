using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace App3.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class CompanyPage : ContentPage
    {
        public ICommand TapCommand => new Command<string>(async (url) => await Launcher.OpenAsync(url));

        public CompanyPage()
        {
            InitializeComponent();
            BindingContext = this;
        }

        private async void site_event(object sender, EventArgs e)
        {
            await Browser.OpenAsync("http://www.srwsoftware.pt/", BrowserLaunchMode.SystemPreferred);
        }
    }
}