using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Tricker.ViewModels;
using System.Collections.Generic;
using System.Net.Http;
using Newtonsoft.Json;

namespace Tricker.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class AuthorizationPage : ContentPage
    {
        private static readonly HttpClient client = new HttpClient();
        private readonly string url = "https://tricker-server.herokuapp.com/";
        public AuthorizationPage()
        {
            var vm = new AuthorizationViewModel();
            this.BindingContext = vm;
            InitializeComponent();
            Email.Completed += (object sender, EventArgs e) =>
            {
                FullName.Focus();
            };

            FullName.Completed += (object sender, EventArgs e) =>
            {
                Login.Focus();
            };

            Login.Completed += (object sender, EventArgs e) =>
            {
                Password.Focus();
            };

            Password.Completed += (object sender, EventArgs e) =>
            {
                Go.Focus();
            };

        }

        private async void toLogin_Clicked(object sender, EventArgs e)
        {
            Dictionary<string, string> data = new Dictionary<string, string>()
            {
                {"Email", Email.Text},
                {"FullName", FullName.Text },
                {"Login", Login.Text },
                {"Password", Password.Text }
            };
            string json = JsonConvert.SerializeObject(data);
            HttpContent content = new StringContent(json);
            HttpClient client = new HttpClient();
            HttpResponseMessage response = await client.PostAsync(url, content);
      
            await Navigation.PopAsync();
        }

        private async void Terms_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new TermsPage());
        }
    }
}