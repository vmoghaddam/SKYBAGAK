using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace APWeather.Models
{
    public partial class Rating
    {
        public Rating()
        {
            PersonRating = new HashSet<PersonRating>();
        }

        public int Id { get; set; }
        public int OrganizationId { get; set; }
        public string Rate { get; set; }

        public virtual Organization Organization { get; set; }
        public virtual ICollection<PersonRating> PersonRating { get; set; }
    }
}
