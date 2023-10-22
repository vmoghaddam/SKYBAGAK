using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace APWeather.Models
{
    public partial class GrpFlightCal
    {
        public int Year { get; set; }
        public string MonthName { get; set; }
        public int Month { get; set; }
        public int PYear { get; set; }
        public string PMonthName { get; set; }
        public int PMonth { get; set; }
        public int? FlightCount { get; set; }
        public int PreFlightCount { get; set; }
        public decimal? FlightCountDiff { get; set; }
        public int? BlockTime { get; set; }
        public int PreBlockTime { get; set; }
        public decimal? BlockTimeDiff { get; set; }
        public int? FlightTime { get; set; }
        public int PreFlightTime { get; set; }
        public decimal? FlightTimeDiff { get; set; }
        public int? TotalPax { get; set; }
        public int PreTotalPax { get; set; }
        public decimal? TotalPaxDiff { get; set; }
        public int? TotalPaxAll { get; set; }
        public int PreTotalPaxAll { get; set; }
        public decimal? TotalPaxAllDiff { get; set; }
    }
}
