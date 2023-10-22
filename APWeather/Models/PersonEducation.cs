using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace APWeather.Models
{
    public partial class PersonEducation
    {
        public PersonEducation()
        {
            PersonEducationDocument = new HashSet<PersonEducationDocument>();
        }

        public int Id { get; set; }
        public int PersonId { get; set; }
        public int EducationDegreeId { get; set; }
        public DateTime? DateCatch { get; set; }
        public string College { get; set; }
        public string Remark { get; set; }
        public string Title { get; set; }
        public int StudyFieldId { get; set; }
        public string FileTitle { get; set; }
        public string FileType { get; set; }
        public string FileUrl { get; set; }
        public string SysUrl { get; set; }

        public virtual Person Person { get; set; }
        public virtual ICollection<PersonEducationDocument> PersonEducationDocument { get; set; }
    }
}
