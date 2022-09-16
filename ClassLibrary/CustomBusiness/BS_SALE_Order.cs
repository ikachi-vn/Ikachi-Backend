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

    public static partial class BS_SALE_Order
    {
        public static IQueryable<DTO_SALE_Order> getCustom(AppEntities db, int IDBranch, int StaffID, Dictionary<string, string> QueryStrings)
        {
            var query = _queryBuilder(db, IDBranch, StaffID, QueryStrings);

            if (QueryStrings.Any(d => d.Key == "AllChildren") || QueryStrings.Any(d => d.Key == "AllParent"))
            {

                List<DTO_SALE_Order> allItems = db.tbl_SALE_Order.Where(d => d.IsDeleted == false).Select(s => new DTO_SALE_Order()
                {
                    Id = s.Id,
                    IDParent = s.IDParent
                }).ToList();

                List<int> Ids = new List<int>();

                foreach (var item in query)
                {
                    Ids.Add(item.Id);
                    if (QueryStrings.Any(d => d.Key == "AllParent"))
                    {
                        Ids.AddRange(findParent(allItems, item.Id));
                    }
                    if (QueryStrings.Any(d => d.Key == "AllChildren"))
                    {
                        Ids.AddRange(findChildrent(allItems, item.Id).Select(s => s));
                    }

                    query = db.tbl_SALE_Order.Where(d => Ids.Contains(d.Id));
                }

            }

            query = _sortBuilder(query, QueryStrings);
            query = _pagingBuilder(query, QueryStrings);

            return toDTO(query);
        }

        public static dynamic getAnItemCustom1(AppEntities db, int IDBranch, int id)
        {
            var s = db.tbl_SALE_Order.FirstOrDefault(d => d.Id == id && !d.IsDeleted);

            var ShippingAddress = s.tbl_CRM_PartnerAddress==null? null : new
            {
                s.tbl_CRM_PartnerAddress.Id,
                s.tbl_CRM_PartnerAddress.IDPartner,
                s.tbl_CRM_PartnerAddress.AddressLine1,
                s.tbl_CRM_PartnerAddress.AddressLine2,
                s.tbl_CRM_PartnerAddress.Ward,
                s.tbl_CRM_PartnerAddress.District,
                s.tbl_CRM_PartnerAddress.Province,
                s.tbl_CRM_PartnerAddress.Country,
                s.tbl_CRM_PartnerAddress.ZipCode,
                s.tbl_CRM_PartnerAddress.Contact,
                s.tbl_CRM_PartnerAddress.Phone1,
                s.tbl_CRM_PartnerAddress.Phone2,
            };

            var Items = s.tbl_SALE_OrderDetail.Select(i => new
            {
                i.tbl_WMS_Item.Id,
                i.tbl_WMS_Item.Code,
                i.tbl_WMS_Item.Name,
            }).Distinct().ToList();

            List<int> ids = Items.Select(it => it.Id).ToList();
            var UoMs = db.tbl_WMS_ItemUoM.Where(d => ids.Contains(d.IDItem) && !d.IsDeleted).Select(us => new
            {
                us.IDItem,
                us.Id,
                us.Name,
                us.IsBaseUoM,
                us.AlternativeQuantity,
                us.BaseQuantity,
            }).ToList();

            var OrderLines = s.tbl_SALE_OrderDetail.Where(ld => !ld.IsDeleted).Select(ls => new
            {
                ls.Id,
                IDOrder = ls.IDOrder,
                IDItem = ls.IDItem,
                ItemCode = ls.tbl_WMS_Item.Code,
                IDUoM = ls.IDUoM,
                UoMPrice = ls.UoMPrice,
                Quantity = ls.Quantity,
                UoMSwap = ls.UoMSwap,
                IDBaseUoM = ls.IDBaseUoM,
                BaseQuantity = ls.BaseQuantity,
                IsPromotionItem = ls.IsPromotionItem,
                IDPromotion = ls.IDPromotion,
                IDTax = ls.IDTax,
                TaxRate = ls.TaxRate,
                OriginalTotalBeforeDiscount = ls.OriginalTotalBeforeDiscount,
                OriginalPromotion = ls.OriginalPromotion,
                OriginalDiscount1 = ls.OriginalDiscount1,
                OriginalDiscount2 = ls.OriginalDiscount2,
                OriginalDiscountByItem = ls.OriginalDiscountByItem,
                OriginalDiscountByGroup = ls.OriginalDiscountByGroup,
                OriginalDiscountByLine = ls.OriginalDiscountByLine,
                OriginalDiscountByOrder = ls.OriginalDiscountByOrder,
                OriginalDiscountFromSalesman = ls.OriginalDiscountFromSalesman,
                OriginalTotalDiscount = ls.OriginalTotalDiscount,
                OriginalTotalAfterDiscount = ls.OriginalTotalAfterDiscount,
                OriginalTax = ls.OriginalTax,
                OriginalTotalAfterTax = ls.OriginalTotalAfterTax,
                ShippedQuantity = ls.ShippedQuantity,
                ReturnedQuantity = ls.ReturnedQuantity,
                TotalBeforeDiscount = ls.TotalBeforeDiscount,
                Discount1 = ls.Discount1,
                Discount2 = ls.Discount2,
                DiscountByItem = ls.DiscountByItem,
                Promotion = ls.Promotion,
                DiscountByGroup = ls.DiscountByGroup,
                DiscountByLine = ls.DiscountByLine,
                DiscountByOrder = ls.DiscountByOrder,
                DiscountFromSalesman = ls.DiscountFromSalesman,
                TotalDiscount = ls.TotalDiscount,
                TotalAfterDiscount = ls.TotalAfterDiscount,
                Tax = ls.Tax,
                TotalAfterTax = ls.TotalAfterTax,
                ProductWeight = ls.ProductWeight,
                ProductDimensions = ls.ProductDimensions,
                UoMSwapAlter = ls.UoMSwapAlter,
            }).OrderBy(lo => lo.IsPromotionItem).ThenBy(lo => lo.ItemCode);

            dynamic result = new
            {
                IDBranch = s.IDBranch,
                Branch = new
                {
                    s.tbl_BRA_Branch.Id,
                    s.tbl_BRA_Branch.Code,
                    s.tbl_BRA_Branch.Name,
                },
                IDContact = s.IDContact,
                BusinessPartner = new
                {
                    s.tbl_CRM_Contact.Id,
                    s.tbl_CRM_Contact.Code,
                    s.tbl_CRM_Contact.Name
                },
                IDStatus = s.IDStatus,
                Id = s.Id,
                Code = s.Code,
                Name = s.Name,
                Remark = s.Remark,
                IDOwner = s.IDOwner,
                Owner = new
                {
                    s.tbl_HRM_Staff.Id,
                    s.tbl_HRM_Staff.FullName,
                },
                OrderDate = s.OrderDate,
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
                TotalBeforeDiscount = s.TotalBeforeDiscount,
                ProductWeight = s.ProductWeight,
                ProductDimensions = s.ProductDimensions,
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
                Received = s.Received,
                Debt = s.Debt,
                IsDebt = s.IsDebt,
                IsPaymentReceived = s.IsPaymentReceived,

                CreatedBy = s.CreatedBy,
                ModifiedBy = s.ModifiedBy,
                CreatedDate = s.CreatedDate,
                ModifiedDate = s.ModifiedDate,

                InvoiceNumber = s.InvoiceNumber,
                InvoicDate = s.InvoicDate,
                TaxRate = s.TaxRate,

                IsSampleOrder = s.IsSampleOrder,
                IsShipBySaleMan = s.IsShipBySaleMan,
                IsUrgentOrders = s.IsUrgentOrders,
                IDUrgentShipper = s.IDUrgentShipper,
                IsWholeSale = s.IsWholeSale,
                ReceivedDiscountFromSalesman = s.ReceivedDiscountFromSalesman,
                OldReceived = s.OldReceived,
                ShippingAddress = ShippingAddress,

                OrderLines = OrderLines,
                Items = Items,
                UoMs = UoMs
            };

            return result;

        }

        public static void updateStatus(AppEntities db, List<int> Ids, int IDOrderStatus)
        {
            var orders = db.tbl_SALE_Order.Where(d => Ids.Contains(d.Id)).ToList();
            foreach (var o in orders)
            {
                if (IDOrderStatus == 109)
                {
                    o.IDStatus = o.Debt > 0 ? 113 : 114;
                }
                else
                {
                    o.IDStatus = IDOrderStatus;
                }


            }
        }

        public static void calcOrder(tbl_SALE_Order dbitem, DTO_SALE_Order item, string Username, DateTime ModifiedDate, out string err, List<tbl_WMS_ItemUoM> UoMs)
        {
            err = "";
            if (dbitem == null || item == null)
                return;

            item.OrderLines.RemoveAll(line => !(line.IDItem > 0 && line.IDUoM > 0 && line.Quantity > 0));

            if (item.Id > 0)
            {
                //delete removed lines
                var ids = item.OrderLines.Select(s => s.Id).Distinct();
                var deletedLines = dbitem.tbl_SALE_OrderDetail.Where(d => d.IDOrder == item.Id && d.IsDeleted == false && !ids.Contains(d.Id)).ToList();
                foreach (var deleteLine in deletedLines)
                {
                    deleteLine.IsDeleted = true;
                    deleteLine.ModifiedBy = Username;
                    deleteLine.ModifiedDate = ModifiedDate;
                }
                var validIds = dbitem.tbl_SALE_OrderDetail.Select(s => s.Id);
                item.OrderLines.RemoveAll(line =>
                    !(line.IDItem > 0 && line.IDUoM > 0 && line.Quantity > 0)
                    ||
                    (line.Id > 0 && !validIds.Contains(line.Id))
                );
            }
            else
            {
                item.CreatedBy = Username;
                item.CreatedDate = ModifiedDate;
            }

            #region reset value
            item.ProductWeight = 0;
            item.ProductDimensions = 0;

            item.OriginalTotalBeforeDiscount = 0;
            item.OriginalDiscount1 = 0;
            item.OriginalDiscount2 = 0;
            item.OriginalDiscountByItem = 0;
            item.OriginalDiscountByGroup = 0;
            item.OriginalDiscountByLine = 0;
            item.OriginalDiscountByOrder = 0;
            item.OriginalDiscountFromSalesman = 0;
            item.OriginalTotalDiscount = 0;
            item.OriginalTotalAfterDiscount = 0;
            item.OriginalTax = 0;
            item.OriginalTotalAfterTax = 0;

            item.TotalBeforeDiscount = 0;
            item.Discount1 = 0;
            item.Discount2 = 0;
            item.DiscountByItem = 0;
            item.DiscountByGroup = 0;
            item.DiscountByLine = 0;
            item.DiscountByOrder = 0;
            item.DiscountFromSalesman = 0;
            item.TotalDiscount = 0;
            item.TotalAfterDiscount = 0;
            item.Tax = 0;
            item.TotalAfterTax = 0;
            #endregion

            BS_SALE_Order.patchDTOtoDBValue(item, dbitem);

            if (item.OrderLines != null)
            {
                foreach (var line in item.OrderLines)
                {
                    tbl_SALE_OrderDetail dbline = null;
                    if (line.Id != 0)
                    {
                        dbline = dbitem.tbl_SALE_OrderDetail.FirstOrDefault(d => d.Id == line.Id);
                        dbline.IsDeleted = false; //Fix update older order
                    }

                    if (dbline == null)
                    {
                        line.Id = 0;
                        dbline = new tbl_SALE_OrderDetail();
                        dbitem.tbl_SALE_OrderDetail.Add(dbline);
                    }

                    calcLine(dbline, line, Username, ModifiedDate, UoMs);

                    #region subTotal
                    dbitem.ProductWeight += dbline.ProductWeight;
                    dbitem.ProductDimensions += dbline.ProductDimensions;

                    dbitem.OriginalTotalBeforeDiscount += dbline.OriginalTotalBeforeDiscount;
                    dbitem.OriginalDiscount1 += dbline.OriginalDiscount1;
                    dbitem.OriginalDiscount2 += dbline.OriginalDiscount2;
                    dbitem.OriginalDiscountByItem += dbline.OriginalDiscountByItem;
                    dbitem.OriginalDiscountByGroup += dbline.OriginalDiscountByGroup;
                    dbitem.OriginalDiscountByLine += dbline.OriginalDiscountByLine;
                    dbitem.OriginalDiscountByOrder += dbline.OriginalDiscountByOrder;
                    dbitem.OriginalTotalDiscount += dbline.OriginalTotalDiscount;
                    dbitem.OriginalTotalAfterDiscount += dbline.OriginalTotalAfterDiscount;
                    dbitem.OriginalTax += dbline.OriginalTax;
                    dbitem.OriginalTotalAfterTax += dbline.OriginalTotalAfterTax;

                    dbitem.OriginalDiscountFromSalesman += dbline.OriginalDiscountFromSalesman;



                    dbitem.TotalBeforeDiscount += dbline.TotalBeforeDiscount;
                    //item.Promotion += line.Promotion;
                    dbitem.Discount1 += dbline.Discount1;
                    dbitem.Discount2 += dbline.Discount2;
                    dbitem.DiscountByItem += dbline.DiscountByItem;
                    dbitem.DiscountByGroup += dbline.DiscountByGroup;
                    dbitem.DiscountByLine += dbline.DiscountByLine;
                    dbitem.DiscountByOrder += dbline.DiscountByOrder;
                    dbitem.TotalDiscount += dbline.TotalDiscount;
                    dbitem.TotalAfterDiscount += dbline.TotalAfterDiscount;
                    dbitem.Tax += dbline.Tax;
                    dbitem.TotalAfterTax += dbline.TotalAfterTax;


                    dbitem.DiscountFromSalesman += dbline.DiscountFromSalesman;
                    #endregion
                }
            }

            dbitem.TaxRate = dbitem.OriginalTotalAfterDiscount == 0 ? 0 : dbitem.OriginalTax / dbitem.OriginalTotalAfterDiscount * 100;

            var totalShipmentDetail = dbitem.tbl_SHIP_ShipmentDetail.Where(d => d.IsDeleted == false).Select(e => e.Received).DefaultIfEmpty(0).Sum();
            var totalShipmentDebt = dbitem.tbl_SHIP_ShipmentDebt.Where(d => d.IsDeleted == false).Select(e => e.Received).DefaultIfEmpty(0).Sum();
            dbitem.Received = totalShipmentDetail + totalShipmentDebt;

            dbitem.OriginalTotalAfterTax = decimal.Round(dbitem.OriginalTotalAfterTax, 0);
            dbitem.TotalAfterTax = decimal.Round(dbitem.TotalAfterTax, 0);
            dbitem.Debt = dbitem.TotalAfterTax - dbitem.Received;

            dbitem.IsPaymentReceived = (dbitem.TotalAfterTax == dbitem.Received) && (dbitem.Debt == 0);
            if (!dbitem.IsDebt)
            {
                dbitem.IsDebt = dbitem.Debt > 0;
            }

            dbitem.IDStatus = CheckStatus(dbitem);

            dbitem.ModifiedBy = Username;
            dbitem.ModifiedDate = ModifiedDate;

        }

        private static void calcLine(tbl_SALE_OrderDetail dbitem, DTO_SALE_OrderDetail item, string Username, DateTime ModifiedDate, List<tbl_WMS_ItemUoM> UoMs)
        {
            if (dbitem == null || item == null)
                return;

            #region Before delivery
            //User input
            dbitem.Id = item.Id;
            if (dbitem.Id == 0)
            {
                dbitem.CreatedBy = Username;
                dbitem.CreatedDate = ModifiedDate;
            }

            dbitem.IDOrder = item.IDOrder;

            dbitem.IDItem = item.IDItem;
            dbitem.IDUoM = item.IDUoM;
            dbitem.UoMPrice = item.IsPromotionItem ? 0 : item.UoMPrice;
            dbitem.Quantity = item.Quantity;



            if (dbitem.UoMSwap == 0)
            {
                var selectedUoM = UoMs.FirstOrDefault(d => d.Id == item.IDUoM);
                var baseUoM = UoMs.FirstOrDefault(d => d.IDItem == item.IDItem && d.IsDeleted == false && d.IsBaseUoM);
                if (selectedUoM != null && baseUoM != null)
                {
                    dbitem.UoMSwap = decimal.ToInt32(selectedUoM.BaseQuantity);
                    dbitem.IDBaseUoM = baseUoM.Id;

                    dbitem.ProductWeight = selectedUoM.Weight * dbitem.Quantity;
                    dbitem.ProductDimensions = selectedUoM.Length * selectedUoM.Width * selectedUoM.Height * dbitem.Quantity;

                }
            }


            if (dbitem.UoMSwap == 0)
            {
                dbitem.UoMSwap = 1;
                dbitem.ProductWeight = item.ProductWeight;
                dbitem.ProductDimensions = item.ProductDimensions;
            }

            dbitem.BaseQuantity = dbitem.Quantity * dbitem.UoMSwap;

            dbitem.IDPromotion = item.IDPromotion;
            dbitem.IsPromotionItem = item.IsPromotionItem;
            dbitem.IDTax = item.IDTax;
            dbitem.TaxRate = item.TaxRate;

            dbitem.OriginalPromotion = item.IsPromotionItem ? 0 : item.OriginalPromotion;
            dbitem.OriginalDiscount1 = item.IsPromotionItem ? 0 : item.OriginalDiscount1;
            dbitem.OriginalDiscount2 = item.IsPromotionItem ? 0 : item.OriginalDiscount2;

            dbitem.OriginalDiscountByOrder = item.OriginalDiscountByOrder;
            dbitem.Remark = item.Remark;


            dbitem.ModifiedBy = Username;
            dbitem.ModifiedDate = ModifiedDate;

            //Calc
            dbitem.OriginalTotalBeforeDiscount = item.IsPromotionItem ? 0 : dbitem.UoMPrice * dbitem.Quantity;
            dbitem.OriginalDiscountByItem = dbitem.OriginalDiscount1 + dbitem.OriginalDiscount2;

            if (dbitem.OriginalDiscountByItem > dbitem.OriginalTotalBeforeDiscount)
            {
                dbitem.OriginalDiscount1 = dbitem.OriginalTotalBeforeDiscount;
                dbitem.OriginalDiscount2 = 0;
                dbitem.OriginalDiscountByItem = dbitem.OriginalTotalBeforeDiscount;
            }

            dbitem.OriginalDiscountByGroup = (dbitem.OriginalPromotion / 100) * dbitem.OriginalTotalBeforeDiscount;
            dbitem.OriginalDiscountByLine = dbitem.OriginalDiscountByItem + dbitem.OriginalDiscountByGroup;
            dbitem.OriginalTotalDiscount = dbitem.OriginalDiscountByOrder + dbitem.OriginalDiscountByLine;


            dbitem.OriginalTotalAfterDiscount = dbitem.OriginalTotalBeforeDiscount - dbitem.OriginalTotalDiscount;

            dbitem.OriginalTax = dbitem.OriginalTotalAfterDiscount * (dbitem.TaxRate / 100);
            dbitem.OriginalTotalAfterTax = dbitem.OriginalTotalAfterDiscount + dbitem.OriginalTax;

            dbitem.OriginalDiscountFromSalesman = item.OriginalDiscountFromSalesman;

            //dbitem.OriginalDiscountFromSalesman = item.IsPromotionItem ? 0 : item.OriginalDiscountFromSalesman;
            //if (dbitem.OriginalDiscountFromSalesman > dbitem.OriginalTotalAfterTax)
            //{
            //    dbitem.OriginalDiscountFromSalesman = dbitem.OriginalTotalAfterTax;
            //}


            #endregion

            #region After delivery
            dbitem.ShippedQuantity = item.ShippedQuantity;
            dbitem.ReturnedQuantity = dbitem.Quantity - dbitem.ShippedQuantity;
            dbitem.TotalBeforeDiscount = dbitem.ShippedQuantity * dbitem.UoMPrice;


            dbitem.Discount1 = item.Discount1;
            dbitem.Discount2 = item.Discount2;
            dbitem.DiscountByItem = dbitem.Discount1 + dbitem.Discount2;
            dbitem.Promotion = item.Promotion;
            dbitem.DiscountByGroup = (dbitem.Promotion / 100) * dbitem.TotalBeforeDiscount;
            dbitem.DiscountByLine = dbitem.DiscountByItem + dbitem.DiscountByGroup;
            dbitem.DiscountByOrder = item.DiscountByOrder;

            dbitem.TotalDiscount = dbitem.DiscountByOrder + dbitem.DiscountByLine;
            dbitem.TotalAfterDiscount = dbitem.TotalBeforeDiscount - dbitem.TotalDiscount;

            dbitem.Tax = dbitem.TotalAfterDiscount * (dbitem.TaxRate / 100);
            dbitem.TotalAfterTax = dbitem.TotalAfterDiscount + dbitem.Tax;

            dbitem.DiscountFromSalesman = item.DiscountFromSalesman;
            #endregion

        }

        private static int CheckStatus(tbl_SALE_Order item)
        {

            //101 , //	Mới (sale tạo)	1
            //102 , //	Mới (khách tạo)	1
            //103 , //	Imported	1

            //104 , //	Đã xác nhận	1
            //105 , //	Đã phân tài	1
            //106 , //	Đang lấy hàng - đóng gói	1
            //107 , //	Đã giao đơn vị vận chuyển	1

            //108 , //	Đang giao hàng	1
            //109 , //	Đã giao hàng	1
            //110 , //	Chờ giao lại	1
            //111 , //	Đã xuất hóa đơn	1
            //112 , //	Đã có phiếu thu	1
            //113 , //	Còn nợ	1
            //114 , //	Đã xong	1

            if (item.Id == 0)
            {
                if (item.Name != null && item.Name.Contains("Imported"))
                {
                    return 103;
                }
                else
                {
                    return 101;
                }
            }

            if (item.IDStatus == 0)
            {
                return 101;
            }

            return item.IDStatus;
        }

        public static List<SaleReport> calcSaleSalemanReport(AppEntities db, Dictionary<string, string> QueryStrings)
        {
            string queryString = @"
DECLARE @v TABLE (IDBranch INT, IDOwner INT, TotalBeforeDiscount DECIMAL(27,9), Discount1 DECIMAL(27,9), Discount2 DECIMAL(27,9), TotalDiscount DECIMAL(27,9), TotalAfterDiscount DECIMAL(27,9))
INSERT INTO @v
SELECT o.IDBranch, o.IDOwner,
{0}
FROM
dbo.tbl_SALE_Order o
INNER JOIN dbo.tbl_SALE_OrderDetail d ON d.IDOrder = o.Id
{1}
WHERE {3} {4} {5} {6}
    {2}
	o.IsDeleted = 0 AND d.IsDeleted = 0
GROUP BY  o.IDBranch, o.IDOwner

SELECT 
v.IDBranch, b.Name BranchName, 
v.IDOwner IDSaleman, s.Code SalemanCode, s.FullName, s.PhoneNumber WorkPhone,
v.TotalBeforeDiscount, v.Discount1, v.Discount2, v.TotalDiscount, 
v.TotalAfterDiscount 

FROM @v v
INNER JOIN dbo.tbl_BRA_Branch b ON b.Id = v.IDBranch
INNER JOIN dbo.tbl_HRM_Staff s ON s.Id = v.IDOwner

ORDER BY BranchName, s.FirstName, v.TotalAfterDiscount DESC
";

            queryString = queryBuilder(queryString, QueryStrings);
            var results = db.Database.SqlQuery<SaleReport>(queryString);
            return results.ToList();
        }

        public static string queryBuilder(string queryString, Dictionary<string, string> QueryStrings)
        {
            

            bool isCalcShippedOnly = false;
            if (QueryStrings.Any(d => d.Key == "IsCalcShippedOnly"))
                bool.TryParse(QueryStrings.FirstOrDefault(d => d.Key == "IsCalcShippedOnly").Value, out isCalcShippedOnly);

            string sumQuery = "SUM(d.OriginalTotalBeforeDiscount) TotalBeforeDiscount, SUM(d.OriginalDiscount1) Discount1, SUM(d.OriginalDiscount2) Discount2, SUM(d.OriginalTotalDiscount) TotalDiscount, SUM(d.OriginalTotalAfterDiscount) TotalAfterDiscount";
            string innerJoinShipment = "";
            string whereShipment = "o.IDStatus IN (104, 105, 106, 107, 108, 109, 110, 113, 114) AND";
            string branchCondition = "";
            string dateCondition = "";
            string ownerCondition = "";
            string contactCondition = "";
            string promotion = "SUM( CASE WHEN d.IsPromotionItem = 1 THEN d.Quantity ELSE 0 END) PromotionQuantity,";

            if (isCalcShippedOnly)
            {
                sumQuery = "SUM(d.TotalBeforeDiscount) TotalBeforeDiscount, SUM(d.Discount1) Discount1, SUM(d.Discount2) Discount2, SUM(d.TotalDiscount) TotalDiscount, SUM(d.TotalAfterDiscount) TotalAfterDiscount";
                innerJoinShipment = "INNER JOIN dbo.tbl_SHIP_ShipmentDetail sd ON sd.IDSaleOrder = o.Id INNER JOIN dbo.tbl_SHIP_Shipment sh ON sd.IDShipment = sh.Id";
                whereShipment = "sh.IDStatus = 328 AND sd.IDStatus = 319 AND d.ShippedQuantity > 0 AND";
                promotion = "SUM( CASE WHEN d.IsPromotionItem = 1 THEN d.ShippedQuantity ELSE 0 END) PromotionQuantity,";
            }

            List<int> BranchIDs = new List<int>();

            if (QueryStrings.Any(d => d.Key == "IDBranch"))
            {
                var IDList = QueryStrings.FirstOrDefault(d => d.Key == "IDBranch").Value.Replace("[", "").Replace("]", "").Split(',');

                foreach (var item in IDList)
                    if (int.TryParse(item, out int i))
                        BranchIDs.Add(i);
                if (BranchIDs.Count > 0)
                {
                    var ids = string.Join(",", BranchIDs.ToArray());
                    branchCondition = "o.IDBranch IN (" + ids + ") AND";
                }
            }

            if (DateTime.TryParse(QueryStrings.FirstOrDefault(d => d.Key == "fromDate").Value, out DateTime fromDate) && DateTime.TryParse(QueryStrings.FirstOrDefault(d => d.Key == "toDate").Value, out DateTime toDate))
                dateCondition = string.Format("{0} BETWEEN '{1}' AND '{2} 23:59:59.999'  AND", (isCalcShippedOnly ? "sh.DeliveryDate" : "o.OrderDate"), fromDate.ToString("yyyy-MM-dd"), toDate.ToString("yyyy-MM-dd"));

            if (QueryStrings.Any(d => d.Key == "IDOwner"))
            {
                var IDList = QueryStrings.FirstOrDefault(d => d.Key == "IDOwner").Value.Replace("[", "").Replace("]", "").Split(',');
                List<int> IDs = new List<int>();
                foreach (var item in IDList)
                    if (int.TryParse(item, out int i))
                        IDs.Add(i);
                if (IDs.Count > 0)
                {
                    var ids = string.Join(",", IDs.ToArray());
                    ownerCondition = "o.IDOwner IN (" + ids + ")  AND";
                }
            }

            if (QueryStrings.Any(d => d.Key == "IDContact"))
            {
                var IDList = QueryStrings.FirstOrDefault(d => d.Key == "IDContact").Value.Replace("[", "").Replace("]", "").Split(',');
                List<int> IDs = new List<int>();
                foreach (var item in IDList)
                    if (int.TryParse(item, out int i))
                        IDs.Add(i);
                if (IDs.Count > 0)
                {
                    var ids = string.Join(",", IDs.ToArray());
                    contactCondition = "o.IDContact IN (" + ids + ") AND";
                }
            }

            return string.Format(queryString, sumQuery, innerJoinShipment, whereShipment,  branchCondition, dateCondition, ownerCondition, contactCondition, promotion);
        }

        public static List<SaleReport> calcSaleOrderReport(AppEntities db, Dictionary<string, string> QueryStrings)
        {
            string queryString = @"

SELECT 
o.IDContact, c.Code ContactCode, c.Name ContactName, c.WorkPhone,
o.OrderDate,
o.Id IDSaleOrder,
d.IDItem, i.Code ItemCode, i.Name ItemName, 
u.Id IDUoM, u.Name UoM,
d.Quantity, d.ShippedQuantity, d.IsPromotionItem, 
--d.OriginalTotalBeforeDiscount, d.OriginalDiscount1, d.OriginalDiscount2, 
d.OriginalTotalDiscount, d.OriginalTotalAfterDiscount,
--d.TotalBeforeDiscount, d.Discount1, d.Discount2, 
d.TotalDiscount, d.TotalAfterDiscount 

FROM dbo.tbl_SALE_OrderDetail d
INNER JOIN dbo.tbl_SALE_Order o ON o.Id = d.IDOrder
INNER JOIN dbo.tbl_CRM_Contact c ON c.Id = o.IDContact
INNER JOIN dbo.tbl_WMS_Item i ON i.Id = d.IDItem
INNER JOIN dbo.tbl_WMS_ItemUoM u ON u.Id = d.IDUoM
WHERE {3} {4} {5} {6}
    {2}
	o.IsDeleted = 0 AND d.IsDeleted = 0
ORDER BY o.OrderDate DESC, o.Id, d.IsPromotionItem, i.Code, u.IsBaseUoM

";

            queryString = queryBuilder(queryString, QueryStrings);
            var results = db.Database.SqlQuery<SaleReport>(queryString);
            return results.ToList();
        }

        public static List<SaleReport> calcSaleProductReport(AppEntities db, Dictionary<string, string> QueryStrings)
        {
            string queryString = @"
DECLARE @v TABLE (IDBranch INT, IDOwner INT, IDItem int, IDUoM int, Quantity DECIMAL(27,9) , ShippedQuantity DECIMAL(27,9) ,PromotionQuantity DECIMAL(27,9),TotalBeforeDiscount DECIMAL(27,9), Discount1 DECIMAL(27,9), Discount2 DECIMAL(27,9), TotalDiscount DECIMAL(27,9), TotalAfterDiscount DECIMAL(27,9))
INSERT INTO @v
SELECT o.IDBranch, o.IDOwner, d.IDItem, d.IDUoM,
SUM(d.Quantity) Quantity, SUM(d.ShippedQuantity) ShippedQuantity, 
{7} 
{0}
FROM
dbo.tbl_SALE_Order o
INNER JOIN dbo.tbl_SALE_OrderDetail d ON d.IDOrder = o.Id
{1}
WHERE {3} {4} {5} {6}
    {2}
	o.IsDeleted = 0 AND d.IsDeleted = 0
GROUP BY  o.IDBranch, o.IDOwner, d.IDItem, d.IDUoM


SELECT 
v.IDBranch, b.Name BranchName, 
v.IDOwner IDSaleman, 
s.FullName, 
r.Id IDItemGroupRoot, r.Name ItemGroupRoot,
i.IDItemGroup, g.Name ItemGroup, 
v.IDItem, i.Code ItemCode, i.Name ItemName, 
u.Id IDUoM, u.Name UoM,
v.Quantity, v.ShippedQuantity, v.PromotionQuantity, v.TotalBeforeDiscount, v.Discount1, v.Discount2, v.TotalDiscount, v.TotalAfterDiscount 

FROM @v v
INNER JOIN dbo.tbl_BRA_Branch b ON b.Id = v.IDBranch
INNER JOIN dbo.tbl_WMS_Item i ON i.Id = v.IDItem
INNER JOIN dbo.tbl_WMS_ItemGroup g ON g.Id = i.IDItemGroup
INNER JOIN dbo.tbl_WMS_ItemUoM u ON u.Id = v.IDUoM
INNER JOIN dbo.tbl_HRM_Staff s ON s.Id = v.IDOwner
INNER JOIN dbo.tbl_WMS_ItemGroup r ON r.Id = dbo.fnGetRootParentID(i.IDItemGroup)

ORDER BY b.Name, s.FirstName, r.Name, i.Code, u.IsBaseUoM
";

            queryString = queryBuilder(queryString, QueryStrings);
            var results = db.Database.SqlQuery<SaleReport>(queryString);
            return results.ToList();
        }

        public static void ExportSaleProductReport(ExcelPackage package, AppEntities db, int IDBranch, int StaffID, Dictionary<string, string> QueryStrings)
        {
            ExcelWorkbook workBook = package.Workbook;
            if (workBook != null)
            {
                var ws = workBook.Worksheets.FirstOrDefault(); //Worksheets["Data"];
                var data = calcSaleProductReport(db, QueryStrings);

                int SheetColumnsCount, SheetRowCount = 0;
                SheetColumnsCount = ws.Dimension.End.Column;    // Find End Column
                SheetRowCount = ws.Dimension.End.Row;           // Find End Row

                int rowid = 6;

                int firstColInex = 0;
                foreach (var item in data)
                {
                    for (int i = 1; i <= SheetColumnsCount; i++)
                    {
                        string property = ws.Cells[1, i].Value == null ? "" : ws.Cells[1, i].Text;
                        if (
                            !string.IsNullOrEmpty(property)
                            && (item.GetType().GetProperties().Any(d => d.Name == property))
                        )
                        {
                            if (firstColInex == 0)
                            {
                                firstColInex = i;
                            }

                            ws.Cells[rowid, i].Value = item.GetType().GetProperties().First(o => o.Name == property).GetValue(item, null);
                        }
                        else if (property == "#")
                        {
                            ws.Cells[rowid, i].Value = rowid - 5;
                        }

                    }

                    //ws.Cells["C" + rowid].Value = item.BookingDate.HasValue ? item.BookingDate.Value.ToString("yyyy-MM-dd hh:mm:ss") : "";

                    rowid++;
                }

                if (DateTime.TryParse(QueryStrings.FirstOrDefault(d => d.Key == "fromDate").Value, out DateTime fromDate) && DateTime.TryParse(QueryStrings.FirstOrDefault(d => d.Key == "toDate").Value, out DateTime toDate))
                {
                    ws.Cells["B3"].Value = string.Format("Thời gian: {0} - {1} (ngày xuất: {2})", fromDate.ToString("yyyy-MM-dd"), toDate.ToString("yyyy-MM-dd"), DateTime.Now.ToString("yyyy-MM-dd hh:mm"));
                }

                //create a range for the table
                var range = ws.Cells[4, firstColInex, rowid - 1, SheetColumnsCount];
                range.Style.Border.Bottom.Style = OfficeOpenXml.Style.ExcelBorderStyle.Thin;
                range.Style.Border.Bottom.Color.SetColor(System.Drawing.Color.FromArgb(235, 235, 235));
                range.Style.Border.DiagonalDown = true;

                //ws.Cells.AutoFilter = true;
                //ws.Cells.AutoFitColumns(6, 60);

                package.Save();
            }
        }

        public static List<SaleReport> calcSaleOutletReport(AppEntities db, Dictionary<string, string> QueryStrings)
        {
            string queryString = @"
DECLARE @v TABLE (IDBranch INT, IDOwner INT, IDContact INT ,TotalBeforeDiscount DECIMAL(27,9), Discount1 DECIMAL(27,9), Discount2 DECIMAL(27,9), TotalDiscount DECIMAL(27,9), TotalAfterDiscount DECIMAL(27,9))
INSERT INTO @v
SELECT o.IDBranch, o.IDOwner, o.IDContact,
{0}
FROM
dbo.tbl_SALE_Order o
INNER JOIN dbo.tbl_SALE_OrderDetail d ON d.IDOrder = o.Id
{1}
WHERE {3} {4} {5} {6}
    {2}
	o.IsDeleted = 0 AND d.IsDeleted = 0
GROUP BY  o.IDBranch, o.IDOwner, o.IDContact

SELECT 
v.IDBranch, b.Name BranchName, 
v.IDOwner IDSaleman, s.FullName,
v.IDContact, c.Code ContactCode, c.Name ContactName, c.WorkPhone,
v.TotalBeforeDiscount, v.Discount1, v.Discount2, v.TotalDiscount, 
v.TotalAfterDiscount 

FROM @v v
INNER JOIN dbo.tbl_BRA_Branch b ON b.Id = v.IDBranch
INNER JOIN dbo.tbl_CRM_Contact c ON c.Id = v.IDContact
INNER JOIN dbo.tbl_HRM_Staff s ON s.Id = v.IDOwner

ORDER BY BranchName, s.FirstName, v.TotalAfterDiscount DESC

";

            queryString = queryBuilder(queryString, QueryStrings);
            var results = db.Database.SqlQuery<SaleReport>(queryString);
            return results.ToList();
        }

        public static void ExportSaleOutletReport(ExcelPackage package, AppEntities db, int IDBranch, int StaffID, Dictionary<string, string> QueryStrings)
        {
            ExcelWorkbook workBook = package.Workbook;
            if (workBook != null)
            {
                var ws = workBook.Worksheets.FirstOrDefault(); //Worksheets["Data"];
                var data = calcSaleOutletReportDetail(db, QueryStrings);

                int SheetColumnsCount, SheetRowCount = 0;
                SheetColumnsCount = ws.Dimension.End.Column;    // Find End Column
                SheetRowCount = ws.Dimension.End.Row;           // Find End Row

                int rowid = 6;

                int firstColInex = 0;
                foreach (var item in data)
                {
                    for (int i = 1; i <= SheetColumnsCount; i++)
                    {
                        string property = ws.Cells[1, i].Value == null ? "" : ws.Cells[1, i].Text;
                        if (
                            !string.IsNullOrEmpty(property)
                            && (item.GetType().GetProperties().Any(d => d.Name == property))
                        )
                        {
                            if (firstColInex == 0)
                            {
                                firstColInex = i;
                            }

                            ws.Cells[rowid, i].Value = item.GetType().GetProperties().First(o => o.Name == property).GetValue(item, null);
                        }
                        else if (property == "#")
                        {
                            ws.Cells[rowid, i].Value = rowid - 5;
                        }

                    }

                    //ws.Cells["C" + rowid].Value = item.BookingDate.HasValue ? item.BookingDate.Value.ToString("yyyy-MM-dd hh:mm:ss") : "";

                    rowid++;
                }

                if (DateTime.TryParse(QueryStrings.FirstOrDefault(d => d.Key == "fromDate").Value, out DateTime fromDate) && DateTime.TryParse(QueryStrings.FirstOrDefault(d => d.Key == "toDate").Value, out DateTime toDate))
                {
                    ws.Cells["B3"].Value = string.Format("Thời gian: {0} - {1} (ngày xuất: {2})", fromDate.ToString("yyyy-MM-dd"), toDate.ToString("yyyy-MM-dd"), DateTime.Now.ToString("yyyy-MM-dd hh:mm"));
                }

                //create a range for the table
                var range = ws.Cells[4, firstColInex, rowid - 1, SheetColumnsCount];
                range.Style.Border.Bottom.Style = OfficeOpenXml.Style.ExcelBorderStyle.Thin;
                range.Style.Border.Bottom.Color.SetColor(System.Drawing.Color.FromArgb(235, 235, 235));
                range.Style.Border.DiagonalDown = true;

                //ws.Cells.AutoFilter = true;
                //ws.Cells.AutoFitColumns(6, 60);

                package.Save();
            }
        }

        public static List<SaleReport> calcSaleOutletReportDetail(AppEntities db, Dictionary<string, string> QueryStrings)
        {
            string queryString = @"
DECLARE @v TABLE (IDBranch INT, IDOwner INT, IDContact INT, IDItem int, IDUoM int, Quantity DECIMAL(27,9) ,ShippedQuantity DECIMAL(27,9) ,PromotionQuantity DECIMAL(27,9),TotalBeforeDiscount DECIMAL(27,9), Discount1 DECIMAL(27,9), Discount2 DECIMAL(27,9), TotalDiscount DECIMAL(27,9), TotalAfterDiscount DECIMAL(27,9))
INSERT INTO @v
SELECT o.IDBranch, o.IDOwner, o.IDContact, d.IDItem, d.IDUoM,
SUM(d.Quantity) Quantity,
SUM(d.ShippedQuantity) ShippedQuantity, 
{7}
{0}
FROM
dbo.tbl_SALE_Order o
INNER JOIN dbo.tbl_SALE_OrderDetail d ON d.IDOrder = o.Id
{1}
WHERE {3} {4} {5} {6}
    {2}
	o.IsDeleted = 0 AND d.IsDeleted = 0
GROUP BY  o.IDBranch, o.IDOwner, o.IDContact, d.IDItem, d.IDUoM



SELECT 
v.IDBranch, b.Name BranchName, 
v.IDOwner IDSaleman, s.FullName, 
v.IDContact, c.Code ContactCode, c.Name ContactName, c.WorkPhone,
r.Id IDItemGroupRoot, r.Name ItemGroupRoot,
i.IDItemGroup, g.Name ItemGroup, 
v.IDItem, i.Code ItemCode, i.Name ItemName, 
u.Id IDUoM, u.Name UoM,
v.Quantity, v.ShippedQuantity, v.PromotionQuantity, v.TotalBeforeDiscount, v.Discount1, v.Discount2, v.TotalDiscount, 
v.TotalAfterDiscount 

FROM @v v
INNER JOIN dbo.tbl_BRA_Branch b ON b.Id = v.IDBranch
INNER JOIN dbo.tbl_CRM_Contact c ON c.Id = v.IDContact
INNER JOIN dbo.tbl_WMS_Item i ON i.Id = v.IDItem
INNER JOIN dbo.tbl_WMS_ItemGroup g ON g.Id = i.IDItemGroup
INNER JOIN dbo.tbl_WMS_ItemUoM u ON u.Id = v.IDUoM
INNER JOIN dbo.tbl_HRM_Staff s ON s.Id = v.IDOwner
INNER JOIN dbo.tbl_WMS_ItemGroup r ON r.Id = dbo.fnGetRootParentID(i.IDItemGroup)


ORDER BY b.Name, c.Code, s.FirstName, r.Name, i.Code, u.IsBaseUoM

";

            queryString = queryBuilder(queryString, QueryStrings);
            var results = db.Database.SqlQuery<SaleReport>(queryString);
            return results.ToList();
        }


        public static tbl_SALE_Order mergeOrders(AppEntities db, DTO_MergeSaleOrders item)
        {
            string err = "";
            var newItem = new DTO_SALE_Order();
            var dbitem = new tbl_SALE_Order();
            db.tbl_SALE_Order.Add(dbitem);

            var address = db.tbl_CRM_PartnerAddress.FirstOrDefault(d => d.IDPartner == item.IDContact && d.IsDeleted == false);
            if (address==null)
            {
                return null;
            }

            newItem.IDBranch = item.IDBranch;
            newItem.OrderDate = DateTime.Now;
            newItem.IDOwner = item.IDOwner;
            newItem.IDStatus = 101;
            newItem.IDContact = item.IDContact;
            newItem.IDAddress = address.Id;
            newItem.IsSampleOrder = item.IsSampleOrder;
            newItem.IsUrgentOrders = item.IsUrgentOrders;
            newItem.IsWholeSale = item.IsWholeSale;
            newItem.CreatedBy = item.CreatedBy;
            newItem.CreatedDate = newItem.OrderDate;

            dbitem.IDOwner = newItem.IDOwner;
            dbitem.IDBranch = newItem.IDBranch;
            dbitem.IDStatus = newItem.IDStatus;
            dbitem.IDAddress = newItem.IDAddress;
            dbitem.OrderDate = newItem.OrderDate;
            dbitem.CreatedBy = dbitem.ModifiedBy = newItem.CreatedBy;
            dbitem.CreatedDate = dbitem.ModifiedDate = newItem.CreatedDate;


            db.SaveChanges();

            newItem.Id = dbitem.Id;
            newItem.Remark = String.Format("{0}={1};", String.Join("+", item.Ids), newItem.Id);


            var oldOrders = db.tbl_SALE_Order.Where(d => item.Ids.Contains(d.Id));
            foreach (var o in oldOrders)
            {
                o.IDStatus = 112;
                o.IDParent = newItem.Id;
                o.Remark += newItem.Remark;
            }

            var rows = db.tbl_SALE_OrderDetail.Where(d => item.Ids.Contains(d.IDOrder) && d.IsDeleted == false);
            var itemIds = rows.Select(s => s.IDItem).Distinct().ToList();
            var itemUoMs = db.tbl_WMS_ItemUoM.Where(d => itemIds.Contains(d.IDItem) && d.IsDeleted == false).ToList();

            newItem.OrderLines = new List<DTO_SALE_OrderDetail>();
            foreach (var r in rows.GroupBy(g => new { g.IDItem, g.IDUoM, g.IDBaseUoM, g.UoMSwap, g.IsPromotionItem, g.UoMPrice }).Select(s => new
            {
                s.Key.IDItem,
                s.Key.IDUoM,
                s.Key.IDBaseUoM,
                s.Key.UoMSwap,
                s.Key.IsPromotionItem,
                s.Key.UoMPrice,
                Quantity = s.Sum(x => x.Quantity),
                OriginalDiscount1 = s.Sum(x => x.OriginalDiscount1),
                OriginalDiscount2 = s.Sum(x => x.OriginalDiscount2),
                OriginalDiscountFromSalesman = s.Sum(x => x.OriginalDiscountFromSalesman),
                OriginalDiscountByOrder = s.Sum(x => x.OriginalDiscountByOrder),
                ProductWeight = s.Sum(x => x.ProductWeight),
                ProductDimensions = s.Sum(x => x.ProductDimensions),
            }))
            {
                newItem.OrderLines.Add(new DTO_SALE_OrderDetail()
                {
                    IDOrder = newItem.Id,
                    IDItem = r.IDItem,
                    IDUoM = r.IDUoM,
                    IDBaseUoM = r.IDBaseUoM,
                    UoMSwap = r.UoMSwap,
                    UoMPrice = r.UoMPrice,
                    Quantity = r.Quantity,
                    IsPromotionItem = r.IsPromotionItem,
                    OriginalDiscount1 = r.OriginalDiscount1,
                    OriginalDiscount2 = r.OriginalDiscount2,
                    OriginalDiscountFromSalesman = r.OriginalDiscountFromSalesman,
                    OriginalDiscountByOrder = r.OriginalDiscountByOrder,
                    ProductWeight = r.ProductWeight,
                    ProductDimensions = r.ProductDimensions,
                    CreatedBy = newItem.CreatedBy,
                    ModifiedBy = newItem.CreatedBy,
                    CreatedDate = newItem.CreatedDate,
                    ModifiedDate = newItem.CreatedDate,
                });
            }

            BS_SALE_Order.calcOrder(dbitem, newItem, item.CreatedBy, dbitem.CreatedDate, out err, itemUoMs);
            db.SaveChanges();

            return dbitem;
        }

        public static void splitOrder(AppEntities db, DTO_SplitSaleOrders item)
        {
            var oldOrder = db.tbl_SALE_Order.Find(item.Id);
            var oldRows = oldOrder.tbl_SALE_OrderDetail.Where(d => d.IDOrder == item.Id && d.IsDeleted == false);

            var itemIds = oldRows.Select(s => s.IDItem).Distinct().ToList();
            var itemUoMs = db.tbl_WMS_ItemUoM.Where(d => itemIds.Contains(d.IDItem) && d.IsDeleted == false).ToList();

            List<tbl_SALE_Order> newOrders = new List<tbl_SALE_Order>();

            foreach (var splitedOrder in item.SplitedOrders)
            {
                var dbitem = new tbl_SALE_Order();
                string err = "";
                newOrders.Add(dbitem);
                db.tbl_SALE_Order.Add(dbitem);

                splitedOrder.IDParent = item.Id;
                splitedOrder.IDBranch = item.IDBranch;
                splitedOrder.IDStatus = 101;
                splitedOrder.IDOwner = item.IDOwner;
                splitedOrder.OrderDate = DateTime.Now;

                dbitem.CreatedBy = dbitem.ModifiedBy = item.CreatedBy;
                dbitem.CreatedDate = dbitem.ModifiedDate = splitedOrder.OrderDate;

                BS_SALE_Order.calcOrder(dbitem, splitedOrder, item.CreatedBy, splitedOrder.OrderDate, out err, itemUoMs);
            }

            db.SaveChanges();

            oldOrder.Remark = String.Format("{0}={1};", item.Id, String.Join("+", newOrders.Select(s => s.Id).ToArray()));
            oldOrder.IDStatus = 111;
            foreach (var newOrder in newOrders)
            {
                newOrder.Remark = oldOrder.Remark;
            }
            db.SaveChanges();

        }

        public static void submitSalesmanOrdersForApproval(AppEntities db, int StaffID)
        {

            var canApproveStatus = new List<int>() { 101, 102 };
            var items = db.tbl_SALE_Order.Where(d => d.IDOwner == StaffID && canApproveStatus.Contains(d.IDStatus) && d.tbl_SALE_OrderDetail.Count(od => !od.IsDeleted) > 0);
            foreach (var i in items)
            {
                i.IDStatus = 103;
            }
        }


        public static void submitOrdersForApproval(AppEntities db, DTO_ApproveOrders item)
        {
            var ids = item.Ids;
            var canApproveStatus = new List<int>() { 101, 102 };
            var items = db.tbl_SALE_Order.Where(d => ids.Contains(d.Id) && canApproveStatus.Contains(d.IDStatus) && d.tbl_SALE_OrderDetail.Count(od => !od.IsDeleted) > 0);
            foreach (var i in items)
            {
                i.IDStatus = 103;
            }
        }

        public static void approveOrders(AppEntities db, DTO_ApproveOrders item)
        {
            var ids = item.Ids;
            var canApproveStatus = new List<int>() { 101, 102, 103, 110 };
            var items = db.tbl_SALE_Order.Where(d => ids.Contains(d.Id) && canApproveStatus.Contains(d.IDStatus) && d.tbl_SALE_OrderDetail.Count(od => !od.IsDeleted) > 0);
            foreach (var i in items)
            {
                i.IDStatus = 104;
            }
        }

        public static void disapproveOrders(AppEntities db, DTO_ApproveOrders item)
        {
            var ids = item.Ids;
            var canDisapproveStatus = new List<int>() { 103, 104 };
            var items = db.tbl_SALE_Order.Where(d => ids.Contains(d.Id) && canDisapproveStatus.Contains(d.IDStatus));
            foreach (var i in items)
            {
                i.IDStatus = 102;
            }
        }

        public static void cancelOrders(AppEntities db, DTO_ApproveOrders item)
        {
            var ids = item.Ids;
            var canApproveStatus = new List<int>() { 101, 102, 103, 110 };
            var items = db.tbl_SALE_Order.Where(d => ids.Contains(d.Id) && canApproveStatus.Contains(d.IDStatus));
            foreach (var i in items)
            {
                i.IDStatus = 115;
            }
        }

    }
}
