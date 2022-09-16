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
    [RoutePrefix("api/v1/WMS/Outbound")]
    public partial class WMS_OutboundController : CustomApiController
    {
        [Route("PickingList")]
        public IHttpActionResult GetPickingList()
        {
            var query = db.tbl_SALE_OrderDetail.Where(d=>d.IsDeleted == false && !d.tbl_SALE_Order.IsDeleted);


            //Query Id (int)
            if (QueryStrings.Any(d => d.Key == "Id"))
            {
                var IDList = QueryStrings.FirstOrDefault(d => d.Key == "Id").Value.Replace("[", "").Replace("]", "").Split(',');
                List<int> IDs = new List<int>();
                foreach (var item in IDList)
                    if (int.TryParse(item, out int i))
                        IDs.Add(i);
                if (IDs.Count > 0)
                    query = query.Where(d => d.tbl_SALE_Order.tbl_SHIP_ShipmentDetail.Any(sd => IDs.Contains(sd.IDShipment) && !sd.IsDeleted ));
                
            }
            else
            {
                return BadRequest("No IDShipment found");
            }

            var ItemIDs = query.Select(s => s.IDItem).Distinct();
            var Items = db.tbl_WMS_Item.Where(d => ItemIDs.Contains(d.Id));

            return Ok(new {


                #region OrderDetail
                OrderDetail = query.GroupBy(g=> new { g.IDItem, g.IDUoM, g.tbl_WMS_Item.Code, g.tbl_WMS_Item.Name }).Select(s=>new { 
                    s.Key.IDItem,
                    s.Key.IDUoM,
                    s.Key.Code,
                    s.Key.Name,
                    Quantity = s.Sum(g=>g.Quantity)

                }).ToList(),
                #endregion

                #region Items
                Items = Items.Select(s => new {
                    s.Id,
                    s.Code,
                    s.Name,
                    s.Remark,
                    s.InventoryUoM,
                    s.PurchasingUoM,
                    s.SalesUoM,
                    UoMs = s.tbl_WMS_ItemUoM.Where(iu => !iu.IsDeleted).Select(iu => new {
                        iu.Id,
                        iu.Name,
                        iu.AlternativeQuantity,
                        iu.BaseQuantity,
                        iu.IsBaseUoM
                    })
                }).ToList()
                #endregion
            });
        }
    }

    
    public partial class WMS_PriceListDetailController : CustomApiController
    {
        [Route("CalcPrice/{id:int}")]
        [ResponseType(typeof(void))]
        public IHttpActionResult PostCalcPrice(int id, DTO_WMS_PriceListDetail item)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            if (id != item.Id)
                return BadRequest();

            DTO_WMS_PriceListDetail result = BS_WMS_PriceListDetail.calcPrice(db, item, Username);

            return Ok(result);
        }

        

    }

    public partial class WMS_PriceListController : CustomApiController
    {
        [Route("ReCalcPrice")]
        [ResponseType(typeof(void))]
        public IHttpActionResult PostCalcPrice(DTO_WMS_PriceList item)
        {
            

            try
            {
                BS_WMS_PriceList.reCalcPrice(db, item);
                return StatusCode(HttpStatusCode.NoContent);
            }
            catch (System.Exception ex)
            {
                return BadRequest(ex.Message);
            }

            
                
        }

        [Route("PriceListByItem/{id:int}")]
        public IHttpActionResult GetItemPrice(int id)
        {
            //if (QueryStrings.Any(d => d.Key == "IDBranch"))
            //    QueryStrings.Remove("IDBranch");

            var query = BS_WMS_PriceList._queryBuilder(db, IDBranch, StaffID, QueryStrings);

            var item = db.tbl_WMS_Item.Find(id);
            var vendorIds = item.tbl_PROD_ItemInVendor.Where(d => d.IDItem == id && d.IsDeleted == false).Select(s=>s.IDVendor).ToList();
            

            query = query.Where(d => d.tbl_CRM_Contact1.Any(e => vendorIds.Contains(e.Id)) || d.IsPriceListForVendor == false);

            query = BS_WMS_PriceList._sortBuilder(query, QueryStrings);
            query = BS_WMS_PriceList._pagingBuilder(query, QueryStrings);

            var result = query.Select(i => new
            {
                i.Id,
                i.Code,
                i.Name,
                i.PrimaryDefaultCurrency,
                i.PrimaryDefaultCurrency1,
                i.PrimaryDefaultCurrency2,

                Prices = i.tbl_WMS_PriceListDetail.Where(d=> d.IDItem == id && d.tbl_WMS_ItemUoM.IsDeleted==false && d.IsDeleted==false).Select(p=>new {
                    _UoM = new { Id = p.IDItemUoM, p.tbl_WMS_ItemUoM.Name },
                    p.Id,
                    p.IDItem,
                    p.IDItemUoM,
                    p.IsManual,
                    p.Price,
                    p.Price1,
                    p.Price2
                })

            });

            return Ok(result);
        }

    }

}