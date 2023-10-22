using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace APWeather.Models
{
    public partial class CoursePeople
    {
        public int Id { get; set; }
        public int CourseId { get; set; }
        public int? PersonId { get; set; }
        public int? EmployeeId { get; set; }
        public int? StatusId { get; set; }
        public DateTime? DateStatus { get; set; }
        public DateTime? DateIssue { get; set; }
        public DateTime? DateExpire { get; set; }
        public string StatusRemark { get; set; }
        public string CertificateNo { get; set; }
        public string ImgUrl { get; set; }

        public virtual Course Course { get; set; }
        public virtual Person Person { get; set; }
    }
}
