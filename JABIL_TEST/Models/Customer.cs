using System;
using System.Collections.Generic;

namespace JABIL_TEST.Models
{
    public partial class Customer
    {
        public Customer()
        {
            PartNumbers = new HashSet<PartNumber>();
        }

        public int Pkcustomers { get; set; }
        public string Customer1 { get; set; } = null!;
        public string Prefix { get; set; } = null!;
        public int Fkbuilding { get; set; }
        public DateTime LastUpdate { get; set; }
        public int LastUser { get; set; }
        public int Available { get; set; }

        public virtual Building FkbuildingNavigation { get; set; } = null!;
        public virtual ICollection<PartNumber> PartNumbers { get; set; }
    }
}
