using System;
using System.Collections.Generic;

#nullable disable

namespace UCP1_PAW_049_A.Models
{
    public partial class Product
    {
        public Product()
        {
            OrderProducts = new HashSet<OrderProduct>();
        }

        public int IdProduct { get; set; }
        public string NameProduct { get; set; }
        public int? Scale { get; set; }
        public int? ProductionlineId { get; set; }
        public string Vendor { get; set; }
        public string PdtDescription { get; set; }
        public int? QtyInStock { get; set; }
        public decimal? BuyPrice { get; set; }
        public string Msrp { get; set; }

        public virtual ICollection<OrderProduct> OrderProducts { get; set; }
    }
}
