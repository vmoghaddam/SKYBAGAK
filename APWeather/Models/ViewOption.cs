using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace APWeather.Models
{
    public partial class ViewOption
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public int? ParentId { get; set; }
        public bool? IsSystem { get; set; }
        public int? OrderIndex { get; set; }
        public string Parent { get; set; }
        public int? CreatorId { get; set; }
        public string Prop1 { get; set; }
    }
}
