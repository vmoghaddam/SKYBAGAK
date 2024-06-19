using System;
using System.Collections.Generic;

#nullable disable

namespace APCore.Models
{
    public partial class OFPImport
    {
        public OFPImport()
        {
            OFPImportItems = new HashSet<OFPImportItem>();
            OFPImportProps = new HashSet<OFPImportProp>();
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


        public string THM { get; set; }
        public string UNT { get; set; }
        public string CRW
        { get; set; }
        public string RTM
        { get; set; }
        public string RTA
        { get; set; }
        public string RTB
        { get; set; }
        public string RTT
        { get; set; }
        public string PLD
        { get; set; }
        public string EZFW
        { get; set; }
        public string ETOW
        { get; set; }
        public string ELDW
        { get; set; }
        public string ETD
        { get; set; }
        public string ETA
        { get; set; }

        public string ALT1
        { get; set; }
        public string ALT2
        { get; set; }

        public string TALT1
        { get; set; }

        public string TALT2
        { get; set; }

        public string FPF
        { get; set; }

        public int? FuelALT1 { get; set; }
        public int? FuelALT2 { get; set; }
        public int? FuelTOF { get; set; }
        public int? FuelTAXI { get; set; }
        public int? FuelOFFBLOCK { get; set; }
        public int? FuelCONT { get; set; }
        public int? FuelMINTOF { get; set; }
        public int? FuelFINALRES { get; set; }

        public string VDT { get; set; }
        public string MAXSHEER { get; set; }
        public string MINDIVFUEL { get; set; }
        public string WDTMP { get; set; }
        public string DID { get; set; }
        public string WDCLB { get; set; }
        public string WDDES { get; set; }

        public int? FuelExtra { get; set; }
        public int? FuelETOPSADDNL { get; set; }
        public int? FuelOPSEXTRA { get; set; }
        public int? FuelTANKERING { get; set; }
        public int? FuelTOTALFUEL { get; set; }

        public int? FuelACTUALTANKERING { get; set; }


        public string DSPNAME { get; set; }
        public string CM1 { get; set; }
        public string CM2 { get; set; }
        public string MSH { get; set; }
        public string ATC { get; set; }




        public virtual FlightInformation Flight { get; set; }
        public virtual ICollection<OFPImportItem> OFPImportItems { get; set; }
        public virtual ICollection<OFPImportProp> OFPImportProps { get; set; }

    }
}
