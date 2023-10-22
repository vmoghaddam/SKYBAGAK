using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace APWeather.Models
{
    public partial class SumCertificateType
    {
        public int CustomerId { get; set; }
        public int CourseTypeId { get; set; }
        public string CourseTypeTitle { get; set; }
        public int? Count { get; set; }
    }
}
