using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using System.Net.Http;
using WeatherApp.Models;
using WeatherApp.Dto;

namespace WeatherApp.Servicies
{
    class DataService
    {
        public static async Task <WeatherDto> getWeatherDataFromService(string queryString)
        {
            HttpClient client = new HttpClient();
            var response = await client.GetAsync(queryString);

            WeatherDto data = null;
            if(response != null)
            {
                string json = response.Content.ReadAsStringAsync().Result;
                // Deserialization = converting json to .Net object (WeatherDto type)
                // IF FIELDS R SAME
                data = JsonConvert.DeserializeObject<WeatherDto>(json);
                //data = JsonConvert.DeserializeObject(json); // to dynamic
            }
            return data;
        }


    }
}
