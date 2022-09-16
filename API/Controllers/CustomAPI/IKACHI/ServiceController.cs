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
    [RoutePrefix("api/Service")]
    public class ServiceController : CustomApiController
    {
        private eHospitalNDCEntities db = new eHospitalNDCEntities();

        // GET: api/Service
        public IQueryable<tblSC_Service> GettblSC_Service()
        {
            return db.tblSC_Service;
        }

        // GET: api/Service/5
        [ResponseType(typeof(tblSC_Service))]
        public IHttpActionResult GettblSC_Service(int id)
        {
            tblSC_Service tblSC_Service = db.tblSC_Service.Find(id);
            if (tblSC_Service == null)
            {
                return NotFound();
            }

            return Ok(tblSC_Service);
        }

        // PUT: api/Service/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PuttblSC_Service(int id, tblSC_Service tblSC_Service)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != tblSC_Service.ServiceID)
            {
                return BadRequest();
            }

            db.Entry(tblSC_Service).State = System.Data.Entity.EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!tblSC_ServiceExists(id))
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

        // POST: api/Service
        [ResponseType(typeof(tblSC_Service))]
        public IHttpActionResult PosttblSC_Service(tblSC_Service tblSC_Service)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.tblSC_Service.Add(tblSC_Service);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateException)
            {
                if (tblSC_ServiceExists(tblSC_Service.ServiceID))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = tblSC_Service.ServiceID }, tblSC_Service);
        }

        // DELETE: api/Service/5
        [ResponseType(typeof(tblSC_Service))]
        public IHttpActionResult DeletetblSC_Service(int id)
        {
            tblSC_Service tblSC_Service = db.tblSC_Service.Find(id);
            if (tblSC_Service == null)
            {
                return NotFound();
            }

            db.tblSC_Service.Remove(tblSC_Service);
            db.SaveChanges();

            return Ok(tblSC_Service);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool tblSC_ServiceExists(int id)
        {
            return db.tblSC_Service.Count(e => e.ServiceID == id) > 0;
        }
    }
}