using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace GestionDocumental.Models
{
    public class ListViewArea
    {
        [Required]
        public int Id_sede { get; set; }

        [Required]
       public string Nombre_Area { get; set; }

        public Boolean estado { get; set; }
        

    }
}