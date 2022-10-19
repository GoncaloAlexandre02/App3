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
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;
using App3;
using App3.Renderer;
using Xamarin.Facebook;
using Object = Java.Lang.Object;
using App3.Droid.Renderer;

[assembly: ExportRenderer(typeof(FbLoginImage), typeof(FbLoginImageRenderer))]
namespace App3.Droid.Renderer
{
    public class FbLoginImageRenderer : ImageRenderer
    {
        private static Activity _activity;

        public FbLoginImageRenderer(Context context) : base(context)
        {
        }

        protected override void OnElementChanged(ElementChangedEventArgs<Image> e)
		{
			base.OnElementChanged(e);

			_activity = this.Context.GetActivity();// as Activity;

			//DEBUG
			Xamarin.Facebook.Login.LoginManager.Instance.LogOut();

			if (this.Control != null)
			{
				Android.Widget.ImageView button = this.Control;
				button.SetOnClickListener(ImageClickListener.Instance.Value);
			}

			if (AccessToken.CurrentAccessToken != null)
			{
				App.PostSuccessFacebookAction(AccessToken.CurrentAccessToken.Token);
			}
		}

		private class ImageClickListener : Object, IOnClickListener
		{
			public static readonly Lazy<ImageClickListener> Instance = new Lazy<ImageClickListener>(() => new ImageClickListener());

			public void OnClick(Android.Views.View v)
			{
				var myIntent = new Intent(_activity, typeof(Activity1));
				_activity.StartActivityForResult(myIntent, 0);
			}
		}
	}
}