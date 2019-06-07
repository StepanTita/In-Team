﻿using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Tricker.Views;

[assembly: XamlCompilation(XamlCompilationOptions.Compile)]
namespace Tricker
{
    public partial class App : Application
    {
        public App()
        {

            InitializeComponent();
            #if DEBUG
            LiveReload.Init();
            #endif

            MainPage = new NavigationPage(new LoginPage());
        }

        protected override void OnStart()
        {
            // Handle when your app starts
        }

        protected override void OnSleep()
        {
            // Handle when your app sleeps
        }

        protected override void OnResume()
        {
            // Handle when your app resumes
        }
    }
}
