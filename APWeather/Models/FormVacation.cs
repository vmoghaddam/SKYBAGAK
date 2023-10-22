using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace APWeather.Models
{
    public partial class FormVacation
    {
        public int Id { get; set; }
        public int Reason { get; set; }
        public string ReasonStr { get; set; }
        public DateTime? DateFrom { get; set; }
        public DateTime? DateTo { get; set; }
        public string Remark { get; set; }
        public int? UserId { get; set; }
        public DateTime? DateCreate { get; set; }
        public string OperationRemak { get; set; }
        public string SchedulingRemark { get; set; }
    }
}
