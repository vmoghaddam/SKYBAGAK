using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace APWeather.Models
{
    public partial class OFPSkyPuter
    {
        public int Id { get; set; }
        public int? FlightId { get; set; }
        public string FlightNumber { get; set; }
        public DateTime? FlightDate { get; set; }
        public string OFP { get; set; }
        public string AIRLINE { get; set; }
        public DateTime? DateCreate { get; set; }
        public DateTime? DateUpload { get; set; }
        public int? UploadStatus { get; set; }
        public string UploadMessage { get; set; }
    }
}
