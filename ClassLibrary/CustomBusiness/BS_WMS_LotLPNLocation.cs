
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

    public static partial class BS_WMS_LotLPNLocation
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
                IDItem = s.IDItem,
                _Item = new { s.tbl_WMS_Item.Code, s.tbl_WMS_Item.Name },
                
                Id = s.Id,
                IDLot = s.IDLot,
                _Lot = new { s.tbl_WMS_Lot.Lottable0, s.tbl_WMS_Lot.Lottable1, s.tbl_WMS_Lot.Lottable5, s.tbl_WMS_Lot.Lottable6 },
                IDLPN = s.IDLPN,
                _LPN = new
                {
                    s.tbl_WMS_LicencePlateNumber.Id,
                    s.tbl_WMS_LicencePlateNumber.Code,
                },
                IDLocation = s.IDLocation,
                _Location = s.tbl_WMS_Location == null ? null : new
                {
                    s.tbl_WMS_Location.Id,
                    s.tbl_WMS_Location.Name,
                    ZoneName = s.tbl_WMS_Location.tbl_WMS_Zone.Name
                },
                
                QuantityExpected = s.QuantityExpected,
                QuantityOnHand = s.QuantityOnHand,
                QuantityAllocated = s.QuantityAllocated,
                QuantityPicked = s.QuantityPicked,
                QuantityOnHold = s.QuantityOnHold,
                QuantityPickInProcess = s.QuantityPickInProcess,
                QuantityPendingMoveIn = s.QuantityPendingMoveIn,
                IsDisabled = s.IsDisabled,
                IsDeleted = s.IsDeleted,
                CreatedBy = s.CreatedBy,
                ModifiedBy = s.ModifiedBy,
                CreatedDate = s.CreatedDate,
                ModifiedDate = s.ModifiedDate,
            });//;
        }

        public static void addQuantityExpected(AppEntities db, int IDBranch, int IDStorer, int IDLocation, int IDItem, int IDLot, int IDLPN, decimal Quantity, string Username)
        {
            var dbItem = getOrCreate(db, IDBranch, IDStorer, IDLocation, IDItem, IDLot, IDLPN, Username);
            dbItem.QuantityExpected += Quantity;
            dbItem.ModifiedBy = Username;
            dbItem.ModifiedDate = DateTime.Now;
        }

        public static void addQuantityOnHand(AppEntities db, int IDBranch, int IDStorer, int IDLocation, int IDItem, int IDLot, int IDLPN, decimal Quantity, string Username)
        {
            var dbItem = getOrCreate(db, IDBranch, IDStorer, IDLocation, IDItem, IDLot, IDLPN, Username);
            dbItem.QuantityExpected -= Quantity;
            dbItem.QuantityOnHand += Quantity;
            dbItem.ModifiedBy = Username;
            dbItem.ModifiedDate = DateTime.Now;

            if (dbItem.QuantityExpected < 0) dbItem.QuantityExpected = 0;
        }

        public static void addQuantityAllocated(AppEntities db, int IDBranch, int IDStorer, int IDLocation, int IDItem, int IDLot, int IDLPN, decimal Quantity, string Username)
        {
            var dbItem = getOrCreate(db, IDBranch, IDStorer, IDLocation, IDItem, IDLot, IDLPN, Username);
            dbItem.QuantityAllocated += Quantity;
            dbItem.ModifiedBy = Username;
            dbItem.ModifiedDate = DateTime.Now;

        }

        public static void addQuantityPicked(AppEntities db, int IDBranch, int IDStorer, int IDLocation, int IDItem, int IDLot, int IDLPN, decimal Quantity, string Username)
        {
            var dbItem = getOrCreate(db, IDBranch, IDStorer, IDLocation, IDItem, IDLot, IDLPN, Username);
            dbItem.QuantityAllocated -= Quantity;
            dbItem.QuantityPicked += Quantity;
            dbItem.ModifiedBy = Username;
            dbItem.ModifiedDate = DateTime.Now;
        }

        public static void addQuantityOnHold(AppEntities db, int IDBranch, int IDStorer, int IDLocation, int IDItem, int IDLot, int IDLPN, decimal Quantity, string Username)
        {
            var dbItem = getOrCreate(db, IDBranch, IDStorer, IDLocation, IDItem, IDLot, IDLPN, Username);
            dbItem.QuantityOnHold += Quantity;
            dbItem.ModifiedBy = Username;
            dbItem.ModifiedDate = DateTime.Now;
        }
        
        public static void addQuantityPickInProcess(AppEntities db, int IDBranch, int IDStorer, int IDLocation, int IDItem, int IDLot, int IDLPN, decimal Quantity, string Username)
        {
            var dbItem = getOrCreate(db, IDBranch, IDStorer, IDLocation, IDItem, IDLot, IDLPN, Username);
            dbItem.QuantityPickInProcess += Quantity;
            dbItem.ModifiedBy = Username;
            dbItem.ModifiedDate = DateTime.Now;
        }
        
        public static void addQuantityPendingMoveIn(AppEntities db, int IDBranch, int IDStorer, int IDLocation, int IDItem, int IDLot, int IDLPN, decimal Quantity, string Username)
        {
            var dbItem = getOrCreate(db, IDBranch, IDStorer, IDLocation, IDItem, IDLot, IDLPN, Username);
            dbItem.QuantityPendingMoveIn += Quantity;
            dbItem.ModifiedBy = Username;
            dbItem.ModifiedDate = DateTime.Now;
        }

        public static tbl_WMS_LotLPNLocation getOrCreate(AppEntities db, int IDBranch, int IDStorer, int IDLocation, int IDItem, int IDLot, int IDLPN, string Username)
        {
            var dbitem = db.tbl_WMS_LotLPNLocation.FirstOrDefault(d =>
            d.IDBranch == IDBranch
            && d.IDLocation == IDLocation
            && d.IDStorer == IDStorer
            && d.IDItem == IDItem
            && d.IDLot == IDLot
            && d.IDLPN == IDLPN
            && d.IsDeleted == false);

            if (dbitem == null)
            {
                dbitem = new tbl_WMS_LotLPNLocation()
                {
                    IDBranch = IDBranch,
                    IDLocation = IDLocation,
                    IDStorer = IDStorer,
                    IDItem = IDItem,
                    IDLot = IDLot,
                    IDLPN = IDLPN,
                    
                    CreatedBy = Username,
                    CreatedDate = DateTime.Now,
                    ModifiedBy = Username,
                    ModifiedDate = DateTime.Now
                };

                db.tbl_WMS_LotLPNLocation.Add(dbitem);
            }

            return dbitem;
        }

    }
}

