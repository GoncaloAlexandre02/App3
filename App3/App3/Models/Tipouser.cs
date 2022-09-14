using System;
using System.Collections.Generic;

namespace App3.Models
{
    public partial class Tipouser
    {
        public Tipouser()
        {
            //Users = new HashSet<User>();
        }

        public int Idtipo { get; set; }
        public string Desctipo { get; set; }

        //public virtual ICollection<User> Users { get; set; }
        public ICollection<UsersTipos> UsersTipos { get; set; }
        //public virtual User? IduserNavigation { get; set; }

    }
}
