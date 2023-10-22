using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace APWeather.Models
{
    public partial class Client
    {
        public string Id { get; set; }
        public string Secret { get; set; }
        public string Name { get; set; }
        public int? ApplicationType { get; set; }
        public bool Active { get; set; }
        public int? RefreshTokenLifeTime { get; set; }
        public string AllowedOrigin { get; set; }
    }
}
