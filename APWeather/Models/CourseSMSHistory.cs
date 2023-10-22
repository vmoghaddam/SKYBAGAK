using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace APWeather.Models
{
    public partial class CourseSMSHistory
    {
        public int Id { get; set; }
        public int? CourseId { get; set; }
        public int? PersonId { get; set; }
        public string PersonName { get; set; }
        public string Mobil { get; set; }
        public string Msg { get; set; }
        public DateTime? DateSent { get; set; }
        public DateTime? DateStatus { get; set; }
        public long? RefId { get; set; }
        public string Statu { get; set; }
        public int? TypeId { get; set; }
    }
}
