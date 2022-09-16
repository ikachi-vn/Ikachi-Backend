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

    public static partial class BS_WMS_LicencePlateNumber
    {
        public static tbl_WMS_LicencePlateNumber getOrCreate(AppEntities db, int IDBranch, int StaffID, string Username, tbl_WMS_ReceiptPalletization line)
        {
            tbl_WMS_LicencePlateNumber result = line.tbl_WMS_LicencePlateNumber.FirstOrDefault(d => d.IsDeleted == false);
            if (result == null)
            {

                result = new tbl_WMS_LicencePlateNumber()
                {
                    IDBranch = line.tbl_WMS_ReceiptDetail.tbl_WMS_Receipt.IDBranch,
                    IDStorer = line.IDStorer,
                    IDItem = line.IDItem,
                    Status = "LPNOK",
                    CreatedBy = Username,
                    ModifiedBy = Username,
                    CreatedDate = DateTime.Now,
                    ModifiedDate = DateTime.Now,
                };

                if (line.Id != 0)
                    result.IDReceipPalletization = line.Id;
                
                line.tbl_WMS_LicencePlateNumber.Add(result);
                db.SaveChanges();
            }

            return result;
        }
    }
}
