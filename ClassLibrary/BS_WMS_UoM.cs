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

    public static partial class BS_WMS_UoM
    {
        public static IQueryable<DTO_WMS_UoM> getCustom(AppEntities db, int IDBranch, int StaffID, Dictionary<string, string> QueryStrings)
        {
            if (QueryStrings.ContainsKey("IDBranch"))
            {
                QueryStrings.Remove("IDBranch");
            }

            var query = _queryBuilder(db, IDBranch, StaffID, QueryStrings);
            query = _sortBuilder(query, QueryStrings);
            query = _pagingBuilder(query, QueryStrings);

            return toDTO(query);
        }
    }
}
