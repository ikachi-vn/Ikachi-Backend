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

    public static partial class BS_WMS_ItemInLocation
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
                IDItem = s.IDItem,
                _Item = new { s.tbl_WMS_Item.Code, s.tbl_WMS_Item.Name },
                IDLocation = s.IDLocation,
                _Location = new {
                    s.tbl_WMS_Location.Id,
                    s.tbl_WMS_Location.Name,
                    ZoneName = s.tbl_WMS_Location.tbl_WMS_Zone.Name
                },
                Id = s.Id,
                QuantityExpected = s.QuantityExpected,
                QuantityOnHand = s.QuantityOnHand,
                QuantityPreallocated = s.QuantityPreallocated,
                QuantityAllocated = s.QuantityAllocated,
                QuantityPicked = s.QuantityPicked,
                QuantityOnHold = s.QuantityOnHold,
                IsDeleted = s.IsDeleted,
                CreatedBy = s.CreatedBy,
                ModifiedBy = s.ModifiedBy,
                CreatedDate = s.CreatedDate,
                ModifiedDate = s.ModifiedDate,
            });
        }

        public static void addQuantityExpected(AppEntities db, int IDBranch, int IDStorer, int IDLocation, int IDItem, decimal Quantity, string Username)
        {
            var dbItem = getOrCreate(db, IDBranch, IDStorer, IDLocation, IDItem, Username);
            dbItem.QuantityExpected += Quantity;
            dbItem.ModifiedBy = Username;
            dbItem.ModifiedDate = DateTime.Now;
        }

        public static void addQuantityOnHand(AppEntities db, int IDBranch, int IDStorer, int IDLocation, int IDItem, decimal Quantity, string Username)
        {
            var dbItem = getOrCreate(db, IDBranch, IDStorer, IDLocation, IDItem, Username);
            dbItem.QuantityExpected -= Quantity;
            dbItem.QuantityOnHand += Quantity;
            dbItem.ModifiedBy = Username;
            dbItem.ModifiedDate = DateTime.Now;

            if (dbItem.QuantityExpected < 0) dbItem.QuantityExpected = 0;
        }

        public static void addQuantityPreallocated(AppEntities db, int IDBranch, int IDStorer, int IDLocation, int IDItem, decimal Quantity, string Username)
        {
            var dbItem = getOrCreate(db, IDBranch, IDStorer, IDLocation, IDItem, Username);
            dbItem.QuantityPreallocated += Quantity;
            dbItem.ModifiedBy = Username;
            dbItem.ModifiedDate = DateTime.Now;
        }

        public static void addQuantityAllocated(AppEntities db, int IDBranch, int IDStorer, int IDLocation, int IDItem, decimal Quantity, string Username)
        {
            var dbItem = getOrCreate(db, IDBranch, IDStorer, IDLocation, IDItem, Username);
            dbItem.QuantityPreallocated -= Quantity;
            dbItem.QuantityAllocated += Quantity;
            dbItem.ModifiedBy = Username;
            dbItem.ModifiedDate = DateTime.Now;

            if (dbItem.QuantityPreallocated < 0) dbItem.QuantityPreallocated = 0;
        }

        public static void addQuantityPicked(AppEntities db, int IDBranch, int IDStorer, int IDLocation, int IDItem, decimal Quantity, string Username)
        {
            var dbItem = getOrCreate(db, IDBranch, IDStorer, IDLocation, IDItem, Username);
            dbItem.QuantityPicked += Quantity;
            dbItem.ModifiedBy = Username;
            dbItem.ModifiedDate = DateTime.Now;
        }

        public static void addQuantityOnHold(AppEntities db, int IDBranch, int IDStorer, int IDLocation, int IDItem, decimal Quantity, string Username)
        {
            var dbItem = getOrCreate(db, IDBranch, IDStorer, IDLocation, IDItem, Username);
            dbItem.QuantityOnHold += Quantity;
            dbItem.ModifiedBy = Username;
            dbItem.ModifiedDate = DateTime.Now;
        }

        public static tbl_WMS_ItemInLocation getOrCreate(AppEntities db, int IDBranch, int IDStorer, int IDLocation, int IDItem, string Username)
        {
            var dbitem = db.tbl_WMS_ItemInLocation.FirstOrDefault(d =>
            d.IDBranch == IDBranch
            && d.IDStorer == IDStorer
            && d.IDLocation == IDLocation
            && d.IDItem == IDItem
            && d.IsDeleted == false);

            if (dbitem == null)
            {
                dbitem = new tbl_WMS_ItemInLocation()
                {
                    IDBranch = IDBranch,
                    IDStorer = IDStorer,
                    IDItem = IDItem,
                    IDLocation = IDLocation,
                    CreatedBy = Username,
                    CreatedDate = DateTime.Now,
                    ModifiedBy = Username,
                    ModifiedDate = DateTime.Now
                };

                db.tbl_WMS_ItemInLocation.Add(dbitem);
            }

            return dbitem;
        }

    }
}
