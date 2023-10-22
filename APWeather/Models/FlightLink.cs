using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace APWeather.Models
{
    public partial class FlightLink
    {
        public int Flight1Id { get; set; }
        public int Flight2Id { get; set; }
        public int ReasonId { get; set; }
        public string Remark { get; set; }

        public virtual FlightInformation Flight1 { get; set; }
        public virtual FlightInformation Flight2 { get; set; }
    }
}
