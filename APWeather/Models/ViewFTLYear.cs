using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace APWeather.Models
{
    public partial class ViewFTLYear
    {
        public DateTime Date { get; set; }
        public int CrewId { get; set; }
        public double? Duty1Local { get; set; }
        public double? Duty7Local { get; set; }
        public double? Duty14Local { get; set; }
        public double? Duty28Local { get; set; }
        public int? Flight1Local { get; set; }
        public int? Flight28Local { get; set; }
        public int? FlightYearLocal { get; set; }
    }
}
