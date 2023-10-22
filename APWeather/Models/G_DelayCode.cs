using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace APWeather.Models
{
    public partial class G_DelayCode
    {
        public G_DelayCode()
        {
            InverseParent = new HashSet<G_DelayCode>();
        }

        public int ID { get; set; }
        public int? ParentID { get; set; }
        public string Title { get; set; }
        public string DelayCode { get; set; }
        public string Description { get; set; }

        public virtual G_DelayCode Parent { get; set; }
        public virtual ICollection<G_DelayCode> InverseParent { get; set; }
    }
}
