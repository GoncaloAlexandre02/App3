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
    public partial class EventoSingleView : ContentView
    {
        Evento evento2;

        RestService restService;
        public EventoSingleView()
        {
            InitializeComponent();
            restService = new RestService();
        }

        public EventoSingleView(Evento evento)
        {
            InitializeComponent();
            evento2 = evento;
            nomeEvento.Text = evento.Nome.ToString();
            dataDEvento.Text = evento.Dtevento.ToString("dd");
            dataMEvento.Text = evento.Dtevento.ToString("MMM");
            dataHEvento.Text = evento.Dtevento.ToString("HH : mm");
            restService = new RestService();
        


        }

        private void TapGestureRecognizer_Tapped(object sender, EventArgs e)
        {
            Navigation.PushAsync(new EventoPage1(evento2));
        }
    }
}