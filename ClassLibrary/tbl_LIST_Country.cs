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
    
    
    public partial class tbl_LIST_Country
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public tbl_LIST_Country()
        {
            this.tbl_HRM_StaffBasicInfo = new HashSet<tbl_HRM_StaffBasicInfo>();
            this.tbl_HRM_StaffFamily = new HashSet<tbl_HRM_StaffFamily>();
            this.tbl_HRM_StaffIdentityCardAndPIT = new HashSet<tbl_HRM_StaffIdentityCardAndPIT>();
            this.tbl_HRM_StaffIdentityCardAndPIT1 = new HashSet<tbl_HRM_StaffIdentityCardAndPIT>();
            this.tbl_LIST_Province = new HashSet<tbl_LIST_Province>();
        }
    
        public int Id { get; set; }
        public string Code { get; set; }
        public string Name { get; set; }
        public string FormalName { get; set; }
        public string CountryType { get; set; }
        public string CountrySubType { get; set; }
        public string Sovereignty { get; set; }
        public string Capital { get; set; }
        public string CurrencyCode { get; set; }
        public string CurrencyName { get; set; }
        public string TelephoneCode { get; set; }
        public string CountryCode3 { get; set; }
        public string CountryNumber { get; set; }
        public string InternetCountryCode { get; set; }
        public string Flags { get; set; }
        public string Remark { get; set; }
        public Nullable<int> Sort { get; set; }
        public bool IsDisabled { get; set; }
        public bool IsDeleted { get; set; }
        public string CreatedBy { get; set; }
        public string ModifiedBy { get; set; }
        public System.DateTime CreatedDate { get; set; }
        public System.DateTime ModifiedDate { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tbl_HRM_StaffBasicInfo> tbl_HRM_StaffBasicInfo { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tbl_HRM_StaffFamily> tbl_HRM_StaffFamily { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tbl_HRM_StaffIdentityCardAndPIT> tbl_HRM_StaffIdentityCardAndPIT { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tbl_HRM_StaffIdentityCardAndPIT> tbl_HRM_StaffIdentityCardAndPIT1 { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tbl_LIST_Province> tbl_LIST_Province { get; set; }
    }
}


namespace DTOModel
{
	using System;
	public partial class DTO_LIST_Country
	{
		public int Id { get; set; }
		public string Code { get; set; }
		public string Name { get; set; }
		public string FormalName { get; set; }
		public string CountryType { get; set; }
		public string CountrySubType { get; set; }
		public string Sovereignty { get; set; }
		public string Capital { get; set; }
		public string CurrencyCode { get; set; }
		public string CurrencyName { get; set; }
		public string TelephoneCode { get; set; }
		public string CountryCode3 { get; set; }
		public string CountryNumber { get; set; }
		public string InternetCountryCode { get; set; }
		public string Flags { get; set; }
		public string Remark { get; set; }
		public Nullable<int> Sort { get; set; }
		public bool IsDisabled { get; set; }
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

    public static partial class BS_LIST_Country 
    {
        public static dynamic getSearch(AppEntities db, int IDBranch, int StaffID, Dictionary<string, string> QueryStrings)
        {
            return get(db, IDBranch,StaffID, QueryStrings);
        }

		public static IQueryable<DTO_LIST_Country> get(AppEntities db, int IDBranch, int StaffID, Dictionary<string, string> QueryStrings)
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
            package.Workbook.Properties.Title = "ART-DMS LIST_Country";
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

		public static DTO_LIST_Country getAnItem(AppEntities db, int IDBranch, int StaffID, int id)
        {
            var dbResult = db.tbl_LIST_Country.Find(id);

			return toDTO(dbResult);
			
        }
		
		public static DTO_LIST_Country getAnItemByCode(AppEntities db, int IDBranch, int StaffID, string code)
        {
            var dbResult = db.tbl_LIST_Country
			.FirstOrDefault(d => d.IsDeleted == false && d.Code == code );

			return toDTO(dbResult);
			
        }

		public static bool put(AppEntities db, int IDBranch, int StaffID, int Id, dynamic item, string Username, Dictionary<string, string> QueryStrings)
        {
            bool result = false;
            var dbitem = db.tbl_LIST_Country.Find(Id);
            
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
					errorLog.logMessage("put_LIST_Country",e);
                    result = false;
                }
            }
            else
                if (QueryStrings.Any(d => d.Key == "ForceCreate"))
                    result =  post(db, IDBranch, StaffID, item, Username) != null;
                
            return result;
        }

        public static void patchDynamicToDB(dynamic item, tbl_LIST_Country dbitem, string Username)
        {
            Type type = typeof(tbl_LIST_Country);
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

        public static void patchDTOtoDBValue( DTO_LIST_Country item, tbl_LIST_Country dbitem)
        {
            if (item == null){
                dbitem = null;
                return;
            }
            							
			dbitem.Code = item.Code;							
			dbitem.Name = item.Name;							
			dbitem.FormalName = item.FormalName;							
			dbitem.CountryType = item.CountryType;							
			dbitem.CountrySubType = item.CountrySubType;							
			dbitem.Sovereignty = item.Sovereignty;							
			dbitem.Capital = item.Capital;							
			dbitem.CurrencyCode = item.CurrencyCode;							
			dbitem.CurrencyName = item.CurrencyName;							
			dbitem.TelephoneCode = item.TelephoneCode;							
			dbitem.CountryCode3 = item.CountryCode3;							
			dbitem.CountryNumber = item.CountryNumber;							
			dbitem.InternetCountryCode = item.InternetCountryCode;							
			dbitem.Flags = item.Flags;							
			dbitem.Remark = item.Remark;							
			dbitem.Sort = item.Sort;							
			dbitem.IsDisabled = item.IsDisabled;							
			dbitem.IsDeleted = item.IsDeleted;        }

		public static DTO_LIST_Country post(AppEntities db, int IDBranch, int StaffID, dynamic item, string Username)
        {
            tbl_LIST_Country dbitem = new tbl_LIST_Country();
            if (item != null)
            {
                patchDynamicToDB(item, dbitem, Username);
                
				dbitem.CreatedBy = Username;
				dbitem.CreatedDate = DateTime.Now;				
                try
                {
					db.tbl_LIST_Country.Add(dbitem);
                    db.SaveChanges();
				
                }
                catch (DbEntityValidationException e)
                {
					errorLog.logMessage("post_LIST_Country",e);
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
                Type type = Type.GetType("BaseBusiness.BS_LIST_Country, ClassLibrary");
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
                        var target = new tbl_LIST_Country();
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
                    
                    tbl_LIST_Country dbitem = new tbl_LIST_Country();
                    if (it.Id == null || string.IsNullOrEmpty(it.Id.Value) || it.Id == "0")
                    {
                        dbitem = new tbl_LIST_Country();
                        dbitem.CreatedBy = Username;
				        dbitem.CreatedDate = DateTime.Now;
                                            }
                    else
                    {
                        dbitem = db.tbl_LIST_Country.Find((int)it.Id);
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
                        
                        if (dbitem.Id == 0) db.tbl_LIST_Country.Add(dbitem);
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
                    errorLog.logMessage("post_LIST_Country",e);
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

            var dbitems = db.tbl_LIST_Country.Where(d => IDs.Contains(d.Id));
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
			
                BS_Version.update_Version(db, null, "DTO_LIST_Country", updateDate, Username);
			
            }
            catch (DbEntityValidationException e)
            {
				errorLog.logMessage("delete_LIST_Country",e);
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

			
            var dbitems = db.tbl_LIST_Country.Where(d => IDs.Contains(d.Id));
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
			
                BS_Version.update_Version(db, null, "DTO_LIST_Country", updateDate, Username);
			
            }
            catch (DbEntityValidationException e)
            {
				errorLog.logMessage("disable_LIST_Country",e);
                result = false;
            }
            
            return result;
        }

		
		//---//
		public static bool check_Exists(AppEntities db, int id)
		{
             
            return db.tbl_LIST_Country.Any(e => e.Id == id && e.IsDeleted == false);
            
		}
		
		public static bool check_Exists(AppEntities db, string Code)
		{
             
            return db.tbl_LIST_Country.Any(e => e.Code == Code && e.IsDeleted == false);
            
		}
		
		//---//
		public static IQueryable<DTO_LIST_Country> toDTO(IQueryable<tbl_LIST_Country> query)
        {
			return query
			.Select(s => new DTO_LIST_Country(){							
				Id = s.Id,							
				Code = s.Code,							
				Name = s.Name,							
				FormalName = s.FormalName,							
				CountryType = s.CountryType,							
				CountrySubType = s.CountrySubType,							
				Sovereignty = s.Sovereignty,							
				Capital = s.Capital,							
				CurrencyCode = s.CurrencyCode,							
				CurrencyName = s.CurrencyName,							
				TelephoneCode = s.TelephoneCode,							
				CountryCode3 = s.CountryCode3,							
				CountryNumber = s.CountryNumber,							
				InternetCountryCode = s.InternetCountryCode,							
				Flags = s.Flags,							
				Remark = s.Remark,							
				Sort = s.Sort,							
				IsDisabled = s.IsDisabled,							
				IsDeleted = s.IsDeleted,							
				CreatedBy = s.CreatedBy,							
				ModifiedBy = s.ModifiedBy,							
				CreatedDate = s.CreatedDate,							
				ModifiedDate = s.ModifiedDate,					
			});//.OrderBy(o => o.Sort == null).ThenBy(u => u.Sort);
                              
        }

		public static DTO_LIST_Country toDTO(tbl_LIST_Country dbResult)
        {
			if (dbResult != null)
			{
				return new DTO_LIST_Country()
				{							
					Id = dbResult.Id,							
					Code = dbResult.Code,							
					Name = dbResult.Name,							
					FormalName = dbResult.FormalName,							
					CountryType = dbResult.CountryType,							
					CountrySubType = dbResult.CountrySubType,							
					Sovereignty = dbResult.Sovereignty,							
					Capital = dbResult.Capital,							
					CurrencyCode = dbResult.CurrencyCode,							
					CurrencyName = dbResult.CurrencyName,							
					TelephoneCode = dbResult.TelephoneCode,							
					CountryCode3 = dbResult.CountryCode3,							
					CountryNumber = dbResult.CountryNumber,							
					InternetCountryCode = dbResult.InternetCountryCode,							
					Flags = dbResult.Flags,							
					Remark = dbResult.Remark,							
					Sort = dbResult.Sort,							
					IsDisabled = dbResult.IsDisabled,							
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

		public static IQueryable<tbl_LIST_Country> _queryBuilder(AppEntities db, int IDBranch, int StaffID, Dictionary<string, string> QueryStrings)
        {
            
			IQueryable<tbl_LIST_Country> query = db.tbl_LIST_Country.AsNoTracking();//.Where(d => d.IsDeleted == false );
			

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
            

			//Query FormalName (string)
			if (QueryStrings.Any(d => d.Key == "FormalName_eq") && !string.IsNullOrEmpty(QueryStrings.FirstOrDefault(d => d.Key == "FormalName_eq").Value))
            {
                var keyword = QueryStrings.FirstOrDefault(d => d.Key == "FormalName_eq").Value;
                query = query.Where(d=>d.FormalName == keyword);
            }
            if (QueryStrings.Any(d => d.Key == "FormalName") && !string.IsNullOrEmpty(QueryStrings.FirstOrDefault(d => d.Key == "FormalName").Value))
            {
                var keyword = QueryStrings.FirstOrDefault(d => d.Key == "FormalName").Value;
                query = query.Where(d=>d.FormalName.Contains(keyword));
            }
            

			//Query CountryType (string)
			if (QueryStrings.Any(d => d.Key == "CountryType_eq") && !string.IsNullOrEmpty(QueryStrings.FirstOrDefault(d => d.Key == "CountryType_eq").Value))
            {
                var keyword = QueryStrings.FirstOrDefault(d => d.Key == "CountryType_eq").Value;
                query = query.Where(d=>d.CountryType == keyword);
            }
            if (QueryStrings.Any(d => d.Key == "CountryType") && !string.IsNullOrEmpty(QueryStrings.FirstOrDefault(d => d.Key == "CountryType").Value))
            {
                var keyword = QueryStrings.FirstOrDefault(d => d.Key == "CountryType").Value;
                query = query.Where(d=>d.CountryType.Contains(keyword));
            }
            

			//Query CountrySubType (string)
			if (QueryStrings.Any(d => d.Key == "CountrySubType_eq") && !string.IsNullOrEmpty(QueryStrings.FirstOrDefault(d => d.Key == "CountrySubType_eq").Value))
            {
                var keyword = QueryStrings.FirstOrDefault(d => d.Key == "CountrySubType_eq").Value;
                query = query.Where(d=>d.CountrySubType == keyword);
            }
            if (QueryStrings.Any(d => d.Key == "CountrySubType") && !string.IsNullOrEmpty(QueryStrings.FirstOrDefault(d => d.Key == "CountrySubType").Value))
            {
                var keyword = QueryStrings.FirstOrDefault(d => d.Key == "CountrySubType").Value;
                query = query.Where(d=>d.CountrySubType.Contains(keyword));
            }
            

			//Query Sovereignty (string)
			if (QueryStrings.Any(d => d.Key == "Sovereignty_eq") && !string.IsNullOrEmpty(QueryStrings.FirstOrDefault(d => d.Key == "Sovereignty_eq").Value))
            {
                var keyword = QueryStrings.FirstOrDefault(d => d.Key == "Sovereignty_eq").Value;
                query = query.Where(d=>d.Sovereignty == keyword);
            }
            if (QueryStrings.Any(d => d.Key == "Sovereignty") && !string.IsNullOrEmpty(QueryStrings.FirstOrDefault(d => d.Key == "Sovereignty").Value))
            {
                var keyword = QueryStrings.FirstOrDefault(d => d.Key == "Sovereignty").Value;
                query = query.Where(d=>d.Sovereignty.Contains(keyword));
            }
            

			//Query Capital (string)
			if (QueryStrings.Any(d => d.Key == "Capital_eq") && !string.IsNullOrEmpty(QueryStrings.FirstOrDefault(d => d.Key == "Capital_eq").Value))
            {
                var keyword = QueryStrings.FirstOrDefault(d => d.Key == "Capital_eq").Value;
                query = query.Where(d=>d.Capital == keyword);
            }
            if (QueryStrings.Any(d => d.Key == "Capital") && !string.IsNullOrEmpty(QueryStrings.FirstOrDefault(d => d.Key == "Capital").Value))
            {
                var keyword = QueryStrings.FirstOrDefault(d => d.Key == "Capital").Value;
                query = query.Where(d=>d.Capital.Contains(keyword));
            }
            

			//Query CurrencyCode (string)
			if (QueryStrings.Any(d => d.Key == "CurrencyCode_eq") && !string.IsNullOrEmpty(QueryStrings.FirstOrDefault(d => d.Key == "CurrencyCode_eq").Value))
            {
                var keyword = QueryStrings.FirstOrDefault(d => d.Key == "CurrencyCode_eq").Value;
                query = query.Where(d=>d.CurrencyCode == keyword);
            }
            if (QueryStrings.Any(d => d.Key == "CurrencyCode") && !string.IsNullOrEmpty(QueryStrings.FirstOrDefault(d => d.Key == "CurrencyCode").Value))
            {
                var keyword = QueryStrings.FirstOrDefault(d => d.Key == "CurrencyCode").Value;
                query = query.Where(d=>d.CurrencyCode.Contains(keyword));
            }
            

			//Query CurrencyName (string)
			if (QueryStrings.Any(d => d.Key == "CurrencyName_eq") && !string.IsNullOrEmpty(QueryStrings.FirstOrDefault(d => d.Key == "CurrencyName_eq").Value))
            {
                var keyword = QueryStrings.FirstOrDefault(d => d.Key == "CurrencyName_eq").Value;
                query = query.Where(d=>d.CurrencyName == keyword);
            }
            if (QueryStrings.Any(d => d.Key == "CurrencyName") && !string.IsNullOrEmpty(QueryStrings.FirstOrDefault(d => d.Key == "CurrencyName").Value))
            {
                var keyword = QueryStrings.FirstOrDefault(d => d.Key == "CurrencyName").Value;
                query = query.Where(d=>d.CurrencyName.Contains(keyword));
            }
            

			//Query TelephoneCode (string)
			if (QueryStrings.Any(d => d.Key == "TelephoneCode_eq") && !string.IsNullOrEmpty(QueryStrings.FirstOrDefault(d => d.Key == "TelephoneCode_eq").Value))
            {
                var keyword = QueryStrings.FirstOrDefault(d => d.Key == "TelephoneCode_eq").Value;
                query = query.Where(d=>d.TelephoneCode == keyword);
            }
            if (QueryStrings.Any(d => d.Key == "TelephoneCode") && !string.IsNullOrEmpty(QueryStrings.FirstOrDefault(d => d.Key == "TelephoneCode").Value))
            {
                var keyword = QueryStrings.FirstOrDefault(d => d.Key == "TelephoneCode").Value;
                query = query.Where(d=>d.TelephoneCode.Contains(keyword));
            }
            

			//Query CountryCode3 (string)
			if (QueryStrings.Any(d => d.Key == "CountryCode3_eq") && !string.IsNullOrEmpty(QueryStrings.FirstOrDefault(d => d.Key == "CountryCode3_eq").Value))
            {
                var keyword = QueryStrings.FirstOrDefault(d => d.Key == "CountryCode3_eq").Value;
                query = query.Where(d=>d.CountryCode3 == keyword);
            }
            if (QueryStrings.Any(d => d.Key == "CountryCode3") && !string.IsNullOrEmpty(QueryStrings.FirstOrDefault(d => d.Key == "CountryCode3").Value))
            {
                var keyword = QueryStrings.FirstOrDefault(d => d.Key == "CountryCode3").Value;
                query = query.Where(d=>d.CountryCode3.Contains(keyword));
            }
            

			//Query CountryNumber (string)
			if (QueryStrings.Any(d => d.Key == "CountryNumber_eq") && !string.IsNullOrEmpty(QueryStrings.FirstOrDefault(d => d.Key == "CountryNumber_eq").Value))
            {
                var keyword = QueryStrings.FirstOrDefault(d => d.Key == "CountryNumber_eq").Value;
                query = query.Where(d=>d.CountryNumber == keyword);
            }
            if (QueryStrings.Any(d => d.Key == "CountryNumber") && !string.IsNullOrEmpty(QueryStrings.FirstOrDefault(d => d.Key == "CountryNumber").Value))
            {
                var keyword = QueryStrings.FirstOrDefault(d => d.Key == "CountryNumber").Value;
                query = query.Where(d=>d.CountryNumber.Contains(keyword));
            }
            

			//Query InternetCountryCode (string)
			if (QueryStrings.Any(d => d.Key == "InternetCountryCode_eq") && !string.IsNullOrEmpty(QueryStrings.FirstOrDefault(d => d.Key == "InternetCountryCode_eq").Value))
            {
                var keyword = QueryStrings.FirstOrDefault(d => d.Key == "InternetCountryCode_eq").Value;
                query = query.Where(d=>d.InternetCountryCode == keyword);
            }
            if (QueryStrings.Any(d => d.Key == "InternetCountryCode") && !string.IsNullOrEmpty(QueryStrings.FirstOrDefault(d => d.Key == "InternetCountryCode").Value))
            {
                var keyword = QueryStrings.FirstOrDefault(d => d.Key == "InternetCountryCode").Value;
                query = query.Where(d=>d.InternetCountryCode.Contains(keyword));
            }
            

			//Query Flags (string)
			if (QueryStrings.Any(d => d.Key == "Flags_eq") && !string.IsNullOrEmpty(QueryStrings.FirstOrDefault(d => d.Key == "Flags_eq").Value))
            {
                var keyword = QueryStrings.FirstOrDefault(d => d.Key == "Flags_eq").Value;
                query = query.Where(d=>d.Flags == keyword);
            }
            if (QueryStrings.Any(d => d.Key == "Flags") && !string.IsNullOrEmpty(QueryStrings.FirstOrDefault(d => d.Key == "Flags").Value))
            {
                var keyword = QueryStrings.FirstOrDefault(d => d.Key == "Flags").Value;
                query = query.Where(d=>d.Flags.Contains(keyword));
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

            return query;
        }
		
        public static IQueryable<tbl_LIST_Country> _sortBuilder(IQueryable<tbl_LIST_Country> query, Dictionary<string, string> QueryStrings)
        {
            if (QueryStrings.Any(d => d.Key == "SortBy"))
            {
                var sorts = QueryStrings.FirstOrDefault(d => d.Key == "SortBy").Value.Replace("[", "").Replace("]", "").Split(',');
                
                foreach (var item in sorts)
                    if (!string.IsNullOrEmpty(item))
                    {
                        var ordered = query as IOrderedQueryable<tbl_LIST_Country>;
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
							case "FormalName":
								query = isOrdered ? ordered.ThenBy(o => o.FormalName) : query.OrderBy(o => o.FormalName);
								 break;
							case "FormalName_desc":
                                query = isOrdered ? ordered.ThenByDescending(o => o.FormalName) : query.OrderByDescending(o => o.FormalName);
                                break;
							case "CountryType":
								query = isOrdered ? ordered.ThenBy(o => o.CountryType) : query.OrderBy(o => o.CountryType);
								 break;
							case "CountryType_desc":
                                query = isOrdered ? ordered.ThenByDescending(o => o.CountryType) : query.OrderByDescending(o => o.CountryType);
                                break;
							case "CountrySubType":
								query = isOrdered ? ordered.ThenBy(o => o.CountrySubType) : query.OrderBy(o => o.CountrySubType);
								 break;
							case "CountrySubType_desc":
                                query = isOrdered ? ordered.ThenByDescending(o => o.CountrySubType) : query.OrderByDescending(o => o.CountrySubType);
                                break;
							case "Sovereignty":
								query = isOrdered ? ordered.ThenBy(o => o.Sovereignty) : query.OrderBy(o => o.Sovereignty);
								 break;
							case "Sovereignty_desc":
                                query = isOrdered ? ordered.ThenByDescending(o => o.Sovereignty) : query.OrderByDescending(o => o.Sovereignty);
                                break;
							case "Capital":
								query = isOrdered ? ordered.ThenBy(o => o.Capital) : query.OrderBy(o => o.Capital);
								 break;
							case "Capital_desc":
                                query = isOrdered ? ordered.ThenByDescending(o => o.Capital) : query.OrderByDescending(o => o.Capital);
                                break;
							case "CurrencyCode":
								query = isOrdered ? ordered.ThenBy(o => o.CurrencyCode) : query.OrderBy(o => o.CurrencyCode);
								 break;
							case "CurrencyCode_desc":
                                query = isOrdered ? ordered.ThenByDescending(o => o.CurrencyCode) : query.OrderByDescending(o => o.CurrencyCode);
                                break;
							case "CurrencyName":
								query = isOrdered ? ordered.ThenBy(o => o.CurrencyName) : query.OrderBy(o => o.CurrencyName);
								 break;
							case "CurrencyName_desc":
                                query = isOrdered ? ordered.ThenByDescending(o => o.CurrencyName) : query.OrderByDescending(o => o.CurrencyName);
                                break;
							case "TelephoneCode":
								query = isOrdered ? ordered.ThenBy(o => o.TelephoneCode) : query.OrderBy(o => o.TelephoneCode);
								 break;
							case "TelephoneCode_desc":
                                query = isOrdered ? ordered.ThenByDescending(o => o.TelephoneCode) : query.OrderByDescending(o => o.TelephoneCode);
                                break;
							case "CountryCode3":
								query = isOrdered ? ordered.ThenBy(o => o.CountryCode3) : query.OrderBy(o => o.CountryCode3);
								 break;
							case "CountryCode3_desc":
                                query = isOrdered ? ordered.ThenByDescending(o => o.CountryCode3) : query.OrderByDescending(o => o.CountryCode3);
                                break;
							case "CountryNumber":
								query = isOrdered ? ordered.ThenBy(o => o.CountryNumber) : query.OrderBy(o => o.CountryNumber);
								 break;
							case "CountryNumber_desc":
                                query = isOrdered ? ordered.ThenByDescending(o => o.CountryNumber) : query.OrderByDescending(o => o.CountryNumber);
                                break;
							case "InternetCountryCode":
								query = isOrdered ? ordered.ThenBy(o => o.InternetCountryCode) : query.OrderBy(o => o.InternetCountryCode);
								 break;
							case "InternetCountryCode_desc":
                                query = isOrdered ? ordered.ThenByDescending(o => o.InternetCountryCode) : query.OrderByDescending(o => o.InternetCountryCode);
                                break;
							case "Flags":
								query = isOrdered ? ordered.ThenBy(o => o.Flags) : query.OrderBy(o => o.Flags);
								 break;
							case "Flags_desc":
                                query = isOrdered ? ordered.ThenByDescending(o => o.Flags) : query.OrderByDescending(o => o.Flags);
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

        public static IQueryable<tbl_LIST_Country> _pagingBuilder(IQueryable<tbl_LIST_Country> query, Dictionary<string, string> QueryStrings)
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






