﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ARTF2.Models
{
    public partial class Equiuni
    {
        [Display(Name = "Folio equipo")]
        public int Idequi { get; set; }
        public string? NumacuofsolNavigator { get; set; }
        public int? ModaequiIdNavigation { get; set; }
        public int? TipequiIdNavigation { get; set; }
        public int? CombuequiIdNavigation { get; set; }

        [Display(Name = "Número serie")]
        public string Nserie { get; set; } = null!;

        [Display(Name = "Matricula")]
        public string Matricula { get; set; } = null!;
        public int? RegiequiIdNavigation { get; set; }

        [Display(Name = "Gravamen")]
        public bool? Graequi { get; set; }
        public int? UsoequiIdNavigation { get; set; }
        public DateTime? Fcons { get; set; }

        [Display(Name = "Número factura")]
        public string? Nofact { get; set; }

        [Display(Name = "Tipo Contrato")]
        public string? Tcontra { get; set; }

        [Display(Name = "Fecha Contrato")]
        public DateTime? Fcontra { get; set; }

        [Display(Name = "Vigencia Contrato")]
        public string? Vcontra { get; set; }

        [Display(Name = "Monto renta")]
        public int? Mrent { get; set; }
        public int? MonrentIdNavigation { get; set; }
        public string Obsarre { get; set; } = null!;

        [Display(Name = "Observaciones gravamen")]
        public string Obsgra { get; set; } = null!;

        [Display(Name = "Observaciones equipo")]
        public string Obsequi { get; set; } = null!;

        [Display(Name = "Nombre documento")]
        public string NameFichaDoc { get; set; } = null!;
        public byte[]? Fichaequi { get; set; }

        [Display(Name = "Fecha requerimiento")]
        public DateTime? Fecharequi { get; set; }

        public virtual CombustibleType? CombuequiIdNavigationNavigation { get; set; }
        public virtual Modelo? ModaequiIdNavigationNavigation { get; set; }
        public virtual Monedum? MonrentIdNavigationNavigation { get; set; }
        public virtual Solrf? NumacuofsolNavigatorNavigation { get; set; }
        public virtual RegimenJuridico? RegiequiIdNavigationNavigation { get; set; }
        public virtual EquipoType? TipequiIdNavigationNavigation { get; set; }
        public virtual Usoequi? UsoequiIdNavigationNavigation { get; set; }
    }
}
