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
    
    
    public partial class tbl_HRM_Staff
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public tbl_HRM_Staff()
        {
            this.tbl_CRM_Campaign = new HashSet<tbl_CRM_Campaign>();
            this.tbl_CRM_Contact = new HashSet<tbl_CRM_Contact>();
            this.tbl_CRM_Lead = new HashSet<tbl_CRM_Lead>();
            this.tbl_CRM_Route = new HashSet<tbl_CRM_Route>();
            this.tbl_CRM_Route1 = new HashSet<tbl_CRM_Route>();
            this.tbl_HRM_DeductionOnSalary = new HashSet<tbl_HRM_DeductionOnSalary>();
            this.tbl_HRM_PayrollPaySheetMaster = new HashSet<tbl_HRM_PayrollPaySheetMaster>();
            this.tbl_HRM_PersonalIncomePaymentProcess = new HashSet<tbl_HRM_PersonalIncomePaymentProcess>();
            this.tbl_HRM_PolWelfare = new HashSet<tbl_HRM_PolWelfare>();
            this.tbl_HRM_StaffLaborContract = new HashSet<tbl_HRM_StaffLaborContract>();
            this.tbl_HRM_StaffAllowance = new HashSet<tbl_HRM_StaffAllowance>();
            this.tbl_HRM_StaffResignationInfo = new HashSet<tbl_HRM_StaffResignationInfo>();
            this.tbl_HRM_StaffSalaryDecision = new HashSet<tbl_HRM_StaffSalaryDecision>();
            this.tbl_HRM_StaffWelfare = new HashSet<tbl_HRM_StaffWelfare>();
            this.tbl_HRM_StaffCurrentWorking = new HashSet<tbl_HRM_StaffCurrentWorking>();
            this.tbl_HRM_StaffCurrentWorking1 = new HashSet<tbl_HRM_StaffCurrentWorking>();
            this.tbl_HRM_StaffRecruitmentInfo = new HashSet<tbl_HRM_StaffRecruitmentInfo>();
            this.tbl_HRM_StaffFamily = new HashSet<tbl_HRM_StaffFamily>();
            this.tbl_HRM_StaffAllowance1 = new HashSet<tbl_HRM_StaffAllowance>();
            this.tbl_HRM_StaffAnotherSkill = new HashSet<tbl_HRM_StaffAnotherSkill>();
            this.tbl_HRM_StaffAppointDecision = new HashSet<tbl_HRM_StaffAppointDecision>();
            this.tbl_HRM_StaffBank = new HashSet<tbl_HRM_StaffBank>();
            this.tbl_HRM_StaffBounusOnSalary = new HashSet<tbl_HRM_StaffBounusOnSalary>();
            this.tbl_HRM_StaffConcurrentPosition = new HashSet<tbl_HRM_StaffConcurrentPosition>();
            this.tbl_HRM_StaffConcurrentProbationryPosition = new HashSet<tbl_HRM_StaffConcurrentProbationryPosition>();
            this.tbl_HRM_StaffForeignLanguage = new HashSet<tbl_HRM_StaffForeignLanguage>();
            this.tbl_HRM_StaffInsurancePaymentProcess = new HashSet<tbl_HRM_StaffInsurancePaymentProcess>();
            this.tbl_HRM_StaffInternetAccount = new HashSet<tbl_HRM_StaffInternetAccount>();
            this.tbl_HRM_StaffLaborContract1 = new HashSet<tbl_HRM_StaffLaborContract>();
            this.tbl_HRM_StaffLearningProcess = new HashSet<tbl_HRM_StaffLearningProcess>();
            this.tbl_HRM_StaffPhone = new HashSet<tbl_HRM_StaffPhone>();
            this.tbl_HRM_StaffResignationInfo1 = new HashSet<tbl_HRM_StaffResignationInfo>();
            this.tbl_HRM_StaffSalaryDecision1 = new HashSet<tbl_HRM_StaffSalaryDecision>();
            this.tbl_HRM_StaffSpecializedField = new HashSet<tbl_HRM_StaffSpecializedField>();
            this.tbl_HRM_StaffSpecializedSkill = new HashSet<tbl_HRM_StaffSpecializedSkill>();
            this.tbl_HRM_StaffStaffAndFamilyJob = new HashSet<tbl_HRM_StaffStaffAndFamilyJob>();
            this.tbl_HRM_StaffWelfare1 = new HashSet<tbl_HRM_StaffWelfare>();
            this.tbl_HRM_StaffWorkExperience = new HashSet<tbl_HRM_StaffWorkExperience>();
            this.tbl_HRM_StaffWorkingDiary = new HashSet<tbl_HRM_StaffWorkingDiary>();
            this.tbl_HRM_Staff_ConcurrentPosition = new HashSet<tbl_HRM_Staff_ConcurrentPosition>();
            this.tbl_HRM_TimeSheetLog = new HashSet<tbl_HRM_TimeSheetLog>();
            this.tbl_SALE_Order = new HashSet<tbl_SALE_Order>();
            this.tbl_SHIFT_TimeSheet = new HashSet<tbl_SHIFT_TimeSheet>();
            this.tbl_SHIP_Shipment = new HashSet<tbl_SHIP_Shipment>();
            this.tbl_SHIP_Vehicle = new HashSet<tbl_SHIP_Vehicle>();
        }
    
        public Nullable<int> IDBranch { get; set; }
        public Nullable<int> IDDepartment { get; set; }
        public Nullable<int> IDJobTitle { get; set; }
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
        public string Title { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string FullName { get; set; }
        public string ShortName { get; set; }
        public Nullable<bool> Gender { get; set; }
        public string DOB { get; set; }
        public string IdentityCardNumber { get; set; }
        public string Domicile { get; set; }
        public Nullable<System.DateTime> DateOfIssueID { get; set; }
        public string IssuedBy { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
        public string Address { get; set; }
        public string BackgroundColor { get; set; }
        public string ImageURL { get; set; }
        //List 0:1
        public virtual tbl_BRA_Branch tbl_BRA_Branch { get; set; }
        //List 0:1
        public virtual tbl_BRA_Branch tbl_BRA_Branch1 { get; set; }
        //List 0:1
        public virtual tbl_BRA_Branch tbl_BRA_Branch2 { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tbl_CRM_Campaign> tbl_CRM_Campaign { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tbl_CRM_Contact> tbl_CRM_Contact { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tbl_CRM_Lead> tbl_CRM_Lead { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tbl_CRM_Route> tbl_CRM_Route { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tbl_CRM_Route> tbl_CRM_Route1 { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tbl_HRM_DeductionOnSalary> tbl_HRM_DeductionOnSalary { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tbl_HRM_PayrollPaySheetMaster> tbl_HRM_PayrollPaySheetMaster { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tbl_HRM_PersonalIncomePaymentProcess> tbl_HRM_PersonalIncomePaymentProcess { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tbl_HRM_PolWelfare> tbl_HRM_PolWelfare { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tbl_HRM_StaffLaborContract> tbl_HRM_StaffLaborContract { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tbl_HRM_StaffAllowance> tbl_HRM_StaffAllowance { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tbl_HRM_StaffResignationInfo> tbl_HRM_StaffResignationInfo { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tbl_HRM_StaffSalaryDecision> tbl_HRM_StaffSalaryDecision { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tbl_HRM_StaffWelfare> tbl_HRM_StaffWelfare { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tbl_HRM_StaffCurrentWorking> tbl_HRM_StaffCurrentWorking { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tbl_HRM_StaffCurrentWorking> tbl_HRM_StaffCurrentWorking1 { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tbl_HRM_StaffRecruitmentInfo> tbl_HRM_StaffRecruitmentInfo { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tbl_HRM_StaffFamily> tbl_HRM_StaffFamily { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tbl_HRM_StaffAllowance> tbl_HRM_StaffAllowance1 { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tbl_HRM_StaffAnotherSkill> tbl_HRM_StaffAnotherSkill { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tbl_HRM_StaffAppointDecision> tbl_HRM_StaffAppointDecision { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tbl_HRM_StaffBank> tbl_HRM_StaffBank { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tbl_HRM_StaffBounusOnSalary> tbl_HRM_StaffBounusOnSalary { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tbl_HRM_StaffConcurrentPosition> tbl_HRM_StaffConcurrentPosition { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tbl_HRM_StaffConcurrentProbationryPosition> tbl_HRM_StaffConcurrentProbationryPosition { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tbl_HRM_StaffForeignLanguage> tbl_HRM_StaffForeignLanguage { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tbl_HRM_StaffInsurancePaymentProcess> tbl_HRM_StaffInsurancePaymentProcess { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tbl_HRM_StaffInternetAccount> tbl_HRM_StaffInternetAccount { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tbl_HRM_StaffLaborContract> tbl_HRM_StaffLaborContract1 { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tbl_HRM_StaffLearningProcess> tbl_HRM_StaffLearningProcess { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tbl_HRM_StaffPhone> tbl_HRM_StaffPhone { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tbl_HRM_StaffResignationInfo> tbl_HRM_StaffResignationInfo1 { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tbl_HRM_StaffSalaryDecision> tbl_HRM_StaffSalaryDecision1 { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tbl_HRM_StaffSpecializedField> tbl_HRM_StaffSpecializedField { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tbl_HRM_StaffSpecializedSkill> tbl_HRM_StaffSpecializedSkill { get; set; }
        //List 0:1
        public virtual tbl_HRM_StaffAcademicLevel tbl_HRM_StaffAcademicLevel { get; set; }
        //List 0:1
        public virtual tbl_HRM_StaffAddress tbl_HRM_StaffAddress { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tbl_HRM_StaffStaffAndFamilyJob> tbl_HRM_StaffStaffAndFamilyJob { get; set; }
        //List 0:1
        public virtual tbl_HRM_StaffBasicInfo tbl_HRM_StaffBasicInfo { get; set; }
        //List 0:1
        public virtual tbl_HRM_StaffCompulsoryInsurance tbl_HRM_StaffCompulsoryInsurance { get; set; }
        //List 0:1
        public virtual tbl_HRM_StaffCurrentWorking tbl_HRM_StaffCurrentWorking2 { get; set; }
        //List 0:1
        public virtual tbl_HRM_StaffIdentityCardAndPIT tbl_HRM_StaffIdentityCardAndPIT { get; set; }
        //List 0:1
        public virtual tbl_HRM_StaffRecruitmentInfo tbl_HRM_StaffRecruitmentInfo1 { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tbl_HRM_StaffWelfare> tbl_HRM_StaffWelfare1 { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tbl_HRM_StaffWorkExperience> tbl_HRM_StaffWorkExperience { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tbl_HRM_StaffWorkingDiary> tbl_HRM_StaffWorkingDiary { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tbl_HRM_Staff_ConcurrentPosition> tbl_HRM_Staff_ConcurrentPosition { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tbl_HRM_TimeSheetLog> tbl_HRM_TimeSheetLog { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tbl_SALE_Order> tbl_SALE_Order { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tbl_SHIFT_TimeSheet> tbl_SHIFT_TimeSheet { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tbl_SHIP_Shipment> tbl_SHIP_Shipment { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tbl_SHIP_Vehicle> tbl_SHIP_Vehicle { get; set; }
    }
}


namespace DTOModel
{
	using System;
	public partial class DTO_HRM_Staff
	{
		public Nullable<int> IDBranch { get; set; }
		public Nullable<int> IDDepartment { get; set; }
		public Nullable<int> IDJobTitle { get; set; }
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
		public string Title { get; set; }
		public string FirstName { get; set; }
		public string LastName { get; set; }
		public string FullName { get; set; }
		public string ShortName { get; set; }
		public Nullable<bool> Gender { get; set; }
		public string DOB { get; set; }
		public string IdentityCardNumber { get; set; }
		public string Domicile { get; set; }
		public Nullable<System.DateTime> DateOfIssueID { get; set; }
		public string IssuedBy { get; set; }
		public string PhoneNumber { get; set; }
		public string Email { get; set; }
		public string Address { get; set; }
		public string BackgroundColor { get; set; }
		public string ImageURL { get; set; }
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

    public static partial class BS_HRM_Staff 
    {
        public static dynamic getSearch(AppEntities db, int IDBranch, int StaffID, Dictionary<string, string> QueryStrings)
        {
            return get(db, IDBranch,StaffID, QueryStrings);
        }

		public static IQueryable<DTO_HRM_Staff> get(AppEntities db, int IDBranch, int StaffID, Dictionary<string, string> QueryStrings)
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
            package.Workbook.Properties.Title = "ART-DMS HRM_Staff";
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
                //var BRA_Branch2List = BS_BRA_Branch.get(db,IDBranch, StaffID,QueryStrings).Select(s => new ItemModel { Id = s.Id, Name = s.Name });
                //var HRM_StaffAcademicLevelList = BS_HRM_StaffAcademicLevel.get(db,IDBranch, StaffID,QueryStrings).Select(s => new ItemModel { Id = s.Id, Name = s.Name });
                //var HRM_StaffAddressList = BS_HRM_StaffAddress.get(db,IDBranch, StaffID,QueryStrings).Select(s => new ItemModel { Id = s.Id, Name = s.Name });
                //var HRM_StaffBasicInfoList = BS_HRM_StaffBasicInfo.get(db,IDBranch, StaffID,QueryStrings).Select(s => new ItemModel { Id = s.Id, Name = s.Name });
                //var HRM_StaffCompulsoryInsuranceList = BS_HRM_StaffCompulsoryInsurance.get(db,IDBranch, StaffID,QueryStrings).Select(s => new ItemModel { Id = s.Id, Name = s.Name });
                //var HRM_StaffCurrentWorking2List = BS_HRM_StaffCurrentWorking.get(db,IDBranch, StaffID,QueryStrings).Select(s => new ItemModel { Id = s.Id, Name = s.Name });
                //var HRM_StaffIdentityCardAndPITList = BS_HRM_StaffIdentityCardAndPIT.get(db,IDBranch, StaffID,QueryStrings).Select(s => new ItemModel { Id = s.Id, Name = s.Name });
                //var HRM_StaffRecruitmentInfo1List = BS_HRM_StaffRecruitmentInfo.get(db,IDBranch, StaffID,QueryStrings).Select(s => new ItemModel { Id = s.Id, Name = s.Name });
                 

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

		public static DTO_HRM_Staff getAnItem(AppEntities db, int IDBranch, int StaffID, int id)
        {
            var dbResult = db.tbl_HRM_Staff.Find(id);

			//if (dbResult == null || (IDBranch != 0 && dbResult.IDBranch != IDBranch))
			//	return null; 
			//else 
				return toDTO(dbResult);
			
        }
		
		public static DTO_HRM_Staff getAnItemByCode(AppEntities db, int IDBranch, int StaffID, string code)
        {
            var dbResult = db.tbl_HRM_Staff
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
            var dbitem = db.tbl_HRM_Staff.Find(Id);
            
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
					errorLog.logMessage("put_HRM_Staff",e);
                    result = false;
                }
            }
            else
                if (QueryStrings.Any(d => d.Key == "ForceCreate"))
                    result =  post(db, IDBranch, StaffID, item, Username) != null;
                
            return result;
        }

        public static void patchDynamicToDB(dynamic item, tbl_HRM_Staff dbitem, string Username)
        {
            Type type = typeof(tbl_HRM_Staff);
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

        public static void patchDTOtoDBValue( DTO_HRM_Staff item, tbl_HRM_Staff dbitem)
        {
            if (item == null){
                dbitem = null;
                return;
            }
            							
			dbitem.IDBranch = item.IDBranch;							
			dbitem.IDDepartment = item.IDDepartment;							
			dbitem.IDJobTitle = item.IDJobTitle;							
			dbitem.Code = item.Code;							
			dbitem.Name = item.Name;							
			dbitem.Remark = item.Remark;							
			dbitem.Sort = item.Sort;							
			dbitem.IsDisabled = item.IsDisabled;							
			dbitem.IsDeleted = item.IsDeleted;							
			dbitem.Title = item.Title;							
			dbitem.FirstName = item.FirstName;							
			dbitem.LastName = item.LastName;							
			dbitem.FullName = item.FullName;							
			dbitem.ShortName = item.ShortName;							
			dbitem.Gender = item.Gender;							
			dbitem.DOB = item.DOB;							
			dbitem.IdentityCardNumber = item.IdentityCardNumber;							
			dbitem.Domicile = item.Domicile;							
			dbitem.DateOfIssueID = item.DateOfIssueID;							
			dbitem.IssuedBy = item.IssuedBy;							
			dbitem.PhoneNumber = item.PhoneNumber;							
			dbitem.Email = item.Email;							
			dbitem.Address = item.Address;							
			dbitem.BackgroundColor = item.BackgroundColor;							
			dbitem.ImageURL = item.ImageURL;        }

		public static DTO_HRM_Staff post(AppEntities db, int IDBranch, int StaffID, dynamic item, string Username)
        {
            tbl_HRM_Staff dbitem = new tbl_HRM_Staff();
            if (item != null)
            {
                patchDynamicToDB(item, dbitem, Username);
                
				dbitem.CreatedBy = Username;
				dbitem.CreatedDate = DateTime.Now;				
                try
                {
					db.tbl_HRM_Staff.Add(dbitem);
                    db.SaveChanges();
				
                }
                catch (DbEntityValidationException e)
                {
					errorLog.logMessage("post_HRM_Staff",e);
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
                Type type = Type.GetType("BaseBusiness.BS_HRM_Staff, ClassLibrary");
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
                        var target = new tbl_HRM_Staff();
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
                    
                    tbl_HRM_Staff dbitem = new tbl_HRM_Staff();
                    if (it.Id == null || string.IsNullOrEmpty(it.Id.Value) || it.Id == "0")
                    {
                        dbitem = new tbl_HRM_Staff();
                        dbitem.CreatedBy = Username;
				        dbitem.CreatedDate = DateTime.Now;
                                            }
                    else
                    {
                        dbitem = db.tbl_HRM_Staff.Find((int)it.Id);
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
                        
                        if (dbitem.Id == 0) db.tbl_HRM_Staff.Add(dbitem);
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
                    errorLog.logMessage("post_HRM_Staff",e);
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

            var dbitems = db.tbl_HRM_Staff.Where(d => IDs.Contains(d.Id));
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
                    BS_Version.update_Version(db, IDBranch, "DTO_HRM_Staff", updateDate, Username);
                }
			
            }
            catch (DbEntityValidationException e)
            {
				errorLog.logMessage("delete_HRM_Staff",e);
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

			
            var dbitems = db.tbl_HRM_Staff.Where(d => IDs.Contains(d.Id));
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
                    BS_Version.update_Version(db, IDBranch, "DTO_HRM_Staff", updateDate, Username);
                }
			
            }
            catch (DbEntityValidationException e)
            {
				errorLog.logMessage("disable_HRM_Staff",e);
                result = false;
            }
            
            return result;
        }

		
		//---//
		public static bool check_Exists(AppEntities db, int id)
		{
             
            return db.tbl_HRM_Staff.Any(e => e.Id == id && e.IsDeleted == false);
            
		}
		
		public static bool check_Exists(AppEntities db, string Code)
		{
             
            return db.tbl_HRM_Staff.Any(e => e.Code == Code && e.IsDeleted == false);
            
		}
		
		//---//
		public static IQueryable<DTO_HRM_Staff> toDTO(IQueryable<tbl_HRM_Staff> query)
        {
			return query
			.Select(s => new DTO_HRM_Staff(){							
				IDBranch = s.IDBranch,							
				IDDepartment = s.IDDepartment,							
				IDJobTitle = s.IDJobTitle,							
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
				Title = s.Title,							
				FirstName = s.FirstName,							
				LastName = s.LastName,							
				FullName = s.FullName,							
				ShortName = s.ShortName,							
				Gender = s.Gender,							
				DOB = s.DOB,							
				IdentityCardNumber = s.IdentityCardNumber,							
				Domicile = s.Domicile,							
				DateOfIssueID = s.DateOfIssueID,							
				IssuedBy = s.IssuedBy,							
				PhoneNumber = s.PhoneNumber,							
				Email = s.Email,							
				Address = s.Address,							
				BackgroundColor = s.BackgroundColor,							
				ImageURL = s.ImageURL,					
			});//.OrderBy(o => o.Sort == null).ThenBy(u => u.Sort);
                              
        }

		public static DTO_HRM_Staff toDTO(tbl_HRM_Staff dbResult)
        {
			if (dbResult != null)
			{
				return new DTO_HRM_Staff()
				{							
					IDBranch = dbResult.IDBranch,							
					IDDepartment = dbResult.IDDepartment,							
					IDJobTitle = dbResult.IDJobTitle,							
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
					Title = dbResult.Title,							
					FirstName = dbResult.FirstName,							
					LastName = dbResult.LastName,							
					FullName = dbResult.FullName,							
					ShortName = dbResult.ShortName,							
					Gender = dbResult.Gender,							
					DOB = dbResult.DOB,							
					IdentityCardNumber = dbResult.IdentityCardNumber,							
					Domicile = dbResult.Domicile,							
					DateOfIssueID = dbResult.DateOfIssueID,							
					IssuedBy = dbResult.IssuedBy,							
					PhoneNumber = dbResult.PhoneNumber,							
					Email = dbResult.Email,							
					Address = dbResult.Address,							
					BackgroundColor = dbResult.BackgroundColor,							
					ImageURL = dbResult.ImageURL,
				};
			}
			else
				return null; 
        }

		public static IQueryable<tbl_HRM_Staff> _queryBuilder(AppEntities db, int IDBranch, int StaffID, Dictionary<string, string> QueryStrings)
        {
            
			IQueryable<tbl_HRM_Staff> query = db.tbl_HRM_Staff.AsNoTracking();//.Where(d => d.IsDeleted == false);
			

			//Query keyword
			if (QueryStrings.Any(d => d.Key == "Keyword") && !string.IsNullOrEmpty(QueryStrings.FirstOrDefault(d => d.Key == "Keyword").Value))
            {
                var keyword = QueryStrings.FirstOrDefault(d => d.Key == "Keyword").Value;
                query = query.Where(d=>d.Name.Contains(keyword) || d.Code.Contains(keyword));
            }



			//Query IDBranch (Nullable<int>)
			if (QueryStrings.Any(d => d.Key == "IDBranch"))
            {
                var IDList = QueryStrings.FirstOrDefault(d => d.Key == "IDBranch").Value.Replace("[", "").Replace("]", "").Split(',');
                List<int?> IDs = new List<int?>();
                foreach (var item in IDList)
                    if (int.TryParse(item, out int i))
                        IDs.Add(i);
					else if (item == "null")
						IDs.Add(null);
                if (IDs.Count > 0)
                    query = query.Where(d => IDs.Contains(d.IDBranch));
////                    query = query.Where(d => d.IDBranch == null || IDs.Contains(d.IDBranch));
//                    
            }

			//Query IDDepartment (Nullable<int>)
			if (QueryStrings.Any(d => d.Key == "IDDepartment"))
            {
                var IDList = QueryStrings.FirstOrDefault(d => d.Key == "IDDepartment").Value.Replace("[", "").Replace("]", "").Split(',');
                List<int?> IDs = new List<int?>();
                foreach (var item in IDList)
                    if (int.TryParse(item, out int i))
                        IDs.Add(i);
					else if (item == "null")
						IDs.Add(null);
                if (IDs.Count > 0)
                    query = query.Where(d => IDs.Contains(d.IDDepartment));
////                    query = query.Where(d => IDs.Contains(d.IDDepartment));
//                    
            }

			//Query IDJobTitle (Nullable<int>)
			if (QueryStrings.Any(d => d.Key == "IDJobTitle"))
            {
                var IDList = QueryStrings.FirstOrDefault(d => d.Key == "IDJobTitle").Value.Replace("[", "").Replace("]", "").Split(',');
                List<int?> IDs = new List<int?>();
                foreach (var item in IDList)
                    if (int.TryParse(item, out int i))
                        IDs.Add(i);
					else if (item == "null")
						IDs.Add(null);
                if (IDs.Count > 0)
                    query = query.Where(d => IDs.Contains(d.IDJobTitle));
////                    query = query.Where(d => IDs.Contains(d.IDJobTitle));
//                    
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


			//Query Title (string)
			if (QueryStrings.Any(d => d.Key == "Title_eq") && !string.IsNullOrEmpty(QueryStrings.FirstOrDefault(d => d.Key == "Title_eq").Value))
            {
                var keyword = QueryStrings.FirstOrDefault(d => d.Key == "Title_eq").Value;
                query = query.Where(d=>d.Title == keyword);
            }
            if (QueryStrings.Any(d => d.Key == "Title") && !string.IsNullOrEmpty(QueryStrings.FirstOrDefault(d => d.Key == "Title").Value))
            {
                var keyword = QueryStrings.FirstOrDefault(d => d.Key == "Title").Value;
                query = query.Where(d=>d.Title.Contains(keyword));
            }
            

			//Query FirstName (string)
			if (QueryStrings.Any(d => d.Key == "FirstName_eq") && !string.IsNullOrEmpty(QueryStrings.FirstOrDefault(d => d.Key == "FirstName_eq").Value))
            {
                var keyword = QueryStrings.FirstOrDefault(d => d.Key == "FirstName_eq").Value;
                query = query.Where(d=>d.FirstName == keyword);
            }
            if (QueryStrings.Any(d => d.Key == "FirstName") && !string.IsNullOrEmpty(QueryStrings.FirstOrDefault(d => d.Key == "FirstName").Value))
            {
                var keyword = QueryStrings.FirstOrDefault(d => d.Key == "FirstName").Value;
                query = query.Where(d=>d.FirstName.Contains(keyword));
            }
            

			//Query LastName (string)
			if (QueryStrings.Any(d => d.Key == "LastName_eq") && !string.IsNullOrEmpty(QueryStrings.FirstOrDefault(d => d.Key == "LastName_eq").Value))
            {
                var keyword = QueryStrings.FirstOrDefault(d => d.Key == "LastName_eq").Value;
                query = query.Where(d=>d.LastName == keyword);
            }
            if (QueryStrings.Any(d => d.Key == "LastName") && !string.IsNullOrEmpty(QueryStrings.FirstOrDefault(d => d.Key == "LastName").Value))
            {
                var keyword = QueryStrings.FirstOrDefault(d => d.Key == "LastName").Value;
                query = query.Where(d=>d.LastName.Contains(keyword));
            }
            

			//Query FullName (string)
			if (QueryStrings.Any(d => d.Key == "FullName_eq") && !string.IsNullOrEmpty(QueryStrings.FirstOrDefault(d => d.Key == "FullName_eq").Value))
            {
                var keyword = QueryStrings.FirstOrDefault(d => d.Key == "FullName_eq").Value;
                query = query.Where(d=>d.FullName == keyword);
            }
            if (QueryStrings.Any(d => d.Key == "FullName") && !string.IsNullOrEmpty(QueryStrings.FirstOrDefault(d => d.Key == "FullName").Value))
            {
                var keyword = QueryStrings.FirstOrDefault(d => d.Key == "FullName").Value;
                query = query.Where(d=>d.FullName.Contains(keyword));
            }
            

			//Query ShortName (string)
			if (QueryStrings.Any(d => d.Key == "ShortName_eq") && !string.IsNullOrEmpty(QueryStrings.FirstOrDefault(d => d.Key == "ShortName_eq").Value))
            {
                var keyword = QueryStrings.FirstOrDefault(d => d.Key == "ShortName_eq").Value;
                query = query.Where(d=>d.ShortName == keyword);
            }
            if (QueryStrings.Any(d => d.Key == "ShortName") && !string.IsNullOrEmpty(QueryStrings.FirstOrDefault(d => d.Key == "ShortName").Value))
            {
                var keyword = QueryStrings.FirstOrDefault(d => d.Key == "ShortName").Value;
                query = query.Where(d=>d.ShortName.Contains(keyword));
            }
            

			//Query Gender (Nullable<bool>)

			//Query DOB (string)
			if (QueryStrings.Any(d => d.Key == "DOB_eq") && !string.IsNullOrEmpty(QueryStrings.FirstOrDefault(d => d.Key == "DOB_eq").Value))
            {
                var keyword = QueryStrings.FirstOrDefault(d => d.Key == "DOB_eq").Value;
                query = query.Where(d=>d.DOB == keyword);
            }
            if (QueryStrings.Any(d => d.Key == "DOB") && !string.IsNullOrEmpty(QueryStrings.FirstOrDefault(d => d.Key == "DOB").Value))
            {
                var keyword = QueryStrings.FirstOrDefault(d => d.Key == "DOB").Value;
                query = query.Where(d=>d.DOB.Contains(keyword));
            }
            

			//Query IdentityCardNumber (string)
			if (QueryStrings.Any(d => d.Key == "IdentityCardNumber_eq") && !string.IsNullOrEmpty(QueryStrings.FirstOrDefault(d => d.Key == "IdentityCardNumber_eq").Value))
            {
                var keyword = QueryStrings.FirstOrDefault(d => d.Key == "IdentityCardNumber_eq").Value;
                query = query.Where(d=>d.IdentityCardNumber == keyword);
            }
            if (QueryStrings.Any(d => d.Key == "IdentityCardNumber") && !string.IsNullOrEmpty(QueryStrings.FirstOrDefault(d => d.Key == "IdentityCardNumber").Value))
            {
                var keyword = QueryStrings.FirstOrDefault(d => d.Key == "IdentityCardNumber").Value;
                query = query.Where(d=>d.IdentityCardNumber.Contains(keyword));
            }
            

			//Query Domicile (string)
			if (QueryStrings.Any(d => d.Key == "Domicile_eq") && !string.IsNullOrEmpty(QueryStrings.FirstOrDefault(d => d.Key == "Domicile_eq").Value))
            {
                var keyword = QueryStrings.FirstOrDefault(d => d.Key == "Domicile_eq").Value;
                query = query.Where(d=>d.Domicile == keyword);
            }
            if (QueryStrings.Any(d => d.Key == "Domicile") && !string.IsNullOrEmpty(QueryStrings.FirstOrDefault(d => d.Key == "Domicile").Value))
            {
                var keyword = QueryStrings.FirstOrDefault(d => d.Key == "Domicile").Value;
                query = query.Where(d=>d.Domicile.Contains(keyword));
            }
            

			//Query DateOfIssueID (Nullable<System.DateTime>)
			if (QueryStrings.Any(d => d.Key == "DateOfIssueIDFrom") && QueryStrings.Any(d => d.Key == "DateOfIssueIDTo"))
                if (DateTime.TryParse(QueryStrings.FirstOrDefault(d => d.Key == "DateOfIssueIDFrom").Value, out DateTime fromDate) && DateTime.TryParse(QueryStrings.FirstOrDefault(d => d.Key == "DateOfIssueIDTo").Value, out DateTime toDate))
                    query = query.Where(d => fromDate <= d.DateOfIssueID && d.DateOfIssueID <= toDate);

            if (QueryStrings.Any(d => d.Key == "DateOfIssueID"))
                if (DateTime.TryParse(QueryStrings.FirstOrDefault(d => d.Key == "DateOfIssueID").Value, out DateTime val))
                    query = query.Where(d => d.DateOfIssueID != null && DbFunctions.TruncateTime(val) == DbFunctions.TruncateTime(d.DateOfIssueID));


			//Query IssuedBy (string)
			if (QueryStrings.Any(d => d.Key == "IssuedBy_eq") && !string.IsNullOrEmpty(QueryStrings.FirstOrDefault(d => d.Key == "IssuedBy_eq").Value))
            {
                var keyword = QueryStrings.FirstOrDefault(d => d.Key == "IssuedBy_eq").Value;
                query = query.Where(d=>d.IssuedBy == keyword);
            }
            if (QueryStrings.Any(d => d.Key == "IssuedBy") && !string.IsNullOrEmpty(QueryStrings.FirstOrDefault(d => d.Key == "IssuedBy").Value))
            {
                var keyword = QueryStrings.FirstOrDefault(d => d.Key == "IssuedBy").Value;
                query = query.Where(d=>d.IssuedBy.Contains(keyword));
            }
            

			//Query PhoneNumber (string)
			if (QueryStrings.Any(d => d.Key == "PhoneNumber_eq") && !string.IsNullOrEmpty(QueryStrings.FirstOrDefault(d => d.Key == "PhoneNumber_eq").Value))
            {
                var keyword = QueryStrings.FirstOrDefault(d => d.Key == "PhoneNumber_eq").Value;
                query = query.Where(d=>d.PhoneNumber == keyword);
            }
            if (QueryStrings.Any(d => d.Key == "PhoneNumber") && !string.IsNullOrEmpty(QueryStrings.FirstOrDefault(d => d.Key == "PhoneNumber").Value))
            {
                var keyword = QueryStrings.FirstOrDefault(d => d.Key == "PhoneNumber").Value;
                query = query.Where(d=>d.PhoneNumber.Contains(keyword));
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
            

			//Query Address (string)
			if (QueryStrings.Any(d => d.Key == "Address_eq") && !string.IsNullOrEmpty(QueryStrings.FirstOrDefault(d => d.Key == "Address_eq").Value))
            {
                var keyword = QueryStrings.FirstOrDefault(d => d.Key == "Address_eq").Value;
                query = query.Where(d=>d.Address == keyword);
            }
            if (QueryStrings.Any(d => d.Key == "Address") && !string.IsNullOrEmpty(QueryStrings.FirstOrDefault(d => d.Key == "Address").Value))
            {
                var keyword = QueryStrings.FirstOrDefault(d => d.Key == "Address").Value;
                query = query.Where(d=>d.Address.Contains(keyword));
            }
            

			//Query BackgroundColor (string)
			if (QueryStrings.Any(d => d.Key == "BackgroundColor_eq") && !string.IsNullOrEmpty(QueryStrings.FirstOrDefault(d => d.Key == "BackgroundColor_eq").Value))
            {
                var keyword = QueryStrings.FirstOrDefault(d => d.Key == "BackgroundColor_eq").Value;
                query = query.Where(d=>d.BackgroundColor == keyword);
            }
            if (QueryStrings.Any(d => d.Key == "BackgroundColor") && !string.IsNullOrEmpty(QueryStrings.FirstOrDefault(d => d.Key == "BackgroundColor").Value))
            {
                var keyword = QueryStrings.FirstOrDefault(d => d.Key == "BackgroundColor").Value;
                query = query.Where(d=>d.BackgroundColor.Contains(keyword));
            }
            

			//Query ImageURL (string)
			if (QueryStrings.Any(d => d.Key == "ImageURL_eq") && !string.IsNullOrEmpty(QueryStrings.FirstOrDefault(d => d.Key == "ImageURL_eq").Value))
            {
                var keyword = QueryStrings.FirstOrDefault(d => d.Key == "ImageURL_eq").Value;
                query = query.Where(d=>d.ImageURL == keyword);
            }
            if (QueryStrings.Any(d => d.Key == "ImageURL") && !string.IsNullOrEmpty(QueryStrings.FirstOrDefault(d => d.Key == "ImageURL").Value))
            {
                var keyword = QueryStrings.FirstOrDefault(d => d.Key == "ImageURL").Value;
                query = query.Where(d=>d.ImageURL.Contains(keyword));
            }
            
            return query;
        }
		
        public static IQueryable<tbl_HRM_Staff> _sortBuilder(IQueryable<tbl_HRM_Staff> query, Dictionary<string, string> QueryStrings)
        {
            if (QueryStrings.Any(d => d.Key == "SortBy"))
            {
                var sorts = QueryStrings.FirstOrDefault(d => d.Key == "SortBy").Value.Replace("[", "").Replace("]", "").Split(',');
                
                foreach (var item in sorts)
                    if (!string.IsNullOrEmpty(item))
                    {
                        var ordered = query as IOrderedQueryable<tbl_HRM_Staff>;
                        bool isOrdered = ordered.ToString().IndexOf("ORDER BY") !=-1;

                        switch (item)
                        {
							case "IDBranch":
								query = isOrdered ? ordered.ThenBy(o => o.IDBranch) : query.OrderBy(o => o.IDBranch);
								 break;
							case "IDBranch_desc":
                                query = isOrdered ? ordered.ThenByDescending(o => o.IDBranch) : query.OrderByDescending(o => o.IDBranch);
                                break;
							case "IDDepartment":
								query = isOrdered ? ordered.ThenBy(o => o.IDDepartment) : query.OrderBy(o => o.IDDepartment);
								 break;
							case "IDDepartment_desc":
                                query = isOrdered ? ordered.ThenByDescending(o => o.IDDepartment) : query.OrderByDescending(o => o.IDDepartment);
                                break;
							case "IDJobTitle":
								query = isOrdered ? ordered.ThenBy(o => o.IDJobTitle) : query.OrderBy(o => o.IDJobTitle);
								 break;
							case "IDJobTitle_desc":
                                query = isOrdered ? ordered.ThenByDescending(o => o.IDJobTitle) : query.OrderByDescending(o => o.IDJobTitle);
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
							case "Title":
								query = isOrdered ? ordered.ThenBy(o => o.Title) : query.OrderBy(o => o.Title);
								 break;
							case "Title_desc":
                                query = isOrdered ? ordered.ThenByDescending(o => o.Title) : query.OrderByDescending(o => o.Title);
                                break;
							case "FirstName":
								query = isOrdered ? ordered.ThenBy(o => o.FirstName) : query.OrderBy(o => o.FirstName);
								 break;
							case "FirstName_desc":
                                query = isOrdered ? ordered.ThenByDescending(o => o.FirstName) : query.OrderByDescending(o => o.FirstName);
                                break;
							case "LastName":
								query = isOrdered ? ordered.ThenBy(o => o.LastName) : query.OrderBy(o => o.LastName);
								 break;
							case "LastName_desc":
                                query = isOrdered ? ordered.ThenByDescending(o => o.LastName) : query.OrderByDescending(o => o.LastName);
                                break;
							case "FullName":
								query = isOrdered ? ordered.ThenBy(o => o.FullName) : query.OrderBy(o => o.FullName);
								 break;
							case "FullName_desc":
                                query = isOrdered ? ordered.ThenByDescending(o => o.FullName) : query.OrderByDescending(o => o.FullName);
                                break;
							case "ShortName":
								query = isOrdered ? ordered.ThenBy(o => o.ShortName) : query.OrderBy(o => o.ShortName);
								 break;
							case "ShortName_desc":
                                query = isOrdered ? ordered.ThenByDescending(o => o.ShortName) : query.OrderByDescending(o => o.ShortName);
                                break;
							case "Gender":
								query = isOrdered ? ordered.ThenBy(o => o.Gender) : query.OrderBy(o => o.Gender);
								 break;
							case "Gender_desc":
                                query = isOrdered ? ordered.ThenByDescending(o => o.Gender) : query.OrderByDescending(o => o.Gender);
                                break;
							case "DOB":
								query = isOrdered ? ordered.ThenBy(o => o.DOB) : query.OrderBy(o => o.DOB);
								 break;
							case "DOB_desc":
                                query = isOrdered ? ordered.ThenByDescending(o => o.DOB) : query.OrderByDescending(o => o.DOB);
                                break;
							case "IdentityCardNumber":
								query = isOrdered ? ordered.ThenBy(o => o.IdentityCardNumber) : query.OrderBy(o => o.IdentityCardNumber);
								 break;
							case "IdentityCardNumber_desc":
                                query = isOrdered ? ordered.ThenByDescending(o => o.IdentityCardNumber) : query.OrderByDescending(o => o.IdentityCardNumber);
                                break;
							case "Domicile":
								query = isOrdered ? ordered.ThenBy(o => o.Domicile) : query.OrderBy(o => o.Domicile);
								 break;
							case "Domicile_desc":
                                query = isOrdered ? ordered.ThenByDescending(o => o.Domicile) : query.OrderByDescending(o => o.Domicile);
                                break;
							case "DateOfIssueID":
								query = isOrdered ? ordered.ThenBy(o => o.DateOfIssueID) : query.OrderBy(o => o.DateOfIssueID);
								 break;
							case "DateOfIssueID_desc":
                                query = isOrdered ? ordered.ThenByDescending(o => o.DateOfIssueID) : query.OrderByDescending(o => o.DateOfIssueID);
                                break;
							case "IssuedBy":
								query = isOrdered ? ordered.ThenBy(o => o.IssuedBy) : query.OrderBy(o => o.IssuedBy);
								 break;
							case "IssuedBy_desc":
                                query = isOrdered ? ordered.ThenByDescending(o => o.IssuedBy) : query.OrderByDescending(o => o.IssuedBy);
                                break;
							case "PhoneNumber":
								query = isOrdered ? ordered.ThenBy(o => o.PhoneNumber) : query.OrderBy(o => o.PhoneNumber);
								 break;
							case "PhoneNumber_desc":
                                query = isOrdered ? ordered.ThenByDescending(o => o.PhoneNumber) : query.OrderByDescending(o => o.PhoneNumber);
                                break;
							case "Email":
								query = isOrdered ? ordered.ThenBy(o => o.Email) : query.OrderBy(o => o.Email);
								 break;
							case "Email_desc":
                                query = isOrdered ? ordered.ThenByDescending(o => o.Email) : query.OrderByDescending(o => o.Email);
                                break;
							case "Address":
								query = isOrdered ? ordered.ThenBy(o => o.Address) : query.OrderBy(o => o.Address);
								 break;
							case "Address_desc":
                                query = isOrdered ? ordered.ThenByDescending(o => o.Address) : query.OrderByDescending(o => o.Address);
                                break;
							case "BackgroundColor":
								query = isOrdered ? ordered.ThenBy(o => o.BackgroundColor) : query.OrderBy(o => o.BackgroundColor);
								 break;
							case "BackgroundColor_desc":
                                query = isOrdered ? ordered.ThenByDescending(o => o.BackgroundColor) : query.OrderByDescending(o => o.BackgroundColor);
                                break;
							case "ImageURL":
								query = isOrdered ? ordered.ThenBy(o => o.ImageURL) : query.OrderBy(o => o.ImageURL);
								 break;
							case "ImageURL_desc":
                                query = isOrdered ? ordered.ThenByDescending(o => o.ImageURL) : query.OrderByDescending(o => o.ImageURL);
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

        public static IQueryable<tbl_HRM_Staff> _pagingBuilder(IQueryable<tbl_HRM_Staff> query, Dictionary<string, string> QueryStrings)
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






