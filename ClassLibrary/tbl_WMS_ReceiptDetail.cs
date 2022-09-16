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
    
    
    public partial class tbl_WMS_ReceiptDetail
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public tbl_WMS_ReceiptDetail()
        {
            this.tbl_WMS_ReceiptPalletization = new HashSet<tbl_WMS_ReceiptPalletization>();
        }
    
        public int IDReceipt { get; set; }
        public Nullable<int> IDPO { get; set; }
        public Nullable<int> IDPOLine { get; set; }
        public int IDItem { get; set; }
        public int Id { get; set; }
        public string Code { get; set; }
        public string Remark { get; set; }
        public string ForeignRemark { get; set; }
        public string ExternalReceipt { get; set; }
        public string ExternalLine { get; set; }
        public string Status { get; set; }
        public Nullable<System.DateTime> ReceivedDate { get; set; }
        public int IDUoM { get; set; }
        public decimal UoMQuantityExpected { get; set; }
        public decimal QuantityExpected { get; set; }
        public decimal QuantityAdjusted { get; set; }
        public decimal QuantityReceived { get; set; }
        public decimal QuantityRejected { get; set; }
        public decimal Cube { get; set; }
        public decimal GrossWeight { get; set; }
        public decimal NetWeight { get; set; }
        public string Lottable0 { get; set; }
        public string Lottable1 { get; set; }
        public string Lottable2 { get; set; }
        public string Lottable3 { get; set; }
        public string Lottable4 { get; set; }
        public Nullable<System.DateTime> Lottable5 { get; set; }
        public Nullable<System.DateTime> Lottable6 { get; set; }
        public Nullable<System.DateTime> Lottable7 { get; set; }
        public Nullable<System.DateTime> Lottable8 { get; set; }
        public Nullable<System.DateTime> Lottable9 { get; set; }
        public bool IsDeleted { get; set; }
        public string CreatedBy { get; set; }
        public string ModifiedBy { get; set; }
        public System.DateTime CreatedDate { get; set; }
        public System.DateTime ModifiedDate { get; set; }
        //List 0:1
        public virtual tbl_WMS_Item tbl_WMS_Item { get; set; }
        //List 0:1
        public virtual tbl_WMS_ItemUoM tbl_WMS_ItemUoM { get; set; }
        //List 0:1
        public virtual tbl_WMS_Receipt tbl_WMS_Receipt { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tbl_WMS_ReceiptPalletization> tbl_WMS_ReceiptPalletization { get; set; }
    }
}


namespace DTOModel
{
	using System;
	public partial class DTO_WMS_ReceiptDetail
	{
		public int IDReceipt { get; set; }
		public Nullable<int> IDPO { get; set; }
		public Nullable<int> IDPOLine { get; set; }
		public int IDItem { get; set; }
		public int Id { get; set; }
		public string Code { get; set; }
		public string Remark { get; set; }
		public string ForeignRemark { get; set; }
		public string ExternalReceipt { get; set; }
		public string ExternalLine { get; set; }
		public string Status { get; set; }
		public Nullable<System.DateTime> ReceivedDate { get; set; }
		public int IDUoM { get; set; }
		public decimal UoMQuantityExpected { get; set; }
		public decimal QuantityExpected { get; set; }
		public decimal QuantityAdjusted { get; set; }
		public decimal QuantityReceived { get; set; }
		public decimal QuantityRejected { get; set; }
		public decimal Cube { get; set; }
		public decimal GrossWeight { get; set; }
		public decimal NetWeight { get; set; }
		public string Lottable0 { get; set; }
		public string Lottable1 { get; set; }
		public string Lottable2 { get; set; }
		public string Lottable3 { get; set; }
		public string Lottable4 { get; set; }
		public Nullable<System.DateTime> Lottable5 { get; set; }
		public Nullable<System.DateTime> Lottable6 { get; set; }
		public Nullable<System.DateTime> Lottable7 { get; set; }
		public Nullable<System.DateTime> Lottable8 { get; set; }
		public Nullable<System.DateTime> Lottable9 { get; set; }
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

    public static partial class BS_WMS_ReceiptDetail 
    {
        public static dynamic getSearch(AppEntities db, int IDBranch, int StaffID, Dictionary<string, string> QueryStrings)
        {
            return get(db, IDBranch,StaffID, QueryStrings);
        }

		public static IQueryable<DTO_WMS_ReceiptDetail> get(AppEntities db, int IDBranch, int StaffID, Dictionary<string, string> QueryStrings)
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
            package.Workbook.Properties.Title = "ART-DMS WMS_ReceiptDetail";
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

		public static DTO_WMS_ReceiptDetail getAnItem(AppEntities db, int IDBranch, int StaffID, int id)
        {
            var dbResult = db.tbl_WMS_ReceiptDetail.Find(id);

			return toDTO(dbResult);
			
        }
		
		public static DTO_WMS_ReceiptDetail getAnItemByCode(AppEntities db, int IDBranch, int StaffID, string code)
        {
            var dbResult = db.tbl_WMS_ReceiptDetail
			.FirstOrDefault(d => d.IsDeleted == false && d.Code == code );

			return toDTO(dbResult);
			
        }

		public static bool put(AppEntities db, int IDBranch, int StaffID, int Id, dynamic item, string Username, Dictionary<string, string> QueryStrings)
        {
            bool result = false;
            var dbitem = db.tbl_WMS_ReceiptDetail.Find(Id);
            
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
					errorLog.logMessage("put_WMS_ReceiptDetail",e);
                    result = false;
                }
            }
            else
                if (QueryStrings.Any(d => d.Key == "ForceCreate"))
                    result =  post(db, IDBranch, StaffID, item, Username) != null;
                
            return result;
        }

        public static void patchDynamicToDB(dynamic item, tbl_WMS_ReceiptDetail dbitem, string Username)
        {
            Type type = typeof(tbl_WMS_ReceiptDetail);
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

        public static void patchDTOtoDBValue( DTO_WMS_ReceiptDetail item, tbl_WMS_ReceiptDetail dbitem)
        {
            if (item == null){
                dbitem = null;
                return;
            }
            							
			dbitem.IDReceipt = item.IDReceipt;							
			dbitem.IDPO = item.IDPO;							
			dbitem.IDPOLine = item.IDPOLine;							
			dbitem.IDItem = item.IDItem;							
			dbitem.Code = item.Code;							
			dbitem.Remark = item.Remark;							
			dbitem.ForeignRemark = item.ForeignRemark;							
			dbitem.ExternalReceipt = item.ExternalReceipt;							
			dbitem.ExternalLine = item.ExternalLine;							
			dbitem.Status = item.Status;							
			dbitem.ReceivedDate = item.ReceivedDate;							
			dbitem.IDUoM = item.IDUoM;							
			dbitem.UoMQuantityExpected = item.UoMQuantityExpected;							
			dbitem.QuantityExpected = item.QuantityExpected;							
			dbitem.QuantityAdjusted = item.QuantityAdjusted;							
			dbitem.QuantityReceived = item.QuantityReceived;							
			dbitem.QuantityRejected = item.QuantityRejected;							
			dbitem.Cube = item.Cube;							
			dbitem.GrossWeight = item.GrossWeight;							
			dbitem.NetWeight = item.NetWeight;							
			dbitem.Lottable0 = item.Lottable0;							
			dbitem.Lottable1 = item.Lottable1;							
			dbitem.Lottable2 = item.Lottable2;							
			dbitem.Lottable3 = item.Lottable3;							
			dbitem.Lottable4 = item.Lottable4;							
			dbitem.Lottable5 = item.Lottable5;							
			dbitem.Lottable6 = item.Lottable6;							
			dbitem.Lottable7 = item.Lottable7;							
			dbitem.Lottable8 = item.Lottable8;							
			dbitem.Lottable9 = item.Lottable9;							
			dbitem.IsDeleted = item.IsDeleted;        }

		public static DTO_WMS_ReceiptDetail post(AppEntities db, int IDBranch, int StaffID, dynamic item, string Username)
        {
            tbl_WMS_ReceiptDetail dbitem = new tbl_WMS_ReceiptDetail();
            if (item != null)
            {
                patchDynamicToDB(item, dbitem, Username);
                
				dbitem.CreatedBy = Username;
				dbitem.CreatedDate = DateTime.Now;				
                try
                {
					db.tbl_WMS_ReceiptDetail.Add(dbitem);
                    db.SaveChanges();
				
                }
                catch (DbEntityValidationException e)
                {
					errorLog.logMessage("post_WMS_ReceiptDetail",e);
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
                Type type = Type.GetType("BaseBusiness.BS_WMS_ReceiptDetail, ClassLibrary");
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
                        var target = new tbl_WMS_ReceiptDetail();
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
                    
                    tbl_WMS_ReceiptDetail dbitem = new tbl_WMS_ReceiptDetail();
                    if (it.Id == null || string.IsNullOrEmpty(it.Id.Value) || it.Id == "0")
                    {
                        dbitem = new tbl_WMS_ReceiptDetail();
                        dbitem.CreatedBy = Username;
				        dbitem.CreatedDate = DateTime.Now;
                                            }
                    else
                    {
                        dbitem = db.tbl_WMS_ReceiptDetail.Find((int)it.Id);
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
                        
                        if (dbitem.Id == 0) db.tbl_WMS_ReceiptDetail.Add(dbitem);
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
                    errorLog.logMessage("post_WMS_ReceiptDetail",e);
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

            var dbitems = db.tbl_WMS_ReceiptDetail.Where(d => IDs.Contains(d.Id));
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
			
                BS_Version.update_Version(db, null, "DTO_WMS_ReceiptDetail", updateDate, Username);
			
            }
            catch (DbEntityValidationException e)
            {
				errorLog.logMessage("delete_WMS_ReceiptDetail",e);
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
             
            return db.tbl_WMS_ReceiptDetail.Any(e => e.Id == id && e.IsDeleted == false);
            
		}
		
		public static bool check_Exists(AppEntities db, string Code)
		{
             
            return db.tbl_WMS_ReceiptDetail.Any(e => e.Code == Code && e.IsDeleted == false);
            
		}
		
		//---//
		public static IQueryable<DTO_WMS_ReceiptDetail> toDTO(IQueryable<tbl_WMS_ReceiptDetail> query)
        {
			return query
			.Select(s => new DTO_WMS_ReceiptDetail(){							
				IDReceipt = s.IDReceipt,							
				IDPO = s.IDPO,							
				IDPOLine = s.IDPOLine,							
				IDItem = s.IDItem,							
				Id = s.Id,							
				Code = s.Code,							
				Remark = s.Remark,							
				ForeignRemark = s.ForeignRemark,							
				ExternalReceipt = s.ExternalReceipt,							
				ExternalLine = s.ExternalLine,							
				Status = s.Status,							
				ReceivedDate = s.ReceivedDate,							
				IDUoM = s.IDUoM,							
				UoMQuantityExpected = s.UoMQuantityExpected,							
				QuantityExpected = s.QuantityExpected,							
				QuantityAdjusted = s.QuantityAdjusted,							
				QuantityReceived = s.QuantityReceived,							
				QuantityRejected = s.QuantityRejected,							
				Cube = s.Cube,							
				GrossWeight = s.GrossWeight,							
				NetWeight = s.NetWeight,							
				Lottable0 = s.Lottable0,							
				Lottable1 = s.Lottable1,							
				Lottable2 = s.Lottable2,							
				Lottable3 = s.Lottable3,							
				Lottable4 = s.Lottable4,							
				Lottable5 = s.Lottable5,							
				Lottable6 = s.Lottable6,							
				Lottable7 = s.Lottable7,							
				Lottable8 = s.Lottable8,							
				Lottable9 = s.Lottable9,							
				IsDeleted = s.IsDeleted,							
				CreatedBy = s.CreatedBy,							
				ModifiedBy = s.ModifiedBy,							
				CreatedDate = s.CreatedDate,							
				ModifiedDate = s.ModifiedDate,					
			});//;
                              
        }

		public static DTO_WMS_ReceiptDetail toDTO(tbl_WMS_ReceiptDetail dbResult)
        {
			if (dbResult != null)
			{
				return new DTO_WMS_ReceiptDetail()
				{							
					IDReceipt = dbResult.IDReceipt,							
					IDPO = dbResult.IDPO,							
					IDPOLine = dbResult.IDPOLine,							
					IDItem = dbResult.IDItem,							
					Id = dbResult.Id,							
					Code = dbResult.Code,							
					Remark = dbResult.Remark,							
					ForeignRemark = dbResult.ForeignRemark,							
					ExternalReceipt = dbResult.ExternalReceipt,							
					ExternalLine = dbResult.ExternalLine,							
					Status = dbResult.Status,							
					ReceivedDate = dbResult.ReceivedDate,							
					IDUoM = dbResult.IDUoM,							
					UoMQuantityExpected = dbResult.UoMQuantityExpected,							
					QuantityExpected = dbResult.QuantityExpected,							
					QuantityAdjusted = dbResult.QuantityAdjusted,							
					QuantityReceived = dbResult.QuantityReceived,							
					QuantityRejected = dbResult.QuantityRejected,							
					Cube = dbResult.Cube,							
					GrossWeight = dbResult.GrossWeight,							
					NetWeight = dbResult.NetWeight,							
					Lottable0 = dbResult.Lottable0,							
					Lottable1 = dbResult.Lottable1,							
					Lottable2 = dbResult.Lottable2,							
					Lottable3 = dbResult.Lottable3,							
					Lottable4 = dbResult.Lottable4,							
					Lottable5 = dbResult.Lottable5,							
					Lottable6 = dbResult.Lottable6,							
					Lottable7 = dbResult.Lottable7,							
					Lottable8 = dbResult.Lottable8,							
					Lottable9 = dbResult.Lottable9,							
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

		public static IQueryable<tbl_WMS_ReceiptDetail> _queryBuilder(AppEntities db, int IDBranch, int StaffID, Dictionary<string, string> QueryStrings)
        {
            
			IQueryable<tbl_WMS_ReceiptDetail> query = db.tbl_WMS_ReceiptDetail.AsNoTracking();//.Where(d => d.IsDeleted == false );
			

			//Query keyword
			if (QueryStrings.Any(d => d.Key == "Keyword") && !string.IsNullOrEmpty(QueryStrings.FirstOrDefault(d => d.Key == "Keyword").Value))
            {
                var keyword = QueryStrings.FirstOrDefault(d => d.Key == "Keyword").Value;
                query = query.Where(d=>d.Code.Contains(keyword));
            }



			//Query IDReceipt (int)
			if (QueryStrings.Any(d => d.Key == "IDReceipt"))
            {
                var IDList = QueryStrings.FirstOrDefault(d => d.Key == "IDReceipt").Value.Replace("[", "").Replace("]", "").Split(',');
                List<int> IDs = new List<int>();
                foreach (var item in IDList)
                    if (int.TryParse(item, out int i))
                        IDs.Add(i);
                if (IDs.Count > 0)
                    query = query.Where(d => IDs.Contains(d.IDReceipt));
            }

			//Query IDPO (Nullable<int>)
			if (QueryStrings.Any(d => d.Key == "IDPO"))
            {
                var IDList = QueryStrings.FirstOrDefault(d => d.Key == "IDPO").Value.Replace("[", "").Replace("]", "").Split(',');
                List<int?> IDs = new List<int?>();
                foreach (var item in IDList)
                    if (int.TryParse(item, out int i))
                        IDs.Add(i);
					else if (item == "null")
						IDs.Add(null);
                if (IDs.Count > 0)
                    query = query.Where(d => IDs.Contains(d.IDPO));
////                    query = query.Where(d => IDs.Contains(d.IDPO));
//                    
            }

			//Query IDPOLine (Nullable<int>)
			if (QueryStrings.Any(d => d.Key == "IDPOLine"))
            {
                var IDList = QueryStrings.FirstOrDefault(d => d.Key == "IDPOLine").Value.Replace("[", "").Replace("]", "").Split(',');
                List<int?> IDs = new List<int?>();
                foreach (var item in IDList)
                    if (int.TryParse(item, out int i))
                        IDs.Add(i);
					else if (item == "null")
						IDs.Add(null);
                if (IDs.Count > 0)
                    query = query.Where(d => IDs.Contains(d.IDPOLine));
////                    query = query.Where(d => IDs.Contains(d.IDPOLine));
//                    
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
            

			//Query ExternalReceipt (string)
			if (QueryStrings.Any(d => d.Key == "ExternalReceipt_eq") && !string.IsNullOrEmpty(QueryStrings.FirstOrDefault(d => d.Key == "ExternalReceipt_eq").Value))
            {
                var keyword = QueryStrings.FirstOrDefault(d => d.Key == "ExternalReceipt_eq").Value;
                query = query.Where(d=>d.ExternalReceipt == keyword);
            }
            if (QueryStrings.Any(d => d.Key == "ExternalReceipt") && !string.IsNullOrEmpty(QueryStrings.FirstOrDefault(d => d.Key == "ExternalReceipt").Value))
            {
                var keyword = QueryStrings.FirstOrDefault(d => d.Key == "ExternalReceipt").Value;
                query = query.Where(d=>d.ExternalReceipt.Contains(keyword));
            }
            

			//Query ExternalLine (string)
			if (QueryStrings.Any(d => d.Key == "ExternalLine_eq") && !string.IsNullOrEmpty(QueryStrings.FirstOrDefault(d => d.Key == "ExternalLine_eq").Value))
            {
                var keyword = QueryStrings.FirstOrDefault(d => d.Key == "ExternalLine_eq").Value;
                query = query.Where(d=>d.ExternalLine == keyword);
            }
            if (QueryStrings.Any(d => d.Key == "ExternalLine") && !string.IsNullOrEmpty(QueryStrings.FirstOrDefault(d => d.Key == "ExternalLine").Value))
            {
                var keyword = QueryStrings.FirstOrDefault(d => d.Key == "ExternalLine").Value;
                query = query.Where(d=>d.ExternalLine.Contains(keyword));
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
            

			//Query ReceivedDate (Nullable<System.DateTime>)
			if (QueryStrings.Any(d => d.Key == "ReceivedDateFrom") && QueryStrings.Any(d => d.Key == "ReceivedDateTo"))
                if (DateTime.TryParse(QueryStrings.FirstOrDefault(d => d.Key == "ReceivedDateFrom").Value, out DateTime fromDate) && DateTime.TryParse(QueryStrings.FirstOrDefault(d => d.Key == "ReceivedDateTo").Value, out DateTime toDate))
                    query = query.Where(d => fromDate <= d.ReceivedDate && d.ReceivedDate <= toDate);

            if (QueryStrings.Any(d => d.Key == "ReceivedDate"))
                if (DateTime.TryParse(QueryStrings.FirstOrDefault(d => d.Key == "ReceivedDate").Value, out DateTime val))
                    query = query.Where(d => d.ReceivedDate != null && DbFunctions.TruncateTime(val) == DbFunctions.TruncateTime(d.ReceivedDate));


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


			//Query Lottable0 (string)
			if (QueryStrings.Any(d => d.Key == "Lottable0_eq") && !string.IsNullOrEmpty(QueryStrings.FirstOrDefault(d => d.Key == "Lottable0_eq").Value))
            {
                var keyword = QueryStrings.FirstOrDefault(d => d.Key == "Lottable0_eq").Value;
                query = query.Where(d=>d.Lottable0 == keyword);
            }
            if (QueryStrings.Any(d => d.Key == "Lottable0") && !string.IsNullOrEmpty(QueryStrings.FirstOrDefault(d => d.Key == "Lottable0").Value))
            {
                var keyword = QueryStrings.FirstOrDefault(d => d.Key == "Lottable0").Value;
                query = query.Where(d=>d.Lottable0.Contains(keyword));
            }
            

			//Query Lottable1 (string)
			if (QueryStrings.Any(d => d.Key == "Lottable1_eq") && !string.IsNullOrEmpty(QueryStrings.FirstOrDefault(d => d.Key == "Lottable1_eq").Value))
            {
                var keyword = QueryStrings.FirstOrDefault(d => d.Key == "Lottable1_eq").Value;
                query = query.Where(d=>d.Lottable1 == keyword);
            }
            if (QueryStrings.Any(d => d.Key == "Lottable1") && !string.IsNullOrEmpty(QueryStrings.FirstOrDefault(d => d.Key == "Lottable1").Value))
            {
                var keyword = QueryStrings.FirstOrDefault(d => d.Key == "Lottable1").Value;
                query = query.Where(d=>d.Lottable1.Contains(keyword));
            }
            

			//Query Lottable2 (string)
			if (QueryStrings.Any(d => d.Key == "Lottable2_eq") && !string.IsNullOrEmpty(QueryStrings.FirstOrDefault(d => d.Key == "Lottable2_eq").Value))
            {
                var keyword = QueryStrings.FirstOrDefault(d => d.Key == "Lottable2_eq").Value;
                query = query.Where(d=>d.Lottable2 == keyword);
            }
            if (QueryStrings.Any(d => d.Key == "Lottable2") && !string.IsNullOrEmpty(QueryStrings.FirstOrDefault(d => d.Key == "Lottable2").Value))
            {
                var keyword = QueryStrings.FirstOrDefault(d => d.Key == "Lottable2").Value;
                query = query.Where(d=>d.Lottable2.Contains(keyword));
            }
            

			//Query Lottable3 (string)
			if (QueryStrings.Any(d => d.Key == "Lottable3_eq") && !string.IsNullOrEmpty(QueryStrings.FirstOrDefault(d => d.Key == "Lottable3_eq").Value))
            {
                var keyword = QueryStrings.FirstOrDefault(d => d.Key == "Lottable3_eq").Value;
                query = query.Where(d=>d.Lottable3 == keyword);
            }
            if (QueryStrings.Any(d => d.Key == "Lottable3") && !string.IsNullOrEmpty(QueryStrings.FirstOrDefault(d => d.Key == "Lottable3").Value))
            {
                var keyword = QueryStrings.FirstOrDefault(d => d.Key == "Lottable3").Value;
                query = query.Where(d=>d.Lottable3.Contains(keyword));
            }
            

			//Query Lottable4 (string)
			if (QueryStrings.Any(d => d.Key == "Lottable4_eq") && !string.IsNullOrEmpty(QueryStrings.FirstOrDefault(d => d.Key == "Lottable4_eq").Value))
            {
                var keyword = QueryStrings.FirstOrDefault(d => d.Key == "Lottable4_eq").Value;
                query = query.Where(d=>d.Lottable4 == keyword);
            }
            if (QueryStrings.Any(d => d.Key == "Lottable4") && !string.IsNullOrEmpty(QueryStrings.FirstOrDefault(d => d.Key == "Lottable4").Value))
            {
                var keyword = QueryStrings.FirstOrDefault(d => d.Key == "Lottable4").Value;
                query = query.Where(d=>d.Lottable4.Contains(keyword));
            }
            

			//Query Lottable5 (Nullable<System.DateTime>)
			if (QueryStrings.Any(d => d.Key == "Lottable5From") && QueryStrings.Any(d => d.Key == "Lottable5To"))
                if (DateTime.TryParse(QueryStrings.FirstOrDefault(d => d.Key == "Lottable5From").Value, out DateTime fromDate) && DateTime.TryParse(QueryStrings.FirstOrDefault(d => d.Key == "Lottable5To").Value, out DateTime toDate))
                    query = query.Where(d => fromDate <= d.Lottable5 && d.Lottable5 <= toDate);

            if (QueryStrings.Any(d => d.Key == "Lottable5"))
                if (DateTime.TryParse(QueryStrings.FirstOrDefault(d => d.Key == "Lottable5").Value, out DateTime val))
                    query = query.Where(d => d.Lottable5 != null && DbFunctions.TruncateTime(val) == DbFunctions.TruncateTime(d.Lottable5));


			//Query Lottable6 (Nullable<System.DateTime>)
			if (QueryStrings.Any(d => d.Key == "Lottable6From") && QueryStrings.Any(d => d.Key == "Lottable6To"))
                if (DateTime.TryParse(QueryStrings.FirstOrDefault(d => d.Key == "Lottable6From").Value, out DateTime fromDate) && DateTime.TryParse(QueryStrings.FirstOrDefault(d => d.Key == "Lottable6To").Value, out DateTime toDate))
                    query = query.Where(d => fromDate <= d.Lottable6 && d.Lottable6 <= toDate);

            if (QueryStrings.Any(d => d.Key == "Lottable6"))
                if (DateTime.TryParse(QueryStrings.FirstOrDefault(d => d.Key == "Lottable6").Value, out DateTime val))
                    query = query.Where(d => d.Lottable6 != null && DbFunctions.TruncateTime(val) == DbFunctions.TruncateTime(d.Lottable6));


			//Query Lottable7 (Nullable<System.DateTime>)
			if (QueryStrings.Any(d => d.Key == "Lottable7From") && QueryStrings.Any(d => d.Key == "Lottable7To"))
                if (DateTime.TryParse(QueryStrings.FirstOrDefault(d => d.Key == "Lottable7From").Value, out DateTime fromDate) && DateTime.TryParse(QueryStrings.FirstOrDefault(d => d.Key == "Lottable7To").Value, out DateTime toDate))
                    query = query.Where(d => fromDate <= d.Lottable7 && d.Lottable7 <= toDate);

            if (QueryStrings.Any(d => d.Key == "Lottable7"))
                if (DateTime.TryParse(QueryStrings.FirstOrDefault(d => d.Key == "Lottable7").Value, out DateTime val))
                    query = query.Where(d => d.Lottable7 != null && DbFunctions.TruncateTime(val) == DbFunctions.TruncateTime(d.Lottable7));


			//Query Lottable8 (Nullable<System.DateTime>)
			if (QueryStrings.Any(d => d.Key == "Lottable8From") && QueryStrings.Any(d => d.Key == "Lottable8To"))
                if (DateTime.TryParse(QueryStrings.FirstOrDefault(d => d.Key == "Lottable8From").Value, out DateTime fromDate) && DateTime.TryParse(QueryStrings.FirstOrDefault(d => d.Key == "Lottable8To").Value, out DateTime toDate))
                    query = query.Where(d => fromDate <= d.Lottable8 && d.Lottable8 <= toDate);

            if (QueryStrings.Any(d => d.Key == "Lottable8"))
                if (DateTime.TryParse(QueryStrings.FirstOrDefault(d => d.Key == "Lottable8").Value, out DateTime val))
                    query = query.Where(d => d.Lottable8 != null && DbFunctions.TruncateTime(val) == DbFunctions.TruncateTime(d.Lottable8));


			//Query Lottable9 (Nullable<System.DateTime>)
			if (QueryStrings.Any(d => d.Key == "Lottable9From") && QueryStrings.Any(d => d.Key == "Lottable9To"))
                if (DateTime.TryParse(QueryStrings.FirstOrDefault(d => d.Key == "Lottable9From").Value, out DateTime fromDate) && DateTime.TryParse(QueryStrings.FirstOrDefault(d => d.Key == "Lottable9To").Value, out DateTime toDate))
                    query = query.Where(d => fromDate <= d.Lottable9 && d.Lottable9 <= toDate);

            if (QueryStrings.Any(d => d.Key == "Lottable9"))
                if (DateTime.TryParse(QueryStrings.FirstOrDefault(d => d.Key == "Lottable9").Value, out DateTime val))
                    query = query.Where(d => d.Lottable9 != null && DbFunctions.TruncateTime(val) == DbFunctions.TruncateTime(d.Lottable9));


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
		
        public static IQueryable<tbl_WMS_ReceiptDetail> _sortBuilder(IQueryable<tbl_WMS_ReceiptDetail> query, Dictionary<string, string> QueryStrings)
        {
            if (QueryStrings.Any(d => d.Key == "SortBy"))
            {
                var sorts = QueryStrings.FirstOrDefault(d => d.Key == "SortBy").Value.Replace("[", "").Replace("]", "").Split(',');
                
                foreach (var item in sorts)
                    if (!string.IsNullOrEmpty(item))
                    {
                        var ordered = query as IOrderedQueryable<tbl_WMS_ReceiptDetail>;
                        bool isOrdered = ordered.ToString().IndexOf("ORDER BY") !=-1;

                        switch (item)
                        {
							case "IDReceipt":
								query = isOrdered ? ordered.ThenBy(o => o.IDReceipt) : query.OrderBy(o => o.IDReceipt);
								 break;
							case "IDReceipt_desc":
                                query = isOrdered ? ordered.ThenByDescending(o => o.IDReceipt) : query.OrderByDescending(o => o.IDReceipt);
                                break;
							case "IDPO":
								query = isOrdered ? ordered.ThenBy(o => o.IDPO) : query.OrderBy(o => o.IDPO);
								 break;
							case "IDPO_desc":
                                query = isOrdered ? ordered.ThenByDescending(o => o.IDPO) : query.OrderByDescending(o => o.IDPO);
                                break;
							case "IDPOLine":
								query = isOrdered ? ordered.ThenBy(o => o.IDPOLine) : query.OrderBy(o => o.IDPOLine);
								 break;
							case "IDPOLine_desc":
                                query = isOrdered ? ordered.ThenByDescending(o => o.IDPOLine) : query.OrderByDescending(o => o.IDPOLine);
                                break;
							case "IDItem":
								query = isOrdered ? ordered.ThenBy(o => o.IDItem) : query.OrderBy(o => o.IDItem);
								 break;
							case "IDItem_desc":
                                query = isOrdered ? ordered.ThenByDescending(o => o.IDItem) : query.OrderByDescending(o => o.IDItem);
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
							case "ExternalReceipt":
								query = isOrdered ? ordered.ThenBy(o => o.ExternalReceipt) : query.OrderBy(o => o.ExternalReceipt);
								 break;
							case "ExternalReceipt_desc":
                                query = isOrdered ? ordered.ThenByDescending(o => o.ExternalReceipt) : query.OrderByDescending(o => o.ExternalReceipt);
                                break;
							case "ExternalLine":
								query = isOrdered ? ordered.ThenBy(o => o.ExternalLine) : query.OrderBy(o => o.ExternalLine);
								 break;
							case "ExternalLine_desc":
                                query = isOrdered ? ordered.ThenByDescending(o => o.ExternalLine) : query.OrderByDescending(o => o.ExternalLine);
                                break;
							case "Status":
								query = isOrdered ? ordered.ThenBy(o => o.Status) : query.OrderBy(o => o.Status);
								 break;
							case "Status_desc":
                                query = isOrdered ? ordered.ThenByDescending(o => o.Status) : query.OrderByDescending(o => o.Status);
                                break;
							case "ReceivedDate":
								query = isOrdered ? ordered.ThenBy(o => o.ReceivedDate) : query.OrderBy(o => o.ReceivedDate);
								 break;
							case "ReceivedDate_desc":
                                query = isOrdered ? ordered.ThenByDescending(o => o.ReceivedDate) : query.OrderByDescending(o => o.ReceivedDate);
                                break;
							case "IDUoM":
								query = isOrdered ? ordered.ThenBy(o => o.IDUoM) : query.OrderBy(o => o.IDUoM);
								 break;
							case "IDUoM_desc":
                                query = isOrdered ? ordered.ThenByDescending(o => o.IDUoM) : query.OrderByDescending(o => o.IDUoM);
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
							case "Lottable0":
								query = isOrdered ? ordered.ThenBy(o => o.Lottable0) : query.OrderBy(o => o.Lottable0);
								 break;
							case "Lottable0_desc":
                                query = isOrdered ? ordered.ThenByDescending(o => o.Lottable0) : query.OrderByDescending(o => o.Lottable0);
                                break;
							case "Lottable1":
								query = isOrdered ? ordered.ThenBy(o => o.Lottable1) : query.OrderBy(o => o.Lottable1);
								 break;
							case "Lottable1_desc":
                                query = isOrdered ? ordered.ThenByDescending(o => o.Lottable1) : query.OrderByDescending(o => o.Lottable1);
                                break;
							case "Lottable2":
								query = isOrdered ? ordered.ThenBy(o => o.Lottable2) : query.OrderBy(o => o.Lottable2);
								 break;
							case "Lottable2_desc":
                                query = isOrdered ? ordered.ThenByDescending(o => o.Lottable2) : query.OrderByDescending(o => o.Lottable2);
                                break;
							case "Lottable3":
								query = isOrdered ? ordered.ThenBy(o => o.Lottable3) : query.OrderBy(o => o.Lottable3);
								 break;
							case "Lottable3_desc":
                                query = isOrdered ? ordered.ThenByDescending(o => o.Lottable3) : query.OrderByDescending(o => o.Lottable3);
                                break;
							case "Lottable4":
								query = isOrdered ? ordered.ThenBy(o => o.Lottable4) : query.OrderBy(o => o.Lottable4);
								 break;
							case "Lottable4_desc":
                                query = isOrdered ? ordered.ThenByDescending(o => o.Lottable4) : query.OrderByDescending(o => o.Lottable4);
                                break;
							case "Lottable5":
								query = isOrdered ? ordered.ThenBy(o => o.Lottable5) : query.OrderBy(o => o.Lottable5);
								 break;
							case "Lottable5_desc":
                                query = isOrdered ? ordered.ThenByDescending(o => o.Lottable5) : query.OrderByDescending(o => o.Lottable5);
                                break;
							case "Lottable6":
								query = isOrdered ? ordered.ThenBy(o => o.Lottable6) : query.OrderBy(o => o.Lottable6);
								 break;
							case "Lottable6_desc":
                                query = isOrdered ? ordered.ThenByDescending(o => o.Lottable6) : query.OrderByDescending(o => o.Lottable6);
                                break;
							case "Lottable7":
								query = isOrdered ? ordered.ThenBy(o => o.Lottable7) : query.OrderBy(o => o.Lottable7);
								 break;
							case "Lottable7_desc":
                                query = isOrdered ? ordered.ThenByDescending(o => o.Lottable7) : query.OrderByDescending(o => o.Lottable7);
                                break;
							case "Lottable8":
								query = isOrdered ? ordered.ThenBy(o => o.Lottable8) : query.OrderBy(o => o.Lottable8);
								 break;
							case "Lottable8_desc":
                                query = isOrdered ? ordered.ThenByDescending(o => o.Lottable8) : query.OrderByDescending(o => o.Lottable8);
                                break;
							case "Lottable9":
								query = isOrdered ? ordered.ThenBy(o => o.Lottable9) : query.OrderBy(o => o.Lottable9);
								 break;
							case "Lottable9_desc":
                                query = isOrdered ? ordered.ThenByDescending(o => o.Lottable9) : query.OrderByDescending(o => o.Lottable9);
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

        public static IQueryable<tbl_WMS_ReceiptDetail> _pagingBuilder(IQueryable<tbl_WMS_ReceiptDetail> query, Dictionary<string, string> QueryStrings)
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






