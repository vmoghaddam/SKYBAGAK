using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace APWeather.Models
{
    public partial class Charterer
    {
        public int Id { get; set; }
        public string Code { get; set; }
        public string Title1 { get; set; }
        public string Remark { get; set; }
        public string NiraCode { get; set; }
        public string Title2 { get; set; }
    }
}
