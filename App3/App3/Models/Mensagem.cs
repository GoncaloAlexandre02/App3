using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace App3.Models
{
    public class Mensagem
    {

        public int Idmensagem { get; set; }
        public string Descmsg { get; set; }
        public string Emissor { get; set; }
        public string Receptor { get; set; }
        public int Idemissor { get; set; }
        public int? Idreceptor { get; set; }
        public string ImgEmissor { get; set; }
        public string ImgReceptor { get; set; }
        public DateTime Dtmsg { get; set; }
        public int? Evento { get; set; }
        public int? Social { get; set; }
        public int? Mural { get; set; }
        public int? Departamento { get; set; }

        public ImageSource ImgEmissorSource { get; set; }

        public bool isGrupo()
        {
            return Evento != null || Social != null || Mural != null || Departamento != null;
        }
    }

    public class RootMsg
    {
        public List<Mensagem> data { get; set; }
    }
}
