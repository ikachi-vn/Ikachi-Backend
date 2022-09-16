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
    
    
    public partial class tbl_SALE_OrderDetail
    {
        public int Id { get; set; }
        public Nullable<int> RefID { get; set; }
        public int IDOrder { get; set; }
        public string RefOrder { get; set; }
        public int IDItem { get; set; }
        public string RefItem { get; set; }
        public int IDUoM { get; set; }
        public decimal UoMPrice { get; set; }
        public decimal Quantity { get; set; }
        public int UoMSwap { get; set; }
        public int IDBaseUoM { get; set; }
        public decimal BaseQuantity { get; set; }
        public bool IsPromotionItem { get; set; }
        public Nullable<int> IDPromotion { get; set; }
        public Nullable<int> IDTax { get; set; }
        public decimal TaxRate { get; set; }
        public decimal OriginalTotalBeforeDiscount { get; set; }
        public decimal OriginalPromotion { get; set; }
        public decimal OriginalDiscount1 { get; set; }
        public decimal OriginalDiscount2 { get; set; }
        public decimal OriginalDiscountByItem { get; set; }
        public decimal OriginalDiscountByGroup { get; set; }
        public decimal OriginalDiscountByLine { get; set; }
        public decimal OriginalDiscountByOrder { get; set; }
        public decimal OriginalDiscountFromSalesman { get; set; }
        public decimal OriginalTotalDiscount { get; set; }
        public decimal OriginalTotalAfterDiscount { get; set; }
        public decimal OriginalTax { get; set; }
        public decimal OriginalTotalAfterTax { get; set; }
        public decimal ShippedQuantity { get; set; }
        public decimal ReturnedQuantity { get; set; }
        public decimal TotalBeforeDiscount { get; set; }
        public decimal Discount1 { get; set; }
        public decimal Discount2 { get; set; }
        public decimal DiscountByItem { get; set; }
        public decimal Promotion { get; set; }
        public decimal DiscountByGroup { get; set; }
        public decimal DiscountByLine { get; set; }
        public decimal DiscountByOrder { get; set; }
        public decimal DiscountFromSalesman { get; set; }
        public decimal TotalDiscount { get; set; }
        public decimal TotalAfterDiscount { get; set; }
        public decimal Tax { get; set; }
        public decimal TotalAfterTax { get; set; }
        public string Remark { get; set; }
        public bool IsDisabled { get; set; }
        public bool IsDeleted { get; set; }
        public string CreatedBy { get; set; }
        public string ModifiedBy { get; set; }
        public System.DateTime CreatedDate { get; set; }
        public System.DateTime ModifiedDate { get; set; }
        public string ProductStatus { get; set; }
        public decimal ProductWeight { get; set; }
        public decimal ProductDimensions { get; set; }
        public Nullable<System.DateTime> ExpectedDeliveryDate { get; set; }
        public Nullable<System.DateTime> ShippedDate { get; set; }
        public int UoMSwapAlter { get; set; }
        //List 0:1
        public virtual tbl_SALE_Order tbl_SALE_Order { get; set; }
        //List 0:1
        public virtual tbl_WMS_Item tbl_WMS_Item { get; set; }
        //List 0:1
        public virtual tbl_WMS_ItemUoM tbl_WMS_ItemUoM { get; set; }
    }
}


namespace DTOModel
{
	using System;
	public partial class DTO_SALE_OrderDetail
	{
		public int Id { get; set; }
		public Nullable<int> RefID { get; set; }
		public int IDOrder { get; set; }
		public string RefOrder { get; set; }
		public int IDItem { get; set; }
		public string RefItem { get; set; }
		public int IDUoM { get; set; }
		public decimal UoMPrice { get; set; }
		public decimal Quantity { get; set; }
		public int UoMSwap { get; set; }
		public int IDBaseUoM { get; set; }
		public decimal BaseQuantity { get; set; }
		public bool IsPromotionItem { get; set; }
		public Nullable<int> IDPromotion { get; set; }
		public Nullable<int> IDTax { get; set; }
		public decimal TaxRate { get; set; }
		public decimal OriginalTotalBeforeDiscount { get; set; }
		public decimal OriginalPromotion { get; set; }
		public decimal OriginalDiscount1 { get; set; }
		public decimal OriginalDiscount2 { get; set; }
		public decimal OriginalDiscountByItem { get; set; }
		public decimal OriginalDiscountByGroup { get; set; }
		public decimal OriginalDiscountByLine { get; set; }
		public decimal OriginalDiscountByOrder { get; set; }
		public decimal OriginalDiscountFromSalesman { get; set; }
		public decimal OriginalTotalDiscount { get; set; }
		public decimal OriginalTotalAfterDiscount { get; set; }
		public decimal OriginalTax { get; set; }
		public decimal OriginalTotalAfterTax { get; set; }
		public decimal ShippedQuantity { get; set; }
		public decimal ReturnedQuantity { get; set; }
		public decimal TotalBeforeDiscount { get; set; }
		public decimal Discount1 { get; set; }
		public decimal Discount2 { get; set; }
		public decimal DiscountByItem { get; set; }
		public decimal Promotion { get; set; }
		public decimal DiscountByGroup { get; set; }
		public decimal DiscountByLine { get; set; }
		public decimal DiscountByOrder { get; set; }
		public decimal DiscountFromSalesman { get; set; }
		public decimal TotalDiscount { get; set; }
		public decimal TotalAfterDiscount { get; set; }
		public decimal Tax { get; set; }
		public decimal TotalAfterTax { get; set; }
		public string Remark { get; set; }
		public bool IsDisabled { get; set; }
		public bool IsDeleted { get; set; }
		public string CreatedBy { get; set; }
		public string ModifiedBy { get; set; }
		public System.DateTime CreatedDate { get; set; }
		public System.DateTime ModifiedDate { get; set; }
		public string ProductStatus { get; set; }
		public decimal ProductWeight { get; set; }
		public decimal ProductDimensions { get; set; }
		public Nullable<System.DateTime> ExpectedDeliveryDate { get; set; }
		public Nullable<System.DateTime> ShippedDate { get; set; }
		public int UoMSwapAlter { get; set; }
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

    public static partial class BS_SALE_OrderDetail 
    {
        public static dynamic getSearch(AppEntities db, int IDBranch, int StaffID, Dictionary<string, string> QueryStrings)
        {
            return get(db, IDBranch,StaffID, QueryStrings);
        }

		public static IQueryable<DTO_SALE_OrderDetail> get(AppEntities db, int IDBranch, int StaffID, Dictionary<string, string> QueryStrings)
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
            package.Workbook.Properties.Title = "ART-DMS SALE_OrderDetail";
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

		public static DTO_SALE_OrderDetail getAnItem(AppEntities db, int IDBranch, int StaffID, int id)
        {
            var dbResult = db.tbl_SALE_OrderDetail.Find(id);

			return toDTO(dbResult);
			
        }
		

		public static bool put(AppEntities db, int IDBranch, int StaffID, int Id, dynamic item, string Username, Dictionary<string, string> QueryStrings)
        {
            bool result = false;
            var dbitem = db.tbl_SALE_OrderDetail.Find(Id);
            
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
					errorLog.logMessage("put_SALE_OrderDetail",e);
                    result = false;
                }
            }
            else
                if (QueryStrings.Any(d => d.Key == "ForceCreate"))
                    result =  post(db, IDBranch, StaffID, item, Username) != null;
                
            return result;
        }

        public static void patchDynamicToDB(dynamic item, tbl_SALE_OrderDetail dbitem, string Username)
        {
            Type type = typeof(tbl_SALE_OrderDetail);
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

        public static void patchDTOtoDBValue( DTO_SALE_OrderDetail item, tbl_SALE_OrderDetail dbitem)
        {
            if (item == null){
                dbitem = null;
                return;
            }
            							
			dbitem.RefID = item.RefID;							
			dbitem.IDOrder = item.IDOrder;							
			dbitem.RefOrder = item.RefOrder;							
			dbitem.IDItem = item.IDItem;							
			dbitem.RefItem = item.RefItem;							
			dbitem.IDUoM = item.IDUoM;							
			dbitem.UoMPrice = item.UoMPrice;							
			dbitem.Quantity = item.Quantity;							
			dbitem.UoMSwap = item.UoMSwap;							
			dbitem.IDBaseUoM = item.IDBaseUoM;							
			dbitem.BaseQuantity = item.BaseQuantity;							
			dbitem.IsPromotionItem = item.IsPromotionItem;							
			dbitem.IDPromotion = item.IDPromotion;							
			dbitem.IDTax = item.IDTax;							
			dbitem.TaxRate = item.TaxRate;							
			dbitem.OriginalTotalBeforeDiscount = item.OriginalTotalBeforeDiscount;							
			dbitem.OriginalPromotion = item.OriginalPromotion;							
			dbitem.OriginalDiscount1 = item.OriginalDiscount1;							
			dbitem.OriginalDiscount2 = item.OriginalDiscount2;							
			dbitem.OriginalDiscountByItem = item.OriginalDiscountByItem;							
			dbitem.OriginalDiscountByGroup = item.OriginalDiscountByGroup;							
			dbitem.OriginalDiscountByLine = item.OriginalDiscountByLine;							
			dbitem.OriginalDiscountByOrder = item.OriginalDiscountByOrder;							
			dbitem.OriginalDiscountFromSalesman = item.OriginalDiscountFromSalesman;							
			dbitem.OriginalTotalDiscount = item.OriginalTotalDiscount;							
			dbitem.OriginalTotalAfterDiscount = item.OriginalTotalAfterDiscount;							
			dbitem.OriginalTax = item.OriginalTax;							
			dbitem.OriginalTotalAfterTax = item.OriginalTotalAfterTax;							
			dbitem.ShippedQuantity = item.ShippedQuantity;							
			dbitem.ReturnedQuantity = item.ReturnedQuantity;							
			dbitem.TotalBeforeDiscount = item.TotalBeforeDiscount;							
			dbitem.Discount1 = item.Discount1;							
			dbitem.Discount2 = item.Discount2;							
			dbitem.DiscountByItem = item.DiscountByItem;							
			dbitem.Promotion = item.Promotion;							
			dbitem.DiscountByGroup = item.DiscountByGroup;							
			dbitem.DiscountByLine = item.DiscountByLine;							
			dbitem.DiscountByOrder = item.DiscountByOrder;							
			dbitem.DiscountFromSalesman = item.DiscountFromSalesman;							
			dbitem.TotalDiscount = item.TotalDiscount;							
			dbitem.TotalAfterDiscount = item.TotalAfterDiscount;							
			dbitem.Tax = item.Tax;							
			dbitem.TotalAfterTax = item.TotalAfterTax;							
			dbitem.Remark = item.Remark;							
			dbitem.IsDisabled = item.IsDisabled;							
			dbitem.IsDeleted = item.IsDeleted;							
			dbitem.ProductStatus = item.ProductStatus;							
			dbitem.ProductWeight = item.ProductWeight;							
			dbitem.ProductDimensions = item.ProductDimensions;							
			dbitem.ExpectedDeliveryDate = item.ExpectedDeliveryDate;							
			dbitem.ShippedDate = item.ShippedDate;							
			dbitem.UoMSwapAlter = item.UoMSwapAlter;        }

		public static DTO_SALE_OrderDetail post(AppEntities db, int IDBranch, int StaffID, dynamic item, string Username)
        {
            tbl_SALE_OrderDetail dbitem = new tbl_SALE_OrderDetail();
            if (item != null)
            {
                patchDynamicToDB(item, dbitem, Username);
                
				dbitem.CreatedBy = Username;
				dbitem.CreatedDate = DateTime.Now;				
                try
                {
					db.tbl_SALE_OrderDetail.Add(dbitem);
                    db.SaveChanges();
				
                }
                catch (DbEntityValidationException e)
                {
					errorLog.logMessage("post_SALE_OrderDetail",e);
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
                Type type = Type.GetType("BaseBusiness.BS_SALE_OrderDetail, ClassLibrary");
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
                        var target = new tbl_SALE_OrderDetail();
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
                    
                    tbl_SALE_OrderDetail dbitem = new tbl_SALE_OrderDetail();
                    if (it.Id == null || string.IsNullOrEmpty(it.Id.Value) || it.Id == "0")
                    {
                        dbitem = new tbl_SALE_OrderDetail();
                        dbitem.CreatedBy = Username;
				        dbitem.CreatedDate = DateTime.Now;
                                            }
                    else
                    {
                        dbitem = db.tbl_SALE_OrderDetail.Find((int)it.Id);
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
                        
                        if (dbitem.Id == 0) db.tbl_SALE_OrderDetail.Add(dbitem);
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
                    errorLog.logMessage("post_SALE_OrderDetail",e);
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

            var dbitems = db.tbl_SALE_OrderDetail.Where(d => IDs.Contains(d.Id));
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
			
                BS_Version.update_Version(db, null, "DTO_SALE_OrderDetail", updateDate, Username);
			
            }
            catch (DbEntityValidationException e)
            {
				errorLog.logMessage("delete_SALE_OrderDetail",e);
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

			
            var dbitems = db.tbl_SALE_OrderDetail.Where(d => IDs.Contains(d.Id));
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
			
                BS_Version.update_Version(db, null, "DTO_SALE_OrderDetail", updateDate, Username);
			
            }
            catch (DbEntityValidationException e)
            {
				errorLog.logMessage("disable_SALE_OrderDetail",e);
                result = false;
            }
            
            return result;
        }

		
		//---//
		public static bool check_Exists(AppEntities db, int id)
		{
             
            return db.tbl_SALE_OrderDetail.Any(e => e.Id == id && e.IsDeleted == false);
            
		}
		
		//---//
		public static IQueryable<DTO_SALE_OrderDetail> toDTO(IQueryable<tbl_SALE_OrderDetail> query)
        {
			return query
			.Select(s => new DTO_SALE_OrderDetail(){							
				Id = s.Id,							
				RefID = s.RefID,							
				IDOrder = s.IDOrder,							
				RefOrder = s.RefOrder,							
				IDItem = s.IDItem,							
				RefItem = s.RefItem,							
				IDUoM = s.IDUoM,							
				UoMPrice = s.UoMPrice,							
				Quantity = s.Quantity,							
				UoMSwap = s.UoMSwap,							
				IDBaseUoM = s.IDBaseUoM,							
				BaseQuantity = s.BaseQuantity,							
				IsPromotionItem = s.IsPromotionItem,							
				IDPromotion = s.IDPromotion,							
				IDTax = s.IDTax,							
				TaxRate = s.TaxRate,							
				OriginalTotalBeforeDiscount = s.OriginalTotalBeforeDiscount,							
				OriginalPromotion = s.OriginalPromotion,							
				OriginalDiscount1 = s.OriginalDiscount1,							
				OriginalDiscount2 = s.OriginalDiscount2,							
				OriginalDiscountByItem = s.OriginalDiscountByItem,							
				OriginalDiscountByGroup = s.OriginalDiscountByGroup,							
				OriginalDiscountByLine = s.OriginalDiscountByLine,							
				OriginalDiscountByOrder = s.OriginalDiscountByOrder,							
				OriginalDiscountFromSalesman = s.OriginalDiscountFromSalesman,							
				OriginalTotalDiscount = s.OriginalTotalDiscount,							
				OriginalTotalAfterDiscount = s.OriginalTotalAfterDiscount,							
				OriginalTax = s.OriginalTax,							
				OriginalTotalAfterTax = s.OriginalTotalAfterTax,							
				ShippedQuantity = s.ShippedQuantity,							
				ReturnedQuantity = s.ReturnedQuantity,							
				TotalBeforeDiscount = s.TotalBeforeDiscount,							
				Discount1 = s.Discount1,							
				Discount2 = s.Discount2,							
				DiscountByItem = s.DiscountByItem,							
				Promotion = s.Promotion,							
				DiscountByGroup = s.DiscountByGroup,							
				DiscountByLine = s.DiscountByLine,							
				DiscountByOrder = s.DiscountByOrder,							
				DiscountFromSalesman = s.DiscountFromSalesman,							
				TotalDiscount = s.TotalDiscount,							
				TotalAfterDiscount = s.TotalAfterDiscount,							
				Tax = s.Tax,							
				TotalAfterTax = s.TotalAfterTax,							
				Remark = s.Remark,							
				IsDisabled = s.IsDisabled,							
				IsDeleted = s.IsDeleted,							
				CreatedBy = s.CreatedBy,							
				ModifiedBy = s.ModifiedBy,							
				CreatedDate = s.CreatedDate,							
				ModifiedDate = s.ModifiedDate,							
				ProductStatus = s.ProductStatus,							
				ProductWeight = s.ProductWeight,							
				ProductDimensions = s.ProductDimensions,							
				ExpectedDeliveryDate = s.ExpectedDeliveryDate,							
				ShippedDate = s.ShippedDate,							
				UoMSwapAlter = s.UoMSwapAlter,					
			});//;
                              
        }

		public static DTO_SALE_OrderDetail toDTO(tbl_SALE_OrderDetail dbResult)
        {
			if (dbResult != null)
			{
				return new DTO_SALE_OrderDetail()
				{							
					Id = dbResult.Id,							
					RefID = dbResult.RefID,							
					IDOrder = dbResult.IDOrder,							
					RefOrder = dbResult.RefOrder,							
					IDItem = dbResult.IDItem,							
					RefItem = dbResult.RefItem,							
					IDUoM = dbResult.IDUoM,							
					UoMPrice = dbResult.UoMPrice,							
					Quantity = dbResult.Quantity,							
					UoMSwap = dbResult.UoMSwap,							
					IDBaseUoM = dbResult.IDBaseUoM,							
					BaseQuantity = dbResult.BaseQuantity,							
					IsPromotionItem = dbResult.IsPromotionItem,							
					IDPromotion = dbResult.IDPromotion,							
					IDTax = dbResult.IDTax,							
					TaxRate = dbResult.TaxRate,							
					OriginalTotalBeforeDiscount = dbResult.OriginalTotalBeforeDiscount,							
					OriginalPromotion = dbResult.OriginalPromotion,							
					OriginalDiscount1 = dbResult.OriginalDiscount1,							
					OriginalDiscount2 = dbResult.OriginalDiscount2,							
					OriginalDiscountByItem = dbResult.OriginalDiscountByItem,							
					OriginalDiscountByGroup = dbResult.OriginalDiscountByGroup,							
					OriginalDiscountByLine = dbResult.OriginalDiscountByLine,							
					OriginalDiscountByOrder = dbResult.OriginalDiscountByOrder,							
					OriginalDiscountFromSalesman = dbResult.OriginalDiscountFromSalesman,							
					OriginalTotalDiscount = dbResult.OriginalTotalDiscount,							
					OriginalTotalAfterDiscount = dbResult.OriginalTotalAfterDiscount,							
					OriginalTax = dbResult.OriginalTax,							
					OriginalTotalAfterTax = dbResult.OriginalTotalAfterTax,							
					ShippedQuantity = dbResult.ShippedQuantity,							
					ReturnedQuantity = dbResult.ReturnedQuantity,							
					TotalBeforeDiscount = dbResult.TotalBeforeDiscount,							
					Discount1 = dbResult.Discount1,							
					Discount2 = dbResult.Discount2,							
					DiscountByItem = dbResult.DiscountByItem,							
					Promotion = dbResult.Promotion,							
					DiscountByGroup = dbResult.DiscountByGroup,							
					DiscountByLine = dbResult.DiscountByLine,							
					DiscountByOrder = dbResult.DiscountByOrder,							
					DiscountFromSalesman = dbResult.DiscountFromSalesman,							
					TotalDiscount = dbResult.TotalDiscount,							
					TotalAfterDiscount = dbResult.TotalAfterDiscount,							
					Tax = dbResult.Tax,							
					TotalAfterTax = dbResult.TotalAfterTax,							
					Remark = dbResult.Remark,							
					IsDisabled = dbResult.IsDisabled,							
					IsDeleted = dbResult.IsDeleted,							
					CreatedBy = dbResult.CreatedBy,							
					ModifiedBy = dbResult.ModifiedBy,							
					CreatedDate = dbResult.CreatedDate,							
					ModifiedDate = dbResult.ModifiedDate,							
					ProductStatus = dbResult.ProductStatus,							
					ProductWeight = dbResult.ProductWeight,							
					ProductDimensions = dbResult.ProductDimensions,							
					ExpectedDeliveryDate = dbResult.ExpectedDeliveryDate,							
					ShippedDate = dbResult.ShippedDate,							
					UoMSwapAlter = dbResult.UoMSwapAlter,
				};
			}
			else
				return null; 
        }

		public static IQueryable<tbl_SALE_OrderDetail> _queryBuilder(AppEntities db, int IDBranch, int StaffID, Dictionary<string, string> QueryStrings)
        {
            
			IQueryable<tbl_SALE_OrderDetail> query = db.tbl_SALE_OrderDetail.AsNoTracking();//.Where(d => d.IsDeleted == false );
			

			//Query keyword



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

			//Query RefID (Nullable<int>)
			if (QueryStrings.Any(d => d.Key == "RefID"))
            {
                var IDList = QueryStrings.FirstOrDefault(d => d.Key == "RefID").Value.Replace("[", "").Replace("]", "").Split(',');
                List<int?> IDs = new List<int?>();
                foreach (var item in IDList)
                    if (int.TryParse(item, out int i))
                        IDs.Add(i);
					else if (item == "null")
						IDs.Add(null);
                if (IDs.Count > 0)
                    query = query.Where(d => IDs.Contains(d.RefID));
////                    query = query.Where(d => IDs.Contains(d.RefID));
//                    
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

			//Query RefOrder (string)
			if (QueryStrings.Any(d => d.Key == "RefOrder_eq") && !string.IsNullOrEmpty(QueryStrings.FirstOrDefault(d => d.Key == "RefOrder_eq").Value))
            {
                var keyword = QueryStrings.FirstOrDefault(d => d.Key == "RefOrder_eq").Value;
                query = query.Where(d=>d.RefOrder == keyword);
            }
            if (QueryStrings.Any(d => d.Key == "RefOrder") && !string.IsNullOrEmpty(QueryStrings.FirstOrDefault(d => d.Key == "RefOrder").Value))
            {
                var keyword = QueryStrings.FirstOrDefault(d => d.Key == "RefOrder").Value;
                query = query.Where(d=>d.RefOrder.Contains(keyword));
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

			//Query RefItem (string)
			if (QueryStrings.Any(d => d.Key == "RefItem_eq") && !string.IsNullOrEmpty(QueryStrings.FirstOrDefault(d => d.Key == "RefItem_eq").Value))
            {
                var keyword = QueryStrings.FirstOrDefault(d => d.Key == "RefItem_eq").Value;
                query = query.Where(d=>d.RefItem == keyword);
            }
            if (QueryStrings.Any(d => d.Key == "RefItem") && !string.IsNullOrEmpty(QueryStrings.FirstOrDefault(d => d.Key == "RefItem").Value))
            {
                var keyword = QueryStrings.FirstOrDefault(d => d.Key == "RefItem").Value;
                query = query.Where(d=>d.RefItem.Contains(keyword));
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

			//Query UoMPrice (decimal)
			if (QueryStrings.Any(d => d.Key == "UoMPriceFrom") && QueryStrings.Any(d => d.Key == "UoMPriceTo"))
                if (decimal.TryParse(QueryStrings.FirstOrDefault(d => d.Key == "UoMPriceFrom").Value, out decimal fromVal) && decimal.TryParse(QueryStrings.FirstOrDefault(d => d.Key == "UoMPriceTo").Value, out decimal toVal))
                    query = query.Where(d => fromVal <= d.UoMPrice && d.UoMPrice <= toVal);
            
            if (QueryStrings.Any(d => d.Key == "UoMPrice"))
                if (decimal.TryParse(QueryStrings.FirstOrDefault(d => d.Key == "UoMPrice").Value, out decimal val))
                    query = query.Where(d => val == d.UoMPrice);


			//Query Quantity (decimal)
			if (QueryStrings.Any(d => d.Key == "QuantityFrom") && QueryStrings.Any(d => d.Key == "QuantityTo"))
                if (decimal.TryParse(QueryStrings.FirstOrDefault(d => d.Key == "QuantityFrom").Value, out decimal fromVal) && decimal.TryParse(QueryStrings.FirstOrDefault(d => d.Key == "QuantityTo").Value, out decimal toVal))
                    query = query.Where(d => fromVal <= d.Quantity && d.Quantity <= toVal);
            
            if (QueryStrings.Any(d => d.Key == "Quantity"))
                if (decimal.TryParse(QueryStrings.FirstOrDefault(d => d.Key == "Quantity").Value, out decimal val))
                    query = query.Where(d => val == d.Quantity);


			//Query UoMSwap (int)
			if (QueryStrings.Any(d => d.Key == "UoMSwapFrom") && QueryStrings.Any(d => d.Key == "UoMSwapTo"))
                if (int.TryParse(QueryStrings.FirstOrDefault(d => d.Key == "UoMSwapFrom").Value, out int fromVal) && int.TryParse(QueryStrings.FirstOrDefault(d => d.Key == "UoMSwapTo").Value, out int toVal))
                    query = query.Where(d => fromVal <= d.UoMSwap && d.UoMSwap <= toVal);
            
            if (QueryStrings.Any(d => d.Key == "UoMSwap"))
                if (int.TryParse(QueryStrings.FirstOrDefault(d => d.Key == "UoMSwap").Value, out int val))
                    query = query.Where(d => val == d.UoMSwap);


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

			//Query BaseQuantity (decimal)
			if (QueryStrings.Any(d => d.Key == "BaseQuantityFrom") && QueryStrings.Any(d => d.Key == "BaseQuantityTo"))
                if (decimal.TryParse(QueryStrings.FirstOrDefault(d => d.Key == "BaseQuantityFrom").Value, out decimal fromVal) && decimal.TryParse(QueryStrings.FirstOrDefault(d => d.Key == "BaseQuantityTo").Value, out decimal toVal))
                    query = query.Where(d => fromVal <= d.BaseQuantity && d.BaseQuantity <= toVal);
            
            if (QueryStrings.Any(d => d.Key == "BaseQuantity"))
                if (decimal.TryParse(QueryStrings.FirstOrDefault(d => d.Key == "BaseQuantity").Value, out decimal val))
                    query = query.Where(d => val == d.BaseQuantity);


			//Query IsPromotionItem (bool)
			if (QueryStrings.Any(d => d.Key == "IsPromotionItem"))
            {
                var qValue = QueryStrings.FirstOrDefault(d => d.Key == "IsPromotionItem").Value;
                if (bool.TryParse(qValue, out bool qBoolValue))
                    query = query.Where(d => qBoolValue == d.IsPromotionItem);
            }

			//Query IDPromotion (Nullable<int>)
			if (QueryStrings.Any(d => d.Key == "IDPromotion"))
            {
                var IDList = QueryStrings.FirstOrDefault(d => d.Key == "IDPromotion").Value.Replace("[", "").Replace("]", "").Split(',');
                List<int?> IDs = new List<int?>();
                foreach (var item in IDList)
                    if (int.TryParse(item, out int i))
                        IDs.Add(i);
					else if (item == "null")
						IDs.Add(null);
                if (IDs.Count > 0)
                    query = query.Where(d => IDs.Contains(d.IDPromotion));
////                    query = query.Where(d => IDs.Contains(d.IDPromotion));
//                    
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


			//Query OriginalTotalBeforeDiscount (decimal)
			if (QueryStrings.Any(d => d.Key == "OriginalTotalBeforeDiscountFrom") && QueryStrings.Any(d => d.Key == "OriginalTotalBeforeDiscountTo"))
                if (decimal.TryParse(QueryStrings.FirstOrDefault(d => d.Key == "OriginalTotalBeforeDiscountFrom").Value, out decimal fromVal) && decimal.TryParse(QueryStrings.FirstOrDefault(d => d.Key == "OriginalTotalBeforeDiscountTo").Value, out decimal toVal))
                    query = query.Where(d => fromVal <= d.OriginalTotalBeforeDiscount && d.OriginalTotalBeforeDiscount <= toVal);
            
            if (QueryStrings.Any(d => d.Key == "OriginalTotalBeforeDiscount"))
                if (decimal.TryParse(QueryStrings.FirstOrDefault(d => d.Key == "OriginalTotalBeforeDiscount").Value, out decimal val))
                    query = query.Where(d => val == d.OriginalTotalBeforeDiscount);


			//Query OriginalPromotion (decimal)
			if (QueryStrings.Any(d => d.Key == "OriginalPromotionFrom") && QueryStrings.Any(d => d.Key == "OriginalPromotionTo"))
                if (decimal.TryParse(QueryStrings.FirstOrDefault(d => d.Key == "OriginalPromotionFrom").Value, out decimal fromVal) && decimal.TryParse(QueryStrings.FirstOrDefault(d => d.Key == "OriginalPromotionTo").Value, out decimal toVal))
                    query = query.Where(d => fromVal <= d.OriginalPromotion && d.OriginalPromotion <= toVal);
            
            if (QueryStrings.Any(d => d.Key == "OriginalPromotion"))
                if (decimal.TryParse(QueryStrings.FirstOrDefault(d => d.Key == "OriginalPromotion").Value, out decimal val))
                    query = query.Where(d => val == d.OriginalPromotion);


			//Query OriginalDiscount1 (decimal)
			if (QueryStrings.Any(d => d.Key == "OriginalDiscount1From") && QueryStrings.Any(d => d.Key == "OriginalDiscount1To"))
                if (decimal.TryParse(QueryStrings.FirstOrDefault(d => d.Key == "OriginalDiscount1From").Value, out decimal fromVal) && decimal.TryParse(QueryStrings.FirstOrDefault(d => d.Key == "OriginalDiscount1To").Value, out decimal toVal))
                    query = query.Where(d => fromVal <= d.OriginalDiscount1 && d.OriginalDiscount1 <= toVal);
            
            if (QueryStrings.Any(d => d.Key == "OriginalDiscount1"))
                if (decimal.TryParse(QueryStrings.FirstOrDefault(d => d.Key == "OriginalDiscount1").Value, out decimal val))
                    query = query.Where(d => val == d.OriginalDiscount1);


			//Query OriginalDiscount2 (decimal)
			if (QueryStrings.Any(d => d.Key == "OriginalDiscount2From") && QueryStrings.Any(d => d.Key == "OriginalDiscount2To"))
                if (decimal.TryParse(QueryStrings.FirstOrDefault(d => d.Key == "OriginalDiscount2From").Value, out decimal fromVal) && decimal.TryParse(QueryStrings.FirstOrDefault(d => d.Key == "OriginalDiscount2To").Value, out decimal toVal))
                    query = query.Where(d => fromVal <= d.OriginalDiscount2 && d.OriginalDiscount2 <= toVal);
            
            if (QueryStrings.Any(d => d.Key == "OriginalDiscount2"))
                if (decimal.TryParse(QueryStrings.FirstOrDefault(d => d.Key == "OriginalDiscount2").Value, out decimal val))
                    query = query.Where(d => val == d.OriginalDiscount2);


			//Query OriginalDiscountByItem (decimal)
			if (QueryStrings.Any(d => d.Key == "OriginalDiscountByItemFrom") && QueryStrings.Any(d => d.Key == "OriginalDiscountByItemTo"))
                if (decimal.TryParse(QueryStrings.FirstOrDefault(d => d.Key == "OriginalDiscountByItemFrom").Value, out decimal fromVal) && decimal.TryParse(QueryStrings.FirstOrDefault(d => d.Key == "OriginalDiscountByItemTo").Value, out decimal toVal))
                    query = query.Where(d => fromVal <= d.OriginalDiscountByItem && d.OriginalDiscountByItem <= toVal);
            
            if (QueryStrings.Any(d => d.Key == "OriginalDiscountByItem"))
                if (decimal.TryParse(QueryStrings.FirstOrDefault(d => d.Key == "OriginalDiscountByItem").Value, out decimal val))
                    query = query.Where(d => val == d.OriginalDiscountByItem);


			//Query OriginalDiscountByGroup (decimal)
			if (QueryStrings.Any(d => d.Key == "OriginalDiscountByGroupFrom") && QueryStrings.Any(d => d.Key == "OriginalDiscountByGroupTo"))
                if (decimal.TryParse(QueryStrings.FirstOrDefault(d => d.Key == "OriginalDiscountByGroupFrom").Value, out decimal fromVal) && decimal.TryParse(QueryStrings.FirstOrDefault(d => d.Key == "OriginalDiscountByGroupTo").Value, out decimal toVal))
                    query = query.Where(d => fromVal <= d.OriginalDiscountByGroup && d.OriginalDiscountByGroup <= toVal);
            
            if (QueryStrings.Any(d => d.Key == "OriginalDiscountByGroup"))
                if (decimal.TryParse(QueryStrings.FirstOrDefault(d => d.Key == "OriginalDiscountByGroup").Value, out decimal val))
                    query = query.Where(d => val == d.OriginalDiscountByGroup);


			//Query OriginalDiscountByLine (decimal)
			if (QueryStrings.Any(d => d.Key == "OriginalDiscountByLineFrom") && QueryStrings.Any(d => d.Key == "OriginalDiscountByLineTo"))
                if (decimal.TryParse(QueryStrings.FirstOrDefault(d => d.Key == "OriginalDiscountByLineFrom").Value, out decimal fromVal) && decimal.TryParse(QueryStrings.FirstOrDefault(d => d.Key == "OriginalDiscountByLineTo").Value, out decimal toVal))
                    query = query.Where(d => fromVal <= d.OriginalDiscountByLine && d.OriginalDiscountByLine <= toVal);
            
            if (QueryStrings.Any(d => d.Key == "OriginalDiscountByLine"))
                if (decimal.TryParse(QueryStrings.FirstOrDefault(d => d.Key == "OriginalDiscountByLine").Value, out decimal val))
                    query = query.Where(d => val == d.OriginalDiscountByLine);


			//Query OriginalDiscountByOrder (decimal)
			if (QueryStrings.Any(d => d.Key == "OriginalDiscountByOrderFrom") && QueryStrings.Any(d => d.Key == "OriginalDiscountByOrderTo"))
                if (decimal.TryParse(QueryStrings.FirstOrDefault(d => d.Key == "OriginalDiscountByOrderFrom").Value, out decimal fromVal) && decimal.TryParse(QueryStrings.FirstOrDefault(d => d.Key == "OriginalDiscountByOrderTo").Value, out decimal toVal))
                    query = query.Where(d => fromVal <= d.OriginalDiscountByOrder && d.OriginalDiscountByOrder <= toVal);
            
            if (QueryStrings.Any(d => d.Key == "OriginalDiscountByOrder"))
                if (decimal.TryParse(QueryStrings.FirstOrDefault(d => d.Key == "OriginalDiscountByOrder").Value, out decimal val))
                    query = query.Where(d => val == d.OriginalDiscountByOrder);


			//Query OriginalDiscountFromSalesman (decimal)
			if (QueryStrings.Any(d => d.Key == "OriginalDiscountFromSalesmanFrom") && QueryStrings.Any(d => d.Key == "OriginalDiscountFromSalesmanTo"))
                if (decimal.TryParse(QueryStrings.FirstOrDefault(d => d.Key == "OriginalDiscountFromSalesmanFrom").Value, out decimal fromVal) && decimal.TryParse(QueryStrings.FirstOrDefault(d => d.Key == "OriginalDiscountFromSalesmanTo").Value, out decimal toVal))
                    query = query.Where(d => fromVal <= d.OriginalDiscountFromSalesman && d.OriginalDiscountFromSalesman <= toVal);
            
            if (QueryStrings.Any(d => d.Key == "OriginalDiscountFromSalesman"))
                if (decimal.TryParse(QueryStrings.FirstOrDefault(d => d.Key == "OriginalDiscountFromSalesman").Value, out decimal val))
                    query = query.Where(d => val == d.OriginalDiscountFromSalesman);


			//Query OriginalTotalDiscount (decimal)
			if (QueryStrings.Any(d => d.Key == "OriginalTotalDiscountFrom") && QueryStrings.Any(d => d.Key == "OriginalTotalDiscountTo"))
                if (decimal.TryParse(QueryStrings.FirstOrDefault(d => d.Key == "OriginalTotalDiscountFrom").Value, out decimal fromVal) && decimal.TryParse(QueryStrings.FirstOrDefault(d => d.Key == "OriginalTotalDiscountTo").Value, out decimal toVal))
                    query = query.Where(d => fromVal <= d.OriginalTotalDiscount && d.OriginalTotalDiscount <= toVal);
            
            if (QueryStrings.Any(d => d.Key == "OriginalTotalDiscount"))
                if (decimal.TryParse(QueryStrings.FirstOrDefault(d => d.Key == "OriginalTotalDiscount").Value, out decimal val))
                    query = query.Where(d => val == d.OriginalTotalDiscount);


			//Query OriginalTotalAfterDiscount (decimal)
			if (QueryStrings.Any(d => d.Key == "OriginalTotalAfterDiscountFrom") && QueryStrings.Any(d => d.Key == "OriginalTotalAfterDiscountTo"))
                if (decimal.TryParse(QueryStrings.FirstOrDefault(d => d.Key == "OriginalTotalAfterDiscountFrom").Value, out decimal fromVal) && decimal.TryParse(QueryStrings.FirstOrDefault(d => d.Key == "OriginalTotalAfterDiscountTo").Value, out decimal toVal))
                    query = query.Where(d => fromVal <= d.OriginalTotalAfterDiscount && d.OriginalTotalAfterDiscount <= toVal);
            
            if (QueryStrings.Any(d => d.Key == "OriginalTotalAfterDiscount"))
                if (decimal.TryParse(QueryStrings.FirstOrDefault(d => d.Key == "OriginalTotalAfterDiscount").Value, out decimal val))
                    query = query.Where(d => val == d.OriginalTotalAfterDiscount);


			//Query OriginalTax (decimal)
			if (QueryStrings.Any(d => d.Key == "OriginalTaxFrom") && QueryStrings.Any(d => d.Key == "OriginalTaxTo"))
                if (decimal.TryParse(QueryStrings.FirstOrDefault(d => d.Key == "OriginalTaxFrom").Value, out decimal fromVal) && decimal.TryParse(QueryStrings.FirstOrDefault(d => d.Key == "OriginalTaxTo").Value, out decimal toVal))
                    query = query.Where(d => fromVal <= d.OriginalTax && d.OriginalTax <= toVal);
            
            if (QueryStrings.Any(d => d.Key == "OriginalTax"))
                if (decimal.TryParse(QueryStrings.FirstOrDefault(d => d.Key == "OriginalTax").Value, out decimal val))
                    query = query.Where(d => val == d.OriginalTax);


			//Query OriginalTotalAfterTax (decimal)
			if (QueryStrings.Any(d => d.Key == "OriginalTotalAfterTaxFrom") && QueryStrings.Any(d => d.Key == "OriginalTotalAfterTaxTo"))
                if (decimal.TryParse(QueryStrings.FirstOrDefault(d => d.Key == "OriginalTotalAfterTaxFrom").Value, out decimal fromVal) && decimal.TryParse(QueryStrings.FirstOrDefault(d => d.Key == "OriginalTotalAfterTaxTo").Value, out decimal toVal))
                    query = query.Where(d => fromVal <= d.OriginalTotalAfterTax && d.OriginalTotalAfterTax <= toVal);
            
            if (QueryStrings.Any(d => d.Key == "OriginalTotalAfterTax"))
                if (decimal.TryParse(QueryStrings.FirstOrDefault(d => d.Key == "OriginalTotalAfterTax").Value, out decimal val))
                    query = query.Where(d => val == d.OriginalTotalAfterTax);


			//Query ShippedQuantity (decimal)
			if (QueryStrings.Any(d => d.Key == "ShippedQuantityFrom") && QueryStrings.Any(d => d.Key == "ShippedQuantityTo"))
                if (decimal.TryParse(QueryStrings.FirstOrDefault(d => d.Key == "ShippedQuantityFrom").Value, out decimal fromVal) && decimal.TryParse(QueryStrings.FirstOrDefault(d => d.Key == "ShippedQuantityTo").Value, out decimal toVal))
                    query = query.Where(d => fromVal <= d.ShippedQuantity && d.ShippedQuantity <= toVal);
            
            if (QueryStrings.Any(d => d.Key == "ShippedQuantity"))
                if (decimal.TryParse(QueryStrings.FirstOrDefault(d => d.Key == "ShippedQuantity").Value, out decimal val))
                    query = query.Where(d => val == d.ShippedQuantity);


			//Query ReturnedQuantity (decimal)
			if (QueryStrings.Any(d => d.Key == "ReturnedQuantityFrom") && QueryStrings.Any(d => d.Key == "ReturnedQuantityTo"))
                if (decimal.TryParse(QueryStrings.FirstOrDefault(d => d.Key == "ReturnedQuantityFrom").Value, out decimal fromVal) && decimal.TryParse(QueryStrings.FirstOrDefault(d => d.Key == "ReturnedQuantityTo").Value, out decimal toVal))
                    query = query.Where(d => fromVal <= d.ReturnedQuantity && d.ReturnedQuantity <= toVal);
            
            if (QueryStrings.Any(d => d.Key == "ReturnedQuantity"))
                if (decimal.TryParse(QueryStrings.FirstOrDefault(d => d.Key == "ReturnedQuantity").Value, out decimal val))
                    query = query.Where(d => val == d.ReturnedQuantity);


			//Query TotalBeforeDiscount (decimal)
			if (QueryStrings.Any(d => d.Key == "TotalBeforeDiscountFrom") && QueryStrings.Any(d => d.Key == "TotalBeforeDiscountTo"))
                if (decimal.TryParse(QueryStrings.FirstOrDefault(d => d.Key == "TotalBeforeDiscountFrom").Value, out decimal fromVal) && decimal.TryParse(QueryStrings.FirstOrDefault(d => d.Key == "TotalBeforeDiscountTo").Value, out decimal toVal))
                    query = query.Where(d => fromVal <= d.TotalBeforeDiscount && d.TotalBeforeDiscount <= toVal);
            
            if (QueryStrings.Any(d => d.Key == "TotalBeforeDiscount"))
                if (decimal.TryParse(QueryStrings.FirstOrDefault(d => d.Key == "TotalBeforeDiscount").Value, out decimal val))
                    query = query.Where(d => val == d.TotalBeforeDiscount);


			//Query Discount1 (decimal)
			if (QueryStrings.Any(d => d.Key == "Discount1From") && QueryStrings.Any(d => d.Key == "Discount1To"))
                if (decimal.TryParse(QueryStrings.FirstOrDefault(d => d.Key == "Discount1From").Value, out decimal fromVal) && decimal.TryParse(QueryStrings.FirstOrDefault(d => d.Key == "Discount1To").Value, out decimal toVal))
                    query = query.Where(d => fromVal <= d.Discount1 && d.Discount1 <= toVal);
            
            if (QueryStrings.Any(d => d.Key == "Discount1"))
                if (decimal.TryParse(QueryStrings.FirstOrDefault(d => d.Key == "Discount1").Value, out decimal val))
                    query = query.Where(d => val == d.Discount1);


			//Query Discount2 (decimal)
			if (QueryStrings.Any(d => d.Key == "Discount2From") && QueryStrings.Any(d => d.Key == "Discount2To"))
                if (decimal.TryParse(QueryStrings.FirstOrDefault(d => d.Key == "Discount2From").Value, out decimal fromVal) && decimal.TryParse(QueryStrings.FirstOrDefault(d => d.Key == "Discount2To").Value, out decimal toVal))
                    query = query.Where(d => fromVal <= d.Discount2 && d.Discount2 <= toVal);
            
            if (QueryStrings.Any(d => d.Key == "Discount2"))
                if (decimal.TryParse(QueryStrings.FirstOrDefault(d => d.Key == "Discount2").Value, out decimal val))
                    query = query.Where(d => val == d.Discount2);


			//Query DiscountByItem (decimal)
			if (QueryStrings.Any(d => d.Key == "DiscountByItemFrom") && QueryStrings.Any(d => d.Key == "DiscountByItemTo"))
                if (decimal.TryParse(QueryStrings.FirstOrDefault(d => d.Key == "DiscountByItemFrom").Value, out decimal fromVal) && decimal.TryParse(QueryStrings.FirstOrDefault(d => d.Key == "DiscountByItemTo").Value, out decimal toVal))
                    query = query.Where(d => fromVal <= d.DiscountByItem && d.DiscountByItem <= toVal);
            
            if (QueryStrings.Any(d => d.Key == "DiscountByItem"))
                if (decimal.TryParse(QueryStrings.FirstOrDefault(d => d.Key == "DiscountByItem").Value, out decimal val))
                    query = query.Where(d => val == d.DiscountByItem);


			//Query Promotion (decimal)
			if (QueryStrings.Any(d => d.Key == "PromotionFrom") && QueryStrings.Any(d => d.Key == "PromotionTo"))
                if (decimal.TryParse(QueryStrings.FirstOrDefault(d => d.Key == "PromotionFrom").Value, out decimal fromVal) && decimal.TryParse(QueryStrings.FirstOrDefault(d => d.Key == "PromotionTo").Value, out decimal toVal))
                    query = query.Where(d => fromVal <= d.Promotion && d.Promotion <= toVal);
            
            if (QueryStrings.Any(d => d.Key == "Promotion"))
                if (decimal.TryParse(QueryStrings.FirstOrDefault(d => d.Key == "Promotion").Value, out decimal val))
                    query = query.Where(d => val == d.Promotion);


			//Query DiscountByGroup (decimal)
			if (QueryStrings.Any(d => d.Key == "DiscountByGroupFrom") && QueryStrings.Any(d => d.Key == "DiscountByGroupTo"))
                if (decimal.TryParse(QueryStrings.FirstOrDefault(d => d.Key == "DiscountByGroupFrom").Value, out decimal fromVal) && decimal.TryParse(QueryStrings.FirstOrDefault(d => d.Key == "DiscountByGroupTo").Value, out decimal toVal))
                    query = query.Where(d => fromVal <= d.DiscountByGroup && d.DiscountByGroup <= toVal);
            
            if (QueryStrings.Any(d => d.Key == "DiscountByGroup"))
                if (decimal.TryParse(QueryStrings.FirstOrDefault(d => d.Key == "DiscountByGroup").Value, out decimal val))
                    query = query.Where(d => val == d.DiscountByGroup);


			//Query DiscountByLine (decimal)
			if (QueryStrings.Any(d => d.Key == "DiscountByLineFrom") && QueryStrings.Any(d => d.Key == "DiscountByLineTo"))
                if (decimal.TryParse(QueryStrings.FirstOrDefault(d => d.Key == "DiscountByLineFrom").Value, out decimal fromVal) && decimal.TryParse(QueryStrings.FirstOrDefault(d => d.Key == "DiscountByLineTo").Value, out decimal toVal))
                    query = query.Where(d => fromVal <= d.DiscountByLine && d.DiscountByLine <= toVal);
            
            if (QueryStrings.Any(d => d.Key == "DiscountByLine"))
                if (decimal.TryParse(QueryStrings.FirstOrDefault(d => d.Key == "DiscountByLine").Value, out decimal val))
                    query = query.Where(d => val == d.DiscountByLine);


			//Query DiscountByOrder (decimal)
			if (QueryStrings.Any(d => d.Key == "DiscountByOrderFrom") && QueryStrings.Any(d => d.Key == "DiscountByOrderTo"))
                if (decimal.TryParse(QueryStrings.FirstOrDefault(d => d.Key == "DiscountByOrderFrom").Value, out decimal fromVal) && decimal.TryParse(QueryStrings.FirstOrDefault(d => d.Key == "DiscountByOrderTo").Value, out decimal toVal))
                    query = query.Where(d => fromVal <= d.DiscountByOrder && d.DiscountByOrder <= toVal);
            
            if (QueryStrings.Any(d => d.Key == "DiscountByOrder"))
                if (decimal.TryParse(QueryStrings.FirstOrDefault(d => d.Key == "DiscountByOrder").Value, out decimal val))
                    query = query.Where(d => val == d.DiscountByOrder);


			//Query DiscountFromSalesman (decimal)
			if (QueryStrings.Any(d => d.Key == "DiscountFromSalesmanFrom") && QueryStrings.Any(d => d.Key == "DiscountFromSalesmanTo"))
                if (decimal.TryParse(QueryStrings.FirstOrDefault(d => d.Key == "DiscountFromSalesmanFrom").Value, out decimal fromVal) && decimal.TryParse(QueryStrings.FirstOrDefault(d => d.Key == "DiscountFromSalesmanTo").Value, out decimal toVal))
                    query = query.Where(d => fromVal <= d.DiscountFromSalesman && d.DiscountFromSalesman <= toVal);
            
            if (QueryStrings.Any(d => d.Key == "DiscountFromSalesman"))
                if (decimal.TryParse(QueryStrings.FirstOrDefault(d => d.Key == "DiscountFromSalesman").Value, out decimal val))
                    query = query.Where(d => val == d.DiscountFromSalesman);


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


			//Query ProductStatus (string)
			if (QueryStrings.Any(d => d.Key == "ProductStatus_eq") && !string.IsNullOrEmpty(QueryStrings.FirstOrDefault(d => d.Key == "ProductStatus_eq").Value))
            {
                var keyword = QueryStrings.FirstOrDefault(d => d.Key == "ProductStatus_eq").Value;
                query = query.Where(d=>d.ProductStatus == keyword);
            }
            if (QueryStrings.Any(d => d.Key == "ProductStatus") && !string.IsNullOrEmpty(QueryStrings.FirstOrDefault(d => d.Key == "ProductStatus").Value))
            {
                var keyword = QueryStrings.FirstOrDefault(d => d.Key == "ProductStatus").Value;
                query = query.Where(d=>d.ProductStatus.Contains(keyword));
            }
            

			//Query ProductWeight (decimal)
			if (QueryStrings.Any(d => d.Key == "ProductWeightFrom") && QueryStrings.Any(d => d.Key == "ProductWeightTo"))
                if (decimal.TryParse(QueryStrings.FirstOrDefault(d => d.Key == "ProductWeightFrom").Value, out decimal fromVal) && decimal.TryParse(QueryStrings.FirstOrDefault(d => d.Key == "ProductWeightTo").Value, out decimal toVal))
                    query = query.Where(d => fromVal <= d.ProductWeight && d.ProductWeight <= toVal);
            
            if (QueryStrings.Any(d => d.Key == "ProductWeight"))
                if (decimal.TryParse(QueryStrings.FirstOrDefault(d => d.Key == "ProductWeight").Value, out decimal val))
                    query = query.Where(d => val == d.ProductWeight);


			//Query ProductDimensions (decimal)
			if (QueryStrings.Any(d => d.Key == "ProductDimensionsFrom") && QueryStrings.Any(d => d.Key == "ProductDimensionsTo"))
                if (decimal.TryParse(QueryStrings.FirstOrDefault(d => d.Key == "ProductDimensionsFrom").Value, out decimal fromVal) && decimal.TryParse(QueryStrings.FirstOrDefault(d => d.Key == "ProductDimensionsTo").Value, out decimal toVal))
                    query = query.Where(d => fromVal <= d.ProductDimensions && d.ProductDimensions <= toVal);
            
            if (QueryStrings.Any(d => d.Key == "ProductDimensions"))
                if (decimal.TryParse(QueryStrings.FirstOrDefault(d => d.Key == "ProductDimensions").Value, out decimal val))
                    query = query.Where(d => val == d.ProductDimensions);


			//Query ExpectedDeliveryDate (Nullable<System.DateTime>)
			if (QueryStrings.Any(d => d.Key == "ExpectedDeliveryDateFrom") && QueryStrings.Any(d => d.Key == "ExpectedDeliveryDateTo"))
                if (DateTime.TryParse(QueryStrings.FirstOrDefault(d => d.Key == "ExpectedDeliveryDateFrom").Value, out DateTime fromDate) && DateTime.TryParse(QueryStrings.FirstOrDefault(d => d.Key == "ExpectedDeliveryDateTo").Value, out DateTime toDate))
                    query = query.Where(d => fromDate <= d.ExpectedDeliveryDate && d.ExpectedDeliveryDate <= toDate);

            if (QueryStrings.Any(d => d.Key == "ExpectedDeliveryDate"))
                if (DateTime.TryParse(QueryStrings.FirstOrDefault(d => d.Key == "ExpectedDeliveryDate").Value, out DateTime val))
                    query = query.Where(d => d.ExpectedDeliveryDate != null && DbFunctions.TruncateTime(val) == DbFunctions.TruncateTime(d.ExpectedDeliveryDate));


			//Query ShippedDate (Nullable<System.DateTime>)
			if (QueryStrings.Any(d => d.Key == "ShippedDateFrom") && QueryStrings.Any(d => d.Key == "ShippedDateTo"))
                if (DateTime.TryParse(QueryStrings.FirstOrDefault(d => d.Key == "ShippedDateFrom").Value, out DateTime fromDate) && DateTime.TryParse(QueryStrings.FirstOrDefault(d => d.Key == "ShippedDateTo").Value, out DateTime toDate))
                    query = query.Where(d => fromDate <= d.ShippedDate && d.ShippedDate <= toDate);

            if (QueryStrings.Any(d => d.Key == "ShippedDate"))
                if (DateTime.TryParse(QueryStrings.FirstOrDefault(d => d.Key == "ShippedDate").Value, out DateTime val))
                    query = query.Where(d => d.ShippedDate != null && DbFunctions.TruncateTime(val) == DbFunctions.TruncateTime(d.ShippedDate));


			//Query UoMSwapAlter (int)
			if (QueryStrings.Any(d => d.Key == "UoMSwapAlterFrom") && QueryStrings.Any(d => d.Key == "UoMSwapAlterTo"))
                if (int.TryParse(QueryStrings.FirstOrDefault(d => d.Key == "UoMSwapAlterFrom").Value, out int fromVal) && int.TryParse(QueryStrings.FirstOrDefault(d => d.Key == "UoMSwapAlterTo").Value, out int toVal))
                    query = query.Where(d => fromVal <= d.UoMSwapAlter && d.UoMSwapAlter <= toVal);
            
            if (QueryStrings.Any(d => d.Key == "UoMSwapAlter"))
                if (int.TryParse(QueryStrings.FirstOrDefault(d => d.Key == "UoMSwapAlter").Value, out int val))
                    query = query.Where(d => val == d.UoMSwapAlter);

            return query;
        }
		
        public static IQueryable<tbl_SALE_OrderDetail> _sortBuilder(IQueryable<tbl_SALE_OrderDetail> query, Dictionary<string, string> QueryStrings)
        {
            if (QueryStrings.Any(d => d.Key == "SortBy"))
            {
                var sorts = QueryStrings.FirstOrDefault(d => d.Key == "SortBy").Value.Replace("[", "").Replace("]", "").Split(',');
                
                foreach (var item in sorts)
                    if (!string.IsNullOrEmpty(item))
                    {
                        var ordered = query as IOrderedQueryable<tbl_SALE_OrderDetail>;
                        bool isOrdered = ordered.ToString().IndexOf("ORDER BY") !=-1;

                        switch (item)
                        {
							case "Id":
								query = isOrdered ? ordered.ThenBy(o => o.Id) : query.OrderBy(o => o.Id);
								 break;
							case "Id_desc":
                                query = isOrdered ? ordered.ThenByDescending(o => o.Id) : query.OrderByDescending(o => o.Id);
                                break;
							case "RefID":
								query = isOrdered ? ordered.ThenBy(o => o.RefID) : query.OrderBy(o => o.RefID);
								 break;
							case "RefID_desc":
                                query = isOrdered ? ordered.ThenByDescending(o => o.RefID) : query.OrderByDescending(o => o.RefID);
                                break;
							case "IDOrder":
								query = isOrdered ? ordered.ThenBy(o => o.IDOrder) : query.OrderBy(o => o.IDOrder);
								 break;
							case "IDOrder_desc":
                                query = isOrdered ? ordered.ThenByDescending(o => o.IDOrder) : query.OrderByDescending(o => o.IDOrder);
                                break;
							case "RefOrder":
								query = isOrdered ? ordered.ThenBy(o => o.RefOrder) : query.OrderBy(o => o.RefOrder);
								 break;
							case "RefOrder_desc":
                                query = isOrdered ? ordered.ThenByDescending(o => o.RefOrder) : query.OrderByDescending(o => o.RefOrder);
                                break;
							case "IDItem":
								query = isOrdered ? ordered.ThenBy(o => o.IDItem) : query.OrderBy(o => o.IDItem);
								 break;
							case "IDItem_desc":
                                query = isOrdered ? ordered.ThenByDescending(o => o.IDItem) : query.OrderByDescending(o => o.IDItem);
                                break;
							case "RefItem":
								query = isOrdered ? ordered.ThenBy(o => o.RefItem) : query.OrderBy(o => o.RefItem);
								 break;
							case "RefItem_desc":
                                query = isOrdered ? ordered.ThenByDescending(o => o.RefItem) : query.OrderByDescending(o => o.RefItem);
                                break;
							case "IDUoM":
								query = isOrdered ? ordered.ThenBy(o => o.IDUoM) : query.OrderBy(o => o.IDUoM);
								 break;
							case "IDUoM_desc":
                                query = isOrdered ? ordered.ThenByDescending(o => o.IDUoM) : query.OrderByDescending(o => o.IDUoM);
                                break;
							case "UoMPrice":
								query = isOrdered ? ordered.ThenBy(o => o.UoMPrice) : query.OrderBy(o => o.UoMPrice);
								 break;
							case "UoMPrice_desc":
                                query = isOrdered ? ordered.ThenByDescending(o => o.UoMPrice) : query.OrderByDescending(o => o.UoMPrice);
                                break;
							case "Quantity":
								query = isOrdered ? ordered.ThenBy(o => o.Quantity) : query.OrderBy(o => o.Quantity);
								 break;
							case "Quantity_desc":
                                query = isOrdered ? ordered.ThenByDescending(o => o.Quantity) : query.OrderByDescending(o => o.Quantity);
                                break;
							case "UoMSwap":
								query = isOrdered ? ordered.ThenBy(o => o.UoMSwap) : query.OrderBy(o => o.UoMSwap);
								 break;
							case "UoMSwap_desc":
                                query = isOrdered ? ordered.ThenByDescending(o => o.UoMSwap) : query.OrderByDescending(o => o.UoMSwap);
                                break;
							case "IDBaseUoM":
								query = isOrdered ? ordered.ThenBy(o => o.IDBaseUoM) : query.OrderBy(o => o.IDBaseUoM);
								 break;
							case "IDBaseUoM_desc":
                                query = isOrdered ? ordered.ThenByDescending(o => o.IDBaseUoM) : query.OrderByDescending(o => o.IDBaseUoM);
                                break;
							case "BaseQuantity":
								query = isOrdered ? ordered.ThenBy(o => o.BaseQuantity) : query.OrderBy(o => o.BaseQuantity);
								 break;
							case "BaseQuantity_desc":
                                query = isOrdered ? ordered.ThenByDescending(o => o.BaseQuantity) : query.OrderByDescending(o => o.BaseQuantity);
                                break;
							case "IsPromotionItem":
								query = isOrdered ? ordered.ThenBy(o => o.IsPromotionItem) : query.OrderBy(o => o.IsPromotionItem);
								 break;
							case "IsPromotionItem_desc":
                                query = isOrdered ? ordered.ThenByDescending(o => o.IsPromotionItem) : query.OrderByDescending(o => o.IsPromotionItem);
                                break;
							case "IDPromotion":
								query = isOrdered ? ordered.ThenBy(o => o.IDPromotion) : query.OrderBy(o => o.IDPromotion);
								 break;
							case "IDPromotion_desc":
                                query = isOrdered ? ordered.ThenByDescending(o => o.IDPromotion) : query.OrderByDescending(o => o.IDPromotion);
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
							case "OriginalTotalBeforeDiscount":
								query = isOrdered ? ordered.ThenBy(o => o.OriginalTotalBeforeDiscount) : query.OrderBy(o => o.OriginalTotalBeforeDiscount);
								 break;
							case "OriginalTotalBeforeDiscount_desc":
                                query = isOrdered ? ordered.ThenByDescending(o => o.OriginalTotalBeforeDiscount) : query.OrderByDescending(o => o.OriginalTotalBeforeDiscount);
                                break;
							case "OriginalPromotion":
								query = isOrdered ? ordered.ThenBy(o => o.OriginalPromotion) : query.OrderBy(o => o.OriginalPromotion);
								 break;
							case "OriginalPromotion_desc":
                                query = isOrdered ? ordered.ThenByDescending(o => o.OriginalPromotion) : query.OrderByDescending(o => o.OriginalPromotion);
                                break;
							case "OriginalDiscount1":
								query = isOrdered ? ordered.ThenBy(o => o.OriginalDiscount1) : query.OrderBy(o => o.OriginalDiscount1);
								 break;
							case "OriginalDiscount1_desc":
                                query = isOrdered ? ordered.ThenByDescending(o => o.OriginalDiscount1) : query.OrderByDescending(o => o.OriginalDiscount1);
                                break;
							case "OriginalDiscount2":
								query = isOrdered ? ordered.ThenBy(o => o.OriginalDiscount2) : query.OrderBy(o => o.OriginalDiscount2);
								 break;
							case "OriginalDiscount2_desc":
                                query = isOrdered ? ordered.ThenByDescending(o => o.OriginalDiscount2) : query.OrderByDescending(o => o.OriginalDiscount2);
                                break;
							case "OriginalDiscountByItem":
								query = isOrdered ? ordered.ThenBy(o => o.OriginalDiscountByItem) : query.OrderBy(o => o.OriginalDiscountByItem);
								 break;
							case "OriginalDiscountByItem_desc":
                                query = isOrdered ? ordered.ThenByDescending(o => o.OriginalDiscountByItem) : query.OrderByDescending(o => o.OriginalDiscountByItem);
                                break;
							case "OriginalDiscountByGroup":
								query = isOrdered ? ordered.ThenBy(o => o.OriginalDiscountByGroup) : query.OrderBy(o => o.OriginalDiscountByGroup);
								 break;
							case "OriginalDiscountByGroup_desc":
                                query = isOrdered ? ordered.ThenByDescending(o => o.OriginalDiscountByGroup) : query.OrderByDescending(o => o.OriginalDiscountByGroup);
                                break;
							case "OriginalDiscountByLine":
								query = isOrdered ? ordered.ThenBy(o => o.OriginalDiscountByLine) : query.OrderBy(o => o.OriginalDiscountByLine);
								 break;
							case "OriginalDiscountByLine_desc":
                                query = isOrdered ? ordered.ThenByDescending(o => o.OriginalDiscountByLine) : query.OrderByDescending(o => o.OriginalDiscountByLine);
                                break;
							case "OriginalDiscountByOrder":
								query = isOrdered ? ordered.ThenBy(o => o.OriginalDiscountByOrder) : query.OrderBy(o => o.OriginalDiscountByOrder);
								 break;
							case "OriginalDiscountByOrder_desc":
                                query = isOrdered ? ordered.ThenByDescending(o => o.OriginalDiscountByOrder) : query.OrderByDescending(o => o.OriginalDiscountByOrder);
                                break;
							case "OriginalDiscountFromSalesman":
								query = isOrdered ? ordered.ThenBy(o => o.OriginalDiscountFromSalesman) : query.OrderBy(o => o.OriginalDiscountFromSalesman);
								 break;
							case "OriginalDiscountFromSalesman_desc":
                                query = isOrdered ? ordered.ThenByDescending(o => o.OriginalDiscountFromSalesman) : query.OrderByDescending(o => o.OriginalDiscountFromSalesman);
                                break;
							case "OriginalTotalDiscount":
								query = isOrdered ? ordered.ThenBy(o => o.OriginalTotalDiscount) : query.OrderBy(o => o.OriginalTotalDiscount);
								 break;
							case "OriginalTotalDiscount_desc":
                                query = isOrdered ? ordered.ThenByDescending(o => o.OriginalTotalDiscount) : query.OrderByDescending(o => o.OriginalTotalDiscount);
                                break;
							case "OriginalTotalAfterDiscount":
								query = isOrdered ? ordered.ThenBy(o => o.OriginalTotalAfterDiscount) : query.OrderBy(o => o.OriginalTotalAfterDiscount);
								 break;
							case "OriginalTotalAfterDiscount_desc":
                                query = isOrdered ? ordered.ThenByDescending(o => o.OriginalTotalAfterDiscount) : query.OrderByDescending(o => o.OriginalTotalAfterDiscount);
                                break;
							case "OriginalTax":
								query = isOrdered ? ordered.ThenBy(o => o.OriginalTax) : query.OrderBy(o => o.OriginalTax);
								 break;
							case "OriginalTax_desc":
                                query = isOrdered ? ordered.ThenByDescending(o => o.OriginalTax) : query.OrderByDescending(o => o.OriginalTax);
                                break;
							case "OriginalTotalAfterTax":
								query = isOrdered ? ordered.ThenBy(o => o.OriginalTotalAfterTax) : query.OrderBy(o => o.OriginalTotalAfterTax);
								 break;
							case "OriginalTotalAfterTax_desc":
                                query = isOrdered ? ordered.ThenByDescending(o => o.OriginalTotalAfterTax) : query.OrderByDescending(o => o.OriginalTotalAfterTax);
                                break;
							case "ShippedQuantity":
								query = isOrdered ? ordered.ThenBy(o => o.ShippedQuantity) : query.OrderBy(o => o.ShippedQuantity);
								 break;
							case "ShippedQuantity_desc":
                                query = isOrdered ? ordered.ThenByDescending(o => o.ShippedQuantity) : query.OrderByDescending(o => o.ShippedQuantity);
                                break;
							case "ReturnedQuantity":
								query = isOrdered ? ordered.ThenBy(o => o.ReturnedQuantity) : query.OrderBy(o => o.ReturnedQuantity);
								 break;
							case "ReturnedQuantity_desc":
                                query = isOrdered ? ordered.ThenByDescending(o => o.ReturnedQuantity) : query.OrderByDescending(o => o.ReturnedQuantity);
                                break;
							case "TotalBeforeDiscount":
								query = isOrdered ? ordered.ThenBy(o => o.TotalBeforeDiscount) : query.OrderBy(o => o.TotalBeforeDiscount);
								 break;
							case "TotalBeforeDiscount_desc":
                                query = isOrdered ? ordered.ThenByDescending(o => o.TotalBeforeDiscount) : query.OrderByDescending(o => o.TotalBeforeDiscount);
                                break;
							case "Discount1":
								query = isOrdered ? ordered.ThenBy(o => o.Discount1) : query.OrderBy(o => o.Discount1);
								 break;
							case "Discount1_desc":
                                query = isOrdered ? ordered.ThenByDescending(o => o.Discount1) : query.OrderByDescending(o => o.Discount1);
                                break;
							case "Discount2":
								query = isOrdered ? ordered.ThenBy(o => o.Discount2) : query.OrderBy(o => o.Discount2);
								 break;
							case "Discount2_desc":
                                query = isOrdered ? ordered.ThenByDescending(o => o.Discount2) : query.OrderByDescending(o => o.Discount2);
                                break;
							case "DiscountByItem":
								query = isOrdered ? ordered.ThenBy(o => o.DiscountByItem) : query.OrderBy(o => o.DiscountByItem);
								 break;
							case "DiscountByItem_desc":
                                query = isOrdered ? ordered.ThenByDescending(o => o.DiscountByItem) : query.OrderByDescending(o => o.DiscountByItem);
                                break;
							case "Promotion":
								query = isOrdered ? ordered.ThenBy(o => o.Promotion) : query.OrderBy(o => o.Promotion);
								 break;
							case "Promotion_desc":
                                query = isOrdered ? ordered.ThenByDescending(o => o.Promotion) : query.OrderByDescending(o => o.Promotion);
                                break;
							case "DiscountByGroup":
								query = isOrdered ? ordered.ThenBy(o => o.DiscountByGroup) : query.OrderBy(o => o.DiscountByGroup);
								 break;
							case "DiscountByGroup_desc":
                                query = isOrdered ? ordered.ThenByDescending(o => o.DiscountByGroup) : query.OrderByDescending(o => o.DiscountByGroup);
                                break;
							case "DiscountByLine":
								query = isOrdered ? ordered.ThenBy(o => o.DiscountByLine) : query.OrderBy(o => o.DiscountByLine);
								 break;
							case "DiscountByLine_desc":
                                query = isOrdered ? ordered.ThenByDescending(o => o.DiscountByLine) : query.OrderByDescending(o => o.DiscountByLine);
                                break;
							case "DiscountByOrder":
								query = isOrdered ? ordered.ThenBy(o => o.DiscountByOrder) : query.OrderBy(o => o.DiscountByOrder);
								 break;
							case "DiscountByOrder_desc":
                                query = isOrdered ? ordered.ThenByDescending(o => o.DiscountByOrder) : query.OrderByDescending(o => o.DiscountByOrder);
                                break;
							case "DiscountFromSalesman":
								query = isOrdered ? ordered.ThenBy(o => o.DiscountFromSalesman) : query.OrderBy(o => o.DiscountFromSalesman);
								 break;
							case "DiscountFromSalesman_desc":
                                query = isOrdered ? ordered.ThenByDescending(o => o.DiscountFromSalesman) : query.OrderByDescending(o => o.DiscountFromSalesman);
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
							case "Remark":
								query = isOrdered ? ordered.ThenBy(o => o.Remark) : query.OrderBy(o => o.Remark);
								 break;
							case "Remark_desc":
                                query = isOrdered ? ordered.ThenByDescending(o => o.Remark) : query.OrderByDescending(o => o.Remark);
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
							case "ProductStatus":
								query = isOrdered ? ordered.ThenBy(o => o.ProductStatus) : query.OrderBy(o => o.ProductStatus);
								 break;
							case "ProductStatus_desc":
                                query = isOrdered ? ordered.ThenByDescending(o => o.ProductStatus) : query.OrderByDescending(o => o.ProductStatus);
                                break;
							case "ProductWeight":
								query = isOrdered ? ordered.ThenBy(o => o.ProductWeight) : query.OrderBy(o => o.ProductWeight);
								 break;
							case "ProductWeight_desc":
                                query = isOrdered ? ordered.ThenByDescending(o => o.ProductWeight) : query.OrderByDescending(o => o.ProductWeight);
                                break;
							case "ProductDimensions":
								query = isOrdered ? ordered.ThenBy(o => o.ProductDimensions) : query.OrderBy(o => o.ProductDimensions);
								 break;
							case "ProductDimensions_desc":
                                query = isOrdered ? ordered.ThenByDescending(o => o.ProductDimensions) : query.OrderByDescending(o => o.ProductDimensions);
                                break;
							case "ExpectedDeliveryDate":
								query = isOrdered ? ordered.ThenBy(o => o.ExpectedDeliveryDate) : query.OrderBy(o => o.ExpectedDeliveryDate);
								 break;
							case "ExpectedDeliveryDate_desc":
                                query = isOrdered ? ordered.ThenByDescending(o => o.ExpectedDeliveryDate) : query.OrderByDescending(o => o.ExpectedDeliveryDate);
                                break;
							case "ShippedDate":
								query = isOrdered ? ordered.ThenBy(o => o.ShippedDate) : query.OrderBy(o => o.ShippedDate);
								 break;
							case "ShippedDate_desc":
                                query = isOrdered ? ordered.ThenByDescending(o => o.ShippedDate) : query.OrderByDescending(o => o.ShippedDate);
                                break;
							case "UoMSwapAlter":
								query = isOrdered ? ordered.ThenBy(o => o.UoMSwapAlter) : query.OrderBy(o => o.UoMSwapAlter);
								 break;
							case "UoMSwapAlter_desc":
                                query = isOrdered ? ordered.ThenByDescending(o => o.UoMSwapAlter) : query.OrderByDescending(o => o.UoMSwapAlter);
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

        public static IQueryable<tbl_SALE_OrderDetail> _pagingBuilder(IQueryable<tbl_SALE_OrderDetail> query, Dictionary<string, string> QueryStrings)
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






