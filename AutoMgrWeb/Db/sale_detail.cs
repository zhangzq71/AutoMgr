//------------------------------------------------------------------------------
// <auto-generated>
//    This code was generated from a template.
//
//    Manual changes to this file may cause unexpected behavior in your application.
//    Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace AutoMgrWeb.Db
{
    using System;
    using System.Collections.Generic;
    
    public partial class sale_detail
    {
        public int id { get; set; }
        public int sale_id { get; set; }
        public int goods_id { get; set; }
        public decimal price { get; set; }
        public decimal order_quantity { get; set; }
        public Nullable<decimal> stock_quantity { get; set; }
        public bool packet { get; set; }
        public Nullable<int> shelf_io_id { get; set; }
    
        public virtual goods goods { get; set; }
        public virtual sale sale { get; set; }
        public virtual shelf_io shelf_io { get; set; }
    }
}
