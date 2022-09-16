namespace BaseBusiness
{
    using ClassLibrary;
    using DTOModel;
    using Newtonsoft.Json.Linq;
    using OfficeOpenXml;
    using System;
    using System.Collections.Generic;
    using System.Data;
    using System.Data.Entity;
    using System.Data.Entity.Validation;
    using System.Linq;

    public static partial class BS_PURCHASE_Order
    {
        public static dynamic getCustom(AppEntities db, int IDBranch, int StaffID, Dictionary<string, string> QueryStrings)
        {
            var query = _queryBuilder(db, IDBranch, StaffID, QueryStrings);

            if (QueryStrings.Any(d => d.Key == "StorerName") && !string.IsNullOrEmpty(QueryStrings.FirstOrDefault(d => d.Key == "StorerName").Value))
            {
                var keyword = QueryStrings.FirstOrDefault(d => d.Key == "StorerName").Value;
                query = query.Where(d => d.tbl_CRM_Contact.Name.Contains(keyword) || d.tbl_CRM_Contact.Code.Contains(keyword));
            }

            if (QueryStrings.Any(d => d.Key == "VendorName") && !string.IsNullOrEmpty(QueryStrings.FirstOrDefault(d => d.Key == "VendorName").Value))
            {
                var keyword = QueryStrings.FirstOrDefault(d => d.Key == "VendorName").Value;
                query = query.Where(d => d.tbl_CRM_Contact1.Name.Contains(keyword) || d.tbl_CRM_Contact1.Code.Contains(keyword));
            }


            query = _sortBuilder(query, QueryStrings);
            query = _pagingBuilder(query, QueryStrings);

            return query.Select(s => new
            {
                Id = s.Id,
                Code = s.Code,
                BranchName = s.tbl_BRA_Branch.Name,
                StorerName = s.tbl_CRM_Contact.Name,
                VendorName = s.tbl_CRM_Contact1.Name,

                OrderDate = s.OrderDate,
                ExpectedReceiptDate = s.ExpectedReceiptDate,
                ReceiptedDate = s.ReceiptedDate,
                Status = s.Status,
                PaymentStatus = s.PaymentStatus,

                CreatedBy = s.CreatedBy,
                ModifiedBy = s.ModifiedBy,
                CreatedDate = s.CreatedDate,
                ModifiedDate = s.ModifiedDate,

                TotalAfterTax = s.tbl_PURCHASE_OrderDetail.Where(d => d.IsDeleted == false).GroupBy(g => g.IDOrder).Select(sg => sg.Sum(ss => ss.TotalAfterTax)).FirstOrDefault()
            });
        }

        public static dynamic getAnItemCustom(AppEntities db, int IDBranch, int StaffID, int id)
        {
            var dbResult = db.tbl_PURCHASE_Order
                .Include(i => i.tbl_BRA_Branch)
                .Include(i => i.tbl_CRM_Contact)
                .Include(i => i.tbl_CRM_Contact1)
                .FirstOrDefault(d => d.Id == id && d.IsDeleted == false);
            if (dbResult == null) return null;

            int buyPriceList = BS_WMS_PriceList.getPriceListByPO(db, id);

            //BS_WMS_PriceList.getPriceListByStaffID(db, StaffID, out int buyPriceList, out int salePriceList);


            #region order lines
            var OrderLines = dbResult.tbl_PURCHASE_OrderDetail.Where(d => d.IsDeleted == false).Select(s => new
            {
                IDOrder = s.IDOrder,
                Id = s.Id,
                Code = s.Code,
                Remark = s.Remark,
                ForeignRemark = s.ForeignRemark,
                IDItem = s.IDItem,
                IDUoM = s.IDUoM,
                UoMPrice = s.UoMPrice,
                UoMQuantityExpected = s.UoMQuantityExpected,
                IsPromotionItem = s.IsPromotionItem,
                TotalBeforeDiscount = s.TotalBeforeDiscount,
                TotalDiscount = s.TotalDiscount,
                TotalAfterDiscount = s.TotalAfterDiscount,
                IDTax = s.IDTax,
                TaxRate = s.TaxRate,
                Tax = s.Tax,
                TotalAfterTax = s.TotalAfterTax,

                _SplitUoMs = BS_WMS_ItemUoM.splitUoM(s.tbl_WMS_Item, s.QuantityExpected, s.IDUoM),

                _Item = s.tbl_WMS_Item == null ? null : new
                {
                    s.tbl_WMS_Item.Id,
                    s.tbl_WMS_Item.Code,
                    s.tbl_WMS_Item.Name,
                    s.tbl_WMS_Item.SalesUoM,
                    s.tbl_WMS_Item.PurchasingUoM,
                    UoMs = s.tbl_WMS_Item.tbl_WMS_ItemUoM.Where(ud => ud.IsDeleted == false && ud.tbl_WMS_PriceListDetail.Any(dp => dp.IsDeleted == false && (dp.IDPriceList == buyPriceList))).Select(su => new
                    {
                        su.Id,
                        su.Name,
                        PriceList = su.tbl_WMS_PriceListDetail.Where(dp => dp.IsDeleted == false && (dp.IDPriceList == buyPriceList)).Select(p => new
                        {
                            Type = "PriceListForVendor",
                            p.Id,
                            p.Price
                        })
                    })
                }
            });

            #endregion

            return new
            {
                TotalBeforeDiscount = OrderLines.Sum(d=>d.TotalBeforeDiscount),
                TotalDiscount = OrderLines.Sum(d => d.TotalDiscount),
                TotalAfterDiscount = OrderLines.Sum(d => d.TotalAfterDiscount),
                TotalTax = OrderLines.Sum(d => d.Tax),
                TotalAfterTax = OrderLines.Sum(d => d.TotalAfterTax),
                
                
                _Branch = new
                {
                    dbResult.tbl_BRA_Branch.Name,
                    dbResult.tbl_BRA_Branch.Phone,
                    dbResult.tbl_BRA_Branch.Phone2,
                    dbResult.tbl_BRA_Branch.LogoURL,
                    dbResult.tbl_BRA_Branch.TemplateHeader,
                    dbResult.tbl_BRA_Branch.Address,
                },
                _Vendor = new
                {
                    dbResult.tbl_CRM_Contact1.Name,
                    dbResult.tbl_CRM_Contact1.CompanyName
                },
                _Storer = new
                {
                    dbResult.tbl_CRM_Contact.Name,
                    dbResult.tbl_CRM_Contact.CompanyName
                },
                IDBranch = dbResult.IDBranch,
                IDStorer = dbResult.IDStorer,
                IDVendor = dbResult.IDVendor,
                Id = dbResult.Id,
                Code = dbResult.Code,
                Name = dbResult.Name,
                ForeignName = dbResult.ForeignName,
                Remark = dbResult.Remark,
                ForeignRemark = dbResult.ForeignRemark,
                OrderDate = dbResult.OrderDate,
                ExpectedReceiptDate = dbResult.ExpectedReceiptDate,
                ReceiptedDate = dbResult.ReceiptedDate,
                Status = dbResult.Status,
                PaymentStatus = dbResult.PaymentStatus,
                IsDisabled = dbResult.IsDisabled,
                IsDeleted = dbResult.IsDeleted,
                CreatedBy = dbResult.CreatedBy,
                ModifiedBy = dbResult.ModifiedBy,
                CreatedDate = dbResult.CreatedDate,
                ModifiedDate = dbResult.ModifiedDate,

                OrderLines = OrderLines
            };
        }

        public static dynamic postCustom(AppEntities db, int IDBranch, int StaffID, dynamic item, string Username)
        {
            tbl_PURCHASE_Order dbitem = new tbl_PURCHASE_Order();
            if (item != null)
            {
                try
                {
                    if (item.Id != 0 && item.Id != null)
                    {
                        dbitem = db.tbl_PURCHASE_Order.Find((int)item.Id);
                    }
                    else
                    {
                        db.tbl_PURCHASE_Order.Add(dbitem);
                        dbitem.CreatedBy = Username;
                        dbitem.CreatedDate = DateTime.Now;
                        dbitem.OrderDate = dbitem.CreatedDate;
                        dbitem.Status = "PODraft";
                        dbitem.PaymentStatus = "WaitForPay";
                    }

                    patchDynamicToDB(item, dbitem, Username);

                    if (item.OrderLines != null)
                    {
                        foreach (var l in item.OrderLines)
                        {
                            dynamic line = l.Value;
                            if (line == null)
                                continue;

                            tbl_PURCHASE_OrderDetail dbline = new tbl_PURCHASE_OrderDetail();
                            if (line.Id != 0)
                            {
                                dbline = db.tbl_PURCHASE_OrderDetail.Find((int)line.Id);

                            }
                            else
                            {
                                dbitem.tbl_PURCHASE_OrderDetail.Add(dbline);
                                dbline.CreatedBy = Username;
                                dbline.CreatedDate = DateTime.Now;
                                //db.tbl_PURCHASE_OrderDetail.Attach(dbline);
                            }

                            BS_PURCHASE_OrderDetail.patchDynamicToDB(line, dbline, Username);

                            tbl_WMS_Item dbItem = db.tbl_WMS_Item.Find(dbline.IDItem);
                            dbitem.tbl_PURCHASE_OrderDetail.Add(dbline);

                            dbline.TotalBeforeDiscount = dbline.UoMPrice * dbline.UoMQuantityExpected;
                            dbline.TotalAfterDiscount = dbline.TotalBeforeDiscount - dbline.TotalDiscount;

                            if (dbline.IsPromotionItem)
                            {
                                dbline.TotalDiscount = 0;
                                dbline.TotalAfterDiscount = 0;
                            }

                            dbline.Tax = dbline.TotalAfterDiscount * dbline.TaxRate;
                            dbline.TotalAfterTax = dbline.TotalAfterDiscount - dbline.Tax;

                        }
                    }

                    db.SaveChanges();
                }
                catch (DbEntityValidationException e)
                {
                    errorLog.logMessage("post_PURCHASE_Order", e);
                    dbitem = null;
                }
            }

            return getAnItemCustom(db, IDBranch, StaffID, dbitem.Id);
        }

        public static dynamic putCustom(AppEntities db, int IDBranch, int StaffID, int Id, dynamic item, string Username, Dictionary<string, string> QueryStrings)
        {
            var saved = postCustom(db, IDBranch, StaffID, item, Username);
            return getAnItemCustom(db, IDBranch, StaffID, Id);
        }

        public static dynamic PostImportDetailFile(ExcelPackage package, int IDPO, AppEntities db, int IDBranch, int StaffID, Dictionary<string, string> QueryStrings, string Username)
        {
            ExcelWorkbook workBook = package.Workbook;
            int errCount = 0;
            var errList = new List<Tuple<int, int, string>>().Select(t => new { Id = t.Item1, Line = t.Item2, Message = t.Item3 }).ToList();

            var dbPO = db.tbl_PURCHASE_Order.Find(IDPO);
            var dbPODetail = dbPO.tbl_PURCHASE_OrderDetail.Where(d => d.IsDeleted == false);

            if (dbPO.Status != "PODraft")
            {
                errCount++;
                errList.Add(new { Id = errCount, Line = 0, Message = "This document was locked!" });
                return new
                {
                    ErrorList = errList,
                    FileUrl = package.File.FullName.Substring(package.File.FullName.IndexOf("\\Uploads\\")).Replace("\\", "/")
                };
            }


            if (workBook != null)
            {
                //Lặp lấy dataRow => dynamic
                //Lấy danh sách item theo code + đơn vị gốc hoặc lưu kho
                //Lặp dataRow - validate + add db

                Type type = Type.GetType("BaseBusiness.BS_PURCHASE_OrderDetail, ClassLibrary");
                var ws = workBook.Worksheets.FirstOrDefault();
                int SheetColumnsCount = ws.Dimension.End.Column;
                int SheetRowCount = ws.Dimension.End.Row;
                int firstRow = 5;
                int firstColIndex = 1;

                List<dynamic> imRows = new List<dynamic>();
                for (int r = firstRow; r <= SheetRowCount; r++)
                {
                    dynamic it = new Newtonsoft.Json.Linq.JObject();
                    bool isBreak = false;
                    for (int c = firstColIndex; c <= SheetColumnsCount; c++)
                    {
                        dynamic convert = new Newtonsoft.Json.Linq.JObject();
                        var target = new tbl_PURCHASE_OrderDetail();
                        string property = ws.Cells[1, c].Value == null ? "" : ws.Cells[1, c].Text;
                        if (!string.IsNullOrEmpty(property))
                        {
                            var v = ws.Cells[r, c].Value == null ? "" : ws.Cells[r, c].Value.ToString();
                            try
                            {
                                if (property.Contains("|"))
                                {
                                    it[property] = v;
                                    property = property.Split('|')[1];
                                    if (v.Contains("."))
                                        v = v.Split('.')[0];
                                }

                                convert[property] = string.IsNullOrEmpty(v) ? null : v;
                                BS_PURCHASE_OrderDetail.patchDynamicToDB(convert, target, Username);
                                System.Reflection.MethodInfo validate = type.GetMethod("validate");
                                if (validate != null)
                                {
                                    string message = (string)validate.Invoke(null, new object[] { target, property, db, IDBranch, StaffID, QueryStrings, Username });

                                    if (message != "OK")
                                    {
                                        errCount++;
                                        errList.Add(new { Id = errCount, Line = r, Message = message });
                                        ExcelUtil.NoteToWorkSheet(ws, r, c, message, System.Drawing.Color.Red, System.Drawing.Color.White);
                                        isBreak = true;
                                        continue;
                                    }
                                }

                                if (property == "ItemCode" && string.IsNullOrEmpty(v))
                                {
                                    errCount++;
                                    string message = "Không có mã sản phẩm";
                                    errList.Add(new { Id = errCount, Line = r, Message = message });
                                    ExcelUtil.NoteToWorkSheet(ws, r, c, message, System.Drawing.Color.Red, System.Drawing.Color.White);
                                    isBreak = true;
                                    continue;
                                }

                                if ((property == "PurchaseUoM" || property == "BaseUoM") && !string.IsNullOrEmpty(v) && !int.TryParse(v, out int pqty))
                                {
                                    errCount++;
                                    string message = "Số lượng không hợp lệ";
                                    errList.Add(new { Id = errCount, Line = r, Message = message });
                                    ExcelUtil.NoteToWorkSheet(ws, r, c, message, System.Drawing.Color.Red, System.Drawing.Color.White);
                                    isBreak = true;
                                    continue;
                                }

                                it[property] = convert[property];
                            }
                            catch (Exception ex)
                            {
                                errCount++;
                                errList.Add(new { Id = errCount, Line = r, Message = ex.Message });
                                ExcelUtil.NoteToWorkSheet(ws, r, c, ex.Message, System.Drawing.Color.Red, System.Drawing.Color.White);
                                isBreak = true;
                                continue;
                            }
                        }
                    }
                    if (isBreak) continue;
                    it.Index = r;
                    imRows.Add(it);
                }

                var itemCodes = imRows.Select(s => (string)s.ItemCode).ToList();
                var items = db.tbl_WMS_Item.Where(d => itemCodes.Contains(d.Code) && d.IsDeleted == false).ToList();
                int buyPriceList = BS_WMS_PriceList.getPriceListByPO(db, IDPO);

                foreach (var it in imRows)
                {
                    var dbItem = items.FirstOrDefault(d => d.Code == (string)it.ItemCode);
                    if (dbItem == null)
                    {
                        errCount++;
                        string message = "Không tìm được sản phẩm";
                        errList.Add(new { Id = errCount, Line = (int)it.Index, Message = message });
                        ExcelUtil.NoteToWorkSheet(ws, (int)it.Index, firstColIndex, message, System.Drawing.Color.Red, System.Drawing.Color.White);
                        continue;
                    }

                    var bUoM = dbItem.tbl_WMS_ItemUoM.FirstOrDefault(d => d.IsBaseUoM);
                    var pUoM = dbItem.tbl_WMS_ItemUoM.FirstOrDefault(d => d.Id == dbItem.PurchasingUoM);



                    decimal pQty = 0;
                    decimal bQty = 0;

                    decimal.TryParse((string)it.PurchaseUoM, out pQty);
                    decimal.TryParse((string)it.BaseUoM, out bQty);

                    if (pQty + bQty == 0)
                    {
                        errCount++;
                        string message = "Số lượng không hợp lệ.";
                        errList.Add(new { Id = errCount, Line = (int)it.Index, Message = message });
                        ExcelUtil.NoteToWorkSheet(ws, (int)it.Index, firstColIndex, message, System.Drawing.Color.Red, System.Drawing.Color.White);
                        continue;
                    }

                    tbl_PURCHASE_OrderDetail dbline = new tbl_PURCHASE_OrderDetail();
                    if (it.Id == null || string.IsNullOrEmpty(it.Id.Value) || it.Id == "0")
                    {
                        dbline = new tbl_PURCHASE_OrderDetail();
                        dbline.IDOrder = dbPO.Id;
                        dbline.CreatedBy = Username;
                        dbline.CreatedDate = DateTime.Now;

                    }
                    else
                    {
                        dbline = db.tbl_PURCHASE_OrderDetail.Find((int)it.Id);
                    }

                    if (dbline == null)
                    {
                        errCount++;
                        string message = "Không tìm được dữ liệu (Id: " + it.Id + ")";
                        errList.Add(new { Id = errCount, Line = (int)it.Index, Message = message });
                        ExcelUtil.NoteToWorkSheet(ws, (int)it.Index, firstColIndex, message, System.Drawing.Color.Red, System.Drawing.Color.White);
                        continue;
                    }

                    try
                    {
                        dbline.IDItem = dbItem.Id;

                        if (pUoM == null)
                        {
                            errCount++;
                            string message = "Không tìm được đơn vị mua vào";
                            errList.Add(new { Id = errCount, Line = (int)it.Index, Message = message });
                            ExcelUtil.NoteToWorkSheet(ws, (int)it.Index, firstColIndex, message, System.Drawing.Color.Red, System.Drawing.Color.White);
                            continue;
                        }

                        if (bUoM == null)
                        {
                            errCount++;
                            string message = "Không tìm được đơn vị gốc";
                            errList.Add(new { Id = errCount, Line = (int)it.Index, Message = message });
                            ExcelUtil.NoteToWorkSheet(ws, (int)it.Index, firstColIndex, message, System.Drawing.Color.Red, System.Drawing.Color.White);
                            continue;
                        }

                        var splitedUoMs = new List<DTO_ConvertUnit>();
                        splitedUoMs.Add(new DTO_ConvertUnit() { ItemId = dbItem.Id, UoMId = pUoM.Id, Quantity = pQty });
                        splitedUoMs.Add(new DTO_ConvertUnit() { ItemId = dbItem.Id, UoMId = bUoM.Id, Quantity = bQty });
                        var mUoM = BS_WMS_ItemUoM.mergeUoM(dbItem, splitedUoMs, pUoM.Id);

                        dbline.IDUoM = mUoM.UoMId;
                        dbline.UoMQuantityExpected = mUoM.Quantity;
                        dbline.QuantityExpected = mUoM.BaseQuantity;

                        
                        var mBuyPrice = db.tbl_WMS_PriceListDetail.FirstOrDefault(d => d.IDItemUoM == mUoM.UoMId && d.IDPriceList == buyPriceList && d.IsDeleted == false);
                        if (mBuyPrice == null)
                        {
                            errCount++;
                            string message = "Không tìm thấy giá mua sản phẩm này";
                            errList.Add(new { Id = errCount, Line = (int)it.Index, Message = message });
                            ExcelUtil.NoteToWorkSheet(ws, (int)it.Index, firstColIndex, message, System.Drawing.Color.Red, System.Drawing.Color.White);
                            continue;
                        }
                        dbline.UoMPrice = mBuyPrice.Price;

                        dbline.TotalBeforeDiscount = dbline.UoMPrice * dbline.UoMQuantityExpected;
                        dbline.TotalAfterDiscount = dbline.TotalBeforeDiscount - dbline.TotalDiscount;

                        if (dbline.IsPromotionItem)
                        {
                            dbline.TotalDiscount = 0;
                            dbline.TotalAfterDiscount = 0;
                        }

                        dbline.Tax = dbline.TotalAfterDiscount * dbline.TaxRate;
                        dbline.TotalAfterTax = dbline.TotalAfterDiscount - dbline.Tax;

                        dbline.ModifiedBy = Username;
                        dbline.ModifiedDate = DateTime.Now;
                        if (dbline.Id == 0) db.tbl_PURCHASE_OrderDetail.Add(dbline);
                    }
                    catch (Exception ex)
                    {
                        errCount++;
                        errList.Add(new { Id = errCount, Line = (int)it.Index, Message = ex.Message });
                        ExcelUtil.NoteToWorkSheet(ws, (int)it.Index, firstColIndex, ex.Message, System.Drawing.Color.Red, System.Drawing.Color.White);
                        continue;
                    }
                }

                try
                {
                    db.SaveChanges();
                }
                catch (System.Data.Entity.Infrastructure.DbUpdateException e)
                {
                    errCount++;
                    errList.Add(new { Id = errCount, Line = firstRow, Message = e.Message });
                    ExcelUtil.NoteToWorkSheet(ws, firstRow, firstColIndex, e.Message, System.Drawing.Color.Red, System.Drawing.Color.White);
                }
                catch (DbEntityValidationException e)
                {
                    errorLog.logMessage("post_PURCHASE_OrderDetail", e);
                    errCount++;
                    errList.Add(new { Id = errCount, Line = firstRow, Message = e.Message });
                    ExcelUtil.NoteToWorkSheet(ws, firstRow, firstColIndex, e.Message, System.Drawing.Color.Red, System.Drawing.Color.White);
                }
                catch (Exception e)
                {
                    errCount++;
                    errList.Add(new { Id = errCount, Line = firstRow, Message = e.Message });
                    ExcelUtil.NoteToWorkSheet(ws, firstRow, firstColIndex, e.Message, System.Drawing.Color.Red, System.Drawing.Color.White);
                }

            }
            if (errCount > 0)
            {
                package.Save();
            }

            return new
            {
                ErrorList = errList,
                FileUrl = package.File.FullName.Substring(package.File.FullName.IndexOf("\\Uploads\\")).Replace("\\", "/")
            };
        }

        public static int copyToReceipt(AppEntities db, int IDBranch, int StaffID, dynamic item, string Username)
        {
            int result = 0;
            tbl_PURCHASE_Order POItem = null;
            if (item != null)
            {
                if (item.Id != 0 && item.Id != null)
                {
                    POItem = db.tbl_PURCHASE_Order.Find((int)item.Id);
                }

                if (POItem.Status == "PODraft")
                {
                    POItem.Status = "POConfirmed";
                }

                if (POItem != null && POItem.tbl_PURCHASE_OrderDetail.Count(d => d.IsDeleted == false) > 0)
                {
                    dynamic dbitem = new Newtonsoft.Json.Linq.JObject();

                    dbitem.IDBranch = POItem.IDBranch;
                    dbitem.IDStorer = POItem.IDStorer;
                    dbitem.IDVendor = POItem.IDVendor;

                    dbitem.IDPurchaseOrder = POItem.Id;
                    dbitem.POCode = POItem.Code;

                    dbitem.IDCarrier = item.IDCarrier;
                    dbitem.VehicleNumber = item.VehicleNumber;

                    dbitem.ExpectedReceiptDate = POItem.ExpectedReceiptDate.HasValue ? POItem.ExpectedReceiptDate.Value : DateTime.Now;

                    JArray jarrayObj = new JArray();

                    foreach (var line in POItem.tbl_PURCHASE_OrderDetail.Where(d => d.IsDeleted == false).ToList())
                    {
                        dynamic dbline = new Newtonsoft.Json.Linq.JObject();

                        dbline.IDPO = line.IDOrder;
                        dbline.IDPOLine = line.Id;
                        dbline.IDItem = line.IDItem;
                        dbline.IDUoM = line.IDUoM;
                        dbline.UoMQuantityExpected = line.UoMQuantityExpected;

                        dbline.Lottable0 = "-";
                        dbline.Lottable5 = "2021-01-01";
                        dbline.Lottable6 = "2099-01-01";

                        jarrayObj.Add(dbline);

                    }

                    dbitem.Add("Lines", jarrayObj);

                    result = BS_WMS_Receipt.save(db, IDBranch, StaffID, dbitem, Username);

                }

            }

            return result;
        }

        public static int changePOStatus(AppEntities db, List<int> ids, List<string> fromStatus, string toStatus, int IDBranch, int StaffID, string Username)
        {
            var items = db.tbl_PURCHASE_Order.Where(d => ids.Contains(d.Id) && fromStatus.Contains(d.Status) && d.tbl_PURCHASE_OrderDetail.Count(od => !od.IsDeleted) > 0).ToList();
            foreach (var i in items)
            {
                i.Status = toStatus;
                i.ModifiedBy = Username;
                i.ModifiedDate = DateTime.Now;
            }
            db.SaveChanges();
            return items.Count();
        }

    }
}
