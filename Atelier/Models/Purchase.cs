using System;
using System.Collections.Generic;

namespace AtelierAPI.Models
{
    public partial class Purchase
    {
        public int? IdPurchase { get; set; }
        public DateTime? DateTime { get; set; }
        public string NameProduct { get; set; }
    }
}
