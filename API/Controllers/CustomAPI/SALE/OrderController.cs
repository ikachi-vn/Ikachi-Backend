using BaseBusiness;
using ClassLibrary;
using DTOModel;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web.Http;
using System.Web.Http.Description;

namespace API.Controllers.V1
{
    public partial class SALE_OrderController : CustomApiController
    {
        [Route("List")]
        public IHttpActionResult GetList()
        {
            var query = BS_SALE_Order._queryBuilder(db, IDBranch, StaffID, QueryStrings);

            //Query RefID (string)
            if (QueryStrings.Any(d => d.Key == "CustomerName") && !string.IsNullOrEmpty(QueryStrings.FirstOrDefault(d => d.Key == "CustomerName").Value))
            {
                var keyword = QueryStrings.FirstOrDefault(d => d.Key == "CustomerName").Value;
                if (keyword.StartsWith("C:") && int.TryParse(keyword.Replace("C:", ""), out int id))
                {
                    query = query.Where(d => d.tbl_CRM_Contact.Id == id);
                }
                else
                {
                    query = query.Where(d =>
                    d.tbl_CRM_Contact.Name.Contains(keyword)
                    || d.tbl_CRM_Contact.WorkPhone.Contains(keyword)
                    || d.tbl_CRM_Contact.tbl_CRM_ContactReference.Any(e => !e.IsDeleted && e.Code.Contains(keyword))
                    );
                }
            }
            if (QueryStrings.Any(d => d.Key == "Saleman") && !string.IsNullOrEmpty(QueryStrings.FirstOrDefault(d => d.Key == "Saleman").Value))
            {
                var keyword = QueryStrings.FirstOrDefault(d => d.Key == "Saleman").Value;
                query = query.Where(d =>
                    d.tbl_HRM_Staff.FullName.Contains(keyword)
                    || d.tbl_HRM_Staff.PhoneNumber.Contains(keyword)
                    || d.tbl_HRM_Staff.Code.Contains(keyword)
                );
            }

            query = BS_SALE_Order._sortBuilder(query, QueryStrings);
            query = BS_SALE_Order._pagingBuilder(query, QueryStrings);

            var ids = query.Select(s => s.Id).ToList();

            var q = db.tbl_SALE_Order.Where(d => ids.Contains(d.Id));
            var result = BS_SALE_Order._sortBuilder(q, QueryStrings).Select(s => new
            {
                s.Id,
                s.Code,
                s.Name,
                s.OrderDate,
                s.ExpectedDeliveryDate,
                Status = new { s.IDStatus, s.tbl_SYS_Status.Name, s.tbl_SYS_Status.Color },
                s.IDContact,
                Saleman = new { Id = s.tbl_HRM_Staff == null ? 0 : s.tbl_HRM_Staff.Id, FirstName = s.tbl_HRM_Staff == null ? "" : s.tbl_HRM_Staff.FirstName, FullName = s.tbl_HRM_Staff == null ? "" : s.tbl_HRM_Staff.FullName },
                CustomerName = s.tbl_CRM_Contact.Name,
                s.tbl_CRM_Contact.WorkPhone,
                s.tbl_CRM_PartnerAddress.AddressLine1,
                s.tbl_CRM_PartnerAddress.AddressLine2,
                s.tbl_CRM_PartnerAddress.Ward,
                s.tbl_CRM_PartnerAddress.District,
                s.tbl_CRM_PartnerAddress.Province,
                s.tbl_CRM_PartnerAddress.Country,
                s.tbl_CRM_PartnerAddress.Lat,
                s.tbl_CRM_PartnerAddress.Long,
                RefCodes = s.tbl_CRM_Contact.tbl_CRM_ContactReference.Select(ss => new { ss.Code, IDVendor = ss.tbl_CRM_Contact.Id, VendorName = ss.tbl_CRM_Contact.Name }),
                s.IDBranch,
                BranchName = s.tbl_BRA_Branch.Name,
                s.OriginalTotalBeforeDiscount,
                s.OriginalTotalDiscount,
                s.OriginalTotalAfterDiscount,
                s.OriginalTax,
                s.OriginalTotalAfterTax,
                ShipmentIds = s.tbl_SHIP_ShipmentDetail.Where(e => !e.IsDeleted && !e.tbl_SHIP_Shipment.IsDeleted).Select(r => r.IDShipment).DefaultIfEmpty(0),
                s.IsSampleOrder,
                s.IsShipBySaleMan,
                s.IsUrgentOrders,
                s.IsWholeSale

            });


            return Ok(result);
        }

        [Route("ShippingList")]
        public IHttpActionResult GetShippingList()
        {
            var query = BS_SALE_Order._queryBuilder(db, IDBranch, StaffID, QueryStrings);



            if (QueryStrings.Any(d => d.Key == "IDShipment"))
            {
                var IDList = QueryStrings.FirstOrDefault(d => d.Key == "IDShipment").Value.Replace("[", "").Replace("]", "").Split(',');
                List<int> IDs = new List<int>();
                foreach (var item in IDList)
                    if (int.TryParse(item, out int i))
                        IDs.Add(i);
                if (IDs.Count > 0)
                    query = query.Where(d => d.tbl_SHIP_ShipmentDetail.Any(e => !e.IsDeleted && !e.tbl_SHIP_Shipment.IsDeleted && IDs.Contains(e.IDShipment)));
            }

            //Query RefID (string)
            if (QueryStrings.Any(d => d.Key == "CustomerName") && !string.IsNullOrEmpty(QueryStrings.FirstOrDefault(d => d.Key == "CustomerName").Value))
            {
                var keyword = QueryStrings.FirstOrDefault(d => d.Key == "CustomerName").Value;
                if (keyword.StartsWith("SHIP:") && int.TryParse(keyword.Replace("SHIP:", ""), out int id))
                {
                    query = query.Where(d => d.Id == id);
                }
                else
                {
                    query = query.Where(d =>
                    d.tbl_CRM_Contact.Name.Contains(keyword)
                    || d.tbl_CRM_Contact.WorkPhone.Contains(keyword)
                    || d.tbl_CRM_Contact.tbl_CRM_ContactReference.Any(e => !e.IsDeleted && e.Code.Contains(keyword))
                    );
                }
            }



            if (QueryStrings.Any(d => d.Key == "AnyShipment"))
            {
                var qValue = QueryStrings.FirstOrDefault(d => d.Key == "AnyShipment").Value;
                if (bool.TryParse(qValue, out bool qBoolValue))
                    query = query.Where(d => qBoolValue == d.tbl_SHIP_ShipmentDetail.Any(e => !e.IsDeleted && !e.tbl_SHIP_Shipment.IsDeleted && e.tbl_SHIP_Shipment.IDStatus != 328));
            }

            query = query.Where(d => d.tbl_SALE_OrderDetail.Any(e => !e.IsDeleted));

            query = BS_SALE_Order._sortBuilder(query, QueryStrings);
            query = BS_SALE_Order._pagingBuilder(query, QueryStrings);

            var result = query.Select(s => new
            {
                s.Id,
                s.Code,
                s.Name,
                s.OrderDate,
                s.ExpectedDeliveryDate,
                s.IDStatus,
                s.IDContact,
                CustomerName = s.tbl_CRM_Contact.Name,
                s.tbl_CRM_Contact.WorkPhone,
                s.tbl_CRM_PartnerAddress.AddressLine1,
                s.tbl_CRM_PartnerAddress.AddressLine2,
                s.tbl_CRM_PartnerAddress.Ward,
                s.tbl_CRM_PartnerAddress.District,
                s.tbl_CRM_PartnerAddress.Province,
                s.tbl_CRM_PartnerAddress.Country,
                s.tbl_CRM_PartnerAddress.Lat,
                s.tbl_CRM_PartnerAddress.Long,

                RouteName = s.tbl_CRM_Contact.tbl_CRM_RouteDetail.Any(d => d.IsDeleted == false && d.tbl_CRM_Route.IsDeleted == false && d.tbl_CRM_Route.IDSeller == s.IDOwner) ?
                    s.tbl_CRM_Contact.tbl_CRM_RouteDetail.FirstOrDefault(d => d.IsDeleted == false && d.tbl_CRM_Route.IsDeleted == false && d.tbl_CRM_Route.IDSeller == s.IDOwner).tbl_CRM_Route.Name : "",
                IDRoute = s.tbl_CRM_Contact.tbl_CRM_RouteDetail.Any(d => d.IsDeleted == false && d.tbl_CRM_Route.IsDeleted == false && d.tbl_CRM_Route.IDSeller == s.IDOwner) ?
                    s.tbl_CRM_Contact.tbl_CRM_RouteDetail.FirstOrDefault(d => d.IsDeleted == false && d.tbl_CRM_Route.IsDeleted == false && d.tbl_CRM_Route.IDSeller == s.IDOwner).IDRoute : 0,

                SellerName = s.tbl_HRM_Staff != null ? s.tbl_HRM_Staff.FullName : "",
                IDSeller = s.tbl_HRM_Staff != null ? s.IDOwner : 0,

                RefCodes = s.tbl_CRM_Contact.tbl_CRM_ContactReference.Select(ss => new { ss.Code, IDVendor = ss.tbl_CRM_Contact.Id, VendorName = ss.tbl_CRM_Contact.Name }),
                s.IDBranch,
                BranchName = s.tbl_BRA_Branch.Name,
                s.OriginalTotalBeforeDiscount,
                s.OriginalTotalDiscount,
                s.OriginalTotalAfterDiscount,
                s.OriginalTax,
                s.OriginalTotalAfterTax,
                s.ProductDimensions,
                s.ProductWeight,
                IDShipment = s.tbl_SHIP_ShipmentDetail.FirstOrDefault(e => e.IsDeleted == false) != null ? s.tbl_SHIP_ShipmentDetail.FirstOrDefault(e => e.IsDeleted == false).IDShipment : 0

            }).ToList();

            return Ok(result);
        }

        [Route("DebtList")]
        public IHttpActionResult GetDebtList()
        {



            var query = BS_SALE_Order._queryBuilder(db, IDBranch, StaffID, QueryStrings);
            //Query RefID (string)

            if (QueryStrings.Any(d => d.Key == "CustomerName") && !string.IsNullOrEmpty(QueryStrings.FirstOrDefault(d => d.Key == "CustomerName").Value))
            {
                var keyword = QueryStrings.FirstOrDefault(d => d.Key == "CustomerName").Value;
                if (keyword.StartsWith("SHIP:") && int.TryParse(keyword.Replace("SHIP:", ""), out int sid))
                {
                    query = query.Where(d => d.Id == sid);
                }
                else if (keyword.StartsWith("C:") && int.TryParse(keyword.Replace("C:", ""), out int cid))
                {
                    query = query.Where(d => d.tbl_CRM_Contact.Id == cid);
                }
                else
                {
                    query = query.Where(d =>
                    d.tbl_CRM_Contact.Name.Contains(keyword)
                    || d.tbl_CRM_Contact.WorkPhone.Contains(keyword)
                    || d.tbl_CRM_Contact.tbl_CRM_ContactReference.Any(e => !e.IsDeleted && e.Code.Contains(keyword))
                    );
                }
            }

            //Debt in shipment
            if (QueryStrings.Any(d => d.Key == "IDShipment"))
            {
                var IDList = QueryStrings.FirstOrDefault(d => d.Key == "IDShipment").Value.Replace("[", "").Replace("]", "").Split(',');
                List<int> IDs = new List<int>();
                foreach (var item in IDList)
                    if (int.TryParse(item, out int i))
                        IDs.Add(i);
                if (IDs.Count > 0)
                    query = query.Where(d => d.tbl_SHIP_ShipmentDebt.Any(e => e.IsDeleted == false && IDs.Contains(e.IDShipment)));
            }
            else if (QueryStrings.Any(d => d.Key == "ShowDebt"))
            {
                var type = QueryStrings.FirstOrDefault(d => d.Key == "ShowDebt").Value;
                List<int> notReturnShipmentStatus = new List<int>() {
                        320 , //	Chuẩn bị đi thu	33
                        321 , //	Đang đi thu	33
                        //322 , //	Đóng - Đã thu một phần	33
                        //323 , //	Đóng - Đã thu xong	33
                        //324 , //	Đóng - Khách hẹn lại	33
                        //325 , //	Đóng - Không liên lạc được	33
                        326 , //	SAI TIỀN - Khách khiếu nại	33
                        //327 , //	MẤT PHIẾU	33
                    };

                if (type == "All")
                {
                    query = query.Where(d => d.IDStatus == 113);
                }
                else if (type == "IsInProgress")
                {
                    //Còn nợ và không có ai đang đi thu
                    query = query.Where(d =>
                        !d.IsPaymentReceived && d.Debt > 0
                        && (
                            d.tbl_SHIP_ShipmentDebt.Any(e => !e.IsDeleted && !e.tbl_SHIP_Shipment.IsDeleted && e.tbl_SHIP_Shipment.IDStatus != 328 && notReturnShipmentStatus.Contains(e.IDStatus))
                            || d.tbl_SHIP_ShipmentDetail.Any(e => !e.IsDeleted && !e.tbl_SHIP_Shipment.IsDeleted && e.tbl_SHIP_Shipment.IDStatus != 328)
                        )
                    );
                }
                else if (type == "IsNotInProgress")
                {
                    //nợ và không ai đang thu
                    query = query.Where(d =>
                        !d.IsPaymentReceived && d.Debt > 0
                        && !d.tbl_SHIP_ShipmentDebt.Any(e => !e.IsDeleted && !e.tbl_SHIP_Shipment.IsDeleted && e.tbl_SHIP_Shipment.IDStatus != 328 && notReturnShipmentStatus.Contains(e.IDStatus))
                        && !d.tbl_SHIP_ShipmentDetail.Any(e => !e.IsDeleted && !e.tbl_SHIP_Shipment.IsDeleted && e.tbl_SHIP_Shipment.IDStatus != 328)
                        );
                }



            }

            query = query.Where(d => d.Debt > (d.DiscountFromSalesman - d.ReceivedDiscountFromSalesman));


            query = BS_SALE_Order._sortBuilder(query, QueryStrings);
            query = BS_SALE_Order._pagingBuilder(query, QueryStrings);

            var result = query.Select(s => new
            {
                s.Id,
                s.Code,
                s.Name,
                s.OrderDate,
                s.ExpectedDeliveryDate,
                s.IDStatus,
                s.IDContact,
                CustomerName = s.tbl_CRM_Contact.Name,
                s.tbl_CRM_Contact.WorkPhone,
                s.tbl_CRM_PartnerAddress.AddressLine1,
                s.tbl_CRM_PartnerAddress.AddressLine2,
                s.tbl_CRM_PartnerAddress.Ward,
                s.tbl_CRM_PartnerAddress.District,
                s.tbl_CRM_PartnerAddress.Province,
                s.tbl_CRM_PartnerAddress.Country,
                s.tbl_CRM_PartnerAddress.Lat,
                s.tbl_CRM_PartnerAddress.Long,


                RouteName = s.tbl_CRM_Contact.tbl_CRM_RouteDetail.Any(d => d.IsDeleted == false && d.tbl_CRM_Route.IsDeleted == false) ? s.tbl_CRM_Contact.tbl_CRM_RouteDetail.FirstOrDefault(d => d.IsDeleted == false && d.tbl_CRM_Route.IsDeleted == false).tbl_CRM_Route.Name : "",
                IDRoute = s.tbl_CRM_Contact.tbl_CRM_RouteDetail.Any(d => d.IsDeleted == false && d.tbl_CRM_Route.IsDeleted == false) ? s.tbl_CRM_Contact.tbl_CRM_RouteDetail.FirstOrDefault(d => d.IsDeleted == false && d.tbl_CRM_Route.IsDeleted == false).IDRoute : 0,

                SellerName = s.tbl_HRM_Staff != null ? s.tbl_HRM_Staff.FullName : "",
                IDSeller = s.tbl_HRM_Staff != null ? s.IDOwner : 0,

                //RefCodes = s.tbl_CRM_Contact.tbl_CRM_ContactReference.Select(ss => new { ss.Code, IDVendor = ss.tbl_CRM_Contact.Id, VendorName = ss.tbl_CRM_Contact.Name }),
                //s.IDBranch,
                //BranchName = s.tbl_BRA_Branch.Name,

                s.TotalAfterTax,
                s.Debt


            }).ToList();

            return Ok(result);
        }

        [Route("SalemanDebtList")]
        public IHttpActionResult GetSalemanDebtList()
        {



            var query = BS_SALE_Order._queryBuilder(db, IDBranch, StaffID, QueryStrings);
            //Query RefID (string)
            if (QueryStrings.Any(d => d.Key == "CustomerName") && !string.IsNullOrEmpty(QueryStrings.FirstOrDefault(d => d.Key == "CustomerName").Value))
            {
                var keyword = QueryStrings.FirstOrDefault(d => d.Key == "CustomerName").Value;
                if (keyword.StartsWith("SHIP:") && int.TryParse(keyword.Replace("SHIP:", ""), out int id))
                {
                    query = query.Where(d => d.Id == id);
                }
                else if (keyword.StartsWith("C:") && int.TryParse(keyword.Replace("C:", ""), out int cid))
                {
                    query = query.Where(d => d.tbl_CRM_Contact.Id == cid);
                }
                else
                {
                    query = query.Where(d =>
                    d.tbl_CRM_Contact.Name.Contains(keyword)
                    || d.tbl_CRM_Contact.WorkPhone.Contains(keyword)
                    || d.tbl_CRM_Contact.tbl_CRM_ContactReference.Any(e => !e.IsDeleted && e.Code.Contains(keyword))
                    );
                }
            }

            if (QueryStrings.Any(d => d.Key == "SellerName") && !string.IsNullOrEmpty(QueryStrings.FirstOrDefault(d => d.Key == "SellerName").Value))
            {
                var keyword = QueryStrings.FirstOrDefault(d => d.Key == "SellerName").Value;

                query = query.Where(d =>
                d.tbl_HRM_Staff.FullName.Contains(keyword)
                || d.tbl_HRM_Staff.PhoneNumber.Contains(keyword)
                || d.tbl_HRM_Staff.Code.Contains(keyword)
                );

            }



            if (QueryStrings.Any(d => d.Key == "ShowDebt"))
            {
                var type = QueryStrings.FirstOrDefault(d => d.Key == "ShowDebt").Value;
                if (type == "All")
                {
                    query = query.Where(d => d.IDStatus == 113 && d.ReceivedDiscountFromSalesman < d.DiscountFromSalesman);
                }

            }




            query = BS_SALE_Order._sortBuilder(query, QueryStrings);
            //query = BS_SALE_Order._pagingBuilder(query, QueryStrings);

            var result = query.Select(s => new
            {
                s.Id,
                s.Code,
                s.Name,
                s.OrderDate,
                s.ExpectedDeliveryDate,
                s.IDStatus,
                s.IDContact,
                CustomerName = s.tbl_CRM_Contact.Name,
                s.tbl_CRM_Contact.WorkPhone,


                RouteName = s.tbl_CRM_Contact.tbl_CRM_RouteDetail.Any(d => d.IsDeleted == false && d.tbl_CRM_Route.IsDeleted == false) ? s.tbl_CRM_Contact.tbl_CRM_RouteDetail.FirstOrDefault(d => d.IsDeleted == false && d.tbl_CRM_Route.IsDeleted == false).tbl_CRM_Route.Name : "",
                IDRoute = s.tbl_CRM_Contact.tbl_CRM_RouteDetail.Any(d => d.IsDeleted == false && d.tbl_CRM_Route.IsDeleted == false) ? s.tbl_CRM_Contact.tbl_CRM_RouteDetail.FirstOrDefault(d => d.IsDeleted == false && d.tbl_CRM_Route.IsDeleted == false).IDRoute : 0,

                SellerName = s.tbl_HRM_Staff != null ? s.tbl_HRM_Staff.FullName : "",
                IDSeller = s.tbl_HRM_Staff != null ? s.IDOwner : 0,

                //RefCodes = s.tbl_CRM_Contact.tbl_CRM_ContactReference.Select(ss => new { ss.Code, IDVendor = ss.tbl_CRM_Contact.Id, VendorName = ss.tbl_CRM_Contact.Name }),
                //s.IDBranch,
                //BranchName = s.tbl_BRA_Branch.Name,

                s.TotalAfterTax,
                s.Debt,

                s.DiscountFromSalesman,
                s.ReceivedDiscountFromSalesman,


            }).ToList();

            return Ok(result);
        }

        [Route("CreateReceipt")]
        [ResponseType(typeof(DTO_SALE_Order))]
        public IHttpActionResult PostCreateReceipt(DTO_CreateReceipt item)
        {

            if (item.IDOwner == 0 || item.Amount == 0)
            {
                return BadRequest("Owner or Payment amount is not valid");// Ok();
            }


            var query = db.tbl_SALE_Order.Where(d => d.IDOwner == item.IDOwner && d.IDStatus == 113 && d.ReceivedDiscountFromSalesman < d.DiscountFromSalesman && d.IsDeleted == false);

            if (item.Ids != null && item.Ids.Count > 0)
            {
                query = query.Where(d => item.Ids.Contains(d.Id));
            }

            var totalDebt = query.Sum(s => (s.DiscountFromSalesman - s.ReceivedDiscountFromSalesman));
            if (item.Amount > totalDebt)
            {
                return BadRequest("Payment amount is not valid");// Ok();
            }

            int index = 0;
            decimal total = item.Amount;
            query = query.OrderBy(o => o.OrderDate);

            var incomingPayment = new tbl_BANK_IncomingPayment()
            {
                IDBranch = item.IDBranch,
                IDStaff = item.IDOwner,
                DocumentDate = item.PostDate,
                DueDate = item.PostDate,
                PostingDate = item.PostDate,
                IDType = 51,
                Amount = item.Amount,
                CreatedBy = Username,
                ModifiedBy = Username,
                CreatedDate = DateTime.Now,
                ModifiedDate = DateTime.Now
            };
            db.tbl_BANK_IncomingPayment.Add(incomingPayment);

            while (total > 0)
            {
                var order = query.Skip(index).Take(1).FirstOrDefault();

                var amount = order.DiscountFromSalesman - order.ReceivedDiscountFromSalesman;
                if (total < amount)
                {
                    amount = total;
                }

                var ipd = new tbl_BANK_IncomingPaymentDetail()
                {
                    IDBranch = item.IDBranch,
                    IDSaleOrder = order.Id,
                    Amount = amount,
                    CreatedBy = Username,
                    ModifiedBy = Username,
                    CreatedDate = DateTime.Now,
                    ModifiedDate = DateTime.Now
                };
                incomingPayment.tbl_BANK_IncomingPaymentDetail.Add(ipd);

                order.ReceivedDiscountFromSalesman += amount;
                order.Received += amount;
                order.Debt -= amount;

                if (order.DiscountFromSalesman == order.ReceivedDiscountFromSalesman)
                {
                    order.IDStatus = 114;
                }
                index++;
                total = total - amount;
            }

            db.SaveChanges();


            return Ok();
        }

        [Route("MobileList")]
        public IHttpActionResult GetMobileList()
        {
            var query = BS_SALE_Order._queryBuilder(db, IDBranch, StaffID, QueryStrings);

            //Query RefID (string)
            if (QueryStrings.Any(d => d.Key == "CustomerName") && !string.IsNullOrEmpty(QueryStrings.FirstOrDefault(d => d.Key == "CustomerName").Value))
            {
                var keyword = QueryStrings.FirstOrDefault(d => d.Key == "CustomerName").Value;
                if (keyword.StartsWith("O:") && int.TryParse(keyword.Replace("O:", ""), out int id))
                {
                    query = query.Where(d => d.Id == id);
                }
                else
                {
                    query = query.Where(d =>
                    d.tbl_CRM_Contact.Name.Contains(keyword)
                    || d.tbl_CRM_Contact.WorkPhone.Contains(keyword)
                    || d.tbl_CRM_Contact.tbl_CRM_ContactReference.Any(e => !e.IsDeleted && e.Code.Contains(keyword))
                    );
                }
            }

            query = BS_SALE_Order._sortBuilder(query, QueryStrings);
            query = BS_SALE_Order._pagingBuilder(query, QueryStrings);

            var result = query.Select(s => new
            {
                s.Id,
                s.Code,
                s.Name,
                s.OrderDate,
                s.ExpectedDeliveryDate,
                s.IDStatus,
                Status = new { s.tbl_SYS_Status.Id, s.tbl_SYS_Status.Name, s.tbl_SYS_Status.Color },
                s.IDContact,
                CustomerName = s.tbl_CRM_Contact.Name,
                s.tbl_CRM_Contact.WorkPhone,
                s.tbl_CRM_PartnerAddress.AddressLine1,
                s.tbl_CRM_PartnerAddress.AddressLine2,
                s.tbl_CRM_PartnerAddress.Ward,
                s.tbl_CRM_PartnerAddress.District,
                s.tbl_CRM_PartnerAddress.Province,
                s.tbl_CRM_PartnerAddress.Country,
                s.tbl_CRM_PartnerAddress.Lat,
                s.tbl_CRM_PartnerAddress.Long,
                RefCodes = s.tbl_CRM_Contact.tbl_CRM_ContactReference.Select(ss => new { ss.Code, IDVendor = ss.tbl_CRM_Contact.Id, VendorName = ss.tbl_CRM_Contact.Name }),
                s.IDBranch,
                BranchName = s.tbl_BRA_Branch.Name,
                s.OriginalTotalBeforeDiscount,
                s.OriginalTotalDiscount,
                s.OriginalTotalAfterDiscount,
                s.OriginalTax,
                s.OriginalTotalAfterTax


            }).ToList();

            return Ok(result);
        }

        [Route("Add")]
        [ResponseType(typeof(DTO_SALE_Order))]
        public IHttpActionResult PostAddNewOrder(DTO_SALE_Order item)
        {
            tbl_SALE_Order dbitem = null;
            string err = "";

            if (item.Id == 0 && !string.IsNullOrEmpty(item.Code) && BS_SALE_Order.check_Exists(db, item.Code))
            {
                item.Id = BS_SALE_Order.getAnItemByCode(db, IDBranch, StaffID, item.Code).Id;
            }

            if (item.Id == 0)
            {
                dbitem = new tbl_SALE_Order();
                dbitem.IDOwner = item.IDOwner = StaffID;
                dbitem.IDAddress = item.IDAddress;
                dbitem.OrderDate = item.OrderDate = DateTime.Now;
                dbitem.CreatedBy = Username;
                dbitem.CreatedDate = DateTime.Now;
                db.tbl_SALE_Order.Add(dbitem);
            }
            else
            {
                return Conflict();
                //dbitem = db.tbl_SALE_Order.Find(item.Id);
            }

            if (dbitem == null || dbitem.IsDeleted)
            {
                return BadRequest(ModelState);
            }

            if (item.OrderLines == null)
            {
                item.OrderLines = new List<DTO_SALE_OrderDetail>();
            }

            var itemIds = item.OrderLines.Select(s => s.IDItem).Distinct().ToList();
            var itemUoMs = db.tbl_WMS_ItemUoM.Where(d => itemIds.Contains(d.IDItem) && d.IsDeleted == false).ToList();
            BS_SALE_Order.calcOrder(dbitem, item, Username, DateTime.Now, out err, itemUoMs);
            db.SaveChanges();

            if (dbitem != null)
            {
                return CreatedAtRoute("get_SALE_Order", new { id = dbitem.Id }, dbitem);
            }
            return Conflict();

        }

        [Route("Update/{id:int}")]
        [ResponseType(typeof(void))]
        public IHttpActionResult PutUpdate(int id, DTO_SALE_Order item)
        {

            string err = "";
            tbl_SALE_Order dbitem = db.tbl_SALE_Order.Find(item.Id);

            if (!ModelState.IsValid || dbitem == null || dbitem.IsDeleted || Username == null)
            {
                return BadRequest(ModelState);
            }

            List<int> lockedStatus = new List<int>() { 104, 105, 106, 107, 108, 109, 111, 112, 113, 114, 115 };
            if (lockedStatus.Contains(dbitem.IDStatus))
                return BadRequest("Order was locked!");

            if (dbitem.IDOwner == 0 || item.IDOwner == 0)
            {
                dbitem.IDOwner = item.IDOwner = StaffID;
                dbitem.IDAddress = item.IDAddress;
                dbitem.OrderDate = item.OrderDate = DateTime.Now;
                dbitem.CreatedBy = Username;
                dbitem.CreatedDate = DateTime.Now;
            }

            var itemIds = item.OrderLines.Select(s => s.IDItem).Distinct().ToList();
            var itemUoMs = db.tbl_WMS_ItemUoM.Where(d => itemIds.Contains(d.IDItem) && d.IsDeleted == false).ToList();
            BS_SALE_Order.calcOrder(dbitem, item, Username, DateTime.Now, out err, itemUoMs);
            db.SaveChanges();

            if (dbitem != null)
                return StatusCode(HttpStatusCode.NoContent);
            else
                return BadRequest(err);

        }
        
        [HttpGet]
        [Route("SaleSalemanReport")]
        public IHttpActionResult SaleSalemanReport()
        {

            //Query OrderDate (System.DateTime)
            if (QueryStrings.Any(d => d.Key == "fromDate") && QueryStrings.Any(d => d.Key == "toDate"))
            {
                var results = BS_SALE_Order.calcSaleSalemanReport(db, QueryStrings);
                return Ok(results);
            }
            else
            {
                return BadRequest("Order date filter is required");
            }
        }

        [HttpGet]
        [Route("SaleOrderReport")]
        public IHttpActionResult SaleOrderReport()
        {
            if (QueryStrings.Any(d=>d.Key == "IsCalcShippedOnly"))
            {
                QueryStrings.Remove("IsCalcShippedOnly");
            }

            //Query OrderDate (System.DateTime)
            if (QueryStrings.Any(d => d.Key == "fromDate") && QueryStrings.Any(d => d.Key == "toDate"))
            {
                var results = BS_SALE_Order.calcSaleOrderReport(db, QueryStrings);
                return Ok(results);
            }
            else
            {
                return BadRequest("Order date filter is required");
            }
        }

        [HttpGet]
        [Route("SaleProductReport")]
        public IHttpActionResult SaleProductReport()
        {

            //Query OrderDate (System.DateTime)
            if (QueryStrings.Any(d => d.Key == "fromDate") && QueryStrings.Any(d => d.Key == "toDate"))
            {
                var results = BS_SALE_Order.calcSaleProductReport(db, QueryStrings);
                return Ok(results);
            }
            else
            {
                return BadRequest("Order date filter is required");
            }
        }

        [Route("ExportSaleProductReport")]
        public IHttpActionResult Get_ExportSaleProductReport()
        {
            if (!(QueryStrings.Any(d => d.Key == "fromDate") && QueryStrings.Any(d => d.Key == "toDate")))
            {
                return BadRequest("Order date filter is required");
            }

            string fileurl = "";

            var package = GetTemplateWorkbook("SaleOrders_Report_Template.xlsx", "SaleOrders_Report.xlsx", out fileurl);
            BS_SALE_Order.ExportSaleProductReport(package, db, IDBranch, StaffID, QueryStrings);

            package.Workbook.Properties.Title = "[ART-DMS] Sale order report";
            package.Workbook.Properties.Author = "hung.vu@codeart.vn";
            package.Workbook.Properties.Application = "ART-DMS";
            package.Workbook.Properties.Company = "A.R.T Distribution";

            package.Save();

            return Ok(fileurl); //downloadExcelFile(package, "SALE_Order.xlsx");
        }

        [HttpGet]
        [Route("SaleOutletReport")]
        public IHttpActionResult SaleOutletReport()
        {

            //Query OrderDate (System.DateTime)
            if (QueryStrings.Any(d => d.Key == "fromDate") && QueryStrings.Any(d => d.Key == "toDate"))
            {
                var results = BS_SALE_Order.calcSaleOutletReport(db, QueryStrings);
                return Ok(results);
            }
            else
            {
                return BadRequest("Order date filter is required");
            }
        }

        [Route("ExportSaleOutletReport")]
        public IHttpActionResult Get_ExportSaleOutletReport()
        {
            if (!(QueryStrings.Any(d => d.Key == "fromDate") && QueryStrings.Any(d => d.Key == "toDate")))
            {
                return BadRequest("Order date filter is required");
            }

            string fileurl = "";

            var package = GetTemplateWorkbook("SaleOrders_Outlet_Report_Template.xlsx", "SaleOrders_Report.xlsx", out fileurl);
            BS_SALE_Order.ExportSaleOutletReport(package, db, IDBranch, StaffID, QueryStrings);

            package.Workbook.Properties.Title = "[ART-DMS] Sale order report";
            package.Workbook.Properties.Author = "hung.vu@codeart.vn";
            package.Workbook.Properties.Application = "ART-DMS";
            package.Workbook.Properties.Company = "A.R.T Distribution";

            package.Save();

            return Ok(fileurl); //downloadExcelFile(package, "SALE_Order.xlsx");
        }



        [Route("MergeOrders")]
        [ResponseType(typeof(DTO_SALE_Order))]
        public IHttpActionResult PostMergeOrders(DTO_MergeSaleOrders item)
        {
            item.IDOwner = StaffID;
            item.CreatedBy = Username;

            if (item.IDContact == 0)
            {
                return BadRequest(ModelState);
            }

            tbl_SALE_Order dbitem = BS_SALE_Order.mergeOrders(db, item);

            if (dbitem != null)
            {
                List<int> lockedStatus = new List<int>() { 104, 105, 106, 107, 108, 109, 111, 112, 113, 114, 115 };
                if (lockedStatus.Contains(dbitem.IDStatus))
                    return BadRequest("Order was locked!");
                
                return CreatedAtRoute("get_SALE_Order", new { id = dbitem.Id }, new DTO_SALE_Order() { Id = dbitem.Id });
            }
            return Conflict();

        }

        [Route("SplitOrder")]
        public IHttpActionResult PostSplitOrder(DTO_SplitSaleOrders item)
        {

            List<int> lockedStatus = new List<int>() { 104, 105, 106, 107, 108, 109, 111, 112, 113, 114, 115 };
            var dbitem = db.tbl_SALE_Order.Find(item.Id);
            if (lockedStatus.Contains(dbitem.IDStatus))
                return BadRequest("Order was locked!");

            item.IDOwner = StaffID;
            item.CreatedBy = Username;

            if (false)
            {
                return BadRequest(ModelState);
            }

            BS_SALE_Order.splitOrder(db, item);

            return Ok();
        }


        [Route("SubmitOrdersForApproval")]
        public IHttpActionResult PostSubmitOrdersForApproval(DTO_ApproveOrders item)
        {
            BS_SALE_Order.submitOrdersForApproval(db, item);
            db.SaveChanges();
            return Ok();
        }


        [Route("SubmitSalesmanOrdersForApproval")]
        public IHttpActionResult PostSubmitSalesmanOrdersForApproval()
        {
            BS_SALE_Order.submitSalesmanOrdersForApproval(db, StaffID);
            db.SaveChanges();
            return Ok();
        }


        [Route("ApproveOrders")]
        public IHttpActionResult PostApproveOrders(DTO_ApproveOrders item)
        {
            BS_SALE_Order.approveOrders(db, item);
            db.SaveChanges();
            return Ok();
        }

        [Route("DisapproveOrders")]
        public IHttpActionResult PostDisApproveOrders(DTO_ApproveOrders item)
        {


            BS_SALE_Order.disapproveOrders(db, item);
            db.SaveChanges();
            return Ok();
        }

        [Route("CancelOrders")]
        public IHttpActionResult PostCancelOrders(DTO_ApproveOrders item)
        {
            BS_SALE_Order.cancelOrders(db, item);
            db.SaveChanges();
            return Ok();
        }
    }

    public partial class SALE_OrderDetailController : CustomApiController
    {
        [Route("List")]
        public IHttpActionResult GetList()
        {
            var query = BS_SALE_OrderDetail._queryBuilder(db, IDBranch, StaffID, QueryStrings);


            query = BS_SALE_OrderDetail._sortBuilder(query, QueryStrings);
            query = BS_SALE_OrderDetail._pagingBuilder(query, QueryStrings);

            var ids = query.Select(s => s.Id).ToList();

            var q = db.tbl_SALE_OrderDetail.Where(d => ids.Contains(d.Id));
            var result = BS_SALE_OrderDetail._sortBuilder(q, QueryStrings).Select(s => new
            {
                Id = s.Id,
                IDOrder = s.IDOrder,
                IDItem = s.IDItem,
                ItemName = s.tbl_WMS_Item.Name,
                UoMName = s.tbl_WMS_ItemUoM.Name,
                IDUoM = s.IDUoM,
                UoMPrice = s.UoMPrice,
                Quantity = s.Quantity,
                UoMSwap = s.UoMSwap,
                IDBaseUoM = s.IDBaseUoM,
                BaseQuantity = s.BaseQuantity,
                IsPromotionItem = s.IsPromotionItem,
                IDTax = s.IDTax,
                TaxRate = s.TaxRate,

                OriginalTotalBeforeDiscount = s.OriginalTotalBeforeDiscount,
                OriginalPromotion = s.OriginalPromotion,
                OriginalDiscount1 = s.OriginalDiscount1,
                OriginalDiscount2 = s.OriginalDiscount2,
                OriginalDiscountByItem = s.OriginalDiscountByItem,
                OriginalDiscountByGroup = s.OriginalDiscountByGroup,
                OriginalDiscountByLine = s.OriginalDiscountByLine,
                OriginalDiscountByOrder = s.OriginalDiscountByOrder,
                OriginalDiscountFromSalesman = s.OriginalDiscountFromSalesman,
                OriginalTotalDiscount = s.OriginalTotalDiscount,
                OriginalTotalAfterDiscount = s.OriginalTotalAfterDiscount,
                OriginalTax = s.OriginalTax,
                OriginalTotalAfterTax = s.OriginalTotalAfterTax,

                ShippedQuantity = s.ShippedQuantity,
                ReturnedQuantity = s.ReturnedQuantity,

                TotalBeforeDiscount = s.TotalBeforeDiscount,
                Discount1 = s.Discount1,
                Discount2 = s.Discount2,
                DiscountByItem = s.DiscountByItem,
                Promotion = s.Promotion,
                DiscountByGroup = s.DiscountByGroup,
                DiscountByLine = s.DiscountByLine,
                DiscountByOrder = s.DiscountByOrder,
                DiscountFromSalesman = s.DiscountFromSalesman,
                TotalDiscount = s.TotalDiscount,
                TotalAfterDiscount = s.TotalAfterDiscount,
                Tax = s.Tax,
                TotalAfterTax = s.TotalAfterTax,

                Remark = s.Remark,


            });


            return Ok(result);
        }
    }
}