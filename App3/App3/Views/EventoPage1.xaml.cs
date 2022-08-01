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
    public partial class EventoPage1 : ContentPage
    {
        RestService restService;
        Evento evento2;
        Pessoaevento pessoaevento;
        public EventoPage1()
        {
            InitializeComponent();
            restService = new RestService();
        }
        public EventoPage1(Evento evento)
        {
            InitializeComponent();
            restService = new RestService();
            evento2 = evento;
            AtualizarPessoaevento();
            titulolabel.Text = evento.Nome.ToString();
            dtlabel.Text = evento.Dtevento.ToString("HH:mm dd MMM");
            desclabel.Text = evento.Descevento.ToString();
        }
        public async void AtualizarPessoaevento()
        {
            try
            {


                var resp = await restService.GetPessoaeventoAsync(evento2.Idevento.ToString(), await SecureStorage.GetAsync("iduser"));

                if (resp[0].estado == "vai")
                {
                    bVou.BackgroundColor = Color.FromHex("#0a2a3b");
                    bNao.BackgroundColor = Color.FromHex("#035891");
                    bTalvez.BackgroundColor = Color.FromHex("#035891");
                }
                else if (resp[0].estado == "talvez")
                {
                    bTalvez.BackgroundColor = Color.FromHex("#0a2a3b");
                    bVou.BackgroundColor = Color.FromHex("#035891");
                    bNao.BackgroundColor = Color.FromHex("#035891");
                }
                else
                {
                    bNao.BackgroundColor = Color.FromHex("#0a2a3b");
                    bVou.BackgroundColor = Color.FromHex("#035891");
                    bTalvez.BackgroundColor = Color.FromHex("#035891");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        private async void bVou_Clicked(object sender, EventArgs e)
        {
            try
            {
                bVou.BackgroundColor = Color.FromHex("#0a2a3b");
                bNao.BackgroundColor = Color.FromHex("#035891");
                bTalvez.BackgroundColor = Color.FromHex("#035891");
                pessoaevento = new Pessoaevento { Idevento = evento2.Idevento, Iduser = int.Parse(await SecureStorage.GetAsync("iduser")), Estado = "vai" };
            var res = await restService.UpdatePessoaevento(pessoaevento, evento2.Idevento.ToString());
            }catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        private async void bTalvez_Clicked(object sender, EventArgs e)
        {
            try
            {
                bTalvez.BackgroundColor = Color.FromHex("#0a2a3b");
                bVou.BackgroundColor = Color.FromHex("#035891");
                bNao.BackgroundColor = Color.FromHex("#035891");
                pessoaevento = new Pessoaevento { Idevento = evento2.Idevento, Iduser = int.Parse(await SecureStorage.GetAsync("iduser")), Estado = "talvez" };
                var res = await restService.UpdatePessoaevento(pessoaevento, evento2.Idevento.ToString());
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        private async void bNao_Clicked(object sender, EventArgs e)
        {
            try
            {
                bNao.BackgroundColor = Color.FromHex("#0a2a3b");
                bVou.BackgroundColor = Color.FromHex("#035891");
                bTalvez.BackgroundColor = Color.FromHex("#035891");
                pessoaevento = new Pessoaevento { Idevento = evento2.Idevento, Iduser = int.Parse(await SecureStorage.GetAsync("iduser")), Estado = "nao" };
                var res = await restService.UpdatePessoaevento(pessoaevento, evento2.Idevento.ToString());
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        private void ImageButton_Clicked(object sender, EventArgs e)
        {
            var change = stack3.Children.OfType<Label>().ToArray();

            foreach (var item in change)
            {
                item.FontSize -= 2;
            }
        }

        private void ImageButton_Clicked_1(object sender, EventArgs e)
        {
            var change = stack3.Children.OfType<Label>().ToArray();

            foreach (var item in change)
            {
                item.FontSize += 2;
            }
        }

        private void ImageButton_Clicked_2(object sender, EventArgs e)
        {
            BibliaPage.ModoLeitura(scrollP);
     
        }

        private async void TapGestureRecognizer_Tapped(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new ChatPage("1"));
        }
    }
}