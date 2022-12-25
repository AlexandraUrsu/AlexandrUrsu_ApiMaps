using AlexandrUrsu_ApiMaps.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Net.Http;
using System.Net.Http.Headers;
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

        public async Task<bool> PostAsync(Place place, string WebServiceUrl)
        {
            var httpClient = new HttpClient();

            var json = JsonConvert.SerializeObject(place);

            HttpContent httpContent = new StringContent(json);

            httpContent.Headers.ContentType = new MediaTypeHeaderValue("application/json");

            var result = await httpClient.PostAsync(WebServiceUrl, httpContent);

            return result.IsSuccessStatusCode;
        }

        public async Task<bool> PutAsync(int id, Place place, string WebServiceUrl)
        {
            var httpClient = new HttpClient();

            var json = JsonConvert.SerializeObject(place);

            HttpContent httpContent = new StringContent(json);

            httpContent.Headers.ContentType = new MediaTypeHeaderValue("application/json");

            var result = await httpClient.PutAsync(WebServiceUrl + id, httpContent);

            return result.IsSuccessStatusCode;
        }

        public async Task<bool> DeleteAsync(int id, Place place, string WebServiceUrl)
        {
            var httpClient = new HttpClient();

            var response = await httpClient.DeleteAsync(WebServiceUrl + id);

            return response.IsSuccessStatusCode;
        }
    }
}
