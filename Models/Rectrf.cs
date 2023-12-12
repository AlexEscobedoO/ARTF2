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
        public string? NumacuofsolNavigator { get; set; }

        [Display(Name = "nombre documento")]
        public string NameFichatecDoc { get; set; } = null!;
        public byte[]? Fichatecrect { get; set; } = ObtenerValorPredeterminado();
        public string Numdocemp { get; set; } = null!;
        public DateTime Fechadocsol { get; set; }
        public DateTime Fecharect { get; set; }

        [Display(Name = "Descripción rectificación")]
        public string Desrect { get; set; } = null!;

        [Display(Name = "Observaciones rectificación")]
        public string Obsrect { get; set; } = null!;
        public string NameAcuDoc { get; set; } = null!;
        public byte[]? Acurect { get; set; } = ObtenerValorPredeterminado();

        [Display(Name = "Homoclave rectificación")]
        public string? Homoclaverect { get; set; }
        public DateTime Fechamodrect { get; set; }

        public virtual Solrf? NumacuofsolNavigatorNavigation { get; set; }
        private static byte[] ObtenerValorPredeterminado()
        {
            // Lógica para obtener el valor predeterminado
            return Encoding.UTF8.GetBytes("Default");
        }
    }
}
