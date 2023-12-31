﻿using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace APWeather.Models
{
    public partial class ViewRosterSheet
    {
        public int ID { get; set; }
        public DateTime? STDDay { get; set; }
        public string Register { get; set; }
        public string FlightNumber { get; set; }
        public string FromAirportIATA { get; set; }
        public string ToAirportIATA { get; set; }
        public int? FromAirport { get; set; }
        public int? ToAirport { get; set; }
        public string Route { get; set; }
        public string FSTDLocal { get; set; }
        public string FSTALocal { get; set; }
        public string FSTD { get; set; }
        public string FSTA { get; set; }
        public DateTime? STD { get; set; }
        public DateTime? STA { get; set; }
        public DateTime? STDLocal { get; set; }
        public DateTime? STALocal { get; set; }
        public string Duration { get; set; }
        public int? DurationMinutes { get; set; }
        public string FlightStatus { get; set; }
        public int? FlightStatusID { get; set; }
        public int IsCanceled { get; set; }
        public DateTime? Departure { get; set; }
        public DateTime? DepartureLocal { get; set; }
        public DateTime? Arrival { get; set; }
        public DateTime? ArrivalLocal { get; set; }
        public int? FlightTimeActual { get; set; }
        public int? BlockTime { get; set; }
        public int? IP1 { get; set; }
        public string IP1Name { get; set; }
        public bool? IP1DH { get; set; }
        public int? IP2 { get; set; }
        public string IP2Name { get; set; }
        public bool? IP2DH { get; set; }
        public int? P11 { get; set; }
        public string P11Name { get; set; }
        public bool? P11DH { get; set; }
        public int? P12 { get; set; }
        public string P12Name { get; set; }
        public bool? P12DH { get; set; }
        public int? P13 { get; set; }
        public string P13Name { get; set; }
        public bool? P13DH { get; set; }
        public int? P14 { get; set; }
        public string P14Name { get; set; }
        public bool? P14DH { get; set; }
        public int? P15 { get; set; }
        public string P15Name { get; set; }
        public bool? P15DH { get; set; }
        public int? P21 { get; set; }
        public string P21Name { get; set; }
        public bool? P21DH { get; set; }
        public int? P22 { get; set; }
        public string P22Name { get; set; }
        public bool? P22DH { get; set; }
        public int? P23 { get; set; }
        public string P23Name { get; set; }
        public bool? P23DH { get; set; }
        public int? P24 { get; set; }
        public string P24Name { get; set; }
        public bool? P24DH { get; set; }
        public int? P25 { get; set; }
        public string P25Name { get; set; }
        public bool? P25DH { get; set; }
        public int? Safety1 { get; set; }
        public string Safety1Name { get; set; }
        public bool? Safety1DH { get; set; }
        public int? Safety2 { get; set; }
        public string Safety2Name { get; set; }
        public bool? Safety2DH { get; set; }
        public int? ISCCM1 { get; set; }
        public string ISCCM1Name { get; set; }
        public bool? ISCCM1DH { get; set; }
        public int? SCCM1 { get; set; }
        public string SCCM1Name { get; set; }
        public bool? SCCM1DH { get; set; }
        public int? SCCM2 { get; set; }
        public string SCCM2Name { get; set; }
        public bool? SCCM2DH { get; set; }
        public int? SCCM3 { get; set; }
        public int? SCCM4 { get; set; }
        public int? SCCM5 { get; set; }
        public string SCCM3Name { get; set; }
        public string SCCM4Name { get; set; }
        public string SCCM5Name { get; set; }
        public bool? SCCM3DH { get; set; }
        public bool? SCCM4DH { get; set; }
        public bool? SCCM5DH { get; set; }
        public int? CCM1 { get; set; }
        public string CCM1Name { get; set; }
        public bool? CCM1DH { get; set; }
        public int? CCM2 { get; set; }
        public string CCM2Name { get; set; }
        public bool? CCM2DH { get; set; }
        public int? CCM3 { get; set; }
        public string CCM3Name { get; set; }
        public bool? CCM3DH { get; set; }
        public int? CCM4 { get; set; }
        public string CCM4Name { get; set; }
        public bool? CCM4DH { get; set; }
        public int? CCM5 { get; set; }
        public string CCM5Name { get; set; }
        public bool? CCM5DH { get; set; }
        public int? OBS1 { get; set; }
        public string OBS1Name { get; set; }
        public bool? OBS1DH { get; set; }
        public int? OBS2 { get; set; }
        public string OBS2Name { get; set; }
        public bool? OBS2DH { get; set; }
        public int? CHECK1 { get; set; }
        public string CHECK1Name { get; set; }
        public bool? CHECK1DH { get; set; }
        public int? CHECK2 { get; set; }
        public string CHECK2Name { get; set; }
        public bool? CHECK2DH { get; set; }
        public int? FlightTime { get; set; }
        public string DeadHeads { get; set; }
        public string Color1 { get; set; }
        public string Color2 { get; set; }
    }
}
