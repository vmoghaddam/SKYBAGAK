using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace APWeather.Models
{
    public partial class WeatherMetarSkyCondition
    {
        public int Id { get; set; }
        public int MetarId { get; set; }
        public string sky_cover { get; set; }
        public int? cloud_base_ft_agl { get; set; }

        public virtual WeatherMetar Metar { get; set; }
    }
}
