using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace APWeather.Models
{
    public partial class CourseSessionPresenceDetail
    {
        public int Id { get; set; }
        public int? SessionId { get; set; }
        public DateTime? Date { get; set; }
        public string Remark { get; set; }
        public int? PersonId { get; set; }
        public string SessionKey { get; set; }
        public int? CourseId { get; set; }
        public DateTime? DateFrom { get; set; }
        public DateTime? DateTo { get; set; }

        public virtual Course Course { get; set; }
        public virtual Person Person { get; set; }
        public virtual CourseSession Session { get; set; }
    }
}
