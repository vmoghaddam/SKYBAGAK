using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace APWeather.Models
{
    public partial class CourseRelatedCourse
    {
        public int Id { get; set; }
        public int CourseId { get; set; }
        public string Remark { get; set; }
        public int RelatedCourseId { get; set; }

        public virtual Course Course { get; set; }
        public virtual Course RelatedCourse { get; set; }
    }
}
