using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace APWeather.Models
{
    public partial class WeatherMetarQualityControl
    {
        public int Id { get; set; }
        public int MetarId { get; set; }
        public string corrected { get; set; }
        public string auto { get; set; }
        public string auto_station { get; set; }
        public string maintenance_indicator_on { get; set; }
        public string no_signal { get; set; }
        public string lightning_sensor_off { get; set; }
        public string freezing_rain_sensor_off { get; set; }
        public string present_weather_sensor_off { get; set; }

        public virtual WeatherMetar Metar { get; set; }
    }
}
