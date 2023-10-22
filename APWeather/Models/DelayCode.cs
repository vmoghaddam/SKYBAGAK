using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace APWeather.Models
{
    public partial class DelayCode
    {
        public DelayCode()
        {
            FlightDelay = new HashSet<FlightDelay>();
        }

        public int Id { get; set; }
        public string Title { get; set; }
        public string Code { get; set; }
        public int DelayCategoryId { get; set; }
        public string Remark { get; set; }
        public int? AirlineId { get; set; }
        public string ICategory { get; set; }

        public virtual DelayCodeCategory DelayCategory { get; set; }
        public virtual ICollection<FlightDelay> FlightDelay { get; set; }
    }
}
