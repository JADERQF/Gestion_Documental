using GestionDocumental.Controllers;
using GestionDocumental.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http.Controllers;
using System.Web.Mvc;

namespace GestionDocumental.Filters
{
    public class Session : ActionFilterAttribute
    {
        private persona usuario; //objeto tipo persona
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            try
            {
                base.OnActionExecuting(filterContext);
                usuario = (persona)HttpContext.Current.Session["User"];//obtencion y casteo de la sesión.
                if (usuario == null)
                {
                    if(filterContext.Controller is PersonaController == false)
                    {
                        filterContext.HttpContext.Response.Redirect("~/Persona/Login");
                    }
                }
            }
            catch
            {

            }
        }

    }
}