using AlexandrUrsu_ApiMaps.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace AlexandrUrsu_ApiMaps.RestClient
{
   public class RestClient<Place>
    {
        public async Task<Place> GetAsync(string WebServiceUrl)
        {
            try
            {
                var httpClient = new HttpClient();
                
                var json = await httpClient.GetStringAsync(WebServiceUrl);
                var taskModels = JsonConvert.DeserializeObject<Place>(json);

                return taskModels;
            }
            catch (Exception e)
            {
                Debug.WriteLine("GetAsync error: " + e.Message);
                return default(Place);
            }

        }
    }
}
