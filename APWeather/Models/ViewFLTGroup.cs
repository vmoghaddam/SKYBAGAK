using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace APWeather.Models
{
    public partial class ViewFLTGroup
    {
        public int Id { get; set; }
        public DateTime CDate { get; set; }
        public string Remark { get; set; }
        public int FirstFlightId { get; set; }
        public int LastFlightId { get; set; }
        public DateTime? Start { get; set; }
        public DateTime? StartLocal { get; set; }
        public DateTime? End { get; set; }
        public DateTime? EndLocal { get; set; }
        public string FirstFlightNumber { get; set; }
        public string LastFlightNumber { get; set; }
    }
}
