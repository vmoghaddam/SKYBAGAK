﻿using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace APWeather.Models
{
    public partial class HelperFDPBox
    {
        public int Id { get; set; }
        public int? Cid { get; set; }
        public int DelayAmount { get; set; }
        public int DelayAmountLast { get; set; }
        public DateTime? DelayedReportingTime { get; set; }
        public DateTime? NextNotification { get; set; }
        public DateTime? RevisedDelayedReportingTime { get; set; }
        public DateTime? FirstNotification { get; set; }
        public int? Sectors { get; set; }
        public int? ACTypeId { get; set; }
        public DateTime? STD { get; set; }
        public DateTime? STA { get; set; }
        public DateTime? Departure { get; set; }
        public DateTime? Arrival { get; set; }
        public DateTime? DepartureLocal { get; set; }
        public DateTime? ArrivalLocal { get; set; }
        public DateTime? DefaultReportingTime { get; set; }
        public DateTime? ReportingTime { get; set; }
        public DateTime? ReportingTimeLCL { get; set; }
        public int? LastFlightStatusID { get; set; }
        public string FlightNumber { get; set; }
        public int? FromAirport { get; set; }
        public string FromAirportIATA { get; set; }
        public int? FromAirportCityId { get; set; }
        public int? ToAirport { get; set; }
        public string ToAirportIATA { get; set; }
    }
}
