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

    public static partial class BS_SYS_Form
    {
        public static IQueryable<DTO_SYS_Form> get_SYS_Form(AppEntities db, List<int> IDJobtitles, List<string> SysRoles)
        {
            var query = db.tbl_SYS_Form.Where(d => d.IsDeleted == false);

            if (SysRoles.Contains("GUEST"))
            {
                query = query.Where(d => d.Type == 0); //Public view
            }
            else if(SysRoles.Contains("HOST"))
            {
                query = query.Where(d => d.Type > 0 ); //View - Hidden view - Function
            }
            else
            {
                query = query.Where(d => d.tbl_SYS_PermissionList.Any(c => IDJobtitles.Contains(c.IDBranch) && c.Visible == true));
            }

            query = query.OrderBy(o => o.Sort);

            return toDTO(query);

        }

    }
}
