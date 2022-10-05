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
        // GET: Documento
        public ActionResult Index()
        {
            using (var db = new proyecto_radicadoEntities1())
            {
                return View(db.documento.ToList());
            }
        }
        public ActionResult Create()
        {
            using (var db = new proyecto_radicadoEntities1())
            {
                return View();
            }
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