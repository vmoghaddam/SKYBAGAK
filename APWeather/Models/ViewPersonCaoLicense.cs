using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace APWeather.Models
{
    public partial class ViewPersonCaoLicense
    {
        public int Id { get; set; }
        public int PersonId { get; set; }
        public int? CaoBasicTypeId { get; set; }
        public int? CaoCategoryId { get; set; }
        public int? CaoBasicId { get; set; }
        public DateTime? DateLicense { get; set; }
        public string Remark { get; set; }
        public string Result { get; set; }
        public bool? IsNew { get; set; }
        public bool? Quarantine { get; set; }
    }
}
