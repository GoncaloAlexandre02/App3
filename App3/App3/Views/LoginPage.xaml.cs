using App3.Models;
using App3.Services;
using App3.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Xamarin.CommunityToolkit.Extensions;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace App3.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class LoginPage : ContentPage
    {

       RestService restService;
        User user;
        public LoginPage()
        {
            InitializeComponent();
            this.BindingContext = new LoginViewModel();
            restService = new RestService();
        }

        private async void Button_ClickedAsync(object sender, EventArgs e)
        {
           
            var regmail = @"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$";
            var email = txtEmail.Text;
            var password = txtPassword.Text;
            if (email == null || password == null || email == "" || password == "")
            {
                fEmail.BorderColor = Color.FromRgb(255, 0, 0);
                fPass.BorderColor = Color.FromRgb(255, 0, 0);
                await this.DisplayToastAsync("Preencha todos os campos!", 2000);
            }
            else if (!Regex.IsMatch(email, regmail))
            {
                fEmail.BorderColor = Color.FromRgb(255, 0, 0);
               
                await this.DisplayToastAsync("Email Invalido", 2000);
            }
            else
            {
                
                var pass2 = MD5Hash.Hash.Content(password);
                var data = "{email :" + email + " , password : " + password + "}";
                user = await restService.PostLogin(data, email, pass2);
                if (user == null)
                {
                    fEmail.BorderColor = Color.FromRgb(255, 0, 0);
                    fPass.BorderColor = Color.FromRgb(255, 0, 0);
                    await this.DisplayToastAsync("Utilizador ou Password, Incorretos", 5000);
                }
                else
                {
                    
                    SecureStorage.RemoveAll();
                   
                    await SecureStorage.SetAsync("iduser", user.Iduser.ToString());
                    await this.DisplayToastAsync(user.Tokenuser, 500);
                    await Shell.Current.GoToAsync("//Home");
                }
            }

             //await Shell.Current.GoToAsync("//Home");
        }
    }
}