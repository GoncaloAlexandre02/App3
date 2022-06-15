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

    
    public partial class NoticiaPage : ContentPage
    {

        List<Noticia> noticiaList = new List<Noticia>();
        public NoticiaPage()
        {
            InitializeComponent();
            noticiaList.Add(new Noticia() { dataNoticia = "06 de jun de 2022"});
            lista.ItemsSource = noticiaList;
           
        }

        async void lista_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            await Navigation.PushAsync(new NoticiaPage1());
           
        }
    }
}