using GestionDocumental.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace GestionDocumental.Controllers
{
    public class TipoController : Controller
    {
        // GET: Tipo
        public ActionResult Index()
        {
            List<ListViewTipo> lista;
            using (proyecto_radicadoEntities1 db = new proyecto_radicadoEntities1())
            {
                lista = (from x in db.tipoDocumento
                         select new ListViewTipo
                         {
                             tipoDocumentoId = x.IdTipoDocumento,
                             nombreDocumento = x.nombreDocumento,
                             tiempoRes = x.tiempoRespuesta,
                             Estado = x.estado
                         }
                         ).ToList();
            }
            return View(lista);
        }
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(ListViewTipo collection)
        {
            try
            {
                using (proyecto_radicadoEntities1 db = new proyecto_radicadoEntities1())
                {
                    var table = new tipoDocumento();
                    table.nombreDocumento = collection.nombreDocumento;
                    table.tiempoRespuesta = collection.tiempoRes;
                    table.estado = true;
                    db.tipoDocumento.Add(table);
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }
            }
            catch
            {
                return View();
            }
        }
        public ActionResult getId(int id)
        {
            try
            {
                ListViewTipo model = new ListViewTipo();
                using (proyecto_radicadoEntities1 bd = new proyecto_radicadoEntities1())
                {
                    var table = bd.tipoDocumento.Find(id);
                    model.tipoDocumentoId = table.IdTipoDocumento;
                    model.nombreDocumento = table.nombreDocumento;
                    model.tiempoRes = table.tiempoRespuesta;
                    model.Estado = table.estado;
                }
                return View(model);
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", "Error" + ex);
                return View();
                throw;
            }
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(ListViewTipo collection)
        {
            try
            {
                using (proyecto_radicadoEntities1 db = new proyecto_radicadoEntities1())
                {
                    var table = db.tipoDocumento.Find(collection.tipoDocumentoId);
                    table.nombreDocumento = collection.nombreDocumento;
                    table.tiempoRespuesta = collection.tiempoRes;
                    table.estado = collection.Estado;
                    db.Entry(table).State = System.Data.Entity.EntityState.Modified;
                    db.SaveChanges();
                }

                return Redirect("Index");
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", "Error" + ex);
                return View();
                throw;
            }
        }
        [HttpGet]
        public ActionResult Delete(int Id)
        {
            try
            {
                using (proyecto_radicadoEntities1 db = new proyecto_radicadoEntities1())
                {
                    var table = db.tipo.Find
                }
            }
        }
    }
}