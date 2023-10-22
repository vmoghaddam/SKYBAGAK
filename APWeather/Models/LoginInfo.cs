using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace APWeather.Models
{
    public partial class LoginInfo
    {
        public int Id { get; set; }
        public string User { get; set; }
        public DateTime? DateCreate { get; set; }
        public string Info { get; set; }
        public string IP { get; set; }
        public string LocationCity { get; set; }
    }
}
