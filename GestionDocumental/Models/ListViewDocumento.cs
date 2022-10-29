using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GestionDocumental.Models
{
    public class ListViewDocumento
    {
        public int IdDocumento { get; set; }

        public DateTime fechaRadicado { get; set; }

        public DateTime fechaDocumento { get; set; }

        public DateTime fechaVence { get; set; }
    }
}