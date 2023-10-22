using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace APWeather.Models
{
    public partial class Airport
    {
        public Airport()
        {
            CateringItem = new HashSet<CateringItem>();
            EmployeeBaseAirport = new HashSet<Employee>();
            EmployeeCurrentLocationAirportNavigation = new HashSet<Employee>();
            FlightInformationFromAirport = new HashSet<FlightInformation>();
            FlightInformationToAirport = new HashSet<FlightInformation>();
            FlightPlanItemFromAirportNavigation = new HashSet<FlightPlanItem>();
            FlightPlanItemToAirportNavigation = new HashSet<FlightPlanItem>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public string IATA { get; set; }
        public string ICAO { get; set; }
        public int? CityId { get; set; }
        public string ImportId { get; set; }
        public string Type { get; set; }
        public decimal? Latitude { get; set; }
        public decimal? Longitude { get; set; }
        public int? SortIndex { get; set; }
        public bool? IsInt { get; set; }

        public virtual City City { get; set; }
        public virtual ICollection<CateringItem> CateringItem { get; set; }
        public virtual ICollection<Employee> EmployeeBaseAirport { get; set; }
        public virtual ICollection<Employee> EmployeeCurrentLocationAirportNavigation { get; set; }
        public virtual ICollection<FlightInformation> FlightInformationFromAirport { get; set; }
        public virtual ICollection<FlightInformation> FlightInformationToAirport { get; set; }
        public virtual ICollection<FlightPlanItem> FlightPlanItemFromAirportNavigation { get; set; }
        public virtual ICollection<FlightPlanItem> FlightPlanItemToAirportNavigation { get; set; }
    }
}
