using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace APWeather.Models
{
    public partial class BoxFlightPlanItem
    {
        public int Id { get; set; }
        public int BoxId { get; set; }
        public int ItemId { get; set; }
        public int CalanderId { get; set; }
        public bool? SplitDuty { get; set; }
        public int? SplitDutyPairId { get; set; }

        public virtual Box Box { get; set; }
    }
}
