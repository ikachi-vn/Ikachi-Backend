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
    
    
    public partial class tbl_WMS_ItemInLocation
    {
        public int IDBranch { get; set; }
        public int IDStorer { get; set; }
        public int IDItem { get; set; }
        public int IDLocation { get; set; }
        public int Id { get; set; }
        public decimal QuantityExpected { get; set; }
        public decimal QuantityOnHand { get; set; }
        public decimal QuantityPreallocated { get; set; }
        public decimal QuantityAllocated { get; set; }
        public decimal QuantityPicked { get; set; }
        public decimal QuantityOnHold { get; set; }
        public bool IsDeleted { get; set; }
        public string CreatedBy { get; set; }
        public string ModifiedBy { get; set; }
        public System.DateTime CreatedDate { get; set; }
        public System.DateTime ModifiedDate { get; set; }
        //List 0:1
        public virtual tbl_BRA_Branch tbl_BRA_Branch { get; set; }
        //List 0:1
        public virtual tbl_WMS_Item tbl_WMS_Item { get; set; }
        //List 0:1
        public virtual tbl_WMS_Location tbl_WMS_Location { get; set; }
        //List 0:1
        public virtual tbl_WMS_Storer tbl_WMS_Storer { get; set; }
    }
}


namespace DTOModel
{
	using System;
	public partial class DTO_WMS_ItemInLocation
	{
		public int IDBranch { get; set; }
		public int IDStorer { get; set; }
		public int IDItem { get; set; }
		public int IDLocation { get; set; }
		public int Id { get; set; }
		public decimal QuantityExpected { get; set; }
		public decimal QuantityOnHand { get; set; }
		public decimal QuantityPreallocated { get; set; }
		public decimal QuantityAllocated { get; set; }
		public decimal QuantityPicked { get; set; }
		public decimal QuantityOnHold { get; set; }
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

    public static partial class BS_WMS_ItemInLocation 
    {
        public static dynamic getSearch(AppEntities db, int IDBranch, int StaffID, Dictionary<string, string> QueryStrings)
        {
            return get(db, IDBranch,StaffID, QueryStrings);
        }

		public static IQueryable<DTO_WMS_ItemInLocation> get(AppEntities db, int IDBranch, int StaffID, Dictionary<string, string> QueryStrings)
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
            package.Workbook.Properties.Title = "ART-DMS WMS_ItemInLocation";
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

		public static DTO_WMS_ItemInLocation getAnItem(AppEntities db, int IDBranch, int StaffID, int id)
        {
            var dbResult = db.tbl_WMS_ItemInLocation.Find(id);

			//if (dbResult == null || (IDBranch != 0 && dbResult.IDBranch != IDBranch))
			//	return null; 
			//else 
				return toDTO(dbResult);
			
        }
		

		public static bool put(AppEntities db, int IDBranch, int StaffID, int Id, dynamic item, string Username, Dictionary<string, string> QueryStrings)
        {
            bool result = false;
            var dbitem = db.tbl_WMS_ItemInLocation.Find(Id);
            
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
					errorLog.logMessage("put_WMS_ItemInLocation",e);
                    result = false;
                }
            }
            else
                if (QueryStrings.Any(d => d.Key == "ForceCreate"))
                    result =  post(db, IDBranch, StaffID, item, Username) != null;
                
            return result;
        }

        public static void patchDynamicToDB(dynamic item, tbl_WMS_ItemInLocation dbitem, string Username)
        {
            Type type = typeof(tbl_WMS_ItemInLocation);
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

        public static void patchDTOtoDBValue( DTO_WMS_ItemInLocation item, tbl_WMS_ItemInLocation dbitem)
        {
            if (item == null){
                dbitem = null;
                return;
            }
            							
			dbitem.IDBranch = item.IDBranch;							
			dbitem.IDStorer = item.IDStorer;							
			dbitem.IDItem = item.IDItem;							
			dbitem.IDLocation = item.IDLocation;							
			dbitem.QuantityExpected = item.QuantityExpected;							
			dbitem.QuantityOnHand = item.QuantityOnHand;							
			dbitem.QuantityPreallocated = item.QuantityPreallocated;							
			dbitem.QuantityAllocated = item.QuantityAllocated;							
			dbitem.QuantityPicked = item.QuantityPicked;							
			dbitem.QuantityOnHold = item.QuantityOnHold;							
			dbitem.IsDeleted = item.IsDeleted;        }

		public static DTO_WMS_ItemInLocation post(AppEntities db, int IDBranch, int StaffID, dynamic item, string Username)
        {
            tbl_WMS_ItemInLocation dbitem = new tbl_WMS_ItemInLocation();
            if (item != null)
            {
                patchDynamicToDB(item, dbitem, Username);
                
				dbitem.CreatedBy = Username;
				dbitem.CreatedDate = DateTime.Now;				
                try
                {
					db.tbl_WMS_ItemInLocation.Add(dbitem);
                    db.SaveChanges();
				
                }
                catch (DbEntityValidationException e)
                {
					errorLog.logMessage("post_WMS_ItemInLocation",e);
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
                Type type = Type.GetType("BaseBusiness.BS_WMS_ItemInLocation, ClassLibrary");
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
                        var target = new tbl_WMS_ItemInLocation();
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
                    
                    tbl_WMS_ItemInLocation dbitem = new tbl_WMS_ItemInLocation();
                    if (it.Id == null || string.IsNullOrEmpty(it.Id.Value) || it.Id == "0")
                    {
                        dbitem = new tbl_WMS_ItemInLocation();
                        dbitem.CreatedBy = Username;
				        dbitem.CreatedDate = DateTime.Now;
                                            }
                    else
                    {
                        dbitem = db.tbl_WMS_ItemInLocation.Find((int)it.Id);
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
                        
                        if (dbitem.Id == 0) db.tbl_WMS_ItemInLocation.Add(dbitem);
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
                    errorLog.logMessage("post_WMS_ItemInLocation",e);
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

            var dbitems = db.tbl_WMS_ItemInLocation.Where(d => IDs.Contains(d.Id));
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
                    BS_Version.update_Version(db, IDBranch, "DTO_WMS_ItemInLocation", updateDate, Username);
                }
			
            }
            catch (DbEntityValidationException e)
            {
				errorLog.logMessage("delete_WMS_ItemInLocation",e);
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
             
            return db.tbl_WMS_ItemInLocation.Any(e => e.Id == id && e.IsDeleted == false);
            
		}
		
		//---//
		public static IQueryable<DTO_WMS_ItemInLocation> toDTO(IQueryable<tbl_WMS_ItemInLocation> query)
        {
			return query
			.Select(s => new DTO_WMS_ItemInLocation(){							
				IDBranch = s.IDBranch,							
				IDStorer = s.IDStorer,							
				IDItem = s.IDItem,							
				IDLocation = s.IDLocation,							
				Id = s.Id,							
				QuantityExpected = s.QuantityExpected,							
				QuantityOnHand = s.QuantityOnHand,							
				QuantityPreallocated = s.QuantityPreallocated,							
				QuantityAllocated = s.QuantityAllocated,							
				QuantityPicked = s.QuantityPicked,							
				QuantityOnHold = s.QuantityOnHold,							
				IsDeleted = s.IsDeleted,							
				CreatedBy = s.CreatedBy,							
				ModifiedBy = s.ModifiedBy,							
				CreatedDate = s.CreatedDate,							
				ModifiedDate = s.ModifiedDate,					
			});//;
                              
        }

		public static DTO_WMS_ItemInLocation toDTO(tbl_WMS_ItemInLocation dbResult)
        {
			if (dbResult != null)
			{
				return new DTO_WMS_ItemInLocation()
				{							
					IDBranch = dbResult.IDBranch,							
					IDStorer = dbResult.IDStorer,							
					IDItem = dbResult.IDItem,							
					IDLocation = dbResult.IDLocation,							
					Id = dbResult.Id,							
					QuantityExpected = dbResult.QuantityExpected,							
					QuantityOnHand = dbResult.QuantityOnHand,							
					QuantityPreallocated = dbResult.QuantityPreallocated,							
					QuantityAllocated = dbResult.QuantityAllocated,							
					QuantityPicked = dbResult.QuantityPicked,							
					QuantityOnHold = dbResult.QuantityOnHold,							
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

		public static IQueryable<tbl_WMS_ItemInLocation> _queryBuilder(AppEntities db, int IDBranch, int StaffID, Dictionary<string, string> QueryStrings)
        {
            
			IQueryable<tbl_WMS_ItemInLocation> query = db.tbl_WMS_ItemInLocation.AsNoTracking();//.Where(d => d.IsDeleted == false);
			

			//Query keyword



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

			//Query IDStorer (int)
			if (QueryStrings.Any(d => d.Key == "IDStorer"))
            {
                var IDList = QueryStrings.FirstOrDefault(d => d.Key == "IDStorer").Value.Replace("[", "").Replace("]", "").Split(',');
                List<int> IDs = new List<int>();
                foreach (var item in IDList)
                    if (int.TryParse(item, out int i))
                        IDs.Add(i);
                if (IDs.Count > 0)
                    query = query.Where(d => IDs.Contains(d.IDStorer));
            }

			//Query IDItem (int)
			if (QueryStrings.Any(d => d.Key == "IDItem"))
            {
                var IDList = QueryStrings.FirstOrDefault(d => d.Key == "IDItem").Value.Replace("[", "").Replace("]", "").Split(',');
                List<int> IDs = new List<int>();
                foreach (var item in IDList)
                    if (int.TryParse(item, out int i))
                        IDs.Add(i);
                if (IDs.Count > 0)
                    query = query.Where(d => IDs.Contains(d.IDItem));
            }

			//Query IDLocation (int)
			if (QueryStrings.Any(d => d.Key == "IDLocation"))
            {
                var IDList = QueryStrings.FirstOrDefault(d => d.Key == "IDLocation").Value.Replace("[", "").Replace("]", "").Split(',');
                List<int> IDs = new List<int>();
                foreach (var item in IDList)
                    if (int.TryParse(item, out int i))
                        IDs.Add(i);
                if (IDs.Count > 0)
                    query = query.Where(d => IDs.Contains(d.IDLocation));
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

			//Query QuantityExpected (decimal)
			if (QueryStrings.Any(d => d.Key == "QuantityExpectedFrom") && QueryStrings.Any(d => d.Key == "QuantityExpectedTo"))
                if (decimal.TryParse(QueryStrings.FirstOrDefault(d => d.Key == "QuantityExpectedFrom").Value, out decimal fromVal) && decimal.TryParse(QueryStrings.FirstOrDefault(d => d.Key == "QuantityExpectedTo").Value, out decimal toVal))
                    query = query.Where(d => fromVal <= d.QuantityExpected && d.QuantityExpected <= toVal);
            
            if (QueryStrings.Any(d => d.Key == "QuantityExpected"))
                if (decimal.TryParse(QueryStrings.FirstOrDefault(d => d.Key == "QuantityExpected").Value, out decimal val))
                    query = query.Where(d => val == d.QuantityExpected);


			//Query QuantityOnHand (decimal)
			if (QueryStrings.Any(d => d.Key == "QuantityOnHandFrom") && QueryStrings.Any(d => d.Key == "QuantityOnHandTo"))
                if (decimal.TryParse(QueryStrings.FirstOrDefault(d => d.Key == "QuantityOnHandFrom").Value, out decimal fromVal) && decimal.TryParse(QueryStrings.FirstOrDefault(d => d.Key == "QuantityOnHandTo").Value, out decimal toVal))
                    query = query.Where(d => fromVal <= d.QuantityOnHand && d.QuantityOnHand <= toVal);
            
            if (QueryStrings.Any(d => d.Key == "QuantityOnHand"))
                if (decimal.TryParse(QueryStrings.FirstOrDefault(d => d.Key == "QuantityOnHand").Value, out decimal val))
                    query = query.Where(d => val == d.QuantityOnHand);


			//Query QuantityPreallocated (decimal)
			if (QueryStrings.Any(d => d.Key == "QuantityPreallocatedFrom") && QueryStrings.Any(d => d.Key == "QuantityPreallocatedTo"))
                if (decimal.TryParse(QueryStrings.FirstOrDefault(d => d.Key == "QuantityPreallocatedFrom").Value, out decimal fromVal) && decimal.TryParse(QueryStrings.FirstOrDefault(d => d.Key == "QuantityPreallocatedTo").Value, out decimal toVal))
                    query = query.Where(d => fromVal <= d.QuantityPreallocated && d.QuantityPreallocated <= toVal);
            
            if (QueryStrings.Any(d => d.Key == "QuantityPreallocated"))
                if (decimal.TryParse(QueryStrings.FirstOrDefault(d => d.Key == "QuantityPreallocated").Value, out decimal val))
                    query = query.Where(d => val == d.QuantityPreallocated);


			//Query QuantityAllocated (decimal)
			if (QueryStrings.Any(d => d.Key == "QuantityAllocatedFrom") && QueryStrings.Any(d => d.Key == "QuantityAllocatedTo"))
                if (decimal.TryParse(QueryStrings.FirstOrDefault(d => d.Key == "QuantityAllocatedFrom").Value, out decimal fromVal) && decimal.TryParse(QueryStrings.FirstOrDefault(d => d.Key == "QuantityAllocatedTo").Value, out decimal toVal))
                    query = query.Where(d => fromVal <= d.QuantityAllocated && d.QuantityAllocated <= toVal);
            
            if (QueryStrings.Any(d => d.Key == "QuantityAllocated"))
                if (decimal.TryParse(QueryStrings.FirstOrDefault(d => d.Key == "QuantityAllocated").Value, out decimal val))
                    query = query.Where(d => val == d.QuantityAllocated);


			//Query QuantityPicked (decimal)
			if (QueryStrings.Any(d => d.Key == "QuantityPickedFrom") && QueryStrings.Any(d => d.Key == "QuantityPickedTo"))
                if (decimal.TryParse(QueryStrings.FirstOrDefault(d => d.Key == "QuantityPickedFrom").Value, out decimal fromVal) && decimal.TryParse(QueryStrings.FirstOrDefault(d => d.Key == "QuantityPickedTo").Value, out decimal toVal))
                    query = query.Where(d => fromVal <= d.QuantityPicked && d.QuantityPicked <= toVal);
            
            if (QueryStrings.Any(d => d.Key == "QuantityPicked"))
                if (decimal.TryParse(QueryStrings.FirstOrDefault(d => d.Key == "QuantityPicked").Value, out decimal val))
                    query = query.Where(d => val == d.QuantityPicked);


			//Query QuantityOnHold (decimal)
			if (QueryStrings.Any(d => d.Key == "QuantityOnHoldFrom") && QueryStrings.Any(d => d.Key == "QuantityOnHoldTo"))
                if (decimal.TryParse(QueryStrings.FirstOrDefault(d => d.Key == "QuantityOnHoldFrom").Value, out decimal fromVal) && decimal.TryParse(QueryStrings.FirstOrDefault(d => d.Key == "QuantityOnHoldTo").Value, out decimal toVal))
                    query = query.Where(d => fromVal <= d.QuantityOnHold && d.QuantityOnHold <= toVal);
            
            if (QueryStrings.Any(d => d.Key == "QuantityOnHold"))
                if (decimal.TryParse(QueryStrings.FirstOrDefault(d => d.Key == "QuantityOnHold").Value, out decimal val))
                    query = query.Where(d => val == d.QuantityOnHold);


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
		
        public static IQueryable<tbl_WMS_ItemInLocation> _sortBuilder(IQueryable<tbl_WMS_ItemInLocation> query, Dictionary<string, string> QueryStrings)
        {
            if (QueryStrings.Any(d => d.Key == "SortBy"))
            {
                var sorts = QueryStrings.FirstOrDefault(d => d.Key == "SortBy").Value.Replace("[", "").Replace("]", "").Split(',');
                
                foreach (var item in sorts)
                    if (!string.IsNullOrEmpty(item))
                    {
                        var ordered = query as IOrderedQueryable<tbl_WMS_ItemInLocation>;
                        bool isOrdered = ordered.ToString().IndexOf("ORDER BY") !=-1;

                        switch (item)
                        {
							case "IDBranch":
								query = isOrdered ? ordered.ThenBy(o => o.IDBranch) : query.OrderBy(o => o.IDBranch);
								 break;
							case "IDBranch_desc":
                                query = isOrdered ? ordered.ThenByDescending(o => o.IDBranch) : query.OrderByDescending(o => o.IDBranch);
                                break;
							case "IDStorer":
								query = isOrdered ? ordered.ThenBy(o => o.IDStorer) : query.OrderBy(o => o.IDStorer);
								 break;
							case "IDStorer_desc":
                                query = isOrdered ? ordered.ThenByDescending(o => o.IDStorer) : query.OrderByDescending(o => o.IDStorer);
                                break;
							case "IDItem":
								query = isOrdered ? ordered.ThenBy(o => o.IDItem) : query.OrderBy(o => o.IDItem);
								 break;
							case "IDItem_desc":
                                query = isOrdered ? ordered.ThenByDescending(o => o.IDItem) : query.OrderByDescending(o => o.IDItem);
                                break;
							case "IDLocation":
								query = isOrdered ? ordered.ThenBy(o => o.IDLocation) : query.OrderBy(o => o.IDLocation);
								 break;
							case "IDLocation_desc":
                                query = isOrdered ? ordered.ThenByDescending(o => o.IDLocation) : query.OrderByDescending(o => o.IDLocation);
                                break;
							case "Id":
								query = isOrdered ? ordered.ThenBy(o => o.Id) : query.OrderBy(o => o.Id);
								 break;
							case "Id_desc":
                                query = isOrdered ? ordered.ThenByDescending(o => o.Id) : query.OrderByDescending(o => o.Id);
                                break;
							case "QuantityExpected":
								query = isOrdered ? ordered.ThenBy(o => o.QuantityExpected) : query.OrderBy(o => o.QuantityExpected);
								 break;
							case "QuantityExpected_desc":
                                query = isOrdered ? ordered.ThenByDescending(o => o.QuantityExpected) : query.OrderByDescending(o => o.QuantityExpected);
                                break;
							case "QuantityOnHand":
								query = isOrdered ? ordered.ThenBy(o => o.QuantityOnHand) : query.OrderBy(o => o.QuantityOnHand);
								 break;
							case "QuantityOnHand_desc":
                                query = isOrdered ? ordered.ThenByDescending(o => o.QuantityOnHand) : query.OrderByDescending(o => o.QuantityOnHand);
                                break;
							case "QuantityPreallocated":
								query = isOrdered ? ordered.ThenBy(o => o.QuantityPreallocated) : query.OrderBy(o => o.QuantityPreallocated);
								 break;
							case "QuantityPreallocated_desc":
                                query = isOrdered ? ordered.ThenByDescending(o => o.QuantityPreallocated) : query.OrderByDescending(o => o.QuantityPreallocated);
                                break;
							case "QuantityAllocated":
								query = isOrdered ? ordered.ThenBy(o => o.QuantityAllocated) : query.OrderBy(o => o.QuantityAllocated);
								 break;
							case "QuantityAllocated_desc":
                                query = isOrdered ? ordered.ThenByDescending(o => o.QuantityAllocated) : query.OrderByDescending(o => o.QuantityAllocated);
                                break;
							case "QuantityPicked":
								query = isOrdered ? ordered.ThenBy(o => o.QuantityPicked) : query.OrderBy(o => o.QuantityPicked);
								 break;
							case "QuantityPicked_desc":
                                query = isOrdered ? ordered.ThenByDescending(o => o.QuantityPicked) : query.OrderByDescending(o => o.QuantityPicked);
                                break;
							case "QuantityOnHold":
								query = isOrdered ? ordered.ThenBy(o => o.QuantityOnHold) : query.OrderBy(o => o.QuantityOnHold);
								 break;
							case "QuantityOnHold_desc":
                                query = isOrdered ? ordered.ThenByDescending(o => o.QuantityOnHold) : query.OrderByDescending(o => o.QuantityOnHold);
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

        public static IQueryable<tbl_WMS_ItemInLocation> _pagingBuilder(IQueryable<tbl_WMS_ItemInLocation> query, Dictionary<string, string> QueryStrings)
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






