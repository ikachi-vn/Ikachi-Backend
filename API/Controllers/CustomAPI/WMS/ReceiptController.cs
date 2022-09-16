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
    public partial class WMS_ReceiptController : CustomApiController
    {
        [Route("Palletize")]
        public IHttpActionResult PostPalletize(dynamic item)
        {
            return Ok(BS_WMS_Receipt.palletize(db, IDBranch, StaffID, item, Username));
        }
        [Route("Unpalletize")]
        public IHttpActionResult PostUnpalletize(dynamic item)
        {
            return Ok(BS_WMS_Receipt.unpalletize(db, IDBranch, StaffID, item, Username));
        }

        [Route("ReceiveReceipt")]
        public IHttpActionResult PostReceiveReceipt(DTO_ApproveOrders item)
        {
            return Ok(BS_WMS_Receipt.receiveReceipt(db, IDBranch, StaffID, item, Username));
        }

        [Route("ImportReceiptDetailFile/{id:int}")]
        public IHttpActionResult PostImportReceiptDetailFile(int id)
        {
            var package = SaveImportedFile(out string fileurl);
            return Ok(BS_WMS_Receipt.PostImportReceiptDetailFile(package, id, db, IDBranch, StaffID, QueryStrings, Username));
        }


    }
}


