using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GestionDocumental.Models
{
    public class ListViewDocumento
    {
        public HttpPostedFileBase archivo { get; set; }//Este tipo de archivo sirve para subir archivos al servidor
        public int IdDocumento { get; set; }

        public DateTime fechaRadicado { get; set; }

        public DateTime fechaDocumento { get; set; }

        public DateTime fechaVence { get; set; }

        public string ubicacion { get; set; }

        public int Id_Persona { get; set; }

        public int Id_TipoDocumento { get; set; }

        public int Id_Estado { get; set; }
    }
}