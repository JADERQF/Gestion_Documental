using GestionDocumental.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace GestionDocumental.Controllers
{
    public class SedeController : Controller
    {
        // GET: Sede
        public ActionResult Index()
        {
            List<ListViewSede> lista; //Crea un objeto de tipo ListViewSucursal
            using (proyecto_radicadoEntities1 db = new proyecto_radicadoEntities1()) //Instanciamos un obj de la bd
            {
                lista = (from x in db.sede
                         select new ListViewSede
                         {
                             SedeId = x.IdSede, //Asignamos valores a la lista
                             SedeName = x.nombreSede,
                             MunicipioId = x.Id_Municipio                         }
                         ).ToList();
            }
            return View(lista);
        }

        // GET: Sede/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Sede/Create
        [HttpPost]
        public ActionResult Create(ListViewSede collection)
        {
            try
            {
                // if(ModelState.IsValid) //Valida los dataNotation
                //{
                using (proyecto_radicadoEntities1 db = new proyecto_radicadoEntities1())
                {
                    var table = new sede();
                    table.nombreSede = collection.SedeName;
                    table.Id_Municipio = collection.MunicipioId;
                    table.estado = true; //Adecuar desde la BD
                    db.sede.Add(table);
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }
            }
            catch
            {
                return View();
            }
        }

        // GET: Sede/Edit/5
        public ActionResult Edit(int id)
        {
            try
            {
                ListViewSede model = new ListViewSede();
                using (proyecto_radicadoEntities1 bd = new proyecto_radicadoEntities1())
                {
                    var table = bd.sede.Find(id); //encuentra el id del registro
                    model.SedeId = table.IdSede;
                    model.SedeName = table.nombreSede;
                    model.MunicipioId = table.Id_Municipio;
                }
                return View(model); //Retorna los datos del registro seleccionado
            }
            catch (Exception ex)
            {
                throw (ex);
            }


        }
        // POST: Sede/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Editar(ListViewSede collection)
        {
            try
            {
                using (proyecto_radicadoEntities1 db = new proyecto_radicadoEntities1())
                {
                    //Console.WriteLine(string.Join(", ", collection));
                    var table = db.sede.Find(collection.SedeId);
                    table.nombreSede = collection.SedeName;
                    table.Id_Municipio = collection.MunicipioId;
                    table.IdSede = collection.SedeId;
                    db.Entry(table).State = System.Data.Entity.EntityState.Modified;
                    db.SaveChanges();
                }
                return Redirect("Index");
            }
            catch
            {
                return View();
            }
        }

        // POST: Sede/Delete/5
        [HttpGet]
        public ActionResult Delete(int Id)
        {
            try
            {
                using (proyecto_radicadoEntities1 db = new proyecto_radicadoEntities1())
                {
                    
                    var table = db.sede.Find(Id);
                    db.sede.Remove(table);
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
