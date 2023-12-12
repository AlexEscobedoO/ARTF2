using System;
using System.Collections.Generic;

namespace ARTF2.Models
{
    public partial class User
    {
        public int Iduser { get; set; }
        public string Tipouser { get; set; } = null!;
        public string Nomuser { get; set; } = null!;
        public string Pauser { get; set; } = null!;
        public string? Sauser { get; set; }
        public string Mailuser { get; set; } = null!;
        public string Passuser { get; set; } = null!;
    }
}
