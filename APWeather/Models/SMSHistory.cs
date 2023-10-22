using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace APWeather.Models
{
    public partial class SMSHistory
    {
        public int Id { get; set; }
        public string RecName { get; set; }
        public string RecMobile { get; set; }
        public string Text { get; set; }
        public DateTime? DateSent { get; set; }
        public string Ref { get; set; }
        public int? TypeId { get; set; }
        public int? ResId { get; set; }
        public string ResStr { get; set; }
        public DateTime? ResDate { get; set; }
        public string ResFlts { get; set; }
        public string Delivery { get; set; }
        public int? RecId { get; set; }
        public int? FlightId { get; set; }
        public string Sender { get; set; }
    }
}
