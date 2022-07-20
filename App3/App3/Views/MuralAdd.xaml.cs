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
    public partial class MuralAdd : ContentPage
    {

        RestService restService;
        Mural mural;
        public MuralAdd()
        {
            InitializeComponent();
            restService = new RestService();
        }

        private async void Button_ClickedAsync(object sender, EventArgs e)
        {
            try
            {
                var motivo = Motivo.Text;
                var descmural = DescM.Text;
                var visita = "nao";
                var ligacao = "nao";
                var publicar = "nao";
                var iduser = await SecureStorage.GetAsync("iduser");
                if (cVisitaSim.IsChecked)
                {
                    visita = "sim";
                }
                else if (cVisitaNao.IsChecked)
                {
                    visita = "nao";
                }
                if (cLigacaoSim.IsChecked)
                {
                    ligacao = "sim";
                }
                else
                {
                    ligacao = "nao";
                }
                if (cPublicarSim.IsChecked)
                {
                    publicar = "sim";
                }
                else
                {
                    publicar = "nao";
                }

                if (motivo == null || descmural == null || cVisitaNao == null || cVisitaSim == null || cPublicarNao == null || cPublicarSim == null || cLigacaoNao == null || cLigacaoSim == null || motivo == "" || descmural == "")
                {
                    await this.DisplayToastAsync("Campos Invalidos", 2000);
                }
                else
                {
                    string data = @"{'iduser':'" + iduser + "', 'motivo':'" + motivo + "', 'descmural':'" + descmural + "', 'visita':'" + visita + "', 'ligacao':'" + ligacao + "', 'publicar':'" + publicar + " '}";
                    var dataal = data.Replace('\'', '\"');
                    var res = await restService.AddMurais(dataal);
                    if (res == null)
                    {
                        await this.DisplayToastAsync("Erro ao Criar Mural, Tente mais Tarde", 5000);
                    }
                    else if (res.IsSuccessStatusCode)
                    {

                        await Navigation.PushAsync(new MuralPage());
                    }
                    Console.WriteLine(res.ToString());


                }
            }
            catch (NullReferenceException ex)
            {
                await this.DisplayToastAsync("Campos Invalidos", 2000);
            }


        }


    }
}