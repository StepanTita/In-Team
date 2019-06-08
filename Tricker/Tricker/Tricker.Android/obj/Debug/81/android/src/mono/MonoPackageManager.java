package mono;

import java.io.*;
import java.lang.String;
import java.util.Locale;
import java.util.HashSet;
import java.util.zip.*;
import java.util.Arrays;
import android.content.Context;
import android.content.Intent;
import android.content.pm.ApplicationInfo;
import android.content.res.AssetManager;
import android.util.Log;
import mono.android.Runtime;

public class MonoPackageManager {

	static Object lock = new Object ();
	static boolean initialized;

	static android.content.Context Context;

	public static void LoadApplication (Context context, ApplicationInfo runtimePackage, String[] apks)
	{
		synchronized (lock) {
			if (context instanceof android.app.Application) {
				Context = context;
			}
			if (!initialized) {
				android.content.IntentFilter timezoneChangedFilter  = new android.content.IntentFilter (
						android.content.Intent.ACTION_TIMEZONE_CHANGED
				);
				context.registerReceiver (new mono.android.app.NotifyTimeZoneChanges (), timezoneChangedFilter);

				Locale locale       = Locale.getDefault ();
				String language     = locale.getLanguage () + "-" + locale.getCountry ();
				String filesDir     = context.getFilesDir ().getAbsolutePath ();
				String cacheDir     = context.getCacheDir ().getAbsolutePath ();
				String dataDir      = getNativeLibraryPath (context);
				ClassLoader loader  = context.getClassLoader ();
				java.io.File external0 = android.os.Environment.getExternalStorageDirectory ();
				String externalDir = new java.io.File (
							external0,
							"Android/data/" + context.getPackageName () + "/files/.__override__").getAbsolutePath ();
				String externalLegacyDir = new java.io.File (
							external0,
							"../legacy/Android/data/" + context.getPackageName () + "/files/.__override__").getAbsolutePath ();

				System.loadLibrary("monodroid");

				Runtime.init (
						language,
						apks,
						getNativeLibraryPath (runtimePackage),
						new String[]{
							filesDir,
							cacheDir,
							dataDir,
						},
						loader,
						new String[] {
							externalDir,
							externalLegacyDir
						},
						MonoPackageManager_Resources.Assemblies,
						context.getPackageName (),
						android.os.Build.VERSION.SDK_INT,
						mono.android.app.XamarinAndroidEnvironmentVariables.Variables);
				
				mono.android.app.ApplicationRegistration.registerApplications ();
				
				initialized = true;
			}
		}
	}

	public static void setContext (Context context)
	{
		// Ignore; vestigial
	}

	static String getNativeLibraryPath (Context context)
	{
	    return getNativeLibraryPath (context.getApplicationInfo ());
	}

	static String getNativeLibraryPath (ApplicationInfo ainfo)
	{
		if (android.os.Build.VERSION.SDK_INT >= 9)
			return ainfo.nativeLibraryDir;
		return ainfo.dataDir + "/lib";
	}

	public static String[] getAssemblies ()
	{
		return MonoPackageManager_Resources.Assemblies;
	}

	public static String[] getDependencies ()
	{
		return MonoPackageManager_Resources.Dependencies;
	}

	public static String getApiPackageName ()
	{
		return MonoPackageManager_Resources.ApiPackageName;
	}
}

class MonoPackageManager_Resources {
	public static final String[] Assemblies = new String[]{
		/* We need to ensure that "Tricker.Android.dll" comes first in this list. */
		"Tricker.Android.dll",
		"Bolts.AppLinks.dll",
		"Bolts.Tasks.dll",
		"CarouselView.FormsPlugin.Abstractions.dll",
		"CarouselView.FormsPlugin.Android.dll",
		"Com.Android.DeskClock.dll",
		"Com.ViewPagerIndicator.dll",
		"Corcav.Behaviors.dll",
		"FFImageLoading.dll",
		"FFImageLoading.Forms.dll",
		"FFImageLoading.Forms.Platform.dll",
		"FFImageLoading.Platform.dll",
		"FFImageLoading.Transformations.dll",
		"FormsToolkit.Android.dll",
		"FormsToolkit.dll",
		"FormsViewGroup.dll",
		"FreshIOC.dll",
		"FreshMvvm.dll",
		"Google.ZXing.Core.dll",
		"Merq.dll",
		"Newtonsoft.Json.dll",
		"Plugin.CurrentActivity.dll",
		"Plugin.DeviceInfo.Abstractions.dll",
		"Plugin.DeviceInfo.dll",
		"Plugin.Geolocator.dll",
		"Plugin.Permissions.dll",
		"System.Diagnostics.Tracer.dll",
		"System.Net.Mqtt.dll",
		"System.Reactive.Core.dll",
		"System.Reactive.dll",
		"System.Reactive.Interfaces.dll",
		"System.Reactive.Linq.dll",
		"System.Reactive.PlatformServices.dll",
		"Tricker.dll",
		"Xam.Behaviors.dll",
		"Xamarin.Android.Arch.Core.Common.dll",
		"Xamarin.Android.Arch.Lifecycle.Common.dll",
		"Xamarin.Android.Arch.Lifecycle.Runtime.dll",
		"Xamarin.Android.Support.Animated.Vector.Drawable.dll",
		"Xamarin.Android.Support.Annotations.dll",
		"Xamarin.Android.Support.Compat.dll",
		"Xamarin.Android.Support.Core.UI.dll",
		"Xamarin.Android.Support.Core.Utils.dll",
		"Xamarin.Android.Support.CustomTabs.dll",
		"Xamarin.Android.Support.Design.dll",
		"Xamarin.Android.Support.Fragment.dll",
		"Xamarin.Android.Support.Media.Compat.dll",
		"Xamarin.Android.Support.Transition.dll",
		"Xamarin.Android.Support.v4.dll",
		"Xamarin.Android.Support.v7.AppCompat.dll",
		"Xamarin.Android.Support.v7.CardView.dll",
		"Xamarin.Android.Support.v7.MediaRouter.dll",
		"Xamarin.Android.Support.v7.Palette.dll",
		"Xamarin.Android.Support.v7.RecyclerView.dll",
		"Xamarin.Android.Support.Vector.Drawable.dll",
		"Xamarin.Auth.dll",
		"Xamarin.Essentials.dll",
		"Xamarin.Facebook.Android.dll",
		"Xamarin.Facebook.AppLinks.Android.dll",
		"Xamarin.Facebook.Common.Android.dll",
		"Xamarin.Facebook.Core.Android.dll",
		"Xamarin.Facebook.Login.Android.dll",
		"Xamarin.Facebook.Messenger.Android.dll",
		"Xamarin.Facebook.Places.Android.dll",
		"Xamarin.Facebook.Share.Android.dll",
		"Xamarin.Forms.Core.dll",
		"Xamarin.Forms.GoogleMaps.Android.dll",
		"Xamarin.Forms.GoogleMaps.dll",
		"Xamarin.Forms.Loader.dll",
		"Xamarin.Forms.Maps.Android.dll",
		"Xamarin.Forms.Maps.dll",
		"Xamarin.Forms.Platform.Android.dll",
		"Xamarin.Forms.Platform.dll",
		"Xamarin.Forms.Xaml.dll",
		"Xamarin.GooglePlayServices.Base.dll",
		"Xamarin.GooglePlayServices.Basement.dll",
		"Xamarin.GooglePlayServices.Maps.dll",
		"Xamarin.GooglePlayServices.Tasks.dll",
		"Xamarin.Live.dll",
		"Xamarin.Live.Reload.dll",
	};
	public static final String[] Dependencies = new String[]{
	};
	public static final String ApiPackageName = "Mono.Android.Platform.ApiLevel_27";
}
