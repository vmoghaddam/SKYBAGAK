using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace APWeather.Models
{
    public partial class ViewDutyCalendar
    {
        public DateTime CDate { get; set; }
        public DateTime? DatePart { get; set; }
        public int CrewCalendarId { get; set; }
        public int EmployeeId { get; set; }
        public DateTime? DateStart { get; set; }
        public DateTime? DateEndActual { get; set; }
        public DateTime? DateStartLocal { get; set; }
        public DateTime? DateEndActualLocal { get; set; }
        public string Status { get; set; }
        public int StatusId { get; set; }
        public int? DurationOriginal { get; set; }
        public int? DurationLocalOriginal { get; set; }
        public decimal? Duration { get; set; }
        public decimal? DurationLocal { get; set; }
    }
}
