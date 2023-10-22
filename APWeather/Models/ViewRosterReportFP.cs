using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace APWeather.Models
{
    public partial class ViewRosterReportFP
    {
        public int ID { get; set; }
        public string Day { get; set; }
        public DateTime? STDDay { get; set; }
        public string PDATE { get; set; }
        public string FlightNumber { get; set; }
        public string Register { get; set; }
        public string Route { get; set; }
        public string STD { get; set; }
        public string STA { get; set; }
        public string STDLOC { get; set; }
        public string STALOC { get; set; }
        public string Origin { get; set; }
        public string Destination { get; set; }
        public string IP { get; set; }
        public string CPT { get; set; }
        public string FO { get; set; }
        public string SAFETY { get; set; }
        public string CHECK { get; set; }
        public string OBS { get; set; }
        public string ISCCM { get; set; }
        public string SCCM { get; set; }
        public string CCM { get; set; }
        public string CHECKC { get; set; }
        public string OBSC { get; set; }
    }
}
