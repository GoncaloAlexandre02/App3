using App3.Models;
using App3.Services;
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

        RootNoticia noticia;
        List<Noticia> noticiaList;
        RestService restService;
        public ObservableCollection<Noticia> Noticias { get; set; } = new ObservableCollection<Noticia>();
        public NoticiaPage()
        {
            InitializeComponent();
            restService = new RestService();

            AtualizaNoticias();

        }

       

        async void AtualizaNoticias()
        {
            noticia = await restService.GetNoticiasAsync();
            noticiaList = noticia.data;
            noticiaList.Reverse();
            foreach (var item in noticiaList)
            {

                if (item.Nomenoticia.Length >= 20)
                    item.Nomenoticia = item.Nomenoticia.Substring(0, 20) + "...";
                Noticias.Add(item);
            }
            

        }


        private void MySearchBarOnTextChanged(object sender, TextChangedEventArgs textChangedEventArgs)
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

        }
    }
}