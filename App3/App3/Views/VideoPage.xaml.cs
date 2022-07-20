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
    public partial class VideoPage : ContentPage
    {
        public VideoPage()
        {
            InitializeComponent();
        }

        private void Button_Clicked_Youtube(object sender, EventArgs e)
        {

            scrollYoutube.IsVisible = true;
            scrollVip.IsVisible = false;
            AddVideo.IsVisible = false;

        }

        private void Button_Clicked_VIP(object sender, EventArgs e)
        {
            scrollYoutube.IsVisible = false;
            scrollVip.IsVisible = true;
            AddVideo.IsVisible = true;
        }

        private void TapGestureRecognizer_Tapped_Add(object sender, EventArgs e)
        {
            Navigation.PushPopupAsync(new VideoAddPopup());
        }
    }
}
  