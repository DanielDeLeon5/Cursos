using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ExamenWebApi.Models
{
    public class Catedratico
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public string DPI { get; set; }
        public string Especialidad { get; set; }
    }
}