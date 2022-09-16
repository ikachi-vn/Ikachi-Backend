namespace DTOModel
{
    using System;
    using System.Collections.Generic;

    public partial class DTO_SALE_Order
    {
        public DTO_CRM_Contact Customer { get; set; }
        public List<DTO_SALE_OrderDetail> OrderLines { get; set; }
        //public List<DTO_SALE_OrderDetail> OrderLines { get; set; }
        
    }

    public partial class DTO_SALE_OrderDetail
    {
        public int index { get; set; }
        

        
        public string ItemCode { get; set; }
        public string ItemName { get; set; }
        public string UoMName { get; set; }
    }

    public class SaleReport
    {
        public int? IDBranch { get; set; }
        public string BranchName { get; set; }

        public int IDContact { get; set; }
        public string ContactCode { get; set; }
        public string ContactName { get; set; }
        public string WorkPhone { get; set; }

        public DateTime? OrderDate { get; set; }
        public int? IDSaleOrder { get; set; }

        public int? IDSaleman { get; set; }
        public string FullName { get; set; }

        public int IDItemGroup { get; set; }
        public string ItemGroup { get; set; }

        public int IDItemGroupRoot { get; set; }
        public string ItemGroupRoot { get; set; }

        public int IDItem { get; set; }
        public string ItemCode { get; set; }
        public string ItemName { get; set; }
        
        public int IDUoM { get; set; }
        public string UoM { get; set; }
        
        public decimal Quantity { get; set; }
        public bool IsPromotionItem { get; set; }
        public decimal PromotionQuantity { get; set; }
        
        public decimal OriginalTotalBeforeDiscount { get; set; }
        public decimal OriginalDiscount1 { get; set; }
        public decimal OriginalDiscount2 { get; set; }
        public decimal OriginalTotalDiscount { get; set; }
        public decimal OriginalTotalPromotion { get; set; }
        public decimal OriginalTotalAfterDiscount { get; set; }

        public decimal ShippedQuantity { get; set; }
        public decimal TotalBeforeDiscount { get; set; }
        public decimal Discount1 { get; set; }
        public decimal Discount2 { get; set; }
        public decimal TotalDiscount { get; set; }
        public decimal TotalPromotion { get; set; }
        public decimal TotalAfterDiscount { get; set; }
    }

    public class DTO_MergeSaleOrders
    {
        public List<int> Ids { get; set; }
        public int IDContact { get; set; }
        public bool IsSampleOrder { get; set; }
        public bool IsUrgentOrders { get; set; }
        public bool IsWholeSale { get; set; }
        public int IDBranch { get; set; }
        public int IDOwner { get; set; }
        public string CreatedBy { get; set; }
    }

    public class DTO_SplitSaleOrders
    {
        public int Id { get; set; }
        public int IDBranch { get; set; }
        public int IDOwner { get; set; }
        public string CreatedBy { get; set; }

        public List<DTO_SALE_Order> SplitedOrders { get; set; }
    }

    public class DTO_ApproveOrders
    {
        public List<int> Ids { get; set; }
    }

    public class DTO_CreateReceipt
    {
        public int IDBranch { get; set; }
        public List<int> Ids { get; set; }
        public int IDOwner { get; set; }
        public decimal Amount { get; set; }
        public DateTime DocumentDate { get; set; }
        public DateTime PostDate { get; set; }
    }

}