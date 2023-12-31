﻿using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace APWeather.Models
{
    public partial class ViewIdeaSessionItem
    {
        public int Id { get; set; }
        public int SessionId { get; set; }
        public DateTime? DateFrom { get; set; }
        public DateTime? DateTo { get; set; }
        public DateTime? DateFromUtc { get; set; }
        public DateTime? DateToUtc { get; set; }
        public string Remark { get; set; }
        public int? FDPId { get; set; }
        public string IdeaId { get; set; }
        public DateTime? DateCreate { get; set; }
        public string NID { get; set; }
        public string ClassID { get; set; }
        public string CourseTitle { get; set; }
        public string CourseCode { get; set; }
        public DateTime? DateBegin { get; set; }
        public DateTime? DateEnd { get; set; }
        public string RemarkSession { get; set; }
    }
}
