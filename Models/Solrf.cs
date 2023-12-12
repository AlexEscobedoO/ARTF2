using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ARTF2.Models
{
    public partial class Solrf
    {
        public Solrf()
        {
            Canrves = new HashSet<Canrf>();
            Equiunis = new HashSet<Equiuni>();
            Insrves = new HashSet<Insrf>();
            Modrves = new HashSet<Modrf>();
            Rectrves = new HashSet<Rectrf>();
            SolrfDocs = new HashSet<SolrfDoc>();
        }

        [Display(Name = "Número acuerdo solicitud")]
        public string Numacuofsol { get; set; } = null!;

        [Display(Name = "Observaciones solicitud")]
        public string? Obssol { get; set; }

        [Display(Name = "Fecha solicitud")]
        public DateTime? Fecapsol { get; set; }

        public virtual ICollection<Canrf> Canrves { get; set; }
        public virtual ICollection<Equiuni> Equiunis { get; set; }
        public virtual ICollection<Insrf> Insrves { get; set; }
        public virtual ICollection<Modrf> Modrves { get; set; }
        public virtual ICollection<Rectrf> Rectrves { get; set; }
        public virtual ICollection<SolrfDoc> SolrfDocs { get; set; }
    }
}
