using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace APWeather.Models
{
    public partial class ViewRotserDailyCrew
    {
        public int Id { get; set; }
        public DateTime? DepartureLocal { get; set; }
        public int GroupOrder { get; set; }
        public string JobGroup { get; set; }
        public int? GroupId { get; set; }
        public string JobGroupCode { get; set; }
        public string Name { get; set; }
        public string ScheduleName { get; set; }
    }
}
