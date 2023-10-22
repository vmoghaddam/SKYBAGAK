using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace APWeather.Models
{
    public partial class FlightCard
    {
        public int Id { get; set; }
        public string Key { get; set; }
        public int? FlightId { get; set; }
        public string Reg { get; set; }
        public string Route { get; set; }
        public string FltNo { get; set; }
        public DateTime? DateCreate { get; set; }
    }
}
