using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace APWeather.Models
{
    public partial class XDaily
    {
        public DateTime? XSTD { get; set; }
        public DateTime? XSTA { get; set; }
        public int? XFlightH { get; set; }
        public int? XFlightM { get; set; }
        public DateTime? XDateUTC { get; set; }
        public DateTime? XOffBlock { get; set; }
        public DateTime? XTakeOff { get; set; }
        public DateTime? XLanding { get; set; }
        public DateTime? XOnBlock { get; set; }
        public string XFlightNumber { get; set; }
        public string Reg { get; set; }
        public int? XRegisterId { get; set; }
        public int XFlightStatusId { get; set; }
        public DateTime? DateUTC { get; set; }
        public string STD { get; set; }
        public string STA { get; set; }
        public string OffBlock { get; set; }
        public string OnBlock { get; set; }
        public string TakeOff { get; set; }
        public string Landing { get; set; }
        public string ADL { get; set; }
        public string CHD { get; set; }
        public string INF { get; set; }
        public string Bag { get; set; }
        public string cargo { get; set; }
        public string uplift { get; set; }
        public string trip { get; set; }
        public string Status { get; set; }
        public string XFromAirport { get; set; }
        public int? XFromAirportId { get; set; }
        public string XToAirport { get; set; }
        public int? XToAirportId { get; set; }
    }
}
