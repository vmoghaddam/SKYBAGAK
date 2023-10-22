using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace APWeather.Models
{
    public partial class NOTAMItem
    {
        public int Id { get; set; }
        public int NOTAMId { get; set; }
        public string Text { get; set; }

        public virtual NOTAM NOTAM { get; set; }
    }
}
