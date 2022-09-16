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

    public static partial class BS_WMS_Transaction
    {
        public static dynamic getCustom(AppEntities db, int IDBranch, int StaffID, Dictionary<string, string> QueryStrings)
        {
            var query = _queryBuilder(db, IDBranch, StaffID, QueryStrings);
            query = _sortBuilder(query, QueryStrings);
            query = _pagingBuilder(query, QueryStrings);

			return query
			.Select(s => new
			{
				IDBranch = s.IDBranch,
				_Branch = new { s.tbl_BRA_Branch.Id, s.tbl_BRA_Branch.Name },
				
				IDStorer = s.IDStorer,
				_Storer = new { s.tbl_WMS_Storer.Id, s.tbl_WMS_Storer.tbl_CRM_Contact.Name},
				Id = s.Id,
				TransactionType = s.TransactionType,
				IDTransaction = s.IDTransaction,
				IDItem = s.IDItem,
				_Item = new { s.tbl_WMS_Item.Code, s.tbl_WMS_Item.Name },
				Lot = s.Lot,
				_Lot = new { s.tbl_WMS_Lot.Lottable0, s.tbl_WMS_Lot.Lottable1, s.tbl_WMS_Lot.Lottable5, s.tbl_WMS_Lot.Lottable6 },
				FromLocation = s.FromLocation,
				_FromLocation = s.tbl_WMS_Location==null?null: new
				{
					s.tbl_WMS_Location.Id,
					s.tbl_WMS_Location.Name,
					Zone = s.tbl_WMS_Location.tbl_WMS_Zone.Name
				},
				ToLocation = s.ToLocation,
				_ToLocation = s.tbl_WMS_Location1 == null ? null : new
				{
					s.tbl_WMS_Location1.Id,
					s.tbl_WMS_Location1.Name,
					Zone = s.tbl_WMS_Location1.tbl_WMS_Zone.Name
				},
				FromLPN = s.FromLPN,
				_FromLPN = s.tbl_WMS_LicencePlateNumber == null ? null : new { s.tbl_WMS_LicencePlateNumber.Id, s.tbl_WMS_LicencePlateNumber.Code },
				ToLPN = s.ToLPN,
				_ToLPN = s.tbl_WMS_LicencePlateNumber1 == null? null : new { s.tbl_WMS_LicencePlateNumber1.Id, s.tbl_WMS_LicencePlateNumber1.Code},
				SourceKey = s.SourceKey,
				SourceType = s.SourceType,
				Status = s.Status,
				IDUoM = s.IDUoM,
				_UoM = new { s.tbl_WMS_ItemUoM.Name },
				UoMQuantity = s.UoMQuantity,
				Quantity = s.Quantity,
				Cube = s.Cube,
				GrossWeight = s.GrossWeight,
				NetWeight = s.NetWeight,
				IsDeleted = s.IsDeleted,
				CreatedBy = s.CreatedBy,
				ModifiedBy = s.ModifiedBy,
				CreatedDate = s.CreatedDate,
				ModifiedDate = s.ModifiedDate,
			});
		}

		public static dynamic calcInputOutputInventory(AppEntities db, int IDBranch, int StaffID, Dictionary<string, string> QueryStrings)
        {
			string BranchIds = "";
			if (QueryStrings.Any(d => d.Key == "IDBranch"))
			{
				var IDList = QueryStrings.FirstOrDefault(d => d.Key == "IDBranch").Value.Replace("[", "").Replace("]", "").Split(',');
				List<int> IDs = new List<int>();
				foreach (var item in IDList)
					if (int.TryParse(item, out int i))
						IDs.Add(i);
				if (IDs.Count > 0)
					BranchIds = string.Format(" AND IDBranch IN ({0})", string.Join(",", IDs.ToArray()));

			}

			QueryStrings.Remove("IDBranch");
			var query = BS_WMS_Item._queryBuilder(db, IDBranch, StaffID, QueryStrings);
			query = BS_WMS_Item._sortBuilder(query, QueryStrings);
			query = BS_WMS_Item._pagingBuilder(query, QueryStrings);
			var ids = query.Select(s => s.Id).ToList();

            if (ids.Count==0)
            {
				return ids;
            }

			string queryString = @"
DECLARE @fromDate DATETIME='{0}';
DECLARE @toDate DATETIME='{1}';

SELECT ISNULL( o.IDBranch, I.IDBranch) IDBranch, ISNULL( o.IDStorer, i.IDStorer) IDStorer, o.IDItem, o.ItemCode, o.ItemName, o.OpenQuantity, o.OpenCube, o.OpenNetWeight, o.OpenGrossWeight,
ISNULL(i.InputQuantity,0) InputQuantity, ISNULL(i.InputCube,0) InputCube, ISNULL(i.InputNetWeight,0) InputNetWeight, ISNULL(i.InputGrossWeight,0) InputGrossWeight, 
ISNULL(u.OutputQuantity,0) OutputQuantity, ISNULL(u.OutputCube,0) OutputCube, ISNULL(u.OutputNetWeight,0) OutputNetWeight, ISNULL(u.OutputGrossWeight,0) OutputGrossWeight,
o.OpenQuantity + ISNULL(i.InputQuantity,0) + ISNULL(u.OutputQuantity,0) CloseQuantity, 
o.OpenCube + ISNULL(i.InputCube,0) + ISNULL(u.OutputCube,0) CloseCube, 
o.OpenNetWeight + ISNULL(i.InputNetWeight,0) + ISNULL(u.OutputNetWeight,0) CloseNetWeight, 
o.OpenGrossWeight + ISNULL(i.InputGrossWeight,0) + ISNULL(u.OutputGrossWeight,0) CloseGrossWeight 
FROM 
(SELECT  t.IDBranch, t.IDStorer, i.Id IDItem, i.Code ItemCode, i.Name ItemName,  ISNULL(OpenQuantity,0) OpenQuantity, ISNULL(OpenCube,0) OpenCube, ISNULL(OpenNetWeight,0) OpenNetWeight, ISNULL(OpenGrossWeight,0) OpenGrossWeight
FROM (SELECT id, code, name FROM dbo.tbl_WMS_Item WHERE IsDeleted = 0 {2}) i
LEFT JOIN 
(SELECT  IDBranch, IDStorer, IDItem, ISNULL(SUM(Quantity),0) OpenQuantity, ISNULL(SUM(Cube),0) OpenCube, ISNULL(SUM(NetWeight),0) OpenNetWeight, ISNULL(SUM(GrossWeight),0) OpenGrossWeight 
FROM dbo.tbl_WMS_Transaction 
WHERE TransactionDate<@fromDate {3} {4} {5} 
GROUP BY IDBranch, IDStorer, IDItem) t 
ON t.IDItem = i.Id
)o
FULL JOIN 
(SELECT IDBranch, IDStorer, IDItem, SUM(Quantity) InputQuantity, SUM(Cube) InputCube, SUM(NetWeight) InputNetWeight, SUM(GrossWeight) InputGrossWeight
FROM dbo.tbl_WMS_Transaction 
WHERE Quantity >0 AND TransactionDate BETWEEN @fromDate AND @toDate {3} {4} {5} 
GROUP BY IDBranch, IDStorer, IDItem
) i ON ((i.IDBranch = o.IDBranch AND i.IDStorer = o.IDStorer) OR (o.IDBranch IS NULL AND o.IDStorer IS NULL)) AND i.IDItem = o.IDItem
FULL JOIN
(SELECT IDBranch, IDStorer, IDItem, SUM(Quantity) OutputQuantity, SUM(Cube) OutputCube, SUM(NetWeight) OutputNetWeight, SUM(GrossWeight) OutputGrossWeight
FROM dbo.tbl_WMS_Transaction 
WHERE Quantity <0 AND TransactionDate BETWEEN @fromDate AND @toDate {3} {4} {5} 
GROUP BY IDBranch, IDStorer, IDItem
) u ON ((u.IDBranch = o.IDBranch AND u.IDStorer = o.IDStorer) OR (o.IDBranch IS NULL AND o.IDStorer IS NULL)) AND u.IDItem = o.IDItem
WHERE ISNULL( o.IDStorer, i.IDStorer) IS NOT NULL  


ORDER BY i.IDBranch, i.IDStorer, o.ItemCode



";

			DateTime fromDate ;
			DateTime toDate ;
            if (!DateTime.TryParse(QueryStrings.FirstOrDefault(d => d.Key == "CreatedDateFrom").Value, out fromDate))
				fromDate = DateTime.Parse("1800-01-01");
			
			if (!DateTime.TryParse(QueryStrings.FirstOrDefault(d => d.Key == "CreatedDateTo").Value, out toDate))
				toDate = DateTime.Parse("3000-01-01");

            if (fromDate > toDate)
            {
				var t = fromDate;
				fromDate = toDate;
				toDate = t;
            }

			

			string StorerIds = "";
			if (QueryStrings.Any(d => d.Key == "IDStorer"))
			{
				var IDList = QueryStrings.FirstOrDefault(d => d.Key == "IDStorer").Value.Replace("[", "").Replace("]", "").Split(',');
				List<int> IDs = new List<int>();
				foreach (var item in IDList)
					if (int.TryParse(item, out int i))
						IDs.Add(i);
				if (IDs.Count > 0)
					StorerIds = string.Format(" AND IDStorer IN ({0})", string.Join(",", IDs.ToArray()));
			}

			string ItemIds = "";
			string MasterItemIds = "";
			if (ids.Count > 0)
			{
				MasterItemIds = string.Format(" AND Id IN ({0})", string.Join(",", ids.ToArray()));
				StorerIds = string.Format(" AND IDItem IN ({0})", string.Join(",", ids.ToArray()));
			}

			queryString = string.Format(queryString, fromDate.ToString("yyyy-MM-dd"), toDate.ToString("yyyy-MM-dd") + " 23:59:59.999", MasterItemIds, ItemIds, BranchIds, StorerIds);

			var results = db.Database.SqlQuery<DTO_InputOutputInventory>(queryString);

			return results.ToList();
		}

		public static void logReceivePalletTransaction(AppEntities db, tbl_WMS_ReceiptPalletization line, int? toLPN, string Username)
        {
			tbl_WMS_Transaction dbItem = new tbl_WMS_Transaction()
			{
				IDBranch = line.tbl_WMS_ReceiptDetail.tbl_WMS_Receipt.IDBranch,
				IDStorer = line.IDStorer,
				TransactionType = "ReceivePallet",
				IDTransaction = line.Id,
				IDItem = line.IDItem,
				Lot = line.ToLot,
				FromLocation = null,
				ToLocation = line.ToLocation,
				FromLPN = null,
				ToLPN = toLPN,
				SourceKey = line.tbl_WMS_ReceiptDetail.tbl_WMS_Receipt.Id,
				SourceType = "ReceiptDetailAdd",
				Status = "OK",
				IDUoM = line.IDUoM,
				UoMQuantity = line.UoMQuantityExpected,
				Quantity = line.QuantityReceived,
				Cube = line.Cube,
				GrossWeight = line.GrossWeight,
				NetWeight = line.NetWeight,

				CreatedBy = Username,
				ModifiedBy = Username,
				CreatedDate = DateTime.Now,
				ModifiedDate = DateTime.Now,
				TransactionDate = DateTime.Now,
			};
			db.tbl_WMS_Transaction.Add(dbItem);

			BS_WMS_LotLPNLocation.addQuantityOnHand( db, dbItem.IDBranch, dbItem.IDStorer, dbItem.ToLocation.GetValueOrDefault(), dbItem.IDItem, dbItem.Lot, dbItem.ToLPN.GetValueOrDefault(), dbItem.Quantity,  Username);
			BS_WMS_ItemInLocation.addQuantityOnHand(db, dbItem.IDBranch, dbItem.IDStorer, dbItem.ToLocation.GetValueOrDefault(), dbItem.IDItem, dbItem.Quantity, Username);
			BS_WMS_Lot.addQuantityOnHand( db, dbItem.Lot, dbItem.Quantity, dbItem.Cube, dbItem.NetWeight, dbItem.GrossWeight, Username);
		}
    }
}
