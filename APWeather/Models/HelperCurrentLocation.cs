using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace APWeather.Models
{
    public partial class HelperCurrentLocation
    {
        public int FDPItemId { get; set; }
        public int FDPId { get; set; }
        public int FlightId { get; set; }
        public int? CrewId { get; set; }
        public int? FromAirport { get; set; }
        public int? ToAirport { get; set; }
        public string FromAirportIATA { get; set; }
        public string ToAirportIATA { get; set; }
        public DateTime? STD { get; set; }
        public DateTime? STA { get; set; }
        public int? FlightStatusID { get; set; }
        public long? Rank { get; set; }
    }
}
