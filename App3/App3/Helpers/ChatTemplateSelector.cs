using App3.Models;
using App3.Views.Cells;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace App3.Helpers
{
    class ChatTemplateSelector : DataTemplateSelector
    {
        DataTemplate incomingDataTemplate;
        DataTemplate incomingGroupDataTemplate;
        DataTemplate outgoingDataTemplate;
        private string iduser;

        public ChatTemplateSelector()
        {
            this.incomingDataTemplate = new DataTemplate(typeof(IncomingViewCell));
            this.incomingGroupDataTemplate = new DataTemplate(typeof(IncomingGroupViewCell));
            this.outgoingDataTemplate = new DataTemplate(typeof(OutgoingViewCell));
            testar();
        }

        protected override DataTemplate OnSelectTemplate(object item, BindableObject container)
        {

            var messageVm = item as Mensagem;
            if (messageVm == null)
                return null;
            return (messageVm.Idemissor == Int32.Parse(iduser)) ? outgoingDataTemplate : 
                (messageVm.isGrupo() ? incomingGroupDataTemplate : incomingDataTemplate);

        }

        public async void testar()
        {
            iduser = await SecureStorage.GetAsync("iduser");
        }

    }
}
