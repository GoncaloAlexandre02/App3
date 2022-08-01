using App3.Models;
using App3.Services;
using Rg.Plugins.Popup.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.CommunityToolkit.Extensions;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace App3.Views
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class IgrejaPage2 : ContentPage
	{
        Igreja igreja2;
        RestService restService;
        public IgrejaPage2()
        {
            InitializeComponent();
            restService = new RestService();
        }

        public IgrejaPage2(Igreja igreja)
        {
            InitializeComponent();
            restService = new RestService();
            igreja2 = igreja;
            nome.Text = igreja.Nomeigreja;
            morada.Text = igreja.Moradaigreja;
            morada2.Text = igreja.Moradaigreja;
            tele.Text = igreja.Telefoneigreja;
            AtualizarEstado();
        }
        public IgrejaPage2(Igreja igreja, string estado)
        {
            InitializeComponent();
            restService = new RestService();
            nome.Text = igreja.Nomeigreja;
            morada.Text = igreja.Moradaigreja;
            morada2.Text = igreja.Moradaigreja;
            tele.Text = igreja.Telefoneigreja;
            igreja2 = igreja;
            if (estado == "sim")
            {
                fav.IsVisible = false;
                favp.IsVisible = true;
            }
            else
            {
                fav.IsVisible = true;
                favp.IsVisible = false;
            }
        }

        public async void AtualizarEstado()
        {
            var bbb = await restService.GetIgrejasFavAsync(await SecureStorage.GetAsync("iduser"));

            foreach (var favIgreja in bbb.data)
            {
                if (igreja2.Idigreja == favIgreja.Idigreja)
                {
                    if (favIgreja.Estado == "sim")
                    {
                        fav.IsVisible = false;
                        favp.IsVisible = true;
                    }
                    else
                    {
                        fav.IsVisible = true;
                        favp.IsVisible = false;
                    }
                }
            }
        }
        private async void TapGestureRecognizer_Tapped(object sender, EventArgs e)
        {
            try
            {
                var sim = "sim";
                string data = @"{'idigreja':'" + igreja2.Idigreja.ToString() + "','iduser':'" + await SecureStorage.GetAsync("iduser") + "', 'estado':'" + sim + "'}";
                var dataal = data.Replace('\'', '\"');
                var res = await restService.UpdateFavIgreja(dataal, await SecureStorage.GetAsync("iduser"));
                Console.WriteLine(res);
                if (res.IsSuccessStatusCode)
                {
                    fav.IsVisible = false;
                    favp.IsVisible = true;
                    await this.DisplayToastAsync("Adicionada aos favoritos", 2000);
                }
                else
                {
                    await this.DisplayToastAsync("Erro, tente mais tarde!", 2000);

                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }


        }

        private async void TapGestureRecognizer_Tapped_1(object sender, EventArgs e)
        {
            try
            {
                var sim = "nao";
                string data = @"{'idigreja':'" + igreja2.Idigreja.ToString() + "','iduser':'" + await SecureStorage.GetAsync("iduser") + "', 'estado':'" + sim + "'}";
                var dataal = data.Replace('\'', '\"');
                var res = await restService.UpdateFavIgreja(dataal, await SecureStorage.GetAsync("iduser"));
                Console.WriteLine(res);
                if (res.IsSuccessStatusCode)
                {
                    fav.IsVisible = true;
                    favp.IsVisible = false;
                    await this.DisplayToastAsync("Removida dos favoritos", 2000);
                }
                else
                {
                    await this.DisplayToastAsync("Erro, tente mais tarde!", 2000);

                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }

        }

        private void TapGestureRecognizer_Tapped_Horario(object sender, EventArgs e)
        {
            Navigation.PushPopupAsync(new IgrejaHorarioPopup());
        }
    }
}