using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace APWeather.Models
{
    public partial class EmployeeLocation
    {
        public int Id { get; set; }
        public int EmployeeId { get; set; }
        public int LocationId { get; set; }
        public bool IsMainLocation { get; set; }
        public int? OrgRoleId { get; set; }
        public decimal? DateActiveStartP { get; set; }
        public decimal? DateActiveEndP { get; set; }
        public DateTime? DateActiveStart { get; set; }
        public DateTime? DateActiveEnd { get; set; }
        public string Remark { get; set; }
        public string Phone { get; set; }

        public virtual Employee Employee { get; set; }
        public virtual Location Location { get; set; }
    }
}
