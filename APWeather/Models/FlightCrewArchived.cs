using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace APWeather.Models
{
    public partial class FlightCrewArchived
    {
        public int Id { get; set; }
        public int? FlightId { get; set; }
        public int? CrewId { get; set; }
        public string Position { get; set; }
        public string Route { get; set; }
        public DateTime? Date { get; set; }
        public string FlightNo { get; set; }
        public int? PositionIndex { get; set; }
        public int? JobGroupId { get; set; }
        public string JobGroupType { get; set; }

        public virtual FlightInformation Flight { get; set; }
    }
}
