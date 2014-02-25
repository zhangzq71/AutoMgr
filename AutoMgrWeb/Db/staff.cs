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
    
    public partial class staff
    {
        public staff()
        {
            this.inventory = new HashSet<inventory>();
            this.procure = new HashSet<procure>();
            this.repair = new HashSet<repair>();
            this.sale = new HashSet<sale>();
        }
    
        public int id { get; set; }
        public int branch_id { get; set; }
        public string name { get; set; }
        public string idcard_num { get; set; }
        public int department_id { get; set; }
        public int role_id { get; set; }
        public string iccard_num { get; set; }
        public bool deleted { get; set; }
        public System.DateTime inserted_time { get; set; }
    
        public virtual branch branch { get; set; }
        public virtual department department { get; set; }
        public virtual ICollection<inventory> inventory { get; set; }
        public virtual ICollection<procure> procure { get; set; }
        public virtual ICollection<repair> repair { get; set; }
        public virtual role role { get; set; }
        public virtual ICollection<sale> sale { get; set; }
    }
}