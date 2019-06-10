using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using FreshMvvm;
using Tricker.Helpers;
using Tricker.PageModels;
using Tricker.Pages;

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
			/*var tabs = new FreshTabbedNavigationContainer("TrickerTabs");

            tabs.AddTab<HomePageModel>("Home", "me.png");
            tabs.AddTab<MapPageModel>("Map", "start.png");
            tabs.AddTab<PhotoPageModel>("Photo", "myplan.png");
            tabs.AddTab<ChatPageModel>("Chat", "friends.png");
            tabs.AddTab<AccountPageModel>("Account", "me.png");

            // Set the selected tab to the middle one.
            tabs.SwitchSelectedRootPageModel<AccountPageModel>();

            MainPage = tabs;*/
			//MainPage = new NavigationPage(new LoginPage());
			//MainPage = new NavigationPage(new PersonalPage());
			MainPage = new NavigationPage(new PersonalPage());
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
