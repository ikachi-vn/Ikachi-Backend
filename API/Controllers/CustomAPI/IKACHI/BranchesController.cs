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
    [RoutePrefix("api/Branches")]
    public class BranchesController : CustomApiController
    {
        private eHospitalNDCEntities db = new eHospitalNDCEntities();

        // GET: api/Branches
        public IQueryable<API_Branches> GetAPI_Branches()
        {
            return db.API_Branches;
        }

        // GET: api/Branches/5
        [ResponseType(typeof(API_Branches))]
        public async Task<IHttpActionResult> GetAPI_Branches(int id)
        {
            API_Branches aPI_Branches = await db.API_Branches.FindAsync(id);
            if (aPI_Branches == null)
            {
                return NotFound();
            }

            return Ok(aPI_Branches);
        }

        // PUT: api/Branches/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutAPI_Branches(int id, API_Branches aPI_Branches)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != aPI_Branches.ID)
            {
                return BadRequest();
            }

            db.Entry(aPI_Branches).State = System.Data.Entity.EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!API_BranchesExists(id))
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

        // POST: api/Branches
        [ResponseType(typeof(API_Branches))]
        public async Task<IHttpActionResult> PostAPI_Branches(API_Branches aPI_Branches)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.API_Branches.Add(aPI_Branches);

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (API_BranchesExists(aPI_Branches.ID))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = aPI_Branches.ID }, aPI_Branches);
        }

        // DELETE: api/Branches/5
        [ResponseType(typeof(API_Branches))]
        public async Task<IHttpActionResult> DeleteAPI_Branches(int id)
        {
            API_Branches aPI_Branches = await db.API_Branches.FindAsync(id);
            if (aPI_Branches == null)
            {
                return NotFound();
            }

            db.API_Branches.Remove(aPI_Branches);
            await db.SaveChangesAsync();

            return Ok(aPI_Branches);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool API_BranchesExists(int id)
        {
            return db.API_Branches.Count(e => e.ID == id) > 0;
        }
    }
}