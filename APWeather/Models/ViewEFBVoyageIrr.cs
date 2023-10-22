using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace APWeather.Models
{
    public partial class ViewEFBVoyageIrr
    {
        public int? VoyageReportId { get; set; }
        public int Id { get; set; }
        public int? IrrId { get; set; }
        public string Title { get; set; }
    }
}
