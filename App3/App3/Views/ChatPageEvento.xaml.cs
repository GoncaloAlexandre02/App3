using App3.Models;
using App3.Services;
using App3.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;
using Xamarin.Essentials;
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
            AtualizaUser();
            Mensagem msg = new Mensagem()
            {
                Receptor = evento.Iduser.ToString(),
                Emissor = SecureStorage.GetAsync("iduser").Result,
                Evento = evento.Idevento,
                Descmsg = ""
            };
            var res = Task.Run(() => restService.MarcarMensagemLidoAsync(msg)).Result;
            aaa = new ChatEventoViewModel(evento.Idevento.ToString(), SecureStorage.GetAsync("iduser").Result, evento.Iduser.ToString());
            this.BindingContext = aaa;
        }

        public ChatPageEvento(string idemissor, string idrecetor, string idevento)
        {
            InitializeComponent();
            restService = new RestService();
            Evento = Task.Run(() => restService.GetEventosAsync()).Result.data.Find(e => e.Idevento.ToString() == idevento);
            Shell.Current.FlyoutIsPresented = false;
            AtualizaUser();
            Mensagem msg = new Mensagem()
            {
                Receptor = idrecetor,
                Emissor = idemissor,
                Evento = int.Parse(idevento),
                Descmsg = ""
            };
            var res = Task.Run(() => restService.MarcarMensagemLidoAsync(msg)).Result;
            aaa = new ChatEventoViewModel(Evento.Idevento.ToString(), idemissor, idrecetor);
            this.BindingContext = aaa;
        }

        private async void AtualizaUser()
        {
            userChat = await restService.GetUserChatAsync(Evento.Iduser.ToString());
            imagemT.Source = await restService.GetImagemServer(userChat.Imagem);
            titulo.Text = userChat.Nome + " " + userChat.Apelido;

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