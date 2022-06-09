using System;
using System.Collections.Generic;
using System.Text;

namespace App3.Models
{
    public class Hinario
    {
        public string NomeHinario { get; set; }
        public string DescHinario { get; set; }
    }

    public class RootHinario
    {
        public List<Hinario> data { get; set; }
    }
}
