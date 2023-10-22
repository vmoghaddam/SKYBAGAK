using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace APWeather.Models
{
    public partial class HelperMatchingList
    {
        public long RN { get; set; }
        public int? FlightId { get; set; }
        public double? FirstCrewId { get; set; }
        public double? SecondCrewId { get; set; }
        public int? TemplateId { get; set; }
    }
}
