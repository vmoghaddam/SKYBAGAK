using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace APWeather.Models
{
    public partial class SumEmployeeMaritalStatus
    {
        public int CustomerId { get; set; }
        public int MarriageId { get; set; }
        public string MaritalStatus { get; set; }
        public int? Count { get; set; }
    }
}
