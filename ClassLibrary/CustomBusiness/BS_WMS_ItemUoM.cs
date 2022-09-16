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

    public static partial class BS_WMS_ItemUoM
    {
        public static List<DTO_ConvertUnit> splitUoM(tbl_WMS_Item item, DTO_ConvertUnit originalUoM, int targetUoMId = 0, string targetUoMName = "")
        {
            if (item == null || originalUoM == null)
                return null;

            List<DTO_ConvertUnit> result = new List<DTO_ConvertUnit>();
            var uoms = item.tbl_WMS_ItemUoM.Where(d => d.IsDeleted == false).OrderByDescending(o => o.BaseQuantity / o.AlternativeQuantity).ToList();
            var u = uoms.FirstOrDefault(d => d.Id == originalUoM.UoMId);
            if (u == null)
            {
                result.Add(originalUoM);
            }
            else
            {
                decimal baseQty = (u.BaseQuantity / u.AlternativeQuantity) * originalUoM.Quantity;
                if (targetUoMName != "" || targetUoMId != 0)
                {
                    var targetUoM = uoms.FirstOrDefault(d => (d.Id == targetUoMId || d.Name == targetUoMName) && d.IsDeleted == false);
                    if (targetUoM != null)
                        uoms = uoms.Where(d => (d.BaseQuantity / d.AlternativeQuantity) <= (targetUoM.BaseQuantity / targetUoM.AlternativeQuantity)).ToList();
                }

                foreach (var toUoM in uoms)
                {
                    if (baseQty - toUoM.BaseQuantity / toUoM.AlternativeQuantity >= 0)
                    {
                        decimal truncateQty = Math.Truncate(baseQty / (toUoM.BaseQuantity / toUoM.AlternativeQuantity));
                        baseQty = baseQty - truncateQty * (toUoM.BaseQuantity / toUoM.AlternativeQuantity);

                        DTO_ConvertUnit convertedUnit = new DTO_ConvertUnit();
                        convertedUnit.Quantity = truncateQty;
                        convertedUnit.BaseQuantity = truncateQty * (toUoM.BaseQuantity / toUoM.AlternativeQuantity);
                        convertedUnit.UoMId = toUoM.Id;
                        convertedUnit.UoMName = toUoM.Name;

                        convertedUnit.Cube = toUoM.Length * toUoM.Width * toUoM.Height * convertedUnit.Quantity;
                        convertedUnit.GrossWeight = toUoM.Weight * convertedUnit.Quantity;
                        convertedUnit.NetWeight = toUoM.Weight * convertedUnit.Quantity;

                        result.Add(convertedUnit);

                        if (baseQty == 0)
                        {
                            break;
                        }
                    }
                }

            }

            return result;
        }

        public static List<DTO_ConvertUnit> splitUoM(tbl_WMS_Item item, decimal baseQty, int targetUoMId = 0, string targetUoMName = "")
        {
            if (item == null)
                return null;

            List<DTO_ConvertUnit> result = new List<DTO_ConvertUnit>();
            var uoms = item.tbl_WMS_ItemUoM.Where(d => d.IsDeleted == false).OrderByDescending(o => o.BaseQuantity / o.AlternativeQuantity).ToList();
            var u = uoms.FirstOrDefault(d => d.IsBaseUoM);
            if (u != null)
            {
                if (targetUoMName != "" || targetUoMId != 0)
                {
                    var targetUoM = uoms.FirstOrDefault(d => (d.Id == targetUoMId || d.Name == targetUoMName) && d.IsDeleted == false);
                    if (targetUoM != null)
                        uoms = uoms.Where(d => (d.BaseQuantity / d.AlternativeQuantity) <= (targetUoM.BaseQuantity / targetUoM.AlternativeQuantity)).ToList();
                }

                foreach (var toUoM in uoms)
                {
                    if (baseQty - toUoM.BaseQuantity / toUoM.AlternativeQuantity >= 0)
                    {
                        decimal truncateQty = Math.Truncate(baseQty / (toUoM.BaseQuantity / toUoM.AlternativeQuantity));
                        baseQty = baseQty - truncateQty * (toUoM.BaseQuantity / toUoM.AlternativeQuantity);

                        DTO_ConvertUnit convertedUnit = new DTO_ConvertUnit();
                        convertedUnit.Quantity = truncateQty;
                        convertedUnit.BaseQuantity = truncateQty * (toUoM.BaseQuantity / toUoM.AlternativeQuantity);
                        convertedUnit.UoMId = toUoM.Id;
                        convertedUnit.UoMName = toUoM.Name;

                        convertedUnit.Cube = toUoM.Length * toUoM.Width * toUoM.Height * convertedUnit.Quantity;
                        convertedUnit.GrossWeight = toUoM.Weight * convertedUnit.Quantity;
                        convertedUnit.NetWeight = toUoM.Weight * convertedUnit.Quantity;

                        result.Add(convertedUnit);

                        if (baseQty == 0)
                        {
                            break;
                        }
                    }
                }

            }

            return result;
        }

        public static DTO_ConvertUnit mergeUoM(tbl_WMS_Item item, List<DTO_ConvertUnit> splitedUoMs, int targetUoMId = 0, string targetUoMName = "")
        {
            decimal baseQty = 0;
            var result = new DTO_ConvertUnit();
            var uoms = item.tbl_WMS_ItemUoM.Where(d => d.IsDeleted == false).OrderByDescending(o => o.BaseQuantity / o.AlternativeQuantity).ToList();

            foreach (var uom in splitedUoMs)
            {
                var u = uoms.FirstOrDefault(d => d.Id == uom.UoMId);
                if (u == null)
                    return null;
                baseQty += (u.BaseQuantity / u.AlternativeQuantity) * uom.Quantity;
            }

            if (targetUoMId != 0)
            {
                var targetUoM = uoms.FirstOrDefault(d => (d.Id == targetUoMId || d.Name == targetUoMName) && d.IsDeleted == false);
                if (targetUoM != null)
                    uoms = uoms.Where(d => (d.BaseQuantity / d.AlternativeQuantity) <= (targetUoM.BaseQuantity / targetUoM.AlternativeQuantity)).ToList();
            }

            foreach (var toUoM in uoms)
            {
                decimal truncateQty = Math.Truncate(baseQty / (toUoM.BaseQuantity / toUoM.AlternativeQuantity));
                decimal leftQty = baseQty - truncateQty * (toUoM.BaseQuantity / toUoM.AlternativeQuantity);

                if (leftQty == 0)
                {
                    result.Quantity = truncateQty;
                    result.BaseQuantity = truncateQty * (toUoM.BaseQuantity / toUoM.AlternativeQuantity);
                    result.UoMId = toUoM.Id;
                    result.UoMName = toUoM.Name;
                    result.Cube += toUoM.Length * toUoM.Width * toUoM.Height * result.Quantity;
                    result.GrossWeight += toUoM.Weight * result.Quantity;
                    result.NetWeight += toUoM.Weight * result.Quantity;
                    break;
                }
            }

            return result;
        }
    }
}
