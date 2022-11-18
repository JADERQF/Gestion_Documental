using GestionDocumental.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using GestionDocumental.Filters;
using System.Web.Http.Filters;

namespace GestionDocumental.Controllers
{
    public class LoginController : Controller
    {
        // GET: Login
        [HttpPost] //recibe datos por metodo POST
        public ActionResult Login(FormCollection formCollection) //recibe un parámetro de tipo formulario
        {
            try
            {
                using (var db = new proyecto_radicadoEntities1()) //instanciamos un objeto de la db.
                {
                    string usuario = formCollection["usuario"]; //guardo el valor de input usuario
                    string clave = formCollection["clave"];       //guardo el valor de input pass
                    //PermisosRolAttribute objper = new PermisosRolAttribute(1);                                              //byte[] pass = Encoding.ASCII.GetBytes(pass1);       //guardo el valor de input pass


                    var user = db.persona.FirstOrDefault(e => e.usuario == usuario && e.clave == clave);
                    if (user != null)
                    {
                        Session["User"] = user; //Sesión de usuario
                        
                        //ViewBag.Message = "Bienvenido...";
                    }
                    else
                    {
                        //ViewBag.Message = "NO Entro";
                        return Login("Credenciales incorrectas");
                    }
                }
                return RedirectToAction("Index", "Home");
            }
            catch (Exception ex)
            {
                //throw (ex);
                ModelState.AddModelError("", "Error" + ex);
                return View();
                throw;
            }

        }
        public ActionResult Login(string mensaje = " ")
        {
            ViewBag.Message = mensaje;
            return View();
        }

        public ActionResult CloseSession()
        {
            Session["User"] = null;
            return RedirectToAction("Login", "Login");
        }

        public ActionResult Denied()
        {
            ViewBag.Message = "Sin permisos para este rol.";
            return View();
        }

    }
}
