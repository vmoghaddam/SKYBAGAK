using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace APWeather.Models
{
    public partial class PersonDocumentFile
    {
        public int DocumentId { get; set; }
        public int PersonDocumentId { get; set; }

        public virtual Document Document { get; set; }
        public virtual PersonDocument PersonDocument { get; set; }
    }
}
