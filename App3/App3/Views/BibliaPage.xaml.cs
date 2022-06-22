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

namespace App3.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class BibliaPage : ContentPage
    {
        RestService restService;
        Root biblia;
        public BibliaPage()
        {
            InitializeComponent();
            var chList = new List<Int32>();
            Navigation.ShowPopup(new PopUpLoading());
            restService = new RestService();
            for (int i = 1; i <= 50; i++)
                chList.Add(i);

            AtualizaDados("1", "gen");

        }
        public BibliaPage (string nomebook,string book, string chapter)
        {
            InitializeComponent();
            Navigation.ShowPopup(new PopUpLoading());
            restService = new RestService();
            titleL.Text = nomebook;
            titleLN.Text = chapter;
            AtualizaDados(chapter, book);


        }

        async void AtualizaDados(string chapter, string book)
        {
            aa.Text = "";
            biblia = await restService.GetVerses(chapter, book);
            foreach (var item in biblia.verses)
                aa.Text += item.verse + ". " + item.text + '\n' + '\n';


        }

        async private void Button_Clicked_Livro(object sender, EventArgs e)
        {
            
            await Navigation.PushAsync(new BibliaLivroPage());
        }

        async void Button_Clicked_Capitulo(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new BibliaCapituloPage());
        }
    }
}