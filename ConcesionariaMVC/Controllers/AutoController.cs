using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ConcesionariaMVC.AccesoDatos;
using ConcesionariaMVC.Models;
using ConcesionariaMVC.ViewModels;

namespace ConcesionariaMVC.Controllers
{
    public class AutoController : Controller
    {
        // GET: Auto
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult ListaAutos()
        {
            List<Auto> listado = AD_Autos.listaAutos(); 

            return View(listado);
        }

        public ActionResult ListaPromociones()
        {
            List<Auto> promociones = AD_Autos.listaPromociones();


            return View(promociones);
        }

        public ActionResult AgregarNuevoAuto()
        {
            List<MarcaVM> listaMarcas = AD_Autos.listaMarcas();

            List<SelectListItem> items = listaMarcas.ConvertAll(d =>
            {
                return new SelectListItem()
                {
                    Text = d.Nombre,
                    Value = d.IdMarca.ToString(),
                    Selected = false
                };
            });

            ViewBag.marcas = items;

            return View();
        }

        [HttpPost]
        public ActionResult AgregarNuevoAuto(Auto model)
        {
            if (ModelState.IsValid)
            {
                Boolean resultado = AD_Autos.agregarNuevoAuto(model);

                if (resultado)
                {
                    return RedirectToAction("ListaAutos", "Auto");
                }
                else
                {
                    return View(model);
                }
            }

            return View();
            


           
        }
    }
}