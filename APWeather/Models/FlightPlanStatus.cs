using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace APWeather.Models
{
    public partial class FlightPlanStatus
    {
        public int Id { get; set; }
        public int FlighPlanId { get; set; }
        public int? ApproverId { get; set; }
        public DateTime DateApproved { get; set; }
        public int ApproveTypeId { get; set; }
        public string Remark { get; set; }

        public virtual Employee Approver { get; set; }
        public virtual FlightPlan FlighPlan { get; set; }
    }
}
