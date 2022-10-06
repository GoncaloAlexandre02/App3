using App3.Models;
using App3.Services;
using Google.Apis.YouTube.v3;
using Google.Apis.Services;
using Rg.Plugins.Popup.Extensions;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Google.Apis.YouTube.v3.Data;
using System.Windows.Input;

namespace App3.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class VideoPage : ContentPage
    {
        RestService restService;
        public List<VideoPreview> videos = new List<VideoPreview>();

        public VideoPage()
        {
            restService = new RestService();
            videos = Task.Run(() => restService.GetVideos()).Result;

            InitializeComponent();
            BindingContext = this;

            ObservableCollection <VideoPreview> f = new ObservableCollection<VideoPreview>(videos);

            var ytv = GetYtChannelVids();

            BindableLayout.SetItemsSource(ListaYt, ytv.Items);
            BindableLayout.SetItemsSource(ListaVip, videos);
        }

        public SearchListResponse GetYtChannelVids()
        {
            var r = new YouTubeService(new BaseClientService.Initializer() { ApiKey = "AIzaSyD2yOyqXFAeojr6EDuJPkFSt8A0vaRhTvg" });
            var req = r.Search.List("snippet");
            req.ChannelId = "UCY6nR3belVvL3jDghOu4fmQ";
            req.MaxResults = 10;
            req.Type = "video";

            var res = req.Execute();
            return res;
        }

        private void Button_Clicked_Youtube(object sender, EventArgs e)
        {

            scrollYoutube.IsVisible = true;
            scrollVip.IsVisible = false;
            AddVideo.IsVisible = false;

        }

        private void Button_Clicked_VIP(object sender, EventArgs e)
        {
            scrollYoutube.IsVisible = false;
            scrollVip.IsVisible = true;
            AddVideo.IsVisible = true;
        }

        private void TapGestureRecognizer_Tapped_Add(object sender, EventArgs e)
        {
            Navigation.PushPopupAsync(new VideoAddPopup());
        }

        private  void TapGestureRecognizer_Tapped(object sender, EventArgs e)
        {
            var frame = (Frame)sender;
            var videoSel = (VideoPreview)frame.BindingContext;

            var filename = videoSel.Nome + "." + videoSel.Ext;
            var folder = FileSystem.CacheDirectory;
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
            }

            Launcher.OpenAsync(new OpenFileRequest() { File = new ReadOnlyFile(videoFile) });
        }

        private async void TapGestureRecognizer_Tapped_1(object sender, EventArgs e)
        {
            var frame = (Frame)sender;
            var videoSel = (SearchResult)frame.BindingContext;

            await Launcher.OpenAsync("https://www.youtube.com/watch?v=" + videoSel.Id.VideoId);
        }
    }
}
  