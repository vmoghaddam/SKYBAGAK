using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace APWeather.Models
{
    public partial class SumFlightDelay
    {
        public int ID { get; set; }
        public string FlightNumber { get; set; }
        public DateTime? STDDay { get; set; }
        public int Delay { get; set; }
    }
}
