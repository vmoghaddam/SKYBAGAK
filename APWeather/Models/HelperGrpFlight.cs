using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace APWeather.Models
{
    public partial class HelperGrpFlight
    {
        public int PYear { get; set; }
        public string PMonthName { get; set; }
        public int Pmonth { get; set; }
        public int? FlightCount { get; set; }
        public int PreFlightCount { get; set; }
        public int? BlockTime { get; set; }
        public int PreBlockTime { get; set; }
        public int? FlightTime { get; set; }
        public int PreFlightTime { get; set; }
        public int? TotalPax { get; set; }
        public int PreTotalPax { get; set; }
        public int? TotalPaxAll { get; set; }
        public int PreTotalPaxAll { get; set; }
    }
}
