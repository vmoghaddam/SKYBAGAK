﻿using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace APWeather.Models
{
    public partial class ViewFinYearlyRoute
    {
        public int Year { get; set; }
        public string Route { get; set; }
        public string FromAirportIATA { get; set; }
        public string ToAirportIATA { get; set; }
        public int? Legs { get; set; }
        public int Child { get; set; }
        public int Infant { get; set; }
        public int Adult { get; set; }
        public int TotalPax { get; set; }
        public int TotalSeat { get; set; }
        public int Delay { get; set; }
        public decimal UpliftFuel { get; set; }
        public decimal UsedFuel { get; set; }
        public int BaggageWeight { get; set; }
        public int CargoWeight { get; set; }
        public int Freight { get; set; }
        public bool? IsDom { get; set; }
    }
}
