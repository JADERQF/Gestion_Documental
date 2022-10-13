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
                             MunicipioId = x.Id_Municipio,
                             Estado = x.estado
                         }
                         ).ToList();
            }
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
        public ActionResult Status(int Id)
        {
            try
            {    using (proyecto_radicadoEntities1 db = new proyecto_radicadoEntities1())
                {
                    var lista = db.sede.Find(Id).estado; //
                    if (!lista == true)
                    {
                        lista = true;
                    }
                    else { lista = false; }

                    var table = db.sede.Find(Id); //Encuentra el registro a editar
                    table.estado = lista;
                    db.Entry(table).State = System.Data.Entity.EntityState.Modified; //guarda cambios
                    db.SaveChanges();//confirma cambios
                }
                return View ("Index");
            }
            catch (Exception ex)
            {
                return View ("Error");  
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
                List<ListViewMunicipio> lst = null;
                ListViewSede model = new ListViewSede();
                using (proyecto_radicadoEntities1 bd = new proyecto_radicadoEntities1())
                {   
                    var table = bd.sede.Find(id); //encuentra el id del registro
                    model.SedeId = table.IdSede;
                    model.SedeName = table.nombreSede;
                    model.MunicipioId = table.Id_Municipio;
                    lst =
                            (from t in bd.municipio
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
                            Selected = t.Id==model.MunicipioId  //valor por defecto del select
                        };
                    });

                    ViewBag.items = items; //variable contiene los valores del select
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
                    var table = db.sede.Find(collection.SedeId); //Encuentra el registro a editar
                    table.nombreSede = collection.SedeName; //Asigna valores al registro a editar
                    table.Id_Municipio = collection.MunicipioId;
                    table.IdSede = collection.SedeId;
                    db.Entry(table).State = System.Data.Entity.EntityState.Modified; //guarda cambios
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
