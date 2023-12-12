using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ARTF2.Models
{
    public partial class EmpreType
    {
        public EmpreType()
        {
            Empresas = new HashSet<Empresa>();
        }

        [Display(Name = "Id tipo empresa")]
        public int Id { get; set; }

        [Display(Name = "Tipo empresa")]
        public string? Type { get; set; }

        public virtual ICollection<Empresa> Empresas { get; set; }
    }
}
