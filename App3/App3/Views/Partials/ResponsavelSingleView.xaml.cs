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
    public partial class ResponsavelSingleView : ContentView
    {
        //Responsavel resp2;
        public ResponsavelSingleView()
        {
            InitializeComponent();
        }
        /*
        public ResponsavelSingleView(Responsavel resp)
        {
            InitializeComponent();
            resp2 = resp;
            resplabel.Text = resp.NomeUser;
            
            
        }

        private async void TapGestureRecognizer_Tapped(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new ChatPage(resp2.Iduser.ToString()));
        }*/
    }
}