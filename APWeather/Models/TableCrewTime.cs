using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace APWeather.Models
{
    public partial class TableCrewTime
    {
        public int Id { get; set; }
        public double? Day1_Flight { get; set; }
        public double? Day7_Flight { get; set; }
        public double? Day14_Flight { get; set; }
        public double? Day28_Flight { get; set; }
        public double? Year_Flight { get; set; }
        public double? CYear_Flight { get; set; }
        public double? Day1_Duty { get; set; }
        public double? Day14_Duty { get; set; }
        public double? Day28_Duty { get; set; }
        public DateTime CDate { get; set; }
        public double? Day7_Duty { get; set; }
    }
}
