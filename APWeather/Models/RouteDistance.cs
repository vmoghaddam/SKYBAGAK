using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace APWeather.Models
{
    public partial class RouteDistance
    {
        public int Id { get; set; }
        public string FromIATA { get; set; }
        public int FromId { get; set; }
        public string ToIATA { get; set; }
        public int ToId { get; set; }
        public double? Distance { get; set; }
    }
}
