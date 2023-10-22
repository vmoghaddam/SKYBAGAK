using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace APWeather.Models
{
    public partial class UserLogin
    {
        public int Id { get; set; }
        public string UserName { get; set; }
        public DateTime? DateAction { get; set; }
        public int? ActionId { get; set; }
        public string Ip { get; set; }
    }
}
