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
    
    
    public partial class tbl_WH_Contacts
    {
        public int Id { get; set; }
        public Nullable<short> IDBranch { get; set; }
        public Nullable<int> IDBusinessPartnerGroup { get; set; }
        public Nullable<int> RefId { get; set; }
        public string Code { get; set; }
        public string Name { get; set; }
        public string CompanyName { get; set; }
        public string TaxCode { get; set; }
        public bool IsStaff { get; set; }
        public bool IsCustomer { get; set; }
        public bool IsVendor { get; set; }
        public bool IsBranch { get; set; }
        public bool IsWholeSale { get; set; }
        public bool IsDistributor { get; set; }
        public bool IsStorer { get; set; }
        public bool IsCarrier { get; set; }
        public bool IsOutlets { get; set; }
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
	public partial class DTO_WH_Contacts
	{
		public int Id { get; set; }
		public Nullable<short> IDBranch { get; set; }
		public Nullable<int> IDBusinessPartnerGroup { get; set; }
		public Nullable<int> RefId { get; set; }
		public string Code { get; set; }
		public string Name { get; set; }
		public string CompanyName { get; set; }
		public string TaxCode { get; set; }
		public bool IsStaff { get; set; }
		public bool IsCustomer { get; set; }
		public bool IsVendor { get; set; }
		public bool IsBranch { get; set; }
		public bool IsWholeSale { get; set; }
		public bool IsDistributor { get; set; }
		public bool IsStorer { get; set; }
		public bool IsCarrier { get; set; }
		public bool IsOutlets { get; set; }
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

    public static partial class BS_WH_Contacts 
    {
        public static dynamic getSearch(AppEntities db, int IDBranch, int StaffID, Dictionary<string, string> QueryStrings)
        {
            return get(db, IDBranch,StaffID, QueryStrings);
        }

		public static IQueryable<DTO_WH_Contacts> get(AppEntities db, int IDBranch, int StaffID, Dictionary<string, string> QueryStrings)
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
            package.Workbook.Properties.Title = "ART-DMS WH_Contacts";
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

		public static DTO_WH_Contacts getAnItem(AppEntities db, int IDBranch, int StaffID, int id)
        {
            var dbResult = db.tbl_WH_Contacts.Find(id);

			//if (dbResult == null || (IDBranch != 0 && dbResult.IDBranch != IDBranch))
			//	return null; 
			//else 
				return toDTO(dbResult);
			
        }
		
		public static DTO_WH_Contacts getAnItemByCode(AppEntities db, int IDBranch, int StaffID, string code)
        {
            var dbResult = db.tbl_WH_Contacts
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
            var dbitem = db.tbl_WH_Contacts.Find(Id);
            
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
					errorLog.logMessage("put_WH_Contacts",e);
                    result = false;
                }
            }
            else
                if (QueryStrings.Any(d => d.Key == "ForceCreate"))
                    result =  post(db, IDBranch, StaffID, item, Username) != null;
                
            return result;
        }

        public static void patchDynamicToDB(dynamic item, tbl_WH_Contacts dbitem, string Username)
        {
            Type type = typeof(tbl_WH_Contacts);
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

        public static void patchDTOtoDBValue( DTO_WH_Contacts item, tbl_WH_Contacts dbitem)
        {
            if (item == null){
                dbitem = null;
                return;
            }
            							
			dbitem.IDBranch = item.IDBranch;							
			dbitem.IDBusinessPartnerGroup = item.IDBusinessPartnerGroup;							
			dbitem.RefId = item.RefId;							
			dbitem.Code = item.Code;							
			dbitem.Name = item.Name;							
			dbitem.CompanyName = item.CompanyName;							
			dbitem.TaxCode = item.TaxCode;							
			dbitem.IsStaff = item.IsStaff;							
			dbitem.IsCustomer = item.IsCustomer;							
			dbitem.IsVendor = item.IsVendor;							
			dbitem.IsBranch = item.IsBranch;							
			dbitem.IsWholeSale = item.IsWholeSale;							
			dbitem.IsDistributor = item.IsDistributor;							
			dbitem.IsStorer = item.IsStorer;							
			dbitem.IsCarrier = item.IsCarrier;							
			dbitem.IsOutlets = item.IsOutlets;							
			dbitem.Sort = item.Sort;							
			dbitem.IsDisabled = item.IsDisabled;							
			dbitem.IsDeleted = item.IsDeleted;        }

		public static DTO_WH_Contacts post(AppEntities db, int IDBranch, int StaffID, dynamic item, string Username)
        {
            tbl_WH_Contacts dbitem = new tbl_WH_Contacts();
            if (item != null)
            {
                patchDynamicToDB(item, dbitem, Username);
                
				dbitem.CreatedBy = Username;
				dbitem.CreatedDate = DateTime.Now;				
                try
                {
					db.tbl_WH_Contacts.Add(dbitem);
                    db.SaveChanges();
				
                }
                catch (DbEntityValidationException e)
                {
					errorLog.logMessage("post_WH_Contacts",e);
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
                Type type = Type.GetType("BaseBusiness.BS_WH_Contacts, ClassLibrary");
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
                        var target = new tbl_WH_Contacts();
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
                    
                    tbl_WH_Contacts dbitem = new tbl_WH_Contacts();
                    if (it.Id == null || string.IsNullOrEmpty(it.Id.Value) || it.Id == "0")
                    {
                        dbitem = new tbl_WH_Contacts();
                        dbitem.CreatedBy = Username;
				        dbitem.CreatedDate = DateTime.Now;
                                            }
                    else
                    {
                        dbitem = db.tbl_WH_Contacts.Find((int)it.Id);
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
                        
                        if (dbitem.Id == 0) db.tbl_WH_Contacts.Add(dbitem);
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
                    errorLog.logMessage("post_WH_Contacts",e);
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

            var dbitems = db.tbl_WH_Contacts.Where(d => IDs.Contains(d.Id));
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
                    BS_Version.update_Version(db, IDBranch, "DTO_WH_Contacts", updateDate, Username);
                }
			
            }
            catch (DbEntityValidationException e)
            {
				errorLog.logMessage("delete_WH_Contacts",e);
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

			
            var dbitems = db.tbl_WH_Contacts.Where(d => IDs.Contains(d.Id));
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
                    BS_Version.update_Version(db, IDBranch, "DTO_WH_Contacts", updateDate, Username);
                }
			
            }
            catch (DbEntityValidationException e)
            {
				errorLog.logMessage("disable_WH_Contacts",e);
                result = false;
            }
            
            return result;
        }

		
		//---//
		public static bool check_Exists(AppEntities db, int id)
		{
             
            return db.tbl_WH_Contacts.Any(e => e.Id == id && e.IsDeleted == false);
            
		}
		
		public static bool check_Exists(AppEntities db, string Code)
		{
             
            return db.tbl_WH_Contacts.Any(e => e.Code == Code && e.IsDeleted == false);
            
		}
		
		//---//
		public static IQueryable<DTO_WH_Contacts> toDTO(IQueryable<tbl_WH_Contacts> query)
        {
			return query
			.Select(s => new DTO_WH_Contacts(){							
				Id = s.Id,							
				IDBranch = s.IDBranch,							
				IDBusinessPartnerGroup = s.IDBusinessPartnerGroup,							
				RefId = s.RefId,							
				Code = s.Code,							
				Name = s.Name,							
				CompanyName = s.CompanyName,							
				TaxCode = s.TaxCode,							
				IsStaff = s.IsStaff,							
				IsCustomer = s.IsCustomer,							
				IsVendor = s.IsVendor,							
				IsBranch = s.IsBranch,							
				IsWholeSale = s.IsWholeSale,							
				IsDistributor = s.IsDistributor,							
				IsStorer = s.IsStorer,							
				IsCarrier = s.IsCarrier,							
				IsOutlets = s.IsOutlets,							
				Sort = s.Sort,							
				IsDisabled = s.IsDisabled,							
				IsDeleted = s.IsDeleted,							
				CreatedBy = s.CreatedBy,							
				CreatedDate = s.CreatedDate,							
				ModifiedBy = s.ModifiedBy,							
				ModifiedDate = s.ModifiedDate,					
			});//.OrderBy(o => o.Sort == null).ThenBy(u => u.Sort);
                              
        }

		public static DTO_WH_Contacts toDTO(tbl_WH_Contacts dbResult)
        {
			if (dbResult != null)
			{
				return new DTO_WH_Contacts()
				{							
					Id = dbResult.Id,							
					IDBranch = dbResult.IDBranch,							
					IDBusinessPartnerGroup = dbResult.IDBusinessPartnerGroup,							
					RefId = dbResult.RefId,							
					Code = dbResult.Code,							
					Name = dbResult.Name,							
					CompanyName = dbResult.CompanyName,							
					TaxCode = dbResult.TaxCode,							
					IsStaff = dbResult.IsStaff,							
					IsCustomer = dbResult.IsCustomer,							
					IsVendor = dbResult.IsVendor,							
					IsBranch = dbResult.IsBranch,							
					IsWholeSale = dbResult.IsWholeSale,							
					IsDistributor = dbResult.IsDistributor,							
					IsStorer = dbResult.IsStorer,							
					IsCarrier = dbResult.IsCarrier,							
					IsOutlets = dbResult.IsOutlets,							
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

		public static IQueryable<tbl_WH_Contacts> _queryBuilder(AppEntities db, int IDBranch, int StaffID, Dictionary<string, string> QueryStrings)
        {
            
			IQueryable<tbl_WH_Contacts> query = db.tbl_WH_Contacts.AsNoTracking();//.Where(d => d.IsDeleted == false);
			

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

			//Query IDBranch (Nullable<short>)

			//Query IDBusinessPartnerGroup (Nullable<int>)
			if (QueryStrings.Any(d => d.Key == "IDBusinessPartnerGroup"))
            {
                var IDList = QueryStrings.FirstOrDefault(d => d.Key == "IDBusinessPartnerGroup").Value.Replace("[", "").Replace("]", "").Split(',');
                List<int?> IDs = new List<int?>();
                foreach (var item in IDList)
                    if (int.TryParse(item, out int i))
                        IDs.Add(i);
					else if (item == "null")
						IDs.Add(null);
                if (IDs.Count > 0)
                    query = query.Where(d => IDs.Contains(d.IDBusinessPartnerGroup));
////                    query = query.Where(d => IDs.Contains(d.IDBusinessPartnerGroup));
//                    
            }

			//Query RefId (Nullable<int>)
			if (QueryStrings.Any(d => d.Key == "RefIdFrom") && QueryStrings.Any(d => d.Key == "RefIdTo"))
                if (int.TryParse(QueryStrings.FirstOrDefault(d => d.Key == "RefIdFrom").Value, out int fromVal) && int.TryParse(QueryStrings.FirstOrDefault(d => d.Key == "RefIdTo").Value, out int toVal))
                    query = query.Where(d => fromVal <= d.RefId && d.RefId <= toVal);

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
            

			//Query CompanyName (string)
			if (QueryStrings.Any(d => d.Key == "CompanyName_eq") && !string.IsNullOrEmpty(QueryStrings.FirstOrDefault(d => d.Key == "CompanyName_eq").Value))
            {
                var keyword = QueryStrings.FirstOrDefault(d => d.Key == "CompanyName_eq").Value;
                query = query.Where(d=>d.CompanyName == keyword);
            }
            if (QueryStrings.Any(d => d.Key == "CompanyName") && !string.IsNullOrEmpty(QueryStrings.FirstOrDefault(d => d.Key == "CompanyName").Value))
            {
                var keyword = QueryStrings.FirstOrDefault(d => d.Key == "CompanyName").Value;
                query = query.Where(d=>d.CompanyName.Contains(keyword));
            }
            

			//Query TaxCode (string)
			if (QueryStrings.Any(d => d.Key == "TaxCode_eq") && !string.IsNullOrEmpty(QueryStrings.FirstOrDefault(d => d.Key == "TaxCode_eq").Value))
            {
                var keyword = QueryStrings.FirstOrDefault(d => d.Key == "TaxCode_eq").Value;
                query = query.Where(d=>d.TaxCode == keyword);
            }
            if (QueryStrings.Any(d => d.Key == "TaxCode") && !string.IsNullOrEmpty(QueryStrings.FirstOrDefault(d => d.Key == "TaxCode").Value))
            {
                var keyword = QueryStrings.FirstOrDefault(d => d.Key == "TaxCode").Value;
                query = query.Where(d=>d.TaxCode.Contains(keyword));
            }
            

			//Query IsStaff (bool)
			if (QueryStrings.Any(d => d.Key == "IsStaff"))
            {
                var qValue = QueryStrings.FirstOrDefault(d => d.Key == "IsStaff").Value;
                if (bool.TryParse(qValue, out bool qBoolValue))
                    query = query.Where(d => qBoolValue == d.IsStaff);
            }

			//Query IsCustomer (bool)
			if (QueryStrings.Any(d => d.Key == "IsCustomer"))
            {
                var qValue = QueryStrings.FirstOrDefault(d => d.Key == "IsCustomer").Value;
                if (bool.TryParse(qValue, out bool qBoolValue))
                    query = query.Where(d => qBoolValue == d.IsCustomer);
            }

			//Query IsVendor (bool)
			if (QueryStrings.Any(d => d.Key == "IsVendor"))
            {
                var qValue = QueryStrings.FirstOrDefault(d => d.Key == "IsVendor").Value;
                if (bool.TryParse(qValue, out bool qBoolValue))
                    query = query.Where(d => qBoolValue == d.IsVendor);
            }

			//Query IsBranch (bool)
			if (QueryStrings.Any(d => d.Key == "IsBranch"))
            {
                var qValue = QueryStrings.FirstOrDefault(d => d.Key == "IsBranch").Value;
                if (bool.TryParse(qValue, out bool qBoolValue))
                    query = query.Where(d => qBoolValue == d.IsBranch);
            }

			//Query IsWholeSale (bool)
			if (QueryStrings.Any(d => d.Key == "IsWholeSale"))
            {
                var qValue = QueryStrings.FirstOrDefault(d => d.Key == "IsWholeSale").Value;
                if (bool.TryParse(qValue, out bool qBoolValue))
                    query = query.Where(d => qBoolValue == d.IsWholeSale);
            }

			//Query IsDistributor (bool)
			if (QueryStrings.Any(d => d.Key == "IsDistributor"))
            {
                var qValue = QueryStrings.FirstOrDefault(d => d.Key == "IsDistributor").Value;
                if (bool.TryParse(qValue, out bool qBoolValue))
                    query = query.Where(d => qBoolValue == d.IsDistributor);
            }

			//Query IsStorer (bool)
			if (QueryStrings.Any(d => d.Key == "IsStorer"))
            {
                var qValue = QueryStrings.FirstOrDefault(d => d.Key == "IsStorer").Value;
                if (bool.TryParse(qValue, out bool qBoolValue))
                    query = query.Where(d => qBoolValue == d.IsStorer);
            }

			//Query IsCarrier (bool)
			if (QueryStrings.Any(d => d.Key == "IsCarrier"))
            {
                var qValue = QueryStrings.FirstOrDefault(d => d.Key == "IsCarrier").Value;
                if (bool.TryParse(qValue, out bool qBoolValue))
                    query = query.Where(d => qBoolValue == d.IsCarrier);
            }

			//Query IsOutlets (bool)
			if (QueryStrings.Any(d => d.Key == "IsOutlets"))
            {
                var qValue = QueryStrings.FirstOrDefault(d => d.Key == "IsOutlets").Value;
                if (bool.TryParse(qValue, out bool qBoolValue))
                    query = query.Where(d => qBoolValue == d.IsOutlets);
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
		
        public static IQueryable<tbl_WH_Contacts> _sortBuilder(IQueryable<tbl_WH_Contacts> query, Dictionary<string, string> QueryStrings)
        {
            if (QueryStrings.Any(d => d.Key == "SortBy"))
            {
                var sorts = QueryStrings.FirstOrDefault(d => d.Key == "SortBy").Value.Replace("[", "").Replace("]", "").Split(',');
                
                foreach (var item in sorts)
                    if (!string.IsNullOrEmpty(item))
                    {
                        var ordered = query as IOrderedQueryable<tbl_WH_Contacts>;
                        bool isOrdered = ordered.ToString().IndexOf("ORDER BY") !=-1;

                        switch (item)
                        {
							case "Id":
								query = isOrdered ? ordered.ThenBy(o => o.Id) : query.OrderBy(o => o.Id);
								 break;
							case "Id_desc":
                                query = isOrdered ? ordered.ThenByDescending(o => o.Id) : query.OrderByDescending(o => o.Id);
                                break;
							case "IDBranch":
								query = isOrdered ? ordered.ThenBy(o => o.IDBranch) : query.OrderBy(o => o.IDBranch);
								 break;
							case "IDBranch_desc":
                                query = isOrdered ? ordered.ThenByDescending(o => o.IDBranch) : query.OrderByDescending(o => o.IDBranch);
                                break;
							case "IDBusinessPartnerGroup":
								query = isOrdered ? ordered.ThenBy(o => o.IDBusinessPartnerGroup) : query.OrderBy(o => o.IDBusinessPartnerGroup);
								 break;
							case "IDBusinessPartnerGroup_desc":
                                query = isOrdered ? ordered.ThenByDescending(o => o.IDBusinessPartnerGroup) : query.OrderByDescending(o => o.IDBusinessPartnerGroup);
                                break;
							case "RefId":
								query = isOrdered ? ordered.ThenBy(o => o.RefId) : query.OrderBy(o => o.RefId);
								 break;
							case "RefId_desc":
                                query = isOrdered ? ordered.ThenByDescending(o => o.RefId) : query.OrderByDescending(o => o.RefId);
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
							case "CompanyName":
								query = isOrdered ? ordered.ThenBy(o => o.CompanyName) : query.OrderBy(o => o.CompanyName);
								 break;
							case "CompanyName_desc":
                                query = isOrdered ? ordered.ThenByDescending(o => o.CompanyName) : query.OrderByDescending(o => o.CompanyName);
                                break;
							case "TaxCode":
								query = isOrdered ? ordered.ThenBy(o => o.TaxCode) : query.OrderBy(o => o.TaxCode);
								 break;
							case "TaxCode_desc":
                                query = isOrdered ? ordered.ThenByDescending(o => o.TaxCode) : query.OrderByDescending(o => o.TaxCode);
                                break;
							case "IsStaff":
								query = isOrdered ? ordered.ThenBy(o => o.IsStaff) : query.OrderBy(o => o.IsStaff);
								 break;
							case "IsStaff_desc":
                                query = isOrdered ? ordered.ThenByDescending(o => o.IsStaff) : query.OrderByDescending(o => o.IsStaff);
                                break;
							case "IsCustomer":
								query = isOrdered ? ordered.ThenBy(o => o.IsCustomer) : query.OrderBy(o => o.IsCustomer);
								 break;
							case "IsCustomer_desc":
                                query = isOrdered ? ordered.ThenByDescending(o => o.IsCustomer) : query.OrderByDescending(o => o.IsCustomer);
                                break;
							case "IsVendor":
								query = isOrdered ? ordered.ThenBy(o => o.IsVendor) : query.OrderBy(o => o.IsVendor);
								 break;
							case "IsVendor_desc":
                                query = isOrdered ? ordered.ThenByDescending(o => o.IsVendor) : query.OrderByDescending(o => o.IsVendor);
                                break;
							case "IsBranch":
								query = isOrdered ? ordered.ThenBy(o => o.IsBranch) : query.OrderBy(o => o.IsBranch);
								 break;
							case "IsBranch_desc":
                                query = isOrdered ? ordered.ThenByDescending(o => o.IsBranch) : query.OrderByDescending(o => o.IsBranch);
                                break;
							case "IsWholeSale":
								query = isOrdered ? ordered.ThenBy(o => o.IsWholeSale) : query.OrderBy(o => o.IsWholeSale);
								 break;
							case "IsWholeSale_desc":
                                query = isOrdered ? ordered.ThenByDescending(o => o.IsWholeSale) : query.OrderByDescending(o => o.IsWholeSale);
                                break;
							case "IsDistributor":
								query = isOrdered ? ordered.ThenBy(o => o.IsDistributor) : query.OrderBy(o => o.IsDistributor);
								 break;
							case "IsDistributor_desc":
                                query = isOrdered ? ordered.ThenByDescending(o => o.IsDistributor) : query.OrderByDescending(o => o.IsDistributor);
                                break;
							case "IsStorer":
								query = isOrdered ? ordered.ThenBy(o => o.IsStorer) : query.OrderBy(o => o.IsStorer);
								 break;
							case "IsStorer_desc":
                                query = isOrdered ? ordered.ThenByDescending(o => o.IsStorer) : query.OrderByDescending(o => o.IsStorer);
                                break;
							case "IsCarrier":
								query = isOrdered ? ordered.ThenBy(o => o.IsCarrier) : query.OrderBy(o => o.IsCarrier);
								 break;
							case "IsCarrier_desc":
                                query = isOrdered ? ordered.ThenByDescending(o => o.IsCarrier) : query.OrderByDescending(o => o.IsCarrier);
                                break;
							case "IsOutlets":
								query = isOrdered ? ordered.ThenBy(o => o.IsOutlets) : query.OrderBy(o => o.IsOutlets);
								 break;
							case "IsOutlets_desc":
                                query = isOrdered ? ordered.ThenByDescending(o => o.IsOutlets) : query.OrderByDescending(o => o.IsOutlets);
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

        public static IQueryable<tbl_WH_Contacts> _pagingBuilder(IQueryable<tbl_WH_Contacts> query, Dictionary<string, string> QueryStrings)
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






