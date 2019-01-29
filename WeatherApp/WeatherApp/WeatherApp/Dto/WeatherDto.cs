using System;
using System.Collections.Generic;
using System.Text;
using WeatherApp.Dto;

namespace WeatherApp.Dto
{
    public class WeatherDto
    {
        public string name;
        public WeatherMainDto main;
        public WeatherWindDto wind;
        public WeatherSysDto sys;
        public List<WeatherWeatherDto> weather;
    }
}
