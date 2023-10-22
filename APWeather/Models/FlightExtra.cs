using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace APWeather.Models
{
    public partial class FlightExtra
    {
        public int Id { get; set; }
        public int? CrewId { get; set; }
        public string FlightNumber { get; set; }
        public DateTime? STALocal { get; set; }
        public DateTime? STDLocal { get; set; }
        public string FromAirportIATA { get; set; }
        public string ToAirportIATA { get; set; }
        public int? ToAirport { get; set; }
        public int? FromAirport { get; set; }
        public string Airline { get; set; }
        public DateTime? STD { get; set; }
        public DateTime? STA { get; set; }
        public string Remark { get; set; }
    }
}
