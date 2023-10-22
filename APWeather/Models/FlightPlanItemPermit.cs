using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace APWeather.Models
{
    public partial class FlightPlanItemPermit
    {
        public int Id { get; set; }
        public int FlightPlanId { get; set; }
        public int PermitId { get; set; }
        public DateTime? Date { get; set; }
        public string Remark { get; set; }
        public DateTime? DateFlight { get; set; }
        public int? CalanderId { get; set; }

        public virtual FlightPlanItem FlightPlan { get; set; }
        public virtual FlightPermit Permit { get; set; }
    }
}
