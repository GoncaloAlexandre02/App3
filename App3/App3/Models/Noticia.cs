using System;
using System.Collections.Generic;
using System.Text;

namespace App3.Models
{
    public class Noticia
    {
        public int Idnoticia { get; set; }
        public int? Idigreja { get; set; }
        public string Nomenoticia { get; set; }
        public string Descnoticia { get; set; }
        public DateTime Dtnoticia { get; set; }
    }

    public class RootNoticia
    {
        public List<Noticia> data { get; set; }
    }
}
