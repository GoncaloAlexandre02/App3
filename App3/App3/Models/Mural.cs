using System;
using System.Collections.Generic;
using System.Text;

namespace App3.Models
{
    public class Mural
    {
        public int Idmural { get; set; }
        public int Iduser { get; set; }
        public string Nomeuser { get; set; }
        public string Motivo { get; set; }

        public string Descmural { get; set; }
        public string Visita { get; set; }
        public string Ligacao { get; set; }
        public string Publicar { get; set; }
    }
    public class RootMural
    {
        public List<Mural> data { get; set; }
    }
}
