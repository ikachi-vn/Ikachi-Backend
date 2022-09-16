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
    
    
    public partial class tbl_WMS_Storer
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public tbl_WMS_Storer()
        {
            this.tbl_WMS_ItemInLocation = new HashSet<tbl_WMS_ItemInLocation>();
            this.tbl_WMS_ItemInWarehouseConfig = new HashSet<tbl_WMS_ItemInWarehouseConfig>();
            this.tbl_WMS_LicencePlateNumber = new HashSet<tbl_WMS_LicencePlateNumber>();
            this.tbl_WMS_Lot = new HashSet<tbl_WMS_Lot>();
            this.tbl_WMS_LotLPNLocation = new HashSet<tbl_WMS_LotLPNLocation>();
            this.tbl_WMS_Receipt = new HashSet<tbl_WMS_Receipt>();
            this.tbl_WMS_ReceiptPalletization = new HashSet<tbl_WMS_ReceiptPalletization>();
            this.tbl_WMS_Transaction = new HashSet<tbl_WMS_Transaction>();
        }
    
        public int Id { get; set; }
        public string Remark { get; set; }
        public Nullable<int> Sort { get; set; }
        public bool isActivated { get; set; }
        public bool IsDeleted { get; set; }
        public string CreatedBy { get; set; }
        public string ModifiedBy { get; set; }
        public System.DateTime CreatedDate { get; set; }
        public System.DateTime ModifiedDate { get; set; }
        public Nullable<int> IDCartonGroup { get; set; }
        public bool IsEnablePacking { get; set; }
        public bool IsQCInspectAtPack { get; set; }
        public bool IsAllowMultiZoneRainbowPallet { get; set; }
        public string DefaultItemRotation { get; set; }
        public string DefaultRotation { get; set; }
        public Nullable<int> DefaultStrategy { get; set; }
        public Nullable<int> DefaultPutawayStrategy { get; set; }
        public Nullable<int> DefaultInboundQCLocation { get; set; }
        public Nullable<int> DefaultOutboundQCLocation { get; set; }
        public Nullable<int> DefaultReturnsReceiptLocation { get; set; }
        public Nullable<int> DefaultPackingLocation { get; set; }
        public string LPNBarcodeSymbology { get; set; }
        public string LPNBarcodeFormat { get; set; }
        public Nullable<int> LPNLength { get; set; }
        public string LPNStartNumber { get; set; }
        public string LPNNextNumber { get; set; }
        public string LPNRollbackNumber { get; set; }
        public string CaseLabelType { get; set; }
        public string ApplicationID { get; set; }
        public string SSCCFirstDigit { get; set; }
        public string UCCVendor { get; set; }
        public bool AllowCommingledLPN { get; set; }
        public Nullable<int> LabelTemplate { get; set; }
        public string StandardCarrierAlphaCode { get; set; }
        public decimal CreditLimit { get; set; }
        public string Name { get; set; }
        //List 0:1
        public virtual tbl_CRM_Contact tbl_CRM_Contact { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tbl_WMS_ItemInLocation> tbl_WMS_ItemInLocation { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tbl_WMS_ItemInWarehouseConfig> tbl_WMS_ItemInWarehouseConfig { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tbl_WMS_LicencePlateNumber> tbl_WMS_LicencePlateNumber { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tbl_WMS_Lot> tbl_WMS_Lot { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tbl_WMS_LotLPNLocation> tbl_WMS_LotLPNLocation { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tbl_WMS_Receipt> tbl_WMS_Receipt { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tbl_WMS_ReceiptPalletization> tbl_WMS_ReceiptPalletization { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tbl_WMS_Transaction> tbl_WMS_Transaction { get; set; }
    }
}


namespace DTOModel
{
	using System;
	public partial class DTO_WMS_Storer
	{
		public int Id { get; set; }
		public string Remark { get; set; }
		public Nullable<int> Sort { get; set; }
		public bool isActivated { get; set; }
		public bool IsDeleted { get; set; }
		public string CreatedBy { get; set; }
		public string ModifiedBy { get; set; }
		public System.DateTime CreatedDate { get; set; }
		public System.DateTime ModifiedDate { get; set; }
		public Nullable<int> IDCartonGroup { get; set; }
		public bool IsEnablePacking { get; set; }
		public bool IsQCInspectAtPack { get; set; }
		public bool IsAllowMultiZoneRainbowPallet { get; set; }
		public string DefaultItemRotation { get; set; }
		public string DefaultRotation { get; set; }
		public Nullable<int> DefaultStrategy { get; set; }
		public Nullable<int> DefaultPutawayStrategy { get; set; }
		public Nullable<int> DefaultInboundQCLocation { get; set; }
		public Nullable<int> DefaultOutboundQCLocation { get; set; }
		public Nullable<int> DefaultReturnsReceiptLocation { get; set; }
		public Nullable<int> DefaultPackingLocation { get; set; }
		public string LPNBarcodeSymbology { get; set; }
		public string LPNBarcodeFormat { get; set; }
		public Nullable<int> LPNLength { get; set; }
		public string LPNStartNumber { get; set; }
		public string LPNNextNumber { get; set; }
		public string LPNRollbackNumber { get; set; }
		public string CaseLabelType { get; set; }
		public string ApplicationID { get; set; }
		public string SSCCFirstDigit { get; set; }
		public string UCCVendor { get; set; }
		public bool AllowCommingledLPN { get; set; }
		public Nullable<int> LabelTemplate { get; set; }
		public string StandardCarrierAlphaCode { get; set; }
		public decimal CreditLimit { get; set; }
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

    public static partial class BS_WMS_Storer 
    {
        public static dynamic getSearch(AppEntities db, int IDBranch, int StaffID, Dictionary<string, string> QueryStrings)
        {
            return get(db, IDBranch,StaffID, QueryStrings);
        }

		public static IQueryable<DTO_WMS_Storer> get(AppEntities db, int IDBranch, int StaffID, Dictionary<string, string> QueryStrings)
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
            package.Workbook.Properties.Title = "ART-DMS WMS_Storer";
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

		public static DTO_WMS_Storer getAnItem(AppEntities db, int IDBranch, int StaffID, int id)
        {
            var dbResult = db.tbl_WMS_Storer.Find(id);

			return toDTO(dbResult);
			
        }
		

		public static bool put(AppEntities db, int IDBranch, int StaffID, int Id, dynamic item, string Username, Dictionary<string, string> QueryStrings)
        {
            bool result = false;
            var dbitem = db.tbl_WMS_Storer.Find(Id);
            
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
					errorLog.logMessage("put_WMS_Storer",e);
                    result = false;
                }
            }
            else
                if (QueryStrings.Any(d => d.Key == "ForceCreate"))
                    result =  post(db, IDBranch, StaffID, item, Username) != null;
                
            return result;
        }

        public static void patchDynamicToDB(dynamic item, tbl_WMS_Storer dbitem, string Username)
        {
            Type type = typeof(tbl_WMS_Storer);
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

        public static void patchDTOtoDBValue( DTO_WMS_Storer item, tbl_WMS_Storer dbitem)
        {
            if (item == null){
                dbitem = null;
                return;
            }
            							
			dbitem.Remark = item.Remark;							
			dbitem.Sort = item.Sort;							
			dbitem.isActivated = item.isActivated;							
			dbitem.IsDeleted = item.IsDeleted;							
			dbitem.IDCartonGroup = item.IDCartonGroup;							
			dbitem.IsEnablePacking = item.IsEnablePacking;							
			dbitem.IsQCInspectAtPack = item.IsQCInspectAtPack;							
			dbitem.IsAllowMultiZoneRainbowPallet = item.IsAllowMultiZoneRainbowPallet;							
			dbitem.DefaultItemRotation = item.DefaultItemRotation;							
			dbitem.DefaultRotation = item.DefaultRotation;							
			dbitem.DefaultStrategy = item.DefaultStrategy;							
			dbitem.DefaultPutawayStrategy = item.DefaultPutawayStrategy;							
			dbitem.DefaultInboundQCLocation = item.DefaultInboundQCLocation;							
			dbitem.DefaultOutboundQCLocation = item.DefaultOutboundQCLocation;							
			dbitem.DefaultReturnsReceiptLocation = item.DefaultReturnsReceiptLocation;							
			dbitem.DefaultPackingLocation = item.DefaultPackingLocation;							
			dbitem.LPNBarcodeSymbology = item.LPNBarcodeSymbology;							
			dbitem.LPNBarcodeFormat = item.LPNBarcodeFormat;							
			dbitem.LPNLength = item.LPNLength;							
			dbitem.LPNStartNumber = item.LPNStartNumber;							
			dbitem.LPNNextNumber = item.LPNNextNumber;							
			dbitem.LPNRollbackNumber = item.LPNRollbackNumber;							
			dbitem.CaseLabelType = item.CaseLabelType;							
			dbitem.ApplicationID = item.ApplicationID;							
			dbitem.SSCCFirstDigit = item.SSCCFirstDigit;							
			dbitem.UCCVendor = item.UCCVendor;							
			dbitem.AllowCommingledLPN = item.AllowCommingledLPN;							
			dbitem.LabelTemplate = item.LabelTemplate;							
			dbitem.StandardCarrierAlphaCode = item.StandardCarrierAlphaCode;							
			dbitem.CreditLimit = item.CreditLimit;							
			dbitem.Name = item.Name;        }

		public static DTO_WMS_Storer post(AppEntities db, int IDBranch, int StaffID, dynamic item, string Username)
        {
            tbl_WMS_Storer dbitem = new tbl_WMS_Storer();
            if (item != null)
            {
                patchDynamicToDB(item, dbitem, Username);
                
				dbitem.CreatedBy = Username;
				dbitem.CreatedDate = DateTime.Now;				
                try
                {
					db.tbl_WMS_Storer.Add(dbitem);
                    db.SaveChanges();
				
                }
                catch (DbEntityValidationException e)
                {
					errorLog.logMessage("post_WMS_Storer",e);
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
                Type type = Type.GetType("BaseBusiness.BS_WMS_Storer, ClassLibrary");
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
                        var target = new tbl_WMS_Storer();
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
                    
                    tbl_WMS_Storer dbitem = new tbl_WMS_Storer();
                    if (it.Id == null || string.IsNullOrEmpty(it.Id.Value) || it.Id == "0")
                    {
                        dbitem = new tbl_WMS_Storer();
                        dbitem.CreatedBy = Username;
				        dbitem.CreatedDate = DateTime.Now;
                                            }
                    else
                    {
                        dbitem = db.tbl_WMS_Storer.Find((int)it.Id);
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
                        
                        if (dbitem.Id == 0) db.tbl_WMS_Storer.Add(dbitem);
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
                    errorLog.logMessage("post_WMS_Storer",e);
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

            var dbitems = db.tbl_WMS_Storer.Where(d => IDs.Contains(d.Id));
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
			
                BS_Version.update_Version(db, null, "DTO_WMS_Storer", updateDate, Username);
			
            }
            catch (DbEntityValidationException e)
            {
				errorLog.logMessage("delete_WMS_Storer",e);
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
             
            return db.tbl_WMS_Storer.Any(e => e.Id == id && e.IsDeleted == false);
            
		}
		
		//---//
		public static IQueryable<DTO_WMS_Storer> toDTO(IQueryable<tbl_WMS_Storer> query)
        {
			return query
			.Select(s => new DTO_WMS_Storer(){							
				Id = s.Id,							
				Remark = s.Remark,							
				Sort = s.Sort,							
				isActivated = s.isActivated,							
				IsDeleted = s.IsDeleted,							
				CreatedBy = s.CreatedBy,							
				ModifiedBy = s.ModifiedBy,							
				CreatedDate = s.CreatedDate,							
				ModifiedDate = s.ModifiedDate,							
				IDCartonGroup = s.IDCartonGroup,							
				IsEnablePacking = s.IsEnablePacking,							
				IsQCInspectAtPack = s.IsQCInspectAtPack,							
				IsAllowMultiZoneRainbowPallet = s.IsAllowMultiZoneRainbowPallet,							
				DefaultItemRotation = s.DefaultItemRotation,							
				DefaultRotation = s.DefaultRotation,							
				DefaultStrategy = s.DefaultStrategy,							
				DefaultPutawayStrategy = s.DefaultPutawayStrategy,							
				DefaultInboundQCLocation = s.DefaultInboundQCLocation,							
				DefaultOutboundQCLocation = s.DefaultOutboundQCLocation,							
				DefaultReturnsReceiptLocation = s.DefaultReturnsReceiptLocation,							
				DefaultPackingLocation = s.DefaultPackingLocation,							
				LPNBarcodeSymbology = s.LPNBarcodeSymbology,							
				LPNBarcodeFormat = s.LPNBarcodeFormat,							
				LPNLength = s.LPNLength,							
				LPNStartNumber = s.LPNStartNumber,							
				LPNNextNumber = s.LPNNextNumber,							
				LPNRollbackNumber = s.LPNRollbackNumber,							
				CaseLabelType = s.CaseLabelType,							
				ApplicationID = s.ApplicationID,							
				SSCCFirstDigit = s.SSCCFirstDigit,							
				UCCVendor = s.UCCVendor,							
				AllowCommingledLPN = s.AllowCommingledLPN,							
				LabelTemplate = s.LabelTemplate,							
				StandardCarrierAlphaCode = s.StandardCarrierAlphaCode,							
				CreditLimit = s.CreditLimit,							
				Name = s.Name,					
			});//.OrderBy(o => o.Sort == null).ThenBy(u => u.Sort);
                              
        }

		public static DTO_WMS_Storer toDTO(tbl_WMS_Storer dbResult)
        {
			if (dbResult != null)
			{
				return new DTO_WMS_Storer()
				{							
					Id = dbResult.Id,							
					Remark = dbResult.Remark,							
					Sort = dbResult.Sort,							
					isActivated = dbResult.isActivated,							
					IsDeleted = dbResult.IsDeleted,							
					CreatedBy = dbResult.CreatedBy,							
					ModifiedBy = dbResult.ModifiedBy,							
					CreatedDate = dbResult.CreatedDate,							
					ModifiedDate = dbResult.ModifiedDate,							
					IDCartonGroup = dbResult.IDCartonGroup,							
					IsEnablePacking = dbResult.IsEnablePacking,							
					IsQCInspectAtPack = dbResult.IsQCInspectAtPack,							
					IsAllowMultiZoneRainbowPallet = dbResult.IsAllowMultiZoneRainbowPallet,							
					DefaultItemRotation = dbResult.DefaultItemRotation,							
					DefaultRotation = dbResult.DefaultRotation,							
					DefaultStrategy = dbResult.DefaultStrategy,							
					DefaultPutawayStrategy = dbResult.DefaultPutawayStrategy,							
					DefaultInboundQCLocation = dbResult.DefaultInboundQCLocation,							
					DefaultOutboundQCLocation = dbResult.DefaultOutboundQCLocation,							
					DefaultReturnsReceiptLocation = dbResult.DefaultReturnsReceiptLocation,							
					DefaultPackingLocation = dbResult.DefaultPackingLocation,							
					LPNBarcodeSymbology = dbResult.LPNBarcodeSymbology,							
					LPNBarcodeFormat = dbResult.LPNBarcodeFormat,							
					LPNLength = dbResult.LPNLength,							
					LPNStartNumber = dbResult.LPNStartNumber,							
					LPNNextNumber = dbResult.LPNNextNumber,							
					LPNRollbackNumber = dbResult.LPNRollbackNumber,							
					CaseLabelType = dbResult.CaseLabelType,							
					ApplicationID = dbResult.ApplicationID,							
					SSCCFirstDigit = dbResult.SSCCFirstDigit,							
					UCCVendor = dbResult.UCCVendor,							
					AllowCommingledLPN = dbResult.AllowCommingledLPN,							
					LabelTemplate = dbResult.LabelTemplate,							
					StandardCarrierAlphaCode = dbResult.StandardCarrierAlphaCode,							
					CreditLimit = dbResult.CreditLimit,							
					Name = dbResult.Name,
				};
			}
			else
				return null; 
        }

		public static IQueryable<tbl_WMS_Storer> _queryBuilder(AppEntities db, int IDBranch, int StaffID, Dictionary<string, string> QueryStrings)
        {
            
			IQueryable<tbl_WMS_Storer> query = db.tbl_WMS_Storer.AsNoTracking();//.Where(d => d.IsDeleted == false );
			

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

			//Query isActivated (bool)
			if (QueryStrings.Any(d => d.Key == "isActivated"))
            {
                var qValue = QueryStrings.FirstOrDefault(d => d.Key == "isActivated").Value;
                if (bool.TryParse(qValue, out bool qBoolValue))
                    query = query.Where(d => qBoolValue == d.isActivated);
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


			//Query IDCartonGroup (Nullable<int>)
			if (QueryStrings.Any(d => d.Key == "IDCartonGroup"))
            {
                var IDList = QueryStrings.FirstOrDefault(d => d.Key == "IDCartonGroup").Value.Replace("[", "").Replace("]", "").Split(',');
                List<int?> IDs = new List<int?>();
                foreach (var item in IDList)
                    if (int.TryParse(item, out int i))
                        IDs.Add(i);
					else if (item == "null")
						IDs.Add(null);
                if (IDs.Count > 0)
                    query = query.Where(d => IDs.Contains(d.IDCartonGroup));
////                    query = query.Where(d => IDs.Contains(d.IDCartonGroup));
//                    
            }

			//Query IsEnablePacking (bool)
			if (QueryStrings.Any(d => d.Key == "IsEnablePacking"))
            {
                var qValue = QueryStrings.FirstOrDefault(d => d.Key == "IsEnablePacking").Value;
                if (bool.TryParse(qValue, out bool qBoolValue))
                    query = query.Where(d => qBoolValue == d.IsEnablePacking);
            }

			//Query IsQCInspectAtPack (bool)
			if (QueryStrings.Any(d => d.Key == "IsQCInspectAtPack"))
            {
                var qValue = QueryStrings.FirstOrDefault(d => d.Key == "IsQCInspectAtPack").Value;
                if (bool.TryParse(qValue, out bool qBoolValue))
                    query = query.Where(d => qBoolValue == d.IsQCInspectAtPack);
            }

			//Query IsAllowMultiZoneRainbowPallet (bool)
			if (QueryStrings.Any(d => d.Key == "IsAllowMultiZoneRainbowPallet"))
            {
                var qValue = QueryStrings.FirstOrDefault(d => d.Key == "IsAllowMultiZoneRainbowPallet").Value;
                if (bool.TryParse(qValue, out bool qBoolValue))
                    query = query.Where(d => qBoolValue == d.IsAllowMultiZoneRainbowPallet);
            }

			//Query DefaultItemRotation (string)
			if (QueryStrings.Any(d => d.Key == "DefaultItemRotation_eq") && !string.IsNullOrEmpty(QueryStrings.FirstOrDefault(d => d.Key == "DefaultItemRotation_eq").Value))
            {
                var keyword = QueryStrings.FirstOrDefault(d => d.Key == "DefaultItemRotation_eq").Value;
                query = query.Where(d=>d.DefaultItemRotation == keyword);
            }
            if (QueryStrings.Any(d => d.Key == "DefaultItemRotation") && !string.IsNullOrEmpty(QueryStrings.FirstOrDefault(d => d.Key == "DefaultItemRotation").Value))
            {
                var keyword = QueryStrings.FirstOrDefault(d => d.Key == "DefaultItemRotation").Value;
                query = query.Where(d=>d.DefaultItemRotation.Contains(keyword));
            }
            

			//Query DefaultRotation (string)
			if (QueryStrings.Any(d => d.Key == "DefaultRotation_eq") && !string.IsNullOrEmpty(QueryStrings.FirstOrDefault(d => d.Key == "DefaultRotation_eq").Value))
            {
                var keyword = QueryStrings.FirstOrDefault(d => d.Key == "DefaultRotation_eq").Value;
                query = query.Where(d=>d.DefaultRotation == keyword);
            }
            if (QueryStrings.Any(d => d.Key == "DefaultRotation") && !string.IsNullOrEmpty(QueryStrings.FirstOrDefault(d => d.Key == "DefaultRotation").Value))
            {
                var keyword = QueryStrings.FirstOrDefault(d => d.Key == "DefaultRotation").Value;
                query = query.Where(d=>d.DefaultRotation.Contains(keyword));
            }
            

			//Query DefaultStrategy (Nullable<int>)
			if (QueryStrings.Any(d => d.Key == "DefaultStrategyFrom") && QueryStrings.Any(d => d.Key == "DefaultStrategyTo"))
                if (int.TryParse(QueryStrings.FirstOrDefault(d => d.Key == "DefaultStrategyFrom").Value, out int fromVal) && int.TryParse(QueryStrings.FirstOrDefault(d => d.Key == "DefaultStrategyTo").Value, out int toVal))
                    query = query.Where(d => fromVal <= d.DefaultStrategy && d.DefaultStrategy <= toVal);

			//Query DefaultPutawayStrategy (Nullable<int>)
			if (QueryStrings.Any(d => d.Key == "DefaultPutawayStrategyFrom") && QueryStrings.Any(d => d.Key == "DefaultPutawayStrategyTo"))
                if (int.TryParse(QueryStrings.FirstOrDefault(d => d.Key == "DefaultPutawayStrategyFrom").Value, out int fromVal) && int.TryParse(QueryStrings.FirstOrDefault(d => d.Key == "DefaultPutawayStrategyTo").Value, out int toVal))
                    query = query.Where(d => fromVal <= d.DefaultPutawayStrategy && d.DefaultPutawayStrategy <= toVal);

			//Query DefaultInboundQCLocation (Nullable<int>)
			if (QueryStrings.Any(d => d.Key == "DefaultInboundQCLocationFrom") && QueryStrings.Any(d => d.Key == "DefaultInboundQCLocationTo"))
                if (int.TryParse(QueryStrings.FirstOrDefault(d => d.Key == "DefaultInboundQCLocationFrom").Value, out int fromVal) && int.TryParse(QueryStrings.FirstOrDefault(d => d.Key == "DefaultInboundQCLocationTo").Value, out int toVal))
                    query = query.Where(d => fromVal <= d.DefaultInboundQCLocation && d.DefaultInboundQCLocation <= toVal);

			//Query DefaultOutboundQCLocation (Nullable<int>)
			if (QueryStrings.Any(d => d.Key == "DefaultOutboundQCLocationFrom") && QueryStrings.Any(d => d.Key == "DefaultOutboundQCLocationTo"))
                if (int.TryParse(QueryStrings.FirstOrDefault(d => d.Key == "DefaultOutboundQCLocationFrom").Value, out int fromVal) && int.TryParse(QueryStrings.FirstOrDefault(d => d.Key == "DefaultOutboundQCLocationTo").Value, out int toVal))
                    query = query.Where(d => fromVal <= d.DefaultOutboundQCLocation && d.DefaultOutboundQCLocation <= toVal);

			//Query DefaultReturnsReceiptLocation (Nullable<int>)
			if (QueryStrings.Any(d => d.Key == "DefaultReturnsReceiptLocationFrom") && QueryStrings.Any(d => d.Key == "DefaultReturnsReceiptLocationTo"))
                if (int.TryParse(QueryStrings.FirstOrDefault(d => d.Key == "DefaultReturnsReceiptLocationFrom").Value, out int fromVal) && int.TryParse(QueryStrings.FirstOrDefault(d => d.Key == "DefaultReturnsReceiptLocationTo").Value, out int toVal))
                    query = query.Where(d => fromVal <= d.DefaultReturnsReceiptLocation && d.DefaultReturnsReceiptLocation <= toVal);

			//Query DefaultPackingLocation (Nullable<int>)
			if (QueryStrings.Any(d => d.Key == "DefaultPackingLocationFrom") && QueryStrings.Any(d => d.Key == "DefaultPackingLocationTo"))
                if (int.TryParse(QueryStrings.FirstOrDefault(d => d.Key == "DefaultPackingLocationFrom").Value, out int fromVal) && int.TryParse(QueryStrings.FirstOrDefault(d => d.Key == "DefaultPackingLocationTo").Value, out int toVal))
                    query = query.Where(d => fromVal <= d.DefaultPackingLocation && d.DefaultPackingLocation <= toVal);

			//Query LPNBarcodeSymbology (string)
			if (QueryStrings.Any(d => d.Key == "LPNBarcodeSymbology_eq") && !string.IsNullOrEmpty(QueryStrings.FirstOrDefault(d => d.Key == "LPNBarcodeSymbology_eq").Value))
            {
                var keyword = QueryStrings.FirstOrDefault(d => d.Key == "LPNBarcodeSymbology_eq").Value;
                query = query.Where(d=>d.LPNBarcodeSymbology == keyword);
            }
            if (QueryStrings.Any(d => d.Key == "LPNBarcodeSymbology") && !string.IsNullOrEmpty(QueryStrings.FirstOrDefault(d => d.Key == "LPNBarcodeSymbology").Value))
            {
                var keyword = QueryStrings.FirstOrDefault(d => d.Key == "LPNBarcodeSymbology").Value;
                query = query.Where(d=>d.LPNBarcodeSymbology.Contains(keyword));
            }
            

			//Query LPNBarcodeFormat (string)
			if (QueryStrings.Any(d => d.Key == "LPNBarcodeFormat_eq") && !string.IsNullOrEmpty(QueryStrings.FirstOrDefault(d => d.Key == "LPNBarcodeFormat_eq").Value))
            {
                var keyword = QueryStrings.FirstOrDefault(d => d.Key == "LPNBarcodeFormat_eq").Value;
                query = query.Where(d=>d.LPNBarcodeFormat == keyword);
            }
            if (QueryStrings.Any(d => d.Key == "LPNBarcodeFormat") && !string.IsNullOrEmpty(QueryStrings.FirstOrDefault(d => d.Key == "LPNBarcodeFormat").Value))
            {
                var keyword = QueryStrings.FirstOrDefault(d => d.Key == "LPNBarcodeFormat").Value;
                query = query.Where(d=>d.LPNBarcodeFormat.Contains(keyword));
            }
            

			//Query LPNLength (Nullable<int>)
			if (QueryStrings.Any(d => d.Key == "LPNLengthFrom") && QueryStrings.Any(d => d.Key == "LPNLengthTo"))
                if (int.TryParse(QueryStrings.FirstOrDefault(d => d.Key == "LPNLengthFrom").Value, out int fromVal) && int.TryParse(QueryStrings.FirstOrDefault(d => d.Key == "LPNLengthTo").Value, out int toVal))
                    query = query.Where(d => fromVal <= d.LPNLength && d.LPNLength <= toVal);

			//Query LPNStartNumber (string)
			if (QueryStrings.Any(d => d.Key == "LPNStartNumber_eq") && !string.IsNullOrEmpty(QueryStrings.FirstOrDefault(d => d.Key == "LPNStartNumber_eq").Value))
            {
                var keyword = QueryStrings.FirstOrDefault(d => d.Key == "LPNStartNumber_eq").Value;
                query = query.Where(d=>d.LPNStartNumber == keyword);
            }
            if (QueryStrings.Any(d => d.Key == "LPNStartNumber") && !string.IsNullOrEmpty(QueryStrings.FirstOrDefault(d => d.Key == "LPNStartNumber").Value))
            {
                var keyword = QueryStrings.FirstOrDefault(d => d.Key == "LPNStartNumber").Value;
                query = query.Where(d=>d.LPNStartNumber.Contains(keyword));
            }
            

			//Query LPNNextNumber (string)
			if (QueryStrings.Any(d => d.Key == "LPNNextNumber_eq") && !string.IsNullOrEmpty(QueryStrings.FirstOrDefault(d => d.Key == "LPNNextNumber_eq").Value))
            {
                var keyword = QueryStrings.FirstOrDefault(d => d.Key == "LPNNextNumber_eq").Value;
                query = query.Where(d=>d.LPNNextNumber == keyword);
            }
            if (QueryStrings.Any(d => d.Key == "LPNNextNumber") && !string.IsNullOrEmpty(QueryStrings.FirstOrDefault(d => d.Key == "LPNNextNumber").Value))
            {
                var keyword = QueryStrings.FirstOrDefault(d => d.Key == "LPNNextNumber").Value;
                query = query.Where(d=>d.LPNNextNumber.Contains(keyword));
            }
            

			//Query LPNRollbackNumber (string)
			if (QueryStrings.Any(d => d.Key == "LPNRollbackNumber_eq") && !string.IsNullOrEmpty(QueryStrings.FirstOrDefault(d => d.Key == "LPNRollbackNumber_eq").Value))
            {
                var keyword = QueryStrings.FirstOrDefault(d => d.Key == "LPNRollbackNumber_eq").Value;
                query = query.Where(d=>d.LPNRollbackNumber == keyword);
            }
            if (QueryStrings.Any(d => d.Key == "LPNRollbackNumber") && !string.IsNullOrEmpty(QueryStrings.FirstOrDefault(d => d.Key == "LPNRollbackNumber").Value))
            {
                var keyword = QueryStrings.FirstOrDefault(d => d.Key == "LPNRollbackNumber").Value;
                query = query.Where(d=>d.LPNRollbackNumber.Contains(keyword));
            }
            

			//Query CaseLabelType (string)
			if (QueryStrings.Any(d => d.Key == "CaseLabelType_eq") && !string.IsNullOrEmpty(QueryStrings.FirstOrDefault(d => d.Key == "CaseLabelType_eq").Value))
            {
                var keyword = QueryStrings.FirstOrDefault(d => d.Key == "CaseLabelType_eq").Value;
                query = query.Where(d=>d.CaseLabelType == keyword);
            }
            if (QueryStrings.Any(d => d.Key == "CaseLabelType") && !string.IsNullOrEmpty(QueryStrings.FirstOrDefault(d => d.Key == "CaseLabelType").Value))
            {
                var keyword = QueryStrings.FirstOrDefault(d => d.Key == "CaseLabelType").Value;
                query = query.Where(d=>d.CaseLabelType.Contains(keyword));
            }
            

			//Query ApplicationID (string)
			if (QueryStrings.Any(d => d.Key == "ApplicationID_eq") && !string.IsNullOrEmpty(QueryStrings.FirstOrDefault(d => d.Key == "ApplicationID_eq").Value))
            {
                var keyword = QueryStrings.FirstOrDefault(d => d.Key == "ApplicationID_eq").Value;
                query = query.Where(d=>d.ApplicationID == keyword);
            }
            if (QueryStrings.Any(d => d.Key == "ApplicationID") && !string.IsNullOrEmpty(QueryStrings.FirstOrDefault(d => d.Key == "ApplicationID").Value))
            {
                var keyword = QueryStrings.FirstOrDefault(d => d.Key == "ApplicationID").Value;
                query = query.Where(d=>d.ApplicationID.Contains(keyword));
            }
            

			//Query SSCCFirstDigit (string)
			if (QueryStrings.Any(d => d.Key == "SSCCFirstDigit_eq") && !string.IsNullOrEmpty(QueryStrings.FirstOrDefault(d => d.Key == "SSCCFirstDigit_eq").Value))
            {
                var keyword = QueryStrings.FirstOrDefault(d => d.Key == "SSCCFirstDigit_eq").Value;
                query = query.Where(d=>d.SSCCFirstDigit == keyword);
            }
            if (QueryStrings.Any(d => d.Key == "SSCCFirstDigit") && !string.IsNullOrEmpty(QueryStrings.FirstOrDefault(d => d.Key == "SSCCFirstDigit").Value))
            {
                var keyword = QueryStrings.FirstOrDefault(d => d.Key == "SSCCFirstDigit").Value;
                query = query.Where(d=>d.SSCCFirstDigit.Contains(keyword));
            }
            

			//Query UCCVendor (string)
			if (QueryStrings.Any(d => d.Key == "UCCVendor_eq") && !string.IsNullOrEmpty(QueryStrings.FirstOrDefault(d => d.Key == "UCCVendor_eq").Value))
            {
                var keyword = QueryStrings.FirstOrDefault(d => d.Key == "UCCVendor_eq").Value;
                query = query.Where(d=>d.UCCVendor == keyword);
            }
            if (QueryStrings.Any(d => d.Key == "UCCVendor") && !string.IsNullOrEmpty(QueryStrings.FirstOrDefault(d => d.Key == "UCCVendor").Value))
            {
                var keyword = QueryStrings.FirstOrDefault(d => d.Key == "UCCVendor").Value;
                query = query.Where(d=>d.UCCVendor.Contains(keyword));
            }
            

			//Query AllowCommingledLPN (bool)
			if (QueryStrings.Any(d => d.Key == "AllowCommingledLPN"))
            {
                var qValue = QueryStrings.FirstOrDefault(d => d.Key == "AllowCommingledLPN").Value;
                if (bool.TryParse(qValue, out bool qBoolValue))
                    query = query.Where(d => qBoolValue == d.AllowCommingledLPN);
            }

			//Query LabelTemplate (Nullable<int>)
			if (QueryStrings.Any(d => d.Key == "LabelTemplateFrom") && QueryStrings.Any(d => d.Key == "LabelTemplateTo"))
                if (int.TryParse(QueryStrings.FirstOrDefault(d => d.Key == "LabelTemplateFrom").Value, out int fromVal) && int.TryParse(QueryStrings.FirstOrDefault(d => d.Key == "LabelTemplateTo").Value, out int toVal))
                    query = query.Where(d => fromVal <= d.LabelTemplate && d.LabelTemplate <= toVal);

			//Query StandardCarrierAlphaCode (string)
			if (QueryStrings.Any(d => d.Key == "StandardCarrierAlphaCode_eq") && !string.IsNullOrEmpty(QueryStrings.FirstOrDefault(d => d.Key == "StandardCarrierAlphaCode_eq").Value))
            {
                var keyword = QueryStrings.FirstOrDefault(d => d.Key == "StandardCarrierAlphaCode_eq").Value;
                query = query.Where(d=>d.StandardCarrierAlphaCode == keyword);
            }
            if (QueryStrings.Any(d => d.Key == "StandardCarrierAlphaCode") && !string.IsNullOrEmpty(QueryStrings.FirstOrDefault(d => d.Key == "StandardCarrierAlphaCode").Value))
            {
                var keyword = QueryStrings.FirstOrDefault(d => d.Key == "StandardCarrierAlphaCode").Value;
                query = query.Where(d=>d.StandardCarrierAlphaCode.Contains(keyword));
            }
            

			//Query CreditLimit (decimal)
			if (QueryStrings.Any(d => d.Key == "CreditLimitFrom") && QueryStrings.Any(d => d.Key == "CreditLimitTo"))
                if (decimal.TryParse(QueryStrings.FirstOrDefault(d => d.Key == "CreditLimitFrom").Value, out decimal fromVal) && decimal.TryParse(QueryStrings.FirstOrDefault(d => d.Key == "CreditLimitTo").Value, out decimal toVal))
                    query = query.Where(d => fromVal <= d.CreditLimit && d.CreditLimit <= toVal);
            
            if (QueryStrings.Any(d => d.Key == "CreditLimit"))
                if (decimal.TryParse(QueryStrings.FirstOrDefault(d => d.Key == "CreditLimit").Value, out decimal val))
                    query = query.Where(d => val == d.CreditLimit);


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
		
        public static IQueryable<tbl_WMS_Storer> _sortBuilder(IQueryable<tbl_WMS_Storer> query, Dictionary<string, string> QueryStrings)
        {
            if (QueryStrings.Any(d => d.Key == "SortBy"))
            {
                var sorts = QueryStrings.FirstOrDefault(d => d.Key == "SortBy").Value.Replace("[", "").Replace("]", "").Split(',');
                
                foreach (var item in sorts)
                    if (!string.IsNullOrEmpty(item))
                    {
                        var ordered = query as IOrderedQueryable<tbl_WMS_Storer>;
                        bool isOrdered = ordered.ToString().IndexOf("ORDER BY") !=-1;

                        switch (item)
                        {
							case "Id":
								query = isOrdered ? ordered.ThenBy(o => o.Id) : query.OrderBy(o => o.Id);
								 break;
							case "Id_desc":
                                query = isOrdered ? ordered.ThenByDescending(o => o.Id) : query.OrderByDescending(o => o.Id);
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
							case "isActivated":
								query = isOrdered ? ordered.ThenBy(o => o.isActivated) : query.OrderBy(o => o.isActivated);
								 break;
							case "isActivated_desc":
                                query = isOrdered ? ordered.ThenByDescending(o => o.isActivated) : query.OrderByDescending(o => o.isActivated);
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
							case "IDCartonGroup":
								query = isOrdered ? ordered.ThenBy(o => o.IDCartonGroup) : query.OrderBy(o => o.IDCartonGroup);
								 break;
							case "IDCartonGroup_desc":
                                query = isOrdered ? ordered.ThenByDescending(o => o.IDCartonGroup) : query.OrderByDescending(o => o.IDCartonGroup);
                                break;
							case "IsEnablePacking":
								query = isOrdered ? ordered.ThenBy(o => o.IsEnablePacking) : query.OrderBy(o => o.IsEnablePacking);
								 break;
							case "IsEnablePacking_desc":
                                query = isOrdered ? ordered.ThenByDescending(o => o.IsEnablePacking) : query.OrderByDescending(o => o.IsEnablePacking);
                                break;
							case "IsQCInspectAtPack":
								query = isOrdered ? ordered.ThenBy(o => o.IsQCInspectAtPack) : query.OrderBy(o => o.IsQCInspectAtPack);
								 break;
							case "IsQCInspectAtPack_desc":
                                query = isOrdered ? ordered.ThenByDescending(o => o.IsQCInspectAtPack) : query.OrderByDescending(o => o.IsQCInspectAtPack);
                                break;
							case "IsAllowMultiZoneRainbowPallet":
								query = isOrdered ? ordered.ThenBy(o => o.IsAllowMultiZoneRainbowPallet) : query.OrderBy(o => o.IsAllowMultiZoneRainbowPallet);
								 break;
							case "IsAllowMultiZoneRainbowPallet_desc":
                                query = isOrdered ? ordered.ThenByDescending(o => o.IsAllowMultiZoneRainbowPallet) : query.OrderByDescending(o => o.IsAllowMultiZoneRainbowPallet);
                                break;
							case "DefaultItemRotation":
								query = isOrdered ? ordered.ThenBy(o => o.DefaultItemRotation) : query.OrderBy(o => o.DefaultItemRotation);
								 break;
							case "DefaultItemRotation_desc":
                                query = isOrdered ? ordered.ThenByDescending(o => o.DefaultItemRotation) : query.OrderByDescending(o => o.DefaultItemRotation);
                                break;
							case "DefaultRotation":
								query = isOrdered ? ordered.ThenBy(o => o.DefaultRotation) : query.OrderBy(o => o.DefaultRotation);
								 break;
							case "DefaultRotation_desc":
                                query = isOrdered ? ordered.ThenByDescending(o => o.DefaultRotation) : query.OrderByDescending(o => o.DefaultRotation);
                                break;
							case "DefaultStrategy":
								query = isOrdered ? ordered.ThenBy(o => o.DefaultStrategy) : query.OrderBy(o => o.DefaultStrategy);
								 break;
							case "DefaultStrategy_desc":
                                query = isOrdered ? ordered.ThenByDescending(o => o.DefaultStrategy) : query.OrderByDescending(o => o.DefaultStrategy);
                                break;
							case "DefaultPutawayStrategy":
								query = isOrdered ? ordered.ThenBy(o => o.DefaultPutawayStrategy) : query.OrderBy(o => o.DefaultPutawayStrategy);
								 break;
							case "DefaultPutawayStrategy_desc":
                                query = isOrdered ? ordered.ThenByDescending(o => o.DefaultPutawayStrategy) : query.OrderByDescending(o => o.DefaultPutawayStrategy);
                                break;
							case "DefaultInboundQCLocation":
								query = isOrdered ? ordered.ThenBy(o => o.DefaultInboundQCLocation) : query.OrderBy(o => o.DefaultInboundQCLocation);
								 break;
							case "DefaultInboundQCLocation_desc":
                                query = isOrdered ? ordered.ThenByDescending(o => o.DefaultInboundQCLocation) : query.OrderByDescending(o => o.DefaultInboundQCLocation);
                                break;
							case "DefaultOutboundQCLocation":
								query = isOrdered ? ordered.ThenBy(o => o.DefaultOutboundQCLocation) : query.OrderBy(o => o.DefaultOutboundQCLocation);
								 break;
							case "DefaultOutboundQCLocation_desc":
                                query = isOrdered ? ordered.ThenByDescending(o => o.DefaultOutboundQCLocation) : query.OrderByDescending(o => o.DefaultOutboundQCLocation);
                                break;
							case "DefaultReturnsReceiptLocation":
								query = isOrdered ? ordered.ThenBy(o => o.DefaultReturnsReceiptLocation) : query.OrderBy(o => o.DefaultReturnsReceiptLocation);
								 break;
							case "DefaultReturnsReceiptLocation_desc":
                                query = isOrdered ? ordered.ThenByDescending(o => o.DefaultReturnsReceiptLocation) : query.OrderByDescending(o => o.DefaultReturnsReceiptLocation);
                                break;
							case "DefaultPackingLocation":
								query = isOrdered ? ordered.ThenBy(o => o.DefaultPackingLocation) : query.OrderBy(o => o.DefaultPackingLocation);
								 break;
							case "DefaultPackingLocation_desc":
                                query = isOrdered ? ordered.ThenByDescending(o => o.DefaultPackingLocation) : query.OrderByDescending(o => o.DefaultPackingLocation);
                                break;
							case "LPNBarcodeSymbology":
								query = isOrdered ? ordered.ThenBy(o => o.LPNBarcodeSymbology) : query.OrderBy(o => o.LPNBarcodeSymbology);
								 break;
							case "LPNBarcodeSymbology_desc":
                                query = isOrdered ? ordered.ThenByDescending(o => o.LPNBarcodeSymbology) : query.OrderByDescending(o => o.LPNBarcodeSymbology);
                                break;
							case "LPNBarcodeFormat":
								query = isOrdered ? ordered.ThenBy(o => o.LPNBarcodeFormat) : query.OrderBy(o => o.LPNBarcodeFormat);
								 break;
							case "LPNBarcodeFormat_desc":
                                query = isOrdered ? ordered.ThenByDescending(o => o.LPNBarcodeFormat) : query.OrderByDescending(o => o.LPNBarcodeFormat);
                                break;
							case "LPNLength":
								query = isOrdered ? ordered.ThenBy(o => o.LPNLength) : query.OrderBy(o => o.LPNLength);
								 break;
							case "LPNLength_desc":
                                query = isOrdered ? ordered.ThenByDescending(o => o.LPNLength) : query.OrderByDescending(o => o.LPNLength);
                                break;
							case "LPNStartNumber":
								query = isOrdered ? ordered.ThenBy(o => o.LPNStartNumber) : query.OrderBy(o => o.LPNStartNumber);
								 break;
							case "LPNStartNumber_desc":
                                query = isOrdered ? ordered.ThenByDescending(o => o.LPNStartNumber) : query.OrderByDescending(o => o.LPNStartNumber);
                                break;
							case "LPNNextNumber":
								query = isOrdered ? ordered.ThenBy(o => o.LPNNextNumber) : query.OrderBy(o => o.LPNNextNumber);
								 break;
							case "LPNNextNumber_desc":
                                query = isOrdered ? ordered.ThenByDescending(o => o.LPNNextNumber) : query.OrderByDescending(o => o.LPNNextNumber);
                                break;
							case "LPNRollbackNumber":
								query = isOrdered ? ordered.ThenBy(o => o.LPNRollbackNumber) : query.OrderBy(o => o.LPNRollbackNumber);
								 break;
							case "LPNRollbackNumber_desc":
                                query = isOrdered ? ordered.ThenByDescending(o => o.LPNRollbackNumber) : query.OrderByDescending(o => o.LPNRollbackNumber);
                                break;
							case "CaseLabelType":
								query = isOrdered ? ordered.ThenBy(o => o.CaseLabelType) : query.OrderBy(o => o.CaseLabelType);
								 break;
							case "CaseLabelType_desc":
                                query = isOrdered ? ordered.ThenByDescending(o => o.CaseLabelType) : query.OrderByDescending(o => o.CaseLabelType);
                                break;
							case "ApplicationID":
								query = isOrdered ? ordered.ThenBy(o => o.ApplicationID) : query.OrderBy(o => o.ApplicationID);
								 break;
							case "ApplicationID_desc":
                                query = isOrdered ? ordered.ThenByDescending(o => o.ApplicationID) : query.OrderByDescending(o => o.ApplicationID);
                                break;
							case "SSCCFirstDigit":
								query = isOrdered ? ordered.ThenBy(o => o.SSCCFirstDigit) : query.OrderBy(o => o.SSCCFirstDigit);
								 break;
							case "SSCCFirstDigit_desc":
                                query = isOrdered ? ordered.ThenByDescending(o => o.SSCCFirstDigit) : query.OrderByDescending(o => o.SSCCFirstDigit);
                                break;
							case "UCCVendor":
								query = isOrdered ? ordered.ThenBy(o => o.UCCVendor) : query.OrderBy(o => o.UCCVendor);
								 break;
							case "UCCVendor_desc":
                                query = isOrdered ? ordered.ThenByDescending(o => o.UCCVendor) : query.OrderByDescending(o => o.UCCVendor);
                                break;
							case "AllowCommingledLPN":
								query = isOrdered ? ordered.ThenBy(o => o.AllowCommingledLPN) : query.OrderBy(o => o.AllowCommingledLPN);
								 break;
							case "AllowCommingledLPN_desc":
                                query = isOrdered ? ordered.ThenByDescending(o => o.AllowCommingledLPN) : query.OrderByDescending(o => o.AllowCommingledLPN);
                                break;
							case "LabelTemplate":
								query = isOrdered ? ordered.ThenBy(o => o.LabelTemplate) : query.OrderBy(o => o.LabelTemplate);
								 break;
							case "LabelTemplate_desc":
                                query = isOrdered ? ordered.ThenByDescending(o => o.LabelTemplate) : query.OrderByDescending(o => o.LabelTemplate);
                                break;
							case "StandardCarrierAlphaCode":
								query = isOrdered ? ordered.ThenBy(o => o.StandardCarrierAlphaCode) : query.OrderBy(o => o.StandardCarrierAlphaCode);
								 break;
							case "StandardCarrierAlphaCode_desc":
                                query = isOrdered ? ordered.ThenByDescending(o => o.StandardCarrierAlphaCode) : query.OrderByDescending(o => o.StandardCarrierAlphaCode);
                                break;
							case "CreditLimit":
								query = isOrdered ? ordered.ThenBy(o => o.CreditLimit) : query.OrderBy(o => o.CreditLimit);
								 break;
							case "CreditLimit_desc":
                                query = isOrdered ? ordered.ThenByDescending(o => o.CreditLimit) : query.OrderByDescending(o => o.CreditLimit);
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

        public static IQueryable<tbl_WMS_Storer> _pagingBuilder(IQueryable<tbl_WMS_Storer> query, Dictionary<string, string> QueryStrings)
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






