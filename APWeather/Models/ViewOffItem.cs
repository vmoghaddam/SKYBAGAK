using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace APWeather.Models
{
    public partial class ViewOffItem
    {
        public int Id { get; set; }
        public int FlightId { get; set; }
        public int? CrewId { get; set; }
        public DateTime? DateStart { get; set; }
        public DateTime? DateEnd { get; set; }
        public string Name { get; set; }
        public string ScheduleName { get; set; }
        public string Remark { get; set; }
    }
}
