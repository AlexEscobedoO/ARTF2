using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ARTF2.Models
{
    public partial class SolrfDoc
    {
        [Display(Name = "Id doc")]
        public int Iddoc { get; set; }

        [Display(Name = "Numero acuerdo solicitud")]
        public string? NumacuofsolNavigator { get; set; }

        [Display(Name = "Nombre documento")]
        public string NameDoc { get; set; } = null!;

        [Display(Name = "Documento")]
        public byte[]? Docsol { get; set; }

        public virtual Solrf? NumacuofsolNavigatorNavigation { get; set; }
    }
}
