﻿using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace APWeather.Models
{
    public partial class MVT
    {
        public int Id { get; set; }
        public int FlightId { get; set; }
        public string Type { get; set; }
        public string FlightNo { get; set; }
        public int? DayOfMonth { get; set; }
        public string Register { get; set; }
        public string FromIATA { get; set; }
        public DateTime? OffBlock { get; set; }
        public DateTime? TakeOff { get; set; }
        public DateTime? ETA { get; set; }
        public string ToIATA { get; set; }
        public string Pax { get; set; }
        public string Bag { get; set; }
        public string CPT { get; set; }
        public string DL { get; set; }
        public string Message { get; set; }
        public DateTime? DateCreate { get; set; }
        public DateTime? DateSent { get; set; }
        public string UserName { get; set; }
        public string SendTo { get; set; }
        public string SendFrom { get; set; }
        public DateTime? OnBlock { get; set; }

        public virtual FlightInformation Flight { get; set; }
    }
}
