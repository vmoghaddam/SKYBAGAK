using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace APWeather.Models
{
    public partial class ExtIdea
    {
        public string PersonalCode { get; set; }
        public string NID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string CourseCode { get; set; }
        public string CourseTitle { get; set; }
        public string ClassID { get; set; }
        public string Instructor { get; set; }
        public DateTime? BeginDate { get; set; }
        public DateTime? EndDate { get; set; }
        public string Days { get; set; }
        public string Location { get; set; }
        public string City { get; set; }
        public DateTime? Issue { get; set; }
        public DateTime? Expire { get; set; }
    }
}
