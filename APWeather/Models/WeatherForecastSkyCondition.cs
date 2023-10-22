using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace APWeather.Models
{
    public partial class WeatherForecastSkyCondition
    {
        public int Id { get; set; }
        public int forecast_id { get; set; }
        public string sky_cover { get; set; }
        public double? cloud_base_ft_agl { get; set; }
        public string cloud_type { get; set; }

        public virtual WeatherTafForecast forecast_ { get; set; }
    }
}
