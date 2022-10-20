using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace GestionDocumental.Models
{
    public class ListViewRol
    {
        public int IdRol { get; set; }

        [Required]
        public string nombreRol { get; set; }
    }
}