using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace APWeather.Models
{
    public partial class ViewPersonAircraftType
    {
        public string AircraftType { get; set; }
        public int ManufacturerId { get; set; }
        public string Manufacturer { get; set; }
        public int Id { get; set; }
        public int AircraftTypeId { get; set; }
        public int PersonId { get; set; }
        public bool? IsActive { get; set; }
        public DateTime? DateLimitBegin { get; set; }
        public DateTime? DateLimitEnd { get; set; }
        public string Remark { get; set; }
        public int? Remain { get; set; }
    }
}
