using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace APWeather.Models
{
    public partial class ExtensionHistory
    {
        public int Id { get; set; }
        public int FDPId { get; set; }
        public int CrewId { get; set; }
        public int? Extension { get; set; }
        public DateTime? DutyStart { get; set; }
        public int? Sectors { get; set; }
        public string Remark { get; set; }

        public virtual FDP FDP { get; set; }
    }
}
