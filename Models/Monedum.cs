using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ARTF2.Models
{
    public partial class Monedum
    {
        public Monedum()
        {
            Equiunis = new HashSet<Equiuni>();
        }
        [Display(Name = "Id moneda")]
        public int Id { get; set; }

        [Display(Name = "Tipo moneda")]
       
        public string? Tipomoneda { get; set; }

        public virtual ICollection<Equiuni> Equiunis { get; set; }
    }
}
