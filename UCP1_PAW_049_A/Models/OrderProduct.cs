using System;
using System.Collections.Generic;

#nullable disable

namespace UCP1_PAW_049_A.Models
{
    public partial class OrderProduct
    {
        public OrderProduct()
        {
            Orders = new HashSet<Order>();
        }

        public int IdOrderProduct { get; set; }
        public int IdProduct { get; set; }
        public int? Qty { get; set; }
        public decimal? PriceEach { get; set; }

        public virtual Product IdProductNavigation { get; set; }
        public virtual ICollection<Order> Orders { get; set; }
    }
}
