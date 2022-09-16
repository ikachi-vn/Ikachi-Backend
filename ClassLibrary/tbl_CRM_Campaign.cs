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
    
    
    public partial class tbl_CRM_Campaign
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public tbl_CRM_Campaign()
        {
            this.tbl_CRM_Campaign1 = new HashSet<tbl_CRM_Campaign>();
            this.tbl_CRM_CampaignMember = new HashSet<tbl_CRM_CampaignMember>();
            this.tbl_CRM_Lead = new HashSet<tbl_CRM_Lead>();
            this.tbl_CRM_Opportunity = new HashSet<tbl_CRM_Opportunity>();
        }
    
        public Nullable<int> IDOwner { get; set; }
        public int IDStatus { get; set; }
        public Nullable<int> IDType { get; set; }
        public Nullable<int> IDParent { get; set; }
        public int IDBranch { get; set; }
        public int Id { get; set; }
        public string Code { get; set; }
        public string Name { get; set; }
        public string Remark { get; set; }
        public System.DateTime StartDate { get; set; }
        public System.DateTime EndDate { get; set; }
        public int NumSent { get; set; }
        public int ExpectedResponse { get; set; }
        public decimal ExpectedRevenue { get; set; }
        public decimal BudgetedCost { get; set; }
        public decimal ActualCost { get; set; }
        public bool IsActive { get; set; }
        public decimal HierarchyActualCost { get; set; }
        public decimal HierarchyBudgetedCost { get; set; }
        public int NumberOfContacts { get; set; }
        public int HierarchyNumberOfContacts { get; set; }
        public int NumberOfConvertedLeads { get; set; }
        public int HierarchyNumberOfConvertedLeads { get; set; }
        public decimal HierarchyExpectedRevenue { get; set; }
        public int NumberOfLeads { get; set; }
        public int HierarchyNumberOfLeads { get; set; }
        public int HierarchyNumberSent { get; set; }
        public int NumberOfOpportunities { get; set; }
        public int HierarchyNumberOfOpportunities { get; set; }
        public int NumberOfResponses { get; set; }
        public int HierarchyNumberOfResponses { get; set; }
        public decimal AmountAllOpportunities { get; set; }
        public decimal HierarchyAmountAllOpportunities { get; set; }
        public decimal AmountWonOpportunities { get; set; }
        public decimal HierarchyAmountWonOpportunities { get; set; }
        public Nullable<int> NumberOfWonOpportunities { get; set; }
        public int HierarchyNumberOfWonOpportunities { get; set; }
        public Nullable<int> Sort { get; set; }
        public bool IsDisabled { get; set; }
        public bool IsDeleted { get; set; }
        public string CreatedBy { get; set; }
        public string ModifiedBy { get; set; }
        public System.DateTime CreatedDate { get; set; }
        public System.DateTime ModifiedDate { get; set; }
        //List 0:1
        public virtual tbl_BRA_Branch tbl_BRA_Branch { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tbl_CRM_Campaign> tbl_CRM_Campaign1 { get; set; }
        //List 0:1
        public virtual tbl_CRM_Campaign tbl_CRM_Campaign2 { get; set; }
        //List 0:1
        public virtual tbl_HRM_Staff tbl_HRM_Staff { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tbl_CRM_CampaignMember> tbl_CRM_CampaignMember { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tbl_CRM_Lead> tbl_CRM_Lead { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tbl_CRM_Opportunity> tbl_CRM_Opportunity { get; set; }
    }
}


namespace DTOModel
{
	using System;
	public partial class DTO_CRM_Campaign
	{
		public Nullable<int> IDOwner { get; set; }
		public int IDStatus { get; set; }
		public Nullable<int> IDType { get; set; }
		public Nullable<int> IDParent { get; set; }
		public int IDBranch { get; set; }
		public int Id { get; set; }
		public string Code { get; set; }
		public string Name { get; set; }
		public string Remark { get; set; }
		public System.DateTime StartDate { get; set; }
		public System.DateTime EndDate { get; set; }
		public int NumSent { get; set; }
		public int ExpectedResponse { get; set; }
		public decimal ExpectedRevenue { get; set; }
		public decimal BudgetedCost { get; set; }
		public decimal ActualCost { get; set; }
		public bool IsActive { get; set; }
		public decimal HierarchyActualCost { get; set; }
		public decimal HierarchyBudgetedCost { get; set; }
		public int NumberOfContacts { get; set; }
		public int HierarchyNumberOfContacts { get; set; }
		public int NumberOfConvertedLeads { get; set; }
		public int HierarchyNumberOfConvertedLeads { get; set; }
		public decimal HierarchyExpectedRevenue { get; set; }
		public int NumberOfLeads { get; set; }
		public int HierarchyNumberOfLeads { get; set; }
		public int HierarchyNumberSent { get; set; }
		public int NumberOfOpportunities { get; set; }
		public int HierarchyNumberOfOpportunities { get; set; }
		public int NumberOfResponses { get; set; }
		public int HierarchyNumberOfResponses { get; set; }
		public decimal AmountAllOpportunities { get; set; }
		public decimal HierarchyAmountAllOpportunities { get; set; }
		public decimal AmountWonOpportunities { get; set; }
		public decimal HierarchyAmountWonOpportunities { get; set; }
		public Nullable<int> NumberOfWonOpportunities { get; set; }
		public int HierarchyNumberOfWonOpportunities { get; set; }
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

    public static partial class BS_CRM_Campaign 
    {
        public static dynamic getSearch(AppEntities db, int IDBranch, int StaffID, Dictionary<string, string> QueryStrings)
        {
            return get(db, IDBranch,StaffID, QueryStrings);
        }

		public static IQueryable<DTO_CRM_Campaign> get(AppEntities db, int IDBranch, int StaffID, Dictionary<string, string> QueryStrings)
        {
			var query = _queryBuilder(db, IDBranch, StaffID, QueryStrings);

            if (QueryStrings.Any(d => d.Key == "AllChildren")  || QueryStrings.Any(d => d.Key == "AllParent"))
            {

                List<DTO_CRM_Campaign> allItems = db.tbl_CRM_Campaign.Where(d => d.IsDeleted == false).Select(s => new DTO_CRM_Campaign()
                {
                    Id = s.Id,
                    IDParent = s.IDParent
                }).ToList();

                List<int> Ids = new List<int>();

                foreach (var item in query)
                {
                    Ids.Add(item.Id);
                    if (QueryStrings.Any(d => d.Key == "AllParent")){
                        Ids.AddRange(findParent(allItems, item.Id));
                    }
                    if (QueryStrings.Any(d => d.Key == "AllChildren")){
                        Ids.AddRange(findChildrent(allItems, item.Id).Select(s=>s));
                    }
                    
                    query = db.tbl_CRM_Campaign.Where(d => Ids.Contains(d.Id));
                }

            }

            query = _sortBuilder(query, QueryStrings);
            query = _pagingBuilder(query, QueryStrings);

			return toDTO(query);
        }

        public static List<int> findParent(List<DTO_CRM_Campaign> allItems, int Id)
        {

            var Ids = new List<int>();

            var item = allItems.FirstOrDefault(d => d.Id == Id);

            if (item != null && item.IDParent.HasValue)
            {
                Ids.Add(item.IDParent.Value);
           
                Ids.AddRange(findParent(allItems, item.IDParent.Value));
            }

            return Ids;
        }

        public static List<int> findChildrent(List<DTO_CRM_Campaign> allItems, int Id)
        {
            var Ids = new List<int>();
            var items = allItems.Where(d => d.IDParent == Id).Select(s => s.Id).ToList();
            Ids.AddRange(items);

            foreach (var item in items)
            {
                Ids.AddRange(findChildrent(allItems, item));
            }

            return Ids;
        }

        public static List<ItemModel> getValidateData(AppEntities db, int IDBranch, int StaffID, Dictionary<string, string> QueryStrings)
        {
            return get(db, IDBranch, StaffID, QueryStrings).Select(s => new ItemModel { 
                Id = s.Id,  Code = s.Code,  Name = s.Name, 
            }).ToList();
        }

        public static string export(ExcelPackage package, AppEntities db, int IDBranch, int StaffID, Dictionary<string, string> QueryStrings)
        {
            package.Workbook.Properties.Title = "ART-DMS CRM_Campaign";
            package.Workbook.Properties.Author = "hung.vu@codeart.vn";
            package.Workbook.Properties.Application = "ART-DMS";
            package.Workbook.Properties.Company = "A.R.T Distribution";

            ExcelWorkbook workBook = package.Workbook;
            if (workBook != null)
            {
                var ws = workBook.Worksheets.FirstOrDefault();
                var data = _queryBuilder(db, IDBranch, StaffID, QueryStrings).ToList();

                //var BRA_BranchList = BS_BRA_Branch.get(db,IDBranch, StaffID,QueryStrings).Select(s => new ItemModel { Id = s.Id, Name = s.Name });
                //var CRM_Campaign2List = BS_CRM_Campaign.get(db,IDBranch, StaffID,QueryStrings).Select(s => new ItemModel { Id = s.Id, Name = s.Name });
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

		public static DTO_CRM_Campaign getAnItem(AppEntities db, int IDBranch, int StaffID, int id)
        {
            var dbResult = db.tbl_CRM_Campaign.Find(id);

			//if (dbResult == null || (IDBranch != 0 && dbResult.IDBranch != IDBranch))
			//	return null; 
			//else 
				return toDTO(dbResult);
			
        }
		
		public static DTO_CRM_Campaign getAnItemByCode(AppEntities db, int IDBranch, int StaffID, string code)
        {
            var dbResult = db.tbl_CRM_Campaign
			.FirstOrDefault(d => d.IsDeleted == false && d.Code == code); //.FirstOrDefault(d => d.IsDeleted == false && (d.IDBranch == IDBranch || IDBranch == 0) && d.Code == code);

			
            return toDTO(dbResult);
            //if (dbResult == null || dbResult.IDBranch != IDBranch)
			//	return null; 
			//else 
			//	return toDTO(dbResult);

			
        }

		public static bool put(AppEntities db, int IDBranch, int StaffID, int Id, dynamic item, string Username, Dictionary<string, string> QueryStrings)
        {
            bool result = false;
            var dbitem = db.tbl_CRM_Campaign.Find(Id);
            
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
					errorLog.logMessage("put_CRM_Campaign",e);
                    result = false;
                }
            }
            else
                if (QueryStrings.Any(d => d.Key == "ForceCreate"))
                    result =  post(db, IDBranch, StaffID, item, Username) != null;
                
            return result;
        }

        public static void patchDynamicToDB(dynamic item, tbl_CRM_Campaign dbitem, string Username)
        {
            Type type = typeof(tbl_CRM_Campaign);
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

        public static void patchDTOtoDBValue( DTO_CRM_Campaign item, tbl_CRM_Campaign dbitem)
        {
            if (item == null){
                dbitem = null;
                return;
            }
            							
			dbitem.IDOwner = item.IDOwner;							
			dbitem.IDStatus = item.IDStatus;							
			dbitem.IDType = item.IDType;							
			dbitem.IDParent = item.IDParent;							
			dbitem.IDBranch = item.IDBranch;							
			dbitem.Code = item.Code;							
			dbitem.Name = item.Name;							
			dbitem.Remark = item.Remark;							
			dbitem.StartDate = item.StartDate;							
			dbitem.EndDate = item.EndDate;							
			dbitem.NumSent = item.NumSent;							
			dbitem.ExpectedResponse = item.ExpectedResponse;							
			dbitem.ExpectedRevenue = item.ExpectedRevenue;							
			dbitem.BudgetedCost = item.BudgetedCost;							
			dbitem.ActualCost = item.ActualCost;							
			dbitem.IsActive = item.IsActive;							
			dbitem.HierarchyActualCost = item.HierarchyActualCost;							
			dbitem.HierarchyBudgetedCost = item.HierarchyBudgetedCost;							
			dbitem.NumberOfContacts = item.NumberOfContacts;							
			dbitem.HierarchyNumberOfContacts = item.HierarchyNumberOfContacts;							
			dbitem.NumberOfConvertedLeads = item.NumberOfConvertedLeads;							
			dbitem.HierarchyNumberOfConvertedLeads = item.HierarchyNumberOfConvertedLeads;							
			dbitem.HierarchyExpectedRevenue = item.HierarchyExpectedRevenue;							
			dbitem.NumberOfLeads = item.NumberOfLeads;							
			dbitem.HierarchyNumberOfLeads = item.HierarchyNumberOfLeads;							
			dbitem.HierarchyNumberSent = item.HierarchyNumberSent;							
			dbitem.NumberOfOpportunities = item.NumberOfOpportunities;							
			dbitem.HierarchyNumberOfOpportunities = item.HierarchyNumberOfOpportunities;							
			dbitem.NumberOfResponses = item.NumberOfResponses;							
			dbitem.HierarchyNumberOfResponses = item.HierarchyNumberOfResponses;							
			dbitem.AmountAllOpportunities = item.AmountAllOpportunities;							
			dbitem.HierarchyAmountAllOpportunities = item.HierarchyAmountAllOpportunities;							
			dbitem.AmountWonOpportunities = item.AmountWonOpportunities;							
			dbitem.HierarchyAmountWonOpportunities = item.HierarchyAmountWonOpportunities;							
			dbitem.NumberOfWonOpportunities = item.NumberOfWonOpportunities;							
			dbitem.HierarchyNumberOfWonOpportunities = item.HierarchyNumberOfWonOpportunities;							
			dbitem.Sort = item.Sort;							
			dbitem.IsDisabled = item.IsDisabled;							
			dbitem.IsDeleted = item.IsDeleted;        }

		public static DTO_CRM_Campaign post(AppEntities db, int IDBranch, int StaffID, dynamic item, string Username)
        {
            tbl_CRM_Campaign dbitem = new tbl_CRM_Campaign();
            if (item != null)
            {
                patchDynamicToDB(item, dbitem, Username);
                
				dbitem.CreatedBy = Username;
				dbitem.CreatedDate = DateTime.Now;				
                try
                {
					db.tbl_CRM_Campaign.Add(dbitem);
                    db.SaveChanges();
				
                }
                catch (DbEntityValidationException e)
                {
					errorLog.logMessage("post_CRM_Campaign",e);
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
                Type type = Type.GetType("BaseBusiness.BS_CRM_Campaign, ClassLibrary");
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
                        var target = new tbl_CRM_Campaign();
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
                    
                    tbl_CRM_Campaign dbitem = new tbl_CRM_Campaign();
                    if (it.Id == null || string.IsNullOrEmpty(it.Id.Value) || it.Id == "0")
                    {
                        dbitem = new tbl_CRM_Campaign();
                        dbitem.CreatedBy = Username;
				        dbitem.CreatedDate = DateTime.Now;
                                            }
                    else
                    {
                        dbitem = db.tbl_CRM_Campaign.Find((int)it.Id);
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
                        
                        if (dbitem.Id == 0) db.tbl_CRM_Campaign.Add(dbitem);
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
                    errorLog.logMessage("post_CRM_Campaign",e);
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

            var dbitems = db.tbl_CRM_Campaign.Where(d => IDs.Contains(d.Id));
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
                    BS_Version.update_Version(db, IDBranch, "DTO_CRM_Campaign", updateDate, Username);
                }
			
            }
            catch (DbEntityValidationException e)
            {
				errorLog.logMessage("delete_CRM_Campaign",e);
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

			
            var dbitems = db.tbl_CRM_Campaign.Where(d => IDs.Contains(d.Id));
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
			
                foreach (var IDBranch in IDBranches)
                {
                    BS_Version.update_Version(db, IDBranch, "DTO_CRM_Campaign", updateDate, Username);
                }
			
            }
            catch (DbEntityValidationException e)
            {
				errorLog.logMessage("disable_CRM_Campaign",e);
                result = false;
            }
            
            return result;
        }

		
		//---//
		public static bool check_Exists(AppEntities db, int id)
		{
             
            return db.tbl_CRM_Campaign.Any(e => e.Id == id && e.IsDeleted == false);
            
		}
		
		public static bool check_Exists(AppEntities db, string Code)
		{
             
            return db.tbl_CRM_Campaign.Any(e => e.Code == Code && e.IsDeleted == false);
            
		}
		
		//---//
		public static IQueryable<DTO_CRM_Campaign> toDTO(IQueryable<tbl_CRM_Campaign> query)
        {
			return query
			.Select(s => new DTO_CRM_Campaign(){							
				IDOwner = s.IDOwner,							
				IDStatus = s.IDStatus,							
				IDType = s.IDType,							
				IDParent = s.IDParent,							
				IDBranch = s.IDBranch,							
				Id = s.Id,							
				Code = s.Code,							
				Name = s.Name,							
				Remark = s.Remark,							
				StartDate = s.StartDate,							
				EndDate = s.EndDate,							
				NumSent = s.NumSent,							
				ExpectedResponse = s.ExpectedResponse,							
				ExpectedRevenue = s.ExpectedRevenue,							
				BudgetedCost = s.BudgetedCost,							
				ActualCost = s.ActualCost,							
				IsActive = s.IsActive,							
				HierarchyActualCost = s.HierarchyActualCost,							
				HierarchyBudgetedCost = s.HierarchyBudgetedCost,							
				NumberOfContacts = s.NumberOfContacts,							
				HierarchyNumberOfContacts = s.HierarchyNumberOfContacts,							
				NumberOfConvertedLeads = s.NumberOfConvertedLeads,							
				HierarchyNumberOfConvertedLeads = s.HierarchyNumberOfConvertedLeads,							
				HierarchyExpectedRevenue = s.HierarchyExpectedRevenue,							
				NumberOfLeads = s.NumberOfLeads,							
				HierarchyNumberOfLeads = s.HierarchyNumberOfLeads,							
				HierarchyNumberSent = s.HierarchyNumberSent,							
				NumberOfOpportunities = s.NumberOfOpportunities,							
				HierarchyNumberOfOpportunities = s.HierarchyNumberOfOpportunities,							
				NumberOfResponses = s.NumberOfResponses,							
				HierarchyNumberOfResponses = s.HierarchyNumberOfResponses,							
				AmountAllOpportunities = s.AmountAllOpportunities,							
				HierarchyAmountAllOpportunities = s.HierarchyAmountAllOpportunities,							
				AmountWonOpportunities = s.AmountWonOpportunities,							
				HierarchyAmountWonOpportunities = s.HierarchyAmountWonOpportunities,							
				NumberOfWonOpportunities = s.NumberOfWonOpportunities,							
				HierarchyNumberOfWonOpportunities = s.HierarchyNumberOfWonOpportunities,							
				Sort = s.Sort,							
				IsDisabled = s.IsDisabled,							
				IsDeleted = s.IsDeleted,							
				CreatedBy = s.CreatedBy,							
				ModifiedBy = s.ModifiedBy,							
				CreatedDate = s.CreatedDate,							
				ModifiedDate = s.ModifiedDate,					
			});//.OrderBy(o => o.Sort == null).ThenBy(u => u.Sort);
                              
        }

		public static DTO_CRM_Campaign toDTO(tbl_CRM_Campaign dbResult)
        {
			if (dbResult != null)
			{
				return new DTO_CRM_Campaign()
				{							
					IDOwner = dbResult.IDOwner,							
					IDStatus = dbResult.IDStatus,							
					IDType = dbResult.IDType,							
					IDParent = dbResult.IDParent,							
					IDBranch = dbResult.IDBranch,							
					Id = dbResult.Id,							
					Code = dbResult.Code,							
					Name = dbResult.Name,							
					Remark = dbResult.Remark,							
					StartDate = dbResult.StartDate,							
					EndDate = dbResult.EndDate,							
					NumSent = dbResult.NumSent,							
					ExpectedResponse = dbResult.ExpectedResponse,							
					ExpectedRevenue = dbResult.ExpectedRevenue,							
					BudgetedCost = dbResult.BudgetedCost,							
					ActualCost = dbResult.ActualCost,							
					IsActive = dbResult.IsActive,							
					HierarchyActualCost = dbResult.HierarchyActualCost,							
					HierarchyBudgetedCost = dbResult.HierarchyBudgetedCost,							
					NumberOfContacts = dbResult.NumberOfContacts,							
					HierarchyNumberOfContacts = dbResult.HierarchyNumberOfContacts,							
					NumberOfConvertedLeads = dbResult.NumberOfConvertedLeads,							
					HierarchyNumberOfConvertedLeads = dbResult.HierarchyNumberOfConvertedLeads,							
					HierarchyExpectedRevenue = dbResult.HierarchyExpectedRevenue,							
					NumberOfLeads = dbResult.NumberOfLeads,							
					HierarchyNumberOfLeads = dbResult.HierarchyNumberOfLeads,							
					HierarchyNumberSent = dbResult.HierarchyNumberSent,							
					NumberOfOpportunities = dbResult.NumberOfOpportunities,							
					HierarchyNumberOfOpportunities = dbResult.HierarchyNumberOfOpportunities,							
					NumberOfResponses = dbResult.NumberOfResponses,							
					HierarchyNumberOfResponses = dbResult.HierarchyNumberOfResponses,							
					AmountAllOpportunities = dbResult.AmountAllOpportunities,							
					HierarchyAmountAllOpportunities = dbResult.HierarchyAmountAllOpportunities,							
					AmountWonOpportunities = dbResult.AmountWonOpportunities,							
					HierarchyAmountWonOpportunities = dbResult.HierarchyAmountWonOpportunities,							
					NumberOfWonOpportunities = dbResult.NumberOfWonOpportunities,							
					HierarchyNumberOfWonOpportunities = dbResult.HierarchyNumberOfWonOpportunities,							
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

		public static IQueryable<tbl_CRM_Campaign> _queryBuilder(AppEntities db, int IDBranch, int StaffID, Dictionary<string, string> QueryStrings)
        {
            
			IQueryable<tbl_CRM_Campaign> query = db.tbl_CRM_Campaign.AsNoTracking();//.Where(d => d.IsDeleted == false);
			

			//Query keyword
			if (QueryStrings.Any(d => d.Key == "Keyword") && !string.IsNullOrEmpty(QueryStrings.FirstOrDefault(d => d.Key == "Keyword").Value))
            {
                var keyword = QueryStrings.FirstOrDefault(d => d.Key == "Keyword").Value;
                query = query.Where(d=>d.Name.Contains(keyword) || d.Code.Contains(keyword));
            }



			//Query IDOwner (Nullable<int>)
			if (QueryStrings.Any(d => d.Key == "IDOwner"))
            {
                var IDList = QueryStrings.FirstOrDefault(d => d.Key == "IDOwner").Value.Replace("[", "").Replace("]", "").Split(',');
                List<int?> IDs = new List<int?>();
                foreach (var item in IDList)
                    if (int.TryParse(item, out int i))
                        IDs.Add(i);
					else if (item == "null")
						IDs.Add(null);
                if (IDs.Count > 0)
                    query = query.Where(d => IDs.Contains(d.IDOwner));
////                    query = query.Where(d => IDs.Contains(d.IDOwner));
//                    
            }

			//Query IDStatus (int)
			if (QueryStrings.Any(d => d.Key == "IDStatus"))
            {
                var IDList = QueryStrings.FirstOrDefault(d => d.Key == "IDStatus").Value.Replace("[", "").Replace("]", "").Split(',');
                List<int> IDs = new List<int>();
                foreach (var item in IDList)
                    if (int.TryParse(item, out int i))
                        IDs.Add(i);
                if (IDs.Count > 0)
                    query = query.Where(d => IDs.Contains(d.IDStatus));
            }

			//Query IDType (Nullable<int>)
			if (QueryStrings.Any(d => d.Key == "IDType"))
            {
                var IDList = QueryStrings.FirstOrDefault(d => d.Key == "IDType").Value.Replace("[", "").Replace("]", "").Split(',');
                List<int?> IDs = new List<int?>();
                foreach (var item in IDList)
                    if (int.TryParse(item, out int i))
                        IDs.Add(i);
					else if (item == "null")
						IDs.Add(null);
                if (IDs.Count > 0)
                    query = query.Where(d => IDs.Contains(d.IDType));
////                    query = query.Where(d => IDs.Contains(d.IDType));
//                    
            }

			//Query IDParent (Nullable<int>)
			if (QueryStrings.Any(d => d.Key == "IDParent"))
            {
                var IDList = QueryStrings.FirstOrDefault(d => d.Key == "IDParent").Value.Replace("[", "").Replace("]", "").Split(',');
                List<int?> IDs = new List<int?>();
                foreach (var item in IDList)
                    if (int.TryParse(item, out int i))
                        IDs.Add(i);
					else if (item == "null")
						IDs.Add(null);
                if (IDs.Count > 0)
                    query = query.Where(d => IDs.Contains(d.IDParent));
////                    query = query.Where(d => IDs.Contains(d.IDParent));
//                    
            }

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
            

			//Query StartDate (System.DateTime)
			if (QueryStrings.Any(d => d.Key == "StartDateFrom") && QueryStrings.Any(d => d.Key == "StartDateTo"))
                if (DateTime.TryParse(QueryStrings.FirstOrDefault(d => d.Key == "StartDateFrom").Value, out DateTime fromDate) && DateTime.TryParse(QueryStrings.FirstOrDefault(d => d.Key == "StartDateTo").Value, out DateTime toDate))
                    query = query.Where(d => fromDate <= d.StartDate && d.StartDate <= toDate);

            if (QueryStrings.Any(d => d.Key == "StartDate"))
                if (DateTime.TryParse(QueryStrings.FirstOrDefault(d => d.Key == "StartDate").Value, out DateTime val))
                    query = query.Where(d => d.StartDate != null && DbFunctions.TruncateTime(val) == DbFunctions.TruncateTime(d.StartDate));


			//Query EndDate (System.DateTime)
			if (QueryStrings.Any(d => d.Key == "EndDateFrom") && QueryStrings.Any(d => d.Key == "EndDateTo"))
                if (DateTime.TryParse(QueryStrings.FirstOrDefault(d => d.Key == "EndDateFrom").Value, out DateTime fromDate) && DateTime.TryParse(QueryStrings.FirstOrDefault(d => d.Key == "EndDateTo").Value, out DateTime toDate))
                    query = query.Where(d => fromDate <= d.EndDate && d.EndDate <= toDate);

            if (QueryStrings.Any(d => d.Key == "EndDate"))
                if (DateTime.TryParse(QueryStrings.FirstOrDefault(d => d.Key == "EndDate").Value, out DateTime val))
                    query = query.Where(d => d.EndDate != null && DbFunctions.TruncateTime(val) == DbFunctions.TruncateTime(d.EndDate));


			//Query NumSent (int)
			if (QueryStrings.Any(d => d.Key == "NumSentFrom") && QueryStrings.Any(d => d.Key == "NumSentTo"))
                if (int.TryParse(QueryStrings.FirstOrDefault(d => d.Key == "NumSentFrom").Value, out int fromVal) && int.TryParse(QueryStrings.FirstOrDefault(d => d.Key == "NumSentTo").Value, out int toVal))
                    query = query.Where(d => fromVal <= d.NumSent && d.NumSent <= toVal);
            
            if (QueryStrings.Any(d => d.Key == "NumSent"))
                if (int.TryParse(QueryStrings.FirstOrDefault(d => d.Key == "NumSent").Value, out int val))
                    query = query.Where(d => val == d.NumSent);


			//Query ExpectedResponse (int)
			if (QueryStrings.Any(d => d.Key == "ExpectedResponseFrom") && QueryStrings.Any(d => d.Key == "ExpectedResponseTo"))
                if (int.TryParse(QueryStrings.FirstOrDefault(d => d.Key == "ExpectedResponseFrom").Value, out int fromVal) && int.TryParse(QueryStrings.FirstOrDefault(d => d.Key == "ExpectedResponseTo").Value, out int toVal))
                    query = query.Where(d => fromVal <= d.ExpectedResponse && d.ExpectedResponse <= toVal);
            
            if (QueryStrings.Any(d => d.Key == "ExpectedResponse"))
                if (int.TryParse(QueryStrings.FirstOrDefault(d => d.Key == "ExpectedResponse").Value, out int val))
                    query = query.Where(d => val == d.ExpectedResponse);


			//Query ExpectedRevenue (decimal)
			if (QueryStrings.Any(d => d.Key == "ExpectedRevenueFrom") && QueryStrings.Any(d => d.Key == "ExpectedRevenueTo"))
                if (decimal.TryParse(QueryStrings.FirstOrDefault(d => d.Key == "ExpectedRevenueFrom").Value, out decimal fromVal) && decimal.TryParse(QueryStrings.FirstOrDefault(d => d.Key == "ExpectedRevenueTo").Value, out decimal toVal))
                    query = query.Where(d => fromVal <= d.ExpectedRevenue && d.ExpectedRevenue <= toVal);
            
            if (QueryStrings.Any(d => d.Key == "ExpectedRevenue"))
                if (decimal.TryParse(QueryStrings.FirstOrDefault(d => d.Key == "ExpectedRevenue").Value, out decimal val))
                    query = query.Where(d => val == d.ExpectedRevenue);


			//Query BudgetedCost (decimal)
			if (QueryStrings.Any(d => d.Key == "BudgetedCostFrom") && QueryStrings.Any(d => d.Key == "BudgetedCostTo"))
                if (decimal.TryParse(QueryStrings.FirstOrDefault(d => d.Key == "BudgetedCostFrom").Value, out decimal fromVal) && decimal.TryParse(QueryStrings.FirstOrDefault(d => d.Key == "BudgetedCostTo").Value, out decimal toVal))
                    query = query.Where(d => fromVal <= d.BudgetedCost && d.BudgetedCost <= toVal);
            
            if (QueryStrings.Any(d => d.Key == "BudgetedCost"))
                if (decimal.TryParse(QueryStrings.FirstOrDefault(d => d.Key == "BudgetedCost").Value, out decimal val))
                    query = query.Where(d => val == d.BudgetedCost);


			//Query ActualCost (decimal)
			if (QueryStrings.Any(d => d.Key == "ActualCostFrom") && QueryStrings.Any(d => d.Key == "ActualCostTo"))
                if (decimal.TryParse(QueryStrings.FirstOrDefault(d => d.Key == "ActualCostFrom").Value, out decimal fromVal) && decimal.TryParse(QueryStrings.FirstOrDefault(d => d.Key == "ActualCostTo").Value, out decimal toVal))
                    query = query.Where(d => fromVal <= d.ActualCost && d.ActualCost <= toVal);
            
            if (QueryStrings.Any(d => d.Key == "ActualCost"))
                if (decimal.TryParse(QueryStrings.FirstOrDefault(d => d.Key == "ActualCost").Value, out decimal val))
                    query = query.Where(d => val == d.ActualCost);


			//Query IsActive (bool)
			if (QueryStrings.Any(d => d.Key == "IsActive"))
            {
                var qValue = QueryStrings.FirstOrDefault(d => d.Key == "IsActive").Value;
                if (bool.TryParse(qValue, out bool qBoolValue))
                    query = query.Where(d => qBoolValue == d.IsActive);
            }

			//Query HierarchyActualCost (decimal)
			if (QueryStrings.Any(d => d.Key == "HierarchyActualCostFrom") && QueryStrings.Any(d => d.Key == "HierarchyActualCostTo"))
                if (decimal.TryParse(QueryStrings.FirstOrDefault(d => d.Key == "HierarchyActualCostFrom").Value, out decimal fromVal) && decimal.TryParse(QueryStrings.FirstOrDefault(d => d.Key == "HierarchyActualCostTo").Value, out decimal toVal))
                    query = query.Where(d => fromVal <= d.HierarchyActualCost && d.HierarchyActualCost <= toVal);
            
            if (QueryStrings.Any(d => d.Key == "HierarchyActualCost"))
                if (decimal.TryParse(QueryStrings.FirstOrDefault(d => d.Key == "HierarchyActualCost").Value, out decimal val))
                    query = query.Where(d => val == d.HierarchyActualCost);


			//Query HierarchyBudgetedCost (decimal)
			if (QueryStrings.Any(d => d.Key == "HierarchyBudgetedCostFrom") && QueryStrings.Any(d => d.Key == "HierarchyBudgetedCostTo"))
                if (decimal.TryParse(QueryStrings.FirstOrDefault(d => d.Key == "HierarchyBudgetedCostFrom").Value, out decimal fromVal) && decimal.TryParse(QueryStrings.FirstOrDefault(d => d.Key == "HierarchyBudgetedCostTo").Value, out decimal toVal))
                    query = query.Where(d => fromVal <= d.HierarchyBudgetedCost && d.HierarchyBudgetedCost <= toVal);
            
            if (QueryStrings.Any(d => d.Key == "HierarchyBudgetedCost"))
                if (decimal.TryParse(QueryStrings.FirstOrDefault(d => d.Key == "HierarchyBudgetedCost").Value, out decimal val))
                    query = query.Where(d => val == d.HierarchyBudgetedCost);


			//Query NumberOfContacts (int)
			if (QueryStrings.Any(d => d.Key == "NumberOfContactsFrom") && QueryStrings.Any(d => d.Key == "NumberOfContactsTo"))
                if (int.TryParse(QueryStrings.FirstOrDefault(d => d.Key == "NumberOfContactsFrom").Value, out int fromVal) && int.TryParse(QueryStrings.FirstOrDefault(d => d.Key == "NumberOfContactsTo").Value, out int toVal))
                    query = query.Where(d => fromVal <= d.NumberOfContacts && d.NumberOfContacts <= toVal);
            
            if (QueryStrings.Any(d => d.Key == "NumberOfContacts"))
                if (int.TryParse(QueryStrings.FirstOrDefault(d => d.Key == "NumberOfContacts").Value, out int val))
                    query = query.Where(d => val == d.NumberOfContacts);


			//Query HierarchyNumberOfContacts (int)
			if (QueryStrings.Any(d => d.Key == "HierarchyNumberOfContactsFrom") && QueryStrings.Any(d => d.Key == "HierarchyNumberOfContactsTo"))
                if (int.TryParse(QueryStrings.FirstOrDefault(d => d.Key == "HierarchyNumberOfContactsFrom").Value, out int fromVal) && int.TryParse(QueryStrings.FirstOrDefault(d => d.Key == "HierarchyNumberOfContactsTo").Value, out int toVal))
                    query = query.Where(d => fromVal <= d.HierarchyNumberOfContacts && d.HierarchyNumberOfContacts <= toVal);
            
            if (QueryStrings.Any(d => d.Key == "HierarchyNumberOfContacts"))
                if (int.TryParse(QueryStrings.FirstOrDefault(d => d.Key == "HierarchyNumberOfContacts").Value, out int val))
                    query = query.Where(d => val == d.HierarchyNumberOfContacts);


			//Query NumberOfConvertedLeads (int)
			if (QueryStrings.Any(d => d.Key == "NumberOfConvertedLeadsFrom") && QueryStrings.Any(d => d.Key == "NumberOfConvertedLeadsTo"))
                if (int.TryParse(QueryStrings.FirstOrDefault(d => d.Key == "NumberOfConvertedLeadsFrom").Value, out int fromVal) && int.TryParse(QueryStrings.FirstOrDefault(d => d.Key == "NumberOfConvertedLeadsTo").Value, out int toVal))
                    query = query.Where(d => fromVal <= d.NumberOfConvertedLeads && d.NumberOfConvertedLeads <= toVal);
            
            if (QueryStrings.Any(d => d.Key == "NumberOfConvertedLeads"))
                if (int.TryParse(QueryStrings.FirstOrDefault(d => d.Key == "NumberOfConvertedLeads").Value, out int val))
                    query = query.Where(d => val == d.NumberOfConvertedLeads);


			//Query HierarchyNumberOfConvertedLeads (int)
			if (QueryStrings.Any(d => d.Key == "HierarchyNumberOfConvertedLeadsFrom") && QueryStrings.Any(d => d.Key == "HierarchyNumberOfConvertedLeadsTo"))
                if (int.TryParse(QueryStrings.FirstOrDefault(d => d.Key == "HierarchyNumberOfConvertedLeadsFrom").Value, out int fromVal) && int.TryParse(QueryStrings.FirstOrDefault(d => d.Key == "HierarchyNumberOfConvertedLeadsTo").Value, out int toVal))
                    query = query.Where(d => fromVal <= d.HierarchyNumberOfConvertedLeads && d.HierarchyNumberOfConvertedLeads <= toVal);
            
            if (QueryStrings.Any(d => d.Key == "HierarchyNumberOfConvertedLeads"))
                if (int.TryParse(QueryStrings.FirstOrDefault(d => d.Key == "HierarchyNumberOfConvertedLeads").Value, out int val))
                    query = query.Where(d => val == d.HierarchyNumberOfConvertedLeads);


			//Query HierarchyExpectedRevenue (decimal)
			if (QueryStrings.Any(d => d.Key == "HierarchyExpectedRevenueFrom") && QueryStrings.Any(d => d.Key == "HierarchyExpectedRevenueTo"))
                if (decimal.TryParse(QueryStrings.FirstOrDefault(d => d.Key == "HierarchyExpectedRevenueFrom").Value, out decimal fromVal) && decimal.TryParse(QueryStrings.FirstOrDefault(d => d.Key == "HierarchyExpectedRevenueTo").Value, out decimal toVal))
                    query = query.Where(d => fromVal <= d.HierarchyExpectedRevenue && d.HierarchyExpectedRevenue <= toVal);
            
            if (QueryStrings.Any(d => d.Key == "HierarchyExpectedRevenue"))
                if (decimal.TryParse(QueryStrings.FirstOrDefault(d => d.Key == "HierarchyExpectedRevenue").Value, out decimal val))
                    query = query.Where(d => val == d.HierarchyExpectedRevenue);


			//Query NumberOfLeads (int)
			if (QueryStrings.Any(d => d.Key == "NumberOfLeadsFrom") && QueryStrings.Any(d => d.Key == "NumberOfLeadsTo"))
                if (int.TryParse(QueryStrings.FirstOrDefault(d => d.Key == "NumberOfLeadsFrom").Value, out int fromVal) && int.TryParse(QueryStrings.FirstOrDefault(d => d.Key == "NumberOfLeadsTo").Value, out int toVal))
                    query = query.Where(d => fromVal <= d.NumberOfLeads && d.NumberOfLeads <= toVal);
            
            if (QueryStrings.Any(d => d.Key == "NumberOfLeads"))
                if (int.TryParse(QueryStrings.FirstOrDefault(d => d.Key == "NumberOfLeads").Value, out int val))
                    query = query.Where(d => val == d.NumberOfLeads);


			//Query HierarchyNumberOfLeads (int)
			if (QueryStrings.Any(d => d.Key == "HierarchyNumberOfLeadsFrom") && QueryStrings.Any(d => d.Key == "HierarchyNumberOfLeadsTo"))
                if (int.TryParse(QueryStrings.FirstOrDefault(d => d.Key == "HierarchyNumberOfLeadsFrom").Value, out int fromVal) && int.TryParse(QueryStrings.FirstOrDefault(d => d.Key == "HierarchyNumberOfLeadsTo").Value, out int toVal))
                    query = query.Where(d => fromVal <= d.HierarchyNumberOfLeads && d.HierarchyNumberOfLeads <= toVal);
            
            if (QueryStrings.Any(d => d.Key == "HierarchyNumberOfLeads"))
                if (int.TryParse(QueryStrings.FirstOrDefault(d => d.Key == "HierarchyNumberOfLeads").Value, out int val))
                    query = query.Where(d => val == d.HierarchyNumberOfLeads);


			//Query HierarchyNumberSent (int)
			if (QueryStrings.Any(d => d.Key == "HierarchyNumberSentFrom") && QueryStrings.Any(d => d.Key == "HierarchyNumberSentTo"))
                if (int.TryParse(QueryStrings.FirstOrDefault(d => d.Key == "HierarchyNumberSentFrom").Value, out int fromVal) && int.TryParse(QueryStrings.FirstOrDefault(d => d.Key == "HierarchyNumberSentTo").Value, out int toVal))
                    query = query.Where(d => fromVal <= d.HierarchyNumberSent && d.HierarchyNumberSent <= toVal);
            
            if (QueryStrings.Any(d => d.Key == "HierarchyNumberSent"))
                if (int.TryParse(QueryStrings.FirstOrDefault(d => d.Key == "HierarchyNumberSent").Value, out int val))
                    query = query.Where(d => val == d.HierarchyNumberSent);


			//Query NumberOfOpportunities (int)
			if (QueryStrings.Any(d => d.Key == "NumberOfOpportunitiesFrom") && QueryStrings.Any(d => d.Key == "NumberOfOpportunitiesTo"))
                if (int.TryParse(QueryStrings.FirstOrDefault(d => d.Key == "NumberOfOpportunitiesFrom").Value, out int fromVal) && int.TryParse(QueryStrings.FirstOrDefault(d => d.Key == "NumberOfOpportunitiesTo").Value, out int toVal))
                    query = query.Where(d => fromVal <= d.NumberOfOpportunities && d.NumberOfOpportunities <= toVal);
            
            if (QueryStrings.Any(d => d.Key == "NumberOfOpportunities"))
                if (int.TryParse(QueryStrings.FirstOrDefault(d => d.Key == "NumberOfOpportunities").Value, out int val))
                    query = query.Where(d => val == d.NumberOfOpportunities);


			//Query HierarchyNumberOfOpportunities (int)
			if (QueryStrings.Any(d => d.Key == "HierarchyNumberOfOpportunitiesFrom") && QueryStrings.Any(d => d.Key == "HierarchyNumberOfOpportunitiesTo"))
                if (int.TryParse(QueryStrings.FirstOrDefault(d => d.Key == "HierarchyNumberOfOpportunitiesFrom").Value, out int fromVal) && int.TryParse(QueryStrings.FirstOrDefault(d => d.Key == "HierarchyNumberOfOpportunitiesTo").Value, out int toVal))
                    query = query.Where(d => fromVal <= d.HierarchyNumberOfOpportunities && d.HierarchyNumberOfOpportunities <= toVal);
            
            if (QueryStrings.Any(d => d.Key == "HierarchyNumberOfOpportunities"))
                if (int.TryParse(QueryStrings.FirstOrDefault(d => d.Key == "HierarchyNumberOfOpportunities").Value, out int val))
                    query = query.Where(d => val == d.HierarchyNumberOfOpportunities);


			//Query NumberOfResponses (int)
			if (QueryStrings.Any(d => d.Key == "NumberOfResponsesFrom") && QueryStrings.Any(d => d.Key == "NumberOfResponsesTo"))
                if (int.TryParse(QueryStrings.FirstOrDefault(d => d.Key == "NumberOfResponsesFrom").Value, out int fromVal) && int.TryParse(QueryStrings.FirstOrDefault(d => d.Key == "NumberOfResponsesTo").Value, out int toVal))
                    query = query.Where(d => fromVal <= d.NumberOfResponses && d.NumberOfResponses <= toVal);
            
            if (QueryStrings.Any(d => d.Key == "NumberOfResponses"))
                if (int.TryParse(QueryStrings.FirstOrDefault(d => d.Key == "NumberOfResponses").Value, out int val))
                    query = query.Where(d => val == d.NumberOfResponses);


			//Query HierarchyNumberOfResponses (int)
			if (QueryStrings.Any(d => d.Key == "HierarchyNumberOfResponsesFrom") && QueryStrings.Any(d => d.Key == "HierarchyNumberOfResponsesTo"))
                if (int.TryParse(QueryStrings.FirstOrDefault(d => d.Key == "HierarchyNumberOfResponsesFrom").Value, out int fromVal) && int.TryParse(QueryStrings.FirstOrDefault(d => d.Key == "HierarchyNumberOfResponsesTo").Value, out int toVal))
                    query = query.Where(d => fromVal <= d.HierarchyNumberOfResponses && d.HierarchyNumberOfResponses <= toVal);
            
            if (QueryStrings.Any(d => d.Key == "HierarchyNumberOfResponses"))
                if (int.TryParse(QueryStrings.FirstOrDefault(d => d.Key == "HierarchyNumberOfResponses").Value, out int val))
                    query = query.Where(d => val == d.HierarchyNumberOfResponses);


			//Query AmountAllOpportunities (decimal)
			if (QueryStrings.Any(d => d.Key == "AmountAllOpportunitiesFrom") && QueryStrings.Any(d => d.Key == "AmountAllOpportunitiesTo"))
                if (decimal.TryParse(QueryStrings.FirstOrDefault(d => d.Key == "AmountAllOpportunitiesFrom").Value, out decimal fromVal) && decimal.TryParse(QueryStrings.FirstOrDefault(d => d.Key == "AmountAllOpportunitiesTo").Value, out decimal toVal))
                    query = query.Where(d => fromVal <= d.AmountAllOpportunities && d.AmountAllOpportunities <= toVal);
            
            if (QueryStrings.Any(d => d.Key == "AmountAllOpportunities"))
                if (decimal.TryParse(QueryStrings.FirstOrDefault(d => d.Key == "AmountAllOpportunities").Value, out decimal val))
                    query = query.Where(d => val == d.AmountAllOpportunities);


			//Query HierarchyAmountAllOpportunities (decimal)
			if (QueryStrings.Any(d => d.Key == "HierarchyAmountAllOpportunitiesFrom") && QueryStrings.Any(d => d.Key == "HierarchyAmountAllOpportunitiesTo"))
                if (decimal.TryParse(QueryStrings.FirstOrDefault(d => d.Key == "HierarchyAmountAllOpportunitiesFrom").Value, out decimal fromVal) && decimal.TryParse(QueryStrings.FirstOrDefault(d => d.Key == "HierarchyAmountAllOpportunitiesTo").Value, out decimal toVal))
                    query = query.Where(d => fromVal <= d.HierarchyAmountAllOpportunities && d.HierarchyAmountAllOpportunities <= toVal);
            
            if (QueryStrings.Any(d => d.Key == "HierarchyAmountAllOpportunities"))
                if (decimal.TryParse(QueryStrings.FirstOrDefault(d => d.Key == "HierarchyAmountAllOpportunities").Value, out decimal val))
                    query = query.Where(d => val == d.HierarchyAmountAllOpportunities);


			//Query AmountWonOpportunities (decimal)
			if (QueryStrings.Any(d => d.Key == "AmountWonOpportunitiesFrom") && QueryStrings.Any(d => d.Key == "AmountWonOpportunitiesTo"))
                if (decimal.TryParse(QueryStrings.FirstOrDefault(d => d.Key == "AmountWonOpportunitiesFrom").Value, out decimal fromVal) && decimal.TryParse(QueryStrings.FirstOrDefault(d => d.Key == "AmountWonOpportunitiesTo").Value, out decimal toVal))
                    query = query.Where(d => fromVal <= d.AmountWonOpportunities && d.AmountWonOpportunities <= toVal);
            
            if (QueryStrings.Any(d => d.Key == "AmountWonOpportunities"))
                if (decimal.TryParse(QueryStrings.FirstOrDefault(d => d.Key == "AmountWonOpportunities").Value, out decimal val))
                    query = query.Where(d => val == d.AmountWonOpportunities);


			//Query HierarchyAmountWonOpportunities (decimal)
			if (QueryStrings.Any(d => d.Key == "HierarchyAmountWonOpportunitiesFrom") && QueryStrings.Any(d => d.Key == "HierarchyAmountWonOpportunitiesTo"))
                if (decimal.TryParse(QueryStrings.FirstOrDefault(d => d.Key == "HierarchyAmountWonOpportunitiesFrom").Value, out decimal fromVal) && decimal.TryParse(QueryStrings.FirstOrDefault(d => d.Key == "HierarchyAmountWonOpportunitiesTo").Value, out decimal toVal))
                    query = query.Where(d => fromVal <= d.HierarchyAmountWonOpportunities && d.HierarchyAmountWonOpportunities <= toVal);
            
            if (QueryStrings.Any(d => d.Key == "HierarchyAmountWonOpportunities"))
                if (decimal.TryParse(QueryStrings.FirstOrDefault(d => d.Key == "HierarchyAmountWonOpportunities").Value, out decimal val))
                    query = query.Where(d => val == d.HierarchyAmountWonOpportunities);


			//Query NumberOfWonOpportunities (Nullable<int>)
			if (QueryStrings.Any(d => d.Key == "NumberOfWonOpportunitiesFrom") && QueryStrings.Any(d => d.Key == "NumberOfWonOpportunitiesTo"))
                if (int.TryParse(QueryStrings.FirstOrDefault(d => d.Key == "NumberOfWonOpportunitiesFrom").Value, out int fromVal) && int.TryParse(QueryStrings.FirstOrDefault(d => d.Key == "NumberOfWonOpportunitiesTo").Value, out int toVal))
                    query = query.Where(d => fromVal <= d.NumberOfWonOpportunities && d.NumberOfWonOpportunities <= toVal);

			//Query HierarchyNumberOfWonOpportunities (int)
			if (QueryStrings.Any(d => d.Key == "HierarchyNumberOfWonOpportunitiesFrom") && QueryStrings.Any(d => d.Key == "HierarchyNumberOfWonOpportunitiesTo"))
                if (int.TryParse(QueryStrings.FirstOrDefault(d => d.Key == "HierarchyNumberOfWonOpportunitiesFrom").Value, out int fromVal) && int.TryParse(QueryStrings.FirstOrDefault(d => d.Key == "HierarchyNumberOfWonOpportunitiesTo").Value, out int toVal))
                    query = query.Where(d => fromVal <= d.HierarchyNumberOfWonOpportunities && d.HierarchyNumberOfWonOpportunities <= toVal);
            
            if (QueryStrings.Any(d => d.Key == "HierarchyNumberOfWonOpportunities"))
                if (int.TryParse(QueryStrings.FirstOrDefault(d => d.Key == "HierarchyNumberOfWonOpportunities").Value, out int val))
                    query = query.Where(d => val == d.HierarchyNumberOfWonOpportunities);


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
		
        public static IQueryable<tbl_CRM_Campaign> _sortBuilder(IQueryable<tbl_CRM_Campaign> query, Dictionary<string, string> QueryStrings)
        {
            if (QueryStrings.Any(d => d.Key == "SortBy"))
            {
                var sorts = QueryStrings.FirstOrDefault(d => d.Key == "SortBy").Value.Replace("[", "").Replace("]", "").Split(',');
                
                foreach (var item in sorts)
                    if (!string.IsNullOrEmpty(item))
                    {
                        var ordered = query as IOrderedQueryable<tbl_CRM_Campaign>;
                        bool isOrdered = ordered.ToString().IndexOf("ORDER BY") !=-1;

                        switch (item)
                        {
							case "IDOwner":
								query = isOrdered ? ordered.ThenBy(o => o.IDOwner) : query.OrderBy(o => o.IDOwner);
								 break;
							case "IDOwner_desc":
                                query = isOrdered ? ordered.ThenByDescending(o => o.IDOwner) : query.OrderByDescending(o => o.IDOwner);
                                break;
							case "IDStatus":
								query = isOrdered ? ordered.ThenBy(o => o.IDStatus) : query.OrderBy(o => o.IDStatus);
								 break;
							case "IDStatus_desc":
                                query = isOrdered ? ordered.ThenByDescending(o => o.IDStatus) : query.OrderByDescending(o => o.IDStatus);
                                break;
							case "IDType":
								query = isOrdered ? ordered.ThenBy(o => o.IDType) : query.OrderBy(o => o.IDType);
								 break;
							case "IDType_desc":
                                query = isOrdered ? ordered.ThenByDescending(o => o.IDType) : query.OrderByDescending(o => o.IDType);
                                break;
							case "IDParent":
								query = isOrdered ? ordered.ThenBy(o => o.IDParent) : query.OrderBy(o => o.IDParent);
								 break;
							case "IDParent_desc":
                                query = isOrdered ? ordered.ThenByDescending(o => o.IDParent) : query.OrderByDescending(o => o.IDParent);
                                break;
							case "IDBranch":
								query = isOrdered ? ordered.ThenBy(o => o.IDBranch) : query.OrderBy(o => o.IDBranch);
								 break;
							case "IDBranch_desc":
                                query = isOrdered ? ordered.ThenByDescending(o => o.IDBranch) : query.OrderByDescending(o => o.IDBranch);
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
							case "StartDate":
								query = isOrdered ? ordered.ThenBy(o => o.StartDate) : query.OrderBy(o => o.StartDate);
								 break;
							case "StartDate_desc":
                                query = isOrdered ? ordered.ThenByDescending(o => o.StartDate) : query.OrderByDescending(o => o.StartDate);
                                break;
							case "EndDate":
								query = isOrdered ? ordered.ThenBy(o => o.EndDate) : query.OrderBy(o => o.EndDate);
								 break;
							case "EndDate_desc":
                                query = isOrdered ? ordered.ThenByDescending(o => o.EndDate) : query.OrderByDescending(o => o.EndDate);
                                break;
							case "NumSent":
								query = isOrdered ? ordered.ThenBy(o => o.NumSent) : query.OrderBy(o => o.NumSent);
								 break;
							case "NumSent_desc":
                                query = isOrdered ? ordered.ThenByDescending(o => o.NumSent) : query.OrderByDescending(o => o.NumSent);
                                break;
							case "ExpectedResponse":
								query = isOrdered ? ordered.ThenBy(o => o.ExpectedResponse) : query.OrderBy(o => o.ExpectedResponse);
								 break;
							case "ExpectedResponse_desc":
                                query = isOrdered ? ordered.ThenByDescending(o => o.ExpectedResponse) : query.OrderByDescending(o => o.ExpectedResponse);
                                break;
							case "ExpectedRevenue":
								query = isOrdered ? ordered.ThenBy(o => o.ExpectedRevenue) : query.OrderBy(o => o.ExpectedRevenue);
								 break;
							case "ExpectedRevenue_desc":
                                query = isOrdered ? ordered.ThenByDescending(o => o.ExpectedRevenue) : query.OrderByDescending(o => o.ExpectedRevenue);
                                break;
							case "BudgetedCost":
								query = isOrdered ? ordered.ThenBy(o => o.BudgetedCost) : query.OrderBy(o => o.BudgetedCost);
								 break;
							case "BudgetedCost_desc":
                                query = isOrdered ? ordered.ThenByDescending(o => o.BudgetedCost) : query.OrderByDescending(o => o.BudgetedCost);
                                break;
							case "ActualCost":
								query = isOrdered ? ordered.ThenBy(o => o.ActualCost) : query.OrderBy(o => o.ActualCost);
								 break;
							case "ActualCost_desc":
                                query = isOrdered ? ordered.ThenByDescending(o => o.ActualCost) : query.OrderByDescending(o => o.ActualCost);
                                break;
							case "IsActive":
								query = isOrdered ? ordered.ThenBy(o => o.IsActive) : query.OrderBy(o => o.IsActive);
								 break;
							case "IsActive_desc":
                                query = isOrdered ? ordered.ThenByDescending(o => o.IsActive) : query.OrderByDescending(o => o.IsActive);
                                break;
							case "HierarchyActualCost":
								query = isOrdered ? ordered.ThenBy(o => o.HierarchyActualCost) : query.OrderBy(o => o.HierarchyActualCost);
								 break;
							case "HierarchyActualCost_desc":
                                query = isOrdered ? ordered.ThenByDescending(o => o.HierarchyActualCost) : query.OrderByDescending(o => o.HierarchyActualCost);
                                break;
							case "HierarchyBudgetedCost":
								query = isOrdered ? ordered.ThenBy(o => o.HierarchyBudgetedCost) : query.OrderBy(o => o.HierarchyBudgetedCost);
								 break;
							case "HierarchyBudgetedCost_desc":
                                query = isOrdered ? ordered.ThenByDescending(o => o.HierarchyBudgetedCost) : query.OrderByDescending(o => o.HierarchyBudgetedCost);
                                break;
							case "NumberOfContacts":
								query = isOrdered ? ordered.ThenBy(o => o.NumberOfContacts) : query.OrderBy(o => o.NumberOfContacts);
								 break;
							case "NumberOfContacts_desc":
                                query = isOrdered ? ordered.ThenByDescending(o => o.NumberOfContacts) : query.OrderByDescending(o => o.NumberOfContacts);
                                break;
							case "HierarchyNumberOfContacts":
								query = isOrdered ? ordered.ThenBy(o => o.HierarchyNumberOfContacts) : query.OrderBy(o => o.HierarchyNumberOfContacts);
								 break;
							case "HierarchyNumberOfContacts_desc":
                                query = isOrdered ? ordered.ThenByDescending(o => o.HierarchyNumberOfContacts) : query.OrderByDescending(o => o.HierarchyNumberOfContacts);
                                break;
							case "NumberOfConvertedLeads":
								query = isOrdered ? ordered.ThenBy(o => o.NumberOfConvertedLeads) : query.OrderBy(o => o.NumberOfConvertedLeads);
								 break;
							case "NumberOfConvertedLeads_desc":
                                query = isOrdered ? ordered.ThenByDescending(o => o.NumberOfConvertedLeads) : query.OrderByDescending(o => o.NumberOfConvertedLeads);
                                break;
							case "HierarchyNumberOfConvertedLeads":
								query = isOrdered ? ordered.ThenBy(o => o.HierarchyNumberOfConvertedLeads) : query.OrderBy(o => o.HierarchyNumberOfConvertedLeads);
								 break;
							case "HierarchyNumberOfConvertedLeads_desc":
                                query = isOrdered ? ordered.ThenByDescending(o => o.HierarchyNumberOfConvertedLeads) : query.OrderByDescending(o => o.HierarchyNumberOfConvertedLeads);
                                break;
							case "HierarchyExpectedRevenue":
								query = isOrdered ? ordered.ThenBy(o => o.HierarchyExpectedRevenue) : query.OrderBy(o => o.HierarchyExpectedRevenue);
								 break;
							case "HierarchyExpectedRevenue_desc":
                                query = isOrdered ? ordered.ThenByDescending(o => o.HierarchyExpectedRevenue) : query.OrderByDescending(o => o.HierarchyExpectedRevenue);
                                break;
							case "NumberOfLeads":
								query = isOrdered ? ordered.ThenBy(o => o.NumberOfLeads) : query.OrderBy(o => o.NumberOfLeads);
								 break;
							case "NumberOfLeads_desc":
                                query = isOrdered ? ordered.ThenByDescending(o => o.NumberOfLeads) : query.OrderByDescending(o => o.NumberOfLeads);
                                break;
							case "HierarchyNumberOfLeads":
								query = isOrdered ? ordered.ThenBy(o => o.HierarchyNumberOfLeads) : query.OrderBy(o => o.HierarchyNumberOfLeads);
								 break;
							case "HierarchyNumberOfLeads_desc":
                                query = isOrdered ? ordered.ThenByDescending(o => o.HierarchyNumberOfLeads) : query.OrderByDescending(o => o.HierarchyNumberOfLeads);
                                break;
							case "HierarchyNumberSent":
								query = isOrdered ? ordered.ThenBy(o => o.HierarchyNumberSent) : query.OrderBy(o => o.HierarchyNumberSent);
								 break;
							case "HierarchyNumberSent_desc":
                                query = isOrdered ? ordered.ThenByDescending(o => o.HierarchyNumberSent) : query.OrderByDescending(o => o.HierarchyNumberSent);
                                break;
							case "NumberOfOpportunities":
								query = isOrdered ? ordered.ThenBy(o => o.NumberOfOpportunities) : query.OrderBy(o => o.NumberOfOpportunities);
								 break;
							case "NumberOfOpportunities_desc":
                                query = isOrdered ? ordered.ThenByDescending(o => o.NumberOfOpportunities) : query.OrderByDescending(o => o.NumberOfOpportunities);
                                break;
							case "HierarchyNumberOfOpportunities":
								query = isOrdered ? ordered.ThenBy(o => o.HierarchyNumberOfOpportunities) : query.OrderBy(o => o.HierarchyNumberOfOpportunities);
								 break;
							case "HierarchyNumberOfOpportunities_desc":
                                query = isOrdered ? ordered.ThenByDescending(o => o.HierarchyNumberOfOpportunities) : query.OrderByDescending(o => o.HierarchyNumberOfOpportunities);
                                break;
							case "NumberOfResponses":
								query = isOrdered ? ordered.ThenBy(o => o.NumberOfResponses) : query.OrderBy(o => o.NumberOfResponses);
								 break;
							case "NumberOfResponses_desc":
                                query = isOrdered ? ordered.ThenByDescending(o => o.NumberOfResponses) : query.OrderByDescending(o => o.NumberOfResponses);
                                break;
							case "HierarchyNumberOfResponses":
								query = isOrdered ? ordered.ThenBy(o => o.HierarchyNumberOfResponses) : query.OrderBy(o => o.HierarchyNumberOfResponses);
								 break;
							case "HierarchyNumberOfResponses_desc":
                                query = isOrdered ? ordered.ThenByDescending(o => o.HierarchyNumberOfResponses) : query.OrderByDescending(o => o.HierarchyNumberOfResponses);
                                break;
							case "AmountAllOpportunities":
								query = isOrdered ? ordered.ThenBy(o => o.AmountAllOpportunities) : query.OrderBy(o => o.AmountAllOpportunities);
								 break;
							case "AmountAllOpportunities_desc":
                                query = isOrdered ? ordered.ThenByDescending(o => o.AmountAllOpportunities) : query.OrderByDescending(o => o.AmountAllOpportunities);
                                break;
							case "HierarchyAmountAllOpportunities":
								query = isOrdered ? ordered.ThenBy(o => o.HierarchyAmountAllOpportunities) : query.OrderBy(o => o.HierarchyAmountAllOpportunities);
								 break;
							case "HierarchyAmountAllOpportunities_desc":
                                query = isOrdered ? ordered.ThenByDescending(o => o.HierarchyAmountAllOpportunities) : query.OrderByDescending(o => o.HierarchyAmountAllOpportunities);
                                break;
							case "AmountWonOpportunities":
								query = isOrdered ? ordered.ThenBy(o => o.AmountWonOpportunities) : query.OrderBy(o => o.AmountWonOpportunities);
								 break;
							case "AmountWonOpportunities_desc":
                                query = isOrdered ? ordered.ThenByDescending(o => o.AmountWonOpportunities) : query.OrderByDescending(o => o.AmountWonOpportunities);
                                break;
							case "HierarchyAmountWonOpportunities":
								query = isOrdered ? ordered.ThenBy(o => o.HierarchyAmountWonOpportunities) : query.OrderBy(o => o.HierarchyAmountWonOpportunities);
								 break;
							case "HierarchyAmountWonOpportunities_desc":
                                query = isOrdered ? ordered.ThenByDescending(o => o.HierarchyAmountWonOpportunities) : query.OrderByDescending(o => o.HierarchyAmountWonOpportunities);
                                break;
							case "NumberOfWonOpportunities":
								query = isOrdered ? ordered.ThenBy(o => o.NumberOfWonOpportunities) : query.OrderBy(o => o.NumberOfWonOpportunities);
								 break;
							case "NumberOfWonOpportunities_desc":
                                query = isOrdered ? ordered.ThenByDescending(o => o.NumberOfWonOpportunities) : query.OrderByDescending(o => o.NumberOfWonOpportunities);
                                break;
							case "HierarchyNumberOfWonOpportunities":
								query = isOrdered ? ordered.ThenBy(o => o.HierarchyNumberOfWonOpportunities) : query.OrderBy(o => o.HierarchyNumberOfWonOpportunities);
								 break;
							case "HierarchyNumberOfWonOpportunities_desc":
                                query = isOrdered ? ordered.ThenByDescending(o => o.HierarchyNumberOfWonOpportunities) : query.OrderByDescending(o => o.HierarchyNumberOfWonOpportunities);
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

        public static IQueryable<tbl_CRM_Campaign> _pagingBuilder(IQueryable<tbl_CRM_Campaign> query, Dictionary<string, string> QueryStrings)
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






