using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace APWeather.Models
{
    public partial class OffItem
    {
        public int FDPId { get; set; }
        public int FlightId { get; set; }
        public string Remark { get; set; }

        public virtual FDP FDP { get; set; }
        public virtual FlightInformation Flight { get; set; }
    }
}
