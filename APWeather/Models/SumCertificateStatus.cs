using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace APWeather.Models
{
    public partial class SumCertificateStatus
    {
        public int Id { get; set; }
        public int? Expired { get; set; }
        public int? Expiring { get; set; }
        public int? Valid { get; set; }
    }
}
