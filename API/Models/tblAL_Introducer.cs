//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace API.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class tblAL_Introducer
    {
        public int ID { get; set; }
        public string IntroducerName { get; set; }
        public string IntroducerCode { get; set; }
        public Nullable<byte> Sex { get; set; }
        public string Phone { get; set; }
        public string Address { get; set; }
        public string eMail { get; set; }
        public string BankAccount { get; set; }
        public string BankName { get; set; }
        public string Note { get; set; }
        public Nullable<bool> InActive { get; set; }
        public string CreateBy { get; set; }
        public Nullable<System.DateTime> CreateDate { get; set; }
    }
}