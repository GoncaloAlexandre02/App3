using System;
using System.Collections.Generic;
using System.Text;

namespace App3.Models
{
    public class Mensagem
    {

        public int Idmensagem { get; set; }
        public string Descmsg { get; set; }
        public string Emissor { get; set; }
        public string Receptor { get; set; }
        public int Idemissor { get; set; }
        public int Idreceptor { get; set; }
        public string ImgEmissor { get; set; }
        public string ImgReceptor { get; set; }
        public DateTime Dtmsg { get; set; }

    }

    public class RootMsg
    {
        public List<Mensagem> data { get; set; }
    }
}
