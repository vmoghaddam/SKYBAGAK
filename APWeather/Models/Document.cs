using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace APWeather.Models
{
    public partial class Document
    {
        public Document()
        {
            BookFile = new HashSet<BookFile>();
            InverseParent = new HashSet<Document>();
            PersonEducationDocument = new HashSet<PersonEducationDocument>();
            PersonRatingDocument = new HashSet<PersonRatingDocument>();
        }

        public int Id { get; set; }
        public int? DocumentTypeId { get; set; }
        public int? FileTypeId { get; set; }
        public string FileUrl { get; set; }
        public string Title { get; set; }
        public int? ParentId { get; set; }
        public string SysUrl { get; set; }
        public string FileType { get; set; }

        public virtual Document Parent { get; set; }
        public virtual PersonDocumentFile PersonDocumentFile { get; set; }
        public virtual ICollection<BookFile> BookFile { get; set; }
        public virtual ICollection<Document> InverseParent { get; set; }
        public virtual ICollection<PersonEducationDocument> PersonEducationDocument { get; set; }
        public virtual ICollection<PersonRatingDocument> PersonRatingDocument { get; set; }
    }
}
