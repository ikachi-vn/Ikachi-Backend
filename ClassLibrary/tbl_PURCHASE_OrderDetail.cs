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
    
    
    public partial class tbl_PURCHASE_OrderDetail
    {
        public int IDOrder { get; set; }
        public int Id { get; set; }
        public string Code { get; set; }
        public string Remark { get; set; }
        public string ForeignRemark { get; set; }
        public int IDItem { get; set; }
        public int IDUoM { get; set; }
        public int IDBaseUoM { get; set; }
        public int UoMSwap { get; set; }
        public int UoMSwapAlter { get; set; }
        public decimal UoMQuantityExpected { get; set; }
        public decimal QuantityExpected { get; set; }
        public decimal QuantityAdjusted { get; set; }
        public decimal QuantityReceived { get; set; }
        public decimal QuantityRejected { get; set; }
        public decimal UoMPrice { get; set; }
        public bool IsPromotionItem { get; set; }
        public Nullable<int> IDTax { get; set; }
        public decimal TaxRate { get; set; }
        public decimal TotalBeforeDiscount { get; set; }
        public decimal TotalDiscount { get; set; }
        public decimal TotalAfterDiscount { get; set; }
        public decimal Tax { get; set; }
        public decimal TotalAfterTax { get; set; }
        public bool IsDeleted { get; set; }
        public string CreatedBy { get; set; }
        public string ModifiedBy { get; set; }
        public System.DateTime CreatedDate { get; set; }
        public System.DateTime ModifiedDate { get; set; }
        //List 0:1
        public virtual tbl_PURCHASE_Order tbl_PURCHASE_Order { get; set; }
        //List 0:1
        public virtual tbl_WMS_Item tbl_WMS_Item { get; set; }
    }
}


namespace DTOModel
{
	using System;
	public partial class DTO_PURCHASE_OrderDetail
	{
		public int IDOrder { get; set; }
		public int Id { get; set; }
		public string Code { get; set; }
		public string Remark { get; set; }
		public string ForeignRemark { get; set; }
		public int IDItem { get; set; }
		public int IDUoM { get; set; }
		public int IDBaseUoM { get; set; }
		public int UoMSwap { get; set; }
		public int UoMSwapAlter { get; set; }
		public decimal UoMQuantityExpected { get; set; }
		public decimal QuantityExpected { get; set; }
		public decimal QuantityAdjusted { get; set; }
		public decimal QuantityReceived { get; set; }
		public decimal QuantityRejected { get; set; }
		public decimal UoMPrice { get; set; }
		public bool IsPromotionItem { get; set; }
		public Nullable<int> IDTax { get; set; }
		public decimal TaxRate { get; set; }
		public decimal TotalBeforeDiscount { get; set; }
		public decimal TotalDiscount { get; set; }
		public decimal TotalAfterDiscount { get; set; }
		public decimal Tax { get; set; }
		public decimal TotalAfterTax { get; set; }
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

    public static partial class BS_PURCHASE_OrderDetail 
    {
        public static dynamic getSearch(AppEntities db, int IDBranch, int StaffID, Dictionary<string, string> QueryStrings)
        {
            return get(db, IDBranch,StaffID, QueryStrings);
        }

		public static IQueryable<DTO_PURCHASE_OrderDetail> get(AppEntities db, int IDBranch, int StaffID, Dictionary<string, string> QueryStrings)
        {
			var query = _queryBuilder(db, IDBranch, StaffID, QueryStrings);
            query = _sortBuilder(query, QueryStrings);
            query = _pagingBuilder(query, QueryStrings);

			return toDTO(query);
        }

        public static List<ItemModel> getValidateData(AppEntities db, int IDBranch, int StaffID, Dictionary<string, string> QueryStrings)
        {
            return get(db, IDBranch, StaffID, QueryStrings).Select(s => new ItemModel { 
                Id = s.Id,  Code = s.Code, }).ToList();
        }

        public static string export(ExcelPackage package, AppEntities db, int IDBranch, int StaffID, Dictionary<string, string> QueryStrings)
        {
            package.Workbook.Properties.Title = "ART-DMS PURCHASE_OrderDetail";
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

		public static DTO_PURCHASE_OrderDetail getAnItem(AppEntities db, int IDBranch, int StaffID, int id)
        {
            var dbResult = db.tbl_PURCHASE_OrderDetail.Find(id);

			return toDTO(dbResult);
			
        }
		
		public static DTO_PURCHASE_OrderDetail getAnItemByCode(AppEntities db, int IDBranch, int StaffID, string code)
        {
            var dbResult = db.tbl_PURCHASE_OrderDetail
			.FirstOrDefault(d => d.IsDeleted == false && d.Code == code );

			return toDTO(dbResult);
			
        }

		public static bool put(AppEntities db, int IDBranch, int StaffID, int Id, dynamic item, string Username, Dictionary<string, string> QueryStrings)
        {
            bool result = false;
            var dbitem = db.tbl_PURCHASE_OrderDetail.Find(Id);
            
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
					errorLog.logMessage("put_PURCHASE_OrderDetail",e);
                    result = false;
                }
            }
            else
                if (QueryStrings.Any(d => d.Key == "ForceCreate"))
                    result =  post(db, IDBranch, StaffID, item, Username) != null;
                
            return result;
        }

        public static void patchDynamicToDB(dynamic item, tbl_PURCHASE_OrderDetail dbitem, string Username)
        {
            Type type = typeof(tbl_PURCHASE_OrderDetail);
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

        public static void patchDTOtoDBValue( DTO_PURCHASE_OrderDetail item, tbl_PURCHASE_OrderDetail dbitem)
        {
            if (item == null){
                dbitem = null;
                return;
            }
            							
			dbitem.IDOrder = item.IDOrder;							
			dbitem.Code = item.Code;							
			dbitem.Remark = item.Remark;							
			dbitem.ForeignRemark = item.ForeignRemark;							
			dbitem.IDItem = item.IDItem;							
			dbitem.IDUoM = item.IDUoM;							
			dbitem.IDBaseUoM = item.IDBaseUoM;							
			dbitem.UoMSwap = item.UoMSwap;							
			dbitem.UoMSwapAlter = item.UoMSwapAlter;							
			dbitem.UoMQuantityExpected = item.UoMQuantityExpected;							
			dbitem.QuantityExpected = item.QuantityExpected;							
			dbitem.QuantityAdjusted = item.QuantityAdjusted;							
			dbitem.QuantityReceived = item.QuantityReceived;							
			dbitem.QuantityRejected = item.QuantityRejected;							
			dbitem.UoMPrice = item.UoMPrice;							
			dbitem.IsPromotionItem = item.IsPromotionItem;							
			dbitem.IDTax = item.IDTax;							
			dbitem.TaxRate = item.TaxRate;							
			dbitem.TotalBeforeDiscount = item.TotalBeforeDiscount;							
			dbitem.TotalDiscount = item.TotalDiscount;							
			dbitem.TotalAfterDiscount = item.TotalAfterDiscount;							
			dbitem.Tax = item.Tax;							
			dbitem.TotalAfterTax = item.TotalAfterTax;							
			dbitem.IsDeleted = item.IsDeleted;        }

		public static DTO_PURCHASE_OrderDetail post(AppEntities db, int IDBranch, int StaffID, dynamic item, string Username)
        {
            tbl_PURCHASE_OrderDetail dbitem = new tbl_PURCHASE_OrderDetail();
            if (item != null)
            {
                patchDynamicToDB(item, dbitem, Username);
                
				dbitem.CreatedBy = Username;
				dbitem.CreatedDate = DateTime.Now;				
                try
                {
					db.tbl_PURCHASE_OrderDetail.Add(dbitem);
                    db.SaveChanges();
				
                }
                catch (DbEntityValidationException e)
                {
					errorLog.logMessage("post_PURCHASE_OrderDetail",e);
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
                Type type = Type.GetType("BaseBusiness.BS_PURCHASE_OrderDetail, ClassLibrary");
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
                        var target = new tbl_PURCHASE_OrderDetail();
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
                    
                    tbl_PURCHASE_OrderDetail dbitem = new tbl_PURCHASE_OrderDetail();
                    if (it.Id == null || string.IsNullOrEmpty(it.Id.Value) || it.Id == "0")
                    {
                        dbitem = new tbl_PURCHASE_OrderDetail();
                        dbitem.CreatedBy = Username;
				        dbitem.CreatedDate = DateTime.Now;
                                            }
                    else
                    {
                        dbitem = db.tbl_PURCHASE_OrderDetail.Find((int)it.Id);
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
                        
                        if (dbitem.Id == 0) db.tbl_PURCHASE_OrderDetail.Add(dbitem);
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
                    errorLog.logMessage("post_PURCHASE_OrderDetail",e);
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

            var dbitems = db.tbl_PURCHASE_OrderDetail.Where(d => IDs.Contains(d.Id));
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
			
                BS_Version.update_Version(db, null, "DTO_PURCHASE_OrderDetail", updateDate, Username);
			
            }
            catch (DbEntityValidationException e)
            {
				errorLog.logMessage("delete_PURCHASE_OrderDetail",e);
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
             
            return db.tbl_PURCHASE_OrderDetail.Any(e => e.Id == id && e.IsDeleted == false);
            
		}
		
		public static bool check_Exists(AppEntities db, string Code)
		{
             
            return db.tbl_PURCHASE_OrderDetail.Any(e => e.Code == Code && e.IsDeleted == false);
            
		}
		
		//---//
		public static IQueryable<DTO_PURCHASE_OrderDetail> toDTO(IQueryable<tbl_PURCHASE_OrderDetail> query)
        {
			return query
			.Select(s => new DTO_PURCHASE_OrderDetail(){							
				IDOrder = s.IDOrder,							
				Id = s.Id,							
				Code = s.Code,							
				Remark = s.Remark,							
				ForeignRemark = s.ForeignRemark,							
				IDItem = s.IDItem,							
				IDUoM = s.IDUoM,							
				IDBaseUoM = s.IDBaseUoM,							
				UoMSwap = s.UoMSwap,							
				UoMSwapAlter = s.UoMSwapAlter,							
				UoMQuantityExpected = s.UoMQuantityExpected,							
				QuantityExpected = s.QuantityExpected,							
				QuantityAdjusted = s.QuantityAdjusted,							
				QuantityReceived = s.QuantityReceived,							
				QuantityRejected = s.QuantityRejected,							
				UoMPrice = s.UoMPrice,							
				IsPromotionItem = s.IsPromotionItem,							
				IDTax = s.IDTax,							
				TaxRate = s.TaxRate,							
				TotalBeforeDiscount = s.TotalBeforeDiscount,							
				TotalDiscount = s.TotalDiscount,							
				TotalAfterDiscount = s.TotalAfterDiscount,							
				Tax = s.Tax,							
				TotalAfterTax = s.TotalAfterTax,							
				IsDeleted = s.IsDeleted,							
				CreatedBy = s.CreatedBy,							
				ModifiedBy = s.ModifiedBy,							
				CreatedDate = s.CreatedDate,							
				ModifiedDate = s.ModifiedDate,					
			});//;
                              
        }

		public static DTO_PURCHASE_OrderDetail toDTO(tbl_PURCHASE_OrderDetail dbResult)
        {
			if (dbResult != null)
			{
				return new DTO_PURCHASE_OrderDetail()
				{							
					IDOrder = dbResult.IDOrder,							
					Id = dbResult.Id,							
					Code = dbResult.Code,							
					Remark = dbResult.Remark,							
					ForeignRemark = dbResult.ForeignRemark,							
					IDItem = dbResult.IDItem,							
					IDUoM = dbResult.IDUoM,							
					IDBaseUoM = dbResult.IDBaseUoM,							
					UoMSwap = dbResult.UoMSwap,							
					UoMSwapAlter = dbResult.UoMSwapAlter,							
					UoMQuantityExpected = dbResult.UoMQuantityExpected,							
					QuantityExpected = dbResult.QuantityExpected,							
					QuantityAdjusted = dbResult.QuantityAdjusted,							
					QuantityReceived = dbResult.QuantityReceived,							
					QuantityRejected = dbResult.QuantityRejected,							
					UoMPrice = dbResult.UoMPrice,							
					IsPromotionItem = dbResult.IsPromotionItem,							
					IDTax = dbResult.IDTax,							
					TaxRate = dbResult.TaxRate,							
					TotalBeforeDiscount = dbResult.TotalBeforeDiscount,							
					TotalDiscount = dbResult.TotalDiscount,							
					TotalAfterDiscount = dbResult.TotalAfterDiscount,							
					Tax = dbResult.Tax,							
					TotalAfterTax = dbResult.TotalAfterTax,							
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

		public static IQueryable<tbl_PURCHASE_OrderDetail> _queryBuilder(AppEntities db, int IDBranch, int StaffID, Dictionary<string, string> QueryStrings)
        {
            
			IQueryable<tbl_PURCHASE_OrderDetail> query = db.tbl_PURCHASE_OrderDetail.AsNoTracking();//.Where(d => d.IsDeleted == false );
			

			//Query keyword
			if (QueryStrings.Any(d => d.Key == "Keyword") && !string.IsNullOrEmpty(QueryStrings.FirstOrDefault(d => d.Key == "Keyword").Value))
            {
                var keyword = QueryStrings.FirstOrDefault(d => d.Key == "Keyword").Value;
                query = query.Where(d=>d.Code.Contains(keyword));
            }



			//Query IDOrder (int)
			if (QueryStrings.Any(d => d.Key == "IDOrder"))
            {
                var IDList = QueryStrings.FirstOrDefault(d => d.Key == "IDOrder").Value.Replace("[", "").Replace("]", "").Split(',');
                List<int> IDs = new List<int>();
                foreach (var item in IDList)
                    if (int.TryParse(item, out int i))
                        IDs.Add(i);
                if (IDs.Count > 0)
                    query = query.Where(d => IDs.Contains(d.IDOrder));
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

			//Query IDBaseUoM (int)
			if (QueryStrings.Any(d => d.Key == "IDBaseUoM"))
            {
                var IDList = QueryStrings.FirstOrDefault(d => d.Key == "IDBaseUoM").Value.Replace("[", "").Replace("]", "").Split(',');
                List<int> IDs = new List<int>();
                foreach (var item in IDList)
                    if (int.TryParse(item, out int i))
                        IDs.Add(i);
                if (IDs.Count > 0)
                    query = query.Where(d => IDs.Contains(d.IDBaseUoM));
            }

			//Query UoMSwap (int)
			if (QueryStrings.Any(d => d.Key == "UoMSwapFrom") && QueryStrings.Any(d => d.Key == "UoMSwapTo"))
                if (int.TryParse(QueryStrings.FirstOrDefault(d => d.Key == "UoMSwapFrom").Value, out int fromVal) && int.TryParse(QueryStrings.FirstOrDefault(d => d.Key == "UoMSwapTo").Value, out int toVal))
                    query = query.Where(d => fromVal <= d.UoMSwap && d.UoMSwap <= toVal);
            
            if (QueryStrings.Any(d => d.Key == "UoMSwap"))
                if (int.TryParse(QueryStrings.FirstOrDefault(d => d.Key == "UoMSwap").Value, out int val))
                    query = query.Where(d => val == d.UoMSwap);


			//Query UoMSwapAlter (int)
			if (QueryStrings.Any(d => d.Key == "UoMSwapAlterFrom") && QueryStrings.Any(d => d.Key == "UoMSwapAlterTo"))
                if (int.TryParse(QueryStrings.FirstOrDefault(d => d.Key == "UoMSwapAlterFrom").Value, out int fromVal) && int.TryParse(QueryStrings.FirstOrDefault(d => d.Key == "UoMSwapAlterTo").Value, out int toVal))
                    query = query.Where(d => fromVal <= d.UoMSwapAlter && d.UoMSwapAlter <= toVal);
            
            if (QueryStrings.Any(d => d.Key == "UoMSwapAlter"))
                if (int.TryParse(QueryStrings.FirstOrDefault(d => d.Key == "UoMSwapAlter").Value, out int val))
                    query = query.Where(d => val == d.UoMSwapAlter);


			//Query UoMQuantityExpected (decimal)
			if (QueryStrings.Any(d => d.Key == "UoMQuantityExpectedFrom") && QueryStrings.Any(d => d.Key == "UoMQuantityExpectedTo"))
                if (decimal.TryParse(QueryStrings.FirstOrDefault(d => d.Key == "UoMQuantityExpectedFrom").Value, out decimal fromVal) && decimal.TryParse(QueryStrings.FirstOrDefault(d => d.Key == "UoMQuantityExpectedTo").Value, out decimal toVal))
                    query = query.Where(d => fromVal <= d.UoMQuantityExpected && d.UoMQuantityExpected <= toVal);
            
            if (QueryStrings.Any(d => d.Key == "UoMQuantityExpected"))
                if (decimal.TryParse(QueryStrings.FirstOrDefault(d => d.Key == "UoMQuantityExpected").Value, out decimal val))
                    query = query.Where(d => val == d.UoMQuantityExpected);


			//Query QuantityExpected (decimal)
			if (QueryStrings.Any(d => d.Key == "QuantityExpectedFrom") && QueryStrings.Any(d => d.Key == "QuantityExpectedTo"))
                if (decimal.TryParse(QueryStrings.FirstOrDefault(d => d.Key == "QuantityExpectedFrom").Value, out decimal fromVal) && decimal.TryParse(QueryStrings.FirstOrDefault(d => d.Key == "QuantityExpectedTo").Value, out decimal toVal))
                    query = query.Where(d => fromVal <= d.QuantityExpected && d.QuantityExpected <= toVal);
            
            if (QueryStrings.Any(d => d.Key == "QuantityExpected"))
                if (decimal.TryParse(QueryStrings.FirstOrDefault(d => d.Key == "QuantityExpected").Value, out decimal val))
                    query = query.Where(d => val == d.QuantityExpected);


			//Query QuantityAdjusted (decimal)
			if (QueryStrings.Any(d => d.Key == "QuantityAdjustedFrom") && QueryStrings.Any(d => d.Key == "QuantityAdjustedTo"))
                if (decimal.TryParse(QueryStrings.FirstOrDefault(d => d.Key == "QuantityAdjustedFrom").Value, out decimal fromVal) && decimal.TryParse(QueryStrings.FirstOrDefault(d => d.Key == "QuantityAdjustedTo").Value, out decimal toVal))
                    query = query.Where(d => fromVal <= d.QuantityAdjusted && d.QuantityAdjusted <= toVal);
            
            if (QueryStrings.Any(d => d.Key == "QuantityAdjusted"))
                if (decimal.TryParse(QueryStrings.FirstOrDefault(d => d.Key == "QuantityAdjusted").Value, out decimal val))
                    query = query.Where(d => val == d.QuantityAdjusted);


			//Query QuantityReceived (decimal)
			if (QueryStrings.Any(d => d.Key == "QuantityReceivedFrom") && QueryStrings.Any(d => d.Key == "QuantityReceivedTo"))
                if (decimal.TryParse(QueryStrings.FirstOrDefault(d => d.Key == "QuantityReceivedFrom").Value, out decimal fromVal) && decimal.TryParse(QueryStrings.FirstOrDefault(d => d.Key == "QuantityReceivedTo").Value, out decimal toVal))
                    query = query.Where(d => fromVal <= d.QuantityReceived && d.QuantityReceived <= toVal);
            
            if (QueryStrings.Any(d => d.Key == "QuantityReceived"))
                if (decimal.TryParse(QueryStrings.FirstOrDefault(d => d.Key == "QuantityReceived").Value, out decimal val))
                    query = query.Where(d => val == d.QuantityReceived);


			//Query QuantityRejected (decimal)
			if (QueryStrings.Any(d => d.Key == "QuantityRejectedFrom") && QueryStrings.Any(d => d.Key == "QuantityRejectedTo"))
                if (decimal.TryParse(QueryStrings.FirstOrDefault(d => d.Key == "QuantityRejectedFrom").Value, out decimal fromVal) && decimal.TryParse(QueryStrings.FirstOrDefault(d => d.Key == "QuantityRejectedTo").Value, out decimal toVal))
                    query = query.Where(d => fromVal <= d.QuantityRejected && d.QuantityRejected <= toVal);
            
            if (QueryStrings.Any(d => d.Key == "QuantityRejected"))
                if (decimal.TryParse(QueryStrings.FirstOrDefault(d => d.Key == "QuantityRejected").Value, out decimal val))
                    query = query.Where(d => val == d.QuantityRejected);


			//Query UoMPrice (decimal)
			if (QueryStrings.Any(d => d.Key == "UoMPriceFrom") && QueryStrings.Any(d => d.Key == "UoMPriceTo"))
                if (decimal.TryParse(QueryStrings.FirstOrDefault(d => d.Key == "UoMPriceFrom").Value, out decimal fromVal) && decimal.TryParse(QueryStrings.FirstOrDefault(d => d.Key == "UoMPriceTo").Value, out decimal toVal))
                    query = query.Where(d => fromVal <= d.UoMPrice && d.UoMPrice <= toVal);
            
            if (QueryStrings.Any(d => d.Key == "UoMPrice"))
                if (decimal.TryParse(QueryStrings.FirstOrDefault(d => d.Key == "UoMPrice").Value, out decimal val))
                    query = query.Where(d => val == d.UoMPrice);


			//Query IsPromotionItem (bool)
			if (QueryStrings.Any(d => d.Key == "IsPromotionItem"))
            {
                var qValue = QueryStrings.FirstOrDefault(d => d.Key == "IsPromotionItem").Value;
                if (bool.TryParse(qValue, out bool qBoolValue))
                    query = query.Where(d => qBoolValue == d.IsPromotionItem);
            }

			//Query IDTax (Nullable<int>)
			if (QueryStrings.Any(d => d.Key == "IDTax"))
            {
                var IDList = QueryStrings.FirstOrDefault(d => d.Key == "IDTax").Value.Replace("[", "").Replace("]", "").Split(',');
                List<int?> IDs = new List<int?>();
                foreach (var item in IDList)
                    if (int.TryParse(item, out int i))
                        IDs.Add(i);
					else if (item == "null")
						IDs.Add(null);
                if (IDs.Count > 0)
                    query = query.Where(d => IDs.Contains(d.IDTax));
////                    query = query.Where(d => IDs.Contains(d.IDTax));
//                    
            }

			//Query TaxRate (decimal)
			if (QueryStrings.Any(d => d.Key == "TaxRateFrom") && QueryStrings.Any(d => d.Key == "TaxRateTo"))
                if (decimal.TryParse(QueryStrings.FirstOrDefault(d => d.Key == "TaxRateFrom").Value, out decimal fromVal) && decimal.TryParse(QueryStrings.FirstOrDefault(d => d.Key == "TaxRateTo").Value, out decimal toVal))
                    query = query.Where(d => fromVal <= d.TaxRate && d.TaxRate <= toVal);
            
            if (QueryStrings.Any(d => d.Key == "TaxRate"))
                if (decimal.TryParse(QueryStrings.FirstOrDefault(d => d.Key == "TaxRate").Value, out decimal val))
                    query = query.Where(d => val == d.TaxRate);


			//Query TotalBeforeDiscount (decimal)
			if (QueryStrings.Any(d => d.Key == "TotalBeforeDiscountFrom") && QueryStrings.Any(d => d.Key == "TotalBeforeDiscountTo"))
                if (decimal.TryParse(QueryStrings.FirstOrDefault(d => d.Key == "TotalBeforeDiscountFrom").Value, out decimal fromVal) && decimal.TryParse(QueryStrings.FirstOrDefault(d => d.Key == "TotalBeforeDiscountTo").Value, out decimal toVal))
                    query = query.Where(d => fromVal <= d.TotalBeforeDiscount && d.TotalBeforeDiscount <= toVal);
            
            if (QueryStrings.Any(d => d.Key == "TotalBeforeDiscount"))
                if (decimal.TryParse(QueryStrings.FirstOrDefault(d => d.Key == "TotalBeforeDiscount").Value, out decimal val))
                    query = query.Where(d => val == d.TotalBeforeDiscount);


			//Query TotalDiscount (decimal)
			if (QueryStrings.Any(d => d.Key == "TotalDiscountFrom") && QueryStrings.Any(d => d.Key == "TotalDiscountTo"))
                if (decimal.TryParse(QueryStrings.FirstOrDefault(d => d.Key == "TotalDiscountFrom").Value, out decimal fromVal) && decimal.TryParse(QueryStrings.FirstOrDefault(d => d.Key == "TotalDiscountTo").Value, out decimal toVal))
                    query = query.Where(d => fromVal <= d.TotalDiscount && d.TotalDiscount <= toVal);
            
            if (QueryStrings.Any(d => d.Key == "TotalDiscount"))
                if (decimal.TryParse(QueryStrings.FirstOrDefault(d => d.Key == "TotalDiscount").Value, out decimal val))
                    query = query.Where(d => val == d.TotalDiscount);


			//Query TotalAfterDiscount (decimal)
			if (QueryStrings.Any(d => d.Key == "TotalAfterDiscountFrom") && QueryStrings.Any(d => d.Key == "TotalAfterDiscountTo"))
                if (decimal.TryParse(QueryStrings.FirstOrDefault(d => d.Key == "TotalAfterDiscountFrom").Value, out decimal fromVal) && decimal.TryParse(QueryStrings.FirstOrDefault(d => d.Key == "TotalAfterDiscountTo").Value, out decimal toVal))
                    query = query.Where(d => fromVal <= d.TotalAfterDiscount && d.TotalAfterDiscount <= toVal);
            
            if (QueryStrings.Any(d => d.Key == "TotalAfterDiscount"))
                if (decimal.TryParse(QueryStrings.FirstOrDefault(d => d.Key == "TotalAfterDiscount").Value, out decimal val))
                    query = query.Where(d => val == d.TotalAfterDiscount);


			//Query Tax (decimal)
			if (QueryStrings.Any(d => d.Key == "TaxFrom") && QueryStrings.Any(d => d.Key == "TaxTo"))
                if (decimal.TryParse(QueryStrings.FirstOrDefault(d => d.Key == "TaxFrom").Value, out decimal fromVal) && decimal.TryParse(QueryStrings.FirstOrDefault(d => d.Key == "TaxTo").Value, out decimal toVal))
                    query = query.Where(d => fromVal <= d.Tax && d.Tax <= toVal);
            
            if (QueryStrings.Any(d => d.Key == "Tax"))
                if (decimal.TryParse(QueryStrings.FirstOrDefault(d => d.Key == "Tax").Value, out decimal val))
                    query = query.Where(d => val == d.Tax);


			//Query TotalAfterTax (decimal)
			if (QueryStrings.Any(d => d.Key == "TotalAfterTaxFrom") && QueryStrings.Any(d => d.Key == "TotalAfterTaxTo"))
                if (decimal.TryParse(QueryStrings.FirstOrDefault(d => d.Key == "TotalAfterTaxFrom").Value, out decimal fromVal) && decimal.TryParse(QueryStrings.FirstOrDefault(d => d.Key == "TotalAfterTaxTo").Value, out decimal toVal))
                    query = query.Where(d => fromVal <= d.TotalAfterTax && d.TotalAfterTax <= toVal);
            
            if (QueryStrings.Any(d => d.Key == "TotalAfterTax"))
                if (decimal.TryParse(QueryStrings.FirstOrDefault(d => d.Key == "TotalAfterTax").Value, out decimal val))
                    query = query.Where(d => val == d.TotalAfterTax);


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
		
        public static IQueryable<tbl_PURCHASE_OrderDetail> _sortBuilder(IQueryable<tbl_PURCHASE_OrderDetail> query, Dictionary<string, string> QueryStrings)
        {
            if (QueryStrings.Any(d => d.Key == "SortBy"))
            {
                var sorts = QueryStrings.FirstOrDefault(d => d.Key == "SortBy").Value.Replace("[", "").Replace("]", "").Split(',');
                
                foreach (var item in sorts)
                    if (!string.IsNullOrEmpty(item))
                    {
                        var ordered = query as IOrderedQueryable<tbl_PURCHASE_OrderDetail>;
                        bool isOrdered = ordered.ToString().IndexOf("ORDER BY") !=-1;

                        switch (item)
                        {
							case "IDOrder":
								query = isOrdered ? ordered.ThenBy(o => o.IDOrder) : query.OrderBy(o => o.IDOrder);
								 break;
							case "IDOrder_desc":
                                query = isOrdered ? ordered.ThenByDescending(o => o.IDOrder) : query.OrderByDescending(o => o.IDOrder);
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
							case "IDItem":
								query = isOrdered ? ordered.ThenBy(o => o.IDItem) : query.OrderBy(o => o.IDItem);
								 break;
							case "IDItem_desc":
                                query = isOrdered ? ordered.ThenByDescending(o => o.IDItem) : query.OrderByDescending(o => o.IDItem);
                                break;
							case "IDUoM":
								query = isOrdered ? ordered.ThenBy(o => o.IDUoM) : query.OrderBy(o => o.IDUoM);
								 break;
							case "IDUoM_desc":
                                query = isOrdered ? ordered.ThenByDescending(o => o.IDUoM) : query.OrderByDescending(o => o.IDUoM);
                                break;
							case "IDBaseUoM":
								query = isOrdered ? ordered.ThenBy(o => o.IDBaseUoM) : query.OrderBy(o => o.IDBaseUoM);
								 break;
							case "IDBaseUoM_desc":
                                query = isOrdered ? ordered.ThenByDescending(o => o.IDBaseUoM) : query.OrderByDescending(o => o.IDBaseUoM);
                                break;
							case "UoMSwap":
								query = isOrdered ? ordered.ThenBy(o => o.UoMSwap) : query.OrderBy(o => o.UoMSwap);
								 break;
							case "UoMSwap_desc":
                                query = isOrdered ? ordered.ThenByDescending(o => o.UoMSwap) : query.OrderByDescending(o => o.UoMSwap);
                                break;
							case "UoMSwapAlter":
								query = isOrdered ? ordered.ThenBy(o => o.UoMSwapAlter) : query.OrderBy(o => o.UoMSwapAlter);
								 break;
							case "UoMSwapAlter_desc":
                                query = isOrdered ? ordered.ThenByDescending(o => o.UoMSwapAlter) : query.OrderByDescending(o => o.UoMSwapAlter);
                                break;
							case "UoMQuantityExpected":
								query = isOrdered ? ordered.ThenBy(o => o.UoMQuantityExpected) : query.OrderBy(o => o.UoMQuantityExpected);
								 break;
							case "UoMQuantityExpected_desc":
                                query = isOrdered ? ordered.ThenByDescending(o => o.UoMQuantityExpected) : query.OrderByDescending(o => o.UoMQuantityExpected);
                                break;
							case "QuantityExpected":
								query = isOrdered ? ordered.ThenBy(o => o.QuantityExpected) : query.OrderBy(o => o.QuantityExpected);
								 break;
							case "QuantityExpected_desc":
                                query = isOrdered ? ordered.ThenByDescending(o => o.QuantityExpected) : query.OrderByDescending(o => o.QuantityExpected);
                                break;
							case "QuantityAdjusted":
								query = isOrdered ? ordered.ThenBy(o => o.QuantityAdjusted) : query.OrderBy(o => o.QuantityAdjusted);
								 break;
							case "QuantityAdjusted_desc":
                                query = isOrdered ? ordered.ThenByDescending(o => o.QuantityAdjusted) : query.OrderByDescending(o => o.QuantityAdjusted);
                                break;
							case "QuantityReceived":
								query = isOrdered ? ordered.ThenBy(o => o.QuantityReceived) : query.OrderBy(o => o.QuantityReceived);
								 break;
							case "QuantityReceived_desc":
                                query = isOrdered ? ordered.ThenByDescending(o => o.QuantityReceived) : query.OrderByDescending(o => o.QuantityReceived);
                                break;
							case "QuantityRejected":
								query = isOrdered ? ordered.ThenBy(o => o.QuantityRejected) : query.OrderBy(o => o.QuantityRejected);
								 break;
							case "QuantityRejected_desc":
                                query = isOrdered ? ordered.ThenByDescending(o => o.QuantityRejected) : query.OrderByDescending(o => o.QuantityRejected);
                                break;
							case "UoMPrice":
								query = isOrdered ? ordered.ThenBy(o => o.UoMPrice) : query.OrderBy(o => o.UoMPrice);
								 break;
							case "UoMPrice_desc":
                                query = isOrdered ? ordered.ThenByDescending(o => o.UoMPrice) : query.OrderByDescending(o => o.UoMPrice);
                                break;
							case "IsPromotionItem":
								query = isOrdered ? ordered.ThenBy(o => o.IsPromotionItem) : query.OrderBy(o => o.IsPromotionItem);
								 break;
							case "IsPromotionItem_desc":
                                query = isOrdered ? ordered.ThenByDescending(o => o.IsPromotionItem) : query.OrderByDescending(o => o.IsPromotionItem);
                                break;
							case "IDTax":
								query = isOrdered ? ordered.ThenBy(o => o.IDTax) : query.OrderBy(o => o.IDTax);
								 break;
							case "IDTax_desc":
                                query = isOrdered ? ordered.ThenByDescending(o => o.IDTax) : query.OrderByDescending(o => o.IDTax);
                                break;
							case "TaxRate":
								query = isOrdered ? ordered.ThenBy(o => o.TaxRate) : query.OrderBy(o => o.TaxRate);
								 break;
							case "TaxRate_desc":
                                query = isOrdered ? ordered.ThenByDescending(o => o.TaxRate) : query.OrderByDescending(o => o.TaxRate);
                                break;
							case "TotalBeforeDiscount":
								query = isOrdered ? ordered.ThenBy(o => o.TotalBeforeDiscount) : query.OrderBy(o => o.TotalBeforeDiscount);
								 break;
							case "TotalBeforeDiscount_desc":
                                query = isOrdered ? ordered.ThenByDescending(o => o.TotalBeforeDiscount) : query.OrderByDescending(o => o.TotalBeforeDiscount);
                                break;
							case "TotalDiscount":
								query = isOrdered ? ordered.ThenBy(o => o.TotalDiscount) : query.OrderBy(o => o.TotalDiscount);
								 break;
							case "TotalDiscount_desc":
                                query = isOrdered ? ordered.ThenByDescending(o => o.TotalDiscount) : query.OrderByDescending(o => o.TotalDiscount);
                                break;
							case "TotalAfterDiscount":
								query = isOrdered ? ordered.ThenBy(o => o.TotalAfterDiscount) : query.OrderBy(o => o.TotalAfterDiscount);
								 break;
							case "TotalAfterDiscount_desc":
                                query = isOrdered ? ordered.ThenByDescending(o => o.TotalAfterDiscount) : query.OrderByDescending(o => o.TotalAfterDiscount);
                                break;
							case "Tax":
								query = isOrdered ? ordered.ThenBy(o => o.Tax) : query.OrderBy(o => o.Tax);
								 break;
							case "Tax_desc":
                                query = isOrdered ? ordered.ThenByDescending(o => o.Tax) : query.OrderByDescending(o => o.Tax);
                                break;
							case "TotalAfterTax":
								query = isOrdered ? ordered.ThenBy(o => o.TotalAfterTax) : query.OrderBy(o => o.TotalAfterTax);
								 break;
							case "TotalAfterTax_desc":
                                query = isOrdered ? ordered.ThenByDescending(o => o.TotalAfterTax) : query.OrderByDescending(o => o.TotalAfterTax);
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

        public static IQueryable<tbl_PURCHASE_OrderDetail> _pagingBuilder(IQueryable<tbl_PURCHASE_OrderDetail> query, Dictionary<string, string> QueryStrings)
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






