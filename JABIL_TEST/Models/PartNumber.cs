using System;
using System.Collections.Generic;

namespace JABIL_TEST.Models
{
    public partial class PartNumber
    {
        public int PkpartNumber { get; set; }
        public string PartNumber1 { get; set; } = null!;
        public int Fkcustomer { get; set; }
        public DateTime LastUpdate { get; set; }
        public int LastUser { get; set; }
        public int Available { get; set; }

        public virtual Customer FkcustomerNavigation { get; set; } = null!;
    }
}
