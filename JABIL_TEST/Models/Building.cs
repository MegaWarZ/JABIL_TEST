using System;
using System.Collections.Generic;

namespace JABIL_TEST.Models
{
    public partial class Building
    {
        public Building()
        {
            Customers = new HashSet<Customer>();
        }

        public int Pkbuilding { get; set; }
        public string Building1 { get; set; } = null!;
        public DateTime LastUpdate { get; set; }
        public int LastUser { get; set; }
        public int Available { get; set; }

        public virtual ICollection<Customer> Customers { get; set; }
    }
}
