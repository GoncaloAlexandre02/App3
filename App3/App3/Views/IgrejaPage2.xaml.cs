using Rg.Plugins.Popup.Extensions;
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
	public partial class IgrejaPage2 : ContentPage
	{
		public IgrejaPage2 ()
		{
			InitializeComponent ();
		}

        private void TapGestureRecognizer_Tapped(object sender, EventArgs e)
        {
            fav.IsVisible = false;
            favp.IsVisible = true;
        }

        private void TapGestureRecognizer_Tapped_1(object sender, EventArgs e)
        {
            fav.IsVisible = true;
            favp.IsVisible = false;
        }

        private void TapGestureRecognizer_Tapped_Horario(object sender, EventArgs e)
        {
            Navigation.PushPopupAsync(new IgrejaHorarioPopup());
        }
    }
}