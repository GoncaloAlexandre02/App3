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
    public partial class BibliaCapituloPage : ContentPage

    {

        RestService restService;
        Root biblia;
        public BibliaCapituloPage()
        {

            InitializeComponent();
            var chList = new List<Int32>();

            restService = new RestService();
           


            var selectedIndex = listaC.SelectedItem as Biblia;
            for (int i = 1; i <= selectedIndex.Ch; i++)
                chList.Add(i);
            listaC.ItemsSource = chList;

        }

        public BibliaCapituloPage(string nomebook, string book, string chapter)
        {

        }




    }
}