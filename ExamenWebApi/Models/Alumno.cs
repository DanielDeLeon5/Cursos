using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace ExamenWebApi.Models
{
    public class Alumno
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public string DPI { get; set; }
        public int Edad { get; set; }
        public int CursoId { get; set; }

        [ForeignKey("CursoId")]
        public Curso Curso { get; set; }
    }
}