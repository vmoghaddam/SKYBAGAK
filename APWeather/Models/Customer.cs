using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace APWeather.Models
{
    public partial class Customer
    {
        public Customer()
        {
            Ac_MSN = new HashSet<Ac_MSN>();
            Book = new HashSet<Book>();
            FlightInformation = new HashSet<FlightInformation>();
            FlightPlan = new HashSet<FlightPlan>();
            Location = new HashSet<Location>();
            PersonCustomer = new HashSet<PersonCustomer>();
        }

        public int Id { get; set; }
        public string Title { get; set; }
        public int? TypeId { get; set; }
        public string Address { get; set; }
        public int? CountryId { get; set; }
        public string IDNo { get; set; }
        public string NID { get; set; }
        public string MapUrl { get; set; }
        public DateTime DateRegister { get; set; }
        public DateTime? DateConfirmed { get; set; }
        public string Phone1 { get; set; }
        public string Phone2 { get; set; }
        public string Phone3 { get; set; }
        public string Website { get; set; }
        public string Email { get; set; }
        public string Remark { get; set; }

        public virtual Country Country { get; set; }
        public virtual Option Type { get; set; }
        public virtual ICollection<Ac_MSN> Ac_MSN { get; set; }
        public virtual ICollection<Book> Book { get; set; }
        public virtual ICollection<FlightInformation> FlightInformation { get; set; }
        public virtual ICollection<FlightPlan> FlightPlan { get; set; }
        public virtual ICollection<Location> Location { get; set; }
        public virtual ICollection<PersonCustomer> PersonCustomer { get; set; }
    }
}
