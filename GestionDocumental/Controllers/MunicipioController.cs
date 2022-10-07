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
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("List");
            }
            catch
            {
                return View();
            }
        }

        // GET: Sucursal/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Sucursal/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Sucursal/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Sucursal/Delete/5
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
