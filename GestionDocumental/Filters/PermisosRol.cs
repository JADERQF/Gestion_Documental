using GestionDocumental.Models;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http.Controllers;
using System.Web.Mvc;
using System.Web.UI.WebControls;
using System.Xml.Linq;

namespace GestionDocumental.Filters
{
    [AttributeUsage(AttributeTargets.Method, AllowMultiple = false)]
    public class PermisosRol : AuthorizeAttribute
    {
        //private readonly int[] Id_Rol;
        private int[] Id_Rol;

        public PermisosRol(int[] idrol)
        {
            this.Id_Rol = idrol;
        }

        private persona usuario; //objeto tipo persona
        public override void OnAuthorization(AuthorizationContext filterContext)
        {
            try
            {
                //context.HttpContext.Response.Headers.Add(Id_Rol);
                usuario = (persona)HttpContext.Current.Session["User"];//obtencion y casteo de la sesión.
                if (usuario != null)
                {
                    int cont = 0;
                    foreach (int num in this.Id_Rol)
                    {
                        if (usuario.Id_Rol == num) //Validamos permisos
                        {
                          cont++;
                        }
                    }
                    if (cont == 0)
                    {
                        filterContext.Result = new RedirectResult("~/Login/Denied");
                    }
                }
            }
            catch
            {
                throw;
            }
        }

    }
}