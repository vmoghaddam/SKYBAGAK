using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace APWeather.Models
{
    public partial class ViewRosterReport
    {
        public int Id { get; set; }
        public DateTime? DateLocal { get; set; }
        public string FltNo { get; set; }
        public string Route { get; set; }
        public DateTime? STDLocal { get; set; }
        public DateTime? STALocal { get; set; }
        public string Register { get; set; }
        public string AircraftType { get; set; }
        public string IP { get; set; }
        public string OBS { get; set; }
        public string P1 { get; set; }
        public string P2 { get; set; }
        public string SAFETY { get; set; }
        public string SCCM { get; set; }
        public string CCM1 { get; set; }
        public string CCM2 { get; set; }
        public string CCM3 { get; set; }
    }
}
