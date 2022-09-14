using System;
using System.Collections.Generic;

namespace App3.Models
{
    public partial class UsersTipos
    {
        public int Iduser { get; set; }
        public User User { get; set; }
        public int Idtipo { get; set; }

        public Tipouser Tipouser { get; set; }
    }
}
