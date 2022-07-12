using System;
using System.Collections.Generic;
using System.Text;

namespace App3.Models
{
    public class Departamento
    {
        public int Iddepart { get; set; }
        public string Nomedepart { get; set; } 
        public string Descdepart { get; set; } 

        public string Imgdepart { get; set; }
    }
    public class RootDepartamento
    {
        public List<Departamento> data { get; set; }
    }

}
