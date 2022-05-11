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
    public partial class PlanoPopup : Rg.Plugins.Popup.Pages.PopupPage
    {
        public PlanoPopup()
        {
            InitializeComponent();
        }
    }
}