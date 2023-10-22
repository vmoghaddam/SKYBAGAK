using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace APWeather.Models
{
    public partial class FlighPlanCalendar
    {
        public FlighPlanCalendar()
        {
            FlightPlanCalanderCrew = new HashSet<FlightPlanCalanderCrew>();
        }

        public int Id { get; set; }
        public int FlightPlanId { get; set; }
        public DateTime? Date { get; set; }

        public virtual FlightPlan FlightPlan { get; set; }
        public virtual ICollection<FlightPlanCalanderCrew> FlightPlanCalanderCrew { get; set; }
    }
}
