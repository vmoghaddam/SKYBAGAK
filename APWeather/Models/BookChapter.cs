using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace APWeather.Models
{
    public partial class BookChapter
    {
        public BookChapter()
        {
            InverseParent = new HashSet<BookChapter>();
        }

        public int Id { get; set; }
        public string Title { get; set; }
        public int? ParentId { get; set; }
        public string Remark { get; set; }
        public string Code { get; set; }
        public string FullCode { get; set; }
        public int? BookId { get; set; }
        public string BookKey { get; set; }

        public virtual Book Book { get; set; }
        public virtual BookChapter Parent { get; set; }
        public virtual ICollection<BookChapter> InverseParent { get; set; }
    }
}
