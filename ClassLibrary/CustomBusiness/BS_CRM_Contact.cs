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

    public static partial class BS_CRM_Contact
    {
        public static dynamic getCustom(AppEntities db, int IDBranch, int StaffID, Dictionary<string, string> QueryStrings)
        {
            var query = BS_CRM_Contact._queryBuilder(db, IDBranch, StaffID, QueryStrings);
            //Query RefID (string)
            if (QueryStrings.Any(d => d.Key == "CustomerName") && !string.IsNullOrEmpty(QueryStrings.FirstOrDefault(d => d.Key == "CustomerName").Value))
            {
                var keyword = QueryStrings.FirstOrDefault(d => d.Key == "CustomerName").Value;
                if (keyword.StartsWith("C:") && int.TryParse(keyword.Replace("C:", ""), out int id))
                {
                    query = query.Where(d => d.Id == id);
                }
                else
                {
                    query = query.Where(d =>
                    d.Name.Contains(keyword)
                    || d.Code.Contains(keyword)
                    || d.WorkPhone.Contains(keyword)
                    || d.tbl_CRM_ContactReference.Any(dd => dd.Code.Contains(keyword))
                    );
                }
            }

            query = BS_CRM_Contact._sortBuilder(query, QueryStrings);
            query = BS_CRM_Contact._pagingBuilder(query, QueryStrings);

            var result = query.Select(s => new
            {
                s.Id,
                s.Code,
                s.Name,
                s.WorkPhone,

                RefCodes = s.tbl_CRM_ContactReference.Select(ss => new { ss.Code, IDVendor = ss.tbl_CRM_Contact.Id, VendorName = ss.tbl_CRM_Contact.Name }),
                s.IDBranch,
                s.IsOutlets,
                s.IsStorer,
                s.IsVendor,
                s.IsCarrier,
                s.IsCustomer,
                s.IsDistributor,
                s.IsBranch,
                s.IsStaff,
                s.IsPersonal,
                s.Title,
                PersonInfo = new
                {
                    s.tbl_CRM_PersonInfo.FullName,
                    s.tbl_CRM_PersonInfo.FirstName,
                    s.tbl_CRM_PersonInfo.LastName,
                    s.tbl_CRM_PersonInfo.DateOfBirth,
                    s.tbl_CRM_PersonInfo.Gender
                }
            }).ToList();

            return result;
        }

        public static dynamic getSearchCustom(AppEntities db, int IDBranch, int StaffID, Dictionary<string, string> QueryStrings)
        {
            var query = _queryBuilder(db, IDBranch, StaffID, QueryStrings);

            if (QueryStrings.Any(d => d.Key == "Term") && !string.IsNullOrEmpty(QueryStrings.FirstOrDefault(d => d.Key == "Term").Value))
            {
                var keyword = QueryStrings.FirstOrDefault(d => d.Key == "Term").Value;
                int.TryParse(keyword, out int id);

                query = query.Where(d => d.Name.Contains(keyword) || d.Code.Contains(keyword) || d.WorkPhone.Contains(keyword) || d.Email.Contains(keyword) || d.Id == id);
            }

            query = _sortBuilder(query, QueryStrings);
            query = _pagingBuilder(query, QueryStrings);

            List<int> Ids = query.Select(s => s.Id).ToList();


            var result = db.tbl_CRM_PartnerAddress.Where(d => Ids.Contains(d.IDPartner) && !d.IsDeleted).Select(s => new
            {
                
                Id = s.IDPartner,
                s.tbl_CRM_Contact.Code,
                s.tbl_CRM_Contact.Name,
                s.tbl_CRM_Contact.WorkPhone,
                IDAddress = s.Id,
                Address = new
                {
                    s.Id,
                    s.AddressLine1,
                    s.AddressLine2,
                    s.Ward,
                    s.District,
                    s.Province,
                    s.Country,
                    s.Contact,
                    s.Phone1,
                    s.Phone2
                }
            }).ToList();

            return result;
        }

        public static bool putCustom(AppEntities db, int IDBranch, int StaffID, int Id, dynamic item, string Username, Dictionary<string, string> QueryStrings)
        {
            bool result = false;
            var dbitem = db.tbl_CRM_Contact.Find(Id);

            if (dbitem != null)
            {
                patchDynamicToDB(item, dbitem, Username);
                try
                {
                    if (item.PersonInfo != null)
                    {
                        BS_CRM_PersonInfo.put(db, IDBranch, StaffID, Id, item.PersonInfo, Username, QueryStrings);
                    }

                    db.SaveChanges();
                    result = true;
                }
                catch (DbEntityValidationException e)
                {
                    errorLog.logMessage("put_CRM_Contact", e);
                    result = false;
                }
            }
            else
                if (QueryStrings.Any(d => d.Key == "ForceCreate"))
                result = post(db, IDBranch, StaffID, item, Username) != null;

            return result;
        }

        public static dynamic postCustom(AppEntities db, int IDBranch, int StaffID, dynamic item, string Username)
        {
            tbl_CRM_Contact dbitem = new tbl_CRM_Contact();
            int IDAddress = 0;
            if (item != null)
            {
                patchDynamicToDB(item, dbitem, Username);

                dbitem.CreatedBy = Username;
                dbitem.CreatedDate = DateTime.Now;
                try
                {
                    db.tbl_CRM_Contact.Add(dbitem);
                    db.SaveChanges();

                    if (item.Address != null)
                    {
                        if (string.IsNullOrEmpty(dbitem.WorkPhone))
                            dbitem.WorkPhone = item.Address.Phone1;

                        item.Address.IDPartner = dbitem.Id;

                        dynamic sa = BS_CRM_PartnerAddress.post(db, IDBranch, StaffID, item.Address, Username);
                        IDAddress = sa.Id;
                        return new { Id = dbitem.Id, IDAddress = IDAddress };
                    }
                }
                catch (DbEntityValidationException e)
                {
                    errorLog.logMessage("post_CRM_Contact", e);
                    item = null;
                }
            }
            return toDTO(dbitem);
        }



    }
}
