using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace APWeather.Models
{
    public partial class CourseTypeJobGroup
    {
        public int CourseTypeId { get; set; }
        public int JobGroupId { get; set; }
        public string Remark { get; set; }
        public bool? Mandatory { get; set; }
        public bool? NoRecurrent { get; set; }
        public int? Interval { get; set; }
        public int? IntervalUnit { get; set; }
        public int? Duration { get; set; }

        public virtual CourseType CourseType { get; set; }
        public virtual JobGroup JobGroup { get; set; }
    }
}
