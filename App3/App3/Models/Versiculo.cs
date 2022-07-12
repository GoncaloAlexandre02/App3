using System;
using System.Collections.Generic;
using System.Text;

namespace App3.Models
{
    public class Versiculo
    {
        public int? Idversiculo { get; set; }
        public string Book_id { get; set; }
        public string Book_name { get; set; }
        public int Chapter { get; set; }
        public int Verse { get; set; }
        public string Text { get; set; }

        public  string ChTotal { get; set; }

        public DateTime? DataV { get; set; }
    }
}
