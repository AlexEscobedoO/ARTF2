using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ARTF2.Models
{
    public partial class Canrf
    {
        [Display(Name = "Folio cancelación")]
        public int Idcan { get; set; }

        [Display(Name = "Folio solicitud")]
        public string? NumacuofsolNavigator { get; set; }

        [Display(Name = "Fecha oficio cancelación")]
        public DateTime Fechaofcan { get; set; }

        [Display(Name = "Motivo cancelación")]
        public string Juscan { get; set; } = null!;

        [Display(Name = "Observaciones")]
        public string Obscan { get; set; } = null!;

        [Display(Name = "Nombre del documento")]
        public string NameFichaDoc { get; set; } = null!;

        [Display(Name = "Ficha")]
        public byte[] Fichacan { get; set; } = null!;

        [Display(Name = "Homoclave")]
        public string? Homoclavecan { get; set; }

        [Display(Name = "Fecha de cancelación")]
        public DateTime Fechacan { get; set; }

        public virtual Solrf? NumacuofsolNavigatorNavigation { get; set; }
    }
}
