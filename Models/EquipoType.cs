using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ARTF2.Models
{
    public partial class EquipoType
    {
        public EquipoType()
        {
            Equiunis = new HashSet<Equiuni>();
        }

        [Display(Name = "Folio equipo tipo")]
        public int IdEqui { get; set; }

        [Display(Name = "Tipo equipo")]
        public string Description { get; set; } = null!;

        public virtual ICollection<Equiuni> Equiunis { get; set; }
    }
}
