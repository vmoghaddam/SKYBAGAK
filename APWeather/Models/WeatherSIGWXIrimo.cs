using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace APWeather.Models
{
    public partial class WeatherSIGWXIrimo
    {
        public int Id { get; set; }
        public string Level { get; set; }
        public string Valid { get; set; }
        public int? Size { get; set; }
        public DateTime? DateCreate { get; set; }
        public string Title { get; set; }
        public DateTime? DateDay { get; set; }
    }
}
