using BaseBusiness;
using DTOModel;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;

namespace API.Controllers.V1
{
    public partial class CRM_ContactController : CustomApiController
    {
        
        [Route("QuickSave")]
        public IHttpActionResult PostQuickSave()
        {
            return Ok(BS_CRM_Contact.getSearchCustom(db, IDBranch, StaffID, QueryStrings));
        }
    }

    public partial class CRM_RouteController : CustomApiController
    {
        [Route("List")]
        public IHttpActionResult GetList()
        {
            var query = BS_CRM_Route._queryBuilder(db, IDBranch, StaffID, QueryStrings);
            //Query RefID (string)
            if (QueryStrings.Any(d => d.Key == "SellerName") && !string.IsNullOrEmpty(QueryStrings.FirstOrDefault(d => d.Key == "SellerName").Value))
            {
                var keyword = QueryStrings.FirstOrDefault(d => d.Key == "SellerName").Value;
                if (keyword.StartsWith("SA:") && int.TryParse(keyword.Replace("SA:", ""), out int id))
                {
                    query = query.Where(d => d.Id == id);
                }
                else
                {
                    query = query.Where(d =>
                    d.tbl_HRM_Staff.FullName.Contains(keyword)
                    || d.tbl_HRM_Staff.Code.Contains(keyword)
                    || d.tbl_HRM_Staff.PhoneNumber.Contains(keyword)
                    );
                }
            }

            query = BS_CRM_Route._sortBuilder(query, QueryStrings);
            query = BS_CRM_Route._pagingBuilder(query, QueryStrings);

            var result = query.Select(s => new
            {
                s.IDBranch,
                s.Id,
                s.Code,
                s.Name,
                s.IDSeller,

                SellerName = s.tbl_HRM_Staff != null ? s.tbl_HRM_Staff.FullName : "",
                ShipperName = s.tbl_HRM_Staff1 != null ? s.tbl_HRM_Staff1.FullName : "",
                VehicleName = s.tbl_SHIP_Vehicle != null ? s.tbl_SHIP_Vehicle.Name : "",
                WarehoseName = s.tbl_BRA_Branch1 != null ? s.tbl_BRA_Branch1.Name : "",

                NumberOfCustomer = s.tbl_CRM_RouteDetail.Count(e => e.IsDeleted == false && e.tbl_CRM_Contact.IsDeleted == false)

            }).ToList();

            return Ok(result);

            //return BS_CRM_Contact.get_CRM_Contact(db, IDBranch, StaffID, QueryStrings);
        }
    }
}