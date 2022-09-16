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

    public static partial class BS_WMS_ItemGroup
    {
        public static dynamic getSearchCustom(AppEntities db, int IDBranch, int StaffID, Dictionary<string, string> QueryStrings)
        {
            var query = BS_WMS_ItemGroup._queryBuilder(db, IDBranch, StaffID, QueryStrings);

            if (QueryStrings.Any(d => d.Key == "Keyword") && !string.IsNullOrEmpty(QueryStrings.FirstOrDefault(d => d.Key == "Keyword").Value))
            {

                List<DTO_WMS_ItemGroup> allItems = db.tbl_WMS_ItemGroup.Where(d => d.IsDeleted == false).Select(s => new DTO_WMS_ItemGroup()
                {
                    Id = s.Id,
                    IDParent = s.IDParent
                }).ToList();

                List<int> Ids = new List<int>();

                foreach (var item in query)
                {
                    Ids.Add(item.Id);
                    Ids.AddRange(BS_WMS_ItemGroup.findParent(allItems, item.Id));
                    Ids.AddRange(BS_WMS_ItemGroup.findChildrent(allItems, item.Id).Select(s => s));

                    query = db.tbl_WMS_ItemGroup.Where(d => Ids.Contains(d.Id));
                }

            }

            query = BS_WMS_ItemGroup._sortBuilder(query, QueryStrings);
            query = BS_WMS_ItemGroup._pagingBuilder(query, QueryStrings);

            return query.Select(s => new { s.Id, s.IDParent, s.Name });

        }
    }
}
