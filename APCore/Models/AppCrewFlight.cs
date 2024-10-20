﻿using System;
using System.Collections.Generic;

#nullable disable

namespace APCore.Models
{
    public partial class AppCrewFlight
    {
        public int FDPId { get; set; }
        public int? Id { get; set; }
        public int DutyType { get; set; }
        public string DutyTypeTitle { get; set; }
        public int FDPItemId { get; set; }
        public int? CrewId { get; set; }
        public int? FlightId { get; set; }
        public bool? IsPositioning { get; set; }
        public int? PositionId { get; set; }
        public string Position { get; set; }
        public string Name { get; set; }
        public string ScheduleName { get; set; }
        public int? GroupId { get; set; }
        public string JobGroup { get; set; }
        public string JobGroupCode { get; set; }
        public int SexId { get; set; }
        public string Sex { get; set; }
        public int GroupOrder { get; set; }
        public int IsCockpit { get; set; }
        public DateTime? STDDay { get; set; }
        public DateTime? STADay { get; set; }
        public DateTime? STDDayLocal { get; set; }
        public DateTime? STADayLocal { get; set; }
        public string FlightNumber { get; set; }
        public string FromAirportIATA { get; set; }
        public string ToAirportIATA { get; set; }
        public int? FromAirport { get; set; }
        public int? ToAirport { get; set; }
        public DateTime? STD { get; set; }
        public DateTime? STA { get; set; }
        public DateTime? STDLocal { get; set; }
        public DateTime? STALocal { get; set; }
        public string Register { get; set; }
        public int? RegisterId { get; set; }
        public DateTime? BlockOff { get; set; }
        public DateTime? BlockOn { get; set; }
        public DateTime? TakeOff { get; set; }
        public DateTime? Landing { get; set; }
        public DateTime? BlockOffLocal { get; set; }
        public DateTime? BlockOnLocal { get; set; }
        public DateTime? TakeOffLocal { get; set; }
        public DateTime? LandingLocal { get; set; }
        public int? BlockTime { get; set; }
        public int? FlightTime { get; set; }
        public int? ScheduledFlightTime { get; set; }
        public int? FPFlightTime { get; set; }
        public int BaggageWeight { get; set; }
        public int CargoWeight { get; set; }
        public int? Freight { get; set; }
        public string FlightStatus { get; set; }
        public int? FlightStatusId { get; set; }
        public string Airline { get; set; }
        public int? AirlineOperatorsID { get; set; }
        public int? CPCrewId { get; set; }
        public string CPInstructor { get; set; }
        public string CPP1 { get; set; }
        public string CPP2 { get; set; }
        public string CPSCCM { get; set; }
        public string CPISCCM { get; set; }
        public bool? SplitDuty { get; set; }
        public int NightTime { get; set; }
        public int? DayTime { get; set; }
        public int? DelayBlockOff { get; set; }
        public int? NightTakeOff { get; set; }
        public int? DayTakeOff { get; set; }
        public int? NightLanding { get; set; }
        public int? DayLanding { get; set; }
        public int? JLUserId { get; set; }
        public int? JLApproverId { get; set; }
        public DateTime? JLDate { get; set; }
        public DateTime? JLDateApproved { get; set; }
        public string JLNo { get; set; }
        public string JLUser { get; set; }
        public string JLApprover { get; set; }
        public int IsJL { get; set; }
        public int IsJLApproved { get; set; }
        public int? FuelUnitID { get; set; }
        public decimal? FuelRemaining { get; set; }
        public decimal? FuelUplift { get; set; }
        public decimal? FuelUsed { get; set; }
        public decimal? FuelTotal { get; set; }
        public int? PaxAdult { get; set; }
        public int? PaxChild { get; set; }
        public int? PaxInfant { get; set; }
        public int? PaxMale { get; set; }
        public int? PaxFemale { get; set; }
        public int? PaxTotal { get; set; }
        public int? PaxRevenued { get; set; }
        public string SerialNo { get; set; }
        public string LTR { get; set; }
        public decimal? RVSM_GND_CPT { get; set; }
        public decimal? RVSM_GND_STBY { get; set; }
        public decimal? RVSM_GND_FO { get; set; }
        public decimal? RVSM_FLT_CPT { get; set; }
        public decimal? RVSM_FLT_STBY { get; set; }
        public decimal? RVSM_FLT_FO { get; set; }
        public decimal? CARGO { get; set; }
        public decimal? FuelDensity { get; set; }
        public string CommanderNote { get; set; }
        public bool? AttASR { get; set; }
        public bool? AttVoyageReport { get; set; }
        public bool? AttRepositioning1 { get; set; }
        public bool? AttRepositioning2 { get; set; }
        public int? Version { get; set; }
        public bool? IsSynced { get; set; }
        public string PF { get; set; }
        public string IPName { get; set; }
        public int? IPId { get; set; }
        public string IPScheduleName { get; set; }
        public string P1Name { get; set; }
        public int? P1Id { get; set; }
        public string P1ScheduleName { get; set; }
        public string P2Name { get; set; }
        public int? P2Id { get; set; }
        public string P2ScheduleName { get; set; }
        public string PIC { get; set; }
        public int? PICId { get; set; }
        public string SIC { get; set; }
        public int? SICId { get; set; }
        public DateTime? JLDatePICApproved { get; set; }
        public DateTime? IStart { get; set; }
        public string JLSignedBy { get; set; }
        public string ALT1 { get; set; }
        public string ALT2 { get; set; }
        public string ALT3 { get; set; }
        public string ALT4 { get; set; }
        public string ALT5 { get; set; }
        public string ATL { get; set; }
        public string ATCPlan { get; set; }
        public decimal? FPTripFuel { get; set; }
        public decimal? FPFuel { get; set; }
        public decimal? FuelPlanned { get; set; }
        public int? OFPExtra { get; set; }

        public int? OFPCONTFUEL { get; set; }
        public int? OFPALT1FUEL { get; set; }
        public int? OFPALT2FUEL { get; set; }
        public int? OFPFINALRESFUEL { get; set; }
        public int? OFPTAXIFUEL { get; set; }
        public int? OFPETOPSADDNLFUEL { get; set; }
        public int? OFPOPSEXTRAFUEL { get; set; }
        public int? OFPTANKERINGFUEL { get; set; }
        public int? OFPTOTALFUEL { get; set; }


        public int? OFPMINTOFFUEL { get; set; }
        public int? OFPOFFBLOCKFUEL { get; set; }
        public int? OFPTRIPFUEL { get; set; }
        public int? PILOTREQFUEL { get; set; }
        public int? FuelUsedEng1 { get; set; }
        public int? FuelUsedEng2 { get; set; }

        public int? ACTUALTANKERINGFUEL { get; set; }

        public int? TANKERINGDIFF { get; set; }
        public int? ACTUALTOTALFUEL { get; set; }
        public string LTR2 { get; set; }

        public DateTime? dep_dawn { get; set; }
        public DateTime? dep_dusk { get; set; }
        public DateTime? arr_dawn { get; set; }
        public DateTime? arr_dusk { get; set; }

        public string FlightTypeOPS { get; set; }
        public string AttForms { get; set; }
    }
}
