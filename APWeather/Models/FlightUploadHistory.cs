using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace APWeather.Models
{
    public partial class FlightUploadHistory
    {
        public int Id { get; set; }
        public DateTime? DateCreate { get; set; }
        public string FileName { get; set; }
        public string URL { get; set; }
        public DateTime? DateFrom { get; set; }
        public DateTime? DateTo { get; set; }
        public string Key { get; set; }
    }
}
