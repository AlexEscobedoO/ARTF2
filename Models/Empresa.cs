using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ARTF2.Models
{
    public partial class Empresa
    {
        [Display(Name = "Folio empresa")]
        public int Idempre { get; set; }

        [Display(Name = "Razón social")]
        public string Rsempre { get; set; } = null!;

        [Display(Name = "Dirección")]
        public string Dirempre { get; set; } = null!;
        public int? TipoempreIdNavigation { get; set; }

        public virtual EmpreType? TipoempreIdNavigationNavigation { get; set; }
        public virtual ICollection<Equiuni> Equiunis { get; set; }

    }
}
