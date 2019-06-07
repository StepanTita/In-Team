using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Tricker.ViewModels;
using System.Windows.Input;
using Xamarin.Auth;
using System.Net.Http;
using System.Collections.Generic;
using Android.App;

namespace Tricker.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class LoginPage : ContentPage
    {
        public ICommand OnClickLabelCommand { protected set; get; }
        private static readonly HttpClient client = new HttpClient();
        private readonly string url = "https://tricker-server.herokuapp.com/";
        public static readonly string GOOGLE_ID =
                          "908587121681-dmgcqqknvdsjfkrtug47h1dlohbntkf2.apps.googleusercontent.com";
        public static readonly string GOOGLE_SCOPE =
                                 "https://www.googleapis.com/auth/userinfo.email";
        public static readonly string GOOGLE_AUTH =
                                   "https://accounts.google.com/o/oauth2/auth";
        public static readonly string GOOGLE_REDIRECTURL =
                                  "";
        public static readonly string GOOGLE_REQUESTURL =
                                  "https://www.googleapis.com/oauth2/v2/userinfo";
        public static readonly string FB_APPID = "298607957716911";
        public static readonly string FB_SCOPE = "";
        public static readonly string FB_AUTHURL = "https://m.facebook.com/dialog/oauth/";
        public static readonly string FB_REDIRECTURL = "";
        public static readonly string FB_REQUESTURL = "https://graph.facebook.com/me?fields=id,name,email,picture.type(large)";

        LoginViewModel vm;
        public LoginPage()
        {
            vm = new LoginViewModel();
            this.BindingContext = vm;
            vm.DisplayInvalidLoginPrompt += () => DisplayAlert("Error", "Invalid Login, try again", "OK");
            InitializeComponent();

            Email.Completed += (object sender, EventArgs e) =>
            {
                Password.Focus();
            };

            Password.Completed += (object sender, EventArgs e) =>
            {
                Go.Focus();
            };
            Google.Clicked += GoogleAuthentication;
            Facebook.Clicked += FacebookAuthentication;
        }

        private  async void toRegister_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new AuthorizationPage());
        }

        private async void Submit_Clicked(object sender, EventArgs e)
        {
            Dictionary<string, string> data = new Dictionary<string, string>()
            {
                {"Email", Email.Text},
                {"Password", Password.Text }
            };
            FormUrlEncodedContent form = new FormUrlEncodedContent(data);
            HttpResponseMessage response = await client.PostAsync(url, form);

        }
        private  void Facebook_Clicked(object sender, EventArgs e)
        {
            FacebookAuthentication(sender, e);
        }

        private void Google_Clicked(object sender, EventArgs e)
        {
            
            GoogleAuthentication(sender, e);
        }

        private void GoogleAuthentication(object sender, EventArgs e)
        {
            var auth = new OAuth2Authenticator
                       (
                         GOOGLE_ID,
                         GOOGLE_SCOPE,
                         new Uri(GOOGLE_AUTH),
                         new Uri(GOOGLE_REDIRECTURL)
                        );

            auth.AllowCancel = true;
            auth.Completed += async (sender2, e2) =>
            {
                if (!e2.IsAuthenticated)
                {
                    return;
                }
                var request = new OAuth2Request
                              (
                                 "GET",
                                  new Uri(GOOGLE_REQUESTURL),
                                  null,
                                  e2.Account
                              );
                var response = await request.GetResponseAsync();
                if (response != null)
                {
                    var userData = response.GetResponseText();
                }
            };
        }
        private void FacebookAuthentication(object sender, EventArgs e)
        {
            var auth = new OAuth2Authenticator
                       (
                         GOOGLE_ID,
                         GOOGLE_SCOPE,
                         new Uri(GOOGLE_AUTH),
                         new Uri(GOOGLE_REDIRECTURL)
                        );

            auth.AllowCancel = true;
            auth.Completed += async (sender2, e2) =>
            {
                if (!e2.IsAuthenticated)
                {
                    return;
                }
                var request = new OAuth2Request
                              (
                                 "GET",
                                  new Uri(GOOGLE_REQUESTURL),
                                  null,
                                  e2.Account
                              );
                var response = await request.GetResponseAsync();
                if (response != null)
                {
                    var userData = response.GetResponseText();
                }
            };
        }
    }
}