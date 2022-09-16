using BaseBusiness;
using DTOModel;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;

namespace API.Controllers.V1
{
    public partial class WMS_PriceListController : CustomApiController
    {
        [Route("ImportPriceList/{id:int}")]
        public IHttpActionResult PostImportPriceList(int id)
        {
            var package = SaveImportedFile(out string fileurl);
            return Ok(BS_WMS_PriceList.PostImportPriceList(package, id, db, IDBranch, StaffID, QueryStrings, Username));
        }

        

        [Route("ApplyPriceListVersion/{id:int}")]
        public IHttpActionResult PostApplyPriceListVersion(int id)
        {
            return Ok(BS_WMS_PriceList.PostApplyPriceListVersion(db, id, IDBranch, StaffID, Username));
        }


        [HttpGet]
        [Route("PriceListCompareReport")]
        public IHttpActionResult PriceListCompareReport()
        {
            //Query OrderDate (System.DateTime)
            if (QueryStrings.Any(d => d.Key == "IDPriceList"))
            {
                var results = BS_WMS_PriceList.calcPriceListCompareReport(db, QueryStrings);
                return Ok(results);
            }
            else
            {
                return BadRequest("IDPriceList filter is required");
            }
        }

        [HttpGet]
        [Route("PriceListVersionCompareReport")]
        public IHttpActionResult PriceListVersionCompareReport()
        {
            //Query OrderDate (System.DateTime)
            if (QueryStrings.Any(d => d.Key == "IDPriceList"))
            {
                var results = BS_WMS_PriceList.calcPriceListVersionCompareReport(db, QueryStrings);
                return Ok(results);
            }
            else
            {
                return BadRequest("IDPriceList filter is required");
            }
        }




    }

}