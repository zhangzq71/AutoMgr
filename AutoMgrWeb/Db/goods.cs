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
    
    public partial class goods
    {
        public goods()
        {
            this.barcode_goods = new HashSet<barcode_goods>();
            this.goods_alias = new HashSet<goods_alias>();
            this.goods_photo = new HashSet<goods_photo>();
            this.procure_detail = new HashSet<procure_detail>();
            this.repair_parts = new HashSet<repair_parts>();
            this.sale_detail = new HashSet<sale_detail>();
            this.shelf = new HashSet<shelf>();
        }
    
        public int id { get; set; }
        public string name { get; set; }
        public string unit { get; set; }
        public decimal price { get; set; }
        public string brand { get; set; }
        public string origin { get; set; }
        public string model { get; set; }
        public Nullable<decimal> limit { get; set; }
        public Nullable<float> length { get; set; }
        public Nullable<float> width { get; set; }
        public Nullable<float> height { get; set; }
        public Nullable<float> weight { get; set; }
        public string alias { get; set; }
    
        public virtual ICollection<barcode_goods> barcode_goods { get; set; }
        public virtual ICollection<goods_alias> goods_alias { get; set; }
        public virtual ICollection<goods_photo> goods_photo { get; set; }
        public virtual ICollection<procure_detail> procure_detail { get; set; }
        public virtual ICollection<repair_parts> repair_parts { get; set; }
        public virtual ICollection<sale_detail> sale_detail { get; set; }
        public virtual ICollection<shelf> shelf { get; set; }
    }
}
