using App3.Models;
using App3.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Xamarin.CommunityToolkit.Extensions;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace App3.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class RegisterPage : ContentPage
    {

        RestService restService;
        User user;
        public RegisterPage()
        {
            InitializeComponent();
            restService = new RestService();
        }

        private async void Button_ClickedAsync(object sender, EventArgs e)
        {
            var regmail = @"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$";
            var nome = txtNome.Text;
            var apelido = txtApelido.Text;
            var tele = txtTelefone.Text;
            //var dtnasc = txtDtNas.Date.ToString("yyyy-MM-dd");
            var email = txtEmail.Text;
            var password = txtPassword.Text;
            if (nome == null || email == null || password == null || tele == null || apelido == null || nome == "" || email == "" || password == "" || tele == "" || apelido == "")
            {
                fEmail.BorderColor = Color.FromRgb(255, 0, 0);
                fNome.BorderColor = Color.FromRgb(255, 0, 0);
                fApelido.BorderColor = Color.FromRgb(255, 0, 0);
                fTele.BorderColor = Color.FromRgb(255, 0, 0);
                //fDtNas.BorderColor = Color.FromRgb(255, 0, 0);
                fPass.BorderColor = Color.FromRgb(255, 0, 0);
                await this.DisplayToastAsync("Preencha Todos os Campos", 2000);

            }
            else if (!Regex.IsMatch(email, regmail))
            {
               
                fEmail.BorderColor = Color.FromRgb(255, 0, 0);
                await this.DisplayToastAsync("Email Invalido", 2000);

            }
            else
            {
               

                var pass2 = MD5Hash.Hash.Content(password);
                string data = @"{'nome':'" + nome + "', 'apelido':'" + apelido + "', 'email':'" + email + "', 'password':'" + pass2 + "', 'morada':' ', 'telefone':'" + tele + "', 'emailativo':'nao', 'tipouser':2}";
                var dataal = data.Replace('\'', '\"');
                //await this.DisplayToastAsync(dataal, 3000);

                var res = await restService.PostRegister(dataal);
                if (res == null)
                {
                    await this.DisplayToastAsync("Erro ao Registar, Tente mais Tarde", 5000);
                }
                else if (res.IsSuccessStatusCode)
                {
                    await this.DisplayToastAsync("Conta Criada", 2000);
                    await Navigation.PushModalAsync(new Views.LoginPage());
                }
                else if (res.StatusCode.ToString().Contains("Conflict"))
                {
                    fEmail.BorderColor = Color.FromRgb(255, 0, 0);
                    await this.DisplayToastAsync("Email ja esta em uso!", 2000);

                }
            }
        }
    }
}