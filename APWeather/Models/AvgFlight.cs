using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace APWeather.Models
{
    public partial class AvgFlight
    {
        public int FromAirport { get; set; }
        public int ToAirport { get; set; }
        public decimal? Duration { get; set; }
        public decimal? FlightH { get; set; }
        public decimal? FlightM { get; set; }
    }
}
