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
    
    
    public partial class tbl_LIST_General
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public tbl_LIST_General()
        {
            this.tbl_HRM_DeductionOnSalary = new HashSet<tbl_HRM_DeductionOnSalary>();
            this.tbl_HRM_PolAllowance = new HashSet<tbl_HRM_PolAllowance>();
            this.tbl_HRM_PolAllowance1 = new HashSet<tbl_HRM_PolAllowance>();
            this.tbl_HRM_PolAllowanceApplyFor = new HashSet<tbl_HRM_PolAllowanceApplyFor>();
            this.tbl_HRM_PolAllowanceApplyFor1 = new HashSet<tbl_HRM_PolAllowanceApplyFor>();
            this.tbl_HRM_PolAllowanceApplyFor2 = new HashSet<tbl_HRM_PolAllowanceApplyFor>();
            this.tbl_HRM_PolCompulsoryInsuranceApplyFor = new HashSet<tbl_HRM_PolCompulsoryInsuranceApplyFor>();
            this.tbl_HRM_PolCompulsoryInsuranceApplyFor1 = new HashSet<tbl_HRM_PolCompulsoryInsuranceApplyFor>();
            this.tbl_HRM_PolCompulsoryInsuranceApplyFor2 = new HashSet<tbl_HRM_PolCompulsoryInsuranceApplyFor>();
            this.tbl_HRM_PolWelfareApplyFor = new HashSet<tbl_HRM_PolWelfareApplyFor>();
            this.tbl_HRM_PolWelfareApplyFor1 = new HashSet<tbl_HRM_PolWelfareApplyFor>();
            this.tbl_HRM_PolWelfareApplyFor2 = new HashSet<tbl_HRM_PolWelfareApplyFor>();
            this.tbl_HRM_StaffAcademicLevel = new HashSet<tbl_HRM_StaffAcademicLevel>();
            this.tbl_HRM_StaffAcademicLevel1 = new HashSet<tbl_HRM_StaffAcademicLevel>();
            this.tbl_HRM_StaffAcademicLevel2 = new HashSet<tbl_HRM_StaffAcademicLevel>();
            this.tbl_HRM_StaffAllowance = new HashSet<tbl_HRM_StaffAllowance>();
            this.tbl_HRM_StaffAnotherSkill = new HashSet<tbl_HRM_StaffAnotherSkill>();
            this.tbl_HRM_StaffAppointDecision = new HashSet<tbl_HRM_StaffAppointDecision>();
            this.tbl_HRM_StaffBank = new HashSet<tbl_HRM_StaffBank>();
            this.tbl_HRM_StaffBank1 = new HashSet<tbl_HRM_StaffBank>();
            this.tbl_HRM_StaffBasicInfo = new HashSet<tbl_HRM_StaffBasicInfo>();
            this.tbl_HRM_StaffBasicInfo1 = new HashSet<tbl_HRM_StaffBasicInfo>();
            this.tbl_HRM_StaffBounusOnSalary = new HashSet<tbl_HRM_StaffBounusOnSalary>();
            this.tbl_HRM_StaffCurrentWorking = new HashSet<tbl_HRM_StaffCurrentWorking>();
            this.tbl_HRM_StaffFamily = new HashSet<tbl_HRM_StaffFamily>();
            this.tbl_HRM_StaffFamily1 = new HashSet<tbl_HRM_StaffFamily>();
            this.tbl_HRM_StaffForeignLanguage = new HashSet<tbl_HRM_StaffForeignLanguage>();
            this.tbl_HRM_StaffForeignLanguage1 = new HashSet<tbl_HRM_StaffForeignLanguage>();
            this.tbl_HRM_StaffForeignLanguage2 = new HashSet<tbl_HRM_StaffForeignLanguage>();
            this.tbl_HRM_StaffForeignLanguage3 = new HashSet<tbl_HRM_StaffForeignLanguage>();
            this.tbl_HRM_StaffForeignLanguage4 = new HashSet<tbl_HRM_StaffForeignLanguage>();
            this.tbl_HRM_StaffForeignLanguage5 = new HashSet<tbl_HRM_StaffForeignLanguage>();
            this.tbl_HRM_StaffIdentityCardAndPIT = new HashSet<tbl_HRM_StaffIdentityCardAndPIT>();
            this.tbl_HRM_StaffLaborContract = new HashSet<tbl_HRM_StaffLaborContract>();
            this.tbl_HRM_StaffLearningProcess = new HashSet<tbl_HRM_StaffLearningProcess>();
            this.tbl_HRM_StaffRecruitmentInfo = new HashSet<tbl_HRM_StaffRecruitmentInfo>();
            this.tbl_HRM_StaffRecruitmentInfo1 = new HashSet<tbl_HRM_StaffRecruitmentInfo>();
            this.tbl_HRM_StaffResignationInfo = new HashSet<tbl_HRM_StaffResignationInfo>();
            this.tbl_HRM_StaffSpecializedField = new HashSet<tbl_HRM_StaffSpecializedField>();
            this.tbl_HRM_StaffSpecializedSkill = new HashSet<tbl_HRM_StaffSpecializedSkill>();
            this.tbl_HRM_StaffStaffAndFamilyJob = new HashSet<tbl_HRM_StaffStaffAndFamilyJob>();
            this.tbl_HRM_StaffTrainingProcessSkill = new HashSet<tbl_HRM_StaffTrainingProcessSkill>();
            this.tbl_HRM_StaffWelfare = new HashSet<tbl_HRM_StaffWelfare>();
            this.tbl_HRM_StaffWorkExperience = new HashSet<tbl_HRM_StaffWorkExperience>();
            this.tbl_HRM_StaffWorkingDiary = new HashSet<tbl_HRM_StaffWorkingDiary>();
            this.tbl_HRM_StaffWorkingDiary1 = new HashSet<tbl_HRM_StaffWorkingDiary>();
        }
    
        public Nullable<int> IDPartner { get; set; }
        public Nullable<int> IDParent { get; set; }
        public int Id { get; set; }
        public string Code { get; set; }
        public string Name { get; set; }
        public string ForeignName { get; set; }
        public string Remark { get; set; }
        public string ForeignRemark { get; set; }
        public string Color { get; set; }
        public Nullable<int> Sort { get; set; }
        public bool IsSysAttrib { get; set; }
        public bool IsDefault { get; set; }
        public bool IsDisabled { get; set; }
        public bool IsDeleted { get; set; }
        public string CreatedBy { get; set; }
        public string ModifiedBy { get; set; }
        public System.DateTime CreatedDate { get; set; }
        public System.DateTime ModifiedDate { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tbl_HRM_DeductionOnSalary> tbl_HRM_DeductionOnSalary { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tbl_HRM_PolAllowance> tbl_HRM_PolAllowance { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tbl_HRM_PolAllowance> tbl_HRM_PolAllowance1 { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tbl_HRM_PolAllowanceApplyFor> tbl_HRM_PolAllowanceApplyFor { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tbl_HRM_PolAllowanceApplyFor> tbl_HRM_PolAllowanceApplyFor1 { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tbl_HRM_PolAllowanceApplyFor> tbl_HRM_PolAllowanceApplyFor2 { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tbl_HRM_PolCompulsoryInsuranceApplyFor> tbl_HRM_PolCompulsoryInsuranceApplyFor { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tbl_HRM_PolCompulsoryInsuranceApplyFor> tbl_HRM_PolCompulsoryInsuranceApplyFor1 { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tbl_HRM_PolCompulsoryInsuranceApplyFor> tbl_HRM_PolCompulsoryInsuranceApplyFor2 { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tbl_HRM_PolWelfareApplyFor> tbl_HRM_PolWelfareApplyFor { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tbl_HRM_PolWelfareApplyFor> tbl_HRM_PolWelfareApplyFor1 { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tbl_HRM_PolWelfareApplyFor> tbl_HRM_PolWelfareApplyFor2 { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tbl_HRM_StaffAcademicLevel> tbl_HRM_StaffAcademicLevel { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tbl_HRM_StaffAcademicLevel> tbl_HRM_StaffAcademicLevel1 { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tbl_HRM_StaffAcademicLevel> tbl_HRM_StaffAcademicLevel2 { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tbl_HRM_StaffAllowance> tbl_HRM_StaffAllowance { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tbl_HRM_StaffAnotherSkill> tbl_HRM_StaffAnotherSkill { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tbl_HRM_StaffAppointDecision> tbl_HRM_StaffAppointDecision { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tbl_HRM_StaffBank> tbl_HRM_StaffBank { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tbl_HRM_StaffBank> tbl_HRM_StaffBank1 { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tbl_HRM_StaffBasicInfo> tbl_HRM_StaffBasicInfo { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tbl_HRM_StaffBasicInfo> tbl_HRM_StaffBasicInfo1 { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tbl_HRM_StaffBounusOnSalary> tbl_HRM_StaffBounusOnSalary { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tbl_HRM_StaffCurrentWorking> tbl_HRM_StaffCurrentWorking { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tbl_HRM_StaffFamily> tbl_HRM_StaffFamily { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tbl_HRM_StaffFamily> tbl_HRM_StaffFamily1 { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tbl_HRM_StaffForeignLanguage> tbl_HRM_StaffForeignLanguage { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tbl_HRM_StaffForeignLanguage> tbl_HRM_StaffForeignLanguage1 { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tbl_HRM_StaffForeignLanguage> tbl_HRM_StaffForeignLanguage2 { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tbl_HRM_StaffForeignLanguage> tbl_HRM_StaffForeignLanguage3 { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tbl_HRM_StaffForeignLanguage> tbl_HRM_StaffForeignLanguage4 { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tbl_HRM_StaffForeignLanguage> tbl_HRM_StaffForeignLanguage5 { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tbl_HRM_StaffIdentityCardAndPIT> tbl_HRM_StaffIdentityCardAndPIT { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tbl_HRM_StaffLaborContract> tbl_HRM_StaffLaborContract { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tbl_HRM_StaffLearningProcess> tbl_HRM_StaffLearningProcess { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tbl_HRM_StaffRecruitmentInfo> tbl_HRM_StaffRecruitmentInfo { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tbl_HRM_StaffRecruitmentInfo> tbl_HRM_StaffRecruitmentInfo1 { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tbl_HRM_StaffResignationInfo> tbl_HRM_StaffResignationInfo { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tbl_HRM_StaffSpecializedField> tbl_HRM_StaffSpecializedField { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tbl_HRM_StaffSpecializedSkill> tbl_HRM_StaffSpecializedSkill { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tbl_HRM_StaffStaffAndFamilyJob> tbl_HRM_StaffStaffAndFamilyJob { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tbl_HRM_StaffTrainingProcessSkill> tbl_HRM_StaffTrainingProcessSkill { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tbl_HRM_StaffWelfare> tbl_HRM_StaffWelfare { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tbl_HRM_StaffWorkExperience> tbl_HRM_StaffWorkExperience { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tbl_HRM_StaffWorkingDiary> tbl_HRM_StaffWorkingDiary { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tbl_HRM_StaffWorkingDiary> tbl_HRM_StaffWorkingDiary1 { get; set; }
    }
}


namespace DTOModel
{
	using System;
	public partial class DTO_LIST_General
	{
		public Nullable<int> IDPartner { get; set; }
		public Nullable<int> IDParent { get; set; }
		public int Id { get; set; }
		public string Code { get; set; }
		public string Name { get; set; }
		public string ForeignName { get; set; }
		public string Remark { get; set; }
		public string ForeignRemark { get; set; }
		public string Color { get; set; }
		public Nullable<int> Sort { get; set; }
		public bool IsSysAttrib { get; set; }
		public bool IsDefault { get; set; }
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

    public static partial class BS_LIST_General 
    {
        public static dynamic getSearch(AppEntities db, int IDBranch, int StaffID, Dictionary<string, string> QueryStrings)
        {
            return get(db, IDBranch,StaffID, QueryStrings);
        }

		public static IQueryable<DTO_LIST_General> get(AppEntities db, int IDBranch, int StaffID, Dictionary<string, string> QueryStrings)
        {
			var query = _queryBuilder(db, IDBranch, StaffID, QueryStrings);

            if (QueryStrings.Any(d => d.Key == "AllChildren")  || QueryStrings.Any(d => d.Key == "AllParent"))
            {

                List<DTO_LIST_General> allItems = db.tbl_LIST_General.Where(d => d.IsDeleted == false).Select(s => new DTO_LIST_General()
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
                    
                    query = db.tbl_LIST_General.Where(d => Ids.Contains(d.Id));
                }

            }

            query = _sortBuilder(query, QueryStrings);
            query = _pagingBuilder(query, QueryStrings);

			return toDTO(query);
        }

        public static List<int> findParent(List<DTO_LIST_General> allItems, int Id)
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

        public static List<int> findChildrent(List<DTO_LIST_General> allItems, int Id)
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
            package.Workbook.Properties.Title = "ART-DMS LIST_General";
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

		public static DTO_LIST_General getAnItem(AppEntities db, int IDBranch, int StaffID, int id)
        {
            var dbResult = db.tbl_LIST_General.Find(id);

			return toDTO(dbResult);
			
        }
		
		public static DTO_LIST_General getAnItemByCode(AppEntities db, int IDBranch, int StaffID, string code)
        {
            var dbResult = db.tbl_LIST_General
			.FirstOrDefault(d => d.IsDeleted == false && d.Code == code );

			return toDTO(dbResult);
			
        }

		public static bool put(AppEntities db, int IDBranch, int StaffID, int Id, dynamic item, string Username, Dictionary<string, string> QueryStrings)
        {
            bool result = false;
            var dbitem = db.tbl_LIST_General.Find(Id);
            
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
					errorLog.logMessage("put_LIST_General",e);
                    result = false;
                }
            }
            else
                if (QueryStrings.Any(d => d.Key == "ForceCreate"))
                    result =  post(db, IDBranch, StaffID, item, Username) != null;
                
            return result;
        }

        public static void patchDynamicToDB(dynamic item, tbl_LIST_General dbitem, string Username)
        {
            Type type = typeof(tbl_LIST_General);
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

        public static void patchDTOtoDBValue( DTO_LIST_General item, tbl_LIST_General dbitem)
        {
            if (item == null){
                dbitem = null;
                return;
            }
            							
			dbitem.IDPartner = item.IDPartner;							
			dbitem.IDParent = item.IDParent;							
			dbitem.Code = item.Code;							
			dbitem.Name = item.Name;							
			dbitem.ForeignName = item.ForeignName;							
			dbitem.Remark = item.Remark;							
			dbitem.ForeignRemark = item.ForeignRemark;							
			dbitem.Color = item.Color;							
			dbitem.Sort = item.Sort;							
			dbitem.IsSysAttrib = item.IsSysAttrib;							
			dbitem.IsDefault = item.IsDefault;							
			dbitem.IsDisabled = item.IsDisabled;							
			dbitem.IsDeleted = item.IsDeleted;        }

		public static DTO_LIST_General post(AppEntities db, int IDBranch, int StaffID, dynamic item, string Username)
        {
            tbl_LIST_General dbitem = new tbl_LIST_General();
            if (item != null)
            {
                patchDynamicToDB(item, dbitem, Username);
                
				dbitem.CreatedBy = Username;
				dbitem.CreatedDate = DateTime.Now;				
                try
                {
					db.tbl_LIST_General.Add(dbitem);
                    db.SaveChanges();
				
                }
                catch (DbEntityValidationException e)
                {
					errorLog.logMessage("post_LIST_General",e);
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
                Type type = Type.GetType("BaseBusiness.BS_LIST_General, ClassLibrary");
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
                        var target = new tbl_LIST_General();
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
                    
                    tbl_LIST_General dbitem = new tbl_LIST_General();
                    if (it.Id == null || string.IsNullOrEmpty(it.Id.Value) || it.Id == "0")
                    {
                        dbitem = new tbl_LIST_General();
                        dbitem.CreatedBy = Username;
				        dbitem.CreatedDate = DateTime.Now;
                                            }
                    else
                    {
                        dbitem = db.tbl_LIST_General.Find((int)it.Id);
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
                        
                        if (dbitem.Id == 0) db.tbl_LIST_General.Add(dbitem);
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
                    errorLog.logMessage("post_LIST_General",e);
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

            var dbitems = db.tbl_LIST_General.Where(d => IDs.Contains(d.Id));
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
			
                BS_Version.update_Version(db, null, "DTO_LIST_General", updateDate, Username);
			
            }
            catch (DbEntityValidationException e)
            {
				errorLog.logMessage("delete_LIST_General",e);
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

			
            var dbitems = db.tbl_LIST_General.Where(d => IDs.Contains(d.Id));
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
			
                BS_Version.update_Version(db, null, "DTO_LIST_General", updateDate, Username);
			
            }
            catch (DbEntityValidationException e)
            {
				errorLog.logMessage("disable_LIST_General",e);
                result = false;
            }
            
            return result;
        }

		
		//---//
		public static bool check_Exists(AppEntities db, int id)
		{
             
            return db.tbl_LIST_General.Any(e => e.Id == id && e.IsDeleted == false);
            
		}
		
		public static bool check_Exists(AppEntities db, string Code)
		{
             
            return db.tbl_LIST_General.Any(e => e.Code == Code && e.IsDeleted == false);
            
		}
		
		//---//
		public static IQueryable<DTO_LIST_General> toDTO(IQueryable<tbl_LIST_General> query)
        {
			return query
			.Select(s => new DTO_LIST_General(){							
				IDPartner = s.IDPartner,							
				IDParent = s.IDParent,							
				Id = s.Id,							
				Code = s.Code,							
				Name = s.Name,							
				ForeignName = s.ForeignName,							
				Remark = s.Remark,							
				ForeignRemark = s.ForeignRemark,							
				Color = s.Color,							
				Sort = s.Sort,							
				IsSysAttrib = s.IsSysAttrib,							
				IsDefault = s.IsDefault,							
				IsDisabled = s.IsDisabled,							
				IsDeleted = s.IsDeleted,							
				CreatedBy = s.CreatedBy,							
				ModifiedBy = s.ModifiedBy,							
				CreatedDate = s.CreatedDate,							
				ModifiedDate = s.ModifiedDate,					
			});//.OrderBy(o => o.Sort == null).ThenBy(u => u.Sort);
                              
        }

		public static DTO_LIST_General toDTO(tbl_LIST_General dbResult)
        {
			if (dbResult != null)
			{
				return new DTO_LIST_General()
				{							
					IDPartner = dbResult.IDPartner,							
					IDParent = dbResult.IDParent,							
					Id = dbResult.Id,							
					Code = dbResult.Code,							
					Name = dbResult.Name,							
					ForeignName = dbResult.ForeignName,							
					Remark = dbResult.Remark,							
					ForeignRemark = dbResult.ForeignRemark,							
					Color = dbResult.Color,							
					Sort = dbResult.Sort,							
					IsSysAttrib = dbResult.IsSysAttrib,							
					IsDefault = dbResult.IsDefault,							
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

		public static IQueryable<tbl_LIST_General> _queryBuilder(AppEntities db, int IDBranch, int StaffID, Dictionary<string, string> QueryStrings)
        {
            
			IQueryable<tbl_LIST_General> query = db.tbl_LIST_General.AsNoTracking();//.Where(d => d.IsDeleted == false );
			

			//Query keyword
			if (QueryStrings.Any(d => d.Key == "Keyword") && !string.IsNullOrEmpty(QueryStrings.FirstOrDefault(d => d.Key == "Keyword").Value))
            {
                var keyword = QueryStrings.FirstOrDefault(d => d.Key == "Keyword").Value;
                query = query.Where(d=>d.Name.Contains(keyword) || d.Code.Contains(keyword));
            }



			//Query IDPartner (Nullable<int>)
			if (QueryStrings.Any(d => d.Key == "IDPartner"))
            {
                var IDList = QueryStrings.FirstOrDefault(d => d.Key == "IDPartner").Value.Replace("[", "").Replace("]", "").Split(',');
                List<int?> IDs = new List<int?>();
                foreach (var item in IDList)
                    if (int.TryParse(item, out int i))
                        IDs.Add(i);
					else if (item == "null")
						IDs.Add(null);
                if (IDs.Count > 0)
                    query = query.Where(d => IDs.Contains(d.IDPartner));
////                    query = query.Where(d => IDs.Contains(d.IDPartner));
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
            

			//Query ForeignName (string)
			if (QueryStrings.Any(d => d.Key == "ForeignName_eq") && !string.IsNullOrEmpty(QueryStrings.FirstOrDefault(d => d.Key == "ForeignName_eq").Value))
            {
                var keyword = QueryStrings.FirstOrDefault(d => d.Key == "ForeignName_eq").Value;
                query = query.Where(d=>d.ForeignName == keyword);
            }
            if (QueryStrings.Any(d => d.Key == "ForeignName") && !string.IsNullOrEmpty(QueryStrings.FirstOrDefault(d => d.Key == "ForeignName").Value))
            {
                var keyword = QueryStrings.FirstOrDefault(d => d.Key == "ForeignName").Value;
                query = query.Where(d=>d.ForeignName.Contains(keyword));
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
            

			//Query Color (string)
			if (QueryStrings.Any(d => d.Key == "Color_eq") && !string.IsNullOrEmpty(QueryStrings.FirstOrDefault(d => d.Key == "Color_eq").Value))
            {
                var keyword = QueryStrings.FirstOrDefault(d => d.Key == "Color_eq").Value;
                query = query.Where(d=>d.Color == keyword);
            }
            if (QueryStrings.Any(d => d.Key == "Color") && !string.IsNullOrEmpty(QueryStrings.FirstOrDefault(d => d.Key == "Color").Value))
            {
                var keyword = QueryStrings.FirstOrDefault(d => d.Key == "Color").Value;
                query = query.Where(d=>d.Color.Contains(keyword));
            }
            

			//Query Sort (Nullable<int>)
			if (QueryStrings.Any(d => d.Key == "SortFrom") && QueryStrings.Any(d => d.Key == "SortTo"))
                if (int.TryParse(QueryStrings.FirstOrDefault(d => d.Key == "SortFrom").Value, out int fromVal) && int.TryParse(QueryStrings.FirstOrDefault(d => d.Key == "SortTo").Value, out int toVal))
                    query = query.Where(d => fromVal <= d.Sort && d.Sort <= toVal);

			//Query IsSysAttrib (bool)
			if (QueryStrings.Any(d => d.Key == "IsSysAttrib"))
            {
                var qValue = QueryStrings.FirstOrDefault(d => d.Key == "IsSysAttrib").Value;
                if (bool.TryParse(qValue, out bool qBoolValue))
                    query = query.Where(d => qBoolValue == d.IsSysAttrib);
            }

			//Query IsDefault (bool)
			if (QueryStrings.Any(d => d.Key == "IsDefault"))
            {
                var qValue = QueryStrings.FirstOrDefault(d => d.Key == "IsDefault").Value;
                if (bool.TryParse(qValue, out bool qBoolValue))
                    query = query.Where(d => qBoolValue == d.IsDefault);
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

            return query;
        }
		
        public static IQueryable<tbl_LIST_General> _sortBuilder(IQueryable<tbl_LIST_General> query, Dictionary<string, string> QueryStrings)
        {
            if (QueryStrings.Any(d => d.Key == "SortBy"))
            {
                var sorts = QueryStrings.FirstOrDefault(d => d.Key == "SortBy").Value.Replace("[", "").Replace("]", "").Split(',');
                
                foreach (var item in sorts)
                    if (!string.IsNullOrEmpty(item))
                    {
                        var ordered = query as IOrderedQueryable<tbl_LIST_General>;
                        bool isOrdered = ordered.ToString().IndexOf("ORDER BY") !=-1;

                        switch (item)
                        {
							case "IDPartner":
								query = isOrdered ? ordered.ThenBy(o => o.IDPartner) : query.OrderBy(o => o.IDPartner);
								 break;
							case "IDPartner_desc":
                                query = isOrdered ? ordered.ThenByDescending(o => o.IDPartner) : query.OrderByDescending(o => o.IDPartner);
                                break;
							case "IDParent":
								query = isOrdered ? ordered.ThenBy(o => o.IDParent) : query.OrderBy(o => o.IDParent);
								 break;
							case "IDParent_desc":
                                query = isOrdered ? ordered.ThenByDescending(o => o.IDParent) : query.OrderByDescending(o => o.IDParent);
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
							case "ForeignName":
								query = isOrdered ? ordered.ThenBy(o => o.ForeignName) : query.OrderBy(o => o.ForeignName);
								 break;
							case "ForeignName_desc":
                                query = isOrdered ? ordered.ThenByDescending(o => o.ForeignName) : query.OrderByDescending(o => o.ForeignName);
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
							case "Color":
								query = isOrdered ? ordered.ThenBy(o => o.Color) : query.OrderBy(o => o.Color);
								 break;
							case "Color_desc":
                                query = isOrdered ? ordered.ThenByDescending(o => o.Color) : query.OrderByDescending(o => o.Color);
                                break;
							case "Sort":
								query = isOrdered ? ordered.ThenBy(o => o.Sort) : query.OrderBy(o => o.Sort);
								 break;
							case "Sort_desc":
                                query = isOrdered ? ordered.ThenByDescending(o => o.Sort) : query.OrderByDescending(o => o.Sort);
                                break;
							case "IsSysAttrib":
								query = isOrdered ? ordered.ThenBy(o => o.IsSysAttrib) : query.OrderBy(o => o.IsSysAttrib);
								 break;
							case "IsSysAttrib_desc":
                                query = isOrdered ? ordered.ThenByDescending(o => o.IsSysAttrib) : query.OrderByDescending(o => o.IsSysAttrib);
                                break;
							case "IsDefault":
								query = isOrdered ? ordered.ThenBy(o => o.IsDefault) : query.OrderBy(o => o.IsDefault);
								 break;
							case "IsDefault_desc":
                                query = isOrdered ? ordered.ThenByDescending(o => o.IsDefault) : query.OrderByDescending(o => o.IsDefault);
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

        public static IQueryable<tbl_LIST_General> _pagingBuilder(IQueryable<tbl_LIST_General> query, Dictionary<string, string> QueryStrings)
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






