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
using API.Controllers;
using API.Models;

namespace Ikachi_New_Server.Controllers
{
    [RoutePrefix("api/Subject")]
    public class SubjectController : CustomApiController
    {
        private eHospitalNDCEntities db = new eHospitalNDCEntities();

        // GET: api/Subject
        public IQueryable<tblSC_Subject> GettblSC_Subject()
        {
            return db.tblSC_Subject;
        }

        // GET: api/Subject/5
        [ResponseType(typeof(tblSC_Subject))]
        public IHttpActionResult GettblSC_Subject(int id)
        {
            tblSC_Subject tblSC_Subject = db.tblSC_Subject.Find(id);
            if (tblSC_Subject == null)
            {
                return NotFound();
            }

            return Ok(tblSC_Subject);
        }

        // PUT: api/Subject/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PuttblSC_Subject(int id, tblSC_Subject tblSC_Subject)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != tblSC_Subject.SubjectID)
            {
                return BadRequest();
            }

            db.Entry(tblSC_Subject).State = System.Data.Entity.EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!tblSC_SubjectExists(id))
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

        // POST: api/Subject
        [ResponseType(typeof(tblSC_Subject))]
        public IHttpActionResult PosttblSC_Subject(tblSC_Subject tblSC_Subject)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.tblSC_Subject.Add(tblSC_Subject);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateException)
            {
                if (tblSC_SubjectExists(tblSC_Subject.SubjectID))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = tblSC_Subject.SubjectID }, tblSC_Subject);
        }

        // DELETE: api/Subject/5
        [ResponseType(typeof(tblSC_Subject))]
        public IHttpActionResult DeletetblSC_Subject(int id)
        {
            tblSC_Subject tblSC_Subject = db.tblSC_Subject.Find(id);
            if (tblSC_Subject == null)
            {
                return NotFound();
            }

            db.tblSC_Subject.Remove(tblSC_Subject);
            db.SaveChanges();

            return Ok(tblSC_Subject);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool tblSC_SubjectExists(int id)
        {
            return db.tblSC_Subject.Count(e => e.SubjectID == id) > 0;
        }
    }
}