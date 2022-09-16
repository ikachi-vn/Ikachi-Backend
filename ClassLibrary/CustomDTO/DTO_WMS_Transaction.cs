namespace DTOModel
{
    using System;
    using System.Collections.Generic;

    public partial class DTO_InputOutputInventory
    {
        public int? IDBranch { get; set; }
        public int? IDStorer { get; set; }
        public int? IDItem { get; set; }
        public string ItemCode { get; set; }
        public string ItemName { get; set; }

        public decimal OpenQuantity { get; set; }
        public decimal OpenCube { get; set; }
        public decimal OpenGrossWeight { get; set; }
        public decimal OpenNetWeight { get; set; }

        public decimal InputQuantity { get; set; }
        public decimal InputCube { get; set; }
        public decimal InputGrossWeight { get; set; }
        public decimal InputNetWeight { get; set; }

        public decimal OutputQuantity { get; set; }
        public decimal OutputCube { get; set; }
        public decimal OutputGrossWeight { get; set; }
        public decimal OutputNetWeight { get; set; }

        public decimal CloseQuantity { get; set; }
        public decimal CloseCube { get; set; }
        public decimal CloseGrossWeight { get; set; }
        public decimal CloseNetWeight { get; set; }
    }
}