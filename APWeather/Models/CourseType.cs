using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace APWeather.Models
{
    public partial class CourseType
    {
        public CourseType()
        {
            Course = new HashSet<Course>();
            CourseRelatedCourseType = new HashSet<CourseRelatedCourseType>();
            CourseTypeJobGroup = new HashSet<CourseTypeJobGroup>();
        }

        public int Id { get; set; }
        public int? CalenderTypeId { get; set; }
        public int? CourseCategoryId { get; set; }
        public int? LicenseResultBasicId { get; set; }
        public string Title { get; set; }
        public string Remark { get; set; }
        public int? Interval { get; set; }
        public bool? IsGeneral { get; set; }
        public bool? Status { get; set; }
        public int? Duration { get; set; }
        public int? CertificateTypeId { get; set; }
        public int? IDX { get; set; }
        public int? Mandatory { get; set; }

        public virtual CertificateType CertificateType { get; set; }
        public virtual CourseCategory CourseCategory { get; set; }
        public virtual LicenseResultBasic LicenseResultBasic { get; set; }
        public virtual ICollection<Course> Course { get; set; }
        public virtual ICollection<CourseRelatedCourseType> CourseRelatedCourseType { get; set; }
        public virtual ICollection<CourseTypeJobGroup> CourseTypeJobGroup { get; set; }
    }
}
