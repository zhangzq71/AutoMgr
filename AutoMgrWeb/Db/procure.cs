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
    
    public partial class procure
    {
        public procure()
        {
            this.procure_detail = new HashSet<procure_detail>();
            this.shelf_io = new HashSet<shelf_io>();
        }
    
        public int id { get; set; }
        public int branch_id { get; set; }
        public int stuff_id { get; set; }
        public int supplyer_id { get; set; }
        public int contact_id { get; set; }
        public System.DateTime date { get; set; }
        public bool closed { get; set; }
    
        public virtual branch branch { get; set; }
        public virtual contact contact { get; set; }
        public virtual ICollection<procure_detail> procure_detail { get; set; }
        public virtual staff staff { get; set; }
        public virtual supplyer supplyer { get; set; }
        public virtual ICollection<shelf_io> shelf_io { get; set; }
    }
}
