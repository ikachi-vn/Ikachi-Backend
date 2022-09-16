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
    
    
    public partial class tbl_HRM_StaffCompulsoryInsurance
    {
        public int Id { get; set; }
        public string Code { get; set; }
        public string Name { get; set; }
        public string Remark { get; set; }
        public Nullable<int> Sort { get; set; }
        public string CreatedBy { get; set; }
        public string ModifiedBy { get; set; }
        public System.DateTime CreatedDate { get; set; }
        public System.DateTime ModifiedDate { get; set; }
        public string SocialInsuranceNumber { get; set; }
        public Nullable<System.DateTime> DateOfIssue { get; set; }
        public Nullable<System.DateTime> DateOfAnnouncement { get; set; }
        public Nullable<System.DateTime> DateOfDelivery { get; set; }
        public Nullable<int> IDPOLCompulsoryInsuranceApplyFor { get; set; }
        public Nullable<int> IDPOLCompulsoryInsurance { get; set; }
        public Nullable<System.DateTime> EffectiveDate { get; set; }
        public Nullable<System.DateTime> DateOfExpiry { get; set; }
        public Nullable<bool> IsJoinedSI { get; set; }
        public Nullable<decimal> RateOfSocialInsuranceCo { get; set; }
        public Nullable<decimal> RateOfSocialInsuranceEm { get; set; }
        public Nullable<bool> IsCompanyPaySI { get; set; }
        public Nullable<System.DateTime> StartMonthPayingSI { get; set; }
        public string SINote { get; set; }
        public Nullable<bool> IsJoinedHI { get; set; }
        public Nullable<decimal> RateOfHealthInsuranceCo { get; set; }
        public Nullable<decimal> RateOfHealthInsuranceEm { get; set; }
        public Nullable<bool> IsCompanyPayHI { get; set; }
        public Nullable<System.DateTime> StartMonthPayingHI { get; set; }
        public string HINote { get; set; }
        public Nullable<bool> IsJoinedUI { get; set; }
        public Nullable<decimal> RateOfUnemploymentInsuranceCo { get; set; }
        public Nullable<decimal> RateOfUnemploymentInsuranceEm { get; set; }
        public Nullable<bool> IsCompanyPayUI { get; set; }
        public Nullable<System.DateTime> StartMonthPayingUI { get; set; }
        public string UINote { get; set; }
        public Nullable<bool> IsJoinedTUF { get; set; }
        public Nullable<decimal> RateOfTradeUnionFeesCo { get; set; }
        public Nullable<decimal> RateOfTradeUnionFeesEm { get; set; }
        public Nullable<bool> IsCompanyPayTUF { get; set; }
        public Nullable<System.DateTime> StartMonthPayingUF { get; set; }
        public string UFNote { get; set; }
        public Nullable<bool> IsApproved { get; set; }
        public Nullable<decimal> TotalOfRateOfCo { get; set; }
        public Nullable<decimal> TotalOfRateOfEm { get; set; }
        public bool IsDeleted { get; set; }
        //List 0:1
        public virtual tbl_HRM_PolCompulsoryInsurance tbl_HRM_PolCompulsoryInsurance { get; set; }
        //List 0:1
        public virtual tbl_HRM_PolCompulsoryInsuranceApplyFor tbl_HRM_PolCompulsoryInsuranceApplyFor { get; set; }
        //List 0:1
        public virtual tbl_HRM_Staff tbl_HRM_Staff { get; set; }
    }
}


namespace DTOModel
{
	using System;
	public partial class DTO_HRM_StaffCompulsoryInsurance
	{
		public int Id { get; set; }
		public string Code { get; set; }
		public string Name { get; set; }
		public string Remark { get; set; }
		public Nullable<int> Sort { get; set; }
		public string CreatedBy { get; set; }
		public string ModifiedBy { get; set; }
		public System.DateTime CreatedDate { get; set; }
		public System.DateTime ModifiedDate { get; set; }
		public string SocialInsuranceNumber { get; set; }
		public Nullable<System.DateTime> DateOfIssue { get; set; }
		public Nullable<System.DateTime> DateOfAnnouncement { get; set; }
		public Nullable<System.DateTime> DateOfDelivery { get; set; }
		public Nullable<int> IDPOLCompulsoryInsuranceApplyFor { get; set; }
		public Nullable<int> IDPOLCompulsoryInsurance { get; set; }
		public Nullable<System.DateTime> EffectiveDate { get; set; }
		public Nullable<System.DateTime> DateOfExpiry { get; set; }
		public Nullable<bool> IsJoinedSI { get; set; }
		public Nullable<decimal> RateOfSocialInsuranceCo { get; set; }
		public Nullable<decimal> RateOfSocialInsuranceEm { get; set; }
		public Nullable<bool> IsCompanyPaySI { get; set; }
		public Nullable<System.DateTime> StartMonthPayingSI { get; set; }
		public string SINote { get; set; }
		public Nullable<bool> IsJoinedHI { get; set; }
		public Nullable<decimal> RateOfHealthInsuranceCo { get; set; }
		public Nullable<decimal> RateOfHealthInsuranceEm { get; set; }
		public Nullable<bool> IsCompanyPayHI { get; set; }
		public Nullable<System.DateTime> StartMonthPayingHI { get; set; }
		public string HINote { get; set; }
		public Nullable<bool> IsJoinedUI { get; set; }
		public Nullable<decimal> RateOfUnemploymentInsuranceCo { get; set; }
		public Nullable<decimal> RateOfUnemploymentInsuranceEm { get; set; }
		public Nullable<bool> IsCompanyPayUI { get; set; }
		public Nullable<System.DateTime> StartMonthPayingUI { get; set; }
		public string UINote { get; set; }
		public Nullable<bool> IsJoinedTUF { get; set; }
		public Nullable<decimal> RateOfTradeUnionFeesCo { get; set; }
		public Nullable<decimal> RateOfTradeUnionFeesEm { get; set; }
		public Nullable<bool> IsCompanyPayTUF { get; set; }
		public Nullable<System.DateTime> StartMonthPayingUF { get; set; }
		public string UFNote { get; set; }
		public Nullable<bool> IsApproved { get; set; }
		public Nullable<decimal> TotalOfRateOfCo { get; set; }
		public Nullable<decimal> TotalOfRateOfEm { get; set; }
		public bool IsDeleted { get; set; }
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

    public static partial class BS_HRM_StaffCompulsoryInsurance 
    {
        public static dynamic getSearch(AppEntities db, int IDBranch, int StaffID, Dictionary<string, string> QueryStrings)
        {
            return get(db, IDBranch,StaffID, QueryStrings);
        }

		public static IQueryable<DTO_HRM_StaffCompulsoryInsurance> get(AppEntities db, int IDBranch, int StaffID, Dictionary<string, string> QueryStrings)
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
            package.Workbook.Properties.Title = "ART-DMS HRM_StaffCompulsoryInsurance";
            package.Workbook.Properties.Author = "hung.vu@codeart.vn";
            package.Workbook.Properties.Application = "ART-DMS";
            package.Workbook.Properties.Company = "A.R.T Distribution";

            ExcelWorkbook workBook = package.Workbook;
            if (workBook != null)
            {
                var ws = workBook.Worksheets.FirstOrDefault();
                var data = _queryBuilder(db, IDBranch, StaffID, QueryStrings).ToList();

                //var HRM_PolCompulsoryInsuranceList = BS_HRM_PolCompulsoryInsurance.get(db,IDBranch, StaffID,QueryStrings).Select(s => new ItemModel { Id = s.Id, Name = s.Name });
                //var HRM_PolCompulsoryInsuranceApplyForList = BS_HRM_PolCompulsoryInsuranceApplyFor.get(db,IDBranch, StaffID,QueryStrings).Select(s => new ItemModel { Id = s.Id, Name = s.Name });
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

		public static DTO_HRM_StaffCompulsoryInsurance getAnItem(AppEntities db, int IDBranch, int StaffID, int id)
        {
            var dbResult = db.tbl_HRM_StaffCompulsoryInsurance.Find(id);

			return toDTO(dbResult);
			
        }
		
		public static DTO_HRM_StaffCompulsoryInsurance getAnItemByCode(AppEntities db, int IDBranch, int StaffID, string code)
        {
            var dbResult = db.tbl_HRM_StaffCompulsoryInsurance
			.FirstOrDefault(d => d.IsDeleted == false && d.Code == code );

			return toDTO(dbResult);
			
        }

		public static bool put(AppEntities db, int IDBranch, int StaffID, int Id, dynamic item, string Username, Dictionary<string, string> QueryStrings)
        {
            bool result = false;
            var dbitem = db.tbl_HRM_StaffCompulsoryInsurance.Find(Id);
            
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
					errorLog.logMessage("put_HRM_StaffCompulsoryInsurance",e);
                    result = false;
                }
            }
            else
                if (QueryStrings.Any(d => d.Key == "ForceCreate"))
                    result =  post(db, IDBranch, StaffID, item, Username) != null;
                
            return result;
        }

        public static void patchDynamicToDB(dynamic item, tbl_HRM_StaffCompulsoryInsurance dbitem, string Username)
        {
            Type type = typeof(tbl_HRM_StaffCompulsoryInsurance);
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

        public static void patchDTOtoDBValue( DTO_HRM_StaffCompulsoryInsurance item, tbl_HRM_StaffCompulsoryInsurance dbitem)
        {
            if (item == null){
                dbitem = null;
                return;
            }
            							
			dbitem.Code = item.Code;							
			dbitem.Name = item.Name;							
			dbitem.Remark = item.Remark;							
			dbitem.Sort = item.Sort;							
			dbitem.SocialInsuranceNumber = item.SocialInsuranceNumber;							
			dbitem.DateOfIssue = item.DateOfIssue;							
			dbitem.DateOfAnnouncement = item.DateOfAnnouncement;							
			dbitem.DateOfDelivery = item.DateOfDelivery;							
			dbitem.IDPOLCompulsoryInsuranceApplyFor = item.IDPOLCompulsoryInsuranceApplyFor;							
			dbitem.IDPOLCompulsoryInsurance = item.IDPOLCompulsoryInsurance;							
			dbitem.EffectiveDate = item.EffectiveDate;							
			dbitem.DateOfExpiry = item.DateOfExpiry;							
			dbitem.IsJoinedSI = item.IsJoinedSI;							
			dbitem.RateOfSocialInsuranceCo = item.RateOfSocialInsuranceCo;							
			dbitem.RateOfSocialInsuranceEm = item.RateOfSocialInsuranceEm;							
			dbitem.IsCompanyPaySI = item.IsCompanyPaySI;							
			dbitem.StartMonthPayingSI = item.StartMonthPayingSI;							
			dbitem.SINote = item.SINote;							
			dbitem.IsJoinedHI = item.IsJoinedHI;							
			dbitem.RateOfHealthInsuranceCo = item.RateOfHealthInsuranceCo;							
			dbitem.RateOfHealthInsuranceEm = item.RateOfHealthInsuranceEm;							
			dbitem.IsCompanyPayHI = item.IsCompanyPayHI;							
			dbitem.StartMonthPayingHI = item.StartMonthPayingHI;							
			dbitem.HINote = item.HINote;							
			dbitem.IsJoinedUI = item.IsJoinedUI;							
			dbitem.RateOfUnemploymentInsuranceCo = item.RateOfUnemploymentInsuranceCo;							
			dbitem.RateOfUnemploymentInsuranceEm = item.RateOfUnemploymentInsuranceEm;							
			dbitem.IsCompanyPayUI = item.IsCompanyPayUI;							
			dbitem.StartMonthPayingUI = item.StartMonthPayingUI;							
			dbitem.UINote = item.UINote;							
			dbitem.IsJoinedTUF = item.IsJoinedTUF;							
			dbitem.RateOfTradeUnionFeesCo = item.RateOfTradeUnionFeesCo;							
			dbitem.RateOfTradeUnionFeesEm = item.RateOfTradeUnionFeesEm;							
			dbitem.IsCompanyPayTUF = item.IsCompanyPayTUF;							
			dbitem.StartMonthPayingUF = item.StartMonthPayingUF;							
			dbitem.UFNote = item.UFNote;							
			dbitem.IsApproved = item.IsApproved;							
			dbitem.TotalOfRateOfCo = item.TotalOfRateOfCo;							
			dbitem.TotalOfRateOfEm = item.TotalOfRateOfEm;							
			dbitem.IsDeleted = item.IsDeleted;        }

		public static DTO_HRM_StaffCompulsoryInsurance post(AppEntities db, int IDBranch, int StaffID, dynamic item, string Username)
        {
            tbl_HRM_StaffCompulsoryInsurance dbitem = new tbl_HRM_StaffCompulsoryInsurance();
            if (item != null)
            {
                patchDynamicToDB(item, dbitem, Username);
                
				dbitem.CreatedBy = Username;
				dbitem.CreatedDate = DateTime.Now;				
                try
                {
					db.tbl_HRM_StaffCompulsoryInsurance.Add(dbitem);
                    db.SaveChanges();
				
                }
                catch (DbEntityValidationException e)
                {
					errorLog.logMessage("post_HRM_StaffCompulsoryInsurance",e);
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
                Type type = Type.GetType("BaseBusiness.BS_HRM_StaffCompulsoryInsurance, ClassLibrary");
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
                        var target = new tbl_HRM_StaffCompulsoryInsurance();
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
                    
                    tbl_HRM_StaffCompulsoryInsurance dbitem = new tbl_HRM_StaffCompulsoryInsurance();
                    if (it.Id == null || string.IsNullOrEmpty(it.Id.Value) || it.Id == "0")
                    {
                        dbitem = new tbl_HRM_StaffCompulsoryInsurance();
                        dbitem.CreatedBy = Username;
				        dbitem.CreatedDate = DateTime.Now;
                                            }
                    else
                    {
                        dbitem = db.tbl_HRM_StaffCompulsoryInsurance.Find((int)it.Id);
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
                        
                        if (dbitem.Id == 0) db.tbl_HRM_StaffCompulsoryInsurance.Add(dbitem);
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
                    errorLog.logMessage("post_HRM_StaffCompulsoryInsurance",e);
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

            var dbitems = db.tbl_HRM_StaffCompulsoryInsurance.Where(d => IDs.Contains(d.Id));
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
			
                BS_Version.update_Version(db, null, "DTO_HRM_StaffCompulsoryInsurance", updateDate, Username);
			
            }
            catch (DbEntityValidationException e)
            {
				errorLog.logMessage("delete_HRM_StaffCompulsoryInsurance",e);
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
             
            return db.tbl_HRM_StaffCompulsoryInsurance.Any(e => e.Id == id && e.IsDeleted == false);
            
		}
		
		public static bool check_Exists(AppEntities db, string Code)
		{
             
            return db.tbl_HRM_StaffCompulsoryInsurance.Any(e => e.Code == Code && e.IsDeleted == false);
            
		}
		
		//---//
		public static IQueryable<DTO_HRM_StaffCompulsoryInsurance> toDTO(IQueryable<tbl_HRM_StaffCompulsoryInsurance> query)
        {
			return query
			.Select(s => new DTO_HRM_StaffCompulsoryInsurance(){							
				Id = s.Id,							
				Code = s.Code,							
				Name = s.Name,							
				Remark = s.Remark,							
				Sort = s.Sort,							
				CreatedBy = s.CreatedBy,							
				ModifiedBy = s.ModifiedBy,							
				CreatedDate = s.CreatedDate,							
				ModifiedDate = s.ModifiedDate,							
				SocialInsuranceNumber = s.SocialInsuranceNumber,							
				DateOfIssue = s.DateOfIssue,							
				DateOfAnnouncement = s.DateOfAnnouncement,							
				DateOfDelivery = s.DateOfDelivery,							
				IDPOLCompulsoryInsuranceApplyFor = s.IDPOLCompulsoryInsuranceApplyFor,							
				IDPOLCompulsoryInsurance = s.IDPOLCompulsoryInsurance,							
				EffectiveDate = s.EffectiveDate,							
				DateOfExpiry = s.DateOfExpiry,							
				IsJoinedSI = s.IsJoinedSI,							
				RateOfSocialInsuranceCo = s.RateOfSocialInsuranceCo,							
				RateOfSocialInsuranceEm = s.RateOfSocialInsuranceEm,							
				IsCompanyPaySI = s.IsCompanyPaySI,							
				StartMonthPayingSI = s.StartMonthPayingSI,							
				SINote = s.SINote,							
				IsJoinedHI = s.IsJoinedHI,							
				RateOfHealthInsuranceCo = s.RateOfHealthInsuranceCo,							
				RateOfHealthInsuranceEm = s.RateOfHealthInsuranceEm,							
				IsCompanyPayHI = s.IsCompanyPayHI,							
				StartMonthPayingHI = s.StartMonthPayingHI,							
				HINote = s.HINote,							
				IsJoinedUI = s.IsJoinedUI,							
				RateOfUnemploymentInsuranceCo = s.RateOfUnemploymentInsuranceCo,							
				RateOfUnemploymentInsuranceEm = s.RateOfUnemploymentInsuranceEm,							
				IsCompanyPayUI = s.IsCompanyPayUI,							
				StartMonthPayingUI = s.StartMonthPayingUI,							
				UINote = s.UINote,							
				IsJoinedTUF = s.IsJoinedTUF,							
				RateOfTradeUnionFeesCo = s.RateOfTradeUnionFeesCo,							
				RateOfTradeUnionFeesEm = s.RateOfTradeUnionFeesEm,							
				IsCompanyPayTUF = s.IsCompanyPayTUF,							
				StartMonthPayingUF = s.StartMonthPayingUF,							
				UFNote = s.UFNote,							
				IsApproved = s.IsApproved,							
				TotalOfRateOfCo = s.TotalOfRateOfCo,							
				TotalOfRateOfEm = s.TotalOfRateOfEm,							
				IsDeleted = s.IsDeleted,					
			});//.OrderBy(o => o.Sort == null).ThenBy(u => u.Sort);
                              
        }

		public static DTO_HRM_StaffCompulsoryInsurance toDTO(tbl_HRM_StaffCompulsoryInsurance dbResult)
        {
			if (dbResult != null)
			{
				return new DTO_HRM_StaffCompulsoryInsurance()
				{							
					Id = dbResult.Id,							
					Code = dbResult.Code,							
					Name = dbResult.Name,							
					Remark = dbResult.Remark,							
					Sort = dbResult.Sort,							
					CreatedBy = dbResult.CreatedBy,							
					ModifiedBy = dbResult.ModifiedBy,							
					CreatedDate = dbResult.CreatedDate,							
					ModifiedDate = dbResult.ModifiedDate,							
					SocialInsuranceNumber = dbResult.SocialInsuranceNumber,							
					DateOfIssue = dbResult.DateOfIssue,							
					DateOfAnnouncement = dbResult.DateOfAnnouncement,							
					DateOfDelivery = dbResult.DateOfDelivery,							
					IDPOLCompulsoryInsuranceApplyFor = dbResult.IDPOLCompulsoryInsuranceApplyFor,							
					IDPOLCompulsoryInsurance = dbResult.IDPOLCompulsoryInsurance,							
					EffectiveDate = dbResult.EffectiveDate,							
					DateOfExpiry = dbResult.DateOfExpiry,							
					IsJoinedSI = dbResult.IsJoinedSI,							
					RateOfSocialInsuranceCo = dbResult.RateOfSocialInsuranceCo,							
					RateOfSocialInsuranceEm = dbResult.RateOfSocialInsuranceEm,							
					IsCompanyPaySI = dbResult.IsCompanyPaySI,							
					StartMonthPayingSI = dbResult.StartMonthPayingSI,							
					SINote = dbResult.SINote,							
					IsJoinedHI = dbResult.IsJoinedHI,							
					RateOfHealthInsuranceCo = dbResult.RateOfHealthInsuranceCo,							
					RateOfHealthInsuranceEm = dbResult.RateOfHealthInsuranceEm,							
					IsCompanyPayHI = dbResult.IsCompanyPayHI,							
					StartMonthPayingHI = dbResult.StartMonthPayingHI,							
					HINote = dbResult.HINote,							
					IsJoinedUI = dbResult.IsJoinedUI,							
					RateOfUnemploymentInsuranceCo = dbResult.RateOfUnemploymentInsuranceCo,							
					RateOfUnemploymentInsuranceEm = dbResult.RateOfUnemploymentInsuranceEm,							
					IsCompanyPayUI = dbResult.IsCompanyPayUI,							
					StartMonthPayingUI = dbResult.StartMonthPayingUI,							
					UINote = dbResult.UINote,							
					IsJoinedTUF = dbResult.IsJoinedTUF,							
					RateOfTradeUnionFeesCo = dbResult.RateOfTradeUnionFeesCo,							
					RateOfTradeUnionFeesEm = dbResult.RateOfTradeUnionFeesEm,							
					IsCompanyPayTUF = dbResult.IsCompanyPayTUF,							
					StartMonthPayingUF = dbResult.StartMonthPayingUF,							
					UFNote = dbResult.UFNote,							
					IsApproved = dbResult.IsApproved,							
					TotalOfRateOfCo = dbResult.TotalOfRateOfCo,							
					TotalOfRateOfEm = dbResult.TotalOfRateOfEm,							
					IsDeleted = dbResult.IsDeleted,
				};
			}
			else
				return null; 
        }

		public static IQueryable<tbl_HRM_StaffCompulsoryInsurance> _queryBuilder(AppEntities db, int IDBranch, int StaffID, Dictionary<string, string> QueryStrings)
        {
            
			IQueryable<tbl_HRM_StaffCompulsoryInsurance> query = db.tbl_HRM_StaffCompulsoryInsurance.AsNoTracking();//.Where(d => d.IsDeleted == false );
			

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


			//Query SocialInsuranceNumber (string)
			if (QueryStrings.Any(d => d.Key == "SocialInsuranceNumber_eq") && !string.IsNullOrEmpty(QueryStrings.FirstOrDefault(d => d.Key == "SocialInsuranceNumber_eq").Value))
            {
                var keyword = QueryStrings.FirstOrDefault(d => d.Key == "SocialInsuranceNumber_eq").Value;
                query = query.Where(d=>d.SocialInsuranceNumber == keyword);
            }
            if (QueryStrings.Any(d => d.Key == "SocialInsuranceNumber") && !string.IsNullOrEmpty(QueryStrings.FirstOrDefault(d => d.Key == "SocialInsuranceNumber").Value))
            {
                var keyword = QueryStrings.FirstOrDefault(d => d.Key == "SocialInsuranceNumber").Value;
                query = query.Where(d=>d.SocialInsuranceNumber.Contains(keyword));
            }
            

			//Query DateOfIssue (Nullable<System.DateTime>)
			if (QueryStrings.Any(d => d.Key == "DateOfIssueFrom") && QueryStrings.Any(d => d.Key == "DateOfIssueTo"))
                if (DateTime.TryParse(QueryStrings.FirstOrDefault(d => d.Key == "DateOfIssueFrom").Value, out DateTime fromDate) && DateTime.TryParse(QueryStrings.FirstOrDefault(d => d.Key == "DateOfIssueTo").Value, out DateTime toDate))
                    query = query.Where(d => fromDate <= d.DateOfIssue && d.DateOfIssue <= toDate);

            if (QueryStrings.Any(d => d.Key == "DateOfIssue"))
                if (DateTime.TryParse(QueryStrings.FirstOrDefault(d => d.Key == "DateOfIssue").Value, out DateTime val))
                    query = query.Where(d => d.DateOfIssue != null && DbFunctions.TruncateTime(val) == DbFunctions.TruncateTime(d.DateOfIssue));


			//Query DateOfAnnouncement (Nullable<System.DateTime>)
			if (QueryStrings.Any(d => d.Key == "DateOfAnnouncementFrom") && QueryStrings.Any(d => d.Key == "DateOfAnnouncementTo"))
                if (DateTime.TryParse(QueryStrings.FirstOrDefault(d => d.Key == "DateOfAnnouncementFrom").Value, out DateTime fromDate) && DateTime.TryParse(QueryStrings.FirstOrDefault(d => d.Key == "DateOfAnnouncementTo").Value, out DateTime toDate))
                    query = query.Where(d => fromDate <= d.DateOfAnnouncement && d.DateOfAnnouncement <= toDate);

            if (QueryStrings.Any(d => d.Key == "DateOfAnnouncement"))
                if (DateTime.TryParse(QueryStrings.FirstOrDefault(d => d.Key == "DateOfAnnouncement").Value, out DateTime val))
                    query = query.Where(d => d.DateOfAnnouncement != null && DbFunctions.TruncateTime(val) == DbFunctions.TruncateTime(d.DateOfAnnouncement));


			//Query DateOfDelivery (Nullable<System.DateTime>)
			if (QueryStrings.Any(d => d.Key == "DateOfDeliveryFrom") && QueryStrings.Any(d => d.Key == "DateOfDeliveryTo"))
                if (DateTime.TryParse(QueryStrings.FirstOrDefault(d => d.Key == "DateOfDeliveryFrom").Value, out DateTime fromDate) && DateTime.TryParse(QueryStrings.FirstOrDefault(d => d.Key == "DateOfDeliveryTo").Value, out DateTime toDate))
                    query = query.Where(d => fromDate <= d.DateOfDelivery && d.DateOfDelivery <= toDate);

            if (QueryStrings.Any(d => d.Key == "DateOfDelivery"))
                if (DateTime.TryParse(QueryStrings.FirstOrDefault(d => d.Key == "DateOfDelivery").Value, out DateTime val))
                    query = query.Where(d => d.DateOfDelivery != null && DbFunctions.TruncateTime(val) == DbFunctions.TruncateTime(d.DateOfDelivery));


			//Query IDPOLCompulsoryInsuranceApplyFor (Nullable<int>)
			if (QueryStrings.Any(d => d.Key == "IDPOLCompulsoryInsuranceApplyFor"))
            {
                var IDList = QueryStrings.FirstOrDefault(d => d.Key == "IDPOLCompulsoryInsuranceApplyFor").Value.Replace("[", "").Replace("]", "").Split(',');
                List<int?> IDs = new List<int?>();
                foreach (var item in IDList)
                    if (int.TryParse(item, out int i))
                        IDs.Add(i);
					else if (item == "null")
						IDs.Add(null);
                if (IDs.Count > 0)
                    query = query.Where(d => IDs.Contains(d.IDPOLCompulsoryInsuranceApplyFor));
////                    query = query.Where(d => IDs.Contains(d.IDPOLCompulsoryInsuranceApplyFor));
//                    
            }

			//Query IDPOLCompulsoryInsurance (Nullable<int>)
			if (QueryStrings.Any(d => d.Key == "IDPOLCompulsoryInsurance"))
            {
                var IDList = QueryStrings.FirstOrDefault(d => d.Key == "IDPOLCompulsoryInsurance").Value.Replace("[", "").Replace("]", "").Split(',');
                List<int?> IDs = new List<int?>();
                foreach (var item in IDList)
                    if (int.TryParse(item, out int i))
                        IDs.Add(i);
					else if (item == "null")
						IDs.Add(null);
                if (IDs.Count > 0)
                    query = query.Where(d => IDs.Contains(d.IDPOLCompulsoryInsurance));
////                    query = query.Where(d => IDs.Contains(d.IDPOLCompulsoryInsurance));
//                    
            }

			//Query EffectiveDate (Nullable<System.DateTime>)
			if (QueryStrings.Any(d => d.Key == "EffectiveDateFrom") && QueryStrings.Any(d => d.Key == "EffectiveDateTo"))
                if (DateTime.TryParse(QueryStrings.FirstOrDefault(d => d.Key == "EffectiveDateFrom").Value, out DateTime fromDate) && DateTime.TryParse(QueryStrings.FirstOrDefault(d => d.Key == "EffectiveDateTo").Value, out DateTime toDate))
                    query = query.Where(d => fromDate <= d.EffectiveDate && d.EffectiveDate <= toDate);

            if (QueryStrings.Any(d => d.Key == "EffectiveDate"))
                if (DateTime.TryParse(QueryStrings.FirstOrDefault(d => d.Key == "EffectiveDate").Value, out DateTime val))
                    query = query.Where(d => d.EffectiveDate != null && DbFunctions.TruncateTime(val) == DbFunctions.TruncateTime(d.EffectiveDate));


			//Query DateOfExpiry (Nullable<System.DateTime>)
			if (QueryStrings.Any(d => d.Key == "DateOfExpiryFrom") && QueryStrings.Any(d => d.Key == "DateOfExpiryTo"))
                if (DateTime.TryParse(QueryStrings.FirstOrDefault(d => d.Key == "DateOfExpiryFrom").Value, out DateTime fromDate) && DateTime.TryParse(QueryStrings.FirstOrDefault(d => d.Key == "DateOfExpiryTo").Value, out DateTime toDate))
                    query = query.Where(d => fromDate <= d.DateOfExpiry && d.DateOfExpiry <= toDate);

            if (QueryStrings.Any(d => d.Key == "DateOfExpiry"))
                if (DateTime.TryParse(QueryStrings.FirstOrDefault(d => d.Key == "DateOfExpiry").Value, out DateTime val))
                    query = query.Where(d => d.DateOfExpiry != null && DbFunctions.TruncateTime(val) == DbFunctions.TruncateTime(d.DateOfExpiry));


			//Query IsJoinedSI (Nullable<bool>)

			//Query RateOfSocialInsuranceCo (Nullable<decimal>)
			if (QueryStrings.Any(d => d.Key == "RateOfSocialInsuranceCoFrom") && QueryStrings.Any(d => d.Key == "RateOfSocialInsuranceCoTo"))
                if (decimal.TryParse(QueryStrings.FirstOrDefault(d => d.Key == "RateOfSocialInsuranceCoFrom").Value, out decimal fromVal) && decimal.TryParse(QueryStrings.FirstOrDefault(d => d.Key == "RateOfSocialInsuranceCoTo").Value, out decimal toVal))
                    query = query.Where(d => fromVal <= d.RateOfSocialInsuranceCo && d.RateOfSocialInsuranceCo <= toVal);

			//Query RateOfSocialInsuranceEm (Nullable<decimal>)
			if (QueryStrings.Any(d => d.Key == "RateOfSocialInsuranceEmFrom") && QueryStrings.Any(d => d.Key == "RateOfSocialInsuranceEmTo"))
                if (decimal.TryParse(QueryStrings.FirstOrDefault(d => d.Key == "RateOfSocialInsuranceEmFrom").Value, out decimal fromVal) && decimal.TryParse(QueryStrings.FirstOrDefault(d => d.Key == "RateOfSocialInsuranceEmTo").Value, out decimal toVal))
                    query = query.Where(d => fromVal <= d.RateOfSocialInsuranceEm && d.RateOfSocialInsuranceEm <= toVal);

			//Query IsCompanyPaySI (Nullable<bool>)

			//Query StartMonthPayingSI (Nullable<System.DateTime>)
			if (QueryStrings.Any(d => d.Key == "StartMonthPayingSIFrom") && QueryStrings.Any(d => d.Key == "StartMonthPayingSITo"))
                if (DateTime.TryParse(QueryStrings.FirstOrDefault(d => d.Key == "StartMonthPayingSIFrom").Value, out DateTime fromDate) && DateTime.TryParse(QueryStrings.FirstOrDefault(d => d.Key == "StartMonthPayingSITo").Value, out DateTime toDate))
                    query = query.Where(d => fromDate <= d.StartMonthPayingSI && d.StartMonthPayingSI <= toDate);

            if (QueryStrings.Any(d => d.Key == "StartMonthPayingSI"))
                if (DateTime.TryParse(QueryStrings.FirstOrDefault(d => d.Key == "StartMonthPayingSI").Value, out DateTime val))
                    query = query.Where(d => d.StartMonthPayingSI != null && DbFunctions.TruncateTime(val) == DbFunctions.TruncateTime(d.StartMonthPayingSI));


			//Query SINote (string)
			if (QueryStrings.Any(d => d.Key == "SINote_eq") && !string.IsNullOrEmpty(QueryStrings.FirstOrDefault(d => d.Key == "SINote_eq").Value))
            {
                var keyword = QueryStrings.FirstOrDefault(d => d.Key == "SINote_eq").Value;
                query = query.Where(d=>d.SINote == keyword);
            }
            if (QueryStrings.Any(d => d.Key == "SINote") && !string.IsNullOrEmpty(QueryStrings.FirstOrDefault(d => d.Key == "SINote").Value))
            {
                var keyword = QueryStrings.FirstOrDefault(d => d.Key == "SINote").Value;
                query = query.Where(d=>d.SINote.Contains(keyword));
            }
            

			//Query IsJoinedHI (Nullable<bool>)

			//Query RateOfHealthInsuranceCo (Nullable<decimal>)
			if (QueryStrings.Any(d => d.Key == "RateOfHealthInsuranceCoFrom") && QueryStrings.Any(d => d.Key == "RateOfHealthInsuranceCoTo"))
                if (decimal.TryParse(QueryStrings.FirstOrDefault(d => d.Key == "RateOfHealthInsuranceCoFrom").Value, out decimal fromVal) && decimal.TryParse(QueryStrings.FirstOrDefault(d => d.Key == "RateOfHealthInsuranceCoTo").Value, out decimal toVal))
                    query = query.Where(d => fromVal <= d.RateOfHealthInsuranceCo && d.RateOfHealthInsuranceCo <= toVal);

			//Query RateOfHealthInsuranceEm (Nullable<decimal>)
			if (QueryStrings.Any(d => d.Key == "RateOfHealthInsuranceEmFrom") && QueryStrings.Any(d => d.Key == "RateOfHealthInsuranceEmTo"))
                if (decimal.TryParse(QueryStrings.FirstOrDefault(d => d.Key == "RateOfHealthInsuranceEmFrom").Value, out decimal fromVal) && decimal.TryParse(QueryStrings.FirstOrDefault(d => d.Key == "RateOfHealthInsuranceEmTo").Value, out decimal toVal))
                    query = query.Where(d => fromVal <= d.RateOfHealthInsuranceEm && d.RateOfHealthInsuranceEm <= toVal);

			//Query IsCompanyPayHI (Nullable<bool>)

			//Query StartMonthPayingHI (Nullable<System.DateTime>)
			if (QueryStrings.Any(d => d.Key == "StartMonthPayingHIFrom") && QueryStrings.Any(d => d.Key == "StartMonthPayingHITo"))
                if (DateTime.TryParse(QueryStrings.FirstOrDefault(d => d.Key == "StartMonthPayingHIFrom").Value, out DateTime fromDate) && DateTime.TryParse(QueryStrings.FirstOrDefault(d => d.Key == "StartMonthPayingHITo").Value, out DateTime toDate))
                    query = query.Where(d => fromDate <= d.StartMonthPayingHI && d.StartMonthPayingHI <= toDate);

            if (QueryStrings.Any(d => d.Key == "StartMonthPayingHI"))
                if (DateTime.TryParse(QueryStrings.FirstOrDefault(d => d.Key == "StartMonthPayingHI").Value, out DateTime val))
                    query = query.Where(d => d.StartMonthPayingHI != null && DbFunctions.TruncateTime(val) == DbFunctions.TruncateTime(d.StartMonthPayingHI));


			//Query HINote (string)
			if (QueryStrings.Any(d => d.Key == "HINote_eq") && !string.IsNullOrEmpty(QueryStrings.FirstOrDefault(d => d.Key == "HINote_eq").Value))
            {
                var keyword = QueryStrings.FirstOrDefault(d => d.Key == "HINote_eq").Value;
                query = query.Where(d=>d.HINote == keyword);
            }
            if (QueryStrings.Any(d => d.Key == "HINote") && !string.IsNullOrEmpty(QueryStrings.FirstOrDefault(d => d.Key == "HINote").Value))
            {
                var keyword = QueryStrings.FirstOrDefault(d => d.Key == "HINote").Value;
                query = query.Where(d=>d.HINote.Contains(keyword));
            }
            

			//Query IsJoinedUI (Nullable<bool>)

			//Query RateOfUnemploymentInsuranceCo (Nullable<decimal>)
			if (QueryStrings.Any(d => d.Key == "RateOfUnemploymentInsuranceCoFrom") && QueryStrings.Any(d => d.Key == "RateOfUnemploymentInsuranceCoTo"))
                if (decimal.TryParse(QueryStrings.FirstOrDefault(d => d.Key == "RateOfUnemploymentInsuranceCoFrom").Value, out decimal fromVal) && decimal.TryParse(QueryStrings.FirstOrDefault(d => d.Key == "RateOfUnemploymentInsuranceCoTo").Value, out decimal toVal))
                    query = query.Where(d => fromVal <= d.RateOfUnemploymentInsuranceCo && d.RateOfUnemploymentInsuranceCo <= toVal);

			//Query RateOfUnemploymentInsuranceEm (Nullable<decimal>)
			if (QueryStrings.Any(d => d.Key == "RateOfUnemploymentInsuranceEmFrom") && QueryStrings.Any(d => d.Key == "RateOfUnemploymentInsuranceEmTo"))
                if (decimal.TryParse(QueryStrings.FirstOrDefault(d => d.Key == "RateOfUnemploymentInsuranceEmFrom").Value, out decimal fromVal) && decimal.TryParse(QueryStrings.FirstOrDefault(d => d.Key == "RateOfUnemploymentInsuranceEmTo").Value, out decimal toVal))
                    query = query.Where(d => fromVal <= d.RateOfUnemploymentInsuranceEm && d.RateOfUnemploymentInsuranceEm <= toVal);

			//Query IsCompanyPayUI (Nullable<bool>)

			//Query StartMonthPayingUI (Nullable<System.DateTime>)
			if (QueryStrings.Any(d => d.Key == "StartMonthPayingUIFrom") && QueryStrings.Any(d => d.Key == "StartMonthPayingUITo"))
                if (DateTime.TryParse(QueryStrings.FirstOrDefault(d => d.Key == "StartMonthPayingUIFrom").Value, out DateTime fromDate) && DateTime.TryParse(QueryStrings.FirstOrDefault(d => d.Key == "StartMonthPayingUITo").Value, out DateTime toDate))
                    query = query.Where(d => fromDate <= d.StartMonthPayingUI && d.StartMonthPayingUI <= toDate);

            if (QueryStrings.Any(d => d.Key == "StartMonthPayingUI"))
                if (DateTime.TryParse(QueryStrings.FirstOrDefault(d => d.Key == "StartMonthPayingUI").Value, out DateTime val))
                    query = query.Where(d => d.StartMonthPayingUI != null && DbFunctions.TruncateTime(val) == DbFunctions.TruncateTime(d.StartMonthPayingUI));


			//Query UINote (string)
			if (QueryStrings.Any(d => d.Key == "UINote_eq") && !string.IsNullOrEmpty(QueryStrings.FirstOrDefault(d => d.Key == "UINote_eq").Value))
            {
                var keyword = QueryStrings.FirstOrDefault(d => d.Key == "UINote_eq").Value;
                query = query.Where(d=>d.UINote == keyword);
            }
            if (QueryStrings.Any(d => d.Key == "UINote") && !string.IsNullOrEmpty(QueryStrings.FirstOrDefault(d => d.Key == "UINote").Value))
            {
                var keyword = QueryStrings.FirstOrDefault(d => d.Key == "UINote").Value;
                query = query.Where(d=>d.UINote.Contains(keyword));
            }
            

			//Query IsJoinedTUF (Nullable<bool>)

			//Query RateOfTradeUnionFeesCo (Nullable<decimal>)
			if (QueryStrings.Any(d => d.Key == "RateOfTradeUnionFeesCoFrom") && QueryStrings.Any(d => d.Key == "RateOfTradeUnionFeesCoTo"))
                if (decimal.TryParse(QueryStrings.FirstOrDefault(d => d.Key == "RateOfTradeUnionFeesCoFrom").Value, out decimal fromVal) && decimal.TryParse(QueryStrings.FirstOrDefault(d => d.Key == "RateOfTradeUnionFeesCoTo").Value, out decimal toVal))
                    query = query.Where(d => fromVal <= d.RateOfTradeUnionFeesCo && d.RateOfTradeUnionFeesCo <= toVal);

			//Query RateOfTradeUnionFeesEm (Nullable<decimal>)
			if (QueryStrings.Any(d => d.Key == "RateOfTradeUnionFeesEmFrom") && QueryStrings.Any(d => d.Key == "RateOfTradeUnionFeesEmTo"))
                if (decimal.TryParse(QueryStrings.FirstOrDefault(d => d.Key == "RateOfTradeUnionFeesEmFrom").Value, out decimal fromVal) && decimal.TryParse(QueryStrings.FirstOrDefault(d => d.Key == "RateOfTradeUnionFeesEmTo").Value, out decimal toVal))
                    query = query.Where(d => fromVal <= d.RateOfTradeUnionFeesEm && d.RateOfTradeUnionFeesEm <= toVal);

			//Query IsCompanyPayTUF (Nullable<bool>)

			//Query StartMonthPayingUF (Nullable<System.DateTime>)
			if (QueryStrings.Any(d => d.Key == "StartMonthPayingUFFrom") && QueryStrings.Any(d => d.Key == "StartMonthPayingUFTo"))
                if (DateTime.TryParse(QueryStrings.FirstOrDefault(d => d.Key == "StartMonthPayingUFFrom").Value, out DateTime fromDate) && DateTime.TryParse(QueryStrings.FirstOrDefault(d => d.Key == "StartMonthPayingUFTo").Value, out DateTime toDate))
                    query = query.Where(d => fromDate <= d.StartMonthPayingUF && d.StartMonthPayingUF <= toDate);

            if (QueryStrings.Any(d => d.Key == "StartMonthPayingUF"))
                if (DateTime.TryParse(QueryStrings.FirstOrDefault(d => d.Key == "StartMonthPayingUF").Value, out DateTime val))
                    query = query.Where(d => d.StartMonthPayingUF != null && DbFunctions.TruncateTime(val) == DbFunctions.TruncateTime(d.StartMonthPayingUF));


			//Query UFNote (string)
			if (QueryStrings.Any(d => d.Key == "UFNote_eq") && !string.IsNullOrEmpty(QueryStrings.FirstOrDefault(d => d.Key == "UFNote_eq").Value))
            {
                var keyword = QueryStrings.FirstOrDefault(d => d.Key == "UFNote_eq").Value;
                query = query.Where(d=>d.UFNote == keyword);
            }
            if (QueryStrings.Any(d => d.Key == "UFNote") && !string.IsNullOrEmpty(QueryStrings.FirstOrDefault(d => d.Key == "UFNote").Value))
            {
                var keyword = QueryStrings.FirstOrDefault(d => d.Key == "UFNote").Value;
                query = query.Where(d=>d.UFNote.Contains(keyword));
            }
            

			//Query IsApproved (Nullable<bool>)

			//Query TotalOfRateOfCo (Nullable<decimal>)
			if (QueryStrings.Any(d => d.Key == "TotalOfRateOfCoFrom") && QueryStrings.Any(d => d.Key == "TotalOfRateOfCoTo"))
                if (decimal.TryParse(QueryStrings.FirstOrDefault(d => d.Key == "TotalOfRateOfCoFrom").Value, out decimal fromVal) && decimal.TryParse(QueryStrings.FirstOrDefault(d => d.Key == "TotalOfRateOfCoTo").Value, out decimal toVal))
                    query = query.Where(d => fromVal <= d.TotalOfRateOfCo && d.TotalOfRateOfCo <= toVal);

			//Query TotalOfRateOfEm (Nullable<decimal>)
			if (QueryStrings.Any(d => d.Key == "TotalOfRateOfEmFrom") && QueryStrings.Any(d => d.Key == "TotalOfRateOfEmTo"))
                if (decimal.TryParse(QueryStrings.FirstOrDefault(d => d.Key == "TotalOfRateOfEmFrom").Value, out decimal fromVal) && decimal.TryParse(QueryStrings.FirstOrDefault(d => d.Key == "TotalOfRateOfEmTo").Value, out decimal toVal))
                    query = query.Where(d => fromVal <= d.TotalOfRateOfEm && d.TotalOfRateOfEm <= toVal);

			//Query IsDeleted (bool)
			if (QueryStrings.Any(d => d.Key == "IsDeleted"))
            {
                var qValue = QueryStrings.FirstOrDefault(d => d.Key == "IsDeleted").Value;
                if (bool.TryParse(qValue, out bool qBoolValue))
                    query = query.Where(d => qBoolValue == d.IsDeleted);
            }
            else
                query = query.Where(d => false == d.IsDeleted);
            return query;
        }
		
        public static IQueryable<tbl_HRM_StaffCompulsoryInsurance> _sortBuilder(IQueryable<tbl_HRM_StaffCompulsoryInsurance> query, Dictionary<string, string> QueryStrings)
        {
            if (QueryStrings.Any(d => d.Key == "SortBy"))
            {
                var sorts = QueryStrings.FirstOrDefault(d => d.Key == "SortBy").Value.Replace("[", "").Replace("]", "").Split(',');
                
                foreach (var item in sorts)
                    if (!string.IsNullOrEmpty(item))
                    {
                        var ordered = query as IOrderedQueryable<tbl_HRM_StaffCompulsoryInsurance>;
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
							case "SocialInsuranceNumber":
								query = isOrdered ? ordered.ThenBy(o => o.SocialInsuranceNumber) : query.OrderBy(o => o.SocialInsuranceNumber);
								 break;
							case "SocialInsuranceNumber_desc":
                                query = isOrdered ? ordered.ThenByDescending(o => o.SocialInsuranceNumber) : query.OrderByDescending(o => o.SocialInsuranceNumber);
                                break;
							case "DateOfIssue":
								query = isOrdered ? ordered.ThenBy(o => o.DateOfIssue) : query.OrderBy(o => o.DateOfIssue);
								 break;
							case "DateOfIssue_desc":
                                query = isOrdered ? ordered.ThenByDescending(o => o.DateOfIssue) : query.OrderByDescending(o => o.DateOfIssue);
                                break;
							case "DateOfAnnouncement":
								query = isOrdered ? ordered.ThenBy(o => o.DateOfAnnouncement) : query.OrderBy(o => o.DateOfAnnouncement);
								 break;
							case "DateOfAnnouncement_desc":
                                query = isOrdered ? ordered.ThenByDescending(o => o.DateOfAnnouncement) : query.OrderByDescending(o => o.DateOfAnnouncement);
                                break;
							case "DateOfDelivery":
								query = isOrdered ? ordered.ThenBy(o => o.DateOfDelivery) : query.OrderBy(o => o.DateOfDelivery);
								 break;
							case "DateOfDelivery_desc":
                                query = isOrdered ? ordered.ThenByDescending(o => o.DateOfDelivery) : query.OrderByDescending(o => o.DateOfDelivery);
                                break;
							case "IDPOLCompulsoryInsuranceApplyFor":
								query = isOrdered ? ordered.ThenBy(o => o.IDPOLCompulsoryInsuranceApplyFor) : query.OrderBy(o => o.IDPOLCompulsoryInsuranceApplyFor);
								 break;
							case "IDPOLCompulsoryInsuranceApplyFor_desc":
                                query = isOrdered ? ordered.ThenByDescending(o => o.IDPOLCompulsoryInsuranceApplyFor) : query.OrderByDescending(o => o.IDPOLCompulsoryInsuranceApplyFor);
                                break;
							case "IDPOLCompulsoryInsurance":
								query = isOrdered ? ordered.ThenBy(o => o.IDPOLCompulsoryInsurance) : query.OrderBy(o => o.IDPOLCompulsoryInsurance);
								 break;
							case "IDPOLCompulsoryInsurance_desc":
                                query = isOrdered ? ordered.ThenByDescending(o => o.IDPOLCompulsoryInsurance) : query.OrderByDescending(o => o.IDPOLCompulsoryInsurance);
                                break;
							case "EffectiveDate":
								query = isOrdered ? ordered.ThenBy(o => o.EffectiveDate) : query.OrderBy(o => o.EffectiveDate);
								 break;
							case "EffectiveDate_desc":
                                query = isOrdered ? ordered.ThenByDescending(o => o.EffectiveDate) : query.OrderByDescending(o => o.EffectiveDate);
                                break;
							case "DateOfExpiry":
								query = isOrdered ? ordered.ThenBy(o => o.DateOfExpiry) : query.OrderBy(o => o.DateOfExpiry);
								 break;
							case "DateOfExpiry_desc":
                                query = isOrdered ? ordered.ThenByDescending(o => o.DateOfExpiry) : query.OrderByDescending(o => o.DateOfExpiry);
                                break;
							case "IsJoinedSI":
								query = isOrdered ? ordered.ThenBy(o => o.IsJoinedSI) : query.OrderBy(o => o.IsJoinedSI);
								 break;
							case "IsJoinedSI_desc":
                                query = isOrdered ? ordered.ThenByDescending(o => o.IsJoinedSI) : query.OrderByDescending(o => o.IsJoinedSI);
                                break;
							case "RateOfSocialInsuranceCo":
								query = isOrdered ? ordered.ThenBy(o => o.RateOfSocialInsuranceCo) : query.OrderBy(o => o.RateOfSocialInsuranceCo);
								 break;
							case "RateOfSocialInsuranceCo_desc":
                                query = isOrdered ? ordered.ThenByDescending(o => o.RateOfSocialInsuranceCo) : query.OrderByDescending(o => o.RateOfSocialInsuranceCo);
                                break;
							case "RateOfSocialInsuranceEm":
								query = isOrdered ? ordered.ThenBy(o => o.RateOfSocialInsuranceEm) : query.OrderBy(o => o.RateOfSocialInsuranceEm);
								 break;
							case "RateOfSocialInsuranceEm_desc":
                                query = isOrdered ? ordered.ThenByDescending(o => o.RateOfSocialInsuranceEm) : query.OrderByDescending(o => o.RateOfSocialInsuranceEm);
                                break;
							case "IsCompanyPaySI":
								query = isOrdered ? ordered.ThenBy(o => o.IsCompanyPaySI) : query.OrderBy(o => o.IsCompanyPaySI);
								 break;
							case "IsCompanyPaySI_desc":
                                query = isOrdered ? ordered.ThenByDescending(o => o.IsCompanyPaySI) : query.OrderByDescending(o => o.IsCompanyPaySI);
                                break;
							case "StartMonthPayingSI":
								query = isOrdered ? ordered.ThenBy(o => o.StartMonthPayingSI) : query.OrderBy(o => o.StartMonthPayingSI);
								 break;
							case "StartMonthPayingSI_desc":
                                query = isOrdered ? ordered.ThenByDescending(o => o.StartMonthPayingSI) : query.OrderByDescending(o => o.StartMonthPayingSI);
                                break;
							case "SINote":
								query = isOrdered ? ordered.ThenBy(o => o.SINote) : query.OrderBy(o => o.SINote);
								 break;
							case "SINote_desc":
                                query = isOrdered ? ordered.ThenByDescending(o => o.SINote) : query.OrderByDescending(o => o.SINote);
                                break;
							case "IsJoinedHI":
								query = isOrdered ? ordered.ThenBy(o => o.IsJoinedHI) : query.OrderBy(o => o.IsJoinedHI);
								 break;
							case "IsJoinedHI_desc":
                                query = isOrdered ? ordered.ThenByDescending(o => o.IsJoinedHI) : query.OrderByDescending(o => o.IsJoinedHI);
                                break;
							case "RateOfHealthInsuranceCo":
								query = isOrdered ? ordered.ThenBy(o => o.RateOfHealthInsuranceCo) : query.OrderBy(o => o.RateOfHealthInsuranceCo);
								 break;
							case "RateOfHealthInsuranceCo_desc":
                                query = isOrdered ? ordered.ThenByDescending(o => o.RateOfHealthInsuranceCo) : query.OrderByDescending(o => o.RateOfHealthInsuranceCo);
                                break;
							case "RateOfHealthInsuranceEm":
								query = isOrdered ? ordered.ThenBy(o => o.RateOfHealthInsuranceEm) : query.OrderBy(o => o.RateOfHealthInsuranceEm);
								 break;
							case "RateOfHealthInsuranceEm_desc":
                                query = isOrdered ? ordered.ThenByDescending(o => o.RateOfHealthInsuranceEm) : query.OrderByDescending(o => o.RateOfHealthInsuranceEm);
                                break;
							case "IsCompanyPayHI":
								query = isOrdered ? ordered.ThenBy(o => o.IsCompanyPayHI) : query.OrderBy(o => o.IsCompanyPayHI);
								 break;
							case "IsCompanyPayHI_desc":
                                query = isOrdered ? ordered.ThenByDescending(o => o.IsCompanyPayHI) : query.OrderByDescending(o => o.IsCompanyPayHI);
                                break;
							case "StartMonthPayingHI":
								query = isOrdered ? ordered.ThenBy(o => o.StartMonthPayingHI) : query.OrderBy(o => o.StartMonthPayingHI);
								 break;
							case "StartMonthPayingHI_desc":
                                query = isOrdered ? ordered.ThenByDescending(o => o.StartMonthPayingHI) : query.OrderByDescending(o => o.StartMonthPayingHI);
                                break;
							case "HINote":
								query = isOrdered ? ordered.ThenBy(o => o.HINote) : query.OrderBy(o => o.HINote);
								 break;
							case "HINote_desc":
                                query = isOrdered ? ordered.ThenByDescending(o => o.HINote) : query.OrderByDescending(o => o.HINote);
                                break;
							case "IsJoinedUI":
								query = isOrdered ? ordered.ThenBy(o => o.IsJoinedUI) : query.OrderBy(o => o.IsJoinedUI);
								 break;
							case "IsJoinedUI_desc":
                                query = isOrdered ? ordered.ThenByDescending(o => o.IsJoinedUI) : query.OrderByDescending(o => o.IsJoinedUI);
                                break;
							case "RateOfUnemploymentInsuranceCo":
								query = isOrdered ? ordered.ThenBy(o => o.RateOfUnemploymentInsuranceCo) : query.OrderBy(o => o.RateOfUnemploymentInsuranceCo);
								 break;
							case "RateOfUnemploymentInsuranceCo_desc":
                                query = isOrdered ? ordered.ThenByDescending(o => o.RateOfUnemploymentInsuranceCo) : query.OrderByDescending(o => o.RateOfUnemploymentInsuranceCo);
                                break;
							case "RateOfUnemploymentInsuranceEm":
								query = isOrdered ? ordered.ThenBy(o => o.RateOfUnemploymentInsuranceEm) : query.OrderBy(o => o.RateOfUnemploymentInsuranceEm);
								 break;
							case "RateOfUnemploymentInsuranceEm_desc":
                                query = isOrdered ? ordered.ThenByDescending(o => o.RateOfUnemploymentInsuranceEm) : query.OrderByDescending(o => o.RateOfUnemploymentInsuranceEm);
                                break;
							case "IsCompanyPayUI":
								query = isOrdered ? ordered.ThenBy(o => o.IsCompanyPayUI) : query.OrderBy(o => o.IsCompanyPayUI);
								 break;
							case "IsCompanyPayUI_desc":
                                query = isOrdered ? ordered.ThenByDescending(o => o.IsCompanyPayUI) : query.OrderByDescending(o => o.IsCompanyPayUI);
                                break;
							case "StartMonthPayingUI":
								query = isOrdered ? ordered.ThenBy(o => o.StartMonthPayingUI) : query.OrderBy(o => o.StartMonthPayingUI);
								 break;
							case "StartMonthPayingUI_desc":
                                query = isOrdered ? ordered.ThenByDescending(o => o.StartMonthPayingUI) : query.OrderByDescending(o => o.StartMonthPayingUI);
                                break;
							case "UINote":
								query = isOrdered ? ordered.ThenBy(o => o.UINote) : query.OrderBy(o => o.UINote);
								 break;
							case "UINote_desc":
                                query = isOrdered ? ordered.ThenByDescending(o => o.UINote) : query.OrderByDescending(o => o.UINote);
                                break;
							case "IsJoinedTUF":
								query = isOrdered ? ordered.ThenBy(o => o.IsJoinedTUF) : query.OrderBy(o => o.IsJoinedTUF);
								 break;
							case "IsJoinedTUF_desc":
                                query = isOrdered ? ordered.ThenByDescending(o => o.IsJoinedTUF) : query.OrderByDescending(o => o.IsJoinedTUF);
                                break;
							case "RateOfTradeUnionFeesCo":
								query = isOrdered ? ordered.ThenBy(o => o.RateOfTradeUnionFeesCo) : query.OrderBy(o => o.RateOfTradeUnionFeesCo);
								 break;
							case "RateOfTradeUnionFeesCo_desc":
                                query = isOrdered ? ordered.ThenByDescending(o => o.RateOfTradeUnionFeesCo) : query.OrderByDescending(o => o.RateOfTradeUnionFeesCo);
                                break;
							case "RateOfTradeUnionFeesEm":
								query = isOrdered ? ordered.ThenBy(o => o.RateOfTradeUnionFeesEm) : query.OrderBy(o => o.RateOfTradeUnionFeesEm);
								 break;
							case "RateOfTradeUnionFeesEm_desc":
                                query = isOrdered ? ordered.ThenByDescending(o => o.RateOfTradeUnionFeesEm) : query.OrderByDescending(o => o.RateOfTradeUnionFeesEm);
                                break;
							case "IsCompanyPayTUF":
								query = isOrdered ? ordered.ThenBy(o => o.IsCompanyPayTUF) : query.OrderBy(o => o.IsCompanyPayTUF);
								 break;
							case "IsCompanyPayTUF_desc":
                                query = isOrdered ? ordered.ThenByDescending(o => o.IsCompanyPayTUF) : query.OrderByDescending(o => o.IsCompanyPayTUF);
                                break;
							case "StartMonthPayingUF":
								query = isOrdered ? ordered.ThenBy(o => o.StartMonthPayingUF) : query.OrderBy(o => o.StartMonthPayingUF);
								 break;
							case "StartMonthPayingUF_desc":
                                query = isOrdered ? ordered.ThenByDescending(o => o.StartMonthPayingUF) : query.OrderByDescending(o => o.StartMonthPayingUF);
                                break;
							case "UFNote":
								query = isOrdered ? ordered.ThenBy(o => o.UFNote) : query.OrderBy(o => o.UFNote);
								 break;
							case "UFNote_desc":
                                query = isOrdered ? ordered.ThenByDescending(o => o.UFNote) : query.OrderByDescending(o => o.UFNote);
                                break;
							case "IsApproved":
								query = isOrdered ? ordered.ThenBy(o => o.IsApproved) : query.OrderBy(o => o.IsApproved);
								 break;
							case "IsApproved_desc":
                                query = isOrdered ? ordered.ThenByDescending(o => o.IsApproved) : query.OrderByDescending(o => o.IsApproved);
                                break;
							case "TotalOfRateOfCo":
								query = isOrdered ? ordered.ThenBy(o => o.TotalOfRateOfCo) : query.OrderBy(o => o.TotalOfRateOfCo);
								 break;
							case "TotalOfRateOfCo_desc":
                                query = isOrdered ? ordered.ThenByDescending(o => o.TotalOfRateOfCo) : query.OrderByDescending(o => o.TotalOfRateOfCo);
                                break;
							case "TotalOfRateOfEm":
								query = isOrdered ? ordered.ThenBy(o => o.TotalOfRateOfEm) : query.OrderBy(o => o.TotalOfRateOfEm);
								 break;
							case "TotalOfRateOfEm_desc":
                                query = isOrdered ? ordered.ThenByDescending(o => o.TotalOfRateOfEm) : query.OrderByDescending(o => o.TotalOfRateOfEm);
                                break;
							case "IsDeleted":
								query = isOrdered ? ordered.ThenBy(o => o.IsDeleted) : query.OrderBy(o => o.IsDeleted);
								 break;
							case "IsDeleted_desc":
                                query = isOrdered ? ordered.ThenByDescending(o => o.IsDeleted) : query.OrderByDescending(o => o.IsDeleted);
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

        public static IQueryable<tbl_HRM_StaffCompulsoryInsurance> _pagingBuilder(IQueryable<tbl_HRM_StaffCompulsoryInsurance> query, Dictionary<string, string> QueryStrings)
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






