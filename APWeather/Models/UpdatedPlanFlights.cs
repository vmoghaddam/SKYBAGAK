using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace APWeather.Models
{
    public partial class UpdatedPlanFlights
    {
        public int Id { get; set; }
        public int? PlanId { get; set; }
        public int? PlanItemId { get; set; }
        public int? FlightId { get; set; }
        public DateTime? Date { get; set; }
        public int? Status { get; set; }
    }
}
