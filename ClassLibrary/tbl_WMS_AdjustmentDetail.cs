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
    
    
    public partial class tbl_WMS_AdjustmentDetail
    {
        public int IDBranch { get; set; }
        public int IDStorer { get; set; }
        public int IDAdjustment { get; set; }
        public int Id { get; set; }
        public string Status { get; set; }
        public int IDItem { get; set; }
        public int Location { get; set; }
        public int Lot { get; set; }
        public Nullable<int> LPN { get; set; }
        public decimal QuantityAdjusted { get; set; }
        public decimal Cube { get; set; }
        public decimal GrossWeight { get; set; }
        public decimal NetWeight { get; set; }
        public bool IsDeleted { get; set; }
        public string CreatedBy { get; set; }
        public string ModifiedBy { get; set; }
        public System.DateTime CreatedDate { get; set; }
        public System.DateTime ModifiedDate { get; set; }
        //List 0:1
        public virtual tbl_WMS_Adjustment tbl_WMS_Adjustment { get; set; }
        //List 0:1
        public virtual tbl_WMS_Item tbl_WMS_Item { get; set; }
        //List 0:1
        public virtual tbl_WMS_LicencePlateNumber tbl_WMS_LicencePlateNumber { get; set; }
        //List 0:1
        public virtual tbl_WMS_Location tbl_WMS_Location { get; set; }
        //List 0:1
        public virtual tbl_WMS_Lot tbl_WMS_Lot { get; set; }
    }
}


namespace DTOModel
{
	using System;
	public partial class DTO_WMS_AdjustmentDetail
	{
		public int IDBranch { get; set; }
		public int IDStorer { get; set; }
		public int IDAdjustment { get; set; }
		public int Id { get; set; }
		public string Status { get; set; }
		public int IDItem { get; set; }
		public int Location { get; set; }
		public int Lot { get; set; }
		public Nullable<int> LPN { get; set; }
		public decimal QuantityAdjusted { get; set; }
		public decimal Cube { get; set; }
		public decimal GrossWeight { get; set; }
		public decimal NetWeight { get; set; }
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

    public static partial class BS_WMS_AdjustmentDetail 
    {
        public static dynamic getSearch(AppEntities db, int IDBranch, int StaffID, Dictionary<string, string> QueryStrings)
        {
            return get(db, IDBranch,StaffID, QueryStrings);
        }

		public static IQueryable<DTO_WMS_AdjustmentDetail> get(AppEntities db, int IDBranch, int StaffID, Dictionary<string, string> QueryStrings)
        {
			var query = _queryBuilder(db, IDBranch, StaffID, QueryStrings);
            query = _sortBuilder(query, QueryStrings);
            query = _pagingBuilder(query, QueryStrings);

			return toDTO(query);
        }

        public static List<ItemModel> getValidateData(AppEntities db, int IDBranch, int StaffID, Dictionary<string, string> QueryStrings)
        {
            return get(db, IDBranch, StaffID, QueryStrings).Select(s => new ItemModel { 
                Id = s.Id, }).ToList();
        }

        public static string export(ExcelPackage package, AppEntities db, int IDBranch, int StaffID, Dictionary<string, string> QueryStrings)
        {
            package.Workbook.Properties.Title = "ART-DMS WMS_AdjustmentDetail";
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

		public static DTO_WMS_AdjustmentDetail getAnItem(AppEntities db, int IDBranch, int StaffID, int id)
        {
            var dbResult = db.tbl_WMS_AdjustmentDetail.Find(id);

			//if (dbResult == null || (IDBranch != 0 && dbResult.IDBranch != IDBranch))
			//	return null; 
			//else 
				return toDTO(dbResult);
			
        }
		

		public static bool put(AppEntities db, int IDBranch, int StaffID, int Id, dynamic item, string Username, Dictionary<string, string> QueryStrings)
        {
            bool result = false;
            var dbitem = db.tbl_WMS_AdjustmentDetail.Find(Id);
            
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
					errorLog.logMessage("put_WMS_AdjustmentDetail",e);
                    result = false;
                }
            }
            else
                if (QueryStrings.Any(d => d.Key == "ForceCreate"))
                    result =  post(db, IDBranch, StaffID, item, Username) != null;
                
            return result;
        }

        public static void patchDynamicToDB(dynamic item, tbl_WMS_AdjustmentDetail dbitem, string Username)
        {
            Type type = typeof(tbl_WMS_AdjustmentDetail);
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

        public static void patchDTOtoDBValue( DTO_WMS_AdjustmentDetail item, tbl_WMS_AdjustmentDetail dbitem)
        {
            if (item == null){
                dbitem = null;
                return;
            }
            							
			dbitem.IDBranch = item.IDBranch;							
			dbitem.IDStorer = item.IDStorer;							
			dbitem.IDAdjustment = item.IDAdjustment;							
			dbitem.Status = item.Status;							
			dbitem.IDItem = item.IDItem;							
			dbitem.Location = item.Location;							
			dbitem.Lot = item.Lot;							
			dbitem.LPN = item.LPN;							
			dbitem.QuantityAdjusted = item.QuantityAdjusted;							
			dbitem.Cube = item.Cube;							
			dbitem.GrossWeight = item.GrossWeight;							
			dbitem.NetWeight = item.NetWeight;							
			dbitem.IsDeleted = item.IsDeleted;        }

		public static DTO_WMS_AdjustmentDetail post(AppEntities db, int IDBranch, int StaffID, dynamic item, string Username)
        {
            tbl_WMS_AdjustmentDetail dbitem = new tbl_WMS_AdjustmentDetail();
            if (item != null)
            {
                patchDynamicToDB(item, dbitem, Username);
                
				dbitem.CreatedBy = Username;
				dbitem.CreatedDate = DateTime.Now;				
                try
                {
					db.tbl_WMS_AdjustmentDetail.Add(dbitem);
                    db.SaveChanges();
				
                }
                catch (DbEntityValidationException e)
                {
					errorLog.logMessage("post_WMS_AdjustmentDetail",e);
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
                Type type = Type.GetType("BaseBusiness.BS_WMS_AdjustmentDetail, ClassLibrary");
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
                        var target = new tbl_WMS_AdjustmentDetail();
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
                    
                    tbl_WMS_AdjustmentDetail dbitem = new tbl_WMS_AdjustmentDetail();
                    if (it.Id == null || string.IsNullOrEmpty(it.Id.Value) || it.Id == "0")
                    {
                        dbitem = new tbl_WMS_AdjustmentDetail();
                        dbitem.CreatedBy = Username;
				        dbitem.CreatedDate = DateTime.Now;
                                            }
                    else
                    {
                        dbitem = db.tbl_WMS_AdjustmentDetail.Find((int)it.Id);
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
                        
                        if (dbitem.Id == 0) db.tbl_WMS_AdjustmentDetail.Add(dbitem);
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
                    errorLog.logMessage("post_WMS_AdjustmentDetail",e);
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

            var dbitems = db.tbl_WMS_AdjustmentDetail.Where(d => IDs.Contains(d.Id));
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
                    BS_Version.update_Version(db, IDBranch, "DTO_WMS_AdjustmentDetail", updateDate, Username);
                }
			
            }
            catch (DbEntityValidationException e)
            {
				errorLog.logMessage("delete_WMS_AdjustmentDetail",e);
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
             
            return db.tbl_WMS_AdjustmentDetail.Any(e => e.Id == id && e.IsDeleted == false);
            
		}
		
		//---//
		public static IQueryable<DTO_WMS_AdjustmentDetail> toDTO(IQueryable<tbl_WMS_AdjustmentDetail> query)
        {
			return query
			.Select(s => new DTO_WMS_AdjustmentDetail(){							
				IDBranch = s.IDBranch,							
				IDStorer = s.IDStorer,							
				IDAdjustment = s.IDAdjustment,							
				Id = s.Id,							
				Status = s.Status,							
				IDItem = s.IDItem,							
				Location = s.Location,							
				Lot = s.Lot,							
				LPN = s.LPN,							
				QuantityAdjusted = s.QuantityAdjusted,							
				Cube = s.Cube,							
				GrossWeight = s.GrossWeight,							
				NetWeight = s.NetWeight,							
				IsDeleted = s.IsDeleted,							
				CreatedBy = s.CreatedBy,							
				ModifiedBy = s.ModifiedBy,							
				CreatedDate = s.CreatedDate,							
				ModifiedDate = s.ModifiedDate,					
			});//;
                              
        }

		public static DTO_WMS_AdjustmentDetail toDTO(tbl_WMS_AdjustmentDetail dbResult)
        {
			if (dbResult != null)
			{
				return new DTO_WMS_AdjustmentDetail()
				{							
					IDBranch = dbResult.IDBranch,							
					IDStorer = dbResult.IDStorer,							
					IDAdjustment = dbResult.IDAdjustment,							
					Id = dbResult.Id,							
					Status = dbResult.Status,							
					IDItem = dbResult.IDItem,							
					Location = dbResult.Location,							
					Lot = dbResult.Lot,							
					LPN = dbResult.LPN,							
					QuantityAdjusted = dbResult.QuantityAdjusted,							
					Cube = dbResult.Cube,							
					GrossWeight = dbResult.GrossWeight,							
					NetWeight = dbResult.NetWeight,							
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

		public static IQueryable<tbl_WMS_AdjustmentDetail> _queryBuilder(AppEntities db, int IDBranch, int StaffID, Dictionary<string, string> QueryStrings)
        {
            
			IQueryable<tbl_WMS_AdjustmentDetail> query = db.tbl_WMS_AdjustmentDetail.AsNoTracking();//.Where(d => d.IsDeleted == false);
			

			//Query keyword



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

			//Query IDAdjustment (int)
			if (QueryStrings.Any(d => d.Key == "IDAdjustment"))
            {
                var IDList = QueryStrings.FirstOrDefault(d => d.Key == "IDAdjustment").Value.Replace("[", "").Replace("]", "").Split(',');
                List<int> IDs = new List<int>();
                foreach (var item in IDList)
                    if (int.TryParse(item, out int i))
                        IDs.Add(i);
                if (IDs.Count > 0)
                    query = query.Where(d => IDs.Contains(d.IDAdjustment));
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
            

			//Query IDItem (int)
			if (QueryStrings.Any(d => d.Key == "IDItem"))
            {
                var IDList = QueryStrings.FirstOrDefault(d => d.Key == "IDItem").Value.Replace("[", "").Replace("]", "").Split(',');
                List<int> IDs = new List<int>();
                foreach (var item in IDList)
                    if (int.TryParse(item, out int i))
                        IDs.Add(i);
                if (IDs.Count > 0)
                    query = query.Where(d => IDs.Contains(d.IDItem));
            }

			//Query Location (int)
			if (QueryStrings.Any(d => d.Key == "LocationFrom") && QueryStrings.Any(d => d.Key == "LocationTo"))
                if (int.TryParse(QueryStrings.FirstOrDefault(d => d.Key == "LocationFrom").Value, out int fromVal) && int.TryParse(QueryStrings.FirstOrDefault(d => d.Key == "LocationTo").Value, out int toVal))
                    query = query.Where(d => fromVal <= d.Location && d.Location <= toVal);
            
            if (QueryStrings.Any(d => d.Key == "Location"))
                if (int.TryParse(QueryStrings.FirstOrDefault(d => d.Key == "Location").Value, out int val))
                    query = query.Where(d => val == d.Location);


			//Query Lot (int)
			if (QueryStrings.Any(d => d.Key == "LotFrom") && QueryStrings.Any(d => d.Key == "LotTo"))
                if (int.TryParse(QueryStrings.FirstOrDefault(d => d.Key == "LotFrom").Value, out int fromVal) && int.TryParse(QueryStrings.FirstOrDefault(d => d.Key == "LotTo").Value, out int toVal))
                    query = query.Where(d => fromVal <= d.Lot && d.Lot <= toVal);
            
            if (QueryStrings.Any(d => d.Key == "Lot"))
                if (int.TryParse(QueryStrings.FirstOrDefault(d => d.Key == "Lot").Value, out int val))
                    query = query.Where(d => val == d.Lot);


			//Query LPN (Nullable<int>)
			if (QueryStrings.Any(d => d.Key == "LPNFrom") && QueryStrings.Any(d => d.Key == "LPNTo"))
                if (int.TryParse(QueryStrings.FirstOrDefault(d => d.Key == "LPNFrom").Value, out int fromVal) && int.TryParse(QueryStrings.FirstOrDefault(d => d.Key == "LPNTo").Value, out int toVal))
                    query = query.Where(d => fromVal <= d.LPN && d.LPN <= toVal);

			//Query QuantityAdjusted (decimal)
			if (QueryStrings.Any(d => d.Key == "QuantityAdjustedFrom") && QueryStrings.Any(d => d.Key == "QuantityAdjustedTo"))
                if (decimal.TryParse(QueryStrings.FirstOrDefault(d => d.Key == "QuantityAdjustedFrom").Value, out decimal fromVal) && decimal.TryParse(QueryStrings.FirstOrDefault(d => d.Key == "QuantityAdjustedTo").Value, out decimal toVal))
                    query = query.Where(d => fromVal <= d.QuantityAdjusted && d.QuantityAdjusted <= toVal);
            
            if (QueryStrings.Any(d => d.Key == "QuantityAdjusted"))
                if (decimal.TryParse(QueryStrings.FirstOrDefault(d => d.Key == "QuantityAdjusted").Value, out decimal val))
                    query = query.Where(d => val == d.QuantityAdjusted);


			//Query Cube (decimal)
			if (QueryStrings.Any(d => d.Key == "CubeFrom") && QueryStrings.Any(d => d.Key == "CubeTo"))
                if (decimal.TryParse(QueryStrings.FirstOrDefault(d => d.Key == "CubeFrom").Value, out decimal fromVal) && decimal.TryParse(QueryStrings.FirstOrDefault(d => d.Key == "CubeTo").Value, out decimal toVal))
                    query = query.Where(d => fromVal <= d.Cube && d.Cube <= toVal);
            
            if (QueryStrings.Any(d => d.Key == "Cube"))
                if (decimal.TryParse(QueryStrings.FirstOrDefault(d => d.Key == "Cube").Value, out decimal val))
                    query = query.Where(d => val == d.Cube);


			//Query GrossWeight (decimal)
			if (QueryStrings.Any(d => d.Key == "GrossWeightFrom") && QueryStrings.Any(d => d.Key == "GrossWeightTo"))
                if (decimal.TryParse(QueryStrings.FirstOrDefault(d => d.Key == "GrossWeightFrom").Value, out decimal fromVal) && decimal.TryParse(QueryStrings.FirstOrDefault(d => d.Key == "GrossWeightTo").Value, out decimal toVal))
                    query = query.Where(d => fromVal <= d.GrossWeight && d.GrossWeight <= toVal);
            
            if (QueryStrings.Any(d => d.Key == "GrossWeight"))
                if (decimal.TryParse(QueryStrings.FirstOrDefault(d => d.Key == "GrossWeight").Value, out decimal val))
                    query = query.Where(d => val == d.GrossWeight);


			//Query NetWeight (decimal)
			if (QueryStrings.Any(d => d.Key == "NetWeightFrom") && QueryStrings.Any(d => d.Key == "NetWeightTo"))
                if (decimal.TryParse(QueryStrings.FirstOrDefault(d => d.Key == "NetWeightFrom").Value, out decimal fromVal) && decimal.TryParse(QueryStrings.FirstOrDefault(d => d.Key == "NetWeightTo").Value, out decimal toVal))
                    query = query.Where(d => fromVal <= d.NetWeight && d.NetWeight <= toVal);
            
            if (QueryStrings.Any(d => d.Key == "NetWeight"))
                if (decimal.TryParse(QueryStrings.FirstOrDefault(d => d.Key == "NetWeight").Value, out decimal val))
                    query = query.Where(d => val == d.NetWeight);


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
		
        public static IQueryable<tbl_WMS_AdjustmentDetail> _sortBuilder(IQueryable<tbl_WMS_AdjustmentDetail> query, Dictionary<string, string> QueryStrings)
        {
            if (QueryStrings.Any(d => d.Key == "SortBy"))
            {
                var sorts = QueryStrings.FirstOrDefault(d => d.Key == "SortBy").Value.Replace("[", "").Replace("]", "").Split(',');
                
                foreach (var item in sorts)
                    if (!string.IsNullOrEmpty(item))
                    {
                        var ordered = query as IOrderedQueryable<tbl_WMS_AdjustmentDetail>;
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
							case "IDAdjustment":
								query = isOrdered ? ordered.ThenBy(o => o.IDAdjustment) : query.OrderBy(o => o.IDAdjustment);
								 break;
							case "IDAdjustment_desc":
                                query = isOrdered ? ordered.ThenByDescending(o => o.IDAdjustment) : query.OrderByDescending(o => o.IDAdjustment);
                                break;
							case "Id":
								query = isOrdered ? ordered.ThenBy(o => o.Id) : query.OrderBy(o => o.Id);
								 break;
							case "Id_desc":
                                query = isOrdered ? ordered.ThenByDescending(o => o.Id) : query.OrderByDescending(o => o.Id);
                                break;
							case "Status":
								query = isOrdered ? ordered.ThenBy(o => o.Status) : query.OrderBy(o => o.Status);
								 break;
							case "Status_desc":
                                query = isOrdered ? ordered.ThenByDescending(o => o.Status) : query.OrderByDescending(o => o.Status);
                                break;
							case "IDItem":
								query = isOrdered ? ordered.ThenBy(o => o.IDItem) : query.OrderBy(o => o.IDItem);
								 break;
							case "IDItem_desc":
                                query = isOrdered ? ordered.ThenByDescending(o => o.IDItem) : query.OrderByDescending(o => o.IDItem);
                                break;
							case "Location":
								query = isOrdered ? ordered.ThenBy(o => o.Location) : query.OrderBy(o => o.Location);
								 break;
							case "Location_desc":
                                query = isOrdered ? ordered.ThenByDescending(o => o.Location) : query.OrderByDescending(o => o.Location);
                                break;
							case "Lot":
								query = isOrdered ? ordered.ThenBy(o => o.Lot) : query.OrderBy(o => o.Lot);
								 break;
							case "Lot_desc":
                                query = isOrdered ? ordered.ThenByDescending(o => o.Lot) : query.OrderByDescending(o => o.Lot);
                                break;
							case "LPN":
								query = isOrdered ? ordered.ThenBy(o => o.LPN) : query.OrderBy(o => o.LPN);
								 break;
							case "LPN_desc":
                                query = isOrdered ? ordered.ThenByDescending(o => o.LPN) : query.OrderByDescending(o => o.LPN);
                                break;
							case "QuantityAdjusted":
								query = isOrdered ? ordered.ThenBy(o => o.QuantityAdjusted) : query.OrderBy(o => o.QuantityAdjusted);
								 break;
							case "QuantityAdjusted_desc":
                                query = isOrdered ? ordered.ThenByDescending(o => o.QuantityAdjusted) : query.OrderByDescending(o => o.QuantityAdjusted);
                                break;
							case "Cube":
								query = isOrdered ? ordered.ThenBy(o => o.Cube) : query.OrderBy(o => o.Cube);
								 break;
							case "Cube_desc":
                                query = isOrdered ? ordered.ThenByDescending(o => o.Cube) : query.OrderByDescending(o => o.Cube);
                                break;
							case "GrossWeight":
								query = isOrdered ? ordered.ThenBy(o => o.GrossWeight) : query.OrderBy(o => o.GrossWeight);
								 break;
							case "GrossWeight_desc":
                                query = isOrdered ? ordered.ThenByDescending(o => o.GrossWeight) : query.OrderByDescending(o => o.GrossWeight);
                                break;
							case "NetWeight":
								query = isOrdered ? ordered.ThenBy(o => o.NetWeight) : query.OrderBy(o => o.NetWeight);
								 break;
							case "NetWeight_desc":
                                query = isOrdered ? ordered.ThenByDescending(o => o.NetWeight) : query.OrderByDescending(o => o.NetWeight);
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

        public static IQueryable<tbl_WMS_AdjustmentDetail> _pagingBuilder(IQueryable<tbl_WMS_AdjustmentDetail> query, Dictionary<string, string> QueryStrings)
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






