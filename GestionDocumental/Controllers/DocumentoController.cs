using GestionDocumental.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace GestionDocumental.Controllers
{
    public class DocumentoController : Controller
    {
        proyecto_radicadoEntities1 __ConnectBD;
        // GET: Documento

        public DocumentoController()
        {
            __ConnectBD = new proyecto_radicadoEntities1();
        }
        public ActionResult Index()
        {
            List<ListViewDocumento> lista; //Crea un objeto de tipo ListViewDocumento

            lista = (from x in __ConnectBD.documento
                     select new ListViewDocumento
                     {
                         IdDocumento = x.IdDocumento,
                         fechaRadicado = x.fechaRadicado,
                         fechaDocumento = x.fechaDocumento,
                         fechaVence = x.fechaVence,
                         ubicacion = x.ubicacion,
                         Id_Persona = x.Id_Persona,
                         Id_TipoDocumento = x.Id_TipoDocumento,
                         Id_Estado = x.Id_Estado
                     }).ToList();
            return View(lista);   
        }
        public ActionResult Create()
        {
            try
            {
                List<ListViewPersona> listPersona;
                List<ListViewTipo> listTipo;
                List<ListViewEstado> listEstado;

                listPersona = (from x in __ConnectBD.persona
                               select new ListViewPersona
                               {
                                   IdPersona = x.IdPersona,
                                   primerNombre = x.primerNombre,
                                   segundoNombre = x.segundoNombre,
                                   primerApellido = x.primerApellido
                               }).ToList();

                listEstado = (from x in __ConnectBD.estado
                            select new ListViewEstado
                            {
                                IdEstado = x.IdEstado,
                                nombreEstado = x.nombreEstado
                            }).ToList();

                listTipo = (from x in __ConnectBD.tipoDocumento
                            where x.estado == true
                            select new ListViewTipo
                            {
                                tipoDocumentoId = x.IdTipoDocumento,
                                nombreDocumento = x.nombreDocumento
                            }).ToList();

                List<SelectListItem> itemsPersona = listPersona.ConvertAll(t =>
                {
                    return new SelectListItem()
                    {
                        Text = t.primerNombre.ToString(),
                        Value = t.IdPersona.ToString(),
                        Selected = false
                    };
                });

                List<SelectListItem> itemsTipo = listTipo.ConvertAll(t =>
                {
                    return new SelectListItem()
                    {
                        Text = t.nombreDocumento.ToString(),
                        Value = t.tipoDocumentoId.ToString(),
                        Selected = false
                    };
                });

                List<SelectListItem> itemsEstado = listEstado.ConvertAll(t =>
                {
                    return new SelectListItem()
                    {
                        Text = t.nombreEstado.ToString(),
                        Value = t.IdEstado.ToString(),
                        Selected = false
                    };
                });

                ViewBag.itemsPersona = itemsPersona;
                ViewBag.itemsEstado = itemsEstado;
                ViewBag.itemsTipo = itemsTipo;

                return View();
            }
            catch (Exception)
            {

                throw;
            }          
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(ListViewDocumento Collection)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    //var table = documento();
                    string result = Collection.archivo.FileName;
                    string RutaSitio = Server.MapPath("~/");
                    var table = new documento();
                    string PathArchivo = Path.Combine(RutaSitio + "/Files/"+result);
                    table.ubicacion = PathArchivo;
                    table.fechaRadicado = DateTime.Today;
                    table.fechaDocumento = Collection.fechaDocumento;
                    var table1 = __ConnectBD.tipoDocumento.Find(Collection.Id_TipoDocumento);
                    double TiempoRes = Convert.ToDouble(table1.tiempoRespuesta);
                    table.fechaVence = table.fechaRadicado.AddDays(TiempoRes);
                    table.Id_Persona = Collection.Id_Persona;
                    table.Id_TipoDocumento = Collection.Id_TipoDocumento;
                    table.Id_Estado = Collection.Id_Estado;
                    __ConnectBD.documento.Add(table);
                    __ConnectBD.SaveChanges();
                    Collection.archivo.SaveAs(PathArchivo);
                } else
                {
                    
                }
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