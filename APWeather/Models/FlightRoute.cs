using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace APWeather.Models
{
    public partial class FlightRoute
    {
        public int Id { get; set; }
        public int AirlineId { get; set; }
        public int SourceAirportId { get; set; }
        public int DestinationAirportId { get; set; }
        public int? Stops { get; set; }
        public string Equipment { get; set; }
        public int? FlightH { get; set; }
        public int? FlightM { get; set; }
        public double? Distance { get; set; }
    }
}
