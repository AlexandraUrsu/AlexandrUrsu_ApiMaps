using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace AlexandrUrsu_ApiMaps
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
  
        }

        private void OnApiButtonClicked(object sender, EventArgs e)
        {
            Navigation.PushModalAsync(new MapsApi(46.770439, 23.591423));
        }
        private void OnFavoriteClicked(object sender, EventArgs e)
        {
            Navigation.PushModalAsync(new ListFavorite());
        }

        private void OnNewPlacesButtonClicked(object sender, EventArgs e)
        {
            Navigation.PushModalAsync(new PlaceApi());
        }
    }
}
