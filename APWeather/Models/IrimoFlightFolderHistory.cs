using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace APWeather.Models
{
    public partial class IrimoFlightFolderHistory
    {
        public int Id { get; set; }
        public string FL { get; set; }
        public string DT { get; set; }
        public string VT { get; set; }
        public string FileName { get; set; }
    }
}
