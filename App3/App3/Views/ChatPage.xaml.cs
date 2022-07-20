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
    public partial class ChatPage : ContentPage
    {
        RestService restService;
        User userChat;
        private ChatViewModel aaa;
        public ChatPage(string idrecetor)
        {
            
            InitializeComponent();
            restService = new RestService();
            Shell.Current.FlyoutIsPresented = false;
            AtualizaUser(idrecetor);
            aaa = new ChatViewModel(idrecetor);
            this.BindingContext = aaa;


        }
        private async void AtualizaUser(string id)
        {
            userChat = await restService.GetUserChatAsync(id);
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