﻿using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace APWeather.Models
{
    public partial class AspNetUserTokens
    {
        public string UserId { get; set; }
        public int LoginProvider { get; set; }
        public string Name { get; set; }
        public string Value { get; set; }
    }
}
