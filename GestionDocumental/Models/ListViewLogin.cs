using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Xml.Linq;

namespace GestionDocumental.Models
{
    public class ListViewLogin
    {
        [Required]
        [Display(Name = "Usuario")]
        public string usuario { get; set; }
        [Required]
        [Display(Name = "Clave")]
        public string clave { get; set; }

        [Required]
        [Display(Name = "Rol")]
        public int Id_Rol { get; set; }
    }
}