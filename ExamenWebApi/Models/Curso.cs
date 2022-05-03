using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace ExamenWebApi.Models
{
    public class Curso
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Categoria { get; set; }
        public string Descripcion { get; set; }
        public int CatedraticoId { get; set; }

        [ForeignKey("CatedraticoId")]
        public Catedratico Catedratico { get; set; }
    }
}