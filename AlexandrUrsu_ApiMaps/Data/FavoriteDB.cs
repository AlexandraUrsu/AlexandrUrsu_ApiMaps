using AlexandrUrsu_ApiMaps.Models;
using Android.App;
using SQLite;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace AlexandrUrsu_ApiMaps.Data
{
    public class FavoriteDB
    {
        readonly SQLiteAsyncConnection _database;

        public FavoriteDB(string dbPath)
        {
            _database = new SQLiteAsyncConnection(dbPath);
            _database.CreateTableAsync<Favorite>().Wait();
        }

        public Task<List<Favorite>> GetFavoritePlaceAsync()
        {
            return _database.Table<Favorite>().ToListAsync();
        }

        public Task<int> SaveFavoritePlaceAsync(Favorite fav)
        {
            if (fav.ID != 0)
            {
                return _database.UpdateAsync(fav);
            }
            else
            {
                return _database.InsertAsync(fav);
            }
        }

        public Task<int> DeleteFavoritePlaceAsync(Favorite fav)
        {
            return _database.DeleteAsync(fav);
        }

    }
}
