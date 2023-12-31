﻿using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace APWeather.Models
{
    public partial class EFBVoyageReport
    {
        public EFBVoyageReport()
        {
            EFBFlightIrregularity = new HashSet<EFBFlightIrregularity>();
            EFBReason = new HashSet<EFBReason>();
        }

        public int Id { get; set; }
        public int? FlightId { get; set; }
        public string Route { get; set; }
        public int? RestReduction { get; set; }
        public int? DutyExtention { get; set; }
        public string Report { get; set; }
        public DateTime? DatePICSignature { get; set; }
        public int? ActionedById { get; set; }
        public DateTime? DateActioned { get; set; }
        public DateTime? DateConfirmed { get; set; }
        public int? DepDelay { get; set; }
        public string DateUpdate { get; set; }
        public string User { get; set; }
        public string JLSignedBy { get; set; }
        public DateTime? JLDatePICApproved { get; set; }
        public int? PICId { get; set; }
        public string PIC { get; set; }
        public string OPSRemark { get; set; }
        public DateTime? OPSRemarkDate { get; set; }
        public int? OPSId { get; set; }
        public DateTime? OPSConfirmDate { get; set; }
        public string OPSStaffRemark { get; set; }
        public DateTime? OPSStaffDateVisit { get; set; }
        public DateTime? OPSStaffConfirmDate { get; set; }
        public int? OPSStaffId { get; set; }
        public DateTime? OPSStaffRemarkDate { get; set; }
        public string OPSUser { get; set; }
        public string OPSStaffUser { get; set; }
        public int? OPSStatusId { get; set; }
        public int? OPSStaffStatusId { get; set; }

        public virtual FlightInformation Flight { get; set; }
        public virtual ICollection<EFBFlightIrregularity> EFBFlightIrregularity { get; set; }
        public virtual ICollection<EFBReason> EFBReason { get; set; }
    }
}
