using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Core.Objects;
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
    [RoutePrefix("api/Appointment")]
    public class AppointmentController : CustomApiController
    {
        private eHospitalNDCEntities db = new eHospitalNDCEntities();

        // GET: api/Appointment
        public IQueryable<tblSC_Appointment> GettblSC_Appointment()
        {
            return db.tblSC_Appointment;
        }

        public virtual ObjectResult<st_rptAppointmentList_Result> st_rptAppointmentList(Nullable<System.DateTime> fromDate, Nullable<System.DateTime> toDate, Nullable<int> branchID)
        {
            var fromDateParameter = fromDate.HasValue ?
                new ObjectParameter("fromDate", fromDate) :
                new ObjectParameter("fromDate", typeof(System.DateTime));

            var toDateParameter = toDate.HasValue ?
                new ObjectParameter("toDate", toDate) :
                new ObjectParameter("toDate", typeof(System.DateTime));

            var branchIDParameter = branchID.HasValue ?
                new ObjectParameter("BranchID", branchID) :
                new ObjectParameter("BranchID", typeof(int));

            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<st_rptAppointmentList_Result>("st_rptAppointmentList", fromDateParameter, toDateParameter, branchIDParameter);
        }

        // GET: api/Appointment/5
        [Route("{id:int}", Name = "get_GettblSC_Appointment")]
        public async Task<IHttpActionResult> GettblSC_Appointment(int id)
        {
            tblSC_Appointment tblSC_Appointment = await db.tblSC_Appointment.FindAsync(id);
            if (tblSC_Appointment == null)
            {
                return NotFound();
            }

            return Ok(tblSC_Appointment);
        }

        // PUT: api/Appointment/5
        [Route("{id:int}")]
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PuttblSC_Appointment(int id, tblSC_Appointment tblSC_Appointment)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != tblSC_Appointment.ID)
            {
                return BadRequest();
            }

            db.Entry(tblSC_Appointment).State = System.Data.Entity.EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
                return Ok(tblSC_Appointment);
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!tblSC_AppointmentExists(id))
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

        [Route("")]
        public IHttpActionResult Post_tblSC_Appointment(tblSC_Appointment tblSC_Appointment)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.tblSC_Appointment.Add(tblSC_Appointment);
            db.SaveChanges();

            return CreatedAtRoute("get_GettblSC_Appointment", new { id = tblSC_Appointment.ID },new { ID = tblSC_Appointment.ID });
        }

        [Route("{id:int}")]
        public async Task<IHttpActionResult> DeletetblSC_Appointment(int id)
        {
            tblSC_Appointment tblSC_Appointment = await db.tblSC_Appointment.FindAsync(id);
            if (tblSC_Appointment == null)
            {
                return NotFound();
            }

            db.tblSC_Appointment.Remove(tblSC_Appointment);
            await db.SaveChangesAsync();

            return StatusCode(HttpStatusCode.NoContent);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool tblSC_AppointmentExists(int id)
        {
            return db.tblSC_Appointment.Count(e => e.ID == id) > 0;
        }
    }
}