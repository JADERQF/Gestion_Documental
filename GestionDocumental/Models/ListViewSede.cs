using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace GestionDocumental.Models
{
    public class ListViewSede
    {
        public int SedeId { get; set; }

        [Required]
        [Display(Name = "Sede")]
        public string SedeName { get; set; }

        [Required]
        [Display(Name = "Ciudad")]
        public int MunicipioId { get; set; }

        [Required]
        public Boolean? Estado { get; set; }

    }
}