using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace APWeather.Models
{
    public partial class Country
    {
        public Country()
        {
            Customer = new HashSet<Customer>();
        }

        public int Id { get; set; }
        public string SortName { get; set; }
        public string Name { get; set; }
        public int? PhoneCode { get; set; }

        public virtual ICollection<Customer> Customer { get; set; }
    }
}
