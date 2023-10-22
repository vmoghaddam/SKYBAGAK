using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace APWeather.Models
{
    public partial class G_OpOneDelayType
    {
        public Guid PKG_OpOneDelayType { get; set; }
        public string Title { get; set; }
        public string DelayCodeStartWith { get; set; }
        public string Description { get; set; }
    }
}
