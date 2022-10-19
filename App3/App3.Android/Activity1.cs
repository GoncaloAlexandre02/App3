using Android.App;
using Android.Content;
using Android.OS;
using Java.Lang;
using Xamarin.Facebook.Login;
using Xamarin.Facebook;
using System;
using App3;

[assembly: MetaData("com.facebook.sdk.ApplicationId", Value = "@string/facebook_app_id")]
namespace App3.Droid
{
    [Activity(Label = "Activity1")]
    public class Activity1 : Activity
    {
        ICallbackManager callbackManager;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Create your application here
            if(AccessToken.CurrentAccessToken != null)
            {
                App.PostSuccessFacebookAction(AccessToken.CurrentAccessToken.Token);
                Finish();
                return;
            }

            callbackManager = CallbackManagerFactory.Create();
            LoginManager.Instance.RegisterCallback(callbackManager, new FacebookCallBack());

            LoginManager.Instance.LogOut();
            LoginManager.Instance.LogIn(this, new string[] { "public_profile", "email" });
        }

        protected override void OnActivityResult(int requestCode, Result resultCode, Intent data)
        {
            base.OnActivityResult(requestCode, resultCode, data);

            callbackManager.OnActivityResult(requestCode, (int)resultCode, data);
            Finish();
        }
    }

    public class FacebookCallBack : Java.Lang.Object, IFacebookCallback, IDisposable
    {
        #region IFacebookCallback implementation
        public void OnCancel()
        {

        }
        public void OnError(FacebookException p0)
        {

        }
        public void OnSuccess(Java.Lang.Object p0)
        {
            LoginResult loginResult = (LoginResult)p0;

            var parameters = new Bundle();
            parameters.PutString("fields", "id,email,picture.type(large)");
            //var request = GraphRequest.NewMeRequest(loginResult.AccessToken, this);
            //request.Parameters = parameters;
            //request.ExecuteAsync();

            App.PostSuccessFacebookAction(loginResult.AccessToken.Token);
        }
        #endregion
    }
}