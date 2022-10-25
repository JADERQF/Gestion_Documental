using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GestionDocumental.Models
{
    public class ListViewPersona 
    {
        public int IdPersona { get; set; }

        public string primerNombre { get; set; }

        public string segundoNombre { get; set; }

        public string primerApellido { get; set; }
        public string segundoApellido { get; set; }
        public string documento { get; set; }

        public string telefono { get; set; }

        public string usuario { get; set; }

        public string clave { get; set; }

        public Boolean estado { get; set; }

        public int Id_Area { get; set; }

        public int Id_Rol { get; set; }

        public int Id_Sede { get; set; }

    }
}