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
        string nomebook2;
        string book2;
        string chapter2;
        Biblia biblia2;
        Versiculo versi2;
        public static int modo = 1;

        public BibliaPage()
        {
            InitializeComponent();
            var chList = new List<Int32>();

            restService = new RestService();
            for (int i = 1; i <= 50; i++)
                chList.Add(i);
            nomebook2 = "Gênesis";
            AtualizaDados("1", "gen");
            book2 = "gen";
            chapter2 = "1";
        }
        public BibliaPage(string nomebook, string book, string chapter, Biblia bibliaIndex)
        {
            InitializeComponent();

            restService = new RestService();
            titleL.Text = nomebook;
            titleLN.Text = chapter;
            nomebook2 = nomebook;
            biblia2 = bibliaIndex;
            book2 = book;
            chapter2 = chapter;
            AtualizaDados(chapter, book);


        }
        public BibliaPage(string nomebook, string book, string chapter, string verse, Versiculo versiculoIndex)
        {
            InitializeComponent();

            restService = new RestService();
            titleL.Text = nomebook;
            titleLN.Text = chapter;
            nomebook2 = nomebook;
            book2 = book;
            chapter2 = chapter;
            versi2 = versiculoIndex;
            AtualizaDadosVerso(chapter, book, verse);


        }

        /*  void OnPickerSelectedIndexChanged(object sender, EventArgs e)
          {
              var chList = new List<Int32>();
              var selectedIndex = pickerB.SelectedItem as Biblia;
              titleL.Text = selectedIndex.Nome;

                  // aa.Text = selectedIndex.Id;

              for(int i = 1; i <= selectedIndex.Ch; i++)
                  chList.Add(i);
              titleLN.Text = "1";
              pickerC.ItemsSource = chList;

              AtualizaDados("1", selectedIndex.Id.ToString());
          }
          void OnPickerSelectedIndexChangedCh(object sender, EventArgs e)
          {
              var selectedIndex = pickerB.SelectedItem as Biblia;
              var selectedCh = pickerC.SelectedItem;
              try
              {
                  titleLN.Text = selectedCh.ToString();

                  AtualizaDados(selectedCh.ToString(), selectedIndex.Id.ToString());
              }
              catch(Exception ex)
              {
                  titleLN.Text = "1";

                  AtualizaDados("1", selectedIndex.Id.ToString());

              }



          }*/
        async void AtualizaDados(string chapter, string book)
        {
            aa.Text = "";
            biblia = await restService.GetVerses(chapter, book);
            titleL.Text = nomebook2;
            titleLN.Text = chapter;
            corpoB.Children.Clear();
            foreach (var item in biblia.verses)
            {

                corpoB.Children.Add(new Label { Text = item.verse + ". " + item.text + '\n', HorizontalTextAlignment = TextAlignment.Start, FontFamily = "OpenSans-SemiBold", FontSize = 16, TextColor = Color.FromHex("#4d4d4d"), Padding = 0 });

            }
            if (chapter == "1")
            {
                setaAnt.IsVisible = false;
            }
            else
            {
                setaAnt.IsVisible = true;
            }
            try
            {
                if (biblia != null)
                {
                    if (chapter == biblia2.Ch.ToString())
                    {
                        setaProx.IsVisible = false;
                    }
                    else
                    {
                        setaProx.IsVisible = true;
                    }
                }
                else if (versi2 != null)
                {
                    if (chapter == versi2.ChTotal.ToString())
                    {
                        setaProx.IsVisible = false;
                    }
                    else
                    {
                        setaProx.IsVisible = true;
                    }
                }
                else
                {
                    if (chapter == "50")
                    {
                        setaProx.IsVisible = false;
                    }
                    else
                    {
                        setaProx.IsVisible = true;
                    }
                }
            }
            catch (Exception ex)
            {

                if (chapter == "50")
                {
                    setaProx.IsVisible = false;
                }
                else
                {
                    setaProx.IsVisible = true;
                }
            }




        }
        async void AtualizaDadosVerso(string chapter, string book, string verse)
        {
            aa.Text = "";
            biblia = await restService.GetVerses(chapter, book);
            corpoB.Children.Clear();
            foreach (var item in biblia.verses)
            {
                if (item.verse.ToString() == verse)
                {
                    corpoB.Children.Add(new Label { Text = item.verse + ". " + item.text + '\n', HorizontalTextAlignment = TextAlignment.Start, FontFamily = "OpenSans-SemiBold", FontSize = 16, TextColor = Color.FromHex("#4d4d4d"), Padding = 0, BackgroundColor = Color.FromHex("#a6e6ff"), ClassId = "ola" });
                    await scrollP.ScrollToAsync(corpoB.Children.LastOrDefault(), ScrollToPosition.MakeVisible, true);
                }
                else
                    corpoB.Children.Add(new Label { Text = item.verse + ". " + item.text + '\n', HorizontalTextAlignment = TextAlignment.Start, FontFamily = "OpenSans-SemiBold", FontSize = 16, TextColor = Color.FromHex("#4d4d4d"), Padding = 0 });
            }


        }


        async private void Button_Clicked_Livro(object sender, EventArgs e)
        {

            await Navigation.PushModalAsync(new BibliaLivroPage());

        }

        async void Button_Clicked_Capitulo(object sender, EventArgs e)
        {
            await Navigation.PushModalAsync(new BibliaLivroPage());
        }

        private void TapGestureRecognizer_TappedAnterior(object sender, EventArgs e)
        {

            if (int.Parse(chapter2) > 0)
            {
                chapter2 = (int.Parse(chapter2) - 1).ToString();
            }
            Console.WriteLine("CLIQUEI NA SETA ANTERIOR");
            AtualizaDados(chapter2, book2);
        }

        private void TapGestureRecognizer_TappedProximo(object sender, EventArgs e)
        {
            if (int.Parse(chapter2) < 50)
            {
                chapter2 = (int.Parse(chapter2) + 1).ToString();
            }

            Console.WriteLine("CLIQUEI NA SETA PROXIMA " + chapter2);
            AtualizaDados(chapter2, book2);
        }

        private void AumentarLetra(object sender, EventArgs e)
        {
            var change = corpoB.Children.OfType<Label>().ToArray();

            foreach (var item in change)
            {
                item.FontSize += 2;
            }
        }
        private void DiminuirLetra(object sender, EventArgs e)
        {
            var change = corpoB.Children.OfType<Label>().ToArray();

            foreach (var item in change)
            {
                item.FontSize -= 2;
            }
        }
        public static void ModoLeitura(ScrollView stackLayout)
        {


            if (modo == 1)
            {

                stackLayout.BackgroundColor = Color.FromHex("#FBF0D9");
                modo = 2;
            }
            else if (modo == 2)
            {
                stackLayout.BackgroundColor = Color.White;
                modo = 1;
            }

        }
        public static void ModoLeitura(StackLayout stackLayout)
        {


            if (modo == 1)
            {

                stackLayout.BackgroundColor = Color.FromHex("#FBF0D9");

            }
            else if (modo == 2)
            {
                stackLayout.BackgroundColor = Color.White;

            }

        }
        private void Leitura(object sender, EventArgs e)
        {
            ModoLeitura(scrollP);
        }

        private void ImageButton_Clicked(object sender, EventArgs e)
        {

        }
    }
}