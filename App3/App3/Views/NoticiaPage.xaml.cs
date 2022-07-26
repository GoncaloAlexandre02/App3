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


        /* private void MySearchBarOnTextChanged(object sender, TextChangedEventArgs textChangedEventArgs)
         {
             // Has Cancel has been pressed?
             if (textChangedEventArgs.NewTextValue == null)
             {
                 Noticias.Clear();
                 foreach (var item in noticiaList)
                 {
                     Noticias.Add(item);

                 }
             }

             var txtsearch = pesquisa.Text;
             Noticias.Clear();
             if (txtsearch == null || txtsearch.Length == 0 || txtsearch == "")
             {
                 foreach (var item in noticiaList)
                 {
                     Noticias.Add(item);

                 }
             }
             else
             {


                 foreach (var item in noticiaList)
                 {
                     if (item.Nomenoticia.IndexOf(txtsearch, StringComparison.OrdinalIgnoreCase) >= 0 || item.Dtnoticia.ToString("dd/MM/yyyy HH:mm").IndexOf(txtsearch, StringComparison.OrdinalIgnoreCase) >= 0)
                         Noticias.Add(item);

                 }
             }

         }*/
    }
}