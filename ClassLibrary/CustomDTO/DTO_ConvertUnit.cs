namespace DTOModel
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public partial class DTO_ConvertUnit
    {
        public int ItemId { get; set; }
        public int UoMId { get; set; }
        public string UoMName { get; set; }
        public decimal Quantity { get; set; }
        public decimal BaseQuantity { get; set; }
        public decimal Cube { get; set; }
        public decimal GrossWeight { get; set; }
        public decimal NetWeight { get; set; }
    }

}
