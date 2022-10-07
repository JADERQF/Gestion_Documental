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
        public string SedeName { get; set; }

        [Required]
        public int MunicipioId { get; set; } = 1;

    }
}