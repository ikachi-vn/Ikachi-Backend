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
    public partial class PURCHASE_OrderController : CustomApiController
    {
        [Route("ImportDetailFile/{id:int}")]
        public IHttpActionResult PostImportReceiptDetailFile(int id)
        {
            var package = SaveImportedFile(out string fileurl);
            return Ok(BS_PURCHASE_Order.PostImportDetailFile(package, id, db, IDBranch, StaffID, QueryStrings, Username));
        }

        [Route("CopyToReceipt")]
        public IHttpActionResult PostCopyToReceipt(dynamic item)
        {
            int result = BS_PURCHASE_Order.copyToReceipt(db, IDBranch, StaffID, item, Username);
            if (result != 0)
                return CreatedAtRoute("get_WMS_Receipt", new { id = result }, result);

            return Conflict();
        }

        [Route("SubmitOrdersForApproval")]
        public IHttpActionResult PostSubmitOrdersForApproval(DTO_ApproveOrders item)
        {
            var fromStatus = new List<string>() { "PODraft", "PORequestUnapproved" };
            var result = BS_PURCHASE_Order.changePOStatus(db, item.Ids, fromStatus, "PORequestSubmitted", IDBranch,StaffID, Username);
            return Ok(result);
        }

        [Route("ApproveOrders")]
        public IHttpActionResult PostApproveOrders(DTO_ApproveOrders item)
        {
            var fromStatus = new List<string>() { "PORequestSubmitted" };
            var result = BS_PURCHASE_Order.changePOStatus(db, item.Ids, fromStatus, "PORequestApproved", IDBranch, StaffID, Username);
            return Ok(result);
        }

        [Route("DisapproveOrders")]
        public IHttpActionResult PostDisapproveOrders(DTO_ApproveOrders item)
        {
            var fromStatus = new List<string>() { "PORequestSubmitted", "PORequestApproved" };
            var result = BS_PURCHASE_Order.changePOStatus(db, item.Ids, fromStatus, "PORequestUnapproved", IDBranch, StaffID, Username);
            return Ok(result);
        }

        [Route("CancelOrders")]
        public IHttpActionResult PostCancelOrders(DTO_ApproveOrders item)
        {
            var fromStatus = new List<string>() { "PODraft", "PORequestUnapproved" };
            var result = BS_PURCHASE_Order.changePOStatus(db, item.Ids, fromStatus, "POCancelled", IDBranch, StaffID, Username);
            return Ok(result);
        }

    }

}