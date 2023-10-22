using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace APWeather.Models
{
    public partial class FTLFlightTime
    {
        public int FlightId { get; set; }
        public DateTime? STDDay { get; set; }
        public int FDPItemId { get; set; }
        public int FDPId { get; set; }
        public int? ScheduledFlightTime { get; set; }
    }
}
