using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace APWeather.Models
{
    public partial class ImportPlan
    {
        public DateTime Date { get; set; }
        public string Base { get; set; }
        public string Type { get; set; }
        public string Reg { get; set; }
        public string No { get; set; }
        public string From { get; set; }
        public string To { get; set; }
        public DateTime? STD { get; set; }
        public DateTime? STA { get; set; }
        public string Duration { get; set; }
        public string Line { get; set; }
    }
}
