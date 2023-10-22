using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace APWeather.Models
{
    public partial class HelperCertLINE
    {
        public int Id { get; set; }
        public int PersonId { get; set; }
        public string Name { get; set; }
        public int TypeId { get; set; }
        public DateTime? IssueDate { get; set; }
        public DateTime? ExpireDate { get; set; }
        public int? Remain { get; set; }
    }
}
