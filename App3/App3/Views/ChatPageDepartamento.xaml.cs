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
    public partial class ChatPageDepartamento : ContentPage
    {
        RestService restService;
        User userChat;
        Responsavel Responsavel;
        private ChatDepartamentoViewModel aaa;
        public ChatPageDepartamento(Responsavel responsavel)
        {
            Responsavel = responsavel;
            InitializeComponent();
            restService = new RestService();
            Shell.Current.FlyoutIsPresented = false;
            AtualizaUser();
            aaa = new ChatDepartamentoViewModel(Responsavel.Iddepart.ToString()); ;
            this.BindingContext = aaa;


        }
        private async void AtualizaUser()
        {
            userChat = await restService.GetUserChatAsync(Responsavel.Iduser.ToString());
            imagemT.Source = await restService.GetImagemServer(userChat.Imagem);
            titulo.Text = Responsavel.NomeDepart;// userChat.Nome + " " + userChat.Apelido;

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