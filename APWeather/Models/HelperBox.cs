using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace APWeather.Models
{
    public partial class HelperBox
    {
        public int Id { get; set; }
        public DateTime? DelayedReport { get; set; }
        public int? DelayAmount { get; set; }
        public DateTime? DefaultStart { get; set; }
        public DateTime? DefaultEnd { get; set; }
        public int? Sector { get; set; }
        public int? MaxFDPByReportingTime { get; set; }
        public double? MaxFDP { get; set; }
        public int? CalanderId { get; set; }
    }
}
