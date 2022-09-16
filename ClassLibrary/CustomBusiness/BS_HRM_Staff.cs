
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

    public static partial class BS_HRM_Staff
    {

        public static dynamic getSearchCustom(AppEntities db, int IDBranch, int StaffID, Dictionary<string, string> QueryStrings)
        {
            var query = BS_HRM_Staff._queryBuilder(db, IDBranch, StaffID, QueryStrings);

            if (QueryStrings.Any(d => d.Key == "Term") && !string.IsNullOrEmpty(QueryStrings.FirstOrDefault(d => d.Key == "Term").Value))
            {
                var keyword = QueryStrings.FirstOrDefault(d => d.Key == "Term").Value;
                int.TryParse(keyword, out int id);

                query = query.Where(d => d.FullName.Contains(keyword) || d.Code.Contains(keyword) || d.PhoneNumber.Contains(keyword) || d.Id == id);
            }

            query = BS_HRM_Staff._sortBuilder(query, QueryStrings);
            query = BS_HRM_Staff._pagingBuilder(query, QueryStrings);

            return query.Select(s => new
            {
                s.Id,
                s.Code,
                s.FullName,
                s.PhoneNumber
            }).ToList();
        }
    }
}
