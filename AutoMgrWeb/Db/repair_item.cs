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
    
    public partial class repair_item
    {
        public repair_item()
        {
            this.repair_cate_item = new HashSet<repair_cate_item>();
            this.repair_item_detail = new HashSet<repair_item_detail>();
        }
    
        public int id { get; set; }
        public string name { get; set; }
        public Nullable<decimal> warking_hour { get; set; }
        public Nullable<decimal> price { get; set; }
    
        public virtual ICollection<repair_cate_item> repair_cate_item { get; set; }
        public virtual ICollection<repair_item_detail> repair_item_detail { get; set; }
    }
}
