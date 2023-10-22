using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace APWeather.Models
{
    public partial class XInit
    {
        public int Id { get; set; }
        public DateTime? InitStart { get; set; }
        public DateTime? InitEnd { get; set; }
        public DateTime? InitRestTo { get; set; }
        public string InitScheduleName { get; set; }
        public int? InitFromIATA { get; set; }
        public int? InitToIATA { get; set; }
        public string InitGroup { get; set; }
        public int? InitHomeBase { get; set; }
        public string InitFlts { get; set; }
        public string InitRoute { get; set; }
        public int? InitIndex { get; set; }
        public string InitRank { get; set; }
        public string InitFlights { get; set; }
        public string InitNo { get; set; }
        public string InitKey { get; set; }
    }
}
