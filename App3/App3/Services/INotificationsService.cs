using System;
using System.Collections.Generic;
using System.Text;

namespace App3.Services
{
    public interface INotificationsService
    {
        //void PushServicoNotif(string message);
        //void PushMensagemNotif(string message);
        void PushNotif(string message);
        void PushMensagemNotif(string message);
        void PushSocialNotif(string message);
        void PushEventoNotif(string message);
    }
}
