using System;
using System.Collections.Generic;
using System.Text;

namespace App3.Models
{
    public class Favigreja
    {
        public int Idigreja { get; set; }
        public int Iduser { get; set; }
        public string Nomeigreja { get; set; }
        public string Morada { get; set; }
        public string Estado { get; set; }
    }

    public class RootFavigreja
    {
        public List<Favigreja> data { get; set; }
    }
}
