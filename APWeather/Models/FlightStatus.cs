using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace APWeather.Models
{
    public partial class FlightStatus
    {
        public FlightStatus()
        {
            FlightInformation = new HashSet<FlightInformation>();
        }

        public int ID { get; set; }
        public string FlightStatus1 { get; set; }
        public string Description { get; set; }
        public string BgColor { get; set; }
        public string Color { get; set; }
        public string Class { get; set; }

        public virtual ICollection<FlightInformation> FlightInformation { get; set; }
    }
}
