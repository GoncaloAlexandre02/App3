using App3.Models;
using App3.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace App3.Views.Partials
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class DepartamentoSingleView : ContentView
    {
        Departamento depart2;
        List<Responsavel> bbb;
        RestService restService;
        public DepartamentoSingleView()
        {
            InitializeComponent();
            restService = new RestService();
        }

        public DepartamentoSingleView(Departamento depart)
        {
            InitializeComponent();
            depart2 = depart;
            nomeDepart.Text = depart.Nomedepart.ToString();
            restService = new RestService();
            AtualizaResp(depart.Iddepart);


        }
        public async void AtualizaResp(int iddepart)
        {
            
            try
            {
  
                bbb = await restService.GetResponsaveisAsync(iddepart);
                
                nomeUser.Text = bbb[0].NomeUser.ToString();
                
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                nomeUser.Text = "";
            }
            
        }

        private void TapGestureRecognizer_Tapped(object sender, EventArgs e)
        {
            Navigation.PushAsync(new DepartamentoPage1(depart2.Iddepart.ToString()));
        }
    }
}