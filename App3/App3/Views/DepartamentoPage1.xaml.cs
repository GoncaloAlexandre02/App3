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
    public partial class DepartamentoPage1 : ContentPage
    {
        RestService restService;
        Departamento depart;
        List<Responsavel> resp;
        public DepartamentoPage1()
        {
            InitializeComponent();
        }
        public DepartamentoPage1(string id)
        {
            InitializeComponent();
            restService = new RestService();
            AtualizaDepartamento(id);

        }

        async void AtualizaDepartamento(string id)
        {
            depart = await restService.GetDepartamentoAsync(id);

            titulolabel.Text = depart.Nomedepart;
            desclabel.Text = depart.Descdepart;

            EcraResp.Children.Clear();
            EcraResp.Children.Add(new Label { Text = "Coordenadores", Padding = new Thickness(0, 0, 0, 20), FontSize=16,FontFamily="OpenSans-SemiBold",TextColor=Color.FromHex("#4568C7") });
            try
            {
                resp = await restService.GetResponsaveisAsync(depart.Iddepart);
                foreach (Responsavel respon in resp) ;
                //EcraResp.Children.Add(new ResponsavelSingleView(respon));
                

            }catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            try
            {
                if (depart.Imgdepart == null)
                {
                    //imgD.Source = "rezar";
                }
                else
                {
                    //imgD.Source = await restService.GetImagemServer(depart.Imgdepart);
                }

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                //imgD.Source = "rezar";
            }

        }
        private void ImageButton_Clicked(object sender, EventArgs e)
        {
            var change = stack3.Children.OfType<Label>().ToArray();

            foreach (var item in change)
            {
                item.FontSize -= 2;
            }
        }

        private void ImageButton_Clicked_1(object sender, EventArgs e)
        {
            var change = stack3.Children.OfType<Label>().ToArray();

            foreach (var item in change)
            {
                item.FontSize += 2;
            }
        }

        private void ImageButton_Clicked_2(object sender, EventArgs e)
        {
            BibliaPage.ModoLeitura(scrollP);

        }
    }
}