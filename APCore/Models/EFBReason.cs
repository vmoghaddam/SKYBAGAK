using System;
using System.Collections.Generic;

#nullable disable

namespace APCore.Models
{
    public partial class EFBReason
    {
        public int Id { get; set; }
        public int? VoyageReportId { get; set; }
        public int? ReasonId { get; set; }

        public virtual EFBVoyageReport VoyageReport { get; set; }
    }

    public partial class EFBDutyDisorder
    {
        public int Id { get; set; }
        public int? VoyageReportId { get; set; }
        public int? DisorderId { get; set; }

        public virtual EFBVoyageReport VoyageReport { get; set; }
    }
}
