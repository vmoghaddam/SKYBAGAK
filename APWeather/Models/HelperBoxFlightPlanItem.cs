using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace APWeather.Models
{
    public partial class HelperBoxFlightPlanItem
    {
        public int Id { get; set; }
        public int BoxId { get; set; }
        public int ItemId { get; set; }
        public int CalanderId { get; set; }
        public bool? SplitDuty { get; set; }
        public int? SplitDutyPairId { get; set; }
        public DateTime? ItemDeparture { get; set; }
        public DateTime? ItemArrival { get; set; }
        public DateTime? PairItemDeparture { get; set; }
        public DateTime? PairItemArrival { get; set; }
        public int? Break { get; set; }
        public int? WOCL { get; set; }
        public decimal? SplitDutyExtension { get; set; }
    }
}
