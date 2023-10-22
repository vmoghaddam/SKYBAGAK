using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace APWeather.Models
{
    public partial class FLTGroupItem
    {
        public int Id { get; set; }
        public int FlightId { get; set; }
        public int FLTGroupId { get; set; }

        public virtual FLTGroup FLTGroup { get; set; }
        public virtual FlightInformation Flight { get; set; }
    }
}
