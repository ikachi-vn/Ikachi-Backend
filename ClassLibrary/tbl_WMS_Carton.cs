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
    
    
    public partial class tbl_WMS_Carton
    {
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
        public int IDCartonGroup { get; set; }
        public string CartonType { get; set; }
        public string ContainerType { get; set; }
        public int UseSequence { get; set; }
        public decimal Cube { get; set; }
        public int MaxCount { get; set; }
        public decimal MaxWeight { get; set; }
        public decimal TareWeight { get; set; }
        public decimal Length { get; set; }
        public decimal Width { get; set; }
        public decimal Height { get; set; }
        public string DefaultPalletCartonType { get; set; }
        public string DefaultNonPalletCartonType { get; set; }
        public bool DisplayForPicking { get; set; }
        public bool DisplayForPacking { get; set; }
        public bool DisplayForLoading { get; set; }
        //List 0:1
        public virtual tbl_WMS_CartonGroup tbl_WMS_CartonGroup { get; set; }
    }
}


namespace DTOModel
{
	using System;
	public partial class DTO_WMS_Carton
	{
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
		public int IDCartonGroup { get; set; }
		public string CartonType { get; set; }
		public string ContainerType { get; set; }
		public int UseSequence { get; set; }
		public decimal Cube { get; set; }
		public int MaxCount { get; set; }
		public decimal MaxWeight { get; set; }
		public decimal TareWeight { get; set; }
		public decimal Length { get; set; }
		public decimal Width { get; set; }
		public decimal Height { get; set; }
		public string DefaultPalletCartonType { get; set; }
		public string DefaultNonPalletCartonType { get; set; }
		public bool DisplayForPicking { get; set; }
		public bool DisplayForPacking { get; set; }
		public bool DisplayForLoading { get; set; }
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

    public static partial class BS_WMS_Carton 
    {
        public static dynamic getSearch(AppEntities db, int IDBranch, int StaffID, Dictionary<string, string> QueryStrings)
        {
            return get(db, IDBranch,StaffID, QueryStrings);
        }

		public static IQueryable<DTO_WMS_Carton> get(AppEntities db, int IDBranch, int StaffID, Dictionary<string, string> QueryStrings)
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
            package.Workbook.Properties.Title = "ART-DMS WMS_Carton";
            package.Workbook.Properties.Author = "hung.vu@codeart.vn";
            package.Workbook.Properties.Application = "ART-DMS";
            package.Workbook.Properties.Company = "A.R.T Distribution";

            ExcelWorkbook workBook = package.Workbook;
            if (workBook != null)
            {
                var ws = workBook.Worksheets.FirstOrDefault();
                var data = _queryBuilder(db, IDBranch, StaffID, QueryStrings).ToList();

                //var WMS_CartonGroupList = BS_WMS_CartonGroup.get(db,IDBranch, StaffID,QueryStrings).Select(s => new ItemModel { Id = s.Id, Name = s.Name });
                 

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

		public static DTO_WMS_Carton getAnItem(AppEntities db, int IDBranch, int StaffID, int id)
        {
            var dbResult = db.tbl_WMS_Carton.Find(id);

			return toDTO(dbResult);
			
        }
		
		public static DTO_WMS_Carton getAnItemByCode(AppEntities db, int IDBranch, int StaffID, string code)
        {
            var dbResult = db.tbl_WMS_Carton
			.FirstOrDefault(d => d.IsDeleted == false && d.Code == code );

			return toDTO(dbResult);
			
        }

		public static bool put(AppEntities db, int IDBranch, int StaffID, int Id, dynamic item, string Username, Dictionary<string, string> QueryStrings)
        {
            bool result = false;
            var dbitem = db.tbl_WMS_Carton.Find(Id);
            
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
					errorLog.logMessage("put_WMS_Carton",e);
                    result = false;
                }
            }
            else
                if (QueryStrings.Any(d => d.Key == "ForceCreate"))
                    result =  post(db, IDBranch, StaffID, item, Username) != null;
                
            return result;
        }

        public static void patchDynamicToDB(dynamic item, tbl_WMS_Carton dbitem, string Username)
        {
            Type type = typeof(tbl_WMS_Carton);
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

        public static void patchDTOtoDBValue( DTO_WMS_Carton item, tbl_WMS_Carton dbitem)
        {
            if (item == null){
                dbitem = null;
                return;
            }
            							
			dbitem.Code = item.Code;							
			dbitem.Name = item.Name;							
			dbitem.Remark = item.Remark;							
			dbitem.Sort = item.Sort;							
			dbitem.IsDisabled = item.IsDisabled;							
			dbitem.IsDeleted = item.IsDeleted;							
			dbitem.IDCartonGroup = item.IDCartonGroup;							
			dbitem.CartonType = item.CartonType;							
			dbitem.ContainerType = item.ContainerType;							
			dbitem.UseSequence = item.UseSequence;							
			dbitem.Cube = item.Cube;							
			dbitem.MaxCount = item.MaxCount;							
			dbitem.MaxWeight = item.MaxWeight;							
			dbitem.TareWeight = item.TareWeight;							
			dbitem.Length = item.Length;							
			dbitem.Width = item.Width;							
			dbitem.Height = item.Height;							
			dbitem.DefaultPalletCartonType = item.DefaultPalletCartonType;							
			dbitem.DefaultNonPalletCartonType = item.DefaultNonPalletCartonType;							
			dbitem.DisplayForPicking = item.DisplayForPicking;							
			dbitem.DisplayForPacking = item.DisplayForPacking;							
			dbitem.DisplayForLoading = item.DisplayForLoading;        }

		public static DTO_WMS_Carton post(AppEntities db, int IDBranch, int StaffID, dynamic item, string Username)
        {
            tbl_WMS_Carton dbitem = new tbl_WMS_Carton();
            if (item != null)
            {
                patchDynamicToDB(item, dbitem, Username);
                
				dbitem.CreatedBy = Username;
				dbitem.CreatedDate = DateTime.Now;				
                try
                {
					db.tbl_WMS_Carton.Add(dbitem);
                    db.SaveChanges();
				
                }
                catch (DbEntityValidationException e)
                {
					errorLog.logMessage("post_WMS_Carton",e);
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
                Type type = Type.GetType("BaseBusiness.BS_WMS_Carton, ClassLibrary");
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
                        var target = new tbl_WMS_Carton();
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
                    
                    tbl_WMS_Carton dbitem = new tbl_WMS_Carton();
                    if (it.Id == null || string.IsNullOrEmpty(it.Id.Value) || it.Id == "0")
                    {
                        dbitem = new tbl_WMS_Carton();
                        dbitem.CreatedBy = Username;
				        dbitem.CreatedDate = DateTime.Now;
                                            }
                    else
                    {
                        dbitem = db.tbl_WMS_Carton.Find((int)it.Id);
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
                        
                        if (dbitem.Id == 0) db.tbl_WMS_Carton.Add(dbitem);
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
                    errorLog.logMessage("post_WMS_Carton",e);
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

            var dbitems = db.tbl_WMS_Carton.Where(d => IDs.Contains(d.Id));
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
			
                BS_Version.update_Version(db, null, "DTO_WMS_Carton", updateDate, Username);
			
            }
            catch (DbEntityValidationException e)
            {
				errorLog.logMessage("delete_WMS_Carton",e);
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

			
            var dbitems = db.tbl_WMS_Carton.Where(d => IDs.Contains(d.Id));
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
			
                BS_Version.update_Version(db, null, "DTO_WMS_Carton", updateDate, Username);
			
            }
            catch (DbEntityValidationException e)
            {
				errorLog.logMessage("disable_WMS_Carton",e);
                result = false;
            }
            
            return result;
        }

		
		//---//
		public static bool check_Exists(AppEntities db, int id)
		{
             
            return db.tbl_WMS_Carton.Any(e => e.Id == id && e.IsDeleted == false);
            
		}
		
		public static bool check_Exists(AppEntities db, string Code)
		{
             
            return db.tbl_WMS_Carton.Any(e => e.Code == Code && e.IsDeleted == false);
            
		}
		
		//---//
		public static IQueryable<DTO_WMS_Carton> toDTO(IQueryable<tbl_WMS_Carton> query)
        {
			return query
			.Select(s => new DTO_WMS_Carton(){							
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
				IDCartonGroup = s.IDCartonGroup,							
				CartonType = s.CartonType,							
				ContainerType = s.ContainerType,							
				UseSequence = s.UseSequence,							
				Cube = s.Cube,							
				MaxCount = s.MaxCount,							
				MaxWeight = s.MaxWeight,							
				TareWeight = s.TareWeight,							
				Length = s.Length,							
				Width = s.Width,							
				Height = s.Height,							
				DefaultPalletCartonType = s.DefaultPalletCartonType,							
				DefaultNonPalletCartonType = s.DefaultNonPalletCartonType,							
				DisplayForPicking = s.DisplayForPicking,							
				DisplayForPacking = s.DisplayForPacking,							
				DisplayForLoading = s.DisplayForLoading,					
			});//.OrderBy(o => o.Sort == null).ThenBy(u => u.Sort);
                              
        }

		public static DTO_WMS_Carton toDTO(tbl_WMS_Carton dbResult)
        {
			if (dbResult != null)
			{
				return new DTO_WMS_Carton()
				{							
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
					IDCartonGroup = dbResult.IDCartonGroup,							
					CartonType = dbResult.CartonType,							
					ContainerType = dbResult.ContainerType,							
					UseSequence = dbResult.UseSequence,							
					Cube = dbResult.Cube,							
					MaxCount = dbResult.MaxCount,							
					MaxWeight = dbResult.MaxWeight,							
					TareWeight = dbResult.TareWeight,							
					Length = dbResult.Length,							
					Width = dbResult.Width,							
					Height = dbResult.Height,							
					DefaultPalletCartonType = dbResult.DefaultPalletCartonType,							
					DefaultNonPalletCartonType = dbResult.DefaultNonPalletCartonType,							
					DisplayForPicking = dbResult.DisplayForPicking,							
					DisplayForPacking = dbResult.DisplayForPacking,							
					DisplayForLoading = dbResult.DisplayForLoading,
				};
			}
			else
				return null; 
        }

		public static IQueryable<tbl_WMS_Carton> _queryBuilder(AppEntities db, int IDBranch, int StaffID, Dictionary<string, string> QueryStrings)
        {
            
			IQueryable<tbl_WMS_Carton> query = db.tbl_WMS_Carton.AsNoTracking();//.Where(d => d.IsDeleted == false );
			

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


			//Query IDCartonGroup (int)
			if (QueryStrings.Any(d => d.Key == "IDCartonGroup"))
            {
                var IDList = QueryStrings.FirstOrDefault(d => d.Key == "IDCartonGroup").Value.Replace("[", "").Replace("]", "").Split(',');
                List<int> IDs = new List<int>();
                foreach (var item in IDList)
                    if (int.TryParse(item, out int i))
                        IDs.Add(i);
                if (IDs.Count > 0)
                    query = query.Where(d => IDs.Contains(d.IDCartonGroup));
            }

			//Query CartonType (string)
			if (QueryStrings.Any(d => d.Key == "CartonType_eq") && !string.IsNullOrEmpty(QueryStrings.FirstOrDefault(d => d.Key == "CartonType_eq").Value))
            {
                var keyword = QueryStrings.FirstOrDefault(d => d.Key == "CartonType_eq").Value;
                query = query.Where(d=>d.CartonType == keyword);
            }
            if (QueryStrings.Any(d => d.Key == "CartonType") && !string.IsNullOrEmpty(QueryStrings.FirstOrDefault(d => d.Key == "CartonType").Value))
            {
                var keyword = QueryStrings.FirstOrDefault(d => d.Key == "CartonType").Value;
                query = query.Where(d=>d.CartonType.Contains(keyword));
            }
            

			//Query ContainerType (string)
			if (QueryStrings.Any(d => d.Key == "ContainerType_eq") && !string.IsNullOrEmpty(QueryStrings.FirstOrDefault(d => d.Key == "ContainerType_eq").Value))
            {
                var keyword = QueryStrings.FirstOrDefault(d => d.Key == "ContainerType_eq").Value;
                query = query.Where(d=>d.ContainerType == keyword);
            }
            if (QueryStrings.Any(d => d.Key == "ContainerType") && !string.IsNullOrEmpty(QueryStrings.FirstOrDefault(d => d.Key == "ContainerType").Value))
            {
                var keyword = QueryStrings.FirstOrDefault(d => d.Key == "ContainerType").Value;
                query = query.Where(d=>d.ContainerType.Contains(keyword));
            }
            

			//Query UseSequence (int)
			if (QueryStrings.Any(d => d.Key == "UseSequenceFrom") && QueryStrings.Any(d => d.Key == "UseSequenceTo"))
                if (int.TryParse(QueryStrings.FirstOrDefault(d => d.Key == "UseSequenceFrom").Value, out int fromVal) && int.TryParse(QueryStrings.FirstOrDefault(d => d.Key == "UseSequenceTo").Value, out int toVal))
                    query = query.Where(d => fromVal <= d.UseSequence && d.UseSequence <= toVal);
            
            if (QueryStrings.Any(d => d.Key == "UseSequence"))
                if (int.TryParse(QueryStrings.FirstOrDefault(d => d.Key == "UseSequence").Value, out int val))
                    query = query.Where(d => val == d.UseSequence);


			//Query Cube (decimal)
			if (QueryStrings.Any(d => d.Key == "CubeFrom") && QueryStrings.Any(d => d.Key == "CubeTo"))
                if (decimal.TryParse(QueryStrings.FirstOrDefault(d => d.Key == "CubeFrom").Value, out decimal fromVal) && decimal.TryParse(QueryStrings.FirstOrDefault(d => d.Key == "CubeTo").Value, out decimal toVal))
                    query = query.Where(d => fromVal <= d.Cube && d.Cube <= toVal);
            
            if (QueryStrings.Any(d => d.Key == "Cube"))
                if (decimal.TryParse(QueryStrings.FirstOrDefault(d => d.Key == "Cube").Value, out decimal val))
                    query = query.Where(d => val == d.Cube);


			//Query MaxCount (int)
			if (QueryStrings.Any(d => d.Key == "MaxCountFrom") && QueryStrings.Any(d => d.Key == "MaxCountTo"))
                if (int.TryParse(QueryStrings.FirstOrDefault(d => d.Key == "MaxCountFrom").Value, out int fromVal) && int.TryParse(QueryStrings.FirstOrDefault(d => d.Key == "MaxCountTo").Value, out int toVal))
                    query = query.Where(d => fromVal <= d.MaxCount && d.MaxCount <= toVal);
            
            if (QueryStrings.Any(d => d.Key == "MaxCount"))
                if (int.TryParse(QueryStrings.FirstOrDefault(d => d.Key == "MaxCount").Value, out int val))
                    query = query.Where(d => val == d.MaxCount);


			//Query MaxWeight (decimal)
			if (QueryStrings.Any(d => d.Key == "MaxWeightFrom") && QueryStrings.Any(d => d.Key == "MaxWeightTo"))
                if (decimal.TryParse(QueryStrings.FirstOrDefault(d => d.Key == "MaxWeightFrom").Value, out decimal fromVal) && decimal.TryParse(QueryStrings.FirstOrDefault(d => d.Key == "MaxWeightTo").Value, out decimal toVal))
                    query = query.Where(d => fromVal <= d.MaxWeight && d.MaxWeight <= toVal);
            
            if (QueryStrings.Any(d => d.Key == "MaxWeight"))
                if (decimal.TryParse(QueryStrings.FirstOrDefault(d => d.Key == "MaxWeight").Value, out decimal val))
                    query = query.Where(d => val == d.MaxWeight);


			//Query TareWeight (decimal)
			if (QueryStrings.Any(d => d.Key == "TareWeightFrom") && QueryStrings.Any(d => d.Key == "TareWeightTo"))
                if (decimal.TryParse(QueryStrings.FirstOrDefault(d => d.Key == "TareWeightFrom").Value, out decimal fromVal) && decimal.TryParse(QueryStrings.FirstOrDefault(d => d.Key == "TareWeightTo").Value, out decimal toVal))
                    query = query.Where(d => fromVal <= d.TareWeight && d.TareWeight <= toVal);
            
            if (QueryStrings.Any(d => d.Key == "TareWeight"))
                if (decimal.TryParse(QueryStrings.FirstOrDefault(d => d.Key == "TareWeight").Value, out decimal val))
                    query = query.Where(d => val == d.TareWeight);


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


			//Query DefaultPalletCartonType (string)
			if (QueryStrings.Any(d => d.Key == "DefaultPalletCartonType_eq") && !string.IsNullOrEmpty(QueryStrings.FirstOrDefault(d => d.Key == "DefaultPalletCartonType_eq").Value))
            {
                var keyword = QueryStrings.FirstOrDefault(d => d.Key == "DefaultPalletCartonType_eq").Value;
                query = query.Where(d=>d.DefaultPalletCartonType == keyword);
            }
            if (QueryStrings.Any(d => d.Key == "DefaultPalletCartonType") && !string.IsNullOrEmpty(QueryStrings.FirstOrDefault(d => d.Key == "DefaultPalletCartonType").Value))
            {
                var keyword = QueryStrings.FirstOrDefault(d => d.Key == "DefaultPalletCartonType").Value;
                query = query.Where(d=>d.DefaultPalletCartonType.Contains(keyword));
            }
            

			//Query DefaultNonPalletCartonType (string)
			if (QueryStrings.Any(d => d.Key == "DefaultNonPalletCartonType_eq") && !string.IsNullOrEmpty(QueryStrings.FirstOrDefault(d => d.Key == "DefaultNonPalletCartonType_eq").Value))
            {
                var keyword = QueryStrings.FirstOrDefault(d => d.Key == "DefaultNonPalletCartonType_eq").Value;
                query = query.Where(d=>d.DefaultNonPalletCartonType == keyword);
            }
            if (QueryStrings.Any(d => d.Key == "DefaultNonPalletCartonType") && !string.IsNullOrEmpty(QueryStrings.FirstOrDefault(d => d.Key == "DefaultNonPalletCartonType").Value))
            {
                var keyword = QueryStrings.FirstOrDefault(d => d.Key == "DefaultNonPalletCartonType").Value;
                query = query.Where(d=>d.DefaultNonPalletCartonType.Contains(keyword));
            }
            

			//Query DisplayForPicking (bool)
			if (QueryStrings.Any(d => d.Key == "DisplayForPicking"))
            {
                var qValue = QueryStrings.FirstOrDefault(d => d.Key == "DisplayForPicking").Value;
                if (bool.TryParse(qValue, out bool qBoolValue))
                    query = query.Where(d => qBoolValue == d.DisplayForPicking);
            }

			//Query DisplayForPacking (bool)
			if (QueryStrings.Any(d => d.Key == "DisplayForPacking"))
            {
                var qValue = QueryStrings.FirstOrDefault(d => d.Key == "DisplayForPacking").Value;
                if (bool.TryParse(qValue, out bool qBoolValue))
                    query = query.Where(d => qBoolValue == d.DisplayForPacking);
            }

			//Query DisplayForLoading (bool)
			if (QueryStrings.Any(d => d.Key == "DisplayForLoading"))
            {
                var qValue = QueryStrings.FirstOrDefault(d => d.Key == "DisplayForLoading").Value;
                if (bool.TryParse(qValue, out bool qBoolValue))
                    query = query.Where(d => qBoolValue == d.DisplayForLoading);
            }
            return query;
        }
		
        public static IQueryable<tbl_WMS_Carton> _sortBuilder(IQueryable<tbl_WMS_Carton> query, Dictionary<string, string> QueryStrings)
        {
            if (QueryStrings.Any(d => d.Key == "SortBy"))
            {
                var sorts = QueryStrings.FirstOrDefault(d => d.Key == "SortBy").Value.Replace("[", "").Replace("]", "").Split(',');
                
                foreach (var item in sorts)
                    if (!string.IsNullOrEmpty(item))
                    {
                        var ordered = query as IOrderedQueryable<tbl_WMS_Carton>;
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
							case "IDCartonGroup":
								query = isOrdered ? ordered.ThenBy(o => o.IDCartonGroup) : query.OrderBy(o => o.IDCartonGroup);
								 break;
							case "IDCartonGroup_desc":
                                query = isOrdered ? ordered.ThenByDescending(o => o.IDCartonGroup) : query.OrderByDescending(o => o.IDCartonGroup);
                                break;
							case "CartonType":
								query = isOrdered ? ordered.ThenBy(o => o.CartonType) : query.OrderBy(o => o.CartonType);
								 break;
							case "CartonType_desc":
                                query = isOrdered ? ordered.ThenByDescending(o => o.CartonType) : query.OrderByDescending(o => o.CartonType);
                                break;
							case "ContainerType":
								query = isOrdered ? ordered.ThenBy(o => o.ContainerType) : query.OrderBy(o => o.ContainerType);
								 break;
							case "ContainerType_desc":
                                query = isOrdered ? ordered.ThenByDescending(o => o.ContainerType) : query.OrderByDescending(o => o.ContainerType);
                                break;
							case "UseSequence":
								query = isOrdered ? ordered.ThenBy(o => o.UseSequence) : query.OrderBy(o => o.UseSequence);
								 break;
							case "UseSequence_desc":
                                query = isOrdered ? ordered.ThenByDescending(o => o.UseSequence) : query.OrderByDescending(o => o.UseSequence);
                                break;
							case "Cube":
								query = isOrdered ? ordered.ThenBy(o => o.Cube) : query.OrderBy(o => o.Cube);
								 break;
							case "Cube_desc":
                                query = isOrdered ? ordered.ThenByDescending(o => o.Cube) : query.OrderByDescending(o => o.Cube);
                                break;
							case "MaxCount":
								query = isOrdered ? ordered.ThenBy(o => o.MaxCount) : query.OrderBy(o => o.MaxCount);
								 break;
							case "MaxCount_desc":
                                query = isOrdered ? ordered.ThenByDescending(o => o.MaxCount) : query.OrderByDescending(o => o.MaxCount);
                                break;
							case "MaxWeight":
								query = isOrdered ? ordered.ThenBy(o => o.MaxWeight) : query.OrderBy(o => o.MaxWeight);
								 break;
							case "MaxWeight_desc":
                                query = isOrdered ? ordered.ThenByDescending(o => o.MaxWeight) : query.OrderByDescending(o => o.MaxWeight);
                                break;
							case "TareWeight":
								query = isOrdered ? ordered.ThenBy(o => o.TareWeight) : query.OrderBy(o => o.TareWeight);
								 break;
							case "TareWeight_desc":
                                query = isOrdered ? ordered.ThenByDescending(o => o.TareWeight) : query.OrderByDescending(o => o.TareWeight);
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
							case "DefaultPalletCartonType":
								query = isOrdered ? ordered.ThenBy(o => o.DefaultPalletCartonType) : query.OrderBy(o => o.DefaultPalletCartonType);
								 break;
							case "DefaultPalletCartonType_desc":
                                query = isOrdered ? ordered.ThenByDescending(o => o.DefaultPalletCartonType) : query.OrderByDescending(o => o.DefaultPalletCartonType);
                                break;
							case "DefaultNonPalletCartonType":
								query = isOrdered ? ordered.ThenBy(o => o.DefaultNonPalletCartonType) : query.OrderBy(o => o.DefaultNonPalletCartonType);
								 break;
							case "DefaultNonPalletCartonType_desc":
                                query = isOrdered ? ordered.ThenByDescending(o => o.DefaultNonPalletCartonType) : query.OrderByDescending(o => o.DefaultNonPalletCartonType);
                                break;
							case "DisplayForPicking":
								query = isOrdered ? ordered.ThenBy(o => o.DisplayForPicking) : query.OrderBy(o => o.DisplayForPicking);
								 break;
							case "DisplayForPicking_desc":
                                query = isOrdered ? ordered.ThenByDescending(o => o.DisplayForPicking) : query.OrderByDescending(o => o.DisplayForPicking);
                                break;
							case "DisplayForPacking":
								query = isOrdered ? ordered.ThenBy(o => o.DisplayForPacking) : query.OrderBy(o => o.DisplayForPacking);
								 break;
							case "DisplayForPacking_desc":
                                query = isOrdered ? ordered.ThenByDescending(o => o.DisplayForPacking) : query.OrderByDescending(o => o.DisplayForPacking);
                                break;
							case "DisplayForLoading":
								query = isOrdered ? ordered.ThenBy(o => o.DisplayForLoading) : query.OrderBy(o => o.DisplayForLoading);
								 break;
							case "DisplayForLoading_desc":
                                query = isOrdered ? ordered.ThenByDescending(o => o.DisplayForLoading) : query.OrderByDescending(o => o.DisplayForLoading);
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

        public static IQueryable<tbl_WMS_Carton> _pagingBuilder(IQueryable<tbl_WMS_Carton> query, Dictionary<string, string> QueryStrings)
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






