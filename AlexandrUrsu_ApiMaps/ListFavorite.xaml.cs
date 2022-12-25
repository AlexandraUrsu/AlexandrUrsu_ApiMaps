using AlexandrUrsu_ApiMaps.Models;
using SQLite;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.GoogleMaps;
using Xamarin.Forms.Xaml;

namespace AlexandrUrsu_ApiMaps
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ListFavorite : ContentPage
    {
        public ListFavorite()
        {
            InitializeComponent();

        }

        protected override async void OnAppearing()
        {
            base.OnAppearing();
            list_favorite.ItemsSource = await App.Database.GetFavoritePlaceAsync();  
        }
        private async void ListFavorite_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            Favorite fav = list_favorite.SelectedItem as Favorite;
            var actionSheet = await DisplayActionSheet(fav.Name, "Cancel", null, "View", "Remove");

            switch (actionSheet)
            {
                case "Cancel":

                    break;

                case "View":
                    var viewactionSheet = await DisplayActionSheet(fav.Name, "Cancel",null, "Open Location", "Website", "Call");

                    switch (viewactionSheet)
                    {
                        case "Cancel":

                            break;

                        case "Open Location":
                            Geocoder geoCoder = new Geocoder();
                            IEnumerable<Position> approximateLocations = await geoCoder.GetPositionsForAddressAsync(fav.Adress);
                            Position position = approximateLocations.FirstOrDefault();

                            await Navigation.PushModalAsync(new MapsApi(position.Latitude, position.Longitude));

                            break;


                        case "Website":

                            await Navigation.PushModalAsync(new WebPage(fav.Website));

                            break;

                        case "Call":

                            await Launcher.OpenAsync("tel:" + fav.Phone);

                            break;
                    }
                 break;


                case "Remove":
                    await DisplayAlert(fav.Name, "Removed from favorites", "ok");
                    await App.Database.DeleteFavoritePlaceAsync(fav);
                     await Navigation.PopModalAsync();
                    

                    break;
            }


        }
    }
}
