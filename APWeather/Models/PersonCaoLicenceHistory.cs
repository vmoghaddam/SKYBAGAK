using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace APWeather.Models
{
    public partial class PersonCaoLicenceHistory
    {
        public int Id { get; set; }
        public int CaoUserLicenseId { get; set; }
        public int PersonId { get; set; }
        public int CaoBasicTypeId { get; set; }
        public int CaoCategoryId { get; set; }
        public DateTime DateLicense { get; set; }
        public string Remark { get; set; }

        public virtual CaoBasicType CaoBasicType { get; set; }
        public virtual CaoCategory CaoCategory { get; set; }
        public virtual PersonCaoLicense CaoUserLicense { get; set; }
        public virtual Person Person { get; set; }
    }
}
