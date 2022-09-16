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
    [RoutePrefix("api/MemoTemplate")]
    public class MemoTemplateController : CustomApiController
    {
        private eHospitalNDCEntities db = new eHospitalNDCEntities();

        // GET: api/MemoTemplate
        public IQueryable<tblSC_MemoTemplate> GettblSC_MemoTemplate()
        {
            return db.tblSC_MemoTemplate;
        }

        // GET: api/MemoTemplate/5
        [ResponseType(typeof(tblSC_MemoTemplate))]
        public async Task<IHttpActionResult> GettblSC_MemoTemplate(int id)
        {
            tblSC_MemoTemplate tblSC_MemoTemplate = await db.tblSC_MemoTemplate.FindAsync(id);
            if (tblSC_MemoTemplate == null)
            {
                return NotFound();
            }

            return Ok(tblSC_MemoTemplate);
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