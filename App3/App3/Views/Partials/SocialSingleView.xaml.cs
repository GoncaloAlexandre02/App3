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
    public partial class SocialSingleView : ContentView
    {
        Social social1;
        SocialimgRoot socialimg;
        RestService restService;
        
        public SocialSingleView()
        {
            InitializeComponent();
        }

        public SocialSingleView(Social social)
        {
            InitializeComponent();
            titulo.Text = social.Nomesocial.ToString();
            if(social.Estado == "indisponivel")
            {
                titulo2.TextColor= Color.Red;
            }
            else
            {
                titulo2.TextColor= Color.FromHex("#039800");
            }
            titulo2.Text = social.Estado.ToString();
            
            social1 = social;
            restService = new RestService();
            AtualizarImg();
        }

        public async void AtualizarImg()
        {
            try
            {
                socialimg = await restService.GetSocialImgAsync(social1.Idsocial.ToString());
            }catch (Exception ex)
            {
                ImgSoc.Source = "noimage";
            }
            try { 
            if (socialimg == null || socialimg.data.Count == 0)
            {
                ImgSoc.Source = "noimage";
            }
            else
            {
                ImgSoc.Source = await restService.GetImagemServer(socialimg.data[0].Img);
            }
            }catch (Exception ex)
            {
                ImgSoc.Source = "noimage";
            }
        }

        private async void TapGestureRecognizer_Tapped(object sender, EventArgs e)
        {
            await Navigation.PushModalAsync(new IgrejaSocialPage1(social1));
        }
    }
}