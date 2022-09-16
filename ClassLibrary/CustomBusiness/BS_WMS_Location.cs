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

    public static partial class BS_WMS_Location
    {
        public static dynamic getCustom(AppEntities db, int IDBranch, int StaffID, Dictionary<string, string> QueryStrings)
        {
            var query = _queryBuilder(db, IDBranch, StaffID, QueryStrings);
            if (QueryStrings.Any(d => d.Key == "Zone") && !string.IsNullOrEmpty(QueryStrings.FirstOrDefault(d => d.Key == "Zone").Value))
            {
                var keyword = QueryStrings.FirstOrDefault(d => d.Key == "Zone").Value;
                query = query.Where(d => d.tbl_WMS_Zone.Name.Contains(keyword) || d.tbl_WMS_Zone.Code.Contains(keyword));
            }

            if (QueryStrings.Any(d => d.Key == "SortBy"))
            {
                var sorts = QueryStrings.FirstOrDefault(d => d.Key == "SortBy").Value.Replace("[", "").Replace("]", "").Split(',');

                foreach (var item in sorts)
                    if (!string.IsNullOrEmpty(item))
                    {
                        switch (item)
                        {
                            case "Zone":
                                query = query.OrderBy(o => o.tbl_WMS_Zone.Name);
                                break;
                            case "Zone_desc":
                                query = query.OrderByDescending(o => o.tbl_WMS_Zone.Name);
                                break;
                            default:
                                break;
                        }
                    }
            }
            query = _sortBuilder(query, QueryStrings);
            query = _pagingBuilder(query, QueryStrings);

            return query
            .Select(s => new
            {
                IDBranch = s.IDBranch,
                Id = s.Id,
                Code = s.Code,
                Name = s.Name,
                IDZone = s.IDZone,
                Zone = s.tbl_WMS_Zone.Name,
                Remark = s.Remark,

                CreatedBy = s.CreatedBy,
                ModifiedBy = s.ModifiedBy,
                CreatedDate = s.CreatedDate,
                ModifiedDate = s.ModifiedDate,
                LocationType = s.LocationType,
                LocationFlag = s.LocationFlag,
            });
        }

        public static string validate(tbl_WMS_Location dbitem, string property, AppEntities db, int IDBranch, int StaffID, Dictionary<string, string> QueryStrings, string Username)
        {
            string message = "";
            if (dbitem != null && property == "Name" && string.IsNullOrEmpty(dbitem.Name))
            {
                message = "Name is required.";
            }
            return string.IsNullOrEmpty(message) ? "OK" : message;
        }

        public static void fillReference(tbl_WMS_Location dbitem, dynamic it, AppEntities db, int IDBranch, int StaffID, Dictionary<string, string> QueryStrings, string Username)
        {
            if (dbitem != null)
            {
                var zone = db.tbl_WMS_Zone.Find(dbitem.IDZone);
                dbitem.IDBranch = zone.IDBranch;
            }
        }

        public static tbl_WMS_Location getPutawayLocation(AppEntities db, int IDWarehouse, int IDStorer, int IDItem, int StaffID, string Username)
        {
            tbl_WMS_Location result = null;

            var item = db.tbl_WMS_Item.Find(IDItem);
            var itemConfig = item.tbl_WMS_ItemInWarehouseConfig.FirstOrDefault(d => d.IDStorer == IDStorer && d.IDBranch == IDWarehouse);

            if (itemConfig != null)
            {
                result = db.tbl_WMS_Location.FirstOrDefault(d => d.Id == itemConfig.PutawayLocation);
            }

            if (result == null)
            {
                result = db.tbl_WMS_Location.FirstOrDefault(d => d.Name == "UNKNOWN" && d.IDBranch == IDWarehouse && d.IsDeleted == false);
            }

            return result;
        }
    }
}