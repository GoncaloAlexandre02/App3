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
            aaa = new ChatMuralViewModel(mural.Idmural.ToString());
            this.BindingContext = aaa;


        }
        private async void AtualizaUser()
        {
            userChat = await restService.GetUserChatAsync(Mural.Iduser.ToString());
            imagemT.Source = await restService.GetImagemServer(userChat.Imagem);
            titulo.Text = Mural.Motivo;// userChat.Nome + " " + userChat.Apelido;

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