﻿using System;
using System.ComponentModel;
using Android.Content;
using Android.Gms.Maps;
using Android.Gms.Maps.Model;
using Tricker.Controls;
using Tricker.Droid.Renderers;
using Xamarin.Forms;
using Xamarin.Forms.Maps;
using Xamarin.Forms.Maps.Android;
using Xamarin.Forms.Platform.Android;

[assembly: ExportRenderer(typeof(TrickerMap), typeof(CustomMapRenderer))]
namespace Tricker.Droid.Renderers
{

    public class CustomMapRenderer : MapRenderer
    {
        bool isDrawn;

        public CustomMapRenderer(Context context) : base(context) { }
        protected override void OnElementChanged(Xamarin.Forms.Platform.Android.ElementChangedEventArgs<Map> e)
        {
            base.OnElementChanged(e);

            if (e.NewElement != null)
            {
                var formsMap = (TrickerMap)e.NewElement;
                Control.GetMapAsync(this);
            }
        }

        protected override void OnElementPropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
        {
            base.OnElementPropertyChanged(sender, e);

            if (e.PropertyName.Equals("VisibleRegion") && !isDrawn)
            {
                NativeMap.SetPadding(0, 0, 0, 900);

                NativeMap.MyLocationEnabled = true;
                NativeMap.UiSettings.ZoomControlsEnabled = false;
                NativeMap.UiSettings.CompassEnabled = false;
                NativeMap.UiSettings.MyLocationButtonEnabled = true;
                NativeMap.BuildingsEnabled = false;

                isDrawn = true;
            }
        }
    }
}