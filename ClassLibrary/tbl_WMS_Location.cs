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
    
    
    public partial class tbl_WMS_Location
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public tbl_WMS_Location()
        {
            this.tbl_WMS_AdjustmentDetail = new HashSet<tbl_WMS_AdjustmentDetail>();
            this.tbl_WMS_ItemInLocation = new HashSet<tbl_WMS_ItemInLocation>();
            this.tbl_WMS_LotLPNLocation = new HashSet<tbl_WMS_LotLPNLocation>();
            this.tbl_WMS_ReceiptPalletization = new HashSet<tbl_WMS_ReceiptPalletization>();
            this.tbl_WMS_Transaction = new HashSet<tbl_WMS_Transaction>();
            this.tbl_WMS_Transaction1 = new HashSet<tbl_WMS_Transaction>();
            this.tbl_WMS_Zone1 = new HashSet<tbl_WMS_Zone>();
            this.tbl_WMS_Zone2 = new HashSet<tbl_WMS_Zone>();
            this.tbl_WMS_Zone3 = new HashSet<tbl_WMS_Zone>();
        }
    
        public int IDBranch { get; set; }
        public int Id { get; set; }
        public string Code { get; set; }
        public string Name { get; set; }
        public string Remark { get; set; }
        public Nullable<int> Sort { get; set; }
        public bool IsDisabled { get; set; }
        public bool IsDeleted { get; set; }
        public string CreatedBy { get; set; }
        public string ModifiedBy { get; set; }
        public System.DateTime CreatedDate { get; set; }
        public System.DateTime ModifiedDate { get; set; }
        public int IDZone { get; set; }
        public string LocationType { get; set; }
        public bool IsAutomaticallyShipPickedProduct { get; set; }
        public bool IsLoseID { get; set; }
        public string RouteSequence { get; set; }
        public bool IsCommingleItem { get; set; }
        public bool IsCommingleLot { get; set; }
        public decimal Length { get; set; }
        public decimal Width { get; set; }
        public string LocationFlag { get; set; }
        public int FootPrint { get; set; }
        public int StackLimit { get; set; }
        public decimal Height { get; set; }
        public decimal CubicCapacity { get; set; }
        public string LocationCategory { get; set; }
        public string LocationHandling { get; set; }
        public int Level { get; set; }
        public decimal WeightCapacity { get; set; }
        public string MoverType { get; set; }
        public int XCoordinate { get; set; }
        public int YCoordinate { get; set; }
        public int ZCoordinate { get; set; }
        public int Orientation { get; set; }
        //List 0:1
        public virtual tbl_BRA_Branch tbl_BRA_Branch { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tbl_WMS_AdjustmentDetail> tbl_WMS_AdjustmentDetail { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tbl_WMS_ItemInLocation> tbl_WMS_ItemInLocation { get; set; }
        //List 0:1
        public virtual tbl_WMS_Zone tbl_WMS_Zone { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tbl_WMS_LotLPNLocation> tbl_WMS_LotLPNLocation { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tbl_WMS_ReceiptPalletization> tbl_WMS_ReceiptPalletization { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tbl_WMS_Transaction> tbl_WMS_Transaction { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tbl_WMS_Transaction> tbl_WMS_Transaction1 { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tbl_WMS_Zone> tbl_WMS_Zone1 { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tbl_WMS_Zone> tbl_WMS_Zone2 { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tbl_WMS_Zone> tbl_WMS_Zone3 { get; set; }
    }
}


namespace DTOModel
{
	using System;
	public partial class DTO_WMS_Location
	{
		public int IDBranch { get; set; }
		public int Id { get; set; }
		public string Code { get; set; }
		public string Name { get; set; }
		public string Remark { get; set; }
		public Nullable<int> Sort { get; set; }
		public bool IsDisabled { get; set; }
		public bool IsDeleted { get; set; }
		public string CreatedBy { get; set; }
		public string ModifiedBy { get; set; }
		public System.DateTime CreatedDate { get; set; }
		public System.DateTime ModifiedDate { get; set; }
		public int IDZone { get; set; }
		public string LocationType { get; set; }
		public bool IsAutomaticallyShipPickedProduct { get; set; }
		public bool IsLoseID { get; set; }
		public string RouteSequence { get; set; }
		public bool IsCommingleItem { get; set; }
		public bool IsCommingleLot { get; set; }
		public decimal Length { get; set; }
		public decimal Width { get; set; }
		public string LocationFlag { get; set; }
		public int FootPrint { get; set; }
		public int StackLimit { get; set; }
		public decimal Height { get; set; }
		public decimal CubicCapacity { get; set; }
		public string LocationCategory { get; set; }
		public string LocationHandling { get; set; }
		public int Level { get; set; }
		public decimal WeightCapacity { get; set; }
		public string MoverType { get; set; }
		public int XCoordinate { get; set; }
		public int YCoordinate { get; set; }
		public int ZCoordinate { get; set; }
		public int Orientation { get; set; }
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

    public static partial class BS_WMS_Location 
    {
        public static dynamic getSearch(AppEntities db, int IDBranch, int StaffID, Dictionary<string, string> QueryStrings)
        {
            return get(db, IDBranch,StaffID, QueryStrings);
        }

		public static IQueryable<DTO_WMS_Location> get(AppEntities db, int IDBranch, int StaffID, Dictionary<string, string> QueryStrings)
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
            package.Workbook.Properties.Title = "ART-DMS WMS_Location";
            package.Workbook.Properties.Author = "hung.vu@codeart.vn";
            package.Workbook.Properties.Application = "ART-DMS";
            package.Workbook.Properties.Company = "A.R.T Distribution";

            ExcelWorkbook workBook = package.Workbook;
            if (workBook != null)
            {
                var ws = workBook.Worksheets.FirstOrDefault();
                var data = _queryBuilder(db, IDBranch, StaffID, QueryStrings).ToList();

                //var BRA_BranchList = BS_BRA_Branch.get(db,IDBranch, StaffID,QueryStrings).Select(s => new ItemModel { Id = s.Id, Name = s.Name });
                //var WMS_ZoneList = BS_WMS_Zone.get(db,IDBranch, StaffID,QueryStrings).Select(s => new ItemModel { Id = s.Id, Name = s.Name });
                 

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

		public static DTO_WMS_Location getAnItem(AppEntities db, int IDBranch, int StaffID, int id)
        {
            var dbResult = db.tbl_WMS_Location.Find(id);

			//if (dbResult == null || (IDBranch != 0 && dbResult.IDBranch != IDBranch))
			//	return null; 
			//else 
				return toDTO(dbResult);
			
        }
		
		public static DTO_WMS_Location getAnItemByCode(AppEntities db, int IDBranch, int StaffID, string code)
        {
            var dbResult = db.tbl_WMS_Location
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
            var dbitem = db.tbl_WMS_Location.Find(Id);
            
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
					errorLog.logMessage("put_WMS_Location",e);
                    result = false;
                }
            }
            else
                if (QueryStrings.Any(d => d.Key == "ForceCreate"))
                    result =  post(db, IDBranch, StaffID, item, Username) != null;
                
            return result;
        }

        public static void patchDynamicToDB(dynamic item, tbl_WMS_Location dbitem, string Username)
        {
            Type type = typeof(tbl_WMS_Location);
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

        public static void patchDTOtoDBValue( DTO_WMS_Location item, tbl_WMS_Location dbitem)
        {
            if (item == null){
                dbitem = null;
                return;
            }
            							
			dbitem.IDBranch = item.IDBranch;							
			dbitem.Code = item.Code;							
			dbitem.Name = item.Name;							
			dbitem.Remark = item.Remark;							
			dbitem.Sort = item.Sort;							
			dbitem.IsDisabled = item.IsDisabled;							
			dbitem.IsDeleted = item.IsDeleted;							
			dbitem.IDZone = item.IDZone;							
			dbitem.LocationType = item.LocationType;							
			dbitem.IsAutomaticallyShipPickedProduct = item.IsAutomaticallyShipPickedProduct;							
			dbitem.IsLoseID = item.IsLoseID;							
			dbitem.RouteSequence = item.RouteSequence;							
			dbitem.IsCommingleItem = item.IsCommingleItem;							
			dbitem.IsCommingleLot = item.IsCommingleLot;							
			dbitem.Length = item.Length;							
			dbitem.Width = item.Width;							
			dbitem.LocationFlag = item.LocationFlag;							
			dbitem.FootPrint = item.FootPrint;							
			dbitem.StackLimit = item.StackLimit;							
			dbitem.Height = item.Height;							
			dbitem.CubicCapacity = item.CubicCapacity;							
			dbitem.LocationCategory = item.LocationCategory;							
			dbitem.LocationHandling = item.LocationHandling;							
			dbitem.Level = item.Level;							
			dbitem.WeightCapacity = item.WeightCapacity;							
			dbitem.MoverType = item.MoverType;							
			dbitem.XCoordinate = item.XCoordinate;							
			dbitem.YCoordinate = item.YCoordinate;							
			dbitem.ZCoordinate = item.ZCoordinate;							
			dbitem.Orientation = item.Orientation;        }

		public static DTO_WMS_Location post(AppEntities db, int IDBranch, int StaffID, dynamic item, string Username)
        {
            tbl_WMS_Location dbitem = new tbl_WMS_Location();
            if (item != null)
            {
                patchDynamicToDB(item, dbitem, Username);
                
				dbitem.CreatedBy = Username;
				dbitem.CreatedDate = DateTime.Now;				
                try
                {
					db.tbl_WMS_Location.Add(dbitem);
                    db.SaveChanges();
				
                }
                catch (DbEntityValidationException e)
                {
					errorLog.logMessage("post_WMS_Location",e);
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
                Type type = Type.GetType("BaseBusiness.BS_WMS_Location, ClassLibrary");
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
                        var target = new tbl_WMS_Location();
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
                    
                    tbl_WMS_Location dbitem = new tbl_WMS_Location();
                    if (it.Id == null || string.IsNullOrEmpty(it.Id.Value) || it.Id == "0")
                    {
                        dbitem = new tbl_WMS_Location();
                        dbitem.CreatedBy = Username;
				        dbitem.CreatedDate = DateTime.Now;
                                            }
                    else
                    {
                        dbitem = db.tbl_WMS_Location.Find((int)it.Id);
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
                        
                        if (dbitem.Id == 0) db.tbl_WMS_Location.Add(dbitem);
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
                    errorLog.logMessage("post_WMS_Location",e);
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

            var dbitems = db.tbl_WMS_Location.Where(d => IDs.Contains(d.Id));
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
                    BS_Version.update_Version(db, IDBranch, "DTO_WMS_Location", updateDate, Username);
                }
			
            }
            catch (DbEntityValidationException e)
            {
				errorLog.logMessage("delete_WMS_Location",e);
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

			
            var dbitems = db.tbl_WMS_Location.Where(d => IDs.Contains(d.Id));
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
                    BS_Version.update_Version(db, IDBranch, "DTO_WMS_Location", updateDate, Username);
                }
			
            }
            catch (DbEntityValidationException e)
            {
				errorLog.logMessage("disable_WMS_Location",e);
                result = false;
            }
            
            return result;
        }

		
		//---//
		public static bool check_Exists(AppEntities db, int id)
		{
             
            return db.tbl_WMS_Location.Any(e => e.Id == id && e.IsDeleted == false);
            
		}
		
		public static bool check_Exists(AppEntities db, string Code)
		{
             
            return db.tbl_WMS_Location.Any(e => e.Code == Code && e.IsDeleted == false);
            
		}
		
		//---//
		public static IQueryable<DTO_WMS_Location> toDTO(IQueryable<tbl_WMS_Location> query)
        {
			return query
			.Select(s => new DTO_WMS_Location(){							
				IDBranch = s.IDBranch,							
				Id = s.Id,							
				Code = s.Code,							
				Name = s.Name,							
				Remark = s.Remark,							
				Sort = s.Sort,							
				IsDisabled = s.IsDisabled,							
				IsDeleted = s.IsDeleted,							
				CreatedBy = s.CreatedBy,							
				ModifiedBy = s.ModifiedBy,							
				CreatedDate = s.CreatedDate,							
				ModifiedDate = s.ModifiedDate,							
				IDZone = s.IDZone,							
				LocationType = s.LocationType,							
				IsAutomaticallyShipPickedProduct = s.IsAutomaticallyShipPickedProduct,							
				IsLoseID = s.IsLoseID,							
				RouteSequence = s.RouteSequence,							
				IsCommingleItem = s.IsCommingleItem,							
				IsCommingleLot = s.IsCommingleLot,							
				Length = s.Length,							
				Width = s.Width,							
				LocationFlag = s.LocationFlag,							
				FootPrint = s.FootPrint,							
				StackLimit = s.StackLimit,							
				Height = s.Height,							
				CubicCapacity = s.CubicCapacity,							
				LocationCategory = s.LocationCategory,							
				LocationHandling = s.LocationHandling,							
				Level = s.Level,							
				WeightCapacity = s.WeightCapacity,							
				MoverType = s.MoverType,							
				XCoordinate = s.XCoordinate,							
				YCoordinate = s.YCoordinate,							
				ZCoordinate = s.ZCoordinate,							
				Orientation = s.Orientation,					
			});//.OrderBy(o => o.Sort == null).ThenBy(u => u.Sort);
                              
        }

		public static DTO_WMS_Location toDTO(tbl_WMS_Location dbResult)
        {
			if (dbResult != null)
			{
				return new DTO_WMS_Location()
				{							
					IDBranch = dbResult.IDBranch,							
					Id = dbResult.Id,							
					Code = dbResult.Code,							
					Name = dbResult.Name,							
					Remark = dbResult.Remark,							
					Sort = dbResult.Sort,							
					IsDisabled = dbResult.IsDisabled,							
					IsDeleted = dbResult.IsDeleted,							
					CreatedBy = dbResult.CreatedBy,							
					ModifiedBy = dbResult.ModifiedBy,							
					CreatedDate = dbResult.CreatedDate,							
					ModifiedDate = dbResult.ModifiedDate,							
					IDZone = dbResult.IDZone,							
					LocationType = dbResult.LocationType,							
					IsAutomaticallyShipPickedProduct = dbResult.IsAutomaticallyShipPickedProduct,							
					IsLoseID = dbResult.IsLoseID,							
					RouteSequence = dbResult.RouteSequence,							
					IsCommingleItem = dbResult.IsCommingleItem,							
					IsCommingleLot = dbResult.IsCommingleLot,							
					Length = dbResult.Length,							
					Width = dbResult.Width,							
					LocationFlag = dbResult.LocationFlag,							
					FootPrint = dbResult.FootPrint,							
					StackLimit = dbResult.StackLimit,							
					Height = dbResult.Height,							
					CubicCapacity = dbResult.CubicCapacity,							
					LocationCategory = dbResult.LocationCategory,							
					LocationHandling = dbResult.LocationHandling,							
					Level = dbResult.Level,							
					WeightCapacity = dbResult.WeightCapacity,							
					MoverType = dbResult.MoverType,							
					XCoordinate = dbResult.XCoordinate,							
					YCoordinate = dbResult.YCoordinate,							
					ZCoordinate = dbResult.ZCoordinate,							
					Orientation = dbResult.Orientation,
				};
			}
			else
				return null; 
        }

		public static IQueryable<tbl_WMS_Location> _queryBuilder(AppEntities db, int IDBranch, int StaffID, Dictionary<string, string> QueryStrings)
        {
            
			IQueryable<tbl_WMS_Location> query = db.tbl_WMS_Location.AsNoTracking();//.Where(d => d.IsDeleted == false);
			

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


			//Query IDZone (int)
			if (QueryStrings.Any(d => d.Key == "IDZone"))
            {
                var IDList = QueryStrings.FirstOrDefault(d => d.Key == "IDZone").Value.Replace("[", "").Replace("]", "").Split(',');
                List<int> IDs = new List<int>();
                foreach (var item in IDList)
                    if (int.TryParse(item, out int i))
                        IDs.Add(i);
                if (IDs.Count > 0)
                    query = query.Where(d => IDs.Contains(d.IDZone));
            }

			//Query LocationType (string)
			if (QueryStrings.Any(d => d.Key == "LocationType_eq") && !string.IsNullOrEmpty(QueryStrings.FirstOrDefault(d => d.Key == "LocationType_eq").Value))
            {
                var keyword = QueryStrings.FirstOrDefault(d => d.Key == "LocationType_eq").Value;
                query = query.Where(d=>d.LocationType == keyword);
            }
            if (QueryStrings.Any(d => d.Key == "LocationType") && !string.IsNullOrEmpty(QueryStrings.FirstOrDefault(d => d.Key == "LocationType").Value))
            {
                var keyword = QueryStrings.FirstOrDefault(d => d.Key == "LocationType").Value;
                query = query.Where(d=>d.LocationType.Contains(keyword));
            }
            

			//Query IsAutomaticallyShipPickedProduct (bool)
			if (QueryStrings.Any(d => d.Key == "IsAutomaticallyShipPickedProduct"))
            {
                var qValue = QueryStrings.FirstOrDefault(d => d.Key == "IsAutomaticallyShipPickedProduct").Value;
                if (bool.TryParse(qValue, out bool qBoolValue))
                    query = query.Where(d => qBoolValue == d.IsAutomaticallyShipPickedProduct);
            }

			//Query IsLoseID (bool)
			if (QueryStrings.Any(d => d.Key == "IsLoseID"))
            {
                var qValue = QueryStrings.FirstOrDefault(d => d.Key == "IsLoseID").Value;
                if (bool.TryParse(qValue, out bool qBoolValue))
                    query = query.Where(d => qBoolValue == d.IsLoseID);
            }

			//Query RouteSequence (string)
			if (QueryStrings.Any(d => d.Key == "RouteSequence_eq") && !string.IsNullOrEmpty(QueryStrings.FirstOrDefault(d => d.Key == "RouteSequence_eq").Value))
            {
                var keyword = QueryStrings.FirstOrDefault(d => d.Key == "RouteSequence_eq").Value;
                query = query.Where(d=>d.RouteSequence == keyword);
            }
            if (QueryStrings.Any(d => d.Key == "RouteSequence") && !string.IsNullOrEmpty(QueryStrings.FirstOrDefault(d => d.Key == "RouteSequence").Value))
            {
                var keyword = QueryStrings.FirstOrDefault(d => d.Key == "RouteSequence").Value;
                query = query.Where(d=>d.RouteSequence.Contains(keyword));
            }
            

			//Query IsCommingleItem (bool)
			if (QueryStrings.Any(d => d.Key == "IsCommingleItem"))
            {
                var qValue = QueryStrings.FirstOrDefault(d => d.Key == "IsCommingleItem").Value;
                if (bool.TryParse(qValue, out bool qBoolValue))
                    query = query.Where(d => qBoolValue == d.IsCommingleItem);
            }

			//Query IsCommingleLot (bool)
			if (QueryStrings.Any(d => d.Key == "IsCommingleLot"))
            {
                var qValue = QueryStrings.FirstOrDefault(d => d.Key == "IsCommingleLot").Value;
                if (bool.TryParse(qValue, out bool qBoolValue))
                    query = query.Where(d => qBoolValue == d.IsCommingleLot);
            }

			//Query Length (decimal)
			if (QueryStrings.Any(d => d.Key == "LengthFrom") && QueryStrings.Any(d => d.Key == "LengthTo"))
                if (decimal.TryParse(QueryStrings.FirstOrDefault(d => d.Key == "LengthFrom").Value, out decimal fromVal) && decimal.TryParse(QueryStrings.FirstOrDefault(d => d.Key == "LengthTo").Value, out decimal toVal))
                    query = query.Where(d => fromVal <= d.Length && d.Length <= toVal);
            
            if (QueryStrings.Any(d => d.Key == "Length"))
                if (decimal.TryParse(QueryStrings.FirstOrDefault(d => d.Key == "Length").Value, out decimal val))
                    query = query.Where(d => val == d.Length);


			//Query Width (decimal)
			if (QueryStrings.Any(d => d.Key == "WidthFrom") && QueryStrings.Any(d => d.Key == "WidthTo"))
                if (decimal.TryParse(QueryStrings.FirstOrDefault(d => d.Key == "WidthFrom").Value, out decimal fromVal) && decimal.TryParse(QueryStrings.FirstOrDefault(d => d.Key == "WidthTo").Value, out decimal toVal))
                    query = query.Where(d => fromVal <= d.Width && d.Width <= toVal);
            
            if (QueryStrings.Any(d => d.Key == "Width"))
                if (decimal.TryParse(QueryStrings.FirstOrDefault(d => d.Key == "Width").Value, out decimal val))
                    query = query.Where(d => val == d.Width);


			//Query LocationFlag (string)
			if (QueryStrings.Any(d => d.Key == "LocationFlag_eq") && !string.IsNullOrEmpty(QueryStrings.FirstOrDefault(d => d.Key == "LocationFlag_eq").Value))
            {
                var keyword = QueryStrings.FirstOrDefault(d => d.Key == "LocationFlag_eq").Value;
                query = query.Where(d=>d.LocationFlag == keyword);
            }
            if (QueryStrings.Any(d => d.Key == "LocationFlag") && !string.IsNullOrEmpty(QueryStrings.FirstOrDefault(d => d.Key == "LocationFlag").Value))
            {
                var keyword = QueryStrings.FirstOrDefault(d => d.Key == "LocationFlag").Value;
                query = query.Where(d=>d.LocationFlag.Contains(keyword));
            }
            

			//Query FootPrint (int)
			if (QueryStrings.Any(d => d.Key == "FootPrintFrom") && QueryStrings.Any(d => d.Key == "FootPrintTo"))
                if (int.TryParse(QueryStrings.FirstOrDefault(d => d.Key == "FootPrintFrom").Value, out int fromVal) && int.TryParse(QueryStrings.FirstOrDefault(d => d.Key == "FootPrintTo").Value, out int toVal))
                    query = query.Where(d => fromVal <= d.FootPrint && d.FootPrint <= toVal);
            
            if (QueryStrings.Any(d => d.Key == "FootPrint"))
                if (int.TryParse(QueryStrings.FirstOrDefault(d => d.Key == "FootPrint").Value, out int val))
                    query = query.Where(d => val == d.FootPrint);


			//Query StackLimit (int)
			if (QueryStrings.Any(d => d.Key == "StackLimitFrom") && QueryStrings.Any(d => d.Key == "StackLimitTo"))
                if (int.TryParse(QueryStrings.FirstOrDefault(d => d.Key == "StackLimitFrom").Value, out int fromVal) && int.TryParse(QueryStrings.FirstOrDefault(d => d.Key == "StackLimitTo").Value, out int toVal))
                    query = query.Where(d => fromVal <= d.StackLimit && d.StackLimit <= toVal);
            
            if (QueryStrings.Any(d => d.Key == "StackLimit"))
                if (int.TryParse(QueryStrings.FirstOrDefault(d => d.Key == "StackLimit").Value, out int val))
                    query = query.Where(d => val == d.StackLimit);


			//Query Height (decimal)
			if (QueryStrings.Any(d => d.Key == "HeightFrom") && QueryStrings.Any(d => d.Key == "HeightTo"))
                if (decimal.TryParse(QueryStrings.FirstOrDefault(d => d.Key == "HeightFrom").Value, out decimal fromVal) && decimal.TryParse(QueryStrings.FirstOrDefault(d => d.Key == "HeightTo").Value, out decimal toVal))
                    query = query.Where(d => fromVal <= d.Height && d.Height <= toVal);
            
            if (QueryStrings.Any(d => d.Key == "Height"))
                if (decimal.TryParse(QueryStrings.FirstOrDefault(d => d.Key == "Height").Value, out decimal val))
                    query = query.Where(d => val == d.Height);


			//Query CubicCapacity (decimal)
			if (QueryStrings.Any(d => d.Key == "CubicCapacityFrom") && QueryStrings.Any(d => d.Key == "CubicCapacityTo"))
                if (decimal.TryParse(QueryStrings.FirstOrDefault(d => d.Key == "CubicCapacityFrom").Value, out decimal fromVal) && decimal.TryParse(QueryStrings.FirstOrDefault(d => d.Key == "CubicCapacityTo").Value, out decimal toVal))
                    query = query.Where(d => fromVal <= d.CubicCapacity && d.CubicCapacity <= toVal);
            
            if (QueryStrings.Any(d => d.Key == "CubicCapacity"))
                if (decimal.TryParse(QueryStrings.FirstOrDefault(d => d.Key == "CubicCapacity").Value, out decimal val))
                    query = query.Where(d => val == d.CubicCapacity);


			//Query LocationCategory (string)
			if (QueryStrings.Any(d => d.Key == "LocationCategory_eq") && !string.IsNullOrEmpty(QueryStrings.FirstOrDefault(d => d.Key == "LocationCategory_eq").Value))
            {
                var keyword = QueryStrings.FirstOrDefault(d => d.Key == "LocationCategory_eq").Value;
                query = query.Where(d=>d.LocationCategory == keyword);
            }
            if (QueryStrings.Any(d => d.Key == "LocationCategory") && !string.IsNullOrEmpty(QueryStrings.FirstOrDefault(d => d.Key == "LocationCategory").Value))
            {
                var keyword = QueryStrings.FirstOrDefault(d => d.Key == "LocationCategory").Value;
                query = query.Where(d=>d.LocationCategory.Contains(keyword));
            }
            

			//Query LocationHandling (string)
			if (QueryStrings.Any(d => d.Key == "LocationHandling_eq") && !string.IsNullOrEmpty(QueryStrings.FirstOrDefault(d => d.Key == "LocationHandling_eq").Value))
            {
                var keyword = QueryStrings.FirstOrDefault(d => d.Key == "LocationHandling_eq").Value;
                query = query.Where(d=>d.LocationHandling == keyword);
            }
            if (QueryStrings.Any(d => d.Key == "LocationHandling") && !string.IsNullOrEmpty(QueryStrings.FirstOrDefault(d => d.Key == "LocationHandling").Value))
            {
                var keyword = QueryStrings.FirstOrDefault(d => d.Key == "LocationHandling").Value;
                query = query.Where(d=>d.LocationHandling.Contains(keyword));
            }
            

			//Query Level (int)
			if (QueryStrings.Any(d => d.Key == "LevelFrom") && QueryStrings.Any(d => d.Key == "LevelTo"))
                if (int.TryParse(QueryStrings.FirstOrDefault(d => d.Key == "LevelFrom").Value, out int fromVal) && int.TryParse(QueryStrings.FirstOrDefault(d => d.Key == "LevelTo").Value, out int toVal))
                    query = query.Where(d => fromVal <= d.Level && d.Level <= toVal);
            
            if (QueryStrings.Any(d => d.Key == "Level"))
                if (int.TryParse(QueryStrings.FirstOrDefault(d => d.Key == "Level").Value, out int val))
                    query = query.Where(d => val == d.Level);


			//Query WeightCapacity (decimal)
			if (QueryStrings.Any(d => d.Key == "WeightCapacityFrom") && QueryStrings.Any(d => d.Key == "WeightCapacityTo"))
                if (decimal.TryParse(QueryStrings.FirstOrDefault(d => d.Key == "WeightCapacityFrom").Value, out decimal fromVal) && decimal.TryParse(QueryStrings.FirstOrDefault(d => d.Key == "WeightCapacityTo").Value, out decimal toVal))
                    query = query.Where(d => fromVal <= d.WeightCapacity && d.WeightCapacity <= toVal);
            
            if (QueryStrings.Any(d => d.Key == "WeightCapacity"))
                if (decimal.TryParse(QueryStrings.FirstOrDefault(d => d.Key == "WeightCapacity").Value, out decimal val))
                    query = query.Where(d => val == d.WeightCapacity);


			//Query MoverType (string)
			if (QueryStrings.Any(d => d.Key == "MoverType_eq") && !string.IsNullOrEmpty(QueryStrings.FirstOrDefault(d => d.Key == "MoverType_eq").Value))
            {
                var keyword = QueryStrings.FirstOrDefault(d => d.Key == "MoverType_eq").Value;
                query = query.Where(d=>d.MoverType == keyword);
            }
            if (QueryStrings.Any(d => d.Key == "MoverType") && !string.IsNullOrEmpty(QueryStrings.FirstOrDefault(d => d.Key == "MoverType").Value))
            {
                var keyword = QueryStrings.FirstOrDefault(d => d.Key == "MoverType").Value;
                query = query.Where(d=>d.MoverType.Contains(keyword));
            }
            

			//Query XCoordinate (int)
			if (QueryStrings.Any(d => d.Key == "XCoordinateFrom") && QueryStrings.Any(d => d.Key == "XCoordinateTo"))
                if (int.TryParse(QueryStrings.FirstOrDefault(d => d.Key == "XCoordinateFrom").Value, out int fromVal) && int.TryParse(QueryStrings.FirstOrDefault(d => d.Key == "XCoordinateTo").Value, out int toVal))
                    query = query.Where(d => fromVal <= d.XCoordinate && d.XCoordinate <= toVal);
            
            if (QueryStrings.Any(d => d.Key == "XCoordinate"))
                if (int.TryParse(QueryStrings.FirstOrDefault(d => d.Key == "XCoordinate").Value, out int val))
                    query = query.Where(d => val == d.XCoordinate);


			//Query YCoordinate (int)
			if (QueryStrings.Any(d => d.Key == "YCoordinateFrom") && QueryStrings.Any(d => d.Key == "YCoordinateTo"))
                if (int.TryParse(QueryStrings.FirstOrDefault(d => d.Key == "YCoordinateFrom").Value, out int fromVal) && int.TryParse(QueryStrings.FirstOrDefault(d => d.Key == "YCoordinateTo").Value, out int toVal))
                    query = query.Where(d => fromVal <= d.YCoordinate && d.YCoordinate <= toVal);
            
            if (QueryStrings.Any(d => d.Key == "YCoordinate"))
                if (int.TryParse(QueryStrings.FirstOrDefault(d => d.Key == "YCoordinate").Value, out int val))
                    query = query.Where(d => val == d.YCoordinate);


			//Query ZCoordinate (int)
			if (QueryStrings.Any(d => d.Key == "ZCoordinateFrom") && QueryStrings.Any(d => d.Key == "ZCoordinateTo"))
                if (int.TryParse(QueryStrings.FirstOrDefault(d => d.Key == "ZCoordinateFrom").Value, out int fromVal) && int.TryParse(QueryStrings.FirstOrDefault(d => d.Key == "ZCoordinateTo").Value, out int toVal))
                    query = query.Where(d => fromVal <= d.ZCoordinate && d.ZCoordinate <= toVal);
            
            if (QueryStrings.Any(d => d.Key == "ZCoordinate"))
                if (int.TryParse(QueryStrings.FirstOrDefault(d => d.Key == "ZCoordinate").Value, out int val))
                    query = query.Where(d => val == d.ZCoordinate);


			//Query Orientation (int)
			if (QueryStrings.Any(d => d.Key == "OrientationFrom") && QueryStrings.Any(d => d.Key == "OrientationTo"))
                if (int.TryParse(QueryStrings.FirstOrDefault(d => d.Key == "OrientationFrom").Value, out int fromVal) && int.TryParse(QueryStrings.FirstOrDefault(d => d.Key == "OrientationTo").Value, out int toVal))
                    query = query.Where(d => fromVal <= d.Orientation && d.Orientation <= toVal);
            
            if (QueryStrings.Any(d => d.Key == "Orientation"))
                if (int.TryParse(QueryStrings.FirstOrDefault(d => d.Key == "Orientation").Value, out int val))
                    query = query.Where(d => val == d.Orientation);

            return query;
        }
		
        public static IQueryable<tbl_WMS_Location> _sortBuilder(IQueryable<tbl_WMS_Location> query, Dictionary<string, string> QueryStrings)
        {
            if (QueryStrings.Any(d => d.Key == "SortBy"))
            {
                var sorts = QueryStrings.FirstOrDefault(d => d.Key == "SortBy").Value.Replace("[", "").Replace("]", "").Split(',');
                
                foreach (var item in sorts)
                    if (!string.IsNullOrEmpty(item))
                    {
                        var ordered = query as IOrderedQueryable<tbl_WMS_Location>;
                        bool isOrdered = ordered.ToString().IndexOf("ORDER BY") !=-1;

                        switch (item)
                        {
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
							case "IDZone":
								query = isOrdered ? ordered.ThenBy(o => o.IDZone) : query.OrderBy(o => o.IDZone);
								 break;
							case "IDZone_desc":
                                query = isOrdered ? ordered.ThenByDescending(o => o.IDZone) : query.OrderByDescending(o => o.IDZone);
                                break;
							case "LocationType":
								query = isOrdered ? ordered.ThenBy(o => o.LocationType) : query.OrderBy(o => o.LocationType);
								 break;
							case "LocationType_desc":
                                query = isOrdered ? ordered.ThenByDescending(o => o.LocationType) : query.OrderByDescending(o => o.LocationType);
                                break;
							case "IsAutomaticallyShipPickedProduct":
								query = isOrdered ? ordered.ThenBy(o => o.IsAutomaticallyShipPickedProduct) : query.OrderBy(o => o.IsAutomaticallyShipPickedProduct);
								 break;
							case "IsAutomaticallyShipPickedProduct_desc":
                                query = isOrdered ? ordered.ThenByDescending(o => o.IsAutomaticallyShipPickedProduct) : query.OrderByDescending(o => o.IsAutomaticallyShipPickedProduct);
                                break;
							case "IsLoseID":
								query = isOrdered ? ordered.ThenBy(o => o.IsLoseID) : query.OrderBy(o => o.IsLoseID);
								 break;
							case "IsLoseID_desc":
                                query = isOrdered ? ordered.ThenByDescending(o => o.IsLoseID) : query.OrderByDescending(o => o.IsLoseID);
                                break;
							case "RouteSequence":
								query = isOrdered ? ordered.ThenBy(o => o.RouteSequence) : query.OrderBy(o => o.RouteSequence);
								 break;
							case "RouteSequence_desc":
                                query = isOrdered ? ordered.ThenByDescending(o => o.RouteSequence) : query.OrderByDescending(o => o.RouteSequence);
                                break;
							case "IsCommingleItem":
								query = isOrdered ? ordered.ThenBy(o => o.IsCommingleItem) : query.OrderBy(o => o.IsCommingleItem);
								 break;
							case "IsCommingleItem_desc":
                                query = isOrdered ? ordered.ThenByDescending(o => o.IsCommingleItem) : query.OrderByDescending(o => o.IsCommingleItem);
                                break;
							case "IsCommingleLot":
								query = isOrdered ? ordered.ThenBy(o => o.IsCommingleLot) : query.OrderBy(o => o.IsCommingleLot);
								 break;
							case "IsCommingleLot_desc":
                                query = isOrdered ? ordered.ThenByDescending(o => o.IsCommingleLot) : query.OrderByDescending(o => o.IsCommingleLot);
                                break;
							case "Length":
								query = isOrdered ? ordered.ThenBy(o => o.Length) : query.OrderBy(o => o.Length);
								 break;
							case "Length_desc":
                                query = isOrdered ? ordered.ThenByDescending(o => o.Length) : query.OrderByDescending(o => o.Length);
                                break;
							case "Width":
								query = isOrdered ? ordered.ThenBy(o => o.Width) : query.OrderBy(o => o.Width);
								 break;
							case "Width_desc":
                                query = isOrdered ? ordered.ThenByDescending(o => o.Width) : query.OrderByDescending(o => o.Width);
                                break;
							case "LocationFlag":
								query = isOrdered ? ordered.ThenBy(o => o.LocationFlag) : query.OrderBy(o => o.LocationFlag);
								 break;
							case "LocationFlag_desc":
                                query = isOrdered ? ordered.ThenByDescending(o => o.LocationFlag) : query.OrderByDescending(o => o.LocationFlag);
                                break;
							case "FootPrint":
								query = isOrdered ? ordered.ThenBy(o => o.FootPrint) : query.OrderBy(o => o.FootPrint);
								 break;
							case "FootPrint_desc":
                                query = isOrdered ? ordered.ThenByDescending(o => o.FootPrint) : query.OrderByDescending(o => o.FootPrint);
                                break;
							case "StackLimit":
								query = isOrdered ? ordered.ThenBy(o => o.StackLimit) : query.OrderBy(o => o.StackLimit);
								 break;
							case "StackLimit_desc":
                                query = isOrdered ? ordered.ThenByDescending(o => o.StackLimit) : query.OrderByDescending(o => o.StackLimit);
                                break;
							case "Height":
								query = isOrdered ? ordered.ThenBy(o => o.Height) : query.OrderBy(o => o.Height);
								 break;
							case "Height_desc":
                                query = isOrdered ? ordered.ThenByDescending(o => o.Height) : query.OrderByDescending(o => o.Height);
                                break;
							case "CubicCapacity":
								query = isOrdered ? ordered.ThenBy(o => o.CubicCapacity) : query.OrderBy(o => o.CubicCapacity);
								 break;
							case "CubicCapacity_desc":
                                query = isOrdered ? ordered.ThenByDescending(o => o.CubicCapacity) : query.OrderByDescending(o => o.CubicCapacity);
                                break;
							case "LocationCategory":
								query = isOrdered ? ordered.ThenBy(o => o.LocationCategory) : query.OrderBy(o => o.LocationCategory);
								 break;
							case "LocationCategory_desc":
                                query = isOrdered ? ordered.ThenByDescending(o => o.LocationCategory) : query.OrderByDescending(o => o.LocationCategory);
                                break;
							case "LocationHandling":
								query = isOrdered ? ordered.ThenBy(o => o.LocationHandling) : query.OrderBy(o => o.LocationHandling);
								 break;
							case "LocationHandling_desc":
                                query = isOrdered ? ordered.ThenByDescending(o => o.LocationHandling) : query.OrderByDescending(o => o.LocationHandling);
                                break;
							case "Level":
								query = isOrdered ? ordered.ThenBy(o => o.Level) : query.OrderBy(o => o.Level);
								 break;
							case "Level_desc":
                                query = isOrdered ? ordered.ThenByDescending(o => o.Level) : query.OrderByDescending(o => o.Level);
                                break;
							case "WeightCapacity":
								query = isOrdered ? ordered.ThenBy(o => o.WeightCapacity) : query.OrderBy(o => o.WeightCapacity);
								 break;
							case "WeightCapacity_desc":
                                query = isOrdered ? ordered.ThenByDescending(o => o.WeightCapacity) : query.OrderByDescending(o => o.WeightCapacity);
                                break;
							case "MoverType":
								query = isOrdered ? ordered.ThenBy(o => o.MoverType) : query.OrderBy(o => o.MoverType);
								 break;
							case "MoverType_desc":
                                query = isOrdered ? ordered.ThenByDescending(o => o.MoverType) : query.OrderByDescending(o => o.MoverType);
                                break;
							case "XCoordinate":
								query = isOrdered ? ordered.ThenBy(o => o.XCoordinate) : query.OrderBy(o => o.XCoordinate);
								 break;
							case "XCoordinate_desc":
                                query = isOrdered ? ordered.ThenByDescending(o => o.XCoordinate) : query.OrderByDescending(o => o.XCoordinate);
                                break;
							case "YCoordinate":
								query = isOrdered ? ordered.ThenBy(o => o.YCoordinate) : query.OrderBy(o => o.YCoordinate);
								 break;
							case "YCoordinate_desc":
                                query = isOrdered ? ordered.ThenByDescending(o => o.YCoordinate) : query.OrderByDescending(o => o.YCoordinate);
                                break;
							case "ZCoordinate":
								query = isOrdered ? ordered.ThenBy(o => o.ZCoordinate) : query.OrderBy(o => o.ZCoordinate);
								 break;
							case "ZCoordinate_desc":
                                query = isOrdered ? ordered.ThenByDescending(o => o.ZCoordinate) : query.OrderByDescending(o => o.ZCoordinate);
                                break;
							case "Orientation":
								query = isOrdered ? ordered.ThenBy(o => o.Orientation) : query.OrderBy(o => o.Orientation);
								 break;
							case "Orientation_desc":
                                query = isOrdered ? ordered.ThenByDescending(o => o.Orientation) : query.OrderByDescending(o => o.Orientation);
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

        public static IQueryable<tbl_WMS_Location> _pagingBuilder(IQueryable<tbl_WMS_Location> query, Dictionary<string, string> QueryStrings)
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






