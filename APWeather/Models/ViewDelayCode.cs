using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace APWeather.Models
{
    public partial class ViewDelayCode
    {
        public int Id { get; set; }
        public string Category { get; set; }
        public string CategoryRemark { get; set; }
        public string Title { get; set; }
        public string Code { get; set; }
        public int? CodeNumber { get; set; }
        public int DelayCategoryId { get; set; }
        public string Remark { get; set; }
        public int? AirlineId { get; set; }
        public string ICategory { get; set; }
    }
}
