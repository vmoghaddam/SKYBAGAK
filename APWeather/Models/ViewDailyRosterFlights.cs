using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace APWeather.Models
{
    public partial class ViewDailyRosterFlights
    {
        public int Id { get; set; }
        public string FlightNumber { get; set; }
        public DateTime? Departure { get; set; }
        public DateTime? DepartureLocal { get; set; }
        public DateTime? Arrival { get; set; }
        public DateTime? ArrivalLocal { get; set; }
        public int? FromAirport { get; set; }
        public string FromAirportIATA { get; set; }
        public int? ToAirport { get; set; }
        public string ToAirportIATA { get; set; }
        public string Register { get; set; }
        public int? CrewId { get; set; }
        public bool? IsPositioning { get; set; }
        public DateTime? DepartureDate { get; set; }
    }
}
