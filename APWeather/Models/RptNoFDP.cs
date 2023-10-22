using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace APWeather.Models
{
    public partial class RptNoFDP
    {
        public int Id { get; set; }
        public int DutyType { get; set; }
        public string DutyTypeTitle { get; set; }
        public string PDate { get; set; }
        public string PeriodFixTime { get; set; }
        public int? PYear { get; set; }
        public DateTime? Date { get; set; }
        public DateTime? DateStart { get; set; }
        public DateTime? DateEnd { get; set; }
        public string Remark { get; set; }
        public int? CrewId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Name { get; set; }
        public string ScheduleName { get; set; }
        public string JobGroup { get; set; }
        public int? GroupId { get; set; }
        public string JobGroupCode { get; set; }
        public string JobGroupRoot { get; set; }
        public int? Duration { get; set; }
        public int? FX { get; set; }
    }
}
