using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace APWeather.Models
{
    public partial class CaoBasicType
    {
        public CaoBasicType()
        {
            PersonCaoLicenceHistory = new HashSet<PersonCaoLicenceHistory>();
            PersonCaoLicense = new HashSet<PersonCaoLicense>();
        }

        public int Id { get; set; }
        public int CaoBasicId { get; set; }
        public int CaoTypeId { get; set; }

        public virtual CaoBasic CaoBasic { get; set; }
        public virtual CaoType CaoType { get; set; }
        public virtual ICollection<PersonCaoLicenceHistory> PersonCaoLicenceHistory { get; set; }
        public virtual ICollection<PersonCaoLicense> PersonCaoLicense { get; set; }
    }
}
