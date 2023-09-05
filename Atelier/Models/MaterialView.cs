using System;
using System.Collections.Generic;

namespace AtelierAPI.Models
{
    public partial class MaterialView
    {
        public int? НомерМатериала { get; set; }
        public int? Количество10мРул { get; set; }
        public int? ЦенаШт { get; set; }
        public string ВидМатериала { get; set; }
        public string Поставщик { get; set; }
    }
}
