using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace APWeather.Models
{
    public partial class ViewDayFlight
    {
        public DateTime Date { get; set; }
        public int CrewId { get; set; }
        public int? Duration { get; set; }
        public int? DurationLocal { get; set; }
        public int? FLT28 { get; set; }
        public int? FLT28Local { get; set; }
        public int FLTYear { get; set; }
        public int FLTCYear { get; set; }
    }
}
