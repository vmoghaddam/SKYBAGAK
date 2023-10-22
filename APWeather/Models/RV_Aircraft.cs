using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace APWeather.Models
{
    public partial class RV_Aircraft
    {
        public string Type { get; set; }
        public string Reg { get; set; }
        public string Seat { get; set; }
        public string Owner { get; set; }
        public string MaxCargoWeight { get; set; }
        public string Real { get; set; }
        public string GanttShowOrder { get; set; }
        public string Id { get; set; }
        public string FuelCapacity { get; set; }
        public string FuelUnit { get; set; }
    }
}
