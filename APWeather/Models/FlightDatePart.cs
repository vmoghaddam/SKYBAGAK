using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace APWeather.Models
{
    public partial class FlightDatePart
    {
        public int Id { get; set; }
        public int FlightId { get; set; }
        public DateTime DateRef { get; set; }
        public DateTime? DateAfter { get; set; }
        public DateTime? DateFrom { get; set; }
        public int? OrderIndex { get; set; }
    }
}
