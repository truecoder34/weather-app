using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using WeatherApp.Dto;
using WeatherApp.Models;
using WeatherApp.Servicies;

namespace WeatherApp.Controllers
{
    public class WeatherController
    {
        public static async Task<Weather> GetWeather(string zipCode)
        {
            // Sign up for api key of weather servic 
            string key = "69a500462ccf842f83f73c5b880a73d7"; // Problems with gettin key - only by VPN
            string queryString = "http://api.openweathermap.org/data/2.5/weather?zip="
                + zipCode + ",us&appid=" + key + "&units=imperial";

            WeatherDto results = await DataService.getWeatherDataFromService(queryString).ConfigureAwait(false);

            if (results != null)
            {
                Weather weather = new Weather();
                weather.Title = results.name;
                weather.Temperature = results.main.temp + " F";
                weather.Wind = results.wind.speed + " mph";
                weather.Humidity = results.main.humidity + " %";
                weather.Visibility = results.weather[0].main;

                DateTime time = new System.DateTime(1970, 1, 1, 0, 0, 0, 0);
                DateTime sunrise = time.AddSeconds(Convert.ToDouble(results.sys.sunrise));
                DateTime sunset = time.AddSeconds(Convert.ToDouble(results.sys.sunset));
                weather.Sunrise = sunrise.ToString() + " UTC";
                weather.Sunset = sunset.ToString() + " UTC";

                return weather;
            } 
            else
            {
                return null;
            }
        }
    }
}
