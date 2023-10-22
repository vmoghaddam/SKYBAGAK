using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace APWeather.Models
{
    public partial class SumEmployeeLocation
    {
        public int CustomerId { get; set; }
        public string Code { get; set; }
        public string Title { get; set; }
        public int? Count { get; set; }
    }
}
