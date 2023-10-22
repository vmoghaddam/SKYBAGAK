using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace APWeather.Models
{
    public partial class FDPExtra
    {
        public int Id { get; set; }
        public int FDPId { get; set; }
        public decimal? MaxFDP { get; set; }

        public virtual FDP FDP { get; set; }
    }
}
