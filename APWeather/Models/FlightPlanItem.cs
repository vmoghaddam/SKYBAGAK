using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace APWeather.Models
{
    public partial class FlightPlanItem
    {
        public FlightPlanItem()
        {
            BoxItem = new HashSet<BoxItem>();
            FlightInformation = new HashSet<FlightInformation>();
            FlightPlanCalanderCrew = new HashSet<FlightPlanCalanderCrew>();
            FlightPlanGroup = new HashSet<FlightPlanGroup>();
            FlightPlanItemPermit = new HashSet<FlightPlanItemPermit>();
        }

        public int Id { get; set; }
        public int FlightPlanId { get; set; }
        public int? TypeId { get; set; }
        public int? RegisterID { get; set; }
        public int? FlightTypeID { get; set; }
        public int? AirlineOperatorsID { get; set; }
        public string FlightNumber { get; set; }
        public int FromAirport { get; set; }
        public int ToAirport { get; set; }
        public DateTime? STD { get; set; }
        public DateTime? STA { get; set; }
        public int FlightH { get; set; }
        public int FlightM { get; set; }
        public string Unknown { get; set; }
        public int? StatusId { get; set; }
        public int? RouteId { get; set; }
        public int? BoxId { get; set; }
        public string DepartureRemark { get; set; }

        public virtual Organization AirlineOperators { get; set; }
        public virtual Box Box { get; set; }
        public virtual FlightPlan FlightPlan { get; set; }
        public virtual Airport FromAirportNavigation { get; set; }
        public virtual Ac_MSN Register { get; set; }
        public virtual Airport ToAirportNavigation { get; set; }
        public virtual AircraftType Type { get; set; }
        public virtual ICollection<BoxItem> BoxItem { get; set; }
        public virtual ICollection<FlightInformation> FlightInformation { get; set; }
        public virtual ICollection<FlightPlanCalanderCrew> FlightPlanCalanderCrew { get; set; }
        public virtual ICollection<FlightPlanGroup> FlightPlanGroup { get; set; }
        public virtual ICollection<FlightPlanItemPermit> FlightPlanItemPermit { get; set; }
    }
}
