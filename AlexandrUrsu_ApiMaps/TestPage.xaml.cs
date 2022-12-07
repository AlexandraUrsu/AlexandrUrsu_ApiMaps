using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace AlexandrUrsu_ApiMaps
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class TestPage : ContentPage
    {
        public TestPage()
        {
            InitializeComponent();
        }
        private void OnApiButtonClicked(object sender, EventArgs e)
        {
            Navigation.PushModalAsync(new MapsApi());
        }

        
    }
}