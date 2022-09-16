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
    
    
    public partial class tbl_SYS_Log
    {
        public int Id { get; set; }
        public string AppName { get; set; }
        public string LoggedBy { get; set; }
        public System.DateTime Date { get; set; }
        public string Level { get; set; }
        public string Logger { get; set; }
        public string Message { get; set; }
        public string Method { get; set; }
        public string API { get; set; }
        public string Data { get; set; }
        public string Exception { get; set; }
        public string Thread { get; set; }
        public string IPAddress { get; set; }
        public string IPAddressLan { get; set; }
        public bool IsDeleted { get; set; }
        public string AppVersion { get; set; }
        public string Segment0 { get; set; }
        public string Segment1 { get; set; }
        public string Segment2 { get; set; }
        public string Segment3 { get; set; }
        public string Segment4 { get; set; }
        public string Segment5 { get; set; }
        public string Segment6 { get; set; }
        public string Segment7 { get; set; }
        public string Segment8 { get; set; }
        public string Segment9 { get; set; }
    }
}


namespace DTOModel
{
	using System;
	public partial class DTO_SYS_Log
	{
		public int Id { get; set; }
		public string AppName { get; set; }
		public string LoggedBy { get; set; }
		public System.DateTime Date { get; set; }
		public string Level { get; set; }
		public string Logger { get; set; }
		public string Message { get; set; }
		public string Method { get; set; }
		public string API { get; set; }
		public string Data { get; set; }
		public string Exception { get; set; }
		public string Thread { get; set; }
		public string IPAddress { get; set; }
		public string IPAddressLan { get; set; }
		public bool IsDeleted { get; set; }
		public string AppVersion { get; set; }
		public string Segment0 { get; set; }
		public string Segment1 { get; set; }
		public string Segment2 { get; set; }
		public string Segment3 { get; set; }
		public string Segment4 { get; set; }
		public string Segment5 { get; set; }
		public string Segment6 { get; set; }
		public string Segment7 { get; set; }
		public string Segment8 { get; set; }
		public string Segment9 { get; set; }
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

    public static partial class BS_SYS_Log 
    {
        public static dynamic getSearch(AppEntities db, int IDBranch, int StaffID, Dictionary<string, string> QueryStrings)
        {
            return get(db, IDBranch,StaffID, QueryStrings);
        }

		public static IQueryable<DTO_SYS_Log> get(AppEntities db, int IDBranch, int StaffID, Dictionary<string, string> QueryStrings)
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
            package.Workbook.Properties.Title = "ART-DMS SYS_Log";
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

		public static DTO_SYS_Log getAnItem(AppEntities db, int IDBranch, int StaffID, int id)
        {
            var dbResult = db.tbl_SYS_Log.Find(id);

			return toDTO(dbResult);
			
        }
		

		public static bool put(AppEntities db, int IDBranch, int StaffID, int Id, dynamic item, string Username, Dictionary<string, string> QueryStrings)
        {
            bool result = false;
            var dbitem = db.tbl_SYS_Log.Find(Id);
            
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
					errorLog.logMessage("put_SYS_Log",e);
                    result = false;
                }
            }
            else
                if (QueryStrings.Any(d => d.Key == "ForceCreate"))
                    result =  post(db, IDBranch, StaffID, item, Username) != null;
                
            return result;
        }

        public static void patchDynamicToDB(dynamic item, tbl_SYS_Log dbitem, string Username)
        {
            Type type = typeof(tbl_SYS_Log);
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

        public static void patchDTOtoDBValue( DTO_SYS_Log item, tbl_SYS_Log dbitem)
        {
            if (item == null){
                dbitem = null;
                return;
            }
            							
			dbitem.AppName = item.AppName;							
			dbitem.LoggedBy = item.LoggedBy;							
			dbitem.Date = item.Date;							
			dbitem.Level = item.Level;							
			dbitem.Logger = item.Logger;							
			dbitem.Message = item.Message;							
			dbitem.Method = item.Method;							
			dbitem.API = item.API;							
			dbitem.Data = item.Data;							
			dbitem.Exception = item.Exception;							
			dbitem.Thread = item.Thread;							
			dbitem.IPAddress = item.IPAddress;							
			dbitem.IPAddressLan = item.IPAddressLan;							
			dbitem.IsDeleted = item.IsDeleted;							
			dbitem.AppVersion = item.AppVersion;							
			dbitem.Segment0 = item.Segment0;							
			dbitem.Segment1 = item.Segment1;							
			dbitem.Segment2 = item.Segment2;							
			dbitem.Segment3 = item.Segment3;							
			dbitem.Segment4 = item.Segment4;							
			dbitem.Segment5 = item.Segment5;							
			dbitem.Segment6 = item.Segment6;							
			dbitem.Segment7 = item.Segment7;							
			dbitem.Segment8 = item.Segment8;							
			dbitem.Segment9 = item.Segment9;        }

		public static DTO_SYS_Log post(AppEntities db, int IDBranch, int StaffID, dynamic item, string Username)
        {
            tbl_SYS_Log dbitem = new tbl_SYS_Log();
            if (item != null)
            {
                patchDynamicToDB(item, dbitem, Username);
                
								
                try
                {
					db.tbl_SYS_Log.Add(dbitem);
                    db.SaveChanges();
				
                }
                catch (DbEntityValidationException e)
                {
					errorLog.logMessage("post_SYS_Log",e);
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
                Type type = Type.GetType("BaseBusiness.BS_SYS_Log, ClassLibrary");
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
                        var target = new tbl_SYS_Log();
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
                    
                    tbl_SYS_Log dbitem = new tbl_SYS_Log();
                    if (it.Id == null || string.IsNullOrEmpty(it.Id.Value) || it.Id == "0")
                    {
                        dbitem = new tbl_SYS_Log();
                                            }
                    else
                    {
                        dbitem = db.tbl_SYS_Log.Find((int)it.Id);
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
                        
                        if (dbitem.Id == 0) db.tbl_SYS_Log.Add(dbitem);
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
                    errorLog.logMessage("post_SYS_Log",e);
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

            var dbitems = db.tbl_SYS_Log.Where(d => IDs.Contains(d.Id));
            var updateDate = DateTime.Now;
            List<int?> IDBranches = new List<int?>();

            foreach (var dbitem in dbitems)
            {
										            
                
            }

            try
            {
                db.SaveChanges();
                result = true;
			
                BS_Version.update_Version(db, null, "DTO_SYS_Log", updateDate, Username);
			
            }
            catch (DbEntityValidationException e)
            {
				errorLog.logMessage("delete_SYS_Log",e);
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
             
            return db.tbl_SYS_Log.Any(e => e.Id == id && e.IsDeleted == false);
            
		}
		
		//---//
		public static IQueryable<DTO_SYS_Log> toDTO(IQueryable<tbl_SYS_Log> query)
        {
			return query
			.Select(s => new DTO_SYS_Log(){							
				Id = s.Id,							
				AppName = s.AppName,							
				LoggedBy = s.LoggedBy,							
				Date = s.Date,							
				Level = s.Level,							
				Logger = s.Logger,							
				Message = s.Message,							
				Method = s.Method,							
				API = s.API,							
				Data = s.Data,							
				Exception = s.Exception,							
				Thread = s.Thread,							
				IPAddress = s.IPAddress,							
				IPAddressLan = s.IPAddressLan,							
				IsDeleted = s.IsDeleted,							
				AppVersion = s.AppVersion,							
				Segment0 = s.Segment0,							
				Segment1 = s.Segment1,							
				Segment2 = s.Segment2,							
				Segment3 = s.Segment3,							
				Segment4 = s.Segment4,							
				Segment5 = s.Segment5,							
				Segment6 = s.Segment6,							
				Segment7 = s.Segment7,							
				Segment8 = s.Segment8,							
				Segment9 = s.Segment9,					
			});//;
                              
        }

		public static DTO_SYS_Log toDTO(tbl_SYS_Log dbResult)
        {
			if (dbResult != null)
			{
				return new DTO_SYS_Log()
				{							
					Id = dbResult.Id,							
					AppName = dbResult.AppName,							
					LoggedBy = dbResult.LoggedBy,							
					Date = dbResult.Date,							
					Level = dbResult.Level,							
					Logger = dbResult.Logger,							
					Message = dbResult.Message,							
					Method = dbResult.Method,							
					API = dbResult.API,							
					Data = dbResult.Data,							
					Exception = dbResult.Exception,							
					Thread = dbResult.Thread,							
					IPAddress = dbResult.IPAddress,							
					IPAddressLan = dbResult.IPAddressLan,							
					IsDeleted = dbResult.IsDeleted,							
					AppVersion = dbResult.AppVersion,							
					Segment0 = dbResult.Segment0,							
					Segment1 = dbResult.Segment1,							
					Segment2 = dbResult.Segment2,							
					Segment3 = dbResult.Segment3,							
					Segment4 = dbResult.Segment4,							
					Segment5 = dbResult.Segment5,							
					Segment6 = dbResult.Segment6,							
					Segment7 = dbResult.Segment7,							
					Segment8 = dbResult.Segment8,							
					Segment9 = dbResult.Segment9,
				};
			}
			else
				return null; 
        }

		public static IQueryable<tbl_SYS_Log> _queryBuilder(AppEntities db, int IDBranch, int StaffID, Dictionary<string, string> QueryStrings)
        {
            
			IQueryable<tbl_SYS_Log> query = db.tbl_SYS_Log.AsNoTracking();//.Where(d => d.IsDeleted == false );
			

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

			//Query AppName (string)
			if (QueryStrings.Any(d => d.Key == "AppName_eq") && !string.IsNullOrEmpty(QueryStrings.FirstOrDefault(d => d.Key == "AppName_eq").Value))
            {
                var keyword = QueryStrings.FirstOrDefault(d => d.Key == "AppName_eq").Value;
                query = query.Where(d=>d.AppName == keyword);
            }
            if (QueryStrings.Any(d => d.Key == "AppName") && !string.IsNullOrEmpty(QueryStrings.FirstOrDefault(d => d.Key == "AppName").Value))
            {
                var keyword = QueryStrings.FirstOrDefault(d => d.Key == "AppName").Value;
                query = query.Where(d=>d.AppName.Contains(keyword));
            }
            

			//Query LoggedBy (string)
			if (QueryStrings.Any(d => d.Key == "LoggedBy_eq") && !string.IsNullOrEmpty(QueryStrings.FirstOrDefault(d => d.Key == "LoggedBy_eq").Value))
            {
                var keyword = QueryStrings.FirstOrDefault(d => d.Key == "LoggedBy_eq").Value;
                query = query.Where(d=>d.LoggedBy == keyword);
            }
            if (QueryStrings.Any(d => d.Key == "LoggedBy") && !string.IsNullOrEmpty(QueryStrings.FirstOrDefault(d => d.Key == "LoggedBy").Value))
            {
                var keyword = QueryStrings.FirstOrDefault(d => d.Key == "LoggedBy").Value;
                query = query.Where(d=>d.LoggedBy.Contains(keyword));
            }
            

			//Query Date (System.DateTime)
			if (QueryStrings.Any(d => d.Key == "DateFrom") && QueryStrings.Any(d => d.Key == "DateTo"))
                if (DateTime.TryParse(QueryStrings.FirstOrDefault(d => d.Key == "DateFrom").Value, out DateTime fromDate) && DateTime.TryParse(QueryStrings.FirstOrDefault(d => d.Key == "DateTo").Value, out DateTime toDate))
                    query = query.Where(d => fromDate <= d.Date && d.Date <= toDate);

            if (QueryStrings.Any(d => d.Key == "Date"))
                if (DateTime.TryParse(QueryStrings.FirstOrDefault(d => d.Key == "Date").Value, out DateTime val))
                    query = query.Where(d => d.Date != null && DbFunctions.TruncateTime(val) == DbFunctions.TruncateTime(d.Date));


			//Query Level (string)
			if (QueryStrings.Any(d => d.Key == "Level_eq") && !string.IsNullOrEmpty(QueryStrings.FirstOrDefault(d => d.Key == "Level_eq").Value))
            {
                var keyword = QueryStrings.FirstOrDefault(d => d.Key == "Level_eq").Value;
                query = query.Where(d=>d.Level == keyword);
            }
            if (QueryStrings.Any(d => d.Key == "Level") && !string.IsNullOrEmpty(QueryStrings.FirstOrDefault(d => d.Key == "Level").Value))
            {
                var keyword = QueryStrings.FirstOrDefault(d => d.Key == "Level").Value;
                query = query.Where(d=>d.Level.Contains(keyword));
            }
            

			//Query Logger (string)
			if (QueryStrings.Any(d => d.Key == "Logger_eq") && !string.IsNullOrEmpty(QueryStrings.FirstOrDefault(d => d.Key == "Logger_eq").Value))
            {
                var keyword = QueryStrings.FirstOrDefault(d => d.Key == "Logger_eq").Value;
                query = query.Where(d=>d.Logger == keyword);
            }
            if (QueryStrings.Any(d => d.Key == "Logger") && !string.IsNullOrEmpty(QueryStrings.FirstOrDefault(d => d.Key == "Logger").Value))
            {
                var keyword = QueryStrings.FirstOrDefault(d => d.Key == "Logger").Value;
                query = query.Where(d=>d.Logger.Contains(keyword));
            }
            

			//Query Message (string)
			if (QueryStrings.Any(d => d.Key == "Message_eq") && !string.IsNullOrEmpty(QueryStrings.FirstOrDefault(d => d.Key == "Message_eq").Value))
            {
                var keyword = QueryStrings.FirstOrDefault(d => d.Key == "Message_eq").Value;
                query = query.Where(d=>d.Message == keyword);
            }
            if (QueryStrings.Any(d => d.Key == "Message") && !string.IsNullOrEmpty(QueryStrings.FirstOrDefault(d => d.Key == "Message").Value))
            {
                var keyword = QueryStrings.FirstOrDefault(d => d.Key == "Message").Value;
                query = query.Where(d=>d.Message.Contains(keyword));
            }
            

			//Query Method (string)
			if (QueryStrings.Any(d => d.Key == "Method_eq") && !string.IsNullOrEmpty(QueryStrings.FirstOrDefault(d => d.Key == "Method_eq").Value))
            {
                var keyword = QueryStrings.FirstOrDefault(d => d.Key == "Method_eq").Value;
                query = query.Where(d=>d.Method == keyword);
            }
            if (QueryStrings.Any(d => d.Key == "Method") && !string.IsNullOrEmpty(QueryStrings.FirstOrDefault(d => d.Key == "Method").Value))
            {
                var keyword = QueryStrings.FirstOrDefault(d => d.Key == "Method").Value;
                query = query.Where(d=>d.Method.Contains(keyword));
            }
            

			//Query API (string)
			if (QueryStrings.Any(d => d.Key == "API_eq") && !string.IsNullOrEmpty(QueryStrings.FirstOrDefault(d => d.Key == "API_eq").Value))
            {
                var keyword = QueryStrings.FirstOrDefault(d => d.Key == "API_eq").Value;
                query = query.Where(d=>d.API == keyword);
            }
            if (QueryStrings.Any(d => d.Key == "API") && !string.IsNullOrEmpty(QueryStrings.FirstOrDefault(d => d.Key == "API").Value))
            {
                var keyword = QueryStrings.FirstOrDefault(d => d.Key == "API").Value;
                query = query.Where(d=>d.API.Contains(keyword));
            }
            

			//Query Data (string)
			if (QueryStrings.Any(d => d.Key == "Data_eq") && !string.IsNullOrEmpty(QueryStrings.FirstOrDefault(d => d.Key == "Data_eq").Value))
            {
                var keyword = QueryStrings.FirstOrDefault(d => d.Key == "Data_eq").Value;
                query = query.Where(d=>d.Data == keyword);
            }
            if (QueryStrings.Any(d => d.Key == "Data") && !string.IsNullOrEmpty(QueryStrings.FirstOrDefault(d => d.Key == "Data").Value))
            {
                var keyword = QueryStrings.FirstOrDefault(d => d.Key == "Data").Value;
                query = query.Where(d=>d.Data.Contains(keyword));
            }
            

			//Query Exception (string)
			if (QueryStrings.Any(d => d.Key == "Exception_eq") && !string.IsNullOrEmpty(QueryStrings.FirstOrDefault(d => d.Key == "Exception_eq").Value))
            {
                var keyword = QueryStrings.FirstOrDefault(d => d.Key == "Exception_eq").Value;
                query = query.Where(d=>d.Exception == keyword);
            }
            if (QueryStrings.Any(d => d.Key == "Exception") && !string.IsNullOrEmpty(QueryStrings.FirstOrDefault(d => d.Key == "Exception").Value))
            {
                var keyword = QueryStrings.FirstOrDefault(d => d.Key == "Exception").Value;
                query = query.Where(d=>d.Exception.Contains(keyword));
            }
            

			//Query Thread (string)
			if (QueryStrings.Any(d => d.Key == "Thread_eq") && !string.IsNullOrEmpty(QueryStrings.FirstOrDefault(d => d.Key == "Thread_eq").Value))
            {
                var keyword = QueryStrings.FirstOrDefault(d => d.Key == "Thread_eq").Value;
                query = query.Where(d=>d.Thread == keyword);
            }
            if (QueryStrings.Any(d => d.Key == "Thread") && !string.IsNullOrEmpty(QueryStrings.FirstOrDefault(d => d.Key == "Thread").Value))
            {
                var keyword = QueryStrings.FirstOrDefault(d => d.Key == "Thread").Value;
                query = query.Where(d=>d.Thread.Contains(keyword));
            }
            

			//Query IPAddress (string)
			if (QueryStrings.Any(d => d.Key == "IPAddress_eq") && !string.IsNullOrEmpty(QueryStrings.FirstOrDefault(d => d.Key == "IPAddress_eq").Value))
            {
                var keyword = QueryStrings.FirstOrDefault(d => d.Key == "IPAddress_eq").Value;
                query = query.Where(d=>d.IPAddress == keyword);
            }
            if (QueryStrings.Any(d => d.Key == "IPAddress") && !string.IsNullOrEmpty(QueryStrings.FirstOrDefault(d => d.Key == "IPAddress").Value))
            {
                var keyword = QueryStrings.FirstOrDefault(d => d.Key == "IPAddress").Value;
                query = query.Where(d=>d.IPAddress.Contains(keyword));
            }
            

			//Query IPAddressLan (string)
			if (QueryStrings.Any(d => d.Key == "IPAddressLan_eq") && !string.IsNullOrEmpty(QueryStrings.FirstOrDefault(d => d.Key == "IPAddressLan_eq").Value))
            {
                var keyword = QueryStrings.FirstOrDefault(d => d.Key == "IPAddressLan_eq").Value;
                query = query.Where(d=>d.IPAddressLan == keyword);
            }
            if (QueryStrings.Any(d => d.Key == "IPAddressLan") && !string.IsNullOrEmpty(QueryStrings.FirstOrDefault(d => d.Key == "IPAddressLan").Value))
            {
                var keyword = QueryStrings.FirstOrDefault(d => d.Key == "IPAddressLan").Value;
                query = query.Where(d=>d.IPAddressLan.Contains(keyword));
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

			//Query AppVersion (string)
			if (QueryStrings.Any(d => d.Key == "AppVersion_eq") && !string.IsNullOrEmpty(QueryStrings.FirstOrDefault(d => d.Key == "AppVersion_eq").Value))
            {
                var keyword = QueryStrings.FirstOrDefault(d => d.Key == "AppVersion_eq").Value;
                query = query.Where(d=>d.AppVersion == keyword);
            }
            if (QueryStrings.Any(d => d.Key == "AppVersion") && !string.IsNullOrEmpty(QueryStrings.FirstOrDefault(d => d.Key == "AppVersion").Value))
            {
                var keyword = QueryStrings.FirstOrDefault(d => d.Key == "AppVersion").Value;
                query = query.Where(d=>d.AppVersion.Contains(keyword));
            }
            

			//Query Segment0 (string)
			if (QueryStrings.Any(d => d.Key == "Segment0_eq") && !string.IsNullOrEmpty(QueryStrings.FirstOrDefault(d => d.Key == "Segment0_eq").Value))
            {
                var keyword = QueryStrings.FirstOrDefault(d => d.Key == "Segment0_eq").Value;
                query = query.Where(d=>d.Segment0 == keyword);
            }
            if (QueryStrings.Any(d => d.Key == "Segment0") && !string.IsNullOrEmpty(QueryStrings.FirstOrDefault(d => d.Key == "Segment0").Value))
            {
                var keyword = QueryStrings.FirstOrDefault(d => d.Key == "Segment0").Value;
                query = query.Where(d=>d.Segment0.Contains(keyword));
            }
            

			//Query Segment1 (string)
			if (QueryStrings.Any(d => d.Key == "Segment1_eq") && !string.IsNullOrEmpty(QueryStrings.FirstOrDefault(d => d.Key == "Segment1_eq").Value))
            {
                var keyword = QueryStrings.FirstOrDefault(d => d.Key == "Segment1_eq").Value;
                query = query.Where(d=>d.Segment1 == keyword);
            }
            if (QueryStrings.Any(d => d.Key == "Segment1") && !string.IsNullOrEmpty(QueryStrings.FirstOrDefault(d => d.Key == "Segment1").Value))
            {
                var keyword = QueryStrings.FirstOrDefault(d => d.Key == "Segment1").Value;
                query = query.Where(d=>d.Segment1.Contains(keyword));
            }
            

			//Query Segment2 (string)
			if (QueryStrings.Any(d => d.Key == "Segment2_eq") && !string.IsNullOrEmpty(QueryStrings.FirstOrDefault(d => d.Key == "Segment2_eq").Value))
            {
                var keyword = QueryStrings.FirstOrDefault(d => d.Key == "Segment2_eq").Value;
                query = query.Where(d=>d.Segment2 == keyword);
            }
            if (QueryStrings.Any(d => d.Key == "Segment2") && !string.IsNullOrEmpty(QueryStrings.FirstOrDefault(d => d.Key == "Segment2").Value))
            {
                var keyword = QueryStrings.FirstOrDefault(d => d.Key == "Segment2").Value;
                query = query.Where(d=>d.Segment2.Contains(keyword));
            }
            

			//Query Segment3 (string)
			if (QueryStrings.Any(d => d.Key == "Segment3_eq") && !string.IsNullOrEmpty(QueryStrings.FirstOrDefault(d => d.Key == "Segment3_eq").Value))
            {
                var keyword = QueryStrings.FirstOrDefault(d => d.Key == "Segment3_eq").Value;
                query = query.Where(d=>d.Segment3 == keyword);
            }
            if (QueryStrings.Any(d => d.Key == "Segment3") && !string.IsNullOrEmpty(QueryStrings.FirstOrDefault(d => d.Key == "Segment3").Value))
            {
                var keyword = QueryStrings.FirstOrDefault(d => d.Key == "Segment3").Value;
                query = query.Where(d=>d.Segment3.Contains(keyword));
            }
            

			//Query Segment4 (string)
			if (QueryStrings.Any(d => d.Key == "Segment4_eq") && !string.IsNullOrEmpty(QueryStrings.FirstOrDefault(d => d.Key == "Segment4_eq").Value))
            {
                var keyword = QueryStrings.FirstOrDefault(d => d.Key == "Segment4_eq").Value;
                query = query.Where(d=>d.Segment4 == keyword);
            }
            if (QueryStrings.Any(d => d.Key == "Segment4") && !string.IsNullOrEmpty(QueryStrings.FirstOrDefault(d => d.Key == "Segment4").Value))
            {
                var keyword = QueryStrings.FirstOrDefault(d => d.Key == "Segment4").Value;
                query = query.Where(d=>d.Segment4.Contains(keyword));
            }
            

			//Query Segment5 (string)
			if (QueryStrings.Any(d => d.Key == "Segment5_eq") && !string.IsNullOrEmpty(QueryStrings.FirstOrDefault(d => d.Key == "Segment5_eq").Value))
            {
                var keyword = QueryStrings.FirstOrDefault(d => d.Key == "Segment5_eq").Value;
                query = query.Where(d=>d.Segment5 == keyword);
            }
            if (QueryStrings.Any(d => d.Key == "Segment5") && !string.IsNullOrEmpty(QueryStrings.FirstOrDefault(d => d.Key == "Segment5").Value))
            {
                var keyword = QueryStrings.FirstOrDefault(d => d.Key == "Segment5").Value;
                query = query.Where(d=>d.Segment5.Contains(keyword));
            }
            

			//Query Segment6 (string)
			if (QueryStrings.Any(d => d.Key == "Segment6_eq") && !string.IsNullOrEmpty(QueryStrings.FirstOrDefault(d => d.Key == "Segment6_eq").Value))
            {
                var keyword = QueryStrings.FirstOrDefault(d => d.Key == "Segment6_eq").Value;
                query = query.Where(d=>d.Segment6 == keyword);
            }
            if (QueryStrings.Any(d => d.Key == "Segment6") && !string.IsNullOrEmpty(QueryStrings.FirstOrDefault(d => d.Key == "Segment6").Value))
            {
                var keyword = QueryStrings.FirstOrDefault(d => d.Key == "Segment6").Value;
                query = query.Where(d=>d.Segment6.Contains(keyword));
            }
            

			//Query Segment7 (string)
			if (QueryStrings.Any(d => d.Key == "Segment7_eq") && !string.IsNullOrEmpty(QueryStrings.FirstOrDefault(d => d.Key == "Segment7_eq").Value))
            {
                var keyword = QueryStrings.FirstOrDefault(d => d.Key == "Segment7_eq").Value;
                query = query.Where(d=>d.Segment7 == keyword);
            }
            if (QueryStrings.Any(d => d.Key == "Segment7") && !string.IsNullOrEmpty(QueryStrings.FirstOrDefault(d => d.Key == "Segment7").Value))
            {
                var keyword = QueryStrings.FirstOrDefault(d => d.Key == "Segment7").Value;
                query = query.Where(d=>d.Segment7.Contains(keyword));
            }
            

			//Query Segment8 (string)
			if (QueryStrings.Any(d => d.Key == "Segment8_eq") && !string.IsNullOrEmpty(QueryStrings.FirstOrDefault(d => d.Key == "Segment8_eq").Value))
            {
                var keyword = QueryStrings.FirstOrDefault(d => d.Key == "Segment8_eq").Value;
                query = query.Where(d=>d.Segment8 == keyword);
            }
            if (QueryStrings.Any(d => d.Key == "Segment8") && !string.IsNullOrEmpty(QueryStrings.FirstOrDefault(d => d.Key == "Segment8").Value))
            {
                var keyword = QueryStrings.FirstOrDefault(d => d.Key == "Segment8").Value;
                query = query.Where(d=>d.Segment8.Contains(keyword));
            }
            

			//Query Segment9 (string)
			if (QueryStrings.Any(d => d.Key == "Segment9_eq") && !string.IsNullOrEmpty(QueryStrings.FirstOrDefault(d => d.Key == "Segment9_eq").Value))
            {
                var keyword = QueryStrings.FirstOrDefault(d => d.Key == "Segment9_eq").Value;
                query = query.Where(d=>d.Segment9 == keyword);
            }
            if (QueryStrings.Any(d => d.Key == "Segment9") && !string.IsNullOrEmpty(QueryStrings.FirstOrDefault(d => d.Key == "Segment9").Value))
            {
                var keyword = QueryStrings.FirstOrDefault(d => d.Key == "Segment9").Value;
                query = query.Where(d=>d.Segment9.Contains(keyword));
            }
            
            return query;
        }
		
        public static IQueryable<tbl_SYS_Log> _sortBuilder(IQueryable<tbl_SYS_Log> query, Dictionary<string, string> QueryStrings)
        {
            if (QueryStrings.Any(d => d.Key == "SortBy"))
            {
                var sorts = QueryStrings.FirstOrDefault(d => d.Key == "SortBy").Value.Replace("[", "").Replace("]", "").Split(',');
                
                foreach (var item in sorts)
                    if (!string.IsNullOrEmpty(item))
                    {
                        var ordered = query as IOrderedQueryable<tbl_SYS_Log>;
                        bool isOrdered = ordered.ToString().IndexOf("ORDER BY") !=-1;

                        switch (item)
                        {
							case "Id":
								query = isOrdered ? ordered.ThenBy(o => o.Id) : query.OrderBy(o => o.Id);
								 break;
							case "Id_desc":
                                query = isOrdered ? ordered.ThenByDescending(o => o.Id) : query.OrderByDescending(o => o.Id);
                                break;
							case "AppName":
								query = isOrdered ? ordered.ThenBy(o => o.AppName) : query.OrderBy(o => o.AppName);
								 break;
							case "AppName_desc":
                                query = isOrdered ? ordered.ThenByDescending(o => o.AppName) : query.OrderByDescending(o => o.AppName);
                                break;
							case "LoggedBy":
								query = isOrdered ? ordered.ThenBy(o => o.LoggedBy) : query.OrderBy(o => o.LoggedBy);
								 break;
							case "LoggedBy_desc":
                                query = isOrdered ? ordered.ThenByDescending(o => o.LoggedBy) : query.OrderByDescending(o => o.LoggedBy);
                                break;
							case "Date":
								query = isOrdered ? ordered.ThenBy(o => o.Date) : query.OrderBy(o => o.Date);
								 break;
							case "Date_desc":
                                query = isOrdered ? ordered.ThenByDescending(o => o.Date) : query.OrderByDescending(o => o.Date);
                                break;
							case "Level":
								query = isOrdered ? ordered.ThenBy(o => o.Level) : query.OrderBy(o => o.Level);
								 break;
							case "Level_desc":
                                query = isOrdered ? ordered.ThenByDescending(o => o.Level) : query.OrderByDescending(o => o.Level);
                                break;
							case "Logger":
								query = isOrdered ? ordered.ThenBy(o => o.Logger) : query.OrderBy(o => o.Logger);
								 break;
							case "Logger_desc":
                                query = isOrdered ? ordered.ThenByDescending(o => o.Logger) : query.OrderByDescending(o => o.Logger);
                                break;
							case "Message":
								query = isOrdered ? ordered.ThenBy(o => o.Message) : query.OrderBy(o => o.Message);
								 break;
							case "Message_desc":
                                query = isOrdered ? ordered.ThenByDescending(o => o.Message) : query.OrderByDescending(o => o.Message);
                                break;
							case "Method":
								query = isOrdered ? ordered.ThenBy(o => o.Method) : query.OrderBy(o => o.Method);
								 break;
							case "Method_desc":
                                query = isOrdered ? ordered.ThenByDescending(o => o.Method) : query.OrderByDescending(o => o.Method);
                                break;
							case "API":
								query = isOrdered ? ordered.ThenBy(o => o.API) : query.OrderBy(o => o.API);
								 break;
							case "API_desc":
                                query = isOrdered ? ordered.ThenByDescending(o => o.API) : query.OrderByDescending(o => o.API);
                                break;
							case "Data":
								query = isOrdered ? ordered.ThenBy(o => o.Data) : query.OrderBy(o => o.Data);
								 break;
							case "Data_desc":
                                query = isOrdered ? ordered.ThenByDescending(o => o.Data) : query.OrderByDescending(o => o.Data);
                                break;
							case "Exception":
								query = isOrdered ? ordered.ThenBy(o => o.Exception) : query.OrderBy(o => o.Exception);
								 break;
							case "Exception_desc":
                                query = isOrdered ? ordered.ThenByDescending(o => o.Exception) : query.OrderByDescending(o => o.Exception);
                                break;
							case "Thread":
								query = isOrdered ? ordered.ThenBy(o => o.Thread) : query.OrderBy(o => o.Thread);
								 break;
							case "Thread_desc":
                                query = isOrdered ? ordered.ThenByDescending(o => o.Thread) : query.OrderByDescending(o => o.Thread);
                                break;
							case "IPAddress":
								query = isOrdered ? ordered.ThenBy(o => o.IPAddress) : query.OrderBy(o => o.IPAddress);
								 break;
							case "IPAddress_desc":
                                query = isOrdered ? ordered.ThenByDescending(o => o.IPAddress) : query.OrderByDescending(o => o.IPAddress);
                                break;
							case "IPAddressLan":
								query = isOrdered ? ordered.ThenBy(o => o.IPAddressLan) : query.OrderBy(o => o.IPAddressLan);
								 break;
							case "IPAddressLan_desc":
                                query = isOrdered ? ordered.ThenByDescending(o => o.IPAddressLan) : query.OrderByDescending(o => o.IPAddressLan);
                                break;
							case "IsDeleted":
								query = isOrdered ? ordered.ThenBy(o => o.IsDeleted) : query.OrderBy(o => o.IsDeleted);
								 break;
							case "IsDeleted_desc":
                                query = isOrdered ? ordered.ThenByDescending(o => o.IsDeleted) : query.OrderByDescending(o => o.IsDeleted);
                                break;
							case "AppVersion":
								query = isOrdered ? ordered.ThenBy(o => o.AppVersion) : query.OrderBy(o => o.AppVersion);
								 break;
							case "AppVersion_desc":
                                query = isOrdered ? ordered.ThenByDescending(o => o.AppVersion) : query.OrderByDescending(o => o.AppVersion);
                                break;
							case "Segment0":
								query = isOrdered ? ordered.ThenBy(o => o.Segment0) : query.OrderBy(o => o.Segment0);
								 break;
							case "Segment0_desc":
                                query = isOrdered ? ordered.ThenByDescending(o => o.Segment0) : query.OrderByDescending(o => o.Segment0);
                                break;
							case "Segment1":
								query = isOrdered ? ordered.ThenBy(o => o.Segment1) : query.OrderBy(o => o.Segment1);
								 break;
							case "Segment1_desc":
                                query = isOrdered ? ordered.ThenByDescending(o => o.Segment1) : query.OrderByDescending(o => o.Segment1);
                                break;
							case "Segment2":
								query = isOrdered ? ordered.ThenBy(o => o.Segment2) : query.OrderBy(o => o.Segment2);
								 break;
							case "Segment2_desc":
                                query = isOrdered ? ordered.ThenByDescending(o => o.Segment2) : query.OrderByDescending(o => o.Segment2);
                                break;
							case "Segment3":
								query = isOrdered ? ordered.ThenBy(o => o.Segment3) : query.OrderBy(o => o.Segment3);
								 break;
							case "Segment3_desc":
                                query = isOrdered ? ordered.ThenByDescending(o => o.Segment3) : query.OrderByDescending(o => o.Segment3);
                                break;
							case "Segment4":
								query = isOrdered ? ordered.ThenBy(o => o.Segment4) : query.OrderBy(o => o.Segment4);
								 break;
							case "Segment4_desc":
                                query = isOrdered ? ordered.ThenByDescending(o => o.Segment4) : query.OrderByDescending(o => o.Segment4);
                                break;
							case "Segment5":
								query = isOrdered ? ordered.ThenBy(o => o.Segment5) : query.OrderBy(o => o.Segment5);
								 break;
							case "Segment5_desc":
                                query = isOrdered ? ordered.ThenByDescending(o => o.Segment5) : query.OrderByDescending(o => o.Segment5);
                                break;
							case "Segment6":
								query = isOrdered ? ordered.ThenBy(o => o.Segment6) : query.OrderBy(o => o.Segment6);
								 break;
							case "Segment6_desc":
                                query = isOrdered ? ordered.ThenByDescending(o => o.Segment6) : query.OrderByDescending(o => o.Segment6);
                                break;
							case "Segment7":
								query = isOrdered ? ordered.ThenBy(o => o.Segment7) : query.OrderBy(o => o.Segment7);
								 break;
							case "Segment7_desc":
                                query = isOrdered ? ordered.ThenByDescending(o => o.Segment7) : query.OrderByDescending(o => o.Segment7);
                                break;
							case "Segment8":
								query = isOrdered ? ordered.ThenBy(o => o.Segment8) : query.OrderBy(o => o.Segment8);
								 break;
							case "Segment8_desc":
                                query = isOrdered ? ordered.ThenByDescending(o => o.Segment8) : query.OrderByDescending(o => o.Segment8);
                                break;
							case "Segment9":
								query = isOrdered ? ordered.ThenBy(o => o.Segment9) : query.OrderBy(o => o.Segment9);
								 break;
							case "Segment9_desc":
                                query = isOrdered ? ordered.ThenByDescending(o => o.Segment9) : query.OrderByDescending(o => o.Segment9);
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

        public static IQueryable<tbl_SYS_Log> _pagingBuilder(IQueryable<tbl_SYS_Log> query, Dictionary<string, string> QueryStrings)
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






