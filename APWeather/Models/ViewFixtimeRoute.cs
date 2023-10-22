using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace APWeather.Models
{
    public partial class ViewFixtimeRoute
    {
        public string Route { get; set; }
        public int? FixtTime { get; set; }
        public TimeSpan FixTime2 { get; set; }
        public int? Hour { get; set; }
        public int? Minute { get; set; }
    }
}
