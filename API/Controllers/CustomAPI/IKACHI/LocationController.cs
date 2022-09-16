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
    [RoutePrefix("api/Location")]
    public class LocationController : CustomApiController
    {
        private eHospitalNDCEntities db = new eHospitalNDCEntities();

        // GET: api/Location
        public IQueryable<tblSC_Location> GettblSC_Location()
        {
            return db.tblSC_Location;
        }

        // GET: api/Location/5
        [ResponseType(typeof(tblSC_Location))]
        public IHttpActionResult GettblSC_Location(int id)
        {
            tblSC_Location tblSC_Location = db.tblSC_Location.Find(id);
            if (tblSC_Location == null)
            {
                return NotFound();
            }

            return Ok(tblSC_Location);
        }

        // PUT: api/Location/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PuttblSC_Location(int id, tblSC_Location tblSC_Location)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != tblSC_Location.LocationID)
            {
                return BadRequest();
            }

            db.Entry(tblSC_Location).State = System.Data.Entity.EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!tblSC_LocationExists(id))
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

        // POST: api/Location
        [ResponseType(typeof(tblSC_Location))]
        public IHttpActionResult PosttblSC_Location(tblSC_Location tblSC_Location)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.tblSC_Location.Add(tblSC_Location);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateException)
            {
                if (tblSC_LocationExists(tblSC_Location.LocationID))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = tblSC_Location.LocationID }, tblSC_Location);
        }

        // DELETE: api/Location/5
        [ResponseType(typeof(tblSC_Location))]
        public IHttpActionResult DeletetblSC_Location(int id)
        {
            tblSC_Location tblSC_Location = db.tblSC_Location.Find(id);
            if (tblSC_Location == null)
            {
                return NotFound();
            }

            db.tblSC_Location.Remove(tblSC_Location);
            db.SaveChanges();

            return Ok(tblSC_Location);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool tblSC_LocationExists(int id)
        {
            return db.tblSC_Location.Count(e => e.LocationID == id) > 0;
        }
    }
}