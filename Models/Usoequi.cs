using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ARTF2.Models
{
    public partial class Usoequi
    {
        public Usoequi()
        {
            Equiunis = new HashSet<Equiuni>();
        }

        [Display(Name = "Id uso equipo")]
        public int Id { get; set; }

        [Display(Name = "Uso equipo")]
        public string Usoequi1 { get; set; } = null!;

        public virtual ICollection<Equiuni> Equiunis { get; set; }
    }
}
