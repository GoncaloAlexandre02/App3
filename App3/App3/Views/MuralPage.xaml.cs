using App3.Models;
using App3.Services;
using App3.Views.Partials;
using Rg.Plugins.Popup.Extensions;
using Rg.Plugins.Popup.Services;
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
    public partial class MuralPage : ContentPage
    {
        RootMural aaa;
        RestService restService;
        public MuralPage()
        {
            InitializeComponent();
            restService = new RestService();
            AtualizarMural();
        }

        private async void AtualizarMural()
        {
            aaa = await restService.GetMuraisAsync();
            EcraMural.Children.Clear();
            try
            {

                foreach (Mural mural in aaa.data)
                {

                    EcraMural.Children.Add(new MuralSingleView(mural));
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
        private void TapGestureRecognizer_Tapped_MuralPopup(object sender, EventArgs e)
        {
            Navigation.PushPopupAsync(new MuralPopup());

        }
        protected override void OnAppearing()
        {
            AtualizarMural();
        }
        private async void AddMural_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new MuralAdd());
        }
    }
}