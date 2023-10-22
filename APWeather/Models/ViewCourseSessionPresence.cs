using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace APWeather.Models
{
    public partial class ViewCourseSessionPresence
    {
        public int Id { get; set; }
        public int SessionId { get; set; }
        public DateTime Date { get; set; }
        public string Remark { get; set; }
        public int? PersonId { get; set; }
        public string SessionKey { get; set; }
        public int CourseId { get; set; }
        public DateTime? SessionStart { get; set; }
        public DateTime? SessionEnd { get; set; }
        public int? TotalSession { get; set; }
        public int? Attendance { get; set; }
        public decimal? AttendancePercent { get; set; }
        public int? CourseSessionPresenceId { get; set; }
        public int IsPresent { get; set; }
    }
}
