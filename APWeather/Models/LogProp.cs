using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace APWeather.Models
{
    public partial class LogProp
    {
        public int Id { get; set; }
        public int FlightId { get; set; }
        public string PropName { get; set; }
        public string PropValue { get; set; }
        public DateTime? DateUpdate { get; set; }
        public decimal? DateUpdateLocal { get; set; }
        public string User { get; set; }
        public string PropValueOld { get; set; }
    }
}
