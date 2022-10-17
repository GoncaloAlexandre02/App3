using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using App3.Models;
using App3.Services;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace App3.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MainPage : ContentPage
    {
        List<Mensagem> msgs = null;
        List<Social> sociais = null;
        List<Evento> eventos = null;
        RestService restService = new RestService();

        public MainPage()
        {
            
            InitializeComponent();

            Auth();

            InitTimer();

        }

        private async void Auth()
        {
            var token = await SecureStorage.GetAsync("tokenuser");
            var remembered = await SecureStorage.GetAsync("userRemember");

            if (token == null || (remembered == null || remembered == "0"))
            {
                SecureStorage.Remove("tokenuser");
                return;
            }
            else
            {
                await Shell.Current.GoToAsync("//Home");
            }
        }

        private async void Entrar_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushModalAsync(new Views.LoginPage());
        }

        private async void Cadastrar_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushModalAsync(new Views.RegisterPage());
        }
    
        private void InitTimer()
        {
            int period = 10 * 60 * 1000; //every 10 min
            TimerCallback timerDelegateServicos = new TimerCallback(NotificationsTick);
            Timer _dispatcherTimerServicos = new Timer(timerDelegateServicos, null, period / 10, period / 10);
        }

        private async void NotificationsTick(object sender)
        {
            var token = await SecureStorage.GetAsync("tokenuser");
            if (token != null)
            {
                MessageCountWatcher();
                IgrejaSocialCountWatcher();
                MuralWatcher();
                EventoCountWatcher();
            }
            
        }
    
        private async void MessageCountWatcher()
        {
            try
            {
                var notify = false;
                var msg = await restService.GetMensagensListAsync(await SecureStorage.GetAsync("iduser"));

                if (msgs != null)
                {
                    foreach (var m in msg.data)
                    {
                        var aa = msgs.Find(ms => ms.Idmensagem == m.Idmensagem);
                        if (aa == null)
                        {
                            notify = true;
                            break;
                        }
                        else if (m.Count > aa.Count)
                        {
                            notify = true;
                            break;
                        }
                    }
                }

                msgs = msg.data;

                if (notify == true)
                {
                    DependencyService.Get<INotificationsService>().PushMensagemNotif("Tem novas mensagems!");
                }
            } 
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
        }

        private async void IgrejaSocialCountWatcher()
        {
            try
            {
                var notify = false;
                var soc = await restService.GetSocialItemsAsync("tudo");

                if (sociais != null)
                {
                    foreach (var s in soc.data)
                    {
                        var aa = sociais.Find(ss => ss.Idsocial == s.Idsocial);
                        if (aa == null)
                        {
                            notify = true;
                            break;
                        }
                    }
                }

                sociais = soc.data;

                if (notify == true)
                {
                    DependencyService.Get<INotificationsService>().PushSocialNotif("Foram adicionados novos itens à Igreja Social!");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
        }

        private async void MuralWatcher()
        {
            return;
        }

        private async void EventoCountWatcher()
        {
            try
            {
                var notify = false;
                var ev = await restService.GetEventosAsync();

                if (eventos != null)
                {
                    foreach (var e in ev.data)
                    {
                        var aa = eventos.Find(ee => ee.Idevento == e.Idevento);
                        if (aa == null)
                        {
                            notify = true;
                            break;
                        }
                    }
                }

                eventos = ev.data;

                if (notify == true)
                {
                    DependencyService.Get<INotificationsService>().PushEventoNotif("Existem novos eventos!");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
        }
    }
}