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
    
    public partial class vehicle
    {
        public vehicle()
        {
            this.repair = new HashSet<repair>();
        }
    
        public int id { get; set; }
        public string car_num { get; set; }
        public string engine_num { get; set; }
        public string frame_num { get; set; }
        public string brand { get; set; }
        public string model { get; set; }
        public int customer_id { get; set; }
    
        public virtual customer customer { get; set; }
        public virtual ICollection<repair> repair { get; set; }
    }
}