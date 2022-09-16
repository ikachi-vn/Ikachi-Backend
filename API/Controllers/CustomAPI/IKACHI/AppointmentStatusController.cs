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
    [RoutePrefix("api/AppointmentStatus")]
    public class AppointmentStatusController : CustomApiController
    {
        private eHospitalNDCEntities db = new eHospitalNDCEntities();

        // GET: api/AppointmentStatus
        public IQueryable<tblSC_AppointmentStatus> GettblSC_AppointmentStatus()
        {
            return db.tblSC_AppointmentStatus;
        }

        // GET: api/AppointmentStatus/5
        [ResponseType(typeof(tblSC_AppointmentStatus))]
        public IHttpActionResult GettblSC_AppointmentStatus(byte id)
        {
            tblSC_AppointmentStatus tblSC_AppointmentStatus = db.tblSC_AppointmentStatus.Find(id);
            if (tblSC_AppointmentStatus == null)
            {
                return NotFound();
            }

            return Ok(tblSC_AppointmentStatus);
        }

        // PUT: api/AppointmentStatus/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PuttblSC_AppointmentStatus(byte id, tblSC_AppointmentStatus tblSC_AppointmentStatus)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != tblSC_AppointmentStatus.ID)
            {
                return BadRequest();
            }

            db.Entry(tblSC_AppointmentStatus).State = System.Data.Entity.EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!tblSC_AppointmentStatusExists(id))
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

        // POST: api/AppointmentStatus
        [ResponseType(typeof(tblSC_AppointmentStatus))]
        public IHttpActionResult PosttblSC_AppointmentStatus(tblSC_AppointmentStatus tblSC_AppointmentStatus)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.tblSC_AppointmentStatus.Add(tblSC_AppointmentStatus);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateException)
            {
                if (tblSC_AppointmentStatusExists(tblSC_AppointmentStatus.ID))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = tblSC_AppointmentStatus.ID }, tblSC_AppointmentStatus);
        }

        // DELETE: api/AppointmentStatus/5
        [ResponseType(typeof(tblSC_AppointmentStatus))]
        public IHttpActionResult DeletetblSC_AppointmentStatus(byte id)
        {
            tblSC_AppointmentStatus tblSC_AppointmentStatus = db.tblSC_AppointmentStatus.Find(id);
            if (tblSC_AppointmentStatus == null)
            {
                return NotFound();
            }

            db.tblSC_AppointmentStatus.Remove(tblSC_AppointmentStatus);
            db.SaveChanges();

            return Ok(tblSC_AppointmentStatus);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool tblSC_AppointmentStatusExists(byte id)
        {
            return db.tblSC_AppointmentStatus.Count(e => e.ID == id) > 0;
        }
    }
}