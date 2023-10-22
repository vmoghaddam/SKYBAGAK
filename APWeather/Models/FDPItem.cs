using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace APWeather.Models
{
    public partial class FDPItem
    {
        public FDPItem()
        {
            RosterCrewSheet = new HashSet<RosterCrewSheet>();
        }

        public int Id { get; set; }
        public int FDPId { get; set; }
        public int? FlightId { get; set; }
        public bool IsSector { get; set; }
        public int? SplitDutyPairId { get; set; }
        public bool? SplitDuty { get; set; }
        public bool? IsPositioning { get; set; }
        public bool? IsOff { get; set; }
        public int? PositionId { get; set; }
        public int? RosterPositionId { get; set; }
        public DateTime? Pickup { get; set; }
        public string Remark { get; set; }

        public virtual FDP FDP { get; set; }
        public virtual FlightInformation Flight { get; set; }
        public virtual ICollection<RosterCrewSheet> RosterCrewSheet { get; set; }
    }
}
