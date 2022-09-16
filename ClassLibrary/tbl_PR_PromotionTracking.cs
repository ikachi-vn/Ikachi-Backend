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
    
    
    public partial class tbl_PR_PromotionTracking
    {
        public int Id { get; set; }
        public string MaNVBH { get; set; }
        public string TenNVBH { get; set; }
        public string MaKH { get; set; }
        public string TenKH { get; set; }
        public string DiaChi { get; set; }
        public string MaDH { get; set; }
        public string TrangThai { get; set; }
        public Nullable<System.DateTime> NgayDonHang { get; set; }
        public Nullable<System.DateTime> NgayHoaDon { get; set; }
        public Nullable<System.DateTime> ClaimDate { get; set; }
        public string TenChuongTrinh { get; set; }
        public string MaSP { get; set; }
        public string TenSP { get; set; }
        public Nullable<int> SoThung { get; set; }
        public Nullable<int> SoLe { get; set; }
        public int TongLe { get; set; }
        public double ChietKhau { get; set; }
    }
}


namespace DTOModel
{
	using System;
	public partial class DTO_PR_PromotionTracking
	{
		public int Id { get; set; }
		public string MaNVBH { get; set; }
		public string TenNVBH { get; set; }
		public string MaKH { get; set; }
		public string TenKH { get; set; }
		public string DiaChi { get; set; }
		public string MaDH { get; set; }
		public string TrangThai { get; set; }
		public Nullable<System.DateTime> NgayDonHang { get; set; }
		public Nullable<System.DateTime> NgayHoaDon { get; set; }
		public Nullable<System.DateTime> ClaimDate { get; set; }
		public string TenChuongTrinh { get; set; }
		public string MaSP { get; set; }
		public string TenSP { get; set; }
		public Nullable<int> SoThung { get; set; }
		public Nullable<int> SoLe { get; set; }
		public int TongLe { get; set; }
		public double ChietKhau { get; set; }
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

    public static partial class BS_PR_PromotionTracking 
    {
        public static dynamic getSearch(AppEntities db, int IDBranch, int StaffID, Dictionary<string, string> QueryStrings)
        {
            return get(db, IDBranch,StaffID, QueryStrings);
        }

		public static IQueryable<DTO_PR_PromotionTracking> get(AppEntities db, int IDBranch, int StaffID, Dictionary<string, string> QueryStrings)
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
            package.Workbook.Properties.Title = "ART-DMS PR_PromotionTracking";
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

		public static DTO_PR_PromotionTracking getAnItem(AppEntities db, int IDBranch, int StaffID, int id)
        {
            var dbResult = db.tbl_PR_PromotionTracking.Find(id);

			return toDTO(dbResult);
			
        }
		

		public static bool put(AppEntities db, int IDBranch, int StaffID, int Id, dynamic item, string Username, Dictionary<string, string> QueryStrings)
        {
            bool result = false;
            var dbitem = db.tbl_PR_PromotionTracking.Find(Id);
            
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
					errorLog.logMessage("put_PR_PromotionTracking",e);
                    result = false;
                }
            }
            else
                if (QueryStrings.Any(d => d.Key == "ForceCreate"))
                    result =  post(db, IDBranch, StaffID, item, Username) != null;
                
            return result;
        }

        public static void patchDynamicToDB(dynamic item, tbl_PR_PromotionTracking dbitem, string Username)
        {
            Type type = typeof(tbl_PR_PromotionTracking);
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

            
        }

        public static void patchDTOtoDBValue( DTO_PR_PromotionTracking item, tbl_PR_PromotionTracking dbitem)
        {
            if (item == null){
                dbitem = null;
                return;
            }
            							
			dbitem.MaNVBH = item.MaNVBH;							
			dbitem.TenNVBH = item.TenNVBH;							
			dbitem.MaKH = item.MaKH;							
			dbitem.TenKH = item.TenKH;							
			dbitem.DiaChi = item.DiaChi;							
			dbitem.MaDH = item.MaDH;							
			dbitem.TrangThai = item.TrangThai;							
			dbitem.NgayDonHang = item.NgayDonHang;							
			dbitem.NgayHoaDon = item.NgayHoaDon;							
			dbitem.ClaimDate = item.ClaimDate;							
			dbitem.TenChuongTrinh = item.TenChuongTrinh;							
			dbitem.MaSP = item.MaSP;							
			dbitem.TenSP = item.TenSP;							
			dbitem.SoThung = item.SoThung;							
			dbitem.SoLe = item.SoLe;							
			dbitem.TongLe = item.TongLe;							
			dbitem.ChietKhau = item.ChietKhau;        }

		public static DTO_PR_PromotionTracking post(AppEntities db, int IDBranch, int StaffID, dynamic item, string Username)
        {
            tbl_PR_PromotionTracking dbitem = new tbl_PR_PromotionTracking();
            if (item != null)
            {
                patchDynamicToDB(item, dbitem, Username);
                
								
                try
                {
					db.tbl_PR_PromotionTracking.Add(dbitem);
                    db.SaveChanges();
				
                }
                catch (DbEntityValidationException e)
                {
					errorLog.logMessage("post_PR_PromotionTracking",e);
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
                Type type = Type.GetType("BaseBusiness.BS_PR_PromotionTracking, ClassLibrary");
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
                        var target = new tbl_PR_PromotionTracking();
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
                    
                    tbl_PR_PromotionTracking dbitem = new tbl_PR_PromotionTracking();
                    if (it.Id == null || string.IsNullOrEmpty(it.Id.Value) || it.Id == "0")
                    {
                        dbitem = new tbl_PR_PromotionTracking();
                                            }
                    else
                    {
                        dbitem = db.tbl_PR_PromotionTracking.Find((int)it.Id);
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
                        
                        if (dbitem.Id == 0) db.tbl_PR_PromotionTracking.Add(dbitem);
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
                    errorLog.logMessage("post_PR_PromotionTracking",e);
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

            var dbitems = db.tbl_PR_PromotionTracking.Where(d => IDs.Contains(d.Id));
            var updateDate = DateTime.Now;
            List<int?> IDBranches = new List<int?>();

            foreach (var dbitem in dbitems)
            {
			
				db.tbl_PR_PromotionTracking.Remove(dbitem);
			            
                
            }

            try
            {
                db.SaveChanges();
                result = true;
			
                BS_Version.update_Version(db, null, "DTO_PR_PromotionTracking", updateDate, Username);
			
            }
            catch (DbEntityValidationException e)
            {
				errorLog.logMessage("delete_PR_PromotionTracking",e);
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
            			return db.tbl_PR_PromotionTracking.Any(e => e.Id == id);
            
		}
		
		//---//
		public static IQueryable<DTO_PR_PromotionTracking> toDTO(IQueryable<tbl_PR_PromotionTracking> query)
        {
			return query
			.Select(s => new DTO_PR_PromotionTracking(){							
				Id = s.Id,							
				MaNVBH = s.MaNVBH,							
				TenNVBH = s.TenNVBH,							
				MaKH = s.MaKH,							
				TenKH = s.TenKH,							
				DiaChi = s.DiaChi,							
				MaDH = s.MaDH,							
				TrangThai = s.TrangThai,							
				NgayDonHang = s.NgayDonHang,							
				NgayHoaDon = s.NgayHoaDon,							
				ClaimDate = s.ClaimDate,							
				TenChuongTrinh = s.TenChuongTrinh,							
				MaSP = s.MaSP,							
				TenSP = s.TenSP,							
				SoThung = s.SoThung,							
				SoLe = s.SoLe,							
				TongLe = s.TongLe,							
				ChietKhau = s.ChietKhau,					
			});//;
                              
        }

		public static DTO_PR_PromotionTracking toDTO(tbl_PR_PromotionTracking dbResult)
        {
			if (dbResult != null)
			{
				return new DTO_PR_PromotionTracking()
				{							
					Id = dbResult.Id,							
					MaNVBH = dbResult.MaNVBH,							
					TenNVBH = dbResult.TenNVBH,							
					MaKH = dbResult.MaKH,							
					TenKH = dbResult.TenKH,							
					DiaChi = dbResult.DiaChi,							
					MaDH = dbResult.MaDH,							
					TrangThai = dbResult.TrangThai,							
					NgayDonHang = dbResult.NgayDonHang,							
					NgayHoaDon = dbResult.NgayHoaDon,							
					ClaimDate = dbResult.ClaimDate,							
					TenChuongTrinh = dbResult.TenChuongTrinh,							
					MaSP = dbResult.MaSP,							
					TenSP = dbResult.TenSP,							
					SoThung = dbResult.SoThung,							
					SoLe = dbResult.SoLe,							
					TongLe = dbResult.TongLe,							
					ChietKhau = dbResult.ChietKhau,
				};
			}
			else
				return null; 
        }

		public static IQueryable<tbl_PR_PromotionTracking> _queryBuilder(AppEntities db, int IDBranch, int StaffID, Dictionary<string, string> QueryStrings)
        {
            
			IQueryable<tbl_PR_PromotionTracking> query = db.tbl_PR_PromotionTracking.AsNoTracking();//;
			

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

			//Query MaNVBH (string)
			if (QueryStrings.Any(d => d.Key == "MaNVBH_eq") && !string.IsNullOrEmpty(QueryStrings.FirstOrDefault(d => d.Key == "MaNVBH_eq").Value))
            {
                var keyword = QueryStrings.FirstOrDefault(d => d.Key == "MaNVBH_eq").Value;
                query = query.Where(d=>d.MaNVBH == keyword);
            }
            if (QueryStrings.Any(d => d.Key == "MaNVBH") && !string.IsNullOrEmpty(QueryStrings.FirstOrDefault(d => d.Key == "MaNVBH").Value))
            {
                var keyword = QueryStrings.FirstOrDefault(d => d.Key == "MaNVBH").Value;
                query = query.Where(d=>d.MaNVBH.Contains(keyword));
            }
            

			//Query TenNVBH (string)
			if (QueryStrings.Any(d => d.Key == "TenNVBH_eq") && !string.IsNullOrEmpty(QueryStrings.FirstOrDefault(d => d.Key == "TenNVBH_eq").Value))
            {
                var keyword = QueryStrings.FirstOrDefault(d => d.Key == "TenNVBH_eq").Value;
                query = query.Where(d=>d.TenNVBH == keyword);
            }
            if (QueryStrings.Any(d => d.Key == "TenNVBH") && !string.IsNullOrEmpty(QueryStrings.FirstOrDefault(d => d.Key == "TenNVBH").Value))
            {
                var keyword = QueryStrings.FirstOrDefault(d => d.Key == "TenNVBH").Value;
                query = query.Where(d=>d.TenNVBH.Contains(keyword));
            }
            

			//Query MaKH (string)
			if (QueryStrings.Any(d => d.Key == "MaKH_eq") && !string.IsNullOrEmpty(QueryStrings.FirstOrDefault(d => d.Key == "MaKH_eq").Value))
            {
                var keyword = QueryStrings.FirstOrDefault(d => d.Key == "MaKH_eq").Value;
                query = query.Where(d=>d.MaKH == keyword);
            }
            if (QueryStrings.Any(d => d.Key == "MaKH") && !string.IsNullOrEmpty(QueryStrings.FirstOrDefault(d => d.Key == "MaKH").Value))
            {
                var keyword = QueryStrings.FirstOrDefault(d => d.Key == "MaKH").Value;
                query = query.Where(d=>d.MaKH.Contains(keyword));
            }
            

			//Query TenKH (string)
			if (QueryStrings.Any(d => d.Key == "TenKH_eq") && !string.IsNullOrEmpty(QueryStrings.FirstOrDefault(d => d.Key == "TenKH_eq").Value))
            {
                var keyword = QueryStrings.FirstOrDefault(d => d.Key == "TenKH_eq").Value;
                query = query.Where(d=>d.TenKH == keyword);
            }
            if (QueryStrings.Any(d => d.Key == "TenKH") && !string.IsNullOrEmpty(QueryStrings.FirstOrDefault(d => d.Key == "TenKH").Value))
            {
                var keyword = QueryStrings.FirstOrDefault(d => d.Key == "TenKH").Value;
                query = query.Where(d=>d.TenKH.Contains(keyword));
            }
            

			//Query DiaChi (string)
			if (QueryStrings.Any(d => d.Key == "DiaChi_eq") && !string.IsNullOrEmpty(QueryStrings.FirstOrDefault(d => d.Key == "DiaChi_eq").Value))
            {
                var keyword = QueryStrings.FirstOrDefault(d => d.Key == "DiaChi_eq").Value;
                query = query.Where(d=>d.DiaChi == keyword);
            }
            if (QueryStrings.Any(d => d.Key == "DiaChi") && !string.IsNullOrEmpty(QueryStrings.FirstOrDefault(d => d.Key == "DiaChi").Value))
            {
                var keyword = QueryStrings.FirstOrDefault(d => d.Key == "DiaChi").Value;
                query = query.Where(d=>d.DiaChi.Contains(keyword));
            }
            

			//Query MaDH (string)
			if (QueryStrings.Any(d => d.Key == "MaDH_eq") && !string.IsNullOrEmpty(QueryStrings.FirstOrDefault(d => d.Key == "MaDH_eq").Value))
            {
                var keyword = QueryStrings.FirstOrDefault(d => d.Key == "MaDH_eq").Value;
                query = query.Where(d=>d.MaDH == keyword);
            }
            if (QueryStrings.Any(d => d.Key == "MaDH") && !string.IsNullOrEmpty(QueryStrings.FirstOrDefault(d => d.Key == "MaDH").Value))
            {
                var keyword = QueryStrings.FirstOrDefault(d => d.Key == "MaDH").Value;
                query = query.Where(d=>d.MaDH.Contains(keyword));
            }
            

			//Query TrangThai (string)
			if (QueryStrings.Any(d => d.Key == "TrangThai_eq") && !string.IsNullOrEmpty(QueryStrings.FirstOrDefault(d => d.Key == "TrangThai_eq").Value))
            {
                var keyword = QueryStrings.FirstOrDefault(d => d.Key == "TrangThai_eq").Value;
                query = query.Where(d=>d.TrangThai == keyword);
            }
            if (QueryStrings.Any(d => d.Key == "TrangThai") && !string.IsNullOrEmpty(QueryStrings.FirstOrDefault(d => d.Key == "TrangThai").Value))
            {
                var keyword = QueryStrings.FirstOrDefault(d => d.Key == "TrangThai").Value;
                query = query.Where(d=>d.TrangThai.Contains(keyword));
            }
            

			//Query NgayDonHang (Nullable<System.DateTime>)
			if (QueryStrings.Any(d => d.Key == "NgayDonHangFrom") && QueryStrings.Any(d => d.Key == "NgayDonHangTo"))
                if (DateTime.TryParse(QueryStrings.FirstOrDefault(d => d.Key == "NgayDonHangFrom").Value, out DateTime fromDate) && DateTime.TryParse(QueryStrings.FirstOrDefault(d => d.Key == "NgayDonHangTo").Value, out DateTime toDate))
                    query = query.Where(d => fromDate <= d.NgayDonHang && d.NgayDonHang <= toDate);

            if (QueryStrings.Any(d => d.Key == "NgayDonHang"))
                if (DateTime.TryParse(QueryStrings.FirstOrDefault(d => d.Key == "NgayDonHang").Value, out DateTime val))
                    query = query.Where(d => d.NgayDonHang != null && DbFunctions.TruncateTime(val) == DbFunctions.TruncateTime(d.NgayDonHang));


			//Query NgayHoaDon (Nullable<System.DateTime>)
			if (QueryStrings.Any(d => d.Key == "NgayHoaDonFrom") && QueryStrings.Any(d => d.Key == "NgayHoaDonTo"))
                if (DateTime.TryParse(QueryStrings.FirstOrDefault(d => d.Key == "NgayHoaDonFrom").Value, out DateTime fromDate) && DateTime.TryParse(QueryStrings.FirstOrDefault(d => d.Key == "NgayHoaDonTo").Value, out DateTime toDate))
                    query = query.Where(d => fromDate <= d.NgayHoaDon && d.NgayHoaDon <= toDate);

            if (QueryStrings.Any(d => d.Key == "NgayHoaDon"))
                if (DateTime.TryParse(QueryStrings.FirstOrDefault(d => d.Key == "NgayHoaDon").Value, out DateTime val))
                    query = query.Where(d => d.NgayHoaDon != null && DbFunctions.TruncateTime(val) == DbFunctions.TruncateTime(d.NgayHoaDon));


			//Query ClaimDate (Nullable<System.DateTime>)
			if (QueryStrings.Any(d => d.Key == "ClaimDateFrom") && QueryStrings.Any(d => d.Key == "ClaimDateTo"))
                if (DateTime.TryParse(QueryStrings.FirstOrDefault(d => d.Key == "ClaimDateFrom").Value, out DateTime fromDate) && DateTime.TryParse(QueryStrings.FirstOrDefault(d => d.Key == "ClaimDateTo").Value, out DateTime toDate))
                    query = query.Where(d => fromDate <= d.ClaimDate && d.ClaimDate <= toDate);

            if (QueryStrings.Any(d => d.Key == "ClaimDate"))
                if (DateTime.TryParse(QueryStrings.FirstOrDefault(d => d.Key == "ClaimDate").Value, out DateTime val))
                    query = query.Where(d => d.ClaimDate != null && DbFunctions.TruncateTime(val) == DbFunctions.TruncateTime(d.ClaimDate));


			//Query TenChuongTrinh (string)
			if (QueryStrings.Any(d => d.Key == "TenChuongTrinh_eq") && !string.IsNullOrEmpty(QueryStrings.FirstOrDefault(d => d.Key == "TenChuongTrinh_eq").Value))
            {
                var keyword = QueryStrings.FirstOrDefault(d => d.Key == "TenChuongTrinh_eq").Value;
                query = query.Where(d=>d.TenChuongTrinh == keyword);
            }
            if (QueryStrings.Any(d => d.Key == "TenChuongTrinh") && !string.IsNullOrEmpty(QueryStrings.FirstOrDefault(d => d.Key == "TenChuongTrinh").Value))
            {
                var keyword = QueryStrings.FirstOrDefault(d => d.Key == "TenChuongTrinh").Value;
                query = query.Where(d=>d.TenChuongTrinh.Contains(keyword));
            }
            

			//Query MaSP (string)
			if (QueryStrings.Any(d => d.Key == "MaSP_eq") && !string.IsNullOrEmpty(QueryStrings.FirstOrDefault(d => d.Key == "MaSP_eq").Value))
            {
                var keyword = QueryStrings.FirstOrDefault(d => d.Key == "MaSP_eq").Value;
                query = query.Where(d=>d.MaSP == keyword);
            }
            if (QueryStrings.Any(d => d.Key == "MaSP") && !string.IsNullOrEmpty(QueryStrings.FirstOrDefault(d => d.Key == "MaSP").Value))
            {
                var keyword = QueryStrings.FirstOrDefault(d => d.Key == "MaSP").Value;
                query = query.Where(d=>d.MaSP.Contains(keyword));
            }
            

			//Query TenSP (string)
			if (QueryStrings.Any(d => d.Key == "TenSP_eq") && !string.IsNullOrEmpty(QueryStrings.FirstOrDefault(d => d.Key == "TenSP_eq").Value))
            {
                var keyword = QueryStrings.FirstOrDefault(d => d.Key == "TenSP_eq").Value;
                query = query.Where(d=>d.TenSP == keyword);
            }
            if (QueryStrings.Any(d => d.Key == "TenSP") && !string.IsNullOrEmpty(QueryStrings.FirstOrDefault(d => d.Key == "TenSP").Value))
            {
                var keyword = QueryStrings.FirstOrDefault(d => d.Key == "TenSP").Value;
                query = query.Where(d=>d.TenSP.Contains(keyword));
            }
            

			//Query SoThung (Nullable<int>)
			if (QueryStrings.Any(d => d.Key == "SoThungFrom") && QueryStrings.Any(d => d.Key == "SoThungTo"))
                if (int.TryParse(QueryStrings.FirstOrDefault(d => d.Key == "SoThungFrom").Value, out int fromVal) && int.TryParse(QueryStrings.FirstOrDefault(d => d.Key == "SoThungTo").Value, out int toVal))
                    query = query.Where(d => fromVal <= d.SoThung && d.SoThung <= toVal);

			//Query SoLe (Nullable<int>)
			if (QueryStrings.Any(d => d.Key == "SoLeFrom") && QueryStrings.Any(d => d.Key == "SoLeTo"))
                if (int.TryParse(QueryStrings.FirstOrDefault(d => d.Key == "SoLeFrom").Value, out int fromVal) && int.TryParse(QueryStrings.FirstOrDefault(d => d.Key == "SoLeTo").Value, out int toVal))
                    query = query.Where(d => fromVal <= d.SoLe && d.SoLe <= toVal);

			//Query TongLe (int)
			if (QueryStrings.Any(d => d.Key == "TongLeFrom") && QueryStrings.Any(d => d.Key == "TongLeTo"))
                if (int.TryParse(QueryStrings.FirstOrDefault(d => d.Key == "TongLeFrom").Value, out int fromVal) && int.TryParse(QueryStrings.FirstOrDefault(d => d.Key == "TongLeTo").Value, out int toVal))
                    query = query.Where(d => fromVal <= d.TongLe && d.TongLe <= toVal);
            
            if (QueryStrings.Any(d => d.Key == "TongLe"))
                if (int.TryParse(QueryStrings.FirstOrDefault(d => d.Key == "TongLe").Value, out int val))
                    query = query.Where(d => val == d.TongLe);


			//Query ChietKhau (double)
            return query;
        }
		
        public static IQueryable<tbl_PR_PromotionTracking> _sortBuilder(IQueryable<tbl_PR_PromotionTracking> query, Dictionary<string, string> QueryStrings)
        {
            if (QueryStrings.Any(d => d.Key == "SortBy"))
            {
                var sorts = QueryStrings.FirstOrDefault(d => d.Key == "SortBy").Value.Replace("[", "").Replace("]", "").Split(',');
                
                foreach (var item in sorts)
                    if (!string.IsNullOrEmpty(item))
                    {
                        var ordered = query as IOrderedQueryable<tbl_PR_PromotionTracking>;
                        bool isOrdered = ordered.ToString().IndexOf("ORDER BY") !=-1;

                        switch (item)
                        {
							case "Id":
								query = isOrdered ? ordered.ThenBy(o => o.Id) : query.OrderBy(o => o.Id);
								 break;
							case "Id_desc":
                                query = isOrdered ? ordered.ThenByDescending(o => o.Id) : query.OrderByDescending(o => o.Id);
                                break;
							case "MaNVBH":
								query = isOrdered ? ordered.ThenBy(o => o.MaNVBH) : query.OrderBy(o => o.MaNVBH);
								 break;
							case "MaNVBH_desc":
                                query = isOrdered ? ordered.ThenByDescending(o => o.MaNVBH) : query.OrderByDescending(o => o.MaNVBH);
                                break;
							case "TenNVBH":
								query = isOrdered ? ordered.ThenBy(o => o.TenNVBH) : query.OrderBy(o => o.TenNVBH);
								 break;
							case "TenNVBH_desc":
                                query = isOrdered ? ordered.ThenByDescending(o => o.TenNVBH) : query.OrderByDescending(o => o.TenNVBH);
                                break;
							case "MaKH":
								query = isOrdered ? ordered.ThenBy(o => o.MaKH) : query.OrderBy(o => o.MaKH);
								 break;
							case "MaKH_desc":
                                query = isOrdered ? ordered.ThenByDescending(o => o.MaKH) : query.OrderByDescending(o => o.MaKH);
                                break;
							case "TenKH":
								query = isOrdered ? ordered.ThenBy(o => o.TenKH) : query.OrderBy(o => o.TenKH);
								 break;
							case "TenKH_desc":
                                query = isOrdered ? ordered.ThenByDescending(o => o.TenKH) : query.OrderByDescending(o => o.TenKH);
                                break;
							case "DiaChi":
								query = isOrdered ? ordered.ThenBy(o => o.DiaChi) : query.OrderBy(o => o.DiaChi);
								 break;
							case "DiaChi_desc":
                                query = isOrdered ? ordered.ThenByDescending(o => o.DiaChi) : query.OrderByDescending(o => o.DiaChi);
                                break;
							case "MaDH":
								query = isOrdered ? ordered.ThenBy(o => o.MaDH) : query.OrderBy(o => o.MaDH);
								 break;
							case "MaDH_desc":
                                query = isOrdered ? ordered.ThenByDescending(o => o.MaDH) : query.OrderByDescending(o => o.MaDH);
                                break;
							case "TrangThai":
								query = isOrdered ? ordered.ThenBy(o => o.TrangThai) : query.OrderBy(o => o.TrangThai);
								 break;
							case "TrangThai_desc":
                                query = isOrdered ? ordered.ThenByDescending(o => o.TrangThai) : query.OrderByDescending(o => o.TrangThai);
                                break;
							case "NgayDonHang":
								query = isOrdered ? ordered.ThenBy(o => o.NgayDonHang) : query.OrderBy(o => o.NgayDonHang);
								 break;
							case "NgayDonHang_desc":
                                query = isOrdered ? ordered.ThenByDescending(o => o.NgayDonHang) : query.OrderByDescending(o => o.NgayDonHang);
                                break;
							case "NgayHoaDon":
								query = isOrdered ? ordered.ThenBy(o => o.NgayHoaDon) : query.OrderBy(o => o.NgayHoaDon);
								 break;
							case "NgayHoaDon_desc":
                                query = isOrdered ? ordered.ThenByDescending(o => o.NgayHoaDon) : query.OrderByDescending(o => o.NgayHoaDon);
                                break;
							case "ClaimDate":
								query = isOrdered ? ordered.ThenBy(o => o.ClaimDate) : query.OrderBy(o => o.ClaimDate);
								 break;
							case "ClaimDate_desc":
                                query = isOrdered ? ordered.ThenByDescending(o => o.ClaimDate) : query.OrderByDescending(o => o.ClaimDate);
                                break;
							case "TenChuongTrinh":
								query = isOrdered ? ordered.ThenBy(o => o.TenChuongTrinh) : query.OrderBy(o => o.TenChuongTrinh);
								 break;
							case "TenChuongTrinh_desc":
                                query = isOrdered ? ordered.ThenByDescending(o => o.TenChuongTrinh) : query.OrderByDescending(o => o.TenChuongTrinh);
                                break;
							case "MaSP":
								query = isOrdered ? ordered.ThenBy(o => o.MaSP) : query.OrderBy(o => o.MaSP);
								 break;
							case "MaSP_desc":
                                query = isOrdered ? ordered.ThenByDescending(o => o.MaSP) : query.OrderByDescending(o => o.MaSP);
                                break;
							case "TenSP":
								query = isOrdered ? ordered.ThenBy(o => o.TenSP) : query.OrderBy(o => o.TenSP);
								 break;
							case "TenSP_desc":
                                query = isOrdered ? ordered.ThenByDescending(o => o.TenSP) : query.OrderByDescending(o => o.TenSP);
                                break;
							case "SoThung":
								query = isOrdered ? ordered.ThenBy(o => o.SoThung) : query.OrderBy(o => o.SoThung);
								 break;
							case "SoThung_desc":
                                query = isOrdered ? ordered.ThenByDescending(o => o.SoThung) : query.OrderByDescending(o => o.SoThung);
                                break;
							case "SoLe":
								query = isOrdered ? ordered.ThenBy(o => o.SoLe) : query.OrderBy(o => o.SoLe);
								 break;
							case "SoLe_desc":
                                query = isOrdered ? ordered.ThenByDescending(o => o.SoLe) : query.OrderByDescending(o => o.SoLe);
                                break;
							case "TongLe":
								query = isOrdered ? ordered.ThenBy(o => o.TongLe) : query.OrderBy(o => o.TongLe);
								 break;
							case "TongLe_desc":
                                query = isOrdered ? ordered.ThenByDescending(o => o.TongLe) : query.OrderByDescending(o => o.TongLe);
                                break;
							case "ChietKhau":
								query = isOrdered ? ordered.ThenBy(o => o.ChietKhau) : query.OrderBy(o => o.ChietKhau);
								 break;
							case "ChietKhau_desc":
                                query = isOrdered ? ordered.ThenByDescending(o => o.ChietKhau) : query.OrderByDescending(o => o.ChietKhau);
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

        public static IQueryable<tbl_PR_PromotionTracking> _pagingBuilder(IQueryable<tbl_PR_PromotionTracking> query, Dictionary<string, string> QueryStrings)
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






