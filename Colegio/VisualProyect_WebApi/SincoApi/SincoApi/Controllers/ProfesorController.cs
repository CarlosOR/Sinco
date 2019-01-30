using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using SincoApi.Persistencia;

namespace SincoApi.Controllers
{
    public class ProfesorController : ApiController
    {
        private SINCOABREntities1 db = new SINCOABREntities1();

        // GET: api/Profesor
        public IQueryable<PROFESORES> GetPROFESOR()
        {
            return db.PROFESORES;
        }

        // GET: api/Profesor/5
        [ResponseType(typeof(PROFESOR))]
        public IHttpActionResult GetPROFESOR(string id)
        {
            PROFESOR pROFESOR = db.PROFESOR.Find(id);
            if (pROFESOR == null)
            {
                return NotFound();
            }

            return Ok(pROFESOR);
        }

        // PUT: api/Profesor/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutPROFESOR(string id, PROFESOR pROFESOR)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != pROFESOR.ID_PROFESOR)
            {
                return BadRequest();
            }

            db.Entry(pROFESOR).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PROFESORExists(id))
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

        // POST: api/Profesor
        [ResponseType(typeof(PROFESOR))]
        public IHttpActionResult PostPROFESOR(PROFESOR pROFESOR)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.PROFESOR.Add(pROFESOR);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateException)
            {
                if (PROFESORExists(pROFESOR.ID_PROFESOR))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = pROFESOR.ID_PROFESOR }, pROFESOR);
        }

        // DELETE: api/Profesor/5
        [ResponseType(typeof(PROFESOR))]
        public IHttpActionResult DeletePROFESOR(string id)
        {
            PROFESOR pROFESOR = db.PROFESOR.Find(id);
            if (pROFESOR == null)
            {
                return NotFound();
            }

            db.PROFESOR.Remove(pROFESOR);
            db.SaveChanges();

            return Ok(pROFESOR);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool PROFESORExists(string id)
        {
            return db.PROFESOR.Count(e => e.ID_PROFESOR == id) > 0;
        }
    }
}