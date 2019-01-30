using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;
using System.Web.Http.Description;
using SincoApi.Persistencia;

namespace SincoApi.Controllers
{
    public class MateriaController : ApiController
    {
        private SINCOABREntities1 db = new SINCOABREntities1();

        // GET: api/Materia
        public IQueryable<MATERIAS> GetMATERIA()
        {
            return db.MATERIAS;
        }

        // GET: api/Materia/5
        [ResponseType(typeof(MATERIA))]
        public IHttpActionResult GetMATERIA(int id)
        {
            MATERIA mATERIA = db.MATERIA.Find(id);
            if (mATERIA == null)
            {
                return NotFound();
            }

            return Ok(mATERIA);
        }

        // PUT: api/Materia/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutMATERIA(int id, MATERIA mATERIA)
        {
            if (db.MATERIA.Any(mat => mat.ID_MATERIA == mATERIA.ID_MATERIA))
            {
                MATERIA materia = db.MATERIA.Find(id);
                materia.NOMBRE = mATERIA.NOMBRE;
                materia.DESCRIPCION = mATERIA.DESCRIPCION;
                db.SaveChanges();
                return StatusCode(HttpStatusCode.NoContent);
            }
            return NotFound();
        }

        // POST: api/Materia
        [ResponseType(typeof(MATERIA))]
        public IHttpActionResult PostMATERIA(MATERIA mATERIA)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (!db.MATERIA.Any(ma => ma.ID_MATERIA == mATERIA.ID_MATERIA))
            {
                db.MATERIA.Add(mATERIA);
                db.SaveChanges();
            }

            return CreatedAtRoute("DefaultApi", new { id = mATERIA.ID_MATERIA }, mATERIA);
        }

        // DELETE: api/Materia/5
        [ResponseType(typeof(MATERIA))]
        public IHttpActionResult DeleteMATERIA(int id)
        {
            MATERIA mATERIA = db.MATERIA.Find(id);
            if (mATERIA == null)
            {
                return NotFound();
            }

            db.MATERIA.Remove(mATERIA);
            db.SaveChanges();

            return Ok(mATERIA);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool MATERIAExists(int id)
        {
            return db.MATERIA.Count(e => e.ID_MATERIA == id) > 0;
        }
    }
}