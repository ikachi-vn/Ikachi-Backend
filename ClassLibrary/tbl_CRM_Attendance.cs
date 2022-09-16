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
    
    
    public partial class tbl_CRM_Attendance
    {
        public int Id { get; set; }
        public Nullable<System.DateTime> PartyDate { get; set; }
        public string CustomerName { get; set; }
        public string Email { get; set; }
        public Nullable<System.DateTime> DOB { get; set; }
        public Nullable<int> LunchPax { get; set; }
        public Nullable<int> DinnerPax { get; set; }
        public Nullable<int> RealField { get; set; }
        public Nullable<int> Kids { get; set; }
        public string RegisteredTable { get; set; }
        public string TypeOfParty { get; set; }
        public string BillingInformation { get; set; }
        public string Status { get; set; }
        public string DiningCard { get; set; }
        public Nullable<int> Arrivaled { get; set; }
        public string CustomerType { get; set; }
        public string Phone { get; set; }
        public Nullable<int> NoRecords { get; set; }
        public Nullable<int> ForeignerNo { get; set; }
        public string TableOfLunch { get; set; }
        public string TimeOfParty { get; set; }
        public string CustomerGroup { get; set; }
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
    }
}


namespace DTOModel
{
	using System;
	public partial class DTO_CRM_Attendance
	{
		public int Id { get; set; }
		public Nullable<System.DateTime> PartyDate { get; set; }
		public string CustomerName { get; set; }
		public string Email { get; set; }
		public Nullable<System.DateTime> DOB { get; set; }
		public Nullable<int> LunchPax { get; set; }
		public Nullable<int> DinnerPax { get; set; }
		public Nullable<int> RealField { get; set; }
		public Nullable<int> Kids { get; set; }
		public string RegisteredTable { get; set; }
		public string TypeOfParty { get; set; }
		public string BillingInformation { get; set; }
		public string Status { get; set; }
		public string DiningCard { get; set; }
		public Nullable<int> Arrivaled { get; set; }
		public string CustomerType { get; set; }
		public string Phone { get; set; }
		public Nullable<int> NoRecords { get; set; }
		public Nullable<int> ForeignerNo { get; set; }
		public string TableOfLunch { get; set; }
		public string TimeOfParty { get; set; }
		public string CustomerGroup { get; set; }
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

    public static partial class BS_CRM_Attendance 
    {
        public static dynamic getSearch(AppEntities db, int IDBranch, int StaffID, Dictionary<string, string> QueryStrings)
        {
            return get(db, IDBranch,StaffID, QueryStrings);
        }

		public static IQueryable<DTO_CRM_Attendance> get(AppEntities db, int IDBranch, int StaffID, Dictionary<string, string> QueryStrings)
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
            package.Workbook.Properties.Title = "ART-DMS CRM_Attendance";
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

		public static DTO_CRM_Attendance getAnItem(AppEntities db, int IDBranch, int StaffID, int id)
        {
            var dbResult = db.tbl_CRM_Attendance.Find(id);

			return toDTO(dbResult);
			
        }
		
		public static DTO_CRM_Attendance getAnItemByCode(AppEntities db, int IDBranch, int StaffID, string code)
        {
            var dbResult = db.tbl_CRM_Attendance
			.FirstOrDefault(d => d.IsDeleted == false && d.Code == code );

			return toDTO(dbResult);
			
        }

		public static bool put(AppEntities db, int IDBranch, int StaffID, int Id, dynamic item, string Username, Dictionary<string, string> QueryStrings)
        {
            bool result = false;
            var dbitem = db.tbl_CRM_Attendance.Find(Id);
            
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
					errorLog.logMessage("put_CRM_Attendance",e);
                    result = false;
                }
            }
            else
                if (QueryStrings.Any(d => d.Key == "ForceCreate"))
                    result =  post(db, IDBranch, StaffID, item, Username) != null;
                
            return result;
        }

        public static void patchDynamicToDB(dynamic item, tbl_CRM_Attendance dbitem, string Username)
        {
            Type type = typeof(tbl_CRM_Attendance);
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

        public static void patchDTOtoDBValue( DTO_CRM_Attendance item, tbl_CRM_Attendance dbitem)
        {
            if (item == null){
                dbitem = null;
                return;
            }
            							
			dbitem.PartyDate = item.PartyDate;							
			dbitem.CustomerName = item.CustomerName;							
			dbitem.Email = item.Email;							
			dbitem.DOB = item.DOB;							
			dbitem.LunchPax = item.LunchPax;							
			dbitem.DinnerPax = item.DinnerPax;							
			dbitem.RealField = item.RealField;							
			dbitem.Kids = item.Kids;							
			dbitem.RegisteredTable = item.RegisteredTable;							
			dbitem.TypeOfParty = item.TypeOfParty;							
			dbitem.BillingInformation = item.BillingInformation;							
			dbitem.Status = item.Status;							
			dbitem.DiningCard = item.DiningCard;							
			dbitem.Arrivaled = item.Arrivaled;							
			dbitem.CustomerType = item.CustomerType;							
			dbitem.Phone = item.Phone;							
			dbitem.NoRecords = item.NoRecords;							
			dbitem.ForeignerNo = item.ForeignerNo;							
			dbitem.TableOfLunch = item.TableOfLunch;							
			dbitem.TimeOfParty = item.TimeOfParty;							
			dbitem.CustomerGroup = item.CustomerGroup;							
			dbitem.Code = item.Code;							
			dbitem.Name = item.Name;							
			dbitem.Remark = item.Remark;							
			dbitem.Sort = item.Sort;							
			dbitem.IsDisabled = item.IsDisabled;							
			dbitem.IsDeleted = item.IsDeleted;        }

		public static DTO_CRM_Attendance post(AppEntities db, int IDBranch, int StaffID, dynamic item, string Username)
        {
            tbl_CRM_Attendance dbitem = new tbl_CRM_Attendance();
            if (item != null)
            {
                patchDynamicToDB(item, dbitem, Username);
                
				dbitem.CreatedBy = Username;
				dbitem.CreatedDate = DateTime.Now;				
                try
                {
					db.tbl_CRM_Attendance.Add(dbitem);
                    db.SaveChanges();
				
                }
                catch (DbEntityValidationException e)
                {
					errorLog.logMessage("post_CRM_Attendance",e);
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
                Type type = Type.GetType("BaseBusiness.BS_CRM_Attendance, ClassLibrary");
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
                        var target = new tbl_CRM_Attendance();
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
                    
                    tbl_CRM_Attendance dbitem = new tbl_CRM_Attendance();
                    if (it.Id == null || string.IsNullOrEmpty(it.Id.Value) || it.Id == "0")
                    {
                        dbitem = new tbl_CRM_Attendance();
                        dbitem.CreatedBy = Username;
				        dbitem.CreatedDate = DateTime.Now;
                                            }
                    else
                    {
                        dbitem = db.tbl_CRM_Attendance.Find((int)it.Id);
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
                        
                        if (dbitem.Id == 0) db.tbl_CRM_Attendance.Add(dbitem);
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
                    errorLog.logMessage("post_CRM_Attendance",e);
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

            var dbitems = db.tbl_CRM_Attendance.Where(d => IDs.Contains(d.Id));
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
			
                BS_Version.update_Version(db, null, "DTO_CRM_Attendance", updateDate, Username);
			
            }
            catch (DbEntityValidationException e)
            {
				errorLog.logMessage("delete_CRM_Attendance",e);
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

			
            var dbitems = db.tbl_CRM_Attendance.Where(d => IDs.Contains(d.Id));
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
			
                BS_Version.update_Version(db, null, "DTO_CRM_Attendance", updateDate, Username);
			
            }
            catch (DbEntityValidationException e)
            {
				errorLog.logMessage("disable_CRM_Attendance",e);
                result = false;
            }
            
            return result;
        }

		
		//---//
		public static bool check_Exists(AppEntities db, int id)
		{
             
            return db.tbl_CRM_Attendance.Any(e => e.Id == id && e.IsDeleted == false);
            
		}
		
		public static bool check_Exists(AppEntities db, string Code)
		{
             
            return db.tbl_CRM_Attendance.Any(e => e.Code == Code && e.IsDeleted == false);
            
		}
		
		//---//
		public static IQueryable<DTO_CRM_Attendance> toDTO(IQueryable<tbl_CRM_Attendance> query)
        {
			return query
			.Select(s => new DTO_CRM_Attendance(){							
				Id = s.Id,							
				PartyDate = s.PartyDate,							
				CustomerName = s.CustomerName,							
				Email = s.Email,							
				DOB = s.DOB,							
				LunchPax = s.LunchPax,							
				DinnerPax = s.DinnerPax,							
				RealField = s.RealField,							
				Kids = s.Kids,							
				RegisteredTable = s.RegisteredTable,							
				TypeOfParty = s.TypeOfParty,							
				BillingInformation = s.BillingInformation,							
				Status = s.Status,							
				DiningCard = s.DiningCard,							
				Arrivaled = s.Arrivaled,							
				CustomerType = s.CustomerType,							
				Phone = s.Phone,							
				NoRecords = s.NoRecords,							
				ForeignerNo = s.ForeignerNo,							
				TableOfLunch = s.TableOfLunch,							
				TimeOfParty = s.TimeOfParty,							
				CustomerGroup = s.CustomerGroup,							
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
			});//.OrderBy(o => o.Sort == null).ThenBy(u => u.Sort);
                              
        }

		public static DTO_CRM_Attendance toDTO(tbl_CRM_Attendance dbResult)
        {
			if (dbResult != null)
			{
				return new DTO_CRM_Attendance()
				{							
					Id = dbResult.Id,							
					PartyDate = dbResult.PartyDate,							
					CustomerName = dbResult.CustomerName,							
					Email = dbResult.Email,							
					DOB = dbResult.DOB,							
					LunchPax = dbResult.LunchPax,							
					DinnerPax = dbResult.DinnerPax,							
					RealField = dbResult.RealField,							
					Kids = dbResult.Kids,							
					RegisteredTable = dbResult.RegisteredTable,							
					TypeOfParty = dbResult.TypeOfParty,							
					BillingInformation = dbResult.BillingInformation,							
					Status = dbResult.Status,							
					DiningCard = dbResult.DiningCard,							
					Arrivaled = dbResult.Arrivaled,							
					CustomerType = dbResult.CustomerType,							
					Phone = dbResult.Phone,							
					NoRecords = dbResult.NoRecords,							
					ForeignerNo = dbResult.ForeignerNo,							
					TableOfLunch = dbResult.TableOfLunch,							
					TimeOfParty = dbResult.TimeOfParty,							
					CustomerGroup = dbResult.CustomerGroup,							
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
				};
			}
			else
				return null; 
        }

		public static IQueryable<tbl_CRM_Attendance> _queryBuilder(AppEntities db, int IDBranch, int StaffID, Dictionary<string, string> QueryStrings)
        {
            
			IQueryable<tbl_CRM_Attendance> query = db.tbl_CRM_Attendance.AsNoTracking();//.Where(d => d.IsDeleted == false );
			

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

			//Query PartyDate (Nullable<System.DateTime>)
			if (QueryStrings.Any(d => d.Key == "PartyDateFrom") && QueryStrings.Any(d => d.Key == "PartyDateTo"))
                if (DateTime.TryParse(QueryStrings.FirstOrDefault(d => d.Key == "PartyDateFrom").Value, out DateTime fromDate) && DateTime.TryParse(QueryStrings.FirstOrDefault(d => d.Key == "PartyDateTo").Value, out DateTime toDate))
                    query = query.Where(d => fromDate <= d.PartyDate && d.PartyDate <= toDate);

            if (QueryStrings.Any(d => d.Key == "PartyDate"))
                if (DateTime.TryParse(QueryStrings.FirstOrDefault(d => d.Key == "PartyDate").Value, out DateTime val))
                    query = query.Where(d => d.PartyDate != null && DbFunctions.TruncateTime(val) == DbFunctions.TruncateTime(d.PartyDate));


			//Query CustomerName (string)
			if (QueryStrings.Any(d => d.Key == "CustomerName_eq") && !string.IsNullOrEmpty(QueryStrings.FirstOrDefault(d => d.Key == "CustomerName_eq").Value))
            {
                var keyword = QueryStrings.FirstOrDefault(d => d.Key == "CustomerName_eq").Value;
                query = query.Where(d=>d.CustomerName == keyword);
            }
            if (QueryStrings.Any(d => d.Key == "CustomerName") && !string.IsNullOrEmpty(QueryStrings.FirstOrDefault(d => d.Key == "CustomerName").Value))
            {
                var keyword = QueryStrings.FirstOrDefault(d => d.Key == "CustomerName").Value;
                query = query.Where(d=>d.CustomerName.Contains(keyword));
            }
            

			//Query Email (string)
			if (QueryStrings.Any(d => d.Key == "Email_eq") && !string.IsNullOrEmpty(QueryStrings.FirstOrDefault(d => d.Key == "Email_eq").Value))
            {
                var keyword = QueryStrings.FirstOrDefault(d => d.Key == "Email_eq").Value;
                query = query.Where(d=>d.Email == keyword);
            }
            if (QueryStrings.Any(d => d.Key == "Email") && !string.IsNullOrEmpty(QueryStrings.FirstOrDefault(d => d.Key == "Email").Value))
            {
                var keyword = QueryStrings.FirstOrDefault(d => d.Key == "Email").Value;
                query = query.Where(d=>d.Email.Contains(keyword));
            }
            

			//Query DOB (Nullable<System.DateTime>)
			if (QueryStrings.Any(d => d.Key == "DOBFrom") && QueryStrings.Any(d => d.Key == "DOBTo"))
                if (DateTime.TryParse(QueryStrings.FirstOrDefault(d => d.Key == "DOBFrom").Value, out DateTime fromDate) && DateTime.TryParse(QueryStrings.FirstOrDefault(d => d.Key == "DOBTo").Value, out DateTime toDate))
                    query = query.Where(d => fromDate <= d.DOB && d.DOB <= toDate);

            if (QueryStrings.Any(d => d.Key == "DOB"))
                if (DateTime.TryParse(QueryStrings.FirstOrDefault(d => d.Key == "DOB").Value, out DateTime val))
                    query = query.Where(d => d.DOB != null && DbFunctions.TruncateTime(val) == DbFunctions.TruncateTime(d.DOB));


			//Query LunchPax (Nullable<int>)
			if (QueryStrings.Any(d => d.Key == "LunchPaxFrom") && QueryStrings.Any(d => d.Key == "LunchPaxTo"))
                if (int.TryParse(QueryStrings.FirstOrDefault(d => d.Key == "LunchPaxFrom").Value, out int fromVal) && int.TryParse(QueryStrings.FirstOrDefault(d => d.Key == "LunchPaxTo").Value, out int toVal))
                    query = query.Where(d => fromVal <= d.LunchPax && d.LunchPax <= toVal);

			//Query DinnerPax (Nullable<int>)
			if (QueryStrings.Any(d => d.Key == "DinnerPaxFrom") && QueryStrings.Any(d => d.Key == "DinnerPaxTo"))
                if (int.TryParse(QueryStrings.FirstOrDefault(d => d.Key == "DinnerPaxFrom").Value, out int fromVal) && int.TryParse(QueryStrings.FirstOrDefault(d => d.Key == "DinnerPaxTo").Value, out int toVal))
                    query = query.Where(d => fromVal <= d.DinnerPax && d.DinnerPax <= toVal);

			//Query RealField (Nullable<int>)
			if (QueryStrings.Any(d => d.Key == "RealFieldFrom") && QueryStrings.Any(d => d.Key == "RealFieldTo"))
                if (int.TryParse(QueryStrings.FirstOrDefault(d => d.Key == "RealFieldFrom").Value, out int fromVal) && int.TryParse(QueryStrings.FirstOrDefault(d => d.Key == "RealFieldTo").Value, out int toVal))
                    query = query.Where(d => fromVal <= d.RealField && d.RealField <= toVal);

			//Query Kids (Nullable<int>)
			if (QueryStrings.Any(d => d.Key == "KidsFrom") && QueryStrings.Any(d => d.Key == "KidsTo"))
                if (int.TryParse(QueryStrings.FirstOrDefault(d => d.Key == "KidsFrom").Value, out int fromVal) && int.TryParse(QueryStrings.FirstOrDefault(d => d.Key == "KidsTo").Value, out int toVal))
                    query = query.Where(d => fromVal <= d.Kids && d.Kids <= toVal);

			//Query RegisteredTable (string)
			if (QueryStrings.Any(d => d.Key == "RegisteredTable_eq") && !string.IsNullOrEmpty(QueryStrings.FirstOrDefault(d => d.Key == "RegisteredTable_eq").Value))
            {
                var keyword = QueryStrings.FirstOrDefault(d => d.Key == "RegisteredTable_eq").Value;
                query = query.Where(d=>d.RegisteredTable == keyword);
            }
            if (QueryStrings.Any(d => d.Key == "RegisteredTable") && !string.IsNullOrEmpty(QueryStrings.FirstOrDefault(d => d.Key == "RegisteredTable").Value))
            {
                var keyword = QueryStrings.FirstOrDefault(d => d.Key == "RegisteredTable").Value;
                query = query.Where(d=>d.RegisteredTable.Contains(keyword));
            }
            

			//Query TypeOfParty (string)
			if (QueryStrings.Any(d => d.Key == "TypeOfParty_eq") && !string.IsNullOrEmpty(QueryStrings.FirstOrDefault(d => d.Key == "TypeOfParty_eq").Value))
            {
                var keyword = QueryStrings.FirstOrDefault(d => d.Key == "TypeOfParty_eq").Value;
                query = query.Where(d=>d.TypeOfParty == keyword);
            }
            if (QueryStrings.Any(d => d.Key == "TypeOfParty") && !string.IsNullOrEmpty(QueryStrings.FirstOrDefault(d => d.Key == "TypeOfParty").Value))
            {
                var keyword = QueryStrings.FirstOrDefault(d => d.Key == "TypeOfParty").Value;
                query = query.Where(d=>d.TypeOfParty.Contains(keyword));
            }
            

			//Query BillingInformation (string)
			if (QueryStrings.Any(d => d.Key == "BillingInformation_eq") && !string.IsNullOrEmpty(QueryStrings.FirstOrDefault(d => d.Key == "BillingInformation_eq").Value))
            {
                var keyword = QueryStrings.FirstOrDefault(d => d.Key == "BillingInformation_eq").Value;
                query = query.Where(d=>d.BillingInformation == keyword);
            }
            if (QueryStrings.Any(d => d.Key == "BillingInformation") && !string.IsNullOrEmpty(QueryStrings.FirstOrDefault(d => d.Key == "BillingInformation").Value))
            {
                var keyword = QueryStrings.FirstOrDefault(d => d.Key == "BillingInformation").Value;
                query = query.Where(d=>d.BillingInformation.Contains(keyword));
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
            

			//Query DiningCard (string)
			if (QueryStrings.Any(d => d.Key == "DiningCard_eq") && !string.IsNullOrEmpty(QueryStrings.FirstOrDefault(d => d.Key == "DiningCard_eq").Value))
            {
                var keyword = QueryStrings.FirstOrDefault(d => d.Key == "DiningCard_eq").Value;
                query = query.Where(d=>d.DiningCard == keyword);
            }
            if (QueryStrings.Any(d => d.Key == "DiningCard") && !string.IsNullOrEmpty(QueryStrings.FirstOrDefault(d => d.Key == "DiningCard").Value))
            {
                var keyword = QueryStrings.FirstOrDefault(d => d.Key == "DiningCard").Value;
                query = query.Where(d=>d.DiningCard.Contains(keyword));
            }
            

			//Query Arrivaled (Nullable<int>)
			if (QueryStrings.Any(d => d.Key == "ArrivaledFrom") && QueryStrings.Any(d => d.Key == "ArrivaledTo"))
                if (int.TryParse(QueryStrings.FirstOrDefault(d => d.Key == "ArrivaledFrom").Value, out int fromVal) && int.TryParse(QueryStrings.FirstOrDefault(d => d.Key == "ArrivaledTo").Value, out int toVal))
                    query = query.Where(d => fromVal <= d.Arrivaled && d.Arrivaled <= toVal);

			//Query CustomerType (string)
			if (QueryStrings.Any(d => d.Key == "CustomerType_eq") && !string.IsNullOrEmpty(QueryStrings.FirstOrDefault(d => d.Key == "CustomerType_eq").Value))
            {
                var keyword = QueryStrings.FirstOrDefault(d => d.Key == "CustomerType_eq").Value;
                query = query.Where(d=>d.CustomerType == keyword);
            }
            if (QueryStrings.Any(d => d.Key == "CustomerType") && !string.IsNullOrEmpty(QueryStrings.FirstOrDefault(d => d.Key == "CustomerType").Value))
            {
                var keyword = QueryStrings.FirstOrDefault(d => d.Key == "CustomerType").Value;
                query = query.Where(d=>d.CustomerType.Contains(keyword));
            }
            

			//Query Phone (string)
			if (QueryStrings.Any(d => d.Key == "Phone_eq") && !string.IsNullOrEmpty(QueryStrings.FirstOrDefault(d => d.Key == "Phone_eq").Value))
            {
                var keyword = QueryStrings.FirstOrDefault(d => d.Key == "Phone_eq").Value;
                query = query.Where(d=>d.Phone == keyword);
            }
            if (QueryStrings.Any(d => d.Key == "Phone") && !string.IsNullOrEmpty(QueryStrings.FirstOrDefault(d => d.Key == "Phone").Value))
            {
                var keyword = QueryStrings.FirstOrDefault(d => d.Key == "Phone").Value;
                query = query.Where(d=>d.Phone.Contains(keyword));
            }
            

			//Query NoRecords (Nullable<int>)
			if (QueryStrings.Any(d => d.Key == "NoRecordsFrom") && QueryStrings.Any(d => d.Key == "NoRecordsTo"))
                if (int.TryParse(QueryStrings.FirstOrDefault(d => d.Key == "NoRecordsFrom").Value, out int fromVal) && int.TryParse(QueryStrings.FirstOrDefault(d => d.Key == "NoRecordsTo").Value, out int toVal))
                    query = query.Where(d => fromVal <= d.NoRecords && d.NoRecords <= toVal);

			//Query ForeignerNo (Nullable<int>)
			if (QueryStrings.Any(d => d.Key == "ForeignerNoFrom") && QueryStrings.Any(d => d.Key == "ForeignerNoTo"))
                if (int.TryParse(QueryStrings.FirstOrDefault(d => d.Key == "ForeignerNoFrom").Value, out int fromVal) && int.TryParse(QueryStrings.FirstOrDefault(d => d.Key == "ForeignerNoTo").Value, out int toVal))
                    query = query.Where(d => fromVal <= d.ForeignerNo && d.ForeignerNo <= toVal);

			//Query TableOfLunch (string)
			if (QueryStrings.Any(d => d.Key == "TableOfLunch_eq") && !string.IsNullOrEmpty(QueryStrings.FirstOrDefault(d => d.Key == "TableOfLunch_eq").Value))
            {
                var keyword = QueryStrings.FirstOrDefault(d => d.Key == "TableOfLunch_eq").Value;
                query = query.Where(d=>d.TableOfLunch == keyword);
            }
            if (QueryStrings.Any(d => d.Key == "TableOfLunch") && !string.IsNullOrEmpty(QueryStrings.FirstOrDefault(d => d.Key == "TableOfLunch").Value))
            {
                var keyword = QueryStrings.FirstOrDefault(d => d.Key == "TableOfLunch").Value;
                query = query.Where(d=>d.TableOfLunch.Contains(keyword));
            }
            

			//Query TimeOfParty (string)
			if (QueryStrings.Any(d => d.Key == "TimeOfParty_eq") && !string.IsNullOrEmpty(QueryStrings.FirstOrDefault(d => d.Key == "TimeOfParty_eq").Value))
            {
                var keyword = QueryStrings.FirstOrDefault(d => d.Key == "TimeOfParty_eq").Value;
                query = query.Where(d=>d.TimeOfParty == keyword);
            }
            if (QueryStrings.Any(d => d.Key == "TimeOfParty") && !string.IsNullOrEmpty(QueryStrings.FirstOrDefault(d => d.Key == "TimeOfParty").Value))
            {
                var keyword = QueryStrings.FirstOrDefault(d => d.Key == "TimeOfParty").Value;
                query = query.Where(d=>d.TimeOfParty.Contains(keyword));
            }
            

			//Query CustomerGroup (string)
			if (QueryStrings.Any(d => d.Key == "CustomerGroup_eq") && !string.IsNullOrEmpty(QueryStrings.FirstOrDefault(d => d.Key == "CustomerGroup_eq").Value))
            {
                var keyword = QueryStrings.FirstOrDefault(d => d.Key == "CustomerGroup_eq").Value;
                query = query.Where(d=>d.CustomerGroup == keyword);
            }
            if (QueryStrings.Any(d => d.Key == "CustomerGroup") && !string.IsNullOrEmpty(QueryStrings.FirstOrDefault(d => d.Key == "CustomerGroup").Value))
            {
                var keyword = QueryStrings.FirstOrDefault(d => d.Key == "CustomerGroup").Value;
                query = query.Where(d=>d.CustomerGroup.Contains(keyword));
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

            return query;
        }
		
        public static IQueryable<tbl_CRM_Attendance> _sortBuilder(IQueryable<tbl_CRM_Attendance> query, Dictionary<string, string> QueryStrings)
        {
            if (QueryStrings.Any(d => d.Key == "SortBy"))
            {
                var sorts = QueryStrings.FirstOrDefault(d => d.Key == "SortBy").Value.Replace("[", "").Replace("]", "").Split(',');
                
                foreach (var item in sorts)
                    if (!string.IsNullOrEmpty(item))
                    {
                        var ordered = query as IOrderedQueryable<tbl_CRM_Attendance>;
                        bool isOrdered = ordered.ToString().IndexOf("ORDER BY") !=-1;

                        switch (item)
                        {
							case "Id":
								query = isOrdered ? ordered.ThenBy(o => o.Id) : query.OrderBy(o => o.Id);
								 break;
							case "Id_desc":
                                query = isOrdered ? ordered.ThenByDescending(o => o.Id) : query.OrderByDescending(o => o.Id);
                                break;
							case "PartyDate":
								query = isOrdered ? ordered.ThenBy(o => o.PartyDate) : query.OrderBy(o => o.PartyDate);
								 break;
							case "PartyDate_desc":
                                query = isOrdered ? ordered.ThenByDescending(o => o.PartyDate) : query.OrderByDescending(o => o.PartyDate);
                                break;
							case "CustomerName":
								query = isOrdered ? ordered.ThenBy(o => o.CustomerName) : query.OrderBy(o => o.CustomerName);
								 break;
							case "CustomerName_desc":
                                query = isOrdered ? ordered.ThenByDescending(o => o.CustomerName) : query.OrderByDescending(o => o.CustomerName);
                                break;
							case "Email":
								query = isOrdered ? ordered.ThenBy(o => o.Email) : query.OrderBy(o => o.Email);
								 break;
							case "Email_desc":
                                query = isOrdered ? ordered.ThenByDescending(o => o.Email) : query.OrderByDescending(o => o.Email);
                                break;
							case "DOB":
								query = isOrdered ? ordered.ThenBy(o => o.DOB) : query.OrderBy(o => o.DOB);
								 break;
							case "DOB_desc":
                                query = isOrdered ? ordered.ThenByDescending(o => o.DOB) : query.OrderByDescending(o => o.DOB);
                                break;
							case "LunchPax":
								query = isOrdered ? ordered.ThenBy(o => o.LunchPax) : query.OrderBy(o => o.LunchPax);
								 break;
							case "LunchPax_desc":
                                query = isOrdered ? ordered.ThenByDescending(o => o.LunchPax) : query.OrderByDescending(o => o.LunchPax);
                                break;
							case "DinnerPax":
								query = isOrdered ? ordered.ThenBy(o => o.DinnerPax) : query.OrderBy(o => o.DinnerPax);
								 break;
							case "DinnerPax_desc":
                                query = isOrdered ? ordered.ThenByDescending(o => o.DinnerPax) : query.OrderByDescending(o => o.DinnerPax);
                                break;
							case "RealField":
								query = isOrdered ? ordered.ThenBy(o => o.RealField) : query.OrderBy(o => o.RealField);
								 break;
							case "RealField_desc":
                                query = isOrdered ? ordered.ThenByDescending(o => o.RealField) : query.OrderByDescending(o => o.RealField);
                                break;
							case "Kids":
								query = isOrdered ? ordered.ThenBy(o => o.Kids) : query.OrderBy(o => o.Kids);
								 break;
							case "Kids_desc":
                                query = isOrdered ? ordered.ThenByDescending(o => o.Kids) : query.OrderByDescending(o => o.Kids);
                                break;
							case "RegisteredTable":
								query = isOrdered ? ordered.ThenBy(o => o.RegisteredTable) : query.OrderBy(o => o.RegisteredTable);
								 break;
							case "RegisteredTable_desc":
                                query = isOrdered ? ordered.ThenByDescending(o => o.RegisteredTable) : query.OrderByDescending(o => o.RegisteredTable);
                                break;
							case "TypeOfParty":
								query = isOrdered ? ordered.ThenBy(o => o.TypeOfParty) : query.OrderBy(o => o.TypeOfParty);
								 break;
							case "TypeOfParty_desc":
                                query = isOrdered ? ordered.ThenByDescending(o => o.TypeOfParty) : query.OrderByDescending(o => o.TypeOfParty);
                                break;
							case "BillingInformation":
								query = isOrdered ? ordered.ThenBy(o => o.BillingInformation) : query.OrderBy(o => o.BillingInformation);
								 break;
							case "BillingInformation_desc":
                                query = isOrdered ? ordered.ThenByDescending(o => o.BillingInformation) : query.OrderByDescending(o => o.BillingInformation);
                                break;
							case "Status":
								query = isOrdered ? ordered.ThenBy(o => o.Status) : query.OrderBy(o => o.Status);
								 break;
							case "Status_desc":
                                query = isOrdered ? ordered.ThenByDescending(o => o.Status) : query.OrderByDescending(o => o.Status);
                                break;
							case "DiningCard":
								query = isOrdered ? ordered.ThenBy(o => o.DiningCard) : query.OrderBy(o => o.DiningCard);
								 break;
							case "DiningCard_desc":
                                query = isOrdered ? ordered.ThenByDescending(o => o.DiningCard) : query.OrderByDescending(o => o.DiningCard);
                                break;
							case "Arrivaled":
								query = isOrdered ? ordered.ThenBy(o => o.Arrivaled) : query.OrderBy(o => o.Arrivaled);
								 break;
							case "Arrivaled_desc":
                                query = isOrdered ? ordered.ThenByDescending(o => o.Arrivaled) : query.OrderByDescending(o => o.Arrivaled);
                                break;
							case "CustomerType":
								query = isOrdered ? ordered.ThenBy(o => o.CustomerType) : query.OrderBy(o => o.CustomerType);
								 break;
							case "CustomerType_desc":
                                query = isOrdered ? ordered.ThenByDescending(o => o.CustomerType) : query.OrderByDescending(o => o.CustomerType);
                                break;
							case "Phone":
								query = isOrdered ? ordered.ThenBy(o => o.Phone) : query.OrderBy(o => o.Phone);
								 break;
							case "Phone_desc":
                                query = isOrdered ? ordered.ThenByDescending(o => o.Phone) : query.OrderByDescending(o => o.Phone);
                                break;
							case "NoRecords":
								query = isOrdered ? ordered.ThenBy(o => o.NoRecords) : query.OrderBy(o => o.NoRecords);
								 break;
							case "NoRecords_desc":
                                query = isOrdered ? ordered.ThenByDescending(o => o.NoRecords) : query.OrderByDescending(o => o.NoRecords);
                                break;
							case "ForeignerNo":
								query = isOrdered ? ordered.ThenBy(o => o.ForeignerNo) : query.OrderBy(o => o.ForeignerNo);
								 break;
							case "ForeignerNo_desc":
                                query = isOrdered ? ordered.ThenByDescending(o => o.ForeignerNo) : query.OrderByDescending(o => o.ForeignerNo);
                                break;
							case "TableOfLunch":
								query = isOrdered ? ordered.ThenBy(o => o.TableOfLunch) : query.OrderBy(o => o.TableOfLunch);
								 break;
							case "TableOfLunch_desc":
                                query = isOrdered ? ordered.ThenByDescending(o => o.TableOfLunch) : query.OrderByDescending(o => o.TableOfLunch);
                                break;
							case "TimeOfParty":
								query = isOrdered ? ordered.ThenBy(o => o.TimeOfParty) : query.OrderBy(o => o.TimeOfParty);
								 break;
							case "TimeOfParty_desc":
                                query = isOrdered ? ordered.ThenByDescending(o => o.TimeOfParty) : query.OrderByDescending(o => o.TimeOfParty);
                                break;
							case "CustomerGroup":
								query = isOrdered ? ordered.ThenBy(o => o.CustomerGroup) : query.OrderBy(o => o.CustomerGroup);
								 break;
							case "CustomerGroup_desc":
                                query = isOrdered ? ordered.ThenByDescending(o => o.CustomerGroup) : query.OrderByDescending(o => o.CustomerGroup);
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

        public static IQueryable<tbl_CRM_Attendance> _pagingBuilder(IQueryable<tbl_CRM_Attendance> query, Dictionary<string, string> QueryStrings)
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






