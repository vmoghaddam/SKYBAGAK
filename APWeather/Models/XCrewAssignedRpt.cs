using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace APWeather.Models
{
    public partial class XCrewAssignedRpt
    {
        public string SCH { get; set; }
        public string CODE { get; set; }
        public string PDATE { get; set; }
        public DateTime? DATE { get; set; }
        public string FN { get; set; }
        public int? FlightId { get; set; }
        public int? CrewId2 { get; set; }
        public string Name { get; set; }
        public string JobGroup { get; set; }
        public int? groupid { get; set; }
    }
}
