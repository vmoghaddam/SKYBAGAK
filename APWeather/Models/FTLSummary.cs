using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace APWeather.Models
{
    public partial class FTLSummary
    {
        public DateTime CDate { get; set; }
        public int CrewId { get; set; }
        public double? Duty7 { get; set; }
        public double? Duty14 { get; set; }
        public double? Duty28 { get; set; }
        public double? Flight28 { get; set; }
        public double? FlightYear { get; set; }
        public double? FlightCYear { get; set; }
    }
}
