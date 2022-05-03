using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Description;
using ExamenWebApi.Data;
using ExamenWebApi.Models;
using ExamenWebApi.Models.DTO;

namespace ExamenWebApi.Controllers
{
    public class CursoesController : ApiController
    {
        private ExamenWebApiContext db = new ExamenWebApiContext();

        //// GET: api/Cursoes
        //public IQueryable<Curso> GetCursoes()
        //{
        //    return db.Cursoes;
        //}

        public IQueryable<CursoDto> GetLibros()
        {
            var cursos = from c in db.Cursoes
                         select new CursoDto()
                         {
                             Id = c.Id,
                             NombreCatedratico = c.Catedratico.Nombre + " " + c.Catedratico.Apellido,
                             NombreCurso = c.Nombre,
                             Categoria = c.Categoria,
                             Descripcion = c.Descripcion
                         };
            return cursos;
        }

        // GET: api/Cursoes/5
        [ResponseType(typeof(Curso))]
        public async Task<IHttpActionResult> GetCurso(int id)
        {
            Curso curso = await db.Cursoes.FindAsync(id);
            if (curso == null)
            {
                return NotFound();
            }

            return Ok(curso);
        }

        // PUT: api/Cursoes/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutCurso(int id, Curso curso)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != curso.Id)
            {
                return BadRequest();
            }

            db.Entry(curso).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CursoExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return StatusCode(HttpStatusCode.NoContent);
        }

        // POST: api/Cursoes
        [ResponseType(typeof(Curso))]
        public async Task<IHttpActionResult> PostCurso(Curso curso)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Cursoes.Add(curso);
            await db.SaveChangesAsync();

            return CreatedAtRoute("DefaultApi", new { id = curso.Id }, curso);
        }

        // DELETE: api/Cursoes/5
        [ResponseType(typeof(Curso))]
        public async Task<IHttpActionResult> DeleteCurso(int id)
        {
            Curso curso = await db.Cursoes.FindAsync(id);
            if (curso == null)
            {
                return NotFound();
            }

            db.Cursoes.Remove(curso);
            await db.SaveChangesAsync();

            return Ok(curso);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool CursoExists(int id)
        {
            return db.Cursoes.Count(e => e.Id == id) > 0;
        }
    }
}