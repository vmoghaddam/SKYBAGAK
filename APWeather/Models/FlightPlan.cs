using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace APWeather.Models
{
    public partial class FlightPlan
    {
        public FlightPlan()
        {
            FlighPlanCalendar = new HashSet<FlighPlanCalendar>();
            FlightPlanDay = new HashSet<FlightPlanDay>();
            FlightPlanItem = new HashSet<FlightPlanItem>();
            FlightPlanMonth = new HashSet<FlightPlanMonth>();
            FlightPlanRegister = new HashSet<FlightPlanRegister>();
            FlightPlanStatus = new HashSet<FlightPlanStatus>();
        }

        public int Id { get; set; }
        public string Title { get; set; }
        public DateTime? DateFrom { get; set; }
        public DateTime? DateTo { get; set; }
        public int CustomerId { get; set; }
        public bool IsActive { get; set; }
        public DateTime? DateActive { get; set; }
        public int? Interval { get; set; }
        public DateTime? DateFirst { get; set; }
        public DateTime? DateLast { get; set; }
        public int? BaseId { get; set; }

        public virtual Customer Customer { get; set; }
        public virtual ICollection<FlighPlanCalendar> FlighPlanCalendar { get; set; }
        public virtual ICollection<FlightPlanDay> FlightPlanDay { get; set; }
        public virtual ICollection<FlightPlanItem> FlightPlanItem { get; set; }
        public virtual ICollection<FlightPlanMonth> FlightPlanMonth { get; set; }
        public virtual ICollection<FlightPlanRegister> FlightPlanRegister { get; set; }
        public virtual ICollection<FlightPlanStatus> FlightPlanStatus { get; set; }
    }
}
