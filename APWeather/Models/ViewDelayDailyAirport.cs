using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace APWeather.Models
{
    public partial class ViewDelayDailyAirport
    {
        public DateTime? Date { get; set; }
        public string DayName { get; set; }
        public string YearName { get; set; }
        public string PDate { get; set; }
        public string PYearName { get; set; }
        public string PMonthName { get; set; }
        public string PDayName { get; set; }
        public string Airport { get; set; }
        public int Delay { get; set; }
        public int Count { get; set; }
        public int? TotalFlights { get; set; }
        public int BlockTime { get; set; }
        public int FlightTime { get; set; }
        public double? DelayLeg { get; set; }
        public double? DelayRatio { get; set; }
        public double? TRND { get; set; }
        public double? TRNDLeg { get; set; }
    }
}
