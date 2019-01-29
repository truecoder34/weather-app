using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WeatherApp.Models;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using WeatherApp.Controllers;

namespace WeatherApp
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class WeatherPage : ContentPage
	{
		public WeatherPage()
		{
			InitializeComponent();
            this.Title = "Weather App";
            getWeatherBtn.Clicked += GetWeatherBtn_Clicked;

            // Basic objec binding
            this.BindingContext = new Weather();
        }

        private async void GetWeatherBtn_Clicked(object sender, EventArgs e)
        {
            Weather weather = await WeatherController.GetWeather("60601");
            getWeatherBtn.Text = weather.Title;
        }
	}
}