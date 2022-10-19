using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Android.App;
using Android.Content;
using Android.OS;
using App3.Droid;
using App3.Models;
using App3.Services;
using Org.Json;
using Plugin.CurrentActivity;
using Xamarin.Facebook;
using Xamarin.Facebook.Login;
using Xamarin.Forms;

[assembly: MetaData("com.facebook.sdk.ApplicationId", Value = "@string/facebook_app_id")]
[assembly: Dependency(typeof(FacebookAuthService))]
namespace App3.Droid
{
    public class FacebookAuthService : Java.Lang.Object, IFacebookAuthService, GraphRequest.IGraphJSONObjectCallback, GraphRequest.ICallback, IFacebookCallback
	{
		Context _context;

		public static FacebookAuthService Instance => DependencyService.Get<IFacebookAuthService>() as FacebookAuthService;

		readonly ICallbackManager _callbackManager = CallbackManagerFactory.Create();
		readonly string[] _permissions = { @"public_profile", @"email", @"user_about_me" };

        Services.LoginResult _loginResult;
		TaskCompletionSource<Services.LoginResult> _completionSource;

		public FacebookAuthService()
		{
			_context = global::Android.App.Application.Context;
			LoginManager.Instance.RegisterCallback(_callbackManager, this);

		}

		public Task<Services.LoginResult> Login()
		{
			var aa = CrossCurrentActivity.Current;
			var ab = Xamarin.Essentials.Platform.CurrentActivity;
			var ac = Forms.Context;
			var ll = ac as Activity;

			_completionSource = new TaskCompletionSource<Services.LoginResult>();
			LoginManager.Instance.LogInWithReadPermissions(Forms.Context as Activity, _permissions);
			return _completionSource.Task;
		}

		public void Logout()
		{
			LoginManager.Instance.LogOut();
		}

		public void OnActivityResult(int requestCode, int resultCode, Intent data)
		{
			_callbackManager?.OnActivityResult(requestCode, resultCode, data);
		}

		public void OnCompleted(JSONObject data, GraphResponse response)
		{
			OnCompleted(response);
		}

		public void OnCompleted(GraphResponse response)
		{
			if (response?.JSONObject == null)
				_completionSource?.TrySetResult(new Services.LoginResult { LoginState = LoginState.Canceled });
			else
			{
				_loginResult = new Services.LoginResult
                {
					FirstName = Profile.CurrentProfile.FirstName,
					LastName = Profile.CurrentProfile.LastName,
					Email = response.JSONObject.Has("email") ? response.JSONObject.GetString("email") : string.Empty,
					ImageUrl = response.JSONObject.GetJSONObject("picture")?.GetJSONObject("data")?.GetString("url"),
					Token = AccessToken.CurrentAccessToken.Token,
					UserId = AccessToken.CurrentAccessToken.UserId,
					ExpireAt = FromJavaDateTime(AccessToken.CurrentAccessToken?.Expires?.Time),
					LoginState = LoginState.Success
				};

				_completionSource?.TrySetResult(_loginResult);
			}
		}


		public void OnCancel()
		{
			_completionSource?.TrySetResult(new Services.LoginResult { LoginState = LoginState.Canceled });
		}

		public void OnError(FacebookException exception)
		{
			_completionSource?.TrySetResult(new Services.LoginResult
            {
				LoginState = LoginState.Failed,
				ErrorString = exception?.Message
			});
		}

		public void OnSuccess(Java.Lang.Object result)
		{
			var facebookLoginResult = result as Xamarin.Facebook.Login.LoginResult;
			if (facebookLoginResult == null) return;

			var parameters = new Bundle();
			parameters.PutString("fields", "id,email,picture.type(large)");
			var request = GraphRequest.NewMeRequest(facebookLoginResult.AccessToken, this);
			request.Parameters = parameters;
			request.ExecuteAsync();
		}

		static DateTimeOffset FromJavaDateTime(long? longTimeMillis)
		{
			var epoch = new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc);
			return longTimeMillis != null ? epoch.AddMilliseconds(longTimeMillis.Value) : DateTimeOffset.MinValue;
		}
	}
}