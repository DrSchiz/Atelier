using System;
using System.Collections.Generic;

namespace Atelier.Models
{
    public partial class ArticleView
    {
        public int? IdArticle { get; set; }
        public string Name { get; set; }
        public int? Price { get; set; }
        public string IdType1 { get; set; }
    }
}