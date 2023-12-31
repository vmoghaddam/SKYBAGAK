﻿using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace APWeather.Models
{
    public partial class RptReposition
    {
        public int FDPId { get; set; }
        public int? CrewId { get; set; }
        public string Name { get; set; }
        public string LastName { get; set; }
        public string FirstName { get; set; }
        public string JobGroup { get; set; }
        public string JobGroupCode { get; set; }
        public DateTime? DateFDP { get; set; }
        public string Flights { get; set; }
        public string Route { get; set; }
        public int Pos1 { get; set; }
        public int Pos2 { get; set; }
        public int? Pos { get; set; }
        public int? PosFixTime { get; set; }
        public int? PYear { get; set; }
        public string PMonthName { get; set; }
        public int? PMonth { get; set; }
        public string PDate { get; set; }
        public string PeriodFixTime { get; set; }
    }
}
