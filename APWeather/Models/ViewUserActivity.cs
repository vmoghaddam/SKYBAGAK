using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace APWeather.Models
{
    public partial class ViewUserActivity
    {
        public int Id { get; set; }
        public DateTime? Date { get; set; }
        public int UserId { get; set; }
        public string Key { get; set; }
        public string Url { get; set; }
        public int? ModuleId { get; set; }
        public bool IsMain { get; set; }
        public int? CustomerId { get; set; }
        public string Remark { get; set; }
        public string PID { get; set; }
        public string NID { get; set; }
        public string Name { get; set; }
        public string ImageUrl { get; set; }
    }
}
