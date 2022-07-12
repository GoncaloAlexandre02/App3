using App3.Models;
using App3.Services;
using App3.Views.Partials;
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
    public partial class BibliaCapituloPage : ContentPage

    {

        RestService restService;
        Root biblia;
        int livroch;
        string livronome;
        string livroid;
        Biblia selectedIndex;
        public BibliaCapituloPage()
        {

            InitializeComponent();
            var chList = new List<Int32>();

            restService = new RestService();



            // selectedIndex = listaC.SelectedItem as Biblia;
            // for (int i = 1; i <= selectedIndex.Ch; i++)
            //  chList.Add(i);
            // listaC.ItemsSource = chList;


        }
        public BibliaCapituloPage(string id, string nome, int ch, Biblia bibliaIndex)
        {
            InitializeComponent();
            var chList = new List<Item>();
            livroch = ch;
            livronome = nome;
            livroid = id;
            restService = new RestService();
            selectedIndex = bibliaIndex;
            Ecraflex.Children.Clear();
            try
            {

                for (int i = 1; i <= ch; i++)
                {
                    Ecraflex.Children.Add(new CapituloSingleView(i, selectedIndex));
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            // listaC.ItemsSource = chList;


        }

        /* private async void listaC_ItemSelected(object sender, SelectedItemChangedEventArgs e)
         {
             var item = (Item)listaC.SelectedItem;
             await Navigation.PushModalAsync(new BibliaPage(livronome, livroid,item.Id,selectedIndex));

         } */
        private async void TapGestureRecognizer_Tapped_livro(object sender, EventArgs e)
        {
            await Navigation.PushModalAsync(new BibliaLivroPage());

        }


    }
}