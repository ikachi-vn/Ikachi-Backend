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
    
    
    public partial class tbl_SALE_Order
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public tbl_SALE_Order()
        {
            this.tbl_BANK_IncomingPaymentDetail = new HashSet<tbl_BANK_IncomingPaymentDetail>();
            this.tbl_SALE_OrderDetail = new HashSet<tbl_SALE_OrderDetail>();
            this.tbl_SHIP_ShipmentDebt = new HashSet<tbl_SHIP_ShipmentDebt>();
            this.tbl_SHIP_ShipmentDetail = new HashSet<tbl_SHIP_ShipmentDetail>();
        }
    
        public int IDBranch { get; set; }
        public Nullable<int> IDOpportunity { get; set; }
        public Nullable<int> IDContact { get; set; }
        public Nullable<int> IDContract { get; set; }
        public int IDStatus { get; set; }
        public int IDType { get; set; }
        public Nullable<int> IDParent { get; set; }
        public int Id { get; set; }
        public string Code { get; set; }
        public string Name { get; set; }
        public string Remark { get; set; }
        public int IDOwner { get; set; }
        public System.DateTime OrderDate { get; set; }
        public decimal OriginalTotalBeforeDiscount { get; set; }
        public decimal OriginalPromotion { get; set; }
        public decimal OriginalDiscount1 { get; set; }
        public decimal OriginalDiscount2 { get; set; }
        public decimal OriginalDiscountByItem { get; set; }
        public decimal OriginalDiscountByGroup { get; set; }
        public decimal OriginalDiscountByLine { get; set; }
        public decimal OriginalDiscountByOrder { get; set; }
        public decimal OriginalDiscountFromSalesman { get; set; }
        public decimal OriginalTotalDiscount { get; set; }
        public decimal OriginalTotalAfterDiscount { get; set; }
        public decimal OriginalTax { get; set; }
        public decimal OriginalTotalAfterTax { get; set; }
        public decimal TotalBeforeDiscount { get; set; }
        public decimal ProductWeight { get; set; }
        public decimal ProductDimensions { get; set; }
        public decimal Discount1 { get; set; }
        public decimal Discount2 { get; set; }
        public decimal DiscountByItem { get; set; }
        public decimal Promotion { get; set; }
        public decimal DiscountByGroup { get; set; }
        public decimal DiscountByLine { get; set; }
        public decimal DiscountByOrder { get; set; }
        public decimal DiscountFromSalesman { get; set; }
        public decimal TotalDiscount { get; set; }
        public decimal TotalAfterDiscount { get; set; }
        public decimal Tax { get; set; }
        public decimal TotalAfterTax { get; set; }
        public decimal Received { get; set; }
        public decimal Debt { get; set; }
        public bool IsDebt { get; set; }
        public bool IsPaymentReceived { get; set; }
        public string SubType { get; set; }
        public Nullable<int> Sort { get; set; }
        public bool IsDisabled { get; set; }
        public bool IsDeleted { get; set; }
        public string CreatedBy { get; set; }
        public string ModifiedBy { get; set; }
        public System.DateTime CreatedDate { get; set; }
        public System.DateTime ModifiedDate { get; set; }
        public Nullable<System.DateTime> ExpectedDeliveryDate { get; set; }
        public Nullable<System.DateTime> ShippedDate { get; set; }
        public string ShippingAddress { get; set; }
        public string ShippingAddressRemark { get; set; }
        public string InvoiceNumber { get; set; }
        public Nullable<System.DateTime> InvoicDate { get; set; }
        public decimal TaxRate { get; set; }
        public string RefID { get; set; }
        public string RefOwner { get; set; }
        public string RefContact { get; set; }
        public string RefWarehouse { get; set; }
        public string RefDepartment { get; set; }
        public string RefShipper { get; set; }
        public bool IsCOD { get; set; }
        public decimal CODAmount { get; set; }
        public decimal ShipFee { get; set; }
        public bool ShipFeeBySender { get; set; }
        public bool IsSampleOrder { get; set; }
        public bool IsShipBySaleMan { get; set; }
        public bool IsUrgentOrders { get; set; }
        public Nullable<int> IDUrgentShipper { get; set; }
        public bool IsWholeSale { get; set; }
        public decimal ReceivedDiscountFromSalesman { get; set; }
        public decimal OldReceived { get; set; }
        public int IDAddress { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tbl_BANK_IncomingPaymentDetail> tbl_BANK_IncomingPaymentDetail { get; set; }
        //List 0:1
        public virtual tbl_BRA_Branch tbl_BRA_Branch { get; set; }
        //List 0:1
        public virtual tbl_CRM_Contact tbl_CRM_Contact { get; set; }
        //List 0:1
        public virtual tbl_CRM_Contract tbl_CRM_Contract { get; set; }
        //List 0:1
        public virtual tbl_CRM_PartnerAddress tbl_CRM_PartnerAddress { get; set; }
        //List 0:1
        public virtual tbl_HRM_Staff tbl_HRM_Staff { get; set; }
        //List 0:1
        public virtual tbl_SYS_Status tbl_SYS_Status { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tbl_SALE_OrderDetail> tbl_SALE_OrderDetail { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tbl_SHIP_ShipmentDebt> tbl_SHIP_ShipmentDebt { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tbl_SHIP_ShipmentDetail> tbl_SHIP_ShipmentDetail { get; set; }
    }
}


namespace DTOModel
{
	using System;
	public partial class DTO_SALE_Order
	{
		public int IDBranch { get; set; }
		public Nullable<int> IDOpportunity { get; set; }
		public Nullable<int> IDContact { get; set; }
		public Nullable<int> IDContract { get; set; }
		public int IDStatus { get; set; }
		public int IDType { get; set; }
		public Nullable<int> IDParent { get; set; }
		public int Id { get; set; }
		public string Code { get; set; }
		public string Name { get; set; }
		public string Remark { get; set; }
		public int IDOwner { get; set; }
		public System.DateTime OrderDate { get; set; }
		public decimal OriginalTotalBeforeDiscount { get; set; }
		public decimal OriginalPromotion { get; set; }
		public decimal OriginalDiscount1 { get; set; }
		public decimal OriginalDiscount2 { get; set; }
		public decimal OriginalDiscountByItem { get; set; }
		public decimal OriginalDiscountByGroup { get; set; }
		public decimal OriginalDiscountByLine { get; set; }
		public decimal OriginalDiscountByOrder { get; set; }
		public decimal OriginalDiscountFromSalesman { get; set; }
		public decimal OriginalTotalDiscount { get; set; }
		public decimal OriginalTotalAfterDiscount { get; set; }
		public decimal OriginalTax { get; set; }
		public decimal OriginalTotalAfterTax { get; set; }
		public decimal TotalBeforeDiscount { get; set; }
		public decimal ProductWeight { get; set; }
		public decimal ProductDimensions { get; set; }
		public decimal Discount1 { get; set; }
		public decimal Discount2 { get; set; }
		public decimal DiscountByItem { get; set; }
		public decimal Promotion { get; set; }
		public decimal DiscountByGroup { get; set; }
		public decimal DiscountByLine { get; set; }
		public decimal DiscountByOrder { get; set; }
		public decimal DiscountFromSalesman { get; set; }
		public decimal TotalDiscount { get; set; }
		public decimal TotalAfterDiscount { get; set; }
		public decimal Tax { get; set; }
		public decimal TotalAfterTax { get; set; }
		public decimal Received { get; set; }
		public decimal Debt { get; set; }
		public bool IsDebt { get; set; }
		public bool IsPaymentReceived { get; set; }
		public string SubType { get; set; }
		public Nullable<int> Sort { get; set; }
		public bool IsDisabled { get; set; }
		public bool IsDeleted { get; set; }
		public string CreatedBy { get; set; }
		public string ModifiedBy { get; set; }
		public System.DateTime CreatedDate { get; set; }
		public System.DateTime ModifiedDate { get; set; }
		public Nullable<System.DateTime> ExpectedDeliveryDate { get; set; }
		public Nullable<System.DateTime> ShippedDate { get; set; }
		public string ShippingAddress { get; set; }
		public string ShippingAddressRemark { get; set; }
		public string InvoiceNumber { get; set; }
		public Nullable<System.DateTime> InvoicDate { get; set; }
		public decimal TaxRate { get; set; }
		public string RefID { get; set; }
		public string RefOwner { get; set; }
		public string RefContact { get; set; }
		public string RefWarehouse { get; set; }
		public string RefDepartment { get; set; }
		public string RefShipper { get; set; }
		public bool IsCOD { get; set; }
		public decimal CODAmount { get; set; }
		public decimal ShipFee { get; set; }
		public bool ShipFeeBySender { get; set; }
		public bool IsSampleOrder { get; set; }
		public bool IsShipBySaleMan { get; set; }
		public bool IsUrgentOrders { get; set; }
		public Nullable<int> IDUrgentShipper { get; set; }
		public bool IsWholeSale { get; set; }
		public decimal ReceivedDiscountFromSalesman { get; set; }
		public decimal OldReceived { get; set; }
		public int IDAddress { get; set; }
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

    public static partial class BS_SALE_Order 
    {
        public static dynamic getSearch(AppEntities db, int IDBranch, int StaffID, Dictionary<string, string> QueryStrings)
        {
            return get(db, IDBranch,StaffID, QueryStrings);
        }

		public static IQueryable<DTO_SALE_Order> get(AppEntities db, int IDBranch, int StaffID, Dictionary<string, string> QueryStrings)
        {
			var query = _queryBuilder(db, IDBranch, StaffID, QueryStrings);

            if (QueryStrings.Any(d => d.Key == "AllChildren")  || QueryStrings.Any(d => d.Key == "AllParent"))
            {

                List<DTO_SALE_Order> allItems = db.tbl_SALE_Order.Where(d => d.IsDeleted == false).Select(s => new DTO_SALE_Order()
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
                    
                    query = db.tbl_SALE_Order.Where(d => Ids.Contains(d.Id));
                }

            }

            query = _sortBuilder(query, QueryStrings);
            query = _pagingBuilder(query, QueryStrings);

			return toDTO(query);
        }

        public static List<int> findParent(List<DTO_SALE_Order> allItems, int Id)
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

        public static List<int> findChildrent(List<DTO_SALE_Order> allItems, int Id)
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
            package.Workbook.Properties.Title = "ART-DMS SALE_Order";
            package.Workbook.Properties.Author = "hung.vu@codeart.vn";
            package.Workbook.Properties.Application = "ART-DMS";
            package.Workbook.Properties.Company = "A.R.T Distribution";

            ExcelWorkbook workBook = package.Workbook;
            if (workBook != null)
            {
                var ws = workBook.Worksheets.FirstOrDefault();
                var data = _queryBuilder(db, IDBranch, StaffID, QueryStrings).ToList();

                //var BRA_BranchList = BS_BRA_Branch.get(db,IDBranch, StaffID,QueryStrings).Select(s => new ItemModel { Id = s.Id, Name = s.Name });
                //var CRM_ContactList = BS_CRM_Contact.get(db,IDBranch, StaffID,QueryStrings).Select(s => new ItemModel { Id = s.Id, Name = s.Name });
                //var CRM_ContractList = BS_CRM_Contract.get(db,IDBranch, StaffID,QueryStrings).Select(s => new ItemModel { Id = s.Id, Name = s.Name });
                //var CRM_PartnerAddressList = BS_CRM_PartnerAddress.get(db,IDBranch, StaffID,QueryStrings).Select(s => new ItemModel { Id = s.Id, Name = s.Name });
                //var HRM_StaffList = BS_HRM_Staff.get(db,IDBranch, StaffID,QueryStrings).Select(s => new ItemModel { Id = s.Id, Name = s.Name });
                //var SYS_StatusList = BS_SYS_Status.get(db,IDBranch, StaffID,QueryStrings).Select(s => new ItemModel { Id = s.Id, Name = s.Name });
                 

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

		public static DTO_SALE_Order getAnItem(AppEntities db, int IDBranch, int StaffID, int id)
        {
            var dbResult = db.tbl_SALE_Order.Find(id);

			//if (dbResult == null || (IDBranch != 0 && dbResult.IDBranch != IDBranch))
			//	return null; 
			//else 
				return toDTO(dbResult);
			
        }
		
		public static DTO_SALE_Order getAnItemByCode(AppEntities db, int IDBranch, int StaffID, string code)
        {
            var dbResult = db.tbl_SALE_Order
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
            var dbitem = db.tbl_SALE_Order.Find(Id);
            
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
					errorLog.logMessage("put_SALE_Order",e);
                    result = false;
                }
            }
            else
                if (QueryStrings.Any(d => d.Key == "ForceCreate"))
                    result =  post(db, IDBranch, StaffID, item, Username) != null;
                
            return result;
        }

        public static void patchDynamicToDB(dynamic item, tbl_SALE_Order dbitem, string Username)
        {
            Type type = typeof(tbl_SALE_Order);
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

        public static void patchDTOtoDBValue( DTO_SALE_Order item, tbl_SALE_Order dbitem)
        {
            if (item == null){
                dbitem = null;
                return;
            }
            							
			dbitem.IDBranch = item.IDBranch;							
			dbitem.IDOpportunity = item.IDOpportunity;							
			dbitem.IDContact = item.IDContact;							
			dbitem.IDContract = item.IDContract;							
			dbitem.IDStatus = item.IDStatus;							
			dbitem.IDType = item.IDType;							
			dbitem.IDParent = item.IDParent;							
			dbitem.Code = item.Code;							
			dbitem.Name = item.Name;							
			dbitem.Remark = item.Remark;							
			dbitem.IDOwner = item.IDOwner;							
			dbitem.OrderDate = item.OrderDate;							
			dbitem.OriginalTotalBeforeDiscount = item.OriginalTotalBeforeDiscount;							
			dbitem.OriginalPromotion = item.OriginalPromotion;							
			dbitem.OriginalDiscount1 = item.OriginalDiscount1;							
			dbitem.OriginalDiscount2 = item.OriginalDiscount2;							
			dbitem.OriginalDiscountByItem = item.OriginalDiscountByItem;							
			dbitem.OriginalDiscountByGroup = item.OriginalDiscountByGroup;							
			dbitem.OriginalDiscountByLine = item.OriginalDiscountByLine;							
			dbitem.OriginalDiscountByOrder = item.OriginalDiscountByOrder;							
			dbitem.OriginalDiscountFromSalesman = item.OriginalDiscountFromSalesman;							
			dbitem.OriginalTotalDiscount = item.OriginalTotalDiscount;							
			dbitem.OriginalTotalAfterDiscount = item.OriginalTotalAfterDiscount;							
			dbitem.OriginalTax = item.OriginalTax;							
			dbitem.OriginalTotalAfterTax = item.OriginalTotalAfterTax;							
			dbitem.TotalBeforeDiscount = item.TotalBeforeDiscount;							
			dbitem.ProductWeight = item.ProductWeight;							
			dbitem.ProductDimensions = item.ProductDimensions;							
			dbitem.Discount1 = item.Discount1;							
			dbitem.Discount2 = item.Discount2;							
			dbitem.DiscountByItem = item.DiscountByItem;							
			dbitem.Promotion = item.Promotion;							
			dbitem.DiscountByGroup = item.DiscountByGroup;							
			dbitem.DiscountByLine = item.DiscountByLine;							
			dbitem.DiscountByOrder = item.DiscountByOrder;							
			dbitem.DiscountFromSalesman = item.DiscountFromSalesman;							
			dbitem.TotalDiscount = item.TotalDiscount;							
			dbitem.TotalAfterDiscount = item.TotalAfterDiscount;							
			dbitem.Tax = item.Tax;							
			dbitem.TotalAfterTax = item.TotalAfterTax;							
			dbitem.Received = item.Received;							
			dbitem.Debt = item.Debt;							
			dbitem.IsDebt = item.IsDebt;							
			dbitem.IsPaymentReceived = item.IsPaymentReceived;							
			dbitem.SubType = item.SubType;							
			dbitem.Sort = item.Sort;							
			dbitem.IsDisabled = item.IsDisabled;							
			dbitem.IsDeleted = item.IsDeleted;							
			dbitem.ExpectedDeliveryDate = item.ExpectedDeliveryDate;							
			dbitem.ShippedDate = item.ShippedDate;							
			dbitem.ShippingAddress = item.ShippingAddress;							
			dbitem.ShippingAddressRemark = item.ShippingAddressRemark;							
			dbitem.InvoiceNumber = item.InvoiceNumber;							
			dbitem.InvoicDate = item.InvoicDate;							
			dbitem.TaxRate = item.TaxRate;							
			dbitem.RefID = item.RefID;							
			dbitem.RefOwner = item.RefOwner;							
			dbitem.RefContact = item.RefContact;							
			dbitem.RefWarehouse = item.RefWarehouse;							
			dbitem.RefDepartment = item.RefDepartment;							
			dbitem.RefShipper = item.RefShipper;							
			dbitem.IsCOD = item.IsCOD;							
			dbitem.CODAmount = item.CODAmount;							
			dbitem.ShipFee = item.ShipFee;							
			dbitem.ShipFeeBySender = item.ShipFeeBySender;							
			dbitem.IsSampleOrder = item.IsSampleOrder;							
			dbitem.IsShipBySaleMan = item.IsShipBySaleMan;							
			dbitem.IsUrgentOrders = item.IsUrgentOrders;							
			dbitem.IDUrgentShipper = item.IDUrgentShipper;							
			dbitem.IsWholeSale = item.IsWholeSale;							
			dbitem.ReceivedDiscountFromSalesman = item.ReceivedDiscountFromSalesman;							
			dbitem.OldReceived = item.OldReceived;							
			dbitem.IDAddress = item.IDAddress;        }

		public static DTO_SALE_Order post(AppEntities db, int IDBranch, int StaffID, dynamic item, string Username)
        {
            tbl_SALE_Order dbitem = new tbl_SALE_Order();
            if (item != null)
            {
                patchDynamicToDB(item, dbitem, Username);
                
				dbitem.CreatedBy = Username;
				dbitem.CreatedDate = DateTime.Now;				
                try
                {
					db.tbl_SALE_Order.Add(dbitem);
                    db.SaveChanges();
				
                }
                catch (DbEntityValidationException e)
                {
					errorLog.logMessage("post_SALE_Order",e);
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
                Type type = Type.GetType("BaseBusiness.BS_SALE_Order, ClassLibrary");
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
                        var target = new tbl_SALE_Order();
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
                    
                    tbl_SALE_Order dbitem = new tbl_SALE_Order();
                    if (it.Id == null || string.IsNullOrEmpty(it.Id.Value) || it.Id == "0")
                    {
                        dbitem = new tbl_SALE_Order();
                        dbitem.CreatedBy = Username;
				        dbitem.CreatedDate = DateTime.Now;
                                            }
                    else
                    {
                        dbitem = db.tbl_SALE_Order.Find((int)it.Id);
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
                        
                        if (dbitem.Id == 0) db.tbl_SALE_Order.Add(dbitem);
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
                    errorLog.logMessage("post_SALE_Order",e);
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

            var dbitems = db.tbl_SALE_Order.Where(d => IDs.Contains(d.Id));
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
                    BS_Version.update_Version(db, IDBranch, "DTO_SALE_Order", updateDate, Username);
                }
			
            }
            catch (DbEntityValidationException e)
            {
				errorLog.logMessage("delete_SALE_Order",e);
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

			
            var dbitems = db.tbl_SALE_Order.Where(d => IDs.Contains(d.Id));
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
                    BS_Version.update_Version(db, IDBranch, "DTO_SALE_Order", updateDate, Username);
                }
			
            }
            catch (DbEntityValidationException e)
            {
				errorLog.logMessage("disable_SALE_Order",e);
                result = false;
            }
            
            return result;
        }

		
		//---//
		public static bool check_Exists(AppEntities db, int id)
		{
             
            return db.tbl_SALE_Order.Any(e => e.Id == id && e.IsDeleted == false);
            
		}
		
		public static bool check_Exists(AppEntities db, string Code)
		{
             
            return db.tbl_SALE_Order.Any(e => e.Code == Code && e.IsDeleted == false);
            
		}
		
		//---//
		public static IQueryable<DTO_SALE_Order> toDTO(IQueryable<tbl_SALE_Order> query)
        {
			return query
			.Select(s => new DTO_SALE_Order(){							
				IDBranch = s.IDBranch,							
				IDOpportunity = s.IDOpportunity,							
				IDContact = s.IDContact,							
				IDContract = s.IDContract,							
				IDStatus = s.IDStatus,							
				IDType = s.IDType,							
				IDParent = s.IDParent,							
				Id = s.Id,							
				Code = s.Code,							
				Name = s.Name,							
				Remark = s.Remark,							
				IDOwner = s.IDOwner,							
				OrderDate = s.OrderDate,							
				OriginalTotalBeforeDiscount = s.OriginalTotalBeforeDiscount,							
				OriginalPromotion = s.OriginalPromotion,							
				OriginalDiscount1 = s.OriginalDiscount1,							
				OriginalDiscount2 = s.OriginalDiscount2,							
				OriginalDiscountByItem = s.OriginalDiscountByItem,							
				OriginalDiscountByGroup = s.OriginalDiscountByGroup,							
				OriginalDiscountByLine = s.OriginalDiscountByLine,							
				OriginalDiscountByOrder = s.OriginalDiscountByOrder,							
				OriginalDiscountFromSalesman = s.OriginalDiscountFromSalesman,							
				OriginalTotalDiscount = s.OriginalTotalDiscount,							
				OriginalTotalAfterDiscount = s.OriginalTotalAfterDiscount,							
				OriginalTax = s.OriginalTax,							
				OriginalTotalAfterTax = s.OriginalTotalAfterTax,							
				TotalBeforeDiscount = s.TotalBeforeDiscount,							
				ProductWeight = s.ProductWeight,							
				ProductDimensions = s.ProductDimensions,							
				Discount1 = s.Discount1,							
				Discount2 = s.Discount2,							
				DiscountByItem = s.DiscountByItem,							
				Promotion = s.Promotion,							
				DiscountByGroup = s.DiscountByGroup,							
				DiscountByLine = s.DiscountByLine,							
				DiscountByOrder = s.DiscountByOrder,							
				DiscountFromSalesman = s.DiscountFromSalesman,							
				TotalDiscount = s.TotalDiscount,							
				TotalAfterDiscount = s.TotalAfterDiscount,							
				Tax = s.Tax,							
				TotalAfterTax = s.TotalAfterTax,							
				Received = s.Received,							
				Debt = s.Debt,							
				IsDebt = s.IsDebt,							
				IsPaymentReceived = s.IsPaymentReceived,							
				SubType = s.SubType,							
				Sort = s.Sort,							
				IsDisabled = s.IsDisabled,							
				IsDeleted = s.IsDeleted,							
				CreatedBy = s.CreatedBy,							
				ModifiedBy = s.ModifiedBy,							
				CreatedDate = s.CreatedDate,							
				ModifiedDate = s.ModifiedDate,							
				ExpectedDeliveryDate = s.ExpectedDeliveryDate,							
				ShippedDate = s.ShippedDate,							
				ShippingAddress = s.ShippingAddress,							
				ShippingAddressRemark = s.ShippingAddressRemark,							
				InvoiceNumber = s.InvoiceNumber,							
				InvoicDate = s.InvoicDate,							
				TaxRate = s.TaxRate,							
				RefID = s.RefID,							
				RefOwner = s.RefOwner,							
				RefContact = s.RefContact,							
				RefWarehouse = s.RefWarehouse,							
				RefDepartment = s.RefDepartment,							
				RefShipper = s.RefShipper,							
				IsCOD = s.IsCOD,							
				CODAmount = s.CODAmount,							
				ShipFee = s.ShipFee,							
				ShipFeeBySender = s.ShipFeeBySender,							
				IsSampleOrder = s.IsSampleOrder,							
				IsShipBySaleMan = s.IsShipBySaleMan,							
				IsUrgentOrders = s.IsUrgentOrders,							
				IDUrgentShipper = s.IDUrgentShipper,							
				IsWholeSale = s.IsWholeSale,							
				ReceivedDiscountFromSalesman = s.ReceivedDiscountFromSalesman,							
				OldReceived = s.OldReceived,							
				IDAddress = s.IDAddress,					
			});//.OrderBy(o => o.Sort == null).ThenBy(u => u.Sort);
                              
        }

		public static DTO_SALE_Order toDTO(tbl_SALE_Order dbResult)
        {
			if (dbResult != null)
			{
				return new DTO_SALE_Order()
				{							
					IDBranch = dbResult.IDBranch,							
					IDOpportunity = dbResult.IDOpportunity,							
					IDContact = dbResult.IDContact,							
					IDContract = dbResult.IDContract,							
					IDStatus = dbResult.IDStatus,							
					IDType = dbResult.IDType,							
					IDParent = dbResult.IDParent,							
					Id = dbResult.Id,							
					Code = dbResult.Code,							
					Name = dbResult.Name,							
					Remark = dbResult.Remark,							
					IDOwner = dbResult.IDOwner,							
					OrderDate = dbResult.OrderDate,							
					OriginalTotalBeforeDiscount = dbResult.OriginalTotalBeforeDiscount,							
					OriginalPromotion = dbResult.OriginalPromotion,							
					OriginalDiscount1 = dbResult.OriginalDiscount1,							
					OriginalDiscount2 = dbResult.OriginalDiscount2,							
					OriginalDiscountByItem = dbResult.OriginalDiscountByItem,							
					OriginalDiscountByGroup = dbResult.OriginalDiscountByGroup,							
					OriginalDiscountByLine = dbResult.OriginalDiscountByLine,							
					OriginalDiscountByOrder = dbResult.OriginalDiscountByOrder,							
					OriginalDiscountFromSalesman = dbResult.OriginalDiscountFromSalesman,							
					OriginalTotalDiscount = dbResult.OriginalTotalDiscount,							
					OriginalTotalAfterDiscount = dbResult.OriginalTotalAfterDiscount,							
					OriginalTax = dbResult.OriginalTax,							
					OriginalTotalAfterTax = dbResult.OriginalTotalAfterTax,							
					TotalBeforeDiscount = dbResult.TotalBeforeDiscount,							
					ProductWeight = dbResult.ProductWeight,							
					ProductDimensions = dbResult.ProductDimensions,							
					Discount1 = dbResult.Discount1,							
					Discount2 = dbResult.Discount2,							
					DiscountByItem = dbResult.DiscountByItem,							
					Promotion = dbResult.Promotion,							
					DiscountByGroup = dbResult.DiscountByGroup,							
					DiscountByLine = dbResult.DiscountByLine,							
					DiscountByOrder = dbResult.DiscountByOrder,							
					DiscountFromSalesman = dbResult.DiscountFromSalesman,							
					TotalDiscount = dbResult.TotalDiscount,							
					TotalAfterDiscount = dbResult.TotalAfterDiscount,							
					Tax = dbResult.Tax,							
					TotalAfterTax = dbResult.TotalAfterTax,							
					Received = dbResult.Received,							
					Debt = dbResult.Debt,							
					IsDebt = dbResult.IsDebt,							
					IsPaymentReceived = dbResult.IsPaymentReceived,							
					SubType = dbResult.SubType,							
					Sort = dbResult.Sort,							
					IsDisabled = dbResult.IsDisabled,							
					IsDeleted = dbResult.IsDeleted,							
					CreatedBy = dbResult.CreatedBy,							
					ModifiedBy = dbResult.ModifiedBy,							
					CreatedDate = dbResult.CreatedDate,							
					ModifiedDate = dbResult.ModifiedDate,							
					ExpectedDeliveryDate = dbResult.ExpectedDeliveryDate,							
					ShippedDate = dbResult.ShippedDate,							
					ShippingAddress = dbResult.ShippingAddress,							
					ShippingAddressRemark = dbResult.ShippingAddressRemark,							
					InvoiceNumber = dbResult.InvoiceNumber,							
					InvoicDate = dbResult.InvoicDate,							
					TaxRate = dbResult.TaxRate,							
					RefID = dbResult.RefID,							
					RefOwner = dbResult.RefOwner,							
					RefContact = dbResult.RefContact,							
					RefWarehouse = dbResult.RefWarehouse,							
					RefDepartment = dbResult.RefDepartment,							
					RefShipper = dbResult.RefShipper,							
					IsCOD = dbResult.IsCOD,							
					CODAmount = dbResult.CODAmount,							
					ShipFee = dbResult.ShipFee,							
					ShipFeeBySender = dbResult.ShipFeeBySender,							
					IsSampleOrder = dbResult.IsSampleOrder,							
					IsShipBySaleMan = dbResult.IsShipBySaleMan,							
					IsUrgentOrders = dbResult.IsUrgentOrders,							
					IDUrgentShipper = dbResult.IDUrgentShipper,							
					IsWholeSale = dbResult.IsWholeSale,							
					ReceivedDiscountFromSalesman = dbResult.ReceivedDiscountFromSalesman,							
					OldReceived = dbResult.OldReceived,							
					IDAddress = dbResult.IDAddress,
				};
			}
			else
				return null; 
        }

		public static IQueryable<tbl_SALE_Order> _queryBuilder(AppEntities db, int IDBranch, int StaffID, Dictionary<string, string> QueryStrings)
        {
            
			IQueryable<tbl_SALE_Order> query = db.tbl_SALE_Order.AsNoTracking();//.Where(d => d.IsDeleted == false);
			

			//Query keyword
			if (QueryStrings.Any(d => d.Key == "Keyword") && !string.IsNullOrEmpty(QueryStrings.FirstOrDefault(d => d.Key == "Keyword").Value))
            {
                var keyword = QueryStrings.FirstOrDefault(d => d.Key == "Keyword").Value;
                query = query.Where(d=>d.Name.Contains(keyword) || d.Code.Contains(keyword));
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

			//Query IDOpportunity (Nullable<int>)
			if (QueryStrings.Any(d => d.Key == "IDOpportunity"))
            {
                var IDList = QueryStrings.FirstOrDefault(d => d.Key == "IDOpportunity").Value.Replace("[", "").Replace("]", "").Split(',');
                List<int?> IDs = new List<int?>();
                foreach (var item in IDList)
                    if (int.TryParse(item, out int i))
                        IDs.Add(i);
					else if (item == "null")
						IDs.Add(null);
                if (IDs.Count > 0)
                    query = query.Where(d => IDs.Contains(d.IDOpportunity));
////                    query = query.Where(d => IDs.Contains(d.IDOpportunity));
//                    
            }

			//Query IDContact (Nullable<int>)
			if (QueryStrings.Any(d => d.Key == "IDContact"))
            {
                var IDList = QueryStrings.FirstOrDefault(d => d.Key == "IDContact").Value.Replace("[", "").Replace("]", "").Split(',');
                List<int?> IDs = new List<int?>();
                foreach (var item in IDList)
                    if (int.TryParse(item, out int i))
                        IDs.Add(i);
					else if (item == "null")
						IDs.Add(null);
                if (IDs.Count > 0)
                    query = query.Where(d => IDs.Contains(d.IDContact));
////                    query = query.Where(d => IDs.Contains(d.IDContact));
//                    
            }

			//Query IDContract (Nullable<int>)
			if (QueryStrings.Any(d => d.Key == "IDContract"))
            {
                var IDList = QueryStrings.FirstOrDefault(d => d.Key == "IDContract").Value.Replace("[", "").Replace("]", "").Split(',');
                List<int?> IDs = new List<int?>();
                foreach (var item in IDList)
                    if (int.TryParse(item, out int i))
                        IDs.Add(i);
					else if (item == "null")
						IDs.Add(null);
                if (IDs.Count > 0)
                    query = query.Where(d => IDs.Contains(d.IDContract));
////                    query = query.Where(d => IDs.Contains(d.IDContract));
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
            

			//Query IDOwner (int)
			if (QueryStrings.Any(d => d.Key == "IDOwner"))
            {
                var IDList = QueryStrings.FirstOrDefault(d => d.Key == "IDOwner").Value.Replace("[", "").Replace("]", "").Split(',');
                List<int> IDs = new List<int>();
                foreach (var item in IDList)
                    if (int.TryParse(item, out int i))
                        IDs.Add(i);
                if (IDs.Count > 0)
                    query = query.Where(d => IDs.Contains(d.IDOwner));
            }

			//Query OrderDate (System.DateTime)
			if (QueryStrings.Any(d => d.Key == "OrderDateFrom") && QueryStrings.Any(d => d.Key == "OrderDateTo"))
                if (DateTime.TryParse(QueryStrings.FirstOrDefault(d => d.Key == "OrderDateFrom").Value, out DateTime fromDate) && DateTime.TryParse(QueryStrings.FirstOrDefault(d => d.Key == "OrderDateTo").Value, out DateTime toDate))
                    query = query.Where(d => fromDate <= d.OrderDate && d.OrderDate <= toDate);

            if (QueryStrings.Any(d => d.Key == "OrderDate"))
                if (DateTime.TryParse(QueryStrings.FirstOrDefault(d => d.Key == "OrderDate").Value, out DateTime val))
                    query = query.Where(d => d.OrderDate != null && DbFunctions.TruncateTime(val) == DbFunctions.TruncateTime(d.OrderDate));


			//Query OriginalTotalBeforeDiscount (decimal)
			if (QueryStrings.Any(d => d.Key == "OriginalTotalBeforeDiscountFrom") && QueryStrings.Any(d => d.Key == "OriginalTotalBeforeDiscountTo"))
                if (decimal.TryParse(QueryStrings.FirstOrDefault(d => d.Key == "OriginalTotalBeforeDiscountFrom").Value, out decimal fromVal) && decimal.TryParse(QueryStrings.FirstOrDefault(d => d.Key == "OriginalTotalBeforeDiscountTo").Value, out decimal toVal))
                    query = query.Where(d => fromVal <= d.OriginalTotalBeforeDiscount && d.OriginalTotalBeforeDiscount <= toVal);
            
            if (QueryStrings.Any(d => d.Key == "OriginalTotalBeforeDiscount"))
                if (decimal.TryParse(QueryStrings.FirstOrDefault(d => d.Key == "OriginalTotalBeforeDiscount").Value, out decimal val))
                    query = query.Where(d => val == d.OriginalTotalBeforeDiscount);


			//Query OriginalPromotion (decimal)
			if (QueryStrings.Any(d => d.Key == "OriginalPromotionFrom") && QueryStrings.Any(d => d.Key == "OriginalPromotionTo"))
                if (decimal.TryParse(QueryStrings.FirstOrDefault(d => d.Key == "OriginalPromotionFrom").Value, out decimal fromVal) && decimal.TryParse(QueryStrings.FirstOrDefault(d => d.Key == "OriginalPromotionTo").Value, out decimal toVal))
                    query = query.Where(d => fromVal <= d.OriginalPromotion && d.OriginalPromotion <= toVal);
            
            if (QueryStrings.Any(d => d.Key == "OriginalPromotion"))
                if (decimal.TryParse(QueryStrings.FirstOrDefault(d => d.Key == "OriginalPromotion").Value, out decimal val))
                    query = query.Where(d => val == d.OriginalPromotion);


			//Query OriginalDiscount1 (decimal)
			if (QueryStrings.Any(d => d.Key == "OriginalDiscount1From") && QueryStrings.Any(d => d.Key == "OriginalDiscount1To"))
                if (decimal.TryParse(QueryStrings.FirstOrDefault(d => d.Key == "OriginalDiscount1From").Value, out decimal fromVal) && decimal.TryParse(QueryStrings.FirstOrDefault(d => d.Key == "OriginalDiscount1To").Value, out decimal toVal))
                    query = query.Where(d => fromVal <= d.OriginalDiscount1 && d.OriginalDiscount1 <= toVal);
            
            if (QueryStrings.Any(d => d.Key == "OriginalDiscount1"))
                if (decimal.TryParse(QueryStrings.FirstOrDefault(d => d.Key == "OriginalDiscount1").Value, out decimal val))
                    query = query.Where(d => val == d.OriginalDiscount1);


			//Query OriginalDiscount2 (decimal)
			if (QueryStrings.Any(d => d.Key == "OriginalDiscount2From") && QueryStrings.Any(d => d.Key == "OriginalDiscount2To"))
                if (decimal.TryParse(QueryStrings.FirstOrDefault(d => d.Key == "OriginalDiscount2From").Value, out decimal fromVal) && decimal.TryParse(QueryStrings.FirstOrDefault(d => d.Key == "OriginalDiscount2To").Value, out decimal toVal))
                    query = query.Where(d => fromVal <= d.OriginalDiscount2 && d.OriginalDiscount2 <= toVal);
            
            if (QueryStrings.Any(d => d.Key == "OriginalDiscount2"))
                if (decimal.TryParse(QueryStrings.FirstOrDefault(d => d.Key == "OriginalDiscount2").Value, out decimal val))
                    query = query.Where(d => val == d.OriginalDiscount2);


			//Query OriginalDiscountByItem (decimal)
			if (QueryStrings.Any(d => d.Key == "OriginalDiscountByItemFrom") && QueryStrings.Any(d => d.Key == "OriginalDiscountByItemTo"))
                if (decimal.TryParse(QueryStrings.FirstOrDefault(d => d.Key == "OriginalDiscountByItemFrom").Value, out decimal fromVal) && decimal.TryParse(QueryStrings.FirstOrDefault(d => d.Key == "OriginalDiscountByItemTo").Value, out decimal toVal))
                    query = query.Where(d => fromVal <= d.OriginalDiscountByItem && d.OriginalDiscountByItem <= toVal);
            
            if (QueryStrings.Any(d => d.Key == "OriginalDiscountByItem"))
                if (decimal.TryParse(QueryStrings.FirstOrDefault(d => d.Key == "OriginalDiscountByItem").Value, out decimal val))
                    query = query.Where(d => val == d.OriginalDiscountByItem);


			//Query OriginalDiscountByGroup (decimal)
			if (QueryStrings.Any(d => d.Key == "OriginalDiscountByGroupFrom") && QueryStrings.Any(d => d.Key == "OriginalDiscountByGroupTo"))
                if (decimal.TryParse(QueryStrings.FirstOrDefault(d => d.Key == "OriginalDiscountByGroupFrom").Value, out decimal fromVal) && decimal.TryParse(QueryStrings.FirstOrDefault(d => d.Key == "OriginalDiscountByGroupTo").Value, out decimal toVal))
                    query = query.Where(d => fromVal <= d.OriginalDiscountByGroup && d.OriginalDiscountByGroup <= toVal);
            
            if (QueryStrings.Any(d => d.Key == "OriginalDiscountByGroup"))
                if (decimal.TryParse(QueryStrings.FirstOrDefault(d => d.Key == "OriginalDiscountByGroup").Value, out decimal val))
                    query = query.Where(d => val == d.OriginalDiscountByGroup);


			//Query OriginalDiscountByLine (decimal)
			if (QueryStrings.Any(d => d.Key == "OriginalDiscountByLineFrom") && QueryStrings.Any(d => d.Key == "OriginalDiscountByLineTo"))
                if (decimal.TryParse(QueryStrings.FirstOrDefault(d => d.Key == "OriginalDiscountByLineFrom").Value, out decimal fromVal) && decimal.TryParse(QueryStrings.FirstOrDefault(d => d.Key == "OriginalDiscountByLineTo").Value, out decimal toVal))
                    query = query.Where(d => fromVal <= d.OriginalDiscountByLine && d.OriginalDiscountByLine <= toVal);
            
            if (QueryStrings.Any(d => d.Key == "OriginalDiscountByLine"))
                if (decimal.TryParse(QueryStrings.FirstOrDefault(d => d.Key == "OriginalDiscountByLine").Value, out decimal val))
                    query = query.Where(d => val == d.OriginalDiscountByLine);


			//Query OriginalDiscountByOrder (decimal)
			if (QueryStrings.Any(d => d.Key == "OriginalDiscountByOrderFrom") && QueryStrings.Any(d => d.Key == "OriginalDiscountByOrderTo"))
                if (decimal.TryParse(QueryStrings.FirstOrDefault(d => d.Key == "OriginalDiscountByOrderFrom").Value, out decimal fromVal) && decimal.TryParse(QueryStrings.FirstOrDefault(d => d.Key == "OriginalDiscountByOrderTo").Value, out decimal toVal))
                    query = query.Where(d => fromVal <= d.OriginalDiscountByOrder && d.OriginalDiscountByOrder <= toVal);
            
            if (QueryStrings.Any(d => d.Key == "OriginalDiscountByOrder"))
                if (decimal.TryParse(QueryStrings.FirstOrDefault(d => d.Key == "OriginalDiscountByOrder").Value, out decimal val))
                    query = query.Where(d => val == d.OriginalDiscountByOrder);


			//Query OriginalDiscountFromSalesman (decimal)
			if (QueryStrings.Any(d => d.Key == "OriginalDiscountFromSalesmanFrom") && QueryStrings.Any(d => d.Key == "OriginalDiscountFromSalesmanTo"))
                if (decimal.TryParse(QueryStrings.FirstOrDefault(d => d.Key == "OriginalDiscountFromSalesmanFrom").Value, out decimal fromVal) && decimal.TryParse(QueryStrings.FirstOrDefault(d => d.Key == "OriginalDiscountFromSalesmanTo").Value, out decimal toVal))
                    query = query.Where(d => fromVal <= d.OriginalDiscountFromSalesman && d.OriginalDiscountFromSalesman <= toVal);
            
            if (QueryStrings.Any(d => d.Key == "OriginalDiscountFromSalesman"))
                if (decimal.TryParse(QueryStrings.FirstOrDefault(d => d.Key == "OriginalDiscountFromSalesman").Value, out decimal val))
                    query = query.Where(d => val == d.OriginalDiscountFromSalesman);


			//Query OriginalTotalDiscount (decimal)
			if (QueryStrings.Any(d => d.Key == "OriginalTotalDiscountFrom") && QueryStrings.Any(d => d.Key == "OriginalTotalDiscountTo"))
                if (decimal.TryParse(QueryStrings.FirstOrDefault(d => d.Key == "OriginalTotalDiscountFrom").Value, out decimal fromVal) && decimal.TryParse(QueryStrings.FirstOrDefault(d => d.Key == "OriginalTotalDiscountTo").Value, out decimal toVal))
                    query = query.Where(d => fromVal <= d.OriginalTotalDiscount && d.OriginalTotalDiscount <= toVal);
            
            if (QueryStrings.Any(d => d.Key == "OriginalTotalDiscount"))
                if (decimal.TryParse(QueryStrings.FirstOrDefault(d => d.Key == "OriginalTotalDiscount").Value, out decimal val))
                    query = query.Where(d => val == d.OriginalTotalDiscount);


			//Query OriginalTotalAfterDiscount (decimal)
			if (QueryStrings.Any(d => d.Key == "OriginalTotalAfterDiscountFrom") && QueryStrings.Any(d => d.Key == "OriginalTotalAfterDiscountTo"))
                if (decimal.TryParse(QueryStrings.FirstOrDefault(d => d.Key == "OriginalTotalAfterDiscountFrom").Value, out decimal fromVal) && decimal.TryParse(QueryStrings.FirstOrDefault(d => d.Key == "OriginalTotalAfterDiscountTo").Value, out decimal toVal))
                    query = query.Where(d => fromVal <= d.OriginalTotalAfterDiscount && d.OriginalTotalAfterDiscount <= toVal);
            
            if (QueryStrings.Any(d => d.Key == "OriginalTotalAfterDiscount"))
                if (decimal.TryParse(QueryStrings.FirstOrDefault(d => d.Key == "OriginalTotalAfterDiscount").Value, out decimal val))
                    query = query.Where(d => val == d.OriginalTotalAfterDiscount);


			//Query OriginalTax (decimal)
			if (QueryStrings.Any(d => d.Key == "OriginalTaxFrom") && QueryStrings.Any(d => d.Key == "OriginalTaxTo"))
                if (decimal.TryParse(QueryStrings.FirstOrDefault(d => d.Key == "OriginalTaxFrom").Value, out decimal fromVal) && decimal.TryParse(QueryStrings.FirstOrDefault(d => d.Key == "OriginalTaxTo").Value, out decimal toVal))
                    query = query.Where(d => fromVal <= d.OriginalTax && d.OriginalTax <= toVal);
            
            if (QueryStrings.Any(d => d.Key == "OriginalTax"))
                if (decimal.TryParse(QueryStrings.FirstOrDefault(d => d.Key == "OriginalTax").Value, out decimal val))
                    query = query.Where(d => val == d.OriginalTax);


			//Query OriginalTotalAfterTax (decimal)
			if (QueryStrings.Any(d => d.Key == "OriginalTotalAfterTaxFrom") && QueryStrings.Any(d => d.Key == "OriginalTotalAfterTaxTo"))
                if (decimal.TryParse(QueryStrings.FirstOrDefault(d => d.Key == "OriginalTotalAfterTaxFrom").Value, out decimal fromVal) && decimal.TryParse(QueryStrings.FirstOrDefault(d => d.Key == "OriginalTotalAfterTaxTo").Value, out decimal toVal))
                    query = query.Where(d => fromVal <= d.OriginalTotalAfterTax && d.OriginalTotalAfterTax <= toVal);
            
            if (QueryStrings.Any(d => d.Key == "OriginalTotalAfterTax"))
                if (decimal.TryParse(QueryStrings.FirstOrDefault(d => d.Key == "OriginalTotalAfterTax").Value, out decimal val))
                    query = query.Where(d => val == d.OriginalTotalAfterTax);


			//Query TotalBeforeDiscount (decimal)
			if (QueryStrings.Any(d => d.Key == "TotalBeforeDiscountFrom") && QueryStrings.Any(d => d.Key == "TotalBeforeDiscountTo"))
                if (decimal.TryParse(QueryStrings.FirstOrDefault(d => d.Key == "TotalBeforeDiscountFrom").Value, out decimal fromVal) && decimal.TryParse(QueryStrings.FirstOrDefault(d => d.Key == "TotalBeforeDiscountTo").Value, out decimal toVal))
                    query = query.Where(d => fromVal <= d.TotalBeforeDiscount && d.TotalBeforeDiscount <= toVal);
            
            if (QueryStrings.Any(d => d.Key == "TotalBeforeDiscount"))
                if (decimal.TryParse(QueryStrings.FirstOrDefault(d => d.Key == "TotalBeforeDiscount").Value, out decimal val))
                    query = query.Where(d => val == d.TotalBeforeDiscount);


			//Query ProductWeight (decimal)
			if (QueryStrings.Any(d => d.Key == "ProductWeightFrom") && QueryStrings.Any(d => d.Key == "ProductWeightTo"))
                if (decimal.TryParse(QueryStrings.FirstOrDefault(d => d.Key == "ProductWeightFrom").Value, out decimal fromVal) && decimal.TryParse(QueryStrings.FirstOrDefault(d => d.Key == "ProductWeightTo").Value, out decimal toVal))
                    query = query.Where(d => fromVal <= d.ProductWeight && d.ProductWeight <= toVal);
            
            if (QueryStrings.Any(d => d.Key == "ProductWeight"))
                if (decimal.TryParse(QueryStrings.FirstOrDefault(d => d.Key == "ProductWeight").Value, out decimal val))
                    query = query.Where(d => val == d.ProductWeight);


			//Query ProductDimensions (decimal)
			if (QueryStrings.Any(d => d.Key == "ProductDimensionsFrom") && QueryStrings.Any(d => d.Key == "ProductDimensionsTo"))
                if (decimal.TryParse(QueryStrings.FirstOrDefault(d => d.Key == "ProductDimensionsFrom").Value, out decimal fromVal) && decimal.TryParse(QueryStrings.FirstOrDefault(d => d.Key == "ProductDimensionsTo").Value, out decimal toVal))
                    query = query.Where(d => fromVal <= d.ProductDimensions && d.ProductDimensions <= toVal);
            
            if (QueryStrings.Any(d => d.Key == "ProductDimensions"))
                if (decimal.TryParse(QueryStrings.FirstOrDefault(d => d.Key == "ProductDimensions").Value, out decimal val))
                    query = query.Where(d => val == d.ProductDimensions);


			//Query Discount1 (decimal)
			if (QueryStrings.Any(d => d.Key == "Discount1From") && QueryStrings.Any(d => d.Key == "Discount1To"))
                if (decimal.TryParse(QueryStrings.FirstOrDefault(d => d.Key == "Discount1From").Value, out decimal fromVal) && decimal.TryParse(QueryStrings.FirstOrDefault(d => d.Key == "Discount1To").Value, out decimal toVal))
                    query = query.Where(d => fromVal <= d.Discount1 && d.Discount1 <= toVal);
            
            if (QueryStrings.Any(d => d.Key == "Discount1"))
                if (decimal.TryParse(QueryStrings.FirstOrDefault(d => d.Key == "Discount1").Value, out decimal val))
                    query = query.Where(d => val == d.Discount1);


			//Query Discount2 (decimal)
			if (QueryStrings.Any(d => d.Key == "Discount2From") && QueryStrings.Any(d => d.Key == "Discount2To"))
                if (decimal.TryParse(QueryStrings.FirstOrDefault(d => d.Key == "Discount2From").Value, out decimal fromVal) && decimal.TryParse(QueryStrings.FirstOrDefault(d => d.Key == "Discount2To").Value, out decimal toVal))
                    query = query.Where(d => fromVal <= d.Discount2 && d.Discount2 <= toVal);
            
            if (QueryStrings.Any(d => d.Key == "Discount2"))
                if (decimal.TryParse(QueryStrings.FirstOrDefault(d => d.Key == "Discount2").Value, out decimal val))
                    query = query.Where(d => val == d.Discount2);


			//Query DiscountByItem (decimal)
			if (QueryStrings.Any(d => d.Key == "DiscountByItemFrom") && QueryStrings.Any(d => d.Key == "DiscountByItemTo"))
                if (decimal.TryParse(QueryStrings.FirstOrDefault(d => d.Key == "DiscountByItemFrom").Value, out decimal fromVal) && decimal.TryParse(QueryStrings.FirstOrDefault(d => d.Key == "DiscountByItemTo").Value, out decimal toVal))
                    query = query.Where(d => fromVal <= d.DiscountByItem && d.DiscountByItem <= toVal);
            
            if (QueryStrings.Any(d => d.Key == "DiscountByItem"))
                if (decimal.TryParse(QueryStrings.FirstOrDefault(d => d.Key == "DiscountByItem").Value, out decimal val))
                    query = query.Where(d => val == d.DiscountByItem);


			//Query Promotion (decimal)
			if (QueryStrings.Any(d => d.Key == "PromotionFrom") && QueryStrings.Any(d => d.Key == "PromotionTo"))
                if (decimal.TryParse(QueryStrings.FirstOrDefault(d => d.Key == "PromotionFrom").Value, out decimal fromVal) && decimal.TryParse(QueryStrings.FirstOrDefault(d => d.Key == "PromotionTo").Value, out decimal toVal))
                    query = query.Where(d => fromVal <= d.Promotion && d.Promotion <= toVal);
            
            if (QueryStrings.Any(d => d.Key == "Promotion"))
                if (decimal.TryParse(QueryStrings.FirstOrDefault(d => d.Key == "Promotion").Value, out decimal val))
                    query = query.Where(d => val == d.Promotion);


			//Query DiscountByGroup (decimal)
			if (QueryStrings.Any(d => d.Key == "DiscountByGroupFrom") && QueryStrings.Any(d => d.Key == "DiscountByGroupTo"))
                if (decimal.TryParse(QueryStrings.FirstOrDefault(d => d.Key == "DiscountByGroupFrom").Value, out decimal fromVal) && decimal.TryParse(QueryStrings.FirstOrDefault(d => d.Key == "DiscountByGroupTo").Value, out decimal toVal))
                    query = query.Where(d => fromVal <= d.DiscountByGroup && d.DiscountByGroup <= toVal);
            
            if (QueryStrings.Any(d => d.Key == "DiscountByGroup"))
                if (decimal.TryParse(QueryStrings.FirstOrDefault(d => d.Key == "DiscountByGroup").Value, out decimal val))
                    query = query.Where(d => val == d.DiscountByGroup);


			//Query DiscountByLine (decimal)
			if (QueryStrings.Any(d => d.Key == "DiscountByLineFrom") && QueryStrings.Any(d => d.Key == "DiscountByLineTo"))
                if (decimal.TryParse(QueryStrings.FirstOrDefault(d => d.Key == "DiscountByLineFrom").Value, out decimal fromVal) && decimal.TryParse(QueryStrings.FirstOrDefault(d => d.Key == "DiscountByLineTo").Value, out decimal toVal))
                    query = query.Where(d => fromVal <= d.DiscountByLine && d.DiscountByLine <= toVal);
            
            if (QueryStrings.Any(d => d.Key == "DiscountByLine"))
                if (decimal.TryParse(QueryStrings.FirstOrDefault(d => d.Key == "DiscountByLine").Value, out decimal val))
                    query = query.Where(d => val == d.DiscountByLine);


			//Query DiscountByOrder (decimal)
			if (QueryStrings.Any(d => d.Key == "DiscountByOrderFrom") && QueryStrings.Any(d => d.Key == "DiscountByOrderTo"))
                if (decimal.TryParse(QueryStrings.FirstOrDefault(d => d.Key == "DiscountByOrderFrom").Value, out decimal fromVal) && decimal.TryParse(QueryStrings.FirstOrDefault(d => d.Key == "DiscountByOrderTo").Value, out decimal toVal))
                    query = query.Where(d => fromVal <= d.DiscountByOrder && d.DiscountByOrder <= toVal);
            
            if (QueryStrings.Any(d => d.Key == "DiscountByOrder"))
                if (decimal.TryParse(QueryStrings.FirstOrDefault(d => d.Key == "DiscountByOrder").Value, out decimal val))
                    query = query.Where(d => val == d.DiscountByOrder);


			//Query DiscountFromSalesman (decimal)
			if (QueryStrings.Any(d => d.Key == "DiscountFromSalesmanFrom") && QueryStrings.Any(d => d.Key == "DiscountFromSalesmanTo"))
                if (decimal.TryParse(QueryStrings.FirstOrDefault(d => d.Key == "DiscountFromSalesmanFrom").Value, out decimal fromVal) && decimal.TryParse(QueryStrings.FirstOrDefault(d => d.Key == "DiscountFromSalesmanTo").Value, out decimal toVal))
                    query = query.Where(d => fromVal <= d.DiscountFromSalesman && d.DiscountFromSalesman <= toVal);
            
            if (QueryStrings.Any(d => d.Key == "DiscountFromSalesman"))
                if (decimal.TryParse(QueryStrings.FirstOrDefault(d => d.Key == "DiscountFromSalesman").Value, out decimal val))
                    query = query.Where(d => val == d.DiscountFromSalesman);


			//Query TotalDiscount (decimal)
			if (QueryStrings.Any(d => d.Key == "TotalDiscountFrom") && QueryStrings.Any(d => d.Key == "TotalDiscountTo"))
                if (decimal.TryParse(QueryStrings.FirstOrDefault(d => d.Key == "TotalDiscountFrom").Value, out decimal fromVal) && decimal.TryParse(QueryStrings.FirstOrDefault(d => d.Key == "TotalDiscountTo").Value, out decimal toVal))
                    query = query.Where(d => fromVal <= d.TotalDiscount && d.TotalDiscount <= toVal);
            
            if (QueryStrings.Any(d => d.Key == "TotalDiscount"))
                if (decimal.TryParse(QueryStrings.FirstOrDefault(d => d.Key == "TotalDiscount").Value, out decimal val))
                    query = query.Where(d => val == d.TotalDiscount);


			//Query TotalAfterDiscount (decimal)
			if (QueryStrings.Any(d => d.Key == "TotalAfterDiscountFrom") && QueryStrings.Any(d => d.Key == "TotalAfterDiscountTo"))
                if (decimal.TryParse(QueryStrings.FirstOrDefault(d => d.Key == "TotalAfterDiscountFrom").Value, out decimal fromVal) && decimal.TryParse(QueryStrings.FirstOrDefault(d => d.Key == "TotalAfterDiscountTo").Value, out decimal toVal))
                    query = query.Where(d => fromVal <= d.TotalAfterDiscount && d.TotalAfterDiscount <= toVal);
            
            if (QueryStrings.Any(d => d.Key == "TotalAfterDiscount"))
                if (decimal.TryParse(QueryStrings.FirstOrDefault(d => d.Key == "TotalAfterDiscount").Value, out decimal val))
                    query = query.Where(d => val == d.TotalAfterDiscount);


			//Query Tax (decimal)
			if (QueryStrings.Any(d => d.Key == "TaxFrom") && QueryStrings.Any(d => d.Key == "TaxTo"))
                if (decimal.TryParse(QueryStrings.FirstOrDefault(d => d.Key == "TaxFrom").Value, out decimal fromVal) && decimal.TryParse(QueryStrings.FirstOrDefault(d => d.Key == "TaxTo").Value, out decimal toVal))
                    query = query.Where(d => fromVal <= d.Tax && d.Tax <= toVal);
            
            if (QueryStrings.Any(d => d.Key == "Tax"))
                if (decimal.TryParse(QueryStrings.FirstOrDefault(d => d.Key == "Tax").Value, out decimal val))
                    query = query.Where(d => val == d.Tax);


			//Query TotalAfterTax (decimal)
			if (QueryStrings.Any(d => d.Key == "TotalAfterTaxFrom") && QueryStrings.Any(d => d.Key == "TotalAfterTaxTo"))
                if (decimal.TryParse(QueryStrings.FirstOrDefault(d => d.Key == "TotalAfterTaxFrom").Value, out decimal fromVal) && decimal.TryParse(QueryStrings.FirstOrDefault(d => d.Key == "TotalAfterTaxTo").Value, out decimal toVal))
                    query = query.Where(d => fromVal <= d.TotalAfterTax && d.TotalAfterTax <= toVal);
            
            if (QueryStrings.Any(d => d.Key == "TotalAfterTax"))
                if (decimal.TryParse(QueryStrings.FirstOrDefault(d => d.Key == "TotalAfterTax").Value, out decimal val))
                    query = query.Where(d => val == d.TotalAfterTax);


			//Query Received (decimal)
			if (QueryStrings.Any(d => d.Key == "ReceivedFrom") && QueryStrings.Any(d => d.Key == "ReceivedTo"))
                if (decimal.TryParse(QueryStrings.FirstOrDefault(d => d.Key == "ReceivedFrom").Value, out decimal fromVal) && decimal.TryParse(QueryStrings.FirstOrDefault(d => d.Key == "ReceivedTo").Value, out decimal toVal))
                    query = query.Where(d => fromVal <= d.Received && d.Received <= toVal);
            
            if (QueryStrings.Any(d => d.Key == "Received"))
                if (decimal.TryParse(QueryStrings.FirstOrDefault(d => d.Key == "Received").Value, out decimal val))
                    query = query.Where(d => val == d.Received);


			//Query Debt (decimal)
			if (QueryStrings.Any(d => d.Key == "DebtFrom") && QueryStrings.Any(d => d.Key == "DebtTo"))
                if (decimal.TryParse(QueryStrings.FirstOrDefault(d => d.Key == "DebtFrom").Value, out decimal fromVal) && decimal.TryParse(QueryStrings.FirstOrDefault(d => d.Key == "DebtTo").Value, out decimal toVal))
                    query = query.Where(d => fromVal <= d.Debt && d.Debt <= toVal);
            
            if (QueryStrings.Any(d => d.Key == "Debt"))
                if (decimal.TryParse(QueryStrings.FirstOrDefault(d => d.Key == "Debt").Value, out decimal val))
                    query = query.Where(d => val == d.Debt);


			//Query IsDebt (bool)
			if (QueryStrings.Any(d => d.Key == "IsDebt"))
            {
                var qValue = QueryStrings.FirstOrDefault(d => d.Key == "IsDebt").Value;
                if (bool.TryParse(qValue, out bool qBoolValue))
                    query = query.Where(d => qBoolValue == d.IsDebt);
            }

			//Query IsPaymentReceived (bool)
			if (QueryStrings.Any(d => d.Key == "IsPaymentReceived"))
            {
                var qValue = QueryStrings.FirstOrDefault(d => d.Key == "IsPaymentReceived").Value;
                if (bool.TryParse(qValue, out bool qBoolValue))
                    query = query.Where(d => qBoolValue == d.IsPaymentReceived);
            }

			//Query SubType (string)
			if (QueryStrings.Any(d => d.Key == "SubType_eq") && !string.IsNullOrEmpty(QueryStrings.FirstOrDefault(d => d.Key == "SubType_eq").Value))
            {
                var keyword = QueryStrings.FirstOrDefault(d => d.Key == "SubType_eq").Value;
                query = query.Where(d=>d.SubType == keyword);
            }
            if (QueryStrings.Any(d => d.Key == "SubType") && !string.IsNullOrEmpty(QueryStrings.FirstOrDefault(d => d.Key == "SubType").Value))
            {
                var keyword = QueryStrings.FirstOrDefault(d => d.Key == "SubType").Value;
                query = query.Where(d=>d.SubType.Contains(keyword));
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


			//Query ExpectedDeliveryDate (Nullable<System.DateTime>)
			if (QueryStrings.Any(d => d.Key == "ExpectedDeliveryDateFrom") && QueryStrings.Any(d => d.Key == "ExpectedDeliveryDateTo"))
                if (DateTime.TryParse(QueryStrings.FirstOrDefault(d => d.Key == "ExpectedDeliveryDateFrom").Value, out DateTime fromDate) && DateTime.TryParse(QueryStrings.FirstOrDefault(d => d.Key == "ExpectedDeliveryDateTo").Value, out DateTime toDate))
                    query = query.Where(d => fromDate <= d.ExpectedDeliveryDate && d.ExpectedDeliveryDate <= toDate);

            if (QueryStrings.Any(d => d.Key == "ExpectedDeliveryDate"))
                if (DateTime.TryParse(QueryStrings.FirstOrDefault(d => d.Key == "ExpectedDeliveryDate").Value, out DateTime val))
                    query = query.Where(d => d.ExpectedDeliveryDate != null && DbFunctions.TruncateTime(val) == DbFunctions.TruncateTime(d.ExpectedDeliveryDate));


			//Query ShippedDate (Nullable<System.DateTime>)
			if (QueryStrings.Any(d => d.Key == "ShippedDateFrom") && QueryStrings.Any(d => d.Key == "ShippedDateTo"))
                if (DateTime.TryParse(QueryStrings.FirstOrDefault(d => d.Key == "ShippedDateFrom").Value, out DateTime fromDate) && DateTime.TryParse(QueryStrings.FirstOrDefault(d => d.Key == "ShippedDateTo").Value, out DateTime toDate))
                    query = query.Where(d => fromDate <= d.ShippedDate && d.ShippedDate <= toDate);

            if (QueryStrings.Any(d => d.Key == "ShippedDate"))
                if (DateTime.TryParse(QueryStrings.FirstOrDefault(d => d.Key == "ShippedDate").Value, out DateTime val))
                    query = query.Where(d => d.ShippedDate != null && DbFunctions.TruncateTime(val) == DbFunctions.TruncateTime(d.ShippedDate));


			//Query ShippingAddress (string)
			if (QueryStrings.Any(d => d.Key == "ShippingAddress_eq") && !string.IsNullOrEmpty(QueryStrings.FirstOrDefault(d => d.Key == "ShippingAddress_eq").Value))
            {
                var keyword = QueryStrings.FirstOrDefault(d => d.Key == "ShippingAddress_eq").Value;
                query = query.Where(d=>d.ShippingAddress == keyword);
            }
            if (QueryStrings.Any(d => d.Key == "ShippingAddress") && !string.IsNullOrEmpty(QueryStrings.FirstOrDefault(d => d.Key == "ShippingAddress").Value))
            {
                var keyword = QueryStrings.FirstOrDefault(d => d.Key == "ShippingAddress").Value;
                query = query.Where(d=>d.ShippingAddress.Contains(keyword));
            }
            

			//Query ShippingAddressRemark (string)
			if (QueryStrings.Any(d => d.Key == "ShippingAddressRemark_eq") && !string.IsNullOrEmpty(QueryStrings.FirstOrDefault(d => d.Key == "ShippingAddressRemark_eq").Value))
            {
                var keyword = QueryStrings.FirstOrDefault(d => d.Key == "ShippingAddressRemark_eq").Value;
                query = query.Where(d=>d.ShippingAddressRemark == keyword);
            }
            if (QueryStrings.Any(d => d.Key == "ShippingAddressRemark") && !string.IsNullOrEmpty(QueryStrings.FirstOrDefault(d => d.Key == "ShippingAddressRemark").Value))
            {
                var keyword = QueryStrings.FirstOrDefault(d => d.Key == "ShippingAddressRemark").Value;
                query = query.Where(d=>d.ShippingAddressRemark.Contains(keyword));
            }
            

			//Query InvoiceNumber (string)
			if (QueryStrings.Any(d => d.Key == "InvoiceNumber_eq") && !string.IsNullOrEmpty(QueryStrings.FirstOrDefault(d => d.Key == "InvoiceNumber_eq").Value))
            {
                var keyword = QueryStrings.FirstOrDefault(d => d.Key == "InvoiceNumber_eq").Value;
                query = query.Where(d=>d.InvoiceNumber == keyword);
            }
            if (QueryStrings.Any(d => d.Key == "InvoiceNumber") && !string.IsNullOrEmpty(QueryStrings.FirstOrDefault(d => d.Key == "InvoiceNumber").Value))
            {
                var keyword = QueryStrings.FirstOrDefault(d => d.Key == "InvoiceNumber").Value;
                query = query.Where(d=>d.InvoiceNumber.Contains(keyword));
            }
            

			//Query InvoicDate (Nullable<System.DateTime>)
			if (QueryStrings.Any(d => d.Key == "InvoicDateFrom") && QueryStrings.Any(d => d.Key == "InvoicDateTo"))
                if (DateTime.TryParse(QueryStrings.FirstOrDefault(d => d.Key == "InvoicDateFrom").Value, out DateTime fromDate) && DateTime.TryParse(QueryStrings.FirstOrDefault(d => d.Key == "InvoicDateTo").Value, out DateTime toDate))
                    query = query.Where(d => fromDate <= d.InvoicDate && d.InvoicDate <= toDate);

            if (QueryStrings.Any(d => d.Key == "InvoicDate"))
                if (DateTime.TryParse(QueryStrings.FirstOrDefault(d => d.Key == "InvoicDate").Value, out DateTime val))
                    query = query.Where(d => d.InvoicDate != null && DbFunctions.TruncateTime(val) == DbFunctions.TruncateTime(d.InvoicDate));


			//Query TaxRate (decimal)
			if (QueryStrings.Any(d => d.Key == "TaxRateFrom") && QueryStrings.Any(d => d.Key == "TaxRateTo"))
                if (decimal.TryParse(QueryStrings.FirstOrDefault(d => d.Key == "TaxRateFrom").Value, out decimal fromVal) && decimal.TryParse(QueryStrings.FirstOrDefault(d => d.Key == "TaxRateTo").Value, out decimal toVal))
                    query = query.Where(d => fromVal <= d.TaxRate && d.TaxRate <= toVal);
            
            if (QueryStrings.Any(d => d.Key == "TaxRate"))
                if (decimal.TryParse(QueryStrings.FirstOrDefault(d => d.Key == "TaxRate").Value, out decimal val))
                    query = query.Where(d => val == d.TaxRate);


			//Query RefID (string)
			if (QueryStrings.Any(d => d.Key == "RefID_eq") && !string.IsNullOrEmpty(QueryStrings.FirstOrDefault(d => d.Key == "RefID_eq").Value))
            {
                var keyword = QueryStrings.FirstOrDefault(d => d.Key == "RefID_eq").Value;
                query = query.Where(d=>d.RefID == keyword);
            }
            if (QueryStrings.Any(d => d.Key == "RefID") && !string.IsNullOrEmpty(QueryStrings.FirstOrDefault(d => d.Key == "RefID").Value))
            {
                var keyword = QueryStrings.FirstOrDefault(d => d.Key == "RefID").Value;
                query = query.Where(d=>d.RefID.Contains(keyword));
            }
            

			//Query RefOwner (string)
			if (QueryStrings.Any(d => d.Key == "RefOwner_eq") && !string.IsNullOrEmpty(QueryStrings.FirstOrDefault(d => d.Key == "RefOwner_eq").Value))
            {
                var keyword = QueryStrings.FirstOrDefault(d => d.Key == "RefOwner_eq").Value;
                query = query.Where(d=>d.RefOwner == keyword);
            }
            if (QueryStrings.Any(d => d.Key == "RefOwner") && !string.IsNullOrEmpty(QueryStrings.FirstOrDefault(d => d.Key == "RefOwner").Value))
            {
                var keyword = QueryStrings.FirstOrDefault(d => d.Key == "RefOwner").Value;
                query = query.Where(d=>d.RefOwner.Contains(keyword));
            }
            

			//Query RefContact (string)
			if (QueryStrings.Any(d => d.Key == "RefContact_eq") && !string.IsNullOrEmpty(QueryStrings.FirstOrDefault(d => d.Key == "RefContact_eq").Value))
            {
                var keyword = QueryStrings.FirstOrDefault(d => d.Key == "RefContact_eq").Value;
                query = query.Where(d=>d.RefContact == keyword);
            }
            if (QueryStrings.Any(d => d.Key == "RefContact") && !string.IsNullOrEmpty(QueryStrings.FirstOrDefault(d => d.Key == "RefContact").Value))
            {
                var keyword = QueryStrings.FirstOrDefault(d => d.Key == "RefContact").Value;
                query = query.Where(d=>d.RefContact.Contains(keyword));
            }
            

			//Query RefWarehouse (string)
			if (QueryStrings.Any(d => d.Key == "RefWarehouse_eq") && !string.IsNullOrEmpty(QueryStrings.FirstOrDefault(d => d.Key == "RefWarehouse_eq").Value))
            {
                var keyword = QueryStrings.FirstOrDefault(d => d.Key == "RefWarehouse_eq").Value;
                query = query.Where(d=>d.RefWarehouse == keyword);
            }
            if (QueryStrings.Any(d => d.Key == "RefWarehouse") && !string.IsNullOrEmpty(QueryStrings.FirstOrDefault(d => d.Key == "RefWarehouse").Value))
            {
                var keyword = QueryStrings.FirstOrDefault(d => d.Key == "RefWarehouse").Value;
                query = query.Where(d=>d.RefWarehouse.Contains(keyword));
            }
            

			//Query RefDepartment (string)
			if (QueryStrings.Any(d => d.Key == "RefDepartment_eq") && !string.IsNullOrEmpty(QueryStrings.FirstOrDefault(d => d.Key == "RefDepartment_eq").Value))
            {
                var keyword = QueryStrings.FirstOrDefault(d => d.Key == "RefDepartment_eq").Value;
                query = query.Where(d=>d.RefDepartment == keyword);
            }
            if (QueryStrings.Any(d => d.Key == "RefDepartment") && !string.IsNullOrEmpty(QueryStrings.FirstOrDefault(d => d.Key == "RefDepartment").Value))
            {
                var keyword = QueryStrings.FirstOrDefault(d => d.Key == "RefDepartment").Value;
                query = query.Where(d=>d.RefDepartment.Contains(keyword));
            }
            

			//Query RefShipper (string)
			if (QueryStrings.Any(d => d.Key == "RefShipper_eq") && !string.IsNullOrEmpty(QueryStrings.FirstOrDefault(d => d.Key == "RefShipper_eq").Value))
            {
                var keyword = QueryStrings.FirstOrDefault(d => d.Key == "RefShipper_eq").Value;
                query = query.Where(d=>d.RefShipper == keyword);
            }
            if (QueryStrings.Any(d => d.Key == "RefShipper") && !string.IsNullOrEmpty(QueryStrings.FirstOrDefault(d => d.Key == "RefShipper").Value))
            {
                var keyword = QueryStrings.FirstOrDefault(d => d.Key == "RefShipper").Value;
                query = query.Where(d=>d.RefShipper.Contains(keyword));
            }
            

			//Query IsCOD (bool)
			if (QueryStrings.Any(d => d.Key == "IsCOD"))
            {
                var qValue = QueryStrings.FirstOrDefault(d => d.Key == "IsCOD").Value;
                if (bool.TryParse(qValue, out bool qBoolValue))
                    query = query.Where(d => qBoolValue == d.IsCOD);
            }

			//Query CODAmount (decimal)
			if (QueryStrings.Any(d => d.Key == "CODAmountFrom") && QueryStrings.Any(d => d.Key == "CODAmountTo"))
                if (decimal.TryParse(QueryStrings.FirstOrDefault(d => d.Key == "CODAmountFrom").Value, out decimal fromVal) && decimal.TryParse(QueryStrings.FirstOrDefault(d => d.Key == "CODAmountTo").Value, out decimal toVal))
                    query = query.Where(d => fromVal <= d.CODAmount && d.CODAmount <= toVal);
            
            if (QueryStrings.Any(d => d.Key == "CODAmount"))
                if (decimal.TryParse(QueryStrings.FirstOrDefault(d => d.Key == "CODAmount").Value, out decimal val))
                    query = query.Where(d => val == d.CODAmount);


			//Query ShipFee (decimal)
			if (QueryStrings.Any(d => d.Key == "ShipFeeFrom") && QueryStrings.Any(d => d.Key == "ShipFeeTo"))
                if (decimal.TryParse(QueryStrings.FirstOrDefault(d => d.Key == "ShipFeeFrom").Value, out decimal fromVal) && decimal.TryParse(QueryStrings.FirstOrDefault(d => d.Key == "ShipFeeTo").Value, out decimal toVal))
                    query = query.Where(d => fromVal <= d.ShipFee && d.ShipFee <= toVal);
            
            if (QueryStrings.Any(d => d.Key == "ShipFee"))
                if (decimal.TryParse(QueryStrings.FirstOrDefault(d => d.Key == "ShipFee").Value, out decimal val))
                    query = query.Where(d => val == d.ShipFee);


			//Query ShipFeeBySender (bool)
			if (QueryStrings.Any(d => d.Key == "ShipFeeBySender"))
            {
                var qValue = QueryStrings.FirstOrDefault(d => d.Key == "ShipFeeBySender").Value;
                if (bool.TryParse(qValue, out bool qBoolValue))
                    query = query.Where(d => qBoolValue == d.ShipFeeBySender);
            }

			//Query IsSampleOrder (bool)
			if (QueryStrings.Any(d => d.Key == "IsSampleOrder"))
            {
                var qValue = QueryStrings.FirstOrDefault(d => d.Key == "IsSampleOrder").Value;
                if (bool.TryParse(qValue, out bool qBoolValue))
                    query = query.Where(d => qBoolValue == d.IsSampleOrder);
            }

			//Query IsShipBySaleMan (bool)
			if (QueryStrings.Any(d => d.Key == "IsShipBySaleMan"))
            {
                var qValue = QueryStrings.FirstOrDefault(d => d.Key == "IsShipBySaleMan").Value;
                if (bool.TryParse(qValue, out bool qBoolValue))
                    query = query.Where(d => qBoolValue == d.IsShipBySaleMan);
            }

			//Query IsUrgentOrders (bool)
			if (QueryStrings.Any(d => d.Key == "IsUrgentOrders"))
            {
                var qValue = QueryStrings.FirstOrDefault(d => d.Key == "IsUrgentOrders").Value;
                if (bool.TryParse(qValue, out bool qBoolValue))
                    query = query.Where(d => qBoolValue == d.IsUrgentOrders);
            }

			//Query IDUrgentShipper (Nullable<int>)
			if (QueryStrings.Any(d => d.Key == "IDUrgentShipper"))
            {
                var IDList = QueryStrings.FirstOrDefault(d => d.Key == "IDUrgentShipper").Value.Replace("[", "").Replace("]", "").Split(',');
                List<int?> IDs = new List<int?>();
                foreach (var item in IDList)
                    if (int.TryParse(item, out int i))
                        IDs.Add(i);
					else if (item == "null")
						IDs.Add(null);
                if (IDs.Count > 0)
                    query = query.Where(d => IDs.Contains(d.IDUrgentShipper));
////                    query = query.Where(d => IDs.Contains(d.IDUrgentShipper));
//                    
            }

			//Query IsWholeSale (bool)
			if (QueryStrings.Any(d => d.Key == "IsWholeSale"))
            {
                var qValue = QueryStrings.FirstOrDefault(d => d.Key == "IsWholeSale").Value;
                if (bool.TryParse(qValue, out bool qBoolValue))
                    query = query.Where(d => qBoolValue == d.IsWholeSale);
            }

			//Query ReceivedDiscountFromSalesman (decimal)
			if (QueryStrings.Any(d => d.Key == "ReceivedDiscountFromSalesmanFrom") && QueryStrings.Any(d => d.Key == "ReceivedDiscountFromSalesmanTo"))
                if (decimal.TryParse(QueryStrings.FirstOrDefault(d => d.Key == "ReceivedDiscountFromSalesmanFrom").Value, out decimal fromVal) && decimal.TryParse(QueryStrings.FirstOrDefault(d => d.Key == "ReceivedDiscountFromSalesmanTo").Value, out decimal toVal))
                    query = query.Where(d => fromVal <= d.ReceivedDiscountFromSalesman && d.ReceivedDiscountFromSalesman <= toVal);
            
            if (QueryStrings.Any(d => d.Key == "ReceivedDiscountFromSalesman"))
                if (decimal.TryParse(QueryStrings.FirstOrDefault(d => d.Key == "ReceivedDiscountFromSalesman").Value, out decimal val))
                    query = query.Where(d => val == d.ReceivedDiscountFromSalesman);


			//Query OldReceived (decimal)
			if (QueryStrings.Any(d => d.Key == "OldReceivedFrom") && QueryStrings.Any(d => d.Key == "OldReceivedTo"))
                if (decimal.TryParse(QueryStrings.FirstOrDefault(d => d.Key == "OldReceivedFrom").Value, out decimal fromVal) && decimal.TryParse(QueryStrings.FirstOrDefault(d => d.Key == "OldReceivedTo").Value, out decimal toVal))
                    query = query.Where(d => fromVal <= d.OldReceived && d.OldReceived <= toVal);
            
            if (QueryStrings.Any(d => d.Key == "OldReceived"))
                if (decimal.TryParse(QueryStrings.FirstOrDefault(d => d.Key == "OldReceived").Value, out decimal val))
                    query = query.Where(d => val == d.OldReceived);


			//Query IDAddress (int)
			if (QueryStrings.Any(d => d.Key == "IDAddress"))
            {
                var IDList = QueryStrings.FirstOrDefault(d => d.Key == "IDAddress").Value.Replace("[", "").Replace("]", "").Split(',');
                List<int> IDs = new List<int>();
                foreach (var item in IDList)
                    if (int.TryParse(item, out int i))
                        IDs.Add(i);
                if (IDs.Count > 0)
                    query = query.Where(d => IDs.Contains(d.IDAddress));
            }
            return query;
        }
		
        public static IQueryable<tbl_SALE_Order> _sortBuilder(IQueryable<tbl_SALE_Order> query, Dictionary<string, string> QueryStrings)
        {
            if (QueryStrings.Any(d => d.Key == "SortBy"))
            {
                var sorts = QueryStrings.FirstOrDefault(d => d.Key == "SortBy").Value.Replace("[", "").Replace("]", "").Split(',');
                
                foreach (var item in sorts)
                    if (!string.IsNullOrEmpty(item))
                    {
                        var ordered = query as IOrderedQueryable<tbl_SALE_Order>;
                        bool isOrdered = ordered.ToString().IndexOf("ORDER BY") !=-1;

                        switch (item)
                        {
							case "IDBranch":
								query = isOrdered ? ordered.ThenBy(o => o.IDBranch) : query.OrderBy(o => o.IDBranch);
								 break;
							case "IDBranch_desc":
                                query = isOrdered ? ordered.ThenByDescending(o => o.IDBranch) : query.OrderByDescending(o => o.IDBranch);
                                break;
							case "IDOpportunity":
								query = isOrdered ? ordered.ThenBy(o => o.IDOpportunity) : query.OrderBy(o => o.IDOpportunity);
								 break;
							case "IDOpportunity_desc":
                                query = isOrdered ? ordered.ThenByDescending(o => o.IDOpportunity) : query.OrderByDescending(o => o.IDOpportunity);
                                break;
							case "IDContact":
								query = isOrdered ? ordered.ThenBy(o => o.IDContact) : query.OrderBy(o => o.IDContact);
								 break;
							case "IDContact_desc":
                                query = isOrdered ? ordered.ThenByDescending(o => o.IDContact) : query.OrderByDescending(o => o.IDContact);
                                break;
							case "IDContract":
								query = isOrdered ? ordered.ThenBy(o => o.IDContract) : query.OrderBy(o => o.IDContract);
								 break;
							case "IDContract_desc":
                                query = isOrdered ? ordered.ThenByDescending(o => o.IDContract) : query.OrderByDescending(o => o.IDContract);
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
							case "IDOwner":
								query = isOrdered ? ordered.ThenBy(o => o.IDOwner) : query.OrderBy(o => o.IDOwner);
								 break;
							case "IDOwner_desc":
                                query = isOrdered ? ordered.ThenByDescending(o => o.IDOwner) : query.OrderByDescending(o => o.IDOwner);
                                break;
							case "OrderDate":
								query = isOrdered ? ordered.ThenBy(o => o.OrderDate) : query.OrderBy(o => o.OrderDate);
								 break;
							case "OrderDate_desc":
                                query = isOrdered ? ordered.ThenByDescending(o => o.OrderDate) : query.OrderByDescending(o => o.OrderDate);
                                break;
							case "OriginalTotalBeforeDiscount":
								query = isOrdered ? ordered.ThenBy(o => o.OriginalTotalBeforeDiscount) : query.OrderBy(o => o.OriginalTotalBeforeDiscount);
								 break;
							case "OriginalTotalBeforeDiscount_desc":
                                query = isOrdered ? ordered.ThenByDescending(o => o.OriginalTotalBeforeDiscount) : query.OrderByDescending(o => o.OriginalTotalBeforeDiscount);
                                break;
							case "OriginalPromotion":
								query = isOrdered ? ordered.ThenBy(o => o.OriginalPromotion) : query.OrderBy(o => o.OriginalPromotion);
								 break;
							case "OriginalPromotion_desc":
                                query = isOrdered ? ordered.ThenByDescending(o => o.OriginalPromotion) : query.OrderByDescending(o => o.OriginalPromotion);
                                break;
							case "OriginalDiscount1":
								query = isOrdered ? ordered.ThenBy(o => o.OriginalDiscount1) : query.OrderBy(o => o.OriginalDiscount1);
								 break;
							case "OriginalDiscount1_desc":
                                query = isOrdered ? ordered.ThenByDescending(o => o.OriginalDiscount1) : query.OrderByDescending(o => o.OriginalDiscount1);
                                break;
							case "OriginalDiscount2":
								query = isOrdered ? ordered.ThenBy(o => o.OriginalDiscount2) : query.OrderBy(o => o.OriginalDiscount2);
								 break;
							case "OriginalDiscount2_desc":
                                query = isOrdered ? ordered.ThenByDescending(o => o.OriginalDiscount2) : query.OrderByDescending(o => o.OriginalDiscount2);
                                break;
							case "OriginalDiscountByItem":
								query = isOrdered ? ordered.ThenBy(o => o.OriginalDiscountByItem) : query.OrderBy(o => o.OriginalDiscountByItem);
								 break;
							case "OriginalDiscountByItem_desc":
                                query = isOrdered ? ordered.ThenByDescending(o => o.OriginalDiscountByItem) : query.OrderByDescending(o => o.OriginalDiscountByItem);
                                break;
							case "OriginalDiscountByGroup":
								query = isOrdered ? ordered.ThenBy(o => o.OriginalDiscountByGroup) : query.OrderBy(o => o.OriginalDiscountByGroup);
								 break;
							case "OriginalDiscountByGroup_desc":
                                query = isOrdered ? ordered.ThenByDescending(o => o.OriginalDiscountByGroup) : query.OrderByDescending(o => o.OriginalDiscountByGroup);
                                break;
							case "OriginalDiscountByLine":
								query = isOrdered ? ordered.ThenBy(o => o.OriginalDiscountByLine) : query.OrderBy(o => o.OriginalDiscountByLine);
								 break;
							case "OriginalDiscountByLine_desc":
                                query = isOrdered ? ordered.ThenByDescending(o => o.OriginalDiscountByLine) : query.OrderByDescending(o => o.OriginalDiscountByLine);
                                break;
							case "OriginalDiscountByOrder":
								query = isOrdered ? ordered.ThenBy(o => o.OriginalDiscountByOrder) : query.OrderBy(o => o.OriginalDiscountByOrder);
								 break;
							case "OriginalDiscountByOrder_desc":
                                query = isOrdered ? ordered.ThenByDescending(o => o.OriginalDiscountByOrder) : query.OrderByDescending(o => o.OriginalDiscountByOrder);
                                break;
							case "OriginalDiscountFromSalesman":
								query = isOrdered ? ordered.ThenBy(o => o.OriginalDiscountFromSalesman) : query.OrderBy(o => o.OriginalDiscountFromSalesman);
								 break;
							case "OriginalDiscountFromSalesman_desc":
                                query = isOrdered ? ordered.ThenByDescending(o => o.OriginalDiscountFromSalesman) : query.OrderByDescending(o => o.OriginalDiscountFromSalesman);
                                break;
							case "OriginalTotalDiscount":
								query = isOrdered ? ordered.ThenBy(o => o.OriginalTotalDiscount) : query.OrderBy(o => o.OriginalTotalDiscount);
								 break;
							case "OriginalTotalDiscount_desc":
                                query = isOrdered ? ordered.ThenByDescending(o => o.OriginalTotalDiscount) : query.OrderByDescending(o => o.OriginalTotalDiscount);
                                break;
							case "OriginalTotalAfterDiscount":
								query = isOrdered ? ordered.ThenBy(o => o.OriginalTotalAfterDiscount) : query.OrderBy(o => o.OriginalTotalAfterDiscount);
								 break;
							case "OriginalTotalAfterDiscount_desc":
                                query = isOrdered ? ordered.ThenByDescending(o => o.OriginalTotalAfterDiscount) : query.OrderByDescending(o => o.OriginalTotalAfterDiscount);
                                break;
							case "OriginalTax":
								query = isOrdered ? ordered.ThenBy(o => o.OriginalTax) : query.OrderBy(o => o.OriginalTax);
								 break;
							case "OriginalTax_desc":
                                query = isOrdered ? ordered.ThenByDescending(o => o.OriginalTax) : query.OrderByDescending(o => o.OriginalTax);
                                break;
							case "OriginalTotalAfterTax":
								query = isOrdered ? ordered.ThenBy(o => o.OriginalTotalAfterTax) : query.OrderBy(o => o.OriginalTotalAfterTax);
								 break;
							case "OriginalTotalAfterTax_desc":
                                query = isOrdered ? ordered.ThenByDescending(o => o.OriginalTotalAfterTax) : query.OrderByDescending(o => o.OriginalTotalAfterTax);
                                break;
							case "TotalBeforeDiscount":
								query = isOrdered ? ordered.ThenBy(o => o.TotalBeforeDiscount) : query.OrderBy(o => o.TotalBeforeDiscount);
								 break;
							case "TotalBeforeDiscount_desc":
                                query = isOrdered ? ordered.ThenByDescending(o => o.TotalBeforeDiscount) : query.OrderByDescending(o => o.TotalBeforeDiscount);
                                break;
							case "ProductWeight":
								query = isOrdered ? ordered.ThenBy(o => o.ProductWeight) : query.OrderBy(o => o.ProductWeight);
								 break;
							case "ProductWeight_desc":
                                query = isOrdered ? ordered.ThenByDescending(o => o.ProductWeight) : query.OrderByDescending(o => o.ProductWeight);
                                break;
							case "ProductDimensions":
								query = isOrdered ? ordered.ThenBy(o => o.ProductDimensions) : query.OrderBy(o => o.ProductDimensions);
								 break;
							case "ProductDimensions_desc":
                                query = isOrdered ? ordered.ThenByDescending(o => o.ProductDimensions) : query.OrderByDescending(o => o.ProductDimensions);
                                break;
							case "Discount1":
								query = isOrdered ? ordered.ThenBy(o => o.Discount1) : query.OrderBy(o => o.Discount1);
								 break;
							case "Discount1_desc":
                                query = isOrdered ? ordered.ThenByDescending(o => o.Discount1) : query.OrderByDescending(o => o.Discount1);
                                break;
							case "Discount2":
								query = isOrdered ? ordered.ThenBy(o => o.Discount2) : query.OrderBy(o => o.Discount2);
								 break;
							case "Discount2_desc":
                                query = isOrdered ? ordered.ThenByDescending(o => o.Discount2) : query.OrderByDescending(o => o.Discount2);
                                break;
							case "DiscountByItem":
								query = isOrdered ? ordered.ThenBy(o => o.DiscountByItem) : query.OrderBy(o => o.DiscountByItem);
								 break;
							case "DiscountByItem_desc":
                                query = isOrdered ? ordered.ThenByDescending(o => o.DiscountByItem) : query.OrderByDescending(o => o.DiscountByItem);
                                break;
							case "Promotion":
								query = isOrdered ? ordered.ThenBy(o => o.Promotion) : query.OrderBy(o => o.Promotion);
								 break;
							case "Promotion_desc":
                                query = isOrdered ? ordered.ThenByDescending(o => o.Promotion) : query.OrderByDescending(o => o.Promotion);
                                break;
							case "DiscountByGroup":
								query = isOrdered ? ordered.ThenBy(o => o.DiscountByGroup) : query.OrderBy(o => o.DiscountByGroup);
								 break;
							case "DiscountByGroup_desc":
                                query = isOrdered ? ordered.ThenByDescending(o => o.DiscountByGroup) : query.OrderByDescending(o => o.DiscountByGroup);
                                break;
							case "DiscountByLine":
								query = isOrdered ? ordered.ThenBy(o => o.DiscountByLine) : query.OrderBy(o => o.DiscountByLine);
								 break;
							case "DiscountByLine_desc":
                                query = isOrdered ? ordered.ThenByDescending(o => o.DiscountByLine) : query.OrderByDescending(o => o.DiscountByLine);
                                break;
							case "DiscountByOrder":
								query = isOrdered ? ordered.ThenBy(o => o.DiscountByOrder) : query.OrderBy(o => o.DiscountByOrder);
								 break;
							case "DiscountByOrder_desc":
                                query = isOrdered ? ordered.ThenByDescending(o => o.DiscountByOrder) : query.OrderByDescending(o => o.DiscountByOrder);
                                break;
							case "DiscountFromSalesman":
								query = isOrdered ? ordered.ThenBy(o => o.DiscountFromSalesman) : query.OrderBy(o => o.DiscountFromSalesman);
								 break;
							case "DiscountFromSalesman_desc":
                                query = isOrdered ? ordered.ThenByDescending(o => o.DiscountFromSalesman) : query.OrderByDescending(o => o.DiscountFromSalesman);
                                break;
							case "TotalDiscount":
								query = isOrdered ? ordered.ThenBy(o => o.TotalDiscount) : query.OrderBy(o => o.TotalDiscount);
								 break;
							case "TotalDiscount_desc":
                                query = isOrdered ? ordered.ThenByDescending(o => o.TotalDiscount) : query.OrderByDescending(o => o.TotalDiscount);
                                break;
							case "TotalAfterDiscount":
								query = isOrdered ? ordered.ThenBy(o => o.TotalAfterDiscount) : query.OrderBy(o => o.TotalAfterDiscount);
								 break;
							case "TotalAfterDiscount_desc":
                                query = isOrdered ? ordered.ThenByDescending(o => o.TotalAfterDiscount) : query.OrderByDescending(o => o.TotalAfterDiscount);
                                break;
							case "Tax":
								query = isOrdered ? ordered.ThenBy(o => o.Tax) : query.OrderBy(o => o.Tax);
								 break;
							case "Tax_desc":
                                query = isOrdered ? ordered.ThenByDescending(o => o.Tax) : query.OrderByDescending(o => o.Tax);
                                break;
							case "TotalAfterTax":
								query = isOrdered ? ordered.ThenBy(o => o.TotalAfterTax) : query.OrderBy(o => o.TotalAfterTax);
								 break;
							case "TotalAfterTax_desc":
                                query = isOrdered ? ordered.ThenByDescending(o => o.TotalAfterTax) : query.OrderByDescending(o => o.TotalAfterTax);
                                break;
							case "Received":
								query = isOrdered ? ordered.ThenBy(o => o.Received) : query.OrderBy(o => o.Received);
								 break;
							case "Received_desc":
                                query = isOrdered ? ordered.ThenByDescending(o => o.Received) : query.OrderByDescending(o => o.Received);
                                break;
							case "Debt":
								query = isOrdered ? ordered.ThenBy(o => o.Debt) : query.OrderBy(o => o.Debt);
								 break;
							case "Debt_desc":
                                query = isOrdered ? ordered.ThenByDescending(o => o.Debt) : query.OrderByDescending(o => o.Debt);
                                break;
							case "IsDebt":
								query = isOrdered ? ordered.ThenBy(o => o.IsDebt) : query.OrderBy(o => o.IsDebt);
								 break;
							case "IsDebt_desc":
                                query = isOrdered ? ordered.ThenByDescending(o => o.IsDebt) : query.OrderByDescending(o => o.IsDebt);
                                break;
							case "IsPaymentReceived":
								query = isOrdered ? ordered.ThenBy(o => o.IsPaymentReceived) : query.OrderBy(o => o.IsPaymentReceived);
								 break;
							case "IsPaymentReceived_desc":
                                query = isOrdered ? ordered.ThenByDescending(o => o.IsPaymentReceived) : query.OrderByDescending(o => o.IsPaymentReceived);
                                break;
							case "SubType":
								query = isOrdered ? ordered.ThenBy(o => o.SubType) : query.OrderBy(o => o.SubType);
								 break;
							case "SubType_desc":
                                query = isOrdered ? ordered.ThenByDescending(o => o.SubType) : query.OrderByDescending(o => o.SubType);
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
							case "ExpectedDeliveryDate":
								query = isOrdered ? ordered.ThenBy(o => o.ExpectedDeliveryDate) : query.OrderBy(o => o.ExpectedDeliveryDate);
								 break;
							case "ExpectedDeliveryDate_desc":
                                query = isOrdered ? ordered.ThenByDescending(o => o.ExpectedDeliveryDate) : query.OrderByDescending(o => o.ExpectedDeliveryDate);
                                break;
							case "ShippedDate":
								query = isOrdered ? ordered.ThenBy(o => o.ShippedDate) : query.OrderBy(o => o.ShippedDate);
								 break;
							case "ShippedDate_desc":
                                query = isOrdered ? ordered.ThenByDescending(o => o.ShippedDate) : query.OrderByDescending(o => o.ShippedDate);
                                break;
							case "ShippingAddress":
								query = isOrdered ? ordered.ThenBy(o => o.ShippingAddress) : query.OrderBy(o => o.ShippingAddress);
								 break;
							case "ShippingAddress_desc":
                                query = isOrdered ? ordered.ThenByDescending(o => o.ShippingAddress) : query.OrderByDescending(o => o.ShippingAddress);
                                break;
							case "ShippingAddressRemark":
								query = isOrdered ? ordered.ThenBy(o => o.ShippingAddressRemark) : query.OrderBy(o => o.ShippingAddressRemark);
								 break;
							case "ShippingAddressRemark_desc":
                                query = isOrdered ? ordered.ThenByDescending(o => o.ShippingAddressRemark) : query.OrderByDescending(o => o.ShippingAddressRemark);
                                break;
							case "InvoiceNumber":
								query = isOrdered ? ordered.ThenBy(o => o.InvoiceNumber) : query.OrderBy(o => o.InvoiceNumber);
								 break;
							case "InvoiceNumber_desc":
                                query = isOrdered ? ordered.ThenByDescending(o => o.InvoiceNumber) : query.OrderByDescending(o => o.InvoiceNumber);
                                break;
							case "InvoicDate":
								query = isOrdered ? ordered.ThenBy(o => o.InvoicDate) : query.OrderBy(o => o.InvoicDate);
								 break;
							case "InvoicDate_desc":
                                query = isOrdered ? ordered.ThenByDescending(o => o.InvoicDate) : query.OrderByDescending(o => o.InvoicDate);
                                break;
							case "TaxRate":
								query = isOrdered ? ordered.ThenBy(o => o.TaxRate) : query.OrderBy(o => o.TaxRate);
								 break;
							case "TaxRate_desc":
                                query = isOrdered ? ordered.ThenByDescending(o => o.TaxRate) : query.OrderByDescending(o => o.TaxRate);
                                break;
							case "RefID":
								query = isOrdered ? ordered.ThenBy(o => o.RefID) : query.OrderBy(o => o.RefID);
								 break;
							case "RefID_desc":
                                query = isOrdered ? ordered.ThenByDescending(o => o.RefID) : query.OrderByDescending(o => o.RefID);
                                break;
							case "RefOwner":
								query = isOrdered ? ordered.ThenBy(o => o.RefOwner) : query.OrderBy(o => o.RefOwner);
								 break;
							case "RefOwner_desc":
                                query = isOrdered ? ordered.ThenByDescending(o => o.RefOwner) : query.OrderByDescending(o => o.RefOwner);
                                break;
							case "RefContact":
								query = isOrdered ? ordered.ThenBy(o => o.RefContact) : query.OrderBy(o => o.RefContact);
								 break;
							case "RefContact_desc":
                                query = isOrdered ? ordered.ThenByDescending(o => o.RefContact) : query.OrderByDescending(o => o.RefContact);
                                break;
							case "RefWarehouse":
								query = isOrdered ? ordered.ThenBy(o => o.RefWarehouse) : query.OrderBy(o => o.RefWarehouse);
								 break;
							case "RefWarehouse_desc":
                                query = isOrdered ? ordered.ThenByDescending(o => o.RefWarehouse) : query.OrderByDescending(o => o.RefWarehouse);
                                break;
							case "RefDepartment":
								query = isOrdered ? ordered.ThenBy(o => o.RefDepartment) : query.OrderBy(o => o.RefDepartment);
								 break;
							case "RefDepartment_desc":
                                query = isOrdered ? ordered.ThenByDescending(o => o.RefDepartment) : query.OrderByDescending(o => o.RefDepartment);
                                break;
							case "RefShipper":
								query = isOrdered ? ordered.ThenBy(o => o.RefShipper) : query.OrderBy(o => o.RefShipper);
								 break;
							case "RefShipper_desc":
                                query = isOrdered ? ordered.ThenByDescending(o => o.RefShipper) : query.OrderByDescending(o => o.RefShipper);
                                break;
							case "IsCOD":
								query = isOrdered ? ordered.ThenBy(o => o.IsCOD) : query.OrderBy(o => o.IsCOD);
								 break;
							case "IsCOD_desc":
                                query = isOrdered ? ordered.ThenByDescending(o => o.IsCOD) : query.OrderByDescending(o => o.IsCOD);
                                break;
							case "CODAmount":
								query = isOrdered ? ordered.ThenBy(o => o.CODAmount) : query.OrderBy(o => o.CODAmount);
								 break;
							case "CODAmount_desc":
                                query = isOrdered ? ordered.ThenByDescending(o => o.CODAmount) : query.OrderByDescending(o => o.CODAmount);
                                break;
							case "ShipFee":
								query = isOrdered ? ordered.ThenBy(o => o.ShipFee) : query.OrderBy(o => o.ShipFee);
								 break;
							case "ShipFee_desc":
                                query = isOrdered ? ordered.ThenByDescending(o => o.ShipFee) : query.OrderByDescending(o => o.ShipFee);
                                break;
							case "ShipFeeBySender":
								query = isOrdered ? ordered.ThenBy(o => o.ShipFeeBySender) : query.OrderBy(o => o.ShipFeeBySender);
								 break;
							case "ShipFeeBySender_desc":
                                query = isOrdered ? ordered.ThenByDescending(o => o.ShipFeeBySender) : query.OrderByDescending(o => o.ShipFeeBySender);
                                break;
							case "IsSampleOrder":
								query = isOrdered ? ordered.ThenBy(o => o.IsSampleOrder) : query.OrderBy(o => o.IsSampleOrder);
								 break;
							case "IsSampleOrder_desc":
                                query = isOrdered ? ordered.ThenByDescending(o => o.IsSampleOrder) : query.OrderByDescending(o => o.IsSampleOrder);
                                break;
							case "IsShipBySaleMan":
								query = isOrdered ? ordered.ThenBy(o => o.IsShipBySaleMan) : query.OrderBy(o => o.IsShipBySaleMan);
								 break;
							case "IsShipBySaleMan_desc":
                                query = isOrdered ? ordered.ThenByDescending(o => o.IsShipBySaleMan) : query.OrderByDescending(o => o.IsShipBySaleMan);
                                break;
							case "IsUrgentOrders":
								query = isOrdered ? ordered.ThenBy(o => o.IsUrgentOrders) : query.OrderBy(o => o.IsUrgentOrders);
								 break;
							case "IsUrgentOrders_desc":
                                query = isOrdered ? ordered.ThenByDescending(o => o.IsUrgentOrders) : query.OrderByDescending(o => o.IsUrgentOrders);
                                break;
							case "IDUrgentShipper":
								query = isOrdered ? ordered.ThenBy(o => o.IDUrgentShipper) : query.OrderBy(o => o.IDUrgentShipper);
								 break;
							case "IDUrgentShipper_desc":
                                query = isOrdered ? ordered.ThenByDescending(o => o.IDUrgentShipper) : query.OrderByDescending(o => o.IDUrgentShipper);
                                break;
							case "IsWholeSale":
								query = isOrdered ? ordered.ThenBy(o => o.IsWholeSale) : query.OrderBy(o => o.IsWholeSale);
								 break;
							case "IsWholeSale_desc":
                                query = isOrdered ? ordered.ThenByDescending(o => o.IsWholeSale) : query.OrderByDescending(o => o.IsWholeSale);
                                break;
							case "ReceivedDiscountFromSalesman":
								query = isOrdered ? ordered.ThenBy(o => o.ReceivedDiscountFromSalesman) : query.OrderBy(o => o.ReceivedDiscountFromSalesman);
								 break;
							case "ReceivedDiscountFromSalesman_desc":
                                query = isOrdered ? ordered.ThenByDescending(o => o.ReceivedDiscountFromSalesman) : query.OrderByDescending(o => o.ReceivedDiscountFromSalesman);
                                break;
							case "OldReceived":
								query = isOrdered ? ordered.ThenBy(o => o.OldReceived) : query.OrderBy(o => o.OldReceived);
								 break;
							case "OldReceived_desc":
                                query = isOrdered ? ordered.ThenByDescending(o => o.OldReceived) : query.OrderByDescending(o => o.OldReceived);
                                break;
							case "IDAddress":
								query = isOrdered ? ordered.ThenBy(o => o.IDAddress) : query.OrderBy(o => o.IDAddress);
								 break;
							case "IDAddress_desc":
                                query = isOrdered ? ordered.ThenByDescending(o => o.IDAddress) : query.OrderByDescending(o => o.IDAddress);
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

        public static IQueryable<tbl_SALE_Order> _pagingBuilder(IQueryable<tbl_SALE_Order> query, Dictionary<string, string> QueryStrings)
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






