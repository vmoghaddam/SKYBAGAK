﻿using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace APWeather.Models
{
    public partial class HelperDelayCatRegisterMonthly
    {
        public int? PYear { get; set; }
        public string PMonthName { get; set; }
        public int? PMonth { get; set; }
        public string ICategory { get; set; }
        public int RegisterID { get; set; }
        public string Register { get; set; }
        public string AircraftType { get; set; }
        public int? TypeId { get; set; }
        public int Delay { get; set; }
        public int Count { get; set; }
        public decimal? CountPerLeg { get; set; }
        public decimal? DelayPerLeg { get; set; }
        public decimal? DelayPerBL { get; set; }
        public int? OnTimeFlightCount { get; set; }
        public decimal? DelayedFlightsPerAll { get; set; }
        public decimal? DelayedFlightsPerOnTime { get; set; }
        public int DelayUnder30 { get; set; }
        public int DelayOver30 { get; set; }
        public int Delay3060 { get; set; }
        public int Delay60120 { get; set; }
        public int Delay120180 { get; set; }
        public int DelayOver180 { get; set; }
        public int DelayOver240 { get; set; }
        public int DelayUnder30Time { get; set; }
        public int DelayOver30Time { get; set; }
        public int Delay3060Time { get; set; }
        public int Delay60120Time { get; set; }
        public int Delay120180Time { get; set; }
        public int DelayOver180Time { get; set; }
        public int DelayOver240Time { get; set; }
        public int FltDelayUnder30 { get; set; }
        public int FltDelayOver30 { get; set; }
        public int FltDelay3060 { get; set; }
        public int FltDelay60120 { get; set; }
        public int FltDelay120180 { get; set; }
        public int FltDelayOver180 { get; set; }
        public int FltDelayOver240 { get; set; }
        public int FlightCount { get; set; }
        public int? AFlightCount { get; set; }
        public int BlockTime { get; set; }
        public int? ABlockTime { get; set; }
        public int FlightTime { get; set; }
        public int? AFlightTime { get; set; }
    }
}
