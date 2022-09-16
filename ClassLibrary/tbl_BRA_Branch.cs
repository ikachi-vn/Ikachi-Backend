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
    
    
    public partial class tbl_BRA_Branch
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public tbl_BRA_Branch()
        {
            this.tbl_BANK_PaymentTerm = new HashSet<tbl_BANK_PaymentTerm>();
            this.tbl_BI_Finance_BalanceSheets = new HashSet<tbl_BI_Finance_BalanceSheets>();
            this.tbl_BI_Finance_CashFlow = new HashSet<tbl_BI_Finance_CashFlow>();
            this.tbl_BI_Finance_IncomeStatement = new HashSet<tbl_BI_Finance_IncomeStatement>();
            this.tbl_BI_Finance_Management = new HashSet<tbl_BI_Finance_Management>();
            this.tbl_BI_Oppotunity = new HashSet<tbl_BI_Oppotunity>();
            this.tbl_HRM_StaffRecruitmentInfo = new HashSet<tbl_HRM_StaffRecruitmentInfo>();
            this.tbl_HRM_PersonalIncomePaymentProcess = new HashSet<tbl_HRM_PersonalIncomePaymentProcess>();
            this.tbl_HRM_StaffConcurrentPosition = new HashSet<tbl_HRM_StaffConcurrentPosition>();
            this.tbl_HRM_StaffConcurrentPosition1 = new HashSet<tbl_HRM_StaffConcurrentPosition>();
            this.tbl_HRM_StaffConcurrentProbationryPosition = new HashSet<tbl_HRM_StaffConcurrentProbationryPosition>();
            this.tbl_HRM_StaffConcurrentProbationryPosition1 = new HashSet<tbl_HRM_StaffConcurrentProbationryPosition>();
            this.tbl_SYS_GlobalConfig = new HashSet<tbl_SYS_GlobalConfig>();
            this.tbl_HRM_Staff = new HashSet<tbl_HRM_Staff>();
            this.tbl_HRM_StaffAppointDecision = new HashSet<tbl_HRM_StaffAppointDecision>();
            this.tbl_HRM_StaffInsurancePaymentProcess = new HashSet<tbl_HRM_StaffInsurancePaymentProcess>();
            this.tbl_HRM_Staff1 = new HashSet<tbl_HRM_Staff>();
            this.tbl_HRM_PolAllowanceApplyFor = new HashSet<tbl_HRM_PolAllowanceApplyFor>();
            this.tbl_HRM_StaffAppointDecision1 = new HashSet<tbl_HRM_StaffAppointDecision>();
            this.tbl_HRM_PolCompulsoryInsuranceApplyFor = new HashSet<tbl_HRM_PolCompulsoryInsuranceApplyFor>();
            this.tbl_HRM_StaffInsurancePaymentProcess1 = new HashSet<tbl_HRM_StaffInsurancePaymentProcess>();
            this.tbl_HRM_PersonalIncomePaymentProcess1 = new HashSet<tbl_HRM_PersonalIncomePaymentProcess>();
            this.tbl_HRM_PolWelfareApplyFor = new HashSet<tbl_HRM_PolWelfareApplyFor>();
            this.tbl_HRM_StaffWorkExperience = new HashSet<tbl_HRM_StaffWorkExperience>();
            this.tbl_HRM_StaffRecruitmentInfo1 = new HashSet<tbl_HRM_StaffRecruitmentInfo>();
            this.tbl_BRA_Branch1 = new HashSet<tbl_BRA_Branch>();
            this.tbl_SYS_Role = new HashSet<tbl_SYS_Role>();
            this.tbl_BSC_RevenueTarget = new HashSet<tbl_BSC_RevenueTarget>();
            this.tbl_CRM_BusinessPartnerGroup = new HashSet<tbl_CRM_BusinessPartnerGroup>();
            this.tbl_CRM_Config = new HashSet<tbl_CRM_Config>();
            this.tbl_CRM_Contact = new HashSet<tbl_CRM_Contact>();
            this.tbl_CRM_Campaign = new HashSet<tbl_CRM_Campaign>();
            this.tbl_CRM_Opportunity = new HashSet<tbl_CRM_Opportunity>();
            this.tbl_CRM_Route = new HashSet<tbl_CRM_Route>();
            this.tbl_CRM_Route1 = new HashSet<tbl_CRM_Route>();
            this.tbl_HRM_Staff2 = new HashSet<tbl_HRM_Staff>();
            this.tbl_PURCHASE_Order = new HashSet<tbl_PURCHASE_Order>();
            this.tbl_SALE_Order = new HashSet<tbl_SALE_Order>();
            this.tbl_SHIFT_TimeSheet = new HashSet<tbl_SHIFT_TimeSheet>();
            this.tbl_SHIP_Shipment = new HashSet<tbl_SHIP_Shipment>();
            this.tbl_SHIP_Shipment1 = new HashSet<tbl_SHIP_Shipment>();
            this.tbl_SYS_Config = new HashSet<tbl_SYS_Config>();
            this.tbl_SYS_PermissionList = new HashSet<tbl_SYS_PermissionList>();
            this.tbl_SYS_RuningNo = new HashSet<tbl_SYS_RuningNo>();
            this.tbl_WMS_Item = new HashSet<tbl_WMS_Item>();
            this.tbl_WMS_ItemGroup = new HashSet<tbl_WMS_ItemGroup>();
            this.tbl_WMS_ItemInLocation = new HashSet<tbl_WMS_ItemInLocation>();
            this.tbl_WMS_Location = new HashSet<tbl_WMS_Location>();
            this.tbl_WMS_LotLPNLocation = new HashSet<tbl_WMS_LotLPNLocation>();
            this.tbl_WMS_PriceList = new HashSet<tbl_WMS_PriceList>();
            this.tbl_WMS_PutawayStrategy = new HashSet<tbl_WMS_PutawayStrategy>();
            this.tbl_WMS_Receipt = new HashSet<tbl_WMS_Receipt>();
            this.tbl_WMS_TaskDispatchStrategy = new HashSet<tbl_WMS_TaskDispatchStrategy>();
            this.tbl_WMS_Transaction = new HashSet<tbl_WMS_Transaction>();
            this.tbl_WMS_Transaction1 = new HashSet<tbl_WMS_Transaction>();
            this.tbl_WMS_WarehouseInfo = new HashSet<tbl_WMS_WarehouseInfo>();
            this.tbl_WMS_WavePlanning = new HashSet<tbl_WMS_WavePlanning>();
            this.tbl_WMS_Zone = new HashSet<tbl_WMS_Zone>();
        }
    
        public int IDType { get; set; }
        public Nullable<int> IDParent { get; set; }
        public Nullable<int> IDAdministrationManager { get; set; }
        public Nullable<int> IDSpecializedManagement { get; set; }
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
        public string BusinessRegistrationNumber { get; set; }
        public Nullable<System.DateTime> IssueDate { get; set; }
        public string IssuedBy { get; set; }
        public string TaxCode { get; set; }
        public string Website { get; set; }
        public string Email { get; set; }
        public string Fax { get; set; }
        public string Phone { get; set; }
        public string Phone2 { get; set; }
        public string Address { get; set; }
        public string BankAccount { get; set; }
        public string TemplateHeader { get; set; }
        public string TemplateFooter { get; set; }
        public string TemplateConfig { get; set; }
        public string LogoURL { get; set; }
        public string BannerURL { get; set; }
        public string ImageURL { get; set; }
        public string BackgroundColor { get; set; }
        public bool IsHeadOfDepartment { get; set; }
        public string VuViec { get; set; }
        public Nullable<int> IDPartner { get; set; }
        public string ShortName { get; set; }
        public string Type { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tbl_BANK_PaymentTerm> tbl_BANK_PaymentTerm { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tbl_BI_Finance_BalanceSheets> tbl_BI_Finance_BalanceSheets { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tbl_BI_Finance_CashFlow> tbl_BI_Finance_CashFlow { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tbl_BI_Finance_IncomeStatement> tbl_BI_Finance_IncomeStatement { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tbl_BI_Finance_Management> tbl_BI_Finance_Management { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tbl_BI_Oppotunity> tbl_BI_Oppotunity { get; set; }
        //List 0:1
        public virtual tbl_BP_Partner tbl_BP_Partner { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tbl_HRM_StaffRecruitmentInfo> tbl_HRM_StaffRecruitmentInfo { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tbl_HRM_PersonalIncomePaymentProcess> tbl_HRM_PersonalIncomePaymentProcess { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tbl_HRM_StaffConcurrentPosition> tbl_HRM_StaffConcurrentPosition { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tbl_HRM_StaffConcurrentPosition> tbl_HRM_StaffConcurrentPosition1 { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tbl_HRM_StaffConcurrentProbationryPosition> tbl_HRM_StaffConcurrentProbationryPosition { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tbl_HRM_StaffConcurrentProbationryPosition> tbl_HRM_StaffConcurrentProbationryPosition1 { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tbl_SYS_GlobalConfig> tbl_SYS_GlobalConfig { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tbl_HRM_Staff> tbl_HRM_Staff { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tbl_HRM_StaffAppointDecision> tbl_HRM_StaffAppointDecision { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tbl_HRM_StaffInsurancePaymentProcess> tbl_HRM_StaffInsurancePaymentProcess { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tbl_HRM_Staff> tbl_HRM_Staff1 { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tbl_HRM_PolAllowanceApplyFor> tbl_HRM_PolAllowanceApplyFor { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tbl_HRM_StaffAppointDecision> tbl_HRM_StaffAppointDecision1 { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tbl_HRM_PolCompulsoryInsuranceApplyFor> tbl_HRM_PolCompulsoryInsuranceApplyFor { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tbl_HRM_StaffInsurancePaymentProcess> tbl_HRM_StaffInsurancePaymentProcess1 { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tbl_HRM_PersonalIncomePaymentProcess> tbl_HRM_PersonalIncomePaymentProcess1 { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tbl_HRM_PolWelfareApplyFor> tbl_HRM_PolWelfareApplyFor { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tbl_HRM_StaffWorkExperience> tbl_HRM_StaffWorkExperience { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tbl_HRM_StaffRecruitmentInfo> tbl_HRM_StaffRecruitmentInfo1 { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tbl_BRA_Branch> tbl_BRA_Branch1 { get; set; }
        //List 0:1
        public virtual tbl_BRA_Branch tbl_BRA_Branch2 { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tbl_SYS_Role> tbl_SYS_Role { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tbl_BSC_RevenueTarget> tbl_BSC_RevenueTarget { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tbl_CRM_BusinessPartnerGroup> tbl_CRM_BusinessPartnerGroup { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tbl_CRM_Config> tbl_CRM_Config { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tbl_CRM_Contact> tbl_CRM_Contact { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tbl_CRM_Campaign> tbl_CRM_Campaign { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tbl_CRM_Opportunity> tbl_CRM_Opportunity { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tbl_CRM_Route> tbl_CRM_Route { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tbl_CRM_Route> tbl_CRM_Route1 { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tbl_HRM_Staff> tbl_HRM_Staff2 { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tbl_PURCHASE_Order> tbl_PURCHASE_Order { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tbl_SALE_Order> tbl_SALE_Order { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tbl_SHIFT_TimeSheet> tbl_SHIFT_TimeSheet { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tbl_SHIP_Shipment> tbl_SHIP_Shipment { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tbl_SHIP_Shipment> tbl_SHIP_Shipment1 { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tbl_SYS_Config> tbl_SYS_Config { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tbl_SYS_PermissionList> tbl_SYS_PermissionList { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tbl_SYS_RuningNo> tbl_SYS_RuningNo { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tbl_WMS_Item> tbl_WMS_Item { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tbl_WMS_ItemGroup> tbl_WMS_ItemGroup { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tbl_WMS_ItemInLocation> tbl_WMS_ItemInLocation { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tbl_WMS_Location> tbl_WMS_Location { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tbl_WMS_LotLPNLocation> tbl_WMS_LotLPNLocation { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tbl_WMS_PriceList> tbl_WMS_PriceList { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tbl_WMS_PutawayStrategy> tbl_WMS_PutawayStrategy { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tbl_WMS_Receipt> tbl_WMS_Receipt { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tbl_WMS_TaskDispatchStrategy> tbl_WMS_TaskDispatchStrategy { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tbl_WMS_Transaction> tbl_WMS_Transaction { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tbl_WMS_Transaction> tbl_WMS_Transaction1 { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tbl_WMS_WarehouseInfo> tbl_WMS_WarehouseInfo { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tbl_WMS_WavePlanning> tbl_WMS_WavePlanning { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tbl_WMS_Zone> tbl_WMS_Zone { get; set; }
    }
}


namespace DTOModel
{
	using System;
	public partial class DTO_BRA_Branch
	{
		public int IDType { get; set; }
		public Nullable<int> IDParent { get; set; }
		public Nullable<int> IDAdministrationManager { get; set; }
		public Nullable<int> IDSpecializedManagement { get; set; }
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
		public string BusinessRegistrationNumber { get; set; }
		public Nullable<System.DateTime> IssueDate { get; set; }
		public string IssuedBy { get; set; }
		public string TaxCode { get; set; }
		public string Website { get; set; }
		public string Email { get; set; }
		public string Fax { get; set; }
		public string Phone { get; set; }
		public string Phone2 { get; set; }
		public string Address { get; set; }
		public string BankAccount { get; set; }
		public string TemplateHeader { get; set; }
		public string TemplateFooter { get; set; }
		public string TemplateConfig { get; set; }
		public string LogoURL { get; set; }
		public string BannerURL { get; set; }
		public string ImageURL { get; set; }
		public string BackgroundColor { get; set; }
		public bool IsHeadOfDepartment { get; set; }
		public string VuViec { get; set; }
		public Nullable<int> IDPartner { get; set; }
		public string ShortName { get; set; }
		public string Type { get; set; }
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

    public static partial class BS_BRA_Branch 
    {
        public static dynamic getSearch(AppEntities db, int IDBranch, int StaffID, Dictionary<string, string> QueryStrings)
        {
            return get(db, IDBranch,StaffID, QueryStrings);
        }

		public static IQueryable<DTO_BRA_Branch> get(AppEntities db, int IDBranch, int StaffID, Dictionary<string, string> QueryStrings)
        {
			var query = _queryBuilder(db, IDBranch, StaffID, QueryStrings);

            if (QueryStrings.Any(d => d.Key == "AllChildren")  || QueryStrings.Any(d => d.Key == "AllParent"))
            {

                List<DTO_BRA_Branch> allItems = db.tbl_BRA_Branch.Where(d => d.IsDeleted == false).Select(s => new DTO_BRA_Branch()
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
                    
                    query = db.tbl_BRA_Branch.Where(d => Ids.Contains(d.Id));
                }

            }

            query = _sortBuilder(query, QueryStrings);
            query = _pagingBuilder(query, QueryStrings);

			return toDTO(query);
        }

        public static List<int> findParent(List<DTO_BRA_Branch> allItems, int Id)
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

        public static List<int> findChildrent(List<DTO_BRA_Branch> allItems, int Id)
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
            package.Workbook.Properties.Title = "ART-DMS BRA_Branch";
            package.Workbook.Properties.Author = "hung.vu@codeart.vn";
            package.Workbook.Properties.Application = "ART-DMS";
            package.Workbook.Properties.Company = "A.R.T Distribution";

            ExcelWorkbook workBook = package.Workbook;
            if (workBook != null)
            {
                var ws = workBook.Worksheets.FirstOrDefault();
                var data = _queryBuilder(db, IDBranch, StaffID, QueryStrings).ToList();

                //var BP_PartnerList = BS_BP_Partner.get(db,IDBranch, StaffID,QueryStrings).Select(s => new ItemModel { Id = s.Id, Name = s.Name });
                //var BRA_Branch2List = BS_BRA_Branch.get(db,IDBranch, StaffID,QueryStrings).Select(s => new ItemModel { Id = s.Id, Name = s.Name });
                 

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

		public static DTO_BRA_Branch getAnItem(AppEntities db, int IDBranch, int StaffID, int id)
        {
            var dbResult = db.tbl_BRA_Branch.Find(id);

			return toDTO(dbResult);
			
        }
		
		public static DTO_BRA_Branch getAnItemByCode(AppEntities db, int IDBranch, int StaffID, string code)
        {
            var dbResult = db.tbl_BRA_Branch
			.FirstOrDefault(d => d.IsDeleted == false && d.Code == code );

			return toDTO(dbResult);
			
        }

		public static bool put(AppEntities db, int IDBranch, int StaffID, int Id, dynamic item, string Username, Dictionary<string, string> QueryStrings)
        {
            bool result = false;
            var dbitem = db.tbl_BRA_Branch.Find(Id);
            
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
					errorLog.logMessage("put_BRA_Branch",e);
                    result = false;
                }
            }
            else
                if (QueryStrings.Any(d => d.Key == "ForceCreate"))
                    result =  post(db, IDBranch, StaffID, item, Username) != null;
                
            return result;
        }

        public static void patchDynamicToDB(dynamic item, tbl_BRA_Branch dbitem, string Username)
        {
            Type type = typeof(tbl_BRA_Branch);
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

        public static void patchDTOtoDBValue( DTO_BRA_Branch item, tbl_BRA_Branch dbitem)
        {
            if (item == null){
                dbitem = null;
                return;
            }
            							
			dbitem.IDType = item.IDType;							
			dbitem.IDParent = item.IDParent;							
			dbitem.IDAdministrationManager = item.IDAdministrationManager;							
			dbitem.IDSpecializedManagement = item.IDSpecializedManagement;							
			dbitem.Code = item.Code;							
			dbitem.Name = item.Name;							
			dbitem.Remark = item.Remark;							
			dbitem.Sort = item.Sort;							
			dbitem.IsDisabled = item.IsDisabled;							
			dbitem.IsDeleted = item.IsDeleted;							
			dbitem.BusinessRegistrationNumber = item.BusinessRegistrationNumber;							
			dbitem.IssueDate = item.IssueDate;							
			dbitem.IssuedBy = item.IssuedBy;							
			dbitem.TaxCode = item.TaxCode;							
			dbitem.Website = item.Website;							
			dbitem.Email = item.Email;							
			dbitem.Fax = item.Fax;							
			dbitem.Phone = item.Phone;							
			dbitem.Phone2 = item.Phone2;							
			dbitem.Address = item.Address;							
			dbitem.BankAccount = item.BankAccount;							
			dbitem.TemplateHeader = item.TemplateHeader;							
			dbitem.TemplateFooter = item.TemplateFooter;							
			dbitem.TemplateConfig = item.TemplateConfig;							
			dbitem.LogoURL = item.LogoURL;							
			dbitem.BannerURL = item.BannerURL;							
			dbitem.ImageURL = item.ImageURL;							
			dbitem.BackgroundColor = item.BackgroundColor;							
			dbitem.IsHeadOfDepartment = item.IsHeadOfDepartment;							
			dbitem.VuViec = item.VuViec;							
			dbitem.IDPartner = item.IDPartner;							
			dbitem.ShortName = item.ShortName;							
			dbitem.Type = item.Type;        }

		public static DTO_BRA_Branch post(AppEntities db, int IDBranch, int StaffID, dynamic item, string Username)
        {
            tbl_BRA_Branch dbitem = new tbl_BRA_Branch();
            if (item != null)
            {
                patchDynamicToDB(item, dbitem, Username);
                
				dbitem.CreatedBy = Username;
				dbitem.CreatedDate = DateTime.Now;				
                try
                {
					db.tbl_BRA_Branch.Add(dbitem);
                    db.SaveChanges();
				
                }
                catch (DbEntityValidationException e)
                {
					errorLog.logMessage("post_BRA_Branch",e);
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
                Type type = Type.GetType("BaseBusiness.BS_BRA_Branch, ClassLibrary");
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
                        var target = new tbl_BRA_Branch();
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
                    
                    tbl_BRA_Branch dbitem = new tbl_BRA_Branch();
                    if (it.Id == null || string.IsNullOrEmpty(it.Id.Value) || it.Id == "0")
                    {
                        dbitem = new tbl_BRA_Branch();
                        dbitem.CreatedBy = Username;
				        dbitem.CreatedDate = DateTime.Now;
                                            }
                    else
                    {
                        dbitem = db.tbl_BRA_Branch.Find((int)it.Id);
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
                        
                        if (dbitem.Id == 0) db.tbl_BRA_Branch.Add(dbitem);
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
                    errorLog.logMessage("post_BRA_Branch",e);
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

            var dbitems = db.tbl_BRA_Branch.Where(d => IDs.Contains(d.Id));
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
			
                BS_Version.update_Version(db, null, "DTO_BRA_Branch", updateDate, Username);
			
            }
            catch (DbEntityValidationException e)
            {
				errorLog.logMessage("delete_BRA_Branch",e);
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

			
            var dbitems = db.tbl_BRA_Branch.Where(d => IDs.Contains(d.Id));
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
			
                BS_Version.update_Version(db, null, "DTO_BRA_Branch", updateDate, Username);
			
            }
            catch (DbEntityValidationException e)
            {
				errorLog.logMessage("disable_BRA_Branch",e);
                result = false;
            }
            
            return result;
        }

		
		//---//
		public static bool check_Exists(AppEntities db, int id)
		{
             
            return db.tbl_BRA_Branch.Any(e => e.Id == id && e.IsDeleted == false);
            
		}
		
		public static bool check_Exists(AppEntities db, string Code)
		{
             
            return db.tbl_BRA_Branch.Any(e => e.Code == Code && e.IsDeleted == false);
            
		}
		
		//---//
		public static IQueryable<DTO_BRA_Branch> toDTO(IQueryable<tbl_BRA_Branch> query)
        {
			return query
			.Select(s => new DTO_BRA_Branch(){							
				IDType = s.IDType,							
				IDParent = s.IDParent,							
				IDAdministrationManager = s.IDAdministrationManager,							
				IDSpecializedManagement = s.IDSpecializedManagement,							
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
				BusinessRegistrationNumber = s.BusinessRegistrationNumber,							
				IssueDate = s.IssueDate,							
				IssuedBy = s.IssuedBy,							
				TaxCode = s.TaxCode,							
				Website = s.Website,							
				Email = s.Email,							
				Fax = s.Fax,							
				Phone = s.Phone,							
				Phone2 = s.Phone2,							
				Address = s.Address,							
				BankAccount = s.BankAccount,							
				TemplateHeader = s.TemplateHeader,							
				TemplateFooter = s.TemplateFooter,							
				TemplateConfig = s.TemplateConfig,							
				LogoURL = s.LogoURL,							
				BannerURL = s.BannerURL,							
				ImageURL = s.ImageURL,							
				BackgroundColor = s.BackgroundColor,							
				IsHeadOfDepartment = s.IsHeadOfDepartment,							
				VuViec = s.VuViec,							
				IDPartner = s.IDPartner,							
				ShortName = s.ShortName,							
				Type = s.Type,					
			});//.OrderBy(o => o.Sort == null).ThenBy(u => u.Sort);
                              
        }

		public static DTO_BRA_Branch toDTO(tbl_BRA_Branch dbResult)
        {
			if (dbResult != null)
			{
				return new DTO_BRA_Branch()
				{							
					IDType = dbResult.IDType,							
					IDParent = dbResult.IDParent,							
					IDAdministrationManager = dbResult.IDAdministrationManager,							
					IDSpecializedManagement = dbResult.IDSpecializedManagement,							
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
					BusinessRegistrationNumber = dbResult.BusinessRegistrationNumber,							
					IssueDate = dbResult.IssueDate,							
					IssuedBy = dbResult.IssuedBy,							
					TaxCode = dbResult.TaxCode,							
					Website = dbResult.Website,							
					Email = dbResult.Email,							
					Fax = dbResult.Fax,							
					Phone = dbResult.Phone,							
					Phone2 = dbResult.Phone2,							
					Address = dbResult.Address,							
					BankAccount = dbResult.BankAccount,							
					TemplateHeader = dbResult.TemplateHeader,							
					TemplateFooter = dbResult.TemplateFooter,							
					TemplateConfig = dbResult.TemplateConfig,							
					LogoURL = dbResult.LogoURL,							
					BannerURL = dbResult.BannerURL,							
					ImageURL = dbResult.ImageURL,							
					BackgroundColor = dbResult.BackgroundColor,							
					IsHeadOfDepartment = dbResult.IsHeadOfDepartment,							
					VuViec = dbResult.VuViec,							
					IDPartner = dbResult.IDPartner,							
					ShortName = dbResult.ShortName,							
					Type = dbResult.Type,
				};
			}
			else
				return null; 
        }

		public static IQueryable<tbl_BRA_Branch> _queryBuilder(AppEntities db, int IDBranch, int StaffID, Dictionary<string, string> QueryStrings)
        {
            
			IQueryable<tbl_BRA_Branch> query = db.tbl_BRA_Branch.AsNoTracking();//.Where(d => d.IsDeleted == false );
			

			//Query keyword
			if (QueryStrings.Any(d => d.Key == "Keyword") && !string.IsNullOrEmpty(QueryStrings.FirstOrDefault(d => d.Key == "Keyword").Value))
            {
                var keyword = QueryStrings.FirstOrDefault(d => d.Key == "Keyword").Value;
                query = query.Where(d=>d.Name.Contains(keyword) || d.Code.Contains(keyword));
            }



			//Query IDType (int)
			if (QueryStrings.Any(d => d.Key == "IDType"))
            {
                var IDList = QueryStrings.FirstOrDefault(d => d.Key == "IDType").Value.Replace("[", "").Replace("]", "").Split(',');
                List<int> IDs = new List<int>();
                foreach (var item in IDList)
                    if (int.TryParse(item, out int i))
                        IDs.Add(i);
                if (IDs.Count > 0)
                    query = query.Where(d => IDs.Contains(d.IDType));
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

			//Query IDAdministrationManager (Nullable<int>)
			if (QueryStrings.Any(d => d.Key == "IDAdministrationManager"))
            {
                var IDList = QueryStrings.FirstOrDefault(d => d.Key == "IDAdministrationManager").Value.Replace("[", "").Replace("]", "").Split(',');
                List<int?> IDs = new List<int?>();
                foreach (var item in IDList)
                    if (int.TryParse(item, out int i))
                        IDs.Add(i);
					else if (item == "null")
						IDs.Add(null);
                if (IDs.Count > 0)
                    query = query.Where(d => IDs.Contains(d.IDAdministrationManager));
////                    query = query.Where(d => IDs.Contains(d.IDAdministrationManager));
//                    
            }

			//Query IDSpecializedManagement (Nullable<int>)
			if (QueryStrings.Any(d => d.Key == "IDSpecializedManagement"))
            {
                var IDList = QueryStrings.FirstOrDefault(d => d.Key == "IDSpecializedManagement").Value.Replace("[", "").Replace("]", "").Split(',');
                List<int?> IDs = new List<int?>();
                foreach (var item in IDList)
                    if (int.TryParse(item, out int i))
                        IDs.Add(i);
					else if (item == "null")
						IDs.Add(null);
                if (IDs.Count > 0)
                    query = query.Where(d => IDs.Contains(d.IDSpecializedManagement));
////                    query = query.Where(d => IDs.Contains(d.IDSpecializedManagement));
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


			//Query BusinessRegistrationNumber (string)
			if (QueryStrings.Any(d => d.Key == "BusinessRegistrationNumber_eq") && !string.IsNullOrEmpty(QueryStrings.FirstOrDefault(d => d.Key == "BusinessRegistrationNumber_eq").Value))
            {
                var keyword = QueryStrings.FirstOrDefault(d => d.Key == "BusinessRegistrationNumber_eq").Value;
                query = query.Where(d=>d.BusinessRegistrationNumber == keyword);
            }
            if (QueryStrings.Any(d => d.Key == "BusinessRegistrationNumber") && !string.IsNullOrEmpty(QueryStrings.FirstOrDefault(d => d.Key == "BusinessRegistrationNumber").Value))
            {
                var keyword = QueryStrings.FirstOrDefault(d => d.Key == "BusinessRegistrationNumber").Value;
                query = query.Where(d=>d.BusinessRegistrationNumber.Contains(keyword));
            }
            

			//Query IssueDate (Nullable<System.DateTime>)
			if (QueryStrings.Any(d => d.Key == "IssueDateFrom") && QueryStrings.Any(d => d.Key == "IssueDateTo"))
                if (DateTime.TryParse(QueryStrings.FirstOrDefault(d => d.Key == "IssueDateFrom").Value, out DateTime fromDate) && DateTime.TryParse(QueryStrings.FirstOrDefault(d => d.Key == "IssueDateTo").Value, out DateTime toDate))
                    query = query.Where(d => fromDate <= d.IssueDate && d.IssueDate <= toDate);

            if (QueryStrings.Any(d => d.Key == "IssueDate"))
                if (DateTime.TryParse(QueryStrings.FirstOrDefault(d => d.Key == "IssueDate").Value, out DateTime val))
                    query = query.Where(d => d.IssueDate != null && DbFunctions.TruncateTime(val) == DbFunctions.TruncateTime(d.IssueDate));


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
            

			//Query TaxCode (string)
			if (QueryStrings.Any(d => d.Key == "TaxCode_eq") && !string.IsNullOrEmpty(QueryStrings.FirstOrDefault(d => d.Key == "TaxCode_eq").Value))
            {
                var keyword = QueryStrings.FirstOrDefault(d => d.Key == "TaxCode_eq").Value;
                query = query.Where(d=>d.TaxCode == keyword);
            }
            if (QueryStrings.Any(d => d.Key == "TaxCode") && !string.IsNullOrEmpty(QueryStrings.FirstOrDefault(d => d.Key == "TaxCode").Value))
            {
                var keyword = QueryStrings.FirstOrDefault(d => d.Key == "TaxCode").Value;
                query = query.Where(d=>d.TaxCode.Contains(keyword));
            }
            

			//Query Website (string)
			if (QueryStrings.Any(d => d.Key == "Website_eq") && !string.IsNullOrEmpty(QueryStrings.FirstOrDefault(d => d.Key == "Website_eq").Value))
            {
                var keyword = QueryStrings.FirstOrDefault(d => d.Key == "Website_eq").Value;
                query = query.Where(d=>d.Website == keyword);
            }
            if (QueryStrings.Any(d => d.Key == "Website") && !string.IsNullOrEmpty(QueryStrings.FirstOrDefault(d => d.Key == "Website").Value))
            {
                var keyword = QueryStrings.FirstOrDefault(d => d.Key == "Website").Value;
                query = query.Where(d=>d.Website.Contains(keyword));
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
            

			//Query Fax (string)
			if (QueryStrings.Any(d => d.Key == "Fax_eq") && !string.IsNullOrEmpty(QueryStrings.FirstOrDefault(d => d.Key == "Fax_eq").Value))
            {
                var keyword = QueryStrings.FirstOrDefault(d => d.Key == "Fax_eq").Value;
                query = query.Where(d=>d.Fax == keyword);
            }
            if (QueryStrings.Any(d => d.Key == "Fax") && !string.IsNullOrEmpty(QueryStrings.FirstOrDefault(d => d.Key == "Fax").Value))
            {
                var keyword = QueryStrings.FirstOrDefault(d => d.Key == "Fax").Value;
                query = query.Where(d=>d.Fax.Contains(keyword));
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
            

			//Query Phone2 (string)
			if (QueryStrings.Any(d => d.Key == "Phone2_eq") && !string.IsNullOrEmpty(QueryStrings.FirstOrDefault(d => d.Key == "Phone2_eq").Value))
            {
                var keyword = QueryStrings.FirstOrDefault(d => d.Key == "Phone2_eq").Value;
                query = query.Where(d=>d.Phone2 == keyword);
            }
            if (QueryStrings.Any(d => d.Key == "Phone2") && !string.IsNullOrEmpty(QueryStrings.FirstOrDefault(d => d.Key == "Phone2").Value))
            {
                var keyword = QueryStrings.FirstOrDefault(d => d.Key == "Phone2").Value;
                query = query.Where(d=>d.Phone2.Contains(keyword));
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
            

			//Query BankAccount (string)
			if (QueryStrings.Any(d => d.Key == "BankAccount_eq") && !string.IsNullOrEmpty(QueryStrings.FirstOrDefault(d => d.Key == "BankAccount_eq").Value))
            {
                var keyword = QueryStrings.FirstOrDefault(d => d.Key == "BankAccount_eq").Value;
                query = query.Where(d=>d.BankAccount == keyword);
            }
            if (QueryStrings.Any(d => d.Key == "BankAccount") && !string.IsNullOrEmpty(QueryStrings.FirstOrDefault(d => d.Key == "BankAccount").Value))
            {
                var keyword = QueryStrings.FirstOrDefault(d => d.Key == "BankAccount").Value;
                query = query.Where(d=>d.BankAccount.Contains(keyword));
            }
            

			//Query TemplateHeader (string)
			if (QueryStrings.Any(d => d.Key == "TemplateHeader_eq") && !string.IsNullOrEmpty(QueryStrings.FirstOrDefault(d => d.Key == "TemplateHeader_eq").Value))
            {
                var keyword = QueryStrings.FirstOrDefault(d => d.Key == "TemplateHeader_eq").Value;
                query = query.Where(d=>d.TemplateHeader == keyword);
            }
            if (QueryStrings.Any(d => d.Key == "TemplateHeader") && !string.IsNullOrEmpty(QueryStrings.FirstOrDefault(d => d.Key == "TemplateHeader").Value))
            {
                var keyword = QueryStrings.FirstOrDefault(d => d.Key == "TemplateHeader").Value;
                query = query.Where(d=>d.TemplateHeader.Contains(keyword));
            }
            

			//Query TemplateFooter (string)
			if (QueryStrings.Any(d => d.Key == "TemplateFooter_eq") && !string.IsNullOrEmpty(QueryStrings.FirstOrDefault(d => d.Key == "TemplateFooter_eq").Value))
            {
                var keyword = QueryStrings.FirstOrDefault(d => d.Key == "TemplateFooter_eq").Value;
                query = query.Where(d=>d.TemplateFooter == keyword);
            }
            if (QueryStrings.Any(d => d.Key == "TemplateFooter") && !string.IsNullOrEmpty(QueryStrings.FirstOrDefault(d => d.Key == "TemplateFooter").Value))
            {
                var keyword = QueryStrings.FirstOrDefault(d => d.Key == "TemplateFooter").Value;
                query = query.Where(d=>d.TemplateFooter.Contains(keyword));
            }
            

			//Query TemplateConfig (string)
			if (QueryStrings.Any(d => d.Key == "TemplateConfig_eq") && !string.IsNullOrEmpty(QueryStrings.FirstOrDefault(d => d.Key == "TemplateConfig_eq").Value))
            {
                var keyword = QueryStrings.FirstOrDefault(d => d.Key == "TemplateConfig_eq").Value;
                query = query.Where(d=>d.TemplateConfig == keyword);
            }
            if (QueryStrings.Any(d => d.Key == "TemplateConfig") && !string.IsNullOrEmpty(QueryStrings.FirstOrDefault(d => d.Key == "TemplateConfig").Value))
            {
                var keyword = QueryStrings.FirstOrDefault(d => d.Key == "TemplateConfig").Value;
                query = query.Where(d=>d.TemplateConfig.Contains(keyword));
            }
            

			//Query LogoURL (string)
			if (QueryStrings.Any(d => d.Key == "LogoURL_eq") && !string.IsNullOrEmpty(QueryStrings.FirstOrDefault(d => d.Key == "LogoURL_eq").Value))
            {
                var keyword = QueryStrings.FirstOrDefault(d => d.Key == "LogoURL_eq").Value;
                query = query.Where(d=>d.LogoURL == keyword);
            }
            if (QueryStrings.Any(d => d.Key == "LogoURL") && !string.IsNullOrEmpty(QueryStrings.FirstOrDefault(d => d.Key == "LogoURL").Value))
            {
                var keyword = QueryStrings.FirstOrDefault(d => d.Key == "LogoURL").Value;
                query = query.Where(d=>d.LogoURL.Contains(keyword));
            }
            

			//Query BannerURL (string)
			if (QueryStrings.Any(d => d.Key == "BannerURL_eq") && !string.IsNullOrEmpty(QueryStrings.FirstOrDefault(d => d.Key == "BannerURL_eq").Value))
            {
                var keyword = QueryStrings.FirstOrDefault(d => d.Key == "BannerURL_eq").Value;
                query = query.Where(d=>d.BannerURL == keyword);
            }
            if (QueryStrings.Any(d => d.Key == "BannerURL") && !string.IsNullOrEmpty(QueryStrings.FirstOrDefault(d => d.Key == "BannerURL").Value))
            {
                var keyword = QueryStrings.FirstOrDefault(d => d.Key == "BannerURL").Value;
                query = query.Where(d=>d.BannerURL.Contains(keyword));
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
            

			//Query IsHeadOfDepartment (bool)
			if (QueryStrings.Any(d => d.Key == "IsHeadOfDepartment"))
            {
                var qValue = QueryStrings.FirstOrDefault(d => d.Key == "IsHeadOfDepartment").Value;
                if (bool.TryParse(qValue, out bool qBoolValue))
                    query = query.Where(d => qBoolValue == d.IsHeadOfDepartment);
            }

			//Query VuViec (string)
			if (QueryStrings.Any(d => d.Key == "VuViec_eq") && !string.IsNullOrEmpty(QueryStrings.FirstOrDefault(d => d.Key == "VuViec_eq").Value))
            {
                var keyword = QueryStrings.FirstOrDefault(d => d.Key == "VuViec_eq").Value;
                query = query.Where(d=>d.VuViec == keyword);
            }
            if (QueryStrings.Any(d => d.Key == "VuViec") && !string.IsNullOrEmpty(QueryStrings.FirstOrDefault(d => d.Key == "VuViec").Value))
            {
                var keyword = QueryStrings.FirstOrDefault(d => d.Key == "VuViec").Value;
                query = query.Where(d=>d.VuViec.Contains(keyword));
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
            

			//Query Type (string)
			if (QueryStrings.Any(d => d.Key == "Type_eq") && !string.IsNullOrEmpty(QueryStrings.FirstOrDefault(d => d.Key == "Type_eq").Value))
            {
                var keyword = QueryStrings.FirstOrDefault(d => d.Key == "Type_eq").Value;
                query = query.Where(d=>d.Type == keyword);
            }
            if (QueryStrings.Any(d => d.Key == "Type") && !string.IsNullOrEmpty(QueryStrings.FirstOrDefault(d => d.Key == "Type").Value))
            {
                var keyword = QueryStrings.FirstOrDefault(d => d.Key == "Type").Value;
                query = query.Where(d=>d.Type.Contains(keyword));
            }
            
            return query;
        }
		
        public static IQueryable<tbl_BRA_Branch> _sortBuilder(IQueryable<tbl_BRA_Branch> query, Dictionary<string, string> QueryStrings)
        {
            if (QueryStrings.Any(d => d.Key == "SortBy"))
            {
                var sorts = QueryStrings.FirstOrDefault(d => d.Key == "SortBy").Value.Replace("[", "").Replace("]", "").Split(',');
                
                foreach (var item in sorts)
                    if (!string.IsNullOrEmpty(item))
                    {
                        var ordered = query as IOrderedQueryable<tbl_BRA_Branch>;
                        bool isOrdered = ordered.ToString().IndexOf("ORDER BY") !=-1;

                        switch (item)
                        {
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
							case "IDAdministrationManager":
								query = isOrdered ? ordered.ThenBy(o => o.IDAdministrationManager) : query.OrderBy(o => o.IDAdministrationManager);
								 break;
							case "IDAdministrationManager_desc":
                                query = isOrdered ? ordered.ThenByDescending(o => o.IDAdministrationManager) : query.OrderByDescending(o => o.IDAdministrationManager);
                                break;
							case "IDSpecializedManagement":
								query = isOrdered ? ordered.ThenBy(o => o.IDSpecializedManagement) : query.OrderBy(o => o.IDSpecializedManagement);
								 break;
							case "IDSpecializedManagement_desc":
                                query = isOrdered ? ordered.ThenByDescending(o => o.IDSpecializedManagement) : query.OrderByDescending(o => o.IDSpecializedManagement);
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
							case "BusinessRegistrationNumber":
								query = isOrdered ? ordered.ThenBy(o => o.BusinessRegistrationNumber) : query.OrderBy(o => o.BusinessRegistrationNumber);
								 break;
							case "BusinessRegistrationNumber_desc":
                                query = isOrdered ? ordered.ThenByDescending(o => o.BusinessRegistrationNumber) : query.OrderByDescending(o => o.BusinessRegistrationNumber);
                                break;
							case "IssueDate":
								query = isOrdered ? ordered.ThenBy(o => o.IssueDate) : query.OrderBy(o => o.IssueDate);
								 break;
							case "IssueDate_desc":
                                query = isOrdered ? ordered.ThenByDescending(o => o.IssueDate) : query.OrderByDescending(o => o.IssueDate);
                                break;
							case "IssuedBy":
								query = isOrdered ? ordered.ThenBy(o => o.IssuedBy) : query.OrderBy(o => o.IssuedBy);
								 break;
							case "IssuedBy_desc":
                                query = isOrdered ? ordered.ThenByDescending(o => o.IssuedBy) : query.OrderByDescending(o => o.IssuedBy);
                                break;
							case "TaxCode":
								query = isOrdered ? ordered.ThenBy(o => o.TaxCode) : query.OrderBy(o => o.TaxCode);
								 break;
							case "TaxCode_desc":
                                query = isOrdered ? ordered.ThenByDescending(o => o.TaxCode) : query.OrderByDescending(o => o.TaxCode);
                                break;
							case "Website":
								query = isOrdered ? ordered.ThenBy(o => o.Website) : query.OrderBy(o => o.Website);
								 break;
							case "Website_desc":
                                query = isOrdered ? ordered.ThenByDescending(o => o.Website) : query.OrderByDescending(o => o.Website);
                                break;
							case "Email":
								query = isOrdered ? ordered.ThenBy(o => o.Email) : query.OrderBy(o => o.Email);
								 break;
							case "Email_desc":
                                query = isOrdered ? ordered.ThenByDescending(o => o.Email) : query.OrderByDescending(o => o.Email);
                                break;
							case "Fax":
								query = isOrdered ? ordered.ThenBy(o => o.Fax) : query.OrderBy(o => o.Fax);
								 break;
							case "Fax_desc":
                                query = isOrdered ? ordered.ThenByDescending(o => o.Fax) : query.OrderByDescending(o => o.Fax);
                                break;
							case "Phone":
								query = isOrdered ? ordered.ThenBy(o => o.Phone) : query.OrderBy(o => o.Phone);
								 break;
							case "Phone_desc":
                                query = isOrdered ? ordered.ThenByDescending(o => o.Phone) : query.OrderByDescending(o => o.Phone);
                                break;
							case "Phone2":
								query = isOrdered ? ordered.ThenBy(o => o.Phone2) : query.OrderBy(o => o.Phone2);
								 break;
							case "Phone2_desc":
                                query = isOrdered ? ordered.ThenByDescending(o => o.Phone2) : query.OrderByDescending(o => o.Phone2);
                                break;
							case "Address":
								query = isOrdered ? ordered.ThenBy(o => o.Address) : query.OrderBy(o => o.Address);
								 break;
							case "Address_desc":
                                query = isOrdered ? ordered.ThenByDescending(o => o.Address) : query.OrderByDescending(o => o.Address);
                                break;
							case "BankAccount":
								query = isOrdered ? ordered.ThenBy(o => o.BankAccount) : query.OrderBy(o => o.BankAccount);
								 break;
							case "BankAccount_desc":
                                query = isOrdered ? ordered.ThenByDescending(o => o.BankAccount) : query.OrderByDescending(o => o.BankAccount);
                                break;
							case "TemplateHeader":
								query = isOrdered ? ordered.ThenBy(o => o.TemplateHeader) : query.OrderBy(o => o.TemplateHeader);
								 break;
							case "TemplateHeader_desc":
                                query = isOrdered ? ordered.ThenByDescending(o => o.TemplateHeader) : query.OrderByDescending(o => o.TemplateHeader);
                                break;
							case "TemplateFooter":
								query = isOrdered ? ordered.ThenBy(o => o.TemplateFooter) : query.OrderBy(o => o.TemplateFooter);
								 break;
							case "TemplateFooter_desc":
                                query = isOrdered ? ordered.ThenByDescending(o => o.TemplateFooter) : query.OrderByDescending(o => o.TemplateFooter);
                                break;
							case "TemplateConfig":
								query = isOrdered ? ordered.ThenBy(o => o.TemplateConfig) : query.OrderBy(o => o.TemplateConfig);
								 break;
							case "TemplateConfig_desc":
                                query = isOrdered ? ordered.ThenByDescending(o => o.TemplateConfig) : query.OrderByDescending(o => o.TemplateConfig);
                                break;
							case "LogoURL":
								query = isOrdered ? ordered.ThenBy(o => o.LogoURL) : query.OrderBy(o => o.LogoURL);
								 break;
							case "LogoURL_desc":
                                query = isOrdered ? ordered.ThenByDescending(o => o.LogoURL) : query.OrderByDescending(o => o.LogoURL);
                                break;
							case "BannerURL":
								query = isOrdered ? ordered.ThenBy(o => o.BannerURL) : query.OrderBy(o => o.BannerURL);
								 break;
							case "BannerURL_desc":
                                query = isOrdered ? ordered.ThenByDescending(o => o.BannerURL) : query.OrderByDescending(o => o.BannerURL);
                                break;
							case "ImageURL":
								query = isOrdered ? ordered.ThenBy(o => o.ImageURL) : query.OrderBy(o => o.ImageURL);
								 break;
							case "ImageURL_desc":
                                query = isOrdered ? ordered.ThenByDescending(o => o.ImageURL) : query.OrderByDescending(o => o.ImageURL);
                                break;
							case "BackgroundColor":
								query = isOrdered ? ordered.ThenBy(o => o.BackgroundColor) : query.OrderBy(o => o.BackgroundColor);
								 break;
							case "BackgroundColor_desc":
                                query = isOrdered ? ordered.ThenByDescending(o => o.BackgroundColor) : query.OrderByDescending(o => o.BackgroundColor);
                                break;
							case "IsHeadOfDepartment":
								query = isOrdered ? ordered.ThenBy(o => o.IsHeadOfDepartment) : query.OrderBy(o => o.IsHeadOfDepartment);
								 break;
							case "IsHeadOfDepartment_desc":
                                query = isOrdered ? ordered.ThenByDescending(o => o.IsHeadOfDepartment) : query.OrderByDescending(o => o.IsHeadOfDepartment);
                                break;
							case "VuViec":
								query = isOrdered ? ordered.ThenBy(o => o.VuViec) : query.OrderBy(o => o.VuViec);
								 break;
							case "VuViec_desc":
                                query = isOrdered ? ordered.ThenByDescending(o => o.VuViec) : query.OrderByDescending(o => o.VuViec);
                                break;
							case "IDPartner":
								query = isOrdered ? ordered.ThenBy(o => o.IDPartner) : query.OrderBy(o => o.IDPartner);
								 break;
							case "IDPartner_desc":
                                query = isOrdered ? ordered.ThenByDescending(o => o.IDPartner) : query.OrderByDescending(o => o.IDPartner);
                                break;
							case "ShortName":
								query = isOrdered ? ordered.ThenBy(o => o.ShortName) : query.OrderBy(o => o.ShortName);
								 break;
							case "ShortName_desc":
                                query = isOrdered ? ordered.ThenByDescending(o => o.ShortName) : query.OrderByDescending(o => o.ShortName);
                                break;
							case "Type":
								query = isOrdered ? ordered.ThenBy(o => o.Type) : query.OrderBy(o => o.Type);
								 break;
							case "Type_desc":
                                query = isOrdered ? ordered.ThenByDescending(o => o.Type) : query.OrderByDescending(o => o.Type);
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

        public static IQueryable<tbl_BRA_Branch> _pagingBuilder(IQueryable<tbl_BRA_Branch> query, Dictionary<string, string> QueryStrings)
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






