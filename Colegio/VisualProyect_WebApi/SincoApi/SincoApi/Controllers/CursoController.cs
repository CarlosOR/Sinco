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
    public class CursoController : ApiController
    {
        private SINCOABREntities1 db = new SINCOABREntities1();

        // GET: api/Curso
        [Route("api/Curso")]
        [HttpGet]
        public IHttpActionResult GetCURSO()
        {
            return Ok(db.CURSOS);
        }
        // GET: api/CursoList
        [Route("api/Cursolist")]
        [HttpGet]
        public IHttpActionResult GetCURSOList()
        {
            return Ok(db.CURSOS_LIST);
        }
        // GET: api/Curso/5
        [Route("api/Curso")]
        [HttpGet]
        [ResponseType(typeof(CURSO))]
        public IHttpActionResult GetCURSO(int id)
        {
            CURSO cURSO = db.CURSO.Find(id);
            if (cURSO == null)
            {
                return NotFound();
            }

            return Ok(cURSO);
        }

        // PUT: api/Curso/5
        [Route("api/Curso")]
        [HttpPut]
        [ResponseType(typeof(void))]
        public IHttpActionResult PutCURSO(int id, CURSO cURSO)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != cURSO.ID_CURSO)
            {
                return BadRequest();
            }

            db.Entry(cURSO).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CURSOExists(id))
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

        // POST: api/Curso
        [Route("api/Curso")]
        [HttpPost]
        [ResponseType(typeof(CURSO))]
        public IHttpActionResult PostCURSO(CURSO cURSO)
        {
            if (db.CURSO.Any(cr => cr.ID_CURSO == cURSO.ID_CURSO))
            {
                return BadRequest(ModelState);
            }

            db.CURSO.Add(cURSO);
            db.SaveChanges();

            return Ok();
        }

        // DELETE: api/Curso/5
        [Route("api/Curso")]
        [HttpDelete]
        [ResponseType(typeof(CURSO))]
        public IHttpActionResult DeleteCURSO(int id)
        {
            CURSO cURSO = db.CURSO.Find(id);
            if (cURSO == null)
            {
                return NotFound();
            }

            db.CURSO.Remove(cURSO);
            db.SaveChanges();

            return Ok(cURSO);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool CURSOExists(int id)
        {
            return db.CURSO.Count(e => e.ID_CURSO == id) > 0;
        }
    }
}