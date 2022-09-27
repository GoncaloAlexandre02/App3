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
    public partial class ChatPageMural : ContentPage
    {
        RestService restService;
        User userChat;
        Mural Mural;
        private ChatMuralViewModel aaa;

        public ChatPageMural(Mural mural)
        {
            Mural = mural;
            InitializeComponent();
            restService = new RestService();
            Shell.Current.FlyoutIsPresented = false;
            AtualizaUser();
            Mensagem msg = new Mensagem()
            {
                Receptor = mural.Iduser.ToString(),
                Emissor = SecureStorage.GetAsync("iduser").Result,
                Mural = mural.Idmural,
                Descmsg = ""
            };
            var res = Task.Run(() => restService.MarcarMensagemLidoAsync(msg)).Result;
            aaa = new ChatMuralViewModel(mural.Idmural.ToString(), SecureStorage.GetAsync("iduser").Result, Mural.Iduser.ToString());
            this.BindingContext = aaa;
        }

        public ChatPageMural(string idemissor, string idrecetor, string idmural)
        {
            InitializeComponent();
            restService = new RestService();
            Mural = Task.Run(() => restService.GetMuraisAsync()).Result.data.Find(m => m.Idmural.ToString() == idmural);
            Shell.Current.FlyoutIsPresented = false;
            AtualizaUser();
            Mensagem msg = new Mensagem()
            {
                Receptor = idrecetor,
                Emissor = idemissor,
                Mural = int.Parse(idmural),
                Descmsg = ""
            };
            var res = Task.Run(() => restService.MarcarMensagemLidoAsync(msg)).Result;
            aaa = new ChatMuralViewModel(idmural, idemissor, idrecetor);
            this.BindingContext = aaa;
        }

        private async void AtualizaUser()
        {
            userChat = await restService.GetUserChatAsync(Mural.Iduser.ToString());
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