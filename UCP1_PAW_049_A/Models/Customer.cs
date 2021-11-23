using System;
using System.Collections.Generic;

#nullable disable

namespace UCP1_PAW_049_A.Models
{
    public partial class Customer
    {
        public int IdCustomer { get; set; }
        public string NamaCustomer { get; set; }
        public string Address { get; set; }
        public decimal? CreditLimit { get; set; }
    }
}
