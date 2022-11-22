using GestionDocumental.Controllers;
using GestionDocumental.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http.Controllers;
using System.Web.Mvc;
using System.Web.UI.WebControls;

namespace GestionDocumental.Filters
{
    public class Session : ActionFilterAttribute
    {
        proyecto_radicadoEntities1 __ConnectBD;
        //private int Id_Rol;

        public Session()
        {
            __ConnectBD = new proyecto_radicadoEntities1();
            //Id_Rol = (int)IdRol;
        }
        private persona usuario; //objeto tipo persona
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            try
            {
                base.OnActionExecuting(filterContext);
                usuario = (persona)HttpContext.Current.Session["User"];//obtencion y casteo de la sesión.
                if (usuario == null)
                {
                    if(filterContext.Controller is LoginController == false)
                    { 
                        filterContext.HttpContext.Response.Redirect("~/Login/Login");
                    }
                }
            }
            catch
            {

            }
        }

    }
}