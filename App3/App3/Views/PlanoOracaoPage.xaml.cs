using App3.Models;
using App3.Services;
using App3.Views.Partials;
using Rg.Plugins.Popup.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.CommunityToolkit.Extensions;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace App3.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class PlanoOracaoPage : ContentPage
    {
        RestService restService;
        RootPlano aaa;
        public PlanoOracaoPage()
        {
            InitializeComponent();
            restService = new RestService();

        }
        protected override void OnAppearing()
        {
            AtualizarPlano();
        }
        private async void AtualizarPlano()
        {
            EcraPlano.Children.Clear();
            aaa = await restService.GetPlanosAsync(await SecureStorage.GetAsync("iduser"));

            try
            {

                foreach (var evento in aaa.data)
                {

                    EcraPlano.Children.Add(new PlanoSingleView(evento));
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }


        }

        private void Plano_Clicked(object sender, EventArgs e)
        {
            Navigation.PushPopupAsync(new PlanoPopup());
        }
    }
}