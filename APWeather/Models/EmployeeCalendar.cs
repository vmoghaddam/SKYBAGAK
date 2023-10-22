using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace APWeather.Models
{
    public partial class EmployeeCalendar
    {
        public EmployeeCalendar()
        {
            EmployeeCalendarSplited = new HashSet<EmployeeCalendarSplited>();
        }

        public int Id { get; set; }
        public DateTime Date { get; set; }
        public int EmployeeId { get; set; }
        public int StatusId { get; set; }
        public DateTime? DateStart { get; set; }
        public DateTime? DateEnd { get; set; }
        public DateTime? DateContact { get; set; }
        public int? BoxId { get; set; }
        public DateTime? DateCease { get; set; }
        public bool? IsHomeBase { get; set; }
        public int? FDPId { get; set; }

        public virtual FDP FDP { get; set; }
        public virtual ICollection<EmployeeCalendarSplited> EmployeeCalendarSplited { get; set; }
    }
}
