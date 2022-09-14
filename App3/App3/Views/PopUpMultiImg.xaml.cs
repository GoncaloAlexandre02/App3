using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Rg.Plugins.Popup.Services;
using Xamarin.CommunityToolkit.UI.Views;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace App3.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class PopUpMultiImg : Popup
    {
        public PopUpMultiImg(ICollection<Image> img)
        {

            InitializeComponent();
            CarouselImg.ItemsSource = img;
        }


    }
}