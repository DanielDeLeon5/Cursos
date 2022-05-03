using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ExamenWebApi.Models.DTO
{
    public class AlumnoDto
    {
        public int Id { get; set; }
        public string NombreAlumno { get; set; }
        public string ApellidoAlumno { get; set; }
        public string DPI { get; set; }
        public int Edad { get; set; }
        public string NombreCurso { get; set; }
    }
}