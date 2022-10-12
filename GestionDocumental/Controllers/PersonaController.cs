using GestionDocumental.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Mvc;


namespace GestionDocumental.Controllers
{
    public class PersonaController : Controller
    {
        // GET: Persona
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost] //recibe datos por metodo POST

        public ActionResult login(FormCollection formCollection) //recibe un parámetro de tipo formulario
        {
            using (var db = new proyecto_radicadoEntities1()) //instanciamos un objeto de la db.
            {
                string usuario = formCollection["usuario"]; //guardo el valor de input usuario
                string pass = formCollection["pass"];       //guardo el valor de input pass
                //byte[] pass = Encoding.ASCII.GetBytes(pass1);       //guardo el valor de input pass


                var user = db.persona.FirstOrDefault(e => e.usuario == usuario && e.clave == pass);
                if (user != null)
                {
                    ViewBag.Message = "BIENVENIDO...";
                    return RedirectToAction("Index","Home");
                }
                else
                {
                    //ViewBag.Message = "NO Entro care' verga";
                    return Login("Credenciales incorrectas");
                }


            }


            //string usuario = formCollection["usuario"]; //guardo el valor de input usuario
            //Byte[] clave = Encoding.Unicode.GetBytes(formCollection["pass"]);    
        }
        public ActionResult Login(string mensaje = " ")
        {
            ViewBag.Message = mensaje;
            return View();
        }
    }
}