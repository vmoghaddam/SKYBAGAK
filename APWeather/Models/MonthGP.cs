using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace APWeather.Models
{
    public partial class MonthGP
    {
        public int? PYear { get; set; }
        public int? PMonth { get; set; }
        public string PMonthName { get; set; }
    }
}
