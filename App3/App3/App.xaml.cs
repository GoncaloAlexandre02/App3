using App3.Services;
using App3.Views;
using System;
using System.Net.Http;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace App3
{
    public partial class App : Application
    {
        public static Action<string> PostSuccessFacebookAction { get; set; }

        public App(string page="")
        {
            Device.SetFlags(new string[] { "Brush_Experimental" });
            InitializeComponent();

            DependencyService.Register<MockDataStore>();
            MainPage = new AppShell();

            //Store page string from intent to be used later in the Home page
            Application.Current.Properties["intentPage"] = page;
        }
       
        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
