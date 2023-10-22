using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace APWeather.Models
{
    public partial class ViewRoute
    {
        public int Id { get; set; }
        public int FromAirport { get; set; }
        public string FromAirportIATA { get; set; }
        public int ToAirport { get; set; }
        public string ToAirportIATA { get; set; }
        public string Route { get; set; }
        public int? FlightH { get; set; }
        public int? FlightM { get; set; }
    }
}
