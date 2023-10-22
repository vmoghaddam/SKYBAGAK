using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace APWeather.Models
{
    public partial class ViewEmployeeAge
    {
        public int? CustomerId { get; set; }
        public int Id { get; set; }
        public int? Age { get; set; }
        public int AgeUnknown { get; set; }
        public int Age0025 { get; set; }
        public int Age2530 { get; set; }
        public int Age3040 { get; set; }
        public int Age4050 { get; set; }
        public int Age5000 { get; set; }
    }
}
