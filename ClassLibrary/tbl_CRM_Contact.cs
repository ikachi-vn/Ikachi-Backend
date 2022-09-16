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
    
    
    public partial class tbl_CRM_Contact
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public tbl_CRM_Contact()
        {
            this.tbl_CRM_Activity = new HashSet<tbl_CRM_Activity>();
            this.tbl_CRM_CampaignMember = new HashSet<tbl_CRM_CampaignMember>();
            this.tbl_CRM_ContactReference = new HashSet<tbl_CRM_ContactReference>();
            this.tbl_CRM_ContactReference1 = new HashSet<tbl_CRM_ContactReference>();
            this.tbl_CRM_Contact1 = new HashSet<tbl_CRM_Contact>();
            this.tbl_CRM_PartnerAddress = new HashSet<tbl_CRM_PartnerAddress>();
            this.tbl_CRM_Contract = new HashSet<tbl_CRM_Contract>();
            this.tbl_CRM_Customer = new HashSet<tbl_CRM_Customer>();
            this.tbl_CRM_Opportunity = new HashSet<tbl_CRM_Opportunity>();
            this.tbl_CRM_PartnerBankAccount = new HashSet<tbl_CRM_PartnerBankAccount>();
            this.tbl_CRM_Quotation = new HashSet<tbl_CRM_Quotation>();
            this.tbl_CRM_RouteDetail = new HashSet<tbl_CRM_RouteDetail>();
            this.tbl_PROD_ItemInVendor = new HashSet<tbl_PROD_ItemInVendor>();
            this.tbl_PURCHASE_Order = new HashSet<tbl_PURCHASE_Order>();
            this.tbl_PURCHASE_Order1 = new HashSet<tbl_PURCHASE_Order>();
            this.tbl_SALE_Order = new HashSet<tbl_SALE_Order>();
            this.tbl_SHIP_Shipment = new HashSet<tbl_SHIP_Shipment>();
            this.tbl_WMS_Receipt = new HashSet<tbl_WMS_Receipt>();
            this.tbl_WMS_Receipt1 = new HashSet<tbl_WMS_Receipt>();
            this.tbl_WMS_Receipt2 = new HashSet<tbl_WMS_Receipt>();
        }
    
        public Nullable<int> IDBranch { get; set; }
        public Nullable<int> IDIndividual { get; set; }
        public Nullable<int> IDSource { get; set; }
        public Nullable<int> IDSector { get; set; }
        public Nullable<int> IDIndustry { get; set; }
        public Nullable<int> IDRating { get; set; }
        public Nullable<int> IDOwner { get; set; }
        public Nullable<int> IDParent { get; set; }
        public int Id { get; set; }
        public string Code { get; set; }
        public string Title { get; set; }
        public string Name { get; set; }
        public string CompanyName { get; set; }
        public string TaxCode { get; set; }
        public string Fax { get; set; }
        public string Website { get; set; }
        public string BillingAddress { get; set; }
        public Nullable<int> NumberOfEmployees { get; set; }
        public decimal AnnualRevenue { get; set; }
        public string Remark { get; set; }
        public bool IsPersonal { get; set; }
        public Nullable<int> IDPriceListForVendor { get; set; }
        public string WorkPhone { get; set; }
        public string OtherPhone { get; set; }
        public bool DoNotCall { get; set; }
        public string Email { get; set; }
        public bool HasOptedOutOfEmail { get; set; }
        public Nullable<int> IDPaymentTermForVendor { get; set; }
        public Nullable<int> Sort { get; set; }
        public bool IsDisabled { get; set; }
        public bool IsDeleted { get; set; }
        public string CreatedBy { get; set; }
        public string ModifiedBy { get; set; }
        public System.DateTime CreatedDate { get; set; }
        public System.DateTime ModifiedDate { get; set; }
        public bool IsStaff { get; set; }
        public bool IsCustomer { get; set; }
        public bool IsVendor { get; set; }
        public bool IsBranch { get; set; }
        public bool IsWholeSale { get; set; }
        public Nullable<int> IDBusinessPartnerGroup { get; set; }
        public Nullable<int> IDPriceList { get; set; }
        public Nullable<int> IDPaymentTerm { get; set; }
        public bool IsDistributor { get; set; }
        public bool IsStorer { get; set; }
        public bool IsCarrier { get; set; }
        public bool IsOutlets { get; set; }
        public Nullable<int> RefId { get; set; }
        //List 0:1
        public virtual tbl_BANK_PaymentTerm tbl_BANK_PaymentTerm { get; set; }
        //List 0:1
        public virtual tbl_BP_Partner tbl_BP_Partner { get; set; }
        //List 0:1
        public virtual tbl_BRA_Branch tbl_BRA_Branch { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tbl_CRM_Activity> tbl_CRM_Activity { get; set; }
        //List 0:1
        public virtual tbl_CRM_BusinessPartnerGroup tbl_CRM_BusinessPartnerGroup { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tbl_CRM_CampaignMember> tbl_CRM_CampaignMember { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tbl_CRM_ContactReference> tbl_CRM_ContactReference { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tbl_CRM_ContactReference> tbl_CRM_ContactReference1 { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tbl_CRM_Contact> tbl_CRM_Contact1 { get; set; }
        //List 0:1
        public virtual tbl_CRM_Contact tbl_CRM_Contact2 { get; set; }
        //List 0:1
        public virtual tbl_HRM_Staff tbl_HRM_Staff { get; set; }
        //List 0:1
        public virtual tbl_WMS_PriceList tbl_WMS_PriceList { get; set; }
        //List 0:1
        public virtual tbl_WMS_PriceList tbl_WMS_PriceList1 { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tbl_CRM_PartnerAddress> tbl_CRM_PartnerAddress { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tbl_CRM_Contract> tbl_CRM_Contract { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tbl_CRM_Customer> tbl_CRM_Customer { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tbl_CRM_Opportunity> tbl_CRM_Opportunity { get; set; }
        //List 0:1
        public virtual tbl_CRM_Outlets tbl_CRM_Outlets { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tbl_CRM_PartnerBankAccount> tbl_CRM_PartnerBankAccount { get; set; }
        //List 0:1
        public virtual tbl_CRM_PersonInfo tbl_CRM_PersonInfo { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tbl_CRM_Quotation> tbl_CRM_Quotation { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tbl_CRM_RouteDetail> tbl_CRM_RouteDetail { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tbl_PROD_ItemInVendor> tbl_PROD_ItemInVendor { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tbl_PURCHASE_Order> tbl_PURCHASE_Order { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tbl_PURCHASE_Order> tbl_PURCHASE_Order1 { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tbl_SALE_Order> tbl_SALE_Order { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tbl_SHIP_Shipment> tbl_SHIP_Shipment { get; set; }
        //List 0:1
        public virtual tbl_WMS_Carrier tbl_WMS_Carrier { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tbl_WMS_Receipt> tbl_WMS_Receipt { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tbl_WMS_Receipt> tbl_WMS_Receipt1 { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tbl_WMS_Receipt> tbl_WMS_Receipt2 { get; set; }
        //List 0:1
        public virtual tbl_WMS_Storer tbl_WMS_Storer { get; set; }
        //List 0:1
        public virtual tbl_WMS_Vendor tbl_WMS_Vendor { get; set; }
    }
}


namespace DTOModel
{
	using System;
	public partial class DTO_CRM_Contact
	{
		public Nullable<int> IDBranch { get; set; }
		public Nullable<int> IDIndividual { get; set; }
		public Nullable<int> IDSource { get; set; }
		public Nullable<int> IDSector { get; set; }
		public Nullable<int> IDIndustry { get; set; }
		public Nullable<int> IDRating { get; set; }
		public Nullable<int> IDOwner { get; set; }
		public Nullable<int> IDParent { get; set; }
		public int Id { get; set; }
		public string Code { get; set; }
		public string Title { get; set; }
		public string Name { get; set; }
		public string CompanyName { get; set; }
		public string TaxCode { get; set; }
		public string Fax { get; set; }
		public string Website { get; set; }
		public string BillingAddress { get; set; }
		public Nullable<int> NumberOfEmployees { get; set; }
		public decimal AnnualRevenue { get; set; }
		public string Remark { get; set; }
		public bool IsPersonal { get; set; }
		public Nullable<int> IDPriceListForVendor { get; set; }
		public string WorkPhone { get; set; }
		public string OtherPhone { get; set; }
		public bool DoNotCall { get; set; }
		public string Email { get; set; }
		public bool HasOptedOutOfEmail { get; set; }
		public Nullable<int> IDPaymentTermForVendor { get; set; }
		public Nullable<int> Sort { get; set; }
		public bool IsDisabled { get; set; }
		public bool IsDeleted { get; set; }
		public string CreatedBy { get; set; }
		public string ModifiedBy { get; set; }
		public System.DateTime CreatedDate { get; set; }
		public System.DateTime ModifiedDate { get; set; }
		public bool IsStaff { get; set; }
		public bool IsCustomer { get; set; }
		public bool IsVendor { get; set; }
		public bool IsBranch { get; set; }
		public bool IsWholeSale { get; set; }
		public Nullable<int> IDBusinessPartnerGroup { get; set; }
		public Nullable<int> IDPriceList { get; set; }
		public Nullable<int> IDPaymentTerm { get; set; }
		public bool IsDistributor { get; set; }
		public bool IsStorer { get; set; }
		public bool IsCarrier { get; set; }
		public bool IsOutlets { get; set; }
		public Nullable<int> RefId { get; set; }
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

    public static partial class BS_CRM_Contact 
    {
        public static dynamic getSearch(AppEntities db, int IDBranch, int StaffID, Dictionary<string, string> QueryStrings)
        {
            return get(db, IDBranch,StaffID, QueryStrings);
        }

		public static IQueryable<DTO_CRM_Contact> get(AppEntities db, int IDBranch, int StaffID, Dictionary<string, string> QueryStrings)
        {
			var query = _queryBuilder(db, IDBranch, StaffID, QueryStrings);

            if (QueryStrings.Any(d => d.Key == "AllChildren")  || QueryStrings.Any(d => d.Key == "AllParent"))
            {

                List<DTO_CRM_Contact> allItems = db.tbl_CRM_Contact.Where(d => d.IsDeleted == false).Select(s => new DTO_CRM_Contact()
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
                    
                    query = db.tbl_CRM_Contact.Where(d => Ids.Contains(d.Id));
                }

            }

            query = _sortBuilder(query, QueryStrings);
            query = _pagingBuilder(query, QueryStrings);

			return toDTO(query);
        }

        public static List<int> findParent(List<DTO_CRM_Contact> allItems, int Id)
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

        public static List<int> findChildrent(List<DTO_CRM_Contact> allItems, int Id)
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
            package.Workbook.Properties.Title = "ART-DMS CRM_Contact";
            package.Workbook.Properties.Author = "hung.vu@codeart.vn";
            package.Workbook.Properties.Application = "ART-DMS";
            package.Workbook.Properties.Company = "A.R.T Distribution";

            ExcelWorkbook workBook = package.Workbook;
            if (workBook != null)
            {
                var ws = workBook.Worksheets.FirstOrDefault();
                var data = _queryBuilder(db, IDBranch, StaffID, QueryStrings).ToList();

                //var BANK_PaymentTermList = BS_BANK_PaymentTerm.get(db,IDBranch, StaffID,QueryStrings).Select(s => new ItemModel { Id = s.Id, Name = s.Name });
                //var BP_PartnerList = BS_BP_Partner.get(db,IDBranch, StaffID,QueryStrings).Select(s => new ItemModel { Id = s.Id, Name = s.Name });
                //var BRA_BranchList = BS_BRA_Branch.get(db,IDBranch, StaffID,QueryStrings).Select(s => new ItemModel { Id = s.Id, Name = s.Name });
                //var CRM_BusinessPartnerGroupList = BS_CRM_BusinessPartnerGroup.get(db,IDBranch, StaffID,QueryStrings).Select(s => new ItemModel { Id = s.Id, Name = s.Name });
                //var CRM_Contact2List = BS_CRM_Contact.get(db,IDBranch, StaffID,QueryStrings).Select(s => new ItemModel { Id = s.Id, Name = s.Name });
                //var HRM_StaffList = BS_HRM_Staff.get(db,IDBranch, StaffID,QueryStrings).Select(s => new ItemModel { Id = s.Id, Name = s.Name });
                //var WMS_PriceListList = BS_WMS_PriceList.get(db,IDBranch, StaffID,QueryStrings).Select(s => new ItemModel { Id = s.Id, Name = s.Name });
                //var WMS_PriceList1List = BS_WMS_PriceList.get(db,IDBranch, StaffID,QueryStrings).Select(s => new ItemModel { Id = s.Id, Name = s.Name });
                //var CRM_OutletsList = BS_CRM_Outlets.get(db,IDBranch, StaffID,QueryStrings).Select(s => new ItemModel { Id = s.Id, Name = s.Name });
                //var CRM_PersonInfoList = BS_CRM_PersonInfo.get(db,IDBranch, StaffID,QueryStrings).Select(s => new ItemModel { Id = s.Id, Name = s.Name });
                //var WMS_CarrierList = BS_WMS_Carrier.get(db,IDBranch, StaffID,QueryStrings).Select(s => new ItemModel { Id = s.Id, Name = s.Name });
                //var WMS_StorerList = BS_WMS_Storer.get(db,IDBranch, StaffID,QueryStrings).Select(s => new ItemModel { Id = s.Id, Name = s.Name });
                //var WMS_VendorList = BS_WMS_Vendor.get(db,IDBranch, StaffID,QueryStrings).Select(s => new ItemModel { Id = s.Id, Name = s.Name });
                 

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

		public static DTO_CRM_Contact getAnItem(AppEntities db, int IDBranch, int StaffID, int id)
        {
            var dbResult = db.tbl_CRM_Contact.Find(id);

			//if (dbResult == null || (IDBranch != 0 && dbResult.IDBranch != IDBranch))
			//	return null; 
			//else 
				return toDTO(dbResult);
			
        }
		
		public static DTO_CRM_Contact getAnItemByCode(AppEntities db, int IDBranch, int StaffID, string code)
        {
            var dbResult = db.tbl_CRM_Contact
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
            var dbitem = db.tbl_CRM_Contact.Find(Id);
            
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
					errorLog.logMessage("put_CRM_Contact",e);
                    result = false;
                }
            }
            else
                if (QueryStrings.Any(d => d.Key == "ForceCreate"))
                    result =  post(db, IDBranch, StaffID, item, Username) != null;
                
            return result;
        }

        public static void patchDynamicToDB(dynamic item, tbl_CRM_Contact dbitem, string Username)
        {
            Type type = typeof(tbl_CRM_Contact);
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

        public static void patchDTOtoDBValue( DTO_CRM_Contact item, tbl_CRM_Contact dbitem)
        {
            if (item == null){
                dbitem = null;
                return;
            }
            							
			dbitem.IDBranch = item.IDBranch;							
			dbitem.IDIndividual = item.IDIndividual;							
			dbitem.IDSource = item.IDSource;							
			dbitem.IDSector = item.IDSector;							
			dbitem.IDIndustry = item.IDIndustry;							
			dbitem.IDRating = item.IDRating;							
			dbitem.IDOwner = item.IDOwner;							
			dbitem.IDParent = item.IDParent;							
			dbitem.Code = item.Code;							
			dbitem.Title = item.Title;							
			dbitem.Name = item.Name;							
			dbitem.CompanyName = item.CompanyName;							
			dbitem.TaxCode = item.TaxCode;							
			dbitem.Fax = item.Fax;							
			dbitem.Website = item.Website;							
			dbitem.BillingAddress = item.BillingAddress;							
			dbitem.NumberOfEmployees = item.NumberOfEmployees;							
			dbitem.AnnualRevenue = item.AnnualRevenue;							
			dbitem.Remark = item.Remark;							
			dbitem.IsPersonal = item.IsPersonal;							
			dbitem.IDPriceListForVendor = item.IDPriceListForVendor;							
			dbitem.WorkPhone = item.WorkPhone;							
			dbitem.OtherPhone = item.OtherPhone;							
			dbitem.DoNotCall = item.DoNotCall;							
			dbitem.Email = item.Email;							
			dbitem.HasOptedOutOfEmail = item.HasOptedOutOfEmail;							
			dbitem.IDPaymentTermForVendor = item.IDPaymentTermForVendor;							
			dbitem.Sort = item.Sort;							
			dbitem.IsDisabled = item.IsDisabled;							
			dbitem.IsDeleted = item.IsDeleted;							
			dbitem.IsStaff = item.IsStaff;							
			dbitem.IsCustomer = item.IsCustomer;							
			dbitem.IsVendor = item.IsVendor;							
			dbitem.IsBranch = item.IsBranch;							
			dbitem.IsWholeSale = item.IsWholeSale;							
			dbitem.IDBusinessPartnerGroup = item.IDBusinessPartnerGroup;							
			dbitem.IDPriceList = item.IDPriceList;							
			dbitem.IDPaymentTerm = item.IDPaymentTerm;							
			dbitem.IsDistributor = item.IsDistributor;							
			dbitem.IsStorer = item.IsStorer;							
			dbitem.IsCarrier = item.IsCarrier;							
			dbitem.IsOutlets = item.IsOutlets;							
			dbitem.RefId = item.RefId;        }

		public static DTO_CRM_Contact post(AppEntities db, int IDBranch, int StaffID, dynamic item, string Username)
        {
            tbl_CRM_Contact dbitem = new tbl_CRM_Contact();
            if (item != null)
            {
                patchDynamicToDB(item, dbitem, Username);
                
				dbitem.CreatedBy = Username;
				dbitem.CreatedDate = DateTime.Now;				
                try
                {
					db.tbl_CRM_Contact.Add(dbitem);
                    db.SaveChanges();
				
                }
                catch (DbEntityValidationException e)
                {
					errorLog.logMessage("post_CRM_Contact",e);
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
                Type type = Type.GetType("BaseBusiness.BS_CRM_Contact, ClassLibrary");
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
                        var target = new tbl_CRM_Contact();
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
                    
                    tbl_CRM_Contact dbitem = new tbl_CRM_Contact();
                    if (it.Id == null || string.IsNullOrEmpty(it.Id.Value) || it.Id == "0")
                    {
                        dbitem = new tbl_CRM_Contact();
                        dbitem.CreatedBy = Username;
				        dbitem.CreatedDate = DateTime.Now;
                                            }
                    else
                    {
                        dbitem = db.tbl_CRM_Contact.Find((int)it.Id);
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
                        
                        if (dbitem.Id == 0) db.tbl_CRM_Contact.Add(dbitem);
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
                    errorLog.logMessage("post_CRM_Contact",e);
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

            var dbitems = db.tbl_CRM_Contact.Where(d => IDs.Contains(d.Id));
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
                    BS_Version.update_Version(db, IDBranch, "DTO_CRM_Contact", updateDate, Username);
                }
			
            }
            catch (DbEntityValidationException e)
            {
				errorLog.logMessage("delete_CRM_Contact",e);
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

			
            var dbitems = db.tbl_CRM_Contact.Where(d => IDs.Contains(d.Id));
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
                    BS_Version.update_Version(db, IDBranch, "DTO_CRM_Contact", updateDate, Username);
                }
			
            }
            catch (DbEntityValidationException e)
            {
				errorLog.logMessage("disable_CRM_Contact",e);
                result = false;
            }
            
            return result;
        }

		
		//---//
		public static bool check_Exists(AppEntities db, int id)
		{
             
            return db.tbl_CRM_Contact.Any(e => e.Id == id && e.IsDeleted == false);
            
		}
		
		public static bool check_Exists(AppEntities db, string Code)
		{
             
            return db.tbl_CRM_Contact.Any(e => e.Code == Code && e.IsDeleted == false);
            
		}
		
		//---//
		public static IQueryable<DTO_CRM_Contact> toDTO(IQueryable<tbl_CRM_Contact> query)
        {
			return query
			.Select(s => new DTO_CRM_Contact(){							
				IDBranch = s.IDBranch,							
				IDIndividual = s.IDIndividual,							
				IDSource = s.IDSource,							
				IDSector = s.IDSector,							
				IDIndustry = s.IDIndustry,							
				IDRating = s.IDRating,							
				IDOwner = s.IDOwner,							
				IDParent = s.IDParent,							
				Id = s.Id,							
				Code = s.Code,							
				Title = s.Title,							
				Name = s.Name,							
				CompanyName = s.CompanyName,							
				TaxCode = s.TaxCode,							
				Fax = s.Fax,							
				Website = s.Website,							
				BillingAddress = s.BillingAddress,							
				NumberOfEmployees = s.NumberOfEmployees,							
				AnnualRevenue = s.AnnualRevenue,							
				Remark = s.Remark,							
				IsPersonal = s.IsPersonal,							
				IDPriceListForVendor = s.IDPriceListForVendor,							
				WorkPhone = s.WorkPhone,							
				OtherPhone = s.OtherPhone,							
				DoNotCall = s.DoNotCall,							
				Email = s.Email,							
				HasOptedOutOfEmail = s.HasOptedOutOfEmail,							
				IDPaymentTermForVendor = s.IDPaymentTermForVendor,							
				Sort = s.Sort,							
				IsDisabled = s.IsDisabled,							
				IsDeleted = s.IsDeleted,							
				CreatedBy = s.CreatedBy,							
				ModifiedBy = s.ModifiedBy,							
				CreatedDate = s.CreatedDate,							
				ModifiedDate = s.ModifiedDate,							
				IsStaff = s.IsStaff,							
				IsCustomer = s.IsCustomer,							
				IsVendor = s.IsVendor,							
				IsBranch = s.IsBranch,							
				IsWholeSale = s.IsWholeSale,							
				IDBusinessPartnerGroup = s.IDBusinessPartnerGroup,							
				IDPriceList = s.IDPriceList,							
				IDPaymentTerm = s.IDPaymentTerm,							
				IsDistributor = s.IsDistributor,							
				IsStorer = s.IsStorer,							
				IsCarrier = s.IsCarrier,							
				IsOutlets = s.IsOutlets,							
				RefId = s.RefId,					
			});//.OrderBy(o => o.Sort == null).ThenBy(u => u.Sort);
                              
        }

		public static DTO_CRM_Contact toDTO(tbl_CRM_Contact dbResult)
        {
			if (dbResult != null)
			{
				return new DTO_CRM_Contact()
				{							
					IDBranch = dbResult.IDBranch,							
					IDIndividual = dbResult.IDIndividual,							
					IDSource = dbResult.IDSource,							
					IDSector = dbResult.IDSector,							
					IDIndustry = dbResult.IDIndustry,							
					IDRating = dbResult.IDRating,							
					IDOwner = dbResult.IDOwner,							
					IDParent = dbResult.IDParent,							
					Id = dbResult.Id,							
					Code = dbResult.Code,							
					Title = dbResult.Title,							
					Name = dbResult.Name,							
					CompanyName = dbResult.CompanyName,							
					TaxCode = dbResult.TaxCode,							
					Fax = dbResult.Fax,							
					Website = dbResult.Website,							
					BillingAddress = dbResult.BillingAddress,							
					NumberOfEmployees = dbResult.NumberOfEmployees,							
					AnnualRevenue = dbResult.AnnualRevenue,							
					Remark = dbResult.Remark,							
					IsPersonal = dbResult.IsPersonal,							
					IDPriceListForVendor = dbResult.IDPriceListForVendor,							
					WorkPhone = dbResult.WorkPhone,							
					OtherPhone = dbResult.OtherPhone,							
					DoNotCall = dbResult.DoNotCall,							
					Email = dbResult.Email,							
					HasOptedOutOfEmail = dbResult.HasOptedOutOfEmail,							
					IDPaymentTermForVendor = dbResult.IDPaymentTermForVendor,							
					Sort = dbResult.Sort,							
					IsDisabled = dbResult.IsDisabled,							
					IsDeleted = dbResult.IsDeleted,							
					CreatedBy = dbResult.CreatedBy,							
					ModifiedBy = dbResult.ModifiedBy,							
					CreatedDate = dbResult.CreatedDate,							
					ModifiedDate = dbResult.ModifiedDate,							
					IsStaff = dbResult.IsStaff,							
					IsCustomer = dbResult.IsCustomer,							
					IsVendor = dbResult.IsVendor,							
					IsBranch = dbResult.IsBranch,							
					IsWholeSale = dbResult.IsWholeSale,							
					IDBusinessPartnerGroup = dbResult.IDBusinessPartnerGroup,							
					IDPriceList = dbResult.IDPriceList,							
					IDPaymentTerm = dbResult.IDPaymentTerm,							
					IsDistributor = dbResult.IsDistributor,							
					IsStorer = dbResult.IsStorer,							
					IsCarrier = dbResult.IsCarrier,							
					IsOutlets = dbResult.IsOutlets,							
					RefId = dbResult.RefId,
				};
			}
			else
				return null; 
        }

		public static IQueryable<tbl_CRM_Contact> _queryBuilder(AppEntities db, int IDBranch, int StaffID, Dictionary<string, string> QueryStrings)
        {
            
			IQueryable<tbl_CRM_Contact> query = db.tbl_CRM_Contact.AsNoTracking();//.Where(d => d.IsDeleted == false);
			

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

			//Query IDIndividual (Nullable<int>)
			if (QueryStrings.Any(d => d.Key == "IDIndividual"))
            {
                var IDList = QueryStrings.FirstOrDefault(d => d.Key == "IDIndividual").Value.Replace("[", "").Replace("]", "").Split(',');
                List<int?> IDs = new List<int?>();
                foreach (var item in IDList)
                    if (int.TryParse(item, out int i))
                        IDs.Add(i);
					else if (item == "null")
						IDs.Add(null);
                if (IDs.Count > 0)
                    query = query.Where(d => IDs.Contains(d.IDIndividual));
////                    query = query.Where(d => IDs.Contains(d.IDIndividual));
//                    
            }

			//Query IDSource (Nullable<int>)
			if (QueryStrings.Any(d => d.Key == "IDSource"))
            {
                var IDList = QueryStrings.FirstOrDefault(d => d.Key == "IDSource").Value.Replace("[", "").Replace("]", "").Split(',');
                List<int?> IDs = new List<int?>();
                foreach (var item in IDList)
                    if (int.TryParse(item, out int i))
                        IDs.Add(i);
					else if (item == "null")
						IDs.Add(null);
                if (IDs.Count > 0)
                    query = query.Where(d => IDs.Contains(d.IDSource));
////                    query = query.Where(d => IDs.Contains(d.IDSource));
//                    
            }

			//Query IDSector (Nullable<int>)
			if (QueryStrings.Any(d => d.Key == "IDSector"))
            {
                var IDList = QueryStrings.FirstOrDefault(d => d.Key == "IDSector").Value.Replace("[", "").Replace("]", "").Split(',');
                List<int?> IDs = new List<int?>();
                foreach (var item in IDList)
                    if (int.TryParse(item, out int i))
                        IDs.Add(i);
					else if (item == "null")
						IDs.Add(null);
                if (IDs.Count > 0)
                    query = query.Where(d => IDs.Contains(d.IDSector));
////                    query = query.Where(d => IDs.Contains(d.IDSector));
//                    
            }

			//Query IDIndustry (Nullable<int>)
			if (QueryStrings.Any(d => d.Key == "IDIndustry"))
            {
                var IDList = QueryStrings.FirstOrDefault(d => d.Key == "IDIndustry").Value.Replace("[", "").Replace("]", "").Split(',');
                List<int?> IDs = new List<int?>();
                foreach (var item in IDList)
                    if (int.TryParse(item, out int i))
                        IDs.Add(i);
					else if (item == "null")
						IDs.Add(null);
                if (IDs.Count > 0)
                    query = query.Where(d => IDs.Contains(d.IDIndustry));
////                    query = query.Where(d => IDs.Contains(d.IDIndustry));
//                    
            }

			//Query IDRating (Nullable<int>)
			if (QueryStrings.Any(d => d.Key == "IDRating"))
            {
                var IDList = QueryStrings.FirstOrDefault(d => d.Key == "IDRating").Value.Replace("[", "").Replace("]", "").Split(',');
                List<int?> IDs = new List<int?>();
                foreach (var item in IDList)
                    if (int.TryParse(item, out int i))
                        IDs.Add(i);
					else if (item == "null")
						IDs.Add(null);
                if (IDs.Count > 0)
                    query = query.Where(d => IDs.Contains(d.IDRating));
////                    query = query.Where(d => IDs.Contains(d.IDRating));
//                    
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
            

			//Query CompanyName (string)
			if (QueryStrings.Any(d => d.Key == "CompanyName_eq") && !string.IsNullOrEmpty(QueryStrings.FirstOrDefault(d => d.Key == "CompanyName_eq").Value))
            {
                var keyword = QueryStrings.FirstOrDefault(d => d.Key == "CompanyName_eq").Value;
                query = query.Where(d=>d.CompanyName == keyword);
            }
            if (QueryStrings.Any(d => d.Key == "CompanyName") && !string.IsNullOrEmpty(QueryStrings.FirstOrDefault(d => d.Key == "CompanyName").Value))
            {
                var keyword = QueryStrings.FirstOrDefault(d => d.Key == "CompanyName").Value;
                query = query.Where(d=>d.CompanyName.Contains(keyword));
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
            

			//Query BillingAddress (string)
			if (QueryStrings.Any(d => d.Key == "BillingAddress_eq") && !string.IsNullOrEmpty(QueryStrings.FirstOrDefault(d => d.Key == "BillingAddress_eq").Value))
            {
                var keyword = QueryStrings.FirstOrDefault(d => d.Key == "BillingAddress_eq").Value;
                query = query.Where(d=>d.BillingAddress == keyword);
            }
            if (QueryStrings.Any(d => d.Key == "BillingAddress") && !string.IsNullOrEmpty(QueryStrings.FirstOrDefault(d => d.Key == "BillingAddress").Value))
            {
                var keyword = QueryStrings.FirstOrDefault(d => d.Key == "BillingAddress").Value;
                query = query.Where(d=>d.BillingAddress.Contains(keyword));
            }
            

			//Query NumberOfEmployees (Nullable<int>)
			if (QueryStrings.Any(d => d.Key == "NumberOfEmployeesFrom") && QueryStrings.Any(d => d.Key == "NumberOfEmployeesTo"))
                if (int.TryParse(QueryStrings.FirstOrDefault(d => d.Key == "NumberOfEmployeesFrom").Value, out int fromVal) && int.TryParse(QueryStrings.FirstOrDefault(d => d.Key == "NumberOfEmployeesTo").Value, out int toVal))
                    query = query.Where(d => fromVal <= d.NumberOfEmployees && d.NumberOfEmployees <= toVal);

			//Query AnnualRevenue (decimal)
			if (QueryStrings.Any(d => d.Key == "AnnualRevenueFrom") && QueryStrings.Any(d => d.Key == "AnnualRevenueTo"))
                if (decimal.TryParse(QueryStrings.FirstOrDefault(d => d.Key == "AnnualRevenueFrom").Value, out decimal fromVal) && decimal.TryParse(QueryStrings.FirstOrDefault(d => d.Key == "AnnualRevenueTo").Value, out decimal toVal))
                    query = query.Where(d => fromVal <= d.AnnualRevenue && d.AnnualRevenue <= toVal);
            
            if (QueryStrings.Any(d => d.Key == "AnnualRevenue"))
                if (decimal.TryParse(QueryStrings.FirstOrDefault(d => d.Key == "AnnualRevenue").Value, out decimal val))
                    query = query.Where(d => val == d.AnnualRevenue);


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
            

			//Query IsPersonal (bool)
			if (QueryStrings.Any(d => d.Key == "IsPersonal"))
            {
                var qValue = QueryStrings.FirstOrDefault(d => d.Key == "IsPersonal").Value;
                if (bool.TryParse(qValue, out bool qBoolValue))
                    query = query.Where(d => qBoolValue == d.IsPersonal);
            }

			//Query IDPriceListForVendor (Nullable<int>)
			if (QueryStrings.Any(d => d.Key == "IDPriceListForVendor"))
            {
                var IDList = QueryStrings.FirstOrDefault(d => d.Key == "IDPriceListForVendor").Value.Replace("[", "").Replace("]", "").Split(',');
                List<int?> IDs = new List<int?>();
                foreach (var item in IDList)
                    if (int.TryParse(item, out int i))
                        IDs.Add(i);
					else if (item == "null")
						IDs.Add(null);
                if (IDs.Count > 0)
                    query = query.Where(d => IDs.Contains(d.IDPriceListForVendor));
////                    query = query.Where(d => IDs.Contains(d.IDPriceListForVendor));
//                    
            }

			//Query WorkPhone (string)
			if (QueryStrings.Any(d => d.Key == "WorkPhone_eq") && !string.IsNullOrEmpty(QueryStrings.FirstOrDefault(d => d.Key == "WorkPhone_eq").Value))
            {
                var keyword = QueryStrings.FirstOrDefault(d => d.Key == "WorkPhone_eq").Value;
                query = query.Where(d=>d.WorkPhone == keyword);
            }
            if (QueryStrings.Any(d => d.Key == "WorkPhone") && !string.IsNullOrEmpty(QueryStrings.FirstOrDefault(d => d.Key == "WorkPhone").Value))
            {
                var keyword = QueryStrings.FirstOrDefault(d => d.Key == "WorkPhone").Value;
                query = query.Where(d=>d.WorkPhone.Contains(keyword));
            }
            

			//Query OtherPhone (string)
			if (QueryStrings.Any(d => d.Key == "OtherPhone_eq") && !string.IsNullOrEmpty(QueryStrings.FirstOrDefault(d => d.Key == "OtherPhone_eq").Value))
            {
                var keyword = QueryStrings.FirstOrDefault(d => d.Key == "OtherPhone_eq").Value;
                query = query.Where(d=>d.OtherPhone == keyword);
            }
            if (QueryStrings.Any(d => d.Key == "OtherPhone") && !string.IsNullOrEmpty(QueryStrings.FirstOrDefault(d => d.Key == "OtherPhone").Value))
            {
                var keyword = QueryStrings.FirstOrDefault(d => d.Key == "OtherPhone").Value;
                query = query.Where(d=>d.OtherPhone.Contains(keyword));
            }
            

			//Query DoNotCall (bool)
			if (QueryStrings.Any(d => d.Key == "DoNotCall"))
            {
                var qValue = QueryStrings.FirstOrDefault(d => d.Key == "DoNotCall").Value;
                if (bool.TryParse(qValue, out bool qBoolValue))
                    query = query.Where(d => qBoolValue == d.DoNotCall);
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
            

			//Query HasOptedOutOfEmail (bool)
			if (QueryStrings.Any(d => d.Key == "HasOptedOutOfEmail"))
            {
                var qValue = QueryStrings.FirstOrDefault(d => d.Key == "HasOptedOutOfEmail").Value;
                if (bool.TryParse(qValue, out bool qBoolValue))
                    query = query.Where(d => qBoolValue == d.HasOptedOutOfEmail);
            }

			//Query IDPaymentTermForVendor (Nullable<int>)
			if (QueryStrings.Any(d => d.Key == "IDPaymentTermForVendor"))
            {
                var IDList = QueryStrings.FirstOrDefault(d => d.Key == "IDPaymentTermForVendor").Value.Replace("[", "").Replace("]", "").Split(',');
                List<int?> IDs = new List<int?>();
                foreach (var item in IDList)
                    if (int.TryParse(item, out int i))
                        IDs.Add(i);
					else if (item == "null")
						IDs.Add(null);
                if (IDs.Count > 0)
                    query = query.Where(d => IDs.Contains(d.IDPaymentTermForVendor));
////                    query = query.Where(d => IDs.Contains(d.IDPaymentTermForVendor));
//                    
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


			//Query IsStaff (bool)
			if (QueryStrings.Any(d => d.Key == "IsStaff"))
            {
                var qValue = QueryStrings.FirstOrDefault(d => d.Key == "IsStaff").Value;
                if (bool.TryParse(qValue, out bool qBoolValue))
                    query = query.Where(d => qBoolValue == d.IsStaff);
            }

			//Query IsCustomer (bool)
			if (QueryStrings.Any(d => d.Key == "IsCustomer"))
            {
                var qValue = QueryStrings.FirstOrDefault(d => d.Key == "IsCustomer").Value;
                if (bool.TryParse(qValue, out bool qBoolValue))
                    query = query.Where(d => qBoolValue == d.IsCustomer);
            }

			//Query IsVendor (bool)
			if (QueryStrings.Any(d => d.Key == "IsVendor"))
            {
                var qValue = QueryStrings.FirstOrDefault(d => d.Key == "IsVendor").Value;
                if (bool.TryParse(qValue, out bool qBoolValue))
                    query = query.Where(d => qBoolValue == d.IsVendor);
            }

			//Query IsBranch (bool)
			if (QueryStrings.Any(d => d.Key == "IsBranch"))
            {
                var qValue = QueryStrings.FirstOrDefault(d => d.Key == "IsBranch").Value;
                if (bool.TryParse(qValue, out bool qBoolValue))
                    query = query.Where(d => qBoolValue == d.IsBranch);
            }

			//Query IsWholeSale (bool)
			if (QueryStrings.Any(d => d.Key == "IsWholeSale"))
            {
                var qValue = QueryStrings.FirstOrDefault(d => d.Key == "IsWholeSale").Value;
                if (bool.TryParse(qValue, out bool qBoolValue))
                    query = query.Where(d => qBoolValue == d.IsWholeSale);
            }

			//Query IDBusinessPartnerGroup (Nullable<int>)
			if (QueryStrings.Any(d => d.Key == "IDBusinessPartnerGroup"))
            {
                var IDList = QueryStrings.FirstOrDefault(d => d.Key == "IDBusinessPartnerGroup").Value.Replace("[", "").Replace("]", "").Split(',');
                List<int?> IDs = new List<int?>();
                foreach (var item in IDList)
                    if (int.TryParse(item, out int i))
                        IDs.Add(i);
					else if (item == "null")
						IDs.Add(null);
                if (IDs.Count > 0)
                    query = query.Where(d => IDs.Contains(d.IDBusinessPartnerGroup));
////                    query = query.Where(d => IDs.Contains(d.IDBusinessPartnerGroup));
//                    
            }

			//Query IDPriceList (Nullable<int>)
			if (QueryStrings.Any(d => d.Key == "IDPriceList"))
            {
                var IDList = QueryStrings.FirstOrDefault(d => d.Key == "IDPriceList").Value.Replace("[", "").Replace("]", "").Split(',');
                List<int?> IDs = new List<int?>();
                foreach (var item in IDList)
                    if (int.TryParse(item, out int i))
                        IDs.Add(i);
					else if (item == "null")
						IDs.Add(null);
                if (IDs.Count > 0)
                    query = query.Where(d => IDs.Contains(d.IDPriceList));
////                    query = query.Where(d => IDs.Contains(d.IDPriceList));
//                    
            }

			//Query IDPaymentTerm (Nullable<int>)
			if (QueryStrings.Any(d => d.Key == "IDPaymentTerm"))
            {
                var IDList = QueryStrings.FirstOrDefault(d => d.Key == "IDPaymentTerm").Value.Replace("[", "").Replace("]", "").Split(',');
                List<int?> IDs = new List<int?>();
                foreach (var item in IDList)
                    if (int.TryParse(item, out int i))
                        IDs.Add(i);
					else if (item == "null")
						IDs.Add(null);
                if (IDs.Count > 0)
                    query = query.Where(d => IDs.Contains(d.IDPaymentTerm));
////                    query = query.Where(d => IDs.Contains(d.IDPaymentTerm));
//                    
            }

			//Query IsDistributor (bool)
			if (QueryStrings.Any(d => d.Key == "IsDistributor"))
            {
                var qValue = QueryStrings.FirstOrDefault(d => d.Key == "IsDistributor").Value;
                if (bool.TryParse(qValue, out bool qBoolValue))
                    query = query.Where(d => qBoolValue == d.IsDistributor);
            }

			//Query IsStorer (bool)
			if (QueryStrings.Any(d => d.Key == "IsStorer"))
            {
                var qValue = QueryStrings.FirstOrDefault(d => d.Key == "IsStorer").Value;
                if (bool.TryParse(qValue, out bool qBoolValue))
                    query = query.Where(d => qBoolValue == d.IsStorer);
            }

			//Query IsCarrier (bool)
			if (QueryStrings.Any(d => d.Key == "IsCarrier"))
            {
                var qValue = QueryStrings.FirstOrDefault(d => d.Key == "IsCarrier").Value;
                if (bool.TryParse(qValue, out bool qBoolValue))
                    query = query.Where(d => qBoolValue == d.IsCarrier);
            }

			//Query IsOutlets (bool)
			if (QueryStrings.Any(d => d.Key == "IsOutlets"))
            {
                var qValue = QueryStrings.FirstOrDefault(d => d.Key == "IsOutlets").Value;
                if (bool.TryParse(qValue, out bool qBoolValue))
                    query = query.Where(d => qBoolValue == d.IsOutlets);
            }

			//Query RefId (Nullable<int>)
			if (QueryStrings.Any(d => d.Key == "RefIdFrom") && QueryStrings.Any(d => d.Key == "RefIdTo"))
                if (int.TryParse(QueryStrings.FirstOrDefault(d => d.Key == "RefIdFrom").Value, out int fromVal) && int.TryParse(QueryStrings.FirstOrDefault(d => d.Key == "RefIdTo").Value, out int toVal))
                    query = query.Where(d => fromVal <= d.RefId && d.RefId <= toVal);
            return query;
        }
		
        public static IQueryable<tbl_CRM_Contact> _sortBuilder(IQueryable<tbl_CRM_Contact> query, Dictionary<string, string> QueryStrings)
        {
            if (QueryStrings.Any(d => d.Key == "SortBy"))
            {
                var sorts = QueryStrings.FirstOrDefault(d => d.Key == "SortBy").Value.Replace("[", "").Replace("]", "").Split(',');
                
                foreach (var item in sorts)
                    if (!string.IsNullOrEmpty(item))
                    {
                        var ordered = query as IOrderedQueryable<tbl_CRM_Contact>;
                        bool isOrdered = ordered.ToString().IndexOf("ORDER BY") !=-1;

                        switch (item)
                        {
							case "IDBranch":
								query = isOrdered ? ordered.ThenBy(o => o.IDBranch) : query.OrderBy(o => o.IDBranch);
								 break;
							case "IDBranch_desc":
                                query = isOrdered ? ordered.ThenByDescending(o => o.IDBranch) : query.OrderByDescending(o => o.IDBranch);
                                break;
							case "IDIndividual":
								query = isOrdered ? ordered.ThenBy(o => o.IDIndividual) : query.OrderBy(o => o.IDIndividual);
								 break;
							case "IDIndividual_desc":
                                query = isOrdered ? ordered.ThenByDescending(o => o.IDIndividual) : query.OrderByDescending(o => o.IDIndividual);
                                break;
							case "IDSource":
								query = isOrdered ? ordered.ThenBy(o => o.IDSource) : query.OrderBy(o => o.IDSource);
								 break;
							case "IDSource_desc":
                                query = isOrdered ? ordered.ThenByDescending(o => o.IDSource) : query.OrderByDescending(o => o.IDSource);
                                break;
							case "IDSector":
								query = isOrdered ? ordered.ThenBy(o => o.IDSector) : query.OrderBy(o => o.IDSector);
								 break;
							case "IDSector_desc":
                                query = isOrdered ? ordered.ThenByDescending(o => o.IDSector) : query.OrderByDescending(o => o.IDSector);
                                break;
							case "IDIndustry":
								query = isOrdered ? ordered.ThenBy(o => o.IDIndustry) : query.OrderBy(o => o.IDIndustry);
								 break;
							case "IDIndustry_desc":
                                query = isOrdered ? ordered.ThenByDescending(o => o.IDIndustry) : query.OrderByDescending(o => o.IDIndustry);
                                break;
							case "IDRating":
								query = isOrdered ? ordered.ThenBy(o => o.IDRating) : query.OrderBy(o => o.IDRating);
								 break;
							case "IDRating_desc":
                                query = isOrdered ? ordered.ThenByDescending(o => o.IDRating) : query.OrderByDescending(o => o.IDRating);
                                break;
							case "IDOwner":
								query = isOrdered ? ordered.ThenBy(o => o.IDOwner) : query.OrderBy(o => o.IDOwner);
								 break;
							case "IDOwner_desc":
                                query = isOrdered ? ordered.ThenByDescending(o => o.IDOwner) : query.OrderByDescending(o => o.IDOwner);
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
							case "Title":
								query = isOrdered ? ordered.ThenBy(o => o.Title) : query.OrderBy(o => o.Title);
								 break;
							case "Title_desc":
                                query = isOrdered ? ordered.ThenByDescending(o => o.Title) : query.OrderByDescending(o => o.Title);
                                break;
							case "Name":
								query = isOrdered ? ordered.ThenBy(o => o.Name) : query.OrderBy(o => o.Name);
								 break;
							case "Name_desc":
                                query = isOrdered ? ordered.ThenByDescending(o => o.Name) : query.OrderByDescending(o => o.Name);
                                break;
							case "CompanyName":
								query = isOrdered ? ordered.ThenBy(o => o.CompanyName) : query.OrderBy(o => o.CompanyName);
								 break;
							case "CompanyName_desc":
                                query = isOrdered ? ordered.ThenByDescending(o => o.CompanyName) : query.OrderByDescending(o => o.CompanyName);
                                break;
							case "TaxCode":
								query = isOrdered ? ordered.ThenBy(o => o.TaxCode) : query.OrderBy(o => o.TaxCode);
								 break;
							case "TaxCode_desc":
                                query = isOrdered ? ordered.ThenByDescending(o => o.TaxCode) : query.OrderByDescending(o => o.TaxCode);
                                break;
							case "Fax":
								query = isOrdered ? ordered.ThenBy(o => o.Fax) : query.OrderBy(o => o.Fax);
								 break;
							case "Fax_desc":
                                query = isOrdered ? ordered.ThenByDescending(o => o.Fax) : query.OrderByDescending(o => o.Fax);
                                break;
							case "Website":
								query = isOrdered ? ordered.ThenBy(o => o.Website) : query.OrderBy(o => o.Website);
								 break;
							case "Website_desc":
                                query = isOrdered ? ordered.ThenByDescending(o => o.Website) : query.OrderByDescending(o => o.Website);
                                break;
							case "BillingAddress":
								query = isOrdered ? ordered.ThenBy(o => o.BillingAddress) : query.OrderBy(o => o.BillingAddress);
								 break;
							case "BillingAddress_desc":
                                query = isOrdered ? ordered.ThenByDescending(o => o.BillingAddress) : query.OrderByDescending(o => o.BillingAddress);
                                break;
							case "NumberOfEmployees":
								query = isOrdered ? ordered.ThenBy(o => o.NumberOfEmployees) : query.OrderBy(o => o.NumberOfEmployees);
								 break;
							case "NumberOfEmployees_desc":
                                query = isOrdered ? ordered.ThenByDescending(o => o.NumberOfEmployees) : query.OrderByDescending(o => o.NumberOfEmployees);
                                break;
							case "AnnualRevenue":
								query = isOrdered ? ordered.ThenBy(o => o.AnnualRevenue) : query.OrderBy(o => o.AnnualRevenue);
								 break;
							case "AnnualRevenue_desc":
                                query = isOrdered ? ordered.ThenByDescending(o => o.AnnualRevenue) : query.OrderByDescending(o => o.AnnualRevenue);
                                break;
							case "Remark":
								query = isOrdered ? ordered.ThenBy(o => o.Remark) : query.OrderBy(o => o.Remark);
								 break;
							case "Remark_desc":
                                query = isOrdered ? ordered.ThenByDescending(o => o.Remark) : query.OrderByDescending(o => o.Remark);
                                break;
							case "IsPersonal":
								query = isOrdered ? ordered.ThenBy(o => o.IsPersonal) : query.OrderBy(o => o.IsPersonal);
								 break;
							case "IsPersonal_desc":
                                query = isOrdered ? ordered.ThenByDescending(o => o.IsPersonal) : query.OrderByDescending(o => o.IsPersonal);
                                break;
							case "IDPriceListForVendor":
								query = isOrdered ? ordered.ThenBy(o => o.IDPriceListForVendor) : query.OrderBy(o => o.IDPriceListForVendor);
								 break;
							case "IDPriceListForVendor_desc":
                                query = isOrdered ? ordered.ThenByDescending(o => o.IDPriceListForVendor) : query.OrderByDescending(o => o.IDPriceListForVendor);
                                break;
							case "WorkPhone":
								query = isOrdered ? ordered.ThenBy(o => o.WorkPhone) : query.OrderBy(o => o.WorkPhone);
								 break;
							case "WorkPhone_desc":
                                query = isOrdered ? ordered.ThenByDescending(o => o.WorkPhone) : query.OrderByDescending(o => o.WorkPhone);
                                break;
							case "OtherPhone":
								query = isOrdered ? ordered.ThenBy(o => o.OtherPhone) : query.OrderBy(o => o.OtherPhone);
								 break;
							case "OtherPhone_desc":
                                query = isOrdered ? ordered.ThenByDescending(o => o.OtherPhone) : query.OrderByDescending(o => o.OtherPhone);
                                break;
							case "DoNotCall":
								query = isOrdered ? ordered.ThenBy(o => o.DoNotCall) : query.OrderBy(o => o.DoNotCall);
								 break;
							case "DoNotCall_desc":
                                query = isOrdered ? ordered.ThenByDescending(o => o.DoNotCall) : query.OrderByDescending(o => o.DoNotCall);
                                break;
							case "Email":
								query = isOrdered ? ordered.ThenBy(o => o.Email) : query.OrderBy(o => o.Email);
								 break;
							case "Email_desc":
                                query = isOrdered ? ordered.ThenByDescending(o => o.Email) : query.OrderByDescending(o => o.Email);
                                break;
							case "HasOptedOutOfEmail":
								query = isOrdered ? ordered.ThenBy(o => o.HasOptedOutOfEmail) : query.OrderBy(o => o.HasOptedOutOfEmail);
								 break;
							case "HasOptedOutOfEmail_desc":
                                query = isOrdered ? ordered.ThenByDescending(o => o.HasOptedOutOfEmail) : query.OrderByDescending(o => o.HasOptedOutOfEmail);
                                break;
							case "IDPaymentTermForVendor":
								query = isOrdered ? ordered.ThenBy(o => o.IDPaymentTermForVendor) : query.OrderBy(o => o.IDPaymentTermForVendor);
								 break;
							case "IDPaymentTermForVendor_desc":
                                query = isOrdered ? ordered.ThenByDescending(o => o.IDPaymentTermForVendor) : query.OrderByDescending(o => o.IDPaymentTermForVendor);
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
							case "IsStaff":
								query = isOrdered ? ordered.ThenBy(o => o.IsStaff) : query.OrderBy(o => o.IsStaff);
								 break;
							case "IsStaff_desc":
                                query = isOrdered ? ordered.ThenByDescending(o => o.IsStaff) : query.OrderByDescending(o => o.IsStaff);
                                break;
							case "IsCustomer":
								query = isOrdered ? ordered.ThenBy(o => o.IsCustomer) : query.OrderBy(o => o.IsCustomer);
								 break;
							case "IsCustomer_desc":
                                query = isOrdered ? ordered.ThenByDescending(o => o.IsCustomer) : query.OrderByDescending(o => o.IsCustomer);
                                break;
							case "IsVendor":
								query = isOrdered ? ordered.ThenBy(o => o.IsVendor) : query.OrderBy(o => o.IsVendor);
								 break;
							case "IsVendor_desc":
                                query = isOrdered ? ordered.ThenByDescending(o => o.IsVendor) : query.OrderByDescending(o => o.IsVendor);
                                break;
							case "IsBranch":
								query = isOrdered ? ordered.ThenBy(o => o.IsBranch) : query.OrderBy(o => o.IsBranch);
								 break;
							case "IsBranch_desc":
                                query = isOrdered ? ordered.ThenByDescending(o => o.IsBranch) : query.OrderByDescending(o => o.IsBranch);
                                break;
							case "IsWholeSale":
								query = isOrdered ? ordered.ThenBy(o => o.IsWholeSale) : query.OrderBy(o => o.IsWholeSale);
								 break;
							case "IsWholeSale_desc":
                                query = isOrdered ? ordered.ThenByDescending(o => o.IsWholeSale) : query.OrderByDescending(o => o.IsWholeSale);
                                break;
							case "IDBusinessPartnerGroup":
								query = isOrdered ? ordered.ThenBy(o => o.IDBusinessPartnerGroup) : query.OrderBy(o => o.IDBusinessPartnerGroup);
								 break;
							case "IDBusinessPartnerGroup_desc":
                                query = isOrdered ? ordered.ThenByDescending(o => o.IDBusinessPartnerGroup) : query.OrderByDescending(o => o.IDBusinessPartnerGroup);
                                break;
							case "IDPriceList":
								query = isOrdered ? ordered.ThenBy(o => o.IDPriceList) : query.OrderBy(o => o.IDPriceList);
								 break;
							case "IDPriceList_desc":
                                query = isOrdered ? ordered.ThenByDescending(o => o.IDPriceList) : query.OrderByDescending(o => o.IDPriceList);
                                break;
							case "IDPaymentTerm":
								query = isOrdered ? ordered.ThenBy(o => o.IDPaymentTerm) : query.OrderBy(o => o.IDPaymentTerm);
								 break;
							case "IDPaymentTerm_desc":
                                query = isOrdered ? ordered.ThenByDescending(o => o.IDPaymentTerm) : query.OrderByDescending(o => o.IDPaymentTerm);
                                break;
							case "IsDistributor":
								query = isOrdered ? ordered.ThenBy(o => o.IsDistributor) : query.OrderBy(o => o.IsDistributor);
								 break;
							case "IsDistributor_desc":
                                query = isOrdered ? ordered.ThenByDescending(o => o.IsDistributor) : query.OrderByDescending(o => o.IsDistributor);
                                break;
							case "IsStorer":
								query = isOrdered ? ordered.ThenBy(o => o.IsStorer) : query.OrderBy(o => o.IsStorer);
								 break;
							case "IsStorer_desc":
                                query = isOrdered ? ordered.ThenByDescending(o => o.IsStorer) : query.OrderByDescending(o => o.IsStorer);
                                break;
							case "IsCarrier":
								query = isOrdered ? ordered.ThenBy(o => o.IsCarrier) : query.OrderBy(o => o.IsCarrier);
								 break;
							case "IsCarrier_desc":
                                query = isOrdered ? ordered.ThenByDescending(o => o.IsCarrier) : query.OrderByDescending(o => o.IsCarrier);
                                break;
							case "IsOutlets":
								query = isOrdered ? ordered.ThenBy(o => o.IsOutlets) : query.OrderBy(o => o.IsOutlets);
								 break;
							case "IsOutlets_desc":
                                query = isOrdered ? ordered.ThenByDescending(o => o.IsOutlets) : query.OrderByDescending(o => o.IsOutlets);
                                break;
							case "RefId":
								query = isOrdered ? ordered.ThenBy(o => o.RefId) : query.OrderBy(o => o.RefId);
								 break;
							case "RefId_desc":
                                query = isOrdered ? ordered.ThenByDescending(o => o.RefId) : query.OrderByDescending(o => o.RefId);
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

        public static IQueryable<tbl_CRM_Contact> _pagingBuilder(IQueryable<tbl_CRM_Contact> query, Dictionary<string, string> QueryStrings)
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






