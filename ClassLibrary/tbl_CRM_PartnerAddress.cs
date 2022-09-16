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
    
    
    public partial class tbl_CRM_PartnerAddress
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public tbl_CRM_PartnerAddress()
        {
            this.tbl_SALE_Order = new HashSet<tbl_SALE_Order>();
        }
    
        public int IDPartner { get; set; }
        public int Id { get; set; }
        public string Country { get; set; }
        public string Province { get; set; }
        public string District { get; set; }
        public string Ward { get; set; }
        public string AddressLine1 { get; set; }
        public string AddressLine2 { get; set; }
        public string ZipCode { get; set; }
        public string Lat { get; set; }
        public string Long { get; set; }
        public string Remark { get; set; }
        public string Contact { get; set; }
        public string Phone1 { get; set; }
        public string Phone2 { get; set; }
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
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tbl_SALE_Order> tbl_SALE_Order { get; set; }
    }
}


namespace DTOModel
{
	using System;
	public partial class DTO_CRM_PartnerAddress
	{
		public int IDPartner { get; set; }
		public int Id { get; set; }
		public string Country { get; set; }
		public string Province { get; set; }
		public string District { get; set; }
		public string Ward { get; set; }
		public string AddressLine1 { get; set; }
		public string AddressLine2 { get; set; }
		public string ZipCode { get; set; }
		public string Lat { get; set; }
		public string Long { get; set; }
		public string Remark { get; set; }
		public string Contact { get; set; }
		public string Phone1 { get; set; }
		public string Phone2 { get; set; }
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

    public static partial class BS_CRM_PartnerAddress 
    {
        public static dynamic getSearch(AppEntities db, int IDBranch, int StaffID, Dictionary<string, string> QueryStrings)
        {
            return get(db, IDBranch,StaffID, QueryStrings);
        }

		public static IQueryable<DTO_CRM_PartnerAddress> get(AppEntities db, int IDBranch, int StaffID, Dictionary<string, string> QueryStrings)
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
            package.Workbook.Properties.Title = "ART-DMS CRM_PartnerAddress";
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

		public static DTO_CRM_PartnerAddress getAnItem(AppEntities db, int IDBranch, int StaffID, int id)
        {
            var dbResult = db.tbl_CRM_PartnerAddress.Find(id);

			return toDTO(dbResult);
			
        }
		

		public static bool put(AppEntities db, int IDBranch, int StaffID, int Id, dynamic item, string Username, Dictionary<string, string> QueryStrings)
        {
            bool result = false;
            var dbitem = db.tbl_CRM_PartnerAddress.Find(Id);
            
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
					errorLog.logMessage("put_CRM_PartnerAddress",e);
                    result = false;
                }
            }
            else
                if (QueryStrings.Any(d => d.Key == "ForceCreate"))
                    result =  post(db, IDBranch, StaffID, item, Username) != null;
                
            return result;
        }

        public static void patchDynamicToDB(dynamic item, tbl_CRM_PartnerAddress dbitem, string Username)
        {
            Type type = typeof(tbl_CRM_PartnerAddress);
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

        public static void patchDTOtoDBValue( DTO_CRM_PartnerAddress item, tbl_CRM_PartnerAddress dbitem)
        {
            if (item == null){
                dbitem = null;
                return;
            }
            							
			dbitem.IDPartner = item.IDPartner;							
			dbitem.Country = item.Country;							
			dbitem.Province = item.Province;							
			dbitem.District = item.District;							
			dbitem.Ward = item.Ward;							
			dbitem.AddressLine1 = item.AddressLine1;							
			dbitem.AddressLine2 = item.AddressLine2;							
			dbitem.ZipCode = item.ZipCode;							
			dbitem.Lat = item.Lat;							
			dbitem.Long = item.Long;							
			dbitem.Remark = item.Remark;							
			dbitem.Contact = item.Contact;							
			dbitem.Phone1 = item.Phone1;							
			dbitem.Phone2 = item.Phone2;							
			dbitem.Sort = item.Sort;							
			dbitem.IsDisabled = item.IsDisabled;							
			dbitem.IsDeleted = item.IsDeleted;							
			dbitem.Name = item.Name;        }

		public static DTO_CRM_PartnerAddress post(AppEntities db, int IDBranch, int StaffID, dynamic item, string Username)
        {
            tbl_CRM_PartnerAddress dbitem = new tbl_CRM_PartnerAddress();
            if (item != null)
            {
                patchDynamicToDB(item, dbitem, Username);
                
				dbitem.CreatedBy = Username;
				dbitem.CreatedDate = DateTime.Now;				
                try
                {
					db.tbl_CRM_PartnerAddress.Add(dbitem);
                    db.SaveChanges();
				
                }
                catch (DbEntityValidationException e)
                {
					errorLog.logMessage("post_CRM_PartnerAddress",e);
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
                Type type = Type.GetType("BaseBusiness.BS_CRM_PartnerAddress, ClassLibrary");
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
                        var target = new tbl_CRM_PartnerAddress();
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
                    
                    tbl_CRM_PartnerAddress dbitem = new tbl_CRM_PartnerAddress();
                    if (it.Id == null || string.IsNullOrEmpty(it.Id.Value) || it.Id == "0")
                    {
                        dbitem = new tbl_CRM_PartnerAddress();
                        dbitem.CreatedBy = Username;
				        dbitem.CreatedDate = DateTime.Now;
                                            }
                    else
                    {
                        dbitem = db.tbl_CRM_PartnerAddress.Find((int)it.Id);
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
                        
                        if (dbitem.Id == 0) db.tbl_CRM_PartnerAddress.Add(dbitem);
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
                    errorLog.logMessage("post_CRM_PartnerAddress",e);
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

            var dbitems = db.tbl_CRM_PartnerAddress.Where(d => IDs.Contains(d.Id));
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
			
                BS_Version.update_Version(db, null, "DTO_CRM_PartnerAddress", updateDate, Username);
			
            }
            catch (DbEntityValidationException e)
            {
				errorLog.logMessage("delete_CRM_PartnerAddress",e);
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

			
            var dbitems = db.tbl_CRM_PartnerAddress.Where(d => IDs.Contains(d.Id));
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
			
                BS_Version.update_Version(db, null, "DTO_CRM_PartnerAddress", updateDate, Username);
			
            }
            catch (DbEntityValidationException e)
            {
				errorLog.logMessage("disable_CRM_PartnerAddress",e);
                result = false;
            }
            
            return result;
        }

		
		//---//
		public static bool check_Exists(AppEntities db, int id)
		{
             
            return db.tbl_CRM_PartnerAddress.Any(e => e.Id == id && e.IsDeleted == false);
            
		}
		
		//---//
		public static IQueryable<DTO_CRM_PartnerAddress> toDTO(IQueryable<tbl_CRM_PartnerAddress> query)
        {
			return query
			.Select(s => new DTO_CRM_PartnerAddress(){							
				IDPartner = s.IDPartner,							
				Id = s.Id,							
				Country = s.Country,							
				Province = s.Province,							
				District = s.District,							
				Ward = s.Ward,							
				AddressLine1 = s.AddressLine1,							
				AddressLine2 = s.AddressLine2,							
				ZipCode = s.ZipCode,							
				Lat = s.Lat,							
				Long = s.Long,							
				Remark = s.Remark,							
				Contact = s.Contact,							
				Phone1 = s.Phone1,							
				Phone2 = s.Phone2,							
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

		public static DTO_CRM_PartnerAddress toDTO(tbl_CRM_PartnerAddress dbResult)
        {
			if (dbResult != null)
			{
				return new DTO_CRM_PartnerAddress()
				{							
					IDPartner = dbResult.IDPartner,							
					Id = dbResult.Id,							
					Country = dbResult.Country,							
					Province = dbResult.Province,							
					District = dbResult.District,							
					Ward = dbResult.Ward,							
					AddressLine1 = dbResult.AddressLine1,							
					AddressLine2 = dbResult.AddressLine2,							
					ZipCode = dbResult.ZipCode,							
					Lat = dbResult.Lat,							
					Long = dbResult.Long,							
					Remark = dbResult.Remark,							
					Contact = dbResult.Contact,							
					Phone1 = dbResult.Phone1,							
					Phone2 = dbResult.Phone2,							
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

		public static IQueryable<tbl_CRM_PartnerAddress> _queryBuilder(AppEntities db, int IDBranch, int StaffID, Dictionary<string, string> QueryStrings)
        {
            
			IQueryable<tbl_CRM_PartnerAddress> query = db.tbl_CRM_PartnerAddress.AsNoTracking();//.Where(d => d.IsDeleted == false );
			

			//Query keyword
			if (QueryStrings.Any(d => d.Key == "Keyword") && !string.IsNullOrEmpty(QueryStrings.FirstOrDefault(d => d.Key == "Keyword").Value))
            {
                var keyword = QueryStrings.FirstOrDefault(d => d.Key == "Keyword").Value;
                query = query.Where(d=>d.Name.Contains(keyword));
            }



			//Query IDPartner (int)
			if (QueryStrings.Any(d => d.Key == "IDPartner"))
            {
                var IDList = QueryStrings.FirstOrDefault(d => d.Key == "IDPartner").Value.Replace("[", "").Replace("]", "").Split(',');
                List<int> IDs = new List<int>();
                foreach (var item in IDList)
                    if (int.TryParse(item, out int i))
                        IDs.Add(i);
                if (IDs.Count > 0)
                    query = query.Where(d => IDs.Contains(d.IDPartner));
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

			//Query Country (string)
			if (QueryStrings.Any(d => d.Key == "Country_eq") && !string.IsNullOrEmpty(QueryStrings.FirstOrDefault(d => d.Key == "Country_eq").Value))
            {
                var keyword = QueryStrings.FirstOrDefault(d => d.Key == "Country_eq").Value;
                query = query.Where(d=>d.Country == keyword);
            }
            if (QueryStrings.Any(d => d.Key == "Country") && !string.IsNullOrEmpty(QueryStrings.FirstOrDefault(d => d.Key == "Country").Value))
            {
                var keyword = QueryStrings.FirstOrDefault(d => d.Key == "Country").Value;
                query = query.Where(d=>d.Country.Contains(keyword));
            }
            

			//Query Province (string)
			if (QueryStrings.Any(d => d.Key == "Province_eq") && !string.IsNullOrEmpty(QueryStrings.FirstOrDefault(d => d.Key == "Province_eq").Value))
            {
                var keyword = QueryStrings.FirstOrDefault(d => d.Key == "Province_eq").Value;
                query = query.Where(d=>d.Province == keyword);
            }
            if (QueryStrings.Any(d => d.Key == "Province") && !string.IsNullOrEmpty(QueryStrings.FirstOrDefault(d => d.Key == "Province").Value))
            {
                var keyword = QueryStrings.FirstOrDefault(d => d.Key == "Province").Value;
                query = query.Where(d=>d.Province.Contains(keyword));
            }
            

			//Query District (string)
			if (QueryStrings.Any(d => d.Key == "District_eq") && !string.IsNullOrEmpty(QueryStrings.FirstOrDefault(d => d.Key == "District_eq").Value))
            {
                var keyword = QueryStrings.FirstOrDefault(d => d.Key == "District_eq").Value;
                query = query.Where(d=>d.District == keyword);
            }
            if (QueryStrings.Any(d => d.Key == "District") && !string.IsNullOrEmpty(QueryStrings.FirstOrDefault(d => d.Key == "District").Value))
            {
                var keyword = QueryStrings.FirstOrDefault(d => d.Key == "District").Value;
                query = query.Where(d=>d.District.Contains(keyword));
            }
            

			//Query Ward (string)
			if (QueryStrings.Any(d => d.Key == "Ward_eq") && !string.IsNullOrEmpty(QueryStrings.FirstOrDefault(d => d.Key == "Ward_eq").Value))
            {
                var keyword = QueryStrings.FirstOrDefault(d => d.Key == "Ward_eq").Value;
                query = query.Where(d=>d.Ward == keyword);
            }
            if (QueryStrings.Any(d => d.Key == "Ward") && !string.IsNullOrEmpty(QueryStrings.FirstOrDefault(d => d.Key == "Ward").Value))
            {
                var keyword = QueryStrings.FirstOrDefault(d => d.Key == "Ward").Value;
                query = query.Where(d=>d.Ward.Contains(keyword));
            }
            

			//Query AddressLine1 (string)
			if (QueryStrings.Any(d => d.Key == "AddressLine1_eq") && !string.IsNullOrEmpty(QueryStrings.FirstOrDefault(d => d.Key == "AddressLine1_eq").Value))
            {
                var keyword = QueryStrings.FirstOrDefault(d => d.Key == "AddressLine1_eq").Value;
                query = query.Where(d=>d.AddressLine1 == keyword);
            }
            if (QueryStrings.Any(d => d.Key == "AddressLine1") && !string.IsNullOrEmpty(QueryStrings.FirstOrDefault(d => d.Key == "AddressLine1").Value))
            {
                var keyword = QueryStrings.FirstOrDefault(d => d.Key == "AddressLine1").Value;
                query = query.Where(d=>d.AddressLine1.Contains(keyword));
            }
            

			//Query AddressLine2 (string)
			if (QueryStrings.Any(d => d.Key == "AddressLine2_eq") && !string.IsNullOrEmpty(QueryStrings.FirstOrDefault(d => d.Key == "AddressLine2_eq").Value))
            {
                var keyword = QueryStrings.FirstOrDefault(d => d.Key == "AddressLine2_eq").Value;
                query = query.Where(d=>d.AddressLine2 == keyword);
            }
            if (QueryStrings.Any(d => d.Key == "AddressLine2") && !string.IsNullOrEmpty(QueryStrings.FirstOrDefault(d => d.Key == "AddressLine2").Value))
            {
                var keyword = QueryStrings.FirstOrDefault(d => d.Key == "AddressLine2").Value;
                query = query.Where(d=>d.AddressLine2.Contains(keyword));
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
            

			//Query Lat (string)
			if (QueryStrings.Any(d => d.Key == "Lat_eq") && !string.IsNullOrEmpty(QueryStrings.FirstOrDefault(d => d.Key == "Lat_eq").Value))
            {
                var keyword = QueryStrings.FirstOrDefault(d => d.Key == "Lat_eq").Value;
                query = query.Where(d=>d.Lat == keyword);
            }
            if (QueryStrings.Any(d => d.Key == "Lat") && !string.IsNullOrEmpty(QueryStrings.FirstOrDefault(d => d.Key == "Lat").Value))
            {
                var keyword = QueryStrings.FirstOrDefault(d => d.Key == "Lat").Value;
                query = query.Where(d=>d.Lat.Contains(keyword));
            }
            

			//Query Long (string)
			if (QueryStrings.Any(d => d.Key == "Long_eq") && !string.IsNullOrEmpty(QueryStrings.FirstOrDefault(d => d.Key == "Long_eq").Value))
            {
                var keyword = QueryStrings.FirstOrDefault(d => d.Key == "Long_eq").Value;
                query = query.Where(d=>d.Long == keyword);
            }
            if (QueryStrings.Any(d => d.Key == "Long") && !string.IsNullOrEmpty(QueryStrings.FirstOrDefault(d => d.Key == "Long").Value))
            {
                var keyword = QueryStrings.FirstOrDefault(d => d.Key == "Long").Value;
                query = query.Where(d=>d.Long.Contains(keyword));
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
            

			//Query Contact (string)
			if (QueryStrings.Any(d => d.Key == "Contact_eq") && !string.IsNullOrEmpty(QueryStrings.FirstOrDefault(d => d.Key == "Contact_eq").Value))
            {
                var keyword = QueryStrings.FirstOrDefault(d => d.Key == "Contact_eq").Value;
                query = query.Where(d=>d.Contact == keyword);
            }
            if (QueryStrings.Any(d => d.Key == "Contact") && !string.IsNullOrEmpty(QueryStrings.FirstOrDefault(d => d.Key == "Contact").Value))
            {
                var keyword = QueryStrings.FirstOrDefault(d => d.Key == "Contact").Value;
                query = query.Where(d=>d.Contact.Contains(keyword));
            }
            

			//Query Phone1 (string)
			if (QueryStrings.Any(d => d.Key == "Phone1_eq") && !string.IsNullOrEmpty(QueryStrings.FirstOrDefault(d => d.Key == "Phone1_eq").Value))
            {
                var keyword = QueryStrings.FirstOrDefault(d => d.Key == "Phone1_eq").Value;
                query = query.Where(d=>d.Phone1 == keyword);
            }
            if (QueryStrings.Any(d => d.Key == "Phone1") && !string.IsNullOrEmpty(QueryStrings.FirstOrDefault(d => d.Key == "Phone1").Value))
            {
                var keyword = QueryStrings.FirstOrDefault(d => d.Key == "Phone1").Value;
                query = query.Where(d=>d.Phone1.Contains(keyword));
            }
            

			//Query Phone2 (string)
			if (QueryStrings.Any(d => d.Key == "Phone2_eq") && !string.IsNullOrEmpty(QueryStrings.FirstOrDefault(d => d.Key == "Phone2_eq").Value))
            {
                var keyword = QueryStrings.FirstOrDefault(d => d.Key == "Phone2_eq").Value;
                query = query.Where(d=>d.Phone2 == keyword);
            }
            if (QueryStrings.Any(d => d.Key == "Phone2") && !string.IsNullOrEmpty(QueryStrings.FirstOrDefault(d => d.Key == "Phone2").Value))
            {
                var keyword = QueryStrings.FirstOrDefault(d => d.Key == "Phone2").Value;
                query = query.Where(d=>d.Phone2.Contains(keyword));
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
		
        public static IQueryable<tbl_CRM_PartnerAddress> _sortBuilder(IQueryable<tbl_CRM_PartnerAddress> query, Dictionary<string, string> QueryStrings)
        {
            if (QueryStrings.Any(d => d.Key == "SortBy"))
            {
                var sorts = QueryStrings.FirstOrDefault(d => d.Key == "SortBy").Value.Replace("[", "").Replace("]", "").Split(',');
                
                foreach (var item in sorts)
                    if (!string.IsNullOrEmpty(item))
                    {
                        var ordered = query as IOrderedQueryable<tbl_CRM_PartnerAddress>;
                        bool isOrdered = ordered.ToString().IndexOf("ORDER BY") !=-1;

                        switch (item)
                        {
							case "IDPartner":
								query = isOrdered ? ordered.ThenBy(o => o.IDPartner) : query.OrderBy(o => o.IDPartner);
								 break;
							case "IDPartner_desc":
                                query = isOrdered ? ordered.ThenByDescending(o => o.IDPartner) : query.OrderByDescending(o => o.IDPartner);
                                break;
							case "Id":
								query = isOrdered ? ordered.ThenBy(o => o.Id) : query.OrderBy(o => o.Id);
								 break;
							case "Id_desc":
                                query = isOrdered ? ordered.ThenByDescending(o => o.Id) : query.OrderByDescending(o => o.Id);
                                break;
							case "Country":
								query = isOrdered ? ordered.ThenBy(o => o.Country) : query.OrderBy(o => o.Country);
								 break;
							case "Country_desc":
                                query = isOrdered ? ordered.ThenByDescending(o => o.Country) : query.OrderByDescending(o => o.Country);
                                break;
							case "Province":
								query = isOrdered ? ordered.ThenBy(o => o.Province) : query.OrderBy(o => o.Province);
								 break;
							case "Province_desc":
                                query = isOrdered ? ordered.ThenByDescending(o => o.Province) : query.OrderByDescending(o => o.Province);
                                break;
							case "District":
								query = isOrdered ? ordered.ThenBy(o => o.District) : query.OrderBy(o => o.District);
								 break;
							case "District_desc":
                                query = isOrdered ? ordered.ThenByDescending(o => o.District) : query.OrderByDescending(o => o.District);
                                break;
							case "Ward":
								query = isOrdered ? ordered.ThenBy(o => o.Ward) : query.OrderBy(o => o.Ward);
								 break;
							case "Ward_desc":
                                query = isOrdered ? ordered.ThenByDescending(o => o.Ward) : query.OrderByDescending(o => o.Ward);
                                break;
							case "AddressLine1":
								query = isOrdered ? ordered.ThenBy(o => o.AddressLine1) : query.OrderBy(o => o.AddressLine1);
								 break;
							case "AddressLine1_desc":
                                query = isOrdered ? ordered.ThenByDescending(o => o.AddressLine1) : query.OrderByDescending(o => o.AddressLine1);
                                break;
							case "AddressLine2":
								query = isOrdered ? ordered.ThenBy(o => o.AddressLine2) : query.OrderBy(o => o.AddressLine2);
								 break;
							case "AddressLine2_desc":
                                query = isOrdered ? ordered.ThenByDescending(o => o.AddressLine2) : query.OrderByDescending(o => o.AddressLine2);
                                break;
							case "ZipCode":
								query = isOrdered ? ordered.ThenBy(o => o.ZipCode) : query.OrderBy(o => o.ZipCode);
								 break;
							case "ZipCode_desc":
                                query = isOrdered ? ordered.ThenByDescending(o => o.ZipCode) : query.OrderByDescending(o => o.ZipCode);
                                break;
							case "Lat":
								query = isOrdered ? ordered.ThenBy(o => o.Lat) : query.OrderBy(o => o.Lat);
								 break;
							case "Lat_desc":
                                query = isOrdered ? ordered.ThenByDescending(o => o.Lat) : query.OrderByDescending(o => o.Lat);
                                break;
							case "Long":
								query = isOrdered ? ordered.ThenBy(o => o.Long) : query.OrderBy(o => o.Long);
								 break;
							case "Long_desc":
                                query = isOrdered ? ordered.ThenByDescending(o => o.Long) : query.OrderByDescending(o => o.Long);
                                break;
							case "Remark":
								query = isOrdered ? ordered.ThenBy(o => o.Remark) : query.OrderBy(o => o.Remark);
								 break;
							case "Remark_desc":
                                query = isOrdered ? ordered.ThenByDescending(o => o.Remark) : query.OrderByDescending(o => o.Remark);
                                break;
							case "Contact":
								query = isOrdered ? ordered.ThenBy(o => o.Contact) : query.OrderBy(o => o.Contact);
								 break;
							case "Contact_desc":
                                query = isOrdered ? ordered.ThenByDescending(o => o.Contact) : query.OrderByDescending(o => o.Contact);
                                break;
							case "Phone1":
								query = isOrdered ? ordered.ThenBy(o => o.Phone1) : query.OrderBy(o => o.Phone1);
								 break;
							case "Phone1_desc":
                                query = isOrdered ? ordered.ThenByDescending(o => o.Phone1) : query.OrderByDescending(o => o.Phone1);
                                break;
							case "Phone2":
								query = isOrdered ? ordered.ThenBy(o => o.Phone2) : query.OrderBy(o => o.Phone2);
								 break;
							case "Phone2_desc":
                                query = isOrdered ? ordered.ThenByDescending(o => o.Phone2) : query.OrderByDescending(o => o.Phone2);
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

        public static IQueryable<tbl_CRM_PartnerAddress> _pagingBuilder(IQueryable<tbl_CRM_PartnerAddress> query, Dictionary<string, string> QueryStrings)
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






