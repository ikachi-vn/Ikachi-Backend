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
    
    
    public partial class tbl_SYS_UserDevice
    {
        public int IDBranch { get; set; }
        public string IDUser { get; set; }
        public int Id { get; set; }
        public string Code { get; set; }
        public string Name { get; set; }
        public string Model { get; set; }
        public string Platform { get; set; }
        public string OperatingSystem { get; set; }
        public string OsVersion { get; set; }
        public string Manufacturer { get; set; }
        public bool IsVirtual { get; set; }
        public string Remark { get; set; }
        public Nullable<int> Sort { get; set; }
        public bool IsDisabled { get; set; }
        public bool IsDeleted { get; set; }
        public string CreatedBy { get; set; }
        public string ModifiedBy { get; set; }
        public System.DateTime CreatedDate { get; set; }
        public System.DateTime ModifiedDate { get; set; }
        public Nullable<decimal> MemUsed { get; set; }
        public Nullable<decimal> DiskFree { get; set; }
        public Nullable<decimal> DiskTotal { get; set; }
        public Nullable<decimal> RealDiskFree { get; set; }
        public Nullable<decimal> RealDiskTotal { get; set; }
        public string WebViewVersion { get; set; }
        public Nullable<decimal> BatteryLevel { get; set; }
        public Nullable<bool> IsCharging { get; set; }
        public bool IsAllowCheckIn { get; set; }
    }
}


namespace DTOModel
{
	using System;
	public partial class DTO_SYS_UserDevice
	{
		public int IDBranch { get; set; }
		public string IDUser { get; set; }
		public int Id { get; set; }
		public string Code { get; set; }
		public string Name { get; set; }
		public string Model { get; set; }
		public string Platform { get; set; }
		public string OperatingSystem { get; set; }
		public string OsVersion { get; set; }
		public string Manufacturer { get; set; }
		public bool IsVirtual { get; set; }
		public string Remark { get; set; }
		public Nullable<int> Sort { get; set; }
		public bool IsDisabled { get; set; }
		public bool IsDeleted { get; set; }
		public string CreatedBy { get; set; }
		public string ModifiedBy { get; set; }
		public System.DateTime CreatedDate { get; set; }
		public System.DateTime ModifiedDate { get; set; }
		public Nullable<decimal> MemUsed { get; set; }
		public Nullable<decimal> DiskFree { get; set; }
		public Nullable<decimal> DiskTotal { get; set; }
		public Nullable<decimal> RealDiskFree { get; set; }
		public Nullable<decimal> RealDiskTotal { get; set; }
		public string WebViewVersion { get; set; }
		public Nullable<decimal> BatteryLevel { get; set; }
		public Nullable<bool> IsCharging { get; set; }
		public bool IsAllowCheckIn { get; set; }
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

    public static partial class BS_SYS_UserDevice 
    {
        public static dynamic getSearch(AppEntities db, int IDBranch, int StaffID, Dictionary<string, string> QueryStrings)
        {
            return get(db, IDBranch,StaffID, QueryStrings);
        }

		public static IQueryable<DTO_SYS_UserDevice> get(AppEntities db, int IDBranch, int StaffID, Dictionary<string, string> QueryStrings)
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
            package.Workbook.Properties.Title = "ART-DMS SYS_UserDevice";
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

		public static DTO_SYS_UserDevice getAnItem(AppEntities db, int IDBranch, int StaffID, int id)
        {
            var dbResult = db.tbl_SYS_UserDevice.Find(id);

			//if (dbResult == null || (IDBranch != 0 && dbResult.IDBranch != IDBranch))
			//	return null; 
			//else 
				return toDTO(dbResult);
			
        }
		
		public static DTO_SYS_UserDevice getAnItemByCode(AppEntities db, int IDBranch, int StaffID, string code)
        {
            var dbResult = db.tbl_SYS_UserDevice
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
            var dbitem = db.tbl_SYS_UserDevice.Find(Id);
            
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
					errorLog.logMessage("put_SYS_UserDevice",e);
                    result = false;
                }
            }
            else
                if (QueryStrings.Any(d => d.Key == "ForceCreate"))
                    result =  post(db, IDBranch, StaffID, item, Username) != null;
                
            return result;
        }

        public static void patchDynamicToDB(dynamic item, tbl_SYS_UserDevice dbitem, string Username)
        {
            Type type = typeof(tbl_SYS_UserDevice);
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

        public static void patchDTOtoDBValue( DTO_SYS_UserDevice item, tbl_SYS_UserDevice dbitem)
        {
            if (item == null){
                dbitem = null;
                return;
            }
            							
			dbitem.IDBranch = item.IDBranch;							
			dbitem.IDUser = item.IDUser;							
			dbitem.Code = item.Code;							
			dbitem.Name = item.Name;							
			dbitem.Model = item.Model;							
			dbitem.Platform = item.Platform;							
			dbitem.OperatingSystem = item.OperatingSystem;							
			dbitem.OsVersion = item.OsVersion;							
			dbitem.Manufacturer = item.Manufacturer;							
			dbitem.IsVirtual = item.IsVirtual;							
			dbitem.Remark = item.Remark;							
			dbitem.Sort = item.Sort;							
			dbitem.IsDisabled = item.IsDisabled;							
			dbitem.IsDeleted = item.IsDeleted;							
			dbitem.MemUsed = item.MemUsed;							
			dbitem.DiskFree = item.DiskFree;							
			dbitem.DiskTotal = item.DiskTotal;							
			dbitem.RealDiskFree = item.RealDiskFree;							
			dbitem.RealDiskTotal = item.RealDiskTotal;							
			dbitem.WebViewVersion = item.WebViewVersion;							
			dbitem.BatteryLevel = item.BatteryLevel;							
			dbitem.IsCharging = item.IsCharging;							
			dbitem.IsAllowCheckIn = item.IsAllowCheckIn;        }

		public static DTO_SYS_UserDevice post(AppEntities db, int IDBranch, int StaffID, dynamic item, string Username)
        {
            tbl_SYS_UserDevice dbitem = new tbl_SYS_UserDevice();
            if (item != null)
            {
                patchDynamicToDB(item, dbitem, Username);
                
				dbitem.CreatedBy = Username;
				dbitem.CreatedDate = DateTime.Now;				
                try
                {
					db.tbl_SYS_UserDevice.Add(dbitem);
                    db.SaveChanges();
				
                }
                catch (DbEntityValidationException e)
                {
					errorLog.logMessage("post_SYS_UserDevice",e);
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
                Type type = Type.GetType("BaseBusiness.BS_SYS_UserDevice, ClassLibrary");
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
                        var target = new tbl_SYS_UserDevice();
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
                    
                    tbl_SYS_UserDevice dbitem = new tbl_SYS_UserDevice();
                    if (it.Id == null || string.IsNullOrEmpty(it.Id.Value) || it.Id == "0")
                    {
                        dbitem = new tbl_SYS_UserDevice();
                        dbitem.CreatedBy = Username;
				        dbitem.CreatedDate = DateTime.Now;
                                            }
                    else
                    {
                        dbitem = db.tbl_SYS_UserDevice.Find((int)it.Id);
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
                        
                        if (dbitem.Id == 0) db.tbl_SYS_UserDevice.Add(dbitem);
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
                    errorLog.logMessage("post_SYS_UserDevice",e);
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

            var dbitems = db.tbl_SYS_UserDevice.Where(d => IDs.Contains(d.Id));
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
                    BS_Version.update_Version(db, IDBranch, "DTO_SYS_UserDevice", updateDate, Username);
                }
			
            }
            catch (DbEntityValidationException e)
            {
				errorLog.logMessage("delete_SYS_UserDevice",e);
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

			
            var dbitems = db.tbl_SYS_UserDevice.Where(d => IDs.Contains(d.Id));
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
                    BS_Version.update_Version(db, IDBranch, "DTO_SYS_UserDevice", updateDate, Username);
                }
			
            }
            catch (DbEntityValidationException e)
            {
				errorLog.logMessage("disable_SYS_UserDevice",e);
                result = false;
            }
            
            return result;
        }

		
		//---//
		public static bool check_Exists(AppEntities db, int id)
		{
             
            return db.tbl_SYS_UserDevice.Any(e => e.Id == id && e.IsDeleted == false);
            
		}
		
		public static bool check_Exists(AppEntities db, string Code)
		{
             
            return db.tbl_SYS_UserDevice.Any(e => e.Code == Code && e.IsDeleted == false);
            
		}
		
		//---//
		public static IQueryable<DTO_SYS_UserDevice> toDTO(IQueryable<tbl_SYS_UserDevice> query)
        {
			return query
			.Select(s => new DTO_SYS_UserDevice(){							
				IDBranch = s.IDBranch,							
				IDUser = s.IDUser,							
				Id = s.Id,							
				Code = s.Code,							
				Name = s.Name,							
				Model = s.Model,							
				Platform = s.Platform,							
				OperatingSystem = s.OperatingSystem,							
				OsVersion = s.OsVersion,							
				Manufacturer = s.Manufacturer,							
				IsVirtual = s.IsVirtual,							
				Remark = s.Remark,							
				Sort = s.Sort,							
				IsDisabled = s.IsDisabled,							
				IsDeleted = s.IsDeleted,							
				CreatedBy = s.CreatedBy,							
				ModifiedBy = s.ModifiedBy,							
				CreatedDate = s.CreatedDate,							
				ModifiedDate = s.ModifiedDate,							
				MemUsed = s.MemUsed,							
				DiskFree = s.DiskFree,							
				DiskTotal = s.DiskTotal,							
				RealDiskFree = s.RealDiskFree,							
				RealDiskTotal = s.RealDiskTotal,							
				WebViewVersion = s.WebViewVersion,							
				BatteryLevel = s.BatteryLevel,							
				IsCharging = s.IsCharging,							
				IsAllowCheckIn = s.IsAllowCheckIn,					
			});//.OrderBy(o => o.Sort == null).ThenBy(u => u.Sort);
                              
        }

		public static DTO_SYS_UserDevice toDTO(tbl_SYS_UserDevice dbResult)
        {
			if (dbResult != null)
			{
				return new DTO_SYS_UserDevice()
				{							
					IDBranch = dbResult.IDBranch,							
					IDUser = dbResult.IDUser,							
					Id = dbResult.Id,							
					Code = dbResult.Code,							
					Name = dbResult.Name,							
					Model = dbResult.Model,							
					Platform = dbResult.Platform,							
					OperatingSystem = dbResult.OperatingSystem,							
					OsVersion = dbResult.OsVersion,							
					Manufacturer = dbResult.Manufacturer,							
					IsVirtual = dbResult.IsVirtual,							
					Remark = dbResult.Remark,							
					Sort = dbResult.Sort,							
					IsDisabled = dbResult.IsDisabled,							
					IsDeleted = dbResult.IsDeleted,							
					CreatedBy = dbResult.CreatedBy,							
					ModifiedBy = dbResult.ModifiedBy,							
					CreatedDate = dbResult.CreatedDate,							
					ModifiedDate = dbResult.ModifiedDate,							
					MemUsed = dbResult.MemUsed,							
					DiskFree = dbResult.DiskFree,							
					DiskTotal = dbResult.DiskTotal,							
					RealDiskFree = dbResult.RealDiskFree,							
					RealDiskTotal = dbResult.RealDiskTotal,							
					WebViewVersion = dbResult.WebViewVersion,							
					BatteryLevel = dbResult.BatteryLevel,							
					IsCharging = dbResult.IsCharging,							
					IsAllowCheckIn = dbResult.IsAllowCheckIn,
				};
			}
			else
				return null; 
        }

		public static IQueryable<tbl_SYS_UserDevice> _queryBuilder(AppEntities db, int IDBranch, int StaffID, Dictionary<string, string> QueryStrings)
        {
            
			IQueryable<tbl_SYS_UserDevice> query = db.tbl_SYS_UserDevice.AsNoTracking();//.Where(d => d.IsDeleted == false);
			

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

			//Query IDUser (string)
			if (QueryStrings.Any(d => d.Key == "IDUser_eq") && !string.IsNullOrEmpty(QueryStrings.FirstOrDefault(d => d.Key == "IDUser_eq").Value))
            {
                var keyword = QueryStrings.FirstOrDefault(d => d.Key == "IDUser_eq").Value;
                query = query.Where(d=>d.IDUser == keyword);
            }
            if (QueryStrings.Any(d => d.Key == "IDUser") && !string.IsNullOrEmpty(QueryStrings.FirstOrDefault(d => d.Key == "IDUser").Value))
            {
                var keyword = QueryStrings.FirstOrDefault(d => d.Key == "IDUser").Value;
                query = query.Where(d=>d.IDUser.Contains(keyword));
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
            

			//Query Model (string)
			if (QueryStrings.Any(d => d.Key == "Model_eq") && !string.IsNullOrEmpty(QueryStrings.FirstOrDefault(d => d.Key == "Model_eq").Value))
            {
                var keyword = QueryStrings.FirstOrDefault(d => d.Key == "Model_eq").Value;
                query = query.Where(d=>d.Model == keyword);
            }
            if (QueryStrings.Any(d => d.Key == "Model") && !string.IsNullOrEmpty(QueryStrings.FirstOrDefault(d => d.Key == "Model").Value))
            {
                var keyword = QueryStrings.FirstOrDefault(d => d.Key == "Model").Value;
                query = query.Where(d=>d.Model.Contains(keyword));
            }
            

			//Query Platform (string)
			if (QueryStrings.Any(d => d.Key == "Platform_eq") && !string.IsNullOrEmpty(QueryStrings.FirstOrDefault(d => d.Key == "Platform_eq").Value))
            {
                var keyword = QueryStrings.FirstOrDefault(d => d.Key == "Platform_eq").Value;
                query = query.Where(d=>d.Platform == keyword);
            }
            if (QueryStrings.Any(d => d.Key == "Platform") && !string.IsNullOrEmpty(QueryStrings.FirstOrDefault(d => d.Key == "Platform").Value))
            {
                var keyword = QueryStrings.FirstOrDefault(d => d.Key == "Platform").Value;
                query = query.Where(d=>d.Platform.Contains(keyword));
            }
            

			//Query OperatingSystem (string)
			if (QueryStrings.Any(d => d.Key == "OperatingSystem_eq") && !string.IsNullOrEmpty(QueryStrings.FirstOrDefault(d => d.Key == "OperatingSystem_eq").Value))
            {
                var keyword = QueryStrings.FirstOrDefault(d => d.Key == "OperatingSystem_eq").Value;
                query = query.Where(d=>d.OperatingSystem == keyword);
            }
            if (QueryStrings.Any(d => d.Key == "OperatingSystem") && !string.IsNullOrEmpty(QueryStrings.FirstOrDefault(d => d.Key == "OperatingSystem").Value))
            {
                var keyword = QueryStrings.FirstOrDefault(d => d.Key == "OperatingSystem").Value;
                query = query.Where(d=>d.OperatingSystem.Contains(keyword));
            }
            

			//Query OsVersion (string)
			if (QueryStrings.Any(d => d.Key == "OsVersion_eq") && !string.IsNullOrEmpty(QueryStrings.FirstOrDefault(d => d.Key == "OsVersion_eq").Value))
            {
                var keyword = QueryStrings.FirstOrDefault(d => d.Key == "OsVersion_eq").Value;
                query = query.Where(d=>d.OsVersion == keyword);
            }
            if (QueryStrings.Any(d => d.Key == "OsVersion") && !string.IsNullOrEmpty(QueryStrings.FirstOrDefault(d => d.Key == "OsVersion").Value))
            {
                var keyword = QueryStrings.FirstOrDefault(d => d.Key == "OsVersion").Value;
                query = query.Where(d=>d.OsVersion.Contains(keyword));
            }
            

			//Query Manufacturer (string)
			if (QueryStrings.Any(d => d.Key == "Manufacturer_eq") && !string.IsNullOrEmpty(QueryStrings.FirstOrDefault(d => d.Key == "Manufacturer_eq").Value))
            {
                var keyword = QueryStrings.FirstOrDefault(d => d.Key == "Manufacturer_eq").Value;
                query = query.Where(d=>d.Manufacturer == keyword);
            }
            if (QueryStrings.Any(d => d.Key == "Manufacturer") && !string.IsNullOrEmpty(QueryStrings.FirstOrDefault(d => d.Key == "Manufacturer").Value))
            {
                var keyword = QueryStrings.FirstOrDefault(d => d.Key == "Manufacturer").Value;
                query = query.Where(d=>d.Manufacturer.Contains(keyword));
            }
            

			//Query IsVirtual (bool)
			if (QueryStrings.Any(d => d.Key == "IsVirtual"))
            {
                var qValue = QueryStrings.FirstOrDefault(d => d.Key == "IsVirtual").Value;
                if (bool.TryParse(qValue, out bool qBoolValue))
                    query = query.Where(d => qBoolValue == d.IsVirtual);
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


			//Query MemUsed (Nullable<decimal>)
			if (QueryStrings.Any(d => d.Key == "MemUsedFrom") && QueryStrings.Any(d => d.Key == "MemUsedTo"))
                if (decimal.TryParse(QueryStrings.FirstOrDefault(d => d.Key == "MemUsedFrom").Value, out decimal fromVal) && decimal.TryParse(QueryStrings.FirstOrDefault(d => d.Key == "MemUsedTo").Value, out decimal toVal))
                    query = query.Where(d => fromVal <= d.MemUsed && d.MemUsed <= toVal);

			//Query DiskFree (Nullable<decimal>)
			if (QueryStrings.Any(d => d.Key == "DiskFreeFrom") && QueryStrings.Any(d => d.Key == "DiskFreeTo"))
                if (decimal.TryParse(QueryStrings.FirstOrDefault(d => d.Key == "DiskFreeFrom").Value, out decimal fromVal) && decimal.TryParse(QueryStrings.FirstOrDefault(d => d.Key == "DiskFreeTo").Value, out decimal toVal))
                    query = query.Where(d => fromVal <= d.DiskFree && d.DiskFree <= toVal);

			//Query DiskTotal (Nullable<decimal>)
			if (QueryStrings.Any(d => d.Key == "DiskTotalFrom") && QueryStrings.Any(d => d.Key == "DiskTotalTo"))
                if (decimal.TryParse(QueryStrings.FirstOrDefault(d => d.Key == "DiskTotalFrom").Value, out decimal fromVal) && decimal.TryParse(QueryStrings.FirstOrDefault(d => d.Key == "DiskTotalTo").Value, out decimal toVal))
                    query = query.Where(d => fromVal <= d.DiskTotal && d.DiskTotal <= toVal);

			//Query RealDiskFree (Nullable<decimal>)
			if (QueryStrings.Any(d => d.Key == "RealDiskFreeFrom") && QueryStrings.Any(d => d.Key == "RealDiskFreeTo"))
                if (decimal.TryParse(QueryStrings.FirstOrDefault(d => d.Key == "RealDiskFreeFrom").Value, out decimal fromVal) && decimal.TryParse(QueryStrings.FirstOrDefault(d => d.Key == "RealDiskFreeTo").Value, out decimal toVal))
                    query = query.Where(d => fromVal <= d.RealDiskFree && d.RealDiskFree <= toVal);

			//Query RealDiskTotal (Nullable<decimal>)
			if (QueryStrings.Any(d => d.Key == "RealDiskTotalFrom") && QueryStrings.Any(d => d.Key == "RealDiskTotalTo"))
                if (decimal.TryParse(QueryStrings.FirstOrDefault(d => d.Key == "RealDiskTotalFrom").Value, out decimal fromVal) && decimal.TryParse(QueryStrings.FirstOrDefault(d => d.Key == "RealDiskTotalTo").Value, out decimal toVal))
                    query = query.Where(d => fromVal <= d.RealDiskTotal && d.RealDiskTotal <= toVal);

			//Query WebViewVersion (string)
			if (QueryStrings.Any(d => d.Key == "WebViewVersion_eq") && !string.IsNullOrEmpty(QueryStrings.FirstOrDefault(d => d.Key == "WebViewVersion_eq").Value))
            {
                var keyword = QueryStrings.FirstOrDefault(d => d.Key == "WebViewVersion_eq").Value;
                query = query.Where(d=>d.WebViewVersion == keyword);
            }
            if (QueryStrings.Any(d => d.Key == "WebViewVersion") && !string.IsNullOrEmpty(QueryStrings.FirstOrDefault(d => d.Key == "WebViewVersion").Value))
            {
                var keyword = QueryStrings.FirstOrDefault(d => d.Key == "WebViewVersion").Value;
                query = query.Where(d=>d.WebViewVersion.Contains(keyword));
            }
            

			//Query BatteryLevel (Nullable<decimal>)
			if (QueryStrings.Any(d => d.Key == "BatteryLevelFrom") && QueryStrings.Any(d => d.Key == "BatteryLevelTo"))
                if (decimal.TryParse(QueryStrings.FirstOrDefault(d => d.Key == "BatteryLevelFrom").Value, out decimal fromVal) && decimal.TryParse(QueryStrings.FirstOrDefault(d => d.Key == "BatteryLevelTo").Value, out decimal toVal))
                    query = query.Where(d => fromVal <= d.BatteryLevel && d.BatteryLevel <= toVal);

			//Query IsCharging (Nullable<bool>)

			//Query IsAllowCheckIn (bool)
			if (QueryStrings.Any(d => d.Key == "IsAllowCheckIn"))
            {
                var qValue = QueryStrings.FirstOrDefault(d => d.Key == "IsAllowCheckIn").Value;
                if (bool.TryParse(qValue, out bool qBoolValue))
                    query = query.Where(d => qBoolValue == d.IsAllowCheckIn);
            }
            return query;
        }
		
        public static IQueryable<tbl_SYS_UserDevice> _sortBuilder(IQueryable<tbl_SYS_UserDevice> query, Dictionary<string, string> QueryStrings)
        {
            if (QueryStrings.Any(d => d.Key == "SortBy"))
            {
                var sorts = QueryStrings.FirstOrDefault(d => d.Key == "SortBy").Value.Replace("[", "").Replace("]", "").Split(',');
                
                foreach (var item in sorts)
                    if (!string.IsNullOrEmpty(item))
                    {
                        var ordered = query as IOrderedQueryable<tbl_SYS_UserDevice>;
                        bool isOrdered = ordered.ToString().IndexOf("ORDER BY") !=-1;

                        switch (item)
                        {
							case "IDBranch":
								query = isOrdered ? ordered.ThenBy(o => o.IDBranch) : query.OrderBy(o => o.IDBranch);
								 break;
							case "IDBranch_desc":
                                query = isOrdered ? ordered.ThenByDescending(o => o.IDBranch) : query.OrderByDescending(o => o.IDBranch);
                                break;
							case "IDUser":
								query = isOrdered ? ordered.ThenBy(o => o.IDUser) : query.OrderBy(o => o.IDUser);
								 break;
							case "IDUser_desc":
                                query = isOrdered ? ordered.ThenByDescending(o => o.IDUser) : query.OrderByDescending(o => o.IDUser);
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
							case "Model":
								query = isOrdered ? ordered.ThenBy(o => o.Model) : query.OrderBy(o => o.Model);
								 break;
							case "Model_desc":
                                query = isOrdered ? ordered.ThenByDescending(o => o.Model) : query.OrderByDescending(o => o.Model);
                                break;
							case "Platform":
								query = isOrdered ? ordered.ThenBy(o => o.Platform) : query.OrderBy(o => o.Platform);
								 break;
							case "Platform_desc":
                                query = isOrdered ? ordered.ThenByDescending(o => o.Platform) : query.OrderByDescending(o => o.Platform);
                                break;
							case "OperatingSystem":
								query = isOrdered ? ordered.ThenBy(o => o.OperatingSystem) : query.OrderBy(o => o.OperatingSystem);
								 break;
							case "OperatingSystem_desc":
                                query = isOrdered ? ordered.ThenByDescending(o => o.OperatingSystem) : query.OrderByDescending(o => o.OperatingSystem);
                                break;
							case "OsVersion":
								query = isOrdered ? ordered.ThenBy(o => o.OsVersion) : query.OrderBy(o => o.OsVersion);
								 break;
							case "OsVersion_desc":
                                query = isOrdered ? ordered.ThenByDescending(o => o.OsVersion) : query.OrderByDescending(o => o.OsVersion);
                                break;
							case "Manufacturer":
								query = isOrdered ? ordered.ThenBy(o => o.Manufacturer) : query.OrderBy(o => o.Manufacturer);
								 break;
							case "Manufacturer_desc":
                                query = isOrdered ? ordered.ThenByDescending(o => o.Manufacturer) : query.OrderByDescending(o => o.Manufacturer);
                                break;
							case "IsVirtual":
								query = isOrdered ? ordered.ThenBy(o => o.IsVirtual) : query.OrderBy(o => o.IsVirtual);
								 break;
							case "IsVirtual_desc":
                                query = isOrdered ? ordered.ThenByDescending(o => o.IsVirtual) : query.OrderByDescending(o => o.IsVirtual);
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
							case "MemUsed":
								query = isOrdered ? ordered.ThenBy(o => o.MemUsed) : query.OrderBy(o => o.MemUsed);
								 break;
							case "MemUsed_desc":
                                query = isOrdered ? ordered.ThenByDescending(o => o.MemUsed) : query.OrderByDescending(o => o.MemUsed);
                                break;
							case "DiskFree":
								query = isOrdered ? ordered.ThenBy(o => o.DiskFree) : query.OrderBy(o => o.DiskFree);
								 break;
							case "DiskFree_desc":
                                query = isOrdered ? ordered.ThenByDescending(o => o.DiskFree) : query.OrderByDescending(o => o.DiskFree);
                                break;
							case "DiskTotal":
								query = isOrdered ? ordered.ThenBy(o => o.DiskTotal) : query.OrderBy(o => o.DiskTotal);
								 break;
							case "DiskTotal_desc":
                                query = isOrdered ? ordered.ThenByDescending(o => o.DiskTotal) : query.OrderByDescending(o => o.DiskTotal);
                                break;
							case "RealDiskFree":
								query = isOrdered ? ordered.ThenBy(o => o.RealDiskFree) : query.OrderBy(o => o.RealDiskFree);
								 break;
							case "RealDiskFree_desc":
                                query = isOrdered ? ordered.ThenByDescending(o => o.RealDiskFree) : query.OrderByDescending(o => o.RealDiskFree);
                                break;
							case "RealDiskTotal":
								query = isOrdered ? ordered.ThenBy(o => o.RealDiskTotal) : query.OrderBy(o => o.RealDiskTotal);
								 break;
							case "RealDiskTotal_desc":
                                query = isOrdered ? ordered.ThenByDescending(o => o.RealDiskTotal) : query.OrderByDescending(o => o.RealDiskTotal);
                                break;
							case "WebViewVersion":
								query = isOrdered ? ordered.ThenBy(o => o.WebViewVersion) : query.OrderBy(o => o.WebViewVersion);
								 break;
							case "WebViewVersion_desc":
                                query = isOrdered ? ordered.ThenByDescending(o => o.WebViewVersion) : query.OrderByDescending(o => o.WebViewVersion);
                                break;
							case "BatteryLevel":
								query = isOrdered ? ordered.ThenBy(o => o.BatteryLevel) : query.OrderBy(o => o.BatteryLevel);
								 break;
							case "BatteryLevel_desc":
                                query = isOrdered ? ordered.ThenByDescending(o => o.BatteryLevel) : query.OrderByDescending(o => o.BatteryLevel);
                                break;
							case "IsCharging":
								query = isOrdered ? ordered.ThenBy(o => o.IsCharging) : query.OrderBy(o => o.IsCharging);
								 break;
							case "IsCharging_desc":
                                query = isOrdered ? ordered.ThenByDescending(o => o.IsCharging) : query.OrderByDescending(o => o.IsCharging);
                                break;
							case "IsAllowCheckIn":
								query = isOrdered ? ordered.ThenBy(o => o.IsAllowCheckIn) : query.OrderBy(o => o.IsAllowCheckIn);
								 break;
							case "IsAllowCheckIn_desc":
                                query = isOrdered ? ordered.ThenByDescending(o => o.IsAllowCheckIn) : query.OrderByDescending(o => o.IsAllowCheckIn);
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

        public static IQueryable<tbl_SYS_UserDevice> _pagingBuilder(IQueryable<tbl_SYS_UserDevice> query, Dictionary<string, string> QueryStrings)
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






