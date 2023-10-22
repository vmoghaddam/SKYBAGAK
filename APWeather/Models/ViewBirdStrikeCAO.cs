using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace APWeather.Models
{
    public partial class ViewBirdStrikeCAO
    {
        public string ReportedByName { get; set; }
        public string OperatorName { get; set; }
        public string LocalTime { get; set; }
        public string PhaseOrFlight { get; set; }
        public string SkyCondition { get; set; }
        public string BirdNrSeen { get; set; }
        public string BirdNrStruck { get; set; }
        public string BirdSize { get; set; }
    }
}
