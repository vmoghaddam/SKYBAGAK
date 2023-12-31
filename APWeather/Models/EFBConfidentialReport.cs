﻿using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace APWeather.Models
{
    public partial class EFBConfidentialReport
    {
        public int Id { get; set; }
        public DateTime? Date { get; set; }
        public DateTime? LocalTime { get; set; }
        public DateTime? UTCTime { get; set; }
        public bool? IsDay { get; set; }
        public string EventSummary { get; set; }
        public string ActionTaken { get; set; }
        public string Resolve { get; set; }
        public string SafetyRECO { get; set; }
        public string Other { get; set; }
        public bool? ASRRaised { get; set; }
        public int? FlightId { get; set; }
        public string User { get; set; }
        public string DateUpdate { get; set; }
        public string Name { get; set; }
        public string Phone { get; set; }
        public int? EmpNo { get; set; }

        public virtual FlightInformation Flight { get; set; }
    }
}
