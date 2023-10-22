using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace APWeather.Models
{
    public partial class RosterCrewSheet
    {
        public int Id { get; set; }
        public int FlightId { get; set; }
        public int CrewId { get; set; }
        public bool DH { get; set; }
        public int PositionId { get; set; }
        public int? FDPItemId { get; set; }

        public virtual FDPItem FDPItem { get; set; }
    }
}
