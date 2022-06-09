using App3.Models;
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
    public partial class HinarioPage1 : ContentPage
    {
        List<Hinario> hinarioList = new List<Hinario>();
        public HinarioPage1()
        {
            InitializeComponent();
            hinarioList.Add(new Hinario() { NomeHinario="1 - Harpa Cristã"});
            lista.ItemsSource = hinarioList;



        }
        async void OnItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            ListView lv = (ListView)sender;

            // this assumes your List is bound to a List<Club>

            var item = (Hinario)lista.SelectedItem;
            var itemstrig = item.NomeHinario;
            // assuiming Club has an Id property
            await Navigation.PushAsync(new HinarioPage2(itemstrig.ToString()));
        }
    }
}