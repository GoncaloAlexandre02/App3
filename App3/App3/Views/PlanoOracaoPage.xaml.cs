using Rg.Plugins.Popup.Extensions;
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
    public partial class PlanoOracaoPage : ContentPage
    {
        public PlanoOracaoPage()
        {
            InitializeComponent();
        }

        private void Plano_Clicked(object sender, EventArgs e)
        {
            Navigation.PushPopupAsync(new PlanoPopup());
        }
    }
}