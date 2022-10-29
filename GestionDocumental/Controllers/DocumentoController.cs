using GestionDocumental.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace GestionDocumental.Controllers
{
    public class DocumentoController : Controller
    {
        proyecto_radicadoEntities1 __ConnectBD;
        // GET: Documento

        public DocumentoController()
        {
            __ConnectBD = new proyecto_radicadoEntities1();
        }
        public ActionResult Index()
        {            
                return View(__ConnectBD.documento.ToList());   
        }
        public ActionResult Create()
        {
                return View();          
        }

        [HttpPost]
        public ActionResult Create(documento documento)
        {
            if (!ModelState.IsValid) //
                return View();

            try
            {
                using (var db = new proyecto_radicadoEntities1())
                {
                    db.documento.Add(documento);
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", "Error" + ex);
                return View();
                throw;
            }
        }
    }
}