using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace API.Models
{
    public class SaleReportModel_
    {
       
        public int? IDBranch { get; set; }
        public string BranchName { get; set; }
        public int? IDSaleman { get; set; }
        public string FullName { get; set; }
        public int IDItem { get; set; }
        public string ItemCode { get; set; }
        public string ItemName { get; set; }
        public int IDUoM { get; set; }
        public string UoM { get; set; }
        public int ShippedQuantity { get; set; }
        public decimal TotalBeforeDiscount { get; set; }
        public decimal TotalDiscount { get; set; }
        public decimal TotalAfterDiscount { get; set; }
    }
}