namespace BaseBusiness
{
    using System;
    using System.Collections.Generic;
    using System.Data;
    using System.Data.Entity;
    using OfficeOpenXml;
    using System.Linq;
    using DTOModel;
    using ClassLibrary;
    using System.Data.Entity.Validation;

    public static partial class BS_SHIP_Shipment
    {

        public static tbl_SHIP_Shipment calc_Shipment(AppEntities db, int IDBranch, DTO_SHIP_Shipment item, string Username, out string err)
        {
            err = "";

            if (item.OrderIds == null)
            {
                item.OrderIds = new List<int>();
            }
            if (item.DebtOrderIds == null)
            {
                item.DebtOrderIds = new List<int>();
            }

            if (item.Id == 0 && !string.IsNullOrEmpty(item.Code))
            {
                tbl_SHIP_Shipment dbitem = db.tbl_SHIP_Shipment.FirstOrDefault(d => d.IsDeleted == false && d.IDVehicle == item.IDVehicle && d.DeliveryDate == item.DeliveryDate);
                if (dbitem != null)
                {
                    item.Id = dbitem.Id;
                }
            }

            if (item.Id > 0)
            {

                if (checkLockedStatus(item.IDStatus, out err))
                {
                    return null;
                }


                var shipmentDetails = db.tbl_SHIP_ShipmentDetail.Where(d =>
                    d.IDShipment != item.Id
                    && d.IDSaleOrder.HasValue
                    && item.OrderIds.Contains(d.IDSaleOrder.Value)
                    && d.IsDeleted == false
                    && d.tbl_SHIP_Shipment.IsDeleted == false
                    && d.tbl_SHIP_Shipment.IDStatus == 301 //Đã phân tài
                );

                foreach (var s in shipmentDetails)
                {
                    s.IsDeleted = true;
                    s.ModifiedBy = Username;
                    s.ModifiedDate = DateTime.Now;
                    //TODO: re-calc deleted shipments
                }


                //delete removed lines

                var deletedLines = db.tbl_SHIP_ShipmentDetail.Where(d => d.IDShipment == item.Id && d.IsDeleted == false && d.IDSaleOrder.HasValue && !item.OrderIds.Contains(d.IDSaleOrder.Value)).Select(s => new { s.Id, s.IDSaleOrder }).ToList();

                var deletedLineIds = deletedLines.Select(s => s.Id).Distinct().ToArray();
                var revertOrderIds = deletedLines.Select(s => s.IDSaleOrder).Distinct().ToArray();

                if (deletedLineIds.Length > 0)
                {
                    BS_SHIP_ShipmentDetail.delete(db, string.Join(",", deletedLineIds), Username);


                    var orders = db.tbl_SALE_Order.Where(d => revertOrderIds.Contains(d.Id) && d.IDStatus == 105).ToList();
                    foreach (var o in orders)
                    {
                        o.IDStatus = 104; //Đã duyệt
                    }

                }

                //delete removed debt lines

                var deletedDebtLineIds = db.tbl_SHIP_ShipmentDebt.Where(d =>
                    d.IDShipment == item.Id && d.IsDeleted == false && d.IDSaleOrder.HasValue && !item.DebtOrderIds.Contains(d.IDSaleOrder.Value)
                ).Select(s => s.Id).Distinct().ToArray();

                if (deletedDebtLineIds.Length > 0)
                {
                    BS_SHIP_ShipmentDebt.delete(db, string.Join(",", deletedDebtLineIds), Username);
                }
            }
            return calcItem(db, item, Username, DateTime.Now);
        }

        public static bool checkLockedStatus(int IDStatus, out string err)
        {
            List<int> lockedStatus = new List<int>() {
                        304 ,	//	Đang đóng gói
                        305 ,	//	Đang giao hàng
                        306 ,	//	Đóng - Đã giao hàng
                    };

            if (lockedStatus.Contains(IDStatus))
            {
                err = "Can not update, please check Shipment status";
                return true;
            }
            else
            {
                err = "";
                return false;
            }
        }

        private static tbl_SHIP_Shipment calcItem(AppEntities db, DTO_SHIP_Shipment item, string Username, DateTime ModifiedDate)
        {
            tbl_SHIP_Shipment dbitem = null;
            if (item.Id > 0)
            {
                dbitem = db.tbl_SHIP_Shipment.FirstOrDefault(d => d.IsDeleted == false && (d.Id == item.Id));
                if (dbitem == null)
                {
                    return null;
                }
                else
                {
                    if (item.IDStatus == 0)
                    {
                        item.IDStatus = dbitem.IDStatus;
                    }
                }
            }
            else
            {
                dbitem = new tbl_SHIP_Shipment();
                dbitem.CreatedBy = Username;
                dbitem.CreatedDate = ModifiedDate;
                db.tbl_SHIP_Shipment.Add(dbitem);
            }

            BS_SHIP_Shipment.patchDTOtoDBValue(item, dbitem);




            var Orders = item.OrderIds == null ? null : db.tbl_SALE_Order.Where(d => item.OrderIds.Contains(d.Id)).Select(s => new { s.Id, s.ProductWeight, s.ProductDimensions }).ToList();
            var ShipmentDetails = item.Id == 0 ? new List<tbl_SHIP_ShipmentDetail>() : db.tbl_SHIP_ShipmentDetail.Where(d => d.IsDeleted == false && d.IDShipment == item.Id).ToList();
            if (item.OrderIds != null)
            {
                int IDStatus = 0;

                switch (item.IDStatus)
                {
                    case 301: //	Đã phân tài	31
                        IDStatus = 314; //	Đã phân tài	32
                        break;
                    case 302: //	Đã giao đơn vị vận chuyển	31
                        IDStatus = 315; //	Đã giao đơn vị vận chuyển	32
                        break;
                    case 303: //	Đã lấy hàng về kho	31
                        IDStatus = 316; //	Đã lấy hàng về kho	32
                        break;
                    case 304: //	Đang đóng gói	31
                        IDStatus = 317; //	Đang đóng gói	32
                        break;
                    case 305: //	Đang giao hàng	31
                        IDStatus = 318; //	Đang giao hàng	32
                        break;
                    case 306: //	Đóng - Đã giao hàng	31
                        IDStatus = 319; //	Đóng - Đã giao hàng	32
                                        //307; //	Khách hẹn giao lại	32
                                        //308; //	Không liên lạc được	32
                                        //309; //	Đóng - Khách không nhận do hàng lỗi	32
                                        //310; //	Đóng - Khách không nhận do giá	32
                                        //311; //	Đóng - Khách không nhận do khách đổi ý	32
                                        //312; //	Đóng - Khách không nhận do khách hết tiền	32
                                        //313; //	Đóng - Không giao được - lý do khác	32
                        break;
                    case 328:
                    default:
                        IDStatus = 0;
                        break;
                }

                foreach (var IdOrder in item.OrderIds)
                {
                    var order = Orders.Find(d => d.Id == IdOrder);
                    var line = new DTO_SHIP_ShipmentDetail() { IDSaleOrder = IdOrder, ProductWeight = order.ProductWeight, ProductDimensions = order.ProductDimensions };
                    tbl_SHIP_ShipmentDetail dbline = ShipmentDetails.FirstOrDefault(d => d.IDSaleOrder == line.IDSaleOrder);

                    if (dbline == null)
                    {
                        dbline = new tbl_SHIP_ShipmentDetail();
                        dbitem.tbl_SHIP_ShipmentDetail.Add(dbline);
                        dbline.CreatedBy = Username;
                        dbline.CreatedDate = ModifiedDate;
                    }

                    if (IDStatus != 0)
                    {
                        dbline.IDStatus = IDStatus;
                    }


                    dbline.IDSaleOrder = line.IDSaleOrder;
                    dbline.ProductWeight = line.ProductWeight;
                    dbline.ProductDimensions = line.ProductDimensions;


                    dbline.ModifiedBy = Username;
                    dbline.ModifiedDate = ModifiedDate;

                }
                if (IDStatus != 0)
                {
                    updateShipmentDetailStatus(db, new List<int>(), IDStatus, item.OrderIds);
                }
            }


            var DebtOrders = item.DebtOrderIds == null ? null : db.tbl_SALE_Order.Where(d => item.DebtOrderIds.Contains(d.Id)).Select(s => new { s.Id, s.Debt }).ToList();
            var ShipmentDebts = item.Id == 0 ? null : db.tbl_SHIP_ShipmentDebt.Where(d => d.IsDeleted == false && d.IDShipment == item.Id).ToList();
            if (item.DebtOrderIds != null)
            {

                int IDStatus = 0;
                switch (item.IDStatus)
                {
                    case 301: //	Đã phân tài	31
                        IDStatus = 320; //	Chuẩn bị đi thu	33
                        break;
                    case 302: //	Đã giao đơn vị vận chuyển	31
                        IDStatus = 320; //	Chuẩn bị đi thu	33
                        break;
                    case 303: //	Đã lấy hàng về kho	31
                        IDStatus = 320; //	Chuẩn bị đi thu	33
                        break;
                    case 304: //	Đang đóng gói	31
                        IDStatus = 320; //	Chuẩn bị đi thu	33
                        break;
                    case 305: //	Đang giao hàng	31
                        IDStatus = 321; //	Đang đi thu	33
                        break;
                    case 306: //	Đóng - Đã giao hàng	31
                    case 328: //    HOÀN TẤT - Đã bàn giao
                    default:
                        IDStatus = 0;
                        break;
                }

                foreach (var IdOrder in item.DebtOrderIds)
                {

                    tbl_SHIP_ShipmentDebt dbline = ShipmentDebts.FirstOrDefault(d => d.IDSaleOrder == IdOrder);
                    if (dbline == null)
                    {
                        dbline = new tbl_SHIP_ShipmentDebt();
                        dbitem.tbl_SHIP_ShipmentDebt.Add(dbline);
                        dbline.IDSaleOrder = IdOrder;
                        dbline.Debt = DebtOrders.Find(d => d.Id == IdOrder).Debt;
                        dbline.CreatedBy = Username;
                        dbline.CreatedDate = ModifiedDate;
                    }
                    if (IDStatus != 0)
                    {
                        dbline.IDStatus = IDStatus;
                    }
                    dbline.ModifiedBy = Username;
                    dbline.ModifiedDate = ModifiedDate;

                }

                if (IDStatus != 0)
                {
                    updateShipmentDebtStatus(db, new List<int>(), IDStatus, item.DebtOrderIds);
                }

            }


            dbitem.ModifiedBy = Username;
            dbitem.ModifiedDate = ModifiedDate;

            //db.SaveChanges();
            return dbitem;
        }

        public static tbl_SHIP_ShipmentDetail PutDelivered(AppEntities db, int IDBranch, DTO_SHIP_ShipmentDetail item, string Username, DateTime ModifiedDate) {

            if (item == null || item.SaleOrder == null || item.SaleOrder.OrderLines == null)
            {
                return null;
            }

            var dbitem = db.tbl_SHIP_ShipmentDetail.Find(item.Id);

            if (dbitem == null)
            {
                return null;
            }

            dbitem.IDStatus = item.IDStatus;
            dbitem.Remark = item.Remark;
            dbitem.Received = item.Received;

            dbitem.ModifiedBy = Username;
            dbitem.ModifiedDate = ModifiedDate;


            //Update sale order
            string err = "";

            var dbSaleOrder = dbitem.tbl_SALE_Order;
            item.SaleOrder.IDAddress = dbSaleOrder.IDAddress;
            var itemIds = item.SaleOrder.OrderLines.Select(s => s.IDItem).Distinct().ToList();
            var itemUoMs = db.tbl_WMS_ItemUoM.Where(d => itemIds.Contains(d.IDItem) && d.IsDeleted == false).ToList();

            BS_SALE_Order.calcOrder(dbSaleOrder, item.SaleOrder, Username, ModifiedDate, out err, itemUoMs);

            updateShipmentDetailStatus(db, new List<int>(), item.IDStatus, new List<int>() { item.SaleOrder.Id });

            return dbitem;
        }

        public static tbl_SHIP_ShipmentDebt PutCollectedDebt(AppEntities db, int IDBranch, DTO_SHIP_ShipmentDebt item, string Username, DateTime ModifiedDate)
        {

            if (item == null || item.SaleOrder == null || item.SaleOrder.OrderLines == null)
            {
                return null;
            }

            var dbitem = db.tbl_SHIP_ShipmentDebt.Find(item.Id);

            if (dbitem == null)
            {
                return null;
            }

            var totalReceivedDebt = dbitem.tbl_SALE_Order.tbl_SHIP_ShipmentDebt.Where(d => d.IsDeleted == false && d.Id != item.Id && d.tbl_SHIP_Shipment.IsDeleted == false).Sum(s => s.Received);
            var totalReceivedShipmentDetail = dbitem.tbl_SALE_Order.tbl_SHIP_ShipmentDetail.Where(d => d.IsDeleted == false && d.Id != item.Id && d.tbl_SHIP_Shipment.IsDeleted == false).Sum(s => s.Received);
            dbitem.tbl_SALE_Order.Received = totalReceivedDebt + totalReceivedShipmentDetail + item.Received + dbitem.tbl_SALE_Order.OldReceived + dbitem.tbl_SALE_Order.ReceivedDiscountFromSalesman;
            dbitem.tbl_SALE_Order.Debt = dbitem.tbl_SALE_Order.TotalAfterTax - dbitem.tbl_SALE_Order.Received;

            dbitem.tbl_SALE_Order.IsPaymentReceived = (dbitem.tbl_SALE_Order.TotalAfterTax == dbitem.tbl_SALE_Order.Received) && (dbitem.tbl_SALE_Order.Debt == 0);
            if (!dbitem.tbl_SALE_Order.IsDebt)
            {
                dbitem.tbl_SALE_Order.IsDebt = dbitem.tbl_SALE_Order.Debt > 0;
            }

            //113     Còn nợ
            //114     Đã xong
            dbitem.tbl_SALE_Order.IDStatus = dbitem.tbl_SALE_Order.IsPaymentReceived ? 114 : 113;

            dbitem.tbl_SALE_Order.ModifiedBy = Username;
            dbitem.tbl_SALE_Order.ModifiedDate = ModifiedDate;


            //--33    322 NULL Đóng -Đã thu một phần
            //--33    323 NULL Đóng -Đã thu xong

            if (item.Received > 0)
            {
                dbitem.IDStatus = dbitem.tbl_SALE_Order.Debt == 0 ? 323 : 322;
            }
            else
            {
                dbitem.IDStatus = item.IDStatus;
            }

            dbitem.Remark = item.Remark;
            dbitem.Received = item.Received;
            dbitem.ModifiedBy = Username;
            dbitem.ModifiedDate = ModifiedDate;

            //BS_SHIP_Shipment.updateShipmentDebtStatus(db, new List<int>(), dbShipmentDebt.IDStatus, new List<int>() { dbShipmentDebt.tbl_SALE_Order.Id });
            BS_SHIP_Shipment.updateShipmentStatus(db, item.IDShipment);



            return dbitem;
        }


        public static void updateShipmentDetailStatus(AppEntities db, List<int> Ids, int IDStatus, List<int> SaleOrderIds = null)
        {
            var orders = db.tbl_SHIP_ShipmentDetail.Where(d => Ids.Contains(d.Id)).ToList();
            orders.ForEach(o => o.IDStatus = IDStatus);

            if (SaleOrderIds != null)
            {

                int IDOrderStatus = 0;

                switch (IDStatus)
                {
                    case 314: //	Đã phân tài	32
                        IDOrderStatus = 105; //	Đã phân tài
                        break;
                    case 315: //	Đã giao đơn vị vận chuyển	32
                    case 316: //	Đã lấy hàng về kho	32
                        IDOrderStatus = 106; //	Đang lấy hàng - đóng gói
                        break;
                    case 317: //	Đang đóng gói	32
                        IDOrderStatus = 107; //	Đã giao đơn vị vận chuyển
                        break;
                    case 318: //	Đang giao hàng	32
                        IDOrderStatus = 108; //	Đang giao hàng
                        break;
                    case 319: //	Đóng - Đã giao hàng	32
                        IDOrderStatus = 109; //	Đã giao hàng
                        break;
                    case 307: //	Khách hẹn giao lại	32
                    case 308: //	Không liên lạc được	32
                        IDOrderStatus = 110; //	Chờ giao lại
                        break;
                    case 309: //	Đóng - Khách không nhận do hàng lỗi	32
                    case 310: //	Đóng - Khách không nhận do giá	32
                    case 311: //	Đóng - Khách không nhận do khách đổi ý	32
                    case 312: //	Đóng - Khách không nhận do khách hết tiền	32
                    case 313: //	Đóng - Không giao được - lý do khác	32
                        IDOrderStatus = 114; //	Đã xong
                        break;
                    default:
                        IDOrderStatus = 104; //	Đã xác nhận
                        break;
                }

                BS_SALE_Order.updateStatus(db, SaleOrderIds, IDOrderStatus);
            }
        }
        public static void updateShipmentDebtStatus(AppEntities db, List<int> Ids, int IDStatus, List<int> SaleOrderIds = null)
        {
            var orders = db.tbl_SHIP_ShipmentDebt.Where(d => Ids.Contains(d.Id)).ToList();
            orders.ForEach(o => o.IDStatus = IDStatus);

            if (SaleOrderIds != null)
            {
                var doneList = new List<int>() {
                    //320 , //	Chuẩn bị đi thu	33
                    //321 , //	Đang đi thu	33
                    //322 , //	Đóng - Đã thu một phần	33
                    323 , //	Đóng - Đã thu xong	33
                    //324 , //	Đóng - Khách hẹn lại	33
                    //325 , //	Đóng - Không liên lạc được	33
                    //326 , //	SAI TIỀN - Khách khiếu nại	33
                    327 , //	MẤT PHIẾU	33
                };
                int IDOrderStatus = doneList.Contains(IDStatus) ? 114 : 113;
                BS_SALE_Order.updateStatus(db, SaleOrderIds, IDOrderStatus);
            }
        }

        public static void updateShipmentStatus(AppEntities db, int IDShipment)
        {

            var shipment = db.tbl_SHIP_Shipment.Find(IDShipment);

            if (shipment == null || shipment.IDStatus == 328)
            {
                return;
            }

            var checkShipDetailStatus = new List<int>()
            {
                314 , //	Đã phân tài	32
                315 , //	Đã giao đơn vị vận chuyển	32
                316 , //	Đã lấy hàng về kho	32
                317 , //	Đang đóng gói	32
                318 , //	Đang giao hàng	32
                //319 , //	Đóng - Đã giao hàng	32
                //307 , //	Khách hẹn giao lại	32
                //308 , //	Không liên lạc được	32
                //309 , //	Đóng - Khách không nhận do hàng lỗi	32
                //310 , //	Đóng - Khách không nhận do giá	32
                //311 , //	Đóng - Khách không nhận do khách đổi ý	32
                //312 , //	Đóng - Khách không nhận do khách hết tiền	32
                //313 , //	Đóng - Không giao được - lý do khác	32
                
            };
            var checkShipDebtStatus = new List<int>()
            {
                320 , //	Chuẩn bị đi thu	33
                321 , //	Đang đi thu	33
                //322 , //	Đóng - Đã thu một phần	33
                //323 , //	Đóng - Đã thu xong	33
                //324 , //	Đóng - Khách hẹn lại	33
                //325 , //	Đóng - Không liên lạc được	33
                //326 , //	SAI TIỀN - Khách khiếu nại	33
                //327 , //	MẤT PHIẾU	33
            };

            //31  , //	Tình trạng chuyến giao hàng	3
            //32  , //	Tình trạng giao hàng của từng đơn	3
            //33  , //	Tình trạng thu nợ của từng đơn	3

            //301 , //	Đã phân tài	31
            //302 , //	Đã giao đơn vị vận chuyển	31
            //303 , //	Đã lấy hàng về kho	31
            //304 , //	Đang đóng gói	31
            //305 , //	Đang giao hàng	31
            //306 , //	Đóng - Đã giao hàng	31
            //328 , //	HOÀN TẤT - Đã bàn giao	31

            if (shipment.tbl_SHIP_ShipmentDetail.Count(d => d.IsDeleted == false && checkShipDetailStatus.Contains(d.IDStatus)) > 0
                || shipment.tbl_SHIP_ShipmentDebt.Count(d => d.IsDeleted == false && checkShipDebtStatus.Contains(d.IDStatus)) > 0)
            {
                shipment.IDStatus = 305;
            }
            else
            {
                shipment.IDStatus = 306;
            }

        }


        public static void export_AvailbleSaleOrderForShipment(ExcelPackage package, AppEntities db, int IDBranch, int StaffID, Dictionary<string, string> QueryStrings)
        {

            ExcelWorkbook workBook = package.Workbook;
            if (workBook != null)
            {
                var ws = workBook.Worksheets.FirstOrDefault(); //Worksheets["DS"];

                List<int> IdsStatus = new List<int>() { 104 }; //{ 101, 102, 103, 104, 110 };

                var ExcludeShipmentStatus = new List<int>() { 305, 306, 328 };

                if (QueryStrings.Any(d => d.Key == "IsAllOrders"))
                {
                    var qValue = QueryStrings.FirstOrDefault(d => d.Key == "IsAllOrders").Value;
                    if (bool.TryParse(qValue, out bool qBoolValue))
                    {
                        if (qBoolValue)
                        {
                            IdsStatus.AddRange(new List<int>() { 105 });
                        }
                    }
                }



                var query = db.tbl_SALE_Order.Where(d => IdsStatus.Contains(d.IDStatus) && d.IsDeleted == false
                    && !d.tbl_SHIP_ShipmentDetail.Any(e => ExcludeShipmentStatus.Contains(e.tbl_SHIP_Shipment.IDStatus) && e.IsDeleted==false)
                );

                //Query IDBranch (int)
                if (QueryStrings.Any(d => d.Key == "IDBranch"))
                {
                    var IDList = QueryStrings.FirstOrDefault(d => d.Key == "IDBranch").Value.Replace("[", "").Replace("]", "").Split(',');
                    List<int> IDs = new List<int>();
                    foreach (var item in IDList)
                        if (int.TryParse(item, out int i))
                            IDs.Add(i);
                    if (IDs.Count > 0)
                        query = query.Where(d => IDs.Contains(d.IDBranch));
                }

                if (QueryStrings.Any(d => d.Key == "OrderDate"))
                    if (DateTime.TryParse(QueryStrings.FirstOrDefault(d => d.Key == "OrderDate").Value, out DateTime val))
                        query = query.Where(d => DbFunctions.TruncateTime(val) == DbFunctions.TruncateTime(d.OrderDate));

                var ids = query.Select(s => s.Id).ToList();

                var data = db.tbl_SALE_Order.Where(d => ids.Contains(d.Id)).Select(s => new
                {
                    s.Id,
                    s.Code,
                    s.OrderDate,
                    IDCustomer = s.IDContact,
                    CustomerCode = s.tbl_CRM_Contact.Code,
                    CustomerName = s.tbl_CRM_Contact.Name,

                    s.tbl_CRM_PartnerAddress.AddressLine1,
                    s.tbl_CRM_PartnerAddress.AddressLine2,
                    s.tbl_CRM_PartnerAddress.Ward,
                    s.tbl_CRM_PartnerAddress.District,
                    s.tbl_CRM_PartnerAddress.Province,
                    s.tbl_CRM_PartnerAddress.Country,
                    
                    s.tbl_CRM_Contact.IsWholeSale,

                    ProductWeight = s.ProductWeight / 1000,
                    ProductDimensions = s.ProductDimensions / 1000000,

                    Owner = s.tbl_HRM_Staff.FullName,
                    Route = s.tbl_CRM_Contact.tbl_CRM_RouteDetail.Any(d => d.IsDeleted == false && d.tbl_CRM_Route.IsDeleted == false && d.tbl_CRM_Route.IDSeller == s.IDOwner) ?
                      s.tbl_CRM_Contact.tbl_CRM_RouteDetail.FirstOrDefault(d => d.IsDeleted == false && d.tbl_CRM_Route.IsDeleted == false && d.tbl_CRM_Route.IDSeller == s.IDOwner).tbl_CRM_Route.Name : "",

                    s.IsShipBySaleMan,
                    s.IsSampleOrder,
                    s.IsUrgentOrders,
                    s.IDUrgentShipper,

                    s.OriginalTotalBeforeDiscount,

                    shipmentDetail = s.tbl_SHIP_ShipmentDetail
                      .Where(e => e.IsDeleted == false && e.tbl_SHIP_Shipment.IsDeleted == false && !ExcludeShipmentStatus.Contains(e.IDStatus))
                    //IDShipper = 

                });


                //var BRA_BranchList = db.tbl_BRA_Branch.Where(d => d.IsDeleted == false).Select(s => new ItemModel { Id = s.Id, Name = s.Name });
                //var CRM_ContactList = db.tbl_CRM_Contact.Where(d => d.IsDeleted == false).Select(s => new ItemModel { Id = s.Id, Name = s.Name });
                //var CRM_ContractList = db.tbl_CRM_Contract.Where(d => d.IsDeleted == false).Select(s => new ItemModel { Id = s.Id, Name = s.Name });


                //var SYS_StatusList = db.tbl_SYS_Status.Where(d => d.IsDeleted == false).Select(s => new ItemModel { Id = s.Id, Name = s.Name });
                var VehicleList = db.tbl_SHIP_Vehicle.Where(d => d.IsDeleted == false).Select(s => new ItemModel { Id = s.Id, Name = s.tbl_HRM_Staff == null ? s.Name : s.Name + " - " + s.tbl_HRM_Staff.FullName });

                var ShipperList = db.tbl_HRM_Staff.Where(d => d.IsDeleted == false && db.tbl_SHIP_Vehicle.Any(e => e.IDShipper == d.Id)).Select(s => new ItemModel { Id = s.Id, Name = s.FullName });


                int SheetColumnsCount, SheetRowCount = 0;
                SheetColumnsCount = ws.Dimension.End.Column;    // Find End Column
                SheetRowCount = ws.Dimension.End.Row;           // Find End Row

                int rowid = 5;

                int firstColInex = 1;
                foreach (var item in data)
                {
                    for (int i = firstColInex; i <= SheetColumnsCount; i++)
                    {
                        string property = ws.Cells[1, i].Value == null ? "" : ws.Cells[1, i].Text;
                        if (
                            !string.IsNullOrEmpty(property)
                            && (
                                item.GetType().GetProperties().Any(d =>
                                    d.Name == property
                                    || (property.Contains("|") && d.Name == property.Split('|')[1])
                                )
                                ||
                                (property.Contains("|") && property.Split('|')[0] == "SHIP_Vehicle")
                                ||
                                (property.Contains("|") && property.Split('|')[0] == "HRM_Shipper")
                                ||
                                (property.Contains("|") && property.Split('|')[0] == "Shipment")

                            )


                        )
                        {

                            if (property.Contains("|"))
                            {
                                var parts = property.Split('|');

                                if (property == "SHIP_Vehicle|IDVehicle" && item.shipmentDetail.Count() > 0)
                                {
                                    var id = item.shipmentDetail.FirstOrDefault().tbl_SHIP_Shipment.IDVehicle;
                                    if (id != null)
                                    {
                                        int Id = int.Parse(id.ToString());
                                        var it = VehicleList.FirstOrDefault(d => d.Id == Id);
                                        if (it != null)
                                        {
                                            ws.Cells[rowid, i].Value = id.ToString() + ". " + it.Name;
                                        }
                                    }
                                }

                                if (property == "HRM_Shipper|IDShipper" && item.shipmentDetail.Count() > 0)
                                {
                                    var id = item.shipmentDetail.FirstOrDefault().tbl_SHIP_Shipment.IDShipper;
                                    if (id != null)
                                    {
                                        int Id = int.Parse(id.ToString());
                                        var it = ShipperList.FirstOrDefault(d => d.Id == Id);
                                        if (it != null)
                                        {
                                            ws.Cells[rowid, i].Value = id.ToString() + ". " + it.Name;
                                        }
                                    }
                                }



                                if (property == "Shipment|Date" && item.shipmentDetail.Count() > 0)
                                {

                                    ws.Cells[rowid, i].Value = item.shipmentDetail.FirstOrDefault().tbl_SHIP_Shipment.DeliveryDate.Date;

                                }
                                if (property == "Shipment|Time" && item.shipmentDetail.Count() > 0)
                                {
                                    ws.Cells[rowid, i].Value = item.shipmentDetail.FirstOrDefault().tbl_SHIP_Shipment.DeliveryDate.ToString("HH:mm");
                                }

                                //if (parts[0] == "BRA_Branch")
                                //{
                                //    var id = item.GetType().GetProperties().First(o => o.Name == parts[1]).GetValue(item, null);
                                //    if (id != null)
                                //    {
                                //        int Id = int.Parse(id.ToString());
                                //        var it = BRA_BranchList.FirstOrDefault(d => d.Id == Id);
                                //        if (it != null)
                                //        {
                                //            ws.Cells[rowid, i].Value = id.ToString() + ". " + it.Name;
                                //        }
                                //    }
                                //}


                                //if (parts[0] == "CRM_Contact")
                                //{
                                //    var id = item.GetType().GetProperties().First(o => o.Name == parts[1]).GetValue(item, null);
                                //    if (id != null)
                                //    {
                                //        int Id = int.Parse(id.ToString());
                                //        var it = CRM_ContactList.FirstOrDefault(d => d.Id == Id);
                                //        if (it != null)
                                //        {
                                //            ws.Cells[rowid, i].Value = id.ToString() + ". " + it.Name;
                                //        }
                                //    }
                                //}


                                //if (parts[0] == "CRM_Contract")
                                //{
                                //    var id = item.GetType().GetProperties().First(o => o.Name == parts[1]).GetValue(item, null);
                                //    if (id != null)
                                //    {
                                //        int Id = int.Parse(id.ToString());
                                //        var it = CRM_ContractList.FirstOrDefault(d => d.Id == Id);
                                //        if (it != null)
                                //        {
                                //            ws.Cells[rowid, i].Value = id.ToString() + ". " + it.Name;
                                //        }
                                //    }
                                //}


                                //if (parts[0] == "HRM_Staff")
                                //{
                                //    var id = item.GetType().GetProperties().First(o => o.Name == parts[1]).GetValue(item, null);
                                //    if (id != null)
                                //    {
                                //        int Id = int.Parse(id.ToString());
                                //        var it = HRM_StaffList.FirstOrDefault(d => d.Id == Id);
                                //        if (it != null)
                                //        {
                                //            ws.Cells[rowid, i].Value = id.ToString() + ". " + it.Name;
                                //        }
                                //    }
                                //}


                                //if (parts[0] == "SYS_Status")
                                //{
                                //    var id = item.GetType().GetProperties().First(o => o.Name == parts[1]).GetValue(item, null);
                                //    if (id != null)
                                //    {
                                //        int Id = int.Parse(id.ToString());
                                //        var it = SYS_StatusList.FirstOrDefault(d => d.Id == Id);
                                //        if (it != null)
                                //        {
                                //            ws.Cells[rowid, i].Value = id.ToString() + ". " + it.Name;
                                //        }
                                //    }
                                //}

                            }
                            else
                            {
                                ws.Cells[rowid, i].Value = item.GetType().GetProperties().First(o => o.Name == property).GetValue(item, null);
                            }
                        }

                    }

                    //ws.Cells["C" + rowid].Value = item.BookingDate.HasValue ? item.BookingDate.Value.ToString("yyyy-MM-dd hh:mm:ss") : "";

                    rowid++;
                }

                //create a range for the table
                var range = ws.Cells[4, firstColInex, rowid - 1, SheetColumnsCount];
                range.Style.Border.Bottom.Style = OfficeOpenXml.Style.ExcelBorderStyle.Thin;
                range.Style.Border.Bottom.Color.SetColor(System.Drawing.Color.FromArgb(235, 235, 235));
                range.Style.Border.DiagonalDown = true;

                //ws.Cells.AutoFilter = true;
                //ws.Cells.AutoFitColumns(6, 60);

                for (int i = 1; i <= SheetColumnsCount; i++)
                {
                    string property = ws.Cells[1, i].Value == null ? "" : ws.Cells[1, i].Text;
                    if (!string.IsNullOrEmpty(property) && property.Contains("|"))
                    {

                        //if (property.Split('|')[0] == "BRA_Branch")
                        //{
                        //    ExcelUtil.SetValidateData(package, i, BRA_BranchList.ToList());
                        //}

                        if (property.Split('|')[0] == "SHIP_Vehicle")
                        {
                            ExcelUtil.SetValidateData(package, i, VehicleList.ToList());
                        }

                        if (property.Split('|')[0] == "HRM_Shipper")
                        {
                            ExcelUtil.SetValidateData(package, i, ShipperList.ToList());
                        }

                        //if (property.Split('|')[0] == "HRM_Shipper")
                        //{
                        //    ExcelUtil.SetValidateData(package, i, CRM_ContractList.ToList());
                        //}

                        //if (property.Split('|')[0] == "HRM_Staff")
                        //{
                        //    ExcelUtil.SetValidateData(package, i, HRM_StaffList.ToList());
                        //}

                        //if (property.Split('|')[0] == "SYS_Status")
                        //{
                        //    ExcelUtil.SetValidateData(package, i, SYS_StatusList.ToList());
                        //}
                    }
                }
                package.Save();
            }

        }
        public static void export_PickingListByShipments(ExcelPackage package, AppEntities db, int IDBranch, int StaffID, Dictionary<string, string> QueryStrings)
        {

            ExcelWorkbook workBook = package.Workbook;
            if (workBook != null)
            {
                List<int> Ids = new List<int>();
                if (QueryStrings.Any(d => d.Key == "Id"))
                {
                    var IDList = QueryStrings.FirstOrDefault(d => d.Key == "Id").Value.Replace("[", "").Replace("]", "").Split(',');

                    foreach (var item in IDList)
                        if (int.TryParse(item, out int i))
                            Ids.Add(i);
                }

                var shipments = db.tbl_SHIP_Shipment.Where(d => Ids.Contains(d.Id) && !d.IsDeleted);

                var warehouses = shipments.Select(s => s.tbl_BRA_Branch1).Distinct();
                var shipmentDetails = db.tbl_SHIP_ShipmentDetail.Where(d => Ids.Contains(d.IDShipment) && !d.IsDeleted && !d.tbl_SHIP_Shipment.IsDeleted).ToList();
                var orderIds = shipmentDetails.Select(s => s.IDSaleOrder).Distinct();
                var orderLines = db.tbl_SALE_OrderDetail.Where(d => orderIds.Contains(d.IDOrder) && !d.IsDeleted).ToList();
                var itemIds = orderLines.Select(s => s.IDItem).Distinct();
                var items = db.tbl_WMS_Item.Where(d => itemIds.Contains(d.Id)).OrderBy(o => o.Code).Include(im=>im.tbl_WMS_ItemUoM).ToList();
                var itemGroupIds = items.Select(s => s.IDItemGroup).Distinct();
                var itemGroup = db.tbl_WMS_ItemGroup.Where(d => itemGroupIds.Contains(d.Id)).Select(s => new {
                    s.Id, s.Name, s.Sort,
                    
                    Root =  db.fnGetRootItemGroup(s.Id).FirstOrDefault()
                }).OrderBy(o => o.Sort).ToList();

                var roots = itemGroup.Select(s => new { s.Root.Id, s.Root.Name }).Distinct();


                int SheetColumnsCount, SheetRowCount = 0;
                var ws = workBook.Worksheets.FirstOrDefault();
                SheetColumnsCount = ws.Dimension.End.Column;    // Find End Column
                SheetRowCount = ws.Dimension.End.Row;           // Find End Row

                #region report header
                foreach (var w in warehouses)
                {
                    ws.Cells[1, 2].Value += w.Name + "; ";
                }

                ws.Cells[2, 5].Value = "Ngày in: " + (DateTime.Now.ToString("dd/MM/yyyy"));



                #endregion

                int rowid = 6;
                int firstColInex = 2;
                int count = 1;

                #region add Shipment columns
                int shimentColIndex = firstColInex + 3;

                int totalRowCount = rowid + items.Count() + roots.Count() - 1;

                ws.Cells[totalRowCount, firstColInex + 4].Value = "";

                foreach (var s in shipments)
                {
                    if (shimentColIndex > firstColInex + 3)
                    {
                        ws.InsertColumn(shimentColIndex, 2);
                        SheetColumnsCount += 2;
                        ws.Cells[3, firstColInex + 3, totalRowCount, firstColInex + 4].Copy(ws.Cells[3, shimentColIndex, totalRowCount, shimentColIndex + 1]);

                        
                    }
                    ws.Cells[6, shimentColIndex + 1, totalRowCount, shimentColIndex + 1].Style.Fill.PatternType = OfficeOpenXml.Style.ExcelFillStyle.Solid;
                    ws.Cells[6, shimentColIndex + 1, totalRowCount, shimentColIndex + 1].Style.Fill.BackgroundColor.SetColor(1, 242, 242, 242);

                    ws.Cells[3, shimentColIndex].Value = string.Format("{0} ({1})", s.tbl_SHIP_Vehicle.Name, s.DeliveryDate.ToString("dd/MM hh:mm"));
                    ws.Cells[4, shimentColIndex].Value = s.tbl_HRM_Staff.FullName;


                    ws.Cells[3, shimentColIndex, 3, shimentColIndex + 1].Merge = true;
                    ws.Cells[4, shimentColIndex, 4, shimentColIndex + 1].Merge = true;

                    ws.Column(shimentColIndex).Width = 11.33;
                    ws.Column(shimentColIndex + 1).Width = 11.33;

                    shimentColIndex += 2;
                }

                ws.Cells[6, shimentColIndex + 1, totalRowCount, shimentColIndex + 1].Style.Fill.PatternType = OfficeOpenXml.Style.ExcelFillStyle.Solid;
                ws.Cells[6, shimentColIndex + 1, totalRowCount, shimentColIndex + 1].Style.Fill.BackgroundColor.SetColor(1, 242, 242, 242);

                #endregion

                foreach (var r in roots)
                {
                    ws.Cells[rowid, firstColInex].Value = r.Name;
                    ws.Cells[rowid, firstColInex].Style.HorizontalAlignment = OfficeOpenXml.Style.ExcelHorizontalAlignment.Left;
                    rowid++;

                    var gIds = itemGroup.Where(d => d.Root.Id == r.Id).Select(s => s.Id).ToList();

                    foreach (var i in items.Where(d => gIds.Contains(d.IDItemGroup.GetValueOrDefault())))
                    {
                        var baseUoM = i.tbl_WMS_ItemUoM.Where(d => d.IsBaseUoM && !d.IsDeleted).FirstOrDefault();
                        var inventoryUoM = i.tbl_WMS_ItemUoM.Where(d => d.Id == d.tbl_WMS_Item.InventoryUoM).FirstOrDefault();

                        ws.Cells[rowid, firstColInex].Value = count;
                        ws.Cells[rowid, firstColInex + 1].Value = i.Code;
                        ws.Cells[rowid, firstColInex + 2].Value = i.Name;


                        #region add Shipment columns
                        decimal nBaseQty = 0;
                        List<DTO_WMS_ItemUoMCount> notBaseQty = new List<DTO_WMS_ItemUoMCount>();
                        shimentColIndex = firstColInex + 3;
                        foreach (var s in shipments)
                        {
                            var orders = shipmentDetails.Where(d => d.IDShipment == s.Id).Select(so => so.IDSaleOrder);
                            var lines = orderLines.Where(d => orders.Contains(d.IDOrder) && d.IDItem == i.Id).GroupBy(gb => gb.IDUoM).Select(sg => new DTO_WMS_ItemUoMCount
                            {
                                IDUoM = sg.Key,
                                Quantity = sg.Sum(ss => ss.Quantity)
                            }).ToList();

                            decimal iQty = 0;
                            decimal bQty = 0;
                            var cLines = UoMCalc(lines, i, out iQty, out bQty);

                            ws.Cells[rowid, shimentColIndex, rowid, shimentColIndex + 1].Style.Font.Size = 16;
                            ws.Cells[rowid, shimentColIndex, rowid, shimentColIndex + 1].Style.Font.Bold = true;
                            ws.Cells[rowid, shimentColIndex, rowid, shimentColIndex + 1].Style.Font.Name = "Times New Roman";
                            ws.Cells[rowid, shimentColIndex, rowid, shimentColIndex + 1].Style.HorizontalAlignment = OfficeOpenXml.Style.ExcelHorizontalAlignment.Right;

                            string fUoM = "";
                            foreach (var tl in cLines) fUoM += string.Format("{0}{1} {2}", fUoM == "" ? "" : " + ", tl.Quantity.ToString("0.#########"), tl.UoMName);
                            if (bQty > 0) fUoM += fUoM == "" ? bQty.ToString("0.#########") : string.Format("{0}{1} {2}", fUoM == "" ? "" : " + ", bQty.ToString("0.#########"), "lẻ");

                            if (iQty > 0) ws.Cells[rowid, shimentColIndex].Value = iQty;
                            if (fUoM != "")
                            {
                                decimal fQty = 0;
                                if (decimal.TryParse(fUoM, out fQty))
                                {
                                    ws.Cells[rowid, shimentColIndex + 1].Value = fQty;
                                }
                                else
                                {
                                    ws.Cells[rowid, shimentColIndex + 1].Value = fUoM;
                                }
                            }

                            nBaseQty += bQty;
                            notBaseQty.AddRange(cLines);

                            shimentColIndex += 2;
                        }
                        #endregion

                        #region Total column
                        decimal inventoryQty = 0;
                        decimal baseQty = 0;
                        var totalLines = orderLines.Where(d => d.IDItem == i.Id).GroupBy(gb => gb.IDUoM).Select(sg => new DTO_WMS_ItemUoMCount
                        {
                            IDUoM = sg.Key,
                            Quantity = sg.Sum(ss => ss.Quantity)
                        }).ToList();
                        var calcLines = UoMCalc(totalLines, i, out inventoryQty, out baseQty);

                        string freeUoM = "";
                        foreach (var tl in calcLines) freeUoM += string.Format("{0}{1} {2}", freeUoM == "" ? "" : " + ", tl.Quantity.ToString("0.#########"), tl.UoMName);

                        if (baseQty > 0) freeUoM += freeUoM == "" ? baseQty.ToString("0.#########") : string.Format("{0}{1} {2}", freeUoM == "" ? "" : " + ", baseQty.ToString("0.#########"), "lẻ");

                        if (inventoryQty > 0) ws.Cells[rowid, shimentColIndex].Value = inventoryQty;
                        if (freeUoM != "")
                        {
                            decimal freeQty = 0;
                            if (decimal.TryParse(freeUoM, out freeQty))
                            {
                                ws.Cells[rowid, shimentColIndex + 1].Value = freeQty;
                            }
                            else
                            {
                                ws.Cells[rowid, shimentColIndex + 1].Value = freeUoM;
                            }

                        }
                        #endregion

                        #region Note column


                        decimal niQty = 0;
                        decimal nbQty = 0;
                        var nTotalLines = notBaseQty.GroupBy(gb => new { gb.IDUoM, gb.UoMName }).Select(sg => new DTO_WMS_ItemUoMCount
                        {
                            IDUoM = sg.Key.IDUoM,
                            UoMName = sg.Key.UoMName,
                            Quantity = sg.Sum(ss => ss.Quantity)
                        }).ToList();

                        string nofUoM = "";
                        foreach (var tl in nTotalLines) nofUoM += string.Format("{0}{1} {2}", nofUoM == "" ? "" : " + ", tl.Quantity.ToString("0.#########"), tl.UoMName);
                        if (nBaseQty > 0) nofUoM += string.Format("{0}{1} {2}", nofUoM == "" ? "" : " + ", nBaseQty.ToString("0.#########"), "Lẻ");

                        nTotalLines.Add(new DTO_WMS_ItemUoMCount() { IDUoM = baseUoM.Id, Quantity = nBaseQty });
                        var nLines = UoMCalc(nTotalLines, i, out niQty, out nbQty);
                        if (niQty > 0)
                        {
                            string nfUoM = "";
                            foreach (var tl in nLines) nfUoM += string.Format("{0}{1} {2}", " + ", tl.Quantity.ToString("0.#########"), tl.UoMName);
                            if (nbQty > 0) nfUoM += string.Format("{0}{1} {2}", " + ", nbQty.ToString("0.#########"), "Lẻ");

                            ws.Cells[rowid, shimentColIndex + 2].Value = string.Format(
                                "{0} => {1} Thùng ({2}){3}", nofUoM, niQty.ToString("0.#########"), (inventoryUoM.BaseQuantity / inventoryUoM.AlternativeQuantity).ToString("0.#########"), nfUoM
                            );
                        }

                        #endregion

                        count++;
                        rowid++;
                    }

                }

                //create a range for the table
                var range = ws.Cells[4, firstColInex, rowid - 1, SheetColumnsCount];
                range.Style.Border.Bottom.Style = OfficeOpenXml.Style.ExcelBorderStyle.Thin;
                range.Style.Border.Bottom.Color.SetColor(System.Drawing.Color.FromArgb(235, 235, 235));
                range.Style.Border.DiagonalDown = true;

                ws.Cells[4, firstColInex + 1, rowid - 1, SheetColumnsCount].AutoFitColumns();

                //range.AutoFitColumns();
                //range.AutoFilter = true;

                package.Save();
            }

        }


        private static List<DTO_WMS_ItemUoMCount> UoMCalc(List<DTO_WMS_ItemUoMCount> lines, tbl_WMS_Item item, out decimal inventoryQuantity, out decimal baseQuantity) {
            inventoryQuantity = 0;
            baseQuantity = 0;

            tbl_WMS_ItemUoM inventoryUoM = item.tbl_WMS_ItemUoM.Where(d => d.Id == d.tbl_WMS_Item.InventoryUoM).FirstOrDefault();

            foreach (var line in lines)
            {
                tbl_WMS_ItemUoM uoM = item.tbl_WMS_ItemUoM.Where(d => d.Id == line.IDUoM).FirstOrDefault();
                line.UoMName = uoM.Name;

                if (uoM.IsBaseUoM)
                {
                    baseQuantity += line.Quantity;
                    line.Quantity = 0;
                }
                else if (line.IDUoM == item.InventoryUoM)
                {
                    inventoryQuantity += line.Quantity;
                    line.Quantity = 0;
                }

                if (inventoryUoM != null)
                {
                    decimal tongLeQty = line.Quantity * uoM.BaseQuantity / uoM.AlternativeQuantity;
                    int qdThung = (int)(tongLeQty * inventoryUoM.AlternativeQuantity / inventoryUoM.BaseQuantity);

                    if (qdThung > 0)
                    {
                        inventoryQuantity += qdThung;
                        decimal leConLai = tongLeQty - (qdThung * inventoryUoM.BaseQuantity / inventoryUoM.AlternativeQuantity);

                        decimal uomLe = leConLai * uoM.AlternativeQuantity / uoM.BaseQuantity;
                        line.Quantity = uomLe;

                    }

                    int qdLe = (int)(line.Quantity * uoM.BaseQuantity / uoM.AlternativeQuantity);
                    if (qdLe > 0 && uoM.BaseQuantity < uoM.AlternativeQuantity)
                    {
                        baseQuantity += qdLe;
                        line.Quantity = line.Quantity - (qdLe * uoM.AlternativeQuantity / uoM.BaseQuantity);
                    }

                    qdThung = (int)(baseQuantity * inventoryUoM.AlternativeQuantity / inventoryUoM.BaseQuantity);
                    if (qdThung > 0)
                    {
                        inventoryQuantity += qdThung;
                        baseQuantity = baseQuantity - (qdThung * inventoryUoM.BaseQuantity / inventoryUoM.AlternativeQuantity);
                    }

                }
                

            }

            return lines.Where(d => d.Quantity > 0).ToList();

        }

        
        public static void autoCreateShipment(AppEntities db, int IDBranch, string Username)
        {
            var queryOrders = db.tbl_SALE_Order
                .Where(d =>
                    d.IsDeleted == false && false == d.tbl_SHIP_ShipmentDetail.Any(e => !e.IsDeleted && !e.tbl_SHIP_Shipment.IsDeleted)
                //&& db.tbl_CRM_Route.Any(r=> 
                //    r.IsDeleted == false && r.IsDisabled == false && r.IDSeller == d.IDOwner.Value
                //    && r.tbl_CRM_RouteDetail.Any(e => e.IsDeleted == false && e.IDContact == d.IDContact)
                //)
                )
                .Select(s => new
                {
                    IDSaleOrder = s.Id,
                    IDSeller = s.IDOwner,

                    s.IsUrgentOrders,
                    s.IsWholeSale,
                    s.IsSampleOrder,

                    IDCustomer = s.IDContact,
                    s.ProductWeight,
                    s.ProductDimensions,

                    Route = s.tbl_CRM_Contact.tbl_CRM_RouteDetail.Any(d => d.IsDeleted == false && d.tbl_CRM_Route.IsDeleted == false && d.tbl_CRM_Route.IDSeller == s.IDOwner) ?
                    s.tbl_CRM_Contact.tbl_CRM_RouteDetail.FirstOrDefault(d => d.IsDeleted == false && d.tbl_CRM_Route.IsDeleted == false && d.tbl_CRM_Route.IDSeller == s.IDOwner).tbl_CRM_Route : null,


                    //Route = db.tbl_CRM_Route.FirstOrDefault(r =>
                    //            r.IsDeleted == false && r.IsDisabled == false && r.IDSeller == s.IDOwner.Value
                    //            //&& r.IDVehicle.HasValue
                    //            //&& r.IDVehicle.HasValue
                    //            //&& r.IDVehicle.HasValue
                    //            //&& r.IDVehicle.HasValue
                    //            && r.tbl_CRM_RouteDetail.Any(e => e.IsDeleted == false && e.IDContact == s.IDContact)
                    //            )

                }).ToList();

            var vehicleList = db.tbl_SHIP_Vehicle.Where(d => d.IsDeleted == false && d.IsDisabled == false).ToList();

            var Routes = queryOrders.Where(d=>d.Route != null).Select(r => new
            {
                r.Route.Id,
                r.Route.IDVehicleForUrgent,
                r.Route.IDVehicleForWholeSale,
                r.Route.IDVehicleForSample,
                r.Route.IDVehicle,
                r.Route.IDWarehouse
            }).Distinct().ToList();

            foreach (var route in Routes)
            {
                //Urgent
                var UrgentOrders = queryOrders.Where(d => d.Route != null && d.IsUrgentOrders && d.Route.Id == route.Id && d.Route.IDVehicleForUrgent.HasValue)
                    .Select(s=>new tbl_SALE_Order() { 
                        Id = s.IDSaleOrder,
                        ProductWeight = s.ProductWeight,
                        ProductDimensions = s.ProductDimensions
                    })
                    .ToList();
                var UrgentVehicle = vehicleList.FirstOrDefault(d => d.Id == route.IDVehicleForUrgent);
                createShipmentByRoute(db, UrgentVehicle, UrgentOrders, IDBranch, route.IDWarehouse, Username );

                //Sample
                var SampleOrders = queryOrders.Where(d => d.Route != null && d.IsSampleOrder 
                    && !UrgentOrders.Any(e=>e.Id==d.IDSaleOrder) 
                    && d.Route.Id == route.Id && d.Route.IDVehicleForSample.HasValue)
                    .Select(s => new tbl_SALE_Order()
                    {
                        Id = s.IDSaleOrder,
                        ProductWeight = s.ProductWeight,
                        ProductDimensions = s.ProductDimensions
                    })
                    .ToList();
                var SampleVehicle = vehicleList.FirstOrDefault(d => d.Id == route.IDVehicleForSample);
                createShipmentByRoute(db, SampleVehicle, SampleOrders, IDBranch, route.IDWarehouse, Username);

                //WholeSale
                var WholeSaleOrders = queryOrders.Where(d => d.Route != null && d.IsWholeSale
                    && !UrgentOrders.Any(e => e.Id == d.IDSaleOrder)
                    && !SampleOrders.Any(e => e.Id == d.IDSaleOrder)
                    && d.Route.Id == route.Id && d.Route.IDVehicleForWholeSale.HasValue
                ).Select(s => new tbl_SALE_Order()
                    {
                        Id = s.IDSaleOrder,
                        ProductWeight = s.ProductWeight,
                        ProductDimensions = s.ProductDimensions
                    })
                    .ToList();
                var WholeSaleVehicle = vehicleList.FirstOrDefault(d => d.Id == route.IDVehicleForWholeSale);
                createShipmentByRoute(db, WholeSaleVehicle, WholeSaleOrders, IDBranch, route.IDWarehouse, Username);


                //Other
                var SaleOrders = queryOrders.Where(d => d.Route != null && d.IsWholeSale == false && d.IsUrgentOrders == false && d.IsSampleOrder == false 
                    && d.Route.Id == route.Id
                ).Select(s => new tbl_SALE_Order()
                {
                    Id = s.IDSaleOrder,
                    ProductWeight = s.ProductWeight,
                    ProductDimensions = s.ProductDimensions
                }).ToList();

                var Vehicle = vehicleList.FirstOrDefault(d => d.Id == route.IDVehicle);
                createShipmentByRoute(db, Vehicle, SaleOrders, IDBranch, route.IDWarehouse, Username);
            }

        }
        public static void createShipmentByRoute(AppEntities db, tbl_SHIP_Vehicle vehicle, List<tbl_SALE_Order> Orders, int IDBranch, int? IDWarehouse, string Username, DateTime? DeliveryDate = null)
        {
            if (!DeliveryDate.HasValue)
                DeliveryDate = DateTime.Today.AddDays(1);

            if (vehicle == null || Orders == null || Orders.Count == 0)
            {
                return;
            }


            List<double> times = new List<double>() { 7.5, 10, 13, 15, 17, 18, 19, 20, 21, 22, 23 };

            

            decimal totalWeight = 0;
            decimal totalDemension = 0;

            List<List<int>> shipmentsOfVehicle = new List<List<int>>();
            shipmentsOfVehicle.Add(new List<int>());

            foreach (var o in Orders)
            {
                totalWeight += o.ProductWeight;
                totalDemension += o.ProductDimensions;

                if (totalWeight <= (vehicle.WeightRecommend * 1000) && totalDemension <= (vehicle.VolumeRecommend * 1000000) || shipmentsOfVehicle.LastOrDefault().Count == 0)
                {
                    shipmentsOfVehicle.LastOrDefault().Add(o.Id);
                }
                else
                {
                    shipmentsOfVehicle.Add(new List<int>());
                    totalWeight = o.ProductWeight;
                    totalDemension = o.ProductDimensions;
                    shipmentsOfVehicle.LastOrDefault().Add(o.Id);
                }

            }

            double time = 0;
            for (int i = 0; i < shipmentsOfVehicle.Count; i++)
            {

                time = i < times.Count ? times[i] : time + 3;

                DTO_SHIP_Shipment shipment = new DTO_SHIP_Shipment()
                {
                    IDBranch = IDBranch,
                    IDStatus = 301,

                    IDShipper = vehicle.IDShipper,
                    IDVehicle = vehicle.Id,
                    IDWarehouse = IDWarehouse,

                    DeliveryDate = DeliveryDate.Value.AddHours(time),
                    OrderIds = new List<int>()
                };

                shipment.OrderIds.AddRange(shipmentsOfVehicle[i]);

                string err = "";
                var result = BS_SHIP_Shipment.calc_Shipment(db, IDBranch, shipment, Username, out err);

            }


        }

        public static void confirmInboundReturn(AppEntities db,string ids, string Username, DateTime ModifiedDate)
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
                return;
            }

            var dbitems = db.tbl_SHIP_Shipment.Where(d => IDs.Contains(d.Id) && d.IsDeleted==false && d.IDStatus == 306); //Da giao hang
            var updateDate = DateTime.Now;

            foreach (var dbitem in dbitems)
            {
                dbitem.ModifiedBy = Username;
                dbitem.ModifiedDate = updateDate;
                dbitem.IDStatus = 329;
            }
        }
    }
}
