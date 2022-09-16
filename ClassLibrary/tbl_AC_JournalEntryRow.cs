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
    
    
    public partial class tbl_AC_JournalEntryRow
    {
        public Nullable<int> IDBranch { get; set; }
        public int Id { get; set; }
        public Nullable<int> IDTransaction { get; set; }
        public Nullable<int> RefTransaction { get; set; }
        public int Line { get; set; }
        public Nullable<int> Account { get; set; }
        public string AccountCode { get; set; }
        public decimal Debit { get; set; }
        public decimal Credit { get; set; }
        public System.DateTime DueDate { get; set; }
        public Nullable<int> IDAccount { get; set; }
        public string RefAccountCode { get; set; }
        public Nullable<int> OffsetAccount { get; set; }
        public string RefOffsetAccount { get; set; }
        public Nullable<int> RefCFTId { get; set; }
        public Nullable<int> RefCFWId { get; set; }
        public string Remark { get; set; }
        public Nullable<System.DateTime> DocumentDate { get; set; }
        public Nullable<int> PostingPeriod { get; set; }
        public string DistributionRule { get; set; }
        public bool IsDeleted { get; set; }
        public string CreatedBy { get; set; }
        public string ModifiedBy { get; set; }
        public System.DateTime CreatedDate { get; set; }
        public System.DateTime ModifiedDate { get; set; }
    }
}


namespace DTOModel
{
	using System;
	public partial class DTO_AC_JournalEntryRow
	{
		public Nullable<int> IDBranch { get; set; }
		public int Id { get; set; }
		public Nullable<int> IDTransaction { get; set; }
		public Nullable<int> RefTransaction { get; set; }
		public int Line { get; set; }
		public Nullable<int> Account { get; set; }
		public string AccountCode { get; set; }
		public decimal Debit { get; set; }
		public decimal Credit { get; set; }
		public System.DateTime DueDate { get; set; }
		public Nullable<int> IDAccount { get; set; }
		public string RefAccountCode { get; set; }
		public Nullable<int> OffsetAccount { get; set; }
		public string RefOffsetAccount { get; set; }
		public Nullable<int> RefCFTId { get; set; }
		public Nullable<int> RefCFWId { get; set; }
		public string Remark { get; set; }
		public Nullable<System.DateTime> DocumentDate { get; set; }
		public Nullable<int> PostingPeriod { get; set; }
		public string DistributionRule { get; set; }
		public bool IsDeleted { get; set; }
		public string CreatedBy { get; set; }
		public string ModifiedBy { get; set; }
		public System.DateTime CreatedDate { get; set; }
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

    public static partial class BS_AC_JournalEntryRow 
    {
        public static dynamic getSearch(AppEntities db, int IDBranch, int StaffID, Dictionary<string, string> QueryStrings)
        {
            return get(db, IDBranch,StaffID, QueryStrings);
        }

		public static IQueryable<DTO_AC_JournalEntryRow> get(AppEntities db, int IDBranch, int StaffID, Dictionary<string, string> QueryStrings)
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
            package.Workbook.Properties.Title = "ART-DMS AC_JournalEntryRow";
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

		public static DTO_AC_JournalEntryRow getAnItem(AppEntities db, int IDBranch, int StaffID, int id)
        {
            var dbResult = db.tbl_AC_JournalEntryRow.Find(id);

			//if (dbResult == null || (IDBranch != 0 && dbResult.IDBranch != IDBranch))
			//	return null; 
			//else 
				return toDTO(dbResult);
			
        }
		

		public static bool put(AppEntities db, int IDBranch, int StaffID, int Id, dynamic item, string Username, Dictionary<string, string> QueryStrings)
        {
            bool result = false;
            var dbitem = db.tbl_AC_JournalEntryRow.Find(Id);
            
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
					errorLog.logMessage("put_AC_JournalEntryRow",e);
                    result = false;
                }
            }
            else
                if (QueryStrings.Any(d => d.Key == "ForceCreate"))
                    result =  post(db, IDBranch, StaffID, item, Username) != null;
                
            return result;
        }

        public static void patchDynamicToDB(dynamic item, tbl_AC_JournalEntryRow dbitem, string Username)
        {
            Type type = typeof(tbl_AC_JournalEntryRow);
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

        public static void patchDTOtoDBValue( DTO_AC_JournalEntryRow item, tbl_AC_JournalEntryRow dbitem)
        {
            if (item == null){
                dbitem = null;
                return;
            }
            							
			dbitem.IDBranch = item.IDBranch;							
			dbitem.IDTransaction = item.IDTransaction;							
			dbitem.RefTransaction = item.RefTransaction;							
			dbitem.Line = item.Line;							
			dbitem.Account = item.Account;							
			dbitem.AccountCode = item.AccountCode;							
			dbitem.Debit = item.Debit;							
			dbitem.Credit = item.Credit;							
			dbitem.DueDate = item.DueDate;							
			dbitem.IDAccount = item.IDAccount;							
			dbitem.RefAccountCode = item.RefAccountCode;							
			dbitem.OffsetAccount = item.OffsetAccount;							
			dbitem.RefOffsetAccount = item.RefOffsetAccount;							
			dbitem.RefCFTId = item.RefCFTId;							
			dbitem.RefCFWId = item.RefCFWId;							
			dbitem.Remark = item.Remark;							
			dbitem.DocumentDate = item.DocumentDate;							
			dbitem.PostingPeriod = item.PostingPeriod;							
			dbitem.DistributionRule = item.DistributionRule;							
			dbitem.IsDeleted = item.IsDeleted;        }

		public static DTO_AC_JournalEntryRow post(AppEntities db, int IDBranch, int StaffID, dynamic item, string Username)
        {
            tbl_AC_JournalEntryRow dbitem = new tbl_AC_JournalEntryRow();
            if (item != null)
            {
                patchDynamicToDB(item, dbitem, Username);
                
				dbitem.CreatedBy = Username;
				dbitem.CreatedDate = DateTime.Now;				
                try
                {
					db.tbl_AC_JournalEntryRow.Add(dbitem);
                    db.SaveChanges();
				
                }
                catch (DbEntityValidationException e)
                {
					errorLog.logMessage("post_AC_JournalEntryRow",e);
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
                Type type = Type.GetType("BaseBusiness.BS_AC_JournalEntryRow, ClassLibrary");
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
                        var target = new tbl_AC_JournalEntryRow();
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
                    
                    tbl_AC_JournalEntryRow dbitem = new tbl_AC_JournalEntryRow();
                    if (it.Id == null || string.IsNullOrEmpty(it.Id.Value) || it.Id == "0")
                    {
                        dbitem = new tbl_AC_JournalEntryRow();
                        dbitem.CreatedBy = Username;
				        dbitem.CreatedDate = DateTime.Now;
                                            }
                    else
                    {
                        dbitem = db.tbl_AC_JournalEntryRow.Find((int)it.Id);
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
                        
                        if (dbitem.Id == 0) db.tbl_AC_JournalEntryRow.Add(dbitem);
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
                    errorLog.logMessage("post_AC_JournalEntryRow",e);
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

            var dbitems = db.tbl_AC_JournalEntryRow.Where(d => IDs.Contains(d.Id));
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
                    BS_Version.update_Version(db, IDBranch, "DTO_AC_JournalEntryRow", updateDate, Username);
                }
			
            }
            catch (DbEntityValidationException e)
            {
				errorLog.logMessage("delete_AC_JournalEntryRow",e);
                result = false;
            }

            return result;
        }

        public static bool disable(AppEntities db, string ids, bool isDisable, string Username)
        {
            bool result = false;
            
            return result;
        }

		
		//---//
		public static bool check_Exists(AppEntities db, int id)
		{
             
            return db.tbl_AC_JournalEntryRow.Any(e => e.Id == id && e.IsDeleted == false);
            
		}
		
		//---//
		public static IQueryable<DTO_AC_JournalEntryRow> toDTO(IQueryable<tbl_AC_JournalEntryRow> query)
        {
			return query
			.Select(s => new DTO_AC_JournalEntryRow(){							
				IDBranch = s.IDBranch,							
				Id = s.Id,							
				IDTransaction = s.IDTransaction,							
				RefTransaction = s.RefTransaction,							
				Line = s.Line,							
				Account = s.Account,							
				AccountCode = s.AccountCode,							
				Debit = s.Debit,							
				Credit = s.Credit,							
				DueDate = s.DueDate,							
				IDAccount = s.IDAccount,							
				RefAccountCode = s.RefAccountCode,							
				OffsetAccount = s.OffsetAccount,							
				RefOffsetAccount = s.RefOffsetAccount,							
				RefCFTId = s.RefCFTId,							
				RefCFWId = s.RefCFWId,							
				Remark = s.Remark,							
				DocumentDate = s.DocumentDate,							
				PostingPeriod = s.PostingPeriod,							
				DistributionRule = s.DistributionRule,							
				IsDeleted = s.IsDeleted,							
				CreatedBy = s.CreatedBy,							
				ModifiedBy = s.ModifiedBy,							
				CreatedDate = s.CreatedDate,							
				ModifiedDate = s.ModifiedDate,					
			});//;
                              
        }

		public static DTO_AC_JournalEntryRow toDTO(tbl_AC_JournalEntryRow dbResult)
        {
			if (dbResult != null)
			{
				return new DTO_AC_JournalEntryRow()
				{							
					IDBranch = dbResult.IDBranch,							
					Id = dbResult.Id,							
					IDTransaction = dbResult.IDTransaction,							
					RefTransaction = dbResult.RefTransaction,							
					Line = dbResult.Line,							
					Account = dbResult.Account,							
					AccountCode = dbResult.AccountCode,							
					Debit = dbResult.Debit,							
					Credit = dbResult.Credit,							
					DueDate = dbResult.DueDate,							
					IDAccount = dbResult.IDAccount,							
					RefAccountCode = dbResult.RefAccountCode,							
					OffsetAccount = dbResult.OffsetAccount,							
					RefOffsetAccount = dbResult.RefOffsetAccount,							
					RefCFTId = dbResult.RefCFTId,							
					RefCFWId = dbResult.RefCFWId,							
					Remark = dbResult.Remark,							
					DocumentDate = dbResult.DocumentDate,							
					PostingPeriod = dbResult.PostingPeriod,							
					DistributionRule = dbResult.DistributionRule,							
					IsDeleted = dbResult.IsDeleted,							
					CreatedBy = dbResult.CreatedBy,							
					ModifiedBy = dbResult.ModifiedBy,							
					CreatedDate = dbResult.CreatedDate,							
					ModifiedDate = dbResult.ModifiedDate,
				};
			}
			else
				return null; 
        }

		public static IQueryable<tbl_AC_JournalEntryRow> _queryBuilder(AppEntities db, int IDBranch, int StaffID, Dictionary<string, string> QueryStrings)
        {
            
			IQueryable<tbl_AC_JournalEntryRow> query = db.tbl_AC_JournalEntryRow.AsNoTracking();//.Where(d => d.IsDeleted == false);
			

			//Query keyword



			//Query IDBranch (Nullable<int>)
			if (QueryStrings.Any(d => d.Key == "IDBranch"))
            {
                var IDList = QueryStrings.FirstOrDefault(d => d.Key == "IDBranch").Value.Replace("[", "").Replace("]", "").Split(',');
                List<int?> IDs = new List<int?>();
                foreach (var item in IDList)
                    if (int.TryParse(item, out int i))
                        IDs.Add(i);
					else if (item == "null")
						IDs.Add(null);
                if (IDs.Count > 0)
                    query = query.Where(d => IDs.Contains(d.IDBranch));
////                    query = query.Where(d => d.IDBranch == null || IDs.Contains(d.IDBranch));
//                    
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

			//Query IDTransaction (Nullable<int>)
			if (QueryStrings.Any(d => d.Key == "IDTransaction"))
            {
                var IDList = QueryStrings.FirstOrDefault(d => d.Key == "IDTransaction").Value.Replace("[", "").Replace("]", "").Split(',');
                List<int?> IDs = new List<int?>();
                foreach (var item in IDList)
                    if (int.TryParse(item, out int i))
                        IDs.Add(i);
					else if (item == "null")
						IDs.Add(null);
                if (IDs.Count > 0)
                    query = query.Where(d => IDs.Contains(d.IDTransaction));
////                    query = query.Where(d => IDs.Contains(d.IDTransaction));
//                    
            }

			//Query RefTransaction (Nullable<int>)
			if (QueryStrings.Any(d => d.Key == "RefTransactionFrom") && QueryStrings.Any(d => d.Key == "RefTransactionTo"))
                if (int.TryParse(QueryStrings.FirstOrDefault(d => d.Key == "RefTransactionFrom").Value, out int fromVal) && int.TryParse(QueryStrings.FirstOrDefault(d => d.Key == "RefTransactionTo").Value, out int toVal))
                    query = query.Where(d => fromVal <= d.RefTransaction && d.RefTransaction <= toVal);

			//Query Line (int)
			if (QueryStrings.Any(d => d.Key == "LineFrom") && QueryStrings.Any(d => d.Key == "LineTo"))
                if (int.TryParse(QueryStrings.FirstOrDefault(d => d.Key == "LineFrom").Value, out int fromVal) && int.TryParse(QueryStrings.FirstOrDefault(d => d.Key == "LineTo").Value, out int toVal))
                    query = query.Where(d => fromVal <= d.Line && d.Line <= toVal);
            
            if (QueryStrings.Any(d => d.Key == "Line"))
                if (int.TryParse(QueryStrings.FirstOrDefault(d => d.Key == "Line").Value, out int val))
                    query = query.Where(d => val == d.Line);


			//Query Account (Nullable<int>)
			if (QueryStrings.Any(d => d.Key == "AccountFrom") && QueryStrings.Any(d => d.Key == "AccountTo"))
                if (int.TryParse(QueryStrings.FirstOrDefault(d => d.Key == "AccountFrom").Value, out int fromVal) && int.TryParse(QueryStrings.FirstOrDefault(d => d.Key == "AccountTo").Value, out int toVal))
                    query = query.Where(d => fromVal <= d.Account && d.Account <= toVal);

			//Query AccountCode (string)
			if (QueryStrings.Any(d => d.Key == "AccountCode_eq") && !string.IsNullOrEmpty(QueryStrings.FirstOrDefault(d => d.Key == "AccountCode_eq").Value))
            {
                var keyword = QueryStrings.FirstOrDefault(d => d.Key == "AccountCode_eq").Value;
                query = query.Where(d=>d.AccountCode == keyword);
            }
            if (QueryStrings.Any(d => d.Key == "AccountCode") && !string.IsNullOrEmpty(QueryStrings.FirstOrDefault(d => d.Key == "AccountCode").Value))
            {
                var keyword = QueryStrings.FirstOrDefault(d => d.Key == "AccountCode").Value;
                query = query.Where(d=>d.AccountCode.Contains(keyword));
            }
            

			//Query Debit (decimal)
			if (QueryStrings.Any(d => d.Key == "DebitFrom") && QueryStrings.Any(d => d.Key == "DebitTo"))
                if (decimal.TryParse(QueryStrings.FirstOrDefault(d => d.Key == "DebitFrom").Value, out decimal fromVal) && decimal.TryParse(QueryStrings.FirstOrDefault(d => d.Key == "DebitTo").Value, out decimal toVal))
                    query = query.Where(d => fromVal <= d.Debit && d.Debit <= toVal);
            
            if (QueryStrings.Any(d => d.Key == "Debit"))
                if (decimal.TryParse(QueryStrings.FirstOrDefault(d => d.Key == "Debit").Value, out decimal val))
                    query = query.Where(d => val == d.Debit);


			//Query Credit (decimal)
			if (QueryStrings.Any(d => d.Key == "CreditFrom") && QueryStrings.Any(d => d.Key == "CreditTo"))
                if (decimal.TryParse(QueryStrings.FirstOrDefault(d => d.Key == "CreditFrom").Value, out decimal fromVal) && decimal.TryParse(QueryStrings.FirstOrDefault(d => d.Key == "CreditTo").Value, out decimal toVal))
                    query = query.Where(d => fromVal <= d.Credit && d.Credit <= toVal);
            
            if (QueryStrings.Any(d => d.Key == "Credit"))
                if (decimal.TryParse(QueryStrings.FirstOrDefault(d => d.Key == "Credit").Value, out decimal val))
                    query = query.Where(d => val == d.Credit);


			//Query DueDate (System.DateTime)
			if (QueryStrings.Any(d => d.Key == "DueDateFrom") && QueryStrings.Any(d => d.Key == "DueDateTo"))
                if (DateTime.TryParse(QueryStrings.FirstOrDefault(d => d.Key == "DueDateFrom").Value, out DateTime fromDate) && DateTime.TryParse(QueryStrings.FirstOrDefault(d => d.Key == "DueDateTo").Value, out DateTime toDate))
                    query = query.Where(d => fromDate <= d.DueDate && d.DueDate <= toDate);

            if (QueryStrings.Any(d => d.Key == "DueDate"))
                if (DateTime.TryParse(QueryStrings.FirstOrDefault(d => d.Key == "DueDate").Value, out DateTime val))
                    query = query.Where(d => d.DueDate != null && DbFunctions.TruncateTime(val) == DbFunctions.TruncateTime(d.DueDate));


			//Query IDAccount (Nullable<int>)
			if (QueryStrings.Any(d => d.Key == "IDAccount"))
            {
                var IDList = QueryStrings.FirstOrDefault(d => d.Key == "IDAccount").Value.Replace("[", "").Replace("]", "").Split(',');
                List<int?> IDs = new List<int?>();
                foreach (var item in IDList)
                    if (int.TryParse(item, out int i))
                        IDs.Add(i);
					else if (item == "null")
						IDs.Add(null);
                if (IDs.Count > 0)
                    query = query.Where(d => IDs.Contains(d.IDAccount));
////                    query = query.Where(d => IDs.Contains(d.IDAccount));
//                    
            }

			//Query RefAccountCode (string)
			if (QueryStrings.Any(d => d.Key == "RefAccountCode_eq") && !string.IsNullOrEmpty(QueryStrings.FirstOrDefault(d => d.Key == "RefAccountCode_eq").Value))
            {
                var keyword = QueryStrings.FirstOrDefault(d => d.Key == "RefAccountCode_eq").Value;
                query = query.Where(d=>d.RefAccountCode == keyword);
            }
            if (QueryStrings.Any(d => d.Key == "RefAccountCode") && !string.IsNullOrEmpty(QueryStrings.FirstOrDefault(d => d.Key == "RefAccountCode").Value))
            {
                var keyword = QueryStrings.FirstOrDefault(d => d.Key == "RefAccountCode").Value;
                query = query.Where(d=>d.RefAccountCode.Contains(keyword));
            }
            

			//Query OffsetAccount (Nullable<int>)
			if (QueryStrings.Any(d => d.Key == "OffsetAccountFrom") && QueryStrings.Any(d => d.Key == "OffsetAccountTo"))
                if (int.TryParse(QueryStrings.FirstOrDefault(d => d.Key == "OffsetAccountFrom").Value, out int fromVal) && int.TryParse(QueryStrings.FirstOrDefault(d => d.Key == "OffsetAccountTo").Value, out int toVal))
                    query = query.Where(d => fromVal <= d.OffsetAccount && d.OffsetAccount <= toVal);

			//Query RefOffsetAccount (string)
			if (QueryStrings.Any(d => d.Key == "RefOffsetAccount_eq") && !string.IsNullOrEmpty(QueryStrings.FirstOrDefault(d => d.Key == "RefOffsetAccount_eq").Value))
            {
                var keyword = QueryStrings.FirstOrDefault(d => d.Key == "RefOffsetAccount_eq").Value;
                query = query.Where(d=>d.RefOffsetAccount == keyword);
            }
            if (QueryStrings.Any(d => d.Key == "RefOffsetAccount") && !string.IsNullOrEmpty(QueryStrings.FirstOrDefault(d => d.Key == "RefOffsetAccount").Value))
            {
                var keyword = QueryStrings.FirstOrDefault(d => d.Key == "RefOffsetAccount").Value;
                query = query.Where(d=>d.RefOffsetAccount.Contains(keyword));
            }
            

			//Query RefCFTId (Nullable<int>)
			if (QueryStrings.Any(d => d.Key == "RefCFTIdFrom") && QueryStrings.Any(d => d.Key == "RefCFTIdTo"))
                if (int.TryParse(QueryStrings.FirstOrDefault(d => d.Key == "RefCFTIdFrom").Value, out int fromVal) && int.TryParse(QueryStrings.FirstOrDefault(d => d.Key == "RefCFTIdTo").Value, out int toVal))
                    query = query.Where(d => fromVal <= d.RefCFTId && d.RefCFTId <= toVal);

			//Query RefCFWId (Nullable<int>)
			if (QueryStrings.Any(d => d.Key == "RefCFWIdFrom") && QueryStrings.Any(d => d.Key == "RefCFWIdTo"))
                if (int.TryParse(QueryStrings.FirstOrDefault(d => d.Key == "RefCFWIdFrom").Value, out int fromVal) && int.TryParse(QueryStrings.FirstOrDefault(d => d.Key == "RefCFWIdTo").Value, out int toVal))
                    query = query.Where(d => fromVal <= d.RefCFWId && d.RefCFWId <= toVal);

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
            

			//Query DocumentDate (Nullable<System.DateTime>)
			if (QueryStrings.Any(d => d.Key == "DocumentDateFrom") && QueryStrings.Any(d => d.Key == "DocumentDateTo"))
                if (DateTime.TryParse(QueryStrings.FirstOrDefault(d => d.Key == "DocumentDateFrom").Value, out DateTime fromDate) && DateTime.TryParse(QueryStrings.FirstOrDefault(d => d.Key == "DocumentDateTo").Value, out DateTime toDate))
                    query = query.Where(d => fromDate <= d.DocumentDate && d.DocumentDate <= toDate);

            if (QueryStrings.Any(d => d.Key == "DocumentDate"))
                if (DateTime.TryParse(QueryStrings.FirstOrDefault(d => d.Key == "DocumentDate").Value, out DateTime val))
                    query = query.Where(d => d.DocumentDate != null && DbFunctions.TruncateTime(val) == DbFunctions.TruncateTime(d.DocumentDate));


			//Query PostingPeriod (Nullable<int>)
			if (QueryStrings.Any(d => d.Key == "PostingPeriodFrom") && QueryStrings.Any(d => d.Key == "PostingPeriodTo"))
                if (int.TryParse(QueryStrings.FirstOrDefault(d => d.Key == "PostingPeriodFrom").Value, out int fromVal) && int.TryParse(QueryStrings.FirstOrDefault(d => d.Key == "PostingPeriodTo").Value, out int toVal))
                    query = query.Where(d => fromVal <= d.PostingPeriod && d.PostingPeriod <= toVal);

			//Query DistributionRule (string)
			if (QueryStrings.Any(d => d.Key == "DistributionRule_eq") && !string.IsNullOrEmpty(QueryStrings.FirstOrDefault(d => d.Key == "DistributionRule_eq").Value))
            {
                var keyword = QueryStrings.FirstOrDefault(d => d.Key == "DistributionRule_eq").Value;
                query = query.Where(d=>d.DistributionRule == keyword);
            }
            if (QueryStrings.Any(d => d.Key == "DistributionRule") && !string.IsNullOrEmpty(QueryStrings.FirstOrDefault(d => d.Key == "DistributionRule").Value))
            {
                var keyword = QueryStrings.FirstOrDefault(d => d.Key == "DistributionRule").Value;
                query = query.Where(d=>d.DistributionRule.Contains(keyword));
            }
            

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

            return query;
        }
		
        public static IQueryable<tbl_AC_JournalEntryRow> _sortBuilder(IQueryable<tbl_AC_JournalEntryRow> query, Dictionary<string, string> QueryStrings)
        {
            if (QueryStrings.Any(d => d.Key == "SortBy"))
            {
                var sorts = QueryStrings.FirstOrDefault(d => d.Key == "SortBy").Value.Replace("[", "").Replace("]", "").Split(',');
                
                foreach (var item in sorts)
                    if (!string.IsNullOrEmpty(item))
                    {
                        var ordered = query as IOrderedQueryable<tbl_AC_JournalEntryRow>;
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
							case "IDTransaction":
								query = isOrdered ? ordered.ThenBy(o => o.IDTransaction) : query.OrderBy(o => o.IDTransaction);
								 break;
							case "IDTransaction_desc":
                                query = isOrdered ? ordered.ThenByDescending(o => o.IDTransaction) : query.OrderByDescending(o => o.IDTransaction);
                                break;
							case "RefTransaction":
								query = isOrdered ? ordered.ThenBy(o => o.RefTransaction) : query.OrderBy(o => o.RefTransaction);
								 break;
							case "RefTransaction_desc":
                                query = isOrdered ? ordered.ThenByDescending(o => o.RefTransaction) : query.OrderByDescending(o => o.RefTransaction);
                                break;
							case "Line":
								query = isOrdered ? ordered.ThenBy(o => o.Line) : query.OrderBy(o => o.Line);
								 break;
							case "Line_desc":
                                query = isOrdered ? ordered.ThenByDescending(o => o.Line) : query.OrderByDescending(o => o.Line);
                                break;
							case "Account":
								query = isOrdered ? ordered.ThenBy(o => o.Account) : query.OrderBy(o => o.Account);
								 break;
							case "Account_desc":
                                query = isOrdered ? ordered.ThenByDescending(o => o.Account) : query.OrderByDescending(o => o.Account);
                                break;
							case "AccountCode":
								query = isOrdered ? ordered.ThenBy(o => o.AccountCode) : query.OrderBy(o => o.AccountCode);
								 break;
							case "AccountCode_desc":
                                query = isOrdered ? ordered.ThenByDescending(o => o.AccountCode) : query.OrderByDescending(o => o.AccountCode);
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
							case "DueDate":
								query = isOrdered ? ordered.ThenBy(o => o.DueDate) : query.OrderBy(o => o.DueDate);
								 break;
							case "DueDate_desc":
                                query = isOrdered ? ordered.ThenByDescending(o => o.DueDate) : query.OrderByDescending(o => o.DueDate);
                                break;
							case "IDAccount":
								query = isOrdered ? ordered.ThenBy(o => o.IDAccount) : query.OrderBy(o => o.IDAccount);
								 break;
							case "IDAccount_desc":
                                query = isOrdered ? ordered.ThenByDescending(o => o.IDAccount) : query.OrderByDescending(o => o.IDAccount);
                                break;
							case "RefAccountCode":
								query = isOrdered ? ordered.ThenBy(o => o.RefAccountCode) : query.OrderBy(o => o.RefAccountCode);
								 break;
							case "RefAccountCode_desc":
                                query = isOrdered ? ordered.ThenByDescending(o => o.RefAccountCode) : query.OrderByDescending(o => o.RefAccountCode);
                                break;
							case "OffsetAccount":
								query = isOrdered ? ordered.ThenBy(o => o.OffsetAccount) : query.OrderBy(o => o.OffsetAccount);
								 break;
							case "OffsetAccount_desc":
                                query = isOrdered ? ordered.ThenByDescending(o => o.OffsetAccount) : query.OrderByDescending(o => o.OffsetAccount);
                                break;
							case "RefOffsetAccount":
								query = isOrdered ? ordered.ThenBy(o => o.RefOffsetAccount) : query.OrderBy(o => o.RefOffsetAccount);
								 break;
							case "RefOffsetAccount_desc":
                                query = isOrdered ? ordered.ThenByDescending(o => o.RefOffsetAccount) : query.OrderByDescending(o => o.RefOffsetAccount);
                                break;
							case "RefCFTId":
								query = isOrdered ? ordered.ThenBy(o => o.RefCFTId) : query.OrderBy(o => o.RefCFTId);
								 break;
							case "RefCFTId_desc":
                                query = isOrdered ? ordered.ThenByDescending(o => o.RefCFTId) : query.OrderByDescending(o => o.RefCFTId);
                                break;
							case "RefCFWId":
								query = isOrdered ? ordered.ThenBy(o => o.RefCFWId) : query.OrderBy(o => o.RefCFWId);
								 break;
							case "RefCFWId_desc":
                                query = isOrdered ? ordered.ThenByDescending(o => o.RefCFWId) : query.OrderByDescending(o => o.RefCFWId);
                                break;
							case "Remark":
								query = isOrdered ? ordered.ThenBy(o => o.Remark) : query.OrderBy(o => o.Remark);
								 break;
							case "Remark_desc":
                                query = isOrdered ? ordered.ThenByDescending(o => o.Remark) : query.OrderByDescending(o => o.Remark);
                                break;
							case "DocumentDate":
								query = isOrdered ? ordered.ThenBy(o => o.DocumentDate) : query.OrderBy(o => o.DocumentDate);
								 break;
							case "DocumentDate_desc":
                                query = isOrdered ? ordered.ThenByDescending(o => o.DocumentDate) : query.OrderByDescending(o => o.DocumentDate);
                                break;
							case "PostingPeriod":
								query = isOrdered ? ordered.ThenBy(o => o.PostingPeriod) : query.OrderBy(o => o.PostingPeriod);
								 break;
							case "PostingPeriod_desc":
                                query = isOrdered ? ordered.ThenByDescending(o => o.PostingPeriod) : query.OrderByDescending(o => o.PostingPeriod);
                                break;
							case "DistributionRule":
								query = isOrdered ? ordered.ThenBy(o => o.DistributionRule) : query.OrderBy(o => o.DistributionRule);
								 break;
							case "DistributionRule_desc":
                                query = isOrdered ? ordered.ThenByDescending(o => o.DistributionRule) : query.OrderByDescending(o => o.DistributionRule);
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
                            default:
                                if(!isOrdered)
                                    query = query.OrderBy(o => o.Id);
                                break;
                        }
                    }
                    else
                    {
                        query = query.OrderBy(o => o.Id);
                    }
            }
            else
            {
                query = query.OrderBy(o => o.Id);
            }

            return query;
        }

        public static IQueryable<tbl_AC_JournalEntryRow> _pagingBuilder(IQueryable<tbl_AC_JournalEntryRow> query, Dictionary<string, string> QueryStrings)
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






