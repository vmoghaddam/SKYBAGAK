using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace APWeather.Models
{
    public partial class FlightCrewChangeHistory
    {
        public int Id { get; set; }
        public int FlightCrewId { get; set; }
        public int ReasonId { get; set; }
        public DateTime DateChange { get; set; }
        public int? UserId { get; set; }
        public int? NewEmployeeId { get; set; }
        public int? NewGroupId { get; set; }
        public string Remark { get; set; }
    }
}
