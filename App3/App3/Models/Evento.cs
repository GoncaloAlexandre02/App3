using System;
using System.Collections.Generic;
using System.Text;

namespace App3.Models
{
    public class Evento
    {
        public int Idevento { get; set; }
        public int? Idigreja { get; set; }
        public string Nome { get; set; }
        public string Descevento { get; set; }
        public string Imgevento { get; set; }
        public DateTime Dtevento { get; set; }
    }

    public class RootEvento
    {
        public List<Evento> data { get; set; }
    }
}
