using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace APWeather.Models
{
    public partial class HelperLayOver
    {
        public int? CrewId { get; set; }
        public string Name { get; set; }
        public string ScheduleName { get; set; }
        public string FlightNumber { get; set; }
        public DateTime? STDDayLocal { get; set; }
        public DateTime? STADayLocal { get; set; }
        public DateTime? STALocal { get; set; }
        public string ToAirportIATA { get; set; }
        public int? ToAirport { get; set; }
        public int? BaseAirportId { get; set; }
        public long? DateRank { get; set; }
    }
}
