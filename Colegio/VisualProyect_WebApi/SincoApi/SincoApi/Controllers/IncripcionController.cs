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
    public class IncripcionController : ApiController
    {
        private SINCOABREntities1 db = new SINCOABREntities1();

        // GET: api/Incripcion
        public IQueryable<INCRIPCIONES> GetINCRIPCION()
        {
            return db.INCRIPCIONES;
        }

        // GET: api/Incripcion/5
        [ResponseType(typeof(INCRIPCION))]
        public IHttpActionResult GetINCRIPCION(int id)
        {
            INCRIPCION iNCRIPCION = db.INCRIPCION.Find(id);
            if (iNCRIPCION == null)
            {
                return NotFound();
            }

            return Ok(iNCRIPCION);
        }

        // PUT: api/Incripcion/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutINCRIPCION(int id, INCRIPCION iNCRIPCION)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != iNCRIPCION.ID_INCRIPCION)
            {
                return BadRequest();
            }

            db.Entry(iNCRIPCION).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!INCRIPCIONExists(id))
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

        // POST: api/Incripcion
        [ResponseType(typeof(INCRIPCION))]
        public IHttpActionResult PostINCRIPCION(INCRIPCION iNCRIPCION)
        {
            if (!ModelState.IsValid || db.INCRIPCION.Any(ins => ins.ID_INCRIPCION == iNCRIPCION.ID_INCRIPCION))
            {
                return BadRequest(ModelState);
            }

            db.INCRIPCION.Add(iNCRIPCION);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = iNCRIPCION.ID_INCRIPCION }, iNCRIPCION);
        }

        // DELETE: api/Incripcion/5
        [ResponseType(typeof(INCRIPCION))]
        public IHttpActionResult DeleteINCRIPCION(int id)
        {
            INCRIPCION iNCRIPCION = db.INCRIPCION.Find(id);
            if (iNCRIPCION == null)
            {
                return NotFound();
            }

            db.INCRIPCION.Remove(iNCRIPCION);
            db.SaveChanges();

            return Ok(iNCRIPCION);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool INCRIPCIONExists(int id)
        {
            return db.INCRIPCION.Count(e => e.ID_INCRIPCION == id) > 0;
        }
    }
}