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

    public static partial class BS_PROD_BillOfMaterials
    {
        public static dynamic getCustom(AppEntities db, int IDBranch, int StaffID, Dictionary<string, string> QueryStrings)
        {
            var query = _queryBuilder(db, IDBranch, StaffID, QueryStrings);
            query = _sortBuilder(query, QueryStrings);
            query = _pagingBuilder(query, QueryStrings);

            return query
            .Select(s => new 
            {
                _Item = new { s.tbl_WMS_Item.Id, s.tbl_WMS_Item.Code, s.tbl_WMS_Item.Name },
                Id = s.Id,
                Name = s.Name,
                IDItem = s.IDItem,
                Type = s.Type,
                Quantity = s.Quantity,
                IDWarehouse = s.IDWarehouse,
                IDPriceList = s.IDPriceList,
                IDStdCostPriceList = s.IDStdCostPriceList,
                BatchSize = s.BatchSize,
                Sort = s.Sort,
                IsDisabled = s.IsDisabled,
                CreatedBy = s.CreatedBy,
                CreatedDate = s.CreatedDate,
                ModifiedBy = s.ModifiedBy,
                ModifiedDate = s.ModifiedDate,
            });
        }

        public static dynamic getAnItemCustom(AppEntities db, int IDBranch, int StaffID, int id)
        {
            var dbResult = db.tbl_PROD_BillOfMaterials
                .Include(i => i.tbl_WMS_Item)
                .Include(i => i.tbl_PROD_BillOfMaterialsDetail)
                .FirstOrDefault(d => d.Id == id);

            //var ItemIds = dbResult.tbl_PROD_BillOfMaterialsDetail.Where(d => d.IsDeleted == false).Select(s => s.IDItem).ToList();
            //var UoMs = db.tbl_WMS_ItemUoM.Where(ud => ItemIds.Contains(ud.IDItem) && ud.IsDeleted == false).Select(su => new
            //{
            //    su.IDItem,
            //    su.Id,
            //    su.Name,
            //    UoMPrice = su.tbl_WMS_PriceListDetail.FirstOrDefault(d => d.IDPriceList == dbResult.IDPriceList && d.IsDeleted == false),
            //    StdCost = su.tbl_WMS_PriceListDetail.FirstOrDefault(d => d.IDPriceList == dbResult.IDStdCostPriceList && d.IsDeleted == false),
            //});

            //var Items = db.tbl_WMS_Item.Where(d => ItemIds.Contains(d.Id)).Select(s => new
            //{
            //    s.Id,
            //    s.Code,
            //    s.Name,
            //    UoMs = UoMs.Where(d=>d.IDItem == s.Id)

            //});

            //var Lines = dbResult.tbl_PROD_BillOfMaterialsDetail.Where(d => d.IsDeleted == false).Select(s => new
            //{
            //    s.IDBOM,
            //    s.Id,
            //    s.Type,
            //    s.IDItem,
            //    s.IDUoM,
            //    s.UoMPrice,
            //    s.Quantity,
            //    s.AdditionalQuantity,
            //    s.IssueMethod,
            //    s.IDWarehouse,
            //    s.Name,
            //    s.Remark,
            //    s.Sort,


            //    _Item = Items.FirstOrDefault(d => d.Id == s.IDItem),
            //    _UoM = UoMs.FirstOrDefault(d=>d.Id == s.IDUoM),

            //    TotalPrice = s.Quantity * s.UoMPrice,
            //    TotalStdCost = s.Quantity * UoMs.FirstOrDefault(d => d.Id == s.IDUoM).StdCost.Price,
            //}); ;

            if (dbResult != null)
            {
                return new
                {
                    PrintDate = DateTime.Now.ToString("HH:mm dd/MM/yy"),
                    Id = dbResult.Id,
                    Name = dbResult.Name,
                    IDItem = dbResult.IDItem,
                    _Item = new { dbResult.tbl_WMS_Item.Id, dbResult.tbl_WMS_Item.Code, dbResult.tbl_WMS_Item.Name },
                    Type = dbResult.Type,
                    Quantity = dbResult.Quantity,
                    IDWarehouse = dbResult.IDWarehouse,
                    IDPriceList = dbResult.IDPriceList,
                    IDStdCostPriceList = dbResult.IDStdCostPriceList,
                    BatchSize = dbResult.BatchSize,
                    Sort = dbResult.Sort,
                    IsDisabled = dbResult.IsDisabled,
                    CreatedBy = dbResult.CreatedBy,
                    CreatedDate = dbResult.CreatedDate,
                    ModifiedBy = dbResult.ModifiedBy,
                    ModifiedDate = dbResult.ModifiedDate,

                    Lines = dbResult.tbl_PROD_BillOfMaterialsDetail.Where(d => d.IsDeleted == false).Select(s => new { 
                        s.IDBOM,
                        s.Id,
                        s.Type,
                        s.IDItem,
                        s.IDUoM,
                        s.UoMPrice,
                        s.Quantity,
                        s.AdditionalQuantity,
                        s.IssueMethod,
                        s.IDWarehouse,
                        s.Name,
                        s.Remark,
                        s.Sort,
                        

                        _Item = s.IDItem.HasValue==false? null : s.tbl_WMS_Item == null ? null : new
                        {
                            s.tbl_WMS_Item.Id,
                            s.tbl_WMS_Item.Code,
                            s.tbl_WMS_Item.Name,
                            s.tbl_WMS_Item.SalesUoM,
                            s.tbl_WMS_Item.PurchasingUoM,
                            UoMs = s.tbl_WMS_Item.tbl_WMS_ItemUoM.Where(ud => ud.IsDeleted == false).Select(su => new
                            {
                                su.Id,
                                su.Name,
                                UoMPrice = su.tbl_WMS_PriceListDetail.Where(d => d.IDPriceList == dbResult.IDPriceList && d.IsDeleted == false).Select(sp => sp.Price).FirstOrDefault(),
                                StdCost = su.tbl_WMS_PriceListDetail.Where(d => d.IDPriceList == dbResult.IDStdCostPriceList && d.IsDeleted == false).Select(sp => sp.Price).FirstOrDefault(),
                                PriceList = su.tbl_WMS_PriceListDetail.Where(dp => dp.IsDeleted == false && (dp.IDPriceList == dbResult.IDPriceList || dp.IDPriceList == dbResult.IDStdCostPriceList)).Select(p => new
                                {
                                    Type = p.IDPriceList == dbResult.IDPriceList ? "PriceList" : "StdCostPriceList",
                                    p.Id,
                                    p.Price
                                })
                            })
                        },

                        TotalPrice = s.Quantity * s.UoMPrice,

                    })
                };
            }
            else
                return null;

        }

        public static dynamic putCustom(AppEntities db, int IDBranch, int StaffID, int Id, dynamic item, string Username, Dictionary<string, string> QueryStrings)
        {
            var saved = postCustom(db, IDBranch, StaffID, item, Username);
            return getAnItemCustom(db, IDBranch, StaffID, Id);
        }

        public static dynamic postCustom(AppEntities db, int IDBranch, int StaffID, dynamic item, string Username)
        {
            tbl_PROD_BillOfMaterials dbitem = new tbl_PROD_BillOfMaterials();
            if (item != null)
            {
                try
                {
                    if (item.Id != 0 && item.Id != null)
                    {
                        dbitem = db.tbl_PROD_BillOfMaterials.Find((int)item.Id);
                    }
                    else
                    {
                        db.tbl_PROD_BillOfMaterials.Add(dbitem);
                        dbitem.CreatedBy = Username;
                        dbitem.CreatedDate = DateTime.Now;
                        
                    }

                    patchDynamicToDB(item, dbitem, Username);

                    var dbItem = db.tbl_WMS_Item.Find(dbitem.IDItem);
                    if(dbItem.TreeType != dbitem.Type)
                        dbItem.TreeType = dbitem.Type;

                    if (item.Lines != null)
                    {
                        foreach (var l in item.Lines)
                        {
                            dynamic line = l.Value;
                            if (line == null)
                                continue;

                            tbl_PROD_BillOfMaterialsDetail dbline = new tbl_PROD_BillOfMaterialsDetail();
                            if (line.Id != 0)
                            {
                                dbline = db.tbl_PROD_BillOfMaterialsDetail.Find((int)line.Id);
                            }
                            else
                            {
                                dbitem.tbl_PROD_BillOfMaterialsDetail.Add(dbline);
                                dbline.CreatedBy = Username;
                                dbline.CreatedDate = DateTime.Now;
                            }

                            BS_PROD_BillOfMaterialsDetail.patchDynamicToDB(line, dbline, Username);

                        }
                    }

                    db.SaveChanges();
                }
                catch (DbEntityValidationException e)
                {
                    errorLog.logMessage("post_PROD_BillOfMaterials", e);
                    return null;
                }
            }
            return getAnItemCustom(db, IDBranch, StaffID, dbitem.Id);


        }

        public static string exportCustom(ExcelPackage package, AppEntities db, int IDBranch, int StaffID, Dictionary<string, string> QueryStrings)
        {
            package.Workbook.Properties.Title = "ART-DMS PROD_BillOfMaterials";
            package.Workbook.Properties.Author = "hung.vu@codeart.vn";
            package.Workbook.Properties.Application = "ART-DMS";
            package.Workbook.Properties.Company = "A.R.T Distribution";

            ExcelWorkbook workBook = package.Workbook;
            if (workBook != null)
            {
                var ws = workBook.Worksheets.FirstOrDefault();
                var data = calcBOMReport(db, QueryStrings).ToList();

                int SheetColumnsCount, SheetRowCount = 0;
                SheetColumnsCount = ws.Dimension.End.Column;    // Find End Column
                SheetRowCount = ws.Dimension.End.Row;           // Find End Row

                int rowid = 3;
                int firstColInex = 1;

                #region readPropertyList
                var propList = new List<Tuple<string, string, string, List<ItemModel>>>()
                    .Select(t => new { ClassName = t.Item1, PropertyName = t.Item2, ReffProperty = t.Item3, ValidateData = t.Item4 }).ToList();

                for (int i = 1; i <= SheetColumnsCount; i++)
                {
                    string p = ws.Cells[1, i].Value == null ? "" : ws.Cells[1, i].Text;
                    string modalPart = p.Split('|')[0];
                    string queryPart = "";
                    string className = "";
                    string reffProperty = "Id";

                    if (p.Contains("|")) //Sample property BRA_Branch?Select=Code&IDType=115|IDBranch
                        if (modalPart.Contains("?"))
                        {
                            className = modalPart.Split('?')[0];
                            queryPart = modalPart.Split('?')[1];
                            if (queryPart.Contains("&"))
                            {
                                string[] query = queryPart.Split('&');
                                foreach (var q in query)
                                {
                                    string key = "";
                                    string value = "";

                                    if (q.Contains("="))
                                    {
                                        key = q.Split('=')[0];
                                        value = q.Split('=')[1];
                                    }
                                    else
                                        key = q;

                                    if (QueryStrings.ContainsKey(key))
                                        QueryStrings.Remove(key);

                                    QueryStrings.Add(key, value);
                                }
                            }
                        }
                        else
                            className = modalPart;


                    List<ItemModel> vdata = null;
                    if (className != "")
                    {
                        Type type = Type.GetType("BaseBusiness.BS_" + className + ", ClassLibrary");
                        System.Reflection.MethodInfo dynamicGet = type == null ? null : type.GetMethod("getValidateData");
                        if (dynamicGet != null)
                            vdata = (List<ItemModel>)dynamicGet.Invoke(null, new object[] { db, IDBranch, StaffID, QueryStrings });
                        ExcelUtil.SetValidateData(package, i, vdata);
                    }

                    propList.Add(new
                    {
                        ClassName = className,
                        PropertyName = (p.Contains("|") ? p.Split('|')[1] : p),
                        ReffProperty = reffProperty,
                        ValidateData = vdata
                    });
                }
                #endregion

                foreach (var item in data)
                {
                    for (int i = 1; i <= SheetColumnsCount; i++)
                    {
                        var property = propList[i - 1];
                        if (!string.IsNullOrEmpty(property.PropertyName) && item.GetType().GetProperties().Any(d => d.Name == property.PropertyName))
                        {
                            if (firstColInex == 0)
                                firstColInex = i;

                            if (property.ClassName != "")
                            {
                                ItemModel it = null;
                                if (property.ReffProperty == "Id")
                                {
                                    var val = item.GetType().GetProperties().First(o => o.Name == property.PropertyName).GetValue(item, null);
                                    if (val != null && property.ValidateData != null)
                                    {
                                        int.TryParse(val.ToString(), out int id);
                                        if (id > 0)
                                            it = property.ValidateData.FirstOrDefault(d => d.Id == id);
                                    }
                                }
                                else if (property.ReffProperty == "Code")
                                {
                                    string code = (string)item.GetType().GetProperties().First(o => o.Name == property.PropertyName).GetValue(item, null);
                                    if (!string.IsNullOrEmpty(code))
                                        it = property.ValidateData.FirstOrDefault(d => d.Code == code);
                                }

                                if (it != null)
                                    ws.Cells[rowid, i].Value = (property.ReffProperty == "Id" ? it.Id.ToString() : it.Code) + ". " + it.Name;

                            }
                            else
                                ws.Cells[rowid, i].Value = item.GetType().GetProperties().First(o => o.Name == property.PropertyName).GetValue(item, null);
                        }
                    }
                    ws.Row(rowid).OutlineLevel = item.HLevel;
                    rowid++;
                }

                //create a range for the table
                //var range = ws.Cells[2, firstColInex, rowid - 1, SheetColumnsCount];
                //range.Style.Border.Bottom.Style = OfficeOpenXml.Style.ExcelBorderStyle.Thin;
                //range.Style.Border.Bottom.Color.SetColor(System.Drawing.Color.FromArgb(235, 235, 235));
                //range.Style.Border.DiagonalDown = true;
                //range.AutoFilter = true;

                var rangeCode = ws.Cells[3, 2, rowid, 2];
                rangeCode.FormulaR1C1 = ws.Cells["B3"].FormulaR1C1;

                var rangeSubtract = ws.Cells[3, 11, rowid, 11];
                rangeSubtract.FormulaR1C1 = ws.Cells["K3"].FormulaR1C1;

                if (rowid > 4)
                {
                    var rangeSTT = ws.Cells[4, 1, rowid, 1];
                    rangeSTT.FormulaR1C1 = ws.Cells["A4"].FormulaR1C1;
                }


                package.Save();
            }

            return package.File.FullName.Substring(package.File.FullName.IndexOf("\\Uploads\\"));
        }


        public static List<DTO_PROD_BOMExport> calcBOMReport(AppEntities db, Dictionary<string, string> QueryStrings)
        {
            string queryString = @"
DECLARE @Keyword NVARCHAR(512) = '{0}';

;WITH 
ig AS
(
 SELECT IDParent, Id, Code, Name, 0 AS HLevel,
 RIGHT('0000000000'+CAST(ROW_NUMBER() OVER(ORDER BY IDParent, Sort, Id) AS VARCHAR(MAX)),10)  AS OrderBy
 FROM dbo.tbl_WMS_ItemGroup WHERE IDParent IS NULL AND IsDeleted = 0
 UNION ALL
 SELECT g.IDParent, g.Id, g.Code, g.Name, (CTE.HLevel + 1) AS HLevel,
 CTE.OrderBy + RIGHT('0000000000'+CAST(ROW_NUMBER() OVER(ORDER BY g.IDParent, g.Sort, g.Id) AS VARCHAR(MAX)),10) AS OrderBy  
 FROM dbo.tbl_WMS_ItemGroup g INNER JOIN ig AS CTE ON CTE.id = g.IDParent
 WHERE g.IDParent IS NOT NULL AND IsDeleted = 0
),
bom AS
(
	SELECT b.Id Id, b.Type, b.IDItem, i.Code, i.Name , NULL AS UoMName, b.Quantity, CAST( b.BatchSize AS DECIMAL(27,9)) AdditionalQuantity,
	ig.OrderBy +  RIGHT('0000000000'+CAST(ROW_NUMBER() OVER(ORDER BY b.Sort, b.Id) AS VARCHAR(MAX)),10)  AS OrderBy,
	(ig.HLevel +  1) HLevel,
	b.IDStdCostPriceList,
	i.IDItemGroup GroupId
	FROM dbo.tbl_PROD_BillOfMaterials b
	INNER JOIN dbo.tbl_WMS_Item i ON i.Id = b.IDItem
	INNER JOIN ig ON ig.Id = i.IDItemGroup
	WHERE b.IsDeleted = 0 AND (i.Code LIKE N'%'+@Keyword+'%' OR i.Name LIKE N'%'+@Keyword+'%')
),
gp AS
	(
	SELECT IDParent, Id FROM dbo.tbl_WMS_ItemGroup WHERE Id IN (SELECT bom.GroupId FROM bom) AND IsDeleted = 0
	UNION ALL 
	SELECT g.IDParent, g.Id FROM gp INNER JOIN dbo.tbl_WMS_ItemGroup g ON g.id =  gp.IDParent WHERE IsDeleted = 0
	),
bd AS (
	SELECT d.Id, d.Type, d.IDItem, 
	CASE WHEN d.Type = 'CTStage' OR d.Type = 'CTText' THEN NULL ELSE i.Code END Code, 
	CASE WHEN d.Type = 'CTStage' OR d.Type = 'CTText' THEN d.Name ELSE i.Name END Name, 
	u.Name UoMName, d.Quantity, d.AdditionalQuantity, d.UoMPrice, p.Price SC, 
	d.UoMPrice * d.Quantity AS TotalPrice, 
	p.Price * d.Quantity / bom.Quantity + p.Price * (d.AdditionalQuantity / bom.AdditionalQuantity) TotalSC,
	bom.OrderBy + RIGHT('0000000000'+CAST(ROW_NUMBER() OVER(ORDER BY d.Sort, d.Id) AS VARCHAR(MAX)),10) AS OrderBy ,
	CASE WHEN d.Type = 'CTStage' THEN bom.HLevel + 1 ELSE bom.HLevel + 2 END HLevel,
	bom.id BOMId,
	bom.GroupId,
	1 + sum(CASE WHEN d.Type = 'CTStage' THEN 1 ELSE 0 END) over (order by d.Sort, d.Id) as StageId
	FROM dbo.tbl_PROD_BillOfMaterialsDetail d INNER JOIN bom ON bom.Id = d.IDBOM
	LEFT JOIN dbo.tbl_WMS_Item i ON i.Id = d.IDItem
	LEFT JOIN dbo.tbl_WMS_ItemUoM u ON u.IDItem = i.Id AND u.Id = d.IDUoM
	LEFT JOIN dbo.tbl_WMS_PriceListDetail p ON p.IDItemUoM = d.IDUoM AND p.IDPriceList = bom.IDStdCostPriceList
	
	WHERE d.IsDeleted = 0
)

SELECT s.GroupId, s.BOMId, s.StageId, s.COMId, s.Type, s.IDItem, s.Code, s.Name, s.UoMName, s.Quantity, s.AdditionalQuantity, s.UoMPrice, s.SC StdCode, s.TotalPrice, s.TotalSC TotalStdCode, s.HLevel  
FROM 
(
SELECT ig.Id GroupId, NULL BOMId, NULL COMId, NULL StageId, 'ItemGroup' Type, ig.Id IDItem, ig.Code, ig.Name, NULL UoMName, NULL Quantity, NULL AdditionalQuantity, NULL UoMPrice, NULL SC, NULL TotalPrice,NULL TotalSC, ig.OrderBy,  ig.HLevel--, (REPLICATE( '=> ' , HLevel ) +''+ ig.Name) 
FROM ig WHERE ig.Id IN (SELECT DISTINCT gp.Id FROM gp )
UNION ALL
SELECT bom.GroupId, bom.Id BOMId, NULL COMId, NULL StageId, bom.Type, bom.IDItem, bom.Code, bom.Name, bom.UoMName, bom.Quantity, bom.AdditionalQuantity, NULL UoMPrice, NULL SC, g.TotalPrice, g.TotalSC, bom.OrderBy, bom.HLevel FROM bom
INNER JOIN (SELECT bd.BOMId, SUM(bd.TotalPrice) TotalPrice, SUM(bd.TotalSC) TotalSC  FROM bd GROUP BY bd.BOMId) g ON g.BOMId = bom.Id
UNION ALL
SELECT bd.GroupId, bd.BOMId, bd.Id COMId, bd.StageId, bd.Type, bd.IDItem, bd.Code, bd.Name, bd.UoMName, bd.Quantity, bd.AdditionalQuantity, bd.UoMPrice, bd.SC, 
CASE WHEN (bd.Type = 'CTStage')  THEN sum(bd.TotalPrice) OVER(PARTITION BY bd.StageId) ELSE bd.TotalPrice END TotalPrice,
CASE WHEN (bd.Type = 'CTStage')  THEN sum(bd.TotalSC) OVER(PARTITION BY bd.StageId) ELSE bd.TotalSC END TotalSC,
bd.OrderBy, bd.HLevel FROM bd
) s

ORDER BY OrderBy
";
            string keyword = "";
            if (QueryStrings.Any(d => d.Key == "Keyword") && !string.IsNullOrEmpty(QueryStrings.FirstOrDefault(d => d.Key == "Keyword").Value))
                keyword = QueryStrings.FirstOrDefault(d => d.Key == "Keyword").Value;
                
            queryString = string.Format(queryString, keyword);

            var results = db.Database.SqlQuery<DTO_PROD_BOMExport>(queryString);

            return results.ToList();
        }
    }
}
