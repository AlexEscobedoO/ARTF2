using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace ARTF2.Models
{
    public partial class Modrf
    {
        [Display(Name = "Folio modificación")]
        public int Idmod { get; set; }
        [Display(Name = "Número acuerdo solicitud")]
        public string? NumacuofsolNavigator { get; set; }
        [Display(Name = "Nombre documento inscripción")]
        public string NameAcuDoc { get; set; } = null!;

        [Display(Name = "Acuerdo modificación")]
        public byte[]? Acumod { get; set; } = ObtenerValorPredeterminado();

        [Display(Name = "Fecha modificación")]
        public DateTime Fechamod { get; set; }

        [Display(Name = "Descripción modificación")]
        public string Desmod { get; set; } = null!;

        [Display(Name = "Observaciones modificación")]
        public string Obsmod { get; set; } = null!;

        [Display(Name = "Nombre ficha técnica")]
        public string NameFichaTecDoc { get; set; } = null!;
        [Display(Name = "Ficha técnica")]
        public byte[] Fichatecmod { get; set; } = ObtenerValorPredeterminado();

        [Display(Name = "Homoclave modificación")]
        public string Clavemod { get; set; } = null!;

        public virtual Solrf? NumacuofsolNavigatorNavigation { get; set; }
        private static byte[] ObtenerValorPredeterminado()
        {
            // Lógica para obtener el valor predeterminado
            return Encoding.UTF8.GetBytes("Default");
        }
    }

}
