using System;
using System.Collections.Generic;

namespace AtelierAPI.Models
{
    public partial class Cheque
    {
        public int? IdCheque { get; set; }
        public DateTime? DateTime { get; set; }
        public int? IdOrder { get; set; }

    }
}
