﻿using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace APWeather.Models
{
    public partial class ViewFlightCrew2
    {
        public int FlightId { get; set; }
        public byte? BlockM { get; set; }
        public int? BlockH { get; set; }
        public int? FlightH { get; set; }
        public byte? FlightM { get; set; }
        public DateTime? ChocksIn { get; set; }
        public DateTime? Landing { get; set; }
        public DateTime? Takeoff { get; set; }
        public DateTime? ChocksOut { get; set; }
        public DateTime? STD { get; set; }
        public DateTime? STA { get; set; }
        public DateTime? Date { get; set; }
        public int? FlightStatusID { get; set; }
        public int? RegisterID { get; set; }
        public int? FlightTypeID { get; set; }
        public string FlightType { get; set; }
        public string FlightTypeAbr { get; set; }
        public int? TypeId { get; set; }
        public string FlightNumber { get; set; }
        public int? FromAirport { get; set; }
        public int? ToAirport { get; set; }
        public DateTime? STAPlanned { get; set; }
        public DateTime? STDPlanned { get; set; }
        public int? FlightHPlanned { get; set; }
        public int? FlightMPlanned { get; set; }
        public int? CustomerId { get; set; }
        public string FromAirportName { get; set; }
        public string FromAirportIATA { get; set; }
        public int? FromAirportCityId { get; set; }
        public string ToAirportIATA { get; set; }
        public string ToAirportName { get; set; }
        public int? ToAirportCityId { get; set; }
        public string FromAirportCity { get; set; }
        public string ToAirportCity { get; set; }
        public string AircraftType { get; set; }
        public string Register { get; set; }
        public int? MSN { get; set; }
        public string FlightStatus { get; set; }
        public DateTime? STDDay { get; set; }
        public DateTime? STADay { get; set; }
        public int? DelayOffBlock { get; set; }
        public int? DelayOnBlock { get; set; }
        public int? DelayTakeoff { get; set; }
        public int? DelayLanding { get; set; }
        public int? IsDelayOffBlock { get; set; }
        public int? IsDelayTakeoff { get; set; }
        public int? IsDelayOnBlock { get; set; }
        public int? IsDelayLanding { get; set; }
        public int? ActualFlightHOffBlock { get; set; }
        public int? ActualFlightHTakeoff { get; set; }
        public decimal? ActualFlightMOffBlock { get; set; }
        public decimal? ActualFlightMTakeoff { get; set; }
        public int? CancelReasonId { get; set; }
        public string CancelRemark { get; set; }
        public DateTime? CancelDate { get; set; }
        public string CancelReason { get; set; }
        public int? BoxId { get; set; }
        public int? CalendarId { get; set; }
        public int Id { get; set; }
        public int PositionId { get; set; }
        public int EmployeeId { get; set; }
        public string Position { get; set; }
        public string PID { get; set; }
        public int PersonId { get; set; }
        public int? GroupId { get; set; }
        public string ImageUrl { get; set; }
        public string JobGroupCode { get; set; }
        public string JobGroup { get; set; }
        public int MarriageId { get; set; }
        public string NID { get; set; }
        public int SexId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Name { get; set; }
        public DateTime? DateBirth { get; set; }
        public string Email { get; set; }
        public string Phone1 { get; set; }
        public string Mobile { get; set; }
        public string FaxTelNumber { get; set; }
        public string PassportNumber { get; set; }
        public DateTime? DatePassportIssue { get; set; }
        public DateTime? DatePassportExpire { get; set; }
        public string Address { get; set; }
        public DateTime? DateJoinAvation { get; set; }
        public int? Exp { get; set; }
        public DateTime? DateLastCheckUP { get; set; }
        public DateTime? DateNextCheckUP { get; set; }
        public DateTime? DateYearOfExperience { get; set; }
        public string CaoCardNumber { get; set; }
        public DateTime? DateCaoCardIssue { get; set; }
        public string CompetencyNo { get; set; }
        public int? CaoInterval { get; set; }
        public DateTime? DateCaoCardExpire { get; set; }
        public int IsMedicalExpired { get; set; }
        public string PPLNumber { get; set; }
        public DateTime? PPLDateIssue { get; set; }
        public DateTime? PPLDateExpire { get; set; }
        public int? PPLExpireStatus { get; set; }
        public string CPLNumber { get; set; }
        public DateTime? CPLDateIssue { get; set; }
        public DateTime? CPLDateExpire { get; set; }
        public int? CPLExpireStatus { get; set; }
        public string ATPLNumber { get; set; }
        public DateTime? ATPLDateIssue { get; set; }
        public DateTime? ATPLDateExpire { get; set; }
        public int? ATPLExpireStatus { get; set; }
        public string MCCNumber { get; set; }
        public DateTime? MCCDateIssue { get; set; }
        public DateTime? MCCDateExpire { get; set; }
        public int? MCCExpireStatus { get; set; }
        public int? CurrentLocationAirportId { get; set; }
        public string CurrentLocationAirporIATA { get; set; }
        public DateTime? ReportingTime { get; set; }
        public int? FlightTime { get; set; }
        public int? Ground { get; set; }
        public int? BoxBegin { get; set; }
        public int? Duty { get; set; }
    }
}
