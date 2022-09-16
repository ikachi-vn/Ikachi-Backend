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

    public static partial class BS_PROD_ItemInVendor
    {
        public static dynamic getCustom(AppEntities db, int IDBranch, int StaffID, Dictionary<string, string> QueryStrings)
        {
            var query = _queryBuilder(db, IDBranch, StaffID, QueryStrings);
            query = _sortBuilder(query, QueryStrings);
            query = _pagingBuilder(query, QueryStrings);

            return query
            .Select(s => new
            {
                Id = s.Id,
                IDVendor = s.IDVendor,
                IDItem = s.IDItem,
                _Item=new
                {
                    s.tbl_WMS_Item.Id,
                    s.tbl_WMS_Item.Code,
                    s.tbl_WMS_Item.Name,
                }

            });
        }

    }
}
