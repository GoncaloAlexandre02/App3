using App3.Models;
using App3.Services;
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
    public partial class BibliaPage : ContentPage
    {
        RestService restService;
        Root biblia;
        public BibliaPage()
        {
            InitializeComponent();
            var chList = new List<Int32>();
            Navigation.ShowPopup(new PopUpLoading());
            restService = new RestService();
            for (int i = 1; i <= 50; i++)
                chList.Add(i);
          
            AtualizaDados("1","gen");
            
        }
        void OnPickerSelectedIndexChanged(object sender, EventArgs e)
        {
            var chList = new List<Int32>();
            var selectedIndex = pickerB.SelectedItem as Biblia;
            titleL.Text = selectedIndex.Nome;
            
                // aa.Text = selectedIndex.Id;
                
            for(int i = 1; i <= selectedIndex.Ch; i++)
                chList.Add(i);
            titleLN.Text = "1";
            pickerC.ItemsSource = chList;
            
            AtualizaDados("1", selectedIndex.Id.ToString());
        }
        void OnPickerSelectedIndexChangedCh(object sender, EventArgs e)
        {
            var selectedIndex = pickerB.SelectedItem as Biblia;
            var selectedCh = pickerC.SelectedItem;
            try
            {
                titleLN.Text = selectedCh.ToString();
                
                AtualizaDados(selectedCh.ToString(), selectedIndex.Id.ToString());
            }
            catch(Exception ex)
            {
                titleLN.Text = "1";
          
                AtualizaDados("1", selectedIndex.Id.ToString());
                
            }
            
            
            
        }
        async void AtualizaDados(string chapter,string book)
        {           
            aa.Text = "";
            biblia = await restService.GetVerses(chapter,book);
            foreach (var item in biblia.verses)            
            aa.Text += item.verse +". "+item.text + '\n' + '\n';
           

        }

    }
}