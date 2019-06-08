﻿using System;
using System.Collections.Generic;
using System.Linq;
using FormsToolkit;
using Tricker.Controls;
using Tricker.Helpers;
using Plugin.Geolocator;
using Xamarin.Forms;
using Xamarin.Forms.Maps;

namespace Tricker.Pages
{
    public partial class MapPage : LogoPage
    {
        public MapPage()
        {
            InitializeComponent();
        }

        protected async override void OnAppearing()
        {
            base.OnAppearing();

            // Show the logo
            MessagingService.Current.SendMessage(Constants.ChangeToolbar, true);

            // On Droid this wraps behind the other views.
            if (Device.RuntimePlatform == Device.Android)
            {
                Grid.SetRowSpan(mapView, 3);

                if (ToolbarItems.Count > 1)
                {
                    var firstItem = ToolbarItems.FirstOrDefault();
                    ToolbarItems.Remove(firstItem);
                }
            }

            try
            {
                // Set the map to your current location.
                var locator = CrossGeolocator.Current;
                Plugin.Geolocator.Abstractions.Position position = await locator.GetPositionAsync(TimeSpan.FromSeconds(5), null, true);

                if (position != null)
                {
                    mapView.MoveToRegion(MapSpan.FromCenterAndRadius(new Position(position.Latitude, position.Longitude), Distance.FromMiles(10)).WithZoom(16));
                }
            }
            catch
            {
                // No biggie if you don't allow location, only here for show purposes.
            }
        }

        protected override void OnDisappearing()
        {
            base.OnDisappearing();

            // Remove the logo
            MessagingService.Current.SendMessage(Constants.ChangeToolbar, false);
        }
    }
}
