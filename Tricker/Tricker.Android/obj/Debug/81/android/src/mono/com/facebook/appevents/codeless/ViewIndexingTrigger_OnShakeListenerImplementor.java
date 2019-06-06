package mono.com.facebook.appevents.codeless;


public class ViewIndexingTrigger_OnShakeListenerImplementor
	extends java.lang.Object
	implements
		mono.android.IGCUserPeer,
		com.facebook.appevents.codeless.ViewIndexingTrigger.OnShakeListener
{
/** @hide */
	public static final String __md_methods;
	static {
		__md_methods = 
			"n_onShake:()V:GetOnShakeHandler:Xamarin.Facebook.AppEvents.Codeless.ViewIndexingTrigger/IOnShakeListenerInvoker, Xamarin.Facebook.Core.Android\n" +
			"";
		mono.android.Runtime.register ("Xamarin.Facebook.AppEvents.Codeless.ViewIndexingTrigger+IOnShakeListenerImplementor, Xamarin.Facebook.Core.Android", ViewIndexingTrigger_OnShakeListenerImplementor.class, __md_methods);
	}


	public ViewIndexingTrigger_OnShakeListenerImplementor ()
	{
		super ();
		if (getClass () == ViewIndexingTrigger_OnShakeListenerImplementor.class)
			mono.android.TypeManager.Activate ("Xamarin.Facebook.AppEvents.Codeless.ViewIndexingTrigger+IOnShakeListenerImplementor, Xamarin.Facebook.Core.Android", "", this, new java.lang.Object[] {  });
	}


	public void onShake ()
	{
		n_onShake ();
	}

	private native void n_onShake ();

	private java.util.ArrayList refList;
	public void monodroidAddReference (java.lang.Object obj)
	{
		if (refList == null)
			refList = new java.util.ArrayList ();
		refList.add (obj);
	}

	public void monodroidClearReferences ()
	{
		if (refList != null)
			refList.clear ();
	}
}
