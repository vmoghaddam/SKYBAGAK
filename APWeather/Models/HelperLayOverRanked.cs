using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace APWeather.Models
{
    public partial class HelperLayOverRanked
    {
        public int? CrewId { get; set; }
        public string ScheduleName { get; set; }
        public string FlightNumber { get; set; }
        public int? BaseAirportId { get; set; }
        public DateTime? STADay { get; set; }
        public DateTime? STADayLag { get; set; }
        public string DestinationIATA { get; set; }
        public string DestinationIATALag { get; set; }
        public int? Destination { get; set; }
        public int? DestinationLag { get; set; }
    }
}
