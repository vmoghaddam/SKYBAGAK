using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace APWeather.Models
{
    public partial class _XFDPITEM
    {
        public int Id { get; set; }
        public string FDP { get; set; }
        public string Leg { get; set; }
        public DateTime? STD { get; set; }
        public int? FlightId { get; set; }
        public int? CrewId { get; set; }
        public int? FDPId { get; set; }
        public int? XFDPId { get; set; }
        public string UPD { get; set; }
        public int? Pos { get; set; }
        public int? RosterIndex { get; set; }
    }
}
