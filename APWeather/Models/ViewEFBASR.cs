﻿using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace APWeather.Models
{
    public partial class ViewEFBASR
    {
        public int Id { get; set; }
        public int FlightId { get; set; }
        public int? FlightPhaseId { get; set; }
        public string FlightPhase { get; set; }
        public int? EventTypeId { get; set; }
        public int? METId { get; set; }
        public int? SigxWXId { get; set; }
        public int? RunwayConditionId { get; set; }
        public string EventType { get; set; }
        public string SigxWX { get; set; }
        public string MET { get; set; }
        public string RunwayCondition { get; set; }
        public string AATRisk { get; set; }
        public string AATTCASAlert { get; set; }
        public string WTTurning { get; set; }
        public string WTGlideSlopePos { get; set; }
        public string WTExtendedCenterlinePos { get; set; }
        public string WTAttitudeChange { get; set; }
        public string BSNrStruck { get; set; }
        public string BSNrSeen { get; set; }
        public string BSTime { get; set; }
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
        public int MSN { get; set; }
        public string FlightStatus { get; set; }
        public string ArrivalRemark { get; set; }
        public string DepartureRemark { get; set; }
        public DateTime? STDDay { get; set; }
        public DateTime? STADay { get; set; }
        public DateTime? STDDayLocal { get; set; }
        public DateTime? STADayLocal { get; set; }
        public int? DelayBlockOff { get; set; }
        public int? DelayTakeoff { get; set; }
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
        public int? CPCrewId { get; set; }
        public string CPRegister { get; set; }
        public int? CPPositionId { get; set; }
        public int? CPFlightTypeId { get; set; }
        public int? CPFDPItemId { get; set; }
        public bool? CPDH { get; set; }
        public int? CPFDPId { get; set; }
        public string CPP1 { get; set; }
        public string CPInstructor { get; set; }
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
        public decimal? RVSM_GND_CPT { get; set; }
        public string LTR { get; set; }
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
        public string JLUser { get; set; }
        public string JLApprover { get; set; }
        public int IsJL { get; set; }
        public int IsJLApproved { get; set; }
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
        public DateTime? OccurrenceDate { get; set; }
        public bool? IsDay { get; set; }
        public string SQUAWK { get; set; }
        public decimal? FuelJettisoned { get; set; }
        public decimal? Altitude { get; set; }
        public double? Speed { get; set; }
        public decimal? ACWeight { get; set; }
        public string TechLogPageNO { get; set; }
        public string TechLogItemNO { get; set; }
        public string LOCAirport { get; set; }
        public string LOCStand { get; set; }
        public string LOCRunway { get; set; }
        public string LOCGEOLongtitude { get; set; }
        public string LOCGEOAltitude { get; set; }
        public string ActualWX { get; set; }
        public string ACConfigAP { get; set; }
        public string ACConfigATHR { get; set; }
        public string ACConfigGear { get; set; }
        public string ACConfigFlap { get; set; }
        public string ACConfigSlat { get; set; }
        public string Summary { get; set; }
        public string Result { get; set; }
        public string OthersInfo { get; set; }
        public string ACConfigSpoilers { get; set; }
        public int? AATRiskId { get; set; }
        public bool? AATIsActionTaken { get; set; }
        public string AATReportedToATC { get; set; }
        public string AATATCInstruction { get; set; }
        public string AATFrequency { get; set; }
        public decimal? AATHeading { get; set; }
        public string AATClearedAltitude { get; set; }
        public string AATMinVerticalSep { get; set; }
        public string AATMinHorizontalSep { get; set; }
        public int? AATTCASAlertId { get; set; }
        public string AATTypeRA { get; set; }
        public bool? AATIsRAFollowed { get; set; }
        public string AATVerticalDeviation { get; set; }
        public string AATOtherACType { get; set; }
        public string AATMarkingColour { get; set; }
        public string AATCallSign { get; set; }
        public string AATLighting { get; set; }
        public decimal? WTHeading { get; set; }
        public int? WTTurningId { get; set; }
        public int? WTGlideSlopePosId { get; set; }
        public int? WTExtendedCenterlinePosId { get; set; }
        public int? WTAttitudeChangeId { get; set; }
        public decimal? WTAttitudeChangeDeg { get; set; }
        public bool? WTIsBuffet { get; set; }
        public bool? WTIsStickShaker { get; set; }
        public string WTSuspect { get; set; }
        public string WTDescribeVA { get; set; }
        public string WTPrecedingAC { get; set; }
        public bool? WTIsAware { get; set; }
        public string BSBirdType { get; set; }
        public int? BSNrSeenId { get; set; }
        public int? BSNrStruckId { get; set; }
        public int? BSTimeId { get; set; }
        public DateTime? PICDate { get; set; }
        public int? DayNightStatusId { get; set; }
        public int? IncidentTypeId { get; set; }
        public int? AATXAbove { get; set; }
        public int? AATYAbove { get; set; }
        public int? AATXAstern { get; set; }
        public int? AATYAstern { get; set; }
        public int? AATHorizontalPlane { get; set; }
        public string BSImpactDec { get; set; }
        public bool? IsSecurityEvent { get; set; }
        public bool? IsAirproxATC { get; set; }
        public bool? IsTCASRA { get; set; }
        public bool? IsWakeTur { get; set; }
        public bool? IsBirdStrike { get; set; }
        public bool? IsOthers { get; set; }
        public double? MachNo { get; set; }
        public int? SigxWXTypeId { get; set; }
        public string DateUpdate { get; set; }
        public string User { get; set; }
        public double? BSHeading { get; set; }
        public int? BSTurningId { get; set; }
    }
}
