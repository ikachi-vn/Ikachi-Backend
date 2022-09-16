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

    public static partial class BS_WMS_Zone
    {
        public static dynamic getCustom(AppEntities db, int IDBranch, int StaffID, Dictionary<string, string> QueryStrings)
        {
            var query = _queryBuilder(db, IDBranch, StaffID, QueryStrings);
            if (QueryStrings.Any(d => d.Key == "BranchName") && !string.IsNullOrEmpty(QueryStrings.FirstOrDefault(d => d.Key == "BranchName").Value))
            {
                var keyword = QueryStrings.FirstOrDefault(d => d.Key == "BranchName").Value;
                query = query.Where(d => d.tbl_BRA_Branch.Name.Contains(keyword) || d.tbl_BRA_Branch.Code.Contains(keyword));
            }

            
            if (QueryStrings.Any(d => d.Key == "SortBy"))
            {
                var sorts = QueryStrings.FirstOrDefault(d => d.Key == "SortBy").Value.Replace("[", "").Replace("]", "").Split(',');

                foreach (var item in sorts)
                    if (!string.IsNullOrEmpty(item))
                    {
                        switch (item)
                        {
                            case "BranchName":
                                query = query.OrderBy(o => o.tbl_BRA_Branch.Name);
                                break;
                            case "BranchName_desc":
                                query = query.OrderByDescending(o => o.tbl_BRA_Branch.Name);
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
				BranchName = s.tbl_BRA_Branch.Name,
				Id = s.Id,
				Code = s.Code,
				Name = s.Name,
				Remark = s.Remark,
				Sort = s.Sort,
				
				CreatedBy = s.CreatedBy,
				ModifiedBy = s.ModifiedBy,
				CreatedDate = s.CreatedDate,
				ModifiedDate = s.ModifiedDate,
			});
		}
    }
}
