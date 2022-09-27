using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using AndroidX.Core.App;
using App3.Droid;
using App3.Services;

[assembly: Xamarin.Forms.Dependency(typeof(NotificationsService))]
namespace App3.Droid
{
    [Service(Label = "NotificationsService")]
    public class NotificationsService : INotificationsService
    {
        private const string CHANNEL_ID = "com.company.app.Igrejas";
        private const string CHANNEL_NAME = "com.company.app.Igrejas";
        private const string CHANNEL_DESCRIPTION = "com.company.app.Igrejas";

        NotificationManager manager;
        bool channelInitialized = false;
        int messageId = 0;
        int pendingIntentId = 0;

        public static NotificationsService Instance { get; private set; }
        public NotificationsService() => Initialize();

        public void Initialize()
        {
            if (Instance == null)
            {
                CreateNotificationChannel();
                Instance = this;
            }
        }

        void CreateNotificationChannel()
        {
            manager = (NotificationManager)Application.Context.GetSystemService(Application.NotificationService);

            if (Build.VERSION.SdkInt >= BuildVersionCodes.O)
            {
                var channelNameJava = new Java.Lang.String(CHANNEL_NAME);
                var channel = new NotificationChannel(CHANNEL_ID, channelNameJava, NotificationImportance.Default)
                {
                    Description = CHANNEL_DESCRIPTION
                };
                manager.CreateNotificationChannel(channel);
            }

            channelInitialized = true;
        }

        private NotificationCompat.Builder CreateBuilder()
        {
            NotificationCompat.Builder builder = new NotificationCompat.Builder(Application.Context, CHANNEL_ID)
                .SetContentTitle("Igrejas")//Application.Context.Resources.GetString(Resource.String.app_name))
                .SetSmallIcon(Resource.Drawable.ic_launcher)
                .SetAutoCancel(true);
            return builder;
        }

        public void PushNotif(string message)
        {
            if (!channelInitialized)
            {
                CreateNotificationChannel();
            }

            //Activity specific extra
            Intent intent = new Intent(Application.Context, typeof(MainActivity));
            intent.PutExtra("page", "Mensagens");

            PendingIntent pendingIntent = PendingIntent.GetActivity(Application.Context, pendingIntentId++, intent, PendingIntentFlags.UpdateCurrent);

            var builder = CreateBuilder();

            builder
                .SetContentIntent(pendingIntent)
                .SetContentText(message);

            Notification notification = builder.Build();
            manager.Notify(messageId++, notification);
        }

        public void PushMensagemNotif(string message)
        {
            //Activity specific extra
            Intent intent = new Intent(Application.Context, typeof(MainActivity));
            intent.PutExtra("page", "Mensagens");

            PendingIntent pendingIntent = PendingIntent.GetActivity(Application.Context, pendingIntentId++, intent, PendingIntentFlags.UpdateCurrent);

            var builder = CreateBuilder();

            builder
                .SetContentIntent(pendingIntent)
                .SetContentText(message);

            Notification notification = builder.Build();
            manager.Notify(messageId++, notification);
        }

        public void PushSocialNotif(string message)
        {
            //Activity specific extra
            Intent intent = new Intent(Application.Context, typeof(MainActivity));
            intent.PutExtra("page", "Social");

            PendingIntent pendingIntent = PendingIntent.GetActivity(Application.Context, pendingIntentId++, intent, PendingIntentFlags.UpdateCurrent);

            var builder = CreateBuilder();

            builder
                .SetContentIntent(pendingIntent)
                .SetContentText(message);

            Notification notification = builder.Build();
            manager.Notify(messageId++, notification);
        }

        public void PushEventoNotif(string message)
        {
            //Activity specific extra
            Intent intent = new Intent(Application.Context, typeof(MainActivity));
            intent.PutExtra("page", "Eventos");

            PendingIntent pendingIntent = PendingIntent.GetActivity(Application.Context, pendingIntentId++, intent, PendingIntentFlags.UpdateCurrent);

            var builder = CreateBuilder();

            builder
                .SetContentIntent(pendingIntent)
                .SetContentText(message);

            Notification notification = builder.Build();
            manager.Notify(messageId++, notification);
        }

    }
}