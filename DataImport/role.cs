//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace DataImport
{
    using System;
    using System.Collections.Generic;
    
    public partial class role
    {
        public role()
        {
            this.staff = new HashSet<staff>();
        }
    
        public int id { get; set; }
        public string name { get; set; }
    
        public virtual ICollection<staff> staff { get; set; }
    }
}
