using Rg.Plugins.Popup.Extensions;
using Rg.Plugins.Popup.Services;
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
    public partial class MuralPage : ContentPage
    {
        public MuralPage()
        {
            InitializeComponent();
        }

        private void TapGestureRecognizer_Tapped_MuralPopup(object sender, EventArgs e)
        {
            Navigation.PushPopupAsync(new MuralPopup());

        }

        private async void AddMural_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new MuralAdd());
        }
    }
}