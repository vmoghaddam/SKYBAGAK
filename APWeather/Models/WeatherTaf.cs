using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace APWeather.Models
{
    public partial class WeatherTaf
    {
        public WeatherTaf()
        {
            WeatherTafForecast = new HashSet<WeatherTafForecast>();
        }

        public int Id { get; set; }
        public DateTime? DateCreate { get; set; }
        public string StationId { get; set; }
        public string RawText { get; set; }
        public DateTime? IssueTime { get; set; }
        public DateTime? BulletinTime { get; set; }
        public DateTime? ValidTimeFrom { get; set; }
        public DateTime? ValidTimeTo { get; set; }
        public decimal? Latitude { get; set; }
        public decimal? Longitude { get; set; }
        public decimal? EvaluationM { get; set; }
        public string Remarks { get; set; }
        public DateTime? DateDay { get; set; }
        public int? FlightId { get; set; }
        public int? FDPId { get; set; }
        public int? taf_id { get; set; }
        public string response_text { get; set; }

        public virtual ICollection<WeatherTafForecast> WeatherTafForecast { get; set; }
    }
}
