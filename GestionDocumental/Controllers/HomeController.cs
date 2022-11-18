using GestionDocumental.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using GestionDocumental.Models;

namespace GestionDocumental.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }
        
        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            //return View("About");

            //return RedirectToAction("About"); // Llama el método About dentro de la misma clase
            //o el mismo controlador (en este caso HomeController.cs)
            return RedirectToAction("login", "Persona"); //Llama al método login dentro del controlador persona
        }
    }
}