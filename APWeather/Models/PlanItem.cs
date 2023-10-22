using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace APWeather.Models
{
    public partial class PlanItem
    {
        public int Id { get; set; }
        public DateTime? DateFrom { get; set; }
        public string Day { get; set; }
        public int FromId { get; set; }
        public int ToId { get; set; }
        public DateTime Dep { get; set; }
        public DateTime Arr { get; set; }
        public int TypeId { get; set; }
        public DateTime? DateTo { get; set; }
        public string FlightNumber { get; set; }
        public int? FlightH { get; set; }
        public int? FlightM { get; set; }
        public string Line { get; set; }
    }
}
