using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Xamarin.Forms;
using XLabs.Data;
using XLabs.Platform.Services.GeoLocation;

namespace WorkingWithGeoLocator
{
    public class GeoLocatorViewModel : ObservableObject
    {
       private IGeolocator _geolocator;

       private Command _getPositionCommand;

       private readonly TaskScheduler _scheduler = TaskScheduler.FromCurrentSynchronizationContext();

       private CancellationTokenSource _cancelSource;

       private string _positionStatus = string.Empty;
       /// <summary>
       /// The position latitude
       /// </summary>
       private string _positionLatitude = string.Empty;
       /// <summary>
       /// The position longitude
       /// </summary>
       private string _positionLongitude = string.Empty;

       public string PositionStatus
       {
           get
           {
               return _positionStatus;
           }
           set
           {
               SetProperty(ref _positionStatus, value);
           }
       }

       /// <summary>
       /// Gets or sets the position latitude.
       /// </summary>
       /// <value>The position latitude.</value>
       public string PositionLatitude
       {
           get
           {
               return _positionLatitude;
           }
           set
           {
               SetProperty(ref _positionLatitude, value);
           }
       }

       /// <summary>
       /// Gets or sets the position longitude.
       /// </summary>
       /// <value>The position longitude.</value>
       public string PositionLongitude
       {
           get
           {
               return _positionLongitude;
           }
           set
           {
               SetProperty(ref _positionLongitude, value);
           }
       }
       private IGeolocator Geolocator
       {
           get
           {
               if (_geolocator == null)
               {
                   _geolocator = DependencyService.Get<IGeolocator>();
                 // _geolocator.PositionError += OnListeningError;
                   //_geolocator.PositionChanged += OnPositionChanged;
               }
               return _geolocator;

           }
       }
       public Command GetPositionCommand
       {
           get
           {
               //return _getPositionCommand ??
                 //  (_getPositionCommand = new Command(async () => await GetPosition(), () => Geolocator != null));
               return new Command(async () => await GetPosition());
           }
       }

       private async Task GetPosition()
       {
           _cancelSource = new CancellationTokenSource();

           PositionStatus = string.Empty;
           PositionLatitude = string.Empty;
           PositionLongitude = string.Empty;
          
           await
               Geolocator.GetPositionAsync(10000, _cancelSource.Token, true)
                   .ContinueWith(t =>
                   {
                      
                       if (t.IsFaulted)
                       {
                           PositionStatus = ((GeolocationException)t.Exception.InnerException).Error.ToString();
                       }
                       else if (t.IsCanceled)
                       {
                           PositionStatus = "Canceled";
                       }
                       else
                       {
                           PositionStatus = t.Result.Timestamp.ToString("G");
                           PositionLatitude = "La: " + t.Result.Latitude.ToString("N4");
                           PositionLongitude = "Lo: " + t.Result.Longitude.ToString("N4");
                       }
                   }, _scheduler);
       }

           private void OnListeningError(object sender, PositionErrorEventArgs e)
		{
///			BeginInvokeOnMainThread (() => {
////				ListenStatus.Text = e.Error.ToString();
////			});

            System.Diagnostics.Debug.WriteLine(e.Error.ToString());
		}
       private void OnPositionChanged(object sender, PositionEventArgs e)
		{
////			BeginInvokeOnMainThread (() => {
////				ListenStatus.Text = e.Position.Timestamp.ToString("G");
////				ListenLatitude.Text = "La: " + e.Position.Latitude.ToString("N4");
////				ListenLongitude.Text = "Lo: " + e.Position.Longitude.ToString("N4");
////			});
		}
    }
}
