using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace APWeather.Models
{
    public partial class ViewDayDuty
    {
        public DateTime Date { get; set; }
        public int CrewId { get; set; }
        public double? Duration { get; set; }
        public double? DurationLocal { get; set; }
        public double? Duty7 { get; set; }
        public double? Duty7Local { get; set; }
        public double? Duty14 { get; set; }
        public double? Duty14Local { get; set; }
        public double? Duty28 { get; set; }
        public double? Duty28Local { get; set; }
    }
}
