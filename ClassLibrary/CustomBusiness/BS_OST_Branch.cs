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

    public static partial class BS_BRA_Branch
    {
        public static dynamic getSearchCustom(AppEntities db, int IDBranch, int StaffID, Dictionary<string, string> QueryStrings)
        {
            List<int> BranchIds = new List<int>();

            if (QueryStrings.Any(d => d.Key == "Id"))
            {
                var IDList = QueryStrings.FirstOrDefault(d => d.Key == "Id").Value.Replace("[", "").Replace("]", "").Split(',');
                
                foreach (var item in IDList)
                    if (int.TryParse(item, out int i))
                        BranchIds.Add(i);
                QueryStrings.Remove("Id");
            }

            var query = BS_BRA_Branch._queryBuilder(db, IDBranch, StaffID, QueryStrings);
            
            List<DTO_BRA_Branch> allItems = db.tbl_BRA_Branch.Where(d => d.IsDeleted == false).Select(s => new DTO_BRA_Branch()
            {
                Id = s.Id,
                IDParent = s.IDParent
            }).ToList();

            List<int> Ids = new List<int>();

            foreach (var item in query)
            {
                Ids.Add(item.Id);
                Ids.AddRange(BS_BRA_Branch.findParent(allItems, item.Id));
                Ids.AddRange(BS_BRA_Branch.findChildrent(allItems, item.Id).Select(s => s));
            }

            query = db.tbl_BRA_Branch.Where(d => Ids.Contains(d.Id));
            //query = query.Where(d => BranchIds.Contains(d.Id) || d.IDType == 119);

            query = BS_BRA_Branch._sortBuilder(query, QueryStrings);
            query = BS_BRA_Branch._pagingBuilder(query, QueryStrings);

            query = _sortBuilder(query, QueryStrings);
            query = _pagingBuilder(query, QueryStrings);

            return query.Select(s => new
            {
                IDParent = s.IDParent,
                IDType = s.IDType,
                Id = s.Id,
                Code = s.Code,
                Name = s.Name,
                Remark = s.Remark
            });
        }

        public static IQueryable<DTO_BRA_Branch> getUserBranch(AppEntities db, List<int> BranchIds)
        {
            var query = db.tbl_BRA_Branch.AsNoTracking().Where(d => BranchIds.Contains(d.Id));
            List<DTO_BRA_Branch> allItems = db.tbl_BRA_Branch.Where(d => d.IsDeleted == false).Select(s => new DTO_BRA_Branch()
            {
                Id = s.Id,
                IDParent = s.IDParent
            }).ToList();

            List<int> Ids = new List<int>();

            foreach (var item in query)
            {
                Ids.Add(item.Id);
                Ids.AddRange(BS_BRA_Branch.findParent(allItems, item.Id));
                Ids.AddRange(BS_BRA_Branch.findChildrent(allItems, item.Id).Select(s => s));
            }

            query = db.tbl_BRA_Branch.Where(d => Ids.Contains(d.Id));
            query = _sortBuilder(query, new Dictionary<string, string>());
            return toDTO(query);
        }


    }
}
