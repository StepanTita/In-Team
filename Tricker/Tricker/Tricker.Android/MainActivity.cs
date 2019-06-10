using System;

using Android.App;
using Android.Content;
using Android.Content.PM;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;
using FFImageLoading.Forms;
using CarouselView.FormsPlugin.Android;
using Xamarin.Forms;
using Tricker.Helpers;
using FormsToolkit;
using Android.Text.Style;
using Android.Text;
using FFImageLoading.Forms.Platform;
using ImageCircle.Forms.Plugin.Droid;

namespace Tricker.Droid
{
    [Activity(Label = "Tricker", Icon = "@drawable/icon", Theme = "@style/MainTheme", MainLauncher = true, ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation)]
    public class MainActivity : global::Xamarin.Forms.Platform.Android.FormsAppCompatActivity
    {

		protected override void OnCreate(Bundle bundle)
        {
            TabLayoutResource = Resource.Layout.Tabbar;
            ToolbarResource = Resource.Layout.ToolbarWithLogo;

            CachedImageRenderer.Init(true);
            CarouselViewRenderer.Init();
            Xamarin.FormsMaps.Init(this, bundle);

            base.OnCreate(bundle);

            global::Xamarin.Forms.Forms.Init(this, bundle);
			ImageCircleRenderer.Init();

			LoadApplication(new App());

            // Remove the logo when we're not on the main page.
            MessagingService.Current.Subscribe<bool>(Helpers.Constants.ChangeToolbar, (page, showImage) =>
            {
                // Change the toolbar to be without logo
                if (showImage)
                    ToolbarResource = Resource.Layout.ToolbarWithLogo;
                else
                    ToolbarResource = Resource.Layout.Toolbar;
            });
        }
	}
}
