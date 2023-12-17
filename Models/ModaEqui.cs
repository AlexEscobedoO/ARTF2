using System;
using System.Collections.Generic;

namespace ARTF2.Models
{
    public partial class ModaEqui
    {
        public ModaEqui()
        {
            Equiunis = new HashSet<Equiuni>();
        }

        public int Id { get; set; }
        public string Description { get; set; } = null!;

        public virtual ICollection<Equiuni> Equiunis { get; set; }
    }
}
