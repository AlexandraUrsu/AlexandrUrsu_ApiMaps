﻿using AlexandrUrsu_ApiMaps.Models;
using AlexandrUrsu_ApiMaps.RestClient;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.GoogleMaps;
using Xamarin.Forms.Xaml;
using static AlexandrUrsu_ApiMaps.Models.Place;

namespace AlexandrUrsu_ApiMaps
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class PlaceApi : ContentPage
    {
        private static readonly string PlaceAPIkey = "AIzaSyDb65285S4mY2tne-gOtOHYYI9qa84Ee1E";

        private readonly string nearbyQuery =
            "https://maps.googleapis.com/maps/api/place/nearbysearch/json?location={0}%2C{1}&radius={2}&type={3}&keyword={4}&key=" +
            PlaceAPIkey;

        public string radius = "1500";
        public string typeSearch = "Company";

        public PlaceApi()
        {
            InitializeComponent();
            AddTypeToPicker();
        }

        private void PickerType_OnSelectedIndexChanged(object sender, EventArgs e)
        {
            typeSearch = picker.SelectedItem.ToString();
        }


        private async void ButtonSearch_OnClicked(object sender, EventArgs e)
        {
            ActivityIndicatorStatus.IsVisible = true;
            var request = new GeolocationRequest(GeolocationAccuracy.Medium);
            var location = await Geolocation.GetLocationAsync(request);

            var result = await NearByPlaceSearch(nearbyQuery, location.Latitude.ToString(), location.Longitude.ToString(), radius, typeSearch, typeSearch, "");
            
            var listPlaces = new ObservableCollection<Place.Result>();
            
            foreach (var item in result.results)
            {
                listPlaces.Add(item);

            }
            
            ListViewResult.ItemsSource = listPlaces;
            ActivityIndicatorStatus.IsVisible = false;

        }

        public async Task<Place.RootObject> NearByPlaceSearch(string googleQuery, string lat, string lng, string radius, string type, string keyword, string nextPageToken)
        {
            var pagetoken = nextPageToken != null ? "&pagetoken=" + nextPageToken : null;

            lat = lat.Replace(",", ".");
            lng = lng.Replace(",", ".");

            var requestUri = string.Format(googleQuery, lat, lng, radius, type, keyword) + pagetoken;
            
            try
            {
                var restClient = new RestClient<Place.RootObject>();
                var result = await restClient.GetAsync(requestUri);
                ale.Text = requestUri;
                return result;
                
            }
            catch (Exception e)
            {
                Debug.WriteLine("Near by place search error: " + e.Message);
            }
            return null;
        }

        private void AddTypeToPicker()
        {
            var typeList = new List<string>();
            typeList.Add("company");
            typeList.Add("accounting");
            typeList.Add("airport");
            typeList.Add("amusement_park");
            typeList.Add("aquarium");
            typeList.Add("art_gallery");
            typeList.Add("atm");
            typeList.Add("bakery");
            typeList.Add("bank");
            typeList.Add("bar");
            typeList.Add("beauty_salon");
            typeList.Add("bicycle_store");
            typeList.Add("book_store");
            typeList.Add("bowling_alley");
            typeList.Add("bus_station");
            typeList.Add("cafe");
            typeList.Add("campground");
            typeList.Add("car_dealer");
            typeList.Add("car_rental");
            typeList.Add("car_repair");
            typeList.Add("car_wash");
            typeList.Add("casino");
            typeList.Add("cemetery");
            typeList.Add("church");
            typeList.Add("city_hall");
            typeList.Add("clothing_store");
            typeList.Add("convenience_store");
            typeList.Add("courthouse");
            typeList.Add("dentist");
            typeList.Add("department_store");
            typeList.Add("doctor");
            typeList.Add("electrician");
            typeList.Add("electronics_store");
            typeList.Add("embassy");
            typeList.Add("fire_station");
            typeList.Add("florist");
            typeList.Add("funeral_home");
            typeList.Add("furniture_store");
            typeList.Add("gas_station");
            typeList.Add("gym");
            typeList.Add("hair_care");
            typeList.Add("hardware_store");
            typeList.Add("hindu_temple");
            typeList.Add("home_goods_store");
            typeList.Add("hospital");
            typeList.Add("insurance_agency");
            typeList.Add("jewelry_store");
            typeList.Add("laundry");
            typeList.Add("lawyer");
            typeList.Add("library");
            typeList.Add("liquor_store");
            typeList.Add("local_government_office");
            typeList.Add("locksmith");
            typeList.Add("lodging");
            typeList.Add("meal_delivery");
            typeList.Add("meal_takeaway");
            typeList.Add("mosque");
            typeList.Add("movie_rental");
            typeList.Add("movie_theater");
            typeList.Add("moving_company");
            typeList.Add("museum");
            typeList.Add("night_club");
            typeList.Add("painter");
            typeList.Add("park");
            typeList.Add("parking");
            typeList.Add("pet_store");
            typeList.Add("pharmacy");
            typeList.Add("physiotherapist");
            typeList.Add("plumber");
            typeList.Add("police");
            typeList.Add("post_office");
            typeList.Add("real_estate_agency");
            typeList.Add("restaurant");
            typeList.Add("roofing_contractor");
            typeList.Add("rv_park");
            typeList.Add("school");
            typeList.Add("shoe_store");
            typeList.Add("shopping_mall");
            typeList.Add("spa");
            typeList.Add("stadium");
            typeList.Add("storage");
            typeList.Add("store");
            typeList.Add("subway_station");
            typeList.Add("supermarket");
            typeList.Add("synagogue");
            typeList.Add("taxi_stand");
            typeList.Add("train_station");
            typeList.Add("transit_station");
            typeList.Add("travel_agency");
            typeList.Add("veterinary_care");
            typeList.Add("zoo");
            picker.ItemsSource = typeList;
            picker.SelectedItem = "company";
            picker.Title = "company";
        }
        private void ListViewResult_OnItemSelected(object sender, EventArgs e)
        {

        }

    }
}