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
    
    
    public partial class tbl_SYS_SyncJob
    {
        public int Id { get; set; }
        public string Type { get; set; }
        public string Command { get; set; }
        public Nullable<int> IDBranch { get; set; }
        public Nullable<decimal> RefNum1 { get; set; }
        public Nullable<decimal> RefNum2 { get; set; }
        public Nullable<decimal> RefNum3 { get; set; }
        public Nullable<decimal> RefNum4 { get; set; }
        public string RefChar1 { get; set; }
        public string RefChar2 { get; set; }
        public string RefChar3 { get; set; }
        public bool IsDone { get; set; }
        public System.DateTime CreatedDate { get; set; }
        public string CreatedBy { get; set; }
        public int TryCount { get; set; }
        public Nullable<System.DateTime> ExeDate { get; set; }
        public bool IsRunning { get; set; }
        public string ErrorMessage { get; set; }
    }
}


namespace DTOModel
{
	using System;
	public partial class DTO_SYS_SyncJob
	{
		public int Id { get; set; }
		public string Type { get; set; }
		public string Command { get; set; }
		public Nullable<int> IDBranch { get; set; }
		public Nullable<decimal> RefNum1 { get; set; }
		public Nullable<decimal> RefNum2 { get; set; }
		public Nullable<decimal> RefNum3 { get; set; }
		public Nullable<decimal> RefNum4 { get; set; }
		public string RefChar1 { get; set; }
		public string RefChar2 { get; set; }
		public string RefChar3 { get; set; }
		public bool IsDone { get; set; }
		public System.DateTime CreatedDate { get; set; }
		public string CreatedBy { get; set; }
		public int TryCount { get; set; }
		public Nullable<System.DateTime> ExeDate { get; set; }
		public bool IsRunning { get; set; }
		public string ErrorMessage { get; set; }
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

    public static partial class BS_SYS_SyncJob 
    {
        public static dynamic getSearch(AppEntities db, int IDBranch, int StaffID, Dictionary<string, string> QueryStrings)
        {
            return get(db, IDBranch,StaffID, QueryStrings);
        }

		public static IQueryable<DTO_SYS_SyncJob> get(AppEntities db, int IDBranch, int StaffID, Dictionary<string, string> QueryStrings)
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
            package.Workbook.Properties.Title = "ART-DMS SYS_SyncJob";
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

		public static DTO_SYS_SyncJob getAnItem(AppEntities db, int IDBranch, int StaffID, int id)
        {
            var dbResult = db.tbl_SYS_SyncJob.Find(id);

			//if (dbResult == null || (IDBranch != 0 && dbResult.IDBranch != IDBranch))
			//	return null; 
			//else 
				return toDTO(dbResult);
			
        }
		

		public static bool put(AppEntities db, int IDBranch, int StaffID, int Id, dynamic item, string Username, Dictionary<string, string> QueryStrings)
        {
            bool result = false;
            var dbitem = db.tbl_SYS_SyncJob.Find(Id);
            
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
					errorLog.logMessage("put_SYS_SyncJob",e);
                    result = false;
                }
            }
            else
                if (QueryStrings.Any(d => d.Key == "ForceCreate"))
                    result =  post(db, IDBranch, StaffID, item, Username) != null;
                
            return result;
        }

        public static void patchDynamicToDB(dynamic item, tbl_SYS_SyncJob dbitem, string Username)
        {
            Type type = typeof(tbl_SYS_SyncJob);
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

            
        }

        public static void patchDTOtoDBValue( DTO_SYS_SyncJob item, tbl_SYS_SyncJob dbitem)
        {
            if (item == null){
                dbitem = null;
                return;
            }
            							
			dbitem.Type = item.Type;							
			dbitem.Command = item.Command;							
			dbitem.IDBranch = item.IDBranch;							
			dbitem.RefNum1 = item.RefNum1;							
			dbitem.RefNum2 = item.RefNum2;							
			dbitem.RefNum3 = item.RefNum3;							
			dbitem.RefNum4 = item.RefNum4;							
			dbitem.RefChar1 = item.RefChar1;							
			dbitem.RefChar2 = item.RefChar2;							
			dbitem.RefChar3 = item.RefChar3;							
			dbitem.IsDone = item.IsDone;							
			dbitem.TryCount = item.TryCount;							
			dbitem.ExeDate = item.ExeDate;							
			dbitem.IsRunning = item.IsRunning;							
			dbitem.ErrorMessage = item.ErrorMessage;        }

		public static DTO_SYS_SyncJob post(AppEntities db, int IDBranch, int StaffID, dynamic item, string Username)
        {
            tbl_SYS_SyncJob dbitem = new tbl_SYS_SyncJob();
            if (item != null)
            {
                patchDynamicToDB(item, dbitem, Username);
                
								
                try
                {
					db.tbl_SYS_SyncJob.Add(dbitem);
                    db.SaveChanges();
				
                }
                catch (DbEntityValidationException e)
                {
					errorLog.logMessage("post_SYS_SyncJob",e);
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
                Type type = Type.GetType("BaseBusiness.BS_SYS_SyncJob, ClassLibrary");
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
                        var target = new tbl_SYS_SyncJob();
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
                    
                    tbl_SYS_SyncJob dbitem = new tbl_SYS_SyncJob();
                    if (it.Id == null || string.IsNullOrEmpty(it.Id.Value) || it.Id == "0")
                    {
                        dbitem = new tbl_SYS_SyncJob();
                                            }
                    else
                    {
                        dbitem = db.tbl_SYS_SyncJob.Find((int)it.Id);
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
                        
                        if (dbitem.Id == 0) db.tbl_SYS_SyncJob.Add(dbitem);
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
                    errorLog.logMessage("post_SYS_SyncJob",e);
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

            var dbitems = db.tbl_SYS_SyncJob.Where(d => IDs.Contains(d.Id));
            var updateDate = DateTime.Now;
            List<int?> IDBranches = new List<int?>();

            foreach (var dbitem in dbitems)
            {
			
				db.tbl_SYS_SyncJob.Remove(dbitem);
			            
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
                    BS_Version.update_Version(db, IDBranch, "DTO_SYS_SyncJob", updateDate, Username);
                }
			
            }
            catch (DbEntityValidationException e)
            {
				errorLog.logMessage("delete_SYS_SyncJob",e);
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
            			return db.tbl_SYS_SyncJob.Any(e => e.Id == id);
            
		}
		
		//---//
		public static IQueryable<DTO_SYS_SyncJob> toDTO(IQueryable<tbl_SYS_SyncJob> query)
        {
			return query
			.Select(s => new DTO_SYS_SyncJob(){							
				Id = s.Id,							
				Type = s.Type,							
				Command = s.Command,							
				IDBranch = s.IDBranch,							
				RefNum1 = s.RefNum1,							
				RefNum2 = s.RefNum2,							
				RefNum3 = s.RefNum3,							
				RefNum4 = s.RefNum4,							
				RefChar1 = s.RefChar1,							
				RefChar2 = s.RefChar2,							
				RefChar3 = s.RefChar3,							
				IsDone = s.IsDone,							
				CreatedDate = s.CreatedDate,							
				CreatedBy = s.CreatedBy,							
				TryCount = s.TryCount,							
				ExeDate = s.ExeDate,							
				IsRunning = s.IsRunning,							
				ErrorMessage = s.ErrorMessage,					
			});//;
                              
        }

		public static DTO_SYS_SyncJob toDTO(tbl_SYS_SyncJob dbResult)
        {
			if (dbResult != null)
			{
				return new DTO_SYS_SyncJob()
				{							
					Id = dbResult.Id,							
					Type = dbResult.Type,							
					Command = dbResult.Command,							
					IDBranch = dbResult.IDBranch,							
					RefNum1 = dbResult.RefNum1,							
					RefNum2 = dbResult.RefNum2,							
					RefNum3 = dbResult.RefNum3,							
					RefNum4 = dbResult.RefNum4,							
					RefChar1 = dbResult.RefChar1,							
					RefChar2 = dbResult.RefChar2,							
					RefChar3 = dbResult.RefChar3,							
					IsDone = dbResult.IsDone,							
					CreatedDate = dbResult.CreatedDate,							
					CreatedBy = dbResult.CreatedBy,							
					TryCount = dbResult.TryCount,							
					ExeDate = dbResult.ExeDate,							
					IsRunning = dbResult.IsRunning,							
					ErrorMessage = dbResult.ErrorMessage,
				};
			}
			else
				return null; 
        }

		public static IQueryable<tbl_SYS_SyncJob> _queryBuilder(AppEntities db, int IDBranch, int StaffID, Dictionary<string, string> QueryStrings)
        {
            
			IQueryable<tbl_SYS_SyncJob> query = db.tbl_SYS_SyncJob.AsNoTracking();//;
			

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

			//Query Type (string)
			if (QueryStrings.Any(d => d.Key == "Type_eq") && !string.IsNullOrEmpty(QueryStrings.FirstOrDefault(d => d.Key == "Type_eq").Value))
            {
                var keyword = QueryStrings.FirstOrDefault(d => d.Key == "Type_eq").Value;
                query = query.Where(d=>d.Type == keyword);
            }
            if (QueryStrings.Any(d => d.Key == "Type") && !string.IsNullOrEmpty(QueryStrings.FirstOrDefault(d => d.Key == "Type").Value))
            {
                var keyword = QueryStrings.FirstOrDefault(d => d.Key == "Type").Value;
                query = query.Where(d=>d.Type.Contains(keyword));
            }
            

			//Query Command (string)
			if (QueryStrings.Any(d => d.Key == "Command_eq") && !string.IsNullOrEmpty(QueryStrings.FirstOrDefault(d => d.Key == "Command_eq").Value))
            {
                var keyword = QueryStrings.FirstOrDefault(d => d.Key == "Command_eq").Value;
                query = query.Where(d=>d.Command == keyword);
            }
            if (QueryStrings.Any(d => d.Key == "Command") && !string.IsNullOrEmpty(QueryStrings.FirstOrDefault(d => d.Key == "Command").Value))
            {
                var keyword = QueryStrings.FirstOrDefault(d => d.Key == "Command").Value;
                query = query.Where(d=>d.Command.Contains(keyword));
            }
            

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

			//Query RefNum1 (Nullable<decimal>)
			if (QueryStrings.Any(d => d.Key == "RefNum1From") && QueryStrings.Any(d => d.Key == "RefNum1To"))
                if (decimal.TryParse(QueryStrings.FirstOrDefault(d => d.Key == "RefNum1From").Value, out decimal fromVal) && decimal.TryParse(QueryStrings.FirstOrDefault(d => d.Key == "RefNum1To").Value, out decimal toVal))
                    query = query.Where(d => fromVal <= d.RefNum1 && d.RefNum1 <= toVal);

			//Query RefNum2 (Nullable<decimal>)
			if (QueryStrings.Any(d => d.Key == "RefNum2From") && QueryStrings.Any(d => d.Key == "RefNum2To"))
                if (decimal.TryParse(QueryStrings.FirstOrDefault(d => d.Key == "RefNum2From").Value, out decimal fromVal) && decimal.TryParse(QueryStrings.FirstOrDefault(d => d.Key == "RefNum2To").Value, out decimal toVal))
                    query = query.Where(d => fromVal <= d.RefNum2 && d.RefNum2 <= toVal);

			//Query RefNum3 (Nullable<decimal>)
			if (QueryStrings.Any(d => d.Key == "RefNum3From") && QueryStrings.Any(d => d.Key == "RefNum3To"))
                if (decimal.TryParse(QueryStrings.FirstOrDefault(d => d.Key == "RefNum3From").Value, out decimal fromVal) && decimal.TryParse(QueryStrings.FirstOrDefault(d => d.Key == "RefNum3To").Value, out decimal toVal))
                    query = query.Where(d => fromVal <= d.RefNum3 && d.RefNum3 <= toVal);

			//Query RefNum4 (Nullable<decimal>)
			if (QueryStrings.Any(d => d.Key == "RefNum4From") && QueryStrings.Any(d => d.Key == "RefNum4To"))
                if (decimal.TryParse(QueryStrings.FirstOrDefault(d => d.Key == "RefNum4From").Value, out decimal fromVal) && decimal.TryParse(QueryStrings.FirstOrDefault(d => d.Key == "RefNum4To").Value, out decimal toVal))
                    query = query.Where(d => fromVal <= d.RefNum4 && d.RefNum4 <= toVal);

			//Query RefChar1 (string)
			if (QueryStrings.Any(d => d.Key == "RefChar1_eq") && !string.IsNullOrEmpty(QueryStrings.FirstOrDefault(d => d.Key == "RefChar1_eq").Value))
            {
                var keyword = QueryStrings.FirstOrDefault(d => d.Key == "RefChar1_eq").Value;
                query = query.Where(d=>d.RefChar1 == keyword);
            }
            if (QueryStrings.Any(d => d.Key == "RefChar1") && !string.IsNullOrEmpty(QueryStrings.FirstOrDefault(d => d.Key == "RefChar1").Value))
            {
                var keyword = QueryStrings.FirstOrDefault(d => d.Key == "RefChar1").Value;
                query = query.Where(d=>d.RefChar1.Contains(keyword));
            }
            

			//Query RefChar2 (string)
			if (QueryStrings.Any(d => d.Key == "RefChar2_eq") && !string.IsNullOrEmpty(QueryStrings.FirstOrDefault(d => d.Key == "RefChar2_eq").Value))
            {
                var keyword = QueryStrings.FirstOrDefault(d => d.Key == "RefChar2_eq").Value;
                query = query.Where(d=>d.RefChar2 == keyword);
            }
            if (QueryStrings.Any(d => d.Key == "RefChar2") && !string.IsNullOrEmpty(QueryStrings.FirstOrDefault(d => d.Key == "RefChar2").Value))
            {
                var keyword = QueryStrings.FirstOrDefault(d => d.Key == "RefChar2").Value;
                query = query.Where(d=>d.RefChar2.Contains(keyword));
            }
            

			//Query RefChar3 (string)
			if (QueryStrings.Any(d => d.Key == "RefChar3_eq") && !string.IsNullOrEmpty(QueryStrings.FirstOrDefault(d => d.Key == "RefChar3_eq").Value))
            {
                var keyword = QueryStrings.FirstOrDefault(d => d.Key == "RefChar3_eq").Value;
                query = query.Where(d=>d.RefChar3 == keyword);
            }
            if (QueryStrings.Any(d => d.Key == "RefChar3") && !string.IsNullOrEmpty(QueryStrings.FirstOrDefault(d => d.Key == "RefChar3").Value))
            {
                var keyword = QueryStrings.FirstOrDefault(d => d.Key == "RefChar3").Value;
                query = query.Where(d=>d.RefChar3.Contains(keyword));
            }
            

			//Query IsDone (bool)
			if (QueryStrings.Any(d => d.Key == "IsDone"))
            {
                var qValue = QueryStrings.FirstOrDefault(d => d.Key == "IsDone").Value;
                if (bool.TryParse(qValue, out bool qBoolValue))
                    query = query.Where(d => qBoolValue == d.IsDone);
            }

			//Query CreatedDate (System.DateTime)
			if (QueryStrings.Any(d => d.Key == "CreatedDateFrom") && QueryStrings.Any(d => d.Key == "CreatedDateTo"))
                if (DateTime.TryParse(QueryStrings.FirstOrDefault(d => d.Key == "CreatedDateFrom").Value, out DateTime fromDate) && DateTime.TryParse(QueryStrings.FirstOrDefault(d => d.Key == "CreatedDateTo").Value, out DateTime toDate))
                    query = query.Where(d => fromDate <= d.CreatedDate && d.CreatedDate <= toDate);

            if (QueryStrings.Any(d => d.Key == "CreatedDate"))
                if (DateTime.TryParse(QueryStrings.FirstOrDefault(d => d.Key == "CreatedDate").Value, out DateTime val))
                    query = query.Where(d => d.CreatedDate != null && DbFunctions.TruncateTime(val) == DbFunctions.TruncateTime(d.CreatedDate));


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
            

			//Query TryCount (int)
			if (QueryStrings.Any(d => d.Key == "TryCountFrom") && QueryStrings.Any(d => d.Key == "TryCountTo"))
                if (int.TryParse(QueryStrings.FirstOrDefault(d => d.Key == "TryCountFrom").Value, out int fromVal) && int.TryParse(QueryStrings.FirstOrDefault(d => d.Key == "TryCountTo").Value, out int toVal))
                    query = query.Where(d => fromVal <= d.TryCount && d.TryCount <= toVal);
            
            if (QueryStrings.Any(d => d.Key == "TryCount"))
                if (int.TryParse(QueryStrings.FirstOrDefault(d => d.Key == "TryCount").Value, out int val))
                    query = query.Where(d => val == d.TryCount);


			//Query ExeDate (Nullable<System.DateTime>)
			if (QueryStrings.Any(d => d.Key == "ExeDateFrom") && QueryStrings.Any(d => d.Key == "ExeDateTo"))
                if (DateTime.TryParse(QueryStrings.FirstOrDefault(d => d.Key == "ExeDateFrom").Value, out DateTime fromDate) && DateTime.TryParse(QueryStrings.FirstOrDefault(d => d.Key == "ExeDateTo").Value, out DateTime toDate))
                    query = query.Where(d => fromDate <= d.ExeDate && d.ExeDate <= toDate);

            if (QueryStrings.Any(d => d.Key == "ExeDate"))
                if (DateTime.TryParse(QueryStrings.FirstOrDefault(d => d.Key == "ExeDate").Value, out DateTime val))
                    query = query.Where(d => d.ExeDate != null && DbFunctions.TruncateTime(val) == DbFunctions.TruncateTime(d.ExeDate));


			//Query IsRunning (bool)
			if (QueryStrings.Any(d => d.Key == "IsRunning"))
            {
                var qValue = QueryStrings.FirstOrDefault(d => d.Key == "IsRunning").Value;
                if (bool.TryParse(qValue, out bool qBoolValue))
                    query = query.Where(d => qBoolValue == d.IsRunning);
            }

			//Query ErrorMessage (string)
			if (QueryStrings.Any(d => d.Key == "ErrorMessage_eq") && !string.IsNullOrEmpty(QueryStrings.FirstOrDefault(d => d.Key == "ErrorMessage_eq").Value))
            {
                var keyword = QueryStrings.FirstOrDefault(d => d.Key == "ErrorMessage_eq").Value;
                query = query.Where(d=>d.ErrorMessage == keyword);
            }
            if (QueryStrings.Any(d => d.Key == "ErrorMessage") && !string.IsNullOrEmpty(QueryStrings.FirstOrDefault(d => d.Key == "ErrorMessage").Value))
            {
                var keyword = QueryStrings.FirstOrDefault(d => d.Key == "ErrorMessage").Value;
                query = query.Where(d=>d.ErrorMessage.Contains(keyword));
            }
            
            return query;
        }
		
        public static IQueryable<tbl_SYS_SyncJob> _sortBuilder(IQueryable<tbl_SYS_SyncJob> query, Dictionary<string, string> QueryStrings)
        {
            if (QueryStrings.Any(d => d.Key == "SortBy"))
            {
                var sorts = QueryStrings.FirstOrDefault(d => d.Key == "SortBy").Value.Replace("[", "").Replace("]", "").Split(',');
                
                foreach (var item in sorts)
                    if (!string.IsNullOrEmpty(item))
                    {
                        var ordered = query as IOrderedQueryable<tbl_SYS_SyncJob>;
                        bool isOrdered = ordered.ToString().IndexOf("ORDER BY") !=-1;

                        switch (item)
                        {
							case "Id":
								query = isOrdered ? ordered.ThenBy(o => o.Id) : query.OrderBy(o => o.Id);
								 break;
							case "Id_desc":
                                query = isOrdered ? ordered.ThenByDescending(o => o.Id) : query.OrderByDescending(o => o.Id);
                                break;
							case "Type":
								query = isOrdered ? ordered.ThenBy(o => o.Type) : query.OrderBy(o => o.Type);
								 break;
							case "Type_desc":
                                query = isOrdered ? ordered.ThenByDescending(o => o.Type) : query.OrderByDescending(o => o.Type);
                                break;
							case "Command":
								query = isOrdered ? ordered.ThenBy(o => o.Command) : query.OrderBy(o => o.Command);
								 break;
							case "Command_desc":
                                query = isOrdered ? ordered.ThenByDescending(o => o.Command) : query.OrderByDescending(o => o.Command);
                                break;
							case "IDBranch":
								query = isOrdered ? ordered.ThenBy(o => o.IDBranch) : query.OrderBy(o => o.IDBranch);
								 break;
							case "IDBranch_desc":
                                query = isOrdered ? ordered.ThenByDescending(o => o.IDBranch) : query.OrderByDescending(o => o.IDBranch);
                                break;
							case "RefNum1":
								query = isOrdered ? ordered.ThenBy(o => o.RefNum1) : query.OrderBy(o => o.RefNum1);
								 break;
							case "RefNum1_desc":
                                query = isOrdered ? ordered.ThenByDescending(o => o.RefNum1) : query.OrderByDescending(o => o.RefNum1);
                                break;
							case "RefNum2":
								query = isOrdered ? ordered.ThenBy(o => o.RefNum2) : query.OrderBy(o => o.RefNum2);
								 break;
							case "RefNum2_desc":
                                query = isOrdered ? ordered.ThenByDescending(o => o.RefNum2) : query.OrderByDescending(o => o.RefNum2);
                                break;
							case "RefNum3":
								query = isOrdered ? ordered.ThenBy(o => o.RefNum3) : query.OrderBy(o => o.RefNum3);
								 break;
							case "RefNum3_desc":
                                query = isOrdered ? ordered.ThenByDescending(o => o.RefNum3) : query.OrderByDescending(o => o.RefNum3);
                                break;
							case "RefNum4":
								query = isOrdered ? ordered.ThenBy(o => o.RefNum4) : query.OrderBy(o => o.RefNum4);
								 break;
							case "RefNum4_desc":
                                query = isOrdered ? ordered.ThenByDescending(o => o.RefNum4) : query.OrderByDescending(o => o.RefNum4);
                                break;
							case "RefChar1":
								query = isOrdered ? ordered.ThenBy(o => o.RefChar1) : query.OrderBy(o => o.RefChar1);
								 break;
							case "RefChar1_desc":
                                query = isOrdered ? ordered.ThenByDescending(o => o.RefChar1) : query.OrderByDescending(o => o.RefChar1);
                                break;
							case "RefChar2":
								query = isOrdered ? ordered.ThenBy(o => o.RefChar2) : query.OrderBy(o => o.RefChar2);
								 break;
							case "RefChar2_desc":
                                query = isOrdered ? ordered.ThenByDescending(o => o.RefChar2) : query.OrderByDescending(o => o.RefChar2);
                                break;
							case "RefChar3":
								query = isOrdered ? ordered.ThenBy(o => o.RefChar3) : query.OrderBy(o => o.RefChar3);
								 break;
							case "RefChar3_desc":
                                query = isOrdered ? ordered.ThenByDescending(o => o.RefChar3) : query.OrderByDescending(o => o.RefChar3);
                                break;
							case "IsDone":
								query = isOrdered ? ordered.ThenBy(o => o.IsDone) : query.OrderBy(o => o.IsDone);
								 break;
							case "IsDone_desc":
                                query = isOrdered ? ordered.ThenByDescending(o => o.IsDone) : query.OrderByDescending(o => o.IsDone);
                                break;
							case "CreatedDate":
								query = isOrdered ? ordered.ThenBy(o => o.CreatedDate) : query.OrderBy(o => o.CreatedDate);
								 break;
							case "CreatedDate_desc":
                                query = isOrdered ? ordered.ThenByDescending(o => o.CreatedDate) : query.OrderByDescending(o => o.CreatedDate);
                                break;
							case "CreatedBy":
								query = isOrdered ? ordered.ThenBy(o => o.CreatedBy) : query.OrderBy(o => o.CreatedBy);
								 break;
							case "CreatedBy_desc":
                                query = isOrdered ? ordered.ThenByDescending(o => o.CreatedBy) : query.OrderByDescending(o => o.CreatedBy);
                                break;
							case "TryCount":
								query = isOrdered ? ordered.ThenBy(o => o.TryCount) : query.OrderBy(o => o.TryCount);
								 break;
							case "TryCount_desc":
                                query = isOrdered ? ordered.ThenByDescending(o => o.TryCount) : query.OrderByDescending(o => o.TryCount);
                                break;
							case "ExeDate":
								query = isOrdered ? ordered.ThenBy(o => o.ExeDate) : query.OrderBy(o => o.ExeDate);
								 break;
							case "ExeDate_desc":
                                query = isOrdered ? ordered.ThenByDescending(o => o.ExeDate) : query.OrderByDescending(o => o.ExeDate);
                                break;
							case "IsRunning":
								query = isOrdered ? ordered.ThenBy(o => o.IsRunning) : query.OrderBy(o => o.IsRunning);
								 break;
							case "IsRunning_desc":
                                query = isOrdered ? ordered.ThenByDescending(o => o.IsRunning) : query.OrderByDescending(o => o.IsRunning);
                                break;
							case "ErrorMessage":
								query = isOrdered ? ordered.ThenBy(o => o.ErrorMessage) : query.OrderBy(o => o.ErrorMessage);
								 break;
							case "ErrorMessage_desc":
                                query = isOrdered ? ordered.ThenByDescending(o => o.ErrorMessage) : query.OrderByDescending(o => o.ErrorMessage);
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

        public static IQueryable<tbl_SYS_SyncJob> _pagingBuilder(IQueryable<tbl_SYS_SyncJob> query, Dictionary<string, string> QueryStrings)
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






