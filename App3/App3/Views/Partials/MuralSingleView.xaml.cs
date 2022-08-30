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
    public partial class MuralSingleView : ContentView
    {
        public MuralSingleView()
        {
            InitializeComponent();
        }
        private Mural mural2;
        public MuralSingleView(Mural mural1)
        {
            InitializeComponent();
            mural2 = mural1;
            Motivo.Text = mural1.Motivo.ToString();
            Descmural.Text = mural1.Descmural.ToString();
            Nomeuser.Text = mural1.Nomeuser.ToString();
        }

        private async void ImageButton_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new ChatPageMural(mural2));
        }
    }
}