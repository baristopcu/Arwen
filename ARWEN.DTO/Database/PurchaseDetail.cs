//------------------------------------------------------------------------------
// <auto-generated>
//    This code was generated from a template.
//
//    Manual changes to this file may cause unexpected behavior in your application.
//    Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace ARWEN.DTO.Database
{
    using System;
    using System.Collections.Generic;
    
    public partial class PurchaseDetail
    {
        public int PurchaseDetailID { get; set; }
        public int PurchaseID { get; set; }
        public int ProductID { get; set; }
        public int Amount { get; set; }
        public decimal Price { get; set; }
    
        public virtual Products Products { get; set; }
        public virtual Purchases Purchases { get; set; }
    }
}
