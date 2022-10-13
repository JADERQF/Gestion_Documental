using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace GestionDocumental.Models
{
    public class ListViewSede
    {
        [Required]
        public int SedeId { get; set; }

        [Required]
        [Display(Name = "Release Date")]
        public string SedeName { get; set; }

        [Required]
        public int MunicipioId { get; set; }

        [Required]
        public Boolean Estado { get; set; }

    }
}