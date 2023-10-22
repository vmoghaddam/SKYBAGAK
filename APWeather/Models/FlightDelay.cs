using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace APWeather.Models
{
    public partial class FlightDelay
    {
        public int ID { get; set; }
        public int FlightId { get; set; }
        public int DelayCodeId { get; set; }
        public int? HH { get; set; }
        public int? MM { get; set; }
        public string Remark { get; set; }
        public int? UserId { get; set; }
        public string ICategory { get; set; }

        public virtual DelayCode DelayCode { get; set; }
        public virtual FlightInformation Flight { get; set; }
    }
}
