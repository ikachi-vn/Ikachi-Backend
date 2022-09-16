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
    public partial class WMS_TransactionController : CustomApiController
    {
        [HttpGet]
        [Route("InputOutputInventory")]
        public IHttpActionResult calcInputOutputInventory()
        {
            var results = BS_WMS_Transaction.calcInputOutputInventory(db, IDBranch, StaffID, QueryStrings);
            return Ok(results);
        }
    }
}


