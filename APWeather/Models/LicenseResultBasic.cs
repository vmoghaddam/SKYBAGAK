using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace APWeather.Models
{
    public partial class LicenseResultBasic
    {
        public LicenseResultBasic()
        {
            CourseType = new HashSet<CourseType>();
        }

        public int Id { get; set; }
        public bool Airframe { get; set; }
        public bool PowerPlant { get; set; }
        public bool Electronics { get; set; }
        public bool Electric { get; set; }
        public string Result { get; set; }
        public bool? IsNew { get; set; }

        public virtual ICollection<CourseType> CourseType { get; set; }
    }
}
