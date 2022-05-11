using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.CommunityToolkit.UI.Views;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace App3.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class PopUpLoading : Popup
    {
        public PopUpLoading()
        {
            InitializeComponent();
            PopUpLoadingTime();
        }

        public async void PopUpLoadingTime()
        {
            await Task.Delay(2000);
            Dismiss(this);
        }

    }
}