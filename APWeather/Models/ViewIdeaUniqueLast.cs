﻿using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace APWeather.Models
{
    public partial class ViewIdeaUniqueLast
    {
        public int Id { get; set; }
        public string IdeaId { get; set; }
        public long? Rank { get; set; }
        public string NID { get; set; }
        public string PID { get; set; }
        public string CourseCode { get; set; }
        public string CourseTitle { get; set; }
        public string CourseType { get; set; }
        public string ClassID { get; set; }
        public DateTime? DateBegin { get; set; }
        public DateTime? DateEnd { get; set; }
        public DateTime? DateExpire { get; set; }
        public string Remark { get; set; }
        public DateTime? DateCreate { get; set; }
        public int? CrewId { get; set; }
        public string CrewPID { get; set; }
        public int? GroupId { get; set; }
        public string JobGroup { get; set; }
        public string JobGroupCode { get; set; }
        public string CrewNID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Name { get; set; }
        public string ScheduleName { get; set; }
        public int? IsCockpit { get; set; }
        public int? IsCabin { get; set; }
    }
}
