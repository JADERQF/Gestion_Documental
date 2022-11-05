using GestionDocumental.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace GestionDocumental.Controllers
{
    public class SedeController : Controller
    {
        proyecto_radicadoEntities1 __ConnectBD;

        public SedeController()
        {
            __ConnectBD = new proyecto_radicadoEntities1();
        }
        // GET: Sede
        public ActionResult Index()
        {
            List<ListViewSede> lista; //Crea un objeto de tipo ListViewSucursal

            lista = (from x in __ConnectBD.sede
                     select new ListViewSede
                     {
                         SedeId = x.IdSede, //Asignamos valores a la lista
                         SedeName = x.nombreSede,
                         MunicipioId = x.Id_Municipio,
                         Estado = x.estado
                     }
                     ).ToList();
            return View(lista);
        }
        public static string NombreMunicipio(int Id)
        {
            using (proyecto_radicadoEntities1 db = new proyecto_radicadoEntities1())
            {
                return db.municipio.Find(Id).nombreMunicipio; //Retorna el nombre de la ciudad
            }
        }

        [HttpGet]
        public ActionResult prueba(int Id)
        {
            return View("Index");
        }

        [HttpGet]
        public ActionResult Estado(int Id)
        {
            try
            {
                var lista = __ConnectBD.sede.Find(Id).estado; //
                if (!lista == true)
                {
                    lista = true;
                }
                else
                {
                    lista = false;
                }

                var table = __ConnectBD.sede.Find(Id); //Encuentra el registro a editar
                table.estado = lista;
                __ConnectBD.Entry(table).State = System.Data.Entity.EntityState.Modified; //guarda cambios
                __ConnectBD.SaveChanges();//confirma cambios

                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                return View("Error" + ex);
            }
        }
        // GET: Sede/Create
        public ActionResult Create()
        {
            try
            {
                List<ListViewMunicipio> lst = null;
                using (proyecto_radicadoEntities1 db = new proyecto_radicadoEntities1())
                {
                    lst =
                        (from t in db.municipio
                         select new ListViewMunicipio
                         {
                             Id = t.IdMunicipio,
                             NombreMunicipio = t.nombreMunicipio
                         }).ToList();
                }

                List<SelectListItem> items = lst.ConvertAll(t =>
                {
                    return new SelectListItem()
                    {
                        Text = t.NombreMunicipio.ToString(), //Muestra el valor 
                        Value = t.Id.ToString(), //Valor del Id del registro
                        Selected = false  //valor por defecto del select
                    };
                });

                ViewBag.items = items; //variable contiene los valores del select
                return View();
            }
            catch (Exception ex)
            {

                throw (ex);
            }
        }

        // POST: Sede/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(ListViewSede collection)
        {
            try
            {
                if (ModelState.IsValid)
                {
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
                List<ListViewMunicipio> lst = null;
                using (proyecto_radicadoEntities1 db = new proyecto_radicadoEntities1())
                {
                    lst =
                        (from t in db.municipio
                         select new ListViewMunicipio
                         {
                             Id = t.IdMunicipio,
                             NombreMunicipio = t.nombreMunicipio
                         }).ToList();
                }

                List<SelectListItem> items = lst.ConvertAll(t =>
                {
                    return new SelectListItem()
                    {
                        Text = t.NombreMunicipio.ToString(),
                        Value = t.Id.ToString(),
                        Selected = false
                    };
                });

                ViewBag.items = items;
                return View();
            }
            catch (Exception ex)
            {   //throw (ex);
                ModelState.AddModelError("", "Error" + ex);
                return View();
                throw;
            }
        }

        // GET: Sede/Edit/5
        public ActionResult Edit(int id)
        {
            try
            {
                List<ListViewMunicipio> lst = null;
                ListViewSede model = new ListViewSede();
                var table = __ConnectBD.sede.Find(id); //encuentra el id del registro
                model.SedeId = table.IdSede;
                model.SedeName = table.nombreSede;
                model.MunicipioId = table.Id_Municipio;
                lst =
                        (from t in __ConnectBD.municipio
                         select new ListViewMunicipio
                         {
                             Id = t.IdMunicipio,
                             NombreMunicipio = t.nombreMunicipio
                         }).ToList();

                List<SelectListItem> items = lst.ConvertAll(t =>
                {
                    return new SelectListItem()
                    {
                        Text = t.NombreMunicipio.ToString(), //Muestra el valor 
                            Value = t.Id.ToString(), //Valor del Id del registro
                            Selected = t.Id == model.MunicipioId  //valor por defecto del select
                        };
                });

                ViewBag.items = items; //variable contiene los valores del select
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
                //Console.WriteLine(string.Join(", ", collection));
                var table = __ConnectBD.sede.Find(collection.SedeId); //Encuentra el registro a editar
                table.nombreSede = collection.SedeName; //Asigna valores al registro a editar
                table.Id_Municipio = collection.MunicipioId;
                table.IdSede = collection.SedeId;
                __ConnectBD.Entry(table).State = System.Data.Entity.EntityState.Modified; //guarda cambios
                __ConnectBD.SaveChanges();//confirma cambios
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

        // POST: Sede/Delete/5
        [HttpGet]
        public ActionResult Delete(int Id)
        {
            try
            {
                var table = __ConnectBD.sede.Find(Id);
                __ConnectBD.sede.Remove(table);
                __ConnectBD.SaveChanges();
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
