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
        private readonly IGoogleAuthService _googleService;
        GoogleUser GoogleUser = new GoogleUser();
        RestService restService;
        User user;

        string savedUsers;
        List<string> savedUsersList = new List<string>();

        public LoginPage()
        {
            InitializeComponent();
            this.BindingContext = new LoginViewModel();
            restService = new RestService();
            _googleService = DependencyService.Get<IGoogleAuthService>();

            savedUsers = Task.Run(() => SecureStorage.GetAsync("savedUsers")).Result;
            if (!string.IsNullOrEmpty(savedUsers))
            {
                savedUsersList = savedUsers.Split(';').ToList();
            }
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
                user = await restService.PostLogin(email, pass2);
                if (user == null)
                {
                    fEmail.BorderColor = Color.FromRgb(255, 0, 0);
                    fPass.BorderColor = Color.FromRgb(255, 0, 0);
                    await this.DisplayToastAsync("Utilizador ou Password, Incorretos", 5000);
                }
                else
                {

                    //SecureStorage.RemoveAll();
                    SecureStorage.Remove("iduser");
                    SecureStorage.Remove("tokenuser");

                    await SecureStorage.SetAsync("iduser", user.Iduser.ToString());
                    await SecureStorage.SetAsync("tokenuser", user.Tokenuser.ToString());
                    
                    if (remember.IsChecked)
                        await SecureStorage.SetAsync("userRemember", "1");
                    else
                        await SecureStorage.SetAsync("userRemember", "0");
                    

                    if (save.IsChecked)
                    {
                        await SecureStorage.SetAsync(user.Email, password);
                        if (!savedUsersList.Contains(user.Email))
                            savedUsersList.Add(user.Email);
                    }
                    else
                    {
                        SecureStorage.Remove(user.Email);
                        savedUsersList.Remove(user.Email);
                    }

                    await SecureStorage.SetAsync("savedUsers", string.Join(";", savedUsersList));

                    // await this.DisplayToastAsync(user.Tokenuser, 500);
                    await Shell.Current.GoToAsync("//Home");
                }
            }

             //await Shell.Current.GoToAsync("//Home");
        }

        private async void txtEmail_TextChanged(object sender, TextChangedEventArgs e)
        {
            var email = e.NewTextValue;
            if (!string.IsNullOrWhiteSpace(email))
            {
                //var us = await SecureStorage.GetAsync(email);
                //if (us != null)
                //{
                //    txtPassword.Text = us;
                //    save.IsChecked = true;
                //}

                try
                {
                    countryListView.BeginRefresh();

                    var like = savedUsersList.Where(u => u.Contains(email));

                    countryListView.ItemsSource =like;

                    if (like.Count() == 0)
                    {
                        listLayout.IsVisible = false;
                        countryListView.IsVisible = false;
                    }  
                    else
                    {
                        listLayout.IsVisible = true;
                        countryListView.IsVisible = true;
                    }
                        
                }
                catch (Exception ex)
                {
                    listLayout.IsVisible = false;
                    countryListView.IsVisible = false;
                }
                finally
                {
                    countryListView.EndRefresh();
                }
            }

        }

        private async void countryListView_ItemTapped(object sender, ItemTappedEventArgs e)
        {
            txtEmail.Text = e.Item.ToString();
            
            var password = await SecureStorage.GetAsync(e.Item.ToString());

            // Listview items should always be in storage but check if null just in case
            if (password != null)
            {
                txtPassword.Text = password;
                save.IsChecked = true;
            }

            countryListView.IsVisible = false;
            listLayout.IsVisible = false;
        }

        private void Google_Tapped(object sender, EventArgs e)
        {
            try
            {
                _googleService.Login(OnGoogleLoginComplete);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
        }

        private async void OnGoogleLoginComplete(GoogleUser googleUser, string message)
        {
            if (googleUser != null)
            {
                GoogleUser = googleUser;

                user = await restService.PostLogin(googleUser.Email, null, googleUser.IdToken);

                if (user == null)
                {
                    fEmail.BorderColor = Color.FromRgb(255, 0, 0);
                    fPass.BorderColor = Color.FromRgb(255, 0, 0);
                    await this.DisplayToastAsync("Utilizador ou Password, Incorretos", 5000);
                }
                else
                {

                    //SecureStorage.RemoveAll();
                    SecureStorage.Remove("iduser");
                    SecureStorage.Remove("tokenuser");

                    await SecureStorage.SetAsync("iduser", user.Iduser.ToString());
                    await SecureStorage.SetAsync("tokenuser", user.Tokenuser.ToString());

                    if (remember.IsChecked)
                        await SecureStorage.SetAsync("userRemember", "1");
                    else
                        await SecureStorage.SetAsync("userRemember", "0");

                    await SecureStorage.SetAsync("savedUsers", string.Join(";", savedUsersList));

                    // await this.DisplayToastAsync(user.Tokenuser, 500);
                    await Shell.Current.GoToAsync("//Home");
                }

            }
            else
            {
                await DisplayAlert("Message", message, "Ok");
            }
        }
    }
}