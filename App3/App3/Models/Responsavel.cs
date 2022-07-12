using System;
using System.Collections.Generic;
using System.Text;

namespace App3.Models
{
    public class Responsavel
    {
        public int Iduser { get; set; }
        public int Iddepart { get; set; }
        public string NomeUser { get; set; }
        public string NomeDepart { get; set; }
    }

    public class RootResponsavel
    {
        public List<Responsavel> data { get; set; }
    }
}
