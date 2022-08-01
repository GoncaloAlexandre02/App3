using App3.Models;
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
    public partial class BatismoPage : ContentPage
    {
        RestService restService;
        public BatismoPage()
        {
            InitializeComponent();
            restService = new RestService();
            AtualizarIgrejas();

        }

        public async void AtualizarIgrejas()
        {
            var aaa = await restService.GetIgrejasAsync();

            picker.SetBinding(Picker.ItemsSourceProperty, "Igrejas");
            picker.ItemDisplayBinding = new Binding("Nomeigreja");
            picker.ItemsSource = aaa.data;
        }
        private async void ButtonEnviar_Clicked(object sender, EventArgs e)
        {
            var nome = txtNome.Text;
            var telemovel = txtTelemovel.Text;
            var email = txtEmail.Text;
            var dt = txtData.Date;

            var item = (Igreja)picker.SelectedItem;

            if (nome == null || telemovel == null || email == null || dt == null || item == null)
            {
                await this.DisplayToastAsync("Preencha todos os campos", 2000);
            }
            else
            {
                Console.WriteLine(item.Idigreja.ToString());
                string data = @"{'iduser':'" + await SecureStorage.GetAsync("iduser") + "', 'idgreja':'" + item.Idigreja.ToString() + "', 'nomebatismo':'" + nome + "', 'telemovelbatismo':'" + telemovel + "', 'emailbatismo':'" + email + "', 'dtbatismo':'" + dt.ToString("dd-MM-yyyy") + "' }";
                var dataal = data.Replace('\'', '\"');
                Console.Write(dataal);
                var res = await restService.AddBatismo(dataal);
                if (res == null)
                {
                    await this.DisplayToastAsync("Erro ao registar batismo, Tente mais Tarde", 5000);
                }
                else if (res.IsSuccessStatusCode)
                {
                    await this.DisplayToastAsync("Batismo Registado", 2000);
                    await Navigation.PushAsync(new HomeLayout2());
                }
            }


        }
    }
}