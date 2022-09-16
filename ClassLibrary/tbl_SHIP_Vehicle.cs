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
    
    
    public partial class tbl_SHIP_Vehicle
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public tbl_SHIP_Vehicle()
        {
            this.tbl_CRM_Route = new HashSet<tbl_CRM_Route>();
            this.tbl_SHIP_Shipment = new HashSet<tbl_SHIP_Shipment>();
        }
    
        public int IDBranch { get; set; }
        public Nullable<int> IDVehicleGroup { get; set; }
        public Nullable<int> IDShipper { get; set; }
        public int Id { get; set; }
        public string Code { get; set; }
        public string Name { get; set; }
        public string Remark { get; set; }
        public Nullable<int> Sort { get; set; }
        public bool IsDisabled { get; set; }
        public bool IsDeleted { get; set; }
        public string CreatedBy { get; set; }
        public System.DateTime CreatedDate { get; set; }
        public string ModifiedBy { get; set; }
        public System.DateTime ModifiedDate { get; set; }
        public Nullable<System.DateTime> DateOfPurchase { get; set; }
        public Nullable<System.DateTime> DateOfRegistration { get; set; }
        public Nullable<System.DateTime> DateOfRegistrationExpire { get; set; }
        public decimal Length { get; set; }
        public decimal Width { get; set; }
        public decimal Height { get; set; }
        public decimal VolumeMin { get; set; }
        public decimal VolumeRecommend { get; set; }
        public decimal VolumeMax { get; set; }
        public decimal WeightMin { get; set; }
        public decimal WeightRecommend { get; set; }
        public decimal WeightMax { get; set; }
        public bool IsForSample { get; set; }
        public bool IsForUrgent { get; set; }
        public bool IsForWholeSale { get; set; }
        public string RefShipper { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tbl_CRM_Route> tbl_CRM_Route { get; set; }
        //List 0:1
        public virtual tbl_HRM_Staff tbl_HRM_Staff { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tbl_SHIP_Shipment> tbl_SHIP_Shipment { get; set; }
    }
}


namespace DTOModel
{
	using System;
	public partial class DTO_SHIP_Vehicle
	{
		public int IDBranch { get; set; }
		public Nullable<int> IDVehicleGroup { get; set; }
		public Nullable<int> IDShipper { get; set; }
		public int Id { get; set; }
		public string Code { get; set; }
		public string Name { get; set; }
		public string Remark { get; set; }
		public Nullable<int> Sort { get; set; }
		public bool IsDisabled { get; set; }
		public bool IsDeleted { get; set; }
		public string CreatedBy { get; set; }
		public System.DateTime CreatedDate { get; set; }
		public string ModifiedBy { get; set; }
		public System.DateTime ModifiedDate { get; set; }
		public Nullable<System.DateTime> DateOfPurchase { get; set; }
		public Nullable<System.DateTime> DateOfRegistration { get; set; }
		public Nullable<System.DateTime> DateOfRegistrationExpire { get; set; }
		public decimal Length { get; set; }
		public decimal Width { get; set; }
		public decimal Height { get; set; }
		public decimal VolumeMin { get; set; }
		public decimal VolumeRecommend { get; set; }
		public decimal VolumeMax { get; set; }
		public decimal WeightMin { get; set; }
		public decimal WeightRecommend { get; set; }
		public decimal WeightMax { get; set; }
		public bool IsForSample { get; set; }
		public bool IsForUrgent { get; set; }
		public bool IsForWholeSale { get; set; }
		public string RefShipper { get; set; }
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

    public static partial class BS_SHIP_Vehicle 
    {
        public static dynamic getSearch(AppEntities db, int IDBranch, int StaffID, Dictionary<string, string> QueryStrings)
        {
            return get(db, IDBranch,StaffID, QueryStrings);
        }

		public static IQueryable<DTO_SHIP_Vehicle> get(AppEntities db, int IDBranch, int StaffID, Dictionary<string, string> QueryStrings)
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
            package.Workbook.Properties.Title = "ART-DMS SHIP_Vehicle";
            package.Workbook.Properties.Author = "hung.vu@codeart.vn";
            package.Workbook.Properties.Application = "ART-DMS";
            package.Workbook.Properties.Company = "A.R.T Distribution";

            ExcelWorkbook workBook = package.Workbook;
            if (workBook != null)
            {
                var ws = workBook.Worksheets.FirstOrDefault();
                var data = _queryBuilder(db, IDBranch, StaffID, QueryStrings).ToList();

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

		public static DTO_SHIP_Vehicle getAnItem(AppEntities db, int IDBranch, int StaffID, int id)
        {
            var dbResult = db.tbl_SHIP_Vehicle.Find(id);

			//if (dbResult == null || (IDBranch != 0 && dbResult.IDBranch != IDBranch))
			//	return null; 
			//else 
				return toDTO(dbResult);
			
        }
		
		public static DTO_SHIP_Vehicle getAnItemByCode(AppEntities db, int IDBranch, int StaffID, string code)
        {
            var dbResult = db.tbl_SHIP_Vehicle
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
            var dbitem = db.tbl_SHIP_Vehicle.Find(Id);
            
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
					errorLog.logMessage("put_SHIP_Vehicle",e);
                    result = false;
                }
            }
            else
                if (QueryStrings.Any(d => d.Key == "ForceCreate"))
                    result =  post(db, IDBranch, StaffID, item, Username) != null;
                
            return result;
        }

        public static void patchDynamicToDB(dynamic item, tbl_SHIP_Vehicle dbitem, string Username)
        {
            Type type = typeof(tbl_SHIP_Vehicle);
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

        public static void patchDTOtoDBValue( DTO_SHIP_Vehicle item, tbl_SHIP_Vehicle dbitem)
        {
            if (item == null){
                dbitem = null;
                return;
            }
            							
			dbitem.IDBranch = item.IDBranch;							
			dbitem.IDVehicleGroup = item.IDVehicleGroup;							
			dbitem.IDShipper = item.IDShipper;							
			dbitem.Code = item.Code;							
			dbitem.Name = item.Name;							
			dbitem.Remark = item.Remark;							
			dbitem.Sort = item.Sort;							
			dbitem.IsDisabled = item.IsDisabled;							
			dbitem.IsDeleted = item.IsDeleted;							
			dbitem.DateOfPurchase = item.DateOfPurchase;							
			dbitem.DateOfRegistration = item.DateOfRegistration;							
			dbitem.DateOfRegistrationExpire = item.DateOfRegistrationExpire;							
			dbitem.Length = item.Length;							
			dbitem.Width = item.Width;							
			dbitem.Height = item.Height;							
			dbitem.VolumeMin = item.VolumeMin;							
			dbitem.VolumeRecommend = item.VolumeRecommend;							
			dbitem.VolumeMax = item.VolumeMax;							
			dbitem.WeightMin = item.WeightMin;							
			dbitem.WeightRecommend = item.WeightRecommend;							
			dbitem.WeightMax = item.WeightMax;							
			dbitem.IsForSample = item.IsForSample;							
			dbitem.IsForUrgent = item.IsForUrgent;							
			dbitem.IsForWholeSale = item.IsForWholeSale;							
			dbitem.RefShipper = item.RefShipper;        }

		public static DTO_SHIP_Vehicle post(AppEntities db, int IDBranch, int StaffID, dynamic item, string Username)
        {
            tbl_SHIP_Vehicle dbitem = new tbl_SHIP_Vehicle();
            if (item != null)
            {
                patchDynamicToDB(item, dbitem, Username);
                
				dbitem.CreatedBy = Username;
				dbitem.CreatedDate = DateTime.Now;				
                try
                {
					db.tbl_SHIP_Vehicle.Add(dbitem);
                    db.SaveChanges();
				
                }
                catch (DbEntityValidationException e)
                {
					errorLog.logMessage("post_SHIP_Vehicle",e);
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
                Type type = Type.GetType("BaseBusiness.BS_SHIP_Vehicle, ClassLibrary");
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
                        var target = new tbl_SHIP_Vehicle();
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
                    
                    tbl_SHIP_Vehicle dbitem = new tbl_SHIP_Vehicle();
                    if (it.Id == null || string.IsNullOrEmpty(it.Id.Value) || it.Id == "0")
                    {
                        dbitem = new tbl_SHIP_Vehicle();
                        dbitem.CreatedBy = Username;
				        dbitem.CreatedDate = DateTime.Now;
                                            }
                    else
                    {
                        dbitem = db.tbl_SHIP_Vehicle.Find((int)it.Id);
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
                        
                        if (dbitem.Id == 0) db.tbl_SHIP_Vehicle.Add(dbitem);
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
                    errorLog.logMessage("post_SHIP_Vehicle",e);
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

            var dbitems = db.tbl_SHIP_Vehicle.Where(d => IDs.Contains(d.Id));
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
                    BS_Version.update_Version(db, IDBranch, "DTO_SHIP_Vehicle", updateDate, Username);
                }
			
            }
            catch (DbEntityValidationException e)
            {
				errorLog.logMessage("delete_SHIP_Vehicle",e);
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

			
            var dbitems = db.tbl_SHIP_Vehicle.Where(d => IDs.Contains(d.Id));
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
                    BS_Version.update_Version(db, IDBranch, "DTO_SHIP_Vehicle", updateDate, Username);
                }
			
            }
            catch (DbEntityValidationException e)
            {
				errorLog.logMessage("disable_SHIP_Vehicle",e);
                result = false;
            }
            
            return result;
        }

		
		//---//
		public static bool check_Exists(AppEntities db, int id)
		{
             
            return db.tbl_SHIP_Vehicle.Any(e => e.Id == id && e.IsDeleted == false);
            
		}
		
		public static bool check_Exists(AppEntities db, string Code)
		{
             
            return db.tbl_SHIP_Vehicle.Any(e => e.Code == Code && e.IsDeleted == false);
            
		}
		
		//---//
		public static IQueryable<DTO_SHIP_Vehicle> toDTO(IQueryable<tbl_SHIP_Vehicle> query)
        {
			return query
			.Select(s => new DTO_SHIP_Vehicle(){							
				IDBranch = s.IDBranch,							
				IDVehicleGroup = s.IDVehicleGroup,							
				IDShipper = s.IDShipper,							
				Id = s.Id,							
				Code = s.Code,							
				Name = s.Name,							
				Remark = s.Remark,							
				Sort = s.Sort,							
				IsDisabled = s.IsDisabled,							
				IsDeleted = s.IsDeleted,							
				CreatedBy = s.CreatedBy,							
				CreatedDate = s.CreatedDate,							
				ModifiedBy = s.ModifiedBy,							
				ModifiedDate = s.ModifiedDate,							
				DateOfPurchase = s.DateOfPurchase,							
				DateOfRegistration = s.DateOfRegistration,							
				DateOfRegistrationExpire = s.DateOfRegistrationExpire,							
				Length = s.Length,							
				Width = s.Width,							
				Height = s.Height,							
				VolumeMin = s.VolumeMin,							
				VolumeRecommend = s.VolumeRecommend,							
				VolumeMax = s.VolumeMax,							
				WeightMin = s.WeightMin,							
				WeightRecommend = s.WeightRecommend,							
				WeightMax = s.WeightMax,							
				IsForSample = s.IsForSample,							
				IsForUrgent = s.IsForUrgent,							
				IsForWholeSale = s.IsForWholeSale,							
				RefShipper = s.RefShipper,					
			});//.OrderBy(o => o.Sort == null).ThenBy(u => u.Sort);
                              
        }

		public static DTO_SHIP_Vehicle toDTO(tbl_SHIP_Vehicle dbResult)
        {
			if (dbResult != null)
			{
				return new DTO_SHIP_Vehicle()
				{							
					IDBranch = dbResult.IDBranch,							
					IDVehicleGroup = dbResult.IDVehicleGroup,							
					IDShipper = dbResult.IDShipper,							
					Id = dbResult.Id,							
					Code = dbResult.Code,							
					Name = dbResult.Name,							
					Remark = dbResult.Remark,							
					Sort = dbResult.Sort,							
					IsDisabled = dbResult.IsDisabled,							
					IsDeleted = dbResult.IsDeleted,							
					CreatedBy = dbResult.CreatedBy,							
					CreatedDate = dbResult.CreatedDate,							
					ModifiedBy = dbResult.ModifiedBy,							
					ModifiedDate = dbResult.ModifiedDate,							
					DateOfPurchase = dbResult.DateOfPurchase,							
					DateOfRegistration = dbResult.DateOfRegistration,							
					DateOfRegistrationExpire = dbResult.DateOfRegistrationExpire,							
					Length = dbResult.Length,							
					Width = dbResult.Width,							
					Height = dbResult.Height,							
					VolumeMin = dbResult.VolumeMin,							
					VolumeRecommend = dbResult.VolumeRecommend,							
					VolumeMax = dbResult.VolumeMax,							
					WeightMin = dbResult.WeightMin,							
					WeightRecommend = dbResult.WeightRecommend,							
					WeightMax = dbResult.WeightMax,							
					IsForSample = dbResult.IsForSample,							
					IsForUrgent = dbResult.IsForUrgent,							
					IsForWholeSale = dbResult.IsForWholeSale,							
					RefShipper = dbResult.RefShipper,
				};
			}
			else
				return null; 
        }

		public static IQueryable<tbl_SHIP_Vehicle> _queryBuilder(AppEntities db, int IDBranch, int StaffID, Dictionary<string, string> QueryStrings)
        {
            
			IQueryable<tbl_SHIP_Vehicle> query = db.tbl_SHIP_Vehicle.AsNoTracking();//.Where(d => d.IsDeleted == false);
			

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

			//Query IDVehicleGroup (Nullable<int>)
			if (QueryStrings.Any(d => d.Key == "IDVehicleGroup"))
            {
                var IDList = QueryStrings.FirstOrDefault(d => d.Key == "IDVehicleGroup").Value.Replace("[", "").Replace("]", "").Split(',');
                List<int?> IDs = new List<int?>();
                foreach (var item in IDList)
                    if (int.TryParse(item, out int i))
                        IDs.Add(i);
					else if (item == "null")
						IDs.Add(null);
                if (IDs.Count > 0)
                    query = query.Where(d => IDs.Contains(d.IDVehicleGroup));
////                    query = query.Where(d => IDs.Contains(d.IDVehicleGroup));
//                    
            }

			//Query IDShipper (Nullable<int>)
			if (QueryStrings.Any(d => d.Key == "IDShipper"))
            {
                var IDList = QueryStrings.FirstOrDefault(d => d.Key == "IDShipper").Value.Replace("[", "").Replace("]", "").Split(',');
                List<int?> IDs = new List<int?>();
                foreach (var item in IDList)
                    if (int.TryParse(item, out int i))
                        IDs.Add(i);
					else if (item == "null")
						IDs.Add(null);
                if (IDs.Count > 0)
                    query = query.Where(d => IDs.Contains(d.IDShipper));
////                    query = query.Where(d => IDs.Contains(d.IDShipper));
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


			//Query DateOfPurchase (Nullable<System.DateTime>)
			if (QueryStrings.Any(d => d.Key == "DateOfPurchaseFrom") && QueryStrings.Any(d => d.Key == "DateOfPurchaseTo"))
                if (DateTime.TryParse(QueryStrings.FirstOrDefault(d => d.Key == "DateOfPurchaseFrom").Value, out DateTime fromDate) && DateTime.TryParse(QueryStrings.FirstOrDefault(d => d.Key == "DateOfPurchaseTo").Value, out DateTime toDate))
                    query = query.Where(d => fromDate <= d.DateOfPurchase && d.DateOfPurchase <= toDate);

            if (QueryStrings.Any(d => d.Key == "DateOfPurchase"))
                if (DateTime.TryParse(QueryStrings.FirstOrDefault(d => d.Key == "DateOfPurchase").Value, out DateTime val))
                    query = query.Where(d => d.DateOfPurchase != null && DbFunctions.TruncateTime(val) == DbFunctions.TruncateTime(d.DateOfPurchase));


			//Query DateOfRegistration (Nullable<System.DateTime>)
			if (QueryStrings.Any(d => d.Key == "DateOfRegistrationFrom") && QueryStrings.Any(d => d.Key == "DateOfRegistrationTo"))
                if (DateTime.TryParse(QueryStrings.FirstOrDefault(d => d.Key == "DateOfRegistrationFrom").Value, out DateTime fromDate) && DateTime.TryParse(QueryStrings.FirstOrDefault(d => d.Key == "DateOfRegistrationTo").Value, out DateTime toDate))
                    query = query.Where(d => fromDate <= d.DateOfRegistration && d.DateOfRegistration <= toDate);

            if (QueryStrings.Any(d => d.Key == "DateOfRegistration"))
                if (DateTime.TryParse(QueryStrings.FirstOrDefault(d => d.Key == "DateOfRegistration").Value, out DateTime val))
                    query = query.Where(d => d.DateOfRegistration != null && DbFunctions.TruncateTime(val) == DbFunctions.TruncateTime(d.DateOfRegistration));


			//Query DateOfRegistrationExpire (Nullable<System.DateTime>)
			if (QueryStrings.Any(d => d.Key == "DateOfRegistrationExpireFrom") && QueryStrings.Any(d => d.Key == "DateOfRegistrationExpireTo"))
                if (DateTime.TryParse(QueryStrings.FirstOrDefault(d => d.Key == "DateOfRegistrationExpireFrom").Value, out DateTime fromDate) && DateTime.TryParse(QueryStrings.FirstOrDefault(d => d.Key == "DateOfRegistrationExpireTo").Value, out DateTime toDate))
                    query = query.Where(d => fromDate <= d.DateOfRegistrationExpire && d.DateOfRegistrationExpire <= toDate);

            if (QueryStrings.Any(d => d.Key == "DateOfRegistrationExpire"))
                if (DateTime.TryParse(QueryStrings.FirstOrDefault(d => d.Key == "DateOfRegistrationExpire").Value, out DateTime val))
                    query = query.Where(d => d.DateOfRegistrationExpire != null && DbFunctions.TruncateTime(val) == DbFunctions.TruncateTime(d.DateOfRegistrationExpire));


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


			//Query Height (decimal)
			if (QueryStrings.Any(d => d.Key == "HeightFrom") && QueryStrings.Any(d => d.Key == "HeightTo"))
                if (decimal.TryParse(QueryStrings.FirstOrDefault(d => d.Key == "HeightFrom").Value, out decimal fromVal) && decimal.TryParse(QueryStrings.FirstOrDefault(d => d.Key == "HeightTo").Value, out decimal toVal))
                    query = query.Where(d => fromVal <= d.Height && d.Height <= toVal);
            
            if (QueryStrings.Any(d => d.Key == "Height"))
                if (decimal.TryParse(QueryStrings.FirstOrDefault(d => d.Key == "Height").Value, out decimal val))
                    query = query.Where(d => val == d.Height);


			//Query VolumeMin (decimal)
			if (QueryStrings.Any(d => d.Key == "VolumeMinFrom") && QueryStrings.Any(d => d.Key == "VolumeMinTo"))
                if (decimal.TryParse(QueryStrings.FirstOrDefault(d => d.Key == "VolumeMinFrom").Value, out decimal fromVal) && decimal.TryParse(QueryStrings.FirstOrDefault(d => d.Key == "VolumeMinTo").Value, out decimal toVal))
                    query = query.Where(d => fromVal <= d.VolumeMin && d.VolumeMin <= toVal);
            
            if (QueryStrings.Any(d => d.Key == "VolumeMin"))
                if (decimal.TryParse(QueryStrings.FirstOrDefault(d => d.Key == "VolumeMin").Value, out decimal val))
                    query = query.Where(d => val == d.VolumeMin);


			//Query VolumeRecommend (decimal)
			if (QueryStrings.Any(d => d.Key == "VolumeRecommendFrom") && QueryStrings.Any(d => d.Key == "VolumeRecommendTo"))
                if (decimal.TryParse(QueryStrings.FirstOrDefault(d => d.Key == "VolumeRecommendFrom").Value, out decimal fromVal) && decimal.TryParse(QueryStrings.FirstOrDefault(d => d.Key == "VolumeRecommendTo").Value, out decimal toVal))
                    query = query.Where(d => fromVal <= d.VolumeRecommend && d.VolumeRecommend <= toVal);
            
            if (QueryStrings.Any(d => d.Key == "VolumeRecommend"))
                if (decimal.TryParse(QueryStrings.FirstOrDefault(d => d.Key == "VolumeRecommend").Value, out decimal val))
                    query = query.Where(d => val == d.VolumeRecommend);


			//Query VolumeMax (decimal)
			if (QueryStrings.Any(d => d.Key == "VolumeMaxFrom") && QueryStrings.Any(d => d.Key == "VolumeMaxTo"))
                if (decimal.TryParse(QueryStrings.FirstOrDefault(d => d.Key == "VolumeMaxFrom").Value, out decimal fromVal) && decimal.TryParse(QueryStrings.FirstOrDefault(d => d.Key == "VolumeMaxTo").Value, out decimal toVal))
                    query = query.Where(d => fromVal <= d.VolumeMax && d.VolumeMax <= toVal);
            
            if (QueryStrings.Any(d => d.Key == "VolumeMax"))
                if (decimal.TryParse(QueryStrings.FirstOrDefault(d => d.Key == "VolumeMax").Value, out decimal val))
                    query = query.Where(d => val == d.VolumeMax);


			//Query WeightMin (decimal)
			if (QueryStrings.Any(d => d.Key == "WeightMinFrom") && QueryStrings.Any(d => d.Key == "WeightMinTo"))
                if (decimal.TryParse(QueryStrings.FirstOrDefault(d => d.Key == "WeightMinFrom").Value, out decimal fromVal) && decimal.TryParse(QueryStrings.FirstOrDefault(d => d.Key == "WeightMinTo").Value, out decimal toVal))
                    query = query.Where(d => fromVal <= d.WeightMin && d.WeightMin <= toVal);
            
            if (QueryStrings.Any(d => d.Key == "WeightMin"))
                if (decimal.TryParse(QueryStrings.FirstOrDefault(d => d.Key == "WeightMin").Value, out decimal val))
                    query = query.Where(d => val == d.WeightMin);


			//Query WeightRecommend (decimal)
			if (QueryStrings.Any(d => d.Key == "WeightRecommendFrom") && QueryStrings.Any(d => d.Key == "WeightRecommendTo"))
                if (decimal.TryParse(QueryStrings.FirstOrDefault(d => d.Key == "WeightRecommendFrom").Value, out decimal fromVal) && decimal.TryParse(QueryStrings.FirstOrDefault(d => d.Key == "WeightRecommendTo").Value, out decimal toVal))
                    query = query.Where(d => fromVal <= d.WeightRecommend && d.WeightRecommend <= toVal);
            
            if (QueryStrings.Any(d => d.Key == "WeightRecommend"))
                if (decimal.TryParse(QueryStrings.FirstOrDefault(d => d.Key == "WeightRecommend").Value, out decimal val))
                    query = query.Where(d => val == d.WeightRecommend);


			//Query WeightMax (decimal)
			if (QueryStrings.Any(d => d.Key == "WeightMaxFrom") && QueryStrings.Any(d => d.Key == "WeightMaxTo"))
                if (decimal.TryParse(QueryStrings.FirstOrDefault(d => d.Key == "WeightMaxFrom").Value, out decimal fromVal) && decimal.TryParse(QueryStrings.FirstOrDefault(d => d.Key == "WeightMaxTo").Value, out decimal toVal))
                    query = query.Where(d => fromVal <= d.WeightMax && d.WeightMax <= toVal);
            
            if (QueryStrings.Any(d => d.Key == "WeightMax"))
                if (decimal.TryParse(QueryStrings.FirstOrDefault(d => d.Key == "WeightMax").Value, out decimal val))
                    query = query.Where(d => val == d.WeightMax);


			//Query IsForSample (bool)
			if (QueryStrings.Any(d => d.Key == "IsForSample"))
            {
                var qValue = QueryStrings.FirstOrDefault(d => d.Key == "IsForSample").Value;
                if (bool.TryParse(qValue, out bool qBoolValue))
                    query = query.Where(d => qBoolValue == d.IsForSample);
            }

			//Query IsForUrgent (bool)
			if (QueryStrings.Any(d => d.Key == "IsForUrgent"))
            {
                var qValue = QueryStrings.FirstOrDefault(d => d.Key == "IsForUrgent").Value;
                if (bool.TryParse(qValue, out bool qBoolValue))
                    query = query.Where(d => qBoolValue == d.IsForUrgent);
            }

			//Query IsForWholeSale (bool)
			if (QueryStrings.Any(d => d.Key == "IsForWholeSale"))
            {
                var qValue = QueryStrings.FirstOrDefault(d => d.Key == "IsForWholeSale").Value;
                if (bool.TryParse(qValue, out bool qBoolValue))
                    query = query.Where(d => qBoolValue == d.IsForWholeSale);
            }

			//Query RefShipper (string)
			if (QueryStrings.Any(d => d.Key == "RefShipper_eq") && !string.IsNullOrEmpty(QueryStrings.FirstOrDefault(d => d.Key == "RefShipper_eq").Value))
            {
                var keyword = QueryStrings.FirstOrDefault(d => d.Key == "RefShipper_eq").Value;
                query = query.Where(d=>d.RefShipper == keyword);
            }
            if (QueryStrings.Any(d => d.Key == "RefShipper") && !string.IsNullOrEmpty(QueryStrings.FirstOrDefault(d => d.Key == "RefShipper").Value))
            {
                var keyword = QueryStrings.FirstOrDefault(d => d.Key == "RefShipper").Value;
                query = query.Where(d=>d.RefShipper.Contains(keyword));
            }
            
            return query;
        }
		
        public static IQueryable<tbl_SHIP_Vehicle> _sortBuilder(IQueryable<tbl_SHIP_Vehicle> query, Dictionary<string, string> QueryStrings)
        {
            if (QueryStrings.Any(d => d.Key == "SortBy"))
            {
                var sorts = QueryStrings.FirstOrDefault(d => d.Key == "SortBy").Value.Replace("[", "").Replace("]", "").Split(',');
                
                foreach (var item in sorts)
                    if (!string.IsNullOrEmpty(item))
                    {
                        var ordered = query as IOrderedQueryable<tbl_SHIP_Vehicle>;
                        bool isOrdered = ordered.ToString().IndexOf("ORDER BY") !=-1;

                        switch (item)
                        {
							case "IDBranch":
								query = isOrdered ? ordered.ThenBy(o => o.IDBranch) : query.OrderBy(o => o.IDBranch);
								 break;
							case "IDBranch_desc":
                                query = isOrdered ? ordered.ThenByDescending(o => o.IDBranch) : query.OrderByDescending(o => o.IDBranch);
                                break;
							case "IDVehicleGroup":
								query = isOrdered ? ordered.ThenBy(o => o.IDVehicleGroup) : query.OrderBy(o => o.IDVehicleGroup);
								 break;
							case "IDVehicleGroup_desc":
                                query = isOrdered ? ordered.ThenByDescending(o => o.IDVehicleGroup) : query.OrderByDescending(o => o.IDVehicleGroup);
                                break;
							case "IDShipper":
								query = isOrdered ? ordered.ThenBy(o => o.IDShipper) : query.OrderBy(o => o.IDShipper);
								 break;
							case "IDShipper_desc":
                                query = isOrdered ? ordered.ThenByDescending(o => o.IDShipper) : query.OrderByDescending(o => o.IDShipper);
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
							case "DateOfPurchase":
								query = isOrdered ? ordered.ThenBy(o => o.DateOfPurchase) : query.OrderBy(o => o.DateOfPurchase);
								 break;
							case "DateOfPurchase_desc":
                                query = isOrdered ? ordered.ThenByDescending(o => o.DateOfPurchase) : query.OrderByDescending(o => o.DateOfPurchase);
                                break;
							case "DateOfRegistration":
								query = isOrdered ? ordered.ThenBy(o => o.DateOfRegistration) : query.OrderBy(o => o.DateOfRegistration);
								 break;
							case "DateOfRegistration_desc":
                                query = isOrdered ? ordered.ThenByDescending(o => o.DateOfRegistration) : query.OrderByDescending(o => o.DateOfRegistration);
                                break;
							case "DateOfRegistrationExpire":
								query = isOrdered ? ordered.ThenBy(o => o.DateOfRegistrationExpire) : query.OrderBy(o => o.DateOfRegistrationExpire);
								 break;
							case "DateOfRegistrationExpire_desc":
                                query = isOrdered ? ordered.ThenByDescending(o => o.DateOfRegistrationExpire) : query.OrderByDescending(o => o.DateOfRegistrationExpire);
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
							case "Height":
								query = isOrdered ? ordered.ThenBy(o => o.Height) : query.OrderBy(o => o.Height);
								 break;
							case "Height_desc":
                                query = isOrdered ? ordered.ThenByDescending(o => o.Height) : query.OrderByDescending(o => o.Height);
                                break;
							case "VolumeMin":
								query = isOrdered ? ordered.ThenBy(o => o.VolumeMin) : query.OrderBy(o => o.VolumeMin);
								 break;
							case "VolumeMin_desc":
                                query = isOrdered ? ordered.ThenByDescending(o => o.VolumeMin) : query.OrderByDescending(o => o.VolumeMin);
                                break;
							case "VolumeRecommend":
								query = isOrdered ? ordered.ThenBy(o => o.VolumeRecommend) : query.OrderBy(o => o.VolumeRecommend);
								 break;
							case "VolumeRecommend_desc":
                                query = isOrdered ? ordered.ThenByDescending(o => o.VolumeRecommend) : query.OrderByDescending(o => o.VolumeRecommend);
                                break;
							case "VolumeMax":
								query = isOrdered ? ordered.ThenBy(o => o.VolumeMax) : query.OrderBy(o => o.VolumeMax);
								 break;
							case "VolumeMax_desc":
                                query = isOrdered ? ordered.ThenByDescending(o => o.VolumeMax) : query.OrderByDescending(o => o.VolumeMax);
                                break;
							case "WeightMin":
								query = isOrdered ? ordered.ThenBy(o => o.WeightMin) : query.OrderBy(o => o.WeightMin);
								 break;
							case "WeightMin_desc":
                                query = isOrdered ? ordered.ThenByDescending(o => o.WeightMin) : query.OrderByDescending(o => o.WeightMin);
                                break;
							case "WeightRecommend":
								query = isOrdered ? ordered.ThenBy(o => o.WeightRecommend) : query.OrderBy(o => o.WeightRecommend);
								 break;
							case "WeightRecommend_desc":
                                query = isOrdered ? ordered.ThenByDescending(o => o.WeightRecommend) : query.OrderByDescending(o => o.WeightRecommend);
                                break;
							case "WeightMax":
								query = isOrdered ? ordered.ThenBy(o => o.WeightMax) : query.OrderBy(o => o.WeightMax);
								 break;
							case "WeightMax_desc":
                                query = isOrdered ? ordered.ThenByDescending(o => o.WeightMax) : query.OrderByDescending(o => o.WeightMax);
                                break;
							case "IsForSample":
								query = isOrdered ? ordered.ThenBy(o => o.IsForSample) : query.OrderBy(o => o.IsForSample);
								 break;
							case "IsForSample_desc":
                                query = isOrdered ? ordered.ThenByDescending(o => o.IsForSample) : query.OrderByDescending(o => o.IsForSample);
                                break;
							case "IsForUrgent":
								query = isOrdered ? ordered.ThenBy(o => o.IsForUrgent) : query.OrderBy(o => o.IsForUrgent);
								 break;
							case "IsForUrgent_desc":
                                query = isOrdered ? ordered.ThenByDescending(o => o.IsForUrgent) : query.OrderByDescending(o => o.IsForUrgent);
                                break;
							case "IsForWholeSale":
								query = isOrdered ? ordered.ThenBy(o => o.IsForWholeSale) : query.OrderBy(o => o.IsForWholeSale);
								 break;
							case "IsForWholeSale_desc":
                                query = isOrdered ? ordered.ThenByDescending(o => o.IsForWholeSale) : query.OrderByDescending(o => o.IsForWholeSale);
                                break;
							case "RefShipper":
								query = isOrdered ? ordered.ThenBy(o => o.RefShipper) : query.OrderBy(o => o.RefShipper);
								 break;
							case "RefShipper_desc":
                                query = isOrdered ? ordered.ThenByDescending(o => o.RefShipper) : query.OrderByDescending(o => o.RefShipper);
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

        public static IQueryable<tbl_SHIP_Vehicle> _pagingBuilder(IQueryable<tbl_SHIP_Vehicle> query, Dictionary<string, string> QueryStrings)
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






