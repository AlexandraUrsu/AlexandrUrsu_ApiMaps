using AlexandrUrsu_ApiMaps.Data;
using System;
using System.IO;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace AlexandrUrsu_ApiMaps
{
    public partial class App : Application
    {
        static FavoriteDB database;

        public static FavoriteDB Database
        {
            get
            {
                if (database == null)
                {
                    database = new
                   FavoriteDB(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.
                   LocalApplicationData), "Favorite.db3"));
                }
                return database;
            }
        }
        public App()
        {
            InitializeComponent();
            MainPage = new MainPage();
            
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
