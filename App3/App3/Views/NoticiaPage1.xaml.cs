using App3.Models;
using App3.Services;
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
    public partial class NoticiaPage1 : ContentPage
    {
        Noticia noticia;
        RestService restService;
        public NoticiaPage1()
        {
            InitializeComponent();
            restService = new RestService();


        }
        public NoticiaPage1(string id)
        {
            InitializeComponent();
            restService = new RestService();
            AtualizaNoticia(id);

        }

        async void AtualizaNoticia(string id)
        {
            noticia = await restService.GetNoticiaAsync(id);

            titulolabel.Text = noticia.Nomenoticia;
            dtlabel.Text = noticia.Dtnoticia.ToString("dd/MM/yyyy à\\s HH:mm");
            desclabel.Text = noticia.Descnoticia;

        }

        private void ImageButton_Clicked(object sender, EventArgs e)
        {
            var change = stack3.Children.OfType<Label>().ToArray();

            foreach (var item in change)
            {
                item.FontSize -= 2;
            }
        }

        private void ImageButton_Clicked_1(object sender, EventArgs e)
        {
            var change = stack3.Children.OfType<Label>().ToArray();

            foreach (var item in change)
            {
                item.FontSize += 2;
            }
        }

        private void ImageButton_Clicked_2(object sender, EventArgs e)
        {
            BibliaPage.ModoLeitura(scrollP);

        }
    }
}