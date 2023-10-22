using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace APWeather.Models
{
    public partial class JobGroup
    {
        public JobGroup()
        {
            BookRelatedGroup = new HashSet<BookRelatedGroup>();
            CourseRelatedGroup = new HashSet<CourseRelatedGroup>();
            CourseTypeJobGroup = new HashSet<CourseTypeJobGroup>();
            InverseParent = new HashSet<JobGroup>();
            PersonCustomer = new HashSet<PersonCustomer>();
        }

        public int Id { get; set; }
        public int? ParentId { get; set; }
        public string Title { get; set; }
        public string Code { get; set; }
        public string FullCode { get; set; }
        public string Remark { get; set; }
        public int CustomerId { get; set; }
        public string FullCode2 { get; set; }
        public int? Manager { get; set; }

        public virtual JobGroup Parent { get; set; }
        public virtual ICollection<BookRelatedGroup> BookRelatedGroup { get; set; }
        public virtual ICollection<CourseRelatedGroup> CourseRelatedGroup { get; set; }
        public virtual ICollection<CourseTypeJobGroup> CourseTypeJobGroup { get; set; }
        public virtual ICollection<JobGroup> InverseParent { get; set; }
        public virtual ICollection<PersonCustomer> PersonCustomer { get; set; }
    }
}
