using System;
using System.Collections.Generic;
using System.Text;

namespace App3.Models
{
    public class Socialimg
    {
        public string Idsocialimg { get; set; }
        public string Img { get; set; }
       
    }

    public class SocialimgRoot
    {
        public List<Socialimg> data { get; set; }
    }
}
