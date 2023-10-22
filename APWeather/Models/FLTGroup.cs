using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace APWeather.Models
{
    public partial class FLTGroup
    {
        public FLTGroup()
        {
            FLTGroupItem = new HashSet<FLTGroupItem>();
        }

        public int Id { get; set; }
        public DateTime CDate { get; set; }
        public string Remark { get; set; }
        public int? FirstFlightId { get; set; }
        public int? LastFlightId { get; set; }

        public virtual ICollection<FLTGroupItem> FLTGroupItem { get; set; }
    }
}
