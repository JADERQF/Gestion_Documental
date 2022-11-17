using GestionDocumental.Controllers;
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
    public class PermisosRolAttribute : ActionFilterAttribute
    {
        proyecto_radicadoEntities1 __ConnectBD;
        private readonly int Id_Rol;
        public Roles Permisos { get; set; } 


        public PermisosRolAttribute(int Idrol)
        {
            __ConnectBD = new proyecto_radicadoEntities1();
            Id_Rol = Idrol;
        }

        public PermisosRolAttribute()
        {
        }

        private persona usuario; //objeto tipo persona
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            try
            {
                //context.HttpContext.Response.Headers.Add(Id_Rol);

                base.OnActionExecuting(filterContext);
                usuario = (persona)HttpContext.Current.Session["User"];//obtencion y casteo de la sesión.
                if (usuario != null)
                {
                   //UsuarioId = usuario.Id_Rol; //casteamos el rol del usuario a Roles

                    if (usuario.Id_Rol != this.Id_Rol) //Validamos permisos
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