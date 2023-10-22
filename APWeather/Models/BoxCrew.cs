using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace APWeather.Models
{
    public partial class BoxCrew
    {
        public BoxCrew()
        {
            EmployeeCalendarSplited = new HashSet<EmployeeCalendarSplited>();
        }

        public int Id { get; set; }
        public int BoxId { get; set; }
        public int JobGroupId { get; set; }
        public int EmployeeId { get; set; }
        public int? AvailabilityId { get; set; }
        public string Remark { get; set; }
        public DateTime? ReportingTime { get; set; }

        public virtual Box Box { get; set; }
        public virtual Employee Employee { get; set; }
        public virtual ICollection<EmployeeCalendarSplited> EmployeeCalendarSplited { get; set; }
    }
}
