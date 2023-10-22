using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace APWeather.Models
{
    public partial class Box
    {
        public Box()
        {
            BoxCrew = new HashSet<BoxCrew>();
            BoxFlightPlanItem = new HashSet<BoxFlightPlanItem>();
            BoxItem = new HashSet<BoxItem>();
            FDP = new HashSet<FDP>();
            FlightInformation = new HashSet<FlightInformation>();
            FlightPlanCalanderCrew = new HashSet<FlightPlanCalanderCrew>();
            FlightPlanItem = new HashSet<FlightPlanItem>();
        }

        public int Id { get; set; }
        public int FlightPlanId { get; set; }
        public DateTime? STD { get; set; }
        public DateTime? STA { get; set; }
        public int? FromAirportId { get; set; }
        public int? ToAirportId { get; set; }
        public DateTime? Date { get; set; }
        public int? CalanderId { get; set; }
        public DateTime? DelayedReport { get; set; }
        public DateTime? NextNotification { get; set; }
        public DateTime? FirstNotification { get; set; }
        public int? DelayAmount { get; set; }
        public DateTime? ReportingTime { get; set; }
        public DateTime? DelayedReportingTime { get; set; }
        public DateTime? RevisedDelayedReportingTime { get; set; }

        public virtual ICollection<BoxCrew> BoxCrew { get; set; }
        public virtual ICollection<BoxFlightPlanItem> BoxFlightPlanItem { get; set; }
        public virtual ICollection<BoxItem> BoxItem { get; set; }
        public virtual ICollection<FDP> FDP { get; set; }
        public virtual ICollection<FlightInformation> FlightInformation { get; set; }
        public virtual ICollection<FlightPlanCalanderCrew> FlightPlanCalanderCrew { get; set; }
        public virtual ICollection<FlightPlanItem> FlightPlanItem { get; set; }
    }
}
