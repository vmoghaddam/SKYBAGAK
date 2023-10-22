using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace APWeather.Models
{
    public partial class HelperFlightSexSum
    {
        public int? FlightId { get; set; }
        public int? Total { get; set; }
        public string Sex { get; set; }
        public int SexId { get; set; }
    }
}
