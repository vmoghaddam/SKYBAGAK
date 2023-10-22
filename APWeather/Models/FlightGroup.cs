using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace APWeather.Models
{
    public partial class FlightGroup
    {
        public FlightGroup()
        {
            FlightInformation = new HashSet<FlightInformation>();
        }

        public int ID { get; set; }
        public int EmployeeId { get; set; }
        public int Status { get; set; }
        public DateTime CreateDate { get; set; }
        public string Remark { get; set; }

        public virtual Employee Employee { get; set; }
        public virtual ICollection<FlightInformation> FlightInformation { get; set; }
    }
}
