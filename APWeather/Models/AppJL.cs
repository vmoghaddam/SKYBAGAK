using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace APWeather.Models
{
    public partial class AppJL
    {
        public DateTime? STDDay { get; set; }
        public string INO { get; set; }
        public string PIC { get; set; }
        public int? PICId { get; set; }
        public string Flights { get; set; }
        public string Routes { get; set; }
        public string Register { get; set; }
        public string JLNo { get; set; }
    }
}
