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
using System.Web.Http.Cors;
using System.Web.Http.Description;
using API.Controllers;
using API.Models;

namespace Ikachi_New_Server.Controllers
{
    [RoutePrefix("api/Introducer")]
    public class IntroducerController : CustomApiController
    {
        private eHospitalNDCEntities db = new eHospitalNDCEntities();

        // GET: api/Introducer
        public IQueryable<tblAL_Introducer> GettblAL_Introducer()
        {
            return db.tblAL_Introducer;
        }

        // GET: api/Introducer/5
        [ResponseType(typeof(tblAL_Introducer))]
        public async Task<IHttpActionResult> GettblAL_Introducer(int id)
        {
            tblAL_Introducer tblAL_Introducer = await db.tblAL_Introducer.FindAsync(id);
            if (tblAL_Introducer == null)
            {
                return NotFound();
            }

            return Ok(tblAL_Introducer);
        }

        // PUT: api/Introducer/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PuttblAL_Introducer(int id, tblAL_Introducer tblAL_Introducer)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != tblAL_Introducer.ID)
            {
                return BadRequest();
            }

            db.Entry(tblAL_Introducer).State = System.Data.Entity.EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!tblAL_IntroducerExists(id))
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

        // POST: api/Introducer
        [ResponseType(typeof(tblAL_Introducer))]
        public async Task<IHttpActionResult> PosttblAL_Introducer(tblAL_Introducer tblAL_Introducer)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.tblAL_Introducer.Add(tblAL_Introducer);
            await db.SaveChangesAsync();

            return CreatedAtRoute("DefaultApi", new { id = tblAL_Introducer.ID }, tblAL_Introducer);
        }

        // DELETE: api/Introducer/5
        [ResponseType(typeof(tblAL_Introducer))]
        public async Task<IHttpActionResult> DeletetblAL_Introducer(int id)
        {
            tblAL_Introducer tblAL_Introducer = await db.tblAL_Introducer.FindAsync(id);
            if (tblAL_Introducer == null)
            {
                return NotFound();
            }

            db.tblAL_Introducer.Remove(tblAL_Introducer);
            await db.SaveChangesAsync();

            return Ok(tblAL_Introducer);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool tblAL_IntroducerExists(int id)
        {
            return db.tblAL_Introducer.Count(e => e.ID == id) > 0;
        }
    }
}