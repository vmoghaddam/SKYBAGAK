using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace APWeather.Models
{
    public partial class FlightInformation
    {
        public FlightInformation()
        {
            CateringItem = new HashSet<CateringItem>();
            EFBASR = new HashSet<EFBASR>();
            EFBConfidentialReport = new HashSet<EFBConfidentialReport>();
            EFBDSPRelease = new HashSet<EFBDSPRelease>();
            EFBVoyageReport = new HashSet<EFBVoyageReport>();
            FDM = new HashSet<FDM>();
            FDPItem = new HashSet<FDPItem>();
            FLTGroupItem = new HashSet<FLTGroupItem>();
            FlightCrew = new HashSet<FlightCrew>();
            FlightCrewArchived = new HashSet<FlightCrewArchived>();
            FlightDelay = new HashSet<FlightDelay>();
            FlightLinkFlight1 = new HashSet<FlightLink>();
            FlightLinkFlight2 = new HashSet<FlightLink>();
            FlightStatusLog = new HashSet<FlightStatusLog>();
            FlightStatusWeather = new HashSet<FlightStatusWeather>();
            MVT = new HashSet<MVT>();
            MVTAPI = new HashSet<MVTAPI>();
            OFPImport = new HashSet<OFPImport>();
            OffItem = new HashSet<OffItem>();
        }

        public int ID { get; set; }
        public int? TypeID { get; set; }
        public int? RegisterID { get; set; }
        public int? FlightTypeID { get; set; }
        public int? FlightStatusID { get; set; }
        public int? AirlineOperatorsID { get; set; }
        public int? FlightGroupID { get; set; }
        public string FlightNumber { get; set; }
        public int? FromAirportId { get; set; }
        public int? ToAirportId { get; set; }
        public DateTime? STD { get; set; }
        public DateTime? STA { get; set; }
        public DateTime? ChocksOut { get; set; }
        public DateTime? Takeoff { get; set; }
        public DateTime? Landing { get; set; }
        public DateTime? ChocksIn { get; set; }
        public int? FlightH { get; set; }
        public byte? FlightM { get; set; }
        public int? BlockH { get; set; }
        public byte? BlockM { get; set; }
        public decimal? GWTO { get; set; }
        public decimal? GWLand { get; set; }
        public decimal? FuelPlanned { get; set; }
        public decimal? FuelActual { get; set; }
        public decimal? FuelDeparture { get; set; }
        public decimal? FuelArrival { get; set; }
        public int? PaxAdult { get; set; }
        public int? PaxInfant { get; set; }
        public int? PaxChild { get; set; }
        public int? CargoWeight { get; set; }
        public int? CargoUnitID { get; set; }
        public int? BaggageCount { get; set; }
        public int? CustomerId { get; set; }
        public int? FlightPlanId { get; set; }
        public DateTime? DateCreate { get; set; }
        public int? CargoCount { get; set; }
        public int? BaggageWeight { get; set; }
        public int? FuelUnitID { get; set; }
        public string ArrivalRemark { get; set; }
        public string DepartureRemark { get; set; }
        public int? EstimatedDelay { get; set; }
        public int? FlightStatusUserId { get; set; }
        public int? CancelReasonId { get; set; }
        public string CancelRemark { get; set; }
        public DateTime? CancelDate { get; set; }
        public int? OToAirportId { get; set; }
        public DateTime? OSTA { get; set; }
        public string OToAirportIATA { get; set; }
        public int? RedirectReasonId { get; set; }
        public string RedirectRemark { get; set; }
        public DateTime? RedirectDate { get; set; }
        public bool? IsApplied { get; set; }
        public DateTime? DateApplied { get; set; }
        public int? FlightPlanRegisterId { get; set; }
        public int? CalendarId { get; set; }
        public int? BoxId { get; set; }
        public int? RampReasonId { get; set; }
        public string RampRemark { get; set; }
        public DateTime? RampDate { get; set; }
        public int? FPFlightHH { get; set; }
        public int? FPFlightMM { get; set; }
        public decimal? FPFuel { get; set; }
        public decimal? Defuel { get; set; }
        public bool? SplitDuty { get; set; }
        public decimal? UsedFuel { get; set; }
        public int? JLBLHH { get; set; }
        public int? JLBLMM { get; set; }
        public int? PFLR { get; set; }
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
        public int? NightTime { get; set; }
        public DateTime? JLOffBlock { get; set; }
        public DateTime? JLOnBlock { get; set; }
        public DateTime? JLTakeOff { get; set; }
        public DateTime? JLLanding { get; set; }
        public int? NotifiedDelay { get; set; }
        public DateTime? FlightDate { get; set; }
        public string UPDNOTE { get; set; }
        public Guid? GUID { get; set; }
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
        public bool? AttRepositioning1 { get; set; }
        public bool? AttRepositioning2 { get; set; }
        public int? Version { get; set; }
        public bool? IsSynced { get; set; }
        public string PF { get; set; }
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
        public int? UTCDIFF { get; set; }
        public decimal? FPTripFuel { get; set; }
        public string Charterer { get; set; }
        public string ChrCode { get; set; }
        public string ChrTitle { get; set; }
        public int? ChrCapacity { get; set; }
        public int? ChrAdult { get; set; }
        public int? ChrChild { get; set; }
        public int? ChrInfant { get; set; }
        public string ATCPlan { get; set; }
        public string ATL { get; set; }
        public long? CargoCost { get; set; }
        public int? TTL { get; set; }
        public int? DOW { get; set; }
        public decimal? ZFW { get; set; }
        public decimal? TOW { get; set; }
        public decimal? LNW { get; set; }
        public decimal? DOI { get; set; }
        public decimal? LIZFW { get; set; }
        public decimal? LITOW { get; set; }
        public decimal? LILNW { get; set; }
        public decimal? DLI { get; set; }
        public decimal? MACZFW { get; set; }
        public decimal? MACTOW { get; set; }
        public decimal? MACLNW { get; set; }
        public int? MAXTOW { get; set; }
        public int? CPT1 { get; set; }
        public int? CPT2 { get; set; }
        public int? CPT3 { get; set; }
        public int? CPT4 { get; set; }
        public string PantryCode { get; set; }
        public decimal? StabTrimFive { get; set; }
        public decimal? StabTrimFifteen { get; set; }
        public int? FSO { get; set; }
        public int? FM { get; set; }
        public int? Pilot { get; set; }
        public int? Cabin { get; set; }
        public int? OASec { get; set; }
        public int? OBSec { get; set; }
        public int? OCSec { get; set; }
        public int? ODSec { get; set; }
        public int? MAXZFW { get; set; }
        public int? MAXLNW { get; set; }

        public virtual Organization AirlineOperators { get; set; }
        public virtual Box Box { get; set; }
        public virtual Customer Customer { get; set; }
        public virtual FlightGroup FlightGroup { get; set; }
        public virtual FlightPlanItem FlightPlan { get; set; }
        public virtual FlightStatus FlightStatus { get; set; }
        public virtual Airport FromAirport { get; set; }
        public virtual Ac_MSN Register { get; set; }
        public virtual Airport ToAirport { get; set; }
        public virtual AircraftType Type { get; set; }
        public virtual ICollection<CateringItem> CateringItem { get; set; }
        public virtual ICollection<EFBASR> EFBASR { get; set; }
        public virtual ICollection<EFBConfidentialReport> EFBConfidentialReport { get; set; }
        public virtual ICollection<EFBDSPRelease> EFBDSPRelease { get; set; }
        public virtual ICollection<EFBVoyageReport> EFBVoyageReport { get; set; }
        public virtual ICollection<FDM> FDM { get; set; }
        public virtual ICollection<FDPItem> FDPItem { get; set; }
        public virtual ICollection<FLTGroupItem> FLTGroupItem { get; set; }
        public virtual ICollection<FlightCrew> FlightCrew { get; set; }
        public virtual ICollection<FlightCrewArchived> FlightCrewArchived { get; set; }
        public virtual ICollection<FlightDelay> FlightDelay { get; set; }
        public virtual ICollection<FlightLink> FlightLinkFlight1 { get; set; }
        public virtual ICollection<FlightLink> FlightLinkFlight2 { get; set; }
        public virtual ICollection<FlightStatusLog> FlightStatusLog { get; set; }
        public virtual ICollection<FlightStatusWeather> FlightStatusWeather { get; set; }
        public virtual ICollection<MVT> MVT { get; set; }
        public virtual ICollection<MVTAPI> MVTAPI { get; set; }
        public virtual ICollection<OFPImport> OFPImport { get; set; }
        public virtual ICollection<OffItem> OffItem { get; set; }
    }
}
