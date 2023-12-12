using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ARTF2.Models
{
    public partial class RegimenJuridico
    {
        public RegimenJuridico()
        {
            Equiunis = new HashSet<Equiuni>();
        }

        [Display(Name = "Id regimen")]
        public int Id { get; set; }

        [Display(Name = "Regimen")]
        public string? Regimen { get; set; }

        public virtual ICollection<Equiuni> Equiunis { get; set; }
    }
}
