﻿using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace APWeather.Models
{
    public partial class DelayCodeCategory
    {
        public DelayCodeCategory()
        {
            DelayCode = new HashSet<DelayCode>();
        }

        public int Id { get; set; }
        public string Title { get; set; }
        public string Remark { get; set; }
        public string MainCategory { get; set; }

        public virtual ICollection<DelayCode> DelayCode { get; set; }
    }
}