using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ARTF2.Models
{
    public partial class CombustibleType
    {
        public CombustibleType()
        {
            Equiunis = new HashSet<Equiuni>();
        }

        [Display(Name = "Id Combustible")]
        public int Idcomb { get; set; }

        [Display(Name = "Combustible")]
        public string Description { get; set; } = null!;

        public virtual ICollection<Equiuni> Equiunis { get; set; }
    }
}
