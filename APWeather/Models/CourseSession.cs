using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace APWeather.Models
{
    public partial class CourseSession
    {
        public CourseSession()
        {
            CourseSessionPresence = new HashSet<CourseSessionPresence>();
            CourseSessionPresenceDetail = new HashSet<CourseSessionPresenceDetail>();
        }

        public int Id { get; set; }
        public int CourseId { get; set; }
        public DateTime? DateStart { get; set; }
        public DateTime? DateEnd { get; set; }
        public bool Done { get; set; }
        public string Remark { get; set; }
        public string Key { get; set; }
        public DateTime? DateStartUtc { get; set; }
        public DateTime? DateEndUtc { get; set; }

        public virtual Course Course { get; set; }
        public virtual ICollection<CourseSessionPresence> CourseSessionPresence { get; set; }
        public virtual ICollection<CourseSessionPresenceDetail> CourseSessionPresenceDetail { get; set; }
    }
}
