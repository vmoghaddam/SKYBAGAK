using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace APWeather.Models
{
    public partial class AircraftType
    {
        public AircraftType()
        {
            AircraftModel = new HashSet<AircraftModel>();
            BookRelatedAircraftType = new HashSet<BookRelatedAircraftType>();
            CaoType = new HashSet<CaoType>();
            Course = new HashSet<Course>();
            CourseAircraftType = new HashSet<CourseAircraftType>();
            CourseRelatedAircraftType = new HashSet<CourseRelatedAircraftType>();
            FlightInformation = new HashSet<FlightInformation>();
            FlightPlanItem = new HashSet<FlightPlanItem>();
            PersonAircraftType = new HashSet<PersonAircraftType>();
            PersonRating = new HashSet<PersonRating>();
        }

        public int Id { get; set; }
        public string Type { get; set; }
        public int ManufacturerId { get; set; }
        public string Remark { get; set; }

        public virtual Organization Manufacturer { get; set; }
        public virtual ICollection<AircraftModel> AircraftModel { get; set; }
        public virtual ICollection<BookRelatedAircraftType> BookRelatedAircraftType { get; set; }
        public virtual ICollection<CaoType> CaoType { get; set; }
        public virtual ICollection<Course> Course { get; set; }
        public virtual ICollection<CourseAircraftType> CourseAircraftType { get; set; }
        public virtual ICollection<CourseRelatedAircraftType> CourseRelatedAircraftType { get; set; }
        public virtual ICollection<FlightInformation> FlightInformation { get; set; }
        public virtual ICollection<FlightPlanItem> FlightPlanItem { get; set; }
        public virtual ICollection<PersonAircraftType> PersonAircraftType { get; set; }
        public virtual ICollection<PersonRating> PersonRating { get; set; }
    }
}
