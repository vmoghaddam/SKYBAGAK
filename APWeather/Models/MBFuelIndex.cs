using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace APWeather.Models
{
    public partial class MBFuelIndex
    {
        public int Weight { get; set; }
        public int? Index { get; set; }
        public int RegisterID { get; set; }
        public int ID { get; set; }
    }
}
