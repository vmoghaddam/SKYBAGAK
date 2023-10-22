using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace APWeather.Models
{
    public partial class CourseCategory
    {
        public CourseCategory()
        {
            CourseType = new HashSet<CourseType>();
            InverseParent = new HashSet<CourseCategory>();
        }

        public int Id { get; set; }
        public string Title { get; set; }
        public int? ParentId { get; set; }

        public virtual CourseCategory Parent { get; set; }
        public virtual ICollection<CourseType> CourseType { get; set; }
        public virtual ICollection<CourseCategory> InverseParent { get; set; }
    }
}
