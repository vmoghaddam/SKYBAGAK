﻿using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace APWeather.Models
{
    public partial class ViewTeacher
    {
        public int Id { get; set; }
        public DateTime DateCreate { get; set; }
        public string NID { get; set; }
        public int SexId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Mobile { get; set; }
        public string Address { get; set; }
        public bool IsActive { get; set; }
        public string IDNo { get; set; }
        public string UserId { get; set; }
        public string ImageUrl { get; set; }
        public string RemarkTeacher { get; set; }
        public string JobGroup { get; set; }
        public string JobGroupCode { get; set; }
        public int? EmployeeId { get; set; }
        public int? CourseCount { get; set; }
    }
}
