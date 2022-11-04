using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace GestionDocumental.Models
{
    public class ListViewPersona 
    {
        public int IdPersona { get; set; }
        [Required]
        [Display(Name = "Primer nombre")]
        public string primerNombre { get; set; }

        [Required]
        [Display(Name = "Segundo nombre")]
        public string segundoNombre { get; set; }
        [Required]
        [Display(Name = "Primer apellido")]
        public string primerApellido { get; set; }
        [Required]
        [Display(Name = "Segundo Apellido")]
        public string segundoApellido { get; set; }
        [Required]
        [Display(Name = "Documento")]
        public string documento { get; set; }

        [Required]
        [Display(Name = "Teléfono")]
        public string telefono { get; set; }
        [Required]
        [Display(Name = "Usuario")]
        public string usuario { get; set; }
        [Required]
        [Display(Name = "Clave")]
        public string clave { get; set; }

        public Boolean estado { get; set; }
        [Required]
        [Display(Name = "Area")]
        public int Id_Area { get; set; }
        [Required]
        [Display(Name = "Rol")]
        public int Id_Rol { get; set; }
        [Required]
        [Display(Name = "Sede")]
        public int Id_Sede { get; set; }

    }
}