using System;
using System.Collections.Generic;

namespace AtelierAPI.Models
{
    public partial class User
    {
        public int? IdUser { get; set; }
        public string Login { get; set; }
        public string Salt { get; set; }
        public string Hash { get; set; }
        public int? IdRole { get; set; }
        public int? IdStatus { get; set; }
    }
}
