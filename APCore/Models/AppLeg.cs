﻿using System;
using System.Collections.Generic;

#nullable disable

namespace APCore.Models
{
    public partial class AppLeg
    {
        public int ID { get; set; }
        public int FlightId { get; set; }
        public DateTime? BlockOn { get; set; }
        public DateTime? Landing { get; set; }
        public DateTime? TakeOff { get; set; }
        public DateTime? BlockOff { get; set; }
        public DateTime? BlockOnLocal { get; set; }
        public DateTime? LandingLocal { get; set; }
        public DateTime? TakeOffLocal { get; set; }
        public DateTime? BlockOffLocal { get; set; }
        public DateTime? STD { get; set; }
        public DateTime? STA { get; set; }
        public DateTime? STDLocal { get; set; }
        public DateTime? STALocal { get; set; }
        public int? FlightStatusID { get; set; }
        public int? RegisterID { get; set; }
        public int? FlightTypeID { get; set; }
        public string AircraftType { get; set; }
        public int? TypeId { get; set; }
        public string FlightNumber { get; set; }
        public int? FromAirport { get; set; }
        public int? ToAirport { get; set; }
        public int? CustomerId { get; set; }
        public string FromAirportIATA { get; set; }
        public string ToAirportIATA { get; set; }
        public string Register { get; set; }
        public string FlightStatus { get; set; }
        public string ArrivalRemark { get; set; }
        public string DepartureRemark { get; set; }
        public DateTime? STDDay { get; set; }
        public DateTime? STADay { get; set; }
        public DateTime? STDDayLocal { get; set; }
        public DateTime? STADayLocal { get; set; }
        public int? DelayBlockOff { get; set; }
        public int? DelayTakeoff { get; set; }
        public DateTime? OSTA { get; set; }
        public int? OToAirportId { get; set; }
        public string OToAirportIATA { get; set; }
        public int? FPFlightHH { get; set; }
        public int? FPFlightMM { get; set; }
        public DateTime? Departure { get; set; }
        public DateTime? Arrival { get; set; }
        public DateTime? DepartureLocal { get; set; }
        public DateTime? ArrivalLocal { get; set; }
        public int? BlockTime { get; set; }
        public int? FlightTime { get; set; }
        public int? ScheduledFlightTime { get; set; }
        public int? FPFlightTime { get; set; }
        public int? PFLR { get; set; }
        public int? PaxChild { get; set; }
        public int? PaxInfant { get; set; }
        public int? PaxAdult { get; set; }
        public int? PaxMale { get; set; }
        public int? PaxFemale { get; set; }
        public int? PaxTotal { get; set; }
        public int? PaxRevenued { get; set; }
        public int? FuelUnitID { get; set; }
        public decimal? FuelRemaining { get; set; }
        public decimal? FuelUplift { get; set; }
        public decimal? FuelUsed { get; set; }
        public decimal? FuelTotal { get; set; }
        public int? TotalSeat { get; set; }
        public int BaggageWeight { get; set; }
        public int CargoWeight { get; set; }
        public int? Freight { get; set; }
        public DateTime? FlightDate { get; set; }
        public int? CargoCount { get; set; }
        public int? BaggageCount { get; set; }
        public decimal? FPFuel { get; set; }
        public int? AirlineOperatorsID { get; set; }
        public string Airline { get; set; }
        public int? CPCrewId { get; set; }
        public string CPRegister { get; set; }
        public int? CPPositionId { get; set; }
        public int? CPFlightTypeId { get; set; }
        public int? CPFDPItemId { get; set; }
        public bool? CPDH { get; set; }
        public int? CPFDPId { get; set; }
        public string CPInstructor { get; set; }
        public string CPP1 { get; set; }
        public string CPP2 { get; set; }
        public string CPSCCM { get; set; }
        public string CPISCCM { get; set; }
        public int NightTime { get; set; }
        public int? DayTime { get; set; }
        public int? JLUserId { get; set; }
        public int? JLApproverId { get; set; }
        public DateTime? JLDate { get; set; }
        public DateTime? JLDateApproved { get; set; }
        public string JLNo { get; set; }
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
        public int MSN { get; set; }
        public bool? AttRepositioning1 { get; set; }
        public bool? AttRepositioning2 { get; set; }
        public string JLUser { get; set; }
        public string JLApprover { get; set; }
        public int IsJL { get; set; }
        public int IsJLApproved { get; set; }
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
        public string JLSignedBy { get; set; }
        public string ALT1 { get; set; }
        public string ALT2 { get; set; }
        public string ALT3 { get; set; }
        public string ALT4 { get; set; }
        public string ALT5 { get; set; }
        public string FromAirportIATA2 { get; set; }
        public string ToAirportIATA2 { get; set; }
        public decimal? FPTripFuel { get; set; }
        public string ATL { get; set; }
        public string ATCPlan { get; set; }
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



    }
}
