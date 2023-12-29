using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ARTF2.Models
{
    public partial class Insrf
    {
        [Display(Name = "Folio inscripción")]
        public int Idins { get; set; }

        [Display(Name = "Número acuerdo solicitud")]
        public string? NumacuofsolNavigator { get; set; }

        [Display(Name = "Observaciones inscripción")]
        public string? Obsins { get; set; }

        [Display(Name = "Fecha inscripción")]
        public DateTime? Fecapins { get; set; }

        [Display(Name = "Homoclave inscripción")]
        public string Homoclaveins { get; set; } = "Homo";
        public bool? Cancelled { get; set; }

        public virtual Solrf? NumacuofsolNavigatorNavigation { get; set; }
    }
}
