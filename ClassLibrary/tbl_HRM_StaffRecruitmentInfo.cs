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
    
    
    public partial class tbl_HRM_StaffRecruitmentInfo
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
        public Nullable<int> IDRecruitmentSource { get; set; }
        public Nullable<System.DateTime> ApplyDate { get; set; }
        public Nullable<int> IDApplyJobTitle { get; set; }
        public Nullable<int> IDApplyDepartment { get; set; }
        public Nullable<int> IDRecruitmentForm { get; set; }
        public Nullable<int> IDProbationryDecisionSignedBy { get; set; }
        public Nullable<System.DateTime> ProbationryDecisionSignDate { get; set; }
        public Nullable<System.DateTime> ProbationryDecisionEffectiveDate { get; set; }
        public Nullable<System.DateTime> ProbationryStartDate { get; set; }
        public Nullable<System.DateTime> ProbationryEndDate { get; set; }
        public Nullable<int> IDMainProbationryJobTitle { get; set; }
        public bool IsDeleted { get; set; }
        //List 0:1
        public virtual tbl_BRA_Branch tbl_BRA_Branch { get; set; }
        //List 0:1
        public virtual tbl_BRA_Branch tbl_BRA_Branch1 { get; set; }
        //List 0:1
        public virtual tbl_HRM_Staff tbl_HRM_Staff { get; set; }
        //List 0:1
        public virtual tbl_HRM_Staff tbl_HRM_Staff1 { get; set; }
        //List 0:1
        public virtual tbl_LIST_General tbl_LIST_General { get; set; }
        //List 0:1
        public virtual tbl_LIST_General tbl_LIST_General1 { get; set; }
    }
}


namespace DTOModel
{
	using System;
	public partial class DTO_HRM_StaffRecruitmentInfo
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
		public Nullable<int> IDRecruitmentSource { get; set; }
		public Nullable<System.DateTime> ApplyDate { get; set; }
		public Nullable<int> IDApplyJobTitle { get; set; }
		public Nullable<int> IDApplyDepartment { get; set; }
		public Nullable<int> IDRecruitmentForm { get; set; }
		public Nullable<int> IDProbationryDecisionSignedBy { get; set; }
		public Nullable<System.DateTime> ProbationryDecisionSignDate { get; set; }
		public Nullable<System.DateTime> ProbationryDecisionEffectiveDate { get; set; }
		public Nullable<System.DateTime> ProbationryStartDate { get; set; }
		public Nullable<System.DateTime> ProbationryEndDate { get; set; }
		public Nullable<int> IDMainProbationryJobTitle { get; set; }
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

    public static partial class BS_HRM_StaffRecruitmentInfo 
    {
        public static dynamic getSearch(AppEntities db, int IDBranch, int StaffID, Dictionary<string, string> QueryStrings)
        {
            return get(db, IDBranch,StaffID, QueryStrings);
        }

		public static IQueryable<DTO_HRM_StaffRecruitmentInfo> get(AppEntities db, int IDBranch, int StaffID, Dictionary<string, string> QueryStrings)
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
            package.Workbook.Properties.Title = "ART-DMS HRM_StaffRecruitmentInfo";
            package.Workbook.Properties.Author = "hung.vu@codeart.vn";
            package.Workbook.Properties.Application = "ART-DMS";
            package.Workbook.Properties.Company = "A.R.T Distribution";

            ExcelWorkbook workBook = package.Workbook;
            if (workBook != null)
            {
                var ws = workBook.Worksheets.FirstOrDefault();
                var data = _queryBuilder(db, IDBranch, StaffID, QueryStrings).ToList();

                //var BRA_BranchList = BS_BRA_Branch.get(db,IDBranch, StaffID,QueryStrings).Select(s => new ItemModel { Id = s.Id, Name = s.Name });
                //var BRA_Branch1List = BS_BRA_Branch.get(db,IDBranch, StaffID,QueryStrings).Select(s => new ItemModel { Id = s.Id, Name = s.Name });
                //var HRM_StaffList = BS_HRM_Staff.get(db,IDBranch, StaffID,QueryStrings).Select(s => new ItemModel { Id = s.Id, Name = s.Name });
                //var HRM_Staff1List = BS_HRM_Staff.get(db,IDBranch, StaffID,QueryStrings).Select(s => new ItemModel { Id = s.Id, Name = s.Name });
                //var LIST_GeneralList = BS_LIST_General.get(db,IDBranch, StaffID,QueryStrings).Select(s => new ItemModel { Id = s.Id, Name = s.Name });
                //var LIST_General1List = BS_LIST_General.get(db,IDBranch, StaffID,QueryStrings).Select(s => new ItemModel { Id = s.Id, Name = s.Name });
                 

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

		public static DTO_HRM_StaffRecruitmentInfo getAnItem(AppEntities db, int IDBranch, int StaffID, int id)
        {
            var dbResult = db.tbl_HRM_StaffRecruitmentInfo.Find(id);

			return toDTO(dbResult);
			
        }
		
		public static DTO_HRM_StaffRecruitmentInfo getAnItemByCode(AppEntities db, int IDBranch, int StaffID, string code)
        {
            var dbResult = db.tbl_HRM_StaffRecruitmentInfo
			.FirstOrDefault(d => d.IsDeleted == false && d.Code == code );

			return toDTO(dbResult);
			
        }

		public static bool put(AppEntities db, int IDBranch, int StaffID, int Id, dynamic item, string Username, Dictionary<string, string> QueryStrings)
        {
            bool result = false;
            var dbitem = db.tbl_HRM_StaffRecruitmentInfo.Find(Id);
            
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
					errorLog.logMessage("put_HRM_StaffRecruitmentInfo",e);
                    result = false;
                }
            }
            else
                if (QueryStrings.Any(d => d.Key == "ForceCreate"))
                    result =  post(db, IDBranch, StaffID, item, Username) != null;
                
            return result;
        }

        public static void patchDynamicToDB(dynamic item, tbl_HRM_StaffRecruitmentInfo dbitem, string Username)
        {
            Type type = typeof(tbl_HRM_StaffRecruitmentInfo);
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

        public static void patchDTOtoDBValue( DTO_HRM_StaffRecruitmentInfo item, tbl_HRM_StaffRecruitmentInfo dbitem)
        {
            if (item == null){
                dbitem = null;
                return;
            }
            							
			dbitem.Code = item.Code;							
			dbitem.Name = item.Name;							
			dbitem.Remark = item.Remark;							
			dbitem.Sort = item.Sort;							
			dbitem.IDRecruitmentSource = item.IDRecruitmentSource;							
			dbitem.ApplyDate = item.ApplyDate;							
			dbitem.IDApplyJobTitle = item.IDApplyJobTitle;							
			dbitem.IDApplyDepartment = item.IDApplyDepartment;							
			dbitem.IDRecruitmentForm = item.IDRecruitmentForm;							
			dbitem.IDProbationryDecisionSignedBy = item.IDProbationryDecisionSignedBy;							
			dbitem.ProbationryDecisionSignDate = item.ProbationryDecisionSignDate;							
			dbitem.ProbationryDecisionEffectiveDate = item.ProbationryDecisionEffectiveDate;							
			dbitem.ProbationryStartDate = item.ProbationryStartDate;							
			dbitem.ProbationryEndDate = item.ProbationryEndDate;							
			dbitem.IDMainProbationryJobTitle = item.IDMainProbationryJobTitle;							
			dbitem.IsDeleted = item.IsDeleted;        }

		public static DTO_HRM_StaffRecruitmentInfo post(AppEntities db, int IDBranch, int StaffID, dynamic item, string Username)
        {
            tbl_HRM_StaffRecruitmentInfo dbitem = new tbl_HRM_StaffRecruitmentInfo();
            if (item != null)
            {
                patchDynamicToDB(item, dbitem, Username);
                
				dbitem.CreatedBy = Username;
				dbitem.CreatedDate = DateTime.Now;				
                try
                {
					db.tbl_HRM_StaffRecruitmentInfo.Add(dbitem);
                    db.SaveChanges();
				
                }
                catch (DbEntityValidationException e)
                {
					errorLog.logMessage("post_HRM_StaffRecruitmentInfo",e);
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
                Type type = Type.GetType("BaseBusiness.BS_HRM_StaffRecruitmentInfo, ClassLibrary");
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
                        var target = new tbl_HRM_StaffRecruitmentInfo();
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
                    
                    tbl_HRM_StaffRecruitmentInfo dbitem = new tbl_HRM_StaffRecruitmentInfo();
                    if (it.Id == null || string.IsNullOrEmpty(it.Id.Value) || it.Id == "0")
                    {
                        dbitem = new tbl_HRM_StaffRecruitmentInfo();
                        dbitem.CreatedBy = Username;
				        dbitem.CreatedDate = DateTime.Now;
                                            }
                    else
                    {
                        dbitem = db.tbl_HRM_StaffRecruitmentInfo.Find((int)it.Id);
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
                        
                        if (dbitem.Id == 0) db.tbl_HRM_StaffRecruitmentInfo.Add(dbitem);
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
                    errorLog.logMessage("post_HRM_StaffRecruitmentInfo",e);
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

            var dbitems = db.tbl_HRM_StaffRecruitmentInfo.Where(d => IDs.Contains(d.Id));
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
			
                BS_Version.update_Version(db, null, "DTO_HRM_StaffRecruitmentInfo", updateDate, Username);
			
            }
            catch (DbEntityValidationException e)
            {
				errorLog.logMessage("delete_HRM_StaffRecruitmentInfo",e);
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
             
            return db.tbl_HRM_StaffRecruitmentInfo.Any(e => e.Id == id && e.IsDeleted == false);
            
		}
		
		public static bool check_Exists(AppEntities db, string Code)
		{
             
            return db.tbl_HRM_StaffRecruitmentInfo.Any(e => e.Code == Code && e.IsDeleted == false);
            
		}
		
		//---//
		public static IQueryable<DTO_HRM_StaffRecruitmentInfo> toDTO(IQueryable<tbl_HRM_StaffRecruitmentInfo> query)
        {
			return query
			.Select(s => new DTO_HRM_StaffRecruitmentInfo(){							
				Id = s.Id,							
				Code = s.Code,							
				Name = s.Name,							
				Remark = s.Remark,							
				Sort = s.Sort,							
				CreatedBy = s.CreatedBy,							
				ModifiedBy = s.ModifiedBy,							
				CreatedDate = s.CreatedDate,							
				ModifiedDate = s.ModifiedDate,							
				IDRecruitmentSource = s.IDRecruitmentSource,							
				ApplyDate = s.ApplyDate,							
				IDApplyJobTitle = s.IDApplyJobTitle,							
				IDApplyDepartment = s.IDApplyDepartment,							
				IDRecruitmentForm = s.IDRecruitmentForm,							
				IDProbationryDecisionSignedBy = s.IDProbationryDecisionSignedBy,							
				ProbationryDecisionSignDate = s.ProbationryDecisionSignDate,							
				ProbationryDecisionEffectiveDate = s.ProbationryDecisionEffectiveDate,							
				ProbationryStartDate = s.ProbationryStartDate,							
				ProbationryEndDate = s.ProbationryEndDate,							
				IDMainProbationryJobTitle = s.IDMainProbationryJobTitle,							
				IsDeleted = s.IsDeleted,					
			});//.OrderBy(o => o.Sort == null).ThenBy(u => u.Sort);
                              
        }

		public static DTO_HRM_StaffRecruitmentInfo toDTO(tbl_HRM_StaffRecruitmentInfo dbResult)
        {
			if (dbResult != null)
			{
				return new DTO_HRM_StaffRecruitmentInfo()
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
					IDRecruitmentSource = dbResult.IDRecruitmentSource,							
					ApplyDate = dbResult.ApplyDate,							
					IDApplyJobTitle = dbResult.IDApplyJobTitle,							
					IDApplyDepartment = dbResult.IDApplyDepartment,							
					IDRecruitmentForm = dbResult.IDRecruitmentForm,							
					IDProbationryDecisionSignedBy = dbResult.IDProbationryDecisionSignedBy,							
					ProbationryDecisionSignDate = dbResult.ProbationryDecisionSignDate,							
					ProbationryDecisionEffectiveDate = dbResult.ProbationryDecisionEffectiveDate,							
					ProbationryStartDate = dbResult.ProbationryStartDate,							
					ProbationryEndDate = dbResult.ProbationryEndDate,							
					IDMainProbationryJobTitle = dbResult.IDMainProbationryJobTitle,							
					IsDeleted = dbResult.IsDeleted,
				};
			}
			else
				return null; 
        }

		public static IQueryable<tbl_HRM_StaffRecruitmentInfo> _queryBuilder(AppEntities db, int IDBranch, int StaffID, Dictionary<string, string> QueryStrings)
        {
            
			IQueryable<tbl_HRM_StaffRecruitmentInfo> query = db.tbl_HRM_StaffRecruitmentInfo.AsNoTracking();//.Where(d => d.IsDeleted == false );
			

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


			//Query IDRecruitmentSource (Nullable<int>)
			if (QueryStrings.Any(d => d.Key == "IDRecruitmentSource"))
            {
                var IDList = QueryStrings.FirstOrDefault(d => d.Key == "IDRecruitmentSource").Value.Replace("[", "").Replace("]", "").Split(',');
                List<int?> IDs = new List<int?>();
                foreach (var item in IDList)
                    if (int.TryParse(item, out int i))
                        IDs.Add(i);
					else if (item == "null")
						IDs.Add(null);
                if (IDs.Count > 0)
                    query = query.Where(d => IDs.Contains(d.IDRecruitmentSource));
////                    query = query.Where(d => IDs.Contains(d.IDRecruitmentSource));
//                    
            }

			//Query ApplyDate (Nullable<System.DateTime>)
			if (QueryStrings.Any(d => d.Key == "ApplyDateFrom") && QueryStrings.Any(d => d.Key == "ApplyDateTo"))
                if (DateTime.TryParse(QueryStrings.FirstOrDefault(d => d.Key == "ApplyDateFrom").Value, out DateTime fromDate) && DateTime.TryParse(QueryStrings.FirstOrDefault(d => d.Key == "ApplyDateTo").Value, out DateTime toDate))
                    query = query.Where(d => fromDate <= d.ApplyDate && d.ApplyDate <= toDate);

            if (QueryStrings.Any(d => d.Key == "ApplyDate"))
                if (DateTime.TryParse(QueryStrings.FirstOrDefault(d => d.Key == "ApplyDate").Value, out DateTime val))
                    query = query.Where(d => d.ApplyDate != null && DbFunctions.TruncateTime(val) == DbFunctions.TruncateTime(d.ApplyDate));


			//Query IDApplyJobTitle (Nullable<int>)
			if (QueryStrings.Any(d => d.Key == "IDApplyJobTitle"))
            {
                var IDList = QueryStrings.FirstOrDefault(d => d.Key == "IDApplyJobTitle").Value.Replace("[", "").Replace("]", "").Split(',');
                List<int?> IDs = new List<int?>();
                foreach (var item in IDList)
                    if (int.TryParse(item, out int i))
                        IDs.Add(i);
					else if (item == "null")
						IDs.Add(null);
                if (IDs.Count > 0)
                    query = query.Where(d => IDs.Contains(d.IDApplyJobTitle));
////                    query = query.Where(d => IDs.Contains(d.IDApplyJobTitle));
//                    
            }

			//Query IDApplyDepartment (Nullable<int>)
			if (QueryStrings.Any(d => d.Key == "IDApplyDepartment"))
            {
                var IDList = QueryStrings.FirstOrDefault(d => d.Key == "IDApplyDepartment").Value.Replace("[", "").Replace("]", "").Split(',');
                List<int?> IDs = new List<int?>();
                foreach (var item in IDList)
                    if (int.TryParse(item, out int i))
                        IDs.Add(i);
					else if (item == "null")
						IDs.Add(null);
                if (IDs.Count > 0)
                    query = query.Where(d => IDs.Contains(d.IDApplyDepartment));
////                    query = query.Where(d => IDs.Contains(d.IDApplyDepartment));
//                    
            }

			//Query IDRecruitmentForm (Nullable<int>)
			if (QueryStrings.Any(d => d.Key == "IDRecruitmentForm"))
            {
                var IDList = QueryStrings.FirstOrDefault(d => d.Key == "IDRecruitmentForm").Value.Replace("[", "").Replace("]", "").Split(',');
                List<int?> IDs = new List<int?>();
                foreach (var item in IDList)
                    if (int.TryParse(item, out int i))
                        IDs.Add(i);
					else if (item == "null")
						IDs.Add(null);
                if (IDs.Count > 0)
                    query = query.Where(d => IDs.Contains(d.IDRecruitmentForm));
////                    query = query.Where(d => IDs.Contains(d.IDRecruitmentForm));
//                    
            }

			//Query IDProbationryDecisionSignedBy (Nullable<int>)
			if (QueryStrings.Any(d => d.Key == "IDProbationryDecisionSignedBy"))
            {
                var IDList = QueryStrings.FirstOrDefault(d => d.Key == "IDProbationryDecisionSignedBy").Value.Replace("[", "").Replace("]", "").Split(',');
                List<int?> IDs = new List<int?>();
                foreach (var item in IDList)
                    if (int.TryParse(item, out int i))
                        IDs.Add(i);
					else if (item == "null")
						IDs.Add(null);
                if (IDs.Count > 0)
                    query = query.Where(d => IDs.Contains(d.IDProbationryDecisionSignedBy));
////                    query = query.Where(d => IDs.Contains(d.IDProbationryDecisionSignedBy));
//                    
            }

			//Query ProbationryDecisionSignDate (Nullable<System.DateTime>)
			if (QueryStrings.Any(d => d.Key == "ProbationryDecisionSignDateFrom") && QueryStrings.Any(d => d.Key == "ProbationryDecisionSignDateTo"))
                if (DateTime.TryParse(QueryStrings.FirstOrDefault(d => d.Key == "ProbationryDecisionSignDateFrom").Value, out DateTime fromDate) && DateTime.TryParse(QueryStrings.FirstOrDefault(d => d.Key == "ProbationryDecisionSignDateTo").Value, out DateTime toDate))
                    query = query.Where(d => fromDate <= d.ProbationryDecisionSignDate && d.ProbationryDecisionSignDate <= toDate);

            if (QueryStrings.Any(d => d.Key == "ProbationryDecisionSignDate"))
                if (DateTime.TryParse(QueryStrings.FirstOrDefault(d => d.Key == "ProbationryDecisionSignDate").Value, out DateTime val))
                    query = query.Where(d => d.ProbationryDecisionSignDate != null && DbFunctions.TruncateTime(val) == DbFunctions.TruncateTime(d.ProbationryDecisionSignDate));


			//Query ProbationryDecisionEffectiveDate (Nullable<System.DateTime>)
			if (QueryStrings.Any(d => d.Key == "ProbationryDecisionEffectiveDateFrom") && QueryStrings.Any(d => d.Key == "ProbationryDecisionEffectiveDateTo"))
                if (DateTime.TryParse(QueryStrings.FirstOrDefault(d => d.Key == "ProbationryDecisionEffectiveDateFrom").Value, out DateTime fromDate) && DateTime.TryParse(QueryStrings.FirstOrDefault(d => d.Key == "ProbationryDecisionEffectiveDateTo").Value, out DateTime toDate))
                    query = query.Where(d => fromDate <= d.ProbationryDecisionEffectiveDate && d.ProbationryDecisionEffectiveDate <= toDate);

            if (QueryStrings.Any(d => d.Key == "ProbationryDecisionEffectiveDate"))
                if (DateTime.TryParse(QueryStrings.FirstOrDefault(d => d.Key == "ProbationryDecisionEffectiveDate").Value, out DateTime val))
                    query = query.Where(d => d.ProbationryDecisionEffectiveDate != null && DbFunctions.TruncateTime(val) == DbFunctions.TruncateTime(d.ProbationryDecisionEffectiveDate));


			//Query ProbationryStartDate (Nullable<System.DateTime>)
			if (QueryStrings.Any(d => d.Key == "ProbationryStartDateFrom") && QueryStrings.Any(d => d.Key == "ProbationryStartDateTo"))
                if (DateTime.TryParse(QueryStrings.FirstOrDefault(d => d.Key == "ProbationryStartDateFrom").Value, out DateTime fromDate) && DateTime.TryParse(QueryStrings.FirstOrDefault(d => d.Key == "ProbationryStartDateTo").Value, out DateTime toDate))
                    query = query.Where(d => fromDate <= d.ProbationryStartDate && d.ProbationryStartDate <= toDate);

            if (QueryStrings.Any(d => d.Key == "ProbationryStartDate"))
                if (DateTime.TryParse(QueryStrings.FirstOrDefault(d => d.Key == "ProbationryStartDate").Value, out DateTime val))
                    query = query.Where(d => d.ProbationryStartDate != null && DbFunctions.TruncateTime(val) == DbFunctions.TruncateTime(d.ProbationryStartDate));


			//Query ProbationryEndDate (Nullable<System.DateTime>)
			if (QueryStrings.Any(d => d.Key == "ProbationryEndDateFrom") && QueryStrings.Any(d => d.Key == "ProbationryEndDateTo"))
                if (DateTime.TryParse(QueryStrings.FirstOrDefault(d => d.Key == "ProbationryEndDateFrom").Value, out DateTime fromDate) && DateTime.TryParse(QueryStrings.FirstOrDefault(d => d.Key == "ProbationryEndDateTo").Value, out DateTime toDate))
                    query = query.Where(d => fromDate <= d.ProbationryEndDate && d.ProbationryEndDate <= toDate);

            if (QueryStrings.Any(d => d.Key == "ProbationryEndDate"))
                if (DateTime.TryParse(QueryStrings.FirstOrDefault(d => d.Key == "ProbationryEndDate").Value, out DateTime val))
                    query = query.Where(d => d.ProbationryEndDate != null && DbFunctions.TruncateTime(val) == DbFunctions.TruncateTime(d.ProbationryEndDate));


			//Query IDMainProbationryJobTitle (Nullable<int>)
			if (QueryStrings.Any(d => d.Key == "IDMainProbationryJobTitle"))
            {
                var IDList = QueryStrings.FirstOrDefault(d => d.Key == "IDMainProbationryJobTitle").Value.Replace("[", "").Replace("]", "").Split(',');
                List<int?> IDs = new List<int?>();
                foreach (var item in IDList)
                    if (int.TryParse(item, out int i))
                        IDs.Add(i);
					else if (item == "null")
						IDs.Add(null);
                if (IDs.Count > 0)
                    query = query.Where(d => IDs.Contains(d.IDMainProbationryJobTitle));
////                    query = query.Where(d => IDs.Contains(d.IDMainProbationryJobTitle));
//                    
            }

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
		
        public static IQueryable<tbl_HRM_StaffRecruitmentInfo> _sortBuilder(IQueryable<tbl_HRM_StaffRecruitmentInfo> query, Dictionary<string, string> QueryStrings)
        {
            if (QueryStrings.Any(d => d.Key == "SortBy"))
            {
                var sorts = QueryStrings.FirstOrDefault(d => d.Key == "SortBy").Value.Replace("[", "").Replace("]", "").Split(',');
                
                foreach (var item in sorts)
                    if (!string.IsNullOrEmpty(item))
                    {
                        var ordered = query as IOrderedQueryable<tbl_HRM_StaffRecruitmentInfo>;
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
							case "IDRecruitmentSource":
								query = isOrdered ? ordered.ThenBy(o => o.IDRecruitmentSource) : query.OrderBy(o => o.IDRecruitmentSource);
								 break;
							case "IDRecruitmentSource_desc":
                                query = isOrdered ? ordered.ThenByDescending(o => o.IDRecruitmentSource) : query.OrderByDescending(o => o.IDRecruitmentSource);
                                break;
							case "ApplyDate":
								query = isOrdered ? ordered.ThenBy(o => o.ApplyDate) : query.OrderBy(o => o.ApplyDate);
								 break;
							case "ApplyDate_desc":
                                query = isOrdered ? ordered.ThenByDescending(o => o.ApplyDate) : query.OrderByDescending(o => o.ApplyDate);
                                break;
							case "IDApplyJobTitle":
								query = isOrdered ? ordered.ThenBy(o => o.IDApplyJobTitle) : query.OrderBy(o => o.IDApplyJobTitle);
								 break;
							case "IDApplyJobTitle_desc":
                                query = isOrdered ? ordered.ThenByDescending(o => o.IDApplyJobTitle) : query.OrderByDescending(o => o.IDApplyJobTitle);
                                break;
							case "IDApplyDepartment":
								query = isOrdered ? ordered.ThenBy(o => o.IDApplyDepartment) : query.OrderBy(o => o.IDApplyDepartment);
								 break;
							case "IDApplyDepartment_desc":
                                query = isOrdered ? ordered.ThenByDescending(o => o.IDApplyDepartment) : query.OrderByDescending(o => o.IDApplyDepartment);
                                break;
							case "IDRecruitmentForm":
								query = isOrdered ? ordered.ThenBy(o => o.IDRecruitmentForm) : query.OrderBy(o => o.IDRecruitmentForm);
								 break;
							case "IDRecruitmentForm_desc":
                                query = isOrdered ? ordered.ThenByDescending(o => o.IDRecruitmentForm) : query.OrderByDescending(o => o.IDRecruitmentForm);
                                break;
							case "IDProbationryDecisionSignedBy":
								query = isOrdered ? ordered.ThenBy(o => o.IDProbationryDecisionSignedBy) : query.OrderBy(o => o.IDProbationryDecisionSignedBy);
								 break;
							case "IDProbationryDecisionSignedBy_desc":
                                query = isOrdered ? ordered.ThenByDescending(o => o.IDProbationryDecisionSignedBy) : query.OrderByDescending(o => o.IDProbationryDecisionSignedBy);
                                break;
							case "ProbationryDecisionSignDate":
								query = isOrdered ? ordered.ThenBy(o => o.ProbationryDecisionSignDate) : query.OrderBy(o => o.ProbationryDecisionSignDate);
								 break;
							case "ProbationryDecisionSignDate_desc":
                                query = isOrdered ? ordered.ThenByDescending(o => o.ProbationryDecisionSignDate) : query.OrderByDescending(o => o.ProbationryDecisionSignDate);
                                break;
							case "ProbationryDecisionEffectiveDate":
								query = isOrdered ? ordered.ThenBy(o => o.ProbationryDecisionEffectiveDate) : query.OrderBy(o => o.ProbationryDecisionEffectiveDate);
								 break;
							case "ProbationryDecisionEffectiveDate_desc":
                                query = isOrdered ? ordered.ThenByDescending(o => o.ProbationryDecisionEffectiveDate) : query.OrderByDescending(o => o.ProbationryDecisionEffectiveDate);
                                break;
							case "ProbationryStartDate":
								query = isOrdered ? ordered.ThenBy(o => o.ProbationryStartDate) : query.OrderBy(o => o.ProbationryStartDate);
								 break;
							case "ProbationryStartDate_desc":
                                query = isOrdered ? ordered.ThenByDescending(o => o.ProbationryStartDate) : query.OrderByDescending(o => o.ProbationryStartDate);
                                break;
							case "ProbationryEndDate":
								query = isOrdered ? ordered.ThenBy(o => o.ProbationryEndDate) : query.OrderBy(o => o.ProbationryEndDate);
								 break;
							case "ProbationryEndDate_desc":
                                query = isOrdered ? ordered.ThenByDescending(o => o.ProbationryEndDate) : query.OrderByDescending(o => o.ProbationryEndDate);
                                break;
							case "IDMainProbationryJobTitle":
								query = isOrdered ? ordered.ThenBy(o => o.IDMainProbationryJobTitle) : query.OrderBy(o => o.IDMainProbationryJobTitle);
								 break;
							case "IDMainProbationryJobTitle_desc":
                                query = isOrdered ? ordered.ThenByDescending(o => o.IDMainProbationryJobTitle) : query.OrderByDescending(o => o.IDMainProbationryJobTitle);
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

        public static IQueryable<tbl_HRM_StaffRecruitmentInfo> _pagingBuilder(IQueryable<tbl_HRM_StaffRecruitmentInfo> query, Dictionary<string, string> QueryStrings)
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






