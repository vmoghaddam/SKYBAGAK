using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace APWeather.Models
{
    public partial class ViewEmployeeACType
    {
        public int Id { get; set; }
        public int EmployeeId { get; set; }
        public string AcType { get; set; }
    }
}
