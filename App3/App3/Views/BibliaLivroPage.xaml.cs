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
            book.Add(new Biblia { Id = "gen", Nome = "[Gn] Gênesis", Ch = 50 });
            book.Add(new Biblia { Id = "exo", Nome = "[Êx] Êxodo", Ch = 40 });
            book.Add(new Biblia { Id = "lev", Nome = "[Lv] Levítico", Ch = 27 });
            book.Add(new Biblia { Id = "num", Nome = "[Nm] Números", Ch = 36 });
            book.Add(new Biblia { Id = "deu", Nome = "[Dt] Deuteronômio", Ch = 34 });
            book.Add(new Biblia { Id = "jos", Nome = "[Js] Josué", Ch = 24 });
            book.Add(new Biblia { Id = "jdg", Nome = "[Jz] Juízes", Ch = 21 });
            book.Add(new Biblia { Id = "rut", Nome = "[Rt] Rute", Ch = 4 });
            book.Add(new Biblia { Id = "1Sa", Nome = "[1Sm] 1º Samuel", Ch = 31 });
            book.Add(new Biblia { Id = "2Sa", Nome = "[2Sm] 2º Samuel", Ch = 24 });
            book.Add(new Biblia { Id = "1Ki", Nome = "[1Rs] 1º Reis", Ch = 22 });
            book.Add(new Biblia { Id = "2Ki", Nome = "[2Rs] 2º Reis", Ch = 25 });
            book.Add(new Biblia { Id = "1ch", Nome = "[1Cr] 1º Crônicas", Ch = 29 });
            book.Add(new Biblia { Id = "2ch", Nome = "[2Cr] 2º Crônicas", Ch = 36 });
            book.Add(new Biblia { Id = "ezra", Nome = "[Ed] Esdras", Ch = 10 });
            book.Add(new Biblia { Id = "neh", Nome = "[Ne] Neemias", Ch = 13 });
            book.Add(new Biblia { Id = "est", Nome = "[Et] Ester", Ch = 10 });
            book.Add(new Biblia { Id = "job", Nome = "[Jó] Jó", Ch = 42 });
            book.Add(new Biblia { Id = "psa", Nome = "[Sl] Salmos", Ch = 150 });
            book.Add(new Biblia { Id = "pro", Nome = "[Pv] Provérbios", Ch = 31 });
            book.Add(new Biblia { Id = "ecc", Nome = "[Ec] Eclesiastes", Ch = 12 });
            book.Add(new Biblia { Id = "sng", Nome = "[Ct] Cantares ou Cânticos dos Cânticos", Ch = 8 });
            book.Add(new Biblia { Id = "isa", Nome = "[Is] Isaías", Ch = 66 });
            book.Add(new Biblia { Id = "jer", Nome = "[Jr] Jeremias", Ch = 52 });
            book.Add(new Biblia { Id = "lam", Nome = "[Lm] Lamentações de Jeremias", Ch = 5 });
            book.Add(new Biblia { Id = "ezk", Nome = "[Ez] Ezequiel", Ch = 48 });
            book.Add(new Biblia { Id = "dan", Nome = "[Dn] Daniel", Ch = 12 });
            book.Add(new Biblia { Id = "hos", Nome = "[Os] Oséias", Ch = 14 });
            book.Add(new Biblia { Id = "jol", Nome = "[Jl] Joel", Ch = 3 });
            book.Add(new Biblia { Id = "amo", Nome = "[Am] Amós", Ch = 9 });
            book.Add(new Biblia { Id = "oba", Nome = "[Ob] Obadias", Ch = 1 });
            book.Add(new Biblia { Id = "jon", Nome = "[Jn] Jonas", Ch = 4 });
            book.Add(new Biblia { Id = "mic", Nome = "[Mq] Miquéias", Ch = 7 });
            book.Add(new Biblia { Id = "nah", Nome = "[Na] Naum", Ch = 3 });
            book.Add(new Biblia { Id = "hab", Nome = "[Hc] Habacuque", Ch = 3 });
            book.Add(new Biblia { Id = "zep", Nome = "[Sf] Sofonias", Ch = 3 });
            book.Add(new Biblia { Id = "hag", Nome = "[Ag] Ageu", Ch = 2 });
            book.Add(new Biblia { Id = "zec", Nome = "[Zc] Zacarias", Ch = 14 });
            book.Add(new Biblia { Id = "mal", Nome = "[Ml] Malaquias", Ch = 4 });
            book.Add(new Biblia { Id = "mat", Nome = "[Mt] Mateus", Ch = 28 });
            book.Add(new Biblia { Id = "mrk", Nome = "[Mc] Marcos", Ch = 16 });
            book.Add(new Biblia { Id = "luk", Nome = "[Lc] Lucas", Ch = 24 });
            book.Add(new Biblia { Id = "jhn", Nome = "[Jo] João", Ch = 21 });
            book.Add(new Biblia { Id = "act", Nome = "[At] Atos dos Apóstolos", Ch = 28 });
            book.Add(new Biblia { Id = "rom", Nome = "[Rm] Romanos", Ch = 16 });
            book.Add(new Biblia { Id = "1co", Nome = "[1Co] 1ª Coríntios", Ch = 16 });
            book.Add(new Biblia { Id = "2co", Nome = "[2Co] 2ª Coríntios", Ch = 13 });
            book.Add(new Biblia { Id = "gal", Nome = "[Gl] Gálatas", Ch = 6 });
            book.Add(new Biblia { Id = "eph", Nome = "[Ef] Efésios", Ch = 6 });
            book.Add(new Biblia { Id = "php", Nome = "[Fp] Filipenses", Ch = 4 });
            book.Add(new Biblia { Id = "col", Nome = "[Cl] Colossenses", Ch = 4 });
            book.Add(new Biblia { Id = "1th", Nome = "[1Ts] 1ª Tessalonicenses", Ch = 5 });
            book.Add(new Biblia { Id = "2th", Nome = "[2Ts] 2ª Tessalonicenses", Ch = 3 });
            book.Add(new Biblia { Id = "1ti", Nome = "[1Tn] 1ª Timóteo", Ch = 6 });
            book.Add(new Biblia { Id = "2ti", Nome = "[2Tm] 2ª Timóteo", Ch = 4 });
            book.Add(new Biblia { Id = "tit", Nome = "[Tt] Tito", Ch = 3 });
            book.Add(new Biblia { Id = "phm", Nome = "[Fm] Filemom", Ch = 1 });
            book.Add(new Biblia { Id = "heb", Nome = "[Hb] Hebreus", Ch = 13 });
            book.Add(new Biblia { Id = "jas", Nome = "[Tg] Tiago", Ch = 5 });
            book.Add(new Biblia { Id = "1pe", Nome = "[1Pe] 1ª Pedro", Ch = 5 });
            book.Add(new Biblia { Id = "2pe", Nome = "[2Pe] 2ª Pedro", Ch = 3 });
            book.Add(new Biblia { Id = "1jn", Nome = "[1Jo] 1ª João", Ch = 5 });
            book.Add(new Biblia { Id = "2jn", Nome = "[2Jo] 2ª João", Ch = 1 });
            book.Add(new Biblia { Id = "3jn", Nome = "[3Jo] 3ª João", Ch = 1 });
            book.Add(new Biblia { Id = "jud", Nome = "[Jd] Judas", Ch = 1 });
            book.Add(new Biblia { Id = "rev", Nome = "[Ap] Apocalipse", Ch = 22 });
        }
    }
}