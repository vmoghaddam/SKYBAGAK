using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace APWeather.Models
{
    public partial class HelperMaxFDP
    {
        public int Id { get; set; }
        public double? MaxFDP { get; set; }
        public double? FDPReductionByStandBy { get; set; }
        public double? MaxFDPExtended { get; set; }
    }
}
