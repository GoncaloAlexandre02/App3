using App3.Models;
using App3.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace App3.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class VersiculoPage : ContentPage
    {
        RestService restService;
        Versiculo versiculo;

        public VersiculoPage()
        {
            InitializeComponent();
            restService = new RestService();
            AtualizaVersiculo();
        }

        public async void AtualizaVersiculo()
        {
            //versiculo = await restService.GetVersiculo();
            textV.Text = versiculo.Text;
            bookV.Text = versiculo.Book_name + " " + versiculo.Chapter + ":" + versiculo.Verse;
        }

        private async void Button_Clicked(object sender, EventArgs e)
        {
            //versiculo = await restService.GetVersiculo();
            await Navigation.PushAsync(new BibliaPage(versiculo.Book_name.ToString(), versiculo.Book_id.ToString(), versiculo.Chapter.ToString(), versiculo.Verse.ToString(), versiculo));
        }
    }
}
