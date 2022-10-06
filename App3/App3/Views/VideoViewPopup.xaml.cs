using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using App3.Services;
using Google.Apis.YouTube.v3.Data;
using Plugin.Media;
using Xamarin.CommunityToolkit.Core;
using Xamarin.CommunityToolkit.Extensions;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace App3.Views
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class VideoViewPopup : Rg.Plugins.Popup.Pages.PopupPage
	{
		RestService restService;

		public VideoViewPopup(string filename)
		{
			InitializeComponent();
			restService = new RestService();
			

			var folder = FileSystem.AppDataDirectory;
			var videoFile = Path.Combine(folder, filename);

			if (File.Exists(videoFile))
				File.Delete(videoFile);

			if (!File.Exists(videoFile))
			{
				var res = Task.Run(() => restService.GetVideo(filename)).Result;
				if (res != null)
                {

					using (Stream inputStream = new MemoryStream(res))
					{
						using (FileStream outputStream = File.Create(videoFile))
						{
							inputStream.CopyTo(outputStream);
						}
					}
				}
				//var file = System.Text.Encoding.UTF8.GetBytes(res);

				
			}


			Launcher.OpenAsync(new OpenFileRequest() { File = new ReadOnlyFile(videoFile) });
			//MediaSource ms = MediaSource.FromFile("ms-appdata:///"+ videoFile);
			
			//Player.Source = "ms-appdata:///" + videoFile;
		}

	}
}