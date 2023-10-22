using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace APWeather.Models
{
    public partial class IdeaSession
    {
        public IdeaSession()
        {
            IdeaSessionItem = new HashSet<IdeaSessionItem>();
        }

        public int Id { get; set; }
        public string IdeaId { get; set; }
        public DateTime? DateCreate { get; set; }
        public string PID { get; set; }
        public string NID { get; set; }
        public string ClassID { get; set; }
        public string CourseCode { get; set; }
        public string CourseTitle { get; set; }
        public DateTime? DateBegin { get; set; }
        public DateTime? DateEnd { get; set; }
        public string SessionsStr { get; set; }
        public string Remark { get; set; }

        public virtual ICollection<IdeaSessionItem> IdeaSessionItem { get; set; }
    }
}
