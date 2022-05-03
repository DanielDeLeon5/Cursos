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

namespace ExamenWebApi.Controllers
{
    public class CatedraticoesController : ApiController
    {
        private ExamenWebApiContext db = new ExamenWebApiContext();

        // GET: api/Catedraticoes
        public IQueryable<Catedratico> GetCatedraticoes()
        {
            return db.Catedraticoes;
        }

        // GET: api/Catedraticoes/5
        [ResponseType(typeof(Catedratico))]
        public async Task<IHttpActionResult> GetCatedratico(int id)
        {
            Catedratico catedratico = await db.Catedraticoes.FindAsync(id);
            if (catedratico == null)
            {
                return NotFound();
            }

            return Ok(catedratico);
        }

        // PUT: api/Catedraticoes/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutCatedratico(int id, Catedratico catedratico)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != catedratico.Id)
            {
                return BadRequest();
            }

            db.Entry(catedratico).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CatedraticoExists(id))
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

        // POST: api/Catedraticoes
        [ResponseType(typeof(Catedratico))]
        public async Task<IHttpActionResult> PostCatedratico(Catedratico catedratico)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Catedraticoes.Add(catedratico);
            await db.SaveChangesAsync();

            return CreatedAtRoute("DefaultApi", new { id = catedratico.Id }, catedratico);
        }

        // DELETE: api/Catedraticoes/5
        [ResponseType(typeof(Catedratico))]
        public async Task<IHttpActionResult> DeleteCatedratico(int id)
        {
            Catedratico catedratico = await db.Catedraticoes.FindAsync(id);
            if (catedratico == null)
            {
                return NotFound();
            }

            db.Catedraticoes.Remove(catedratico);
            await db.SaveChangesAsync();

            return Ok(catedratico);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool CatedraticoExists(int id)
        {
            return db.Catedraticoes.Count(e => e.Id == id) > 0;
        }
    }
}