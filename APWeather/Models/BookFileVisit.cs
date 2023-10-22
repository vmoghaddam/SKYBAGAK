using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace APWeather.Models
{
    public partial class BookFileVisit
    {
        public int Id { get; set; }
        public int BookFileId { get; set; }
        public int EmployeeId { get; set; }
        public DateTime DateVisited { get; set; }
    }
}
