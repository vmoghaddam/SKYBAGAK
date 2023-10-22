using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace APWeather.Models
{
    public partial class OFPImport
    {
        public OFPImport()
        {
            OFPImportItem = new HashSet<OFPImportItem>();
            OFPImportProp = new HashSet<OFPImportProp>();
        }

        public int Id { get; set; }
        public string FileName { get; set; }
        public string FlightNo { get; set; }
        public string Origin { get; set; }
        public string Destination { get; set; }
        public DateTime? DateFlight { get; set; }
        public DateTime? DateCreate { get; set; }
        public string Text { get; set; }
        public string User { get; set; }
        public string TextOutput { get; set; }
        public int? FlightId { get; set; }
        public string DateUpdate { get; set; }
        public DateTime? DateConfirmed { get; set; }
        public string UserConfirmed { get; set; }
        public int? PICId { get; set; }
        public DateTime? JLDatePICApproved { get; set; }
        public string JLSignedBy { get; set; }
        public string PIC { get; set; }
        public decimal? FPFuel { get; set; }
        public decimal? FPTripFuel { get; set; }
        public decimal? MCI { get; set; }
        public decimal? FLL { get; set; }
        public decimal? DOW { get; set; }
        public string Source { get; set; }
        public string JPlan { get; set; }
        public string JAPlan1 { get; set; }
        public string JAPlan2 { get; set; }
        public string JFuel { get; set; }
        public string JCSTBL { get; set; }
        public string JALDRF { get; set; }
        public string JWTDRF { get; set; }

        public virtual FlightInformation Flight { get; set; }
        public virtual ICollection<OFPImportItem> OFPImportItem { get; set; }
        public virtual ICollection<OFPImportProp> OFPImportProp { get; set; }
    }
}
