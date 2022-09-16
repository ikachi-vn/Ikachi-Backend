using BaseBusiness;
using ClassLibrary;
using DTOModel;
using OfficeOpenXml;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;

namespace API.Controllers.V1
{
    public partial class SHIP_ShipmentController : CustomApiController
    {
        [Route("List")]
        public IHttpActionResult GetList()
        {
            var query = BS_SHIP_Shipment._queryBuilder(db, IDBranch, StaffID, QueryStrings);

            if (QueryStrings.Any(d => d.Key == "ShipmentTerm") && !string.IsNullOrEmpty(QueryStrings.FirstOrDefault(d => d.Key == "ShipmentTerm").Value))
            {
                var keyword = QueryStrings.FirstOrDefault(d => d.Key == "ShipmentTerm").Value;


                query = query.Where(d =>

                d.tbl_SHIP_ShipmentDetail.Any(e => !e.IsDeleted &&
                    (
                        e.tbl_SALE_Order.tbl_CRM_Contact.Code.Contains(keyword)
                        || e.tbl_SALE_Order.tbl_CRM_Contact.Name.Contains(keyword)
                        || e.tbl_SALE_Order.tbl_CRM_Contact.tbl_CRM_ContactReference.Any(f => !f.IsDeleted && f.Code.Contains(keyword))
                    )
                )

                || d.tbl_SHIP_Vehicle.Code.Contains(keyword)
                || d.tbl_SHIP_Vehicle.Name.Contains(keyword)

                || d.tbl_HRM_Staff.FullName.Contains(keyword)

                );

            }

            query = BS_SHIP_Shipment._sortBuilder(query, QueryStrings);
            query = BS_SHIP_Shipment._pagingBuilder(query, QueryStrings);

            var result = query.Select(s => new
            {
                IDBranch = s.IDBranch,
                IDStatus = s.IDStatus,
                Id = s.Id,
                Code = s.Code,
                Name = s.Name,
                Remark = s.Remark,
                IDShipper = s.IDShipper,
                DeliveryDate = s.DeliveryDate,
                ShippedDate = s.ShippedDate,
                Sort = s.Sort,
                IDVehicle = s.IDVehicle,

                ShipperName = s.tbl_HRM_Staff.FullName,
                //Shipper = new { s.tbl_HRM_Staff.Id, s.tbl_HRM_Staff.Code, s.tbl_HRM_Staff.FullName, s.tbl_HRM_Staff.PhoneNumber },
                VehicleName = s.tbl_SHIP_Vehicle.Name,

                //OrderIds = s.tbl_SHIP_ShipmentDetail.Where(e=>e.IsDeleted==false).Select(ss=>ss.IDSaleOrder)
                OrderCount = s.tbl_SHIP_ShipmentDetail.Where(e => e.IsDeleted == false).Select(r => r.Id).Count(),
                DebtCount = s.tbl_SHIP_ShipmentDebt.Where(e => e.IsDeleted == false).Select(r => r.Id).Count(),

                OriginalTotalAfterTax = s.tbl_SHIP_ShipmentDetail.Where(e => e.IsDeleted == false).Select(r => r.tbl_SALE_Order.OriginalTotalAfterTax).DefaultIfEmpty(0).Sum(),
                ProductWeight = s.tbl_SHIP_ShipmentDetail.Where(e => e.IsDeleted == false).Select(r => r.tbl_SALE_Order.ProductWeight).DefaultIfEmpty(0).Sum(),
                ProductDimensions = s.tbl_SHIP_ShipmentDetail.Where(e => e.IsDeleted == false).Select(r => r.tbl_SALE_Order.ProductDimensions).DefaultIfEmpty(0).Sum(),
            });
                //.OrderBy(o=>o.VehicleName).ThenBy(o=>o.DeliveryDate).ToList();

            return Ok(result);
        }

        [Route("Add")]
        [ResponseType(typeof(DTO_SHIP_Shipment))]
        public IHttpActionResult PostAdd(DTO_SHIP_Shipment item)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            string err = "";
            item.IDStatus = 301;
            var result = BS_SHIP_Shipment.calc_Shipment(db, IDBranch, item, Username, out err);
            db.SaveChanges();

            if (result != null)
            {
                return CreatedAtRoute("get_SHIP_Shipment", new { id = result.Id }, result);
            }
            return Conflict();

        }

        [Route("Update/{id:int}")]
        [ResponseType(typeof(void))]
        public IHttpActionResult PutUpdate(int id, DTO_SHIP_Shipment item)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            if (id != item.Id)
                return BadRequest();

            string err = "";
            var result = BS_SHIP_Shipment.calc_Shipment(db, IDBranch, item, Username, out err);
            db.SaveChanges();

            if (result != null)
                return StatusCode(HttpStatusCode.NoContent);
            else
                return NotFound();

        }

        [Route("QuickAddSO")]
        [ResponseType(typeof(void))]
        public IHttpActionResult PutQuickAddSO(DTO_SHIP_Shipment item)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var dbitem = db.tbl_SHIP_Shipment.Find(item.Id);
            var OderIds = dbitem.tbl_SHIP_ShipmentDetail.Where(d => d.IsDeleted == false).Select(s => s.IDSaleOrder.Value).ToList();
            var DebtOrderIds = dbitem.tbl_SHIP_ShipmentDebt.Where(d => d.IsDeleted == false).Select(s => s.IDSaleOrder.Value).ToList();

            var dtoItem = BS_SHIP_Shipment.toDTO(dbitem);

            dtoItem.OrderIds = OderIds;
            dtoItem.DebtOrderIds = DebtOrderIds;

            dtoItem.OrderIds.AddRange(item.OrderIds);
            dtoItem.DebtOrderIds.AddRange(item.DebtOrderIds);

            string err = "";
            var result = BS_SHIP_Shipment.calc_Shipment(db, IDBranch, dtoItem, Username, out err);
            db.SaveChanges();

            if (result != null)
                return StatusCode(HttpStatusCode.NoContent);
            else
                return NotFound();

        }

        [Route("Delete/{ids}")]
        [ResponseType(typeof(DTO_SHIP_Shipment))]
        public IHttpActionResult DeleteShipment(string ids)
        {

            var IDList = ids.Replace("[", "").Replace("]", "").Split(',');
            List<int?> IDs = new List<int?>();
            foreach (var item in IDList)
                if (int.TryParse(item, out int i))
                    IDs.Add(i);
                else if (item == "null")
                    IDs.Add(null);
            if (IDs.Count == 0)
            {
                return BadRequest();
            }

            var dbitems = db.tbl_SHIP_Shipment.Where(d => IDs.Contains(d.Id));
            var shipments = BS_SHIP_Shipment.toDTO(dbitems).ToList();

            try
            {
                foreach (var shipment in shipments)
                {
                    string err = "";
                    shipment.OrderIds = new List<int>();
                    shipment.DebtOrderIds = new List<int>();
                    shipment.IsDeleted = true;
                    BS_SHIP_Shipment.calc_Shipment(db, IDBranch, shipment, Username, out err);
                }
                db.SaveChanges();
                return StatusCode(HttpStatusCode.NoContent);
            }
            catch (Exception ex)
            {
                return Conflict();
            }
            
        }

        [Route("AutoCreateShipment/{id:int}")]
        [ResponseType(typeof(void))]
        public IHttpActionResult PutAutoCreateShipment_New(int id)
        {
            try
            {
                BS_SHIP_Shipment.autoCreateShipment(db, id, Username);
                db.SaveChanges();
                return StatusCode(HttpStatusCode.NoContent);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);

            }

        }


        [Route("PickingList")]
        public IHttpActionResult GetPickingList()
        {
            var query = BS_SHIP_Shipment._queryBuilder(db, IDBranch, StaffID, QueryStrings);

            var result = query.Select(s => new
            {
                s.Id,
                s.DeliveryDate,

                WarehouseId = s.IDWarehouse.HasValue? s.tbl_BRA_Branch1.Id : 0,
                WarehouseName = s.IDWarehouse.HasValue ? s.tbl_BRA_Branch1.Name : "N/A",
                WarehousePhone = s.IDWarehouse.HasValue ? s.tbl_BRA_Branch1.Phone : "0000.000.000",

                Vehicle = s.tbl_SHIP_Vehicle.Name,

                ShipperName = s.tbl_HRM_Staff.FullName,
                ShipperPhone = s.tbl_HRM_Staff.PhoneNumber,

                Customers = db.tbl_CRM_Contact.Where(d => s.tbl_SHIP_ShipmentDetail.Any(e => e.tbl_SALE_Order.IDContact == d.Id && !e.IsDeleted)).Select(c => new
                {
                    c.Id,
                    c.Code,
                    c.Name,
                    c.WorkPhone,

                    Orders = c.tbl_SALE_Order.Where(d => s.tbl_SHIP_ShipmentDetail.Any(e => e.IDSaleOrder == d.Id && !e.IsDeleted) && !d.IsDeleted)
                     .Select(o => new
                     {
                         o.Id,
                         o.Code,
                         o.OrderDate,

                         o.tbl_CRM_PartnerAddress.AddressLine1,
                         o.tbl_CRM_PartnerAddress.AddressLine2,
                         o.tbl_CRM_PartnerAddress.Ward,
                         o.tbl_CRM_PartnerAddress.District,
                         o.tbl_CRM_PartnerAddress.Province,
                         o.tbl_CRM_PartnerAddress.Country,

                         IDSeller = o.tbl_HRM_Staff.Id,
                         SellerCode = o.tbl_HRM_Staff.Code,
                         SellerName = o.tbl_HRM_Staff.FullName,
                         SellerPhone = o.tbl_HRM_Staff.PhoneNumber,

                         CompanyName = o.tbl_BRA_Branch.Name,
                         CompanyPhone = o.tbl_BRA_Branch.Phone,
                         CompanyPhone2 = o.tbl_BRA_Branch.Phone2,
                         CompanyLogoURL = o.tbl_BRA_Branch.LogoURL,
                         TemplateHeader = o.tbl_BRA_Branch.TemplateHeader,

                         o.OriginalTotalBeforeDiscount,
                         o.OriginalTotalDiscount,
                         o.OriginalTotalAfterDiscount,
                         o.OriginalTax,
                         o.OriginalTotalAfterTax,

                         //DoSo = iData.Common.StringUtil.DocTienBangChu(long.Parse(o.OriginalTotalAfterTax.ToString()) , " đồng"),
                         //QRC = iData.Common.StringUtil.QRC(o.Id, "O:"),

                         #region Order lines
                         OrderLines = o.tbl_SALE_OrderDetail.Where(d => d.IsDeleted == false).Select(l => new
                         {
                             l.Id,
                             l.IDItem,
                             ItemCode = l.tbl_WMS_Item.Code,
                             ItemName = l.tbl_WMS_Item.Name,
                             IDSalesUoM = l.tbl_WMS_Item.SalesUoM,
                             IDInventoryUoM = l.tbl_WMS_Item.InventoryUoM ,
                             InventoryUoMBaseQuantity = l.tbl_WMS_Item.InventoryUoM.HasValue ==false? 0 : l.tbl_WMS_Item.tbl_WMS_ItemUoM.Where(d => d.Id == l.tbl_WMS_Item.InventoryUoM && d.IsDeleted == false)
                                .Select(e=>e.BaseQuantity).DefaultIfEmpty(0).FirstOrDefault(),
                             l.IDUoM,
                             UoMName = l.tbl_WMS_ItemUoM.Name,
                             l.tbl_WMS_ItemUoM.IsBaseUoM,

                             l.tbl_WMS_ItemUoM.AlternativeQuantity,
                             l.tbl_WMS_ItemUoM.BaseQuantity,
                             
                             l.Quantity,
                             l.UoMPrice,
                             l.OriginalTotalBeforeDiscount,
                             l.OriginalTotalDiscount,
                             l.OriginalTotalAfterDiscount,
                             l.OriginalTax,
                             l.OriginalTotalAfterTax,
                             ItemGroupSort = l.tbl_WMS_Item.IDItemGroup.HasValue? l.tbl_WMS_Item.tbl_WMS_ItemGroup.Sort : 0,
                             ItemSort = l.tbl_WMS_Item.Sort,
                             ItemGroupName = l.tbl_WMS_Item.IDItemGroup.HasValue ? l.tbl_WMS_Item.tbl_WMS_ItemGroup.Name : ""

                         }),
                         #endregion

                         #region Promotion
                         PromotionTracking =  db.tbl_PR_PromotionTracking.Where(d=>d.MaDH == o.Code).Select(p=>new { 
                            p.TenChuongTrinh,
                            p.SoThung,
                            p.SoLe,
                            p.ChietKhau
                         })
                         #endregion
                     })
                }),

            }).ToList();


          

            return Ok(result);
        }

        [Route("PickingList2")]
        public IHttpActionResult GetPickingList2()
        {
            var query = BS_SHIP_Shipment._queryBuilder(db, IDBranch, StaffID, QueryStrings);

            var result = query.Select(s => new
            {
                s.Id,
                s.DeliveryDate,

                WarehouseId = s.IDWarehouse.HasValue ? s.tbl_BRA_Branch1.Id : 0,
                WarehouseName = s.IDWarehouse.HasValue ? s.tbl_BRA_Branch1.Name : "N/A",
                WarehousePhone = s.IDWarehouse.HasValue ? s.tbl_BRA_Branch1.Phone : "0000.000.000",

                Vehicle = s.tbl_SHIP_Vehicle.Name,

                ShipperName = s.tbl_HRM_Staff.FullName,
                ShipperPhone = s.tbl_HRM_Staff.PhoneNumber,

                Customers = db.tbl_CRM_Contact.Where(d => s.tbl_SHIP_ShipmentDetail.Any(e => e.tbl_SALE_Order.IDContact == d.Id && !e.IsDeleted)).Select(c => new
                {
                    c.Id,
                    c.Code,
                    c.Name,
                    c.WorkPhone,

                    Orders = c.tbl_SALE_Order.Where(d => s.tbl_SHIP_ShipmentDetail.Any(e => e.IDSaleOrder == d.Id && !e.IsDeleted) && !d.IsDeleted)
                     .Select(o => new
                     {
                         o.Id,
                         o.Code,
                         o.OrderDate,
                         o.RefContact,

                         o.tbl_CRM_PartnerAddress.AddressLine1,
                         o.tbl_CRM_PartnerAddress.AddressLine2,
                         o.tbl_CRM_PartnerAddress.Ward,
                         o.tbl_CRM_PartnerAddress.District,
                         o.tbl_CRM_PartnerAddress.Province,
                         o.tbl_CRM_PartnerAddress.Country,

                         IDSeller = o.tbl_HRM_Staff.Id,
                         SellerCode = o.tbl_HRM_Staff.Code,
                         SellerName = o.tbl_HRM_Staff.FullName,
                         SellerPhone = o.tbl_HRM_Staff.PhoneNumber,

                         CompanyName = o.tbl_BRA_Branch.Name,
                         CompanyPhone = o.tbl_BRA_Branch.Phone,
                         CompanyPhone2 = o.tbl_BRA_Branch.Phone2,
                         CompanyLogoURL = o.tbl_BRA_Branch.LogoURL,
                         TemplateHeader = o.tbl_BRA_Branch.TemplateHeader,

                         o.OriginalTotalBeforeDiscount,
                         o.OriginalTotalDiscount,
                         o.OriginalTotalAfterDiscount,
                         o.OriginalTax,
                         o.OriginalTotalAfterTax,
                         o.OriginalDiscountFromSalesman,

                         //DoSo = iData.Common.StringUtil.DocTienBangChu(long.Parse(o.OriginalTotalAfterTax.ToString()) , " đồng"),
                         //QRC = iData.Common.StringUtil.QRC(o.Id, "O:"),

                         #region Order lines
                         OrderLines = o.tbl_SALE_OrderDetail.Where(d => d.IsDeleted == false).Select(l => new
                         {
                             l.Id,
                             l.IDItem,

                             Item = new
                             {
                                 l.tbl_WMS_Item.Code,
                                 l.tbl_WMS_Item.Name,

                                 UoM = l.tbl_WMS_Item.tbl_WMS_ItemUoM.Where(d => d.Id == l.IDUoM).Select(e => new { e.Id, e.AlternativeQuantity, e.BaseQuantity, e.Name }).FirstOrDefault(),
                                 BaseUoM = l.tbl_WMS_Item.tbl_WMS_ItemUoM.Where(d => d.IsBaseUoM && d.IsDeleted == false).Select(e => new { e.Id, e.AlternativeQuantity, e.BaseQuantity, e.Name }).FirstOrDefault(),
                                 SalesUoM = l.tbl_WMS_Item.tbl_WMS_ItemUoM.Where(d => d.Id == l.tbl_WMS_Item.SalesUoM).Select(e => new { e.Id, e.AlternativeQuantity, e.BaseQuantity, e.Name }).FirstOrDefault(),
                                 InventoryUoM = l.tbl_WMS_Item.tbl_WMS_ItemUoM.Where(d => d.Id == l.tbl_WMS_Item.InventoryUoM).Select(e => new { e.Id, e.AlternativeQuantity, e.BaseQuantity, e.Name }).FirstOrDefault(),

                             },

                             l.Quantity,
                             l.UoMPrice,
                             l.OriginalTotalBeforeDiscount,
                             l.OriginalTotalDiscount,
                             l.OriginalTotalAfterDiscount,
                             l.OriginalTax,
                             l.OriginalTotalAfterTax,
                             l.OriginalDiscountFromSalesman,
                             ItemGroupSort = 0,
                             ItemSort = l.tbl_WMS_Item.Sort,
                             ItemGroupName = db.fnGetRootItemGroup(l.tbl_WMS_Item.IDItemGroup).FirstOrDefault().Name

                         }),
                         #endregion

                         #region Promotion
                         PromotionTracking = db.tbl_PR_PromotionTracking.Where(d => d.MaDH == o.Code).GroupBy(x=>x.TenChuongTrinh).Select(p => new {
                             TenChuongTrinh = p.Key,
                             SoThung = p.Sum(g=>g.SoThung),
                             SoLe = p.Sum(g=>g.SoLe),
                             ChietKhau = p.Sum(g=>g.ChietKhau)
                             //p.TenChuongTrinh,
                             //p.SoThung,
                             //p.SoLe,
                             //p.ChietKhau
                         }).OrderBy(p=>p.ChietKhau)
                         #endregion
                     })
                }),

            }).ToList();




            return Ok(result);
        }

        [Route("ExportPickingListByShipments")]
        public string Get_ExportPickingListByShipments()
        {

            string fileurl = "";

            var package = GetTemplateWorkbook("WMS_PickingList_Template.xlsx", "PickingList.xlsx", out fileurl);
            BS_SHIP_Shipment.export_PickingListByShipments(package, db, IDBranch, StaffID, QueryStrings);

            package.Workbook.Properties.Title = "ART-DMS WMS_PickingList";
            package.Workbook.Properties.Author = "hung.vu@codeart.vn";
            package.Workbook.Properties.Application = "ART-DMS";
            package.Workbook.Properties.Company = "A.R.T Distribution";

            package.Save();

            return fileurl; //downloadExcelFile(package, "SALE_Order.xlsx");

        }

        [Route("ShipmentReview")]
        public IHttpActionResult GetShipmentReview()
        {
            var query = BS_SHIP_Shipment._queryBuilder(db, IDBranch, StaffID, QueryStrings).ToList();

            List<int> UndoneStatus = new List<int>()
            {
                314 , //	Đã phân tài
                315 , //	Đã giao đơn vị vận chuyển
                316 , //	Đã lấy hàng về kho
                317 , //	Đang đóng gói
                318 , //	Đang giao hàng
                //319 , //	Đóng - Đã giao hàng
            };

            var result = query.Select(s => new
            {
                s.Id,
                s.DeliveryDate,

                WarehouseId = s.tbl_BRA_Branch1 == null? 0 : s.tbl_BRA_Branch1.Id,
                WarehouseName = s.tbl_BRA_Branch1 == null? "" : s.tbl_BRA_Branch1.Name,
                WarehousePhone = s.tbl_BRA_Branch1 == null ? "" : s.tbl_BRA_Branch1.Phone,

                Vehicle = s.tbl_SHIP_Vehicle.Name,

                ShipperName = s.tbl_HRM_Staff == null? "": s.tbl_HRM_Staff.FullName,
                ShipperPhone = s.tbl_HRM_Staff == null ? "" : s.tbl_HRM_Staff.PhoneNumber,

                Status = new { s.tbl_SYS_Status.Id, s.tbl_SYS_Status.Name, s.tbl_SYS_Status.Color },


                NumberOfOrder = s.tbl_SHIP_ShipmentDetail.Count(d => d.IsDeleted == false),
                TotalOfOrder = s.tbl_SHIP_ShipmentDetail.Where(d => d.IsDeleted == false).Select(e => e.tbl_SALE_Order.OriginalTotalAfterTax).DefaultIfEmpty(0).Sum(),

                NumberOfUndoneOrder = s.tbl_SHIP_ShipmentDetail.Count(d => d.IsDeleted == false && UndoneStatus.Contains(d.IDStatus)),
                TotalOfUndoneOrder = s.tbl_SHIP_ShipmentDetail.Where(d => d.IsDeleted == false && UndoneStatus.Contains(d.IDStatus)).Select(e => e.tbl_SALE_Order.OriginalTotalAfterTax).DefaultIfEmpty(0).Sum(),


                NumberOfDoneOrder = s.tbl_SHIP_ShipmentDetail.Count(d => d.IsDeleted == false && d.IDStatus == 319),
                NumberOfNewDebt = s.tbl_SHIP_ShipmentDetail.Count(d => d.IsDeleted == false && d.tbl_SALE_Order.IsDebt),

                TotalOfDoneOrder = s.tbl_SHIP_ShipmentDetail.Where(d => d.IsDeleted == false && d.IDStatus == 319).Select(e => e.tbl_SALE_Order.TotalAfterTax).DefaultIfEmpty(0).Sum(),
                TotalOfCashOrder = s.tbl_SHIP_ShipmentDetail.Where(d => d.IsDeleted == false).Select(e => e.Received).DefaultIfEmpty(0).Sum(),
                //TotalOfNewDebtOrder = TotalOfDoneOrder - TotalOfCashOrder

                NumberOfDebt = s.tbl_SHIP_ShipmentDebt.Count(d => d.IsDeleted == false),
                NumberOfReceivedDebt = s.tbl_SHIP_ShipmentDebt.Count(d => d.IsDeleted == false && d.Received > 0),

                TotalOfDebt = s.tbl_SHIP_ShipmentDebt.Where(d => d.IsDeleted == false).Select(e => e.Debt).DefaultIfEmpty(0).Sum(),
                TotalOfReceivedDebt = s.tbl_SHIP_ShipmentDebt.Where(d => d.IsDeleted == false).Select(e => e.Received).DefaultIfEmpty(0).Sum(),



                ShipmentOrder = s.tbl_SHIP_ShipmentDetail.Where(d => d.IsDeleted == false).Select( c=> new { 
                    c.Id,
                    SaleOrder = new
                    {
                        c.tbl_SALE_Order.Id,
                        c.tbl_SALE_Order.Code,
                        c.tbl_SALE_Order.OrderDate,
                        Customer = new
                        {
                            c.tbl_SALE_Order.tbl_CRM_Contact.Id,
                            c.tbl_SALE_Order.tbl_CRM_Contact.Code,
                            c.tbl_SALE_Order.tbl_CRM_Contact.Name,


                            c.tbl_SALE_Order.tbl_CRM_PartnerAddress.AddressLine1,
                            c.tbl_SALE_Order.tbl_CRM_PartnerAddress.AddressLine2,
                            c.tbl_SALE_Order.tbl_CRM_PartnerAddress.Ward,
                            c.tbl_SALE_Order.tbl_CRM_PartnerAddress.District,
                            c.tbl_SALE_Order.tbl_CRM_PartnerAddress.Province,
                            c.tbl_SALE_Order.tbl_CRM_PartnerAddress.Country,

                            c.tbl_SALE_Order.tbl_CRM_Contact.WorkPhone,
                        },

                        c.tbl_SALE_Order.IsDebt,
                        c.tbl_SALE_Order.OriginalTotalAfterTax,
                        c.tbl_SALE_Order.TotalAfterTax,

                        c.tbl_SALE_Order.DiscountFromSalesman,


                        OrderLines = c.tbl_SALE_Order.tbl_SALE_OrderDetail.Where(t => t.IsDeleted == false).Select(l => new
                        {
                            l.Id,
                            l.IDItem,
                            ItemCode = l.tbl_WMS_Item.Code,
                            ItemName = l.tbl_WMS_Item.Name,
                            IDSalesUoM = l.tbl_WMS_Item.SalesUoM,
                            IDInventoryUoM = l.tbl_WMS_Item.InventoryUoM,
                            InventoryUoMBaseQuantity = l.tbl_WMS_Item.tbl_WMS_ItemUoM.Where(d => d.Id == l.tbl_WMS_Item.InventoryUoM && d.IsDeleted==false).Select(e => e.BaseQuantity).DefaultIfEmpty(0).FirstOrDefault(),
                            l.IDUoM,
                            UoMName = l.tbl_WMS_ItemUoM.Name,
                            l.tbl_WMS_ItemUoM.IsBaseUoM,
                            l.tbl_WMS_ItemUoM.BaseQuantity,
                            l.Quantity,
                            l.ShippedQuantity,
                            l.UoMPrice,
                            l.OriginalTotalBeforeDiscount,
                            l.OriginalTotalDiscount,
                            l.OriginalTotalAfterDiscount,
                            l.OriginalTax,
                            l.OriginalTotalAfterTax,
                            l.TotalAfterTax,
                            l.OriginalDiscountFromSalesman,
                        })
                    },
                    c.Received,
                    c.Remark,
                    Status = new { c.tbl_SYS_Status.Id, c.tbl_SYS_Status.Name, c.tbl_SYS_Status.Color } 

                }),

                ShipmentDebt = s.tbl_SHIP_ShipmentDebt.Where(d => d.IsDeleted == false).Select(c => new
                {
                    c.Id,
                    SaleOrder = new
                    {
                        c.tbl_SALE_Order.Id,
                        c.tbl_SALE_Order.Code,
                        c.tbl_SALE_Order.OrderDate,
                        Customer = new
                        {
                            c.tbl_SALE_Order.tbl_CRM_Contact.Id,
                            c.tbl_SALE_Order.tbl_CRM_Contact.Code,
                            c.tbl_SALE_Order.tbl_CRM_Contact.Name,
                            c.tbl_SALE_Order.tbl_CRM_PartnerAddress.AddressLine1,
                            c.tbl_SALE_Order.tbl_CRM_PartnerAddress.AddressLine2,
                            c.tbl_SALE_Order.tbl_CRM_PartnerAddress.Ward,
                            c.tbl_SALE_Order.tbl_CRM_PartnerAddress.District,
                            c.tbl_SALE_Order.tbl_CRM_PartnerAddress.Province,
                            c.tbl_SALE_Order.tbl_CRM_PartnerAddress.Country,
                            c.tbl_SALE_Order.tbl_CRM_Contact.WorkPhone,
                        },
                        c.tbl_SALE_Order.TotalAfterTax
                    },
                    c.Debt,
                    c.Received,
                    c.Remark,
                    Status = new { c.tbl_SYS_Status.Id, c.tbl_SYS_Status.Name, c.tbl_SYS_Status.Color }
                })

            }).ToList();

            return Ok(result);
        }

        [Route("DeliveryShipment")]
        public IHttpActionResult GetDeliveryShipment()
        {
            var query = BS_SHIP_Shipment._queryBuilder(db, IDBranch, StaffID, QueryStrings).ToList();

            List<int> UndoneStatus = new List<int>()
            {
                314 , //	Đã phân tài
                315 , //	Đã giao đơn vị vận chuyển
                316 , //	Đã lấy hàng về kho
                317 , //	Đang đóng gói
                318 , //	Đang giao hàng
                //319 , //	Đóng - Đã giao hàng
            };

            var result = query.Select(s => new DTO_SHIP_Shipment
            {
                Id = s.Id,
                DeliveryDate = s.DeliveryDate,

                Vehicle = s.tbl_SHIP_Vehicle.Name,

                Status = new DTO_SYS_Status{
                    Id = s.tbl_SYS_Status.Id, 
                    Name = s.tbl_SYS_Status.Name, 
                    Color = s.tbl_SYS_Status.Color 
                },

                ShipmentOrder = s.tbl_SHIP_ShipmentDetail.Where(d => d.IsDeleted == false).Select(c => new DTO_SHIP_ShipmentDetail{
                    
                    SaleOrder = new DTO_SALE_Order
                    {
                        Customer = BS_CRM_Contact.toDTO(c.tbl_SALE_Order.tbl_CRM_Contact),

                        OrderLines = c.tbl_SALE_Order.tbl_SALE_OrderDetail.Where(t => t.IsDeleted == false)
                        .Select(l => new DTO_SALE_OrderDetail
                        {
                            ItemCode = l.tbl_WMS_Item.Code,
                            ItemName = l.tbl_WMS_Item.Name,
                            UoMName = l.tbl_WMS_ItemUoM.Name,

                            Id = l.Id,
                            RefID = l.RefID,
                            IDOrder = l.IDOrder,
                            RefOrder = l.RefOrder,
                            IDItem = l.IDItem,
                            RefItem = l.RefItem,
                            IDUoM = l.IDUoM,
                            UoMPrice = l.UoMPrice,
                            Quantity = l.Quantity,
                            UoMSwap = l.UoMSwap,
                            IDBaseUoM = l.IDBaseUoM,
                            BaseQuantity = l.BaseQuantity,
                            IsPromotionItem = l.IsPromotionItem,
                            IDPromotion = l.IDPromotion,
                            IDTax = l.IDTax,
                            TaxRate = l.TaxRate,
                            OriginalTotalBeforeDiscount = l.OriginalTotalBeforeDiscount,
                            OriginalPromotion = l.OriginalPromotion,
                            OriginalDiscount1 = l.OriginalDiscount1,
                            OriginalDiscount2 = l.OriginalDiscount2,
                            OriginalDiscountByItem = l.OriginalDiscountByItem,
                            OriginalDiscountByGroup = l.OriginalDiscountByGroup,
                            OriginalDiscountByLine = l.OriginalDiscountByLine,
                            OriginalDiscountByOrder = l.OriginalDiscountByOrder,
                            OriginalDiscountFromSalesman = l.OriginalDiscountFromSalesman,
                            OriginalTotalDiscount = l.OriginalTotalDiscount,
                            OriginalTotalAfterDiscount = l.OriginalTotalAfterDiscount,
                            OriginalTax = l.OriginalTax,
                            OriginalTotalAfterTax = l.OriginalTotalAfterTax,
                            ShippedQuantity = l.ShippedQuantity,
                            ReturnedQuantity = l.ReturnedQuantity,
                            TotalBeforeDiscount = l.TotalBeforeDiscount,
                            Discount1 = l.Discount1,
                            Discount2 = l.Discount2,
                            DiscountByItem = l.DiscountByItem,
                            Promotion = l.Promotion,
                            DiscountByGroup = l.DiscountByGroup,
                            DiscountByLine = l.DiscountByLine,
                            DiscountByOrder = l.DiscountByOrder,
                            DiscountFromSalesman = l.DiscountFromSalesman,
                            TotalDiscount = l.TotalDiscount,
                            TotalAfterDiscount = l.TotalAfterDiscount,
                            Tax = l.Tax,
                            TotalAfterTax = l.TotalAfterTax,
                            Remark = l.Remark,
                            IsDisabled = l.IsDisabled,
                            IsDeleted = l.IsDeleted,
                            CreatedBy = l.CreatedBy,
                            ModifiedBy = l.ModifiedBy,
                            CreatedDate = l.CreatedDate,
                            ModifiedDate = l.ModifiedDate,
                            ProductStatus = l.ProductStatus,
                            ProductWeight = l.ProductWeight,
                            ProductDimensions = l.ProductDimensions,
                            ExpectedDeliveryDate = l.ExpectedDeliveryDate,
                            ShippedDate = l.ShippedDate
                        }).ToList(),

                        IDBranch = c.tbl_SALE_Order.IDBranch,
                        IDOpportunity = c.tbl_SALE_Order.IDOpportunity,
                        IDContact = c.tbl_SALE_Order.IDContact,
                        IDContract = c.tbl_SALE_Order.IDContract,
                        IDStatus = c.tbl_SALE_Order.IDStatus,
                        IDType = c.tbl_SALE_Order.IDType,
                        Id = c.tbl_SALE_Order.Id,
                        Code = c.tbl_SALE_Order.Code,
                        Name = c.tbl_SALE_Order.Name,
                        Remark = c.tbl_SALE_Order.Remark,
                        IDOwner = c.tbl_SALE_Order.IDOwner,
                        OrderDate = c.tbl_SALE_Order.OrderDate,
                        OriginalTotalBeforeDiscount = c.tbl_SALE_Order.OriginalTotalBeforeDiscount,
                        OriginalPromotion = c.tbl_SALE_Order.OriginalPromotion,
                        OriginalDiscount1 = c.tbl_SALE_Order.OriginalDiscount1,
                        OriginalDiscount2 = c.tbl_SALE_Order.OriginalDiscount2,
                        OriginalDiscountByItem = c.tbl_SALE_Order.OriginalDiscountByItem,
                        OriginalDiscountByGroup = c.tbl_SALE_Order.OriginalDiscountByGroup,
                        OriginalDiscountByLine = c.tbl_SALE_Order.OriginalDiscountByLine,
                        OriginalDiscountByOrder = c.tbl_SALE_Order.OriginalDiscountByOrder,
                        OriginalDiscountFromSalesman = c.tbl_SALE_Order.OriginalDiscountFromSalesman,
                        OriginalTotalDiscount = c.tbl_SALE_Order.OriginalTotalDiscount,
                        OriginalTotalAfterDiscount = c.tbl_SALE_Order.OriginalTotalAfterDiscount,
                        OriginalTax = c.tbl_SALE_Order.OriginalTax,
                        OriginalTotalAfterTax = c.tbl_SALE_Order.OriginalTotalAfterTax,
                        TotalBeforeDiscount = c.tbl_SALE_Order.TotalBeforeDiscount,
                        ProductWeight = c.tbl_SALE_Order.ProductWeight,
                        ProductDimensions = c.tbl_SALE_Order.ProductDimensions,
                        Discount1 = c.tbl_SALE_Order.Discount1,
                        Discount2 = c.tbl_SALE_Order.Discount2,
                        DiscountByItem = c.tbl_SALE_Order.DiscountByItem,
                        Promotion = c.tbl_SALE_Order.Promotion,
                        DiscountByGroup = c.tbl_SALE_Order.DiscountByGroup,
                        DiscountByLine = c.tbl_SALE_Order.DiscountByLine,
                        DiscountByOrder = c.tbl_SALE_Order.DiscountByOrder,
                        DiscountFromSalesman = c.tbl_SALE_Order.DiscountFromSalesman,
                        TotalDiscount = c.tbl_SALE_Order.TotalDiscount,
                        TotalAfterDiscount = c.tbl_SALE_Order.TotalAfterDiscount,
                        Tax = c.tbl_SALE_Order.Tax,
                        TotalAfterTax = c.tbl_SALE_Order.TotalAfterTax,
                        Received = c.tbl_SALE_Order.Received,
                        ReceivedDiscountFromSalesman = c.tbl_SALE_Order.ReceivedDiscountFromSalesman,
                        Debt = c.tbl_SALE_Order.Debt,
                        IsDebt = c.tbl_SALE_Order.IsDebt,
                        IsPaymentReceived = c.tbl_SALE_Order.IsPaymentReceived,
                        SubType = c.tbl_SALE_Order.SubType,
                        Sort = c.tbl_SALE_Order.Sort,
                        IsDisabled = c.tbl_SALE_Order.IsDisabled,
                        IsDeleted = c.tbl_SALE_Order.IsDeleted,
                        CreatedBy = c.tbl_SALE_Order.CreatedBy,
                        ModifiedBy = c.tbl_SALE_Order.ModifiedBy,
                        CreatedDate = c.tbl_SALE_Order.CreatedDate,
                        ModifiedDate = c.tbl_SALE_Order.ModifiedDate,
                        ExpectedDeliveryDate = c.tbl_SALE_Order.ExpectedDeliveryDate,
                        ShippedDate = c.tbl_SALE_Order.ShippedDate,
                        ShippingAddress = c.tbl_SALE_Order.ShippingAddress,
                        ShippingAddressRemark = c.tbl_SALE_Order.ShippingAddressRemark,
                        InvoiceNumber = c.tbl_SALE_Order.InvoiceNumber,
                        InvoicDate = c.tbl_SALE_Order.InvoicDate,
                        TaxRate = c.tbl_SALE_Order.TaxRate,
                        RefID = c.tbl_SALE_Order.RefID,
                        RefOwner = c.tbl_SALE_Order.RefOwner,
                        RefContact = c.tbl_SALE_Order.RefContact,
                        RefWarehouse = c.tbl_SALE_Order.RefWarehouse,
                        RefDepartment = c.tbl_SALE_Order.RefDepartment,
                        RefShipper = c.tbl_SALE_Order.RefShipper,
                        IsCOD = c.tbl_SALE_Order.IsCOD,
                        CODAmount = c.tbl_SALE_Order.CODAmount,
                        ShipFee = c.tbl_SALE_Order.ShipFee,
                        ShipFeeBySender = c.tbl_SALE_Order.ShipFeeBySender,
                        IsSampleOrder = c.tbl_SALE_Order.IsSampleOrder,
                        IsUrgentOrders = c.tbl_SALE_Order.IsUrgentOrders,
                        IDUrgentShipper = c.tbl_SALE_Order.IDUrgentShipper,
                        IsWholeSale = c.tbl_SALE_Order.IsWholeSale,
                    },
                    Status = new DTO_SYS_Status
                    {
                        Id = c.tbl_SYS_Status.Id,
                        Name = c.tbl_SYS_Status.Name,
                        Color = c.tbl_SYS_Status.Color
                    },
                    Id = c.Id,
                    IDShipment = s.Id,
                    IDStatus = c.IDStatus,
                    Received = c.Received,
                    Remark = c.Remark,
                    

                }).ToList(),

                ShipmentDebt = s.tbl_SHIP_ShipmentDebt.Where(d => d.IsDeleted == false).Select(c => new DTO_SHIP_ShipmentDebt
                {
                    SaleOrder = new DTO_SALE_Order
                    {
                        Customer = BS_CRM_Contact.toDTO(c.tbl_SALE_Order.tbl_CRM_Contact),

                        OrderLines = c.tbl_SALE_Order.tbl_SALE_OrderDetail.Where(t => t.IsDeleted == false)
                        .Select(l => new DTO_SALE_OrderDetail
                        {
                            ItemCode = l.tbl_WMS_Item.Code,
                            ItemName = l.tbl_WMS_Item.Name,
                            UoMName = l.tbl_WMS_ItemUoM.Name,

                            Id = l.Id,
                            RefID = l.RefID,
                            IDOrder = l.IDOrder,
                            RefOrder = l.RefOrder,
                            IDItem = l.IDItem,
                            RefItem = l.RefItem,
                            IDUoM = l.IDUoM,
                            UoMPrice = l.UoMPrice,
                            Quantity = l.Quantity,
                            UoMSwap = l.UoMSwap,
                            IDBaseUoM = l.IDBaseUoM,
                            BaseQuantity = l.BaseQuantity,
                            IsPromotionItem = l.IsPromotionItem,
                            IDPromotion = l.IDPromotion,
                            IDTax = l.IDTax,
                            TaxRate = l.TaxRate,
                            OriginalTotalBeforeDiscount = l.OriginalTotalBeforeDiscount,
                            OriginalPromotion = l.OriginalPromotion,
                            OriginalDiscount1 = l.OriginalDiscount1,
                            OriginalDiscount2 = l.OriginalDiscount2,
                            OriginalDiscountByItem = l.OriginalDiscountByItem,
                            OriginalDiscountByGroup = l.OriginalDiscountByGroup,
                            OriginalDiscountByLine = l.OriginalDiscountByLine,
                            OriginalDiscountByOrder = l.OriginalDiscountByOrder,
                            OriginalDiscountFromSalesman = l.OriginalDiscountFromSalesman,
                            OriginalTotalDiscount = l.OriginalTotalDiscount,
                            OriginalTotalAfterDiscount = l.OriginalTotalAfterDiscount,
                            OriginalTax = l.OriginalTax,
                            OriginalTotalAfterTax = l.OriginalTotalAfterTax,
                            ShippedQuantity = l.ShippedQuantity,
                            ReturnedQuantity = l.ReturnedQuantity,
                            TotalBeforeDiscount = l.TotalBeforeDiscount,
                            Discount1 = l.Discount1,
                            Discount2 = l.Discount2,
                            DiscountByItem = l.DiscountByItem,
                            Promotion = l.Promotion,
                            DiscountByGroup = l.DiscountByGroup,
                            DiscountByLine = l.DiscountByLine,
                            DiscountByOrder = l.DiscountByOrder,
                            DiscountFromSalesman = l.DiscountFromSalesman,
                            TotalDiscount = l.TotalDiscount,
                            TotalAfterDiscount = l.TotalAfterDiscount,
                            Tax = l.Tax,
                            TotalAfterTax = l.TotalAfterTax,
                            Remark = l.Remark,
                            IsDisabled = l.IsDisabled,
                            IsDeleted = l.IsDeleted,
                            CreatedBy = l.CreatedBy,
                            ModifiedBy = l.ModifiedBy,
                            CreatedDate = l.CreatedDate,
                            ModifiedDate = l.ModifiedDate,
                            ProductStatus = l.ProductStatus,
                            ProductWeight = l.ProductWeight,
                            ProductDimensions = l.ProductDimensions,
                            ExpectedDeliveryDate = l.ExpectedDeliveryDate,
                            ShippedDate = l.ShippedDate
                        }).ToList(),

                        IDBranch = c.tbl_SALE_Order.IDBranch,
                        IDOpportunity = c.tbl_SALE_Order.IDOpportunity,
                        IDContact = c.tbl_SALE_Order.IDContact,
                        IDContract = c.tbl_SALE_Order.IDContract,
                        IDStatus = c.tbl_SALE_Order.IDStatus,
                        IDType = c.tbl_SALE_Order.IDType,
                        Id = c.tbl_SALE_Order.Id,
                        Code = c.tbl_SALE_Order.Code,
                        Name = c.tbl_SALE_Order.Name,
                        Remark = c.tbl_SALE_Order.Remark,
                        IDOwner = c.tbl_SALE_Order.IDOwner,
                        OrderDate = c.tbl_SALE_Order.OrderDate,
                        OriginalTotalBeforeDiscount = c.tbl_SALE_Order.OriginalTotalBeforeDiscount,
                        OriginalPromotion = c.tbl_SALE_Order.OriginalPromotion,
                        OriginalDiscount1 = c.tbl_SALE_Order.OriginalDiscount1,
                        OriginalDiscount2 = c.tbl_SALE_Order.OriginalDiscount2,
                        OriginalDiscountByItem = c.tbl_SALE_Order.OriginalDiscountByItem,
                        OriginalDiscountByGroup = c.tbl_SALE_Order.OriginalDiscountByGroup,
                        OriginalDiscountByLine = c.tbl_SALE_Order.OriginalDiscountByLine,
                        OriginalDiscountByOrder = c.tbl_SALE_Order.OriginalDiscountByOrder,
                        OriginalDiscountFromSalesman = c.tbl_SALE_Order.OriginalDiscountFromSalesman,
                        OriginalTotalDiscount = c.tbl_SALE_Order.OriginalTotalDiscount,
                        OriginalTotalAfterDiscount = c.tbl_SALE_Order.OriginalTotalAfterDiscount,
                        OriginalTax = c.tbl_SALE_Order.OriginalTax,
                        OriginalTotalAfterTax = c.tbl_SALE_Order.OriginalTotalAfterTax,
                        TotalBeforeDiscount = c.tbl_SALE_Order.TotalBeforeDiscount,
                        ProductWeight = c.tbl_SALE_Order.ProductWeight,
                        ProductDimensions = c.tbl_SALE_Order.ProductDimensions,
                        Discount1 = c.tbl_SALE_Order.Discount1,
                        Discount2 = c.tbl_SALE_Order.Discount2,
                        DiscountByItem = c.tbl_SALE_Order.DiscountByItem,
                        Promotion = c.tbl_SALE_Order.Promotion,
                        DiscountByGroup = c.tbl_SALE_Order.DiscountByGroup,
                        DiscountByLine = c.tbl_SALE_Order.DiscountByLine,
                        DiscountByOrder = c.tbl_SALE_Order.DiscountByOrder,
                        DiscountFromSalesman = c.tbl_SALE_Order.DiscountFromSalesman,
                        TotalDiscount = c.tbl_SALE_Order.TotalDiscount,
                        TotalAfterDiscount = c.tbl_SALE_Order.TotalAfterDiscount,
                        Tax = c.tbl_SALE_Order.Tax,
                        TotalAfterTax = c.tbl_SALE_Order.TotalAfterTax,
                        Received = c.tbl_SALE_Order.Received,
                        ReceivedDiscountFromSalesman = c.tbl_SALE_Order.ReceivedDiscountFromSalesman,
                        Debt = c.tbl_SALE_Order.Debt,
                        IsDebt = c.tbl_SALE_Order.IsDebt,
                        IsPaymentReceived = c.tbl_SALE_Order.IsPaymentReceived,
                        SubType = c.tbl_SALE_Order.SubType,
                        Sort = c.tbl_SALE_Order.Sort,
                        IsDisabled = c.tbl_SALE_Order.IsDisabled,
                        IsDeleted = c.tbl_SALE_Order.IsDeleted,
                        CreatedBy = c.tbl_SALE_Order.CreatedBy,
                        ModifiedBy = c.tbl_SALE_Order.ModifiedBy,
                        CreatedDate = c.tbl_SALE_Order.CreatedDate,
                        ModifiedDate = c.tbl_SALE_Order.ModifiedDate,
                        ExpectedDeliveryDate = c.tbl_SALE_Order.ExpectedDeliveryDate,
                        ShippedDate = c.tbl_SALE_Order.ShippedDate,
                        ShippingAddress = c.tbl_SALE_Order.ShippingAddress,
                        ShippingAddressRemark = c.tbl_SALE_Order.ShippingAddressRemark,
                        InvoiceNumber = c.tbl_SALE_Order.InvoiceNumber,
                        InvoicDate = c.tbl_SALE_Order.InvoicDate,
                        TaxRate = c.tbl_SALE_Order.TaxRate,
                        RefID = c.tbl_SALE_Order.RefID,
                        RefOwner = c.tbl_SALE_Order.RefOwner,
                        RefContact = c.tbl_SALE_Order.RefContact,
                        RefWarehouse = c.tbl_SALE_Order.RefWarehouse,
                        RefDepartment = c.tbl_SALE_Order.RefDepartment,
                        RefShipper = c.tbl_SALE_Order.RefShipper,
                        IsCOD = c.tbl_SALE_Order.IsCOD,
                        CODAmount = c.tbl_SALE_Order.CODAmount,
                        ShipFee = c.tbl_SALE_Order.ShipFee,
                        ShipFeeBySender = c.tbl_SALE_Order.ShipFeeBySender,
                        IsSampleOrder = c.tbl_SALE_Order.IsSampleOrder,
                        IsUrgentOrders = c.tbl_SALE_Order.IsUrgentOrders,
                        IDUrgentShipper = c.tbl_SALE_Order.IDUrgentShipper,
                        IsWholeSale = c.tbl_SALE_Order.IsWholeSale,
                    },
                    Status = new DTO_SYS_Status
                    {
                        Id = c.tbl_SYS_Status.Id,
                        Name = c.tbl_SYS_Status.Name,
                        Color = c.tbl_SYS_Status.Color
                    },
                    Id = c.Id,
                    IDShipment = s.Id,
                    IDStatus = c.IDStatus,
                    Debt = c.Debt,
                    Received = c.Received,
                    Remark = c.Remark,
                    
                }).ToList()

            }).ToList();

            return Ok(result);
        }



        [Route("ShipmentFinished/{id:int}")]
        [ResponseType(typeof(void))]
        public IHttpActionResult PutShipmentFinished(int id, DTO_SHIP_Shipment item)
        {
            var dbItem = db.tbl_SHIP_Shipment.Find(id);

            if(dbItem == null || dbItem.IDStatus!= 329)
            {
                return NotFound();
            }

            dbItem.IDStatus = 328;
            dbItem.ConfirmFinishedBy = Username;
            dbItem.ConfirmFinishedDate = DateTime.Now;
            dbItem.IsLostMoney = item.IsLostMoney;
            dbItem.LostAmount = item.LostAmount;
            dbItem.LostRemark += item.LostRemark;

            var shipmentDetailStatus = new List<int>()
            {
                //307,// NULL    Khách hẹn giao lại
                //308,// NULL    Không liên lạc được
                //309,// NULL    Khách không nhận do hàng lỗi
                //310,// NULL Khách không nhận do giá
                //311,// NULL Khách không nhận
                //312,// NULL Khách không nhận do khách hết tiền
                //313,// NULL Không giao được -lý do khác
                //314,// NULL Đã phân tài
                //315,// NULL Đã giao đơn vị vận chuyển
                //316,// NULL Đang lấy hàng
                //317,// NULL Đang đóng gói
                //318,// NULL Đang giao hàng
                319,// NULL Đã giao hàng
            };

            //Shipment detail
            foreach (var o in dbItem.tbl_SHIP_ShipmentDetail.Where(d=>d.IsDeleted == false && shipmentDetailStatus.Contains(d.IDStatus)))
            {
                db.tbl_SYS_SyncJob.Add(new tbl_SYS_SyncJob()
                {
                    Type = "ShipmentDetail",
                    Command = o.Received >= o.tbl_SALE_Order.TotalAfterTax? "CreateInvoice": "CreateDebtInvoice",
                    RefNum1 = o.Id,
                    CreatedBy = dbItem.ConfirmFinishedBy,
                    CreatedDate = dbItem.ConfirmFinishedDate.Value
                });

                if (o.Received > 0)
                {
                    db.tbl_SYS_SyncJob.Add(new tbl_SYS_SyncJob()
                    {
                        Type = "ShipmentDetail",
                        Command = "CreateReceipts",
                        RefNum1 = o.Id,
                        CreatedBy = dbItem.ConfirmFinishedBy,
                        CreatedDate = dbItem.ConfirmFinishedDate.Value
                    });
                }

            }

            var debtStatus = new List<int>(){
                322, //Đã thu một phần
                323 // Đã thu xong
            };

            //Shipment debt
            foreach (var o in dbItem.tbl_SHIP_ShipmentDebt.Where(d => d.IsDeleted == false && debtStatus.Contains( d.IDStatus )  ))
            {
                if (o.Received > 0)
                {
                    db.tbl_SYS_SyncJob.Add(new tbl_SYS_SyncJob()
                    {
                        Type = "ShipmentDebt",
                        Command = "CreateReceipts",
                        RefNum1 = o.Id,
                        CreatedBy = dbItem.ConfirmFinishedBy,
                        CreatedDate = dbItem.ConfirmFinishedDate.Value
                    });
                }
            }

            //Lost money
            if (dbItem.IsLostMoney)
            {
                db.tbl_SYS_SyncJob.Add(new tbl_SYS_SyncJob()
                {
                    Type = "Shipment",
                    Command = "CreateLostPayment",
                    RefNum1 = dbItem.Id,
                    CreatedBy = dbItem.ConfirmFinishedBy,
                    CreatedDate = dbItem.ConfirmFinishedDate.Value
                });
                
            }

          
            var result = 
            db.SaveChanges();

            if (result == 1)
                return StatusCode(HttpStatusCode.NoContent);
            else
                return NotFound();

        }

        [Route("ExportAvailableOrdersForShipment")]
        public string Get_ExportAvailableOrdersForShipment()
        {
            string fileurl = "";

            var package = GetTemplateWorkbook("SaleOrders_Shipment_Template.xlsx", "SaleOrders_Shipment.xlsx", out fileurl);
            BS_SHIP_Shipment.export_AvailbleSaleOrderForShipment(package, db, IDBranch, StaffID, QueryStrings);

            package.Workbook.Properties.Title = "ART-DMS SALE_Order";
            package.Workbook.Properties.Author = "hung.vu@codeart.vn";
            package.Workbook.Properties.Application = "ART-DMS";
            package.Workbook.Properties.Company = "A.R.T Distribution";

            package.Save();

            return fileurl; //downloadExcelFile(package, "SALE_Order.xlsx");
        }

        [HttpPost]
        [Route("importManualShipment")]
        public IHttpActionResult Post_importManualShipment()
        {
            string err = "";
            string fileurl = "";
            int IdBranch = 0;
            int IdWarehouse = 0;

            if (QueryStrings.Any(d => d.Key == "IDBranch"))
            {
                int.TryParse(QueryStrings.FirstOrDefault(d => d.Key == "IDBranch").Value, out IdBranch);
                var config = db.tbl_SYS_Config.Where(d => (d.IDBranch == IdBranch || d.IDBranch == null) && d.Code == "IDWarehouse").OrderBy(o=>o.IDBranch).FirstOrDefault();
                if (config == null)
                {
                    return BadRequest("IDWarehouse config not found");
                }
                IdWarehouse = int.Parse(config.Value);
            }
            else
            {
                return BadRequest("No IDBranch");
            }


            try
            {
                var package = SaveImportedFile(out fileurl);
                ExcelWorkbook workBook = package.Workbook;
                err = "";

                if (workBook != null)
                {
                    var ws = workBook.Worksheets.FirstOrDefault();

                    var dataRows = new List<Dictionary<string, object>>();

                    var noOfCol = ws.Dimension.End.Column;
                    var noOfRow = ws.Dimension.End.Row;


                    //Đọc data từ file excel
                    for (int rowIndex = 5; rowIndex <= noOfRow; rowIndex++)
                    {
                        var item = new Dictionary<string, object>();
                        item["IsValid"] = true;
                        item["_index"] = rowIndex;
                        item["ValidateMessage"] = "";

                        //for (int colIndex = 1; colIndex <= noOfCol; colIndex++)
                        for (int colIndex = 1; colIndex <= 5; colIndex++)
                        {
                            item["C" + colIndex] = ws.Cells[rowIndex, colIndex].Value == null ? "" : ws.Cells[rowIndex, colIndex].Value.ToString().Trim();
                        }

                        
                        if (item["C5"].ToString() != "")
                        {
                            if (double.TryParse(item["C3"].ToString(), out double c3) && !string.IsNullOrEmpty(item["C4"].ToString()))
                            {
                                DateTime dDate = DateTime.FromOADate(c3);
                                DateTime dTime = item["C4"].ToString().Contains(":") ? DateTime.Parse("2000/1/1 " + item["C4"].ToString()) : DateTime.FromOADate(double.Parse(item["C4"].ToString()));
                                DateTime DeliveryDate = dDate.Add(dTime.TimeOfDay);
                                item["DeliveryDate"] = DeliveryDate;
                            }
                            else
                            {
                                item["DeliveryDate"] = null;
                            }
                            
                            dataRows.Add(item);
                        }
                    }


                    string ModifiedBy = Username;
                    DateTime ModifiedDate = DateTime.Now;


                    var VehicleList = dataRows.Select(s => s["C1"].ToString()).Distinct().ToList();
                    for (int i = 0; i < VehicleList.Count; i++)
                    {
                        if (string.IsNullOrEmpty(VehicleList[i]) || !VehicleList[i].Contains("."))
                        {
                            var removedOrderFormShipment = dataRows.Where(d =>  d["C1"].ToString() == "" )
                                .Select(s => string.IsNullOrEmpty(s["C5"].ToString()) ? 0 : int.Parse(s["C5"].ToString())).Distinct().ToList();

                            var shipmentDetails = db.tbl_SHIP_ShipmentDetail.Where(d =>
                                d.IDSaleOrder.HasValue && 
                                removedOrderFormShipment.Contains(d.IDSaleOrder.Value)
                                && d.IsDeleted == false
                                && d.tbl_SHIP_Shipment.IsDeleted == false
                                && d.tbl_SHIP_Shipment.IDStatus == 301 //Đã phân tài
                            );

                            foreach (var item in shipmentDetails)
                            {
                                item.IsDeleted = true;
                                item.ModifiedBy = ModifiedBy;
                                item.ModifiedDate = ModifiedDate;

                                item.tbl_SALE_Order.IDStatus = item.tbl_SALE_Order.tbl_SHIP_ShipmentDetail.Count(d => d.IsDeleted == false) > 0 ? 110 : 104;
                            }

                        }
                        else
                        {
                            //Distinct Vehicle + DateTime
                            var shipmentList = dataRows.Where(d => d["C1"].ToString() == VehicleList[i].ToString() && d["DeliveryDate"] != null)
                                .Select(s => new
                                {
                                    IDVehicle = (string.IsNullOrEmpty(s["C1"].ToString())) ? 0 : int.Parse(s["C1"].ToString().Split('.')[0]),
                                    DeliveryDate = (DateTime)s["DeliveryDate"]
                                }).Distinct().ToList();


                            foreach (var s in shipmentList)
                            {
                                

                                if (s.DeliveryDate == null)
                                {
                                    continue;
                                }

                                var shipment = BS_SHIP_Shipment.toDTO(db.tbl_SHIP_Shipment.FirstOrDefault(d => d.DeliveryDate == s.DeliveryDate && d.IDVehicle == s.IDVehicle && d.IsDeleted == false));

                                int IDShipper = 0;

                                var ShipperList = dataRows.Where(d => d["C1"].ToString() == VehicleList[i].ToString() && d["DeliveryDate"] != null && (DateTime)d["DeliveryDate"] == s.DeliveryDate && d["C2"].ToString() != "")
                                        .Select(f => f["C2"].ToString()).Distinct().ToList();
                                if (ShipperList.Count > 0)
                                {
                                    IDShipper = int.Parse(ShipperList[0].Split('.')[0]);
                                }
                                else
                                {
                                    var dbVehicle = db.tbl_SHIP_Vehicle.Find(s.IDVehicle);
                                    if (dbVehicle != null && dbVehicle.IDShipper.HasValue)
                                    {
                                        IDShipper = dbVehicle.IDShipper.Value;
                                    }
                                    else
                                    {
                                        continue;
                                    }
                                }


                                if (shipment == null)
                                {
                                    shipment = new DTO_SHIP_Shipment();
                                    shipment.DeliveryDate = s.DeliveryDate;
                                    shipment.IDStatus = 301;
                                    shipment.CreatedBy = ModifiedBy;
                                    shipment.CreatedDate = ModifiedDate;
                                    shipment.IDVehicle = s.IDVehicle;
                                }

                                

                                if (shipment.IDStatus != 301)
                                {
                                    continue;
                                }
                                else
                                {
                                    shipment.IDBranch = IdBranch;
                                    shipment.IDWarehouse = IdWarehouse;
                                    shipment.IDShipper = IDShipper;
                                    shipment.ModifiedBy = ModifiedBy;
                                    shipment.ModifiedDate = ModifiedDate;
                                    

                                    var orders = dataRows.Where(d => d["C1"].ToString() == VehicleList[i].ToString() && (DateTime)d["DeliveryDate"] == s.DeliveryDate)
                                        .Select(f => int.Parse(f["C5"].ToString())).Distinct().ToList();

                                    //if (orders.Contains(1018615))
                                    //{
                                    //    var a = 1;
                                    //}

                                    shipment.OrderIds = orders;

                                    var result = BS_SHIP_Shipment.calc_Shipment(db, IDBranch, shipment, Username, out err);

                                }

                            }

                        }


                    }

                    db.SaveChanges();

                    var deleteNoRowShipment = db.tbl_SHIP_Shipment.Where(d => !d.tbl_SHIP_ShipmentDebt.Any(e => e.IsDisabled == false) && !d.tbl_SHIP_ShipmentDetail.Any(e => e.IsDeleted == false) && d.IsDeleted == false);
                    foreach (var item in deleteNoRowShipment)
                    {
                        item.IsDeleted = true;
                        item.ModifiedBy = ModifiedBy;
                        item.ModifiedDate = ModifiedDate;
                    }

                    db.SaveChanges();

                }
            }
            catch (Exception ex)
            {
                err = ex.Message;
                return BadRequest(err);
            }

            return Ok(fileurl);
        }


        [Route("DeliveryAnOrder")]
        [HttpPut]
        public IHttpActionResult DeliveryAnOrder(DTO_SHIP_ShipmentDetail item)
        {
            string err = string.Empty;
       
            try
            {
                BS_SHIP_Shipment.PutDelivered(db, 1, item, Username, DateTime.Now);
                BS_SHIP_Shipment.updateShipmentStatus(db, item.IDShipment);

                db.SaveChanges();

                return Ok(new
                {
                    Id = item.Id,
                    Success = true
                });

            }
            catch (Exception ex)
            {
                err = ex.Message;
            }

            return Ok(new
            {
                Success = false,
                Error = err
            });
        }

        [Route("DeliveryCollectedDebt")]
        [HttpPut]
        public IHttpActionResult DeliveryCollectedDebt(DTO_SHIP_ShipmentDebt item)
        {
            string err = string.Empty;

            try
            {
                BS_SHIP_Shipment.PutCollectedDebt(db, 1, item, Username, DateTime.Now);
                

                db.SaveChanges();

                return Ok(new
                {
                    Id = item.Id,
                    Success = true
                });

            }
            catch (Exception ex)
            {
                err = ex.Message;
            }

            return Ok(new
            {
                Success = false,
                Error = err
            });
        }


        [Route("DeliveryUpdatePosition")]
        [HttpPut]
        public IHttpActionResult DeliveryUpdatePosition(dynamic item)
        {
            string err = string.Empty;

            try
            {
                tbl_SALE_Order dbItem = db.tbl_SALE_Order.Find((int)item.Id);

                if (dbItem != null)
                {
                    dbItem.tbl_CRM_PartnerAddress.Lat = item.Lat;
                    dbItem.tbl_CRM_PartnerAddress.Long = item.Long;
                    db.SaveChanges();

                    return Ok(new
                    {
                        Id = item.Id,
                        Success = true
                    });
                }
                else
                {
                    return NotFound();
                }
                
            }
            catch (Exception ex)
            {
                err = ex.Message;
            }

            return Ok(new
            {
                Success = false,
                Error = err
            });
        }


        [HttpPost]
        [Route("ConfirmInboundReturn/{ids}")]
        public IHttpActionResult ConfirmInboundReturn(string ids)
        {
            if (string.IsNullOrEmpty(ids))
            {
                return BadRequest(ModelState);
            }

            try
            {
                BS_SHIP_Shipment.confirmInboundReturn(db, ids, Username, DateTime.Now);
                db.SaveChanges();
                return StatusCode(HttpStatusCode.NoContent);
            }
            catch (Exception)
            {

                return Conflict();
            }

        }
    }

}