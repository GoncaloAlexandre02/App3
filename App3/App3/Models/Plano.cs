using System;
using System.Collections.Generic;
using System.Text;

namespace App3.Models
{
    public class Plano
    {
        public int Idplano { get; set; }
        public int Iduser { get; set; }
        public string Nomeuser { get; set; }
        public string Dia { get; set; }
        public string Hora { get; set; }
        public string Ativo { get; set; }


    }

    public class RootPlano
    {
        public List<Plano> data { get; set; }
    }
}
