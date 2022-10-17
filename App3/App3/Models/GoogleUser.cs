using System;
using System.Collections.Generic;
using System.Text;

namespace App3.Models
{
    public class GoogleUser
    {
        public string Name { get; set; }
        public string GivenName { get; set; }
        public string FamilyName { get; set; }
        public string IdToken { get; set; }
        public string Email { get; set; }
        public Uri Picture { get; set; }
    }
}
