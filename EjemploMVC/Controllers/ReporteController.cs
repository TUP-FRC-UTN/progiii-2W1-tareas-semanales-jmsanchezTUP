using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using EjemploMVC.ViewModels.Reportes;

namespace EjemploMVC.Controllers
{
    public class ReporteController : Controller
    {
        // GET: Reporte
        public ActionResult Index()
        {
            InfoVM resultado = new InfoVM();

            return View(resultado);
        }
    }
}