using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using MVVM_Weather_App.Model;
using Newtonsoft.Json;

namespace MVVM_Weather_App.ViewModel.Helpers
{
    public class AccuWeatherHelper
    {
        public const string BaseUrl = "http://dataservice.accuweather.com/";
        public const string AutocompleteEndpoint = "locations/v1/cities/autocomplete?apikey={0}&q={1}";
        public const string CurrentConditionsEndpoint = "currentconditions/v1/{0}?apikey{1}";
        public const string ApiKey = "XSfHZJ1iLjNfBEtBGdU2kqLNygGOiq7G";

        public static async Task<List<City>> GetCities(string query)
        {
            List<City> cities;
            string url = BaseUrl + string.Format(AutocompleteEndpoint, ApiKey, query);

            using (HttpClient client = new HttpClient())
            {
                var response = await client.GetAsync(url);
                string json = await response.Content.ReadAsStringAsync();

                cities = JsonConvert.DeserializeObject<List<City>>(json);
            }
            
            return cities;
        }

        public static async Task<CurrentConditions> GetCurrentConditions(string cityKey)
        {
            CurrentConditions currentConditions;
            string url = BaseUrl + string.Format(CurrentConditionsEndpoint, cityKey, ApiKey);

            using (HttpClient client = new HttpClient())
            {
                var response = await client.GetAsync(url);
                string json = await response.Content.ReadAsStringAsync();

                currentConditions = (JsonConvert.DeserializeObject<List<CurrentConditions>>(json)).FirstOrDefault();
            }

            return currentConditions;
        }
    }
}