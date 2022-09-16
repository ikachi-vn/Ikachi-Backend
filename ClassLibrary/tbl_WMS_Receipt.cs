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
    
    
    public partial class tbl_WMS_Receipt
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public tbl_WMS_Receipt()
        {
            this.tbl_WMS_ReceiptDetail = new HashSet<tbl_WMS_ReceiptDetail>();
        }
    
        public int IDBranch { get; set; }
        public int IDStorer { get; set; }
        public Nullable<int> IDVendor { get; set; }
        public int Id { get; set; }
        public Nullable<int> IDPurchaseOrder { get; set; }
        public string POCode { get; set; }
        public string Code { get; set; }
        public string Name { get; set; }
        public string ForeignName { get; set; }
        public string Remark { get; set; }
        public string ForeignRemark { get; set; }
        public string ExternalReceiptKey { get; set; }
        public Nullable<int> IDCarrier { get; set; }
        public string VehicleNumber { get; set; }
        public System.DateTime ExpectedReceiptDate { get; set; }
        public Nullable<System.DateTime> ArrivalDate { get; set; }
        public Nullable<System.DateTime> ReceiptedDate { get; set; }
        public Nullable<System.DateTime> ClosedDate { get; set; }
        public string Type { get; set; }
        public string Status { get; set; }
        public bool IsDisabled { get; set; }
        public bool IsDeleted { get; set; }
        public string CreatedBy { get; set; }
        public string ModifiedBy { get; set; }
        public System.DateTime CreatedDate { get; set; }
        public System.DateTime ModifiedDate { get; set; }
        //List 0:1
        public virtual tbl_BRA_Branch tbl_BRA_Branch { get; set; }
        //List 0:1
        public virtual tbl_CRM_Contact tbl_CRM_Contact { get; set; }
        //List 0:1
        public virtual tbl_CRM_Contact tbl_CRM_Contact1 { get; set; }
        //List 0:1
        public virtual tbl_CRM_Contact tbl_CRM_Contact2 { get; set; }
        //List 0:1
        public virtual tbl_PURCHASE_Order tbl_PURCHASE_Order { get; set; }
        //List 0:1
        public virtual tbl_WMS_Storer tbl_WMS_Storer { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tbl_WMS_ReceiptDetail> tbl_WMS_ReceiptDetail { get; set; }
    }
}


namespace DTOModel
{
	using System;
	public partial class DTO_WMS_Receipt
	{
		public int IDBranch { get; set; }
		public int IDStorer { get; set; }
		public Nullable<int> IDVendor { get; set; }
		public int Id { get; set; }
		public Nullable<int> IDPurchaseOrder { get; set; }
		public string POCode { get; set; }
		public string Code { get; set; }
		public string Name { get; set; }
		public string ForeignName { get; set; }
		public string Remark { get; set; }
		public string ForeignRemark { get; set; }
		public string ExternalReceiptKey { get; set; }
		public Nullable<int> IDCarrier { get; set; }
		public string VehicleNumber { get; set; }
		public System.DateTime ExpectedReceiptDate { get; set; }
		public Nullable<System.DateTime> ArrivalDate { get; set; }
		public Nullable<System.DateTime> ReceiptedDate { get; set; }
		public Nullable<System.DateTime> ClosedDate { get; set; }
		public string Type { get; set; }
		public string Status { get; set; }
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

    public static partial class BS_WMS_Receipt 
    {
        public static dynamic getSearch(AppEntities db, int IDBranch, int StaffID, Dictionary<string, string> QueryStrings)
        {
            return get(db, IDBranch,StaffID, QueryStrings);
        }

		public static IQueryable<DTO_WMS_Receipt> get(AppEntities db, int IDBranch, int StaffID, Dictionary<string, string> QueryStrings)
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
            package.Workbook.Properties.Title = "ART-DMS WMS_Receipt";
            package.Workbook.Properties.Author = "hung.vu@codeart.vn";
            package.Workbook.Properties.Application = "ART-DMS";
            package.Workbook.Properties.Company = "A.R.T Distribution";

            ExcelWorkbook workBook = package.Workbook;
            if (workBook != null)
            {
                var ws = workBook.Worksheets.FirstOrDefault();
                var data = _queryBuilder(db, IDBranch, StaffID, QueryStrings).ToList();

                //var BRA_BranchList = BS_BRA_Branch.get(db,IDBranch, StaffID,QueryStrings).Select(s => new ItemModel { Id = s.Id, Name = s.Name });
                //var CRM_ContactList = BS_CRM_Contact.get(db,IDBranch, StaffID,QueryStrings).Select(s => new ItemModel { Id = s.Id, Name = s.Name });
                //var CRM_Contact1List = BS_CRM_Contact.get(db,IDBranch, StaffID,QueryStrings).Select(s => new ItemModel { Id = s.Id, Name = s.Name });
                //var CRM_Contact2List = BS_CRM_Contact.get(db,IDBranch, StaffID,QueryStrings).Select(s => new ItemModel { Id = s.Id, Name = s.Name });
                //var PURCHASE_OrderList = BS_PURCHASE_Order.get(db,IDBranch, StaffID,QueryStrings).Select(s => new ItemModel { Id = s.Id, Name = s.Name });
                //var WMS_StorerList = BS_WMS_Storer.get(db,IDBranch, StaffID,QueryStrings).Select(s => new ItemModel { Id = s.Id, Name = s.Name });
                 

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

		public static DTO_WMS_Receipt getAnItem(AppEntities db, int IDBranch, int StaffID, int id)
        {
            var dbResult = db.tbl_WMS_Receipt.Find(id);

			//if (dbResult == null || (IDBranch != 0 && dbResult.IDBranch != IDBranch))
			//	return null; 
			//else 
				return toDTO(dbResult);
			
        }
		
		public static DTO_WMS_Receipt getAnItemByCode(AppEntities db, int IDBranch, int StaffID, string code)
        {
            var dbResult = db.tbl_WMS_Receipt
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
            var dbitem = db.tbl_WMS_Receipt.Find(Id);
            
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
					errorLog.logMessage("put_WMS_Receipt",e);
                    result = false;
                }
            }
            else
                if (QueryStrings.Any(d => d.Key == "ForceCreate"))
                    result =  post(db, IDBranch, StaffID, item, Username) != null;
                
            return result;
        }

        public static void patchDynamicToDB(dynamic item, tbl_WMS_Receipt dbitem, string Username)
        {
            Type type = typeof(tbl_WMS_Receipt);
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

        public static void patchDTOtoDBValue( DTO_WMS_Receipt item, tbl_WMS_Receipt dbitem)
        {
            if (item == null){
                dbitem = null;
                return;
            }
            							
			dbitem.IDBranch = item.IDBranch;							
			dbitem.IDStorer = item.IDStorer;							
			dbitem.IDVendor = item.IDVendor;							
			dbitem.IDPurchaseOrder = item.IDPurchaseOrder;							
			dbitem.POCode = item.POCode;							
			dbitem.Code = item.Code;							
			dbitem.Name = item.Name;							
			dbitem.ForeignName = item.ForeignName;							
			dbitem.Remark = item.Remark;							
			dbitem.ForeignRemark = item.ForeignRemark;							
			dbitem.ExternalReceiptKey = item.ExternalReceiptKey;							
			dbitem.IDCarrier = item.IDCarrier;							
			dbitem.VehicleNumber = item.VehicleNumber;							
			dbitem.ExpectedReceiptDate = item.ExpectedReceiptDate;							
			dbitem.ArrivalDate = item.ArrivalDate;							
			dbitem.ReceiptedDate = item.ReceiptedDate;							
			dbitem.ClosedDate = item.ClosedDate;							
			dbitem.Type = item.Type;							
			dbitem.Status = item.Status;							
			dbitem.IsDisabled = item.IsDisabled;							
			dbitem.IsDeleted = item.IsDeleted;        }

		public static DTO_WMS_Receipt post(AppEntities db, int IDBranch, int StaffID, dynamic item, string Username)
        {
            tbl_WMS_Receipt dbitem = new tbl_WMS_Receipt();
            if (item != null)
            {
                patchDynamicToDB(item, dbitem, Username);
                
				dbitem.CreatedBy = Username;
				dbitem.CreatedDate = DateTime.Now;				
                try
                {
					db.tbl_WMS_Receipt.Add(dbitem);
                    db.SaveChanges();
				
                }
                catch (DbEntityValidationException e)
                {
					errorLog.logMessage("post_WMS_Receipt",e);
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
                Type type = Type.GetType("BaseBusiness.BS_WMS_Receipt, ClassLibrary");
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
                        var target = new tbl_WMS_Receipt();
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
                    
                    tbl_WMS_Receipt dbitem = new tbl_WMS_Receipt();
                    if (it.Id == null || string.IsNullOrEmpty(it.Id.Value) || it.Id == "0")
                    {
                        dbitem = new tbl_WMS_Receipt();
                        dbitem.CreatedBy = Username;
				        dbitem.CreatedDate = DateTime.Now;
                                            }
                    else
                    {
                        dbitem = db.tbl_WMS_Receipt.Find((int)it.Id);
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
                        
                        if (dbitem.Id == 0) db.tbl_WMS_Receipt.Add(dbitem);
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
                    errorLog.logMessage("post_WMS_Receipt",e);
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

            var dbitems = db.tbl_WMS_Receipt.Where(d => IDs.Contains(d.Id));
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
                    BS_Version.update_Version(db, IDBranch, "DTO_WMS_Receipt", updateDate, Username);
                }
			
            }
            catch (DbEntityValidationException e)
            {
				errorLog.logMessage("delete_WMS_Receipt",e);
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

			
            var dbitems = db.tbl_WMS_Receipt.Where(d => IDs.Contains(d.Id));
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
                    BS_Version.update_Version(db, IDBranch, "DTO_WMS_Receipt", updateDate, Username);
                }
			
            }
            catch (DbEntityValidationException e)
            {
				errorLog.logMessage("disable_WMS_Receipt",e);
                result = false;
            }
            
            return result;
        }

		
		//---//
		public static bool check_Exists(AppEntities db, int id)
		{
             
            return db.tbl_WMS_Receipt.Any(e => e.Id == id && e.IsDeleted == false);
            
		}
		
		public static bool check_Exists(AppEntities db, string Code)
		{
             
            return db.tbl_WMS_Receipt.Any(e => e.Code == Code && e.IsDeleted == false);
            
		}
		
		//---//
		public static IQueryable<DTO_WMS_Receipt> toDTO(IQueryable<tbl_WMS_Receipt> query)
        {
			return query
			.Select(s => new DTO_WMS_Receipt(){							
				IDBranch = s.IDBranch,							
				IDStorer = s.IDStorer,							
				IDVendor = s.IDVendor,							
				Id = s.Id,							
				IDPurchaseOrder = s.IDPurchaseOrder,							
				POCode = s.POCode,							
				Code = s.Code,							
				Name = s.Name,							
				ForeignName = s.ForeignName,							
				Remark = s.Remark,							
				ForeignRemark = s.ForeignRemark,							
				ExternalReceiptKey = s.ExternalReceiptKey,							
				IDCarrier = s.IDCarrier,							
				VehicleNumber = s.VehicleNumber,							
				ExpectedReceiptDate = s.ExpectedReceiptDate,							
				ArrivalDate = s.ArrivalDate,							
				ReceiptedDate = s.ReceiptedDate,							
				ClosedDate = s.ClosedDate,							
				Type = s.Type,							
				Status = s.Status,							
				IsDisabled = s.IsDisabled,							
				IsDeleted = s.IsDeleted,							
				CreatedBy = s.CreatedBy,							
				ModifiedBy = s.ModifiedBy,							
				CreatedDate = s.CreatedDate,							
				ModifiedDate = s.ModifiedDate,					
			});//;
                              
        }

		public static DTO_WMS_Receipt toDTO(tbl_WMS_Receipt dbResult)
        {
			if (dbResult != null)
			{
				return new DTO_WMS_Receipt()
				{							
					IDBranch = dbResult.IDBranch,							
					IDStorer = dbResult.IDStorer,							
					IDVendor = dbResult.IDVendor,							
					Id = dbResult.Id,							
					IDPurchaseOrder = dbResult.IDPurchaseOrder,							
					POCode = dbResult.POCode,							
					Code = dbResult.Code,							
					Name = dbResult.Name,							
					ForeignName = dbResult.ForeignName,							
					Remark = dbResult.Remark,							
					ForeignRemark = dbResult.ForeignRemark,							
					ExternalReceiptKey = dbResult.ExternalReceiptKey,							
					IDCarrier = dbResult.IDCarrier,							
					VehicleNumber = dbResult.VehicleNumber,							
					ExpectedReceiptDate = dbResult.ExpectedReceiptDate,							
					ArrivalDate = dbResult.ArrivalDate,							
					ReceiptedDate = dbResult.ReceiptedDate,							
					ClosedDate = dbResult.ClosedDate,							
					Type = dbResult.Type,							
					Status = dbResult.Status,							
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

		public static IQueryable<tbl_WMS_Receipt> _queryBuilder(AppEntities db, int IDBranch, int StaffID, Dictionary<string, string> QueryStrings)
        {
            
			IQueryable<tbl_WMS_Receipt> query = db.tbl_WMS_Receipt.AsNoTracking();//.Where(d => d.IsDeleted == false);
			

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

			//Query IDVendor (Nullable<int>)
			if (QueryStrings.Any(d => d.Key == "IDVendor"))
            {
                var IDList = QueryStrings.FirstOrDefault(d => d.Key == "IDVendor").Value.Replace("[", "").Replace("]", "").Split(',');
                List<int?> IDs = new List<int?>();
                foreach (var item in IDList)
                    if (int.TryParse(item, out int i))
                        IDs.Add(i);
					else if (item == "null")
						IDs.Add(null);
                if (IDs.Count > 0)
                    query = query.Where(d => IDs.Contains(d.IDVendor));
////                    query = query.Where(d => IDs.Contains(d.IDVendor));
//                    
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

			//Query IDPurchaseOrder (Nullable<int>)
			if (QueryStrings.Any(d => d.Key == "IDPurchaseOrder"))
            {
                var IDList = QueryStrings.FirstOrDefault(d => d.Key == "IDPurchaseOrder").Value.Replace("[", "").Replace("]", "").Split(',');
                List<int?> IDs = new List<int?>();
                foreach (var item in IDList)
                    if (int.TryParse(item, out int i))
                        IDs.Add(i);
					else if (item == "null")
						IDs.Add(null);
                if (IDs.Count > 0)
                    query = query.Where(d => IDs.Contains(d.IDPurchaseOrder));
////                    query = query.Where(d => IDs.Contains(d.IDPurchaseOrder));
//                    
            }

			//Query POCode (string)
			if (QueryStrings.Any(d => d.Key == "POCode_eq") && !string.IsNullOrEmpty(QueryStrings.FirstOrDefault(d => d.Key == "POCode_eq").Value))
            {
                var keyword = QueryStrings.FirstOrDefault(d => d.Key == "POCode_eq").Value;
                query = query.Where(d=>d.POCode == keyword);
            }
            if (QueryStrings.Any(d => d.Key == "POCode") && !string.IsNullOrEmpty(QueryStrings.FirstOrDefault(d => d.Key == "POCode").Value))
            {
                var keyword = QueryStrings.FirstOrDefault(d => d.Key == "POCode").Value;
                query = query.Where(d=>d.POCode.Contains(keyword));
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
            

			//Query ForeignName (string)
			if (QueryStrings.Any(d => d.Key == "ForeignName_eq") && !string.IsNullOrEmpty(QueryStrings.FirstOrDefault(d => d.Key == "ForeignName_eq").Value))
            {
                var keyword = QueryStrings.FirstOrDefault(d => d.Key == "ForeignName_eq").Value;
                query = query.Where(d=>d.ForeignName == keyword);
            }
            if (QueryStrings.Any(d => d.Key == "ForeignName") && !string.IsNullOrEmpty(QueryStrings.FirstOrDefault(d => d.Key == "ForeignName").Value))
            {
                var keyword = QueryStrings.FirstOrDefault(d => d.Key == "ForeignName").Value;
                query = query.Where(d=>d.ForeignName.Contains(keyword));
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
            

			//Query ForeignRemark (string)
			if (QueryStrings.Any(d => d.Key == "ForeignRemark_eq") && !string.IsNullOrEmpty(QueryStrings.FirstOrDefault(d => d.Key == "ForeignRemark_eq").Value))
            {
                var keyword = QueryStrings.FirstOrDefault(d => d.Key == "ForeignRemark_eq").Value;
                query = query.Where(d=>d.ForeignRemark == keyword);
            }
            if (QueryStrings.Any(d => d.Key == "ForeignRemark") && !string.IsNullOrEmpty(QueryStrings.FirstOrDefault(d => d.Key == "ForeignRemark").Value))
            {
                var keyword = QueryStrings.FirstOrDefault(d => d.Key == "ForeignRemark").Value;
                query = query.Where(d=>d.ForeignRemark.Contains(keyword));
            }
            

			//Query ExternalReceiptKey (string)
			if (QueryStrings.Any(d => d.Key == "ExternalReceiptKey_eq") && !string.IsNullOrEmpty(QueryStrings.FirstOrDefault(d => d.Key == "ExternalReceiptKey_eq").Value))
            {
                var keyword = QueryStrings.FirstOrDefault(d => d.Key == "ExternalReceiptKey_eq").Value;
                query = query.Where(d=>d.ExternalReceiptKey == keyword);
            }
            if (QueryStrings.Any(d => d.Key == "ExternalReceiptKey") && !string.IsNullOrEmpty(QueryStrings.FirstOrDefault(d => d.Key == "ExternalReceiptKey").Value))
            {
                var keyword = QueryStrings.FirstOrDefault(d => d.Key == "ExternalReceiptKey").Value;
                query = query.Where(d=>d.ExternalReceiptKey.Contains(keyword));
            }
            

			//Query IDCarrier (Nullable<int>)
			if (QueryStrings.Any(d => d.Key == "IDCarrier"))
            {
                var IDList = QueryStrings.FirstOrDefault(d => d.Key == "IDCarrier").Value.Replace("[", "").Replace("]", "").Split(',');
                List<int?> IDs = new List<int?>();
                foreach (var item in IDList)
                    if (int.TryParse(item, out int i))
                        IDs.Add(i);
					else if (item == "null")
						IDs.Add(null);
                if (IDs.Count > 0)
                    query = query.Where(d => IDs.Contains(d.IDCarrier));
////                    query = query.Where(d => IDs.Contains(d.IDCarrier));
//                    
            }

			//Query VehicleNumber (string)
			if (QueryStrings.Any(d => d.Key == "VehicleNumber_eq") && !string.IsNullOrEmpty(QueryStrings.FirstOrDefault(d => d.Key == "VehicleNumber_eq").Value))
            {
                var keyword = QueryStrings.FirstOrDefault(d => d.Key == "VehicleNumber_eq").Value;
                query = query.Where(d=>d.VehicleNumber == keyword);
            }
            if (QueryStrings.Any(d => d.Key == "VehicleNumber") && !string.IsNullOrEmpty(QueryStrings.FirstOrDefault(d => d.Key == "VehicleNumber").Value))
            {
                var keyword = QueryStrings.FirstOrDefault(d => d.Key == "VehicleNumber").Value;
                query = query.Where(d=>d.VehicleNumber.Contains(keyword));
            }
            

			//Query ExpectedReceiptDate (System.DateTime)
			if (QueryStrings.Any(d => d.Key == "ExpectedReceiptDateFrom") && QueryStrings.Any(d => d.Key == "ExpectedReceiptDateTo"))
                if (DateTime.TryParse(QueryStrings.FirstOrDefault(d => d.Key == "ExpectedReceiptDateFrom").Value, out DateTime fromDate) && DateTime.TryParse(QueryStrings.FirstOrDefault(d => d.Key == "ExpectedReceiptDateTo").Value, out DateTime toDate))
                    query = query.Where(d => fromDate <= d.ExpectedReceiptDate && d.ExpectedReceiptDate <= toDate);

            if (QueryStrings.Any(d => d.Key == "ExpectedReceiptDate"))
                if (DateTime.TryParse(QueryStrings.FirstOrDefault(d => d.Key == "ExpectedReceiptDate").Value, out DateTime val))
                    query = query.Where(d => d.ExpectedReceiptDate != null && DbFunctions.TruncateTime(val) == DbFunctions.TruncateTime(d.ExpectedReceiptDate));


			//Query ArrivalDate (Nullable<System.DateTime>)
			if (QueryStrings.Any(d => d.Key == "ArrivalDateFrom") && QueryStrings.Any(d => d.Key == "ArrivalDateTo"))
                if (DateTime.TryParse(QueryStrings.FirstOrDefault(d => d.Key == "ArrivalDateFrom").Value, out DateTime fromDate) && DateTime.TryParse(QueryStrings.FirstOrDefault(d => d.Key == "ArrivalDateTo").Value, out DateTime toDate))
                    query = query.Where(d => fromDate <= d.ArrivalDate && d.ArrivalDate <= toDate);

            if (QueryStrings.Any(d => d.Key == "ArrivalDate"))
                if (DateTime.TryParse(QueryStrings.FirstOrDefault(d => d.Key == "ArrivalDate").Value, out DateTime val))
                    query = query.Where(d => d.ArrivalDate != null && DbFunctions.TruncateTime(val) == DbFunctions.TruncateTime(d.ArrivalDate));


			//Query ReceiptedDate (Nullable<System.DateTime>)
			if (QueryStrings.Any(d => d.Key == "ReceiptedDateFrom") && QueryStrings.Any(d => d.Key == "ReceiptedDateTo"))
                if (DateTime.TryParse(QueryStrings.FirstOrDefault(d => d.Key == "ReceiptedDateFrom").Value, out DateTime fromDate) && DateTime.TryParse(QueryStrings.FirstOrDefault(d => d.Key == "ReceiptedDateTo").Value, out DateTime toDate))
                    query = query.Where(d => fromDate <= d.ReceiptedDate && d.ReceiptedDate <= toDate);

            if (QueryStrings.Any(d => d.Key == "ReceiptedDate"))
                if (DateTime.TryParse(QueryStrings.FirstOrDefault(d => d.Key == "ReceiptedDate").Value, out DateTime val))
                    query = query.Where(d => d.ReceiptedDate != null && DbFunctions.TruncateTime(val) == DbFunctions.TruncateTime(d.ReceiptedDate));


			//Query ClosedDate (Nullable<System.DateTime>)
			if (QueryStrings.Any(d => d.Key == "ClosedDateFrom") && QueryStrings.Any(d => d.Key == "ClosedDateTo"))
                if (DateTime.TryParse(QueryStrings.FirstOrDefault(d => d.Key == "ClosedDateFrom").Value, out DateTime fromDate) && DateTime.TryParse(QueryStrings.FirstOrDefault(d => d.Key == "ClosedDateTo").Value, out DateTime toDate))
                    query = query.Where(d => fromDate <= d.ClosedDate && d.ClosedDate <= toDate);

            if (QueryStrings.Any(d => d.Key == "ClosedDate"))
                if (DateTime.TryParse(QueryStrings.FirstOrDefault(d => d.Key == "ClosedDate").Value, out DateTime val))
                    query = query.Where(d => d.ClosedDate != null && DbFunctions.TruncateTime(val) == DbFunctions.TruncateTime(d.ClosedDate));


			//Query Type (string)
			if (QueryStrings.Any(d => d.Key == "Type_eq") && !string.IsNullOrEmpty(QueryStrings.FirstOrDefault(d => d.Key == "Type_eq").Value))
            {
                var keyword = QueryStrings.FirstOrDefault(d => d.Key == "Type_eq").Value;
                query = query.Where(d=>d.Type == keyword);
            }
            if (QueryStrings.Any(d => d.Key == "Type") && !string.IsNullOrEmpty(QueryStrings.FirstOrDefault(d => d.Key == "Type").Value))
            {
                var keyword = QueryStrings.FirstOrDefault(d => d.Key == "Type").Value;
                query = query.Where(d=>d.Type.Contains(keyword));
            }
            

			//Query Status (string)
			if (QueryStrings.Any(d => d.Key == "Status_eq") && !string.IsNullOrEmpty(QueryStrings.FirstOrDefault(d => d.Key == "Status_eq").Value))
            {
                var keyword = QueryStrings.FirstOrDefault(d => d.Key == "Status_eq").Value;
                query = query.Where(d=>d.Status == keyword);
            }
            if (QueryStrings.Any(d => d.Key == "Status") && !string.IsNullOrEmpty(QueryStrings.FirstOrDefault(d => d.Key == "Status").Value))
            {
                var keyword = QueryStrings.FirstOrDefault(d => d.Key == "Status").Value;
                query = query.Where(d=>d.Status.Contains(keyword));
            }
            

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
		
        public static IQueryable<tbl_WMS_Receipt> _sortBuilder(IQueryable<tbl_WMS_Receipt> query, Dictionary<string, string> QueryStrings)
        {
            if (QueryStrings.Any(d => d.Key == "SortBy"))
            {
                var sorts = QueryStrings.FirstOrDefault(d => d.Key == "SortBy").Value.Replace("[", "").Replace("]", "").Split(',');
                
                foreach (var item in sorts)
                    if (!string.IsNullOrEmpty(item))
                    {
                        var ordered = query as IOrderedQueryable<tbl_WMS_Receipt>;
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
							case "IDVendor":
								query = isOrdered ? ordered.ThenBy(o => o.IDVendor) : query.OrderBy(o => o.IDVendor);
								 break;
							case "IDVendor_desc":
                                query = isOrdered ? ordered.ThenByDescending(o => o.IDVendor) : query.OrderByDescending(o => o.IDVendor);
                                break;
							case "Id":
								query = isOrdered ? ordered.ThenBy(o => o.Id) : query.OrderBy(o => o.Id);
								 break;
							case "Id_desc":
                                query = isOrdered ? ordered.ThenByDescending(o => o.Id) : query.OrderByDescending(o => o.Id);
                                break;
							case "IDPurchaseOrder":
								query = isOrdered ? ordered.ThenBy(o => o.IDPurchaseOrder) : query.OrderBy(o => o.IDPurchaseOrder);
								 break;
							case "IDPurchaseOrder_desc":
                                query = isOrdered ? ordered.ThenByDescending(o => o.IDPurchaseOrder) : query.OrderByDescending(o => o.IDPurchaseOrder);
                                break;
							case "POCode":
								query = isOrdered ? ordered.ThenBy(o => o.POCode) : query.OrderBy(o => o.POCode);
								 break;
							case "POCode_desc":
                                query = isOrdered ? ordered.ThenByDescending(o => o.POCode) : query.OrderByDescending(o => o.POCode);
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
							case "ForeignName":
								query = isOrdered ? ordered.ThenBy(o => o.ForeignName) : query.OrderBy(o => o.ForeignName);
								 break;
							case "ForeignName_desc":
                                query = isOrdered ? ordered.ThenByDescending(o => o.ForeignName) : query.OrderByDescending(o => o.ForeignName);
                                break;
							case "Remark":
								query = isOrdered ? ordered.ThenBy(o => o.Remark) : query.OrderBy(o => o.Remark);
								 break;
							case "Remark_desc":
                                query = isOrdered ? ordered.ThenByDescending(o => o.Remark) : query.OrderByDescending(o => o.Remark);
                                break;
							case "ForeignRemark":
								query = isOrdered ? ordered.ThenBy(o => o.ForeignRemark) : query.OrderBy(o => o.ForeignRemark);
								 break;
							case "ForeignRemark_desc":
                                query = isOrdered ? ordered.ThenByDescending(o => o.ForeignRemark) : query.OrderByDescending(o => o.ForeignRemark);
                                break;
							case "ExternalReceiptKey":
								query = isOrdered ? ordered.ThenBy(o => o.ExternalReceiptKey) : query.OrderBy(o => o.ExternalReceiptKey);
								 break;
							case "ExternalReceiptKey_desc":
                                query = isOrdered ? ordered.ThenByDescending(o => o.ExternalReceiptKey) : query.OrderByDescending(o => o.ExternalReceiptKey);
                                break;
							case "IDCarrier":
								query = isOrdered ? ordered.ThenBy(o => o.IDCarrier) : query.OrderBy(o => o.IDCarrier);
								 break;
							case "IDCarrier_desc":
                                query = isOrdered ? ordered.ThenByDescending(o => o.IDCarrier) : query.OrderByDescending(o => o.IDCarrier);
                                break;
							case "VehicleNumber":
								query = isOrdered ? ordered.ThenBy(o => o.VehicleNumber) : query.OrderBy(o => o.VehicleNumber);
								 break;
							case "VehicleNumber_desc":
                                query = isOrdered ? ordered.ThenByDescending(o => o.VehicleNumber) : query.OrderByDescending(o => o.VehicleNumber);
                                break;
							case "ExpectedReceiptDate":
								query = isOrdered ? ordered.ThenBy(o => o.ExpectedReceiptDate) : query.OrderBy(o => o.ExpectedReceiptDate);
								 break;
							case "ExpectedReceiptDate_desc":
                                query = isOrdered ? ordered.ThenByDescending(o => o.ExpectedReceiptDate) : query.OrderByDescending(o => o.ExpectedReceiptDate);
                                break;
							case "ArrivalDate":
								query = isOrdered ? ordered.ThenBy(o => o.ArrivalDate) : query.OrderBy(o => o.ArrivalDate);
								 break;
							case "ArrivalDate_desc":
                                query = isOrdered ? ordered.ThenByDescending(o => o.ArrivalDate) : query.OrderByDescending(o => o.ArrivalDate);
                                break;
							case "ReceiptedDate":
								query = isOrdered ? ordered.ThenBy(o => o.ReceiptedDate) : query.OrderBy(o => o.ReceiptedDate);
								 break;
							case "ReceiptedDate_desc":
                                query = isOrdered ? ordered.ThenByDescending(o => o.ReceiptedDate) : query.OrderByDescending(o => o.ReceiptedDate);
                                break;
							case "ClosedDate":
								query = isOrdered ? ordered.ThenBy(o => o.ClosedDate) : query.OrderBy(o => o.ClosedDate);
								 break;
							case "ClosedDate_desc":
                                query = isOrdered ? ordered.ThenByDescending(o => o.ClosedDate) : query.OrderByDescending(o => o.ClosedDate);
                                break;
							case "Type":
								query = isOrdered ? ordered.ThenBy(o => o.Type) : query.OrderBy(o => o.Type);
								 break;
							case "Type_desc":
                                query = isOrdered ? ordered.ThenByDescending(o => o.Type) : query.OrderByDescending(o => o.Type);
                                break;
							case "Status":
								query = isOrdered ? ordered.ThenBy(o => o.Status) : query.OrderBy(o => o.Status);
								 break;
							case "Status_desc":
                                query = isOrdered ? ordered.ThenByDescending(o => o.Status) : query.OrderByDescending(o => o.Status);
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

        public static IQueryable<tbl_WMS_Receipt> _pagingBuilder(IQueryable<tbl_WMS_Receipt> query, Dictionary<string, string> QueryStrings)
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






