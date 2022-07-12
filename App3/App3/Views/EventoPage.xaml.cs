using App3.Models;
using App3.Services;
using App3.Views.Partials;
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
    public partial class EventoPage : ContentPage
    {

        RootEvento aaa;
        RestService restService;
        public EventoPage()
        {
            InitializeComponent();
            restService = new RestService();
            AtualizarEventos();
        }

        private async void AtualizarEventos()
        {
            EcraEvento.Children.Clear();
            //aaa = await restService.GetEventosAsync();

            try
            {

                foreach (Evento evento in aaa.data)
                {

                    EcraEvento.Children.Add(new EventoSingleView(evento));
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}