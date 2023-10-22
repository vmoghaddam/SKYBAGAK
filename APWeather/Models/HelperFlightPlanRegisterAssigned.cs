using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace APWeather.Models
{
    public partial class HelperFlightPlanRegisterAssigned
    {
        public int flightplanid { get; set; }
        public int PlannedRegisterId { get; set; }
        public DateTime? MinDateFrom { get; set; }
        public DateTime? MaxDateTo { get; set; }
    }
}
