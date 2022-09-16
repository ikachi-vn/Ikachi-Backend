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
    public partial class WMS_ItemController : CustomApiController
    {
        [Route("ItemPrice")]
        public IHttpActionResult GetItemPrice()
        {
            int IDPriceList = 0;
            bool? IsManual = null;
            bool HasKeyword = false;

            if (QueryStrings.Any(d => d.Key == "IDBranch"))
                QueryStrings.Remove("IDBranch");

            var query = BS_WMS_Item._queryBuilder(db, IDBranch, StaffID, QueryStrings);

            if (QueryStrings.Any(d => d.Key == "IDPriceList") && !string.IsNullOrEmpty(QueryStrings.FirstOrDefault(d => d.Key == "IDPriceList").Value))
                int.TryParse(QueryStrings.FirstOrDefault(d => d.Key == "IDPriceList").Value, out IDPriceList);

            if (QueryStrings.Any(d => d.Key == "Keyword") && !string.IsNullOrEmpty(QueryStrings.FirstOrDefault(d => d.Key == "Keyword").Value))
                HasKeyword = true;


            if (QueryStrings.Any(d => d.Key == "IsManual") && !string.IsNullOrEmpty(QueryStrings.FirstOrDefault(d => d.Key == "IsManual").Value))
            {
                if (bool.TryParse(QueryStrings.FirstOrDefault(d => d.Key == "IsManual").Value, out bool isManual))
                    IsManual = isManual;
            }

            if (IsManual.HasValue && !HasKeyword)
            {
                query = query.Where(d => d.tbl_WMS_ItemUoM.Any(u => u.tbl_WMS_PriceListDetail.Any(p => p.IsManual == IsManual && p.IDPriceList == IDPriceList && p.IsDeleted == false)));
            }

            query = BS_WMS_Item._sortBuilder(query, QueryStrings);
            query = BS_WMS_Item._pagingBuilder(query, QueryStrings);

            var result = query.Select(i => new
            {
                i.Id,
                i.Code,
                i.Name,
                UoMs = i.tbl_WMS_ItemUoM.Where(du => du.IsDeleted == false).Select(u => new
                {
                    u.Id,
                    u.Name,
                    Price = u.tbl_WMS_PriceListDetail.Where(dp => dp.IDPriceList == IDPriceList && dp.IsDeleted == false).Select(p => new
                    {
                        p.Id,
                        p.IsManual,
                        p.Price,
                        p.Price1,
                        p.Price2
                    }).FirstOrDefault()
                })
            });

            return Ok(result);
        }

        [HttpPost]
        [Route("ImportItemInVendor")]
        public IHttpActionResult Post_ImportItemInVendor()
        {
            var package = SaveImportedFile(out string fileurl);
            return Ok(BS_WMS_Item.Post_ImportItemInVendor(package, db, IDBranch, StaffID, QueryStrings, Username));
        }


    }

}