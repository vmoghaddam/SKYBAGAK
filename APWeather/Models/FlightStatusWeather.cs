using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace APWeather.Models
{
    public partial class FlightStatusWeather
    {
        public int Id { get; set; }
        public int FlightId { get; set; }
        public int StatusId { get; set; }
        public DateTime? DateStatus { get; set; }
        public decimal? Temprature { get; set; }
        public decimal? WindSpeed { get; set; }
        public decimal? WindBearing { get; set; }
        public decimal? CloudCover { get; set; }
        public decimal? Pressure { get; set; }
        public decimal? Humidity { get; set; }
        public decimal? DewPoint { get; set; }
        public string Summary { get; set; }
        public decimal? Visibility { get; set; }
        public string Details { get; set; }
        public string Icon { get; set; }

        public virtual FlightInformation Flight { get; set; }
    }
}
