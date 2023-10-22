using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace APWeather.Models
{
    public partial class Teacher
    {
        public Teacher()
        {
            Course = new HashSet<Course>();
            TeacherDocument = new HashSet<TeacherDocument>();
        }

        public int PersonId { get; set; }
        public string Remark { get; set; }

        public virtual Person Person { get; set; }
        public virtual ICollection<Course> Course { get; set; }
        public virtual ICollection<TeacherDocument> TeacherDocument { get; set; }
    }
}
