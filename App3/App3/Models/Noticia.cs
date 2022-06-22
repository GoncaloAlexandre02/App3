using System;
using System.Collections.Generic;
using System.Text;

namespace App3.Models
{
    public class Noticia
    {
        public String dataNoticia { get; set; }
        public String tituloNoticia { get; set; }
    }

    public class RootNoticia
    {
        public List<Noticia> data { get; set; }
    }
}
