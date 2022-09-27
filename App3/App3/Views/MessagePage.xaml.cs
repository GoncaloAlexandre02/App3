using App3.Models;
using App3.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace App3.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MessagePage : ContentPage
    {
        RestService restService;
        List<Mensagem> msgList = new List<Mensagem>();
        RootMsg msg;

        List<Departamento> Departamentos = new List<Departamento>();
        List<Evento> Eventos = new List<Evento>();
        List<Social> Sociais = new List<Social>();
        List<Mural> Murais = new List<Mural>();

        public MessagePage()
        {
            InitializeComponent();
            restService = new RestService();
            AtualizarMensagens();
        }

        public async void AtualizarMensagens()
        {
            msg = await restService.GetMensagensListAsync(await SecureStorage.GetAsync("iduser"));
            Departamentos = (await restService.GetDepartamentosAsync()).data;
            Eventos = (await restService.GetEventosAsync()).data;
            Sociais = (await restService.GetSocialItemsAsync("tudo")).data;
            Murais = (await restService.GetMuraisAsync()).data;
           
            msgList.Clear();

            foreach (var m in msg.data)
            {
                if (m.Departamento != null)
                    m.Titulo = Departamentos.Find(d => d.Iddepart == m.Departamento).Nomedepart;
                else if (m.Evento != null)
                    m.Titulo = Eventos.Find(e => e.Idevento == m.Evento).Nome;
                else if (m.Social != null)
                    m.Titulo = Sociais.Find(s => s.Idsocial == m.Social).Nomesocial;
                else if (m.Mural != null)
                    m.Titulo = Murais.Find(mu => mu.Idmural == m.Mural).Descmural;

                //For display purposes, always set Emissor to not be the current user
                if (m.Idemissor.ToString() == await SecureStorage.GetAsync("iduser"))
                {
                    msgList.Add(new Mensagem() { Descmsg = m.Descmsg, Idemissor = m.Idreceptor.Value, Idmensagem = m.Idmensagem, Idreceptor = m.Idemissor, Emissor = m.Receptor, Receptor = m.Emissor, ImgEmissor = m.ImgReceptor, ImgReceptor = m.ImgEmissor, Dtmsg = m.Dtmsg,
                    Departamento = m.Departamento, Evento = m.Evento, Social = m.Social, Mural = m.Mural, Titulo = m.Titulo, Lido = m.Lido, NaoLidoCount = m.NaoLidoCount, Count = m.Count});
                }
                else
                {
                    msgList.Add(m);
                }
            }

            //msgList = msg.data;

            depList.ItemsSource = msgList.Where(m => m.Departamento != null);
            eventoList.ItemsSource = msgList.Where(m => m.Evento != null);
            socList.ItemsSource = msgList.Where(m => m.Social != null);
            muralList.ItemsSource = msgList.Where(m => m.Mural != null);
        }



        async void OnItemSelectedDep(object sender, SelectedItemChangedEventArgs e)
        {
            ListView lv = (ListView)sender;

            // this assumes your List is bound to a List<Club>
            var item = (Mensagem)depList.SelectedItem;
            var itemstrig = item.Idemissor;

            // assuiming Club has an Id property
            if (item.Departamento != null)
            {
                await Navigation.PushAsync(new ChatPageDepartamento(item.Idreceptor.ToString(), item.Idemissor.ToString(), item.Departamento.ToString()));

            }
            else
                await Navigation.PushAsync(new ChatPage(itemstrig.ToString()));
        }

        async void OnItemSelectedEvento(object sender, SelectedItemChangedEventArgs e)
        {
            ListView lv = (ListView)sender;

            // this assumes your List is bound to a List<Club>
            var item = (Mensagem)depList.SelectedItem;
            var itemstrig = item.Idemissor;

            // assuiming Club has an Id property
            if (item.Departamento != null)
            {
                await Navigation.PushAsync(new ChatPageEvento(item.Idemissor.ToString(), item.Idreceptor.ToString(), item.Evento.ToString()));

            }
            else
                await Navigation.PushAsync(new ChatPage(itemstrig.ToString()));
        }

        async void OnItemSelectedSoc(object sender, SelectedItemChangedEventArgs e)
        {
            ListView lv = (ListView)sender;

            // this assumes your List is bound to a List<Club>
            var item = (Mensagem)socList.SelectedItem;
            var itemstrig = item.Idemissor;

            // assuiming Club has an Id property
            if (item.Social != null)
            {
                await Navigation.PushAsync(new ChatPageSocial(item.Idreceptor.ToString(), item.Idemissor.ToString(), item.Social.ToString()));
            }
            else
                await Navigation.PushAsync(new ChatPage(itemstrig.ToString()));
        }

        async void OnItemSelectedMural(object sender, SelectedItemChangedEventArgs e)
        {
            ListView lv = (ListView)sender;

            // this assumes your List is bound to a List<Club>
            var item = (Mensagem)muralList.SelectedItem;
            var itemstrig = item.Idemissor;

            // assuiming Club has an Id property
            if (item.Mural != null)
            {
                await Navigation.PushAsync(new ChatPageMural(item.Idemissor.ToString(), item.Idreceptor.ToString(), item.Mural.ToString()));

            }
            else
                await Navigation.PushAsync(new ChatPage(itemstrig.ToString()));
        }


        protected override void OnAppearing()
        {
            AtualizarMensagens();
        }
    }
}