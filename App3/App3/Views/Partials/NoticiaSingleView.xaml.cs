using App3.Models;
using App3.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace App3.Views.Partials
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class NoticiaSingleView : ContentView
    {
        Noticia evento2;

        RestService restService;
        public NoticiaSingleView()
        {
            InitializeComponent();
            restService = new RestService();
        }

        public NoticiaSingleView(Noticia evento)
        {
            InitializeComponent();
            evento2 = evento;
            nomeEvento.Text = evento.Nomenoticia.ToString();
            dataDEvento.Text = evento.Dtnoticia.ToString("dd");
            dataMEvento.Text = evento.Dtnoticia.ToString("MMM");
            dataHEvento.Text = evento.Dtnoticia.ToString("HH : mm");
            restService = new RestService();
            


        }

        private void TapGestureRecognizer_Tapped(object sender, EventArgs e)
        {
            Navigation.PushAsync(new NoticiaPage1(evento2.Idnoticia.ToString()));
        }
    }
}