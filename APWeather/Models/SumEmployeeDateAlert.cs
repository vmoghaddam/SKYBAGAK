using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace APWeather.Models
{
    public partial class SumEmployeeDateAlert
    {
        public int Id { get; set; }
        public int? PassportExpired { get; set; }
        public int? PassportExpiring { get; set; }
        public int? NDTExpired { get; set; }
        public int? NDTExpiring { get; set; }
        public int? CAOExpired { get; set; }
        public int? CAOExpiring { get; set; }
        public int? MedicalExpired { get; set; }
        public int? MedicalExpiring { get; set; }
    }
}
