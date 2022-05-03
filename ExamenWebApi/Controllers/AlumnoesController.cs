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
    public class AlumnoesController : ApiController
    {
        private ExamenWebApiContext db = new ExamenWebApiContext();

        // GET: api/Alumnoes
        //public IQueryable<Alumno> GetAlumnoes()
        //{
        //    return db.Alumnoes;
        //}

        public IQueryable<AlumnoDto> GetAlumnos()
        {
            var alumnos = from a in db.Alumnoes
                         select new AlumnoDto()
                         {
                             Id = a.Id,
                             NombreAlumno = a.Nombre,
                             ApellidoAlumno = a.Apellido,
                             DPI = a.DPI,
                             Edad = a.Edad,
                             NombreCurso = a.Curso.Nombre
                         };
            return alumnos;
        }

        // GET: api/Alumnoes/5
        [ResponseType(typeof(Alumno))]
        public async Task<IHttpActionResult> GetAlumno(int id)
        {
            Alumno alumno = await db.Alumnoes.FindAsync(id);
            if (alumno == null)
            {
                return NotFound();
            }

            return Ok(alumno);
        }

        // PUT: api/Alumnoes/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutAlumno(int id, Alumno alumno)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != alumno.Id)
            {
                return BadRequest();
            }

            db.Entry(alumno).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AlumnoExists(id))
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

        // POST: api/Alumnoes
        [ResponseType(typeof(Alumno))]
        public async Task<IHttpActionResult> PostAlumno(Alumno alumno)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Alumnoes.Add(alumno);
            await db.SaveChangesAsync();

            return CreatedAtRoute("DefaultApi", new { id = alumno.Id }, alumno);
        }

        // DELETE: api/Alumnoes/5
        [ResponseType(typeof(Alumno))]
        public async Task<IHttpActionResult> DeleteAlumno(int id)
        {
            Alumno alumno = await db.Alumnoes.FindAsync(id);
            if (alumno == null)
            {
                return NotFound();
            }

            db.Alumnoes.Remove(alumno);
            await db.SaveChangesAsync();

            return Ok(alumno);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool AlumnoExists(int id)
        {
            return db.Alumnoes.Count(e => e.Id == id) > 0;
        }
    }
}