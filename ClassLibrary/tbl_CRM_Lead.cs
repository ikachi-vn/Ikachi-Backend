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
    
    
    public partial class tbl_CRM_Lead
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public tbl_CRM_Lead()
        {
            this.tbl_CRM_Activity = new HashSet<tbl_CRM_Activity>();
            this.tbl_CRM_CampaignMember = new HashSet<tbl_CRM_CampaignMember>();
            this.tbl_CRM_Opportunity = new HashSet<tbl_CRM_Opportunity>();
            this.tbl_PM_Task = new HashSet<tbl_PM_Task>();
        }
    
        public Nullable<int> IDCampaign { get; set; }
        public Nullable<int> IDOwner { get; set; }
        public int IDStatus { get; set; }
        public Nullable<int> IDRating { get; set; }
        public Nullable<int> IDSource { get; set; }
        public Nullable<int> IDIndustry { get; set; }
        public Nullable<int> IDSector { get; set; }
        public Nullable<int> IDCountry { get; set; }
        public Nullable<int> IDCity { get; set; }
        public Nullable<int> IDProvince { get; set; }
        public int IDBranch { get; set; }
        public int Id { get; set; }
        public string Code { get; set; }
        public string Individual { get; set; }
        public string Name { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Company { get; set; }
        public string Title { get; set; }
        public string Remark { get; set; }
        public string Address { get; set; }
        public string Street { get; set; }
        public string ZipCode { get; set; }
        public decimal AnnualRevenue { get; set; }
        public string Email { get; set; }
        public bool HasOptedOutOfEmail { get; set; }
        public string Phone { get; set; }
        public string MobilePhone { get; set; }
        public bool DoNotCall { get; set; }
        public string Fax { get; set; }
        public bool HasOptedOutOfFax { get; set; }
        public Nullable<int> NumberOfEmployees { get; set; }
        public string Website { get; set; }
        public Nullable<System.DateTime> LastTransferDate { get; set; }
        public Nullable<int> Sort { get; set; }
        public bool IsDisabled { get; set; }
        public bool IsDeleted { get; set; }
        public string CreatedBy { get; set; }
        public string ModifiedBy { get; set; }
        public System.DateTime CreatedDate { get; set; }
        public System.DateTime ModifiedDate { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tbl_CRM_Activity> tbl_CRM_Activity { get; set; }
        //List 0:1
        public virtual tbl_CRM_Campaign tbl_CRM_Campaign { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tbl_CRM_CampaignMember> tbl_CRM_CampaignMember { get; set; }
        //List 0:1
        public virtual tbl_HRM_Staff tbl_HRM_Staff { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tbl_CRM_Opportunity> tbl_CRM_Opportunity { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tbl_PM_Task> tbl_PM_Task { get; set; }
    }
}


namespace DTOModel
{
	using System;
	public partial class DTO_CRM_Lead
	{
		public Nullable<int> IDCampaign { get; set; }
		public Nullable<int> IDOwner { get; set; }
		public int IDStatus { get; set; }
		public Nullable<int> IDRating { get; set; }
		public Nullable<int> IDSource { get; set; }
		public Nullable<int> IDIndustry { get; set; }
		public Nullable<int> IDSector { get; set; }
		public Nullable<int> IDCountry { get; set; }
		public Nullable<int> IDCity { get; set; }
		public Nullable<int> IDProvince { get; set; }
		public int IDBranch { get; set; }
		public int Id { get; set; }
		public string Code { get; set; }
		public string Individual { get; set; }
		public string Name { get; set; }
		public string FirstName { get; set; }
		public string LastName { get; set; }
		public string Company { get; set; }
		public string Title { get; set; }
		public string Remark { get; set; }
		public string Address { get; set; }
		public string Street { get; set; }
		public string ZipCode { get; set; }
		public decimal AnnualRevenue { get; set; }
		public string Email { get; set; }
		public bool HasOptedOutOfEmail { get; set; }
		public string Phone { get; set; }
		public string MobilePhone { get; set; }
		public bool DoNotCall { get; set; }
		public string Fax { get; set; }
		public bool HasOptedOutOfFax { get; set; }
		public Nullable<int> NumberOfEmployees { get; set; }
		public string Website { get; set; }
		public Nullable<System.DateTime> LastTransferDate { get; set; }
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

    public static partial class BS_CRM_Lead 
    {
        public static dynamic getSearch(AppEntities db, int IDBranch, int StaffID, Dictionary<string, string> QueryStrings)
        {
            return get(db, IDBranch,StaffID, QueryStrings);
        }

		public static IQueryable<DTO_CRM_Lead> get(AppEntities db, int IDBranch, int StaffID, Dictionary<string, string> QueryStrings)
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
            package.Workbook.Properties.Title = "ART-DMS CRM_Lead";
            package.Workbook.Properties.Author = "hung.vu@codeart.vn";
            package.Workbook.Properties.Application = "ART-DMS";
            package.Workbook.Properties.Company = "A.R.T Distribution";

            ExcelWorkbook workBook = package.Workbook;
            if (workBook != null)
            {
                var ws = workBook.Worksheets.FirstOrDefault();
                var data = _queryBuilder(db, IDBranch, StaffID, QueryStrings).ToList();

                //var CRM_CampaignList = BS_CRM_Campaign.get(db,IDBranch, StaffID,QueryStrings).Select(s => new ItemModel { Id = s.Id, Name = s.Name });
                //var HRM_StaffList = BS_HRM_Staff.get(db,IDBranch, StaffID,QueryStrings).Select(s => new ItemModel { Id = s.Id, Name = s.Name });
                 

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

		public static DTO_CRM_Lead getAnItem(AppEntities db, int IDBranch, int StaffID, int id)
        {
            var dbResult = db.tbl_CRM_Lead.Find(id);

			//if (dbResult == null || (IDBranch != 0 && dbResult.IDBranch != IDBranch))
			//	return null; 
			//else 
				return toDTO(dbResult);
			
        }
		
		public static DTO_CRM_Lead getAnItemByCode(AppEntities db, int IDBranch, int StaffID, string code)
        {
            var dbResult = db.tbl_CRM_Lead
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
            var dbitem = db.tbl_CRM_Lead.Find(Id);
            
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
					errorLog.logMessage("put_CRM_Lead",e);
                    result = false;
                }
            }
            else
                if (QueryStrings.Any(d => d.Key == "ForceCreate"))
                    result =  post(db, IDBranch, StaffID, item, Username) != null;
                
            return result;
        }

        public static void patchDynamicToDB(dynamic item, tbl_CRM_Lead dbitem, string Username)
        {
            Type type = typeof(tbl_CRM_Lead);
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

        public static void patchDTOtoDBValue( DTO_CRM_Lead item, tbl_CRM_Lead dbitem)
        {
            if (item == null){
                dbitem = null;
                return;
            }
            							
			dbitem.IDCampaign = item.IDCampaign;							
			dbitem.IDOwner = item.IDOwner;							
			dbitem.IDStatus = item.IDStatus;							
			dbitem.IDRating = item.IDRating;							
			dbitem.IDSource = item.IDSource;							
			dbitem.IDIndustry = item.IDIndustry;							
			dbitem.IDSector = item.IDSector;							
			dbitem.IDCountry = item.IDCountry;							
			dbitem.IDCity = item.IDCity;							
			dbitem.IDProvince = item.IDProvince;							
			dbitem.IDBranch = item.IDBranch;							
			dbitem.Code = item.Code;							
			dbitem.Individual = item.Individual;							
			dbitem.Name = item.Name;							
			dbitem.FirstName = item.FirstName;							
			dbitem.LastName = item.LastName;							
			dbitem.Company = item.Company;							
			dbitem.Title = item.Title;							
			dbitem.Remark = item.Remark;							
			dbitem.Address = item.Address;							
			dbitem.Street = item.Street;							
			dbitem.ZipCode = item.ZipCode;							
			dbitem.AnnualRevenue = item.AnnualRevenue;							
			dbitem.Email = item.Email;							
			dbitem.HasOptedOutOfEmail = item.HasOptedOutOfEmail;							
			dbitem.Phone = item.Phone;							
			dbitem.MobilePhone = item.MobilePhone;							
			dbitem.DoNotCall = item.DoNotCall;							
			dbitem.Fax = item.Fax;							
			dbitem.HasOptedOutOfFax = item.HasOptedOutOfFax;							
			dbitem.NumberOfEmployees = item.NumberOfEmployees;							
			dbitem.Website = item.Website;							
			dbitem.LastTransferDate = item.LastTransferDate;							
			dbitem.Sort = item.Sort;							
			dbitem.IsDisabled = item.IsDisabled;							
			dbitem.IsDeleted = item.IsDeleted;        }

		public static DTO_CRM_Lead post(AppEntities db, int IDBranch, int StaffID, dynamic item, string Username)
        {
            tbl_CRM_Lead dbitem = new tbl_CRM_Lead();
            if (item != null)
            {
                patchDynamicToDB(item, dbitem, Username);
                
				dbitem.CreatedBy = Username;
				dbitem.CreatedDate = DateTime.Now;				
                try
                {
					db.tbl_CRM_Lead.Add(dbitem);
                    db.SaveChanges();
				
                }
                catch (DbEntityValidationException e)
                {
					errorLog.logMessage("post_CRM_Lead",e);
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
                Type type = Type.GetType("BaseBusiness.BS_CRM_Lead, ClassLibrary");
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
                        var target = new tbl_CRM_Lead();
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
                    
                    tbl_CRM_Lead dbitem = new tbl_CRM_Lead();
                    if (it.Id == null || string.IsNullOrEmpty(it.Id.Value) || it.Id == "0")
                    {
                        dbitem = new tbl_CRM_Lead();
                        dbitem.CreatedBy = Username;
				        dbitem.CreatedDate = DateTime.Now;
                                            }
                    else
                    {
                        dbitem = db.tbl_CRM_Lead.Find((int)it.Id);
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
                        
                        if (dbitem.Id == 0) db.tbl_CRM_Lead.Add(dbitem);
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
                    errorLog.logMessage("post_CRM_Lead",e);
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

            var dbitems = db.tbl_CRM_Lead.Where(d => IDs.Contains(d.Id));
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
                    BS_Version.update_Version(db, IDBranch, "DTO_CRM_Lead", updateDate, Username);
                }
			
            }
            catch (DbEntityValidationException e)
            {
				errorLog.logMessage("delete_CRM_Lead",e);
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

			
            var dbitems = db.tbl_CRM_Lead.Where(d => IDs.Contains(d.Id));
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
                    BS_Version.update_Version(db, IDBranch, "DTO_CRM_Lead", updateDate, Username);
                }
			
            }
            catch (DbEntityValidationException e)
            {
				errorLog.logMessage("disable_CRM_Lead",e);
                result = false;
            }
            
            return result;
        }

		
		//---//
		public static bool check_Exists(AppEntities db, int id)
		{
             
            return db.tbl_CRM_Lead.Any(e => e.Id == id && e.IsDeleted == false);
            
		}
		
		public static bool check_Exists(AppEntities db, string Code)
		{
             
            return db.tbl_CRM_Lead.Any(e => e.Code == Code && e.IsDeleted == false);
            
		}
		
		//---//
		public static IQueryable<DTO_CRM_Lead> toDTO(IQueryable<tbl_CRM_Lead> query)
        {
			return query
			.Select(s => new DTO_CRM_Lead(){							
				IDCampaign = s.IDCampaign,							
				IDOwner = s.IDOwner,							
				IDStatus = s.IDStatus,							
				IDRating = s.IDRating,							
				IDSource = s.IDSource,							
				IDIndustry = s.IDIndustry,							
				IDSector = s.IDSector,							
				IDCountry = s.IDCountry,							
				IDCity = s.IDCity,							
				IDProvince = s.IDProvince,							
				IDBranch = s.IDBranch,							
				Id = s.Id,							
				Code = s.Code,							
				Individual = s.Individual,							
				Name = s.Name,							
				FirstName = s.FirstName,							
				LastName = s.LastName,							
				Company = s.Company,							
				Title = s.Title,							
				Remark = s.Remark,							
				Address = s.Address,							
				Street = s.Street,							
				ZipCode = s.ZipCode,							
				AnnualRevenue = s.AnnualRevenue,							
				Email = s.Email,							
				HasOptedOutOfEmail = s.HasOptedOutOfEmail,							
				Phone = s.Phone,							
				MobilePhone = s.MobilePhone,							
				DoNotCall = s.DoNotCall,							
				Fax = s.Fax,							
				HasOptedOutOfFax = s.HasOptedOutOfFax,							
				NumberOfEmployees = s.NumberOfEmployees,							
				Website = s.Website,							
				LastTransferDate = s.LastTransferDate,							
				Sort = s.Sort,							
				IsDisabled = s.IsDisabled,							
				IsDeleted = s.IsDeleted,							
				CreatedBy = s.CreatedBy,							
				ModifiedBy = s.ModifiedBy,							
				CreatedDate = s.CreatedDate,							
				ModifiedDate = s.ModifiedDate,					
			});//.OrderBy(o => o.Sort == null).ThenBy(u => u.Sort);
                              
        }

		public static DTO_CRM_Lead toDTO(tbl_CRM_Lead dbResult)
        {
			if (dbResult != null)
			{
				return new DTO_CRM_Lead()
				{							
					IDCampaign = dbResult.IDCampaign,							
					IDOwner = dbResult.IDOwner,							
					IDStatus = dbResult.IDStatus,							
					IDRating = dbResult.IDRating,							
					IDSource = dbResult.IDSource,							
					IDIndustry = dbResult.IDIndustry,							
					IDSector = dbResult.IDSector,							
					IDCountry = dbResult.IDCountry,							
					IDCity = dbResult.IDCity,							
					IDProvince = dbResult.IDProvince,							
					IDBranch = dbResult.IDBranch,							
					Id = dbResult.Id,							
					Code = dbResult.Code,							
					Individual = dbResult.Individual,							
					Name = dbResult.Name,							
					FirstName = dbResult.FirstName,							
					LastName = dbResult.LastName,							
					Company = dbResult.Company,							
					Title = dbResult.Title,							
					Remark = dbResult.Remark,							
					Address = dbResult.Address,							
					Street = dbResult.Street,							
					ZipCode = dbResult.ZipCode,							
					AnnualRevenue = dbResult.AnnualRevenue,							
					Email = dbResult.Email,							
					HasOptedOutOfEmail = dbResult.HasOptedOutOfEmail,							
					Phone = dbResult.Phone,							
					MobilePhone = dbResult.MobilePhone,							
					DoNotCall = dbResult.DoNotCall,							
					Fax = dbResult.Fax,							
					HasOptedOutOfFax = dbResult.HasOptedOutOfFax,							
					NumberOfEmployees = dbResult.NumberOfEmployees,							
					Website = dbResult.Website,							
					LastTransferDate = dbResult.LastTransferDate,							
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

		public static IQueryable<tbl_CRM_Lead> _queryBuilder(AppEntities db, int IDBranch, int StaffID, Dictionary<string, string> QueryStrings)
        {
            
			IQueryable<tbl_CRM_Lead> query = db.tbl_CRM_Lead.AsNoTracking();//.Where(d => d.IsDeleted == false);
			

			//Query keyword
			if (QueryStrings.Any(d => d.Key == "Keyword") && !string.IsNullOrEmpty(QueryStrings.FirstOrDefault(d => d.Key == "Keyword").Value))
            {
                var keyword = QueryStrings.FirstOrDefault(d => d.Key == "Keyword").Value;
                query = query.Where(d=>d.Name.Contains(keyword) || d.Code.Contains(keyword));
            }



			//Query IDCampaign (Nullable<int>)
			if (QueryStrings.Any(d => d.Key == "IDCampaign"))
            {
                var IDList = QueryStrings.FirstOrDefault(d => d.Key == "IDCampaign").Value.Replace("[", "").Replace("]", "").Split(',');
                List<int?> IDs = new List<int?>();
                foreach (var item in IDList)
                    if (int.TryParse(item, out int i))
                        IDs.Add(i);
					else if (item == "null")
						IDs.Add(null);
                if (IDs.Count > 0)
                    query = query.Where(d => IDs.Contains(d.IDCampaign));
////                    query = query.Where(d => IDs.Contains(d.IDCampaign));
//                    
            }

			//Query IDOwner (Nullable<int>)
			if (QueryStrings.Any(d => d.Key == "IDOwner"))
            {
                var IDList = QueryStrings.FirstOrDefault(d => d.Key == "IDOwner").Value.Replace("[", "").Replace("]", "").Split(',');
                List<int?> IDs = new List<int?>();
                foreach (var item in IDList)
                    if (int.TryParse(item, out int i))
                        IDs.Add(i);
					else if (item == "null")
						IDs.Add(null);
                if (IDs.Count > 0)
                    query = query.Where(d => IDs.Contains(d.IDOwner));
////                    query = query.Where(d => IDs.Contains(d.IDOwner));
//                    
            }

			//Query IDStatus (int)
			if (QueryStrings.Any(d => d.Key == "IDStatus"))
            {
                var IDList = QueryStrings.FirstOrDefault(d => d.Key == "IDStatus").Value.Replace("[", "").Replace("]", "").Split(',');
                List<int> IDs = new List<int>();
                foreach (var item in IDList)
                    if (int.TryParse(item, out int i))
                        IDs.Add(i);
                if (IDs.Count > 0)
                    query = query.Where(d => IDs.Contains(d.IDStatus));
            }

			//Query IDRating (Nullable<int>)
			if (QueryStrings.Any(d => d.Key == "IDRating"))
            {
                var IDList = QueryStrings.FirstOrDefault(d => d.Key == "IDRating").Value.Replace("[", "").Replace("]", "").Split(',');
                List<int?> IDs = new List<int?>();
                foreach (var item in IDList)
                    if (int.TryParse(item, out int i))
                        IDs.Add(i);
					else if (item == "null")
						IDs.Add(null);
                if (IDs.Count > 0)
                    query = query.Where(d => IDs.Contains(d.IDRating));
////                    query = query.Where(d => IDs.Contains(d.IDRating));
//                    
            }

			//Query IDSource (Nullable<int>)
			if (QueryStrings.Any(d => d.Key == "IDSource"))
            {
                var IDList = QueryStrings.FirstOrDefault(d => d.Key == "IDSource").Value.Replace("[", "").Replace("]", "").Split(',');
                List<int?> IDs = new List<int?>();
                foreach (var item in IDList)
                    if (int.TryParse(item, out int i))
                        IDs.Add(i);
					else if (item == "null")
						IDs.Add(null);
                if (IDs.Count > 0)
                    query = query.Where(d => IDs.Contains(d.IDSource));
////                    query = query.Where(d => IDs.Contains(d.IDSource));
//                    
            }

			//Query IDIndustry (Nullable<int>)
			if (QueryStrings.Any(d => d.Key == "IDIndustry"))
            {
                var IDList = QueryStrings.FirstOrDefault(d => d.Key == "IDIndustry").Value.Replace("[", "").Replace("]", "").Split(',');
                List<int?> IDs = new List<int?>();
                foreach (var item in IDList)
                    if (int.TryParse(item, out int i))
                        IDs.Add(i);
					else if (item == "null")
						IDs.Add(null);
                if (IDs.Count > 0)
                    query = query.Where(d => IDs.Contains(d.IDIndustry));
////                    query = query.Where(d => IDs.Contains(d.IDIndustry));
//                    
            }

			//Query IDSector (Nullable<int>)
			if (QueryStrings.Any(d => d.Key == "IDSector"))
            {
                var IDList = QueryStrings.FirstOrDefault(d => d.Key == "IDSector").Value.Replace("[", "").Replace("]", "").Split(',');
                List<int?> IDs = new List<int?>();
                foreach (var item in IDList)
                    if (int.TryParse(item, out int i))
                        IDs.Add(i);
					else if (item == "null")
						IDs.Add(null);
                if (IDs.Count > 0)
                    query = query.Where(d => IDs.Contains(d.IDSector));
////                    query = query.Where(d => IDs.Contains(d.IDSector));
//                    
            }

			//Query IDCountry (Nullable<int>)
			if (QueryStrings.Any(d => d.Key == "IDCountry"))
            {
                var IDList = QueryStrings.FirstOrDefault(d => d.Key == "IDCountry").Value.Replace("[", "").Replace("]", "").Split(',');
                List<int?> IDs = new List<int?>();
                foreach (var item in IDList)
                    if (int.TryParse(item, out int i))
                        IDs.Add(i);
					else if (item == "null")
						IDs.Add(null);
                if (IDs.Count > 0)
                    query = query.Where(d => IDs.Contains(d.IDCountry));
////                    query = query.Where(d => IDs.Contains(d.IDCountry));
//                    
            }

			//Query IDCity (Nullable<int>)
			if (QueryStrings.Any(d => d.Key == "IDCity"))
            {
                var IDList = QueryStrings.FirstOrDefault(d => d.Key == "IDCity").Value.Replace("[", "").Replace("]", "").Split(',');
                List<int?> IDs = new List<int?>();
                foreach (var item in IDList)
                    if (int.TryParse(item, out int i))
                        IDs.Add(i);
					else if (item == "null")
						IDs.Add(null);
                if (IDs.Count > 0)
                    query = query.Where(d => IDs.Contains(d.IDCity));
////                    query = query.Where(d => IDs.Contains(d.IDCity));
//                    
            }

			//Query IDProvince (Nullable<int>)
			if (QueryStrings.Any(d => d.Key == "IDProvince"))
            {
                var IDList = QueryStrings.FirstOrDefault(d => d.Key == "IDProvince").Value.Replace("[", "").Replace("]", "").Split(',');
                List<int?> IDs = new List<int?>();
                foreach (var item in IDList)
                    if (int.TryParse(item, out int i))
                        IDs.Add(i);
					else if (item == "null")
						IDs.Add(null);
                if (IDs.Count > 0)
                    query = query.Where(d => IDs.Contains(d.IDProvince));
////                    query = query.Where(d => IDs.Contains(d.IDProvince));
//                    
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
            

			//Query Individual (string)
			if (QueryStrings.Any(d => d.Key == "Individual_eq") && !string.IsNullOrEmpty(QueryStrings.FirstOrDefault(d => d.Key == "Individual_eq").Value))
            {
                var keyword = QueryStrings.FirstOrDefault(d => d.Key == "Individual_eq").Value;
                query = query.Where(d=>d.Individual == keyword);
            }
            if (QueryStrings.Any(d => d.Key == "Individual") && !string.IsNullOrEmpty(QueryStrings.FirstOrDefault(d => d.Key == "Individual").Value))
            {
                var keyword = QueryStrings.FirstOrDefault(d => d.Key == "Individual").Value;
                query = query.Where(d=>d.Individual.Contains(keyword));
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
            

			//Query Company (string)
			if (QueryStrings.Any(d => d.Key == "Company_eq") && !string.IsNullOrEmpty(QueryStrings.FirstOrDefault(d => d.Key == "Company_eq").Value))
            {
                var keyword = QueryStrings.FirstOrDefault(d => d.Key == "Company_eq").Value;
                query = query.Where(d=>d.Company == keyword);
            }
            if (QueryStrings.Any(d => d.Key == "Company") && !string.IsNullOrEmpty(QueryStrings.FirstOrDefault(d => d.Key == "Company").Value))
            {
                var keyword = QueryStrings.FirstOrDefault(d => d.Key == "Company").Value;
                query = query.Where(d=>d.Company.Contains(keyword));
            }
            

			//Query Title (string)
			if (QueryStrings.Any(d => d.Key == "Title_eq") && !string.IsNullOrEmpty(QueryStrings.FirstOrDefault(d => d.Key == "Title_eq").Value))
            {
                var keyword = QueryStrings.FirstOrDefault(d => d.Key == "Title_eq").Value;
                query = query.Where(d=>d.Title == keyword);
            }
            if (QueryStrings.Any(d => d.Key == "Title") && !string.IsNullOrEmpty(QueryStrings.FirstOrDefault(d => d.Key == "Title").Value))
            {
                var keyword = QueryStrings.FirstOrDefault(d => d.Key == "Title").Value;
                query = query.Where(d=>d.Title.Contains(keyword));
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
            

			//Query Address (string)
			if (QueryStrings.Any(d => d.Key == "Address_eq") && !string.IsNullOrEmpty(QueryStrings.FirstOrDefault(d => d.Key == "Address_eq").Value))
            {
                var keyword = QueryStrings.FirstOrDefault(d => d.Key == "Address_eq").Value;
                query = query.Where(d=>d.Address == keyword);
            }
            if (QueryStrings.Any(d => d.Key == "Address") && !string.IsNullOrEmpty(QueryStrings.FirstOrDefault(d => d.Key == "Address").Value))
            {
                var keyword = QueryStrings.FirstOrDefault(d => d.Key == "Address").Value;
                query = query.Where(d=>d.Address.Contains(keyword));
            }
            

			//Query Street (string)
			if (QueryStrings.Any(d => d.Key == "Street_eq") && !string.IsNullOrEmpty(QueryStrings.FirstOrDefault(d => d.Key == "Street_eq").Value))
            {
                var keyword = QueryStrings.FirstOrDefault(d => d.Key == "Street_eq").Value;
                query = query.Where(d=>d.Street == keyword);
            }
            if (QueryStrings.Any(d => d.Key == "Street") && !string.IsNullOrEmpty(QueryStrings.FirstOrDefault(d => d.Key == "Street").Value))
            {
                var keyword = QueryStrings.FirstOrDefault(d => d.Key == "Street").Value;
                query = query.Where(d=>d.Street.Contains(keyword));
            }
            

			//Query ZipCode (string)
			if (QueryStrings.Any(d => d.Key == "ZipCode_eq") && !string.IsNullOrEmpty(QueryStrings.FirstOrDefault(d => d.Key == "ZipCode_eq").Value))
            {
                var keyword = QueryStrings.FirstOrDefault(d => d.Key == "ZipCode_eq").Value;
                query = query.Where(d=>d.ZipCode == keyword);
            }
            if (QueryStrings.Any(d => d.Key == "ZipCode") && !string.IsNullOrEmpty(QueryStrings.FirstOrDefault(d => d.Key == "ZipCode").Value))
            {
                var keyword = QueryStrings.FirstOrDefault(d => d.Key == "ZipCode").Value;
                query = query.Where(d=>d.ZipCode.Contains(keyword));
            }
            

			//Query AnnualRevenue (decimal)
			if (QueryStrings.Any(d => d.Key == "AnnualRevenueFrom") && QueryStrings.Any(d => d.Key == "AnnualRevenueTo"))
                if (decimal.TryParse(QueryStrings.FirstOrDefault(d => d.Key == "AnnualRevenueFrom").Value, out decimal fromVal) && decimal.TryParse(QueryStrings.FirstOrDefault(d => d.Key == "AnnualRevenueTo").Value, out decimal toVal))
                    query = query.Where(d => fromVal <= d.AnnualRevenue && d.AnnualRevenue <= toVal);
            
            if (QueryStrings.Any(d => d.Key == "AnnualRevenue"))
                if (decimal.TryParse(QueryStrings.FirstOrDefault(d => d.Key == "AnnualRevenue").Value, out decimal val))
                    query = query.Where(d => val == d.AnnualRevenue);


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
            

			//Query HasOptedOutOfEmail (bool)
			if (QueryStrings.Any(d => d.Key == "HasOptedOutOfEmail"))
            {
                var qValue = QueryStrings.FirstOrDefault(d => d.Key == "HasOptedOutOfEmail").Value;
                if (bool.TryParse(qValue, out bool qBoolValue))
                    query = query.Where(d => qBoolValue == d.HasOptedOutOfEmail);
            }

			//Query Phone (string)
			if (QueryStrings.Any(d => d.Key == "Phone_eq") && !string.IsNullOrEmpty(QueryStrings.FirstOrDefault(d => d.Key == "Phone_eq").Value))
            {
                var keyword = QueryStrings.FirstOrDefault(d => d.Key == "Phone_eq").Value;
                query = query.Where(d=>d.Phone == keyword);
            }
            if (QueryStrings.Any(d => d.Key == "Phone") && !string.IsNullOrEmpty(QueryStrings.FirstOrDefault(d => d.Key == "Phone").Value))
            {
                var keyword = QueryStrings.FirstOrDefault(d => d.Key == "Phone").Value;
                query = query.Where(d=>d.Phone.Contains(keyword));
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
            

			//Query DoNotCall (bool)
			if (QueryStrings.Any(d => d.Key == "DoNotCall"))
            {
                var qValue = QueryStrings.FirstOrDefault(d => d.Key == "DoNotCall").Value;
                if (bool.TryParse(qValue, out bool qBoolValue))
                    query = query.Where(d => qBoolValue == d.DoNotCall);
            }

			//Query Fax (string)
			if (QueryStrings.Any(d => d.Key == "Fax_eq") && !string.IsNullOrEmpty(QueryStrings.FirstOrDefault(d => d.Key == "Fax_eq").Value))
            {
                var keyword = QueryStrings.FirstOrDefault(d => d.Key == "Fax_eq").Value;
                query = query.Where(d=>d.Fax == keyword);
            }
            if (QueryStrings.Any(d => d.Key == "Fax") && !string.IsNullOrEmpty(QueryStrings.FirstOrDefault(d => d.Key == "Fax").Value))
            {
                var keyword = QueryStrings.FirstOrDefault(d => d.Key == "Fax").Value;
                query = query.Where(d=>d.Fax.Contains(keyword));
            }
            

			//Query HasOptedOutOfFax (bool)
			if (QueryStrings.Any(d => d.Key == "HasOptedOutOfFax"))
            {
                var qValue = QueryStrings.FirstOrDefault(d => d.Key == "HasOptedOutOfFax").Value;
                if (bool.TryParse(qValue, out bool qBoolValue))
                    query = query.Where(d => qBoolValue == d.HasOptedOutOfFax);
            }

			//Query NumberOfEmployees (Nullable<int>)
			if (QueryStrings.Any(d => d.Key == "NumberOfEmployeesFrom") && QueryStrings.Any(d => d.Key == "NumberOfEmployeesTo"))
                if (int.TryParse(QueryStrings.FirstOrDefault(d => d.Key == "NumberOfEmployeesFrom").Value, out int fromVal) && int.TryParse(QueryStrings.FirstOrDefault(d => d.Key == "NumberOfEmployeesTo").Value, out int toVal))
                    query = query.Where(d => fromVal <= d.NumberOfEmployees && d.NumberOfEmployees <= toVal);

			//Query Website (string)
			if (QueryStrings.Any(d => d.Key == "Website_eq") && !string.IsNullOrEmpty(QueryStrings.FirstOrDefault(d => d.Key == "Website_eq").Value))
            {
                var keyword = QueryStrings.FirstOrDefault(d => d.Key == "Website_eq").Value;
                query = query.Where(d=>d.Website == keyword);
            }
            if (QueryStrings.Any(d => d.Key == "Website") && !string.IsNullOrEmpty(QueryStrings.FirstOrDefault(d => d.Key == "Website").Value))
            {
                var keyword = QueryStrings.FirstOrDefault(d => d.Key == "Website").Value;
                query = query.Where(d=>d.Website.Contains(keyword));
            }
            

			//Query LastTransferDate (Nullable<System.DateTime>)
			if (QueryStrings.Any(d => d.Key == "LastTransferDateFrom") && QueryStrings.Any(d => d.Key == "LastTransferDateTo"))
                if (DateTime.TryParse(QueryStrings.FirstOrDefault(d => d.Key == "LastTransferDateFrom").Value, out DateTime fromDate) && DateTime.TryParse(QueryStrings.FirstOrDefault(d => d.Key == "LastTransferDateTo").Value, out DateTime toDate))
                    query = query.Where(d => fromDate <= d.LastTransferDate && d.LastTransferDate <= toDate);

            if (QueryStrings.Any(d => d.Key == "LastTransferDate"))
                if (DateTime.TryParse(QueryStrings.FirstOrDefault(d => d.Key == "LastTransferDate").Value, out DateTime val))
                    query = query.Where(d => d.LastTransferDate != null && DbFunctions.TruncateTime(val) == DbFunctions.TruncateTime(d.LastTransferDate));


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
		
        public static IQueryable<tbl_CRM_Lead> _sortBuilder(IQueryable<tbl_CRM_Lead> query, Dictionary<string, string> QueryStrings)
        {
            if (QueryStrings.Any(d => d.Key == "SortBy"))
            {
                var sorts = QueryStrings.FirstOrDefault(d => d.Key == "SortBy").Value.Replace("[", "").Replace("]", "").Split(',');
                
                foreach (var item in sorts)
                    if (!string.IsNullOrEmpty(item))
                    {
                        var ordered = query as IOrderedQueryable<tbl_CRM_Lead>;
                        bool isOrdered = ordered.ToString().IndexOf("ORDER BY") !=-1;

                        switch (item)
                        {
							case "IDCampaign":
								query = isOrdered ? ordered.ThenBy(o => o.IDCampaign) : query.OrderBy(o => o.IDCampaign);
								 break;
							case "IDCampaign_desc":
                                query = isOrdered ? ordered.ThenByDescending(o => o.IDCampaign) : query.OrderByDescending(o => o.IDCampaign);
                                break;
							case "IDOwner":
								query = isOrdered ? ordered.ThenBy(o => o.IDOwner) : query.OrderBy(o => o.IDOwner);
								 break;
							case "IDOwner_desc":
                                query = isOrdered ? ordered.ThenByDescending(o => o.IDOwner) : query.OrderByDescending(o => o.IDOwner);
                                break;
							case "IDStatus":
								query = isOrdered ? ordered.ThenBy(o => o.IDStatus) : query.OrderBy(o => o.IDStatus);
								 break;
							case "IDStatus_desc":
                                query = isOrdered ? ordered.ThenByDescending(o => o.IDStatus) : query.OrderByDescending(o => o.IDStatus);
                                break;
							case "IDRating":
								query = isOrdered ? ordered.ThenBy(o => o.IDRating) : query.OrderBy(o => o.IDRating);
								 break;
							case "IDRating_desc":
                                query = isOrdered ? ordered.ThenByDescending(o => o.IDRating) : query.OrderByDescending(o => o.IDRating);
                                break;
							case "IDSource":
								query = isOrdered ? ordered.ThenBy(o => o.IDSource) : query.OrderBy(o => o.IDSource);
								 break;
							case "IDSource_desc":
                                query = isOrdered ? ordered.ThenByDescending(o => o.IDSource) : query.OrderByDescending(o => o.IDSource);
                                break;
							case "IDIndustry":
								query = isOrdered ? ordered.ThenBy(o => o.IDIndustry) : query.OrderBy(o => o.IDIndustry);
								 break;
							case "IDIndustry_desc":
                                query = isOrdered ? ordered.ThenByDescending(o => o.IDIndustry) : query.OrderByDescending(o => o.IDIndustry);
                                break;
							case "IDSector":
								query = isOrdered ? ordered.ThenBy(o => o.IDSector) : query.OrderBy(o => o.IDSector);
								 break;
							case "IDSector_desc":
                                query = isOrdered ? ordered.ThenByDescending(o => o.IDSector) : query.OrderByDescending(o => o.IDSector);
                                break;
							case "IDCountry":
								query = isOrdered ? ordered.ThenBy(o => o.IDCountry) : query.OrderBy(o => o.IDCountry);
								 break;
							case "IDCountry_desc":
                                query = isOrdered ? ordered.ThenByDescending(o => o.IDCountry) : query.OrderByDescending(o => o.IDCountry);
                                break;
							case "IDCity":
								query = isOrdered ? ordered.ThenBy(o => o.IDCity) : query.OrderBy(o => o.IDCity);
								 break;
							case "IDCity_desc":
                                query = isOrdered ? ordered.ThenByDescending(o => o.IDCity) : query.OrderByDescending(o => o.IDCity);
                                break;
							case "IDProvince":
								query = isOrdered ? ordered.ThenBy(o => o.IDProvince) : query.OrderBy(o => o.IDProvince);
								 break;
							case "IDProvince_desc":
                                query = isOrdered ? ordered.ThenByDescending(o => o.IDProvince) : query.OrderByDescending(o => o.IDProvince);
                                break;
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
							case "Code":
								query = isOrdered ? ordered.ThenBy(o => o.Code) : query.OrderBy(o => o.Code);
								 break;
							case "Code_desc":
                                query = isOrdered ? ordered.ThenByDescending(o => o.Code) : query.OrderByDescending(o => o.Code);
                                break;
							case "Individual":
								query = isOrdered ? ordered.ThenBy(o => o.Individual) : query.OrderBy(o => o.Individual);
								 break;
							case "Individual_desc":
                                query = isOrdered ? ordered.ThenByDescending(o => o.Individual) : query.OrderByDescending(o => o.Individual);
                                break;
							case "Name":
								query = isOrdered ? ordered.ThenBy(o => o.Name) : query.OrderBy(o => o.Name);
								 break;
							case "Name_desc":
                                query = isOrdered ? ordered.ThenByDescending(o => o.Name) : query.OrderByDescending(o => o.Name);
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
							case "Company":
								query = isOrdered ? ordered.ThenBy(o => o.Company) : query.OrderBy(o => o.Company);
								 break;
							case "Company_desc":
                                query = isOrdered ? ordered.ThenByDescending(o => o.Company) : query.OrderByDescending(o => o.Company);
                                break;
							case "Title":
								query = isOrdered ? ordered.ThenBy(o => o.Title) : query.OrderBy(o => o.Title);
								 break;
							case "Title_desc":
                                query = isOrdered ? ordered.ThenByDescending(o => o.Title) : query.OrderByDescending(o => o.Title);
                                break;
							case "Remark":
								query = isOrdered ? ordered.ThenBy(o => o.Remark) : query.OrderBy(o => o.Remark);
								 break;
							case "Remark_desc":
                                query = isOrdered ? ordered.ThenByDescending(o => o.Remark) : query.OrderByDescending(o => o.Remark);
                                break;
							case "Address":
								query = isOrdered ? ordered.ThenBy(o => o.Address) : query.OrderBy(o => o.Address);
								 break;
							case "Address_desc":
                                query = isOrdered ? ordered.ThenByDescending(o => o.Address) : query.OrderByDescending(o => o.Address);
                                break;
							case "Street":
								query = isOrdered ? ordered.ThenBy(o => o.Street) : query.OrderBy(o => o.Street);
								 break;
							case "Street_desc":
                                query = isOrdered ? ordered.ThenByDescending(o => o.Street) : query.OrderByDescending(o => o.Street);
                                break;
							case "ZipCode":
								query = isOrdered ? ordered.ThenBy(o => o.ZipCode) : query.OrderBy(o => o.ZipCode);
								 break;
							case "ZipCode_desc":
                                query = isOrdered ? ordered.ThenByDescending(o => o.ZipCode) : query.OrderByDescending(o => o.ZipCode);
                                break;
							case "AnnualRevenue":
								query = isOrdered ? ordered.ThenBy(o => o.AnnualRevenue) : query.OrderBy(o => o.AnnualRevenue);
								 break;
							case "AnnualRevenue_desc":
                                query = isOrdered ? ordered.ThenByDescending(o => o.AnnualRevenue) : query.OrderByDescending(o => o.AnnualRevenue);
                                break;
							case "Email":
								query = isOrdered ? ordered.ThenBy(o => o.Email) : query.OrderBy(o => o.Email);
								 break;
							case "Email_desc":
                                query = isOrdered ? ordered.ThenByDescending(o => o.Email) : query.OrderByDescending(o => o.Email);
                                break;
							case "HasOptedOutOfEmail":
								query = isOrdered ? ordered.ThenBy(o => o.HasOptedOutOfEmail) : query.OrderBy(o => o.HasOptedOutOfEmail);
								 break;
							case "HasOptedOutOfEmail_desc":
                                query = isOrdered ? ordered.ThenByDescending(o => o.HasOptedOutOfEmail) : query.OrderByDescending(o => o.HasOptedOutOfEmail);
                                break;
							case "Phone":
								query = isOrdered ? ordered.ThenBy(o => o.Phone) : query.OrderBy(o => o.Phone);
								 break;
							case "Phone_desc":
                                query = isOrdered ? ordered.ThenByDescending(o => o.Phone) : query.OrderByDescending(o => o.Phone);
                                break;
							case "MobilePhone":
								query = isOrdered ? ordered.ThenBy(o => o.MobilePhone) : query.OrderBy(o => o.MobilePhone);
								 break;
							case "MobilePhone_desc":
                                query = isOrdered ? ordered.ThenByDescending(o => o.MobilePhone) : query.OrderByDescending(o => o.MobilePhone);
                                break;
							case "DoNotCall":
								query = isOrdered ? ordered.ThenBy(o => o.DoNotCall) : query.OrderBy(o => o.DoNotCall);
								 break;
							case "DoNotCall_desc":
                                query = isOrdered ? ordered.ThenByDescending(o => o.DoNotCall) : query.OrderByDescending(o => o.DoNotCall);
                                break;
							case "Fax":
								query = isOrdered ? ordered.ThenBy(o => o.Fax) : query.OrderBy(o => o.Fax);
								 break;
							case "Fax_desc":
                                query = isOrdered ? ordered.ThenByDescending(o => o.Fax) : query.OrderByDescending(o => o.Fax);
                                break;
							case "HasOptedOutOfFax":
								query = isOrdered ? ordered.ThenBy(o => o.HasOptedOutOfFax) : query.OrderBy(o => o.HasOptedOutOfFax);
								 break;
							case "HasOptedOutOfFax_desc":
                                query = isOrdered ? ordered.ThenByDescending(o => o.HasOptedOutOfFax) : query.OrderByDescending(o => o.HasOptedOutOfFax);
                                break;
							case "NumberOfEmployees":
								query = isOrdered ? ordered.ThenBy(o => o.NumberOfEmployees) : query.OrderBy(o => o.NumberOfEmployees);
								 break;
							case "NumberOfEmployees_desc":
                                query = isOrdered ? ordered.ThenByDescending(o => o.NumberOfEmployees) : query.OrderByDescending(o => o.NumberOfEmployees);
                                break;
							case "Website":
								query = isOrdered ? ordered.ThenBy(o => o.Website) : query.OrderBy(o => o.Website);
								 break;
							case "Website_desc":
                                query = isOrdered ? ordered.ThenByDescending(o => o.Website) : query.OrderByDescending(o => o.Website);
                                break;
							case "LastTransferDate":
								query = isOrdered ? ordered.ThenBy(o => o.LastTransferDate) : query.OrderBy(o => o.LastTransferDate);
								 break;
							case "LastTransferDate_desc":
                                query = isOrdered ? ordered.ThenByDescending(o => o.LastTransferDate) : query.OrderByDescending(o => o.LastTransferDate);
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

        public static IQueryable<tbl_CRM_Lead> _pagingBuilder(IQueryable<tbl_CRM_Lead> query, Dictionary<string, string> QueryStrings)
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






