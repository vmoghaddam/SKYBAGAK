using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace APWeather.Models
{
    public partial class XCrewAssigned
    {
        public string Crew { get; set; }
        public string Name { get; set; }
        public string JobGroup { get; set; }
        public int? groupid { get; set; }
        public int? CrewId { get; set; }
        public string Route { get; set; }
        public string FlightNumber { get; set; }
        public DateTime? DateUTC { get; set; }
        public int? FlightId { get; set; }
    }
}
