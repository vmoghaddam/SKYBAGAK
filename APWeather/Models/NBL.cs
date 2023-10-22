using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace APWeather.Models
{
    public partial class NBL
    {
        public string FLT { get; set; }
        public string DES { get; set; }
        public string ORG { get; set; }
        public string FLT2 { get; set; }
        public int? HH { get; set; }
        public int? MM { get; set; }
        public int? DESID { get; set; }
        public int? ORGID { get; set; }
    }
}
