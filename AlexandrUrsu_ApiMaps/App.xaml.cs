using System;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace AlexandrUrsu_ApiMaps
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();
            MainPage = new TestPage ();
            
        }

        protected override void OnStart()
        {
            
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
