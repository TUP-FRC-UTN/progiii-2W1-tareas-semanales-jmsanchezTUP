using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ConcesionariaMVC.Models
{
    public class Auto
    {
        public int IdAuto { get; set; }
        [Required]
        public string Patente { get; set; }

        [Required]
        public int IdMarca { get; set; }

        [Required]
        public int Kilometros { get; set; }

        [Required]
        public Boolean Promocion { get; set; }

        [Required]
        public float Precio { get; set; }
    }
}