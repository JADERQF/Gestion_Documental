﻿using GestionDocumental.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Mvc;


//David cambio el codigo
namespace GestionDocumental.Controllers
{
    public class PersonaController : Controller
    {
        proyecto_radicadoEntities1 __ConnectBD;

        public PersonaController()
        {
            __ConnectBD = new proyecto_radicadoEntities1();
        }

        // GET: Persona
        public ActionResult Index()
        {
            try
            {
                List<ListViewPersona> lista;

                lista = (from x in __ConnectBD.persona
                         select new ListViewPersona
                         {
                             IdPersona = x.IdPersona,
                             primerNombre = x.primerNombre,
                             segundoNombre = x.segundoNombre,
                             primerApellido = x.primerApellido,
                             segundoApellido = x.segundoApellido,
                             documento = x.documento,
                             estado = x.estado
                         }
                         ).ToList();
                return View(lista);
            }
            catch (Exception ex)
            {
                return View(ex.Message);
                throw;
            }
        }

        [HttpPost] //recibe datos por metodo POST

        public ActionResult login(FormCollection formCollection) //recibe un parámetro de tipo formulario
        {
            using (var db = new proyecto_radicadoEntities1()) //instanciamos un objeto de la db.
            {
                string usuario = formCollection["usuario"]; //guardo el valor de input usuario
                string pass = formCollection["pass"];       //guardo el valor de input pass
                //byte[] pass = Encoding.ASCII.GetBytes(pass1);       //guardo el valor de input pass


                var user = db.persona.FirstOrDefault(e => e.usuario == usuario && e.clave == pass);
                if (user != null)
                {
                    ViewBag.Message = "Bienvenido...";
                    return RedirectToAction("Index", "Home");
                }
                else
                {
                    //ViewBag.Message = "NO Entro";
                    return Login("Credenciales incorrectas");
                }


            }


            //string usuario = formCollection["usuario"]; //guardo el valor de input usuario
            //Byte[] clave = Encoding.Unicode.GetBytes(formCollection["pass"]);    
        }
        public ActionResult Login(string mensaje = " ")
        {
            ViewBag.Message = mensaje;
            return View();
        }

        public ActionResult Create()
        {
            try
            {
                List<ListViewArea> listArea;
                List<ListViewRol> listRol;
                List<ListViewSede> listSede;
                //Consulta Areas
                listArea = (from x in __ConnectBD.area
                            where x.estado == true
                            select new ListViewArea
                            {
                                Id_sede = x.IdArea,
                                Nombre_Area = x.nombreArea
                            }).ToList();
                //Consultar roles
                listRol = (from x in __ConnectBD.rol
                           select new ListViewRol
                           {
                               IdRol = x.IdRol,
                               nombreRol = x.nombreRol
                           }).ToList();

                //Consultar Sede
                listSede = (from x in __ConnectBD.sede
                            where x.estado ==true
                            select new ListViewSede
                            {
                                SedeId = x.IdSede,
                                SedeName = x.nombreSede
                            }).ToList();

                List<SelectListItem> itemsArea = listArea.ConvertAll(t =>
                {
                    return new SelectListItem()
                    {
                        Text = t.Nombre_Area.ToString(),
                        Value = t.Id_sede.ToString(),
                        Selected = false
                    };
                });

                List<SelectListItem> itemsSede = listSede.ConvertAll(t =>
                {
                    return new SelectListItem()
                    {
                        Text = t.SedeName.ToString(),
                        Value = t.SedeId.ToString(),
                        Selected = false
                    };
                });

                List<SelectListItem> itemsRol = listRol.ConvertAll(t =>
                {
                    return new SelectListItem()
                    {
                        Text = t.nombreRol.ToString(),
                        Value = t.IdRol.ToString(),
                        Selected = false
                    };
                });

                ViewBag.itemsSede = itemsSede;
                ViewBag.itemsRol = itemsRol;
                ViewBag.itemsArea = itemsArea;
                return View();
            }
            catch (Exception ex)
            {
                //throw (ex);
                ModelState.AddModelError("", "Error" + ex);
                return View();
                throw;
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(ListViewPersona collection)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var table = new persona();
                    table.primerNombre = collection.primerNombre;
                    table.segundoNombre = collection.segundoNombre;
                    table.primerApellido = collection.primerApellido;
                    table.segundoApellido = collection.segundoApellido;
                    table.documento = collection.documento;
                    table.telefono = collection.telefono;
                    table.usuario = collection.usuario;
                    table.clave = collection.clave;
                    table.estado = collection.estado;
                    table.Id_Area = collection.Id_Area;
                    table.Id_Rol = collection.Id_Rol;
                    table.Id_Sede = collection.Id_Sede;
                    __ConnectBD.persona.Add(table);
                    __ConnectBD.SaveChanges();
                    return RedirectToAction("Index");
                }

                List<ListViewArea> listArea;
                List<ListViewRol> listRol;
                List<ListViewSede> listSede;
                //Consulta Areas
                listArea = (from x in __ConnectBD.area
                            select new ListViewArea
                            {
                                Id_sede = x.IdArea,
                                Nombre_Area = x.nombreArea
                            }).ToList();
                //Consultar roles
                listRol = (from x in __ConnectBD.rol
                           select new ListViewRol
                           {
                               IdRol = x.IdRol,
                               nombreRol = x.nombreRol
                           }).ToList();

                //Consultar Sede
                listSede = (from x in __ConnectBD.sede
                            select new ListViewSede
                            {
                                SedeId = x.IdSede,
                                SedeName = x.nombreSede
                            }).ToList();

                List<SelectListItem> itemsArea = listArea.ConvertAll(t =>
                {
                    return new SelectListItem()
                    {
                        Text = t.Nombre_Area.ToString(),
                        Value = t.Id_sede.ToString(),
                        Selected = false
                    };
                });

                List<SelectListItem> itemsSede = listSede.ConvertAll(t =>
                {
                    return new SelectListItem()
                    {
                        Text = t.SedeName.ToString(),
                        Value = t.SedeId.ToString(),
                        Selected = false
                    };
                });

                List<SelectListItem> itemsRol = listRol.ConvertAll(t =>
                {
                    return new SelectListItem()
                    {
                        Text = t.nombreRol.ToString(),
                        Value = t.IdRol.ToString(),
                        Selected = false
                    };
                });

                ViewBag.itemsSede = itemsSede;
                ViewBag.itemsRol = itemsRol;
                ViewBag.itemsArea = itemsArea;
                return View();
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
                var table = __ConnectBD.persona.Find(Id);
                __ConnectBD.persona.Remove(table);
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

        public ActionResult Edit(int id)
        {
            try
            {
                List<ListViewSede> listSede = null;
                List<ListViewArea> listArea;
                List<ListViewRol> listRol;
                ListViewPersona model = new ListViewPersona();
                
                    var table = __ConnectBD.persona.Find(id); //encuentra el id del registro
                    model.IdPersona = table.IdPersona;
                    model.primerNombre = table.primerNombre;
                    model.segundoNombre = table.segundoNombre;
                    model.primerApellido = table.primerApellido;
                    model.segundoApellido = table.segundoApellido;
                    model.documento = table.documento;
                    model.telefono = table.telefono;
                    model.usuario = table.usuario;
                    model.clave = table.clave;
                    model.estado = table.estado;
                    model.Id_Area = table.Id_Area;
                    model.Id_Rol = table.Id_Rol;
                    model.Id_Sede = table.Id_Sede;

                //Consulta Areas
                listArea = (from x in __ConnectBD.area
                            select new ListViewArea
                            {
                                Id_sede = x.IdArea,
                                Nombre_Area = x.nombreArea
                            }).ToList();
                //Consultar roles
                listRol = (from x in __ConnectBD.rol
                           select new ListViewRol
                           {
                               IdRol = x.IdRol,
                               nombreRol = x.nombreRol
                           }).ToList();

                //Consultar Sede
                listSede = (from x in __ConnectBD.sede
                            select new ListViewSede
                            {
                                SedeId = x.IdSede,
                                SedeName = x.nombreSede
                            }).ToList();

                List<SelectListItem> itemsArea = listArea.ConvertAll(t =>
                {
                    return new SelectListItem()
                    {
                        Text = t.Nombre_Area.ToString(),
                        Value = t.Id_sede.ToString(),
                        Selected = t.Id_sede == model.Id_Sede
                    };
                });

                List<SelectListItem> itemsSede = listSede.ConvertAll(t =>
                {
                    return new SelectListItem()
                    {
                        Text = t.SedeName.ToString(),
                        Value = t.SedeId.ToString(),
                        Selected = t.SedeId ==model.Id_Sede
                    };
                });

                List<SelectListItem> itemsRol = listRol.ConvertAll(t =>
                {
                    return new SelectListItem()
                    {
                        Text = t.nombreRol.ToString(),
                        Value = t.IdRol.ToString(),
                        Selected = t.IdRol == model.Id_Rol
                    };
                });

                ViewBag.itemsSede = itemsSede;
                ViewBag.itemsRol = itemsRol;
                ViewBag.itemsArea = itemsArea;
                ViewBag.message = "Editar Persona";
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
        public ActionResult Update(ListViewPersona collection)
        {
            try
            {
                    //Console.WriteLine(string.Join(", ", collection));
                    var table = __ConnectBD.persona.Find(collection.IdPersona); //Encuentra el registro a editar
                    table.primerNombre = collection.primerNombre; //Asigna valores al registro a editar
                    table.segundoNombre = collection.segundoNombre;
                    table.primerApellido = collection.primerApellido;
                    table.segundoApellido = collection.segundoApellido;
                    table.documento = collection.documento;
                    table.telefono = collection.telefono;
                    table.usuario = collection.usuario;
                    table.clave = collection.clave;
                    table.estado = collection.estado;
                    table.Id_Area = collection.Id_Area;
                    table.Id_Rol = collection.Id_Rol;
                    table.Id_Sede = collection.Id_Sede;
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
    }
}
