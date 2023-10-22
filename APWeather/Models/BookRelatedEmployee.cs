using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace APWeather.Models
{
    public partial class BookRelatedEmployee
    {
        public int Id { get; set; }
        public int EmployeeId { get; set; }
        public int BookId { get; set; }
        public string Remark { get; set; }
        public DateTime? DateSigned { get; set; }

        public virtual Book Book { get; set; }
        public virtual Employee Employee { get; set; }
    }
}
