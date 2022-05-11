using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace App3.Models
{
    public class Verses
    {
        public string book_id { get; set; }
        public string book_name { get; set; }
        public int chapter { get; set; }
        public int verse { get; set; }
        public string text { get; set; }
    }

    public class Root
    {
        public string reference { get; set; }
        public List<Verses> verses { get; set; }
        public string text { get; set; }
        public string translation_id { get; set; }
        public string translation_name { get; set; }
        public string translation_note { get; set; }
    }
}

