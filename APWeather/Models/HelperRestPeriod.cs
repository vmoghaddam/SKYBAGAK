using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace APWeather.Models
{
    public partial class HelperRestPeriod
    {
        public int? CrewId { get; set; }
        public DateTime? RestFrom { get; set; }
        public DateTime? RestUntil { get; set; }
        public DateTime? RestFromLocal { get; set; }
        public DateTime? RestUntilLocal { get; set; }
        public int FDPId { get; set; }
    }
}
