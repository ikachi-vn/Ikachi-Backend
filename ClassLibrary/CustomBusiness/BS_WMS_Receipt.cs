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

    public static partial class BS_WMS_Receipt
    {
        public static dynamic getCustom(AppEntities db, int IDBranch, int StaffID, Dictionary<string, string> QueryStrings)
        {
            var query = _queryBuilder(db, IDBranch, StaffID, QueryStrings);
            query = _sortBuilder(query, QueryStrings);
            query = _pagingBuilder(query, QueryStrings);

            return query
            .Select(s => new
            {
                IDBranch = s.IDBranch,
                IDStorer = s.IDStorer,
                IDVendor = s.IDVendor,
                IDCarrier = s.IDCarrier,
                s.IDPurchaseOrder,

                StorerName = s.tbl_CRM_Contact.Name,
                VendorName = s.tbl_CRM_Contact1.Name,

                Id = s.Id,
                VehicleNumber = s.VehicleNumber,
                ExpectedReceiptDate = s.ExpectedReceiptDate,
                ArrivalDate = s.ArrivalDate,
                ReceiptedDate = s.ReceiptedDate,
                ClosedDate = s.ClosedDate,
                Type = s.Type,
                Status = s.Status,

                CreatedBy = s.CreatedBy,
                ModifiedBy = s.ModifiedBy,
                CreatedDate = s.CreatedDate,
                ModifiedDate = s.ModifiedDate,
            });
        }

        public static dynamic getAnItemCustom(AppEntities db, int IDBranch, int StaffID, int id)
        {
            var dbResult = db.tbl_WMS_Receipt
                .Include(i => i.tbl_WMS_ReceiptDetail)
                .FirstOrDefault(d => d.Id == id);
            if (dbResult == null) return null;

            return new
            {
                IDBranch = dbResult.IDBranch,
                IDStorer = dbResult.IDStorer,
                IDVendor = dbResult.IDVendor,
                Id = dbResult.Id,
                IDPurchaseOrder = dbResult.IDPurchaseOrder,
                POCode = dbResult.POCode,
                Code = dbResult.Code,
                Name = dbResult.Name,
                ForeignName = dbResult.ForeignName,
                Remark = dbResult.Remark,
                ForeignRemark = dbResult.ForeignRemark,
                ExternalReceiptKey = dbResult.ExternalReceiptKey,
                IDCarrier = dbResult.IDCarrier,
                VehicleNumber = dbResult.VehicleNumber,
                ExpectedReceiptDate = dbResult.ExpectedReceiptDate,
                ArrivalDate = dbResult.ArrivalDate,
                ReceiptedDate = dbResult.ReceiptedDate,
                ClosedDate = dbResult.ClosedDate,
                Type = dbResult.Type,
                Status = dbResult.Status,
                IsDisabled = dbResult.IsDisabled,
                IsDeleted = dbResult.IsDeleted,
                CreatedBy = dbResult.CreatedBy,
                ModifiedBy = dbResult.ModifiedBy,
                CreatedDate = dbResult.CreatedDate,
                ModifiedDate = dbResult.ModifiedDate,

                #region Lines
                Lines = dbResult.tbl_WMS_ReceiptDetail.Where(d => d.IsDeleted == false).Select(s => new
                {
                    IDReceipt = s.IDReceipt,
                    IDPO = s.IDPO,
                    IDPOLine = s.IDPOLine,
                    IDItem = s.IDItem,
                    Id = s.Id,
                    Code = s.Code,
                    Remark = s.Remark,
                    ForeignRemark = s.ForeignRemark,
                    ExternalReceipt = s.ExternalReceipt,
                    ExternalLine = s.ExternalLine,
                    Status = s.Status,
                    ReceivedDate = s.ReceivedDate,
                    IDUoM = s.IDUoM,
                    UoMQuantityExpected = s.UoMQuantityExpected,
                    QuantityExpected = s.QuantityExpected,
                    QuantityAdjusted = s.QuantityAdjusted,
                    QuantityReceived = s.QuantityReceived,
                    QuantityRejected = s.QuantityRejected,
                    Cube = s.Cube,
                    GrossWeight = s.GrossWeight,
                    NetWeight = s.NetWeight,
                    Lottable0 = s.Lottable0,
                    Lottable1 = s.Lottable1,
                    Lottable2 = s.Lottable2,
                    Lottable3 = s.Lottable3,
                    Lottable4 = s.Lottable4,
                    Lottable5 = s.Lottable5,
                    Lottable6 = s.Lottable6,
                    Lottable7 = s.Lottable7,
                    Lottable8 = s.Lottable8,
                    Lottable9 = s.Lottable9,

                    #region Pallets
                    Pallets = s.tbl_WMS_ReceiptPalletization.Where(d => d.IsDeleted == false).Select(sp => new
                    {
                        IDStorer = sp.IDStorer,
                        IDReceipt = sp.IDReceipt,
                        IDItem = sp.IDItem,
                        Id = sp.Id,
                        ReceiptLine = sp.ReceiptLine,
                        Status = sp.Status,
                        ReceivedDate = sp.ReceivedDate,
                        IDUoM = sp.IDUoM,
                        UoMQuantityExpected = sp.UoMQuantityExpected,
                        QuantityExpected = sp.QuantityExpected,
                        QuantityAdjusted = sp.QuantityAdjusted,
                        QuantityReceived = sp.QuantityReceived,
                        QuantityRejected = sp.QuantityRejected,
                        ToLocation = sp.ToLocation,
                        ToLot = sp.ToLot,
                        Cube = sp.Cube,
                        GrossWeight = sp.GrossWeight,
                        NetWeight = sp.NetWeight,
                        sp.IsFullPallet,
                        sp.Remark,
                        _Location = new { sp.tbl_WMS_Location.Id, sp.tbl_WMS_Location.Name },
                        _LPN = !sp.tbl_WMS_LicencePlateNumber.Any(dl => dl.IsDeleted == false) ? null :
                        sp.tbl_WMS_LicencePlateNumber.Where(dl => dl.IsDeleted == false).Select(sl => new { sl.Id, sl.Code }).FirstOrDefault()

                    }),
                    #endregion

                    _Item = s.tbl_WMS_Item == null ? null : new
                    {
                        s.tbl_WMS_Item.Id,
                        s.tbl_WMS_Item.Code,
                        s.tbl_WMS_Item.Name,
                        s.tbl_WMS_Item.SalesUoM,
                        s.tbl_WMS_Item.PurchasingUoM,
                        s.tbl_WMS_Item.Expiry,
                        s.tbl_WMS_Item.ExpiryUnit,
                        UoMs = s.tbl_WMS_Item.tbl_WMS_ItemUoM.Where(ud => ud.IsDeleted == false).Select(su => new
                        {
                            su.Id,
                            su.Name,

                            Cube = su.Length * su.Height * su.Width,
                            su.Weight,
                        })
                    }
                }),
                #endregion


            };

        }

        public static dynamic putCustom(AppEntities db, int IDBranch, int StaffID, int Id, dynamic item, string Username, Dictionary<string, string> QueryStrings)
        {
            var saved = postCustom(db, IDBranch, StaffID, item, Username);
            return getAnItemCustom(db, IDBranch, StaffID, Id);
        }

        public static dynamic postCustom(AppEntities db, int IDBranch, int StaffID, dynamic item, string Username)
        {
            tbl_WMS_Receipt dbitem = new tbl_WMS_Receipt();
            if (item != null)
            {
                try
                {

                    if (item.Id != 0 && item.Id != null)
                    {
                        dbitem = db.tbl_WMS_Receipt.Find((int)item.Id);
                    }
                    else
                    {
                        db.tbl_WMS_Receipt.Add(dbitem);
                        dbitem.CreatedBy = Username;
                        dbitem.CreatedDate = DateTime.Now;
                        dbitem.Status = "New";
                        dbitem.Type = "KeyIn";
                    }

                    if (dbitem==null || dbitem.Status!="New")
                    {
                        return null;
                    }

                    patchDynamicToDB(item, dbitem, Username);

                    if (item.Lines != null)
                    {
                        foreach (var l in item.Lines)
                        {
                            dynamic line = l.Value;
                            if (line == null)
                                continue;

                            tbl_WMS_ReceiptDetail dbline = new tbl_WMS_ReceiptDetail();
                            if (line.Id != 0)
                            {
                                dbline = db.tbl_WMS_ReceiptDetail.Find((int)line.Id);
                            }
                            else
                            {
                                dbitem.tbl_WMS_ReceiptDetail.Add(dbline);
                                dbline.CreatedBy = Username;
                                dbline.CreatedDate = DateTime.Now;
                            }

                            BS_WMS_ReceiptDetail.patchDynamicToDB(line, dbline, Username);

                            tbl_WMS_Item dbItem = db.tbl_WMS_Item.Find(dbline.IDItem);
                            var UoM = dbItem.tbl_WMS_ItemUoM.FirstOrDefault(d => d.Id == dbline.IDUoM);
                            dbline.Cube = UoM.Length * UoM.Width * UoM.Height * dbline.QuantityExpected;
                            dbline.GrossWeight = UoM.Weight * dbline.QuantityExpected;
                            dbline.NetWeight = UoM.Weight * dbline.QuantityExpected;

                        }
                    }

                    bool isPaletized = dbitem.tbl_WMS_ReceiptDetail.Any(d => d.tbl_WMS_ReceiptPalletization.Any(dp => dp.IsDeleted == false));

                    if (isPaletized)
                    {
                        return palletize(db, IDBranch, StaffID, item, Username);
                    }

                    db.SaveChanges();
                }
                catch (DbEntityValidationException e)
                {
                    errorLog.logMessage("post_WMS_Receipt", e);
                    dbitem = null;
                }
            }

            return getAnItemCustom(db, IDBranch, StaffID, dbitem.Id);

        }

        public static int save(AppEntities db, int IDBranch, int StaffID, dynamic item, string Username)
        {
            var result = 0;
            if (item != null)
            {
                try
                {
                    tbl_WMS_Receipt dbitem = new tbl_WMS_Receipt();
                    if (item.Id != 0 && item.Id != null)
                    {
                        dbitem = db.tbl_WMS_Receipt.Find((int)item.Id);
                    }
                    else
                    {
                        db.tbl_WMS_Receipt.Add(dbitem);
                        dbitem.CreatedBy = Username;
                        dbitem.CreatedDate = DateTime.Now;
                        dbitem.Status = "New";
                        dbitem.Type = "FromPO";
                    }

                    if (dbitem == null || dbitem.Status != "New")
                    {
                        return 0;
                    }

                    patchDynamicToDB(item, dbitem, Username);

                    if (item.Lines != null)
                    {
                        foreach (var l in item.Lines)
                        {
                            dynamic line = l.Value == null ? l : l.Value;
                            if (line == null)
                                continue;

                            tbl_WMS_ReceiptDetail dbline = new tbl_WMS_ReceiptDetail();
                            if (line.Id != null && line.Id.Value != 0)
                            {
                                dbline = db.tbl_WMS_ReceiptDetail.Find((int)line.Id);
                            }
                            else
                            {
                                dbitem.tbl_WMS_ReceiptDetail.Add(dbline);
                                dbline.CreatedBy = Username;
                                dbline.CreatedDate = DateTime.Now;
                            }

                            BS_WMS_ReceiptDetail.patchDynamicToDB(line, dbline, Username);

                            tbl_WMS_Item dbItem = db.tbl_WMS_Item.Find(dbline.IDItem);
                            var UoM = dbItem.tbl_WMS_ItemUoM.FirstOrDefault(d => d.Id == dbline.IDUoM);
                            dbline.QuantityExpected = dbline.UoMQuantityExpected * UoM.BaseQuantity / UoM.AlternativeQuantity;
                            dbline.Cube = UoM.Length * UoM.Width * UoM.Height * dbline.QuantityExpected;
                            dbline.GrossWeight = UoM.Weight * dbline.QuantityExpected;
                            dbline.NetWeight = UoM.Weight * dbline.QuantityExpected;

                        }
                    }

                    bool isPaletized = dbitem.tbl_WMS_ReceiptDetail.Any(d => d.tbl_WMS_ReceiptPalletization.Any(dp => dp.IsDeleted == false));

                    if (isPaletized)
                    {
                        return palletize(db, IDBranch, StaffID, item, Username);
                    }

                    db.SaveChanges();
                    result = dbitem.Id;
                }
                catch (DbEntityValidationException e)
                {
                    errorLog.logMessage("post_WMS_Receipt", e);
                }
            }

            return result;

        }

        public static dynamic PostImportReceiptDetailFile(ExcelPackage package, int IDReceipt, AppEntities db, int IDBranch, int StaffID, Dictionary<string, string> QueryStrings, string Username)
        {
            ExcelWorkbook workBook = package.Workbook;
            int errCount = 0;
            var errList = new List<Tuple<int, int, string>>().Select(t => new { Id = t.Item1, Line = t.Item2, Message = t.Item3 }).ToList();
            
            var dbReceipt = db.tbl_WMS_Receipt.Find(IDReceipt);
            var dbReceiptDetail = dbReceipt.tbl_WMS_ReceiptDetail.Where(d => d.IsDeleted == false);

            if (dbReceipt.Status != "New")
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
                Type type = Type.GetType("BaseBusiness.BS_WMS_ReceiptDetail, ClassLibrary");
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
                        var target = new tbl_WMS_ReceiptDetail();
                        string property = ws.Cells[1, c].Value == null ? "" : ws.Cells[1, c].Text;
                        if (!string.IsNullOrEmpty(property))
                        {
                            var v = ws.Cells[r, c].Value == null ? "" : ws.Cells[r, c].Value.ToString();
                            if (property == "Lottable5" || property == "Lottable6")
                                v = ws.Cells[r, c].Value == null ? "" : ws.Cells[r, c].Text;

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
                                BS_WMS_ReceiptDetail.patchDynamicToDB(convert, target, Username);
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
                    var iUoM = dbItem.tbl_WMS_ItemUoM.FirstOrDefault(d => d.Id == dbItem.InventoryUoM);

                    

                    decimal iQty = 0;
                    decimal bQty = 0;

                    decimal.TryParse((string)it.InventoryUoM, out iQty);
                    decimal.TryParse((string)it.BaseUoM, out bQty);

                    if (iQty + bQty == 0)
                    {
                        errCount++;
                        string message = "Số lượng không hợp lệ.";
                        errList.Add(new { Id = errCount, Line = (int)it.Index, Message = message });
                        ExcelUtil.NoteToWorkSheet(ws, (int)it.Index, firstColIndex, message, System.Drawing.Color.Red, System.Drawing.Color.White);
                        continue;
                    }

                    tbl_WMS_ReceiptDetail dbline = new tbl_WMS_ReceiptDetail();
                    if (it.Id == null || string.IsNullOrEmpty(it.Id.Value) || it.Id == "0")
                    {
                        dbline = new tbl_WMS_ReceiptDetail();
                        dbline.IDReceipt = dbReceipt.Id;
                        dbline.CreatedBy = Username;
                        dbline.CreatedDate = DateTime.Now;
                    }
                    else
                    {
                        dbline = db.tbl_WMS_ReceiptDetail.Find((int)it.Id);
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
                        
                        if (iUoM == null)
                        {
                            errCount++;
                            string message = "Không tìm được đơn vị lưu kho";
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
                        splitedUoMs.Add(new DTO_ConvertUnit() { ItemId = dbItem.Id, UoMId = iUoM.Id, Quantity = iQty });
                        splitedUoMs.Add(new DTO_ConvertUnit() { ItemId = dbItem.Id, UoMId = bUoM.Id, Quantity = bQty });
                        var mUoM = BS_WMS_ItemUoM.mergeUoM(dbItem, splitedUoMs, iUoM.Id);

                        BS_WMS_ReceiptDetail.patchDynamicToDB(it, dbline, Username);
                        dbline.IDItem = dbItem.Id;
                        dbline.IDUoM = mUoM.UoMId;
                        dbline.UoMQuantityExpected = mUoM.Quantity;
                        dbline.QuantityExpected = mUoM.BaseQuantity;
                        dbline.Cube = mUoM.Cube;
                        dbline.GrossWeight = mUoM.GrossWeight;
                        dbline.NetWeight = mUoM.NetWeight;

                        dbline.ModifiedBy = Username;
                        dbline.ModifiedDate = DateTime.Now;
                        if (dbline.Id == 0) db.tbl_WMS_ReceiptDetail.Add(dbline);
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
                    errorLog.logMessage("post_WMS_ReceiptDetail", e);
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

        public static dynamic unpalletize(AppEntities db, int IDBranch, int StaffID, dynamic item, string Username)
        {
            if (item == null || item.Id == 0 || item.Id == null)
                return null;
            var dbResult = db.tbl_WMS_Receipt.Find((int)item.Id);
            if (dbResult == null) return null;

            if (dbResult.Status != "Palletized")
                return null;
            dbResult.Status = "New";

            var Lines = dbResult.tbl_WMS_ReceiptDetail.Where(d => d.IsDeleted == false).ToList();
            foreach (var line in Lines)
            {
                var dbPallets = line.tbl_WMS_ReceiptPalletization.Where(d => d.IsDeleted == false).ToList();
                foreach (var dbItem in dbPallets)
                {
                    var lpn = dbItem.tbl_WMS_LicencePlateNumber.FirstOrDefault(d => d.IsDeleted==false);

                    BS_WMS_LotLPNLocation.addQuantityExpected(db, dbResult.IDBranch, dbItem.IDStorer, dbItem.ToLocation, dbItem.IDItem, dbItem.ToLot, lpn.Id, 0-dbItem.QuantityExpected, Username);
                    BS_WMS_ItemInLocation.addQuantityExpected(db, dbResult.IDBranch, dbResult.IDStorer, dbItem.ToLocation, dbItem.IDItem, 0-dbItem.QuantityExpected, Username);

                    dbItem.IsDeleted = true;
                    dbItem.ModifiedBy = Username;
                    dbItem.ModifiedDate = DateTime.Now;
                }
            }


            db.SaveChanges();

            return getAnItemCustom(db, IDBranch, StaffID, dbResult.Id);
        }

        public static dynamic palletize(AppEntities db, int IDBranch, int StaffID, dynamic item, string Username)
        {
            if (item == null || item.Id == 0 || item.Id == null)
                return null;

            var dbResult = db.tbl_WMS_Receipt.Find((int)item.Id);
            if (dbResult == null) return null;

            if (dbResult.Status != "New")
                return null;

            dbResult.Status = "Palletized";

            var Lines = dbResult.tbl_WMS_ReceiptDetail.Where(d => d.IsDeleted == false).ToList();
            foreach (var line in Lines)
            {

                //Check & create LOTxLPNxLOC
                //Check & create ItemInLocation

                tbl_WMS_Lot lot = BS_WMS_Lot.getOrCreate(db, IDBranch, StaffID, Username, line);

                DTO_ConvertUnit cline = new DTO_ConvertUnit()
                {
                    ItemId = line.IDItem,
                    UoMId = line.IDUoM,
                    Quantity = line.UoMQuantityExpected
                };

                var splitedUoMs = BS_WMS_ItemUoM.splitUoM(line.tbl_WMS_Item, cline, 0, "Pallet");

                var pallets = new List<DTO_ConvertUnit>();

                decimal numberOfPalletToFill = 0;
                if (splitedUoMs.Any(d => d.UoMName == "Pallet"))
                {
                    var p = splitedUoMs.FirstOrDefault(d => d.UoMName == "Pallet");
                    pallets.Add(p);
                    numberOfPalletToFill = p.Quantity;
                }
                var partUoMs = splitedUoMs.Where(d => d.UoMName != "Pallet").ToList();
                string partUoMsNote = "+";
                if (partUoMs.Count > 0)
                {
                    pallets.Add(BS_WMS_ItemUoM.mergeUoM(line.tbl_WMS_Item, partUoMs));
                    numberOfPalletToFill++;
                    foreach (var u in partUoMs)
                        partUoMsNote += string.Format(" + {0} {1}", u.Quantity, u.UoMName.ToLower());

                    partUoMsNote = partUoMsNote.Replace("+ + ", "");
                }
                var dbPallets = line.tbl_WMS_ReceiptPalletization.Where(d => d.IsDeleted == false).ToList();

                if (dbPallets.Count > numberOfPalletToFill)
                {
                    for (int i = (int)numberOfPalletToFill; i < dbPallets.Count; i++)
                    {
                        dbPallets[i].IsDeleted = true;
                    }
                    dbPallets = dbPallets.Where(d => d.IsDeleted == false).ToList();
                }


                int fillingIndex = 0;
                foreach (var p in pallets)
                {
                    decimal numberOfUoMPallets = 1;
                    bool isFullPallet = p.UoMName == "Pallet";

                    if (isFullPallet)
                        numberOfUoMPallets = p.Quantity;

                    for (int i = 0; i < numberOfUoMPallets; i++)
                    {
                        tbl_WMS_ReceiptPalletization dbItem = null;
                        if (fillingIndex < dbPallets.Count)
                        {
                            dbItem = dbPallets[fillingIndex];
                        }
                        else
                        {
                            dbItem = new tbl_WMS_ReceiptPalletization();
                            line.tbl_WMS_ReceiptPalletization.Add(dbItem);
                            dbItem.CreatedBy = Username;
                            dbItem.CreatedDate = DateTime.Now;

                        }

                        fillingIndex++;

                        dbItem.ModifiedBy = Username;
                        dbItem.ModifiedDate = DateTime.Now;

                        dbItem.IDStorer = dbResult.IDStorer;
                        dbItem.IDItem = line.IDItem;
                        dbItem.IDUoM = p.UoMId;


                        dbItem.Status = "New";

                        dbItem.ToLot = lot.Id;
                        dbItem.UoMQuantityExpected = p.Quantity / numberOfUoMPallets;
                        dbItem.QuantityExpected = p.BaseQuantity / numberOfUoMPallets;
                        dbItem.Cube = p.Cube / numberOfUoMPallets;
                        dbItem.GrossWeight = p.GrossWeight / numberOfUoMPallets;
                        dbItem.NetWeight = p.NetWeight / numberOfUoMPallets;
                        dbItem.IsFullPallet = isFullPallet;

                        if (dbItem.ToLocation == 0)
                        {
                            tbl_WMS_Location loc = BS_WMS_Location.getPutawayLocation(db, line.tbl_WMS_Receipt.IDBranch, line.tbl_WMS_Receipt.IDStorer, line.IDItem, StaffID, Username);
                            dbItem.ToLocation = loc.Id;
                        }
                        
                        tbl_WMS_LicencePlateNumber lpn = BS_WMS_LicencePlateNumber.getOrCreate(db, IDBranch, StaffID, Username, dbItem);

                        BS_WMS_LotLPNLocation.addQuantityExpected(db, dbResult.IDBranch, dbItem.IDStorer, dbItem.ToLocation, dbItem.IDItem, lot.Id, lpn.Id, dbItem.QuantityExpected, Username);
                        BS_WMS_ItemInLocation.addQuantityExpected(db, dbResult.IDBranch, dbResult.IDStorer, dbItem.ToLocation, dbItem.IDItem, dbItem.QuantityExpected, Username);
                        
                        dbItem.tbl_WMS_LicencePlateNumber.Add(lpn);

                        if (!isFullPallet)
                        {
                            dbItem.Remark = partUoMsNote;
                        }
                        else
                        {
                            dbItem.Remark = null;
                        }
                    }

                }
            }

            db.SaveChanges();

            return getAnItemCustom(db, IDBranch, StaffID, dbResult.Id);
        }

        public static dynamic receiveReceipt(AppEntities db, int IDBranch, int StaffID, DTO_ApproveOrders item, string Username)
        {
            var ids = item.Ids;
            var canReceiveStatus = new List<string>() { "Palletized", "Scheduled" };

            var items = db.tbl_WMS_Receipt.Where(d => ids.Contains(d.Id) && canReceiveStatus.Contains(d.Status)).ToList();
            foreach (var i in items)
            {

                //dynamic re = new Newtonsoft.Json.Linq.JObject();
                //re.Id = i.Id;

                palletize(db, IDBranch, StaffID, i, Username);
                i.Status = "Received";
                foreach (var receiptLine in i.tbl_WMS_ReceiptDetail.Where(d => d.IsDeleted == false).ToList())
                {
                    foreach (var palletLine in receiptLine.tbl_WMS_ReceiptPalletization.Where(d => d.IsDeleted == false).Select(s => s.Id).ToList())
                    {
                        receivePallet(db, IDBranch, StaffID, palletLine, Username);
                    }
                }
            }
            db.SaveChanges();
            return true;
        }

        public static dynamic receivePallet(AppEntities db, int IDBranch, int StaffID, int PalletLineId, string Username)
        {
            var line = db.tbl_WMS_ReceiptPalletization.Find(PalletLineId);
            var lpn = db.tbl_WMS_LicencePlateNumber.FirstOrDefault(d => d.IDReceipPalletization == line.Id && d.IsDeleted == false);
            line.QuantityReceived = line.QuantityExpected;
            int? toLPN = null;
            if (lpn != null) toLPN = lpn.Id;

            BS_WMS_Transaction.logReceivePalletTransaction(db, line, toLPN, Username);

            try
            {
                db.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }

        }
    }
}
