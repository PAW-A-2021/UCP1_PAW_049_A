using System;
using System.Collections.Generic;

#nullable disable

namespace UCP1_PAW_049_A.Models
{
    public partial class Order
    {
        public int IdOrder { get; set; }
        public int IdOrderProduct { get; set; }
        public DateTime? OrderDate { get; set; }
        public DateTime? RequiredDate { get; set; }
        public DateTime? ShippedDate { get; set; }
        public int IdStatus { get; set; }
        public string Comment { get; set; }

        public virtual OrderProduct IdOrderProductNavigation { get; set; }
        public virtual Status IdStatusNavigation { get; set; }
    }
}
