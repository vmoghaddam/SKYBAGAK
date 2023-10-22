using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace APWeather.Models
{
    public partial class ViewFolderApplicable
    {
        public int Id { get; set; }
        public int ParentId { get; set; }
        public string Title { get; set; }
        public string FullCode { get; set; }
        public int EmployeeId { get; set; }
        public int? Items { get; set; }
        public int? Files { get; set; }
        public int? NotVisited { get; set; }
        public int? NotDownloaded { get; set; }
        public int? CustomerId { get; set; }
        public int? EmployeeCustomerId { get; set; }
    }
}
