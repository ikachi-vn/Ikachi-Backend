namespace BaseBusiness
{
    using System;
    using System.Collections.Generic;
    using System.Data;
    using System.Data.Entity;
    using OfficeOpenXml;
    using System.Linq;
    using DTOModel;
    using ClassLibrary;
    using System.Data.Entity.Validation;

    public static partial class BS_WMS_PriceListDetail
    {


        public static DTO_WMS_PriceListDetail calcPrice(AppEntities db, DTO_WMS_PriceListDetail item, string Username)
        {
            if (item == null)
            {
                return null;
            }

            tbl_WMS_PriceListDetail dbitem = null;
            if (item.Id != 0)
            {
                dbitem = db.tbl_WMS_PriceListDetail.Find(item.Id);
            }

            if (dbitem == null)
            {
                dbitem = db.tbl_WMS_PriceListDetail.FirstOrDefault(d => d.IDPriceList == item.IDPriceList && d.IDItemUoM == item.IDItemUoM && d.IsDeleted == false);
            }


            if(dbitem==null)
            {
                dbitem = new tbl_WMS_PriceListDetail();
                db.tbl_WMS_PriceListDetail.Add(dbitem);
                dbitem.CreatedBy = Username;
                dbitem.CreatedDate = DateTime.Now;
                dbitem.IDPriceList = item.IDPriceList;
                dbitem.IDItem = item.IDItem;
                dbitem.IDItemUoM = item.IDItemUoM;
            }

            try
            {
                var duplicate = db.tbl_WMS_PriceListDetail.Where(d => d.IDItemUoM == dbitem.IDItemUoM && d.IDPriceList == dbitem.IDPriceList && d.Id != dbitem.Id && d.IsDeleted == false).ToList();
                foreach (var d in duplicate)
                {
                    d.IsDeleted = true;
                    d.Remark = "Duplicate Id: " + dbitem.Id.ToString();
                }
            }
            catch (Exception)
            {

            }
            


            dbitem.Price = item.Price;
            dbitem.Price1 = item.Price1;
            dbitem.Price2 = item.Price2;
            dbitem.IsManual = item.IsManual;

            dbitem.ModifiedBy = Username;
            dbitem.ModifiedDate = DateTime.Now;


            try
            {

                db.SaveChanges();
                
                if (!item.IsManual)
                {
                    var priceList = db.tbl_WMS_PriceList.Find(item.IDPriceList);
                    if (priceList.IDBasePriceList.HasValue)
                    {
                        string queryString = @"
                                UPDATE p2 SET {0}
                                FROM (SELECT Id, IDItem, IDItemUoM, Price, Price1, Price2 FROM dbo.tbl_WMS_PriceListDetail  WHERE IDPriceList = {1}) p1
                                INNER JOIN dbo.tbl_WMS_PriceListDetail p2 ON p2.IDItemUoM = p1.IDItemUoM
                                WHERE  p2.Id= {2}
                                ";

                        string roundUpdate = "p2.Price = p1.Price*{1}, p2.Price1 = p1.Price1*{1}, p2.Price2 = p1.Price2*{1} ";
                        if (priceList.RoundingMethod.HasValue && priceList.RoundingMethod.Value > -1)
                            roundUpdate = "p2.Price = ROUND(p1.Price*{1}, {0}) , p2.Price1 = ROUND(p1.Price1*{1}, {0}), p2.Price2 = ROUND(p1.Price2*{1}, {0}) ";
                        
                        roundUpdate = string.Format(roundUpdate, priceList.RoundingMethod, priceList.Factor);
                        queryString = string.Format(queryString, roundUpdate,  priceList.IDBasePriceList, item.Id);
                        var results = db.Database.ExecuteSqlCommand(queryString);
                        db.Entry(dbitem).Reload();
                        item = toDTO( dbitem);
                    }

                }

                var childrenPriceList = db.tbl_WMS_PriceList.Where(d => d.IDBasePriceList == item.IDPriceList).ToList();
                if (childrenPriceList.Count>0)
                {
                    foreach (var c in childrenPriceList)
                    {
                        var dbp = db.tbl_WMS_PriceListDetail.FirstOrDefault(d => d.IDItemUoM == item.IDItemUoM && d.IDPriceList == c.Id && d.IsDeleted == false);
                        if (dbp == null)
                        {
                            dbp = new tbl_WMS_PriceListDetail();
                            dbp.IDPriceList = c.Id;
                            dbp.IDItem = item.IDItem;
                            dbp.IDItemUoM = item.IDItemUoM;
                            dbp.CreatedBy = Username;
                            dbp.ModifiedBy = Username;
                            dbp.CreatedDate = dbitem.ModifiedDate;
                            dbp.ModifiedDate = dbitem.ModifiedDate;
                            db.tbl_WMS_PriceListDetail.Add(dbp);
                            db.SaveChanges();
                        }

                        var p = toDTO(dbp);
                        calcPrice(db, p, Username);
                    }
                }

                BS_Version.update_Version(db, null, "DTO_WMS_PriceListDetail", dbitem.ModifiedDate, Username);
                item.Id = dbitem.Id;
                item.CreatedBy = dbitem.CreatedBy;
                item.CreatedDate = dbitem.CreatedDate;
                item.ModifiedBy = dbitem.ModifiedBy;
                item.ModifiedDate = dbitem.ModifiedDate;
            }
            catch (DbEntityValidationException e)
            {
                errorLog.logMessage("post_WMS_PriceListDetail", e);
                item = null;
            }

            return item;
        }
    }
}