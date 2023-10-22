using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace APWeather.Models
{
    public partial class WeatherForecastTemperature
    {
        public int Id { get; set; }
        public int forecast_id { get; set; }
        public DateTime? valid_time { get; set; }
        public double? sfc_temp_c { get; set; }
        public string max_temp_c { get; set; }
        public string min_temp_c { get; set; }

        public virtual WeatherTafForecast forecast_ { get; set; }
    }
}
