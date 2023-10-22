using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace APWeather.Models
{
    public partial class PersonExperiense
    {
        public int Id { get; set; }
        public int PersonId { get; set; }
        public int? OrganizationId { get; set; }
        public string Employer { get; set; }
        public int? AircraftTypeId { get; set; }
        public string Remark { get; set; }
        public string JobTitle { get; set; }
        public DateTime? DateStart { get; set; }
        public DateTime? DateEnd { get; set; }
        public string Organization { get; set; }

        public virtual Person Person { get; set; }
    }
}
