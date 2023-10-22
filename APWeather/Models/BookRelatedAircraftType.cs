using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace APWeather.Models
{
    public partial class BookRelatedAircraftType
    {
        public int Id { get; set; }
        public int BookId { get; set; }
        public int AircraftTypeId { get; set; }
        public string Remark { get; set; }

        public virtual AircraftType AircraftType { get; set; }
        public virtual Book Book { get; set; }
    }
}
