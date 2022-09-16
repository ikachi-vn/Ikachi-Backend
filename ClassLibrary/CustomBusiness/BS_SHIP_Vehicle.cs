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

    public static partial class BS_SHIP_Vehicle
    {
        public static dynamic getCustom(AppEntities db, int IDBranch, int StaffID, Dictionary<string, string> QueryStrings)
        {
            var query = _queryBuilder(db, IDBranch, StaffID, QueryStrings);

            if (QueryStrings.Any(d => d.Key == "ShipperName") && !string.IsNullOrEmpty(QueryStrings.FirstOrDefault(d => d.Key == "ShipperName").Value))
            {
                var keyword = QueryStrings.FirstOrDefault(d => d.Key == "ShipperName").Value;
                query = query.Where(d => d.tbl_HRM_Staff.FullName.Contains(keyword));
            }

            query = _sortBuilder(query, QueryStrings);
            query = _pagingBuilder(query, QueryStrings);

            return query.Select(s => new
            {
                IDBranch = s.IDBranch,
                IDVehicleGroup = s.IDVehicleGroup,
                IDShipper = s.IDShipper,
                Id = s.Id,
                Code = s.Code,
                Name = s.Name,
                Remark = s.Remark,
                Sort = s.Sort,

                Length = s.Length,
                Width = s.Width,
                Height = s.Height,
                VolumeMin = s.VolumeMin,
                VolumeRecommend = s.VolumeRecommend,
                VolumeMax = s.VolumeMax,
                WeightMin = s.WeightMin,
                WeightRecommend = s.WeightRecommend,
                WeightMax = s.WeightMax,

                ShipperName = s.IDShipper.HasValue ? s.tbl_HRM_Staff.FullName : "",
                s.RefShipper
            }).ToList();
            
        }
    }
}
