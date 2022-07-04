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
    public partial class DonatePage : ContentPage
    {
        public DonatePage()
        {
            InitializeComponent();
        }

        private void TapGestureRecognizer_Tapped_MBW(object sender, EventArgs e)
        {
            MBWAY.IsVisible= true;
            MB.IsVisible= false;
            CC.IsVisible= false;

        }

        private void TapGestureRecognizer_Tapped_CC(object sender, EventArgs e)
        {
            MBWAY.IsVisible = false;
            MB.IsVisible = false;
            CC.IsVisible = true;
        }

        private void TapGestureRecognizer_Tapped_MB(object sender, EventArgs e)
        {
            MBWAY.IsVisible = false;
            MB.IsVisible = true;
            CC.IsVisible = false;
        }
    }
}