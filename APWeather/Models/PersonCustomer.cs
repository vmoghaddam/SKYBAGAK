using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace APWeather.Models
{
    public partial class PersonCustomer
    {
        public int Id { get; set; }
        public int PersonId { get; set; }
        public DateTime? DateJoinCompany { get; set; }
        public decimal? DateJoinCompanyP { get; set; }
        public bool IsActive { get; set; }
        public decimal DateRegisterP { get; set; }
        public decimal? DateConfirmedP { get; set; }
        public DateTime? DateRegister { get; set; }
        public DateTime? DateConfirmed { get; set; }
        public bool IsDeleted { get; set; }
        public DateTime? DateActiveStart { get; set; }
        public DateTime? DateActiveEnd { get; set; }
        public decimal? DateLastLoginP { get; set; }
        public DateTime? DateLastLogin { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public int? CustomerId { get; set; }
        public int? GroupId { get; set; }

        public virtual Customer Customer { get; set; }
        public virtual JobGroup Group { get; set; }
        public virtual Person Person { get; set; }
        public virtual Employee Employee { get; set; }
    }
}
