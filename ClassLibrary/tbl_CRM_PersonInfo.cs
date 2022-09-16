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
    
    
    public partial class tbl_CRM_PersonInfo
    {
        public int Id { get; set; }
        public string FullName { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public Nullable<bool> Gender { get; set; }
        public Nullable<System.DateTime> DateOfBirth { get; set; }
        public string PlaceOfBirth { get; set; }
        public string PlaceOfOrigin { get; set; }
        public string IdentityCardNumber { get; set; }
        public Nullable<System.DateTime> DateOfIssue { get; set; }
        public string PlaceOfIssue { get; set; }
        public Nullable<System.DateTime> DateOfExpiration { get; set; }
        public string Nationality { get; set; }
        public string Ethnic { get; set; }
        public string Religion { get; set; }
        public string MaritalStatus { get; set; }
        public string MobilePhone { get; set; }
        public string HomePhone { get; set; }
        public string Email { get; set; }
        public string Remark { get; set; }
        public Nullable<int> Sort { get; set; }
        public bool IsDisabled { get; set; }
        public bool IsDeleted { get; set; }
        public string CreatedBy { get; set; }
        public string ModifiedBy { get; set; }
        public System.DateTime CreatedDate { get; set; }
        public System.DateTime ModifiedDate { get; set; }
        public string Name { get; set; }
        //List 0:1
        public virtual tbl_CRM_Contact tbl_CRM_Contact { get; set; }
    }
}


namespace DTOModel
{
	using System;
	public partial class DTO_CRM_PersonInfo
	{
		public int Id { get; set; }
		public string FullName { get; set; }
		public string FirstName { get; set; }
		public string LastName { get; set; }
		public Nullable<bool> Gender { get; set; }
		public Nullable<System.DateTime> DateOfBirth { get; set; }
		public string PlaceOfBirth { get; set; }
		public string PlaceOfOrigin { get; set; }
		public string IdentityCardNumber { get; set; }
		public Nullable<System.DateTime> DateOfIssue { get; set; }
		public string PlaceOfIssue { get; set; }
		public Nullable<System.DateTime> DateOfExpiration { get; set; }
		public string Nationality { get; set; }
		public string Ethnic { get; set; }
		public string Religion { get; set; }
		public string MaritalStatus { get; set; }
		public string MobilePhone { get; set; }
		public string HomePhone { get; set; }
		public string Email { get; set; }
		public string Remark { get; set; }
		public Nullable<int> Sort { get; set; }
		public bool IsDisabled { get; set; }
		public bool IsDeleted { get; set; }
		public string CreatedBy { get; set; }
		public string ModifiedBy { get; set; }
		public System.DateTime CreatedDate { get; set; }
		public System.DateTime ModifiedDate { get; set; }
		public string Name { get; set; }
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

    public static partial class BS_CRM_PersonInfo 
    {
        public static dynamic getSearch(AppEntities db, int IDBranch, int StaffID, Dictionary<string, string> QueryStrings)
        {
            return get(db, IDBranch,StaffID, QueryStrings);
        }

		public static IQueryable<DTO_CRM_PersonInfo> get(AppEntities db, int IDBranch, int StaffID, Dictionary<string, string> QueryStrings)
        {
			var query = _queryBuilder(db, IDBranch, StaffID, QueryStrings);
            query = _sortBuilder(query, QueryStrings);
            query = _pagingBuilder(query, QueryStrings);

			return toDTO(query);
        }

        public static List<ItemModel> getValidateData(AppEntities db, int IDBranch, int StaffID, Dictionary<string, string> QueryStrings)
        {
            return get(db, IDBranch, StaffID, QueryStrings).Select(s => new ItemModel { 
                Id = s.Id,  Name = s.Name, 
            }).ToList();
        }

        public static string export(ExcelPackage package, AppEntities db, int IDBranch, int StaffID, Dictionary<string, string> QueryStrings)
        {
            package.Workbook.Properties.Title = "ART-DMS CRM_PersonInfo";
            package.Workbook.Properties.Author = "hung.vu@codeart.vn";
            package.Workbook.Properties.Application = "ART-DMS";
            package.Workbook.Properties.Company = "A.R.T Distribution";

            ExcelWorkbook workBook = package.Workbook;
            if (workBook != null)
            {
                var ws = workBook.Worksheets.FirstOrDefault();
                var data = _queryBuilder(db, IDBranch, StaffID, QueryStrings).ToList();

                //var CRM_ContactList = BS_CRM_Contact.get(db,IDBranch, StaffID,QueryStrings).Select(s => new ItemModel { Id = s.Id, Name = s.Name });
                 

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

		public static DTO_CRM_PersonInfo getAnItem(AppEntities db, int IDBranch, int StaffID, int id)
        {
            var dbResult = db.tbl_CRM_PersonInfo.Find(id);

			return toDTO(dbResult);
			
        }
		

		public static bool put(AppEntities db, int IDBranch, int StaffID, int Id, dynamic item, string Username, Dictionary<string, string> QueryStrings)
        {
            bool result = false;
            var dbitem = db.tbl_CRM_PersonInfo.Find(Id);
            
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
					errorLog.logMessage("put_CRM_PersonInfo",e);
                    result = false;
                }
            }
            else
                if (QueryStrings.Any(d => d.Key == "ForceCreate"))
                    result =  post(db, IDBranch, StaffID, item, Username) != null;
                
            return result;
        }

        public static void patchDynamicToDB(dynamic item, tbl_CRM_PersonInfo dbitem, string Username)
        {
            Type type = typeof(tbl_CRM_PersonInfo);
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

        public static void patchDTOtoDBValue( DTO_CRM_PersonInfo item, tbl_CRM_PersonInfo dbitem)
        {
            if (item == null){
                dbitem = null;
                return;
            }
            							
			dbitem.FullName = item.FullName;							
			dbitem.FirstName = item.FirstName;							
			dbitem.LastName = item.LastName;							
			dbitem.Gender = item.Gender;							
			dbitem.DateOfBirth = item.DateOfBirth;							
			dbitem.PlaceOfBirth = item.PlaceOfBirth;							
			dbitem.PlaceOfOrigin = item.PlaceOfOrigin;							
			dbitem.IdentityCardNumber = item.IdentityCardNumber;							
			dbitem.DateOfIssue = item.DateOfIssue;							
			dbitem.PlaceOfIssue = item.PlaceOfIssue;							
			dbitem.DateOfExpiration = item.DateOfExpiration;							
			dbitem.Nationality = item.Nationality;							
			dbitem.Ethnic = item.Ethnic;							
			dbitem.Religion = item.Religion;							
			dbitem.MaritalStatus = item.MaritalStatus;							
			dbitem.MobilePhone = item.MobilePhone;							
			dbitem.HomePhone = item.HomePhone;							
			dbitem.Email = item.Email;							
			dbitem.Remark = item.Remark;							
			dbitem.Sort = item.Sort;							
			dbitem.IsDisabled = item.IsDisabled;							
			dbitem.IsDeleted = item.IsDeleted;							
			dbitem.Name = item.Name;        }

		public static DTO_CRM_PersonInfo post(AppEntities db, int IDBranch, int StaffID, dynamic item, string Username)
        {
            tbl_CRM_PersonInfo dbitem = new tbl_CRM_PersonInfo();
            if (item != null)
            {
                patchDynamicToDB(item, dbitem, Username);
                
				dbitem.CreatedBy = Username;
				dbitem.CreatedDate = DateTime.Now;				
                try
                {
					db.tbl_CRM_PersonInfo.Add(dbitem);
                    db.SaveChanges();
				
                }
                catch (DbEntityValidationException e)
                {
					errorLog.logMessage("post_CRM_PersonInfo",e);
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
                Type type = Type.GetType("BaseBusiness.BS_CRM_PersonInfo, ClassLibrary");
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
                        var target = new tbl_CRM_PersonInfo();
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
                    
                    tbl_CRM_PersonInfo dbitem = new tbl_CRM_PersonInfo();
                    if (it.Id == null || string.IsNullOrEmpty(it.Id.Value) || it.Id == "0")
                    {
                        dbitem = new tbl_CRM_PersonInfo();
                        dbitem.CreatedBy = Username;
				        dbitem.CreatedDate = DateTime.Now;
                                            }
                    else
                    {
                        dbitem = db.tbl_CRM_PersonInfo.Find((int)it.Id);
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
                        
                        if (dbitem.Id == 0) db.tbl_CRM_PersonInfo.Add(dbitem);
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
                    errorLog.logMessage("post_CRM_PersonInfo",e);
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

            var dbitems = db.tbl_CRM_PersonInfo.Where(d => IDs.Contains(d.Id));
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
			
                BS_Version.update_Version(db, null, "DTO_CRM_PersonInfo", updateDate, Username);
			
            }
            catch (DbEntityValidationException e)
            {
				errorLog.logMessage("delete_CRM_PersonInfo",e);
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

			
            var dbitems = db.tbl_CRM_PersonInfo.Where(d => IDs.Contains(d.Id));
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
			
                BS_Version.update_Version(db, null, "DTO_CRM_PersonInfo", updateDate, Username);
			
            }
            catch (DbEntityValidationException e)
            {
				errorLog.logMessage("disable_CRM_PersonInfo",e);
                result = false;
            }
            
            return result;
        }

		
		//---//
		public static bool check_Exists(AppEntities db, int id)
		{
             
            return db.tbl_CRM_PersonInfo.Any(e => e.Id == id && e.IsDeleted == false);
            
		}
		
		//---//
		public static IQueryable<DTO_CRM_PersonInfo> toDTO(IQueryable<tbl_CRM_PersonInfo> query)
        {
			return query
			.Select(s => new DTO_CRM_PersonInfo(){							
				Id = s.Id,							
				FullName = s.FullName,							
				FirstName = s.FirstName,							
				LastName = s.LastName,							
				Gender = s.Gender,							
				DateOfBirth = s.DateOfBirth,							
				PlaceOfBirth = s.PlaceOfBirth,							
				PlaceOfOrigin = s.PlaceOfOrigin,							
				IdentityCardNumber = s.IdentityCardNumber,							
				DateOfIssue = s.DateOfIssue,							
				PlaceOfIssue = s.PlaceOfIssue,							
				DateOfExpiration = s.DateOfExpiration,							
				Nationality = s.Nationality,							
				Ethnic = s.Ethnic,							
				Religion = s.Religion,							
				MaritalStatus = s.MaritalStatus,							
				MobilePhone = s.MobilePhone,							
				HomePhone = s.HomePhone,							
				Email = s.Email,							
				Remark = s.Remark,							
				Sort = s.Sort,							
				IsDisabled = s.IsDisabled,							
				IsDeleted = s.IsDeleted,							
				CreatedBy = s.CreatedBy,							
				ModifiedBy = s.ModifiedBy,							
				CreatedDate = s.CreatedDate,							
				ModifiedDate = s.ModifiedDate,							
				Name = s.Name,					
			});//.OrderBy(o => o.Sort == null).ThenBy(u => u.Sort);
                              
        }

		public static DTO_CRM_PersonInfo toDTO(tbl_CRM_PersonInfo dbResult)
        {
			if (dbResult != null)
			{
				return new DTO_CRM_PersonInfo()
				{							
					Id = dbResult.Id,							
					FullName = dbResult.FullName,							
					FirstName = dbResult.FirstName,							
					LastName = dbResult.LastName,							
					Gender = dbResult.Gender,							
					DateOfBirth = dbResult.DateOfBirth,							
					PlaceOfBirth = dbResult.PlaceOfBirth,							
					PlaceOfOrigin = dbResult.PlaceOfOrigin,							
					IdentityCardNumber = dbResult.IdentityCardNumber,							
					DateOfIssue = dbResult.DateOfIssue,							
					PlaceOfIssue = dbResult.PlaceOfIssue,							
					DateOfExpiration = dbResult.DateOfExpiration,							
					Nationality = dbResult.Nationality,							
					Ethnic = dbResult.Ethnic,							
					Religion = dbResult.Religion,							
					MaritalStatus = dbResult.MaritalStatus,							
					MobilePhone = dbResult.MobilePhone,							
					HomePhone = dbResult.HomePhone,							
					Email = dbResult.Email,							
					Remark = dbResult.Remark,							
					Sort = dbResult.Sort,							
					IsDisabled = dbResult.IsDisabled,							
					IsDeleted = dbResult.IsDeleted,							
					CreatedBy = dbResult.CreatedBy,							
					ModifiedBy = dbResult.ModifiedBy,							
					CreatedDate = dbResult.CreatedDate,							
					ModifiedDate = dbResult.ModifiedDate,							
					Name = dbResult.Name,
				};
			}
			else
				return null; 
        }

		public static IQueryable<tbl_CRM_PersonInfo> _queryBuilder(AppEntities db, int IDBranch, int StaffID, Dictionary<string, string> QueryStrings)
        {
            
			IQueryable<tbl_CRM_PersonInfo> query = db.tbl_CRM_PersonInfo.AsNoTracking();//.Where(d => d.IsDeleted == false );
			

			//Query keyword
			if (QueryStrings.Any(d => d.Key == "Keyword") && !string.IsNullOrEmpty(QueryStrings.FirstOrDefault(d => d.Key == "Keyword").Value))
            {
                var keyword = QueryStrings.FirstOrDefault(d => d.Key == "Keyword").Value;
                query = query.Where(d=>d.Name.Contains(keyword));
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

			//Query FullName (string)
			if (QueryStrings.Any(d => d.Key == "FullName_eq") && !string.IsNullOrEmpty(QueryStrings.FirstOrDefault(d => d.Key == "FullName_eq").Value))
            {
                var keyword = QueryStrings.FirstOrDefault(d => d.Key == "FullName_eq").Value;
                query = query.Where(d=>d.FullName == keyword);
            }
            if (QueryStrings.Any(d => d.Key == "FullName") && !string.IsNullOrEmpty(QueryStrings.FirstOrDefault(d => d.Key == "FullName").Value))
            {
                var keyword = QueryStrings.FirstOrDefault(d => d.Key == "FullName").Value;
                query = query.Where(d=>d.FullName.Contains(keyword));
            }
            

			//Query FirstName (string)
			if (QueryStrings.Any(d => d.Key == "FirstName_eq") && !string.IsNullOrEmpty(QueryStrings.FirstOrDefault(d => d.Key == "FirstName_eq").Value))
            {
                var keyword = QueryStrings.FirstOrDefault(d => d.Key == "FirstName_eq").Value;
                query = query.Where(d=>d.FirstName == keyword);
            }
            if (QueryStrings.Any(d => d.Key == "FirstName") && !string.IsNullOrEmpty(QueryStrings.FirstOrDefault(d => d.Key == "FirstName").Value))
            {
                var keyword = QueryStrings.FirstOrDefault(d => d.Key == "FirstName").Value;
                query = query.Where(d=>d.FirstName.Contains(keyword));
            }
            

			//Query LastName (string)
			if (QueryStrings.Any(d => d.Key == "LastName_eq") && !string.IsNullOrEmpty(QueryStrings.FirstOrDefault(d => d.Key == "LastName_eq").Value))
            {
                var keyword = QueryStrings.FirstOrDefault(d => d.Key == "LastName_eq").Value;
                query = query.Where(d=>d.LastName == keyword);
            }
            if (QueryStrings.Any(d => d.Key == "LastName") && !string.IsNullOrEmpty(QueryStrings.FirstOrDefault(d => d.Key == "LastName").Value))
            {
                var keyword = QueryStrings.FirstOrDefault(d => d.Key == "LastName").Value;
                query = query.Where(d=>d.LastName.Contains(keyword));
            }
            

			//Query Gender (Nullable<bool>)

			//Query DateOfBirth (Nullable<System.DateTime>)
			if (QueryStrings.Any(d => d.Key == "DateOfBirthFrom") && QueryStrings.Any(d => d.Key == "DateOfBirthTo"))
                if (DateTime.TryParse(QueryStrings.FirstOrDefault(d => d.Key == "DateOfBirthFrom").Value, out DateTime fromDate) && DateTime.TryParse(QueryStrings.FirstOrDefault(d => d.Key == "DateOfBirthTo").Value, out DateTime toDate))
                    query = query.Where(d => fromDate <= d.DateOfBirth && d.DateOfBirth <= toDate);

            if (QueryStrings.Any(d => d.Key == "DateOfBirth"))
                if (DateTime.TryParse(QueryStrings.FirstOrDefault(d => d.Key == "DateOfBirth").Value, out DateTime val))
                    query = query.Where(d => d.DateOfBirth != null && DbFunctions.TruncateTime(val) == DbFunctions.TruncateTime(d.DateOfBirth));


			//Query PlaceOfBirth (string)
			if (QueryStrings.Any(d => d.Key == "PlaceOfBirth_eq") && !string.IsNullOrEmpty(QueryStrings.FirstOrDefault(d => d.Key == "PlaceOfBirth_eq").Value))
            {
                var keyword = QueryStrings.FirstOrDefault(d => d.Key == "PlaceOfBirth_eq").Value;
                query = query.Where(d=>d.PlaceOfBirth == keyword);
            }
            if (QueryStrings.Any(d => d.Key == "PlaceOfBirth") && !string.IsNullOrEmpty(QueryStrings.FirstOrDefault(d => d.Key == "PlaceOfBirth").Value))
            {
                var keyword = QueryStrings.FirstOrDefault(d => d.Key == "PlaceOfBirth").Value;
                query = query.Where(d=>d.PlaceOfBirth.Contains(keyword));
            }
            

			//Query PlaceOfOrigin (string)
			if (QueryStrings.Any(d => d.Key == "PlaceOfOrigin_eq") && !string.IsNullOrEmpty(QueryStrings.FirstOrDefault(d => d.Key == "PlaceOfOrigin_eq").Value))
            {
                var keyword = QueryStrings.FirstOrDefault(d => d.Key == "PlaceOfOrigin_eq").Value;
                query = query.Where(d=>d.PlaceOfOrigin == keyword);
            }
            if (QueryStrings.Any(d => d.Key == "PlaceOfOrigin") && !string.IsNullOrEmpty(QueryStrings.FirstOrDefault(d => d.Key == "PlaceOfOrigin").Value))
            {
                var keyword = QueryStrings.FirstOrDefault(d => d.Key == "PlaceOfOrigin").Value;
                query = query.Where(d=>d.PlaceOfOrigin.Contains(keyword));
            }
            

			//Query IdentityCardNumber (string)
			if (QueryStrings.Any(d => d.Key == "IdentityCardNumber_eq") && !string.IsNullOrEmpty(QueryStrings.FirstOrDefault(d => d.Key == "IdentityCardNumber_eq").Value))
            {
                var keyword = QueryStrings.FirstOrDefault(d => d.Key == "IdentityCardNumber_eq").Value;
                query = query.Where(d=>d.IdentityCardNumber == keyword);
            }
            if (QueryStrings.Any(d => d.Key == "IdentityCardNumber") && !string.IsNullOrEmpty(QueryStrings.FirstOrDefault(d => d.Key == "IdentityCardNumber").Value))
            {
                var keyword = QueryStrings.FirstOrDefault(d => d.Key == "IdentityCardNumber").Value;
                query = query.Where(d=>d.IdentityCardNumber.Contains(keyword));
            }
            

			//Query DateOfIssue (Nullable<System.DateTime>)
			if (QueryStrings.Any(d => d.Key == "DateOfIssueFrom") && QueryStrings.Any(d => d.Key == "DateOfIssueTo"))
                if (DateTime.TryParse(QueryStrings.FirstOrDefault(d => d.Key == "DateOfIssueFrom").Value, out DateTime fromDate) && DateTime.TryParse(QueryStrings.FirstOrDefault(d => d.Key == "DateOfIssueTo").Value, out DateTime toDate))
                    query = query.Where(d => fromDate <= d.DateOfIssue && d.DateOfIssue <= toDate);

            if (QueryStrings.Any(d => d.Key == "DateOfIssue"))
                if (DateTime.TryParse(QueryStrings.FirstOrDefault(d => d.Key == "DateOfIssue").Value, out DateTime val))
                    query = query.Where(d => d.DateOfIssue != null && DbFunctions.TruncateTime(val) == DbFunctions.TruncateTime(d.DateOfIssue));


			//Query PlaceOfIssue (string)
			if (QueryStrings.Any(d => d.Key == "PlaceOfIssue_eq") && !string.IsNullOrEmpty(QueryStrings.FirstOrDefault(d => d.Key == "PlaceOfIssue_eq").Value))
            {
                var keyword = QueryStrings.FirstOrDefault(d => d.Key == "PlaceOfIssue_eq").Value;
                query = query.Where(d=>d.PlaceOfIssue == keyword);
            }
            if (QueryStrings.Any(d => d.Key == "PlaceOfIssue") && !string.IsNullOrEmpty(QueryStrings.FirstOrDefault(d => d.Key == "PlaceOfIssue").Value))
            {
                var keyword = QueryStrings.FirstOrDefault(d => d.Key == "PlaceOfIssue").Value;
                query = query.Where(d=>d.PlaceOfIssue.Contains(keyword));
            }
            

			//Query DateOfExpiration (Nullable<System.DateTime>)
			if (QueryStrings.Any(d => d.Key == "DateOfExpirationFrom") && QueryStrings.Any(d => d.Key == "DateOfExpirationTo"))
                if (DateTime.TryParse(QueryStrings.FirstOrDefault(d => d.Key == "DateOfExpirationFrom").Value, out DateTime fromDate) && DateTime.TryParse(QueryStrings.FirstOrDefault(d => d.Key == "DateOfExpirationTo").Value, out DateTime toDate))
                    query = query.Where(d => fromDate <= d.DateOfExpiration && d.DateOfExpiration <= toDate);

            if (QueryStrings.Any(d => d.Key == "DateOfExpiration"))
                if (DateTime.TryParse(QueryStrings.FirstOrDefault(d => d.Key == "DateOfExpiration").Value, out DateTime val))
                    query = query.Where(d => d.DateOfExpiration != null && DbFunctions.TruncateTime(val) == DbFunctions.TruncateTime(d.DateOfExpiration));


			//Query Nationality (string)
			if (QueryStrings.Any(d => d.Key == "Nationality_eq") && !string.IsNullOrEmpty(QueryStrings.FirstOrDefault(d => d.Key == "Nationality_eq").Value))
            {
                var keyword = QueryStrings.FirstOrDefault(d => d.Key == "Nationality_eq").Value;
                query = query.Where(d=>d.Nationality == keyword);
            }
            if (QueryStrings.Any(d => d.Key == "Nationality") && !string.IsNullOrEmpty(QueryStrings.FirstOrDefault(d => d.Key == "Nationality").Value))
            {
                var keyword = QueryStrings.FirstOrDefault(d => d.Key == "Nationality").Value;
                query = query.Where(d=>d.Nationality.Contains(keyword));
            }
            

			//Query Ethnic (string)
			if (QueryStrings.Any(d => d.Key == "Ethnic_eq") && !string.IsNullOrEmpty(QueryStrings.FirstOrDefault(d => d.Key == "Ethnic_eq").Value))
            {
                var keyword = QueryStrings.FirstOrDefault(d => d.Key == "Ethnic_eq").Value;
                query = query.Where(d=>d.Ethnic == keyword);
            }
            if (QueryStrings.Any(d => d.Key == "Ethnic") && !string.IsNullOrEmpty(QueryStrings.FirstOrDefault(d => d.Key == "Ethnic").Value))
            {
                var keyword = QueryStrings.FirstOrDefault(d => d.Key == "Ethnic").Value;
                query = query.Where(d=>d.Ethnic.Contains(keyword));
            }
            

			//Query Religion (string)
			if (QueryStrings.Any(d => d.Key == "Religion_eq") && !string.IsNullOrEmpty(QueryStrings.FirstOrDefault(d => d.Key == "Religion_eq").Value))
            {
                var keyword = QueryStrings.FirstOrDefault(d => d.Key == "Religion_eq").Value;
                query = query.Where(d=>d.Religion == keyword);
            }
            if (QueryStrings.Any(d => d.Key == "Religion") && !string.IsNullOrEmpty(QueryStrings.FirstOrDefault(d => d.Key == "Religion").Value))
            {
                var keyword = QueryStrings.FirstOrDefault(d => d.Key == "Religion").Value;
                query = query.Where(d=>d.Religion.Contains(keyword));
            }
            

			//Query MaritalStatus (string)
			if (QueryStrings.Any(d => d.Key == "MaritalStatus_eq") && !string.IsNullOrEmpty(QueryStrings.FirstOrDefault(d => d.Key == "MaritalStatus_eq").Value))
            {
                var keyword = QueryStrings.FirstOrDefault(d => d.Key == "MaritalStatus_eq").Value;
                query = query.Where(d=>d.MaritalStatus == keyword);
            }
            if (QueryStrings.Any(d => d.Key == "MaritalStatus") && !string.IsNullOrEmpty(QueryStrings.FirstOrDefault(d => d.Key == "MaritalStatus").Value))
            {
                var keyword = QueryStrings.FirstOrDefault(d => d.Key == "MaritalStatus").Value;
                query = query.Where(d=>d.MaritalStatus.Contains(keyword));
            }
            

			//Query MobilePhone (string)
			if (QueryStrings.Any(d => d.Key == "MobilePhone_eq") && !string.IsNullOrEmpty(QueryStrings.FirstOrDefault(d => d.Key == "MobilePhone_eq").Value))
            {
                var keyword = QueryStrings.FirstOrDefault(d => d.Key == "MobilePhone_eq").Value;
                query = query.Where(d=>d.MobilePhone == keyword);
            }
            if (QueryStrings.Any(d => d.Key == "MobilePhone") && !string.IsNullOrEmpty(QueryStrings.FirstOrDefault(d => d.Key == "MobilePhone").Value))
            {
                var keyword = QueryStrings.FirstOrDefault(d => d.Key == "MobilePhone").Value;
                query = query.Where(d=>d.MobilePhone.Contains(keyword));
            }
            

			//Query HomePhone (string)
			if (QueryStrings.Any(d => d.Key == "HomePhone_eq") && !string.IsNullOrEmpty(QueryStrings.FirstOrDefault(d => d.Key == "HomePhone_eq").Value))
            {
                var keyword = QueryStrings.FirstOrDefault(d => d.Key == "HomePhone_eq").Value;
                query = query.Where(d=>d.HomePhone == keyword);
            }
            if (QueryStrings.Any(d => d.Key == "HomePhone") && !string.IsNullOrEmpty(QueryStrings.FirstOrDefault(d => d.Key == "HomePhone").Value))
            {
                var keyword = QueryStrings.FirstOrDefault(d => d.Key == "HomePhone").Value;
                query = query.Where(d=>d.HomePhone.Contains(keyword));
            }
            

			//Query Email (string)
			if (QueryStrings.Any(d => d.Key == "Email_eq") && !string.IsNullOrEmpty(QueryStrings.FirstOrDefault(d => d.Key == "Email_eq").Value))
            {
                var keyword = QueryStrings.FirstOrDefault(d => d.Key == "Email_eq").Value;
                query = query.Where(d=>d.Email == keyword);
            }
            if (QueryStrings.Any(d => d.Key == "Email") && !string.IsNullOrEmpty(QueryStrings.FirstOrDefault(d => d.Key == "Email").Value))
            {
                var keyword = QueryStrings.FirstOrDefault(d => d.Key == "Email").Value;
                query = query.Where(d=>d.Email.Contains(keyword));
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
            
            return query;
        }
		
        public static IQueryable<tbl_CRM_PersonInfo> _sortBuilder(IQueryable<tbl_CRM_PersonInfo> query, Dictionary<string, string> QueryStrings)
        {
            if (QueryStrings.Any(d => d.Key == "SortBy"))
            {
                var sorts = QueryStrings.FirstOrDefault(d => d.Key == "SortBy").Value.Replace("[", "").Replace("]", "").Split(',');
                
                foreach (var item in sorts)
                    if (!string.IsNullOrEmpty(item))
                    {
                        var ordered = query as IOrderedQueryable<tbl_CRM_PersonInfo>;
                        bool isOrdered = ordered.ToString().IndexOf("ORDER BY") !=-1;

                        switch (item)
                        {
							case "Id":
								query = isOrdered ? ordered.ThenBy(o => o.Id) : query.OrderBy(o => o.Id);
								 break;
							case "Id_desc":
                                query = isOrdered ? ordered.ThenByDescending(o => o.Id) : query.OrderByDescending(o => o.Id);
                                break;
							case "FullName":
								query = isOrdered ? ordered.ThenBy(o => o.FullName) : query.OrderBy(o => o.FullName);
								 break;
							case "FullName_desc":
                                query = isOrdered ? ordered.ThenByDescending(o => o.FullName) : query.OrderByDescending(o => o.FullName);
                                break;
							case "FirstName":
								query = isOrdered ? ordered.ThenBy(o => o.FirstName) : query.OrderBy(o => o.FirstName);
								 break;
							case "FirstName_desc":
                                query = isOrdered ? ordered.ThenByDescending(o => o.FirstName) : query.OrderByDescending(o => o.FirstName);
                                break;
							case "LastName":
								query = isOrdered ? ordered.ThenBy(o => o.LastName) : query.OrderBy(o => o.LastName);
								 break;
							case "LastName_desc":
                                query = isOrdered ? ordered.ThenByDescending(o => o.LastName) : query.OrderByDescending(o => o.LastName);
                                break;
							case "Gender":
								query = isOrdered ? ordered.ThenBy(o => o.Gender) : query.OrderBy(o => o.Gender);
								 break;
							case "Gender_desc":
                                query = isOrdered ? ordered.ThenByDescending(o => o.Gender) : query.OrderByDescending(o => o.Gender);
                                break;
							case "DateOfBirth":
								query = isOrdered ? ordered.ThenBy(o => o.DateOfBirth) : query.OrderBy(o => o.DateOfBirth);
								 break;
							case "DateOfBirth_desc":
                                query = isOrdered ? ordered.ThenByDescending(o => o.DateOfBirth) : query.OrderByDescending(o => o.DateOfBirth);
                                break;
							case "PlaceOfBirth":
								query = isOrdered ? ordered.ThenBy(o => o.PlaceOfBirth) : query.OrderBy(o => o.PlaceOfBirth);
								 break;
							case "PlaceOfBirth_desc":
                                query = isOrdered ? ordered.ThenByDescending(o => o.PlaceOfBirth) : query.OrderByDescending(o => o.PlaceOfBirth);
                                break;
							case "PlaceOfOrigin":
								query = isOrdered ? ordered.ThenBy(o => o.PlaceOfOrigin) : query.OrderBy(o => o.PlaceOfOrigin);
								 break;
							case "PlaceOfOrigin_desc":
                                query = isOrdered ? ordered.ThenByDescending(o => o.PlaceOfOrigin) : query.OrderByDescending(o => o.PlaceOfOrigin);
                                break;
							case "IdentityCardNumber":
								query = isOrdered ? ordered.ThenBy(o => o.IdentityCardNumber) : query.OrderBy(o => o.IdentityCardNumber);
								 break;
							case "IdentityCardNumber_desc":
                                query = isOrdered ? ordered.ThenByDescending(o => o.IdentityCardNumber) : query.OrderByDescending(o => o.IdentityCardNumber);
                                break;
							case "DateOfIssue":
								query = isOrdered ? ordered.ThenBy(o => o.DateOfIssue) : query.OrderBy(o => o.DateOfIssue);
								 break;
							case "DateOfIssue_desc":
                                query = isOrdered ? ordered.ThenByDescending(o => o.DateOfIssue) : query.OrderByDescending(o => o.DateOfIssue);
                                break;
							case "PlaceOfIssue":
								query = isOrdered ? ordered.ThenBy(o => o.PlaceOfIssue) : query.OrderBy(o => o.PlaceOfIssue);
								 break;
							case "PlaceOfIssue_desc":
                                query = isOrdered ? ordered.ThenByDescending(o => o.PlaceOfIssue) : query.OrderByDescending(o => o.PlaceOfIssue);
                                break;
							case "DateOfExpiration":
								query = isOrdered ? ordered.ThenBy(o => o.DateOfExpiration) : query.OrderBy(o => o.DateOfExpiration);
								 break;
							case "DateOfExpiration_desc":
                                query = isOrdered ? ordered.ThenByDescending(o => o.DateOfExpiration) : query.OrderByDescending(o => o.DateOfExpiration);
                                break;
							case "Nationality":
								query = isOrdered ? ordered.ThenBy(o => o.Nationality) : query.OrderBy(o => o.Nationality);
								 break;
							case "Nationality_desc":
                                query = isOrdered ? ordered.ThenByDescending(o => o.Nationality) : query.OrderByDescending(o => o.Nationality);
                                break;
							case "Ethnic":
								query = isOrdered ? ordered.ThenBy(o => o.Ethnic) : query.OrderBy(o => o.Ethnic);
								 break;
							case "Ethnic_desc":
                                query = isOrdered ? ordered.ThenByDescending(o => o.Ethnic) : query.OrderByDescending(o => o.Ethnic);
                                break;
							case "Religion":
								query = isOrdered ? ordered.ThenBy(o => o.Religion) : query.OrderBy(o => o.Religion);
								 break;
							case "Religion_desc":
                                query = isOrdered ? ordered.ThenByDescending(o => o.Religion) : query.OrderByDescending(o => o.Religion);
                                break;
							case "MaritalStatus":
								query = isOrdered ? ordered.ThenBy(o => o.MaritalStatus) : query.OrderBy(o => o.MaritalStatus);
								 break;
							case "MaritalStatus_desc":
                                query = isOrdered ? ordered.ThenByDescending(o => o.MaritalStatus) : query.OrderByDescending(o => o.MaritalStatus);
                                break;
							case "MobilePhone":
								query = isOrdered ? ordered.ThenBy(o => o.MobilePhone) : query.OrderBy(o => o.MobilePhone);
								 break;
							case "MobilePhone_desc":
                                query = isOrdered ? ordered.ThenByDescending(o => o.MobilePhone) : query.OrderByDescending(o => o.MobilePhone);
                                break;
							case "HomePhone":
								query = isOrdered ? ordered.ThenBy(o => o.HomePhone) : query.OrderBy(o => o.HomePhone);
								 break;
							case "HomePhone_desc":
                                query = isOrdered ? ordered.ThenByDescending(o => o.HomePhone) : query.OrderByDescending(o => o.HomePhone);
                                break;
							case "Email":
								query = isOrdered ? ordered.ThenBy(o => o.Email) : query.OrderBy(o => o.Email);
								 break;
							case "Email_desc":
                                query = isOrdered ? ordered.ThenByDescending(o => o.Email) : query.OrderByDescending(o => o.Email);
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
							case "Name":
								query = isOrdered ? ordered.ThenBy(o => o.Name) : query.OrderBy(o => o.Name);
								 break;
							case "Name_desc":
                                query = isOrdered ? ordered.ThenByDescending(o => o.Name) : query.OrderByDescending(o => o.Name);
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

        public static IQueryable<tbl_CRM_PersonInfo> _pagingBuilder(IQueryable<tbl_CRM_PersonInfo> query, Dictionary<string, string> QueryStrings)
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






