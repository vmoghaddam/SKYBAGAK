using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace APWeather.Models
{
    public partial class FlightCrew
    {
        public int Id { get; set; }
        public int FlightInformationId { get; set; }
        public int? Status { get; set; }
        public string Remark { get; set; }
        public DateTime? CreateDate { get; set; }
        public int? EmployeeId { get; set; }
        public int? GroupId { get; set; }
        public int? FlightPlanCrewId { get; set; }

        public virtual Employee Employee { get; set; }
        public virtual FlightInformation FlightInformation { get; set; }
        public virtual FlightPlanCalanderCrew FlightPlanCrew { get; set; }
    }
}
