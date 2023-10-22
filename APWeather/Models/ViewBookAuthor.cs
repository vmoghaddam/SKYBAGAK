using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace APWeather.Models
{
    public partial class ViewBookAuthor
    {
        public int TypeId { get; set; }
        public int PersonMiscId { get; set; }
        public int Id { get; set; }
        public int BookId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Name { get; set; }
        public int PersonTypeId { get; set; }
        public string PersonType { get; set; }
        public string Type { get; set; }
    }
}
