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
    public partial class ChatPageSocial : ContentPage
    {
        RestService restService;
        User userChat;
        Social Social;
        private ChatSocialViewModel aaa;

        public ChatPageSocial(Social social)
        {
            InitializeComponent();
            Social = social;
            restService = new RestService();
            Shell.Current.FlyoutIsPresented = false;
            AtualizaUser();
            Mensagem msg = new Mensagem()
            {
                Receptor = social.Iduser.ToString(),
                Emissor = SecureStorage.GetAsync("iduser").Result,
                Social = social.Idsocial,
                Descmsg = ""
            };
            var res = Task.Run(() => restService.MarcarMensagemLidoAsync(msg)).Result;
            aaa = new ChatSocialViewModel(Social.Idsocial.ToString(), SecureStorage.GetAsync("iduser").Result, social.Iduser.ToString());
            this.BindingContext = aaa;
        }

        public ChatPageSocial(string idemissor, string idrecetor, string idsocial)
        {
            InitializeComponent();
            restService = new RestService();
            Social = Task.Run(() => restService.GetSocialItemsAsync("tudo")).Result.data.Find(s => s.Idsocial.ToString() == idsocial);
            Shell.Current.FlyoutIsPresented = false;
            AtualizaUser();
            Mensagem msg = new Mensagem()
            {
                Receptor = idrecetor,
                Emissor = idemissor,
                Social = int.Parse(idsocial),
                Descmsg = ""
            };
            var res = Task.Run(() => restService.MarcarMensagemLidoAsync(msg)).Result;
            aaa = new ChatSocialViewModel(idsocial, idemissor, idrecetor);
            this.BindingContext = aaa;
        }

        private async void AtualizaUser()
        {
            userChat = await restService.GetUserChatAsync(Social.Iduser.ToString());
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