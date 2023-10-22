using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace APWeather.Models
{
    public partial class ViewDutyCalendarSum
    {
        public DateTime CDate { get; set; }
        public DateTime? DatePart { get; set; }
        public int EmployeeId { get; set; }
        public decimal? Duration { get; set; }
        public decimal? DurationLocal { get; set; }
        public int? CalendarCount { get; set; }
    }
}
