using GestionDocumental.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.UI.WebControls;

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
                    table.estado = true;
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
            try
            {
                ListViewArea model = new ListViewArea();
                using (proyecto_radicadoEntities1 bd = new proyecto_radicadoEntities1())
                {
                    var table = bd.area.Find(id); //encuentra el id del registro
                    model.Id_sede = table.IdArea;
                    model.Nombre_Area = table.nombreArea;
                    model.estado = table.estado;
                }
                return View(model); //Retorna los datos del registro seleccionado
            }
            catch (Exception ex)
            {
                //throw (ex);
                ModelState.AddModelError("", "Error" + ex);
                return View();
                throw;
            }
        }

        // POST: Area/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Editar(ListViewArea collection)
        {
            try
            {
                using (proyecto_radicadoEntities1 db = new proyecto_radicadoEntities1())
                {
                    var table = db.area.Find(collection.Id_sede);//Encuentra el registro a editar
                    table.nombreArea = collection.Nombre_Area;//Asigna valores al registro a editar
                    table.estado = collection.estado;//Asigna valores al registro a editar
                    db.Entry(table).State = System.Data.Entity.EntityState.Modified;//guarda cambios
                    db.SaveChanges();//confirma cambios
                }

                return Redirect("Index");
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

        // POST: Area/Delete/5
        [HttpGet]
        public ActionResult Delete(int Id)
        {
            try
            {
                using (proyecto_radicadoEntities1 db = new proyecto_radicadoEntities1())
                {
                    var table = db.area.Find(Id);
                    db.area.Remove(table);
                    db.SaveChanges();
                }
                return RedirectToAction("Index");
            }
            catch (Exception ex)    
            {
                //throw (ex);
                ModelState.AddModelError("", "Error" + ex);
                return View();
                throw;
            }
        }
    }
}
