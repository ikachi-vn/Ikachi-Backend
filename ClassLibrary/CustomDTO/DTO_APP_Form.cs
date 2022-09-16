namespace DTOModel
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public partial class DTO_APP_UserInfo
    {
        public string Id { get; set; }
        public string UserName { get; set; }
        public string Email { get; set; }
        public string FullName { get; set; }
        public string Avatar { get; set; }
        public DateTime CreatedDate { get; set; }
        public string CreatedBy { get; set; }
        public int StaffID { get; set; }
        public List<string> SysRoles { get; set; }
        public IEnumerable<DTO_SYS_Form> Forms { get; set; }
        public List<int> Branchs { get; set; }
        public List<int> JobTitles { get; set; }
        public List<DTO_BRA_Branch> BranchList { get; set; }
        public IQueryable<DTO_SYS_UserSetting> UserSetting { get; set; }
        public int IDBranch { get; set; }
    }

}
