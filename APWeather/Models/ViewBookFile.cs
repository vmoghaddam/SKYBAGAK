using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace APWeather.Models
{
    public partial class ViewBookFile
    {
        public string Title { get; set; }
        public string FileUrl { get; set; }
        public string Remark { get; set; }
        public int DocumentId { get; set; }
        public string SysUrl { get; set; }
        public string FileType { get; set; }
        public int? DocumentTypeId { get; set; }
        public int? FileTypeId { get; set; }
        public int? ParentId { get; set; }
        public int BookId { get; set; }
        public int Id { get; set; }
        public int? ChapterId { get; set; }
        public string Chapter { get; set; }
    }
}
