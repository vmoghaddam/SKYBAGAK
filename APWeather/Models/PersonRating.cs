using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace APWeather.Models
{
    public partial class PersonRating
    {
        public int Id { get; set; }
        public int PersonId { get; set; }
        public int AircraftTypeId { get; set; }
        public int? RatingId { get; set; }
        public DateTime DateIssue { get; set; }
        public DateTime? DateExpire { get; set; }
        public int? CategoryId { get; set; }
        public int? OrganizationId { get; set; }

        public virtual AircraftType AircraftType { get; set; }
        public virtual Person Person { get; set; }
        public virtual Rating Rating { get; set; }
        public virtual PersonRatingDocument PersonRatingDocument { get; set; }
    }
}
