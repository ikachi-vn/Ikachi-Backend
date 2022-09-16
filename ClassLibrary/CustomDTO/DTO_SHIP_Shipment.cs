namespace DTOModel
{
    using System;
    using System.Collections.Generic;

    public partial class DTO_SHIP_Shipment
    {
        public List<int> OrderIds { get; set; }
        public List<int> DebtOrderIds { get; set; }

        public DTO_SYS_Status Status { get; set; }

        public string Vehicle { get; set; }

        public List<DTO_SHIP_ShipmentDetail> ShipmentOrder { get; set; }

        public List<DTO_SHIP_ShipmentDebt> ShipmentDebt { get; set; }

    }


    public partial class DTO_SHIP_ShipmentDetail
    {
        //DTO_SALE_Order item
        public DTO_SALE_Order SaleOrder { get; set; }

        public DTO_SYS_Status Status { get; set; }
    }

    public partial class DTO_SHIP_ShipmentDebt
    {
        //DTO_SALE_Order item
        public DTO_SALE_Order SaleOrder { get; set; }
        public DTO_SYS_Status Status { get; set; }
    }

}