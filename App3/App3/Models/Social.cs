using System;
using System.Collections.Generic;
using System.Text;

namespace App3.Models
{
    public class Social
    {
        public int Idsocial { get; set; }
        public int Iduser { get; set; }
        public int? Idigreja { get; set; }
        public string NomeOwner { get; set; }
        public string Nomesocial { get; set; }
        public string Descsocial { get; set; }
        public string Estado { get; set; }
        public string Tipo { get; set; }
    }
    public class SocialRoot
    {
        public List<Social> data { get; set; }

    }
}
