using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace APWeather.Models
{
    public partial class NiraHistory
    {
        public int Id { get; set; }
        public string FLIGHT { get; set; }
        public string CHTIME { get; set; }
        public string NEWAIRCRAFT { get; set; }
        public string NEWSTATUS { get; set; }
        public DateTime? DateSend { get; set; }
        public DateTime? DateReplied { get; set; }
        public string Remark { get; set; }
        public int? FlightId { get; set; }
        public int? FlightStatusId { get; set; }
        public DateTime? Departure { get; set; }
        public DateTime? Arrival { get; set; }
        public string Register { get; set; }
    }
}
