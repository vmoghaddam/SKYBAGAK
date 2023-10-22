using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace APWeather.Models
{
    public partial class FlightPlanMonth
    {
        public int FlightPlanId { get; set; }
        public int Month { get; set; }

        public virtual FlightPlan FlightPlan { get; set; }
    }
}
