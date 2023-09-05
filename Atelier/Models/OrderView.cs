using System;
using System.Collections.Generic;

namespace AtelierAPI.Models
{
    public partial class OrderView
    {
        public int? НомерЗаказа { get; set; }
        public string Клиент { get; set; }
        public string ВидУслуги { get; set; }
        public int? Количество { get; set; }
        public string Статус { get; set; }

    }
}
