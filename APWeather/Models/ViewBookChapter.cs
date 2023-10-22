using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace APWeather.Models
{
    public partial class ViewBookChapter
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public int? ParentId { get; set; }
        public string Remark { get; set; }
        public string Code { get; set; }
        public string Fullcode { get; set; }
        public int? BookId { get; set; }
        public string BookKey { get; set; }
        public string TitleFormated { get; set; }
        public string TitleFormatedSpace { get; set; }
        public int? Files { get; set; }
    }
}
