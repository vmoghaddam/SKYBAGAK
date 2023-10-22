using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace APWeather.Models
{
    public partial class ViewBoxCrewRequirement
    {
        public int? TypeId { get; set; }
        public int Id { get; set; }
        public int FlightPlanId { get; set; }
        public DateTime? Date { get; set; }
        public int? CalanderId { get; set; }
        public int JobGroupId { get; set; }
        public int Min { get; set; }
        public int? Assigned { get; set; }
    }
}
