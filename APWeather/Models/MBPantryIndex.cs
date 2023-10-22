using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace APWeather.Models
{
    public partial class MBPantryIndex
    {
        public int ID { get; set; }
        public int? RegisterID { get; set; }
        public string PantryCode { get; set; }
        public int? CockpitCrew { get; set; }
        public int? CabinCrew { get; set; }
        public int? DOW { get; set; }
        public decimal? DOI { get; set; }
    }
}
