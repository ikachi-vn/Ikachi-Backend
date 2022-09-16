
namespace DTOModel
{
    using System;
    using System.Collections.Generic;

    public partial class DTO_WMS_Item
    {

        public List<DTO_WMS_ItemUoM> ItemUoMList { get; set; }

    }

    public partial class DTO_WMS_ItemUoM
    {
        public List<DTO_WMS_PriceListDetail> PriceDetailList { get; set; }
    }

    public partial class DTO_WMS_ItemUoMCount
    {
        public int IDUoM { get; set; }
        public string UoMName { get; set; }
        public decimal Quantity { get; set; }
        public decimal BaseQuantity { get; set; }
    }


}