using App3.Services;
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
    public partial class PlanoPopup : Rg.Plugins.Popup.Pages.PopupPage
    {
        RestService restService;
        public PlanoPopup()
        {
            InitializeComponent();
            restService = new RestService();
        }

        private async void btnP_Clicked(object sender, EventArgs e)
        {

            var dia = pickerP.SelectedItem as string;
            var hora = horaP.Time.ToString();
            var user = await SecureStorage.GetAsync("iduser");
            var sim = "sim";
            if (dia != null && hora != null)
            {
                string data = @"{'iduser':'" + user + "', 'dia':'" + dia + "', 'hora':'" + hora + "','ativo':'" + sim + "'}";
                var dataal = data.Replace('\'', '\"');
                var res = await restService.AddPlano(dataal);
                Console.WriteLine(res);
                if (res.IsSuccessStatusCode)
                {
                    await this.DisplayToastAsync("Plano Criado!", 2000);
                    await Navigation.PushAsync(new PlanoOracaoPage());
                }
                else
                {
                    await this.DisplayToastAsync("Erro a criar Plano, tente mais tarde!", 2000);

                }
            }
            else
            {
                await this.DisplayToastAsync("Escolha todas as opções", 2000);
            }


        }
    }
}