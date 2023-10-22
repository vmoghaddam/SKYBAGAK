using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace APWeather.Models
{
    public partial class FlightTemplate
    {
        public int Id { get; set; }
        public string FlightNumber { get; set; }
        public int? ChartererId { get; set; }
        public int? OriginId { get; set; }
        public int? DestinationId { get; set; }
        public string Origin { get; set; }
        public string Destination { get; set; }
        public string Code { get; set; }
    }
}
