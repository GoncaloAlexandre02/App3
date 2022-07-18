using App3.Models;
using App3.Services;
using App3.Views.Partials;
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
    public partial class DepartamentoPage : ContentPage
    {
        List<Responsavel> bbb;
        RootDepartamento aaa;
        RestService restService;
        public DepartamentoPage()
        {
            InitializeComponent();
            restService = new RestService();
            AtualizarDepartamentos();
        }

        private async void AtualizarDepartamentos()
        {
            EcraDepart.Children.Clear();
            aaa = await restService.GetDepartamentosAsync();
            
            try
            {

                foreach (Departamento depart in aaa.data)
                {
                                       
                    EcraDepart.Children.Add(new DepartamentoSingleView(depart));
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }


    }
}