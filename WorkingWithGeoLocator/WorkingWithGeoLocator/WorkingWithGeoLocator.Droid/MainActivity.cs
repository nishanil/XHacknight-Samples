using System;

using Android.App;
using Android.Content.PM;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;
using Xamarin.Forms;
using XLabs.Platform.Services.GeoLocation;
using XLabs.Platform.Services.Geolocation;

namespace WorkingWithGeoLocator.Droid
{
    [Activity(Label = "WorkingWithGeoLocator", Icon = "@drawable/icon", MainLauncher = true, ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation)]
    public class MainActivity : global::Xamarin.Forms.Platform.Android.FormsApplicationActivity
    {
        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);

            global::Xamarin.Forms.Forms.Init(this, bundle);
			DependencyService.Register<IGeolocator, Geolocator>();
            LoadApplication(new App());
        }
    }
}

