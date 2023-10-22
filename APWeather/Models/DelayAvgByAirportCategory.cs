using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace APWeather.Models
{
    public partial class DelayAvgByAirportCategory
    {
        public int FromAirport { get; set; }
        public string FromAirportIATA { get; set; }
        public string Category { get; set; }
        public int? Avg { get; set; }
    }
}
