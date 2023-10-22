using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace APWeather.Models
{
    public partial class SumMandatoryCourseExpired
    {
        public string JobGroupRoot { get; set; }
        public string JobGroup { get; set; }
        public string CourseType { get; set; }
        public int CourseTypeId { get; set; }
        public int? CNT { get; set; }
    }
}
