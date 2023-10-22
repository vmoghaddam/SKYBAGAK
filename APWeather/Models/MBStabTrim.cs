using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace APWeather.Models
{
    public partial class MBStabTrim
    {
        public int ID { get; set; }
        public int? MAC { get; set; }
        public decimal? FlapFifteen { get; set; }
        public decimal? FlapFive { get; set; }
        public int? RegisterID { get; set; }
    }
}
