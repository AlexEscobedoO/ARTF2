using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace ARTF2.Models
{
    public partial class Rectrf
    {
        [Display(Name = "Id rectificación")]
        public int Idrect { get; set; }
        [Display(Name = "Número acuerdo solicitud")]
        public string? NumacuofsolNavigator { get; set; }

        [Display(Name = "Nombre documento")]
        public string NameFichatecDoc { get; set; } = null!;
        [Display(Name = "Ficha técnica")]
        public byte[]? Fichatecrect { get; set; } = ObtenerValorPredeterminado();
        [Display(Name = "Número de documento")]
        public string Numdocemp { get; set; } = null!;
        [Display(Name = "Fecha de solicitud")]
        public DateTime Fechadocsol { get; set; }
        [Display(Name = "Fecha de acuerdo")]
        public DateTime Fecharect { get; set; }
        [Display(Name = "Descripción rectificación")]
        public string Desrect { get; set; } = null!;
        [Display(Name = "Observaciones rectificación")]
        public string Obsrect { get; set; } = null!;
        [Display(Name = "Nombre documento")]
        public string NameAcuDoc { get; set; } = null!;
        [Display(Name = "Documento rectificación")]
        public byte[]? Acurect { get; set; } = ObtenerValorPredeterminado();

        [Display(Name = "Homoclave rectificación")]
        public string? Homoclaverect { get; set; }
        [Display(Name = "Fecha rectificación")]
        public DateTime Fechamodrect { get; set; }

        public virtual Solrf? NumacuofsolNavigatorNavigation { get; set; }
        private static byte[] ObtenerValorPredeterminado()
        {
            // Lógica para obtener el valor predeterminado
            return Encoding.UTF8.GetBytes("Default");
        }
    }
}
