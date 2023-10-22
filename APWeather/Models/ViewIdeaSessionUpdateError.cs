using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace APWeather.Models
{
    public partial class ViewIdeaSessionUpdateError
    {
        public int Id { get; set; }
        public int? SessionItemId { get; set; }
        public int? FDPId { get; set; }
        public int? EmployeeId { get; set; }
        public string Name { get; set; }
        public string Route { get; set; }
        public string Flights { get; set; }
        public DateTime? DutyStart { get; set; }
        public DateTime? DutyEnd { get; set; }
        public DateTime? RestUntil { get; set; }
        public DateTime? VisitDate { get; set; }
        public int IsVisited { get; set; }
        public string CourseCode { get; set; }
        public string CourseTitle { get; set; }
        public DateTime? SessionDateFrom { get; set; }
        public DateTime? SessionDateTo { get; set; }
        public DateTime? DateCreate { get; set; }
    }
}
