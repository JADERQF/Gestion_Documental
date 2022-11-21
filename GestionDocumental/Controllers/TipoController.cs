using GestionDocumental.Filters;
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
        proyecto_radicadoEntities1 __ConnectBD;
        // GET: Tipo

        public TipoController()
        {
            __ConnectBD = new proyecto_radicadoEntities1();
        }

        [PermisosRol(new int[] { 1 })]
        public ActionResult Index()
        {
            List<ListViewTipo> lista;
            
                lista = (from x in __ConnectBD.tipoDocumento
                         select new ListViewTipo
                         {
                             tipoDocumentoId = x.IdTipoDocumento,
                             nombreDocumento = x.nombreDocumento,
                             tiempoRes = x.tiempoRespuesta,
                             Estado = x.estado
                         }
                         ).ToList();
            return View(lista);
        }

        [PermisosRol(new int[] { 1 })]
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [PermisosRol(new int[] { 1 })]
        public ActionResult Create(ListViewTipo collection)
        {
            try
            {
                    var table = new tipoDocumento();
                    table.nombreDocumento = collection.nombreDocumento;
                    table.tiempoRespuesta = collection.tiempoRes;
                    table.estado = true;
                    __ConnectBD.tipoDocumento.Add(table);
                    __ConnectBD.SaveChanges();
                    return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        [PermisosRol(new int[] { 1 })]
        public ActionResult getId(int id)
        {
            try
            {
                ListViewTipo model = new ListViewTipo();
                
                    var table = __ConnectBD.tipoDocumento.Find(id);
                    model.tipoDocumentoId = table.IdTipoDocumento;
                    model.nombreDocumento = table.nombreDocumento;
                    model.tiempoRes = table.tiempoRespuesta;
                    model.Estado = table.estado;
                
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
        [PermisosRol(new int[] { 1 })]
        public ActionResult Edit(ListViewTipo collection)
        {
            try
            {

                    var table = __ConnectBD.tipoDocumento.Find(collection.tipoDocumentoId);
                    table.nombreDocumento = collection.nombreDocumento;
                    table.tiempoRespuesta = collection.tiempoRes;
                    table.estado = collection.Estado;
                    __ConnectBD.Entry(table).State = System.Data.Entity.EntityState.Modified;
                    __ConnectBD.SaveChanges();

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
        [PermisosRol(new int[] { 1 })]
        public ActionResult Delete(int Id)
        {
            try
            {
                    var table = __ConnectBD.tipoDocumento.Find(Id);
                    __ConnectBD.tipoDocumento.Remove(table);
                    __ConnectBD.SaveChanges();
                return RedirectToAction("Index");
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