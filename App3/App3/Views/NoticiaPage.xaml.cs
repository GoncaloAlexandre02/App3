using App3.Models;
using App3.Services;
using App3.Views.Partials;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace App3.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]


    public partial class NoticiaPage : ContentPage
    {

        RootNoticia aaa;
        RestService restService;
        public NoticiaPage()
        {
            InitializeComponent();
            restService = new RestService();
            AtualizarNoticias();
        }

        private async void AtualizarNoticias()
        {
            EcraEvento.Children.Clear();
            aaa = await restService.GetNoticiasAsync();

            try
            {

                foreach (var evento in aaa.data)
                {

                    EcraEvento.Children.Add(new NoticiaSingleView(evento));
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }


        }
        private async void AtualizarNoticias2(string pesquisa)
        {

            aaa = await restService.GetNoticiasAsync();
            EcraEvento.Children.Clear();
            try
            {

                foreach (var evento in aaa.data)
                {
                    if (evento.Nomenoticia.IndexOf(pesquisa, StringComparison.OrdinalIgnoreCase) >= 0 || evento.Dtnoticia.ToString("dd/MM/yyyy HH:mm").IndexOf(pesquisa, StringComparison.OrdinalIgnoreCase) >= 0)
                    {
                        EcraEvento.Children.Add(new NoticiaSingleView(evento));
                    }

                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }


        }


        private void MySearchBarOnTextChanged(object sender, TextChangedEventArgs textChangedEventArgs)
        {

            // Has Cancel has been pressed?
            if (textChangedEventArgs.NewTextValue == null)
            {
                EcraEvento.Children.Clear();
                AtualizarNoticias();
            }

            var txtsearch = pesquisa.Text;
            if (txtsearch == null || txtsearch.Length == 0 || txtsearch == "")
            {
                EcraEvento.Children.Clear();
                AtualizarNoticias();
            }
            else
            {
                EcraEvento.Children.Clear();
                AtualizarNoticias2(txtsearch);
            }




        }
    }
}