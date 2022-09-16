using BaseBusiness;
using ClassLibrary;
using DTOModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Caching;
using System.Web;

namespace API.Controllers
{
    public class CacheManage
    {
        //public AppEntities db = new AppEntities();

        public IEnumerable<DTO_SYS_Form> getPermissionByPositionAndRole(List<int> JobTitleIds, List<string> SysRoles)
        {
            AppEntities db = new AppEntities();
            return BS_SYS_Form.get_SYS_Form(db, JobTitleIds, SysRoles).ToList();
            //var key = string.Format("tbl_SYS_Form|{0}|{1}", string.Join(",", JobTitleIds), string.Join(",", SysRoles));

            //var cachedValue = GetFromCache<IEnumerable<DTO_SYS_Form>>(key, () =>
            //{
            //    return BS_SYS_Form.get_SYS_Form(db, JobTitleIds, SysRoles).ToList();
            //});
            //return cachedValue;
        }

        public IEnumerable<DTO_BRA_Branch> getBranch()
        {
            AppEntities db = new AppEntities();
            return BS_BRA_Branch.toDTO(db.tbl_BRA_Branch.Where(d => d.IsDeleted == false)).ToList();
            //var cachedValue = GetFromCache<IEnumerable<DTO_BRA_Branch>>("tbl_BRA_Branch|All", () =>
            //{
            //    return BS_BRA_Branch.toDTO(db.tbl_BRA_Branch.Where(d => d.IsDeleted == false)).ToList();
            //});
            //return cachedValue;
        }

        public IEnumerable<DTO_Version> getVersion()
        {
            AppEntities db = new AppEntities();
            return BS_Version.toDTO(db.tbl_Version).ToList();
            //var cachedValue = GetFromCache<IEnumerable<DTO_Version>>("tbl_Version|All", () =>
            //{
            //    return BS_Version.toDTO(db.tbl_Version).ToList();
            //}, 5);
            //return cachedValue;
        }

        public List<int?> branchRecursiveIds(int? Id)
        {
            var branchList = getBranch();

            List<int?> result = new List<int?>();
            result.Add(Id);
            result.AddRange(Traverse(branchList, Id));
            return result;
        }

        private List<int?> Traverse(IEnumerable<DTO_BRA_Branch> source, int? Id)
        {
            List<int?> Ids = new List<int?>();
            var ChildrentIds = source.Where(d => d.IDParent == Id).Select(s => new int?(s.Id)).ToList();
            foreach (var cId in ChildrentIds)
            {
                Ids.Add(cId);
                Ids.AddRange(Traverse(source, cId));
            }
            return Ids;
        }

        private bool checkIsAnyNewVerion(string tableName, List<int?> BranchIds)
        {
            string key = string.Format("{0}_{1}", tableName, string.Join(",", BranchIds));
            ObjectCache cache = MemoryCache.Default;

            var cachedValue = cache.Get(key);
            if(cachedValue != null)
            {
                var cacheTime = (DateTime)cachedValue;
                return getVersion().Any(d => d.VersionDate > cacheTime && d.Code == tableName && (BranchIds.Contains(-1) || BranchIds.Contains(d.IDBranch)));
            }
            return true;

            
        }

        //private TEntity GetFromCache<TEntity>(string key, Func<TEntity> valueFactory, int expireMinutes = 0) where TEntity : class
        //{
            
        //    return new Lazy<TEntity>(valueFactory).Value;


        //    ////key = [tableName]_[Branch]_KeyId;
        //    //var keys = key.Split('|');
        //    //string tableName = "";
        //    //List<int?> BranchIds = new List<int?>();

        //    //if (keys.Length >= 2)
        //    //{
        //    //    tableName = keys[0];
        //    //    BranchIds = keys[1].Split(',').Select(common.ToNullableInt).ToList();

        //    //    if (tableName != "tbl_Version")
        //    //    {
        //    //        if (checkIsAnyNewVerion(tableName, BranchIds))
        //    //        {
        //    //            MemoryCache.Default.Remove(key);
        //    //        }
        //    //    }
        //    //}

        //    //ObjectCache cache = MemoryCache.Default;
        //    //// the lazy class provides lazy initializtion which will eavaluate the valueFactory expression only if the item does not exist in cache
        //    //var newValue = new Lazy<TEntity>(valueFactory);
        //    //CacheItemPolicy policy = new CacheItemPolicy { AbsoluteExpiration = DateTimeOffset.Now.AddMinutes(expireMinutes) };
        //    ////The line below returns existing item or adds the new value if it doesn't exist
        //    //var value = cache.AddOrGetExisting(key, newValue, policy) as Lazy<TEntity>;
            
        //    ////value = null; //Test

        //    //if ( value == null)
        //    //{
        //    //    string keyVersion = string.Format("{0}_{1}", tableName, string.Join(",", BranchIds));
        //    //    cache.Set(keyVersion, DateTime.Now, policy);
        //    //}

        //    //return (value ?? newValue).Value; // Lazy<T> handles the locking itself
        //}
    }

    public static class common
    {
        public static int? ToNullableInt(this string s)
        {
            int i;
            if (int.TryParse(s, out i)) return i;
            if (s.ToLower() == "all") return -1;
            return null;
        }
    }
}