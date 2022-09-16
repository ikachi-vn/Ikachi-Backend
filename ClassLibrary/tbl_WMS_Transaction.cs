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
    
    
    public partial class tbl_WMS_Transaction
    {
        public int IDBranch { get; set; }
        public int IDStorer { get; set; }
        public int Id { get; set; }
        public string TransactionType { get; set; }
        public int IDItem { get; set; }
        public int Lot { get; set; }
        public Nullable<int> FromLocation { get; set; }
        public Nullable<int> ToLocation { get; set; }
        public Nullable<int> FromLPN { get; set; }
        public Nullable<int> ToLPN { get; set; }
        public Nullable<int> SourceKey { get; set; }
        public string SourceType { get; set; }
        public string Status { get; set; }
        public int IDUoM { get; set; }
        public decimal UoMQuantity { get; set; }
        public decimal Quantity { get; set; }
        public decimal Cube { get; set; }
        public decimal GrossWeight { get; set; }
        public decimal NetWeight { get; set; }
        public bool IsDeleted { get; set; }
        public string CreatedBy { get; set; }
        public string ModifiedBy { get; set; }
        public System.DateTime CreatedDate { get; set; }
        public System.DateTime ModifiedDate { get; set; }
        public Nullable<int> IDTransaction { get; set; }
        public System.DateTime TransactionDate { get; set; }
        //List 0:1
        public virtual tbl_BRA_Branch tbl_BRA_Branch { get; set; }
        //List 0:1
        public virtual tbl_BRA_Branch tbl_BRA_Branch1 { get; set; }
        //List 0:1
        public virtual tbl_WMS_Item tbl_WMS_Item { get; set; }
        //List 0:1
        public virtual tbl_WMS_ItemUoM tbl_WMS_ItemUoM { get; set; }
        //List 0:1
        public virtual tbl_WMS_LicencePlateNumber tbl_WMS_LicencePlateNumber { get; set; }
        //List 0:1
        public virtual tbl_WMS_LicencePlateNumber tbl_WMS_LicencePlateNumber1 { get; set; }
        //List 0:1
        public virtual tbl_WMS_Location tbl_WMS_Location { get; set; }
        //List 0:1
        public virtual tbl_WMS_Location tbl_WMS_Location1 { get; set; }
        //List 0:1
        public virtual tbl_WMS_Lot tbl_WMS_Lot { get; set; }
        //List 0:1
        public virtual tbl_WMS_Storer tbl_WMS_Storer { get; set; }
    }
}


namespace DTOModel
{
	using System;
	public partial class DTO_WMS_Transaction
	{
		public int IDBranch { get; set; }
		public int IDStorer { get; set; }
		public int Id { get; set; }
		public string TransactionType { get; set; }
		public int IDItem { get; set; }
		public int Lot { get; set; }
		public Nullable<int> FromLocation { get; set; }
		public Nullable<int> ToLocation { get; set; }
		public Nullable<int> FromLPN { get; set; }
		public Nullable<int> ToLPN { get; set; }
		public Nullable<int> SourceKey { get; set; }
		public string SourceType { get; set; }
		public string Status { get; set; }
		public int IDUoM { get; set; }
		public decimal UoMQuantity { get; set; }
		public decimal Quantity { get; set; }
		public decimal Cube { get; set; }
		public decimal GrossWeight { get; set; }
		public decimal NetWeight { get; set; }
		public bool IsDeleted { get; set; }
		public string CreatedBy { get; set; }
		public string ModifiedBy { get; set; }
		public System.DateTime CreatedDate { get; set; }
		public System.DateTime ModifiedDate { get; set; }
		public Nullable<int> IDTransaction { get; set; }
		public System.DateTime TransactionDate { get; set; }
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

    public static partial class BS_WMS_Transaction 
    {
        public static dynamic getSearch(AppEntities db, int IDBranch, int StaffID, Dictionary<string, string> QueryStrings)
        {
            return get(db, IDBranch,StaffID, QueryStrings);
        }

		public static IQueryable<DTO_WMS_Transaction> get(AppEntities db, int IDBranch, int StaffID, Dictionary<string, string> QueryStrings)
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
            package.Workbook.Properties.Title = "ART-DMS WMS_Transaction";
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

		public static DTO_WMS_Transaction getAnItem(AppEntities db, int IDBranch, int StaffID, int id)
        {
            var dbResult = db.tbl_WMS_Transaction.Find(id);

			//if (dbResult == null || (IDBranch != 0 && dbResult.IDBranch != IDBranch))
			//	return null; 
			//else 
				return toDTO(dbResult);
			
        }
		

		public static bool put(AppEntities db, int IDBranch, int StaffID, int Id, dynamic item, string Username, Dictionary<string, string> QueryStrings)
        {
            bool result = false;
            var dbitem = db.tbl_WMS_Transaction.Find(Id);
            
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
					errorLog.logMessage("put_WMS_Transaction",e);
                    result = false;
                }
            }
            else
                if (QueryStrings.Any(d => d.Key == "ForceCreate"))
                    result =  post(db, IDBranch, StaffID, item, Username) != null;
                
            return result;
        }

        public static void patchDynamicToDB(dynamic item, tbl_WMS_Transaction dbitem, string Username)
        {
            Type type = typeof(tbl_WMS_Transaction);
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

        public static void patchDTOtoDBValue( DTO_WMS_Transaction item, tbl_WMS_Transaction dbitem)
        {
            if (item == null){
                dbitem = null;
                return;
            }
            							
			dbitem.IDBranch = item.IDBranch;							
			dbitem.IDStorer = item.IDStorer;							
			dbitem.TransactionType = item.TransactionType;							
			dbitem.IDItem = item.IDItem;							
			dbitem.Lot = item.Lot;							
			dbitem.FromLocation = item.FromLocation;							
			dbitem.ToLocation = item.ToLocation;							
			dbitem.FromLPN = item.FromLPN;							
			dbitem.ToLPN = item.ToLPN;							
			dbitem.SourceKey = item.SourceKey;							
			dbitem.SourceType = item.SourceType;							
			dbitem.Status = item.Status;							
			dbitem.IDUoM = item.IDUoM;							
			dbitem.UoMQuantity = item.UoMQuantity;							
			dbitem.Quantity = item.Quantity;							
			dbitem.Cube = item.Cube;							
			dbitem.GrossWeight = item.GrossWeight;							
			dbitem.NetWeight = item.NetWeight;							
			dbitem.IsDeleted = item.IsDeleted;							
			dbitem.IDTransaction = item.IDTransaction;							
			dbitem.TransactionDate = item.TransactionDate;        }

		public static DTO_WMS_Transaction post(AppEntities db, int IDBranch, int StaffID, dynamic item, string Username)
        {
            tbl_WMS_Transaction dbitem = new tbl_WMS_Transaction();
            if (item != null)
            {
                patchDynamicToDB(item, dbitem, Username);
                
				dbitem.CreatedBy = Username;
				dbitem.CreatedDate = DateTime.Now;				
                try
                {
					db.tbl_WMS_Transaction.Add(dbitem);
                    db.SaveChanges();
				
                }
                catch (DbEntityValidationException e)
                {
					errorLog.logMessage("post_WMS_Transaction",e);
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
                Type type = Type.GetType("BaseBusiness.BS_WMS_Transaction, ClassLibrary");
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
                        var target = new tbl_WMS_Transaction();
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
                    
                    tbl_WMS_Transaction dbitem = new tbl_WMS_Transaction();
                    if (it.Id == null || string.IsNullOrEmpty(it.Id.Value) || it.Id == "0")
                    {
                        dbitem = new tbl_WMS_Transaction();
                        dbitem.CreatedBy = Username;
				        dbitem.CreatedDate = DateTime.Now;
                                            }
                    else
                    {
                        dbitem = db.tbl_WMS_Transaction.Find((int)it.Id);
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
                        
                        if (dbitem.Id == 0) db.tbl_WMS_Transaction.Add(dbitem);
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
                    errorLog.logMessage("post_WMS_Transaction",e);
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

            var dbitems = db.tbl_WMS_Transaction.Where(d => IDs.Contains(d.Id));
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
                    BS_Version.update_Version(db, IDBranch, "DTO_WMS_Transaction", updateDate, Username);
                }
			
            }
            catch (DbEntityValidationException e)
            {
				errorLog.logMessage("delete_WMS_Transaction",e);
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
             
            return db.tbl_WMS_Transaction.Any(e => e.Id == id && e.IsDeleted == false);
            
		}
		
		//---//
		public static IQueryable<DTO_WMS_Transaction> toDTO(IQueryable<tbl_WMS_Transaction> query)
        {
			return query
			.Select(s => new DTO_WMS_Transaction(){							
				IDBranch = s.IDBranch,							
				IDStorer = s.IDStorer,							
				Id = s.Id,							
				TransactionType = s.TransactionType,							
				IDItem = s.IDItem,							
				Lot = s.Lot,							
				FromLocation = s.FromLocation,							
				ToLocation = s.ToLocation,							
				FromLPN = s.FromLPN,							
				ToLPN = s.ToLPN,							
				SourceKey = s.SourceKey,							
				SourceType = s.SourceType,							
				Status = s.Status,							
				IDUoM = s.IDUoM,							
				UoMQuantity = s.UoMQuantity,							
				Quantity = s.Quantity,							
				Cube = s.Cube,							
				GrossWeight = s.GrossWeight,							
				NetWeight = s.NetWeight,							
				IsDeleted = s.IsDeleted,							
				CreatedBy = s.CreatedBy,							
				ModifiedBy = s.ModifiedBy,							
				CreatedDate = s.CreatedDate,							
				ModifiedDate = s.ModifiedDate,							
				IDTransaction = s.IDTransaction,							
				TransactionDate = s.TransactionDate,					
			});//;
                              
        }

		public static DTO_WMS_Transaction toDTO(tbl_WMS_Transaction dbResult)
        {
			if (dbResult != null)
			{
				return new DTO_WMS_Transaction()
				{							
					IDBranch = dbResult.IDBranch,							
					IDStorer = dbResult.IDStorer,							
					Id = dbResult.Id,							
					TransactionType = dbResult.TransactionType,							
					IDItem = dbResult.IDItem,							
					Lot = dbResult.Lot,							
					FromLocation = dbResult.FromLocation,							
					ToLocation = dbResult.ToLocation,							
					FromLPN = dbResult.FromLPN,							
					ToLPN = dbResult.ToLPN,							
					SourceKey = dbResult.SourceKey,							
					SourceType = dbResult.SourceType,							
					Status = dbResult.Status,							
					IDUoM = dbResult.IDUoM,							
					UoMQuantity = dbResult.UoMQuantity,							
					Quantity = dbResult.Quantity,							
					Cube = dbResult.Cube,							
					GrossWeight = dbResult.GrossWeight,							
					NetWeight = dbResult.NetWeight,							
					IsDeleted = dbResult.IsDeleted,							
					CreatedBy = dbResult.CreatedBy,							
					ModifiedBy = dbResult.ModifiedBy,							
					CreatedDate = dbResult.CreatedDate,							
					ModifiedDate = dbResult.ModifiedDate,							
					IDTransaction = dbResult.IDTransaction,							
					TransactionDate = dbResult.TransactionDate,
				};
			}
			else
				return null; 
        }

		public static IQueryable<tbl_WMS_Transaction> _queryBuilder(AppEntities db, int IDBranch, int StaffID, Dictionary<string, string> QueryStrings)
        {
            
			IQueryable<tbl_WMS_Transaction> query = db.tbl_WMS_Transaction.AsNoTracking();//.Where(d => d.IsDeleted == false);
			

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

			//Query TransactionType (string)
			if (QueryStrings.Any(d => d.Key == "TransactionType_eq") && !string.IsNullOrEmpty(QueryStrings.FirstOrDefault(d => d.Key == "TransactionType_eq").Value))
            {
                var keyword = QueryStrings.FirstOrDefault(d => d.Key == "TransactionType_eq").Value;
                query = query.Where(d=>d.TransactionType == keyword);
            }
            if (QueryStrings.Any(d => d.Key == "TransactionType") && !string.IsNullOrEmpty(QueryStrings.FirstOrDefault(d => d.Key == "TransactionType").Value))
            {
                var keyword = QueryStrings.FirstOrDefault(d => d.Key == "TransactionType").Value;
                query = query.Where(d=>d.TransactionType.Contains(keyword));
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

			//Query Lot (int)
			if (QueryStrings.Any(d => d.Key == "LotFrom") && QueryStrings.Any(d => d.Key == "LotTo"))
                if (int.TryParse(QueryStrings.FirstOrDefault(d => d.Key == "LotFrom").Value, out int fromVal) && int.TryParse(QueryStrings.FirstOrDefault(d => d.Key == "LotTo").Value, out int toVal))
                    query = query.Where(d => fromVal <= d.Lot && d.Lot <= toVal);
            
            if (QueryStrings.Any(d => d.Key == "Lot"))
                if (int.TryParse(QueryStrings.FirstOrDefault(d => d.Key == "Lot").Value, out int val))
                    query = query.Where(d => val == d.Lot);


			//Query FromLocation (Nullable<int>)
			if (QueryStrings.Any(d => d.Key == "FromLocationFrom") && QueryStrings.Any(d => d.Key == "FromLocationTo"))
                if (int.TryParse(QueryStrings.FirstOrDefault(d => d.Key == "FromLocationFrom").Value, out int fromVal) && int.TryParse(QueryStrings.FirstOrDefault(d => d.Key == "FromLocationTo").Value, out int toVal))
                    query = query.Where(d => fromVal <= d.FromLocation && d.FromLocation <= toVal);

			//Query ToLocation (Nullable<int>)
			if (QueryStrings.Any(d => d.Key == "ToLocationFrom") && QueryStrings.Any(d => d.Key == "ToLocationTo"))
                if (int.TryParse(QueryStrings.FirstOrDefault(d => d.Key == "ToLocationFrom").Value, out int fromVal) && int.TryParse(QueryStrings.FirstOrDefault(d => d.Key == "ToLocationTo").Value, out int toVal))
                    query = query.Where(d => fromVal <= d.ToLocation && d.ToLocation <= toVal);

			//Query FromLPN (Nullable<int>)
			if (QueryStrings.Any(d => d.Key == "FromLPNFrom") && QueryStrings.Any(d => d.Key == "FromLPNTo"))
                if (int.TryParse(QueryStrings.FirstOrDefault(d => d.Key == "FromLPNFrom").Value, out int fromVal) && int.TryParse(QueryStrings.FirstOrDefault(d => d.Key == "FromLPNTo").Value, out int toVal))
                    query = query.Where(d => fromVal <= d.FromLPN && d.FromLPN <= toVal);

			//Query ToLPN (Nullable<int>)
			if (QueryStrings.Any(d => d.Key == "ToLPNFrom") && QueryStrings.Any(d => d.Key == "ToLPNTo"))
                if (int.TryParse(QueryStrings.FirstOrDefault(d => d.Key == "ToLPNFrom").Value, out int fromVal) && int.TryParse(QueryStrings.FirstOrDefault(d => d.Key == "ToLPNTo").Value, out int toVal))
                    query = query.Where(d => fromVal <= d.ToLPN && d.ToLPN <= toVal);

			//Query SourceKey (Nullable<int>)
			if (QueryStrings.Any(d => d.Key == "SourceKeyFrom") && QueryStrings.Any(d => d.Key == "SourceKeyTo"))
                if (int.TryParse(QueryStrings.FirstOrDefault(d => d.Key == "SourceKeyFrom").Value, out int fromVal) && int.TryParse(QueryStrings.FirstOrDefault(d => d.Key == "SourceKeyTo").Value, out int toVal))
                    query = query.Where(d => fromVal <= d.SourceKey && d.SourceKey <= toVal);

			//Query SourceType (string)
			if (QueryStrings.Any(d => d.Key == "SourceType_eq") && !string.IsNullOrEmpty(QueryStrings.FirstOrDefault(d => d.Key == "SourceType_eq").Value))
            {
                var keyword = QueryStrings.FirstOrDefault(d => d.Key == "SourceType_eq").Value;
                query = query.Where(d=>d.SourceType == keyword);
            }
            if (QueryStrings.Any(d => d.Key == "SourceType") && !string.IsNullOrEmpty(QueryStrings.FirstOrDefault(d => d.Key == "SourceType").Value))
            {
                var keyword = QueryStrings.FirstOrDefault(d => d.Key == "SourceType").Value;
                query = query.Where(d=>d.SourceType.Contains(keyword));
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
            

			//Query IDUoM (int)
			if (QueryStrings.Any(d => d.Key == "IDUoM"))
            {
                var IDList = QueryStrings.FirstOrDefault(d => d.Key == "IDUoM").Value.Replace("[", "").Replace("]", "").Split(',');
                List<int> IDs = new List<int>();
                foreach (var item in IDList)
                    if (int.TryParse(item, out int i))
                        IDs.Add(i);
                if (IDs.Count > 0)
                    query = query.Where(d => IDs.Contains(d.IDUoM));
            }

			//Query UoMQuantity (decimal)
			if (QueryStrings.Any(d => d.Key == "UoMQuantityFrom") && QueryStrings.Any(d => d.Key == "UoMQuantityTo"))
                if (decimal.TryParse(QueryStrings.FirstOrDefault(d => d.Key == "UoMQuantityFrom").Value, out decimal fromVal) && decimal.TryParse(QueryStrings.FirstOrDefault(d => d.Key == "UoMQuantityTo").Value, out decimal toVal))
                    query = query.Where(d => fromVal <= d.UoMQuantity && d.UoMQuantity <= toVal);
            
            if (QueryStrings.Any(d => d.Key == "UoMQuantity"))
                if (decimal.TryParse(QueryStrings.FirstOrDefault(d => d.Key == "UoMQuantity").Value, out decimal val))
                    query = query.Where(d => val == d.UoMQuantity);


			//Query Quantity (decimal)
			if (QueryStrings.Any(d => d.Key == "QuantityFrom") && QueryStrings.Any(d => d.Key == "QuantityTo"))
                if (decimal.TryParse(QueryStrings.FirstOrDefault(d => d.Key == "QuantityFrom").Value, out decimal fromVal) && decimal.TryParse(QueryStrings.FirstOrDefault(d => d.Key == "QuantityTo").Value, out decimal toVal))
                    query = query.Where(d => fromVal <= d.Quantity && d.Quantity <= toVal);
            
            if (QueryStrings.Any(d => d.Key == "Quantity"))
                if (decimal.TryParse(QueryStrings.FirstOrDefault(d => d.Key == "Quantity").Value, out decimal val))
                    query = query.Where(d => val == d.Quantity);


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


			//Query IDTransaction (Nullable<int>)
			if (QueryStrings.Any(d => d.Key == "IDTransaction"))
            {
                var IDList = QueryStrings.FirstOrDefault(d => d.Key == "IDTransaction").Value.Replace("[", "").Replace("]", "").Split(',');
                List<int?> IDs = new List<int?>();
                foreach (var item in IDList)
                    if (int.TryParse(item, out int i))
                        IDs.Add(i);
					else if (item == "null")
						IDs.Add(null);
                if (IDs.Count > 0)
                    query = query.Where(d => IDs.Contains(d.IDTransaction));
////                    query = query.Where(d => IDs.Contains(d.IDTransaction));
//                    
            }

			//Query TransactionDate (System.DateTime)
			if (QueryStrings.Any(d => d.Key == "TransactionDateFrom") && QueryStrings.Any(d => d.Key == "TransactionDateTo"))
                if (DateTime.TryParse(QueryStrings.FirstOrDefault(d => d.Key == "TransactionDateFrom").Value, out DateTime fromDate) && DateTime.TryParse(QueryStrings.FirstOrDefault(d => d.Key == "TransactionDateTo").Value, out DateTime toDate))
                    query = query.Where(d => fromDate <= d.TransactionDate && d.TransactionDate <= toDate);

            if (QueryStrings.Any(d => d.Key == "TransactionDate"))
                if (DateTime.TryParse(QueryStrings.FirstOrDefault(d => d.Key == "TransactionDate").Value, out DateTime val))
                    query = query.Where(d => d.TransactionDate != null && DbFunctions.TruncateTime(val) == DbFunctions.TruncateTime(d.TransactionDate));

            return query;
        }
		
        public static IQueryable<tbl_WMS_Transaction> _sortBuilder(IQueryable<tbl_WMS_Transaction> query, Dictionary<string, string> QueryStrings)
        {
            if (QueryStrings.Any(d => d.Key == "SortBy"))
            {
                var sorts = QueryStrings.FirstOrDefault(d => d.Key == "SortBy").Value.Replace("[", "").Replace("]", "").Split(',');
                
                foreach (var item in sorts)
                    if (!string.IsNullOrEmpty(item))
                    {
                        var ordered = query as IOrderedQueryable<tbl_WMS_Transaction>;
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
							case "Id":
								query = isOrdered ? ordered.ThenBy(o => o.Id) : query.OrderBy(o => o.Id);
								 break;
							case "Id_desc":
                                query = isOrdered ? ordered.ThenByDescending(o => o.Id) : query.OrderByDescending(o => o.Id);
                                break;
							case "TransactionType":
								query = isOrdered ? ordered.ThenBy(o => o.TransactionType) : query.OrderBy(o => o.TransactionType);
								 break;
							case "TransactionType_desc":
                                query = isOrdered ? ordered.ThenByDescending(o => o.TransactionType) : query.OrderByDescending(o => o.TransactionType);
                                break;
							case "IDItem":
								query = isOrdered ? ordered.ThenBy(o => o.IDItem) : query.OrderBy(o => o.IDItem);
								 break;
							case "IDItem_desc":
                                query = isOrdered ? ordered.ThenByDescending(o => o.IDItem) : query.OrderByDescending(o => o.IDItem);
                                break;
							case "Lot":
								query = isOrdered ? ordered.ThenBy(o => o.Lot) : query.OrderBy(o => o.Lot);
								 break;
							case "Lot_desc":
                                query = isOrdered ? ordered.ThenByDescending(o => o.Lot) : query.OrderByDescending(o => o.Lot);
                                break;
							case "FromLocation":
								query = isOrdered ? ordered.ThenBy(o => o.FromLocation) : query.OrderBy(o => o.FromLocation);
								 break;
							case "FromLocation_desc":
                                query = isOrdered ? ordered.ThenByDescending(o => o.FromLocation) : query.OrderByDescending(o => o.FromLocation);
                                break;
							case "ToLocation":
								query = isOrdered ? ordered.ThenBy(o => o.ToLocation) : query.OrderBy(o => o.ToLocation);
								 break;
							case "ToLocation_desc":
                                query = isOrdered ? ordered.ThenByDescending(o => o.ToLocation) : query.OrderByDescending(o => o.ToLocation);
                                break;
							case "FromLPN":
								query = isOrdered ? ordered.ThenBy(o => o.FromLPN) : query.OrderBy(o => o.FromLPN);
								 break;
							case "FromLPN_desc":
                                query = isOrdered ? ordered.ThenByDescending(o => o.FromLPN) : query.OrderByDescending(o => o.FromLPN);
                                break;
							case "ToLPN":
								query = isOrdered ? ordered.ThenBy(o => o.ToLPN) : query.OrderBy(o => o.ToLPN);
								 break;
							case "ToLPN_desc":
                                query = isOrdered ? ordered.ThenByDescending(o => o.ToLPN) : query.OrderByDescending(o => o.ToLPN);
                                break;
							case "SourceKey":
								query = isOrdered ? ordered.ThenBy(o => o.SourceKey) : query.OrderBy(o => o.SourceKey);
								 break;
							case "SourceKey_desc":
                                query = isOrdered ? ordered.ThenByDescending(o => o.SourceKey) : query.OrderByDescending(o => o.SourceKey);
                                break;
							case "SourceType":
								query = isOrdered ? ordered.ThenBy(o => o.SourceType) : query.OrderBy(o => o.SourceType);
								 break;
							case "SourceType_desc":
                                query = isOrdered ? ordered.ThenByDescending(o => o.SourceType) : query.OrderByDescending(o => o.SourceType);
                                break;
							case "Status":
								query = isOrdered ? ordered.ThenBy(o => o.Status) : query.OrderBy(o => o.Status);
								 break;
							case "Status_desc":
                                query = isOrdered ? ordered.ThenByDescending(o => o.Status) : query.OrderByDescending(o => o.Status);
                                break;
							case "IDUoM":
								query = isOrdered ? ordered.ThenBy(o => o.IDUoM) : query.OrderBy(o => o.IDUoM);
								 break;
							case "IDUoM_desc":
                                query = isOrdered ? ordered.ThenByDescending(o => o.IDUoM) : query.OrderByDescending(o => o.IDUoM);
                                break;
							case "UoMQuantity":
								query = isOrdered ? ordered.ThenBy(o => o.UoMQuantity) : query.OrderBy(o => o.UoMQuantity);
								 break;
							case "UoMQuantity_desc":
                                query = isOrdered ? ordered.ThenByDescending(o => o.UoMQuantity) : query.OrderByDescending(o => o.UoMQuantity);
                                break;
							case "Quantity":
								query = isOrdered ? ordered.ThenBy(o => o.Quantity) : query.OrderBy(o => o.Quantity);
								 break;
							case "Quantity_desc":
                                query = isOrdered ? ordered.ThenByDescending(o => o.Quantity) : query.OrderByDescending(o => o.Quantity);
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
							case "IDTransaction":
								query = isOrdered ? ordered.ThenBy(o => o.IDTransaction) : query.OrderBy(o => o.IDTransaction);
								 break;
							case "IDTransaction_desc":
                                query = isOrdered ? ordered.ThenByDescending(o => o.IDTransaction) : query.OrderByDescending(o => o.IDTransaction);
                                break;
							case "TransactionDate":
								query = isOrdered ? ordered.ThenBy(o => o.TransactionDate) : query.OrderBy(o => o.TransactionDate);
								 break;
							case "TransactionDate_desc":
                                query = isOrdered ? ordered.ThenByDescending(o => o.TransactionDate) : query.OrderByDescending(o => o.TransactionDate);
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

        public static IQueryable<tbl_WMS_Transaction> _pagingBuilder(IQueryable<tbl_WMS_Transaction> query, Dictionary<string, string> QueryStrings)
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






