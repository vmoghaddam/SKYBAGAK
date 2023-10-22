using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace APWeather.Models
{
    public partial class AircraftModel
    {
        public AircraftModel()
        {
            Ac_MSN = new HashSet<Ac_MSN>();
            Course = new HashSet<Course>();
        }

        public int Id { get; set; }
        public string Model { get; set; }
        public int AircraftTypeId { get; set; }
        public string Remark { get; set; }

        public virtual AircraftType AircraftType { get; set; }
        public virtual ICollection<Ac_MSN> Ac_MSN { get; set; }
        public virtual ICollection<Course> Course { get; set; }
    }
}
