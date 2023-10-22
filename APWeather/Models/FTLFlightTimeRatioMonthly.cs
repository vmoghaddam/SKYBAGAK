using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace APWeather.Models
{
    public partial class FTLFlightTimeRatioMonthly
    {
        public int CrewId { get; set; }
        public int Year { get; set; }
        public int Month { get; set; }
        public int? ScheduledFlightTime { get; set; }
        public int? CNT { get; set; }
        public decimal? Ratio { get; set; }
    }
}
