using System;
using System.Collections.Generic;
using System.Text;

namespace App3.Models
{
    public class User
    {
        public int Iduser { get; set; }
        public int? Idigreja { get; set; }
        public string Nome { get; set; }
        public string Apelido { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string Telefone { get; set; }
        public string Dtnasc { get; set; }
        public string Morada { get; set; }
        public string Localidade { get; set; }
        public string Cpostal { get; set; }
        public string Ocupacao { get; set; }
        public string Estadocivil { get; set; }
        public string Batismo { get; set; }
        public string Genero { get; set; }
        public string Imagem { get; set; }
        public string Tokenuser { get; set; }
        public string Emailativo { get; set; }
        public DateTime Dtregisto { get; set; }
        public int? Tipouser { get; set; }

        public byte[] ImageSource { get; set; }
    }
}
