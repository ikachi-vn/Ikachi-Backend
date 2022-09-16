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

    public static partial class BS_WMS_PriceList
    {
        public static void reCalcPrice(AppEntities db, DTO_WMS_PriceList item)
        {
            if (!item.IDBasePriceList.HasValue)
            {
                return;
            }
            string queryString = @"
                                INSERT INTO dbo.tbl_WMS_PriceListDetail(IDPriceList, IDItem, IDItemUoM, Price, Price1, Price2 )
                                SELECT {2}, IDItem, p1.IDItemUoM, {0}
                                FROM 
			                                (SELECT  IDPriceList, IDItem, IDItemUoM, Id, Price, Price1, Price2	FROM dbo.tbl_WMS_PriceListDetail  WHERE IDPriceList = {1} AND IsDeleted = 0) p1
                                LEFT JOIN	(SELECT Id, IDItemUoM												FROM dbo.tbl_WMS_PriceListDetail  WHERE IDPriceList = {2} AND IsDeleted = 0) p2 ON p2.IDItemUoM = p1.IDItemUoM
                                WHERE p2.Id IS NULL;


                                UPDATE p2 SET {3}
                                FROM (SELECT Id, IDItem, IDItemUoM, Price, Price1, Price2 FROM dbo.tbl_WMS_PriceListDetail  WHERE IDPriceList = {1}) p1
                                INNER JOIN dbo.tbl_WMS_PriceListDetail p2 ON p2.IDItemUoM = p1.IDItemUoM
                                WHERE  p2.IDPriceList = {2} AND p2.IsManual = 0 ";

            string round = "Price*{1}, Price1*{1}, Price2*{1}";
            string roundUpdate = "p2.Price = p1.Price*{1}, p2.Price1 = p1.Price1*{1}, p2.Price2 = p1.Price2*{1} ";
            if (item.RoundingMethod.HasValue && item.RoundingMethod.Value > -1)
            {
                round = "ROUND(Price*{1}, {0}), ROUND(Price1*{1}, {0}),ROUND(Price2*{1}, {0})";
                roundUpdate = "p2.Price = ROUND(p1.Price*{1}, {0}) , p2.Price1 = ROUND(p1.Price1*{1}, {0}), p2.Price2 = ROUND(p1.Price2*{1}, {0}) ";
            }

            round = string.Format(round, item.RoundingMethod, item.Factor);
            roundUpdate = string.Format(roundUpdate, item.RoundingMethod, item.Factor);

            queryString = string.Format(queryString, round, item.IDBasePriceList, item.Id, roundUpdate);

            var results = db.Database.ExecuteSqlCommand(queryString);


        }

        public static int getPriceListByPO(AppEntities db, int IDPO)
        {
            var po = db.tbl_PURCHASE_Order.Find(IDPO);
            var IDPriceList = po.tbl_CRM_Contact1.IDPriceListForVendor;
            if (IDPriceList == null || IDPriceList == 0)
            {
                var IDBranch = db.tbl_PURCHASE_Order.Where(d => d.Id == IDPO).Select(s => s.IDBranch).FirstOrDefault();
                IDPriceList = getVendorPriceListByBranchId(db, IDBranch);
            }
            
            return IDPriceList.GetValueOrDefault();
        }

        public static int getVendorPriceListByBranchId(AppEntities db, int BranchId)
        {
            int PriceListID = 0;
            List<int> BranchIds = new List<int>();

            List<DTO_BRA_Branch> allItems = db.tbl_BRA_Branch.Where(d => d.IsDeleted == false).Select(s => new DTO_BRA_Branch()
            {
                Id = s.Id,
                IDParent = s.IDParent
            }).ToList();
            BranchIds.Add(BranchId);
            BranchIds.AddRange(BS_BRA_Branch.findParent(allItems, BranchId));

            var configs = db.tbl_SYS_Config.Where(d => (d.Code == "BPDefaultPriceListForVendor") && BranchIds.Contains(d.IDBranch.Value) && d.IsDeleted == false).ToList();

            foreach (var bId in BranchIds)
            {
                var c = configs.FirstOrDefault(d => d.IDBranch == bId && d.Code == "BPDefaultPriceListForVendor");
                if (c != null)
                    if (int.TryParse(c.Value, out PriceListID))
                        break;
            }

            return PriceListID;
        }

        public static int getPriceListBySO(AppEntities db, int SOId)
        {
            var IDPriceList = db.tbl_CRM_Contact.Where(d => d.tbl_SALE_Order.Any(e => e.Id == SOId)).Select(s => s.IDPriceList).FirstOrDefault();
            if (IDPriceList == null || IDPriceList == 0)
            {
                var IDBranch = db.tbl_SALE_Order.Where(d => d.Id == SOId).Select(s => s.IDBranch).FirstOrDefault();
                IDPriceList = getCustomerPriceListByBranchId(db, IDBranch);
            }

            return IDPriceList.GetValueOrDefault();
        }

        public static int getCustomerPriceListByBranchId(AppEntities db, int BranchId)
        {
            int PriceListID = 0;
            List<int> BranchIds = new List<int>();

            List<DTO_BRA_Branch> allItems = db.tbl_BRA_Branch.Where(d => d.IsDeleted == false).Select(s => new DTO_BRA_Branch()
            {
                Id = s.Id,
                IDParent = s.IDParent
            }).ToList();
            BranchIds.Add(BranchId);
            BranchIds.AddRange(BS_BRA_Branch.findParent(allItems, BranchId));

            var configs = db.tbl_SYS_Config.Where(d => (d.Code == "BPDefaultPriceListForCustomer") && BranchIds.Contains(d.IDBranch.Value) && d.IsDeleted == false).ToList();

            foreach (var bId in BranchIds)
            {
                var c = configs.FirstOrDefault(d => d.IDBranch == bId && d.Code == "BPDefaultPriceListForCustomer");
                if (c != null)
                    if (int.TryParse(c.Value, out PriceListID))
                        break;
            }

            return PriceListID;
        }

        public static void getPriceListByStaffID(AppEntities db, int StaffID, out int buyPriceList, out int salePriceList)
        {
            buyPriceList = 0;
            salePriceList = 0;
            var staff = BS_HRM_Staff.getAnItem(db, 0, StaffID, StaffID);
            if (staff == null)
                return;

            getPriceListByBranchId(db, staff.IDJobTitle.GetValueOrDefault(), out buyPriceList, out salePriceList);
        }

        public static void getPriceListByBranchId(AppEntities db, int BranchId, out int buyPriceList, out int salePriceList)
        {
            buyPriceList = 0;
            salePriceList = 0;

            List<int> BranchIds = new List<int>();

            List<DTO_BRA_Branch> allItems = db.tbl_BRA_Branch.Where(d => d.IsDeleted == false).Select(s => new DTO_BRA_Branch()
            {
                Id = s.Id,
                IDParent = s.IDParent
            }).ToList();
            BranchIds.Add(BranchId);
            BranchIds.AddRange(BS_BRA_Branch.findParent(allItems, BranchId));

            var configs = db.tbl_SYS_Config.Where(d => (d.Code == "BPDefaultPriceListForCustomer" || d.Code == "BPDefaultPriceListForVendor") && BranchIds.Contains(d.IDBranch.Value) && d.IsDeleted == false).ToList();

            foreach (var bId in BranchIds)
            {
                var c = configs.FirstOrDefault(d => d.IDBranch == bId && d.Code == "BPDefaultPriceListForCustomer");
                if (c != null)
                    if (int.TryParse(c.Value, out salePriceList))
                        break;
            }
            foreach (var bId in BranchIds)
            {
                var c = configs.FirstOrDefault(d => d.IDBranch == bId && d.Code == "BPDefaultPriceListForVendor");
                if (c != null)
                    if (int.TryParse(c.Value, out buyPriceList))
                        break;
            }
        }

        public static dynamic getAnItemCustom(AppEntities db, int IDBranch, int StaffID, int id)
        {
            var dbResult = db.tbl_WMS_PriceList
                .Include(i => i.tbl_WMS_PriceListVersion)
                .Include(i => i.tbl_CRM_Contact)
                .FirstOrDefault(d => d.Id == id);

            if (dbResult != null)
            {
                return new
                {
                    IDBranch = dbResult.IDBranch,
                    Id = dbResult.Id,
                    Code = dbResult.Code,
                    Name = dbResult.Name,
                    Remark = dbResult.Remark,
                    Sort = dbResult.Sort,
                    IsDisabled = dbResult.IsDisabled,
                    IsDeleted = dbResult.IsDeleted,
                    CreatedBy = dbResult.CreatedBy,
                    ModifiedBy = dbResult.ModifiedBy,
                    CreatedDate = dbResult.CreatedDate,
                    ModifiedDate = dbResult.ModifiedDate,
                    IDBasePriceList = dbResult.IDBasePriceList,
                    Factor = dbResult.Factor,
                    RoundingMethod = dbResult.RoundingMethod,
                    ValidFrom = dbResult.ValidFrom,
                    ValidTo = dbResult.ValidTo,
                    PrimaryDefaultCurrency = dbResult.PrimaryDefaultCurrency,
                    PrimaryDefaultCurrency1 = dbResult.PrimaryDefaultCurrency1,
                    PrimaryDefaultCurrency2 = dbResult.PrimaryDefaultCurrency2,
                    IsPriceListForVendor = dbResult.IsPriceListForVendor,

                    Versions = dbResult.tbl_WMS_PriceListVersion.Where(d => d.IsDeleted == false).Select(s => new
                    {
                        s.IDPriceList,
                        s.Id,
                        s.Name,
                        s.IsDisabled,
                        s.ValidFrom,
                        s.ValidTo,
                        s.AppliedDate
                    }).OrderBy(o=>o.Id),
                    Contacts = dbResult.tbl_CRM_Contact.Where(d => d.IsDeleted == false).Select(s => new
                    {
                        s.Id,
                        s.Code,
                        s.Name,
                        s.CompanyName,
                        s.IsVendor,
                        s.IsOutlets,
                        s.IsCustomer
                    })
                };
            }
            else
                return null;

        }

        public static dynamic postCustom(AppEntities db, int IDBranch, int StaffID, dynamic item, string Username)
        {
            tbl_WMS_PriceList dbitem = new tbl_WMS_PriceList();
            if (item != null)
            {
                try
                {
                    if (item.Id != 0 && item.Id != null)
                    {
                        dbitem = db.tbl_WMS_PriceList.Find((int)item.Id);
                    }
                    else
                    {
                        db.tbl_WMS_PriceList.Add(dbitem);
                        dbitem.CreatedBy = Username;
                        dbitem.CreatedDate = DateTime.Now;
                    }

                    patchDynamicToDB(item, dbitem, Username);

                    if (item.Versions != null)
                    {
                        foreach (var l in item.Versions)
                        {
                            dynamic line = l.Value;
                            if (line == null)
                                continue;

                            tbl_WMS_PriceListVersion dbline = new tbl_WMS_PriceListVersion();
                            if (line.Id != 0)
                            {
                                dbline = db.tbl_WMS_PriceListVersion.Find((int)line.Id);

                            }
                            else
                            {
                                dbitem.tbl_WMS_PriceListVersion.Add(dbline);
                                dbline.CreatedBy = Username;
                                dbline.CreatedDate = DateTime.Now;
                            }

                            BS_WMS_PriceListVersion.patchDynamicToDB(line, dbline, Username);

                            dbline.IDPriceList = dbitem.Id;
                            dbline.PrimaryDefaultCurrency = dbitem.PrimaryDefaultCurrency;
                            dbline.PrimaryDefaultCurrency1 = dbitem.PrimaryDefaultCurrency1;
                            dbline.PrimaryDefaultCurrency2 = dbitem.PrimaryDefaultCurrency2;
                        }
                    }

                    db.SaveChanges();
                }
                catch (DbEntityValidationException e)
                {
                    errorLog.logMessage("post_WMS_PriceList", e);
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

        public static dynamic PostImportPriceList(ExcelPackage package, int IDPriceListVersion, AppEntities db, int IDBranch, int StaffID, Dictionary<string, string> QueryStrings, string Username)
        {
            ExcelWorkbook workBook = package.Workbook;
            int errCount = 0;
            var errList = new List<Tuple<int, int, string>>().Select(t => new { Id = t.Item1, Line = t.Item2, Message = t.Item3 }).ToList();

            var dbPriceListVersion = db.tbl_WMS_PriceListVersion.Find(IDPriceListVersion);
            var dbPriceListVersionDetail = dbPriceListVersion.tbl_WMS_PriceListVersionDetail.Where(d => d.IsDeleted == false).ToList();
            foreach (var old in dbPriceListVersionDetail)
            {
                old.IsDeleted = true;
                old.ModifiedBy = Username;
                old.ModifiedDate = DateTime.Now;
            }

            if (workBook != null)
            {
                //Lặp lấy dataRow => dynamic
                //Lấy danh sách item theo code + đơn vị
                //Lặp dataRow - validate + add db

                
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
                        var target = new tbl_WMS_PriceListVersionDetail();
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
                                BS_WMS_PriceListVersionDetail.patchDynamicToDB(convert, target, Username);
                                
                                if (property == "ItemCode" && string.IsNullOrEmpty(v))
                                {
                                    errCount++;
                                    string message = "Không có mã sản phẩm";
                                    errList.Add(new { Id = errCount, Line = r, Message = message });
                                    ExcelUtil.NoteToWorkSheet(ws, r, c, message, System.Drawing.Color.Red, System.Drawing.Color.White);
                                    isBreak = true;
                                    continue;
                                }

                                if ((property == "PurchaseUoM" || property == "BaseUoM") && !string.IsNullOrEmpty(v) && !decimal.TryParse(v, out decimal pqty))
                                {
                                    errCount++;
                                    string message = "Đơn giá không hợp lệ";
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

                var itemCodes = imRows.Select(s => (string)s.ItemCode).Distinct().ToList();
                var items = db.tbl_WMS_Item.Where(d => itemCodes.Contains(d.Code) && d.IsDeleted == false).ToList();
                

                foreach (var it in imRows)
                {
                    bool isContinue = false;
                    var dbItem = items.FirstOrDefault(d => d.Code == (string)it.ItemCode);
                    if (dbItem == null)
                    {
                        errCount++;
                        string message = "Không tìm được sản phẩm";
                        errList.Add(new { Id = errCount, Line = (int)it.Index, Message = message });
                        ExcelUtil.NoteToWorkSheet(ws, (int)it.Index, firstColIndex, message, System.Drawing.Color.Red, System.Drawing.Color.White);
                        continue;
                    }

                    var UoM = dbItem.tbl_WMS_ItemUoM.FirstOrDefault(d => d.Name==(string)it.UoM && d.IsDeleted==false);
                    if (UoM == null)
                    {
                        errCount++;
                        string message = "Không tìm được đơn vị";
                        errList.Add(new { Id = errCount, Line = (int)it.Index, Message = message });
                        ExcelUtil.NoteToWorkSheet(ws, (int)it.Index, firstColIndex, message, System.Drawing.Color.Red, System.Drawing.Color.White);
                        isContinue = true;
                    }

                    decimal price = 0;
                    if (decimal.TryParse((string)it.Price, out price) == false || price < 0)
                    {
                        errCount++;
                        string message = "Đơn giá không hợp lệ";
                        errList.Add(new { Id = errCount, Line = (int)it.Index, Message = message });
                        ExcelUtil.NoteToWorkSheet(ws, (int)it.Index, firstColIndex, message, System.Drawing.Color.Red, System.Drawing.Color.White);
                        isContinue = true;
                    }

                    if (isContinue)
                    {
                        continue;
                    }

                    tbl_WMS_PriceListVersionDetail dbline = new tbl_WMS_PriceListVersionDetail();
                    if (it.Id == null || string.IsNullOrEmpty(it.Id.Value) || it.Id == "0")
                    {
                        dbline = new tbl_WMS_PriceListVersionDetail();
                        dbline.IDPriceListVersion = dbPriceListVersion.Id;
                        dbline.CreatedBy = Username;
                        dbline.CreatedDate = DateTime.Now;

                    }
                    else
                    {
                        dbline = db.tbl_WMS_PriceListVersionDetail.Find((int)it.Id);
                        dbline.IsDeleted = false;
                        dbline.IDPriceListVersion = dbPriceListVersion.Id;
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
                        dbline.IDItemUoM = UoM.Id;
                        dbline.Price = price;

                        dbline.ModifiedBy = Username;
                        dbline.ModifiedDate = DateTime.Now;
                        if (dbline.Id == 0) db.tbl_WMS_PriceListVersionDetail.Add(dbline);
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
                    errorLog.logMessage("post_WMS_PriceListVersionDetail", e);
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

        public static dynamic PostApplyPriceListVersion(AppEntities db, int IDPriceListVersion, int IDBranch, int StaffID, string Username)
        {
            var pVersion = db.tbl_WMS_PriceListVersion
                .Include(i => i.tbl_WMS_PriceListVersionDetail)
                .Where(d => d.Id == IDPriceListVersion).FirstOrDefault();

            if (pVersion == null)
            {
                return false;
            }

            var pVersionDetail = pVersion.tbl_WMS_PriceListVersionDetail.Where(d => d.IsDeleted == false).Select(s => new
            {
                s.IDItem,
                s.IDItemUoM,
                s.Price
            }).ToList();

            var itemUoMs = pVersionDetail.Select(s => s.IDItemUoM).ToList();

            var pDetail = db.tbl_WMS_PriceListDetail.Where(d => d.IDPriceList == pVersion.IDPriceList && itemUoMs.Contains(d.IDItemUoM) && d.IsDeleted==false).ToList();
            foreach (var vd in pVersionDetail)
            {
                var pd = pDetail.FirstOrDefault(d => d.IDItemUoM == vd.IDItemUoM);
                if (pd==null)
                {
                    pd = new tbl_WMS_PriceListDetail();
                    pd.IDPriceList = pVersion.IDPriceList;
                    pd.IDItem = vd.IDItem;
                    pd.IDItemUoM = vd.IDItemUoM;
                    
                    pd.CreatedBy = Username;
                    pd.CreatedDate = DateTime.Now;
                    db.tbl_WMS_PriceListDetail.Add(pd);

                }

                pd.IsManual = true;
                pd.Price = vd.Price;
                pd.ModifiedBy = Username;
                pd.ModifiedDate = DateTime.Now;

            }

            pVersion.AppliedDate = DateTime.Now;
            pVersion.ModifiedBy = Username;
            pVersion.ModifiedDate = DateTime.Now;

            try
            {
                db.SaveChanges();
                return getAnItemCustom(db, IDBranch, StaffID, pVersion.IDPriceList);
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
            
        }

        public static dynamic calcPriceListCompareReport(AppEntities db, Dictionary<string, string> QueryStrings)
        {
            string priceListQuery = "0";
            string itemQuery = "";

            
            if (QueryStrings.Any(d => d.Key == "IDPriceList"))
            {
                var IDList = QueryStrings.FirstOrDefault(d => d.Key == "IDPriceList").Value.Replace("[", "").Replace("]", "").Split(',');
                List<int?> IDs = new List<int?>();
                foreach (var item in IDList)
                    if (int.TryParse(item, out int i))
                        IDs.Add(i);
                    else if (item == "null")
                        IDs.Add(null);
                if (IDs.Count > 0)
                    priceListQuery = string.Join(",", IDs.ToArray());
            }

            if (QueryStrings.Any(d => d.Key == "Keyword") && !string.IsNullOrEmpty(QueryStrings.FirstOrDefault(d => d.Key == "Keyword").Value))
            {
                var keyword = QueryStrings.FirstOrDefault(d => d.Key == "Keyword").Value;
                itemQuery = string.Format( " AND(i.Code LIKE N'%{0}%' OR i.Name LIKE N'%{0}%') ", keyword);
            }


            string queryString = @"

CREATE TABLE #temp (PriceListId INT,
PriceListName NVARCHAR(512),
PriceListSort INT,
ItemId INT,
ItemCode NVARCHAR(256),
ItemName NVARCHAR(512),
UoM NVARCHAR(512),
Price DECIMAL(27, 9));
INSERT INTO #temp(PriceListId, PriceListName, PriceListSort, ItemId, ItemCode, ItemName, UoM, Price)
SELECT p.Id PriceListId, p.Name PriceListName, ISNULL(p.Sort, 999999999), pd.IDItem ItemId, i.Code ItemCode, i.Name ItemName, u.Name UoM, pd.Price
FROM dbo.tbl_WMS_PriceList p
     INNER JOIN dbo.tbl_WMS_PriceListDetail pd ON pd.IDPriceList=p.Id
     INNER JOIN dbo.tbl_WMS_Item i ON pd.IDItem=i.Id
     INNER JOIN dbo.tbl_WMS_ItemUoM u ON u.IDItem=i.Id AND u.Id=pd.IDItemUoM
WHERE 
p.Id IN ({0}) {1} 

AND p.IsDeleted=0 AND pd.IsDeleted=0 AND i.IsDeleted=0 AND u.IsDeleted=0;
DECLARE @cols AS NVARCHAR(MAX), @query AS NVARCHAR(MAX);
SET @cols=STUFF((SELECT ','+QUOTENAME(PriceListName)
                 FROM(SELECT DISTINCT PriceListName, PriceListSort
                      FROM #temp
                      ORDER BY PriceListSort OFFSET 0 ROWS) t
                FOR XML PATH(''), TYPE).value('.', 'NVARCHAR(MAX)'), 1, 1, '');
SET @query=N'SELECT ItemId, ItemCode, ItemName, UoM, '+@cols+N' from 
            ( select PriceListName, ItemId, ItemCode, ItemName, UoM, Price from #temp ) x
            pivot ( max(Price) for PriceListName in ('+@cols+N') ) p ORDER BY ItemCode';
EXECUTE(@query);
DROP TABLE #temp;

";

            queryString = string.Format(queryString, priceListQuery, itemQuery);

            var dt = new DataTable();
            var conn = db.Database.Connection;
            var connectionState = conn.State;
            try
            {
                if (connectionState != ConnectionState.Open) conn.Open();
                using (var cmd = conn.CreateCommand())
                {
                    cmd.CommandText = queryString;
                    cmd.CommandType = CommandType.Text;
                    using (var reader = cmd.ExecuteReader())
                    {
                        dt.Load(reader);
                    }
                }
            }
            catch (Exception ex)
            {
                // error handling
                throw;
            }
            finally
            {
                if (connectionState != ConnectionState.Closed) conn.Close();
            }
            return dt;

            
        }

        public static dynamic calcPriceListVersionCompareReport(AppEntities db, Dictionary<string, string> QueryStrings)
        {
            string priceListQuery = "0";
            string priveVersionQuery = "0";
            string itemQuery = "";
            

            if (QueryStrings.Any(d => d.Key == "IDPriceList"))
            {
                var IDList = QueryStrings.FirstOrDefault(d => d.Key == "IDPriceList").Value.Replace("[", "").Replace("]", "").Split(',');
                List<int?> IDs = new List<int?>();
                foreach (var item in IDList)
                    if (int.TryParse(item, out int i))
                        IDs.Add(i);
                    else if (item == "null")
                        IDs.Add(null);
                if (IDs.Count > 0)
                    priceListQuery = string.Join(",", IDs.ToArray());
            }

            if (QueryStrings.Any(d => d.Key == "IDPriceListVersion"))
            {
                var IDList = QueryStrings.FirstOrDefault(d => d.Key == "IDPriceListVersion").Value.Replace("[", "").Replace("]", "").Split(',');
                List<int?> IDs = new List<int?>();
                foreach (var item in IDList)
                    if (int.TryParse(item, out int i))
                        IDs.Add(i);
                    else if (item == "null")
                        IDs.Add(null);
                if (IDs.Count > 0)
                    priveVersionQuery = string.Join(",", IDs.ToArray());
            }

            if (QueryStrings.Any(d => d.Key == "Keyword") && !string.IsNullOrEmpty(QueryStrings.FirstOrDefault(d => d.Key == "Keyword").Value))
            {
                var keyword = QueryStrings.FirstOrDefault(d => d.Key == "Keyword").Value;
                itemQuery = string.Format(" AND(i.Code LIKE N'%{0}%' OR i.Name LIKE N'%{0}%') ", keyword);
            }


            string queryString = @"
CREATE TABLE #temp (PriceListId INT,
VersionName NVARCHAR(512),
PriceListSort INT,
ItemId INT,
ItemCode NVARCHAR(256),
ItemName NVARCHAR(512),
UoM NVARCHAR(512),
Price DECIMAL(27, 9));
INSERT INTO #temp(PriceListId, VersionName, PriceListSort, ItemId, ItemCode, ItemName, UoM, Price)

SELECT p.Id PriceListId, p.Name VersionName, p.Id, pd.IDItem ItemId, i.Code ItemCode, i.Name ItemName, u.Name UoM, pd.Price
FROM dbo.tbl_WMS_PriceList p
     INNER JOIN dbo.tbl_WMS_PriceListDetail pd ON pd.IDPriceList=p.Id
     INNER JOIN dbo.tbl_WMS_Item i ON pd.IDItem=i.Id
     INNER JOIN dbo.tbl_WMS_ItemUoM u ON u.IDItem=i.Id AND u.Id=pd.IDItemUoM
WHERE p.Id in ({0}) {2}
AND p.IsDeleted=0 AND pd.IsDeleted=0 AND i.IsDeleted=0 AND u.IsDeleted=0
UNION ALL
SELECT p.Id PriceListId, pl.Name + ' - '+p.Name VersionName, pl.id, pd.IDItem ItemId, i.Code ItemCode, i.Name ItemName, u.Name UoM, pd.Price
FROM dbo.tbl_WMS_PriceList pl
	 INNER JOIN dbo.tbl_WMS_PriceListVersion p ON p.IDPriceList = pl.Id
     INNER JOIN dbo.tbl_WMS_PriceListVersionDetail pd ON pd.IDPriceListVersion=p.Id
     INNER JOIN dbo.tbl_WMS_Item i ON pd.IDItem=i.Id
     INNER JOIN dbo.tbl_WMS_ItemUoM u ON u.IDItem=i.Id AND u.Id=pd.IDItemUoM
WHERE p.IDPriceList in ({0}) AND p.Id in ({1}) {2}
AND p.IsDeleted=0 AND pd.IsDeleted=0 AND i.IsDeleted=0 AND u.IsDeleted=0

DECLARE @cols AS NVARCHAR(MAX), @query AS NVARCHAR(MAX);
SET @cols=STUFF((SELECT ','+QUOTENAME(VersionName)
                 FROM(SELECT DISTINCT VersionName, PriceListSort
                      FROM #temp
                      ORDER BY PriceListSort OFFSET 0 ROWS) t
                FOR XML PATH(''), TYPE).value('.', 'NVARCHAR(MAX)'), 1, 1, '');
SET @query=N'SELECT ItemId, ItemCode, ItemName, UoM, '+@cols+N' from 
            ( select VersionName, ItemId, ItemCode, ItemName, UoM, Price from #temp ) x
            pivot ( max(Price) for VersionName in ('+@cols+N') ) p ORDER BY ItemCode';
EXECUTE(@query);
DROP TABLE #temp;

";

            queryString = string.Format(queryString, priceListQuery, priveVersionQuery, itemQuery);

            var dt = new DataTable();
            var conn = db.Database.Connection;
            var connectionState = conn.State;
            try
            {
                if (connectionState != ConnectionState.Open) conn.Open();
                using (var cmd = conn.CreateCommand())
                {
                    cmd.CommandText = queryString;
                    cmd.CommandType = CommandType.Text;
                    using (var reader = cmd.ExecuteReader())
                    {
                        dt.Load(reader);
                    }
                }
            }
            catch (Exception ex)
            {
                // error handling
                throw;
            }
            finally
            {
                if (connectionState != ConnectionState.Closed) conn.Close();
            }
            return dt;


        }
    }
}