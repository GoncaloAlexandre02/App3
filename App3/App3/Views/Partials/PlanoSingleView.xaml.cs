using App3.Models;
using App3.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.CommunityToolkit.Extensions;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace App3.Views.Partials
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class PlanoSingleView : ContentView
    {
        RestService restService;
        Plano plano2;
        public PlanoSingleView()
        {
            InitializeComponent();
        }

        public PlanoSingleView(Plano plano)
        {
            InitializeComponent();
            plano2 = plano;
            restService = new RestService();
            var hora1 = plano.Hora.ToString();
            
            hora.Text = hora1.Remove(5);
            dia.Text = plano.Dia.ToString();
            if(plano2.Ativo == "sim")
            {
                ativar.IsToggled = true;
            }
            else
            {
                ativar.IsToggled = false;
            }
        }

        private async void ativar_Toggled(object sender, ToggledEventArgs e)
        {
            var sim = "sim";
            var nao = "nao";
            
            try {
                 
                if (ativar.IsToggled == true)
            {
                string data = @"{'idplano':'" + plano2.Idplano.ToString() + "','iduser':'" + plano2.Iduser.ToString() + "', 'dia':'" + plano2.Dia + "', 'hora':'" + plano2.Hora + "','ativo':'" + sim + "'}";
                var dataal = data.Replace('\'', '\"');
                var res = await restService.UpdatePlano(dataal,plano2.Idplano.ToString());
                Console.WriteLine(res);
                if (res.IsSuccessStatusCode)
                {
                        plano2.Ativo = "sim";
                    await this.DisplayToastAsync("Ativado", 2000);
                }
                else
                {
                    await this.DisplayToastAsync("Erro, tente mais tarde!", 2000);

                }
            }
            else
            {
                string data = @"{'idplano':'" + plano2.Idplano.ToString() + "','iduser':'" + plano2.Iduser.ToString() + "', 'dia':'" + plano2.Dia + "', 'hora':'" + plano2.Hora + "','ativo':'" + nao + "'}";
                var dataal = data.Replace('\'', '\"');
                var res = await restService.UpdatePlano(dataal, plano2.Idplano.ToString());
                Console.WriteLine(res);
                if (res.IsSuccessStatusCode)
                {
                        plano2.Ativo = "nao";
                        await this.DisplayToastAsync("Desativado", 2000);
                }
                else
                {
                    await this.DisplayToastAsync("Erro, tente mais tarde!", 2000);

                }
            }
            }catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}