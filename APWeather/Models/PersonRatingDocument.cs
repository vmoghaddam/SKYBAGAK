using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace APWeather.Models
{
    public partial class PersonRatingDocument
    {
        public int PersonRatingId { get; set; }
        public int DocumentId { get; set; }
        public string Remark { get; set; }
        public string Title { get; set; }

        public virtual Document Document { get; set; }
        public virtual PersonRating PersonRating { get; set; }
    }
}
