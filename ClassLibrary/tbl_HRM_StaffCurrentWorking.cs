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
    
    
    public partial class tbl_HRM_StaffCurrentWorking
    {
        public int Id { get; set; }
        public string Code { get; set; }
        public string Name { get; set; }
        public string Remark { get; set; }
        public Nullable<int> Sort { get; set; }
        public string CreatedBy { get; set; }
        public string ModifiedBy { get; set; }
        public System.DateTime CreatedDate { get; set; }
        public System.DateTime ModifiedDate { get; set; }
        public Nullable<int> IDStaffType { get; set; }
        public bool IsShareholder { get; set; }
        public Nullable<int> IDDirectManager { get; set; }
        public Nullable<int> IDIndirectManager { get; set; }
        public Nullable<System.DateTime> OfficialEntryDate { get; set; }
        public Nullable<bool> IsResign { get; set; }
        public string LaborBookNumber { get; set; }
        public Nullable<System.DateTime> DateOfIssueLaborBook { get; set; }
        public string IssuedLaborBookBy { get; set; }
        public string StoredRecordCode { get; set; }
        public string StoredPlace { get; set; }
        public bool IsDeleted { get; set; }
        //List 0:1
        public virtual tbl_HRM_Staff tbl_HRM_Staff { get; set; }
        //List 0:1
        public virtual tbl_HRM_Staff tbl_HRM_Staff1 { get; set; }
        //List 0:1
        public virtual tbl_HRM_Staff tbl_HRM_Staff2 { get; set; }
        //List 0:1
        public virtual tbl_LIST_General tbl_LIST_General { get; set; }
    }
}


namespace DTOModel
{
	using System;
	public partial class DTO_HRM_StaffCurrentWorking
	{
		public int Id { get; set; }
		public string Code { get; set; }
		public string Name { get; set; }
		public string Remark { get; set; }
		public Nullable<int> Sort { get; set; }
		public string CreatedBy { get; set; }
		public string ModifiedBy { get; set; }
		public System.DateTime CreatedDate { get; set; }
		public System.DateTime ModifiedDate { get; set; }
		public Nullable<int> IDStaffType { get; set; }
		public bool IsShareholder { get; set; }
		public Nullable<int> IDDirectManager { get; set; }
		public Nullable<int> IDIndirectManager { get; set; }
		public Nullable<System.DateTime> OfficialEntryDate { get; set; }
		public Nullable<bool> IsResign { get; set; }
		public string LaborBookNumber { get; set; }
		public Nullable<System.DateTime> DateOfIssueLaborBook { get; set; }
		public string IssuedLaborBookBy { get; set; }
		public string StoredRecordCode { get; set; }
		public string StoredPlace { get; set; }
		public bool IsDeleted { get; set; }
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

    public static partial class BS_HRM_StaffCurrentWorking 
    {
        public static dynamic getSearch(AppEntities db, int IDBranch, int StaffID, Dictionary<string, string> QueryStrings)
        {
            return get(db, IDBranch,StaffID, QueryStrings);
        }

		public static IQueryable<DTO_HRM_StaffCurrentWorking> get(AppEntities db, int IDBranch, int StaffID, Dictionary<string, string> QueryStrings)
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
            package.Workbook.Properties.Title = "ART-DMS HRM_StaffCurrentWorking";
            package.Workbook.Properties.Author = "hung.vu@codeart.vn";
            package.Workbook.Properties.Application = "ART-DMS";
            package.Workbook.Properties.Company = "A.R.T Distribution";

            ExcelWorkbook workBook = package.Workbook;
            if (workBook != null)
            {
                var ws = workBook.Worksheets.FirstOrDefault();
                var data = _queryBuilder(db, IDBranch, StaffID, QueryStrings).ToList();

                //var HRM_StaffList = BS_HRM_Staff.get(db,IDBranch, StaffID,QueryStrings).Select(s => new ItemModel { Id = s.Id, Name = s.Name });
                //var HRM_Staff1List = BS_HRM_Staff.get(db,IDBranch, StaffID,QueryStrings).Select(s => new ItemModel { Id = s.Id, Name = s.Name });
                //var HRM_Staff2List = BS_HRM_Staff.get(db,IDBranch, StaffID,QueryStrings).Select(s => new ItemModel { Id = s.Id, Name = s.Name });
                //var LIST_GeneralList = BS_LIST_General.get(db,IDBranch, StaffID,QueryStrings).Select(s => new ItemModel { Id = s.Id, Name = s.Name });
                 

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

		public static DTO_HRM_StaffCurrentWorking getAnItem(AppEntities db, int IDBranch, int StaffID, int id)
        {
            var dbResult = db.tbl_HRM_StaffCurrentWorking.Find(id);

			return toDTO(dbResult);
			
        }
		
		public static DTO_HRM_StaffCurrentWorking getAnItemByCode(AppEntities db, int IDBranch, int StaffID, string code)
        {
            var dbResult = db.tbl_HRM_StaffCurrentWorking
			.FirstOrDefault(d => d.IsDeleted == false && d.Code == code );

			return toDTO(dbResult);
			
        }

		public static bool put(AppEntities db, int IDBranch, int StaffID, int Id, dynamic item, string Username, Dictionary<string, string> QueryStrings)
        {
            bool result = false;
            var dbitem = db.tbl_HRM_StaffCurrentWorking.Find(Id);
            
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
					errorLog.logMessage("put_HRM_StaffCurrentWorking",e);
                    result = false;
                }
            }
            else
                if (QueryStrings.Any(d => d.Key == "ForceCreate"))
                    result =  post(db, IDBranch, StaffID, item, Username) != null;
                
            return result;
        }

        public static void patchDynamicToDB(dynamic item, tbl_HRM_StaffCurrentWorking dbitem, string Username)
        {
            Type type = typeof(tbl_HRM_StaffCurrentWorking);
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

        public static void patchDTOtoDBValue( DTO_HRM_StaffCurrentWorking item, tbl_HRM_StaffCurrentWorking dbitem)
        {
            if (item == null){
                dbitem = null;
                return;
            }
            							
			dbitem.Code = item.Code;							
			dbitem.Name = item.Name;							
			dbitem.Remark = item.Remark;							
			dbitem.Sort = item.Sort;							
			dbitem.IDStaffType = item.IDStaffType;							
			dbitem.IsShareholder = item.IsShareholder;							
			dbitem.IDDirectManager = item.IDDirectManager;							
			dbitem.IDIndirectManager = item.IDIndirectManager;							
			dbitem.OfficialEntryDate = item.OfficialEntryDate;							
			dbitem.IsResign = item.IsResign;							
			dbitem.LaborBookNumber = item.LaborBookNumber;							
			dbitem.DateOfIssueLaborBook = item.DateOfIssueLaborBook;							
			dbitem.IssuedLaborBookBy = item.IssuedLaborBookBy;							
			dbitem.StoredRecordCode = item.StoredRecordCode;							
			dbitem.StoredPlace = item.StoredPlace;							
			dbitem.IsDeleted = item.IsDeleted;        }

		public static DTO_HRM_StaffCurrentWorking post(AppEntities db, int IDBranch, int StaffID, dynamic item, string Username)
        {
            tbl_HRM_StaffCurrentWorking dbitem = new tbl_HRM_StaffCurrentWorking();
            if (item != null)
            {
                patchDynamicToDB(item, dbitem, Username);
                
				dbitem.CreatedBy = Username;
				dbitem.CreatedDate = DateTime.Now;				
                try
                {
					db.tbl_HRM_StaffCurrentWorking.Add(dbitem);
                    db.SaveChanges();
				
                }
                catch (DbEntityValidationException e)
                {
					errorLog.logMessage("post_HRM_StaffCurrentWorking",e);
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
                Type type = Type.GetType("BaseBusiness.BS_HRM_StaffCurrentWorking, ClassLibrary");
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
                        var target = new tbl_HRM_StaffCurrentWorking();
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
                    
                    tbl_HRM_StaffCurrentWorking dbitem = new tbl_HRM_StaffCurrentWorking();
                    if (it.Id == null || string.IsNullOrEmpty(it.Id.Value) || it.Id == "0")
                    {
                        dbitem = new tbl_HRM_StaffCurrentWorking();
                        dbitem.CreatedBy = Username;
				        dbitem.CreatedDate = DateTime.Now;
                                            }
                    else
                    {
                        dbitem = db.tbl_HRM_StaffCurrentWorking.Find((int)it.Id);
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
                        
                        if (dbitem.Id == 0) db.tbl_HRM_StaffCurrentWorking.Add(dbitem);
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
                    errorLog.logMessage("post_HRM_StaffCurrentWorking",e);
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

            var dbitems = db.tbl_HRM_StaffCurrentWorking.Where(d => IDs.Contains(d.Id));
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
			
                BS_Version.update_Version(db, null, "DTO_HRM_StaffCurrentWorking", updateDate, Username);
			
            }
            catch (DbEntityValidationException e)
            {
				errorLog.logMessage("delete_HRM_StaffCurrentWorking",e);
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
             
            return db.tbl_HRM_StaffCurrentWorking.Any(e => e.Id == id && e.IsDeleted == false);
            
		}
		
		public static bool check_Exists(AppEntities db, string Code)
		{
             
            return db.tbl_HRM_StaffCurrentWorking.Any(e => e.Code == Code && e.IsDeleted == false);
            
		}
		
		//---//
		public static IQueryable<DTO_HRM_StaffCurrentWorking> toDTO(IQueryable<tbl_HRM_StaffCurrentWorking> query)
        {
			return query
			.Select(s => new DTO_HRM_StaffCurrentWorking(){							
				Id = s.Id,							
				Code = s.Code,							
				Name = s.Name,							
				Remark = s.Remark,							
				Sort = s.Sort,							
				CreatedBy = s.CreatedBy,							
				ModifiedBy = s.ModifiedBy,							
				CreatedDate = s.CreatedDate,							
				ModifiedDate = s.ModifiedDate,							
				IDStaffType = s.IDStaffType,							
				IsShareholder = s.IsShareholder,							
				IDDirectManager = s.IDDirectManager,							
				IDIndirectManager = s.IDIndirectManager,							
				OfficialEntryDate = s.OfficialEntryDate,							
				IsResign = s.IsResign,							
				LaborBookNumber = s.LaborBookNumber,							
				DateOfIssueLaborBook = s.DateOfIssueLaborBook,							
				IssuedLaborBookBy = s.IssuedLaborBookBy,							
				StoredRecordCode = s.StoredRecordCode,							
				StoredPlace = s.StoredPlace,							
				IsDeleted = s.IsDeleted,					
			});//.OrderBy(o => o.Sort == null).ThenBy(u => u.Sort);
                              
        }

		public static DTO_HRM_StaffCurrentWorking toDTO(tbl_HRM_StaffCurrentWorking dbResult)
        {
			if (dbResult != null)
			{
				return new DTO_HRM_StaffCurrentWorking()
				{							
					Id = dbResult.Id,							
					Code = dbResult.Code,							
					Name = dbResult.Name,							
					Remark = dbResult.Remark,							
					Sort = dbResult.Sort,							
					CreatedBy = dbResult.CreatedBy,							
					ModifiedBy = dbResult.ModifiedBy,							
					CreatedDate = dbResult.CreatedDate,							
					ModifiedDate = dbResult.ModifiedDate,							
					IDStaffType = dbResult.IDStaffType,							
					IsShareholder = dbResult.IsShareholder,							
					IDDirectManager = dbResult.IDDirectManager,							
					IDIndirectManager = dbResult.IDIndirectManager,							
					OfficialEntryDate = dbResult.OfficialEntryDate,							
					IsResign = dbResult.IsResign,							
					LaborBookNumber = dbResult.LaborBookNumber,							
					DateOfIssueLaborBook = dbResult.DateOfIssueLaborBook,							
					IssuedLaborBookBy = dbResult.IssuedLaborBookBy,							
					StoredRecordCode = dbResult.StoredRecordCode,							
					StoredPlace = dbResult.StoredPlace,							
					IsDeleted = dbResult.IsDeleted,
				};
			}
			else
				return null; 
        }

		public static IQueryable<tbl_HRM_StaffCurrentWorking> _queryBuilder(AppEntities db, int IDBranch, int StaffID, Dictionary<string, string> QueryStrings)
        {
            
			IQueryable<tbl_HRM_StaffCurrentWorking> query = db.tbl_HRM_StaffCurrentWorking.AsNoTracking();//.Where(d => d.IsDeleted == false );
			

			//Query keyword
			if (QueryStrings.Any(d => d.Key == "Keyword") && !string.IsNullOrEmpty(QueryStrings.FirstOrDefault(d => d.Key == "Keyword").Value))
            {
                var keyword = QueryStrings.FirstOrDefault(d => d.Key == "Keyword").Value;
                query = query.Where(d=>d.Name.Contains(keyword) || d.Code.Contains(keyword));
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


			//Query IDStaffType (Nullable<int>)
			if (QueryStrings.Any(d => d.Key == "IDStaffType"))
            {
                var IDList = QueryStrings.FirstOrDefault(d => d.Key == "IDStaffType").Value.Replace("[", "").Replace("]", "").Split(',');
                List<int?> IDs = new List<int?>();
                foreach (var item in IDList)
                    if (int.TryParse(item, out int i))
                        IDs.Add(i);
					else if (item == "null")
						IDs.Add(null);
                if (IDs.Count > 0)
                    query = query.Where(d => IDs.Contains(d.IDStaffType));
////                    query = query.Where(d => IDs.Contains(d.IDStaffType));
//                    
            }

			//Query IsShareholder (bool)
			if (QueryStrings.Any(d => d.Key == "IsShareholder"))
            {
                var qValue = QueryStrings.FirstOrDefault(d => d.Key == "IsShareholder").Value;
                if (bool.TryParse(qValue, out bool qBoolValue))
                    query = query.Where(d => qBoolValue == d.IsShareholder);
            }

			//Query IDDirectManager (Nullable<int>)
			if (QueryStrings.Any(d => d.Key == "IDDirectManager"))
            {
                var IDList = QueryStrings.FirstOrDefault(d => d.Key == "IDDirectManager").Value.Replace("[", "").Replace("]", "").Split(',');
                List<int?> IDs = new List<int?>();
                foreach (var item in IDList)
                    if (int.TryParse(item, out int i))
                        IDs.Add(i);
					else if (item == "null")
						IDs.Add(null);
                if (IDs.Count > 0)
                    query = query.Where(d => IDs.Contains(d.IDDirectManager));
////                    query = query.Where(d => IDs.Contains(d.IDDirectManager));
//                    
            }

			//Query IDIndirectManager (Nullable<int>)
			if (QueryStrings.Any(d => d.Key == "IDIndirectManager"))
            {
                var IDList = QueryStrings.FirstOrDefault(d => d.Key == "IDIndirectManager").Value.Replace("[", "").Replace("]", "").Split(',');
                List<int?> IDs = new List<int?>();
                foreach (var item in IDList)
                    if (int.TryParse(item, out int i))
                        IDs.Add(i);
					else if (item == "null")
						IDs.Add(null);
                if (IDs.Count > 0)
                    query = query.Where(d => IDs.Contains(d.IDIndirectManager));
////                    query = query.Where(d => IDs.Contains(d.IDIndirectManager));
//                    
            }

			//Query OfficialEntryDate (Nullable<System.DateTime>)
			if (QueryStrings.Any(d => d.Key == "OfficialEntryDateFrom") && QueryStrings.Any(d => d.Key == "OfficialEntryDateTo"))
                if (DateTime.TryParse(QueryStrings.FirstOrDefault(d => d.Key == "OfficialEntryDateFrom").Value, out DateTime fromDate) && DateTime.TryParse(QueryStrings.FirstOrDefault(d => d.Key == "OfficialEntryDateTo").Value, out DateTime toDate))
                    query = query.Where(d => fromDate <= d.OfficialEntryDate && d.OfficialEntryDate <= toDate);

            if (QueryStrings.Any(d => d.Key == "OfficialEntryDate"))
                if (DateTime.TryParse(QueryStrings.FirstOrDefault(d => d.Key == "OfficialEntryDate").Value, out DateTime val))
                    query = query.Where(d => d.OfficialEntryDate != null && DbFunctions.TruncateTime(val) == DbFunctions.TruncateTime(d.OfficialEntryDate));


			//Query IsResign (Nullable<bool>)

			//Query LaborBookNumber (string)
			if (QueryStrings.Any(d => d.Key == "LaborBookNumber_eq") && !string.IsNullOrEmpty(QueryStrings.FirstOrDefault(d => d.Key == "LaborBookNumber_eq").Value))
            {
                var keyword = QueryStrings.FirstOrDefault(d => d.Key == "LaborBookNumber_eq").Value;
                query = query.Where(d=>d.LaborBookNumber == keyword);
            }
            if (QueryStrings.Any(d => d.Key == "LaborBookNumber") && !string.IsNullOrEmpty(QueryStrings.FirstOrDefault(d => d.Key == "LaborBookNumber").Value))
            {
                var keyword = QueryStrings.FirstOrDefault(d => d.Key == "LaborBookNumber").Value;
                query = query.Where(d=>d.LaborBookNumber.Contains(keyword));
            }
            

			//Query DateOfIssueLaborBook (Nullable<System.DateTime>)
			if (QueryStrings.Any(d => d.Key == "DateOfIssueLaborBookFrom") && QueryStrings.Any(d => d.Key == "DateOfIssueLaborBookTo"))
                if (DateTime.TryParse(QueryStrings.FirstOrDefault(d => d.Key == "DateOfIssueLaborBookFrom").Value, out DateTime fromDate) && DateTime.TryParse(QueryStrings.FirstOrDefault(d => d.Key == "DateOfIssueLaborBookTo").Value, out DateTime toDate))
                    query = query.Where(d => fromDate <= d.DateOfIssueLaborBook && d.DateOfIssueLaborBook <= toDate);

            if (QueryStrings.Any(d => d.Key == "DateOfIssueLaborBook"))
                if (DateTime.TryParse(QueryStrings.FirstOrDefault(d => d.Key == "DateOfIssueLaborBook").Value, out DateTime val))
                    query = query.Where(d => d.DateOfIssueLaborBook != null && DbFunctions.TruncateTime(val) == DbFunctions.TruncateTime(d.DateOfIssueLaborBook));


			//Query IssuedLaborBookBy (string)
			if (QueryStrings.Any(d => d.Key == "IssuedLaborBookBy_eq") && !string.IsNullOrEmpty(QueryStrings.FirstOrDefault(d => d.Key == "IssuedLaborBookBy_eq").Value))
            {
                var keyword = QueryStrings.FirstOrDefault(d => d.Key == "IssuedLaborBookBy_eq").Value;
                query = query.Where(d=>d.IssuedLaborBookBy == keyword);
            }
            if (QueryStrings.Any(d => d.Key == "IssuedLaborBookBy") && !string.IsNullOrEmpty(QueryStrings.FirstOrDefault(d => d.Key == "IssuedLaborBookBy").Value))
            {
                var keyword = QueryStrings.FirstOrDefault(d => d.Key == "IssuedLaborBookBy").Value;
                query = query.Where(d=>d.IssuedLaborBookBy.Contains(keyword));
            }
            

			//Query StoredRecordCode (string)
			if (QueryStrings.Any(d => d.Key == "StoredRecordCode_eq") && !string.IsNullOrEmpty(QueryStrings.FirstOrDefault(d => d.Key == "StoredRecordCode_eq").Value))
            {
                var keyword = QueryStrings.FirstOrDefault(d => d.Key == "StoredRecordCode_eq").Value;
                query = query.Where(d=>d.StoredRecordCode == keyword);
            }
            if (QueryStrings.Any(d => d.Key == "StoredRecordCode") && !string.IsNullOrEmpty(QueryStrings.FirstOrDefault(d => d.Key == "StoredRecordCode").Value))
            {
                var keyword = QueryStrings.FirstOrDefault(d => d.Key == "StoredRecordCode").Value;
                query = query.Where(d=>d.StoredRecordCode.Contains(keyword));
            }
            

			//Query StoredPlace (string)
			if (QueryStrings.Any(d => d.Key == "StoredPlace_eq") && !string.IsNullOrEmpty(QueryStrings.FirstOrDefault(d => d.Key == "StoredPlace_eq").Value))
            {
                var keyword = QueryStrings.FirstOrDefault(d => d.Key == "StoredPlace_eq").Value;
                query = query.Where(d=>d.StoredPlace == keyword);
            }
            if (QueryStrings.Any(d => d.Key == "StoredPlace") && !string.IsNullOrEmpty(QueryStrings.FirstOrDefault(d => d.Key == "StoredPlace").Value))
            {
                var keyword = QueryStrings.FirstOrDefault(d => d.Key == "StoredPlace").Value;
                query = query.Where(d=>d.StoredPlace.Contains(keyword));
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
            return query;
        }
		
        public static IQueryable<tbl_HRM_StaffCurrentWorking> _sortBuilder(IQueryable<tbl_HRM_StaffCurrentWorking> query, Dictionary<string, string> QueryStrings)
        {
            if (QueryStrings.Any(d => d.Key == "SortBy"))
            {
                var sorts = QueryStrings.FirstOrDefault(d => d.Key == "SortBy").Value.Replace("[", "").Replace("]", "").Split(',');
                
                foreach (var item in sorts)
                    if (!string.IsNullOrEmpty(item))
                    {
                        var ordered = query as IOrderedQueryable<tbl_HRM_StaffCurrentWorking>;
                        bool isOrdered = ordered.ToString().IndexOf("ORDER BY") !=-1;

                        switch (item)
                        {
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
							case "IDStaffType":
								query = isOrdered ? ordered.ThenBy(o => o.IDStaffType) : query.OrderBy(o => o.IDStaffType);
								 break;
							case "IDStaffType_desc":
                                query = isOrdered ? ordered.ThenByDescending(o => o.IDStaffType) : query.OrderByDescending(o => o.IDStaffType);
                                break;
							case "IsShareholder":
								query = isOrdered ? ordered.ThenBy(o => o.IsShareholder) : query.OrderBy(o => o.IsShareholder);
								 break;
							case "IsShareholder_desc":
                                query = isOrdered ? ordered.ThenByDescending(o => o.IsShareholder) : query.OrderByDescending(o => o.IsShareholder);
                                break;
							case "IDDirectManager":
								query = isOrdered ? ordered.ThenBy(o => o.IDDirectManager) : query.OrderBy(o => o.IDDirectManager);
								 break;
							case "IDDirectManager_desc":
                                query = isOrdered ? ordered.ThenByDescending(o => o.IDDirectManager) : query.OrderByDescending(o => o.IDDirectManager);
                                break;
							case "IDIndirectManager":
								query = isOrdered ? ordered.ThenBy(o => o.IDIndirectManager) : query.OrderBy(o => o.IDIndirectManager);
								 break;
							case "IDIndirectManager_desc":
                                query = isOrdered ? ordered.ThenByDescending(o => o.IDIndirectManager) : query.OrderByDescending(o => o.IDIndirectManager);
                                break;
							case "OfficialEntryDate":
								query = isOrdered ? ordered.ThenBy(o => o.OfficialEntryDate) : query.OrderBy(o => o.OfficialEntryDate);
								 break;
							case "OfficialEntryDate_desc":
                                query = isOrdered ? ordered.ThenByDescending(o => o.OfficialEntryDate) : query.OrderByDescending(o => o.OfficialEntryDate);
                                break;
							case "IsResign":
								query = isOrdered ? ordered.ThenBy(o => o.IsResign) : query.OrderBy(o => o.IsResign);
								 break;
							case "IsResign_desc":
                                query = isOrdered ? ordered.ThenByDescending(o => o.IsResign) : query.OrderByDescending(o => o.IsResign);
                                break;
							case "LaborBookNumber":
								query = isOrdered ? ordered.ThenBy(o => o.LaborBookNumber) : query.OrderBy(o => o.LaborBookNumber);
								 break;
							case "LaborBookNumber_desc":
                                query = isOrdered ? ordered.ThenByDescending(o => o.LaborBookNumber) : query.OrderByDescending(o => o.LaborBookNumber);
                                break;
							case "DateOfIssueLaborBook":
								query = isOrdered ? ordered.ThenBy(o => o.DateOfIssueLaborBook) : query.OrderBy(o => o.DateOfIssueLaborBook);
								 break;
							case "DateOfIssueLaborBook_desc":
                                query = isOrdered ? ordered.ThenByDescending(o => o.DateOfIssueLaborBook) : query.OrderByDescending(o => o.DateOfIssueLaborBook);
                                break;
							case "IssuedLaborBookBy":
								query = isOrdered ? ordered.ThenBy(o => o.IssuedLaborBookBy) : query.OrderBy(o => o.IssuedLaborBookBy);
								 break;
							case "IssuedLaborBookBy_desc":
                                query = isOrdered ? ordered.ThenByDescending(o => o.IssuedLaborBookBy) : query.OrderByDescending(o => o.IssuedLaborBookBy);
                                break;
							case "StoredRecordCode":
								query = isOrdered ? ordered.ThenBy(o => o.StoredRecordCode) : query.OrderBy(o => o.StoredRecordCode);
								 break;
							case "StoredRecordCode_desc":
                                query = isOrdered ? ordered.ThenByDescending(o => o.StoredRecordCode) : query.OrderByDescending(o => o.StoredRecordCode);
                                break;
							case "StoredPlace":
								query = isOrdered ? ordered.ThenBy(o => o.StoredPlace) : query.OrderBy(o => o.StoredPlace);
								 break;
							case "StoredPlace_desc":
                                query = isOrdered ? ordered.ThenByDescending(o => o.StoredPlace) : query.OrderByDescending(o => o.StoredPlace);
                                break;
							case "IsDeleted":
								query = isOrdered ? ordered.ThenBy(o => o.IsDeleted) : query.OrderBy(o => o.IsDeleted);
								 break;
							case "IsDeleted_desc":
                                query = isOrdered ? ordered.ThenByDescending(o => o.IsDeleted) : query.OrderByDescending(o => o.IsDeleted);
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

        public static IQueryable<tbl_HRM_StaffCurrentWorking> _pagingBuilder(IQueryable<tbl_HRM_StaffCurrentWorking> query, Dictionary<string, string> QueryStrings)
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






