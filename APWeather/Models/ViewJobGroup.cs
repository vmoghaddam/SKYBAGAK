using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace APWeather.Models
{
    public partial class ViewJobGroup
    {
        public int Id { get; set; }
        public int? ParentId { get; set; }
        public string Title { get; set; }
        public string Code { get; set; }
        public string FullCode { get; set; }
        public string RootCode { get; set; }
        public string RootTitle { get; set; }
        public string Remark { get; set; }
        public string Parent { get; set; }
        public string ParentCode { get; set; }
        public string TitleFormated { get; set; }
        public string TitleFormatedSpace { get; set; }
        public int CustomerId { get; set; }
        public int? Employees { get; set; }
        public string FullCode2 { get; set; }
        public int? Manager { get; set; }
        public string ManagerTitle { get; set; }
        public string ManagerFullCode2 { get; set; }
    }
}
