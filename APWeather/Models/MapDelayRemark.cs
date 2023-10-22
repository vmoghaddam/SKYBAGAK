using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace APWeather.Models
{
    public partial class MapDelayRemark
    {
        public int Id { get; set; }
        public string DelayRemark { get; set; }
        public string Title2 { get; set; }
        public string Title { get; set; }
    }
}
