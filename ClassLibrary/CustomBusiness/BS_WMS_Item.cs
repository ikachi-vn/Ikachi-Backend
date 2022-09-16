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

    public static partial class BS_WMS_Item
    {
        public static dynamic getSearchCustom(AppEntities db, int IDBranch, int StaffID, Dictionary<string, string> QueryStrings)
        {
            var isAllUoM = false;
            if (QueryStrings.Any(d => d.Key == "AllUoM"))
                isAllUoM = true;

            if (QueryStrings.Any(d => d.Key == "IDBranch"))
                QueryStrings.Remove("IDBranch");

            var query = BS_WMS_Item._queryBuilder(db, IDBranch, StaffID, QueryStrings);

            if (QueryStrings.Any(d => d.Key == "Term") && !string.IsNullOrEmpty(QueryStrings.FirstOrDefault(d => d.Key == "Term").Value))
            {
                var keyword = QueryStrings.FirstOrDefault(d => d.Key == "Term").Value;
                int.TryParse(keyword, out int id);

                query = query.Where(d => d.Name.Contains(keyword) || d.Code.Contains(keyword) || d.Id == id);
            }

            query = BS_WMS_Item._sortBuilder(query, QueryStrings);
            query = BS_WMS_Item._pagingBuilder(query, QueryStrings);

            int IDSO = 0;
            int IDPO = 0;

            int IDPriceList = 0;
            int IDStdCostPriceList = 0;
            if (QueryStrings.Any(d => d.Key == "IDPriceList") && !string.IsNullOrEmpty(QueryStrings.FirstOrDefault(d => d.Key == "IDPriceList").Value))
                int.TryParse(QueryStrings.FirstOrDefault(d => d.Key == "IDPriceList").Value, out IDPriceList);
            if (QueryStrings.Any(d => d.Key == "IDStdCostPriceList") && !string.IsNullOrEmpty(QueryStrings.FirstOrDefault(d => d.Key == "IDStdCostPriceList").Value))
                int.TryParse(QueryStrings.FirstOrDefault(d => d.Key == "IDStdCostPriceList").Value, out IDStdCostPriceList);
            if (QueryStrings.Any(d => d.Key == "IDSO") && !string.IsNullOrEmpty(QueryStrings.FirstOrDefault(d => d.Key == "IDSO").Value))
                int.TryParse(QueryStrings.FirstOrDefault(d => d.Key == "IDSO").Value, out IDSO);
            if (QueryStrings.Any(d => d.Key == "IDPO") && !string.IsNullOrEmpty(QueryStrings.FirstOrDefault(d => d.Key == "IDPO").Value))
                int.TryParse(QueryStrings.FirstOrDefault(d => d.Key == "IDPO").Value, out IDPO);



            int buyPriceList = 0;
            int salePriceList = 0;

            if (IDPriceList == 0 && IDStdCostPriceList == 0)
            {

                if (IDPO > 0)
                    buyPriceList = BS_WMS_PriceList.getPriceListByPO(db, IDPO);
                if (IDSO > 0)
                    salePriceList = BS_WMS_PriceList.getPriceListBySO(db, IDSO);

                if (buyPriceList == 0)
                {
                    BS_WMS_PriceList.getPriceListByStaffID(db, StaffID, out buyPriceList, out salePriceList);
                }
            }

            var result = query.Select(s => new
            {
                s.Id,
                s.Code,
                s.Name,
                s.SalesUoM,
                s.PurchasingUoM,
                Tax = 0,
                UoMs = s.tbl_WMS_ItemUoM.Where(d => d.IsDeleted == false && (isAllUoM || d.tbl_WMS_PriceListDetail.Any(dp => dp.IsDeleted == false && (dp.IDPriceList == IDPriceList || dp.IDPriceList == IDStdCostPriceList || dp.IDPriceList == buyPriceList || dp.IDPriceList == salePriceList)))).Select(u =>
                new
                {
                    u.Id,
                    u.Name,
                    u.LengthUnit,
                    u.Length,
                    u.WidthUnit,
                    u.Width,
                    u.HeightUnit,
                    u.Height,
                    u.WeightUnit,
                    u.Weight,
                    MinQuantity = 1,
                    MaxQuantity = 999,

                    PriceList = u.tbl_WMS_PriceListDetail.Where(dp => dp.IsDeleted == false && (dp.IDPriceList == IDPriceList || dp.IDPriceList == IDStdCostPriceList || dp.IDPriceList == buyPriceList || dp.IDPriceList == salePriceList)).Select(p =>
                   new
                   {
                       IDPriceList = p.IDPriceList == buyPriceList ? 2 : 1,
                       Type = p.IDPriceList == IDPriceList ? "PriceListForCustomer" : (p.IDPriceList == buyPriceList ? "PriceListForVendor" : "StdCostPriceList"),
                       p.Id,
                       p.Price
                   })
                })
            }).ToList();

            return result;
        }

        public static dynamic getAnItemCustom(AppEntities db, int IDBranch, int StaffID, int id)
        {
            var dbResult = db.tbl_WMS_Item.Find(id);

            if (dbResult != null)
            {
                return new
                {
                    IDItemGroup = dbResult.IDItemGroup,
                    IDBranch = dbResult.IDBranch,
                    Id = dbResult.Id,
                    Code = dbResult.Code,
                    Name = dbResult.Name,
                    ForeignName = dbResult.ForeignName,
                    Remark = dbResult.Remark,
                    ForeignRemark = dbResult.ForeignRemark,
                    ItemType = dbResult.ItemType,
                    Industry = dbResult.Industry,
                    Division = dbResult.Division,
                    IsInventoryItem = dbResult.IsInventoryItem,
                    IsSalesItem = dbResult.IsSalesItem,
                    IsPurchaseItem = dbResult.IsPurchaseItem,
                    BaseUoM = dbResult.BaseUoM,
                    AccountantUoM = dbResult.AccountantUoM,
                    InventoryUoM = dbResult.InventoryUoM,
                    PurchasingUoM = dbResult.PurchasingUoM,
                    SalesUoM = dbResult.SalesUoM,
                    IDSalesTaxDefinition = dbResult.IDSalesTaxDefinition,
                    IDTaxDefinition = dbResult.IDTaxDefinition,
                    IDRevenueAccount = dbResult.IDRevenueAccount,
                    IDExemptRevenueAccount = dbResult.IDExemptRevenueAccount,
                    IDDefaultWarehouse = dbResult.IDDefaultWarehouse,
                    IDPreferredVendor = dbResult.IDPreferredVendor,
                    MfrCatalogNo = dbResult.MfrCatalogNo,
                    PrefQtyInPurchaseUnits = dbResult.PrefQtyInPurchaseUnits,
                    ProductionDateInDays = dbResult.ProductionDateInDays,
                    TaxRateForWholesaler = dbResult.TaxRateForWholesaler,
                    SalesTaxInPercent = dbResult.SalesTaxInPercent,
                    IsTrackSales = dbResult.IsTrackSales,
                    NoOfItemsPerSalesUnit = dbResult.NoOfItemsPerSalesUnit,
                    IDCartonGroup = dbResult.IDCartonGroup,
                    PutawayStrategy = dbResult.PutawayStrategy,
                    AllocationStrategy = dbResult.AllocationStrategy,
                    CostToReorderItem = dbResult.CostToReorderItem,
                    ReorderPoint = dbResult.ReorderPoint,
                    QuantityToReorder = dbResult.QuantityToReorder,
                    CostToCarryingPerUnit = dbResult.CostToCarryingPerUnit,
                    Lottable0 = dbResult.Lottable0,
                    Lottable1 = dbResult.Lottable1,
                    Lottable2 = dbResult.Lottable2,
                    Lottable3 = dbResult.Lottable3,
                    Lottable4 = dbResult.Lottable4,
                    Lottable5 = dbResult.Lottable5,
                    Lottable6 = dbResult.Lottable6,
                    Lottable7 = dbResult.Lottable7,
                    Lottable8 = dbResult.Lottable8,
                    Lottable9 = dbResult.Lottable9,
                    Sort = dbResult.Sort,
                    IsDisabled = dbResult.IsDisabled,
                    IsDeleted = dbResult.IsDeleted,
                    CreatedBy = dbResult.CreatedBy,
                    ModifiedBy = dbResult.ModifiedBy,
                    CreatedDate = dbResult.CreatedDate,
                    ModifiedDate = dbResult.ModifiedDate,
                    Expiry = dbResult.Expiry,
                    ExpiryUnit = dbResult.ExpiryUnit,
                    SerialNumberNext = dbResult.SerialNumberNext,
                    SerialNumberStart = dbResult.SerialNumberStart,
                    SerialNumberEnd = dbResult.SerialNumberEnd,
                    IsPhantomItem = dbResult.IsPhantomItem,
                    TreeType = dbResult.TreeType,
                    TI = dbResult.TI,
                    HI = dbResult.HI,

                    WMS_ItemInWarehouseConfig = dbResult.tbl_WMS_ItemInWarehouseConfig.Where(d => d.IsDeleted == false).Select(s => new
                    {
                        IDBranch = s.IDBranch,
                        IDStorer = s.IDStorer,
                        IDItem = s.IDItem,
                        PutawayZone = s.PutawayZone,
                        Rotation = s.Rotation,
                        RotateBy = s.RotateBy,
                        MaxPalletsPerZone = s.MaxPalletsPerZone,
                        StackLimit = s.StackLimit,
                        PutawayLocation = s.PutawayLocation,
                        InboundQCLocation = s.InboundQCLocation,
                        OutboundQCLocation = s.OutboundQCLocation,
                        ReturnLocation = s.ReturnLocation,
                        MinimumInventoryLevel = s.MinimumInventoryLevel,
                        MaximumInventoryLevel = s.MaximumInventoryLevel,
                        Id = s.Id,
                        IsDisabled = s.IsDisabled,
                        IsAllowConsolidation = s.IsAllowConsolidation,
                        PutawayStrategy = s.PutawayStrategy,
                        AllocationStrategy = s.AllocationStrategy,

                    }),

                    VendorIds = dbResult.tbl_PROD_ItemInVendor.Where(d => d.IsDeleted == false).Select(s => s.IDVendor)
                };
            }
            else
                return null;

        }

        public static dynamic putCustom(AppEntities db, int IDBranch, int StaffID, int Id, dynamic item, string Username, Dictionary<string, string> QueryStrings)
        {
            var saved = postCustom(db, IDBranch, StaffID, item, Username);
            return getAnItemCustom(db, IDBranch, StaffID, Id);
        }

        public static DTO_WMS_Item postCustom(AppEntities db, int IDBranch, int StaffID, dynamic item, string Username)
        {
            tbl_WMS_Item dbitem = new tbl_WMS_Item();
            if (item != null)
            {
                try
                {
                    if (item.Id != 0 && item.Id != null)
                    {
                        dbitem = db.tbl_WMS_Item.Find((int)item.Id);
                    }
                    else
                    {
                        db.tbl_WMS_Item.Add(dbitem);
                        dbitem.CreatedBy = Username;
                        dbitem.CreatedDate = DateTime.Now;
                        dbitem.TreeType = "BTNone";
                        dbitem.ExpiryUnit = "Year";
                        dbitem.IsPhantomItem = false;
                    }

                    patchDynamicToDB(item, dbitem, Username);

                    if (item.VendorIds != null)
                    {
                        List<int> Ids = new List<int>();
                        foreach (var v in item.VendorIds)
                            if (int.TryParse((string)v, out int vid))
                                Ids.Add(vid);

                        var deleteRows = dbitem.tbl_PROD_ItemInVendor.Where(d => d.IsDeleted == false && !Ids.Contains(d.IDVendor)).ToList();
                        foreach (var dbdelete in deleteRows)
                        {
                            dbdelete.IsDeleted = true;
                            dbdelete.ModifiedDate = DateTime.Now;
                            dbdelete.ModifiedBy = Username;
                        }

                        var addedRows = dbitem.tbl_PROD_ItemInVendor.Where(d => d.IsDeleted == false).Select(s => s.IDVendor).ToList();

                        foreach (var dbadd in Ids.Where(d => addedRows.Contains(d) == false))
                        {
                            dbitem.tbl_PROD_ItemInVendor.Add(new tbl_PROD_ItemInVendor()
                            {
                                CreatedBy = Username,
                                CreatedDate = DateTime.Now,
                                ModifiedBy = Username,
                                ModifiedDate = DateTime.Now,
                                IDVendor = dbadd

                            });
                        }

                    }

                    if (item.WMS_ItemInWarehouseConfig != null)
                    {
                        foreach (var l in item.WMS_ItemInWarehouseConfig)
                        {
                            dynamic line = l.Value;
                            if (line == null)
                                continue;

                            tbl_WMS_ItemInWarehouseConfig dbline = new tbl_WMS_ItemInWarehouseConfig();
                            if (line.Id != 0)
                            {
                                dbline = db.tbl_WMS_ItemInWarehouseConfig.Find((int)line.Id);
                            }
                            else
                            {
                                dbitem.tbl_WMS_ItemInWarehouseConfig.Add(dbline);
                                dbline.CreatedBy = Username;
                                dbline.CreatedDate = DateTime.Now;
                            }

                            BS_WMS_ItemInWarehouseConfig.patchDynamicToDB(line, dbline, Username);

                        }
                    }

                    db.SaveChanges();

                }
                catch (DbEntityValidationException e)
                {
                    errorLog.logMessage("post_WMS_Item", e);
                    return null;
                }
            }
            return toDTO(dbitem);
        }

        public static dynamic Post_ImportItemInVendor(ExcelPackage package, AppEntities db, int IDBranch, int StaffID, Dictionary<string, string> QueryStrings, string Username)
        {
            ExcelWorkbook workBook = package.Workbook;
            int errCount = 0;
            var errList = new List<Tuple<int, int, string>>().Select(t => new { Id = t.Item1, Line = t.Item2, Message = t.Item3 }).ToList();

            if (workBook != null)
            {
                var ws = workBook.Worksheets.FirstOrDefault();
                int SheetColumnsCount = ws.Dimension.End.Column;
                int SheetRowCount = ws.Dimension.End.Row;
                int firstRow = 2;
                int firstColIndex = 1;

                List<string> FindVendors = new List<string>();

                for (int c = 5; c <= SheetColumnsCount; c++)
                {
                    string vendorName = ws.Cells[1, c].Value == null ? "" : ws.Cells[1, c].Text;
                    FindVendors.Add(vendorName);
                }

                List<int> FindItems = new List<int>();
                for (int r = firstRow; r <= SheetRowCount; r++)
                {
                    string id = ws.Cells[r, 2].Value == null ? "" : ws.Cells[r, 2].Text;
                    if (int.TryParse(id, out int Id))
                        FindItems.Add(Id);
                }

                var vendors = db.tbl_CRM_Contact.Where(d => d.IsVendor && d.IsDeleted == false && FindVendors.Contains(d.Name)).ToList();
                var items = db.tbl_WMS_Item.Where(d => FindItems.Contains(d.Id)).Include(i => i.tbl_PROD_ItemInVendor).ToList();



                for (int r = firstRow; r <= SheetRowCount; r++)
                {
                    tbl_WMS_Item item = null;
                    for (int c = firstColIndex; c <= SheetColumnsCount; c++)
                    {
                        string property = ws.Cells[1, c].Value == null ? "" : ws.Cells[1, c].Text;
                        if (!string.IsNullOrEmpty(property))
                        {
                            var v = ws.Cells[r, c].Value == null ? "" : ws.Cells[r, c].Value.ToString();
                            try
                            {

                                if (property == "Id")
                                {
                                    if (int.TryParse(v, out int Id))
                                    {
                                        item = items.FirstOrDefault(d => d.Id == Id);
                                    }

                                    if (item == null)
                                    {
                                        string message = "Không tìm thấy item này";
                                        errCount++;
                                        errList.Add(new { Id = errCount, Line = r, Message = message });
                                        ExcelUtil.NoteToWorkSheet(ws, r, c, message, System.Drawing.Color.Red, System.Drawing.Color.White);
                                        break;
                                    }
                                }
                                else if (c >= 5)
                                {
                                    var vendor = vendors.FirstOrDefault(d => d.Name == property);
                                    if (vendor == null)
                                    {
                                        string message = "Không tìm thấy NCC này";
                                        errCount++;
                                        errList.Add(new { Id = errCount, Line = r, Message = message });
                                        ExcelUtil.NoteToWorkSheet(ws, r, c, message, System.Drawing.Color.Red, System.Drawing.Color.White);
                                        continue;
                                    }

                                    tbl_PROD_ItemInVendor iiv = item.tbl_PROD_ItemInVendor.FirstOrDefault(d => d.IDVendor == vendor.Id && d.IsDeleted == false);

                                    if (v == "1")
                                    {
                                        if (iiv == null)
                                        {
                                            iiv = new tbl_PROD_ItemInVendor();
                                            iiv.IDItem = item.Id;
                                            iiv.IDVendor = vendor.Id;

                                            iiv.CreatedBy = Username;
                                            iiv.CreatedDate = DateTime.Now;
                                            iiv.ModifiedBy = Username;
                                            iiv.ModifiedDate = DateTime.Now;

                                            db.tbl_PROD_ItemInVendor.Add(iiv);
                                        }
                                    }
                                    else if (v == "0")
                                    {
                                        if (iiv != null)
                                        {
                                            iiv.IsDeleted = true;
                                            iiv.ModifiedBy = Username;
                                            iiv.ModifiedDate = DateTime.Now;
                                        }
                                    }
                                }

                            }
                            catch (Exception ex)
                            {
                                errCount++;
                                errList.Add(new { Id = errCount, Line = r, Message = ex.Message });
                                ExcelUtil.NoteToWorkSheet(ws, r, c, ex.Message, System.Drawing.Color.Red, System.Drawing.Color.White);
                                continue;
                            }
                        }
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
                    errorLog.logMessage("Post_ImportItemInVendor", e);
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


    }
}
