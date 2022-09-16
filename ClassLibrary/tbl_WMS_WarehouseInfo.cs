//------------------------------------------------------------------------------
// 
//    www.codeart.vn
//    hungvq@live.com
//    (+84)908.061.119
// 
//------------------------------------------------------------------------------

namespace ClassLibrary
{
    
    using System;
    using System.Collections.Generic;
    
    
    public partial class tbl_WMS_WarehouseInfo
    {
        public int IDBranch { get; set; }
        public int Id { get; set; }
        public string Code { get; set; }
        public string Name { get; set; }
        public string Remark { get; set; }
        public Nullable<int> Sort { get; set; }
        public bool IsDisabled { get; set; }
        public bool IsDeleted { get; set; }
        public string CreatedBy { get; set; }
        public string ModifiedBy { get; set; }
        public System.DateTime CreatedDate { get; set; }
        public System.DateTime ModifiedDate { get; set; }
        public bool IsLocked { get; set; }
        public Nullable<int> InventoryAccount { get; set; }
        public Nullable<int> CostOfGoodsSoldAccount { get; set; }
        public Nullable<int> AllocationAccount { get; set; }
        public Nullable<int> RevenueAccount { get; set; }
        public Nullable<int> VarianceAccount { get; set; }
        public Nullable<int> InventoryOffsetDecreaseAccount { get; set; }
        public Nullable<int> InventoryOffsetIncreaseAccount { get; set; }
        public Nullable<int> SalesReturnsAccount { get; set; }
        public Nullable<int> ExpenseAccount { get; set; }
        public Nullable<int> RevenueAccountForeign { get; set; }
        public Nullable<int> ExpenseAccountForeign { get; set; }
        public Nullable<int> TaxGroup { get; set; }
        public Nullable<bool> IsDropShip { get; set; }
        public Nullable<int> ExemptRevenueAccount { get; set; }
        public Nullable<bool> IsAllowUseTax { get; set; }
        public Nullable<int> PriceDifferenceAccount { get; set; }
        public Nullable<int> ExchangeRateDifferencesAccount { get; set; }
        public Nullable<int> GoodsClearingAccount { get; set; }
        public Nullable<int> PurchaseAccount { get; set; }
        public Nullable<int> PurchaseReturnAccount { get; set; }
        public Nullable<int> PurchaseOffsetAccount { get; set; }
        public Nullable<int> ShippedGoodsAccount { get; set; }
        public Nullable<int> VATinRevenueAccount { get; set; }
        public Nullable<int> GLDecreaseAccount { get; set; }
        public Nullable<int> GLIncreaseAccount { get; set; }
        public Nullable<bool> IsNettable { get; set; }
        public Nullable<int> InventoryRevaluationAccount { get; set; }
        public Nullable<int> InventoryRevaluationOffsetAccount { get; set; }
        public Nullable<int> COGSRevaluationAccount { get; set; }
        public Nullable<int> COGSRevaluationOffsetAccount { get; set; }
        public Nullable<int> ExpenseClearingAccount { get; set; }
        public Nullable<int> ExpenseOffsetAccount { get; set; }
        public Nullable<int> SalesCreditAccount { get; set; }
        public Nullable<int> SalesCreditAccountForeign { get; set; }
        public Nullable<int> TaxExemptCreditAccount { get; set; }
        public Nullable<int> PurchaseCreditAccount { get; set; }
        public Nullable<int> PurchaseCreditAccountForeign { get; set; }
        public Nullable<int> RevenueReturnsAccount { get; set; }
        public Nullable<int> NegativeInventoryAdjustmentAccount { get; set; }
        public Nullable<int> StockInTransitAccount { get; set; }
        public Nullable<int> PurchaseBalanceAccount { get; set; }
        public Nullable<int> InventoryOffsetPLAccount { get; set; }
        public Nullable<int> Storekeeper { get; set; }
        public Nullable<bool> IsBinActivated { get; set; }
        public string BinSeparator { get; set; }
        public Nullable<int> DefaultBinInternalNumber { get; set; }
        public string GlobalLocationNumber { get; set; }
        public Nullable<int> FreeOfChargeSalesAccount { get; set; }
        public Nullable<int> FreeOfChargePurchaseAccount { get; set; }
        //List 0:1
        public virtual tbl_BRA_Branch tbl_BRA_Branch { get; set; }
    }
}


namespace DTOModel
{
	using System;
	public partial class DTO_WMS_WarehouseInfo
	{
		public int IDBranch { get; set; }
		public int Id { get; set; }
		public string Code { get; set; }
		public string Name { get; set; }
		public string Remark { get; set; }
		public Nullable<int> Sort { get; set; }
		public bool IsDisabled { get; set; }
		public bool IsDeleted { get; set; }
		public string CreatedBy { get; set; }
		public string ModifiedBy { get; set; }
		public System.DateTime CreatedDate { get; set; }
		public System.DateTime ModifiedDate { get; set; }
		public bool IsLocked { get; set; }
		public Nullable<int> InventoryAccount { get; set; }
		public Nullable<int> CostOfGoodsSoldAccount { get; set; }
		public Nullable<int> AllocationAccount { get; set; }
		public Nullable<int> RevenueAccount { get; set; }
		public Nullable<int> VarianceAccount { get; set; }
		public Nullable<int> InventoryOffsetDecreaseAccount { get; set; }
		public Nullable<int> InventoryOffsetIncreaseAccount { get; set; }
		public Nullable<int> SalesReturnsAccount { get; set; }
		public Nullable<int> ExpenseAccount { get; set; }
		public Nullable<int> RevenueAccountForeign { get; set; }
		public Nullable<int> ExpenseAccountForeign { get; set; }
		public Nullable<int> TaxGroup { get; set; }
		public Nullable<bool> IsDropShip { get; set; }
		public Nullable<int> ExemptRevenueAccount { get; set; }
		public Nullable<bool> IsAllowUseTax { get; set; }
		public Nullable<int> PriceDifferenceAccount { get; set; }
		public Nullable<int> ExchangeRateDifferencesAccount { get; set; }
		public Nullable<int> GoodsClearingAccount { get; set; }
		public Nullable<int> PurchaseAccount { get; set; }
		public Nullable<int> PurchaseReturnAccount { get; set; }
		public Nullable<int> PurchaseOffsetAccount { get; set; }
		public Nullable<int> ShippedGoodsAccount { get; set; }
		public Nullable<int> VATinRevenueAccount { get; set; }
		public Nullable<int> GLDecreaseAccount { get; set; }
		public Nullable<int> GLIncreaseAccount { get; set; }
		public Nullable<bool> IsNettable { get; set; }
		public Nullable<int> InventoryRevaluationAccount { get; set; }
		public Nullable<int> InventoryRevaluationOffsetAccount { get; set; }
		public Nullable<int> COGSRevaluationAccount { get; set; }
		public Nullable<int> COGSRevaluationOffsetAccount { get; set; }
		public Nullable<int> ExpenseClearingAccount { get; set; }
		public Nullable<int> ExpenseOffsetAccount { get; set; }
		public Nullable<int> SalesCreditAccount { get; set; }
		public Nullable<int> SalesCreditAccountForeign { get; set; }
		public Nullable<int> TaxExemptCreditAccount { get; set; }
		public Nullable<int> PurchaseCreditAccount { get; set; }
		public Nullable<int> PurchaseCreditAccountForeign { get; set; }
		public Nullable<int> RevenueReturnsAccount { get; set; }
		public Nullable<int> NegativeInventoryAdjustmentAccount { get; set; }
		public Nullable<int> StockInTransitAccount { get; set; }
		public Nullable<int> PurchaseBalanceAccount { get; set; }
		public Nullable<int> InventoryOffsetPLAccount { get; set; }
		public Nullable<int> Storekeeper { get; set; }
		public Nullable<bool> IsBinActivated { get; set; }
		public string BinSeparator { get; set; }
		public Nullable<int> DefaultBinInternalNumber { get; set; }
		public string GlobalLocationNumber { get; set; }
		public Nullable<int> FreeOfChargeSalesAccount { get; set; }
		public Nullable<int> FreeOfChargePurchaseAccount { get; set; }
	}
}


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

    public static partial class BS_WMS_WarehouseInfo 
    {
        public static dynamic getSearch(AppEntities db, int IDBranch, int StaffID, Dictionary<string, string> QueryStrings)
        {
            return get(db, IDBranch,StaffID, QueryStrings);
        }

		public static IQueryable<DTO_WMS_WarehouseInfo> get(AppEntities db, int IDBranch, int StaffID, Dictionary<string, string> QueryStrings)
        {
			var query = _queryBuilder(db, IDBranch, StaffID, QueryStrings);
            query = _sortBuilder(query, QueryStrings);
            query = _pagingBuilder(query, QueryStrings);

			return toDTO(query);
        }

        public static List<ItemModel> getValidateData(AppEntities db, int IDBranch, int StaffID, Dictionary<string, string> QueryStrings)
        {
            return get(db, IDBranch, StaffID, QueryStrings).Select(s => new ItemModel { 
                Id = s.Id,  Code = s.Code,  Name = s.Name, 
            }).ToList();
        }

        public static string export(ExcelPackage package, AppEntities db, int IDBranch, int StaffID, Dictionary<string, string> QueryStrings)
        {
            package.Workbook.Properties.Title = "ART-DMS WMS_WarehouseInfo";
            package.Workbook.Properties.Author = "hung.vu@codeart.vn";
            package.Workbook.Properties.Application = "ART-DMS";
            package.Workbook.Properties.Company = "A.R.T Distribution";

            ExcelWorkbook workBook = package.Workbook;
            if (workBook != null)
            {
                var ws = workBook.Worksheets.FirstOrDefault();
                var data = _queryBuilder(db, IDBranch, StaffID, QueryStrings).ToList();

                //var BRA_BranchList = BS_BRA_Branch.get(db,IDBranch, StaffID,QueryStrings).Select(s => new ItemModel { Id = s.Id, Name = s.Name });
                 

                int SheetColumnsCount, SheetRowCount = 0;
                SheetColumnsCount = ws.Dimension.End.Column;    // Find End Column
                SheetRowCount = ws.Dimension.End.Row;           // Find End Row

                int rowid = 5;
                int firstColInex = 0;

                #region readPropertyList
                var propList = new List<Tuple<string, string, string, List<ItemModel>>>()
                    .Select(t => new { ClassName = t.Item1, PropertyName = t.Item2, ReffProperty = t.Item3, ValidateData = t.Item4 }).ToList();

                for (int i = 1; i <= SheetColumnsCount; i++)
                {
                    string p = ws.Cells[1, i].Value == null ? "" : ws.Cells[1, i].Text;
                    string modalPart = p.Split('|')[0];
                    string queryPart = "";
                    string className = "";
                    string reffProperty = "Id";

                    if (p.Contains("|")) //Sample property BRA_Branch?Select=Code&IDType=115|IDBranch
                        if (modalPart.Contains("?"))
                        {
                            className = modalPart.Split('?')[0];
                            queryPart = modalPart.Split('?')[1];
                            if (queryPart.Contains("&"))
                            {
                                string[] query = queryPart.Split('&');
                                foreach (var q in query)
                                {
                                    string key = "";
                                    string value = "";

                                    if (q.Contains("="))
                                    {
                                        key = q.Split('=')[0];
                                        value = q.Split('=')[1];
                                    }
                                    else
                                        key = q;

                                    if (QueryStrings.ContainsKey(key))
                                        QueryStrings.Remove(key);

                                    QueryStrings.Add(key, value);
                                }
                            }
                        }
                        else
                            className = modalPart;
                    

                    List<ItemModel> vdata = null;
                    if (className != "")
                    {
                        Type type = Type.GetType("BaseBusiness.BS_" + className + ", ClassLibrary");
                        System.Reflection.MethodInfo dynamicGet = type == null ? null : type.GetMethod("getValidateData");
                        if (dynamicGet != null)
                            vdata = (List<ItemModel>)dynamicGet.Invoke(null, new object[] { db, IDBranch, StaffID, QueryStrings });
                        ExcelUtil.SetValidateData(package, i, vdata);
                    }

                    propList.Add(new
                    {
                        ClassName = className,
                        PropertyName = (p.Contains("|") ? p.Split('|')[1] : p),
                        ReffProperty = reffProperty,
                        ValidateData = vdata
                    });
                }
                #endregion

                foreach (var item in data)
                {
                    for (int i = 1; i <= SheetColumnsCount; i++)
                    {
                        var property = propList[i - 1];
                        if (!string.IsNullOrEmpty(property.PropertyName) && item.GetType().GetProperties().Any(d => d.Name == property.PropertyName))
                        {
                            if (firstColInex == 0)
                                firstColInex = i;

                            if (property.ClassName != "")
                            {
                                ItemModel it = null;
                                if (property.ReffProperty == "Id")
                                {
                                    var val = item.GetType().GetProperties().First(o => o.Name == property.PropertyName).GetValue(item, null);
                                    if (val != null && property.ValidateData != null)
                                    {
                                        int.TryParse(val.ToString(), out int id);
                                        if (id > 0)
                                            it = property.ValidateData.FirstOrDefault(d => d.Id == id);
                                    }
                                }
                                else if (property.ReffProperty == "Code")
                                {
                                    string code = (string)item.GetType().GetProperties().First(o => o.Name == property.PropertyName).GetValue(item, null);
                                    if (!string.IsNullOrEmpty(code))
                                        it = property.ValidateData.FirstOrDefault(d => d.Code == code);
                                }

                                if (it != null)
                                    ws.Cells[rowid, i].Value = (property.ReffProperty == "Id"? it.Id.ToString() : it.Code) + ". " + it.Name;
                                
                            }
                            else
                                ws.Cells[rowid, i].Value = item.GetType().GetProperties().First(o => o.Name == property.PropertyName).GetValue(item, null);
                        }
                    }
                    rowid++;
                }

                //create a range for the table
                var range = ws.Cells[4, firstColInex, rowid-1, SheetColumnsCount];
                range.Style.Border.Bottom.Style = OfficeOpenXml.Style.ExcelBorderStyle.Thin;
                range.Style.Border.Bottom.Color.SetColor(System.Drawing.Color.FromArgb(235,235,235));
                range.Style.Border.DiagonalDown = true;

                range.AutoFilter = true;
                //ws.Cells.AutoFilter = true;
                //ws.Cells.AutoFitColumns(6, 60);

                package.Save();
            }

            return package.File.FullName.Substring(package.File.FullName.IndexOf("\\Uploads\\"));
        }

		public static DTO_WMS_WarehouseInfo getAnItem(AppEntities db, int IDBranch, int StaffID, int id)
        {
            var dbResult = db.tbl_WMS_WarehouseInfo.Find(id);

			//if (dbResult == null || (IDBranch != 0 && dbResult.IDBranch != IDBranch))
			//	return null; 
			//else 
				return toDTO(dbResult);
			
        }
		
		public static DTO_WMS_WarehouseInfo getAnItemByCode(AppEntities db, int IDBranch, int StaffID, string code)
        {
            var dbResult = db.tbl_WMS_WarehouseInfo
			.FirstOrDefault(d => d.IsDeleted == false && d.Code == code); //.FirstOrDefault(d => d.IsDeleted == false && (d.IDBranch == IDBranch || IDBranch == 0) && d.Code == code);

			
            return toDTO(dbResult);
            //if (dbResult == null || dbResult.IDBranch != IDBranch)
			//	return null; 
			//else 
			//	return toDTO(dbResult);

			
        }

		public static bool put(AppEntities db, int IDBranch, int StaffID, int Id, dynamic item, string Username, Dictionary<string, string> QueryStrings)
        {
            bool result = false;
            var dbitem = db.tbl_WMS_WarehouseInfo.Find(Id);
            
            if (dbitem != null)
            {
                patchDynamicToDB(item, dbitem, Username);
                try
                {
                    db.SaveChanges();
					result = true;
                }
                catch (DbEntityValidationException e)
                {
					errorLog.logMessage("put_WMS_WarehouseInfo",e);
                    result = false;
                }
            }
            else
                if (QueryStrings.Any(d => d.Key == "ForceCreate"))
                    result =  post(db, IDBranch, StaffID, item, Username) != null;
                
            return result;
        }

        public static void patchDynamicToDB(dynamic item, tbl_WMS_WarehouseInfo dbitem, string Username)
        {
            Type type = typeof(tbl_WMS_WarehouseInfo);
            List<string> Props = new List<string>();
            try
            {
                if (item.GetType().Name == "JObject")
                    foreach (JProperty prop in item.Properties())
                        Props.Add(prop.Name);
                else
                    foreach (var prop in item.GetType().GetProperties())
                        Props.Add(prop.Name);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            
            foreach (string prop in Props)
            {
                if ("|CreatedBy|CreatedDate|ModifiedBy|ModifiedDate|IsDisabled|IsDeleted|".Contains("|" + prop + "|"))
                    continue;

                var tprop = type.GetProperty(prop);
                if (tprop != null)
                {
                    var value = item.GetType().Name == "JObject" ? item[prop].Value : item.GetType().GetProperty(prop).GetValue(item, null);
                    if (prop == "Id" && string.IsNullOrEmpty(Convert.ToString(value))) value = 0;
                    var safeValue = (value == null) ? null : Convert.ChangeType(value, Nullable.GetUnderlyingType(tprop.PropertyType) ?? tprop.PropertyType);
                    tprop.SetValue(dbitem, safeValue);
                }
            }

            dbitem.ModifiedBy = Username;
			dbitem.ModifiedDate = DateTime.Now;
        }

        public static void patchDTOtoDBValue( DTO_WMS_WarehouseInfo item, tbl_WMS_WarehouseInfo dbitem)
        {
            if (item == null){
                dbitem = null;
                return;
            }
            							
			dbitem.IDBranch = item.IDBranch;							
			dbitem.Code = item.Code;							
			dbitem.Name = item.Name;							
			dbitem.Remark = item.Remark;							
			dbitem.Sort = item.Sort;							
			dbitem.IsDisabled = item.IsDisabled;							
			dbitem.IsDeleted = item.IsDeleted;							
			dbitem.IsLocked = item.IsLocked;							
			dbitem.InventoryAccount = item.InventoryAccount;							
			dbitem.CostOfGoodsSoldAccount = item.CostOfGoodsSoldAccount;							
			dbitem.AllocationAccount = item.AllocationAccount;							
			dbitem.RevenueAccount = item.RevenueAccount;							
			dbitem.VarianceAccount = item.VarianceAccount;							
			dbitem.InventoryOffsetDecreaseAccount = item.InventoryOffsetDecreaseAccount;							
			dbitem.InventoryOffsetIncreaseAccount = item.InventoryOffsetIncreaseAccount;							
			dbitem.SalesReturnsAccount = item.SalesReturnsAccount;							
			dbitem.ExpenseAccount = item.ExpenseAccount;							
			dbitem.RevenueAccountForeign = item.RevenueAccountForeign;							
			dbitem.ExpenseAccountForeign = item.ExpenseAccountForeign;							
			dbitem.TaxGroup = item.TaxGroup;							
			dbitem.IsDropShip = item.IsDropShip;							
			dbitem.ExemptRevenueAccount = item.ExemptRevenueAccount;							
			dbitem.IsAllowUseTax = item.IsAllowUseTax;							
			dbitem.PriceDifferenceAccount = item.PriceDifferenceAccount;							
			dbitem.ExchangeRateDifferencesAccount = item.ExchangeRateDifferencesAccount;							
			dbitem.GoodsClearingAccount = item.GoodsClearingAccount;							
			dbitem.PurchaseAccount = item.PurchaseAccount;							
			dbitem.PurchaseReturnAccount = item.PurchaseReturnAccount;							
			dbitem.PurchaseOffsetAccount = item.PurchaseOffsetAccount;							
			dbitem.ShippedGoodsAccount = item.ShippedGoodsAccount;							
			dbitem.VATinRevenueAccount = item.VATinRevenueAccount;							
			dbitem.GLDecreaseAccount = item.GLDecreaseAccount;							
			dbitem.GLIncreaseAccount = item.GLIncreaseAccount;							
			dbitem.IsNettable = item.IsNettable;							
			dbitem.InventoryRevaluationAccount = item.InventoryRevaluationAccount;							
			dbitem.InventoryRevaluationOffsetAccount = item.InventoryRevaluationOffsetAccount;							
			dbitem.COGSRevaluationAccount = item.COGSRevaluationAccount;							
			dbitem.COGSRevaluationOffsetAccount = item.COGSRevaluationOffsetAccount;							
			dbitem.ExpenseClearingAccount = item.ExpenseClearingAccount;							
			dbitem.ExpenseOffsetAccount = item.ExpenseOffsetAccount;							
			dbitem.SalesCreditAccount = item.SalesCreditAccount;							
			dbitem.SalesCreditAccountForeign = item.SalesCreditAccountForeign;							
			dbitem.TaxExemptCreditAccount = item.TaxExemptCreditAccount;							
			dbitem.PurchaseCreditAccount = item.PurchaseCreditAccount;							
			dbitem.PurchaseCreditAccountForeign = item.PurchaseCreditAccountForeign;							
			dbitem.RevenueReturnsAccount = item.RevenueReturnsAccount;							
			dbitem.NegativeInventoryAdjustmentAccount = item.NegativeInventoryAdjustmentAccount;							
			dbitem.StockInTransitAccount = item.StockInTransitAccount;							
			dbitem.PurchaseBalanceAccount = item.PurchaseBalanceAccount;							
			dbitem.InventoryOffsetPLAccount = item.InventoryOffsetPLAccount;							
			dbitem.Storekeeper = item.Storekeeper;							
			dbitem.IsBinActivated = item.IsBinActivated;							
			dbitem.BinSeparator = item.BinSeparator;							
			dbitem.DefaultBinInternalNumber = item.DefaultBinInternalNumber;							
			dbitem.GlobalLocationNumber = item.GlobalLocationNumber;							
			dbitem.FreeOfChargeSalesAccount = item.FreeOfChargeSalesAccount;							
			dbitem.FreeOfChargePurchaseAccount = item.FreeOfChargePurchaseAccount;        }

		public static DTO_WMS_WarehouseInfo post(AppEntities db, int IDBranch, int StaffID, dynamic item, string Username)
        {
            tbl_WMS_WarehouseInfo dbitem = new tbl_WMS_WarehouseInfo();
            if (item != null)
            {
                patchDynamicToDB(item, dbitem, Username);
                
				dbitem.CreatedBy = Username;
				dbitem.CreatedDate = DateTime.Now;				
                try
                {
					db.tbl_WMS_WarehouseInfo.Add(dbitem);
                    db.SaveChanges();
				
                }
                catch (DbEntityValidationException e)
                {
					errorLog.logMessage("post_WMS_WarehouseInfo",e);
                    return null;
                }
            }
            return toDTO(dbitem);
        }

        public static dynamic import(ExcelPackage package, AppEntities db, int IDBranch, int StaffID, Dictionary<string, string> QueryStrings, string Username)
        {
            ExcelWorkbook workBook = package.Workbook;
            int errCount = 0;
            var errList = new List<Tuple<int, int, string>>().Select(t => new { Id = t.Item1, Line = t.Item2, Message = t.Item3 }).ToList();
            
            if (workBook != null)
            {
                Type type = Type.GetType("BaseBusiness.BS_WMS_WarehouseInfo, ClassLibrary");
                var ws = workBook.Worksheets.FirstOrDefault();
                int SheetColumnsCount = ws.Dimension.End.Column;
                int SheetRowCount = ws.Dimension.End.Row;
                int firstRow = 5;
                int firstColIndex = 1;
                
                for (int r = firstRow; r <= SheetRowCount; r++){
                    dynamic it = new Newtonsoft.Json.Linq.JObject();
                    bool isBreak = false;
                    for (int c = firstColIndex; c <= SheetColumnsCount; c++)
                    {
                        dynamic convert = new Newtonsoft.Json.Linq.JObject();
                        var target = new tbl_WMS_WarehouseInfo();
                        string property = ws.Cells[1, c].Value == null ? "" : ws.Cells[1, c].Text;
                        if(!string.IsNullOrEmpty(property))
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
                                patchDynamicToDB(convert, target, Username);
                                System.Reflection.MethodInfo validate = type.GetMethod("validate");
                                if (validate != null) {
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
                    
                    tbl_WMS_WarehouseInfo dbitem = new tbl_WMS_WarehouseInfo();
                    if (it.Id == null || string.IsNullOrEmpty(it.Id.Value) || it.Id == "0")
                    {
                        dbitem = new tbl_WMS_WarehouseInfo();
                        dbitem.CreatedBy = Username;
				        dbitem.CreatedDate = DateTime.Now;
                                            }
                    else
                    {
                        dbitem = db.tbl_WMS_WarehouseInfo.Find((int)it.Id);
                    }

                    if (dbitem == null)
                    {
                        errCount++;
                        string message = "Không tìm được dữ liệu (Id: " + it.Id + ")";
                        errList.Add(new { Id = errCount, Line = r, Message = message });
                        ExcelUtil.NoteToWorkSheet(ws, r, firstColIndex, message, System.Drawing.Color.Red, System.Drawing.Color.White);
                        continue;
                    }
                    try
                    {
                        patchDynamicToDB(it, dbitem, Username);
                        System.Reflection.MethodInfo fillReference = type.GetMethod("fillReference");
                        if (fillReference != null)
                            fillReference.Invoke(null, new object[] { dbitem, it, db, IDBranch, StaffID, QueryStrings, Username });
                        
                        if (dbitem.Id == 0) db.tbl_WMS_WarehouseInfo.Add(dbitem);
                    }
                    catch (Exception ex)
                    {
                        errCount++;
                        errList.Add(new { Id = errCount, Line = r, Message = ex.Message });
                        ExcelUtil.NoteToWorkSheet(ws, r, firstColIndex, ex.Message, System.Drawing.Color.Red, System.Drawing.Color.White);
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
                    errorLog.logMessage("post_WMS_WarehouseInfo",e);
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

		public static bool delete(AppEntities db, string ids, string Username)
        {
			bool result = false;

            var IDList = ids.Replace("[", "").Replace("]", "").Split(',');
            List<int?> IDs = new List<int?>();
            foreach (var item in IDList)
                if (int.TryParse(item, out int i))
                    IDs.Add(i);
                else if (item == "null")
                    IDs.Add(null);
            if (IDs.Count == 0){
                return result;
            }

            var dbitems = db.tbl_WMS_WarehouseInfo.Where(d => IDs.Contains(d.Id));
            var updateDate = DateTime.Now;
            List<int?> IDBranches = new List<int?>();

            foreach (var dbitem in dbitems)
            {
							
				dbitem.ModifiedBy = Username;
				dbitem.ModifiedDate = updateDate;
				dbitem.IsDeleted = true;
							            
                if (!IDBranches.Any(d=>d==dbitem.IDBranch))
                {
                    IDBranches.Add(dbitem.IDBranch);
                }
			
                
            }

            try
            {
                db.SaveChanges();
                result = true;
			
                foreach (var IDBranch in IDBranches)
                {
                    BS_Version.update_Version(db, IDBranch, "DTO_WMS_WarehouseInfo", updateDate, Username);
                }
			
            }
            catch (DbEntityValidationException e)
            {
				errorLog.logMessage("delete_WMS_WarehouseInfo",e);
                result = false;
            }

            return result;
        }

        public static bool disable(AppEntities db, string ids, bool isDisable, string Username)
        {
            bool result = false;
                        
            var IDList = ids.Replace("[", "").Replace("]", "").Split(',');
            List<int?> IDs = new List<int?>();
            foreach (var item in IDList)
                if (int.TryParse(item, out int i))
                    IDs.Add(i);
                else if (item == "null")
                    IDs.Add(null);
            if (IDs.Count == 0){
                return result;
            }

			
            var dbitems = db.tbl_WMS_WarehouseInfo.Where(d => IDs.Contains(d.Id));
            var updateDate = DateTime.Now;
            List<int?> IDBranches = new List<int?>();

            foreach (var dbitem in dbitems)
            {
				
				dbitem.ModifiedBy = Username;
				dbitem.ModifiedDate = updateDate;
				
			    dbitem.IsDisabled = isDisable;
                result = true;

                
            }

            try
            {
                db.SaveChanges();
                result = true;
			
                foreach (var IDBranch in IDBranches)
                {
                    BS_Version.update_Version(db, IDBranch, "DTO_WMS_WarehouseInfo", updateDate, Username);
                }
			
            }
            catch (DbEntityValidationException e)
            {
				errorLog.logMessage("disable_WMS_WarehouseInfo",e);
                result = false;
            }
            
            return result;
        }

		
		//---//
		public static bool check_Exists(AppEntities db, int id)
		{
             
            return db.tbl_WMS_WarehouseInfo.Any(e => e.Id == id && e.IsDeleted == false);
            
		}
		
		public static bool check_Exists(AppEntities db, string Code)
		{
             
            return db.tbl_WMS_WarehouseInfo.Any(e => e.Code == Code && e.IsDeleted == false);
            
		}
		
		//---//
		public static IQueryable<DTO_WMS_WarehouseInfo> toDTO(IQueryable<tbl_WMS_WarehouseInfo> query)
        {
			return query
			.Select(s => new DTO_WMS_WarehouseInfo(){							
				IDBranch = s.IDBranch,							
				Id = s.Id,							
				Code = s.Code,							
				Name = s.Name,							
				Remark = s.Remark,							
				Sort = s.Sort,							
				IsDisabled = s.IsDisabled,							
				IsDeleted = s.IsDeleted,							
				CreatedBy = s.CreatedBy,							
				ModifiedBy = s.ModifiedBy,							
				CreatedDate = s.CreatedDate,							
				ModifiedDate = s.ModifiedDate,							
				IsLocked = s.IsLocked,							
				InventoryAccount = s.InventoryAccount,							
				CostOfGoodsSoldAccount = s.CostOfGoodsSoldAccount,							
				AllocationAccount = s.AllocationAccount,							
				RevenueAccount = s.RevenueAccount,							
				VarianceAccount = s.VarianceAccount,							
				InventoryOffsetDecreaseAccount = s.InventoryOffsetDecreaseAccount,							
				InventoryOffsetIncreaseAccount = s.InventoryOffsetIncreaseAccount,							
				SalesReturnsAccount = s.SalesReturnsAccount,							
				ExpenseAccount = s.ExpenseAccount,							
				RevenueAccountForeign = s.RevenueAccountForeign,							
				ExpenseAccountForeign = s.ExpenseAccountForeign,							
				TaxGroup = s.TaxGroup,							
				IsDropShip = s.IsDropShip,							
				ExemptRevenueAccount = s.ExemptRevenueAccount,							
				IsAllowUseTax = s.IsAllowUseTax,							
				PriceDifferenceAccount = s.PriceDifferenceAccount,							
				ExchangeRateDifferencesAccount = s.ExchangeRateDifferencesAccount,							
				GoodsClearingAccount = s.GoodsClearingAccount,							
				PurchaseAccount = s.PurchaseAccount,							
				PurchaseReturnAccount = s.PurchaseReturnAccount,							
				PurchaseOffsetAccount = s.PurchaseOffsetAccount,							
				ShippedGoodsAccount = s.ShippedGoodsAccount,							
				VATinRevenueAccount = s.VATinRevenueAccount,							
				GLDecreaseAccount = s.GLDecreaseAccount,							
				GLIncreaseAccount = s.GLIncreaseAccount,							
				IsNettable = s.IsNettable,							
				InventoryRevaluationAccount = s.InventoryRevaluationAccount,							
				InventoryRevaluationOffsetAccount = s.InventoryRevaluationOffsetAccount,							
				COGSRevaluationAccount = s.COGSRevaluationAccount,							
				COGSRevaluationOffsetAccount = s.COGSRevaluationOffsetAccount,							
				ExpenseClearingAccount = s.ExpenseClearingAccount,							
				ExpenseOffsetAccount = s.ExpenseOffsetAccount,							
				SalesCreditAccount = s.SalesCreditAccount,							
				SalesCreditAccountForeign = s.SalesCreditAccountForeign,							
				TaxExemptCreditAccount = s.TaxExemptCreditAccount,							
				PurchaseCreditAccount = s.PurchaseCreditAccount,							
				PurchaseCreditAccountForeign = s.PurchaseCreditAccountForeign,							
				RevenueReturnsAccount = s.RevenueReturnsAccount,							
				NegativeInventoryAdjustmentAccount = s.NegativeInventoryAdjustmentAccount,							
				StockInTransitAccount = s.StockInTransitAccount,							
				PurchaseBalanceAccount = s.PurchaseBalanceAccount,							
				InventoryOffsetPLAccount = s.InventoryOffsetPLAccount,							
				Storekeeper = s.Storekeeper,							
				IsBinActivated = s.IsBinActivated,							
				BinSeparator = s.BinSeparator,							
				DefaultBinInternalNumber = s.DefaultBinInternalNumber,							
				GlobalLocationNumber = s.GlobalLocationNumber,							
				FreeOfChargeSalesAccount = s.FreeOfChargeSalesAccount,							
				FreeOfChargePurchaseAccount = s.FreeOfChargePurchaseAccount,					
			});//.OrderBy(o => o.Sort == null).ThenBy(u => u.Sort);
                              
        }

		public static DTO_WMS_WarehouseInfo toDTO(tbl_WMS_WarehouseInfo dbResult)
        {
			if (dbResult != null)
			{
				return new DTO_WMS_WarehouseInfo()
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
					IsLocked = dbResult.IsLocked,							
					InventoryAccount = dbResult.InventoryAccount,							
					CostOfGoodsSoldAccount = dbResult.CostOfGoodsSoldAccount,							
					AllocationAccount = dbResult.AllocationAccount,							
					RevenueAccount = dbResult.RevenueAccount,							
					VarianceAccount = dbResult.VarianceAccount,							
					InventoryOffsetDecreaseAccount = dbResult.InventoryOffsetDecreaseAccount,							
					InventoryOffsetIncreaseAccount = dbResult.InventoryOffsetIncreaseAccount,							
					SalesReturnsAccount = dbResult.SalesReturnsAccount,							
					ExpenseAccount = dbResult.ExpenseAccount,							
					RevenueAccountForeign = dbResult.RevenueAccountForeign,							
					ExpenseAccountForeign = dbResult.ExpenseAccountForeign,							
					TaxGroup = dbResult.TaxGroup,							
					IsDropShip = dbResult.IsDropShip,							
					ExemptRevenueAccount = dbResult.ExemptRevenueAccount,							
					IsAllowUseTax = dbResult.IsAllowUseTax,							
					PriceDifferenceAccount = dbResult.PriceDifferenceAccount,							
					ExchangeRateDifferencesAccount = dbResult.ExchangeRateDifferencesAccount,							
					GoodsClearingAccount = dbResult.GoodsClearingAccount,							
					PurchaseAccount = dbResult.PurchaseAccount,							
					PurchaseReturnAccount = dbResult.PurchaseReturnAccount,							
					PurchaseOffsetAccount = dbResult.PurchaseOffsetAccount,							
					ShippedGoodsAccount = dbResult.ShippedGoodsAccount,							
					VATinRevenueAccount = dbResult.VATinRevenueAccount,							
					GLDecreaseAccount = dbResult.GLDecreaseAccount,							
					GLIncreaseAccount = dbResult.GLIncreaseAccount,							
					IsNettable = dbResult.IsNettable,							
					InventoryRevaluationAccount = dbResult.InventoryRevaluationAccount,							
					InventoryRevaluationOffsetAccount = dbResult.InventoryRevaluationOffsetAccount,							
					COGSRevaluationAccount = dbResult.COGSRevaluationAccount,							
					COGSRevaluationOffsetAccount = dbResult.COGSRevaluationOffsetAccount,							
					ExpenseClearingAccount = dbResult.ExpenseClearingAccount,							
					ExpenseOffsetAccount = dbResult.ExpenseOffsetAccount,							
					SalesCreditAccount = dbResult.SalesCreditAccount,							
					SalesCreditAccountForeign = dbResult.SalesCreditAccountForeign,							
					TaxExemptCreditAccount = dbResult.TaxExemptCreditAccount,							
					PurchaseCreditAccount = dbResult.PurchaseCreditAccount,							
					PurchaseCreditAccountForeign = dbResult.PurchaseCreditAccountForeign,							
					RevenueReturnsAccount = dbResult.RevenueReturnsAccount,							
					NegativeInventoryAdjustmentAccount = dbResult.NegativeInventoryAdjustmentAccount,							
					StockInTransitAccount = dbResult.StockInTransitAccount,							
					PurchaseBalanceAccount = dbResult.PurchaseBalanceAccount,							
					InventoryOffsetPLAccount = dbResult.InventoryOffsetPLAccount,							
					Storekeeper = dbResult.Storekeeper,							
					IsBinActivated = dbResult.IsBinActivated,							
					BinSeparator = dbResult.BinSeparator,							
					DefaultBinInternalNumber = dbResult.DefaultBinInternalNumber,							
					GlobalLocationNumber = dbResult.GlobalLocationNumber,							
					FreeOfChargeSalesAccount = dbResult.FreeOfChargeSalesAccount,							
					FreeOfChargePurchaseAccount = dbResult.FreeOfChargePurchaseAccount,
				};
			}
			else
				return null; 
        }

		public static IQueryable<tbl_WMS_WarehouseInfo> _queryBuilder(AppEntities db, int IDBranch, int StaffID, Dictionary<string, string> QueryStrings)
        {
            
			IQueryable<tbl_WMS_WarehouseInfo> query = db.tbl_WMS_WarehouseInfo.AsNoTracking();//.Where(d => d.IsDeleted == false);
			

			//Query keyword
			if (QueryStrings.Any(d => d.Key == "Keyword") && !string.IsNullOrEmpty(QueryStrings.FirstOrDefault(d => d.Key == "Keyword").Value))
            {
                var keyword = QueryStrings.FirstOrDefault(d => d.Key == "Keyword").Value;
                query = query.Where(d=>d.Name.Contains(keyword) || d.Code.Contains(keyword));
            }



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

			//Query Id (int)
			if (QueryStrings.Any(d => d.Key == "Id"))
            {
                var IDList = QueryStrings.FirstOrDefault(d => d.Key == "Id").Value.Replace("[", "").Replace("]", "").Split(',');
                List<int> IDs = new List<int>();
                foreach (var item in IDList)
                    if (int.TryParse(item, out int i))
                        IDs.Add(i);
                if (IDs.Count > 0)
                    query = query.Where(d => IDs.Contains(d.Id));
            }

			//Query Code (string)
			if (QueryStrings.Any(d => d.Key == "Code_eq") && !string.IsNullOrEmpty(QueryStrings.FirstOrDefault(d => d.Key == "Code_eq").Value))
            {
                var keyword = QueryStrings.FirstOrDefault(d => d.Key == "Code_eq").Value;
                query = query.Where(d=>d.Code == keyword);
            }
            if (QueryStrings.Any(d => d.Key == "Code") && !string.IsNullOrEmpty(QueryStrings.FirstOrDefault(d => d.Key == "Code").Value))
            {
                var keyword = QueryStrings.FirstOrDefault(d => d.Key == "Code").Value;
                query = query.Where(d=>d.Code.Contains(keyword));
            }
            

			//Query Name (string)
			if (QueryStrings.Any(d => d.Key == "Name_eq") && !string.IsNullOrEmpty(QueryStrings.FirstOrDefault(d => d.Key == "Name_eq").Value))
            {
                var keyword = QueryStrings.FirstOrDefault(d => d.Key == "Name_eq").Value;
                query = query.Where(d=>d.Name == keyword);
            }
            if (QueryStrings.Any(d => d.Key == "Name") && !string.IsNullOrEmpty(QueryStrings.FirstOrDefault(d => d.Key == "Name").Value))
            {
                var keyword = QueryStrings.FirstOrDefault(d => d.Key == "Name").Value;
                query = query.Where(d=>d.Name.Contains(keyword));
            }
            

			//Query Remark (string)
			if (QueryStrings.Any(d => d.Key == "Remark_eq") && !string.IsNullOrEmpty(QueryStrings.FirstOrDefault(d => d.Key == "Remark_eq").Value))
            {
                var keyword = QueryStrings.FirstOrDefault(d => d.Key == "Remark_eq").Value;
                query = query.Where(d=>d.Remark == keyword);
            }
            if (QueryStrings.Any(d => d.Key == "Remark") && !string.IsNullOrEmpty(QueryStrings.FirstOrDefault(d => d.Key == "Remark").Value))
            {
                var keyword = QueryStrings.FirstOrDefault(d => d.Key == "Remark").Value;
                query = query.Where(d=>d.Remark.Contains(keyword));
            }
            

			//Query Sort (Nullable<int>)
			if (QueryStrings.Any(d => d.Key == "SortFrom") && QueryStrings.Any(d => d.Key == "SortTo"))
                if (int.TryParse(QueryStrings.FirstOrDefault(d => d.Key == "SortFrom").Value, out int fromVal) && int.TryParse(QueryStrings.FirstOrDefault(d => d.Key == "SortTo").Value, out int toVal))
                    query = query.Where(d => fromVal <= d.Sort && d.Sort <= toVal);

			//Query IsDisabled (bool)
			if (QueryStrings.Any(d => d.Key == "IsDisabled"))
            {
                var qValue = QueryStrings.FirstOrDefault(d => d.Key == "IsDisabled").Value;
                if (bool.TryParse(qValue, out bool qBoolValue))
                    query = query.Where(d => qBoolValue == d.IsDisabled);
            }
            else
                query = query.Where(d => false == d.IsDisabled);

			//Query IsDeleted (bool)
			if (QueryStrings.Any(d => d.Key == "IsDeleted"))
            {
                var qValue = QueryStrings.FirstOrDefault(d => d.Key == "IsDeleted").Value;
                if (bool.TryParse(qValue, out bool qBoolValue))
                    query = query.Where(d => qBoolValue == d.IsDeleted);
            }
            else
                query = query.Where(d => false == d.IsDeleted);

			//Query CreatedBy (string)
			if (QueryStrings.Any(d => d.Key == "CreatedBy_eq") && !string.IsNullOrEmpty(QueryStrings.FirstOrDefault(d => d.Key == "CreatedBy_eq").Value))
            {
                var keyword = QueryStrings.FirstOrDefault(d => d.Key == "CreatedBy_eq").Value;
                query = query.Where(d=>d.CreatedBy == keyword);
            }
            if (QueryStrings.Any(d => d.Key == "CreatedBy") && !string.IsNullOrEmpty(QueryStrings.FirstOrDefault(d => d.Key == "CreatedBy").Value))
            {
                var keyword = QueryStrings.FirstOrDefault(d => d.Key == "CreatedBy").Value;
                query = query.Where(d=>d.CreatedBy.Contains(keyword));
            }
            

			//Query ModifiedBy (string)
			if (QueryStrings.Any(d => d.Key == "ModifiedBy_eq") && !string.IsNullOrEmpty(QueryStrings.FirstOrDefault(d => d.Key == "ModifiedBy_eq").Value))
            {
                var keyword = QueryStrings.FirstOrDefault(d => d.Key == "ModifiedBy_eq").Value;
                query = query.Where(d=>d.ModifiedBy == keyword);
            }
            if (QueryStrings.Any(d => d.Key == "ModifiedBy") && !string.IsNullOrEmpty(QueryStrings.FirstOrDefault(d => d.Key == "ModifiedBy").Value))
            {
                var keyword = QueryStrings.FirstOrDefault(d => d.Key == "ModifiedBy").Value;
                query = query.Where(d=>d.ModifiedBy.Contains(keyword));
            }
            

			//Query CreatedDate (System.DateTime)
			if (QueryStrings.Any(d => d.Key == "CreatedDateFrom") && QueryStrings.Any(d => d.Key == "CreatedDateTo"))
                if (DateTime.TryParse(QueryStrings.FirstOrDefault(d => d.Key == "CreatedDateFrom").Value, out DateTime fromDate) && DateTime.TryParse(QueryStrings.FirstOrDefault(d => d.Key == "CreatedDateTo").Value, out DateTime toDate))
                    query = query.Where(d => fromDate <= d.CreatedDate && d.CreatedDate <= toDate);

            if (QueryStrings.Any(d => d.Key == "CreatedDate"))
                if (DateTime.TryParse(QueryStrings.FirstOrDefault(d => d.Key == "CreatedDate").Value, out DateTime val))
                    query = query.Where(d => d.CreatedDate != null && DbFunctions.TruncateTime(val) == DbFunctions.TruncateTime(d.CreatedDate));


			//Query ModifiedDate (System.DateTime)
			if (QueryStrings.Any(d => d.Key == "ModifiedDateFrom") && QueryStrings.Any(d => d.Key == "ModifiedDateTo"))
                if (DateTime.TryParse(QueryStrings.FirstOrDefault(d => d.Key == "ModifiedDateFrom").Value, out DateTime fromDate) && DateTime.TryParse(QueryStrings.FirstOrDefault(d => d.Key == "ModifiedDateTo").Value, out DateTime toDate))
                    query = query.Where(d => fromDate <= d.ModifiedDate && d.ModifiedDate <= toDate);

            if (QueryStrings.Any(d => d.Key == "ModifiedDate"))
                if (DateTime.TryParse(QueryStrings.FirstOrDefault(d => d.Key == "ModifiedDate").Value, out DateTime val))
                    query = query.Where(d => d.ModifiedDate != null && DbFunctions.TruncateTime(val) == DbFunctions.TruncateTime(d.ModifiedDate));


			//Query IsLocked (bool)
			if (QueryStrings.Any(d => d.Key == "IsLocked"))
            {
                var qValue = QueryStrings.FirstOrDefault(d => d.Key == "IsLocked").Value;
                if (bool.TryParse(qValue, out bool qBoolValue))
                    query = query.Where(d => qBoolValue == d.IsLocked);
            }

			//Query InventoryAccount (Nullable<int>)
			if (QueryStrings.Any(d => d.Key == "InventoryAccountFrom") && QueryStrings.Any(d => d.Key == "InventoryAccountTo"))
                if (int.TryParse(QueryStrings.FirstOrDefault(d => d.Key == "InventoryAccountFrom").Value, out int fromVal) && int.TryParse(QueryStrings.FirstOrDefault(d => d.Key == "InventoryAccountTo").Value, out int toVal))
                    query = query.Where(d => fromVal <= d.InventoryAccount && d.InventoryAccount <= toVal);

			//Query CostOfGoodsSoldAccount (Nullable<int>)
			if (QueryStrings.Any(d => d.Key == "CostOfGoodsSoldAccountFrom") && QueryStrings.Any(d => d.Key == "CostOfGoodsSoldAccountTo"))
                if (int.TryParse(QueryStrings.FirstOrDefault(d => d.Key == "CostOfGoodsSoldAccountFrom").Value, out int fromVal) && int.TryParse(QueryStrings.FirstOrDefault(d => d.Key == "CostOfGoodsSoldAccountTo").Value, out int toVal))
                    query = query.Where(d => fromVal <= d.CostOfGoodsSoldAccount && d.CostOfGoodsSoldAccount <= toVal);

			//Query AllocationAccount (Nullable<int>)
			if (QueryStrings.Any(d => d.Key == "AllocationAccountFrom") && QueryStrings.Any(d => d.Key == "AllocationAccountTo"))
                if (int.TryParse(QueryStrings.FirstOrDefault(d => d.Key == "AllocationAccountFrom").Value, out int fromVal) && int.TryParse(QueryStrings.FirstOrDefault(d => d.Key == "AllocationAccountTo").Value, out int toVal))
                    query = query.Where(d => fromVal <= d.AllocationAccount && d.AllocationAccount <= toVal);

			//Query RevenueAccount (Nullable<int>)
			if (QueryStrings.Any(d => d.Key == "RevenueAccountFrom") && QueryStrings.Any(d => d.Key == "RevenueAccountTo"))
                if (int.TryParse(QueryStrings.FirstOrDefault(d => d.Key == "RevenueAccountFrom").Value, out int fromVal) && int.TryParse(QueryStrings.FirstOrDefault(d => d.Key == "RevenueAccountTo").Value, out int toVal))
                    query = query.Where(d => fromVal <= d.RevenueAccount && d.RevenueAccount <= toVal);

			//Query VarianceAccount (Nullable<int>)
			if (QueryStrings.Any(d => d.Key == "VarianceAccountFrom") && QueryStrings.Any(d => d.Key == "VarianceAccountTo"))
                if (int.TryParse(QueryStrings.FirstOrDefault(d => d.Key == "VarianceAccountFrom").Value, out int fromVal) && int.TryParse(QueryStrings.FirstOrDefault(d => d.Key == "VarianceAccountTo").Value, out int toVal))
                    query = query.Where(d => fromVal <= d.VarianceAccount && d.VarianceAccount <= toVal);

			//Query InventoryOffsetDecreaseAccount (Nullable<int>)
			if (QueryStrings.Any(d => d.Key == "InventoryOffsetDecreaseAccountFrom") && QueryStrings.Any(d => d.Key == "InventoryOffsetDecreaseAccountTo"))
                if (int.TryParse(QueryStrings.FirstOrDefault(d => d.Key == "InventoryOffsetDecreaseAccountFrom").Value, out int fromVal) && int.TryParse(QueryStrings.FirstOrDefault(d => d.Key == "InventoryOffsetDecreaseAccountTo").Value, out int toVal))
                    query = query.Where(d => fromVal <= d.InventoryOffsetDecreaseAccount && d.InventoryOffsetDecreaseAccount <= toVal);

			//Query InventoryOffsetIncreaseAccount (Nullable<int>)
			if (QueryStrings.Any(d => d.Key == "InventoryOffsetIncreaseAccountFrom") && QueryStrings.Any(d => d.Key == "InventoryOffsetIncreaseAccountTo"))
                if (int.TryParse(QueryStrings.FirstOrDefault(d => d.Key == "InventoryOffsetIncreaseAccountFrom").Value, out int fromVal) && int.TryParse(QueryStrings.FirstOrDefault(d => d.Key == "InventoryOffsetIncreaseAccountTo").Value, out int toVal))
                    query = query.Where(d => fromVal <= d.InventoryOffsetIncreaseAccount && d.InventoryOffsetIncreaseAccount <= toVal);

			//Query SalesReturnsAccount (Nullable<int>)
			if (QueryStrings.Any(d => d.Key == "SalesReturnsAccountFrom") && QueryStrings.Any(d => d.Key == "SalesReturnsAccountTo"))
                if (int.TryParse(QueryStrings.FirstOrDefault(d => d.Key == "SalesReturnsAccountFrom").Value, out int fromVal) && int.TryParse(QueryStrings.FirstOrDefault(d => d.Key == "SalesReturnsAccountTo").Value, out int toVal))
                    query = query.Where(d => fromVal <= d.SalesReturnsAccount && d.SalesReturnsAccount <= toVal);

			//Query ExpenseAccount (Nullable<int>)
			if (QueryStrings.Any(d => d.Key == "ExpenseAccountFrom") && QueryStrings.Any(d => d.Key == "ExpenseAccountTo"))
                if (int.TryParse(QueryStrings.FirstOrDefault(d => d.Key == "ExpenseAccountFrom").Value, out int fromVal) && int.TryParse(QueryStrings.FirstOrDefault(d => d.Key == "ExpenseAccountTo").Value, out int toVal))
                    query = query.Where(d => fromVal <= d.ExpenseAccount && d.ExpenseAccount <= toVal);

			//Query RevenueAccountForeign (Nullable<int>)
			if (QueryStrings.Any(d => d.Key == "RevenueAccountForeignFrom") && QueryStrings.Any(d => d.Key == "RevenueAccountForeignTo"))
                if (int.TryParse(QueryStrings.FirstOrDefault(d => d.Key == "RevenueAccountForeignFrom").Value, out int fromVal) && int.TryParse(QueryStrings.FirstOrDefault(d => d.Key == "RevenueAccountForeignTo").Value, out int toVal))
                    query = query.Where(d => fromVal <= d.RevenueAccountForeign && d.RevenueAccountForeign <= toVal);

			//Query ExpenseAccountForeign (Nullable<int>)
			if (QueryStrings.Any(d => d.Key == "ExpenseAccountForeignFrom") && QueryStrings.Any(d => d.Key == "ExpenseAccountForeignTo"))
                if (int.TryParse(QueryStrings.FirstOrDefault(d => d.Key == "ExpenseAccountForeignFrom").Value, out int fromVal) && int.TryParse(QueryStrings.FirstOrDefault(d => d.Key == "ExpenseAccountForeignTo").Value, out int toVal))
                    query = query.Where(d => fromVal <= d.ExpenseAccountForeign && d.ExpenseAccountForeign <= toVal);

			//Query TaxGroup (Nullable<int>)
			if (QueryStrings.Any(d => d.Key == "TaxGroupFrom") && QueryStrings.Any(d => d.Key == "TaxGroupTo"))
                if (int.TryParse(QueryStrings.FirstOrDefault(d => d.Key == "TaxGroupFrom").Value, out int fromVal) && int.TryParse(QueryStrings.FirstOrDefault(d => d.Key == "TaxGroupTo").Value, out int toVal))
                    query = query.Where(d => fromVal <= d.TaxGroup && d.TaxGroup <= toVal);

			//Query IsDropShip (Nullable<bool>)

			//Query ExemptRevenueAccount (Nullable<int>)
			if (QueryStrings.Any(d => d.Key == "ExemptRevenueAccountFrom") && QueryStrings.Any(d => d.Key == "ExemptRevenueAccountTo"))
                if (int.TryParse(QueryStrings.FirstOrDefault(d => d.Key == "ExemptRevenueAccountFrom").Value, out int fromVal) && int.TryParse(QueryStrings.FirstOrDefault(d => d.Key == "ExemptRevenueAccountTo").Value, out int toVal))
                    query = query.Where(d => fromVal <= d.ExemptRevenueAccount && d.ExemptRevenueAccount <= toVal);

			//Query IsAllowUseTax (Nullable<bool>)

			//Query PriceDifferenceAccount (Nullable<int>)
			if (QueryStrings.Any(d => d.Key == "PriceDifferenceAccountFrom") && QueryStrings.Any(d => d.Key == "PriceDifferenceAccountTo"))
                if (int.TryParse(QueryStrings.FirstOrDefault(d => d.Key == "PriceDifferenceAccountFrom").Value, out int fromVal) && int.TryParse(QueryStrings.FirstOrDefault(d => d.Key == "PriceDifferenceAccountTo").Value, out int toVal))
                    query = query.Where(d => fromVal <= d.PriceDifferenceAccount && d.PriceDifferenceAccount <= toVal);

			//Query ExchangeRateDifferencesAccount (Nullable<int>)
			if (QueryStrings.Any(d => d.Key == "ExchangeRateDifferencesAccountFrom") && QueryStrings.Any(d => d.Key == "ExchangeRateDifferencesAccountTo"))
                if (int.TryParse(QueryStrings.FirstOrDefault(d => d.Key == "ExchangeRateDifferencesAccountFrom").Value, out int fromVal) && int.TryParse(QueryStrings.FirstOrDefault(d => d.Key == "ExchangeRateDifferencesAccountTo").Value, out int toVal))
                    query = query.Where(d => fromVal <= d.ExchangeRateDifferencesAccount && d.ExchangeRateDifferencesAccount <= toVal);

			//Query GoodsClearingAccount (Nullable<int>)
			if (QueryStrings.Any(d => d.Key == "GoodsClearingAccountFrom") && QueryStrings.Any(d => d.Key == "GoodsClearingAccountTo"))
                if (int.TryParse(QueryStrings.FirstOrDefault(d => d.Key == "GoodsClearingAccountFrom").Value, out int fromVal) && int.TryParse(QueryStrings.FirstOrDefault(d => d.Key == "GoodsClearingAccountTo").Value, out int toVal))
                    query = query.Where(d => fromVal <= d.GoodsClearingAccount && d.GoodsClearingAccount <= toVal);

			//Query PurchaseAccount (Nullable<int>)
			if (QueryStrings.Any(d => d.Key == "PurchaseAccountFrom") && QueryStrings.Any(d => d.Key == "PurchaseAccountTo"))
                if (int.TryParse(QueryStrings.FirstOrDefault(d => d.Key == "PurchaseAccountFrom").Value, out int fromVal) && int.TryParse(QueryStrings.FirstOrDefault(d => d.Key == "PurchaseAccountTo").Value, out int toVal))
                    query = query.Where(d => fromVal <= d.PurchaseAccount && d.PurchaseAccount <= toVal);

			//Query PurchaseReturnAccount (Nullable<int>)
			if (QueryStrings.Any(d => d.Key == "PurchaseReturnAccountFrom") && QueryStrings.Any(d => d.Key == "PurchaseReturnAccountTo"))
                if (int.TryParse(QueryStrings.FirstOrDefault(d => d.Key == "PurchaseReturnAccountFrom").Value, out int fromVal) && int.TryParse(QueryStrings.FirstOrDefault(d => d.Key == "PurchaseReturnAccountTo").Value, out int toVal))
                    query = query.Where(d => fromVal <= d.PurchaseReturnAccount && d.PurchaseReturnAccount <= toVal);

			//Query PurchaseOffsetAccount (Nullable<int>)
			if (QueryStrings.Any(d => d.Key == "PurchaseOffsetAccountFrom") && QueryStrings.Any(d => d.Key == "PurchaseOffsetAccountTo"))
                if (int.TryParse(QueryStrings.FirstOrDefault(d => d.Key == "PurchaseOffsetAccountFrom").Value, out int fromVal) && int.TryParse(QueryStrings.FirstOrDefault(d => d.Key == "PurchaseOffsetAccountTo").Value, out int toVal))
                    query = query.Where(d => fromVal <= d.PurchaseOffsetAccount && d.PurchaseOffsetAccount <= toVal);

			//Query ShippedGoodsAccount (Nullable<int>)
			if (QueryStrings.Any(d => d.Key == "ShippedGoodsAccountFrom") && QueryStrings.Any(d => d.Key == "ShippedGoodsAccountTo"))
                if (int.TryParse(QueryStrings.FirstOrDefault(d => d.Key == "ShippedGoodsAccountFrom").Value, out int fromVal) && int.TryParse(QueryStrings.FirstOrDefault(d => d.Key == "ShippedGoodsAccountTo").Value, out int toVal))
                    query = query.Where(d => fromVal <= d.ShippedGoodsAccount && d.ShippedGoodsAccount <= toVal);

			//Query VATinRevenueAccount (Nullable<int>)
			if (QueryStrings.Any(d => d.Key == "VATinRevenueAccountFrom") && QueryStrings.Any(d => d.Key == "VATinRevenueAccountTo"))
                if (int.TryParse(QueryStrings.FirstOrDefault(d => d.Key == "VATinRevenueAccountFrom").Value, out int fromVal) && int.TryParse(QueryStrings.FirstOrDefault(d => d.Key == "VATinRevenueAccountTo").Value, out int toVal))
                    query = query.Where(d => fromVal <= d.VATinRevenueAccount && d.VATinRevenueAccount <= toVal);

			//Query GLDecreaseAccount (Nullable<int>)
			if (QueryStrings.Any(d => d.Key == "GLDecreaseAccountFrom") && QueryStrings.Any(d => d.Key == "GLDecreaseAccountTo"))
                if (int.TryParse(QueryStrings.FirstOrDefault(d => d.Key == "GLDecreaseAccountFrom").Value, out int fromVal) && int.TryParse(QueryStrings.FirstOrDefault(d => d.Key == "GLDecreaseAccountTo").Value, out int toVal))
                    query = query.Where(d => fromVal <= d.GLDecreaseAccount && d.GLDecreaseAccount <= toVal);

			//Query GLIncreaseAccount (Nullable<int>)
			if (QueryStrings.Any(d => d.Key == "GLIncreaseAccountFrom") && QueryStrings.Any(d => d.Key == "GLIncreaseAccountTo"))
                if (int.TryParse(QueryStrings.FirstOrDefault(d => d.Key == "GLIncreaseAccountFrom").Value, out int fromVal) && int.TryParse(QueryStrings.FirstOrDefault(d => d.Key == "GLIncreaseAccountTo").Value, out int toVal))
                    query = query.Where(d => fromVal <= d.GLIncreaseAccount && d.GLIncreaseAccount <= toVal);

			//Query IsNettable (Nullable<bool>)

			//Query InventoryRevaluationAccount (Nullable<int>)
			if (QueryStrings.Any(d => d.Key == "InventoryRevaluationAccountFrom") && QueryStrings.Any(d => d.Key == "InventoryRevaluationAccountTo"))
                if (int.TryParse(QueryStrings.FirstOrDefault(d => d.Key == "InventoryRevaluationAccountFrom").Value, out int fromVal) && int.TryParse(QueryStrings.FirstOrDefault(d => d.Key == "InventoryRevaluationAccountTo").Value, out int toVal))
                    query = query.Where(d => fromVal <= d.InventoryRevaluationAccount && d.InventoryRevaluationAccount <= toVal);

			//Query InventoryRevaluationOffsetAccount (Nullable<int>)
			if (QueryStrings.Any(d => d.Key == "InventoryRevaluationOffsetAccountFrom") && QueryStrings.Any(d => d.Key == "InventoryRevaluationOffsetAccountTo"))
                if (int.TryParse(QueryStrings.FirstOrDefault(d => d.Key == "InventoryRevaluationOffsetAccountFrom").Value, out int fromVal) && int.TryParse(QueryStrings.FirstOrDefault(d => d.Key == "InventoryRevaluationOffsetAccountTo").Value, out int toVal))
                    query = query.Where(d => fromVal <= d.InventoryRevaluationOffsetAccount && d.InventoryRevaluationOffsetAccount <= toVal);

			//Query COGSRevaluationAccount (Nullable<int>)
			if (QueryStrings.Any(d => d.Key == "COGSRevaluationAccountFrom") && QueryStrings.Any(d => d.Key == "COGSRevaluationAccountTo"))
                if (int.TryParse(QueryStrings.FirstOrDefault(d => d.Key == "COGSRevaluationAccountFrom").Value, out int fromVal) && int.TryParse(QueryStrings.FirstOrDefault(d => d.Key == "COGSRevaluationAccountTo").Value, out int toVal))
                    query = query.Where(d => fromVal <= d.COGSRevaluationAccount && d.COGSRevaluationAccount <= toVal);

			//Query COGSRevaluationOffsetAccount (Nullable<int>)
			if (QueryStrings.Any(d => d.Key == "COGSRevaluationOffsetAccountFrom") && QueryStrings.Any(d => d.Key == "COGSRevaluationOffsetAccountTo"))
                if (int.TryParse(QueryStrings.FirstOrDefault(d => d.Key == "COGSRevaluationOffsetAccountFrom").Value, out int fromVal) && int.TryParse(QueryStrings.FirstOrDefault(d => d.Key == "COGSRevaluationOffsetAccountTo").Value, out int toVal))
                    query = query.Where(d => fromVal <= d.COGSRevaluationOffsetAccount && d.COGSRevaluationOffsetAccount <= toVal);

			//Query ExpenseClearingAccount (Nullable<int>)
			if (QueryStrings.Any(d => d.Key == "ExpenseClearingAccountFrom") && QueryStrings.Any(d => d.Key == "ExpenseClearingAccountTo"))
                if (int.TryParse(QueryStrings.FirstOrDefault(d => d.Key == "ExpenseClearingAccountFrom").Value, out int fromVal) && int.TryParse(QueryStrings.FirstOrDefault(d => d.Key == "ExpenseClearingAccountTo").Value, out int toVal))
                    query = query.Where(d => fromVal <= d.ExpenseClearingAccount && d.ExpenseClearingAccount <= toVal);

			//Query ExpenseOffsetAccount (Nullable<int>)
			if (QueryStrings.Any(d => d.Key == "ExpenseOffsetAccountFrom") && QueryStrings.Any(d => d.Key == "ExpenseOffsetAccountTo"))
                if (int.TryParse(QueryStrings.FirstOrDefault(d => d.Key == "ExpenseOffsetAccountFrom").Value, out int fromVal) && int.TryParse(QueryStrings.FirstOrDefault(d => d.Key == "ExpenseOffsetAccountTo").Value, out int toVal))
                    query = query.Where(d => fromVal <= d.ExpenseOffsetAccount && d.ExpenseOffsetAccount <= toVal);

			//Query SalesCreditAccount (Nullable<int>)
			if (QueryStrings.Any(d => d.Key == "SalesCreditAccountFrom") && QueryStrings.Any(d => d.Key == "SalesCreditAccountTo"))
                if (int.TryParse(QueryStrings.FirstOrDefault(d => d.Key == "SalesCreditAccountFrom").Value, out int fromVal) && int.TryParse(QueryStrings.FirstOrDefault(d => d.Key == "SalesCreditAccountTo").Value, out int toVal))
                    query = query.Where(d => fromVal <= d.SalesCreditAccount && d.SalesCreditAccount <= toVal);

			//Query SalesCreditAccountForeign (Nullable<int>)
			if (QueryStrings.Any(d => d.Key == "SalesCreditAccountForeignFrom") && QueryStrings.Any(d => d.Key == "SalesCreditAccountForeignTo"))
                if (int.TryParse(QueryStrings.FirstOrDefault(d => d.Key == "SalesCreditAccountForeignFrom").Value, out int fromVal) && int.TryParse(QueryStrings.FirstOrDefault(d => d.Key == "SalesCreditAccountForeignTo").Value, out int toVal))
                    query = query.Where(d => fromVal <= d.SalesCreditAccountForeign && d.SalesCreditAccountForeign <= toVal);

			//Query TaxExemptCreditAccount (Nullable<int>)
			if (QueryStrings.Any(d => d.Key == "TaxExemptCreditAccountFrom") && QueryStrings.Any(d => d.Key == "TaxExemptCreditAccountTo"))
                if (int.TryParse(QueryStrings.FirstOrDefault(d => d.Key == "TaxExemptCreditAccountFrom").Value, out int fromVal) && int.TryParse(QueryStrings.FirstOrDefault(d => d.Key == "TaxExemptCreditAccountTo").Value, out int toVal))
                    query = query.Where(d => fromVal <= d.TaxExemptCreditAccount && d.TaxExemptCreditAccount <= toVal);

			//Query PurchaseCreditAccount (Nullable<int>)
			if (QueryStrings.Any(d => d.Key == "PurchaseCreditAccountFrom") && QueryStrings.Any(d => d.Key == "PurchaseCreditAccountTo"))
                if (int.TryParse(QueryStrings.FirstOrDefault(d => d.Key == "PurchaseCreditAccountFrom").Value, out int fromVal) && int.TryParse(QueryStrings.FirstOrDefault(d => d.Key == "PurchaseCreditAccountTo").Value, out int toVal))
                    query = query.Where(d => fromVal <= d.PurchaseCreditAccount && d.PurchaseCreditAccount <= toVal);

			//Query PurchaseCreditAccountForeign (Nullable<int>)
			if (QueryStrings.Any(d => d.Key == "PurchaseCreditAccountForeignFrom") && QueryStrings.Any(d => d.Key == "PurchaseCreditAccountForeignTo"))
                if (int.TryParse(QueryStrings.FirstOrDefault(d => d.Key == "PurchaseCreditAccountForeignFrom").Value, out int fromVal) && int.TryParse(QueryStrings.FirstOrDefault(d => d.Key == "PurchaseCreditAccountForeignTo").Value, out int toVal))
                    query = query.Where(d => fromVal <= d.PurchaseCreditAccountForeign && d.PurchaseCreditAccountForeign <= toVal);

			//Query RevenueReturnsAccount (Nullable<int>)
			if (QueryStrings.Any(d => d.Key == "RevenueReturnsAccountFrom") && QueryStrings.Any(d => d.Key == "RevenueReturnsAccountTo"))
                if (int.TryParse(QueryStrings.FirstOrDefault(d => d.Key == "RevenueReturnsAccountFrom").Value, out int fromVal) && int.TryParse(QueryStrings.FirstOrDefault(d => d.Key == "RevenueReturnsAccountTo").Value, out int toVal))
                    query = query.Where(d => fromVal <= d.RevenueReturnsAccount && d.RevenueReturnsAccount <= toVal);

			//Query NegativeInventoryAdjustmentAccount (Nullable<int>)
			if (QueryStrings.Any(d => d.Key == "NegativeInventoryAdjustmentAccountFrom") && QueryStrings.Any(d => d.Key == "NegativeInventoryAdjustmentAccountTo"))
                if (int.TryParse(QueryStrings.FirstOrDefault(d => d.Key == "NegativeInventoryAdjustmentAccountFrom").Value, out int fromVal) && int.TryParse(QueryStrings.FirstOrDefault(d => d.Key == "NegativeInventoryAdjustmentAccountTo").Value, out int toVal))
                    query = query.Where(d => fromVal <= d.NegativeInventoryAdjustmentAccount && d.NegativeInventoryAdjustmentAccount <= toVal);

			//Query StockInTransitAccount (Nullable<int>)
			if (QueryStrings.Any(d => d.Key == "StockInTransitAccountFrom") && QueryStrings.Any(d => d.Key == "StockInTransitAccountTo"))
                if (int.TryParse(QueryStrings.FirstOrDefault(d => d.Key == "StockInTransitAccountFrom").Value, out int fromVal) && int.TryParse(QueryStrings.FirstOrDefault(d => d.Key == "StockInTransitAccountTo").Value, out int toVal))
                    query = query.Where(d => fromVal <= d.StockInTransitAccount && d.StockInTransitAccount <= toVal);

			//Query PurchaseBalanceAccount (Nullable<int>)
			if (QueryStrings.Any(d => d.Key == "PurchaseBalanceAccountFrom") && QueryStrings.Any(d => d.Key == "PurchaseBalanceAccountTo"))
                if (int.TryParse(QueryStrings.FirstOrDefault(d => d.Key == "PurchaseBalanceAccountFrom").Value, out int fromVal) && int.TryParse(QueryStrings.FirstOrDefault(d => d.Key == "PurchaseBalanceAccountTo").Value, out int toVal))
                    query = query.Where(d => fromVal <= d.PurchaseBalanceAccount && d.PurchaseBalanceAccount <= toVal);

			//Query InventoryOffsetPLAccount (Nullable<int>)
			if (QueryStrings.Any(d => d.Key == "InventoryOffsetPLAccountFrom") && QueryStrings.Any(d => d.Key == "InventoryOffsetPLAccountTo"))
                if (int.TryParse(QueryStrings.FirstOrDefault(d => d.Key == "InventoryOffsetPLAccountFrom").Value, out int fromVal) && int.TryParse(QueryStrings.FirstOrDefault(d => d.Key == "InventoryOffsetPLAccountTo").Value, out int toVal))
                    query = query.Where(d => fromVal <= d.InventoryOffsetPLAccount && d.InventoryOffsetPLAccount <= toVal);

			//Query Storekeeper (Nullable<int>)
			if (QueryStrings.Any(d => d.Key == "StorekeeperFrom") && QueryStrings.Any(d => d.Key == "StorekeeperTo"))
                if (int.TryParse(QueryStrings.FirstOrDefault(d => d.Key == "StorekeeperFrom").Value, out int fromVal) && int.TryParse(QueryStrings.FirstOrDefault(d => d.Key == "StorekeeperTo").Value, out int toVal))
                    query = query.Where(d => fromVal <= d.Storekeeper && d.Storekeeper <= toVal);

			//Query IsBinActivated (Nullable<bool>)

			//Query BinSeparator (string)
			if (QueryStrings.Any(d => d.Key == "BinSeparator_eq") && !string.IsNullOrEmpty(QueryStrings.FirstOrDefault(d => d.Key == "BinSeparator_eq").Value))
            {
                var keyword = QueryStrings.FirstOrDefault(d => d.Key == "BinSeparator_eq").Value;
                query = query.Where(d=>d.BinSeparator == keyword);
            }
            if (QueryStrings.Any(d => d.Key == "BinSeparator") && !string.IsNullOrEmpty(QueryStrings.FirstOrDefault(d => d.Key == "BinSeparator").Value))
            {
                var keyword = QueryStrings.FirstOrDefault(d => d.Key == "BinSeparator").Value;
                query = query.Where(d=>d.BinSeparator.Contains(keyword));
            }
            

			//Query DefaultBinInternalNumber (Nullable<int>)
			if (QueryStrings.Any(d => d.Key == "DefaultBinInternalNumberFrom") && QueryStrings.Any(d => d.Key == "DefaultBinInternalNumberTo"))
                if (int.TryParse(QueryStrings.FirstOrDefault(d => d.Key == "DefaultBinInternalNumberFrom").Value, out int fromVal) && int.TryParse(QueryStrings.FirstOrDefault(d => d.Key == "DefaultBinInternalNumberTo").Value, out int toVal))
                    query = query.Where(d => fromVal <= d.DefaultBinInternalNumber && d.DefaultBinInternalNumber <= toVal);

			//Query GlobalLocationNumber (string)
			if (QueryStrings.Any(d => d.Key == "GlobalLocationNumber_eq") && !string.IsNullOrEmpty(QueryStrings.FirstOrDefault(d => d.Key == "GlobalLocationNumber_eq").Value))
            {
                var keyword = QueryStrings.FirstOrDefault(d => d.Key == "GlobalLocationNumber_eq").Value;
                query = query.Where(d=>d.GlobalLocationNumber == keyword);
            }
            if (QueryStrings.Any(d => d.Key == "GlobalLocationNumber") && !string.IsNullOrEmpty(QueryStrings.FirstOrDefault(d => d.Key == "GlobalLocationNumber").Value))
            {
                var keyword = QueryStrings.FirstOrDefault(d => d.Key == "GlobalLocationNumber").Value;
                query = query.Where(d=>d.GlobalLocationNumber.Contains(keyword));
            }
            

			//Query FreeOfChargeSalesAccount (Nullable<int>)
			if (QueryStrings.Any(d => d.Key == "FreeOfChargeSalesAccountFrom") && QueryStrings.Any(d => d.Key == "FreeOfChargeSalesAccountTo"))
                if (int.TryParse(QueryStrings.FirstOrDefault(d => d.Key == "FreeOfChargeSalesAccountFrom").Value, out int fromVal) && int.TryParse(QueryStrings.FirstOrDefault(d => d.Key == "FreeOfChargeSalesAccountTo").Value, out int toVal))
                    query = query.Where(d => fromVal <= d.FreeOfChargeSalesAccount && d.FreeOfChargeSalesAccount <= toVal);

			//Query FreeOfChargePurchaseAccount (Nullable<int>)
			if (QueryStrings.Any(d => d.Key == "FreeOfChargePurchaseAccountFrom") && QueryStrings.Any(d => d.Key == "FreeOfChargePurchaseAccountTo"))
                if (int.TryParse(QueryStrings.FirstOrDefault(d => d.Key == "FreeOfChargePurchaseAccountFrom").Value, out int fromVal) && int.TryParse(QueryStrings.FirstOrDefault(d => d.Key == "FreeOfChargePurchaseAccountTo").Value, out int toVal))
                    query = query.Where(d => fromVal <= d.FreeOfChargePurchaseAccount && d.FreeOfChargePurchaseAccount <= toVal);
            return query;
        }
		
        public static IQueryable<tbl_WMS_WarehouseInfo> _sortBuilder(IQueryable<tbl_WMS_WarehouseInfo> query, Dictionary<string, string> QueryStrings)
        {
            if (QueryStrings.Any(d => d.Key == "SortBy"))
            {
                var sorts = QueryStrings.FirstOrDefault(d => d.Key == "SortBy").Value.Replace("[", "").Replace("]", "").Split(',');
                
                foreach (var item in sorts)
                    if (!string.IsNullOrEmpty(item))
                    {
                        var ordered = query as IOrderedQueryable<tbl_WMS_WarehouseInfo>;
                        bool isOrdered = ordered.ToString().IndexOf("ORDER BY") !=-1;

                        switch (item)
                        {
							case "IDBranch":
								query = isOrdered ? ordered.ThenBy(o => o.IDBranch) : query.OrderBy(o => o.IDBranch);
								 break;
							case "IDBranch_desc":
                                query = isOrdered ? ordered.ThenByDescending(o => o.IDBranch) : query.OrderByDescending(o => o.IDBranch);
                                break;
							case "Id":
								query = isOrdered ? ordered.ThenBy(o => o.Id) : query.OrderBy(o => o.Id);
								 break;
							case "Id_desc":
                                query = isOrdered ? ordered.ThenByDescending(o => o.Id) : query.OrderByDescending(o => o.Id);
                                break;
							case "Code":
								query = isOrdered ? ordered.ThenBy(o => o.Code) : query.OrderBy(o => o.Code);
								 break;
							case "Code_desc":
                                query = isOrdered ? ordered.ThenByDescending(o => o.Code) : query.OrderByDescending(o => o.Code);
                                break;
							case "Name":
								query = isOrdered ? ordered.ThenBy(o => o.Name) : query.OrderBy(o => o.Name);
								 break;
							case "Name_desc":
                                query = isOrdered ? ordered.ThenByDescending(o => o.Name) : query.OrderByDescending(o => o.Name);
                                break;
							case "Remark":
								query = isOrdered ? ordered.ThenBy(o => o.Remark) : query.OrderBy(o => o.Remark);
								 break;
							case "Remark_desc":
                                query = isOrdered ? ordered.ThenByDescending(o => o.Remark) : query.OrderByDescending(o => o.Remark);
                                break;
							case "Sort":
								query = isOrdered ? ordered.ThenBy(o => o.Sort) : query.OrderBy(o => o.Sort);
								 break;
							case "Sort_desc":
                                query = isOrdered ? ordered.ThenByDescending(o => o.Sort) : query.OrderByDescending(o => o.Sort);
                                break;
							case "IsDisabled":
								query = isOrdered ? ordered.ThenBy(o => o.IsDisabled) : query.OrderBy(o => o.IsDisabled);
								 break;
							case "IsDisabled_desc":
                                query = isOrdered ? ordered.ThenByDescending(o => o.IsDisabled) : query.OrderByDescending(o => o.IsDisabled);
                                break;
							case "IsDeleted":
								query = isOrdered ? ordered.ThenBy(o => o.IsDeleted) : query.OrderBy(o => o.IsDeleted);
								 break;
							case "IsDeleted_desc":
                                query = isOrdered ? ordered.ThenByDescending(o => o.IsDeleted) : query.OrderByDescending(o => o.IsDeleted);
                                break;
							case "CreatedBy":
								query = isOrdered ? ordered.ThenBy(o => o.CreatedBy) : query.OrderBy(o => o.CreatedBy);
								 break;
							case "CreatedBy_desc":
                                query = isOrdered ? ordered.ThenByDescending(o => o.CreatedBy) : query.OrderByDescending(o => o.CreatedBy);
                                break;
							case "ModifiedBy":
								query = isOrdered ? ordered.ThenBy(o => o.ModifiedBy) : query.OrderBy(o => o.ModifiedBy);
								 break;
							case "ModifiedBy_desc":
                                query = isOrdered ? ordered.ThenByDescending(o => o.ModifiedBy) : query.OrderByDescending(o => o.ModifiedBy);
                                break;
							case "CreatedDate":
								query = isOrdered ? ordered.ThenBy(o => o.CreatedDate) : query.OrderBy(o => o.CreatedDate);
								 break;
							case "CreatedDate_desc":
                                query = isOrdered ? ordered.ThenByDescending(o => o.CreatedDate) : query.OrderByDescending(o => o.CreatedDate);
                                break;
							case "ModifiedDate":
								query = isOrdered ? ordered.ThenBy(o => o.ModifiedDate) : query.OrderBy(o => o.ModifiedDate);
								 break;
							case "ModifiedDate_desc":
                                query = isOrdered ? ordered.ThenByDescending(o => o.ModifiedDate) : query.OrderByDescending(o => o.ModifiedDate);
                                break;
							case "IsLocked":
								query = isOrdered ? ordered.ThenBy(o => o.IsLocked) : query.OrderBy(o => o.IsLocked);
								 break;
							case "IsLocked_desc":
                                query = isOrdered ? ordered.ThenByDescending(o => o.IsLocked) : query.OrderByDescending(o => o.IsLocked);
                                break;
							case "InventoryAccount":
								query = isOrdered ? ordered.ThenBy(o => o.InventoryAccount) : query.OrderBy(o => o.InventoryAccount);
								 break;
							case "InventoryAccount_desc":
                                query = isOrdered ? ordered.ThenByDescending(o => o.InventoryAccount) : query.OrderByDescending(o => o.InventoryAccount);
                                break;
							case "CostOfGoodsSoldAccount":
								query = isOrdered ? ordered.ThenBy(o => o.CostOfGoodsSoldAccount) : query.OrderBy(o => o.CostOfGoodsSoldAccount);
								 break;
							case "CostOfGoodsSoldAccount_desc":
                                query = isOrdered ? ordered.ThenByDescending(o => o.CostOfGoodsSoldAccount) : query.OrderByDescending(o => o.CostOfGoodsSoldAccount);
                                break;
							case "AllocationAccount":
								query = isOrdered ? ordered.ThenBy(o => o.AllocationAccount) : query.OrderBy(o => o.AllocationAccount);
								 break;
							case "AllocationAccount_desc":
                                query = isOrdered ? ordered.ThenByDescending(o => o.AllocationAccount) : query.OrderByDescending(o => o.AllocationAccount);
                                break;
							case "RevenueAccount":
								query = isOrdered ? ordered.ThenBy(o => o.RevenueAccount) : query.OrderBy(o => o.RevenueAccount);
								 break;
							case "RevenueAccount_desc":
                                query = isOrdered ? ordered.ThenByDescending(o => o.RevenueAccount) : query.OrderByDescending(o => o.RevenueAccount);
                                break;
							case "VarianceAccount":
								query = isOrdered ? ordered.ThenBy(o => o.VarianceAccount) : query.OrderBy(o => o.VarianceAccount);
								 break;
							case "VarianceAccount_desc":
                                query = isOrdered ? ordered.ThenByDescending(o => o.VarianceAccount) : query.OrderByDescending(o => o.VarianceAccount);
                                break;
							case "InventoryOffsetDecreaseAccount":
								query = isOrdered ? ordered.ThenBy(o => o.InventoryOffsetDecreaseAccount) : query.OrderBy(o => o.InventoryOffsetDecreaseAccount);
								 break;
							case "InventoryOffsetDecreaseAccount_desc":
                                query = isOrdered ? ordered.ThenByDescending(o => o.InventoryOffsetDecreaseAccount) : query.OrderByDescending(o => o.InventoryOffsetDecreaseAccount);
                                break;
							case "InventoryOffsetIncreaseAccount":
								query = isOrdered ? ordered.ThenBy(o => o.InventoryOffsetIncreaseAccount) : query.OrderBy(o => o.InventoryOffsetIncreaseAccount);
								 break;
							case "InventoryOffsetIncreaseAccount_desc":
                                query = isOrdered ? ordered.ThenByDescending(o => o.InventoryOffsetIncreaseAccount) : query.OrderByDescending(o => o.InventoryOffsetIncreaseAccount);
                                break;
							case "SalesReturnsAccount":
								query = isOrdered ? ordered.ThenBy(o => o.SalesReturnsAccount) : query.OrderBy(o => o.SalesReturnsAccount);
								 break;
							case "SalesReturnsAccount_desc":
                                query = isOrdered ? ordered.ThenByDescending(o => o.SalesReturnsAccount) : query.OrderByDescending(o => o.SalesReturnsAccount);
                                break;
							case "ExpenseAccount":
								query = isOrdered ? ordered.ThenBy(o => o.ExpenseAccount) : query.OrderBy(o => o.ExpenseAccount);
								 break;
							case "ExpenseAccount_desc":
                                query = isOrdered ? ordered.ThenByDescending(o => o.ExpenseAccount) : query.OrderByDescending(o => o.ExpenseAccount);
                                break;
							case "RevenueAccountForeign":
								query = isOrdered ? ordered.ThenBy(o => o.RevenueAccountForeign) : query.OrderBy(o => o.RevenueAccountForeign);
								 break;
							case "RevenueAccountForeign_desc":
                                query = isOrdered ? ordered.ThenByDescending(o => o.RevenueAccountForeign) : query.OrderByDescending(o => o.RevenueAccountForeign);
                                break;
							case "ExpenseAccountForeign":
								query = isOrdered ? ordered.ThenBy(o => o.ExpenseAccountForeign) : query.OrderBy(o => o.ExpenseAccountForeign);
								 break;
							case "ExpenseAccountForeign_desc":
                                query = isOrdered ? ordered.ThenByDescending(o => o.ExpenseAccountForeign) : query.OrderByDescending(o => o.ExpenseAccountForeign);
                                break;
							case "TaxGroup":
								query = isOrdered ? ordered.ThenBy(o => o.TaxGroup) : query.OrderBy(o => o.TaxGroup);
								 break;
							case "TaxGroup_desc":
                                query = isOrdered ? ordered.ThenByDescending(o => o.TaxGroup) : query.OrderByDescending(o => o.TaxGroup);
                                break;
							case "IsDropShip":
								query = isOrdered ? ordered.ThenBy(o => o.IsDropShip) : query.OrderBy(o => o.IsDropShip);
								 break;
							case "IsDropShip_desc":
                                query = isOrdered ? ordered.ThenByDescending(o => o.IsDropShip) : query.OrderByDescending(o => o.IsDropShip);
                                break;
							case "ExemptRevenueAccount":
								query = isOrdered ? ordered.ThenBy(o => o.ExemptRevenueAccount) : query.OrderBy(o => o.ExemptRevenueAccount);
								 break;
							case "ExemptRevenueAccount_desc":
                                query = isOrdered ? ordered.ThenByDescending(o => o.ExemptRevenueAccount) : query.OrderByDescending(o => o.ExemptRevenueAccount);
                                break;
							case "IsAllowUseTax":
								query = isOrdered ? ordered.ThenBy(o => o.IsAllowUseTax) : query.OrderBy(o => o.IsAllowUseTax);
								 break;
							case "IsAllowUseTax_desc":
                                query = isOrdered ? ordered.ThenByDescending(o => o.IsAllowUseTax) : query.OrderByDescending(o => o.IsAllowUseTax);
                                break;
							case "PriceDifferenceAccount":
								query = isOrdered ? ordered.ThenBy(o => o.PriceDifferenceAccount) : query.OrderBy(o => o.PriceDifferenceAccount);
								 break;
							case "PriceDifferenceAccount_desc":
                                query = isOrdered ? ordered.ThenByDescending(o => o.PriceDifferenceAccount) : query.OrderByDescending(o => o.PriceDifferenceAccount);
                                break;
							case "ExchangeRateDifferencesAccount":
								query = isOrdered ? ordered.ThenBy(o => o.ExchangeRateDifferencesAccount) : query.OrderBy(o => o.ExchangeRateDifferencesAccount);
								 break;
							case "ExchangeRateDifferencesAccount_desc":
                                query = isOrdered ? ordered.ThenByDescending(o => o.ExchangeRateDifferencesAccount) : query.OrderByDescending(o => o.ExchangeRateDifferencesAccount);
                                break;
							case "GoodsClearingAccount":
								query = isOrdered ? ordered.ThenBy(o => o.GoodsClearingAccount) : query.OrderBy(o => o.GoodsClearingAccount);
								 break;
							case "GoodsClearingAccount_desc":
                                query = isOrdered ? ordered.ThenByDescending(o => o.GoodsClearingAccount) : query.OrderByDescending(o => o.GoodsClearingAccount);
                                break;
							case "PurchaseAccount":
								query = isOrdered ? ordered.ThenBy(o => o.PurchaseAccount) : query.OrderBy(o => o.PurchaseAccount);
								 break;
							case "PurchaseAccount_desc":
                                query = isOrdered ? ordered.ThenByDescending(o => o.PurchaseAccount) : query.OrderByDescending(o => o.PurchaseAccount);
                                break;
							case "PurchaseReturnAccount":
								query = isOrdered ? ordered.ThenBy(o => o.PurchaseReturnAccount) : query.OrderBy(o => o.PurchaseReturnAccount);
								 break;
							case "PurchaseReturnAccount_desc":
                                query = isOrdered ? ordered.ThenByDescending(o => o.PurchaseReturnAccount) : query.OrderByDescending(o => o.PurchaseReturnAccount);
                                break;
							case "PurchaseOffsetAccount":
								query = isOrdered ? ordered.ThenBy(o => o.PurchaseOffsetAccount) : query.OrderBy(o => o.PurchaseOffsetAccount);
								 break;
							case "PurchaseOffsetAccount_desc":
                                query = isOrdered ? ordered.ThenByDescending(o => o.PurchaseOffsetAccount) : query.OrderByDescending(o => o.PurchaseOffsetAccount);
                                break;
							case "ShippedGoodsAccount":
								query = isOrdered ? ordered.ThenBy(o => o.ShippedGoodsAccount) : query.OrderBy(o => o.ShippedGoodsAccount);
								 break;
							case "ShippedGoodsAccount_desc":
                                query = isOrdered ? ordered.ThenByDescending(o => o.ShippedGoodsAccount) : query.OrderByDescending(o => o.ShippedGoodsAccount);
                                break;
							case "VATinRevenueAccount":
								query = isOrdered ? ordered.ThenBy(o => o.VATinRevenueAccount) : query.OrderBy(o => o.VATinRevenueAccount);
								 break;
							case "VATinRevenueAccount_desc":
                                query = isOrdered ? ordered.ThenByDescending(o => o.VATinRevenueAccount) : query.OrderByDescending(o => o.VATinRevenueAccount);
                                break;
							case "GLDecreaseAccount":
								query = isOrdered ? ordered.ThenBy(o => o.GLDecreaseAccount) : query.OrderBy(o => o.GLDecreaseAccount);
								 break;
							case "GLDecreaseAccount_desc":
                                query = isOrdered ? ordered.ThenByDescending(o => o.GLDecreaseAccount) : query.OrderByDescending(o => o.GLDecreaseAccount);
                                break;
							case "GLIncreaseAccount":
								query = isOrdered ? ordered.ThenBy(o => o.GLIncreaseAccount) : query.OrderBy(o => o.GLIncreaseAccount);
								 break;
							case "GLIncreaseAccount_desc":
                                query = isOrdered ? ordered.ThenByDescending(o => o.GLIncreaseAccount) : query.OrderByDescending(o => o.GLIncreaseAccount);
                                break;
							case "IsNettable":
								query = isOrdered ? ordered.ThenBy(o => o.IsNettable) : query.OrderBy(o => o.IsNettable);
								 break;
							case "IsNettable_desc":
                                query = isOrdered ? ordered.ThenByDescending(o => o.IsNettable) : query.OrderByDescending(o => o.IsNettable);
                                break;
							case "InventoryRevaluationAccount":
								query = isOrdered ? ordered.ThenBy(o => o.InventoryRevaluationAccount) : query.OrderBy(o => o.InventoryRevaluationAccount);
								 break;
							case "InventoryRevaluationAccount_desc":
                                query = isOrdered ? ordered.ThenByDescending(o => o.InventoryRevaluationAccount) : query.OrderByDescending(o => o.InventoryRevaluationAccount);
                                break;
							case "InventoryRevaluationOffsetAccount":
								query = isOrdered ? ordered.ThenBy(o => o.InventoryRevaluationOffsetAccount) : query.OrderBy(o => o.InventoryRevaluationOffsetAccount);
								 break;
							case "InventoryRevaluationOffsetAccount_desc":
                                query = isOrdered ? ordered.ThenByDescending(o => o.InventoryRevaluationOffsetAccount) : query.OrderByDescending(o => o.InventoryRevaluationOffsetAccount);
                                break;
							case "COGSRevaluationAccount":
								query = isOrdered ? ordered.ThenBy(o => o.COGSRevaluationAccount) : query.OrderBy(o => o.COGSRevaluationAccount);
								 break;
							case "COGSRevaluationAccount_desc":
                                query = isOrdered ? ordered.ThenByDescending(o => o.COGSRevaluationAccount) : query.OrderByDescending(o => o.COGSRevaluationAccount);
                                break;
							case "COGSRevaluationOffsetAccount":
								query = isOrdered ? ordered.ThenBy(o => o.COGSRevaluationOffsetAccount) : query.OrderBy(o => o.COGSRevaluationOffsetAccount);
								 break;
							case "COGSRevaluationOffsetAccount_desc":
                                query = isOrdered ? ordered.ThenByDescending(o => o.COGSRevaluationOffsetAccount) : query.OrderByDescending(o => o.COGSRevaluationOffsetAccount);
                                break;
							case "ExpenseClearingAccount":
								query = isOrdered ? ordered.ThenBy(o => o.ExpenseClearingAccount) : query.OrderBy(o => o.ExpenseClearingAccount);
								 break;
							case "ExpenseClearingAccount_desc":
                                query = isOrdered ? ordered.ThenByDescending(o => o.ExpenseClearingAccount) : query.OrderByDescending(o => o.ExpenseClearingAccount);
                                break;
							case "ExpenseOffsetAccount":
								query = isOrdered ? ordered.ThenBy(o => o.ExpenseOffsetAccount) : query.OrderBy(o => o.ExpenseOffsetAccount);
								 break;
							case "ExpenseOffsetAccount_desc":
                                query = isOrdered ? ordered.ThenByDescending(o => o.ExpenseOffsetAccount) : query.OrderByDescending(o => o.ExpenseOffsetAccount);
                                break;
							case "SalesCreditAccount":
								query = isOrdered ? ordered.ThenBy(o => o.SalesCreditAccount) : query.OrderBy(o => o.SalesCreditAccount);
								 break;
							case "SalesCreditAccount_desc":
                                query = isOrdered ? ordered.ThenByDescending(o => o.SalesCreditAccount) : query.OrderByDescending(o => o.SalesCreditAccount);
                                break;
							case "SalesCreditAccountForeign":
								query = isOrdered ? ordered.ThenBy(o => o.SalesCreditAccountForeign) : query.OrderBy(o => o.SalesCreditAccountForeign);
								 break;
							case "SalesCreditAccountForeign_desc":
                                query = isOrdered ? ordered.ThenByDescending(o => o.SalesCreditAccountForeign) : query.OrderByDescending(o => o.SalesCreditAccountForeign);
                                break;
							case "TaxExemptCreditAccount":
								query = isOrdered ? ordered.ThenBy(o => o.TaxExemptCreditAccount) : query.OrderBy(o => o.TaxExemptCreditAccount);
								 break;
							case "TaxExemptCreditAccount_desc":
                                query = isOrdered ? ordered.ThenByDescending(o => o.TaxExemptCreditAccount) : query.OrderByDescending(o => o.TaxExemptCreditAccount);
                                break;
							case "PurchaseCreditAccount":
								query = isOrdered ? ordered.ThenBy(o => o.PurchaseCreditAccount) : query.OrderBy(o => o.PurchaseCreditAccount);
								 break;
							case "PurchaseCreditAccount_desc":
                                query = isOrdered ? ordered.ThenByDescending(o => o.PurchaseCreditAccount) : query.OrderByDescending(o => o.PurchaseCreditAccount);
                                break;
							case "PurchaseCreditAccountForeign":
								query = isOrdered ? ordered.ThenBy(o => o.PurchaseCreditAccountForeign) : query.OrderBy(o => o.PurchaseCreditAccountForeign);
								 break;
							case "PurchaseCreditAccountForeign_desc":
                                query = isOrdered ? ordered.ThenByDescending(o => o.PurchaseCreditAccountForeign) : query.OrderByDescending(o => o.PurchaseCreditAccountForeign);
                                break;
							case "RevenueReturnsAccount":
								query = isOrdered ? ordered.ThenBy(o => o.RevenueReturnsAccount) : query.OrderBy(o => o.RevenueReturnsAccount);
								 break;
							case "RevenueReturnsAccount_desc":
                                query = isOrdered ? ordered.ThenByDescending(o => o.RevenueReturnsAccount) : query.OrderByDescending(o => o.RevenueReturnsAccount);
                                break;
							case "NegativeInventoryAdjustmentAccount":
								query = isOrdered ? ordered.ThenBy(o => o.NegativeInventoryAdjustmentAccount) : query.OrderBy(o => o.NegativeInventoryAdjustmentAccount);
								 break;
							case "NegativeInventoryAdjustmentAccount_desc":
                                query = isOrdered ? ordered.ThenByDescending(o => o.NegativeInventoryAdjustmentAccount) : query.OrderByDescending(o => o.NegativeInventoryAdjustmentAccount);
                                break;
							case "StockInTransitAccount":
								query = isOrdered ? ordered.ThenBy(o => o.StockInTransitAccount) : query.OrderBy(o => o.StockInTransitAccount);
								 break;
							case "StockInTransitAccount_desc":
                                query = isOrdered ? ordered.ThenByDescending(o => o.StockInTransitAccount) : query.OrderByDescending(o => o.StockInTransitAccount);
                                break;
							case "PurchaseBalanceAccount":
								query = isOrdered ? ordered.ThenBy(o => o.PurchaseBalanceAccount) : query.OrderBy(o => o.PurchaseBalanceAccount);
								 break;
							case "PurchaseBalanceAccount_desc":
                                query = isOrdered ? ordered.ThenByDescending(o => o.PurchaseBalanceAccount) : query.OrderByDescending(o => o.PurchaseBalanceAccount);
                                break;
							case "InventoryOffsetPLAccount":
								query = isOrdered ? ordered.ThenBy(o => o.InventoryOffsetPLAccount) : query.OrderBy(o => o.InventoryOffsetPLAccount);
								 break;
							case "InventoryOffsetPLAccount_desc":
                                query = isOrdered ? ordered.ThenByDescending(o => o.InventoryOffsetPLAccount) : query.OrderByDescending(o => o.InventoryOffsetPLAccount);
                                break;
							case "Storekeeper":
								query = isOrdered ? ordered.ThenBy(o => o.Storekeeper) : query.OrderBy(o => o.Storekeeper);
								 break;
							case "Storekeeper_desc":
                                query = isOrdered ? ordered.ThenByDescending(o => o.Storekeeper) : query.OrderByDescending(o => o.Storekeeper);
                                break;
							case "IsBinActivated":
								query = isOrdered ? ordered.ThenBy(o => o.IsBinActivated) : query.OrderBy(o => o.IsBinActivated);
								 break;
							case "IsBinActivated_desc":
                                query = isOrdered ? ordered.ThenByDescending(o => o.IsBinActivated) : query.OrderByDescending(o => o.IsBinActivated);
                                break;
							case "BinSeparator":
								query = isOrdered ? ordered.ThenBy(o => o.BinSeparator) : query.OrderBy(o => o.BinSeparator);
								 break;
							case "BinSeparator_desc":
                                query = isOrdered ? ordered.ThenByDescending(o => o.BinSeparator) : query.OrderByDescending(o => o.BinSeparator);
                                break;
							case "DefaultBinInternalNumber":
								query = isOrdered ? ordered.ThenBy(o => o.DefaultBinInternalNumber) : query.OrderBy(o => o.DefaultBinInternalNumber);
								 break;
							case "DefaultBinInternalNumber_desc":
                                query = isOrdered ? ordered.ThenByDescending(o => o.DefaultBinInternalNumber) : query.OrderByDescending(o => o.DefaultBinInternalNumber);
                                break;
							case "GlobalLocationNumber":
								query = isOrdered ? ordered.ThenBy(o => o.GlobalLocationNumber) : query.OrderBy(o => o.GlobalLocationNumber);
								 break;
							case "GlobalLocationNumber_desc":
                                query = isOrdered ? ordered.ThenByDescending(o => o.GlobalLocationNumber) : query.OrderByDescending(o => o.GlobalLocationNumber);
                                break;
							case "FreeOfChargeSalesAccount":
								query = isOrdered ? ordered.ThenBy(o => o.FreeOfChargeSalesAccount) : query.OrderBy(o => o.FreeOfChargeSalesAccount);
								 break;
							case "FreeOfChargeSalesAccount_desc":
                                query = isOrdered ? ordered.ThenByDescending(o => o.FreeOfChargeSalesAccount) : query.OrderByDescending(o => o.FreeOfChargeSalesAccount);
                                break;
							case "FreeOfChargePurchaseAccount":
								query = isOrdered ? ordered.ThenBy(o => o.FreeOfChargePurchaseAccount) : query.OrderBy(o => o.FreeOfChargePurchaseAccount);
								 break;
							case "FreeOfChargePurchaseAccount_desc":
                                query = isOrdered ? ordered.ThenByDescending(o => o.FreeOfChargePurchaseAccount) : query.OrderByDescending(o => o.FreeOfChargePurchaseAccount);
                                break;
                            default:
                                if(!isOrdered)
                                    query = query.OrderBy(o => o.Sort == null).ThenBy(u => u.Sort);
                                break;
                        }
                    }
                    else
                    {
                        query = query.OrderBy(o => o.Sort == null).ThenBy(u => u.Sort);
                    }
            }
            else
            {
                query = query.OrderBy(o => o.Sort == null).ThenBy(u => u.Sort);
            }

            return query;
        }

        public static IQueryable<tbl_WMS_WarehouseInfo> _pagingBuilder(IQueryable<tbl_WMS_WarehouseInfo> query, Dictionary<string, string> QueryStrings)
        {
            int skip = 0;
            int take = 200;
            if (QueryStrings.Any(d => d.Key == "Skip"))
            {
                int.TryParse(QueryStrings.FirstOrDefault(d => d.Key == "Skip").Value, out skip);
            }
            if (QueryStrings.Any(d => d.Key == "Take"))
            {
                int.TryParse(QueryStrings.FirstOrDefault(d => d.Key == "Take").Value, out take);
            }

            query = query.Skip(skip).Take(take);
            return query;
        }

    }

}






