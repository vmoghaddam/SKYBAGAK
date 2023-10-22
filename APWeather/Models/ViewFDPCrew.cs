using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace APWeather.Models
{
    public partial class ViewFDPCrew
    {
        public int Id { get; set; }
        public int? FDPId { get; set; }
        public string Name { get; set; }
        public string ScheduleName { get; set; }
        public string Position { get; set; }
        public int? PositionId { get; set; }
        public int? RosterPositionId { get; set; }
        public string Mobile { get; set; }
        public string JobGroup { get; set; }
        public string JobGroupCode { get; set; }
    }
}
