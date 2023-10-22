using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace APWeather.Models
{
    public partial class FlightStatusLog
    {
        public int ID { get; set; }
        public int FlightID { get; set; }
        public int FlightStatusID { get; set; }
        public DateTime Date { get; set; }
        public string Remark { get; set; }
        public int UserId { get; set; }

        public virtual FlightInformation Flight { get; set; }
    }
}
