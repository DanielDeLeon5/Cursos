using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ExamenWebApi.Models.DTO
{
    public class CursoDto
    {
        public int Id { get; set; }
        public string NombreCurso { get; set; }
        public string NombreCatedratico { get; set; }
        public string Categoria { get; set; }
        public string Descripcion { get; set; }
    }
}