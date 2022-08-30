using App3.Models;
using App3.Services;
using App3.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace App3.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ChatPageEvento : ContentPage
    {
        RestService restService;
        User userChat;
        Evento Evento;
        private ChatEventoViewModel aaa;
        public ChatPageEvento(Evento evento)
        {
            Evento = evento;
            InitializeComponent();
            restService = new RestService();
            Shell.Current.FlyoutIsPresented = false;
            AtualizaUser("1");
            aaa = new ChatEventoViewModel(evento.Idevento.ToString());
            this.BindingContext = aaa;


        }
        private async void AtualizaUser(string id)
        {
            //userChat = await restService.GetUserChatAsync(id);
            imagemT.Source = await restService.GetImagemServer(Evento.Imgevento);
            titulo.Text = Evento.Nome;// userChat.Nome + " " + userChat.Apelido;

        }
        protected override void OnDisappearing()
        {
            aaa.myTimer.Stop();
        }
        protected override void OnAppearing()
        {
            aaa.myTimer.Start();
        }

    }
}