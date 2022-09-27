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
    public partial class ChatPageDepartamento : ContentPage
    {
        RestService restService;
        User userChat;
        Responsavel Responsavel;
        private ChatDepartamentoViewModel aaa;
        private string Idrecetor;
        public ChatPageDepartamento(Responsavel responsavel)
        {
            Idrecetor = responsavel.Iduser.ToString();
            Responsavel = responsavel;
            InitializeComponent();
            restService = new RestService();
            Shell.Current.FlyoutIsPresented = false;
            AtualizaUser();
            Mensagem msg = new Mensagem()
            {
                Receptor = Idrecetor,
                Emissor = SecureStorage.GetAsync("iduser").Result,
                Departamento = responsavel.Iddepart,
                Descmsg = ""
            };
            var res = Task.Run(() => restService.MarcarMensagemLidoAsync(msg)).Result;
            aaa = new ChatDepartamentoViewModel(Responsavel.Iddepart.ToString(), SecureStorage.GetAsync("iduser").Result, Idrecetor);
            this.BindingContext = aaa;
        }

        public ChatPageDepartamento(string idemissor, string idrecetor, string iddepart)
        {
            Idrecetor = idrecetor;
            InitializeComponent();
            restService = new RestService();
            Responsavel = Task.Run(() => restService.GetResponsaveisAsync(int.Parse(iddepart))).Result.FirstOrDefault();
            Shell.Current.FlyoutIsPresented = false;
            AtualizaUser();
            Mensagem msg = new Mensagem()
            {
                Receptor = idrecetor,
                Emissor = idemissor,
                Departamento = int.Parse(iddepart),
                Descmsg = ""
            };
            var res = Task.Run(() => restService.MarcarMensagemLidoAsync(msg)).Result;
            aaa = new ChatDepartamentoViewModel(iddepart, idemissor, idrecetor);
            this.BindingContext = aaa;
        }

        private async void AtualizaUser()
        {
            userChat = await restService.GetUserChatAsync(Responsavel.Iduser.ToString());
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