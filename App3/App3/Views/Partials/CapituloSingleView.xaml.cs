using App3.Models;
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
    public partial class CapituloSingleView : ContentView
    {
        public int ch2;
        public Biblia book2;
        public CapituloSingleView()
        {
            InitializeComponent();
        }

        public CapituloSingleView(int ch,Biblia book )
        {
            InitializeComponent();
            labelNum.Text = ch.ToString();
            ch2 = ch;
            book2 = book;
        }

        private async void TapGestureRecognizer_Tapped(object sender, EventArgs e)
        {
            await Navigation.PushModalAsync(new BibliaPage(book2.Nome, book2.Id, ch2.ToString(), book2));
        }
    }
}