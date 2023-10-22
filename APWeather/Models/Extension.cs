using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace APWeather.Models
{
    public partial class Extension
    {
        public int Id { get; set; }
        public DateTime? DutyStart { get; set; }
        public DateTime? DutyEnd { get; set; }
        public int? Sectors { get; set; }
        public int? MaxFDP { get; set; }
        public TimeSpan? MaxFDPH { get; set; }
    }
}
