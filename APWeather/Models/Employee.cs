using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace APWeather.Models
{
    public partial class Employee
    {
        public Employee()
        {
            BookRelatedEmployee = new HashSet<BookRelatedEmployee>();
            BoxCrew = new HashSet<BoxCrew>();
            CourseRelatedEmployee = new HashSet<CourseRelatedEmployee>();
            CourseSessionFDP = new HashSet<CourseSessionFDP>();
            EFBDSPRelease = new HashSet<EFBDSPRelease>();
            EmployeeBookStatus = new HashSet<EmployeeBookStatus>();
            EmployeeLocation = new HashSet<EmployeeLocation>();
            FDP = new HashSet<FDP>();
            FlightCrew = new HashSet<FlightCrew>();
            FlightGroup = new HashSet<FlightGroup>();
            FlightPlanCalanderCrew = new HashSet<FlightPlanCalanderCrew>();
            FlightPlanStatus = new HashSet<FlightPlanStatus>();
        }

        public int Id { get; set; }
        public string PID { get; set; }
        public string Phone { get; set; }
        public int? CurrentLocationAirport { get; set; }
        public int? BaseAirportId { get; set; }
        public DateTime? DateInactiveBegin { get; set; }
        public DateTime? DateInactiveEnd { get; set; }
        public double? FlightSum { get; set; }
        public int? FlightEarly { get; set; }
        public int? FlightLate { get; set; }
        public bool? InActive { get; set; }

        public virtual Airport BaseAirport { get; set; }
        public virtual Airport CurrentLocationAirportNavigation { get; set; }
        public virtual PersonCustomer IdNavigation { get; set; }
        public virtual ICollection<BookRelatedEmployee> BookRelatedEmployee { get; set; }
        public virtual ICollection<BoxCrew> BoxCrew { get; set; }
        public virtual ICollection<CourseRelatedEmployee> CourseRelatedEmployee { get; set; }
        public virtual ICollection<CourseSessionFDP> CourseSessionFDP { get; set; }
        public virtual ICollection<EFBDSPRelease> EFBDSPRelease { get; set; }
        public virtual ICollection<EmployeeBookStatus> EmployeeBookStatus { get; set; }
        public virtual ICollection<EmployeeLocation> EmployeeLocation { get; set; }
        public virtual ICollection<FDP> FDP { get; set; }
        public virtual ICollection<FlightCrew> FlightCrew { get; set; }
        public virtual ICollection<FlightGroup> FlightGroup { get; set; }
        public virtual ICollection<FlightPlanCalanderCrew> FlightPlanCalanderCrew { get; set; }
        public virtual ICollection<FlightPlanStatus> FlightPlanStatus { get; set; }
    }
}
