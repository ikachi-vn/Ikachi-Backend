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

    public static partial class BS_WMS_Lot
    {
        public static dynamic getCustom(AppEntities db, int IDBranch, int StaffID, Dictionary<string, string> QueryStrings)
        {
            var query = _queryBuilder(db, IDBranch, StaffID, QueryStrings);
            query = _sortBuilder(query, QueryStrings);
            query = _pagingBuilder(query, QueryStrings);
            return query
            .Select(s => new
            {
                IDBranch = s.IDBranch,
                IDStorer = s.IDStorer,
                _Storer = new { s.tbl_WMS_Storer.Id, s.tbl_WMS_Storer.tbl_CRM_Contact.Name },
                Id = s.Id,
                Name = s.Name,
                IDItem = s.IDItem,
                _Item = new { s.tbl_WMS_Item.Code, s.tbl_WMS_Item.Name },
                Cube = s.Cube,
                GrossWeight = s.GrossWeight,
                NetWeight = s.NetWeight,
                QuantityOnHand = s.QuantityOnHand,
                QuantityPreallocated = s.QuantityPreallocated,
                QuantityAllocated = s.QuantityAllocated,
                QuantityPicked = s.QuantityPicked,
                QuantityOnHold = s.QuantityOnHold,
                Lottable0 = s.Lottable0,
                Lottable1 = s.Lottable1,
                Lottable2 = s.Lottable2,
                Lottable3 = s.Lottable3,
                Lottable4 = s.Lottable4,
                Lottable5 = s.Lottable5,
                Lottable6 = s.Lottable6,
                Lottable7 = s.Lottable7,
                Lottable8 = s.Lottable8,
                Lottable9 = s.Lottable9,
                IsDisabled = s.IsDisabled,
                IsDeleted = s.IsDeleted,
                CreatedBy = s.CreatedBy,
                ModifiedBy = s.ModifiedBy,
                CreatedDate = s.CreatedDate,
                ModifiedDate = s.ModifiedDate,
            });
        }

        public static tbl_WMS_Lot getOrCreate(AppEntities db, int IDBranch, int StaffID, string Username, tbl_WMS_ReceiptDetail line)
        {
            tbl_WMS_Lot result = db.tbl_WMS_Lot.FirstOrDefault(
                d => d.Lottable0 == line.Lottable0
                && d.Lottable1 == line.Lottable1
                && d.Lottable2 == line.Lottable2
                && d.Lottable3 == line.Lottable3
                && d.Lottable4 == line.Lottable4
                && d.Lottable5 == line.Lottable5
                && d.Lottable6 == line.Lottable6
                && d.Lottable7 == line.Lottable7
                && d.Lottable8 == line.Lottable8
                && d.Lottable9 == line.Lottable9
            && d.IDItem == line.IDItem
            && d.IDStorer == line.tbl_WMS_Receipt.IDStorer
            && d.IsDeleted == false);
            if (result == null)
            {
                result = new tbl_WMS_Lot()
                {
                    IDBranch = line.tbl_WMS_Receipt.IDBranch,
                    IDStorer = line.tbl_WMS_Receipt.IDStorer,
                    IDItem = line.IDItem,
                    Lottable0 = line.Lottable0,
                    Lottable1 = line.Lottable1,
                    Lottable2 = line.Lottable2,
                    Lottable3 = line.Lottable3,
                    Lottable4 = line.Lottable4,
                    Lottable5 = line.Lottable5,
                    Lottable6 = line.Lottable6,
                    Lottable7 = line.Lottable7,
                    Lottable8 = line.Lottable8,
                    Lottable9 = line.Lottable9,

                    CreatedBy = Username,
                    ModifiedBy = Username,
                    CreatedDate = DateTime.Now,
                    ModifiedDate = DateTime.Now
                };

                db.tbl_WMS_Lot.Add(result);
                db.SaveChanges();
            }

            return result;
        }
        
        public static void addQuantityOnHand(AppEntities db, int Id, decimal Quantity, decimal Cube, decimal NetWeight, decimal GrossWeight, string Username)
        {
            var lot = db.tbl_WMS_Lot.Find(Id);
            if (lot!= null)
            {
                lot.QuantityOnHand += Quantity;
                lot.Cube += Cube;
                lot.NetWeight += NetWeight;
                lot.GrossWeight += GrossWeight;

                lot.ModifiedBy = Username;
                lot.ModifiedDate = DateTime.Now;
            }
        }

        public static void addQuantityPreallocated(AppEntities db, int Id, decimal Quantity, string Username)
        {
            var lot = db.tbl_WMS_Lot.Find(Id);
            if (lot != null)
            {
                lot.QuantityPreallocated += Quantity;
                
                lot.ModifiedBy = Username;
                lot.ModifiedDate = DateTime.Now;
            }
        }

        public static void addQuantityAllocated(AppEntities db, int Id, decimal Quantity, string Username)
        {
            var lot = db.tbl_WMS_Lot.Find(Id);
            if (lot != null)
            {
                lot.QuantityPreallocated -= Quantity;
                lot.QuantityAllocated += Quantity;
                lot.ModifiedBy = Username;
                lot.ModifiedDate = DateTime.Now;
            }
        }

        public static void addQuantityPicked(AppEntities db, int Id, decimal Quantity, decimal Cube, decimal NetWeight, decimal GrossWeight, string Username)
        {
            var lot = db.tbl_WMS_Lot.Find(Id);
            if (lot != null)
            {
                lot.QuantityAllocated -= Quantity;
                lot.Cube -= Cube;
                lot.NetWeight -= NetWeight;
                lot.GrossWeight -= GrossWeight;

                lot.QuantityPicked += Quantity;
                lot.ModifiedBy = Username;
                lot.ModifiedDate = DateTime.Now;
            }
        }

        public static void addQuantityOnHold(AppEntities db, int Id, decimal Quantity, string Username)
        {
            var lot = db.tbl_WMS_Lot.Find(Id);
            if (lot != null)
            {
                lot.QuantityOnHold += Quantity;
                lot.ModifiedBy = Username;
                lot.ModifiedDate = DateTime.Now;
            }
        }
    }
}