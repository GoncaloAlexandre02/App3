using App3.Services;
using App3.Views.Partials;
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
    public partial class IgrejaPage1 : ContentPage
    {
        RestService restService;
        public IgrejaPage1()
        {
            InitializeComponent();
            restService = new RestService();
            AtualizarIgreja();
        }
        public IgrejaPage1(string fav)
        {
            InitializeComponent();
            restService = new RestService();
            tit.Text = "Favoritos";
            AtualizarFavIgreja();
        }
        private async void AtualizarIgreja()
        {
            EcraIgrejas.Children.Clear();
            var aaa = await restService.GetIgrejasAsync();

            try
            {

                foreach (var evento in aaa.data)
                {

                    EcraIgrejas.Children.Add(new IgrejaSingleView(evento));
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }


        }
        private async void AtualizarFavIgreja()
        {
            EcraIgrejas.Children.Clear();
            var aaa = await restService.GetIgrejasFavAsync(await SecureStorage.GetAsync("iduser"));

            try
            {

                foreach (var evento in aaa.data)
                {

                    EcraIgrejas.Children.Add(new IgrejaSingleView(evento.Idigreja.ToString(), evento.Estado));
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }


        }

    }
}