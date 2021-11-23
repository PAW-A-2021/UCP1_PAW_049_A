using System;
using System.Collections.Generic;

#nullable disable

namespace UCP1_PAW_049_A.Models
{
    public partial class Status
    {
        public Status()
        {
            Orders = new HashSet<Order>();
        }

        public int IdStatus { get; set; }
        public string Status1 { get; set; }

        public virtual ICollection<Order> Orders { get; set; }
    }
}
