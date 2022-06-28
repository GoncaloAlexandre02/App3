using App3.Models;
using App3.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace App3.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class BibliaLivroPage : ContentPage
    {

       
        public BibliaLivroPage()
        {
            InitializeComponent();

            List<Biblia> book = new List<Biblia>();
            lista.ItemsSource = book;
            book.Add(new Biblia { Id = "gen", Nome = "Gênesis", Ch = 50, Sigla = "[Gn]" });
            book.Add(new Biblia { Id = "exo", Nome = "Êxodo", Ch = 40, Sigla = "[Êx]" });
            book.Add(new Biblia { Id = "lev", Nome = "Levítico", Ch = 27, Sigla = "[Lv]" });
            book.Add(new Biblia { Id = "num", Nome = "Números", Ch = 36, Sigla = "[Nm]" });
            book.Add(new Biblia { Id = "deu", Nome = "Deuteronômio", Ch = 34, Sigla = "[Dt]" });
            book.Add(new Biblia { Id = "jos", Nome = "Josué", Ch = 24, Sigla = "[Js]" });
            book.Add(new Biblia { Id = "jdg", Nome = "Juízes", Ch = 21, Sigla = "[Jz]" });
            book.Add(new Biblia { Id = "rut", Nome = "Rute", Ch = 4, Sigla = "[Rt]" });
            book.Add(new Biblia { Id = "1Sa", Nome = "1º Samuel", Ch = 31, Sigla = "[1Sm]" });
            book.Add(new Biblia { Id = "2Sa", Nome = "2º Samuel", Ch = 24, Sigla = "[2Sm]" });
            book.Add(new Biblia { Id = "1Ki", Nome = "1º Reis", Ch = 22, Sigla = "[1Rs]" });
            book.Add(new Biblia { Id = "2Ki", Nome = "2º Reis", Ch = 25, Sigla = "[2Rs]" });
            book.Add(new Biblia { Id = "1ch", Nome = "1º Crônicas", Ch = 29, Sigla = "[1Cr]" });
            book.Add(new Biblia { Id = "2ch", Nome = "2º Crônicas", Ch = 36, Sigla = "[2Cr]" });
            book.Add(new Biblia { Id = "ezra", Nome = "Esdras", Ch = 10, Sigla = "[Ed]" });
            book.Add(new Biblia { Id = "neh", Nome = "Neemias", Ch = 13, Sigla = "[Ne]" });
            book.Add(new Biblia { Id = "est", Nome = "Ester", Ch = 10, Sigla = "[Et]" });
            book.Add(new Biblia { Id = "job", Nome = "Jó", Ch = 42, Sigla = "[Jó]" });
            book.Add(new Biblia { Id = "psa", Nome = "Salmos", Ch = 150, Sigla = "[Sl]" });
            book.Add(new Biblia { Id = "pro", Nome = "Provérbios", Ch = 31, Sigla = "[Pv]" });
            book.Add(new Biblia { Id = "ecc", Nome = "Eclesiastes", Ch = 12, Sigla = "[Ec]" });
            book.Add(new Biblia { Id = "sng", Nome = "Cantares ou Cânticos dos Cânticos", Ch = 8, Sigla = "[Ct]" });
            book.Add(new Biblia { Id = "isa", Nome = "Isaías", Ch = 66, Sigla = "[Is]" });
            book.Add(new Biblia { Id = "jer", Nome = "Jeremias", Ch = 52, Sigla = "[Jr]" });
            book.Add(new Biblia { Id = "lam", Nome = "Lamentações de Jeremias", Ch = 5, Sigla = "[Lm]" });
            book.Add(new Biblia { Id = "ezk", Nome = "Ezequiel", Ch = 48, Sigla = "[Ez]" });
            book.Add(new Biblia { Id = "dan", Nome = "Daniel", Ch = 12, Sigla = "[Dn]" });
            book.Add(new Biblia { Id = "hos", Nome = "Oséias", Ch = 14, Sigla = "[Os]" });
            book.Add(new Biblia { Id = "jol", Nome = "Joel", Ch = 3, Sigla = "[Jl]" });
            book.Add(new Biblia { Id = "amo", Nome = "Amós", Ch = 9, Sigla = "[Am]" });
            book.Add(new Biblia { Id = "oba", Nome = "Obadias", Ch = 1, Sigla = "[Ob]" });
            book.Add(new Biblia { Id = "jon", Nome = "Jonas", Ch = 4, Sigla = "[Jn]" });
            book.Add(new Biblia { Id = "mic", Nome = "Miquéias", Ch = 7, Sigla = "[Mq]" });
            book.Add(new Biblia { Id = "nah", Nome = "Naum", Ch = 3, Sigla = "[Na]" });
            book.Add(new Biblia { Id = "hab", Nome = "Habacuque", Ch = 3, Sigla = "[Hc]" });
            book.Add(new Biblia { Id = "zep", Nome = "Sofonias", Ch = 3, Sigla = "[Sf]" });
            book.Add(new Biblia { Id = "hag", Nome = "Ageu", Ch = 2, Sigla = "[Ag]" });
            book.Add(new Biblia { Id = "zec", Nome = "Zacarias", Ch = 14, Sigla = "[Zc]" });
            book.Add(new Biblia { Id = "mal", Nome = "Malaquias", Ch = 4, Sigla = "[Ml]" });
            book.Add(new Biblia { Id = "mat", Nome = "Mateus", Ch = 28, Sigla = "[Mt]" });
            book.Add(new Biblia { Id = "mrk", Nome = "Marcos", Ch = 16, Sigla = "[Mc]" });
            book.Add(new Biblia { Id = "luk", Nome = "Lucas", Ch = 24, Sigla = "[Lc]" });
            book.Add(new Biblia { Id = "jhn", Nome = "João", Ch = 21, Sigla = "[Jo]" });
            book.Add(new Biblia { Id = "act", Nome = "Atos dos Apóstolos", Ch = 28, Sigla = "[At]" });
            book.Add(new Biblia { Id = "rom", Nome = "Romanos", Ch = 16, Sigla = "[Rm]" });
            book.Add(new Biblia { Id = "1co", Nome = "1ª Coríntios", Ch = 16, Sigla = "[1Co]" });
            book.Add(new Biblia { Id = "2co", Nome = "2ª Coríntios", Ch = 13, Sigla = "[2Co]" });
            book.Add(new Biblia { Id = "gal", Nome = "Gálatas", Ch = 6, Sigla = "[Gl]" });
            book.Add(new Biblia { Id = "eph", Nome = "Efésios", Ch = 6, Sigla = "[Ef]" });
            book.Add(new Biblia { Id = "php", Nome = "Filipenses", Ch = 4, Sigla = "[Fp]" });
            book.Add(new Biblia { Id = "col", Nome = "Colossenses", Ch = 4, Sigla = "[Cl]" });
            book.Add(new Biblia { Id = "1th", Nome = "1ª Tessalonicenses", Ch = 5, Sigla = "[1Ts]" });
            book.Add(new Biblia { Id = "2th", Nome = "2ª Tessalonicenses", Ch = 3, Sigla = "[2Ts]" });
            book.Add(new Biblia { Id = "1ti", Nome = "1ª Timóteo", Ch = 6, Sigla = "[1Tn]" });
            book.Add(new Biblia { Id = "2ti", Nome = "2ª Timóteo", Ch = 4, Sigla = "[2Tm]" });
            book.Add(new Biblia { Id = "tit", Nome = "Tito", Ch = 3, Sigla = "[Tt]" });
            book.Add(new Biblia { Id = "phm", Nome = "Filemom", Ch = 1, Sigla = "[Fm]" });
            book.Add(new Biblia { Id = "heb", Nome = "Hebreus", Ch = 13, Sigla = "[Hb]" });
            book.Add(new Biblia { Id = "jas", Nome = "Tiago", Ch = 5, Sigla = "[Tg]" });
            book.Add(new Biblia { Id = "1pe", Nome = "1ª Pedro", Ch = 5, Sigla = "[1Pe]" });
            book.Add(new Biblia { Id = "2pe", Nome = "2ª Pedro", Ch = 3, Sigla = "[2Pe]" });
            book.Add(new Biblia { Id = "1jn", Nome = "1ª João", Ch = 5, Sigla = "[1Jo]" });
            book.Add(new Biblia { Id = "2jn", Nome = "2ª João", Ch = 1, Sigla = "[2Jo]" });
            book.Add(new Biblia { Id = "3jn", Nome = "3ª João", Ch = 1, Sigla = "[3Jo]" });
            book.Add(new Biblia { Id = "jud", Nome = "Judas", Ch = 1, Sigla = "[Jd]" });
            book.Add(new Biblia { Id = "rev", Nome = "Apocalipse", Ch = 22, Sigla = "[Ap]" });
        }

        
        private async void lista_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            var item = (Biblia)lista.SelectedItem;
            var itemnome = item.Nome;
            var itemch = item.Ch;
            var itemid = item.Id;

            // assuiming Club has an Id property
            await Navigation.PushModalAsync(new BibliaCapituloPage(itemid, itemnome, itemch));
        }

        private void TapGestureRecognizer_Tapped_livro(object sender, EventArgs e)
        {
            //livro.FontFamily = "RedHat-Bold";
            //capitulo.FontFamily = "RedHat-SemiBold";
            //lista.IsVisible = true;
        }

        private void TapGestureRecognizer_Tapped_capitulo(object sender, EventArgs e)
        {
            //capitulo.FontFamily = "RedHat-Bold";
            //livro.FontFamily = "RedHat-SemiBold";
            //lista.IsVisible=false;
        }
    }
}