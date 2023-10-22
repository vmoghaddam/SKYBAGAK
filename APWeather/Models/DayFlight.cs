using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace APWeather.Models
{
    public partial class DayFlight
    {
        public DateTime Date { get; set; }
        public int CrewId { get; set; }
        public int Id { get; set; }
        public double? FLTLocal { get; set; }
        public double? FLT { get; set; }
        public double? FLT28Local { get; set; }
        public double? FLT28 { get; set; }
        public double? FLTYear { get; set; }
        public double? FLTYearLocal { get; set; }
        public double? FLTCYear { get; set; }
        public double? FLTCYearLocal { get; set; }
        public double? DH { get; set; }
        public double? DHLocal { get; set; }
        public double? DH28 { get; set; }
        public double? DH28Local { get; set; }
        public double? DHYear { get; set; }
        public double? DHYearLocal { get; set; }
        public double? DHCYear { get; set; }
        public double? DHCYearLocal { get; set; }
        public int? Year { get; set; }
    }
}
