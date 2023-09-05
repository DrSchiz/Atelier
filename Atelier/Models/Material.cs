using System;
using System.Collections.Generic;

namespace AtelierAPI.Models
{
    public partial class Material
    {

        public int? IdMaterial { get; set; }
        public int? Amount { get; set; }
        public int? Price { get; set; }
        public int? IdType { get; set; }
        public int? IdStock { get; set; }
        public int? IdSupplier { get; set; }
    }
}
