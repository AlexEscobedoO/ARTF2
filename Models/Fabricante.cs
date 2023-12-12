using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ARTF2.Models
{
    public partial class Fabricante
    {
        [Display(Name = "Id fabricante")]
        public int Idfab { get; set; }

        [Display(Name = "Razón social fabricante")]
        public string Rsfab { get; set; } = null!;
    }
}
