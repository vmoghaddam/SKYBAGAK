using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace APWeather.Models
{
    public partial class UserActivityMenuHit
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public int ModuleId { get; set; }
        public string Key { get; set; }
        public int? CustomerId { get; set; }
        public int Hit { get; set; }
        public DateTime DateLastHit { get; set; }
    }
}
