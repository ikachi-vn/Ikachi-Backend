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
    
    
    public partial class tbl_WH_VTB_Statements
    {
        public int Id { get; set; }
        public Nullable<System.DateTime> TransactionDate { get; set; }
        public string TransactionContent { get; set; }
        public Nullable<decimal> Debit { get; set; }
        public Nullable<decimal> Credit { get; set; }
        public Nullable<decimal> AccountBalance { get; set; }
        public string TransactionNumber { get; set; }
        public string CorresponsiveAccount { get; set; }
        public string CorresponsiveAccountName { get; set; }
        public string Agency { get; set; }
        public Nullable<int> CorresponsiveBankID { get; set; }
        public string CorresponsiveBankName { get; set; }
        public Nullable<int> ServiceBranchID { get; set; }
        public string ServiceBranchName { get; set; }
        public string Channel { get; set; }
        public Nullable<int> Sort { get; set; }
        public bool IsDisabled { get; set; }
        public bool IsDeleted { get; set; }
        public string CreatedBy { get; set; }
        public System.DateTime CreatedDate { get; set; }
        public string ModifiedBy { get; set; }
        public System.DateTime ModifiedDate { get; set; }
    }
}


namespace DTOModel
{
	using System;
	public partial class DTO_WH_VTB_Statements
	{
		public int Id { get; set; }
		public Nullable<System.DateTime> TransactionDate { get; set; }
		public string TransactionContent { get; set; }
		public Nullable<decimal> Debit { get; set; }
		public Nullable<decimal> Credit { get; set; }
		public Nullable<decimal> AccountBalance { get; set; }
		public string TransactionNumber { get; set; }
		public string CorresponsiveAccount { get; set; }
		public string CorresponsiveAccountName { get; set; }
		public string Agency { get; set; }
		public Nullable<int> CorresponsiveBankID { get; set; }
		public string CorresponsiveBankName { get; set; }
		public Nullable<int> ServiceBranchID { get; set; }
		public string ServiceBranchName { get; set; }
		public string Channel { get; set; }
		public Nullable<int> Sort { get; set; }
		public bool IsDisabled { get; set; }
		public bool IsDeleted { get; set; }
		public string CreatedBy { get; set; }
		public System.DateTime CreatedDate { get; set; }
		public string ModifiedBy { get; set; }
		public System.DateTime ModifiedDate { get; set; }
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

    public static partial class BS_WH_VTB_Statements 
    {
        public static dynamic getSearch(AppEntities db, int IDBranch, int StaffID, Dictionary<string, string> QueryStrings)
        {
            return get(db, IDBranch,StaffID, QueryStrings);
        }

		public static IQueryable<DTO_WH_VTB_Statements> get(AppEntities db, int IDBranch, int StaffID, Dictionary<string, string> QueryStrings)
        {
			var query = _queryBuilder(db, IDBranch, StaffID, QueryStrings);
            query = _sortBuilder(query, QueryStrings);
            query = _pagingBuilder(query, QueryStrings);

			return toDTO(query);
        }

        public static List<ItemModel> getValidateData(AppEntities db, int IDBranch, int StaffID, Dictionary<string, string> QueryStrings)
        {
            return get(db, IDBranch, StaffID, QueryStrings).Select(s => new ItemModel { 
                Id = s.Id, }).ToList();
        }

        public static string export(ExcelPackage package, AppEntities db, int IDBranch, int StaffID, Dictionary<string, string> QueryStrings)
        {
            package.Workbook.Properties.Title = "ART-DMS WH_VTB_Statements";
            package.Workbook.Properties.Author = "hung.vu@codeart.vn";
            package.Workbook.Properties.Application = "ART-DMS";
            package.Workbook.Properties.Company = "A.R.T Distribution";

            ExcelWorkbook workBook = package.Workbook;
            if (workBook != null)
            {
                var ws = workBook.Worksheets.FirstOrDefault();
                var data = _queryBuilder(db, IDBranch, StaffID, QueryStrings).ToList();

                 

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

		public static DTO_WH_VTB_Statements getAnItem(AppEntities db, int IDBranch, int StaffID, int id)
        {
            var dbResult = db.tbl_WH_VTB_Statements.Find(id);

			return toDTO(dbResult);
			
        }
		

		public static bool put(AppEntities db, int IDBranch, int StaffID, int Id, dynamic item, string Username, Dictionary<string, string> QueryStrings)
        {
            bool result = false;
            var dbitem = db.tbl_WH_VTB_Statements.Find(Id);
            
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
					errorLog.logMessage("put_WH_VTB_Statements",e);
                    result = false;
                }
            }
            else
                if (QueryStrings.Any(d => d.Key == "ForceCreate"))
                    result =  post(db, IDBranch, StaffID, item, Username) != null;
                
            return result;
        }

        public static void patchDynamicToDB(dynamic item, tbl_WH_VTB_Statements dbitem, string Username)
        {
            Type type = typeof(tbl_WH_VTB_Statements);
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

        public static void patchDTOtoDBValue( DTO_WH_VTB_Statements item, tbl_WH_VTB_Statements dbitem)
        {
            if (item == null){
                dbitem = null;
                return;
            }
            							
			dbitem.TransactionDate = item.TransactionDate;							
			dbitem.TransactionContent = item.TransactionContent;							
			dbitem.Debit = item.Debit;							
			dbitem.Credit = item.Credit;							
			dbitem.AccountBalance = item.AccountBalance;							
			dbitem.TransactionNumber = item.TransactionNumber;							
			dbitem.CorresponsiveAccount = item.CorresponsiveAccount;							
			dbitem.CorresponsiveAccountName = item.CorresponsiveAccountName;							
			dbitem.Agency = item.Agency;							
			dbitem.CorresponsiveBankID = item.CorresponsiveBankID;							
			dbitem.CorresponsiveBankName = item.CorresponsiveBankName;							
			dbitem.ServiceBranchID = item.ServiceBranchID;							
			dbitem.ServiceBranchName = item.ServiceBranchName;							
			dbitem.Channel = item.Channel;							
			dbitem.Sort = item.Sort;							
			dbitem.IsDisabled = item.IsDisabled;							
			dbitem.IsDeleted = item.IsDeleted;        }

		public static DTO_WH_VTB_Statements post(AppEntities db, int IDBranch, int StaffID, dynamic item, string Username)
        {
            tbl_WH_VTB_Statements dbitem = new tbl_WH_VTB_Statements();
            if (item != null)
            {
                patchDynamicToDB(item, dbitem, Username);
                
				dbitem.CreatedBy = Username;
				dbitem.CreatedDate = DateTime.Now;				
                try
                {
					db.tbl_WH_VTB_Statements.Add(dbitem);
                    db.SaveChanges();
				
                }
                catch (DbEntityValidationException e)
                {
					errorLog.logMessage("post_WH_VTB_Statements",e);
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
                Type type = Type.GetType("BaseBusiness.BS_WH_VTB_Statements, ClassLibrary");
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
                        var target = new tbl_WH_VTB_Statements();
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
                    
                    tbl_WH_VTB_Statements dbitem = new tbl_WH_VTB_Statements();
                    if (it.Id == null || string.IsNullOrEmpty(it.Id.Value) || it.Id == "0")
                    {
                        dbitem = new tbl_WH_VTB_Statements();
                        dbitem.CreatedBy = Username;
				        dbitem.CreatedDate = DateTime.Now;
                                            }
                    else
                    {
                        dbitem = db.tbl_WH_VTB_Statements.Find((int)it.Id);
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
                        
                        if (dbitem.Id == 0) db.tbl_WH_VTB_Statements.Add(dbitem);
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
                    errorLog.logMessage("post_WH_VTB_Statements",e);
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

            var dbitems = db.tbl_WH_VTB_Statements.Where(d => IDs.Contains(d.Id));
            var updateDate = DateTime.Now;
            List<int?> IDBranches = new List<int?>();

            foreach (var dbitem in dbitems)
            {
							
				dbitem.ModifiedBy = Username;
				dbitem.ModifiedDate = updateDate;
				dbitem.IsDeleted = true;
							            
                
            }

            try
            {
                db.SaveChanges();
                result = true;
			
                BS_Version.update_Version(db, null, "DTO_WH_VTB_Statements", updateDate, Username);
			
            }
            catch (DbEntityValidationException e)
            {
				errorLog.logMessage("delete_WH_VTB_Statements",e);
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

			
            var dbitems = db.tbl_WH_VTB_Statements.Where(d => IDs.Contains(d.Id));
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
			
                BS_Version.update_Version(db, null, "DTO_WH_VTB_Statements", updateDate, Username);
			
            }
            catch (DbEntityValidationException e)
            {
				errorLog.logMessage("disable_WH_VTB_Statements",e);
                result = false;
            }
            
            return result;
        }

		
		//---//
		public static bool check_Exists(AppEntities db, int id)
		{
             
            return db.tbl_WH_VTB_Statements.Any(e => e.Id == id && e.IsDeleted == false);
            
		}
		
		//---//
		public static IQueryable<DTO_WH_VTB_Statements> toDTO(IQueryable<tbl_WH_VTB_Statements> query)
        {
			return query
			.Select(s => new DTO_WH_VTB_Statements(){							
				Id = s.Id,							
				TransactionDate = s.TransactionDate,							
				TransactionContent = s.TransactionContent,							
				Debit = s.Debit,							
				Credit = s.Credit,							
				AccountBalance = s.AccountBalance,							
				TransactionNumber = s.TransactionNumber,							
				CorresponsiveAccount = s.CorresponsiveAccount,							
				CorresponsiveAccountName = s.CorresponsiveAccountName,							
				Agency = s.Agency,							
				CorresponsiveBankID = s.CorresponsiveBankID,							
				CorresponsiveBankName = s.CorresponsiveBankName,							
				ServiceBranchID = s.ServiceBranchID,							
				ServiceBranchName = s.ServiceBranchName,							
				Channel = s.Channel,							
				Sort = s.Sort,							
				IsDisabled = s.IsDisabled,							
				IsDeleted = s.IsDeleted,							
				CreatedBy = s.CreatedBy,							
				CreatedDate = s.CreatedDate,							
				ModifiedBy = s.ModifiedBy,							
				ModifiedDate = s.ModifiedDate,					
			});//.OrderBy(o => o.Sort == null).ThenBy(u => u.Sort);
                              
        }

		public static DTO_WH_VTB_Statements toDTO(tbl_WH_VTB_Statements dbResult)
        {
			if (dbResult != null)
			{
				return new DTO_WH_VTB_Statements()
				{							
					Id = dbResult.Id,							
					TransactionDate = dbResult.TransactionDate,							
					TransactionContent = dbResult.TransactionContent,							
					Debit = dbResult.Debit,							
					Credit = dbResult.Credit,							
					AccountBalance = dbResult.AccountBalance,							
					TransactionNumber = dbResult.TransactionNumber,							
					CorresponsiveAccount = dbResult.CorresponsiveAccount,							
					CorresponsiveAccountName = dbResult.CorresponsiveAccountName,							
					Agency = dbResult.Agency,							
					CorresponsiveBankID = dbResult.CorresponsiveBankID,							
					CorresponsiveBankName = dbResult.CorresponsiveBankName,							
					ServiceBranchID = dbResult.ServiceBranchID,							
					ServiceBranchName = dbResult.ServiceBranchName,							
					Channel = dbResult.Channel,							
					Sort = dbResult.Sort,							
					IsDisabled = dbResult.IsDisabled,							
					IsDeleted = dbResult.IsDeleted,							
					CreatedBy = dbResult.CreatedBy,							
					CreatedDate = dbResult.CreatedDate,							
					ModifiedBy = dbResult.ModifiedBy,							
					ModifiedDate = dbResult.ModifiedDate,
				};
			}
			else
				return null; 
        }

		public static IQueryable<tbl_WH_VTB_Statements> _queryBuilder(AppEntities db, int IDBranch, int StaffID, Dictionary<string, string> QueryStrings)
        {
            
			IQueryable<tbl_WH_VTB_Statements> query = db.tbl_WH_VTB_Statements.AsNoTracking();//.Where(d => d.IsDeleted == false );
			

			//Query keyword



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

			//Query TransactionDate (Nullable<System.DateTime>)
			if (QueryStrings.Any(d => d.Key == "TransactionDateFrom") && QueryStrings.Any(d => d.Key == "TransactionDateTo"))
                if (DateTime.TryParse(QueryStrings.FirstOrDefault(d => d.Key == "TransactionDateFrom").Value, out DateTime fromDate) && DateTime.TryParse(QueryStrings.FirstOrDefault(d => d.Key == "TransactionDateTo").Value, out DateTime toDate))
                    query = query.Where(d => fromDate <= d.TransactionDate && d.TransactionDate <= toDate);

            if (QueryStrings.Any(d => d.Key == "TransactionDate"))
                if (DateTime.TryParse(QueryStrings.FirstOrDefault(d => d.Key == "TransactionDate").Value, out DateTime val))
                    query = query.Where(d => d.TransactionDate != null && DbFunctions.TruncateTime(val) == DbFunctions.TruncateTime(d.TransactionDate));


			//Query TransactionContent (string)
			if (QueryStrings.Any(d => d.Key == "TransactionContent_eq") && !string.IsNullOrEmpty(QueryStrings.FirstOrDefault(d => d.Key == "TransactionContent_eq").Value))
            {
                var keyword = QueryStrings.FirstOrDefault(d => d.Key == "TransactionContent_eq").Value;
                query = query.Where(d=>d.TransactionContent == keyword);
            }
            if (QueryStrings.Any(d => d.Key == "TransactionContent") && !string.IsNullOrEmpty(QueryStrings.FirstOrDefault(d => d.Key == "TransactionContent").Value))
            {
                var keyword = QueryStrings.FirstOrDefault(d => d.Key == "TransactionContent").Value;
                query = query.Where(d=>d.TransactionContent.Contains(keyword));
            }
            

			//Query Debit (Nullable<decimal>)
			if (QueryStrings.Any(d => d.Key == "DebitFrom") && QueryStrings.Any(d => d.Key == "DebitTo"))
                if (decimal.TryParse(QueryStrings.FirstOrDefault(d => d.Key == "DebitFrom").Value, out decimal fromVal) && decimal.TryParse(QueryStrings.FirstOrDefault(d => d.Key == "DebitTo").Value, out decimal toVal))
                    query = query.Where(d => fromVal <= d.Debit && d.Debit <= toVal);

			//Query Credit (Nullable<decimal>)
			if (QueryStrings.Any(d => d.Key == "CreditFrom") && QueryStrings.Any(d => d.Key == "CreditTo"))
                if (decimal.TryParse(QueryStrings.FirstOrDefault(d => d.Key == "CreditFrom").Value, out decimal fromVal) && decimal.TryParse(QueryStrings.FirstOrDefault(d => d.Key == "CreditTo").Value, out decimal toVal))
                    query = query.Where(d => fromVal <= d.Credit && d.Credit <= toVal);

			//Query AccountBalance (Nullable<decimal>)
			if (QueryStrings.Any(d => d.Key == "AccountBalanceFrom") && QueryStrings.Any(d => d.Key == "AccountBalanceTo"))
                if (decimal.TryParse(QueryStrings.FirstOrDefault(d => d.Key == "AccountBalanceFrom").Value, out decimal fromVal) && decimal.TryParse(QueryStrings.FirstOrDefault(d => d.Key == "AccountBalanceTo").Value, out decimal toVal))
                    query = query.Where(d => fromVal <= d.AccountBalance && d.AccountBalance <= toVal);

			//Query TransactionNumber (string)
			if (QueryStrings.Any(d => d.Key == "TransactionNumber_eq") && !string.IsNullOrEmpty(QueryStrings.FirstOrDefault(d => d.Key == "TransactionNumber_eq").Value))
            {
                var keyword = QueryStrings.FirstOrDefault(d => d.Key == "TransactionNumber_eq").Value;
                query = query.Where(d=>d.TransactionNumber == keyword);
            }
            if (QueryStrings.Any(d => d.Key == "TransactionNumber") && !string.IsNullOrEmpty(QueryStrings.FirstOrDefault(d => d.Key == "TransactionNumber").Value))
            {
                var keyword = QueryStrings.FirstOrDefault(d => d.Key == "TransactionNumber").Value;
                query = query.Where(d=>d.TransactionNumber.Contains(keyword));
            }
            

			//Query CorresponsiveAccount (string)
			if (QueryStrings.Any(d => d.Key == "CorresponsiveAccount_eq") && !string.IsNullOrEmpty(QueryStrings.FirstOrDefault(d => d.Key == "CorresponsiveAccount_eq").Value))
            {
                var keyword = QueryStrings.FirstOrDefault(d => d.Key == "CorresponsiveAccount_eq").Value;
                query = query.Where(d=>d.CorresponsiveAccount == keyword);
            }
            if (QueryStrings.Any(d => d.Key == "CorresponsiveAccount") && !string.IsNullOrEmpty(QueryStrings.FirstOrDefault(d => d.Key == "CorresponsiveAccount").Value))
            {
                var keyword = QueryStrings.FirstOrDefault(d => d.Key == "CorresponsiveAccount").Value;
                query = query.Where(d=>d.CorresponsiveAccount.Contains(keyword));
            }
            

			//Query CorresponsiveAccountName (string)
			if (QueryStrings.Any(d => d.Key == "CorresponsiveAccountName_eq") && !string.IsNullOrEmpty(QueryStrings.FirstOrDefault(d => d.Key == "CorresponsiveAccountName_eq").Value))
            {
                var keyword = QueryStrings.FirstOrDefault(d => d.Key == "CorresponsiveAccountName_eq").Value;
                query = query.Where(d=>d.CorresponsiveAccountName == keyword);
            }
            if (QueryStrings.Any(d => d.Key == "CorresponsiveAccountName") && !string.IsNullOrEmpty(QueryStrings.FirstOrDefault(d => d.Key == "CorresponsiveAccountName").Value))
            {
                var keyword = QueryStrings.FirstOrDefault(d => d.Key == "CorresponsiveAccountName").Value;
                query = query.Where(d=>d.CorresponsiveAccountName.Contains(keyword));
            }
            

			//Query Agency (string)
			if (QueryStrings.Any(d => d.Key == "Agency_eq") && !string.IsNullOrEmpty(QueryStrings.FirstOrDefault(d => d.Key == "Agency_eq").Value))
            {
                var keyword = QueryStrings.FirstOrDefault(d => d.Key == "Agency_eq").Value;
                query = query.Where(d=>d.Agency == keyword);
            }
            if (QueryStrings.Any(d => d.Key == "Agency") && !string.IsNullOrEmpty(QueryStrings.FirstOrDefault(d => d.Key == "Agency").Value))
            {
                var keyword = QueryStrings.FirstOrDefault(d => d.Key == "Agency").Value;
                query = query.Where(d=>d.Agency.Contains(keyword));
            }
            

			//Query CorresponsiveBankID (Nullable<int>)
			if (QueryStrings.Any(d => d.Key == "CorresponsiveBankID"))
            {
                var IDList = QueryStrings.FirstOrDefault(d => d.Key == "CorresponsiveBankID").Value.Replace("[", "").Replace("]", "").Split(',');
                List<int?> IDs = new List<int?>();
                foreach (var item in IDList)
                    if (int.TryParse(item, out int i))
                        IDs.Add(i);
					else if (item == "null")
						IDs.Add(null);
                if (IDs.Count > 0)
                    query = query.Where(d => IDs.Contains(d.CorresponsiveBankID));
////                    query = query.Where(d => IDs.Contains(d.CorresponsiveBankID));
//                    
            }

			//Query CorresponsiveBankName (string)
			if (QueryStrings.Any(d => d.Key == "CorresponsiveBankName_eq") && !string.IsNullOrEmpty(QueryStrings.FirstOrDefault(d => d.Key == "CorresponsiveBankName_eq").Value))
            {
                var keyword = QueryStrings.FirstOrDefault(d => d.Key == "CorresponsiveBankName_eq").Value;
                query = query.Where(d=>d.CorresponsiveBankName == keyword);
            }
            if (QueryStrings.Any(d => d.Key == "CorresponsiveBankName") && !string.IsNullOrEmpty(QueryStrings.FirstOrDefault(d => d.Key == "CorresponsiveBankName").Value))
            {
                var keyword = QueryStrings.FirstOrDefault(d => d.Key == "CorresponsiveBankName").Value;
                query = query.Where(d=>d.CorresponsiveBankName.Contains(keyword));
            }
            

			//Query ServiceBranchID (Nullable<int>)
			if (QueryStrings.Any(d => d.Key == "ServiceBranchID"))
            {
                var IDList = QueryStrings.FirstOrDefault(d => d.Key == "ServiceBranchID").Value.Replace("[", "").Replace("]", "").Split(',');
                List<int?> IDs = new List<int?>();
                foreach (var item in IDList)
                    if (int.TryParse(item, out int i))
                        IDs.Add(i);
					else if (item == "null")
						IDs.Add(null);
                if (IDs.Count > 0)
                    query = query.Where(d => IDs.Contains(d.ServiceBranchID));
////                    query = query.Where(d => IDs.Contains(d.ServiceBranchID));
//                    
            }

			//Query ServiceBranchName (string)
			if (QueryStrings.Any(d => d.Key == "ServiceBranchName_eq") && !string.IsNullOrEmpty(QueryStrings.FirstOrDefault(d => d.Key == "ServiceBranchName_eq").Value))
            {
                var keyword = QueryStrings.FirstOrDefault(d => d.Key == "ServiceBranchName_eq").Value;
                query = query.Where(d=>d.ServiceBranchName == keyword);
            }
            if (QueryStrings.Any(d => d.Key == "ServiceBranchName") && !string.IsNullOrEmpty(QueryStrings.FirstOrDefault(d => d.Key == "ServiceBranchName").Value))
            {
                var keyword = QueryStrings.FirstOrDefault(d => d.Key == "ServiceBranchName").Value;
                query = query.Where(d=>d.ServiceBranchName.Contains(keyword));
            }
            

			//Query Channel (string)
			if (QueryStrings.Any(d => d.Key == "Channel_eq") && !string.IsNullOrEmpty(QueryStrings.FirstOrDefault(d => d.Key == "Channel_eq").Value))
            {
                var keyword = QueryStrings.FirstOrDefault(d => d.Key == "Channel_eq").Value;
                query = query.Where(d=>d.Channel == keyword);
            }
            if (QueryStrings.Any(d => d.Key == "Channel") && !string.IsNullOrEmpty(QueryStrings.FirstOrDefault(d => d.Key == "Channel").Value))
            {
                var keyword = QueryStrings.FirstOrDefault(d => d.Key == "Channel").Value;
                query = query.Where(d=>d.Channel.Contains(keyword));
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
            

			//Query CreatedDate (System.DateTime)
			if (QueryStrings.Any(d => d.Key == "CreatedDateFrom") && QueryStrings.Any(d => d.Key == "CreatedDateTo"))
                if (DateTime.TryParse(QueryStrings.FirstOrDefault(d => d.Key == "CreatedDateFrom").Value, out DateTime fromDate) && DateTime.TryParse(QueryStrings.FirstOrDefault(d => d.Key == "CreatedDateTo").Value, out DateTime toDate))
                    query = query.Where(d => fromDate <= d.CreatedDate && d.CreatedDate <= toDate);

            if (QueryStrings.Any(d => d.Key == "CreatedDate"))
                if (DateTime.TryParse(QueryStrings.FirstOrDefault(d => d.Key == "CreatedDate").Value, out DateTime val))
                    query = query.Where(d => d.CreatedDate != null && DbFunctions.TruncateTime(val) == DbFunctions.TruncateTime(d.CreatedDate));


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
            

			//Query ModifiedDate (System.DateTime)
			if (QueryStrings.Any(d => d.Key == "ModifiedDateFrom") && QueryStrings.Any(d => d.Key == "ModifiedDateTo"))
                if (DateTime.TryParse(QueryStrings.FirstOrDefault(d => d.Key == "ModifiedDateFrom").Value, out DateTime fromDate) && DateTime.TryParse(QueryStrings.FirstOrDefault(d => d.Key == "ModifiedDateTo").Value, out DateTime toDate))
                    query = query.Where(d => fromDate <= d.ModifiedDate && d.ModifiedDate <= toDate);

            if (QueryStrings.Any(d => d.Key == "ModifiedDate"))
                if (DateTime.TryParse(QueryStrings.FirstOrDefault(d => d.Key == "ModifiedDate").Value, out DateTime val))
                    query = query.Where(d => d.ModifiedDate != null && DbFunctions.TruncateTime(val) == DbFunctions.TruncateTime(d.ModifiedDate));

            return query;
        }
		
        public static IQueryable<tbl_WH_VTB_Statements> _sortBuilder(IQueryable<tbl_WH_VTB_Statements> query, Dictionary<string, string> QueryStrings)
        {
            if (QueryStrings.Any(d => d.Key == "SortBy"))
            {
                var sorts = QueryStrings.FirstOrDefault(d => d.Key == "SortBy").Value.Replace("[", "").Replace("]", "").Split(',');
                
                foreach (var item in sorts)
                    if (!string.IsNullOrEmpty(item))
                    {
                        var ordered = query as IOrderedQueryable<tbl_WH_VTB_Statements>;
                        bool isOrdered = ordered.ToString().IndexOf("ORDER BY") !=-1;

                        switch (item)
                        {
							case "Id":
								query = isOrdered ? ordered.ThenBy(o => o.Id) : query.OrderBy(o => o.Id);
								 break;
							case "Id_desc":
                                query = isOrdered ? ordered.ThenByDescending(o => o.Id) : query.OrderByDescending(o => o.Id);
                                break;
							case "TransactionDate":
								query = isOrdered ? ordered.ThenBy(o => o.TransactionDate) : query.OrderBy(o => o.TransactionDate);
								 break;
							case "TransactionDate_desc":
                                query = isOrdered ? ordered.ThenByDescending(o => o.TransactionDate) : query.OrderByDescending(o => o.TransactionDate);
                                break;
							case "TransactionContent":
								query = isOrdered ? ordered.ThenBy(o => o.TransactionContent) : query.OrderBy(o => o.TransactionContent);
								 break;
							case "TransactionContent_desc":
                                query = isOrdered ? ordered.ThenByDescending(o => o.TransactionContent) : query.OrderByDescending(o => o.TransactionContent);
                                break;
							case "Debit":
								query = isOrdered ? ordered.ThenBy(o => o.Debit) : query.OrderBy(o => o.Debit);
								 break;
							case "Debit_desc":
                                query = isOrdered ? ordered.ThenByDescending(o => o.Debit) : query.OrderByDescending(o => o.Debit);
                                break;
							case "Credit":
								query = isOrdered ? ordered.ThenBy(o => o.Credit) : query.OrderBy(o => o.Credit);
								 break;
							case "Credit_desc":
                                query = isOrdered ? ordered.ThenByDescending(o => o.Credit) : query.OrderByDescending(o => o.Credit);
                                break;
							case "AccountBalance":
								query = isOrdered ? ordered.ThenBy(o => o.AccountBalance) : query.OrderBy(o => o.AccountBalance);
								 break;
							case "AccountBalance_desc":
                                query = isOrdered ? ordered.ThenByDescending(o => o.AccountBalance) : query.OrderByDescending(o => o.AccountBalance);
                                break;
							case "TransactionNumber":
								query = isOrdered ? ordered.ThenBy(o => o.TransactionNumber) : query.OrderBy(o => o.TransactionNumber);
								 break;
							case "TransactionNumber_desc":
                                query = isOrdered ? ordered.ThenByDescending(o => o.TransactionNumber) : query.OrderByDescending(o => o.TransactionNumber);
                                break;
							case "CorresponsiveAccount":
								query = isOrdered ? ordered.ThenBy(o => o.CorresponsiveAccount) : query.OrderBy(o => o.CorresponsiveAccount);
								 break;
							case "CorresponsiveAccount_desc":
                                query = isOrdered ? ordered.ThenByDescending(o => o.CorresponsiveAccount) : query.OrderByDescending(o => o.CorresponsiveAccount);
                                break;
							case "CorresponsiveAccountName":
								query = isOrdered ? ordered.ThenBy(o => o.CorresponsiveAccountName) : query.OrderBy(o => o.CorresponsiveAccountName);
								 break;
							case "CorresponsiveAccountName_desc":
                                query = isOrdered ? ordered.ThenByDescending(o => o.CorresponsiveAccountName) : query.OrderByDescending(o => o.CorresponsiveAccountName);
                                break;
							case "Agency":
								query = isOrdered ? ordered.ThenBy(o => o.Agency) : query.OrderBy(o => o.Agency);
								 break;
							case "Agency_desc":
                                query = isOrdered ? ordered.ThenByDescending(o => o.Agency) : query.OrderByDescending(o => o.Agency);
                                break;
							case "CorresponsiveBankID":
								query = isOrdered ? ordered.ThenBy(o => o.CorresponsiveBankID) : query.OrderBy(o => o.CorresponsiveBankID);
								 break;
							case "CorresponsiveBankID_desc":
                                query = isOrdered ? ordered.ThenByDescending(o => o.CorresponsiveBankID) : query.OrderByDescending(o => o.CorresponsiveBankID);
                                break;
							case "CorresponsiveBankName":
								query = isOrdered ? ordered.ThenBy(o => o.CorresponsiveBankName) : query.OrderBy(o => o.CorresponsiveBankName);
								 break;
							case "CorresponsiveBankName_desc":
                                query = isOrdered ? ordered.ThenByDescending(o => o.CorresponsiveBankName) : query.OrderByDescending(o => o.CorresponsiveBankName);
                                break;
							case "ServiceBranchID":
								query = isOrdered ? ordered.ThenBy(o => o.ServiceBranchID) : query.OrderBy(o => o.ServiceBranchID);
								 break;
							case "ServiceBranchID_desc":
                                query = isOrdered ? ordered.ThenByDescending(o => o.ServiceBranchID) : query.OrderByDescending(o => o.ServiceBranchID);
                                break;
							case "ServiceBranchName":
								query = isOrdered ? ordered.ThenBy(o => o.ServiceBranchName) : query.OrderBy(o => o.ServiceBranchName);
								 break;
							case "ServiceBranchName_desc":
                                query = isOrdered ? ordered.ThenByDescending(o => o.ServiceBranchName) : query.OrderByDescending(o => o.ServiceBranchName);
                                break;
							case "Channel":
								query = isOrdered ? ordered.ThenBy(o => o.Channel) : query.OrderBy(o => o.Channel);
								 break;
							case "Channel_desc":
                                query = isOrdered ? ordered.ThenByDescending(o => o.Channel) : query.OrderByDescending(o => o.Channel);
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
							case "CreatedDate":
								query = isOrdered ? ordered.ThenBy(o => o.CreatedDate) : query.OrderBy(o => o.CreatedDate);
								 break;
							case "CreatedDate_desc":
                                query = isOrdered ? ordered.ThenByDescending(o => o.CreatedDate) : query.OrderByDescending(o => o.CreatedDate);
                                break;
							case "ModifiedBy":
								query = isOrdered ? ordered.ThenBy(o => o.ModifiedBy) : query.OrderBy(o => o.ModifiedBy);
								 break;
							case "ModifiedBy_desc":
                                query = isOrdered ? ordered.ThenByDescending(o => o.ModifiedBy) : query.OrderByDescending(o => o.ModifiedBy);
                                break;
							case "ModifiedDate":
								query = isOrdered ? ordered.ThenBy(o => o.ModifiedDate) : query.OrderBy(o => o.ModifiedDate);
								 break;
							case "ModifiedDate_desc":
                                query = isOrdered ? ordered.ThenByDescending(o => o.ModifiedDate) : query.OrderByDescending(o => o.ModifiedDate);
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

        public static IQueryable<tbl_WH_VTB_Statements> _pagingBuilder(IQueryable<tbl_WH_VTB_Statements> query, Dictionary<string, string> QueryStrings)
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






