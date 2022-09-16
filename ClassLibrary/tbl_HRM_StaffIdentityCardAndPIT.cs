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
    
    
    public partial class tbl_HRM_StaffIdentityCardAndPIT
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
        public string IdentityCardNumber { get; set; }
        public Nullable<System.DateTime> DateOfIssueID { get; set; }
        public string PlaceOfIssueID { get; set; }
        public Nullable<System.DateTime> DateOfExpiryID { get; set; }
        public string IdentityCardNumber1 { get; set; }
        public Nullable<System.DateTime> DateOfIssueId1 { get; set; }
        public Nullable<System.DateTime> DateOfExpiry1 { get; set; }
        public string TaxIdentificationNumber { get; set; }
        public Nullable<System.DateTime> RegistrationDateOfTaxId { get; set; }
        public string RegistrationPlaceOfTaxId { get; set; }
        public string PassportNumber { get; set; }
        public Nullable<System.DateTime> DateOfIssuePassport { get; set; }
        public Nullable<System.DateTime> DateOfExpiryPassport { get; set; }
        public string PlaceOfIssuePassport { get; set; }
        public Nullable<int> IDTypeOfPassport { get; set; }
        public Nullable<int> IDCountryOfIssuePassport { get; set; }
        public string VisaNumber { get; set; }
        public Nullable<System.DateTime> DateOfIssueVisa { get; set; }
        public Nullable<System.DateTime> DateOfExpiryVisa { get; set; }
        public Nullable<int> IDCountryOfIssueVisa { get; set; }
        public bool IsDeleted { get; set; }
        //List 0:1
        public virtual tbl_HRM_Staff tbl_HRM_Staff { get; set; }
        //List 0:1
        public virtual tbl_LIST_Country tbl_LIST_Country { get; set; }
        //List 0:1
        public virtual tbl_LIST_Country tbl_LIST_Country1 { get; set; }
        //List 0:1
        public virtual tbl_LIST_General tbl_LIST_General { get; set; }
    }
}


namespace DTOModel
{
	using System;
	public partial class DTO_HRM_StaffIdentityCardAndPIT
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
		public string IdentityCardNumber { get; set; }
		public Nullable<System.DateTime> DateOfIssueID { get; set; }
		public string PlaceOfIssueID { get; set; }
		public Nullable<System.DateTime> DateOfExpiryID { get; set; }
		public string IdentityCardNumber1 { get; set; }
		public Nullable<System.DateTime> DateOfIssueId1 { get; set; }
		public Nullable<System.DateTime> DateOfExpiry1 { get; set; }
		public string TaxIdentificationNumber { get; set; }
		public Nullable<System.DateTime> RegistrationDateOfTaxId { get; set; }
		public string RegistrationPlaceOfTaxId { get; set; }
		public string PassportNumber { get; set; }
		public Nullable<System.DateTime> DateOfIssuePassport { get; set; }
		public Nullable<System.DateTime> DateOfExpiryPassport { get; set; }
		public string PlaceOfIssuePassport { get; set; }
		public Nullable<int> IDTypeOfPassport { get; set; }
		public Nullable<int> IDCountryOfIssuePassport { get; set; }
		public string VisaNumber { get; set; }
		public Nullable<System.DateTime> DateOfIssueVisa { get; set; }
		public Nullable<System.DateTime> DateOfExpiryVisa { get; set; }
		public Nullable<int> IDCountryOfIssueVisa { get; set; }
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

    public static partial class BS_HRM_StaffIdentityCardAndPIT 
    {
        public static dynamic getSearch(AppEntities db, int IDBranch, int StaffID, Dictionary<string, string> QueryStrings)
        {
            return get(db, IDBranch,StaffID, QueryStrings);
        }

		public static IQueryable<DTO_HRM_StaffIdentityCardAndPIT> get(AppEntities db, int IDBranch, int StaffID, Dictionary<string, string> QueryStrings)
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
            package.Workbook.Properties.Title = "ART-DMS HRM_StaffIdentityCardAndPIT";
            package.Workbook.Properties.Author = "hung.vu@codeart.vn";
            package.Workbook.Properties.Application = "ART-DMS";
            package.Workbook.Properties.Company = "A.R.T Distribution";

            ExcelWorkbook workBook = package.Workbook;
            if (workBook != null)
            {
                var ws = workBook.Worksheets.FirstOrDefault();
                var data = _queryBuilder(db, IDBranch, StaffID, QueryStrings).ToList();

                //var HRM_StaffList = BS_HRM_Staff.get(db,IDBranch, StaffID,QueryStrings).Select(s => new ItemModel { Id = s.Id, Name = s.Name });
                //var LIST_CountryList = BS_LIST_Country.get(db,IDBranch, StaffID,QueryStrings).Select(s => new ItemModel { Id = s.Id, Name = s.Name });
                //var LIST_Country1List = BS_LIST_Country.get(db,IDBranch, StaffID,QueryStrings).Select(s => new ItemModel { Id = s.Id, Name = s.Name });
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

		public static DTO_HRM_StaffIdentityCardAndPIT getAnItem(AppEntities db, int IDBranch, int StaffID, int id)
        {
            var dbResult = db.tbl_HRM_StaffIdentityCardAndPIT.Find(id);

			return toDTO(dbResult);
			
        }
		
		public static DTO_HRM_StaffIdentityCardAndPIT getAnItemByCode(AppEntities db, int IDBranch, int StaffID, string code)
        {
            var dbResult = db.tbl_HRM_StaffIdentityCardAndPIT
			.FirstOrDefault(d => d.IsDeleted == false && d.Code == code );

			return toDTO(dbResult);
			
        }

		public static bool put(AppEntities db, int IDBranch, int StaffID, int Id, dynamic item, string Username, Dictionary<string, string> QueryStrings)
        {
            bool result = false;
            var dbitem = db.tbl_HRM_StaffIdentityCardAndPIT.Find(Id);
            
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
					errorLog.logMessage("put_HRM_StaffIdentityCardAndPIT",e);
                    result = false;
                }
            }
            else
                if (QueryStrings.Any(d => d.Key == "ForceCreate"))
                    result =  post(db, IDBranch, StaffID, item, Username) != null;
                
            return result;
        }

        public static void patchDynamicToDB(dynamic item, tbl_HRM_StaffIdentityCardAndPIT dbitem, string Username)
        {
            Type type = typeof(tbl_HRM_StaffIdentityCardAndPIT);
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

        public static void patchDTOtoDBValue( DTO_HRM_StaffIdentityCardAndPIT item, tbl_HRM_StaffIdentityCardAndPIT dbitem)
        {
            if (item == null){
                dbitem = null;
                return;
            }
            							
			dbitem.Code = item.Code;							
			dbitem.Name = item.Name;							
			dbitem.Remark = item.Remark;							
			dbitem.Sort = item.Sort;							
			dbitem.IdentityCardNumber = item.IdentityCardNumber;							
			dbitem.DateOfIssueID = item.DateOfIssueID;							
			dbitem.PlaceOfIssueID = item.PlaceOfIssueID;							
			dbitem.DateOfExpiryID = item.DateOfExpiryID;							
			dbitem.IdentityCardNumber1 = item.IdentityCardNumber1;							
			dbitem.DateOfIssueId1 = item.DateOfIssueId1;							
			dbitem.DateOfExpiry1 = item.DateOfExpiry1;							
			dbitem.TaxIdentificationNumber = item.TaxIdentificationNumber;							
			dbitem.RegistrationDateOfTaxId = item.RegistrationDateOfTaxId;							
			dbitem.RegistrationPlaceOfTaxId = item.RegistrationPlaceOfTaxId;							
			dbitem.PassportNumber = item.PassportNumber;							
			dbitem.DateOfIssuePassport = item.DateOfIssuePassport;							
			dbitem.DateOfExpiryPassport = item.DateOfExpiryPassport;							
			dbitem.PlaceOfIssuePassport = item.PlaceOfIssuePassport;							
			dbitem.IDTypeOfPassport = item.IDTypeOfPassport;							
			dbitem.IDCountryOfIssuePassport = item.IDCountryOfIssuePassport;							
			dbitem.VisaNumber = item.VisaNumber;							
			dbitem.DateOfIssueVisa = item.DateOfIssueVisa;							
			dbitem.DateOfExpiryVisa = item.DateOfExpiryVisa;							
			dbitem.IDCountryOfIssueVisa = item.IDCountryOfIssueVisa;							
			dbitem.IsDeleted = item.IsDeleted;        }

		public static DTO_HRM_StaffIdentityCardAndPIT post(AppEntities db, int IDBranch, int StaffID, dynamic item, string Username)
        {
            tbl_HRM_StaffIdentityCardAndPIT dbitem = new tbl_HRM_StaffIdentityCardAndPIT();
            if (item != null)
            {
                patchDynamicToDB(item, dbitem, Username);
                
				dbitem.CreatedBy = Username;
				dbitem.CreatedDate = DateTime.Now;				
                try
                {
					db.tbl_HRM_StaffIdentityCardAndPIT.Add(dbitem);
                    db.SaveChanges();
				
                }
                catch (DbEntityValidationException e)
                {
					errorLog.logMessage("post_HRM_StaffIdentityCardAndPIT",e);
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
                Type type = Type.GetType("BaseBusiness.BS_HRM_StaffIdentityCardAndPIT, ClassLibrary");
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
                        var target = new tbl_HRM_StaffIdentityCardAndPIT();
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
                    
                    tbl_HRM_StaffIdentityCardAndPIT dbitem = new tbl_HRM_StaffIdentityCardAndPIT();
                    if (it.Id == null || string.IsNullOrEmpty(it.Id.Value) || it.Id == "0")
                    {
                        dbitem = new tbl_HRM_StaffIdentityCardAndPIT();
                        dbitem.CreatedBy = Username;
				        dbitem.CreatedDate = DateTime.Now;
                                            }
                    else
                    {
                        dbitem = db.tbl_HRM_StaffIdentityCardAndPIT.Find((int)it.Id);
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
                        
                        if (dbitem.Id == 0) db.tbl_HRM_StaffIdentityCardAndPIT.Add(dbitem);
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
                    errorLog.logMessage("post_HRM_StaffIdentityCardAndPIT",e);
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

            var dbitems = db.tbl_HRM_StaffIdentityCardAndPIT.Where(d => IDs.Contains(d.Id));
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
			
                BS_Version.update_Version(db, null, "DTO_HRM_StaffIdentityCardAndPIT", updateDate, Username);
			
            }
            catch (DbEntityValidationException e)
            {
				errorLog.logMessage("delete_HRM_StaffIdentityCardAndPIT",e);
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
             
            return db.tbl_HRM_StaffIdentityCardAndPIT.Any(e => e.Id == id && e.IsDeleted == false);
            
		}
		
		public static bool check_Exists(AppEntities db, string Code)
		{
             
            return db.tbl_HRM_StaffIdentityCardAndPIT.Any(e => e.Code == Code && e.IsDeleted == false);
            
		}
		
		//---//
		public static IQueryable<DTO_HRM_StaffIdentityCardAndPIT> toDTO(IQueryable<tbl_HRM_StaffIdentityCardAndPIT> query)
        {
			return query
			.Select(s => new DTO_HRM_StaffIdentityCardAndPIT(){							
				Id = s.Id,							
				Code = s.Code,							
				Name = s.Name,							
				Remark = s.Remark,							
				Sort = s.Sort,							
				CreatedBy = s.CreatedBy,							
				ModifiedBy = s.ModifiedBy,							
				CreatedDate = s.CreatedDate,							
				ModifiedDate = s.ModifiedDate,							
				IdentityCardNumber = s.IdentityCardNumber,							
				DateOfIssueID = s.DateOfIssueID,							
				PlaceOfIssueID = s.PlaceOfIssueID,							
				DateOfExpiryID = s.DateOfExpiryID,							
				IdentityCardNumber1 = s.IdentityCardNumber1,							
				DateOfIssueId1 = s.DateOfIssueId1,							
				DateOfExpiry1 = s.DateOfExpiry1,							
				TaxIdentificationNumber = s.TaxIdentificationNumber,							
				RegistrationDateOfTaxId = s.RegistrationDateOfTaxId,							
				RegistrationPlaceOfTaxId = s.RegistrationPlaceOfTaxId,							
				PassportNumber = s.PassportNumber,							
				DateOfIssuePassport = s.DateOfIssuePassport,							
				DateOfExpiryPassport = s.DateOfExpiryPassport,							
				PlaceOfIssuePassport = s.PlaceOfIssuePassport,							
				IDTypeOfPassport = s.IDTypeOfPassport,							
				IDCountryOfIssuePassport = s.IDCountryOfIssuePassport,							
				VisaNumber = s.VisaNumber,							
				DateOfIssueVisa = s.DateOfIssueVisa,							
				DateOfExpiryVisa = s.DateOfExpiryVisa,							
				IDCountryOfIssueVisa = s.IDCountryOfIssueVisa,							
				IsDeleted = s.IsDeleted,					
			});//.OrderBy(o => o.Sort == null).ThenBy(u => u.Sort);
                              
        }

		public static DTO_HRM_StaffIdentityCardAndPIT toDTO(tbl_HRM_StaffIdentityCardAndPIT dbResult)
        {
			if (dbResult != null)
			{
				return new DTO_HRM_StaffIdentityCardAndPIT()
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
					IdentityCardNumber = dbResult.IdentityCardNumber,							
					DateOfIssueID = dbResult.DateOfIssueID,							
					PlaceOfIssueID = dbResult.PlaceOfIssueID,							
					DateOfExpiryID = dbResult.DateOfExpiryID,							
					IdentityCardNumber1 = dbResult.IdentityCardNumber1,							
					DateOfIssueId1 = dbResult.DateOfIssueId1,							
					DateOfExpiry1 = dbResult.DateOfExpiry1,							
					TaxIdentificationNumber = dbResult.TaxIdentificationNumber,							
					RegistrationDateOfTaxId = dbResult.RegistrationDateOfTaxId,							
					RegistrationPlaceOfTaxId = dbResult.RegistrationPlaceOfTaxId,							
					PassportNumber = dbResult.PassportNumber,							
					DateOfIssuePassport = dbResult.DateOfIssuePassport,							
					DateOfExpiryPassport = dbResult.DateOfExpiryPassport,							
					PlaceOfIssuePassport = dbResult.PlaceOfIssuePassport,							
					IDTypeOfPassport = dbResult.IDTypeOfPassport,							
					IDCountryOfIssuePassport = dbResult.IDCountryOfIssuePassport,							
					VisaNumber = dbResult.VisaNumber,							
					DateOfIssueVisa = dbResult.DateOfIssueVisa,							
					DateOfExpiryVisa = dbResult.DateOfExpiryVisa,							
					IDCountryOfIssueVisa = dbResult.IDCountryOfIssueVisa,							
					IsDeleted = dbResult.IsDeleted,
				};
			}
			else
				return null; 
        }

		public static IQueryable<tbl_HRM_StaffIdentityCardAndPIT> _queryBuilder(AppEntities db, int IDBranch, int StaffID, Dictionary<string, string> QueryStrings)
        {
            
			IQueryable<tbl_HRM_StaffIdentityCardAndPIT> query = db.tbl_HRM_StaffIdentityCardAndPIT.AsNoTracking();//.Where(d => d.IsDeleted == false );
			

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
            

			//Query DateOfIssueID (Nullable<System.DateTime>)
			if (QueryStrings.Any(d => d.Key == "DateOfIssueIDFrom") && QueryStrings.Any(d => d.Key == "DateOfIssueIDTo"))
                if (DateTime.TryParse(QueryStrings.FirstOrDefault(d => d.Key == "DateOfIssueIDFrom").Value, out DateTime fromDate) && DateTime.TryParse(QueryStrings.FirstOrDefault(d => d.Key == "DateOfIssueIDTo").Value, out DateTime toDate))
                    query = query.Where(d => fromDate <= d.DateOfIssueID && d.DateOfIssueID <= toDate);

            if (QueryStrings.Any(d => d.Key == "DateOfIssueID"))
                if (DateTime.TryParse(QueryStrings.FirstOrDefault(d => d.Key == "DateOfIssueID").Value, out DateTime val))
                    query = query.Where(d => d.DateOfIssueID != null && DbFunctions.TruncateTime(val) == DbFunctions.TruncateTime(d.DateOfIssueID));


			//Query PlaceOfIssueID (string)
			if (QueryStrings.Any(d => d.Key == "PlaceOfIssueID_eq") && !string.IsNullOrEmpty(QueryStrings.FirstOrDefault(d => d.Key == "PlaceOfIssueID_eq").Value))
            {
                var keyword = QueryStrings.FirstOrDefault(d => d.Key == "PlaceOfIssueID_eq").Value;
                query = query.Where(d=>d.PlaceOfIssueID == keyword);
            }
            if (QueryStrings.Any(d => d.Key == "PlaceOfIssueID") && !string.IsNullOrEmpty(QueryStrings.FirstOrDefault(d => d.Key == "PlaceOfIssueID").Value))
            {
                var keyword = QueryStrings.FirstOrDefault(d => d.Key == "PlaceOfIssueID").Value;
                query = query.Where(d=>d.PlaceOfIssueID.Contains(keyword));
            }
            

			//Query DateOfExpiryID (Nullable<System.DateTime>)
			if (QueryStrings.Any(d => d.Key == "DateOfExpiryIDFrom") && QueryStrings.Any(d => d.Key == "DateOfExpiryIDTo"))
                if (DateTime.TryParse(QueryStrings.FirstOrDefault(d => d.Key == "DateOfExpiryIDFrom").Value, out DateTime fromDate) && DateTime.TryParse(QueryStrings.FirstOrDefault(d => d.Key == "DateOfExpiryIDTo").Value, out DateTime toDate))
                    query = query.Where(d => fromDate <= d.DateOfExpiryID && d.DateOfExpiryID <= toDate);

            if (QueryStrings.Any(d => d.Key == "DateOfExpiryID"))
                if (DateTime.TryParse(QueryStrings.FirstOrDefault(d => d.Key == "DateOfExpiryID").Value, out DateTime val))
                    query = query.Where(d => d.DateOfExpiryID != null && DbFunctions.TruncateTime(val) == DbFunctions.TruncateTime(d.DateOfExpiryID));


			//Query IdentityCardNumber1 (string)
			if (QueryStrings.Any(d => d.Key == "IdentityCardNumber1_eq") && !string.IsNullOrEmpty(QueryStrings.FirstOrDefault(d => d.Key == "IdentityCardNumber1_eq").Value))
            {
                var keyword = QueryStrings.FirstOrDefault(d => d.Key == "IdentityCardNumber1_eq").Value;
                query = query.Where(d=>d.IdentityCardNumber1 == keyword);
            }
            if (QueryStrings.Any(d => d.Key == "IdentityCardNumber1") && !string.IsNullOrEmpty(QueryStrings.FirstOrDefault(d => d.Key == "IdentityCardNumber1").Value))
            {
                var keyword = QueryStrings.FirstOrDefault(d => d.Key == "IdentityCardNumber1").Value;
                query = query.Where(d=>d.IdentityCardNumber1.Contains(keyword));
            }
            

			//Query DateOfIssueId1 (Nullable<System.DateTime>)
			if (QueryStrings.Any(d => d.Key == "DateOfIssueId1From") && QueryStrings.Any(d => d.Key == "DateOfIssueId1To"))
                if (DateTime.TryParse(QueryStrings.FirstOrDefault(d => d.Key == "DateOfIssueId1From").Value, out DateTime fromDate) && DateTime.TryParse(QueryStrings.FirstOrDefault(d => d.Key == "DateOfIssueId1To").Value, out DateTime toDate))
                    query = query.Where(d => fromDate <= d.DateOfIssueId1 && d.DateOfIssueId1 <= toDate);

            if (QueryStrings.Any(d => d.Key == "DateOfIssueId1"))
                if (DateTime.TryParse(QueryStrings.FirstOrDefault(d => d.Key == "DateOfIssueId1").Value, out DateTime val))
                    query = query.Where(d => d.DateOfIssueId1 != null && DbFunctions.TruncateTime(val) == DbFunctions.TruncateTime(d.DateOfIssueId1));


			//Query DateOfExpiry1 (Nullable<System.DateTime>)
			if (QueryStrings.Any(d => d.Key == "DateOfExpiry1From") && QueryStrings.Any(d => d.Key == "DateOfExpiry1To"))
                if (DateTime.TryParse(QueryStrings.FirstOrDefault(d => d.Key == "DateOfExpiry1From").Value, out DateTime fromDate) && DateTime.TryParse(QueryStrings.FirstOrDefault(d => d.Key == "DateOfExpiry1To").Value, out DateTime toDate))
                    query = query.Where(d => fromDate <= d.DateOfExpiry1 && d.DateOfExpiry1 <= toDate);

            if (QueryStrings.Any(d => d.Key == "DateOfExpiry1"))
                if (DateTime.TryParse(QueryStrings.FirstOrDefault(d => d.Key == "DateOfExpiry1").Value, out DateTime val))
                    query = query.Where(d => d.DateOfExpiry1 != null && DbFunctions.TruncateTime(val) == DbFunctions.TruncateTime(d.DateOfExpiry1));


			//Query TaxIdentificationNumber (string)
			if (QueryStrings.Any(d => d.Key == "TaxIdentificationNumber_eq") && !string.IsNullOrEmpty(QueryStrings.FirstOrDefault(d => d.Key == "TaxIdentificationNumber_eq").Value))
            {
                var keyword = QueryStrings.FirstOrDefault(d => d.Key == "TaxIdentificationNumber_eq").Value;
                query = query.Where(d=>d.TaxIdentificationNumber == keyword);
            }
            if (QueryStrings.Any(d => d.Key == "TaxIdentificationNumber") && !string.IsNullOrEmpty(QueryStrings.FirstOrDefault(d => d.Key == "TaxIdentificationNumber").Value))
            {
                var keyword = QueryStrings.FirstOrDefault(d => d.Key == "TaxIdentificationNumber").Value;
                query = query.Where(d=>d.TaxIdentificationNumber.Contains(keyword));
            }
            

			//Query RegistrationDateOfTaxId (Nullable<System.DateTime>)
			if (QueryStrings.Any(d => d.Key == "RegistrationDateOfTaxIdFrom") && QueryStrings.Any(d => d.Key == "RegistrationDateOfTaxIdTo"))
                if (DateTime.TryParse(QueryStrings.FirstOrDefault(d => d.Key == "RegistrationDateOfTaxIdFrom").Value, out DateTime fromDate) && DateTime.TryParse(QueryStrings.FirstOrDefault(d => d.Key == "RegistrationDateOfTaxIdTo").Value, out DateTime toDate))
                    query = query.Where(d => fromDate <= d.RegistrationDateOfTaxId && d.RegistrationDateOfTaxId <= toDate);

            if (QueryStrings.Any(d => d.Key == "RegistrationDateOfTaxId"))
                if (DateTime.TryParse(QueryStrings.FirstOrDefault(d => d.Key == "RegistrationDateOfTaxId").Value, out DateTime val))
                    query = query.Where(d => d.RegistrationDateOfTaxId != null && DbFunctions.TruncateTime(val) == DbFunctions.TruncateTime(d.RegistrationDateOfTaxId));


			//Query RegistrationPlaceOfTaxId (string)
			if (QueryStrings.Any(d => d.Key == "RegistrationPlaceOfTaxId_eq") && !string.IsNullOrEmpty(QueryStrings.FirstOrDefault(d => d.Key == "RegistrationPlaceOfTaxId_eq").Value))
            {
                var keyword = QueryStrings.FirstOrDefault(d => d.Key == "RegistrationPlaceOfTaxId_eq").Value;
                query = query.Where(d=>d.RegistrationPlaceOfTaxId == keyword);
            }
            if (QueryStrings.Any(d => d.Key == "RegistrationPlaceOfTaxId") && !string.IsNullOrEmpty(QueryStrings.FirstOrDefault(d => d.Key == "RegistrationPlaceOfTaxId").Value))
            {
                var keyword = QueryStrings.FirstOrDefault(d => d.Key == "RegistrationPlaceOfTaxId").Value;
                query = query.Where(d=>d.RegistrationPlaceOfTaxId.Contains(keyword));
            }
            

			//Query PassportNumber (string)
			if (QueryStrings.Any(d => d.Key == "PassportNumber_eq") && !string.IsNullOrEmpty(QueryStrings.FirstOrDefault(d => d.Key == "PassportNumber_eq").Value))
            {
                var keyword = QueryStrings.FirstOrDefault(d => d.Key == "PassportNumber_eq").Value;
                query = query.Where(d=>d.PassportNumber == keyword);
            }
            if (QueryStrings.Any(d => d.Key == "PassportNumber") && !string.IsNullOrEmpty(QueryStrings.FirstOrDefault(d => d.Key == "PassportNumber").Value))
            {
                var keyword = QueryStrings.FirstOrDefault(d => d.Key == "PassportNumber").Value;
                query = query.Where(d=>d.PassportNumber.Contains(keyword));
            }
            

			//Query DateOfIssuePassport (Nullable<System.DateTime>)
			if (QueryStrings.Any(d => d.Key == "DateOfIssuePassportFrom") && QueryStrings.Any(d => d.Key == "DateOfIssuePassportTo"))
                if (DateTime.TryParse(QueryStrings.FirstOrDefault(d => d.Key == "DateOfIssuePassportFrom").Value, out DateTime fromDate) && DateTime.TryParse(QueryStrings.FirstOrDefault(d => d.Key == "DateOfIssuePassportTo").Value, out DateTime toDate))
                    query = query.Where(d => fromDate <= d.DateOfIssuePassport && d.DateOfIssuePassport <= toDate);

            if (QueryStrings.Any(d => d.Key == "DateOfIssuePassport"))
                if (DateTime.TryParse(QueryStrings.FirstOrDefault(d => d.Key == "DateOfIssuePassport").Value, out DateTime val))
                    query = query.Where(d => d.DateOfIssuePassport != null && DbFunctions.TruncateTime(val) == DbFunctions.TruncateTime(d.DateOfIssuePassport));


			//Query DateOfExpiryPassport (Nullable<System.DateTime>)
			if (QueryStrings.Any(d => d.Key == "DateOfExpiryPassportFrom") && QueryStrings.Any(d => d.Key == "DateOfExpiryPassportTo"))
                if (DateTime.TryParse(QueryStrings.FirstOrDefault(d => d.Key == "DateOfExpiryPassportFrom").Value, out DateTime fromDate) && DateTime.TryParse(QueryStrings.FirstOrDefault(d => d.Key == "DateOfExpiryPassportTo").Value, out DateTime toDate))
                    query = query.Where(d => fromDate <= d.DateOfExpiryPassport && d.DateOfExpiryPassport <= toDate);

            if (QueryStrings.Any(d => d.Key == "DateOfExpiryPassport"))
                if (DateTime.TryParse(QueryStrings.FirstOrDefault(d => d.Key == "DateOfExpiryPassport").Value, out DateTime val))
                    query = query.Where(d => d.DateOfExpiryPassport != null && DbFunctions.TruncateTime(val) == DbFunctions.TruncateTime(d.DateOfExpiryPassport));


			//Query PlaceOfIssuePassport (string)
			if (QueryStrings.Any(d => d.Key == "PlaceOfIssuePassport_eq") && !string.IsNullOrEmpty(QueryStrings.FirstOrDefault(d => d.Key == "PlaceOfIssuePassport_eq").Value))
            {
                var keyword = QueryStrings.FirstOrDefault(d => d.Key == "PlaceOfIssuePassport_eq").Value;
                query = query.Where(d=>d.PlaceOfIssuePassport == keyword);
            }
            if (QueryStrings.Any(d => d.Key == "PlaceOfIssuePassport") && !string.IsNullOrEmpty(QueryStrings.FirstOrDefault(d => d.Key == "PlaceOfIssuePassport").Value))
            {
                var keyword = QueryStrings.FirstOrDefault(d => d.Key == "PlaceOfIssuePassport").Value;
                query = query.Where(d=>d.PlaceOfIssuePassport.Contains(keyword));
            }
            

			//Query IDTypeOfPassport (Nullable<int>)
			if (QueryStrings.Any(d => d.Key == "IDTypeOfPassport"))
            {
                var IDList = QueryStrings.FirstOrDefault(d => d.Key == "IDTypeOfPassport").Value.Replace("[", "").Replace("]", "").Split(',');
                List<int?> IDs = new List<int?>();
                foreach (var item in IDList)
                    if (int.TryParse(item, out int i))
                        IDs.Add(i);
					else if (item == "null")
						IDs.Add(null);
                if (IDs.Count > 0)
                    query = query.Where(d => IDs.Contains(d.IDTypeOfPassport));
////                    query = query.Where(d => IDs.Contains(d.IDTypeOfPassport));
//                    
            }

			//Query IDCountryOfIssuePassport (Nullable<int>)
			if (QueryStrings.Any(d => d.Key == "IDCountryOfIssuePassport"))
            {
                var IDList = QueryStrings.FirstOrDefault(d => d.Key == "IDCountryOfIssuePassport").Value.Replace("[", "").Replace("]", "").Split(',');
                List<int?> IDs = new List<int?>();
                foreach (var item in IDList)
                    if (int.TryParse(item, out int i))
                        IDs.Add(i);
					else if (item == "null")
						IDs.Add(null);
                if (IDs.Count > 0)
                    query = query.Where(d => IDs.Contains(d.IDCountryOfIssuePassport));
////                    query = query.Where(d => IDs.Contains(d.IDCountryOfIssuePassport));
//                    
            }

			//Query VisaNumber (string)
			if (QueryStrings.Any(d => d.Key == "VisaNumber_eq") && !string.IsNullOrEmpty(QueryStrings.FirstOrDefault(d => d.Key == "VisaNumber_eq").Value))
            {
                var keyword = QueryStrings.FirstOrDefault(d => d.Key == "VisaNumber_eq").Value;
                query = query.Where(d=>d.VisaNumber == keyword);
            }
            if (QueryStrings.Any(d => d.Key == "VisaNumber") && !string.IsNullOrEmpty(QueryStrings.FirstOrDefault(d => d.Key == "VisaNumber").Value))
            {
                var keyword = QueryStrings.FirstOrDefault(d => d.Key == "VisaNumber").Value;
                query = query.Where(d=>d.VisaNumber.Contains(keyword));
            }
            

			//Query DateOfIssueVisa (Nullable<System.DateTime>)
			if (QueryStrings.Any(d => d.Key == "DateOfIssueVisaFrom") && QueryStrings.Any(d => d.Key == "DateOfIssueVisaTo"))
                if (DateTime.TryParse(QueryStrings.FirstOrDefault(d => d.Key == "DateOfIssueVisaFrom").Value, out DateTime fromDate) && DateTime.TryParse(QueryStrings.FirstOrDefault(d => d.Key == "DateOfIssueVisaTo").Value, out DateTime toDate))
                    query = query.Where(d => fromDate <= d.DateOfIssueVisa && d.DateOfIssueVisa <= toDate);

            if (QueryStrings.Any(d => d.Key == "DateOfIssueVisa"))
                if (DateTime.TryParse(QueryStrings.FirstOrDefault(d => d.Key == "DateOfIssueVisa").Value, out DateTime val))
                    query = query.Where(d => d.DateOfIssueVisa != null && DbFunctions.TruncateTime(val) == DbFunctions.TruncateTime(d.DateOfIssueVisa));


			//Query DateOfExpiryVisa (Nullable<System.DateTime>)
			if (QueryStrings.Any(d => d.Key == "DateOfExpiryVisaFrom") && QueryStrings.Any(d => d.Key == "DateOfExpiryVisaTo"))
                if (DateTime.TryParse(QueryStrings.FirstOrDefault(d => d.Key == "DateOfExpiryVisaFrom").Value, out DateTime fromDate) && DateTime.TryParse(QueryStrings.FirstOrDefault(d => d.Key == "DateOfExpiryVisaTo").Value, out DateTime toDate))
                    query = query.Where(d => fromDate <= d.DateOfExpiryVisa && d.DateOfExpiryVisa <= toDate);

            if (QueryStrings.Any(d => d.Key == "DateOfExpiryVisa"))
                if (DateTime.TryParse(QueryStrings.FirstOrDefault(d => d.Key == "DateOfExpiryVisa").Value, out DateTime val))
                    query = query.Where(d => d.DateOfExpiryVisa != null && DbFunctions.TruncateTime(val) == DbFunctions.TruncateTime(d.DateOfExpiryVisa));


			//Query IDCountryOfIssueVisa (Nullable<int>)
			if (QueryStrings.Any(d => d.Key == "IDCountryOfIssueVisa"))
            {
                var IDList = QueryStrings.FirstOrDefault(d => d.Key == "IDCountryOfIssueVisa").Value.Replace("[", "").Replace("]", "").Split(',');
                List<int?> IDs = new List<int?>();
                foreach (var item in IDList)
                    if (int.TryParse(item, out int i))
                        IDs.Add(i);
					else if (item == "null")
						IDs.Add(null);
                if (IDs.Count > 0)
                    query = query.Where(d => IDs.Contains(d.IDCountryOfIssueVisa));
////                    query = query.Where(d => IDs.Contains(d.IDCountryOfIssueVisa));
//                    
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
		
        public static IQueryable<tbl_HRM_StaffIdentityCardAndPIT> _sortBuilder(IQueryable<tbl_HRM_StaffIdentityCardAndPIT> query, Dictionary<string, string> QueryStrings)
        {
            if (QueryStrings.Any(d => d.Key == "SortBy"))
            {
                var sorts = QueryStrings.FirstOrDefault(d => d.Key == "SortBy").Value.Replace("[", "").Replace("]", "").Split(',');
                
                foreach (var item in sorts)
                    if (!string.IsNullOrEmpty(item))
                    {
                        var ordered = query as IOrderedQueryable<tbl_HRM_StaffIdentityCardAndPIT>;
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
							case "IdentityCardNumber":
								query = isOrdered ? ordered.ThenBy(o => o.IdentityCardNumber) : query.OrderBy(o => o.IdentityCardNumber);
								 break;
							case "IdentityCardNumber_desc":
                                query = isOrdered ? ordered.ThenByDescending(o => o.IdentityCardNumber) : query.OrderByDescending(o => o.IdentityCardNumber);
                                break;
							case "DateOfIssueID":
								query = isOrdered ? ordered.ThenBy(o => o.DateOfIssueID) : query.OrderBy(o => o.DateOfIssueID);
								 break;
							case "DateOfIssueID_desc":
                                query = isOrdered ? ordered.ThenByDescending(o => o.DateOfIssueID) : query.OrderByDescending(o => o.DateOfIssueID);
                                break;
							case "PlaceOfIssueID":
								query = isOrdered ? ordered.ThenBy(o => o.PlaceOfIssueID) : query.OrderBy(o => o.PlaceOfIssueID);
								 break;
							case "PlaceOfIssueID_desc":
                                query = isOrdered ? ordered.ThenByDescending(o => o.PlaceOfIssueID) : query.OrderByDescending(o => o.PlaceOfIssueID);
                                break;
							case "DateOfExpiryID":
								query = isOrdered ? ordered.ThenBy(o => o.DateOfExpiryID) : query.OrderBy(o => o.DateOfExpiryID);
								 break;
							case "DateOfExpiryID_desc":
                                query = isOrdered ? ordered.ThenByDescending(o => o.DateOfExpiryID) : query.OrderByDescending(o => o.DateOfExpiryID);
                                break;
							case "IdentityCardNumber1":
								query = isOrdered ? ordered.ThenBy(o => o.IdentityCardNumber1) : query.OrderBy(o => o.IdentityCardNumber1);
								 break;
							case "IdentityCardNumber1_desc":
                                query = isOrdered ? ordered.ThenByDescending(o => o.IdentityCardNumber1) : query.OrderByDescending(o => o.IdentityCardNumber1);
                                break;
							case "DateOfIssueId1":
								query = isOrdered ? ordered.ThenBy(o => o.DateOfIssueId1) : query.OrderBy(o => o.DateOfIssueId1);
								 break;
							case "DateOfIssueId1_desc":
                                query = isOrdered ? ordered.ThenByDescending(o => o.DateOfIssueId1) : query.OrderByDescending(o => o.DateOfIssueId1);
                                break;
							case "DateOfExpiry1":
								query = isOrdered ? ordered.ThenBy(o => o.DateOfExpiry1) : query.OrderBy(o => o.DateOfExpiry1);
								 break;
							case "DateOfExpiry1_desc":
                                query = isOrdered ? ordered.ThenByDescending(o => o.DateOfExpiry1) : query.OrderByDescending(o => o.DateOfExpiry1);
                                break;
							case "TaxIdentificationNumber":
								query = isOrdered ? ordered.ThenBy(o => o.TaxIdentificationNumber) : query.OrderBy(o => o.TaxIdentificationNumber);
								 break;
							case "TaxIdentificationNumber_desc":
                                query = isOrdered ? ordered.ThenByDescending(o => o.TaxIdentificationNumber) : query.OrderByDescending(o => o.TaxIdentificationNumber);
                                break;
							case "RegistrationDateOfTaxId":
								query = isOrdered ? ordered.ThenBy(o => o.RegistrationDateOfTaxId) : query.OrderBy(o => o.RegistrationDateOfTaxId);
								 break;
							case "RegistrationDateOfTaxId_desc":
                                query = isOrdered ? ordered.ThenByDescending(o => o.RegistrationDateOfTaxId) : query.OrderByDescending(o => o.RegistrationDateOfTaxId);
                                break;
							case "RegistrationPlaceOfTaxId":
								query = isOrdered ? ordered.ThenBy(o => o.RegistrationPlaceOfTaxId) : query.OrderBy(o => o.RegistrationPlaceOfTaxId);
								 break;
							case "RegistrationPlaceOfTaxId_desc":
                                query = isOrdered ? ordered.ThenByDescending(o => o.RegistrationPlaceOfTaxId) : query.OrderByDescending(o => o.RegistrationPlaceOfTaxId);
                                break;
							case "PassportNumber":
								query = isOrdered ? ordered.ThenBy(o => o.PassportNumber) : query.OrderBy(o => o.PassportNumber);
								 break;
							case "PassportNumber_desc":
                                query = isOrdered ? ordered.ThenByDescending(o => o.PassportNumber) : query.OrderByDescending(o => o.PassportNumber);
                                break;
							case "DateOfIssuePassport":
								query = isOrdered ? ordered.ThenBy(o => o.DateOfIssuePassport) : query.OrderBy(o => o.DateOfIssuePassport);
								 break;
							case "DateOfIssuePassport_desc":
                                query = isOrdered ? ordered.ThenByDescending(o => o.DateOfIssuePassport) : query.OrderByDescending(o => o.DateOfIssuePassport);
                                break;
							case "DateOfExpiryPassport":
								query = isOrdered ? ordered.ThenBy(o => o.DateOfExpiryPassport) : query.OrderBy(o => o.DateOfExpiryPassport);
								 break;
							case "DateOfExpiryPassport_desc":
                                query = isOrdered ? ordered.ThenByDescending(o => o.DateOfExpiryPassport) : query.OrderByDescending(o => o.DateOfExpiryPassport);
                                break;
							case "PlaceOfIssuePassport":
								query = isOrdered ? ordered.ThenBy(o => o.PlaceOfIssuePassport) : query.OrderBy(o => o.PlaceOfIssuePassport);
								 break;
							case "PlaceOfIssuePassport_desc":
                                query = isOrdered ? ordered.ThenByDescending(o => o.PlaceOfIssuePassport) : query.OrderByDescending(o => o.PlaceOfIssuePassport);
                                break;
							case "IDTypeOfPassport":
								query = isOrdered ? ordered.ThenBy(o => o.IDTypeOfPassport) : query.OrderBy(o => o.IDTypeOfPassport);
								 break;
							case "IDTypeOfPassport_desc":
                                query = isOrdered ? ordered.ThenByDescending(o => o.IDTypeOfPassport) : query.OrderByDescending(o => o.IDTypeOfPassport);
                                break;
							case "IDCountryOfIssuePassport":
								query = isOrdered ? ordered.ThenBy(o => o.IDCountryOfIssuePassport) : query.OrderBy(o => o.IDCountryOfIssuePassport);
								 break;
							case "IDCountryOfIssuePassport_desc":
                                query = isOrdered ? ordered.ThenByDescending(o => o.IDCountryOfIssuePassport) : query.OrderByDescending(o => o.IDCountryOfIssuePassport);
                                break;
							case "VisaNumber":
								query = isOrdered ? ordered.ThenBy(o => o.VisaNumber) : query.OrderBy(o => o.VisaNumber);
								 break;
							case "VisaNumber_desc":
                                query = isOrdered ? ordered.ThenByDescending(o => o.VisaNumber) : query.OrderByDescending(o => o.VisaNumber);
                                break;
							case "DateOfIssueVisa":
								query = isOrdered ? ordered.ThenBy(o => o.DateOfIssueVisa) : query.OrderBy(o => o.DateOfIssueVisa);
								 break;
							case "DateOfIssueVisa_desc":
                                query = isOrdered ? ordered.ThenByDescending(o => o.DateOfIssueVisa) : query.OrderByDescending(o => o.DateOfIssueVisa);
                                break;
							case "DateOfExpiryVisa":
								query = isOrdered ? ordered.ThenBy(o => o.DateOfExpiryVisa) : query.OrderBy(o => o.DateOfExpiryVisa);
								 break;
							case "DateOfExpiryVisa_desc":
                                query = isOrdered ? ordered.ThenByDescending(o => o.DateOfExpiryVisa) : query.OrderByDescending(o => o.DateOfExpiryVisa);
                                break;
							case "IDCountryOfIssueVisa":
								query = isOrdered ? ordered.ThenBy(o => o.IDCountryOfIssueVisa) : query.OrderBy(o => o.IDCountryOfIssueVisa);
								 break;
							case "IDCountryOfIssueVisa_desc":
                                query = isOrdered ? ordered.ThenByDescending(o => o.IDCountryOfIssueVisa) : query.OrderByDescending(o => o.IDCountryOfIssueVisa);
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

        public static IQueryable<tbl_HRM_StaffIdentityCardAndPIT> _pagingBuilder(IQueryable<tbl_HRM_StaffIdentityCardAndPIT> query, Dictionary<string, string> QueryStrings)
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






