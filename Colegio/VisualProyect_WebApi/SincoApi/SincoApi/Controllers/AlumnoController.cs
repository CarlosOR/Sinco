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
    public class AlumnoController : ApiController
    {
        private SINCOABREntities1 db = new SINCOABREntities1();

        // GET: api/Alumno
        public IQueryable<ALUMNOS> GetALUMNO()
        {
            return db.ALUMNOS;
        }

        // GET: api/Alumno/5
        [ResponseType(typeof(ALUMNO))]
        public IHttpActionResult GetALUMNO(string id)
        {
            ALUMNO aLUMNO = db.ALUMNO.Find(id);
            if (aLUMNO == null)
            {
                return NotFound();
            }

            return Ok(aLUMNO);
        }

        // PUT: api/Alumno/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutALUMNO(string id, ALUMNO aLUMNO)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != aLUMNO.ID_ALUMNO)
            {
                return BadRequest();
            }

            db.Entry(aLUMNO).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ALUMNOExists(id))
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

        // POST: api/Alumno
        [ResponseType(typeof(ALUMNO))]
        public IHttpActionResult PostALUMNO(ALUMNO aLUMNO)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.ALUMNO.Add(aLUMNO);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateException)
            {
                if (ALUMNOExists(aLUMNO.ID_ALUMNO))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = aLUMNO.ID_ALUMNO }, aLUMNO);
        }

        // DELETE: api/Alumno/5
        [ResponseType(typeof(ALUMNO))]
        public IHttpActionResult DeleteALUMNO(string id)
        {
            ALUMNO aLUMNO = db.ALUMNO.Find(id);
            if (aLUMNO == null)
            {
                return NotFound();
            }

            db.ALUMNO.Remove(aLUMNO);
            db.SaveChanges();

            return Ok(aLUMNO);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool ALUMNOExists(string id)
        {
            return db.ALUMNO.Count(e => e.ID_ALUMNO == id) > 0;
        }
    }
}