using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace APWeather.Models
{
    public partial class NOTAM
    {
        public NOTAM()
        {
            NOTAMItem = new HashSet<NOTAMItem>();
        }

        public int Id { get; set; }
        public DateTime? DateCreate { get; set; }
        public int? FlightId { get; set; }
        public int? FDPId { get; set; }
        public string StationId { get; set; }
        public DateTime? DateDay { get; set; }

        public virtual ICollection<NOTAMItem> NOTAMItem { get; set; }
    }
}
