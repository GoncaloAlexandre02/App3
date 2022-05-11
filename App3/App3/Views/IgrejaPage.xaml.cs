using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using App3.Services;
using App3.Models;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Newtonsoft.Json;
using Xamarin.CommunityToolkit.Extensions;
namespace App3.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class IgrejaPage : ContentPage
    {
        RestService restService;
        List<Igreja> igreja ;

        public IgrejaPage()
        {
            InitializeComponent();
            Navigation.ShowPopup(new PopUpLoading());
            //restService = new RestService();
            //AtualizaDados();
            

            
            
        }

        async void AtualizaDados()
        {
            igreja = await restService.GetIgrejasAsync();
            
            descIg.Text = igreja[0].Descigreja.ToString();
            teleL.Text = igreja[0].Telefoneigreja.ToString();
            moradaL.Text = igreja[0].Moradaigreja.ToString();

        }
    }
}