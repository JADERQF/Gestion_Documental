using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace GestionDocumental.Models
{
    public class ListViewTipo
    {
        [Required]
        public int tipoDocumentoId { get; set; }

        [Required]
        [Display(Name = "Tipo Documento")]
        public string nombreDocumento { get; set; }

        [Required]
        [Display(Name = "Tiempo de Respuesta")]
        public int? tiempoRes { get; set; }

        [Required]
        public Boolean Estado { get; set; }

    }
}