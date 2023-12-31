﻿using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace APWeather.Models
{
    public partial class ViewDayDutyFlight
    {
        public DateTime Date { get; set; }
        public int CrewId { get; set; }
        public double Duty1 { get; set; }
        public double Duty7 { get; set; }
        public double Duty14 { get; set; }
        public double Duty28 { get; set; }
        public int Flight1 { get; set; }
        public int Flight28 { get; set; }
        public int FlightYear { get; set; }
        public int FlightCYear { get; set; }
    }
}
