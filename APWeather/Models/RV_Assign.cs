using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace APWeather.Models
{
    public partial class RV_Assign
    {
        public string Crew { get; set; }
        public string Route { get; set; }
        public string Rank { get; set; }
        public string JobType { get; set; }
        public string PlanDesc { get; set; }
        public string Scheduler { get; set; }
        public string DateUTC { get; set; }
        public string RouteGroup { get; set; }
        public string Id { get; set; }
    }
}
