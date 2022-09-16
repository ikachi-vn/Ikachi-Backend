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
    [RoutePrefix("api/Resources")]
    public class ResourcesController : CustomApiController
    {
        private eHospitalNDCEntities db = new eHospitalNDCEntities();

        // GET: api/MemoTemplate
        public IQueryable<vwSC_Resources> GetvwSC_Resources()
        {
            return db.vwSC_Resources;
        }

        // GET: api/MemoTemplate/5
        [ResponseType(typeof(vwSC_Resources))]
        public async Task<IHttpActionResult> GetvwSC_Resources(int id)
        {
            vwSC_Resources vwSC_Resources = await db.vwSC_Resources.FindAsync(id);
            if (vwSC_Resources == null)
            {
                return NotFound();
            }

            return Ok(vwSC_Resources);
        }



        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

    }
}