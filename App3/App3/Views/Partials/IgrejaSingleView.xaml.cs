using App3.Models;
using App3.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace App3.Views.Partials
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class IgrejaSingleView : ContentView
    {
        Igreja igreja2;
        RestService restService;
        string estado2 =null;
        public IgrejaSingleView()
        {
            InitializeComponent();
        }
        public IgrejaSingleView(Igreja igreja)
        {
            InitializeComponent();
            igreja2 = igreja;   
            nome.Text = igreja.Nomeigreja;
            morada.Text = igreja.Moradaigreja;
        }
        public IgrejaSingleView(string id, string estado)
        {
            InitializeComponent();
            restService = new RestService();
            estado2 = estado;
            AtualizarIgreja(id);
        }

        public async void AtualizarIgreja(string id)
        {
            var aaa = await restService.GetIgrejasAsync();

            foreach(var igreja in aaa.data)
            {
                if(igreja.Idigreja.ToString() == id)
                {
                    igreja2 = igreja;
                    nome.Text = igreja.Nomeigreja;
                    morada.Text = igreja.Moradaigreja;

                }
            }

        }
        private async void TapGestureRecognizer_Tapped(object sender, EventArgs e)
        {
            try
            {
                if (estado2 == null)
                    await Navigation.PushAsync(new IgrejaPage2(igreja2));
                else
                    await Navigation.PushAsync(new IgrejaPage2(igreja2, estado2));
            }catch (Exception ex)
            {
                await Navigation.PushAsync(new IgrejaPage2(igreja2));
            }
        }
    }
}