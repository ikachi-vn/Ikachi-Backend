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

    public static partial class BS_SALE_OrderDetail
    {
        public static dynamic getCustom(AppEntities db, int IDBranch, int StaffID, Dictionary<string, string> QueryStrings)
        {
            var query = BS_SALE_OrderDetail._queryBuilder(db, IDBranch, StaffID, QueryStrings);
            query = BS_SALE_OrderDetail._sortBuilder(query, QueryStrings);
            query = BS_SALE_OrderDetail._pagingBuilder(query, QueryStrings);

            var ids = query.Select(s => s.Id).ToList();
            var q = db.tbl_SALE_OrderDetail.Where(d => ids.Contains(d.Id));
            var result = BS_SALE_OrderDetail._sortBuilder(q, QueryStrings).Select(s => new
            {
                Id = s.Id,
                IDOrder = s.IDOrder,
                IDItem = s.IDItem,
                ItemName = s.tbl_WMS_Item.Name,
                UoMName = s.tbl_WMS_ItemUoM.Name,
                IDUoM = s.IDUoM,
                UoMPrice = s.UoMPrice,
                Quantity = s.Quantity,
                UoMSwap = s.UoMSwap,
                IDBaseUoM = s.IDBaseUoM,
                BaseQuantity = s.BaseQuantity,
                IsPromotionItem = s.IsPromotionItem,
                IDTax = s.IDTax,
                TaxRate = s.TaxRate,

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

                ShippedQuantity = s.ShippedQuantity,
                ReturnedQuantity = s.ReturnedQuantity,

                TotalBeforeDiscount = s.TotalBeforeDiscount,
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
                Remark = s.Remark,
            });

            return result;
        }

        public static DTO_SALE_OrderDetail postCustom(AppEntities db, int IDBranch, int StaffID, dynamic item, string Username)
        {
            return null;
        }
    }
}