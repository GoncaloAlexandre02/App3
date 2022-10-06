using System;
using System.Collections.Generic;
using System.IO;
using Xamarin.Forms;

namespace App3.Models
{
    public partial class Video
    {
        public int Idvideo { get; set; }
        public int? Idigreja { get; set; }
        public string Nomevideo { get; set; }
        public string Descvideo { get; set; }
        public DateTime Dtvideo { get; set; }
        public string Pathvideo { get; set; } 

    }

    public class VideoPreview
    {
        public string Nome { get; set; }
        public string Ext { get; set; } = ".mp4";
        public Byte[] Thumbnail { get; set; }
        public ImageSource ThumbnailSource { 
            get 
            { 
                ImageSource im = ImageSource.FromStream(() => new MemoryStream(Thumbnail));
                return im;
            }
        }
    }
}
