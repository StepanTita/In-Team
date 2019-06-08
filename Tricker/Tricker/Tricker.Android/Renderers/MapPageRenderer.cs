using System;
using Android.App;
using Android.Content;
using Tricker.Droid.Renderers;
using Tricker.Pages;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;

[assembly: ExportRenderer(typeof(MapPage), typeof(MapPageRenderer))]
namespace Tricker.Droid.Renderers
{
    
    public class MapPageRenderer : PageRenderer
    {
        public MapPageRenderer(Context context) : base(context) { }
        protected override void OnElementChanged(ElementChangedEventArgs<Page> e)
        {
            base.OnElementChanged(e);
        }
    }
}