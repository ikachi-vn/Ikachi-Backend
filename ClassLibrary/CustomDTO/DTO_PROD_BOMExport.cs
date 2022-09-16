namespace DTOModel
{
    using System;
    using System.Collections.Generic;

    public partial class DTO_PROD_BOMExport {
        public int? GroupId { get; set; }
        public int? BOMId { get; set; }
        public int? StageId { get; set; }
        public int? COMId { get; set; }
        public string Type { get; set; }
        public int? IDItem { get; set; }
        public string Code { get; set; }
        public string Name { get; set; }
        public string UoMName { get; set; }
        public decimal? Quantity { get; set; }
        public decimal? AdditionalQuantity { get; set; }
        public decimal? UoMPrice { get; set; }
        public decimal? StdCode { get; set; }
        public decimal? TotalPrice { get; set; }
        public decimal? TotalStdCode { get; set; }
        
        public int HLevel { get; set; }

        //                               

    }
}
