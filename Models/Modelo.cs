using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ARTF2.Models
{
    public partial class Modelo
    {
        public Modelo()
        {
            Equiunis = new HashSet<Equiuni>();
        }

        [Display(Name = "Folio modificación")]
        public int Idmod { get; set; }

        [Display(Name = "Modelo equipo")]
        public string Modequi { get; set; } = null!;

        public virtual ICollection<Equiuni> Equiunis { get; set; }
    }
}
