using App3.Models;
using App3.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace App3.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MessagePage : ContentPage
    {
        RestService restService;
        List<Mensagem> msgList = new List<Mensagem>();
        RootMsg msg;
        public MessagePage()
        {
            InitializeComponent();
            restService = new RestService();
            AtualizarMensagens();
        }

        async void OnItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            ListView lv = (ListView)sender;

            // this assumes your List is bound to a List<Club>
            var item = (Mensagem)lista.SelectedItem;
            var itemstrig = item.Idemissor;

            // assuiming Club has an Id property
            await Navigation.PushAsync(new ChatPage(itemstrig.ToString()));
        }
        public async void AtualizarMensagens()
        {
            msg = await restService.GetMensagensListAsync(await SecureStorage.GetAsync("iduser"));
            msgList = msg.data;

            lista.ItemsSource = msgList;
        }
        protected override void OnAppearing()
        {
            AtualizarMensagens();
        }
    }
}