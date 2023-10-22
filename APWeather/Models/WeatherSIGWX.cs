using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace APWeather.Models
{
    public partial class WeatherSIGWX
    {
        public int Id { get; set; }
        public DateTime? DateCreate { get; set; }
        public string CurrentUrl { get; set; }
        public string PastUrl { get; set; }
        public string Updated { get; set; }
        public string Region { get; set; }
        public string Issued { get; set; }
        public string Product { get; set; }
        public DateTime? DateDay { get; set; }
    }
}
