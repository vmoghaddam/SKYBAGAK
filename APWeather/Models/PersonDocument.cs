using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace APWeather.Models
{
    public partial class PersonDocument
    {
        public PersonDocument()
        {
            PersonDocumentFile = new HashSet<PersonDocumentFile>();
        }

        public int PersonId { get; set; }
        public string Title { get; set; }
        public string Remark { get; set; }
        public int Id { get; set; }
        public int DocumentTypeId { get; set; }

        public virtual Person Person { get; set; }
        public virtual ICollection<PersonDocumentFile> PersonDocumentFile { get; set; }
    }
}
