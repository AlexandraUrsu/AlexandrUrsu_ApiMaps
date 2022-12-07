using AlexandrUrsu_ApiMaps;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.GoogleMaps;
using Xamarin.Forms.Xaml;
using Plugin.Permissions;
using Plugin.Permissions.Abstractions;
using System.Collections.ObjectModel;
using System.Diagnostics;
using Xamarin.Forms.PlatformConfiguration.iOSSpecific;

namespace AlexandrUrsu_ApiMaps
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MapsApi : ContentPage
    {

        public MapsApi()
        {
            InitializeComponent();
            map.MoveToRegion(new MapSpan(new Position(46.770439, 23.591423), 0, 0));
           
        }


        private async void OnLocalizeClicked(object sender, EventArgs e)
        {
            Location mylocation = await Geolocation.GetLastKnownLocationAsync();
               
           // if (mylocation != null)
            //    map.MoveToRegion(new MapSpan(new Position(mylocation.Latitude, mylocation.Longitude), 0, 0));
           // else  
            if (mylocation == null)
            {
                     mylocation = await Geolocation.GetLocationAsync(new GeolocationRequest
                     {
                            DesiredAccuracy = GeolocationAccuracy.Lowest,
                            Timeout = TimeSpan.FromSeconds(10)
                     });
                    //if (mylocation != null)
                      //  map.MoveToRegion(new MapSpan(new Position(mylocation.Latitude, mylocation.Longitude), 0, 0)); 
            }
            
            if (mylocation != null)
            {
                     Geocoder geoCoder = new Geocoder();
                     Position position = new Position(mylocation.Latitude, mylocation.Longitude);
                     IEnumerable<string> possibleAddresses = await geoCoder.GetAddressesForPositionAsync(position);
                     string address = possibleAddresses.FirstOrDefault();
                     Pin pin = new Pin
                     {
                        Label = "My location",
                        Address = address,
                        Type = PinType.Place,
                        Position = new Position(mylocation.Latitude, mylocation.Longitude)
                     };
                     map.Pins.Add(pin);
                     map.MoveToRegion(new MapSpan(new Position(mylocation.Latitude, mylocation.Longitude), 0, 0));         
            }
            
        }


        private void OnStreetClicked(object sender, EventArgs e)
        {
            map.MapType = MapType.Street;
        }

        private void OnTerrainClicked(object sender, EventArgs e)
        {
            map.MapType = MapType.Terrain;
        }

        private void OnHybridClicked(object sender, EventArgs e)
        {
            map.MapType = MapType.Hybrid;
        }

        private void OnSatelliteClicked(object sender, EventArgs e)
        {
            map.MapType = MapType.Satellite;
        }

        private void OnSearchClicked(object sender, EventArgs e)
        {
            Navigation.PushModalAsync(new PlaceApi());
        }
    }
}

    