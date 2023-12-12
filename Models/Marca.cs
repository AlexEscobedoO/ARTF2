using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ARTF2.Models
{
    public partial class Marca
    {
        [Display(Name = "Id marca")]
        public int Id { get; set; }

        [Display(Name = "Razón social marca")]
        public string? RsMarca { get; set; }
    }
}
