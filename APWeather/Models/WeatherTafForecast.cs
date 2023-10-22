using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace APWeather.Models
{
    public partial class WeatherTafForecast
    {
        public WeatherTafForecast()
        {
            WeatherForecastIcingCondition = new HashSet<WeatherForecastIcingCondition>();
            WeatherForecastSkyCondition = new HashSet<WeatherForecastSkyCondition>();
            WeatherForecastTemperature = new HashSet<WeatherForecastTemperature>();
            WeatherForecastTurbulence = new HashSet<WeatherForecastTurbulence>();
        }

        public int Id { get; set; }
        public DateTime? fcst_time_from { get; set; }
        public DateTime? fcst_time_to { get; set; }
        public string change_indicator { get; set; }
        public DateTime? time_becoming { get; set; }
        public double? probability { get; set; }
        public double? wind_dir_degrees { get; set; }
        public double? wind_speed_kt { get; set; }
        public double? wind_gust_kt { get; set; }
        public double? wind_shear_hgt_ft_agl { get; set; }
        public double? wind_shear_dir_degrees { get; set; }
        public double? wind_shear_speed_kt { get; set; }
        public double? visibility_statute_mi { get; set; }
        public double? altim_in_hg { get; set; }
        public double? vert_vis_ft { get; set; }
        public string wx_string { get; set; }
        public string not_decoded { get; set; }
        public int weather_id { get; set; }

        public virtual WeatherTaf weather_ { get; set; }
        public virtual ICollection<WeatherForecastIcingCondition> WeatherForecastIcingCondition { get; set; }
        public virtual ICollection<WeatherForecastSkyCondition> WeatherForecastSkyCondition { get; set; }
        public virtual ICollection<WeatherForecastTemperature> WeatherForecastTemperature { get; set; }
        public virtual ICollection<WeatherForecastTurbulence> WeatherForecastTurbulence { get; set; }
    }
}
