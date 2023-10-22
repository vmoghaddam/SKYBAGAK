using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace APWeather.Models
{
    public partial class ViewFDPIdea
    {
        public int Id { get; set; }
        public int? CrewId { get; set; }
        public string InitFlts { get; set; }
        public string InitRoute { get; set; }
        public DateTime? DutyStart { get; set; }
        public int DutyType { get; set; }
        public DateTime? RestUntil { get; set; }
    }
}
