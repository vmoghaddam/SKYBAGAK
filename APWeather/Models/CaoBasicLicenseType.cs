using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace APWeather.Models
{
    public partial class CaoBasicLicenseType
    {
        public CaoBasicLicenseType()
        {
            CaoBasic = new HashSet<CaoBasic>();
        }

        public int Id { get; set; }
        public string Title { get; set; }
        public string ResultTextCatA { get; set; }
        public string ResultTextCatB { get; set; }
        public string ResultTextCatC { get; set; }
        public string Remark { get; set; }

        public virtual ICollection<CaoBasic> CaoBasic { get; set; }
    }
}
