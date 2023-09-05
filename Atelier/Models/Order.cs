using System;
using System.Collections.Generic;

namespace AtelierAPI.Models
{
    public partial class Order
    {
        public int? IdOrder { get; set; }
        public int? IdUser { get; set; }
        public int? IdStatus { get; set; }
        public int? IdMaterial { get; set; }
        public int? IdType { get; set; }
        public int? IdArticle { get; set; }
        public int? Amount { get; set; }
    }
}
