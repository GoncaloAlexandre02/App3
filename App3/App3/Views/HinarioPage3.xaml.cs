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
    public partial class HinarioPage3 : ContentPage
    {
        RestService restService;
        List<Hinario> hinarioList = new List<Hinario>();
        RootHinario hin;
        public HinarioPage3()
        {
            InitializeComponent();
            restService = new RestService();

        }
        public HinarioPage3(string nome)
        {
            InitializeComponent();
            restService = new RestService();
            AtualizarDescHinario(nome);
            titulo.Text = nome;
        }

        async void AtualizarDescHinario(string nome)
        {
            hin = await restService.GetDescHinarioAsync(nome);
            hinarioList = hin.data;
            hinarioList.RemoveAt(0);
            aa.Text = hinarioList[0].DescHinario;
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

    }
}