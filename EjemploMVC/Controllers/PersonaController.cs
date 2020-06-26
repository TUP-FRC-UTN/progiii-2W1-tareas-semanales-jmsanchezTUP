using EjemploMVC.AccesoDatos;
using EjemploMVC.Models;
using EjemploMVC.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace EjemploMVC.Controllers
{
    public class PersonaController : Controller
    {
        // GET: Persona
        public ActionResult DatosPersona(int idPersona)
        {
            List<SexoItemVM> listaSexos = AD_Persona.obtenerListaSexo();
            List<SelectListItem> itemsCombo = listaSexos.ConvertAll(d =>
            {
                return new SelectListItem()
                {
                    Text = d.Nombre,
                    Value = d.IdSexo.ToString(),
                    Selected = false
                };
            });

            Persona resultado = AD_Persona.obtenerPersona(idPersona);

            foreach (var item in itemsCombo)
            {
                if(item.Value.Equals(resultado.IdSexoPersona.ToString()))
                {
                    item.Selected = true;
                    break;
                }
            }

            ViewBag.itc = itemsCombo;
            
            ViewBag.NombrePersona = resultado.Nombre + " " + resultado.Apellido;
            return View(resultado);
        }

        [HttpPost]
        public ActionResult DatosPersona(Persona model)
        {
            if (ModelState.IsValid)
            {
                bool resultado = AD_Persona.actualizarPersona(model);

                if (resultado)
                {
                    return RedirectToAction("ListadoPersona", "Persona");
                }
                else
                {
                    return View(model);
                }
            }

            return View();
            
        }

        public ActionResult AltaPersona()
        {
            List<SexoItemVM> listaSexos = AD_Persona.obtenerListaSexo();
            List<SelectListItem> items = listaSexos.ConvertAll(d =>
            {
                return new SelectListItem()
                {
                    Text = d.Nombre,
                    Value = d.IdSexo.ToString(),
                    Selected = false
                };
            });

            ViewBag.it = items;

            return View();
        }

        public ActionResult ErrorAlta()
        {
            return View();
        }

        [HttpPost]
        public ActionResult AltaPersona(Persona model)
        {
            if (ModelState.IsValid)
            {
                bool resultado = AD_Persona.insertarNuevaPersona(model);
                
                if (resultado)
                {
                   return RedirectToAction("ListadoPersona", "Persona");
                }
                else
                {
                    return View(model);
                }
                
            }
            else
            {
                //return View(model);
                return RedirectToAction("ErrorAlta", "Persona");
            }
        }
        public ActionResult EliminarPersona(int idPersona)
        {
            Persona resultado = AD_Persona.obtenerPersona(idPersona);
            return View(resultado);
        }

        [HttpPost]
        public ActionResult EliminarPersona(Persona model)
        {
            if (ModelState.IsValid)
            {
                bool resultado = AD_Persona.eliminarPersona(model);

                if (resultado)
                {
                    return RedirectToAction("ListadoPersona", "Persona");
                }
                else
                {
                    return View(model);
                }
            }

            return View();
        }
        public ActionResult ListadoPersona()
        {
            List<Persona> lista = AD_Persona.obtenerListaPersona();
            return View(lista);
        }
    }
}