using System;
using System.Collections.Generic;

namespace AtelierAPI.Models
{
    public partial class Article
    {
        public int? IdArticle { get; set; }
        public string Name { get; set; }
        public int? Price { get; set; }
        public int? IdType1 { get; set; }
    }
}
