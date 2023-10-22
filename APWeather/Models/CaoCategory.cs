using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace APWeather.Models
{
    public partial class CaoCategory
    {
        public CaoCategory()
        {
            PersonCaoLicenceHistory = new HashSet<PersonCaoLicenceHistory>();
            PersonCaoLicense = new HashSet<PersonCaoLicense>();
        }

        public int Id { get; set; }
        public string Title { get; set; }
        public int Number { get; set; }
        public string Description { get; set; }
        public string Remark { get; set; }

        public virtual ICollection<PersonCaoLicenceHistory> PersonCaoLicenceHistory { get; set; }
        public virtual ICollection<PersonCaoLicense> PersonCaoLicense { get; set; }
    }
}
