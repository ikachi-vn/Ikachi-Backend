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

    public static partial class BS_WMS_Carton
    {
        public static dynamic getCustom(AppEntities db, int IDBranch, int StaffID, Dictionary<string, string> QueryStrings)
        {
			if (QueryStrings.Any(d => d.Key == "IDBranch"))
				QueryStrings.Remove("IDBranch");

			var query = _queryBuilder(db, IDBranch, StaffID, QueryStrings);
            query = _sortBuilder(query, QueryStrings);
            query = _pagingBuilder(query, QueryStrings);

			return query
			.Select(s => new
			{
				CartonGroupName = s.tbl_WMS_CartonGroup.Name,
				Id = s.Id,
				Name = s.Name,
				IDCartonGroup = s.IDCartonGroup,
				CartonType = s.CartonType,
				ContainerType = s.ContainerType,
				
				Cube = s.Cube,
				MaxCount = s.MaxCount,

				MaxWeight = s.MaxWeight,
				TareWeight = s.TareWeight,

				Length = s.Length,
				Width = s.Width,
				Height = s.Height,
				CreatedBy = s.CreatedBy,
				ModifiedBy = s.ModifiedBy,
				CreatedDate = s.CreatedDate,
				ModifiedDate = s.ModifiedDate,
			});
		}

    }
}
