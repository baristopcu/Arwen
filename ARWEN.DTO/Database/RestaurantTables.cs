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
    
    public partial class RestaurantTables
    {
        public RestaurantTables()
        {
            this.OrderHeader = new HashSet<OrderHeader>();
            this.Reservation = new HashSet<Reservation>();
        }
    
        public string TableNo { get; set; }
        public byte Capacity { get; set; }
        public string Description { get; set; }
        public byte State { get; set; }
    
        public virtual ICollection<OrderHeader> OrderHeader { get; set; }
        public virtual ICollection<Reservation> Reservation { get; set; }
    }
}
