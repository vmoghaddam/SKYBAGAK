using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace APWeather.Models
{
    public partial class WeatherForecastIcingCondition
    {
        public int Id { get; set; }
        public int forecast_id { get; set; }
        public string icing_intensity { get; set; }
        public double? icing_min_alt_ft_agl { get; set; }
        public double? icing_max_alt_ft_agl { get; set; }

        public virtual WeatherTafForecast forecast_ { get; set; }
    }
}
