using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using App3.Services;
using Rg.Plugins.Popup.Services;
using Xamarin.CommunityToolkit.Extensions;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace App3.Views
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class VideoAddPopup : Rg.Plugins.Popup.Pages.PopupPage
	{
		RestService restService;

		public VideoAddPopup ()
		{
			InitializeComponent ();
			restService = new RestService();
		}

        private async void Button_Clicked(object sender, EventArgs e)
        {
			if (string.IsNullOrWhiteSpace(TitleEntry.Text))
            {
				await this.DisplayToastAsync("Introduza o título do vídeo", 2000);
				return;
			}
            
			var choices = new[] { "Abrir câmera", "Escolher video" };

			var choice = await Acr.UserDialogs.UserDialogs.Instance.ActionSheetAsync("Escolher", "Cancelar", null, null, choices);

			Console.Write(choice);

			FileResult video;

			if (choice == "Abrir câmera") {
				video = await MediaPicker.CaptureVideoAsync();
			} 
			else {
				video = await MediaPicker.PickVideoAsync();
            }

			if (video == null)
				return;

			string ext = video.FileName.Substring(video.FileName.Length-4, 4);

			//Just in case filename is messed up
			if (ext.Length != 4)
				ext = ".mp4";

			var content = new MultipartFormDataContent();
			content.Add(new StreamContent(await video.OpenReadAsync()), "file", TitleEntry.Text + ext);

			//var res = await restService.UploadVideo(content);

			if (true)
				try
                {
					await PopupNavigation.Instance.PopAsync();
				}
				catch(Exception ex)
                {
					Console.WriteLine(ext);
                }
			else
			{
				await this.DisplayToastAsync("Ocorreu um erro ao guardar o vídeo", 2000);
			}

		}
	}
}