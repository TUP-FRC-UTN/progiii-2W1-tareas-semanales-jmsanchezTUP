using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using EjemploMVC.AccesoDatos;

namespace EjemploMVC.ViewModels.Reportes
{
    public class InfoVM
    {
        public List<SexoItemVM> listaSexos { get; set; }
        public List<PersonaItemVM> listaPersonas { get; set; }

        public InfoVM()
        {
            listaSexos = new List<SexoItemVM>();
            listaPersonas = new List<PersonaItemVM>();
            cargarVariables();
        }

        private void cargarVariables()
        {
            listaSexos = AD_Reportes.obtenerCantidadPorSexo();
            listaPersonas = AD_Reportes.obtenerReportePersona();
        }
    }
}