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
    [RoutePrefix("api/Approval")]
    public class ApprovalController : CustomApiController
    {
        private eHospitalNDCEntities ikadb = new eHospitalNDCEntities();

        // GET: api/Approval
        public IHttpActionResult GettblUT_Approval()
        {
            List<tblUT_Approval> tblUT_Approval = ikadb.tblUT_Approval.ToList();
            return Ok(tblUT_Approval);
        }

        // GET: api/Approval/5
        [ResponseType(typeof(tblUT_Approval))]
        public IHttpActionResult GettblUT_Approval(int id)
        {
            tblUT_Approval tblUT_Approval = ikadb.tblUT_Approval.Find(id);
            if (tblUT_Approval == null)
            {
                return NotFound();
            }

            return Ok(tblUT_Approval);
        }

        // PUT: api/Approval/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PuttblUT_Approval(int id, tblUT_Approval tblUT_Approval)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != tblUT_Approval.ID)
            {
                return BadRequest();
            }

            ikadb.Entry(tblUT_Approval).State = System.Data.Entity.EntityState.Modified;

            try
            {
                ikadb.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!tblUT_ApprovalExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return Ok(tblUT_Approval);
        }

        // POST: api/Approval
        [ResponseType(typeof(tblUT_Approval))]
        public IHttpActionResult PosttblUT_Approval(tblUT_Approval tblUT_Approval)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            ikadb.tblUT_Approval.Add(tblUT_Approval);
            ikadb.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = tblUT_Approval.ID }, tblUT_Approval);
        }

        // DELETE: api/Approval/5
        [ResponseType(typeof(tblUT_Approval))]
        public IHttpActionResult DeletetblUT_Approval(int id)
        {
            tblUT_Approval tblUT_Approval = ikadb.tblUT_Approval.Find(id);
            if (tblUT_Approval == null)
            {
                return NotFound();
            }

            ikadb.tblUT_Approval.Remove(tblUT_Approval);
            ikadb.SaveChanges();

            return Ok(tblUT_Approval);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                ikadb.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool tblUT_ApprovalExists(int id)
        {
            return ikadb.tblUT_Approval.Count(e => e.ID == id) > 0;
        }
    }
}