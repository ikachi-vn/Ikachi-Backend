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
    
    
    public partial class tbl_WMS_Item
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public tbl_WMS_Item()
        {
            this.tbl_PROD_BillOfMaterials = new HashSet<tbl_PROD_BillOfMaterials>();
            this.tbl_PROD_BillOfMaterialsDetail = new HashSet<tbl_PROD_BillOfMaterialsDetail>();
            this.tbl_PROD_ItemInVendor = new HashSet<tbl_PROD_ItemInVendor>();
            this.tbl_PURCHASE_OrderDetail = new HashSet<tbl_PURCHASE_OrderDetail>();
            this.tbl_SALE_OrderDetail = new HashSet<tbl_SALE_OrderDetail>();
            this.tbl_WMS_AdjustmentDetail = new HashSet<tbl_WMS_AdjustmentDetail>();
            this.tbl_WMS_ItemInLocation = new HashSet<tbl_WMS_ItemInLocation>();
            this.tbl_WMS_ItemInWarehouseConfig = new HashSet<tbl_WMS_ItemInWarehouseConfig>();
            this.tbl_WMS_ItemUoM = new HashSet<tbl_WMS_ItemUoM>();
            this.tbl_WMS_LicencePlateNumber = new HashSet<tbl_WMS_LicencePlateNumber>();
            this.tbl_WMS_Lot = new HashSet<tbl_WMS_Lot>();
            this.tbl_WMS_LotLPNLocation = new HashSet<tbl_WMS_LotLPNLocation>();
            this.tbl_WMS_PriceListVersionDetail = new HashSet<tbl_WMS_PriceListVersionDetail>();
            this.tbl_WMS_ReceiptDetail = new HashSet<tbl_WMS_ReceiptDetail>();
            this.tbl_WMS_ReceiptPalletization = new HashSet<tbl_WMS_ReceiptPalletization>();
            this.tbl_WMS_Transaction = new HashSet<tbl_WMS_Transaction>();
        }
    
        public Nullable<int> AccountantUoM { get; set; }
        public Nullable<int> IDItemGroup { get; set; }
        public Nullable<int> IDBranch { get; set; }
        public int Id { get; set; }
        public string Code { get; set; }
        public string Name { get; set; }
        public string ForeignName { get; set; }
        public string Remark { get; set; }
        public string ForeignRemark { get; set; }
        public bool IsInventoryItem { get; set; }
        public bool IsSalesItem { get; set; }
        public bool IsPurchaseItem { get; set; }
        public Nullable<int> Sort { get; set; }
        public bool IsDisabled { get; set; }
        public bool IsDeleted { get; set; }
        public string CreatedBy { get; set; }
        public string ModifiedBy { get; set; }
        public System.DateTime CreatedDate { get; set; }
        public System.DateTime ModifiedDate { get; set; }
        public Nullable<int> InventoryUoM { get; set; }
        public Nullable<int> PurchasingUoM { get; set; }
        public Nullable<int> SalesUoM { get; set; }
        public int Expiry { get; set; }
        public Nullable<int> IDSalesTaxDefinition { get; set; }
        public Nullable<int> IDTaxDefinition { get; set; }
        public Nullable<int> IDRevenueAccount { get; set; }
        public Nullable<int> IDExemptRevenueAccount { get; set; }
        public Nullable<int> IDDefaultWarehouse { get; set; }
        public Nullable<int> IDPreferredVendor { get; set; }
        public string MfrCatalogNo { get; set; }
        public int PrefQtyInPurchaseUnits { get; set; }
        public Nullable<int> AllocationStrategy { get; set; }
        public int ProductionDateInDays { get; set; }
        public int TaxRateForWholesaler { get; set; }
        public int SalesTaxInPercent { get; set; }
        public string Lottable0 { get; set; }
        public bool IsTrackSales { get; set; }
        public int NoOfItemsPerSalesUnit { get; set; }
        public Nullable<int> IDCartonGroup { get; set; }
        public Nullable<int> PutawayStrategy { get; set; }
        public Nullable<int> BaseUoM { get; set; }
        public string Division { get; set; }
        public string Industry { get; set; }
        public string SerialNumberStart { get; set; }
        public string SerialNumberEnd { get; set; }
        public string SerialNumberNext { get; set; }
        public Nullable<int> CostToReorderItem { get; set; }
        public Nullable<int> ReorderPoint { get; set; }
        public Nullable<decimal> QuantityToReorder { get; set; }
        public Nullable<int> CostToCarryingPerUnit { get; set; }
        public string ItemType { get; set; }
        public string Lottable1 { get; set; }
        public string Lottable2 { get; set; }
        public string Lottable3 { get; set; }
        public string Lottable4 { get; set; }
        public string Lottable5 { get; set; }
        public string Lottable6 { get; set; }
        public string Lottable7 { get; set; }
        public string Lottable8 { get; set; }
        public string Lottable9 { get; set; }
        public string ExpiryUnit { get; set; }
        public bool IsPhantomItem { get; set; }
        public string TreeType { get; set; }
        public Nullable<int> TI { get; set; }
        public Nullable<int> HI { get; set; }
        //List 0:1
        public virtual tbl_BRA_Branch tbl_BRA_Branch { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tbl_PROD_BillOfMaterials> tbl_PROD_BillOfMaterials { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tbl_PROD_BillOfMaterialsDetail> tbl_PROD_BillOfMaterialsDetail { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tbl_PROD_ItemInVendor> tbl_PROD_ItemInVendor { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tbl_PURCHASE_OrderDetail> tbl_PURCHASE_OrderDetail { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tbl_SALE_OrderDetail> tbl_SALE_OrderDetail { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tbl_WMS_AdjustmentDetail> tbl_WMS_AdjustmentDetail { get; set; }
        //List 0:1
        public virtual tbl_WMS_ItemGroup tbl_WMS_ItemGroup { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tbl_WMS_ItemInLocation> tbl_WMS_ItemInLocation { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tbl_WMS_ItemInWarehouseConfig> tbl_WMS_ItemInWarehouseConfig { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tbl_WMS_ItemUoM> tbl_WMS_ItemUoM { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tbl_WMS_LicencePlateNumber> tbl_WMS_LicencePlateNumber { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tbl_WMS_Lot> tbl_WMS_Lot { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tbl_WMS_LotLPNLocation> tbl_WMS_LotLPNLocation { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tbl_WMS_PriceListVersionDetail> tbl_WMS_PriceListVersionDetail { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tbl_WMS_ReceiptDetail> tbl_WMS_ReceiptDetail { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tbl_WMS_ReceiptPalletization> tbl_WMS_ReceiptPalletization { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tbl_WMS_Transaction> tbl_WMS_Transaction { get; set; }
    }
}


namespace DTOModel
{
	using System;
	public partial class DTO_WMS_Item
	{
		public Nullable<int> AccountantUoM { get; set; }
		public Nullable<int> IDItemGroup { get; set; }
		public Nullable<int> IDBranch { get; set; }
		public int Id { get; set; }
		public string Code { get; set; }
		public string Name { get; set; }
		public string ForeignName { get; set; }
		public string Remark { get; set; }
		public string ForeignRemark { get; set; }
		public bool IsInventoryItem { get; set; }
		public bool IsSalesItem { get; set; }
		public bool IsPurchaseItem { get; set; }
		public Nullable<int> Sort { get; set; }
		public bool IsDisabled { get; set; }
		public bool IsDeleted { get; set; }
		public string CreatedBy { get; set; }
		public string ModifiedBy { get; set; }
		public System.DateTime CreatedDate { get; set; }
		public System.DateTime ModifiedDate { get; set; }
		public Nullable<int> InventoryUoM { get; set; }
		public Nullable<int> PurchasingUoM { get; set; }
		public Nullable<int> SalesUoM { get; set; }
		public int Expiry { get; set; }
		public Nullable<int> IDSalesTaxDefinition { get; set; }
		public Nullable<int> IDTaxDefinition { get; set; }
		public Nullable<int> IDRevenueAccount { get; set; }
		public Nullable<int> IDExemptRevenueAccount { get; set; }
		public Nullable<int> IDDefaultWarehouse { get; set; }
		public Nullable<int> IDPreferredVendor { get; set; }
		public string MfrCatalogNo { get; set; }
		public int PrefQtyInPurchaseUnits { get; set; }
		public Nullable<int> AllocationStrategy { get; set; }
		public int ProductionDateInDays { get; set; }
		public int TaxRateForWholesaler { get; set; }
		public int SalesTaxInPercent { get; set; }
		public string Lottable0 { get; set; }
		public bool IsTrackSales { get; set; }
		public int NoOfItemsPerSalesUnit { get; set; }
		public Nullable<int> IDCartonGroup { get; set; }
		public Nullable<int> PutawayStrategy { get; set; }
		public Nullable<int> BaseUoM { get; set; }
		public string Division { get; set; }
		public string Industry { get; set; }
		public string SerialNumberStart { get; set; }
		public string SerialNumberEnd { get; set; }
		public string SerialNumberNext { get; set; }
		public Nullable<int> CostToReorderItem { get; set; }
		public Nullable<int> ReorderPoint { get; set; }
		public Nullable<decimal> QuantityToReorder { get; set; }
		public Nullable<int> CostToCarryingPerUnit { get; set; }
		public string ItemType { get; set; }
		public string Lottable1 { get; set; }
		public string Lottable2 { get; set; }
		public string Lottable3 { get; set; }
		public string Lottable4 { get; set; }
		public string Lottable5 { get; set; }
		public string Lottable6 { get; set; }
		public string Lottable7 { get; set; }
		public string Lottable8 { get; set; }
		public string Lottable9 { get; set; }
		public string ExpiryUnit { get; set; }
		public bool IsPhantomItem { get; set; }
		public string TreeType { get; set; }
		public Nullable<int> TI { get; set; }
		public Nullable<int> HI { get; set; }
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

    public static partial class BS_WMS_Item 
    {
        public static dynamic getSearch(AppEntities db, int IDBranch, int StaffID, Dictionary<string, string> QueryStrings)
        {
            return get(db, IDBranch,StaffID, QueryStrings);
        }

		public static IQueryable<DTO_WMS_Item> get(AppEntities db, int IDBranch, int StaffID, Dictionary<string, string> QueryStrings)
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
            package.Workbook.Properties.Title = "ART-DMS WMS_Item";
            package.Workbook.Properties.Author = "hung.vu@codeart.vn";
            package.Workbook.Properties.Application = "ART-DMS";
            package.Workbook.Properties.Company = "A.R.T Distribution";

            ExcelWorkbook workBook = package.Workbook;
            if (workBook != null)
            {
                var ws = workBook.Worksheets.FirstOrDefault();
                var data = _queryBuilder(db, IDBranch, StaffID, QueryStrings).ToList();

                //var BRA_BranchList = BS_BRA_Branch.get(db,IDBranch, StaffID,QueryStrings).Select(s => new ItemModel { Id = s.Id, Name = s.Name });
                //var WMS_ItemGroupList = BS_WMS_ItemGroup.get(db,IDBranch, StaffID,QueryStrings).Select(s => new ItemModel { Id = s.Id, Name = s.Name });
                 

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

		public static DTO_WMS_Item getAnItem(AppEntities db, int IDBranch, int StaffID, int id)
        {
            var dbResult = db.tbl_WMS_Item.Find(id);

			//if (dbResult == null || (IDBranch != 0 && dbResult.IDBranch != IDBranch))
			//	return null; 
			//else 
				return toDTO(dbResult);
			
        }
		
		public static DTO_WMS_Item getAnItemByCode(AppEntities db, int IDBranch, int StaffID, string code)
        {
            var dbResult = db.tbl_WMS_Item
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
            var dbitem = db.tbl_WMS_Item.Find(Id);
            
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
					errorLog.logMessage("put_WMS_Item",e);
                    result = false;
                }
            }
            else
                if (QueryStrings.Any(d => d.Key == "ForceCreate"))
                    result =  post(db, IDBranch, StaffID, item, Username) != null;
                
            return result;
        }

        public static void patchDynamicToDB(dynamic item, tbl_WMS_Item dbitem, string Username)
        {
            Type type = typeof(tbl_WMS_Item);
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

        public static void patchDTOtoDBValue( DTO_WMS_Item item, tbl_WMS_Item dbitem)
        {
            if (item == null){
                dbitem = null;
                return;
            }
            							
			dbitem.AccountantUoM = item.AccountantUoM;							
			dbitem.IDItemGroup = item.IDItemGroup;							
			dbitem.IDBranch = item.IDBranch;							
			dbitem.Code = item.Code;							
			dbitem.Name = item.Name;							
			dbitem.ForeignName = item.ForeignName;							
			dbitem.Remark = item.Remark;							
			dbitem.ForeignRemark = item.ForeignRemark;							
			dbitem.IsInventoryItem = item.IsInventoryItem;							
			dbitem.IsSalesItem = item.IsSalesItem;							
			dbitem.IsPurchaseItem = item.IsPurchaseItem;							
			dbitem.Sort = item.Sort;							
			dbitem.IsDisabled = item.IsDisabled;							
			dbitem.IsDeleted = item.IsDeleted;							
			dbitem.InventoryUoM = item.InventoryUoM;							
			dbitem.PurchasingUoM = item.PurchasingUoM;							
			dbitem.SalesUoM = item.SalesUoM;							
			dbitem.Expiry = item.Expiry;							
			dbitem.IDSalesTaxDefinition = item.IDSalesTaxDefinition;							
			dbitem.IDTaxDefinition = item.IDTaxDefinition;							
			dbitem.IDRevenueAccount = item.IDRevenueAccount;							
			dbitem.IDExemptRevenueAccount = item.IDExemptRevenueAccount;							
			dbitem.IDDefaultWarehouse = item.IDDefaultWarehouse;							
			dbitem.IDPreferredVendor = item.IDPreferredVendor;							
			dbitem.MfrCatalogNo = item.MfrCatalogNo;							
			dbitem.PrefQtyInPurchaseUnits = item.PrefQtyInPurchaseUnits;							
			dbitem.AllocationStrategy = item.AllocationStrategy;							
			dbitem.ProductionDateInDays = item.ProductionDateInDays;							
			dbitem.TaxRateForWholesaler = item.TaxRateForWholesaler;							
			dbitem.SalesTaxInPercent = item.SalesTaxInPercent;							
			dbitem.Lottable0 = item.Lottable0;							
			dbitem.IsTrackSales = item.IsTrackSales;							
			dbitem.NoOfItemsPerSalesUnit = item.NoOfItemsPerSalesUnit;							
			dbitem.IDCartonGroup = item.IDCartonGroup;							
			dbitem.PutawayStrategy = item.PutawayStrategy;							
			dbitem.BaseUoM = item.BaseUoM;							
			dbitem.Division = item.Division;							
			dbitem.Industry = item.Industry;							
			dbitem.SerialNumberStart = item.SerialNumberStart;							
			dbitem.SerialNumberEnd = item.SerialNumberEnd;							
			dbitem.SerialNumberNext = item.SerialNumberNext;							
			dbitem.CostToReorderItem = item.CostToReorderItem;							
			dbitem.ReorderPoint = item.ReorderPoint;							
			dbitem.QuantityToReorder = item.QuantityToReorder;							
			dbitem.CostToCarryingPerUnit = item.CostToCarryingPerUnit;							
			dbitem.ItemType = item.ItemType;							
			dbitem.Lottable1 = item.Lottable1;							
			dbitem.Lottable2 = item.Lottable2;							
			dbitem.Lottable3 = item.Lottable3;							
			dbitem.Lottable4 = item.Lottable4;							
			dbitem.Lottable5 = item.Lottable5;							
			dbitem.Lottable6 = item.Lottable6;							
			dbitem.Lottable7 = item.Lottable7;							
			dbitem.Lottable8 = item.Lottable8;							
			dbitem.Lottable9 = item.Lottable9;							
			dbitem.ExpiryUnit = item.ExpiryUnit;							
			dbitem.IsPhantomItem = item.IsPhantomItem;							
			dbitem.TreeType = item.TreeType;							
			dbitem.TI = item.TI;							
			dbitem.HI = item.HI;        }

		public static DTO_WMS_Item post(AppEntities db, int IDBranch, int StaffID, dynamic item, string Username)
        {
            tbl_WMS_Item dbitem = new tbl_WMS_Item();
            if (item != null)
            {
                patchDynamicToDB(item, dbitem, Username);
                
				dbitem.CreatedBy = Username;
				dbitem.CreatedDate = DateTime.Now;				
                try
                {
					db.tbl_WMS_Item.Add(dbitem);
                    db.SaveChanges();
				
                }
                catch (DbEntityValidationException e)
                {
					errorLog.logMessage("post_WMS_Item",e);
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
                Type type = Type.GetType("BaseBusiness.BS_WMS_Item, ClassLibrary");
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
                        var target = new tbl_WMS_Item();
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
                    
                    tbl_WMS_Item dbitem = new tbl_WMS_Item();
                    if (it.Id == null || string.IsNullOrEmpty(it.Id.Value) || it.Id == "0")
                    {
                        dbitem = new tbl_WMS_Item();
                        dbitem.CreatedBy = Username;
				        dbitem.CreatedDate = DateTime.Now;
                                            }
                    else
                    {
                        dbitem = db.tbl_WMS_Item.Find((int)it.Id);
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
                        
                        if (dbitem.Id == 0) db.tbl_WMS_Item.Add(dbitem);
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
                    errorLog.logMessage("post_WMS_Item",e);
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

            var dbitems = db.tbl_WMS_Item.Where(d => IDs.Contains(d.Id));
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
                    BS_Version.update_Version(db, IDBranch, "DTO_WMS_Item", updateDate, Username);
                }
			
            }
            catch (DbEntityValidationException e)
            {
				errorLog.logMessage("delete_WMS_Item",e);
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

			
            var dbitems = db.tbl_WMS_Item.Where(d => IDs.Contains(d.Id));
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
                    BS_Version.update_Version(db, IDBranch, "DTO_WMS_Item", updateDate, Username);
                }
			
            }
            catch (DbEntityValidationException e)
            {
				errorLog.logMessage("disable_WMS_Item",e);
                result = false;
            }
            
            return result;
        }

		
		//---//
		public static bool check_Exists(AppEntities db, int id)
		{
             
            return db.tbl_WMS_Item.Any(e => e.Id == id && e.IsDeleted == false);
            
		}
		
		public static bool check_Exists(AppEntities db, string Code)
		{
             
            return db.tbl_WMS_Item.Any(e => e.Code == Code && e.IsDeleted == false);
            
		}
		
		//---//
		public static IQueryable<DTO_WMS_Item> toDTO(IQueryable<tbl_WMS_Item> query)
        {
			return query
			.Select(s => new DTO_WMS_Item(){							
				AccountantUoM = s.AccountantUoM,							
				IDItemGroup = s.IDItemGroup,							
				IDBranch = s.IDBranch,							
				Id = s.Id,							
				Code = s.Code,							
				Name = s.Name,							
				ForeignName = s.ForeignName,							
				Remark = s.Remark,							
				ForeignRemark = s.ForeignRemark,							
				IsInventoryItem = s.IsInventoryItem,							
				IsSalesItem = s.IsSalesItem,							
				IsPurchaseItem = s.IsPurchaseItem,							
				Sort = s.Sort,							
				IsDisabled = s.IsDisabled,							
				IsDeleted = s.IsDeleted,							
				CreatedBy = s.CreatedBy,							
				ModifiedBy = s.ModifiedBy,							
				CreatedDate = s.CreatedDate,							
				ModifiedDate = s.ModifiedDate,							
				InventoryUoM = s.InventoryUoM,							
				PurchasingUoM = s.PurchasingUoM,							
				SalesUoM = s.SalesUoM,							
				Expiry = s.Expiry,							
				IDSalesTaxDefinition = s.IDSalesTaxDefinition,							
				IDTaxDefinition = s.IDTaxDefinition,							
				IDRevenueAccount = s.IDRevenueAccount,							
				IDExemptRevenueAccount = s.IDExemptRevenueAccount,							
				IDDefaultWarehouse = s.IDDefaultWarehouse,							
				IDPreferredVendor = s.IDPreferredVendor,							
				MfrCatalogNo = s.MfrCatalogNo,							
				PrefQtyInPurchaseUnits = s.PrefQtyInPurchaseUnits,							
				AllocationStrategy = s.AllocationStrategy,							
				ProductionDateInDays = s.ProductionDateInDays,							
				TaxRateForWholesaler = s.TaxRateForWholesaler,							
				SalesTaxInPercent = s.SalesTaxInPercent,							
				Lottable0 = s.Lottable0,							
				IsTrackSales = s.IsTrackSales,							
				NoOfItemsPerSalesUnit = s.NoOfItemsPerSalesUnit,							
				IDCartonGroup = s.IDCartonGroup,							
				PutawayStrategy = s.PutawayStrategy,							
				BaseUoM = s.BaseUoM,							
				Division = s.Division,							
				Industry = s.Industry,							
				SerialNumberStart = s.SerialNumberStart,							
				SerialNumberEnd = s.SerialNumberEnd,							
				SerialNumberNext = s.SerialNumberNext,							
				CostToReorderItem = s.CostToReorderItem,							
				ReorderPoint = s.ReorderPoint,							
				QuantityToReorder = s.QuantityToReorder,							
				CostToCarryingPerUnit = s.CostToCarryingPerUnit,							
				ItemType = s.ItemType,							
				Lottable1 = s.Lottable1,							
				Lottable2 = s.Lottable2,							
				Lottable3 = s.Lottable3,							
				Lottable4 = s.Lottable4,							
				Lottable5 = s.Lottable5,							
				Lottable6 = s.Lottable6,							
				Lottable7 = s.Lottable7,							
				Lottable8 = s.Lottable8,							
				Lottable9 = s.Lottable9,							
				ExpiryUnit = s.ExpiryUnit,							
				IsPhantomItem = s.IsPhantomItem,							
				TreeType = s.TreeType,							
				TI = s.TI,							
				HI = s.HI,					
			});//.OrderBy(o => o.Sort == null).ThenBy(u => u.Sort);
                              
        }

		public static DTO_WMS_Item toDTO(tbl_WMS_Item dbResult)
        {
			if (dbResult != null)
			{
				return new DTO_WMS_Item()
				{							
					AccountantUoM = dbResult.AccountantUoM,							
					IDItemGroup = dbResult.IDItemGroup,							
					IDBranch = dbResult.IDBranch,							
					Id = dbResult.Id,							
					Code = dbResult.Code,							
					Name = dbResult.Name,							
					ForeignName = dbResult.ForeignName,							
					Remark = dbResult.Remark,							
					ForeignRemark = dbResult.ForeignRemark,							
					IsInventoryItem = dbResult.IsInventoryItem,							
					IsSalesItem = dbResult.IsSalesItem,							
					IsPurchaseItem = dbResult.IsPurchaseItem,							
					Sort = dbResult.Sort,							
					IsDisabled = dbResult.IsDisabled,							
					IsDeleted = dbResult.IsDeleted,							
					CreatedBy = dbResult.CreatedBy,							
					ModifiedBy = dbResult.ModifiedBy,							
					CreatedDate = dbResult.CreatedDate,							
					ModifiedDate = dbResult.ModifiedDate,							
					InventoryUoM = dbResult.InventoryUoM,							
					PurchasingUoM = dbResult.PurchasingUoM,							
					SalesUoM = dbResult.SalesUoM,							
					Expiry = dbResult.Expiry,							
					IDSalesTaxDefinition = dbResult.IDSalesTaxDefinition,							
					IDTaxDefinition = dbResult.IDTaxDefinition,							
					IDRevenueAccount = dbResult.IDRevenueAccount,							
					IDExemptRevenueAccount = dbResult.IDExemptRevenueAccount,							
					IDDefaultWarehouse = dbResult.IDDefaultWarehouse,							
					IDPreferredVendor = dbResult.IDPreferredVendor,							
					MfrCatalogNo = dbResult.MfrCatalogNo,							
					PrefQtyInPurchaseUnits = dbResult.PrefQtyInPurchaseUnits,							
					AllocationStrategy = dbResult.AllocationStrategy,							
					ProductionDateInDays = dbResult.ProductionDateInDays,							
					TaxRateForWholesaler = dbResult.TaxRateForWholesaler,							
					SalesTaxInPercent = dbResult.SalesTaxInPercent,							
					Lottable0 = dbResult.Lottable0,							
					IsTrackSales = dbResult.IsTrackSales,							
					NoOfItemsPerSalesUnit = dbResult.NoOfItemsPerSalesUnit,							
					IDCartonGroup = dbResult.IDCartonGroup,							
					PutawayStrategy = dbResult.PutawayStrategy,							
					BaseUoM = dbResult.BaseUoM,							
					Division = dbResult.Division,							
					Industry = dbResult.Industry,							
					SerialNumberStart = dbResult.SerialNumberStart,							
					SerialNumberEnd = dbResult.SerialNumberEnd,							
					SerialNumberNext = dbResult.SerialNumberNext,							
					CostToReorderItem = dbResult.CostToReorderItem,							
					ReorderPoint = dbResult.ReorderPoint,							
					QuantityToReorder = dbResult.QuantityToReorder,							
					CostToCarryingPerUnit = dbResult.CostToCarryingPerUnit,							
					ItemType = dbResult.ItemType,							
					Lottable1 = dbResult.Lottable1,							
					Lottable2 = dbResult.Lottable2,							
					Lottable3 = dbResult.Lottable3,							
					Lottable4 = dbResult.Lottable4,							
					Lottable5 = dbResult.Lottable5,							
					Lottable6 = dbResult.Lottable6,							
					Lottable7 = dbResult.Lottable7,							
					Lottable8 = dbResult.Lottable8,							
					Lottable9 = dbResult.Lottable9,							
					ExpiryUnit = dbResult.ExpiryUnit,							
					IsPhantomItem = dbResult.IsPhantomItem,							
					TreeType = dbResult.TreeType,							
					TI = dbResult.TI,							
					HI = dbResult.HI,
				};
			}
			else
				return null; 
        }

		public static IQueryable<tbl_WMS_Item> _queryBuilder(AppEntities db, int IDBranch, int StaffID, Dictionary<string, string> QueryStrings)
        {
            
			IQueryable<tbl_WMS_Item> query = db.tbl_WMS_Item.AsNoTracking();//.Where(d => d.IsDeleted == false);
			

			//Query keyword
			if (QueryStrings.Any(d => d.Key == "Keyword") && !string.IsNullOrEmpty(QueryStrings.FirstOrDefault(d => d.Key == "Keyword").Value))
            {
                var keyword = QueryStrings.FirstOrDefault(d => d.Key == "Keyword").Value;
                query = query.Where(d=>d.Name.Contains(keyword) || d.Code.Contains(keyword));
            }



			//Query AccountantUoM (Nullable<int>)
			if (QueryStrings.Any(d => d.Key == "AccountantUoMFrom") && QueryStrings.Any(d => d.Key == "AccountantUoMTo"))
                if (int.TryParse(QueryStrings.FirstOrDefault(d => d.Key == "AccountantUoMFrom").Value, out int fromVal) && int.TryParse(QueryStrings.FirstOrDefault(d => d.Key == "AccountantUoMTo").Value, out int toVal))
                    query = query.Where(d => fromVal <= d.AccountantUoM && d.AccountantUoM <= toVal);

			//Query IDItemGroup (Nullable<int>)
			if (QueryStrings.Any(d => d.Key == "IDItemGroup"))
            {
                var IDList = QueryStrings.FirstOrDefault(d => d.Key == "IDItemGroup").Value.Replace("[", "").Replace("]", "").Split(',');
                List<int?> IDs = new List<int?>();
                foreach (var item in IDList)
                    if (int.TryParse(item, out int i))
                        IDs.Add(i);
					else if (item == "null")
						IDs.Add(null);
                if (IDs.Count > 0)
                    query = query.Where(d => IDs.Contains(d.IDItemGroup));
////                    query = query.Where(d => IDs.Contains(d.IDItemGroup));
//                    
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
            

			//Query IsInventoryItem (bool)
			if (QueryStrings.Any(d => d.Key == "IsInventoryItem"))
            {
                var qValue = QueryStrings.FirstOrDefault(d => d.Key == "IsInventoryItem").Value;
                if (bool.TryParse(qValue, out bool qBoolValue))
                    query = query.Where(d => qBoolValue == d.IsInventoryItem);
            }

			//Query IsSalesItem (bool)
			if (QueryStrings.Any(d => d.Key == "IsSalesItem"))
            {
                var qValue = QueryStrings.FirstOrDefault(d => d.Key == "IsSalesItem").Value;
                if (bool.TryParse(qValue, out bool qBoolValue))
                    query = query.Where(d => qBoolValue == d.IsSalesItem);
            }

			//Query IsPurchaseItem (bool)
			if (QueryStrings.Any(d => d.Key == "IsPurchaseItem"))
            {
                var qValue = QueryStrings.FirstOrDefault(d => d.Key == "IsPurchaseItem").Value;
                if (bool.TryParse(qValue, out bool qBoolValue))
                    query = query.Where(d => qBoolValue == d.IsPurchaseItem);
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


			//Query InventoryUoM (Nullable<int>)
			if (QueryStrings.Any(d => d.Key == "InventoryUoMFrom") && QueryStrings.Any(d => d.Key == "InventoryUoMTo"))
                if (int.TryParse(QueryStrings.FirstOrDefault(d => d.Key == "InventoryUoMFrom").Value, out int fromVal) && int.TryParse(QueryStrings.FirstOrDefault(d => d.Key == "InventoryUoMTo").Value, out int toVal))
                    query = query.Where(d => fromVal <= d.InventoryUoM && d.InventoryUoM <= toVal);

			//Query PurchasingUoM (Nullable<int>)
			if (QueryStrings.Any(d => d.Key == "PurchasingUoMFrom") && QueryStrings.Any(d => d.Key == "PurchasingUoMTo"))
                if (int.TryParse(QueryStrings.FirstOrDefault(d => d.Key == "PurchasingUoMFrom").Value, out int fromVal) && int.TryParse(QueryStrings.FirstOrDefault(d => d.Key == "PurchasingUoMTo").Value, out int toVal))
                    query = query.Where(d => fromVal <= d.PurchasingUoM && d.PurchasingUoM <= toVal);

			//Query SalesUoM (Nullable<int>)
			if (QueryStrings.Any(d => d.Key == "SalesUoMFrom") && QueryStrings.Any(d => d.Key == "SalesUoMTo"))
                if (int.TryParse(QueryStrings.FirstOrDefault(d => d.Key == "SalesUoMFrom").Value, out int fromVal) && int.TryParse(QueryStrings.FirstOrDefault(d => d.Key == "SalesUoMTo").Value, out int toVal))
                    query = query.Where(d => fromVal <= d.SalesUoM && d.SalesUoM <= toVal);

			//Query Expiry (int)
			if (QueryStrings.Any(d => d.Key == "ExpiryFrom") && QueryStrings.Any(d => d.Key == "ExpiryTo"))
                if (int.TryParse(QueryStrings.FirstOrDefault(d => d.Key == "ExpiryFrom").Value, out int fromVal) && int.TryParse(QueryStrings.FirstOrDefault(d => d.Key == "ExpiryTo").Value, out int toVal))
                    query = query.Where(d => fromVal <= d.Expiry && d.Expiry <= toVal);
            
            if (QueryStrings.Any(d => d.Key == "Expiry"))
                if (int.TryParse(QueryStrings.FirstOrDefault(d => d.Key == "Expiry").Value, out int val))
                    query = query.Where(d => val == d.Expiry);


			//Query IDSalesTaxDefinition (Nullable<int>)
			if (QueryStrings.Any(d => d.Key == "IDSalesTaxDefinition"))
            {
                var IDList = QueryStrings.FirstOrDefault(d => d.Key == "IDSalesTaxDefinition").Value.Replace("[", "").Replace("]", "").Split(',');
                List<int?> IDs = new List<int?>();
                foreach (var item in IDList)
                    if (int.TryParse(item, out int i))
                        IDs.Add(i);
					else if (item == "null")
						IDs.Add(null);
                if (IDs.Count > 0)
                    query = query.Where(d => IDs.Contains(d.IDSalesTaxDefinition));
////                    query = query.Where(d => IDs.Contains(d.IDSalesTaxDefinition));
//                    
            }

			//Query IDTaxDefinition (Nullable<int>)
			if (QueryStrings.Any(d => d.Key == "IDTaxDefinition"))
            {
                var IDList = QueryStrings.FirstOrDefault(d => d.Key == "IDTaxDefinition").Value.Replace("[", "").Replace("]", "").Split(',');
                List<int?> IDs = new List<int?>();
                foreach (var item in IDList)
                    if (int.TryParse(item, out int i))
                        IDs.Add(i);
					else if (item == "null")
						IDs.Add(null);
                if (IDs.Count > 0)
                    query = query.Where(d => IDs.Contains(d.IDTaxDefinition));
////                    query = query.Where(d => IDs.Contains(d.IDTaxDefinition));
//                    
            }

			//Query IDRevenueAccount (Nullable<int>)
			if (QueryStrings.Any(d => d.Key == "IDRevenueAccount"))
            {
                var IDList = QueryStrings.FirstOrDefault(d => d.Key == "IDRevenueAccount").Value.Replace("[", "").Replace("]", "").Split(',');
                List<int?> IDs = new List<int?>();
                foreach (var item in IDList)
                    if (int.TryParse(item, out int i))
                        IDs.Add(i);
					else if (item == "null")
						IDs.Add(null);
                if (IDs.Count > 0)
                    query = query.Where(d => IDs.Contains(d.IDRevenueAccount));
////                    query = query.Where(d => IDs.Contains(d.IDRevenueAccount));
//                    
            }

			//Query IDExemptRevenueAccount (Nullable<int>)
			if (QueryStrings.Any(d => d.Key == "IDExemptRevenueAccount"))
            {
                var IDList = QueryStrings.FirstOrDefault(d => d.Key == "IDExemptRevenueAccount").Value.Replace("[", "").Replace("]", "").Split(',');
                List<int?> IDs = new List<int?>();
                foreach (var item in IDList)
                    if (int.TryParse(item, out int i))
                        IDs.Add(i);
					else if (item == "null")
						IDs.Add(null);
                if (IDs.Count > 0)
                    query = query.Where(d => IDs.Contains(d.IDExemptRevenueAccount));
////                    query = query.Where(d => IDs.Contains(d.IDExemptRevenueAccount));
//                    
            }

			//Query IDDefaultWarehouse (Nullable<int>)
			if (QueryStrings.Any(d => d.Key == "IDDefaultWarehouse"))
            {
                var IDList = QueryStrings.FirstOrDefault(d => d.Key == "IDDefaultWarehouse").Value.Replace("[", "").Replace("]", "").Split(',');
                List<int?> IDs = new List<int?>();
                foreach (var item in IDList)
                    if (int.TryParse(item, out int i))
                        IDs.Add(i);
					else if (item == "null")
						IDs.Add(null);
                if (IDs.Count > 0)
                    query = query.Where(d => IDs.Contains(d.IDDefaultWarehouse));
////                    query = query.Where(d => IDs.Contains(d.IDDefaultWarehouse));
//                    
            }

			//Query IDPreferredVendor (Nullable<int>)
			if (QueryStrings.Any(d => d.Key == "IDPreferredVendor"))
            {
                var IDList = QueryStrings.FirstOrDefault(d => d.Key == "IDPreferredVendor").Value.Replace("[", "").Replace("]", "").Split(',');
                List<int?> IDs = new List<int?>();
                foreach (var item in IDList)
                    if (int.TryParse(item, out int i))
                        IDs.Add(i);
					else if (item == "null")
						IDs.Add(null);
                if (IDs.Count > 0)
                    query = query.Where(d => IDs.Contains(d.IDPreferredVendor));
////                    query = query.Where(d => IDs.Contains(d.IDPreferredVendor));
//                    
            }

			//Query MfrCatalogNo (string)
			if (QueryStrings.Any(d => d.Key == "MfrCatalogNo_eq") && !string.IsNullOrEmpty(QueryStrings.FirstOrDefault(d => d.Key == "MfrCatalogNo_eq").Value))
            {
                var keyword = QueryStrings.FirstOrDefault(d => d.Key == "MfrCatalogNo_eq").Value;
                query = query.Where(d=>d.MfrCatalogNo == keyword);
            }
            if (QueryStrings.Any(d => d.Key == "MfrCatalogNo") && !string.IsNullOrEmpty(QueryStrings.FirstOrDefault(d => d.Key == "MfrCatalogNo").Value))
            {
                var keyword = QueryStrings.FirstOrDefault(d => d.Key == "MfrCatalogNo").Value;
                query = query.Where(d=>d.MfrCatalogNo.Contains(keyword));
            }
            

			//Query PrefQtyInPurchaseUnits (int)
			if (QueryStrings.Any(d => d.Key == "PrefQtyInPurchaseUnitsFrom") && QueryStrings.Any(d => d.Key == "PrefQtyInPurchaseUnitsTo"))
                if (int.TryParse(QueryStrings.FirstOrDefault(d => d.Key == "PrefQtyInPurchaseUnitsFrom").Value, out int fromVal) && int.TryParse(QueryStrings.FirstOrDefault(d => d.Key == "PrefQtyInPurchaseUnitsTo").Value, out int toVal))
                    query = query.Where(d => fromVal <= d.PrefQtyInPurchaseUnits && d.PrefQtyInPurchaseUnits <= toVal);
            
            if (QueryStrings.Any(d => d.Key == "PrefQtyInPurchaseUnits"))
                if (int.TryParse(QueryStrings.FirstOrDefault(d => d.Key == "PrefQtyInPurchaseUnits").Value, out int val))
                    query = query.Where(d => val == d.PrefQtyInPurchaseUnits);


			//Query AllocationStrategy (Nullable<int>)
			if (QueryStrings.Any(d => d.Key == "AllocationStrategyFrom") && QueryStrings.Any(d => d.Key == "AllocationStrategyTo"))
                if (int.TryParse(QueryStrings.FirstOrDefault(d => d.Key == "AllocationStrategyFrom").Value, out int fromVal) && int.TryParse(QueryStrings.FirstOrDefault(d => d.Key == "AllocationStrategyTo").Value, out int toVal))
                    query = query.Where(d => fromVal <= d.AllocationStrategy && d.AllocationStrategy <= toVal);

			//Query ProductionDateInDays (int)
			if (QueryStrings.Any(d => d.Key == "ProductionDateInDaysFrom") && QueryStrings.Any(d => d.Key == "ProductionDateInDaysTo"))
                if (int.TryParse(QueryStrings.FirstOrDefault(d => d.Key == "ProductionDateInDaysFrom").Value, out int fromVal) && int.TryParse(QueryStrings.FirstOrDefault(d => d.Key == "ProductionDateInDaysTo").Value, out int toVal))
                    query = query.Where(d => fromVal <= d.ProductionDateInDays && d.ProductionDateInDays <= toVal);
            
            if (QueryStrings.Any(d => d.Key == "ProductionDateInDays"))
                if (int.TryParse(QueryStrings.FirstOrDefault(d => d.Key == "ProductionDateInDays").Value, out int val))
                    query = query.Where(d => val == d.ProductionDateInDays);


			//Query TaxRateForWholesaler (int)
			if (QueryStrings.Any(d => d.Key == "TaxRateForWholesalerFrom") && QueryStrings.Any(d => d.Key == "TaxRateForWholesalerTo"))
                if (int.TryParse(QueryStrings.FirstOrDefault(d => d.Key == "TaxRateForWholesalerFrom").Value, out int fromVal) && int.TryParse(QueryStrings.FirstOrDefault(d => d.Key == "TaxRateForWholesalerTo").Value, out int toVal))
                    query = query.Where(d => fromVal <= d.TaxRateForWholesaler && d.TaxRateForWholesaler <= toVal);
            
            if (QueryStrings.Any(d => d.Key == "TaxRateForWholesaler"))
                if (int.TryParse(QueryStrings.FirstOrDefault(d => d.Key == "TaxRateForWholesaler").Value, out int val))
                    query = query.Where(d => val == d.TaxRateForWholesaler);


			//Query SalesTaxInPercent (int)
			if (QueryStrings.Any(d => d.Key == "SalesTaxInPercentFrom") && QueryStrings.Any(d => d.Key == "SalesTaxInPercentTo"))
                if (int.TryParse(QueryStrings.FirstOrDefault(d => d.Key == "SalesTaxInPercentFrom").Value, out int fromVal) && int.TryParse(QueryStrings.FirstOrDefault(d => d.Key == "SalesTaxInPercentTo").Value, out int toVal))
                    query = query.Where(d => fromVal <= d.SalesTaxInPercent && d.SalesTaxInPercent <= toVal);
            
            if (QueryStrings.Any(d => d.Key == "SalesTaxInPercent"))
                if (int.TryParse(QueryStrings.FirstOrDefault(d => d.Key == "SalesTaxInPercent").Value, out int val))
                    query = query.Where(d => val == d.SalesTaxInPercent);


			//Query Lottable0 (string)
			if (QueryStrings.Any(d => d.Key == "Lottable0_eq") && !string.IsNullOrEmpty(QueryStrings.FirstOrDefault(d => d.Key == "Lottable0_eq").Value))
            {
                var keyword = QueryStrings.FirstOrDefault(d => d.Key == "Lottable0_eq").Value;
                query = query.Where(d=>d.Lottable0 == keyword);
            }
            if (QueryStrings.Any(d => d.Key == "Lottable0") && !string.IsNullOrEmpty(QueryStrings.FirstOrDefault(d => d.Key == "Lottable0").Value))
            {
                var keyword = QueryStrings.FirstOrDefault(d => d.Key == "Lottable0").Value;
                query = query.Where(d=>d.Lottable0.Contains(keyword));
            }
            

			//Query IsTrackSales (bool)
			if (QueryStrings.Any(d => d.Key == "IsTrackSales"))
            {
                var qValue = QueryStrings.FirstOrDefault(d => d.Key == "IsTrackSales").Value;
                if (bool.TryParse(qValue, out bool qBoolValue))
                    query = query.Where(d => qBoolValue == d.IsTrackSales);
            }

			//Query NoOfItemsPerSalesUnit (int)
			if (QueryStrings.Any(d => d.Key == "NoOfItemsPerSalesUnitFrom") && QueryStrings.Any(d => d.Key == "NoOfItemsPerSalesUnitTo"))
                if (int.TryParse(QueryStrings.FirstOrDefault(d => d.Key == "NoOfItemsPerSalesUnitFrom").Value, out int fromVal) && int.TryParse(QueryStrings.FirstOrDefault(d => d.Key == "NoOfItemsPerSalesUnitTo").Value, out int toVal))
                    query = query.Where(d => fromVal <= d.NoOfItemsPerSalesUnit && d.NoOfItemsPerSalesUnit <= toVal);
            
            if (QueryStrings.Any(d => d.Key == "NoOfItemsPerSalesUnit"))
                if (int.TryParse(QueryStrings.FirstOrDefault(d => d.Key == "NoOfItemsPerSalesUnit").Value, out int val))
                    query = query.Where(d => val == d.NoOfItemsPerSalesUnit);


			//Query IDCartonGroup (Nullable<int>)
			if (QueryStrings.Any(d => d.Key == "IDCartonGroup"))
            {
                var IDList = QueryStrings.FirstOrDefault(d => d.Key == "IDCartonGroup").Value.Replace("[", "").Replace("]", "").Split(',');
                List<int?> IDs = new List<int?>();
                foreach (var item in IDList)
                    if (int.TryParse(item, out int i))
                        IDs.Add(i);
					else if (item == "null")
						IDs.Add(null);
                if (IDs.Count > 0)
                    query = query.Where(d => IDs.Contains(d.IDCartonGroup));
////                    query = query.Where(d => IDs.Contains(d.IDCartonGroup));
//                    
            }

			//Query PutawayStrategy (Nullable<int>)
			if (QueryStrings.Any(d => d.Key == "PutawayStrategyFrom") && QueryStrings.Any(d => d.Key == "PutawayStrategyTo"))
                if (int.TryParse(QueryStrings.FirstOrDefault(d => d.Key == "PutawayStrategyFrom").Value, out int fromVal) && int.TryParse(QueryStrings.FirstOrDefault(d => d.Key == "PutawayStrategyTo").Value, out int toVal))
                    query = query.Where(d => fromVal <= d.PutawayStrategy && d.PutawayStrategy <= toVal);

			//Query BaseUoM (Nullable<int>)
			if (QueryStrings.Any(d => d.Key == "BaseUoMFrom") && QueryStrings.Any(d => d.Key == "BaseUoMTo"))
                if (int.TryParse(QueryStrings.FirstOrDefault(d => d.Key == "BaseUoMFrom").Value, out int fromVal) && int.TryParse(QueryStrings.FirstOrDefault(d => d.Key == "BaseUoMTo").Value, out int toVal))
                    query = query.Where(d => fromVal <= d.BaseUoM && d.BaseUoM <= toVal);

			//Query Division (string)
			if (QueryStrings.Any(d => d.Key == "Division_eq") && !string.IsNullOrEmpty(QueryStrings.FirstOrDefault(d => d.Key == "Division_eq").Value))
            {
                var keyword = QueryStrings.FirstOrDefault(d => d.Key == "Division_eq").Value;
                query = query.Where(d=>d.Division == keyword);
            }
            if (QueryStrings.Any(d => d.Key == "Division") && !string.IsNullOrEmpty(QueryStrings.FirstOrDefault(d => d.Key == "Division").Value))
            {
                var keyword = QueryStrings.FirstOrDefault(d => d.Key == "Division").Value;
                query = query.Where(d=>d.Division.Contains(keyword));
            }
            

			//Query Industry (string)
			if (QueryStrings.Any(d => d.Key == "Industry_eq") && !string.IsNullOrEmpty(QueryStrings.FirstOrDefault(d => d.Key == "Industry_eq").Value))
            {
                var keyword = QueryStrings.FirstOrDefault(d => d.Key == "Industry_eq").Value;
                query = query.Where(d=>d.Industry == keyword);
            }
            if (QueryStrings.Any(d => d.Key == "Industry") && !string.IsNullOrEmpty(QueryStrings.FirstOrDefault(d => d.Key == "Industry").Value))
            {
                var keyword = QueryStrings.FirstOrDefault(d => d.Key == "Industry").Value;
                query = query.Where(d=>d.Industry.Contains(keyword));
            }
            

			//Query SerialNumberStart (string)
			if (QueryStrings.Any(d => d.Key == "SerialNumberStart_eq") && !string.IsNullOrEmpty(QueryStrings.FirstOrDefault(d => d.Key == "SerialNumberStart_eq").Value))
            {
                var keyword = QueryStrings.FirstOrDefault(d => d.Key == "SerialNumberStart_eq").Value;
                query = query.Where(d=>d.SerialNumberStart == keyword);
            }
            if (QueryStrings.Any(d => d.Key == "SerialNumberStart") && !string.IsNullOrEmpty(QueryStrings.FirstOrDefault(d => d.Key == "SerialNumberStart").Value))
            {
                var keyword = QueryStrings.FirstOrDefault(d => d.Key == "SerialNumberStart").Value;
                query = query.Where(d=>d.SerialNumberStart.Contains(keyword));
            }
            

			//Query SerialNumberEnd (string)
			if (QueryStrings.Any(d => d.Key == "SerialNumberEnd_eq") && !string.IsNullOrEmpty(QueryStrings.FirstOrDefault(d => d.Key == "SerialNumberEnd_eq").Value))
            {
                var keyword = QueryStrings.FirstOrDefault(d => d.Key == "SerialNumberEnd_eq").Value;
                query = query.Where(d=>d.SerialNumberEnd == keyword);
            }
            if (QueryStrings.Any(d => d.Key == "SerialNumberEnd") && !string.IsNullOrEmpty(QueryStrings.FirstOrDefault(d => d.Key == "SerialNumberEnd").Value))
            {
                var keyword = QueryStrings.FirstOrDefault(d => d.Key == "SerialNumberEnd").Value;
                query = query.Where(d=>d.SerialNumberEnd.Contains(keyword));
            }
            

			//Query SerialNumberNext (string)
			if (QueryStrings.Any(d => d.Key == "SerialNumberNext_eq") && !string.IsNullOrEmpty(QueryStrings.FirstOrDefault(d => d.Key == "SerialNumberNext_eq").Value))
            {
                var keyword = QueryStrings.FirstOrDefault(d => d.Key == "SerialNumberNext_eq").Value;
                query = query.Where(d=>d.SerialNumberNext == keyword);
            }
            if (QueryStrings.Any(d => d.Key == "SerialNumberNext") && !string.IsNullOrEmpty(QueryStrings.FirstOrDefault(d => d.Key == "SerialNumberNext").Value))
            {
                var keyword = QueryStrings.FirstOrDefault(d => d.Key == "SerialNumberNext").Value;
                query = query.Where(d=>d.SerialNumberNext.Contains(keyword));
            }
            

			//Query CostToReorderItem (Nullable<int>)
			if (QueryStrings.Any(d => d.Key == "CostToReorderItemFrom") && QueryStrings.Any(d => d.Key == "CostToReorderItemTo"))
                if (int.TryParse(QueryStrings.FirstOrDefault(d => d.Key == "CostToReorderItemFrom").Value, out int fromVal) && int.TryParse(QueryStrings.FirstOrDefault(d => d.Key == "CostToReorderItemTo").Value, out int toVal))
                    query = query.Where(d => fromVal <= d.CostToReorderItem && d.CostToReorderItem <= toVal);

			//Query ReorderPoint (Nullable<int>)
			if (QueryStrings.Any(d => d.Key == "ReorderPointFrom") && QueryStrings.Any(d => d.Key == "ReorderPointTo"))
                if (int.TryParse(QueryStrings.FirstOrDefault(d => d.Key == "ReorderPointFrom").Value, out int fromVal) && int.TryParse(QueryStrings.FirstOrDefault(d => d.Key == "ReorderPointTo").Value, out int toVal))
                    query = query.Where(d => fromVal <= d.ReorderPoint && d.ReorderPoint <= toVal);

			//Query QuantityToReorder (Nullable<decimal>)
			if (QueryStrings.Any(d => d.Key == "QuantityToReorderFrom") && QueryStrings.Any(d => d.Key == "QuantityToReorderTo"))
                if (decimal.TryParse(QueryStrings.FirstOrDefault(d => d.Key == "QuantityToReorderFrom").Value, out decimal fromVal) && decimal.TryParse(QueryStrings.FirstOrDefault(d => d.Key == "QuantityToReorderTo").Value, out decimal toVal))
                    query = query.Where(d => fromVal <= d.QuantityToReorder && d.QuantityToReorder <= toVal);

			//Query CostToCarryingPerUnit (Nullable<int>)
			if (QueryStrings.Any(d => d.Key == "CostToCarryingPerUnitFrom") && QueryStrings.Any(d => d.Key == "CostToCarryingPerUnitTo"))
                if (int.TryParse(QueryStrings.FirstOrDefault(d => d.Key == "CostToCarryingPerUnitFrom").Value, out int fromVal) && int.TryParse(QueryStrings.FirstOrDefault(d => d.Key == "CostToCarryingPerUnitTo").Value, out int toVal))
                    query = query.Where(d => fromVal <= d.CostToCarryingPerUnit && d.CostToCarryingPerUnit <= toVal);

			//Query ItemType (string)
			if (QueryStrings.Any(d => d.Key == "ItemType_eq") && !string.IsNullOrEmpty(QueryStrings.FirstOrDefault(d => d.Key == "ItemType_eq").Value))
            {
                var keyword = QueryStrings.FirstOrDefault(d => d.Key == "ItemType_eq").Value;
                query = query.Where(d=>d.ItemType == keyword);
            }
            if (QueryStrings.Any(d => d.Key == "ItemType") && !string.IsNullOrEmpty(QueryStrings.FirstOrDefault(d => d.Key == "ItemType").Value))
            {
                var keyword = QueryStrings.FirstOrDefault(d => d.Key == "ItemType").Value;
                query = query.Where(d=>d.ItemType.Contains(keyword));
            }
            

			//Query Lottable1 (string)
			if (QueryStrings.Any(d => d.Key == "Lottable1_eq") && !string.IsNullOrEmpty(QueryStrings.FirstOrDefault(d => d.Key == "Lottable1_eq").Value))
            {
                var keyword = QueryStrings.FirstOrDefault(d => d.Key == "Lottable1_eq").Value;
                query = query.Where(d=>d.Lottable1 == keyword);
            }
            if (QueryStrings.Any(d => d.Key == "Lottable1") && !string.IsNullOrEmpty(QueryStrings.FirstOrDefault(d => d.Key == "Lottable1").Value))
            {
                var keyword = QueryStrings.FirstOrDefault(d => d.Key == "Lottable1").Value;
                query = query.Where(d=>d.Lottable1.Contains(keyword));
            }
            

			//Query Lottable2 (string)
			if (QueryStrings.Any(d => d.Key == "Lottable2_eq") && !string.IsNullOrEmpty(QueryStrings.FirstOrDefault(d => d.Key == "Lottable2_eq").Value))
            {
                var keyword = QueryStrings.FirstOrDefault(d => d.Key == "Lottable2_eq").Value;
                query = query.Where(d=>d.Lottable2 == keyword);
            }
            if (QueryStrings.Any(d => d.Key == "Lottable2") && !string.IsNullOrEmpty(QueryStrings.FirstOrDefault(d => d.Key == "Lottable2").Value))
            {
                var keyword = QueryStrings.FirstOrDefault(d => d.Key == "Lottable2").Value;
                query = query.Where(d=>d.Lottable2.Contains(keyword));
            }
            

			//Query Lottable3 (string)
			if (QueryStrings.Any(d => d.Key == "Lottable3_eq") && !string.IsNullOrEmpty(QueryStrings.FirstOrDefault(d => d.Key == "Lottable3_eq").Value))
            {
                var keyword = QueryStrings.FirstOrDefault(d => d.Key == "Lottable3_eq").Value;
                query = query.Where(d=>d.Lottable3 == keyword);
            }
            if (QueryStrings.Any(d => d.Key == "Lottable3") && !string.IsNullOrEmpty(QueryStrings.FirstOrDefault(d => d.Key == "Lottable3").Value))
            {
                var keyword = QueryStrings.FirstOrDefault(d => d.Key == "Lottable3").Value;
                query = query.Where(d=>d.Lottable3.Contains(keyword));
            }
            

			//Query Lottable4 (string)
			if (QueryStrings.Any(d => d.Key == "Lottable4_eq") && !string.IsNullOrEmpty(QueryStrings.FirstOrDefault(d => d.Key == "Lottable4_eq").Value))
            {
                var keyword = QueryStrings.FirstOrDefault(d => d.Key == "Lottable4_eq").Value;
                query = query.Where(d=>d.Lottable4 == keyword);
            }
            if (QueryStrings.Any(d => d.Key == "Lottable4") && !string.IsNullOrEmpty(QueryStrings.FirstOrDefault(d => d.Key == "Lottable4").Value))
            {
                var keyword = QueryStrings.FirstOrDefault(d => d.Key == "Lottable4").Value;
                query = query.Where(d=>d.Lottable4.Contains(keyword));
            }
            

			//Query Lottable5 (string)
			if (QueryStrings.Any(d => d.Key == "Lottable5_eq") && !string.IsNullOrEmpty(QueryStrings.FirstOrDefault(d => d.Key == "Lottable5_eq").Value))
            {
                var keyword = QueryStrings.FirstOrDefault(d => d.Key == "Lottable5_eq").Value;
                query = query.Where(d=>d.Lottable5 == keyword);
            }
            if (QueryStrings.Any(d => d.Key == "Lottable5") && !string.IsNullOrEmpty(QueryStrings.FirstOrDefault(d => d.Key == "Lottable5").Value))
            {
                var keyword = QueryStrings.FirstOrDefault(d => d.Key == "Lottable5").Value;
                query = query.Where(d=>d.Lottable5.Contains(keyword));
            }
            

			//Query Lottable6 (string)
			if (QueryStrings.Any(d => d.Key == "Lottable6_eq") && !string.IsNullOrEmpty(QueryStrings.FirstOrDefault(d => d.Key == "Lottable6_eq").Value))
            {
                var keyword = QueryStrings.FirstOrDefault(d => d.Key == "Lottable6_eq").Value;
                query = query.Where(d=>d.Lottable6 == keyword);
            }
            if (QueryStrings.Any(d => d.Key == "Lottable6") && !string.IsNullOrEmpty(QueryStrings.FirstOrDefault(d => d.Key == "Lottable6").Value))
            {
                var keyword = QueryStrings.FirstOrDefault(d => d.Key == "Lottable6").Value;
                query = query.Where(d=>d.Lottable6.Contains(keyword));
            }
            

			//Query Lottable7 (string)
			if (QueryStrings.Any(d => d.Key == "Lottable7_eq") && !string.IsNullOrEmpty(QueryStrings.FirstOrDefault(d => d.Key == "Lottable7_eq").Value))
            {
                var keyword = QueryStrings.FirstOrDefault(d => d.Key == "Lottable7_eq").Value;
                query = query.Where(d=>d.Lottable7 == keyword);
            }
            if (QueryStrings.Any(d => d.Key == "Lottable7") && !string.IsNullOrEmpty(QueryStrings.FirstOrDefault(d => d.Key == "Lottable7").Value))
            {
                var keyword = QueryStrings.FirstOrDefault(d => d.Key == "Lottable7").Value;
                query = query.Where(d=>d.Lottable7.Contains(keyword));
            }
            

			//Query Lottable8 (string)
			if (QueryStrings.Any(d => d.Key == "Lottable8_eq") && !string.IsNullOrEmpty(QueryStrings.FirstOrDefault(d => d.Key == "Lottable8_eq").Value))
            {
                var keyword = QueryStrings.FirstOrDefault(d => d.Key == "Lottable8_eq").Value;
                query = query.Where(d=>d.Lottable8 == keyword);
            }
            if (QueryStrings.Any(d => d.Key == "Lottable8") && !string.IsNullOrEmpty(QueryStrings.FirstOrDefault(d => d.Key == "Lottable8").Value))
            {
                var keyword = QueryStrings.FirstOrDefault(d => d.Key == "Lottable8").Value;
                query = query.Where(d=>d.Lottable8.Contains(keyword));
            }
            

			//Query Lottable9 (string)
			if (QueryStrings.Any(d => d.Key == "Lottable9_eq") && !string.IsNullOrEmpty(QueryStrings.FirstOrDefault(d => d.Key == "Lottable9_eq").Value))
            {
                var keyword = QueryStrings.FirstOrDefault(d => d.Key == "Lottable9_eq").Value;
                query = query.Where(d=>d.Lottable9 == keyword);
            }
            if (QueryStrings.Any(d => d.Key == "Lottable9") && !string.IsNullOrEmpty(QueryStrings.FirstOrDefault(d => d.Key == "Lottable9").Value))
            {
                var keyword = QueryStrings.FirstOrDefault(d => d.Key == "Lottable9").Value;
                query = query.Where(d=>d.Lottable9.Contains(keyword));
            }
            

			//Query ExpiryUnit (string)
			if (QueryStrings.Any(d => d.Key == "ExpiryUnit_eq") && !string.IsNullOrEmpty(QueryStrings.FirstOrDefault(d => d.Key == "ExpiryUnit_eq").Value))
            {
                var keyword = QueryStrings.FirstOrDefault(d => d.Key == "ExpiryUnit_eq").Value;
                query = query.Where(d=>d.ExpiryUnit == keyword);
            }
            if (QueryStrings.Any(d => d.Key == "ExpiryUnit") && !string.IsNullOrEmpty(QueryStrings.FirstOrDefault(d => d.Key == "ExpiryUnit").Value))
            {
                var keyword = QueryStrings.FirstOrDefault(d => d.Key == "ExpiryUnit").Value;
                query = query.Where(d=>d.ExpiryUnit.Contains(keyword));
            }
            

			//Query IsPhantomItem (bool)
			if (QueryStrings.Any(d => d.Key == "IsPhantomItem"))
            {
                var qValue = QueryStrings.FirstOrDefault(d => d.Key == "IsPhantomItem").Value;
                if (bool.TryParse(qValue, out bool qBoolValue))
                    query = query.Where(d => qBoolValue == d.IsPhantomItem);
            }

			//Query TreeType (string)
			if (QueryStrings.Any(d => d.Key == "TreeType_eq") && !string.IsNullOrEmpty(QueryStrings.FirstOrDefault(d => d.Key == "TreeType_eq").Value))
            {
                var keyword = QueryStrings.FirstOrDefault(d => d.Key == "TreeType_eq").Value;
                query = query.Where(d=>d.TreeType == keyword);
            }
            if (QueryStrings.Any(d => d.Key == "TreeType") && !string.IsNullOrEmpty(QueryStrings.FirstOrDefault(d => d.Key == "TreeType").Value))
            {
                var keyword = QueryStrings.FirstOrDefault(d => d.Key == "TreeType").Value;
                query = query.Where(d=>d.TreeType.Contains(keyword));
            }
            

			//Query TI (Nullable<int>)
			if (QueryStrings.Any(d => d.Key == "TIFrom") && QueryStrings.Any(d => d.Key == "TITo"))
                if (int.TryParse(QueryStrings.FirstOrDefault(d => d.Key == "TIFrom").Value, out int fromVal) && int.TryParse(QueryStrings.FirstOrDefault(d => d.Key == "TITo").Value, out int toVal))
                    query = query.Where(d => fromVal <= d.TI && d.TI <= toVal);

			//Query HI (Nullable<int>)
			if (QueryStrings.Any(d => d.Key == "HIFrom") && QueryStrings.Any(d => d.Key == "HITo"))
                if (int.TryParse(QueryStrings.FirstOrDefault(d => d.Key == "HIFrom").Value, out int fromVal) && int.TryParse(QueryStrings.FirstOrDefault(d => d.Key == "HITo").Value, out int toVal))
                    query = query.Where(d => fromVal <= d.HI && d.HI <= toVal);
            return query;
        }
		
        public static IQueryable<tbl_WMS_Item> _sortBuilder(IQueryable<tbl_WMS_Item> query, Dictionary<string, string> QueryStrings)
        {
            if (QueryStrings.Any(d => d.Key == "SortBy"))
            {
                var sorts = QueryStrings.FirstOrDefault(d => d.Key == "SortBy").Value.Replace("[", "").Replace("]", "").Split(',');
                
                foreach (var item in sorts)
                    if (!string.IsNullOrEmpty(item))
                    {
                        var ordered = query as IOrderedQueryable<tbl_WMS_Item>;
                        bool isOrdered = ordered.ToString().IndexOf("ORDER BY") !=-1;

                        switch (item)
                        {
							case "AccountantUoM":
								query = isOrdered ? ordered.ThenBy(o => o.AccountantUoM) : query.OrderBy(o => o.AccountantUoM);
								 break;
							case "AccountantUoM_desc":
                                query = isOrdered ? ordered.ThenByDescending(o => o.AccountantUoM) : query.OrderByDescending(o => o.AccountantUoM);
                                break;
							case "IDItemGroup":
								query = isOrdered ? ordered.ThenBy(o => o.IDItemGroup) : query.OrderBy(o => o.IDItemGroup);
								 break;
							case "IDItemGroup_desc":
                                query = isOrdered ? ordered.ThenByDescending(o => o.IDItemGroup) : query.OrderByDescending(o => o.IDItemGroup);
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
							case "IsInventoryItem":
								query = isOrdered ? ordered.ThenBy(o => o.IsInventoryItem) : query.OrderBy(o => o.IsInventoryItem);
								 break;
							case "IsInventoryItem_desc":
                                query = isOrdered ? ordered.ThenByDescending(o => o.IsInventoryItem) : query.OrderByDescending(o => o.IsInventoryItem);
                                break;
							case "IsSalesItem":
								query = isOrdered ? ordered.ThenBy(o => o.IsSalesItem) : query.OrderBy(o => o.IsSalesItem);
								 break;
							case "IsSalesItem_desc":
                                query = isOrdered ? ordered.ThenByDescending(o => o.IsSalesItem) : query.OrderByDescending(o => o.IsSalesItem);
                                break;
							case "IsPurchaseItem":
								query = isOrdered ? ordered.ThenBy(o => o.IsPurchaseItem) : query.OrderBy(o => o.IsPurchaseItem);
								 break;
							case "IsPurchaseItem_desc":
                                query = isOrdered ? ordered.ThenByDescending(o => o.IsPurchaseItem) : query.OrderByDescending(o => o.IsPurchaseItem);
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
							case "InventoryUoM":
								query = isOrdered ? ordered.ThenBy(o => o.InventoryUoM) : query.OrderBy(o => o.InventoryUoM);
								 break;
							case "InventoryUoM_desc":
                                query = isOrdered ? ordered.ThenByDescending(o => o.InventoryUoM) : query.OrderByDescending(o => o.InventoryUoM);
                                break;
							case "PurchasingUoM":
								query = isOrdered ? ordered.ThenBy(o => o.PurchasingUoM) : query.OrderBy(o => o.PurchasingUoM);
								 break;
							case "PurchasingUoM_desc":
                                query = isOrdered ? ordered.ThenByDescending(o => o.PurchasingUoM) : query.OrderByDescending(o => o.PurchasingUoM);
                                break;
							case "SalesUoM":
								query = isOrdered ? ordered.ThenBy(o => o.SalesUoM) : query.OrderBy(o => o.SalesUoM);
								 break;
							case "SalesUoM_desc":
                                query = isOrdered ? ordered.ThenByDescending(o => o.SalesUoM) : query.OrderByDescending(o => o.SalesUoM);
                                break;
							case "Expiry":
								query = isOrdered ? ordered.ThenBy(o => o.Expiry) : query.OrderBy(o => o.Expiry);
								 break;
							case "Expiry_desc":
                                query = isOrdered ? ordered.ThenByDescending(o => o.Expiry) : query.OrderByDescending(o => o.Expiry);
                                break;
							case "IDSalesTaxDefinition":
								query = isOrdered ? ordered.ThenBy(o => o.IDSalesTaxDefinition) : query.OrderBy(o => o.IDSalesTaxDefinition);
								 break;
							case "IDSalesTaxDefinition_desc":
                                query = isOrdered ? ordered.ThenByDescending(o => o.IDSalesTaxDefinition) : query.OrderByDescending(o => o.IDSalesTaxDefinition);
                                break;
							case "IDTaxDefinition":
								query = isOrdered ? ordered.ThenBy(o => o.IDTaxDefinition) : query.OrderBy(o => o.IDTaxDefinition);
								 break;
							case "IDTaxDefinition_desc":
                                query = isOrdered ? ordered.ThenByDescending(o => o.IDTaxDefinition) : query.OrderByDescending(o => o.IDTaxDefinition);
                                break;
							case "IDRevenueAccount":
								query = isOrdered ? ordered.ThenBy(o => o.IDRevenueAccount) : query.OrderBy(o => o.IDRevenueAccount);
								 break;
							case "IDRevenueAccount_desc":
                                query = isOrdered ? ordered.ThenByDescending(o => o.IDRevenueAccount) : query.OrderByDescending(o => o.IDRevenueAccount);
                                break;
							case "IDExemptRevenueAccount":
								query = isOrdered ? ordered.ThenBy(o => o.IDExemptRevenueAccount) : query.OrderBy(o => o.IDExemptRevenueAccount);
								 break;
							case "IDExemptRevenueAccount_desc":
                                query = isOrdered ? ordered.ThenByDescending(o => o.IDExemptRevenueAccount) : query.OrderByDescending(o => o.IDExemptRevenueAccount);
                                break;
							case "IDDefaultWarehouse":
								query = isOrdered ? ordered.ThenBy(o => o.IDDefaultWarehouse) : query.OrderBy(o => o.IDDefaultWarehouse);
								 break;
							case "IDDefaultWarehouse_desc":
                                query = isOrdered ? ordered.ThenByDescending(o => o.IDDefaultWarehouse) : query.OrderByDescending(o => o.IDDefaultWarehouse);
                                break;
							case "IDPreferredVendor":
								query = isOrdered ? ordered.ThenBy(o => o.IDPreferredVendor) : query.OrderBy(o => o.IDPreferredVendor);
								 break;
							case "IDPreferredVendor_desc":
                                query = isOrdered ? ordered.ThenByDescending(o => o.IDPreferredVendor) : query.OrderByDescending(o => o.IDPreferredVendor);
                                break;
							case "MfrCatalogNo":
								query = isOrdered ? ordered.ThenBy(o => o.MfrCatalogNo) : query.OrderBy(o => o.MfrCatalogNo);
								 break;
							case "MfrCatalogNo_desc":
                                query = isOrdered ? ordered.ThenByDescending(o => o.MfrCatalogNo) : query.OrderByDescending(o => o.MfrCatalogNo);
                                break;
							case "PrefQtyInPurchaseUnits":
								query = isOrdered ? ordered.ThenBy(o => o.PrefQtyInPurchaseUnits) : query.OrderBy(o => o.PrefQtyInPurchaseUnits);
								 break;
							case "PrefQtyInPurchaseUnits_desc":
                                query = isOrdered ? ordered.ThenByDescending(o => o.PrefQtyInPurchaseUnits) : query.OrderByDescending(o => o.PrefQtyInPurchaseUnits);
                                break;
							case "AllocationStrategy":
								query = isOrdered ? ordered.ThenBy(o => o.AllocationStrategy) : query.OrderBy(o => o.AllocationStrategy);
								 break;
							case "AllocationStrategy_desc":
                                query = isOrdered ? ordered.ThenByDescending(o => o.AllocationStrategy) : query.OrderByDescending(o => o.AllocationStrategy);
                                break;
							case "ProductionDateInDays":
								query = isOrdered ? ordered.ThenBy(o => o.ProductionDateInDays) : query.OrderBy(o => o.ProductionDateInDays);
								 break;
							case "ProductionDateInDays_desc":
                                query = isOrdered ? ordered.ThenByDescending(o => o.ProductionDateInDays) : query.OrderByDescending(o => o.ProductionDateInDays);
                                break;
							case "TaxRateForWholesaler":
								query = isOrdered ? ordered.ThenBy(o => o.TaxRateForWholesaler) : query.OrderBy(o => o.TaxRateForWholesaler);
								 break;
							case "TaxRateForWholesaler_desc":
                                query = isOrdered ? ordered.ThenByDescending(o => o.TaxRateForWholesaler) : query.OrderByDescending(o => o.TaxRateForWholesaler);
                                break;
							case "SalesTaxInPercent":
								query = isOrdered ? ordered.ThenBy(o => o.SalesTaxInPercent) : query.OrderBy(o => o.SalesTaxInPercent);
								 break;
							case "SalesTaxInPercent_desc":
                                query = isOrdered ? ordered.ThenByDescending(o => o.SalesTaxInPercent) : query.OrderByDescending(o => o.SalesTaxInPercent);
                                break;
							case "Lottable0":
								query = isOrdered ? ordered.ThenBy(o => o.Lottable0) : query.OrderBy(o => o.Lottable0);
								 break;
							case "Lottable0_desc":
                                query = isOrdered ? ordered.ThenByDescending(o => o.Lottable0) : query.OrderByDescending(o => o.Lottable0);
                                break;
							case "IsTrackSales":
								query = isOrdered ? ordered.ThenBy(o => o.IsTrackSales) : query.OrderBy(o => o.IsTrackSales);
								 break;
							case "IsTrackSales_desc":
                                query = isOrdered ? ordered.ThenByDescending(o => o.IsTrackSales) : query.OrderByDescending(o => o.IsTrackSales);
                                break;
							case "NoOfItemsPerSalesUnit":
								query = isOrdered ? ordered.ThenBy(o => o.NoOfItemsPerSalesUnit) : query.OrderBy(o => o.NoOfItemsPerSalesUnit);
								 break;
							case "NoOfItemsPerSalesUnit_desc":
                                query = isOrdered ? ordered.ThenByDescending(o => o.NoOfItemsPerSalesUnit) : query.OrderByDescending(o => o.NoOfItemsPerSalesUnit);
                                break;
							case "IDCartonGroup":
								query = isOrdered ? ordered.ThenBy(o => o.IDCartonGroup) : query.OrderBy(o => o.IDCartonGroup);
								 break;
							case "IDCartonGroup_desc":
                                query = isOrdered ? ordered.ThenByDescending(o => o.IDCartonGroup) : query.OrderByDescending(o => o.IDCartonGroup);
                                break;
							case "PutawayStrategy":
								query = isOrdered ? ordered.ThenBy(o => o.PutawayStrategy) : query.OrderBy(o => o.PutawayStrategy);
								 break;
							case "PutawayStrategy_desc":
                                query = isOrdered ? ordered.ThenByDescending(o => o.PutawayStrategy) : query.OrderByDescending(o => o.PutawayStrategy);
                                break;
							case "BaseUoM":
								query = isOrdered ? ordered.ThenBy(o => o.BaseUoM) : query.OrderBy(o => o.BaseUoM);
								 break;
							case "BaseUoM_desc":
                                query = isOrdered ? ordered.ThenByDescending(o => o.BaseUoM) : query.OrderByDescending(o => o.BaseUoM);
                                break;
							case "Division":
								query = isOrdered ? ordered.ThenBy(o => o.Division) : query.OrderBy(o => o.Division);
								 break;
							case "Division_desc":
                                query = isOrdered ? ordered.ThenByDescending(o => o.Division) : query.OrderByDescending(o => o.Division);
                                break;
							case "Industry":
								query = isOrdered ? ordered.ThenBy(o => o.Industry) : query.OrderBy(o => o.Industry);
								 break;
							case "Industry_desc":
                                query = isOrdered ? ordered.ThenByDescending(o => o.Industry) : query.OrderByDescending(o => o.Industry);
                                break;
							case "SerialNumberStart":
								query = isOrdered ? ordered.ThenBy(o => o.SerialNumberStart) : query.OrderBy(o => o.SerialNumberStart);
								 break;
							case "SerialNumberStart_desc":
                                query = isOrdered ? ordered.ThenByDescending(o => o.SerialNumberStart) : query.OrderByDescending(o => o.SerialNumberStart);
                                break;
							case "SerialNumberEnd":
								query = isOrdered ? ordered.ThenBy(o => o.SerialNumberEnd) : query.OrderBy(o => o.SerialNumberEnd);
								 break;
							case "SerialNumberEnd_desc":
                                query = isOrdered ? ordered.ThenByDescending(o => o.SerialNumberEnd) : query.OrderByDescending(o => o.SerialNumberEnd);
                                break;
							case "SerialNumberNext":
								query = isOrdered ? ordered.ThenBy(o => o.SerialNumberNext) : query.OrderBy(o => o.SerialNumberNext);
								 break;
							case "SerialNumberNext_desc":
                                query = isOrdered ? ordered.ThenByDescending(o => o.SerialNumberNext) : query.OrderByDescending(o => o.SerialNumberNext);
                                break;
							case "CostToReorderItem":
								query = isOrdered ? ordered.ThenBy(o => o.CostToReorderItem) : query.OrderBy(o => o.CostToReorderItem);
								 break;
							case "CostToReorderItem_desc":
                                query = isOrdered ? ordered.ThenByDescending(o => o.CostToReorderItem) : query.OrderByDescending(o => o.CostToReorderItem);
                                break;
							case "ReorderPoint":
								query = isOrdered ? ordered.ThenBy(o => o.ReorderPoint) : query.OrderBy(o => o.ReorderPoint);
								 break;
							case "ReorderPoint_desc":
                                query = isOrdered ? ordered.ThenByDescending(o => o.ReorderPoint) : query.OrderByDescending(o => o.ReorderPoint);
                                break;
							case "QuantityToReorder":
								query = isOrdered ? ordered.ThenBy(o => o.QuantityToReorder) : query.OrderBy(o => o.QuantityToReorder);
								 break;
							case "QuantityToReorder_desc":
                                query = isOrdered ? ordered.ThenByDescending(o => o.QuantityToReorder) : query.OrderByDescending(o => o.QuantityToReorder);
                                break;
							case "CostToCarryingPerUnit":
								query = isOrdered ? ordered.ThenBy(o => o.CostToCarryingPerUnit) : query.OrderBy(o => o.CostToCarryingPerUnit);
								 break;
							case "CostToCarryingPerUnit_desc":
                                query = isOrdered ? ordered.ThenByDescending(o => o.CostToCarryingPerUnit) : query.OrderByDescending(o => o.CostToCarryingPerUnit);
                                break;
							case "ItemType":
								query = isOrdered ? ordered.ThenBy(o => o.ItemType) : query.OrderBy(o => o.ItemType);
								 break;
							case "ItemType_desc":
                                query = isOrdered ? ordered.ThenByDescending(o => o.ItemType) : query.OrderByDescending(o => o.ItemType);
                                break;
							case "Lottable1":
								query = isOrdered ? ordered.ThenBy(o => o.Lottable1) : query.OrderBy(o => o.Lottable1);
								 break;
							case "Lottable1_desc":
                                query = isOrdered ? ordered.ThenByDescending(o => o.Lottable1) : query.OrderByDescending(o => o.Lottable1);
                                break;
							case "Lottable2":
								query = isOrdered ? ordered.ThenBy(o => o.Lottable2) : query.OrderBy(o => o.Lottable2);
								 break;
							case "Lottable2_desc":
                                query = isOrdered ? ordered.ThenByDescending(o => o.Lottable2) : query.OrderByDescending(o => o.Lottable2);
                                break;
							case "Lottable3":
								query = isOrdered ? ordered.ThenBy(o => o.Lottable3) : query.OrderBy(o => o.Lottable3);
								 break;
							case "Lottable3_desc":
                                query = isOrdered ? ordered.ThenByDescending(o => o.Lottable3) : query.OrderByDescending(o => o.Lottable3);
                                break;
							case "Lottable4":
								query = isOrdered ? ordered.ThenBy(o => o.Lottable4) : query.OrderBy(o => o.Lottable4);
								 break;
							case "Lottable4_desc":
                                query = isOrdered ? ordered.ThenByDescending(o => o.Lottable4) : query.OrderByDescending(o => o.Lottable4);
                                break;
							case "Lottable5":
								query = isOrdered ? ordered.ThenBy(o => o.Lottable5) : query.OrderBy(o => o.Lottable5);
								 break;
							case "Lottable5_desc":
                                query = isOrdered ? ordered.ThenByDescending(o => o.Lottable5) : query.OrderByDescending(o => o.Lottable5);
                                break;
							case "Lottable6":
								query = isOrdered ? ordered.ThenBy(o => o.Lottable6) : query.OrderBy(o => o.Lottable6);
								 break;
							case "Lottable6_desc":
                                query = isOrdered ? ordered.ThenByDescending(o => o.Lottable6) : query.OrderByDescending(o => o.Lottable6);
                                break;
							case "Lottable7":
								query = isOrdered ? ordered.ThenBy(o => o.Lottable7) : query.OrderBy(o => o.Lottable7);
								 break;
							case "Lottable7_desc":
                                query = isOrdered ? ordered.ThenByDescending(o => o.Lottable7) : query.OrderByDescending(o => o.Lottable7);
                                break;
							case "Lottable8":
								query = isOrdered ? ordered.ThenBy(o => o.Lottable8) : query.OrderBy(o => o.Lottable8);
								 break;
							case "Lottable8_desc":
                                query = isOrdered ? ordered.ThenByDescending(o => o.Lottable8) : query.OrderByDescending(o => o.Lottable8);
                                break;
							case "Lottable9":
								query = isOrdered ? ordered.ThenBy(o => o.Lottable9) : query.OrderBy(o => o.Lottable9);
								 break;
							case "Lottable9_desc":
                                query = isOrdered ? ordered.ThenByDescending(o => o.Lottable9) : query.OrderByDescending(o => o.Lottable9);
                                break;
							case "ExpiryUnit":
								query = isOrdered ? ordered.ThenBy(o => o.ExpiryUnit) : query.OrderBy(o => o.ExpiryUnit);
								 break;
							case "ExpiryUnit_desc":
                                query = isOrdered ? ordered.ThenByDescending(o => o.ExpiryUnit) : query.OrderByDescending(o => o.ExpiryUnit);
                                break;
							case "IsPhantomItem":
								query = isOrdered ? ordered.ThenBy(o => o.IsPhantomItem) : query.OrderBy(o => o.IsPhantomItem);
								 break;
							case "IsPhantomItem_desc":
                                query = isOrdered ? ordered.ThenByDescending(o => o.IsPhantomItem) : query.OrderByDescending(o => o.IsPhantomItem);
                                break;
							case "TreeType":
								query = isOrdered ? ordered.ThenBy(o => o.TreeType) : query.OrderBy(o => o.TreeType);
								 break;
							case "TreeType_desc":
                                query = isOrdered ? ordered.ThenByDescending(o => o.TreeType) : query.OrderByDescending(o => o.TreeType);
                                break;
							case "TI":
								query = isOrdered ? ordered.ThenBy(o => o.TI) : query.OrderBy(o => o.TI);
								 break;
							case "TI_desc":
                                query = isOrdered ? ordered.ThenByDescending(o => o.TI) : query.OrderByDescending(o => o.TI);
                                break;
							case "HI":
								query = isOrdered ? ordered.ThenBy(o => o.HI) : query.OrderBy(o => o.HI);
								 break;
							case "HI_desc":
                                query = isOrdered ? ordered.ThenByDescending(o => o.HI) : query.OrderByDescending(o => o.HI);
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

        public static IQueryable<tbl_WMS_Item> _pagingBuilder(IQueryable<tbl_WMS_Item> query, Dictionary<string, string> QueryStrings)
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






