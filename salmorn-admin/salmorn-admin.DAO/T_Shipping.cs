//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace salmorn_admin.DAO
{
    using System;
    using System.Collections.Generic;
    
    public partial class T_Shipping
    {
        public int id { get; set; }
        public string trackingCode { get; set; }
        public int orderId { get; set; }
        public string orderCode { get; set; }
        public bool isActive { get; set; }
        public bool isShipping { get; set; }
        public Nullable<System.DateTime> shippingDate { get; set; }
        public string email { get; set; }
        public string tel { get; set; }
        public string firstName { get; set; }
        public string lastName { get; set; }
        public string address { get; set; }
        public string province { get; set; }
        public string zipCode { get; set; }
        public Nullable<System.DateTime> createDate { get; set; }
        public Nullable<int> createBy { get; set; }
        public Nullable<System.DateTime> updateDate { get; set; }
        public Nullable<int> updateBy { get; set; }
        public Nullable<int> printCoverQty { get; set; }
    
        public virtual T_Order T_Order { get; set; }
    }
}
