using GestionDocumental.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace GestionDocumental.Controllers
{
    public class MunicipioController : Controller
    {
        public ActionResult Index()
        {
            List<ListViewMunicipio> lista;
            using (proyecto_radicadoEntities1 db = new proyecto_radicadoEntities1())
            {
                lista = (from x in db.municipio
                         select new ListViewMunicipio
                         {
                             Id = x.IdMunicipio,
                             NombreMunicipio = x.nombreMunicipio
                         }).ToList();
            }
            return View(lista);
        }
        // GET: Sucursal
        public ActionResult List()
        {
            List<ListViewMunicipio> lista; //Crea un objeto de tipo ListViewSucursal
            using (proyecto_radicadoEntities1 db = new proyecto_radicadoEntities1()) //Instanciamos un obj de la bd
            {
                lista = (from x in db.municipio
                            select new ListViewMunicipio
                            {
                                Id = x.IdMunicipio,
                                NombreMunicipio = x.nombreMunicipio
                            }
                         ).ToList();
            }
            return View(lista);
        }
     
        // POST: Sucursal/Create
        [HttpPost]
        public ActionResult Create(ListViewMunicipio collection)
        {
            try
            {
                using (proyecto_radicadoEntities1 db = new proyecto_radicadoEntities1())
                {
                    var table = new municipio();
                    table.IdMunicipio = collection.Id;
                    table.nombreMunicipio = collection.NombreMunicipio;
                    db.municipio.Add(table);
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }
            }
            catch
            {
                return View();
            }
        }

        // GET: Sucursal/Edit/5
        public ActionResult Edit(int id)
        {
            try
            {
                ListViewMunicipio model = new ListViewMunicipio();
                using (proyecto_radicadoEntities1 db = new proyecto_radicadoEntities1())
                {
                    var table = db.municipio.Find(id);
                    model.Id = table.IdMunicipio;
                    model.NombreMunicipio = table.nombreMunicipio;
                }
                return View(model);
            }
            catch (Exception ex)
            {

                throw(ex);
            }
        }

        // POST: Sucursal/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(ListViewMunicipio collection)
        {
            try
            {
                using (proyecto_radicadoEntities1 db = new proyecto_radicadoEntities1())
                {
                    var table = db.municipio.Find(collection.Id);
                    table.IdMunicipio = collection.Id;
                    table.nombreMunicipio = collection.NombreMunicipio;
                    db.Entry(table).State = System.Data.Entity.EntityState.Modified;
                    db.SaveChanges();
                }
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Sucursal/Delete/5
        [HttpGet]
        public ActionResult Delete(int id)
        {
            try
            {
                using (proyecto_radicadoEntities1 db = new proyecto_radicadoEntities1())
                {
                    var table = db.municipio.Find(id);
                    db.municipio.Remove(table);
                    db.SaveChanges();
                }
                return View("Index");
            }
            catch (Exception ex)
            {

                throw(ex);
            }
        }
    }
}
