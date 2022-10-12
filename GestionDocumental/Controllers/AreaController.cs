using GestionDocumental.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace GestionDocumental.Controllers
{
    public class AreaController : Controller
    {
        // GET: Area
        public ActionResult Index()
        {
            List<ListViewArea> lista; //Crea un objeto de tipo ListViewArea
            using (proyecto_radicadoEntities1 db = new proyecto_radicadoEntities1())
            {
                lista = (from x in db.area
                         select new ListViewArea
                         {
                             Id_sede = x.IdArea,
                             Nombre_Area = x.nombreArea
                         }
                         ).ToList();

            }
            return View(lista);
        }

        // GET: Area/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Area/Create
        [HttpPost]
        public ActionResult Create(ListViewArea collection)
        {
            try
            {
                using (proyecto_radicadoEntities1 db = new proyecto_radicadoEntities1())
                {
                    var table = new area();
                    table.nombreArea = collection.Nombre_Area;
                    //table.estado = true;
                    db.area.Add(table);
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }                
            }
            catch (Exception ex)
            {
                //throw (ex);
                ModelState.AddModelError("", "Error" + ex);
                return View();
                throw;
            }
        }

        // GET: Area/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Area/Edit/5

        public ActionResult Editar(int id)
        {
            try
            {
                ListViewArea lista = new ListViewArea();
                using (proyecto_radicadoEntities1 bd = new proyecto_radicadoEntities1())
                {
                    var table = bd.area.Find(id);
                    lista.Nombre_Area = table.nombreArea;
                    lista.estado = table.estado;
                }

                return View(lista);
            }
            catch (Exception ex) 
            {
                //throw (ex);
                ModelState.AddModelError("", "Error" + ex);
                return View();
                throw;
            }
        }

        // GET: Area/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Area/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
