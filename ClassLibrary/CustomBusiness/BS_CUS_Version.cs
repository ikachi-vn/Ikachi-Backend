
namespace BaseBusiness
{
    using System;
    using System.Collections.Generic;
    using System.Data;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    using System.Linq;
    using DTOModel;
    using ClassLibrary;
    using System.Data.Entity.Validation;

    public static partial class BS_Version
    {
        public static IQueryable<DTO_Version_View> get_Version(AppEntities db, int IDBranch, Dictionary<string, string> QueryStrings, bool Custom)
        {
            var query = db.tbl_Version
            .Where(d => d.IsDeleted == false && (d.IDBranch == IDBranch || d.IDBranch==null ));

            return query.Select(s => new DTO_Version_View() {
                Code = s.Code,
                VersionDate = s.VersionDate
            });

        }
        public static void update_Version(AppEntities db, int? IDBranch, string Code, DateTime VersionDate, string Username)
        {

            //if(!IDBranch.HasValue || IDBranch == 0)
            //{
            //    return;
            //}


            tbl_Version dbitem = db.tbl_Version.FirstOrDefault(d => d.IDBranch == IDBranch && d.Code == Code);

            bool isNewItem = dbitem == null;

            if (isNewItem)
            {
                dbitem = new tbl_Version();
                dbitem.IDBranch = IDBranch;
                dbitem.Code = Code;
                dbitem.CreatedBy = Username;
                dbitem.CreatedDate = DateTime.Now;
                db.tbl_Version.Add(dbitem);
            }
            
            dbitem.VersionDate = VersionDate;
            dbitem.ModifiedBy = Username;
            dbitem.ModifiedDate = DateTime.Now;

            try
            {
                
                db.SaveChanges();

            }
            catch (DbEntityValidationException e)
            {
                errorLog.logMessage("update_Version", e);
            }

        }
    }
}